#Region "Imports"
Imports System.Diagnostics
Imports System.Threading
Imports System.IO
Imports System.Text
Imports System.IO.Ports
Imports System.ComponentModel
Imports System.Windows.Forms.DataVisualization.Charting
Imports System.IO.Compression
Imports System.Drawing.Imaging
Imports System.Xml
Imports DarkUI.Controls
Imports System.Runtime.InteropServices
#End Region
Public Class Form1
    'ToDo list
    'BaudRates de Arduino, incluir todos los que aparezcan en el IDE oficial
    'Ver > Modo captura
    'Ver > Modo Simulación
    'Ver > Modo Todo
    '
    'Notas de texto en chart simula
    '
    'Corregir el tiempo mostrado en la barra de estado Timer.ticks
    'Si trabajamos en milisegundos que se muestre correctamente en el gráfico
    '
#Region "Variables"
    Dim datos_puerto As String
    Dim datos_split() As String
    Dim series As List(Of Double) = New List(Of Double)
    Dim Tiempo As Double = 0.0
    Dim contador As Double = 0.0
    Dim fila As Integer = 0
    Dim export As String = Application.StartupPath + "\Export\"
    Dim proyecto As String = ""
    Dim nombreproyecto As String = ""
    Dim datosOK As Boolean = False
    Dim annsel As Integer
    Dim tbl As New DataTable("miTabla")
    Dim culture As System.Globalization.CultureInfo = System.Globalization.CultureInfo.CurrentCulture
    Dim decimalSeparator As String = Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator
    Dim ToolTipProvider As New ToolTip
    'Simula
    Dim result_tnow() As Single
    Dim result_SP() As Single
    Dim result_PV() As Single
    Dim result_OP() As Single
    Dim result_DV() As Single
    'Dim cont_simula As Integer = 1
    'Dim mostrarsimant As Boolean = False
    'Dim kc_ant_simula As Single = 0
    'Dim Ti_ant_simula As Single = 0
    'Dim Td_ant_simula As Single = 0
    Dim Kc_simula As Single = 0
    Dim Ti_simula As Single = 0
    Dim Td_simula As Single = 0
    Dim metodo As String = ""
    Dim metodoman As String = ""
    Dim sobreejey As Boolean = False
    Dim sobreejey2 As Boolean = False
    Dim IAE_sim As Single = 0
    'Dim mycolor As Color = Color.FromArgb(Rnd.Next(0, 150), Rnd.Next(0, 150), Rnd.Next(0, 150))
    Dim colors() As Color = {Color.Blue, Color.Fuchsia, Color.Yellow, Color.BlueViolet, Color.Brown, Color.DimGray, Color.DarkGoldenrod, Color.DarkCyan,
                             Color.Peru, Color.Red, Color.RoyalBlue, Color.Bisque}
#End Region
#Region "Funciones"
    Sub GetSerialPortNames()
        Cbo_comports.Items.Clear()
        For Each sp As String In My.Computer.Ports.SerialPortNames
            Cbo_comports.Items.Add(sp)
        Next
    End Sub
    Public Event ScanDataRecieved(ByVal data As String)
    WithEvents comPort As SerialPort
    Public Sub Connect()
        'Try
        'comPort = My.Computer.Ports.OpenSerialPort(Cbo_comports.Text, Cbo_velocidad_2.Text, System.IO.Ports.Parity.None, 8, System.IO.Ports.StopBits.One)
        'Catch
        'End Try
        Try
            comPort = My.Computer.Ports.OpenSerialPort(Cbo_comports.Text, Cbo_velocidad_2.Text, System.IO.Ports.Parity.None, 8, System.IO.Ports.StopBits.One)
            comPort.DiscardInBuffer()
            comPort.Close()
            With comPort
                '.BaudRate = Cbo_velocidad_2.Text
                '.PortName = Cbo_comports.Text
                '.DataBits = 8
                '.Parity = System.IO.Ports.Parity.None
                '.StopBits = IO.Ports.StopBits.One
                .ReadTimeout = 500 '100
                .WriteTimeout = 500
                .DiscardNull = True
                .ReadBufferSize = 16384
            End With

            If Not comPort.IsOpen Then
                comPort.Open()
            End If
        Catch ex As Exception
            IO.File.AppendAllText(Application.StartupPath & "\ACP_LOG.txt", String.Format("{0}[{1}]{2}", Environment.NewLine, DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"), ex.ToString()))
        End Try
    End Sub
    Public Sub Disconnect()
        Try
            If comPort IsNot Nothing AndAlso comPort.IsOpen Then
                comPort.Close()
            End If
        Catch ex As Exception
            comPort.Close()
        End Try
    End Sub
    Private Sub comPort_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles comPort.DataReceived
        Try
            'Thread.Sleep(10)
            datos_puerto = comPort.ReadLine()
            Actualizar()
        Catch ex As Exception
            IO.File.AppendAllText(Application.StartupPath & "\ACP_LOG.txt", String.Format("{0}[{1}]{2}", Environment.NewLine, DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"), ex.ToString()))
        End Try
    End Sub
    Public Sub Actualizar()
        Try
            'datos_puerto = comPort.ReadLine()
            If datos_puerto.StartsWith(txt_inicio.Text) Then
                datos_puerto = datos_puerto.TrimStart(txt_inicio.Text)  'Quito el caracter de inicio
                datos_puerto = datos_puerto.Replace("#", "")            'Quito repeticiones para evitar tramas corruptas
                datos_split = datos_puerto.Split(txt_separador.Text)    'Separo los datos
                If datos_split.Count = Num_vars.Value Then              'Compruebo que recibimos el número correcto de datos
                    For i = 0 To series.Count - 1
                        Application.DoEvents()
                        series(i) = CDbl(datos_split(i).Replace(".", ","))
                    Next
                    datosOK = True
                End If
            Else
                'Txt_datos.Text = String.Empty
                datosOK = False
            End If
        Catch ex As Exception
            datosOK = False
            'Console.WriteLine("Actualizar | " & ex.ToString)
            IO.File.AppendAllText(Application.StartupPath & "\ACP_LOG.txt", String.Format("{0}[{1}]{2}", Environment.NewLine, DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"), ex.ToString()))
        End Try
    End Sub
    Sub GuardarConfig(ByVal archivo As String)
        Try
            Dim oSW As New StreamWriter(archivo)
            Dim Linea As String = "<?xml version='1.0' encoding='UTF-8'?>" & vbNewLine & vbTab & "<ACP>" & vbNewLine
            Linea &= vbTab & vbTab & "<" & "Config" & ">" & vbNewLine
            Linea &= vbTab & vbTab & vbTab & "<config id='0' variables='" & Num_vars.Value & "' delay='" & Num_delay.Value & "' cseparador='" & txt_separador.Text & "' cinicio='" & txt_inicio.Text & "' ventana='" & num_ventana.Value & "' />" & vbNewLine
            Linea &= vbTab & vbTab & vbTab & "<config id='1' K='" & Txt_K.Text.Trim & "' To='" & Txt_To.Text.Trim & "' Tp='" & Txt_Tp.Text & "' Tf='" & Txt_Tf.Text & "' />" & vbNewLine
            Linea &= vbTab & vbTab & vbTab & "<config id='2' PVSup='" & Txt_PVrngSup.Text.Trim & "' PVInf='" & Txt_PVrngInf.Text.Trim & "' Kc='" & Txt_Kc.Text & "' Ti='" & Txt_Ti.Text & "' Td='" & Txt_Td.Text & "' />" & vbNewLine
            Linea &= vbTab & vbTab & vbTab & "<config id='3' Ts='" & Txt_muestreo.Text.Trim & "' TFinal='" & Txt_Tfinal.Text.Trim & "' PVIni='" & Txt_PVini.Text & "' OPIni='" & Txt_OPini.Text & "' CargaIni='" & Txt_CargaIni.Text & "' dSP='" & Txt_DSP.Text & "' dCarga='" & Txt_Dcarga.Text & "' OPLimSup='" & Txt_OPLimSup.Text & "' OPLimInf='" & Txt_OPLimInf.Text & "' />" & vbNewLine
            Linea &= vbTab & vbTab & "</" & "Config" & ">" & vbNewLine
            Linea = Linea & vbTab & "</ACP>"
            oSW.WriteLine(Linea)
            oSW.Flush()
            oSW.Close()
            oSW.Dispose()
        Catch ex As Exception
            Console.WriteLine(ex.ToString)
        End Try
    End Sub
    Sub LeerConfig(ByVal archivo As String)
        Try
            Dim doc As XmlDocument = New XmlDocument
            Dim sr As New StreamReader(archivo, System.Text.Encoding.GetEncoding("UTF-8"))
            doc.Load(sr)
            For Each node As XmlNode In doc.DocumentElement
                For i = 0 To node.ChildNodes.Count - 1
                    Application.DoEvents()
                    'Config Datos
                    If Not node.ChildNodes.ItemOf(i).Attributes.GetNamedItem("variables") Is Nothing Then
                        Num_vars.Value = node.ChildNodes.ItemOf(i).Attributes.GetNamedItem("variables").Value
                    End If
                    If Not node.ChildNodes.ItemOf(i).Attributes.GetNamedItem("delay") Is Nothing Then
                        Num_delay.Value = node.ChildNodes.ItemOf(i).Attributes.GetNamedItem("delay").Value
                    End If
                    If Not node.ChildNodes.ItemOf(i).Attributes.GetNamedItem("cseparador") Is Nothing Then
                        txt_separador.Text = node.ChildNodes.ItemOf(i).Attributes.GetNamedItem("cseparador").Value
                    End If
                    If Not node.ChildNodes.ItemOf(i).Attributes.GetNamedItem("cinicio") Is Nothing Then
                        txt_inicio.Text = node.ChildNodes.ItemOf(i).Attributes.GetNamedItem("cinicio").Value
                    End If
                    If Not node.ChildNodes.ItemOf(i).Attributes.GetNamedItem("ventana") Is Nothing Then
                        num_ventana.Value = node.ChildNodes.ItemOf(i).Attributes.GetNamedItem("ventana").Value
                    End If
                    'Datos Simulación - Ajuste
                    If Not node.ChildNodes.ItemOf(i).Attributes.GetNamedItem("K") Is Nothing Then
                        Txt_K.Text = node.ChildNodes.ItemOf(i).Attributes.GetNamedItem("K").Value
                    End If
                    If Not node.ChildNodes.ItemOf(i).Attributes.GetNamedItem("To") Is Nothing Then
                        Txt_To.Text = node.ChildNodes.ItemOf(i).Attributes.GetNamedItem("To").Value
                    End If
                    If Not node.ChildNodes.ItemOf(i).Attributes.GetNamedItem("Tp") Is Nothing Then
                        Txt_Tp.Text = node.ChildNodes.ItemOf(i).Attributes.GetNamedItem("Tp").Value
                    End If
                    If Not node.ChildNodes.ItemOf(i).Attributes.GetNamedItem("Tf") Is Nothing Then
                        Txt_Tf.Text = node.ChildNodes.ItemOf(i).Attributes.GetNamedItem("Tf").Value
                    End If
                    'Datos Simulación - Controlador
                    If Not node.ChildNodes.ItemOf(i).Attributes.GetNamedItem("PVSup") Is Nothing Then
                        Txt_PVrngSup.Text = node.ChildNodes.ItemOf(i).Attributes.GetNamedItem("PVSup").Value
                    End If
                    If Not node.ChildNodes.ItemOf(i).Attributes.GetNamedItem("PVInf") Is Nothing Then
                        Txt_PVrngInf.Text = node.ChildNodes.ItemOf(i).Attributes.GetNamedItem("PVInf").Value
                    End If
                    If Not node.ChildNodes.ItemOf(i).Attributes.GetNamedItem("Kc") Is Nothing Then
                        Txt_Kc.Text = node.ChildNodes.ItemOf(i).Attributes.GetNamedItem("Kc").Value
                    End If
                    If Not node.ChildNodes.ItemOf(i).Attributes.GetNamedItem("Ti") Is Nothing Then
                        Txt_Ti.Text = node.ChildNodes.ItemOf(i).Attributes.GetNamedItem("Ti").Value
                    End If
                    If Not node.ChildNodes.ItemOf(i).Attributes.GetNamedItem("Td") Is Nothing Then
                        Txt_Td.Text = node.ChildNodes.ItemOf(i).Attributes.GetNamedItem("Td").Value
                    End If
                    'Datos Simulación - simulación
                    If Not node.ChildNodes.ItemOf(i).Attributes.GetNamedItem("Ts") Is Nothing Then
                        Txt_muestreo.Text = node.ChildNodes.ItemOf(i).Attributes.GetNamedItem("Ts").Value
                    End If
                    If Not node.ChildNodes.ItemOf(i).Attributes.GetNamedItem("TFinal") Is Nothing Then
                        Txt_Tfinal.Text = node.ChildNodes.ItemOf(i).Attributes.GetNamedItem("TFinal").Value
                    End If
                    If Not node.ChildNodes.ItemOf(i).Attributes.GetNamedItem("PVIni") Is Nothing Then
                        Txt_PVini.Text = node.ChildNodes.ItemOf(i).Attributes.GetNamedItem("PVIni").Value
                    End If
                    If Not node.ChildNodes.ItemOf(i).Attributes.GetNamedItem("OPIni") Is Nothing Then
                        Txt_OPini.Text = node.ChildNodes.ItemOf(i).Attributes.GetNamedItem("OPIni").Value
                    End If
                    If Not node.ChildNodes.ItemOf(i).Attributes.GetNamedItem("CargaIni") Is Nothing Then
                        Txt_CargaIni.Text = node.ChildNodes.ItemOf(i).Attributes.GetNamedItem("CargaIni").Value
                    End If
                    If Not node.ChildNodes.ItemOf(i).Attributes.GetNamedItem("dSP") Is Nothing Then
                        Txt_DSP.Text = node.ChildNodes.ItemOf(i).Attributes.GetNamedItem("dSP").Value
                    End If
                    If Not node.ChildNodes.ItemOf(i).Attributes.GetNamedItem("dCarga") Is Nothing Then
                        Txt_Dcarga.Text = node.ChildNodes.ItemOf(i).Attributes.GetNamedItem("dCarga").Value
                    End If
                    If Not node.ChildNodes.ItemOf(i).Attributes.GetNamedItem("OPLimSup") Is Nothing Then
                        Txt_OPLimSup.Text = node.ChildNodes.ItemOf(i).Attributes.GetNamedItem("OPLimSup").Value
                    End If
                    If Not node.ChildNodes.ItemOf(i).Attributes.GetNamedItem("OPLimInf") Is Nothing Then
                        Txt_OPLimInf.Text = node.ChildNodes.ItemOf(i).Attributes.GetNamedItem("OPLimInf").Value
                    End If
                Next
                'Console.WriteLine(node.ChildNodes.Count)
            Next
        Catch ex As Exception
            Console.WriteLine(ex.ToString)
        End Try
    End Sub
    Public Sub MakeDoubleBuffered(ByVal chart As Chart)
        Try
            Dim dgvType As Type = chart.[GetType]()
            Dim pis As Reflection.PropertyInfo = dgvType.GetProperty("DoubleBuffered", Reflection.BindingFlags.Instance Or Reflection.BindingFlags.NonPublic)
            pis.SetValue(chart, True, Nothing)
        Catch ex As Exception
            IO.File.AppendAllText(Application.StartupPath & "\ACP_LOG.txt", String.Format("{0}[{1}]{2}", Environment.NewLine, DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"), ex.ToString()))
        End Try
    End Sub
    Public Sub MakeGridViewDoubleBuffered(ByVal dgv As DataGridView)
        Try
            Dim dgvType As Type = dgv.[GetType]()
            Dim pis As Reflection.PropertyInfo = dgvType.GetProperty("DoubleBuffered", Reflection.BindingFlags.Instance Or Reflection.BindingFlags.NonPublic)
            pis.SetValue(dgv, True, Nothing)
        Catch ex As Exception
            IO.File.AppendAllText(Application.StartupPath & "\ACP_LOG.txt", String.Format("{0}[{1}]{2}", Environment.NewLine, DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"), ex.ToString()))
        End Try
    End Sub
    Sub Guardar()
        'DGV
        tbl.WriteXml(proyecto & "\ACP_dgv.txt")
        'TXT
        Txt_datos.SaveFile(proyecto & "\ACP_txt.txt", RichTextBoxStreamType.PlainText)
        'Chart
        Dim myStream As New System.IO.MemoryStream()
        Chart1.Serializer.Save(myStream)
        File.WriteAllBytes(proyecto & "\ACP_chart.bin", myStream.ToArray())
        Chart1.SaveImage(proyecto + "\ACP_" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss") + ".png", ChartImageFormat.Png)
        'Config
        GuardarConfig(proyecto & "\ACP_config.txt")
        '
        Lbl_info.Text = "Proyecto guardado correctamente. " & DateTime.Now
    End Sub
    Sub Simular()
        Try
            Dim imax As Integer
            Dim Ts As Single
            Dim PVEUHI As Single
            Dim PVEULO As Single
            Dim PVIni As Single
            Dim OPIni As Single
            '*************************************************
            'variables para el calculo de la respuesta escalon
            '*************************************************
            Dim Kcalc As Single
            Dim KcalcEU As Single
            Dim Tocalc As Single
            Dim Tpcalc As Single
            Dim a1 As Single
            Dim a2 As Single
            Dim SP As Single
            Dim SPp As Single
            Dim DV As Single
            Dim PV As Single
            Dim PV1 As Single
            Dim PV2 As Single
            Dim dPV As Single
            Dim dPV1 As Single
            Dim PVp As Single
            Dim myError As Single
            Dim myError1 As Single
            Dim myError2 As Single
            Dim i As Integer
            Dim j As Integer
            Dim tnow As Single
            Dim factor As Single
            Dim OP As Single
            Dim OP1 As Single
            Dim dOP As Single
            Dim nDelays As Long
            Dim Kc As Single
            Dim Ti As Single
            Dim Td As Single
            Dim Eq As String
            Dim strTipoModelo As String
            Dim strInc As String
            Dim WindUp As String
            Dim Tfinal As Single
            Dim DVIni As Single
            Dim dSP As Single
            Dim dCarga As Single
            Dim Ik As Single
            Dim Ik1 As Single
            Dim KEUPor As Single
            Dim KPorEU As Single
            Dim TProp As Single
            Dim TInte As Single
            Dim TDer As Single
            Dim dProp As Single
            Dim dInte As Single
            Dim dDer As Single
            Dim Saturado As Boolean
            Dim OPHILim As Single
            Dim OPLOLim As Single
            Dim dPVPred() As Double
            Dim dblCoeffX() As Double
            Dim dblCoeffY() As Double
            Dim nCoeff As Integer
            Dim intHP As Integer
            Dim intPerMuest As Integer
            Dim dteIniciosim As Date = Nothing
            Dim dteFinalsim As Date = Nothing
            Dim dteIniciodgv As Date = Nothing
            Dim dteFinaldgv As Date = Nothing
            Dim dteIniciochart As Date = Nothing
            Dim dteFinalchart As Date = Nothing
            '*******************************
            'Lee parametros de la simulacion
            '*******************************
            PVEUHI = CSng(Txt_PVrngSup.Text)
            PVEULO = CSng(Txt_PVrngInf.Text)
            '
            'kc_ant_simula = Kc_simula
            'Ti_ant_simula = Ti_simula
            'Td_ant_simula = Td_simula
            Kc_simula = CSng(Txt_Kc.Text)
            Ti_simula = CSng(Txt_Ti.Text)
            Td_simula = CSng(Txt_Td.Text)
            '
            Kc = CSng(Txt_Kc.Text)
            Ti = CSng(Txt_Ti.Text)
            If Ti = 0 Then Ti = 9999 'Con 0 no computa bien. 9999 es lo mismo que anular la integral.
            Td = CSng(Txt_Td.Text)
            '
            If Cbo_eq.SelectedIndex <> -1 Then Eq = Cbo_eq.Text Else Eq = "PID"
            'Eq = "PID" 'PI-D, I-PD
            strInc = "NO" 'SI, NO
            WindUp = "SI" ' SI, NO
            '
            Kcalc = CSng(Txt_K.Text)
            KcalcEU = CSng(Txt_K.Text) * (PVEUHI - PVEULO) / 100 'para la simulación se usa en unidades de ingeniería aunque se muestre en %/%
            Tocalc = CSng(Txt_To.Text)
            Tpcalc = CSng(Txt_Tp.Text)
            '
            strTipoModelo = "P.Orden"
            '
            'Tunit = cbo_Tunit_simula.SelectedItem.ToString
            Ts = CSng(Txt_muestreo.Text)
            Tfinal = CSng(Txt_Tfinal.Text)
            PVIni = CSng(Txt_PVini.Text)
            OPIni = CSng(Txt_OPini.Text)
            DVIni = CSng(Txt_CargaIni.Text)
            dSP = CSng(Txt_DSP.Text)
            dCarga = CSng(Txt_Dcarga.Text)
            OPHILim = CSng(Txt_OPLimSup.Text)
            OPLOLim = CSng(Txt_OPLimInf.Text)
            '
            '******************
            'Calculos iniciales
            '******************
            factor = 1 ' 1 para segundos, 60 para minutos
            KEUPor = 100 / (PVEUHI - PVEULO)
            KPorEU = 1 / KEUPor
            '***************************************
            'modelo de primer orden con retardo puro
            '***************************************
            a1 = Ts * KcalcEU / (Tpcalc * factor + Ts) 'a1 = Ts * Kcalc / (Tpcalc * factor + Ts)
            a2 = Tpcalc * factor / (Tpcalc * factor + Ts)
            '**********************************
            'numero de intervalos de simulacion
            '**********************************
            imax = Int(Tfinal * factor / Ts)
            'imax_ant_simula = imax
            '******************************************************
            'numero de retardos necesarios para incorporar el delay
            '******************************************************
            nDelays = Int(Tocalc * factor / Ts) + 1 ' se suma 1 por el Z-H
            '********************
            'inicializa vector OP
            '********************
            Dim MV() As Single = Enumerable.Repeat(OPIni, nDelays).ToArray
            '**************************************************************
            'lee numero de coeficientes interpolados al periodo de muestreo
            '**************************************************************
            ReDim dblCoeffX(nCoeff + 1)
            ReDim dblCoeffY(nCoeff + 1)
            '****************
            'Leo coeficientes
            '****************
            '
            For i = 1 To nCoeff + 1
                dblCoeffX(i) = i 'CDbl(dgv_ensayo.Rows(i).Cells(1).Value) 'TIEMPO
                dblCoeffY(i) = i 'CDbl(dgv_ensayo.Rows(i).Cells(2).Value) 'PV
                'pbar.Value = i
                Application.DoEvents()
            Next i
            '
            '*****************************************************
            'genera la matriz AX con los coeficientes interpolados
            '*****************************************************
            intHP = nCoeff * Int(intPerMuest / Ts)
            Dim AX(intHP, 2) As Double
            ReDim dPVPred(0 To intHP)
            'lbl_seconds.Text = "Generando matriz de coeficientes interpolados"
            For i = 1 To intHP
                AX(i, 2) = Interp1(dblCoeffX, dblCoeffY, i * Ts / 60)
                AX(i, 1) = i * Ts / 60
                dPVPred(i) = 0 'inicializa el vector de predicciones
                Application.DoEvents()
            Next i
            '********************
            'inicializa escalares
            '********************
            PV = PVIni
            PV1 = PVIni
            PV2 = PVIni
            dPV1 = 0
            dPV = 0
            SP = PVIni
            DV = DVIni
            Ik = OPIni * (Ti * factor) / Kc
            Ik1 = Ik
            myError1 = 0
            myError2 = 0
            OP = OPIni
            OP1 = OPIni
            '**********************
            'comienza la simulacion
            '**********************

            txtdebug.Visible = False '4 DEBUG******************************************************************************************

            dteIniciosim = DateTime.Now
            Me.Cursor = Cursors.WaitCursor
            '
            ReDim result_tnow(imax)
            ReDim result_SP(imax)
            ReDim result_PV(imax)
            ReDim result_OP(imax)
            ReDim result_DV(imax)
            '
            Array.Clear(result_tnow, 0, result_tnow.Length)
            Array.Clear(result_SP, 0, result_SP.Length)
            Array.Clear(result_PV, 0, result_PV.Length)
            Array.Clear(result_OP, 0, result_OP.Length)
            Array.Clear(result_DV, 0, result_DV.Length)
            '
            For i = 0 To imax
                'calcula el tiempo actual
                tnow = i * Ts / factor
                'calcula valores actuales de SP,Carga
                'If CInt(Txt_DSP.Text) > 0 Then
                '    If i > Int(imax / 20) Then SP = PVIni + dSP
                'End If
                'If CInt(Txt_DSP.Text) < 0 Then
                '    If i > Int(imax / 20) Then SP = PVIni - CInt(Txt_DSP.Text)
                'End If
                If i > Int(imax / 20) Then SP = PVIni + dSP 'original
                If i > Int(imax / 2) Then DV = DVIni + dCarga
                '********************************
                'convierte a valores porcentuales
                '********************************
                SPp = KEUPor * (SP - PVEULO)
                PVp = KEUPor * (PV - PVEULO)
                '*************
                'calcula errorw
                '*************
                If CInt(Txt_DSP.Text) > 0 Then myError = SPp - PVp
                If CInt(Txt_DSP.Text) < 0 Then myError = PVp - SPp
                'myError = SPp - PVp 'original
                '***************************
                'calcula accion proporcional
                '***************************
                If Eq = "PID" Then TProp = Kc * myError
                If Eq = "PI-D" Then TProp = Kc * myError
                If Eq = "I-PD" Then TProp = -Kc * (PV - PVIni) * KEUPor
                '
                If Eq = "PID" Then dProp = Kc * (myError - myError1)
                If Eq = "PI-D" Then dProp = Kc * (myError - myError1)
                If Eq = "PI-D" Then dProp = Kc * (myError - myError1)
                If Eq = "I-PD" Then dProp = -Kc * (PV - PV1) * KEUPor
                '***********************
                'calcula accion integral
                '***********************
                Ik = Ik1 + Ts / 2 * (myError + myError1)

                'txtdebug.Text &= (i & " Ik: " & Ik & " myError: " & myError & " myError1: " & myError1 & " PVp: " & PVp) & vbNewLine

                TInte = Ik * Kc / (Ti * factor)
                dInte = Kc * Ts / Ti / factor * myError
                '*************************
                'calcula accion derivariva
                '*************************
                If Eq = "PID" Then TDer = Kc * Td * factor * (myError - myError1) / Ts
                If Eq = "PI-D" Then TDer = -(Kc * Td * factor * KEUPor / Ts * (PV - PV1))
                If Eq = "I-PD" Then TDer = -(Kc * Td * factor * KEUPor / Ts * (PV - PV1))
                '
                If Eq = "PID" Then dDer = Kc * Td * factor / Ts * (myError - 2 * myError1 + myError2)
                If Eq = "PI-D" Then dDer = -Kc * Td * factor * KEUPor / Ts * (PV - 2 * PV1 + PV2)
                If Eq = "I-PD" Then dDer = -Kc * Td * factor * KEUPor / Ts * (PV - 2 * PV1 + PV2)
                '*************************
                'calcula el valor de la OP
                '*************************
                If strInc = "SI" Then
                    dOP = dProp + dInte + dDer
                    OP = OP1 + dOP
                Else
                    OP = TProp + TInte + TDer
                End If
                'txtdebug.Text &= (i & " Ik: " & Ik & " TProp: " & TProp & " TInte: " & TInte) & vbNewLine
                Saturado = False
                '***************
                'protege limites
                '***************
                If OP > OPHILim Then
                    OP = OPHILim
                    Saturado = True
                End If
                If OP < OPLOLim Then
                    OP = OPLOLim
                    Saturado = True
                End If
                '******************
                'escribe resultados
                '******************
                result_tnow(i) = tnow
                result_SP(i) = SP
                result_PV(i) = PV
                result_OP(i) = OP
                result_DV(i) = DV
                '***********************************
                'sumar a la OP el efecto de la carga
                '***********************************
                MV(0) = OP + DV
                '***********************************
                'actualiza para la proxima ejecucion
                '***********************************
                myError2 = myError1
                myError1 = myError
                PV2 = PV1
                PV1 = PV
                If CInt(Txt_DSP.Text) > 0 Then dPV1 = PV - PVIni
                If CInt(Txt_DSP.Text) < 0 Then dPV1 = PVIni - PV
                'dPV1 = PV - PVIni 'original
                OP1 = OP
                '*****************
                'proteccion windup
                '*****************
                If WindUp = "SI" Then
                    If Not (Saturado) Then Ik1 = Ik
                Else
                    Ik1 = Ik
                End If
                '******************
                'salida del proceso
                '******************
                If strTipoModelo = "P.Orden" Then
                    'PV = (a1 * (MV(nDelays - 1) - OPIni) + a2 * dPV1) + PVIni 'Original
                    If CInt(Txt_DSP.Text) > 0 Then PV = (a1 * (MV(nDelays - 1) - OPIni) + a2 * dPV1) + PVIni
                    If CInt(Txt_DSP.Text) < 0 Then PV = PVIni - (a1 * (MV(nDelays - 1) - OPIni) + a2 * dPV1)
                End If
                'Console.WriteLine("Error: " & myError & " SP: " & SP & " PV: " & PV & " dPV: " & dPV1)
                '********************************
                'desliza el vector de MV, dpvpred
                '********************************
                MV = RShift(MV)
                Application.DoEvents()
            Next i
            'Console.WriteLine(MV)
            'Console.WriteLine(result_SP)
            'Console.WriteLine(result_PV)
            'Console.WriteLine(result_DV)
            dteFinalsim = DateTime.Now
            '******************
            'Relleno el gráfico
            '******************
            '
            dteIniciochart = DateTime.Now
            Me.Cursor = Cursors.WaitCursor
            '
            'Chart_simula.ChartAreas.Add("Simula")
            Chart_simula.Series.Clear()
            Chart_simula.Legends.Clear()
            Chart_simula.Legends.Add("")
            Chart_simula.Legends(0).ForeColor = Color.Gainsboro
            Chart_simula.Titles.Clear()
            Chart_simula.Titles.Add("Simulación en Lazo Cerrado")
            Chart_simula.Titles(0).Font = New Font("Microsoft Sans Serif", 14, FontStyle.Bold)
            Chart_simula.Titles(0).ForeColor = Color.Gainsboro
            If metodoman = "" Then Chart_simula.Titles.Add(metodo) Else Chart_simula.Titles.Add(metodoman)
            Chart_simula.Titles(1).Font = New Font("Microsoft Sans Serif", 10, FontStyle.Regular)
            Chart_simula.Titles(1).ForeColor = Color.Gainsboro
            '
            Chart_simula.Series.Add("SP") 'sp
            Chart_simula.Series.Add("PV") 'pv
            Chart_simula.Series.Add("OP") 'op
            Chart_simula.Series.Add("CARGA") 'Carga
            '
            Chart_simula.Legends(0).Docking = Docking.Top
            Chart_simula.Legends(0).Alignment = StringAlignment.Center
            Chart_simula.Legends(0).BackColor = Color.FromArgb(60, 63, 65)
            '
            For i = 0 To 3
                Chart_simula.Series(i).ChartType = DataVisualization.Charting.SeriesChartType.FastLine
                Chart_simula.Series(i).IsXValueIndexed = False
                Chart_simula.Series(i).ToolTip = "#SERIESNAME\nValor: #VALY{f2}\nSegundo #VALX{f1}\nMin: #MIN{f2}\nMax: #MAX{f2}\nMedia: #AVG{D0}"
                Application.DoEvents()
            Next i
            Dim stepgeneral As Integer = 0
            If CInt(Txt_Tfinal.Text.Trim) < 300 Then stepgeneral = 1 Else stepgeneral = CInt(imax * 0.01)
            Dim stepaux As Integer = 0
            If CInt(Txt_Tfinal.Text.Trim) < 300 Then stepaux = 1 Else stepaux = CInt(imax * 0.1)
            IAE_sim = 0
            For j = 1 To imax Step stepgeneral
                Chart_simula.Series(0).Points.AddXY(result_tnow(j), result_SP(j))
                Chart_simula.Series(1).Points.AddXY(result_tnow(j), result_PV(j))
                Chart_simula.Series(2).Points.AddXY(result_tnow(j), result_OP(j))
                Chart_simula.Series(3).Points.AddXY(result_tnow(j), result_DV(j))
                IAE_sim += Math.Abs(result_SP(j) - result_PV(j)) 'SP-PV
            Next j
            'If metodo = "" Then
            '    Chart_simula.Titles(1).Text = "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & " (IAE: " & Txt_Td.Text & IAE_sim.ToString("####0.00") & ")"
            'Else
            Chart_simula.Titles.Add("IAE: " & IAE_sim.ToString("####0.00"))
            Chart_simula.Titles(2).Font = New Font("Microsoft Sans Serif", 8, FontStyle.Regular)
            Chart_simula.Titles(2).ForeColor = Color.Gainsboro
            'Chart_simula.Titles(2).Text = metodo & " (IAE: " & IAE_sim.ToString("####0.00") & ")"
            'End If
            '
            Chart_simula.Series(0).Color = Color.Blue
            Chart_simula.Series(1).Color = Color.Fuchsia
            Chart_simula.Series(2).Color = Color.Yellow
            Chart_simula.Series(3).Color = Color.Cyan
            '
            Chart_simula.Series(0).YAxisType = AxisType.Primary     'SP
            Chart_simula.Series(1).YAxisType = AxisType.Primary     'PV
            Chart_simula.Series(2).YAxisType = AxisType.Secondary   'OP
            Chart_simula.Series(3).YAxisType = AxisType.Secondary   'CARGA
            '
            Chart_simula.Series(0).BorderWidth = 2
            Chart_simula.Series(1).BorderWidth = 2
            Chart_simula.Series(2).BorderWidth = 2
            Chart_simula.Series(3).BorderWidth = 2
            '
            Chart_simula.ChartAreas(0).AxisY.Minimum = Double.NaN
            Chart_simula.ChartAreas(0).AxisY.Maximum = Double.NaN
            Chart_simula.ChartAreas(0).AxisY2.Minimum = Double.NaN
            Chart_simula.ChartAreas(0).AxisY2.Maximum = Double.NaN
            Chart_simula.ChartAreas(0).RecalculateAxesScale()
            Chart_simula.ChartAreas(0).AxisX.ScaleView.Zoomable = True
            Chart_simula.ChartAreas(0).AxisY.ScaleView.Zoomable = True
            Chart_simula.ChartAreas(0).AxisY2.ScaleView.Zoomable = True
            Chart_simula.ChartAreas(0).CursorX.IsUserSelectionEnabled = True
            Chart_simula.ChartAreas(0).CursorY.IsUserSelectionEnabled = True
            Chart_simula.ChartAreas(0).CursorX.AutoScroll = True
            Chart_simula.ChartAreas(0).CursorY.AutoScroll = True
            Chart_simula.ChartAreas(0).AxisY.IsStartedFromZero = False
            Chart_simula.ChartAreas(0).AxisX.IsStartedFromZero = True
            Chart_simula.ChartAreas(0).AxisX.LabelStyle.Format = "#.#"
            Chart_simula.ChartAreas(0).AxisX.Title = "Tiempo (segundos)"
            Chart_simula.ChartAreas(0).AxisX.Minimum = 0
            'Chart_simula.ChartAreas(0).AxisX.Maximum = Math.Round(CInt(Txt_Tfinal.Text) + 5, 0)
            'Chart_simula.Visible = True
            Chart_simula.ChartAreas(0).RecalculateAxesScale()
            '
            'Dim IAE As Single
            'For i = 0 To Chart_simula.Series(0).Points.Count - 1
            '    IAE =
            'Next
            '
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            'MsgBox(ex.ToString)
            'MsgBox("Ocurrió un error al generar la simulación. Comprueba bien todos los campos.", vbExclamation + vbOKOnly, "Error al Simular")
        End Try
    End Sub
    Sub sintonias(ind As Integer)
        Try
            metodo = ""
            If Txt_K.Text <> "" AndAlso Txt_To.Text <> "" AndAlso Txt_To.Text <> "" AndAlso Txt_Tp.Text <> "" Then
                Dim K As Single = CSng(Txt_K.Text)
                Dim T0 As Single = CSng(Txt_To.Text)
                Dim Tp As Single = CSng(Txt_Tp.Text)
                Dim Tf As Single = CSng(Txt_Tf.Text)
                Select Case ind
                    Case 0
                        Txt_Kc.Text = ((1 / K) * (Tp / T0) * (1 + (T0 / (3 * Tp)))).ToString("####0.00")
                        Txt_Ti.Text = 0
                        Txt_Td.Text = 0
                        metodo = "CC-25 | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
                    Case 1
                        Txt_Kc.Text = ((1 / K) * (Tp / T0) * (0.9 + (T0 / (12 * Tp)))).ToString("####0.00")
                        Txt_Ti.Text = (T0 * (30 + 3 * (T0 / Tp)) / (9 + 20 * (T0 / Tp))).ToString("####0.00")
                        Txt_Td.Text = 0
                        metodo = "CC-25 | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
                    Case 2
                        Txt_Kc.Text = ((1 / K) * (Tp / T0) * (16 * Tp + (3 * T0)) / (12 * Tp)).ToString("####0.00")
                        Txt_Ti.Text = (T0 * (32 + 6 * (T0 / Tp)) / (13 + 8 * (T0 / Tp))).ToString("####0.00")
                        Txt_Td.Text = (4 * T0 / (11 + 2 * (T0 / Tp))).ToString("####0.00")
                        metodo = "CC-25 | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
                    Case 3
                        Txt_Kc.Text = ((1 / K) * (Tp / T0) * (1 + (T0 / (3 * Tp))) * 0.6).ToString("####0.00")
                        Txt_Ti.Text = 0
                        Txt_Td.Text = 0
                        metodo = "CC-10 | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
                        If CInt(Txt_Tp.Text.Trim) < CInt(Txt_To.Text.Trim) / 2 Then MsgBox("El sistema no cumple con la condición 𝑇𝑝>𝑇o/2", vbOKOnly + vbInformation, "Aviso")
                    Case 4
                        Txt_Kc.Text = ((1 / K) * (Tp / T0) * (0.9 + (T0 / (12 * Tp))) * 0.6).ToString("####0.00")
                        Txt_Ti.Text = (T0 * (30 + 3 * (T0 / Tp)) / (9 + 20 * (T0 / Tp)) * 1.2).ToString("####0.00")
                        Txt_Td.Text = 0
                        metodo = "CC-10 | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
                        If CInt(Txt_Tp.Text.Trim) < CInt(Txt_To.Text.Trim) / 2 Then MsgBox("El sistema no cumple con la condición 𝑇𝑝>𝑇o/2", vbOKOnly + vbInformation, "Aviso")
                    Case 5
                        Txt_Kc.Text = ((1 / K) * (Tp / T0) * (16 * Tp + (3 * T0)) / (12 * Tp) * 0.6).ToString("####0.00")
                        Txt_Ti.Text = (T0 * (32 + 6 * (T0 / Tp)) / (13 + 8 * (T0 / Tp)) * 1.2).ToString("####0.00")
                        Txt_Td.Text = (4 * T0 / (11 + 2 * (T0 / Tp))).ToString("####0.00")
                        metodo = "CC-10 | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
                        If CInt(Txt_Tp.Text.Trim) < CInt(Txt_To.Text.Trim) / 2 Then MsgBox("El sistema no cumple con la condición 𝑇𝑝>𝑇o/2", vbOKOnly + vbInformation, "Aviso")
                    Case 6
                        Txt_Kc.Text = (Tp / (K * T0)).ToString("####0.00")
                        Txt_Ti.Text = 0
                        Txt_Td.Text = 0
                        metodo = "ZN-25 | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
                    Case 7
                        Txt_Kc.Text = (Tp / (K * T0) * 0.9).ToString("####0.00")
                        Txt_Ti.Text = (T0 / 0.3).ToString("####0.00")
                        Txt_Td.Text = 0
                        metodo = "ZN-25 | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
                    Case 8
                        Txt_Kc.Text = ((Tp / (K * T0) * 1.2) * ((2 * T0) + (0.5 * T0)) / (2 * T0)).ToString("####0.00")
                        Txt_Ti.Text = ((2 * T0) + (0.5 * T0)).ToString("####0.00")
                        Txt_Td.Text = ((0.5 * T0) * (2 * T0) / ((2 * T0) + (0.5 * T0))).ToString("####0.00")
                        metodo = "ZN-25 | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
                    Case 9
                        Txt_Kc.Text = (Tp / (K * T0) * 0.666).ToString("####0.00")
                        Txt_Ti.Text = 0
                        Txt_Td.Text = 0
                        metodo = "ZN-10 | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
                        If CInt(Txt_Tp.Text.Trim) < CInt(Txt_To.Text.Trim) * 2 Then MsgBox("El sistema no cumple con la condición Tp>2*To", vbOKOnly + vbInformation, "Aviso")
                    Case 10
                        Txt_Kc.Text = (Tp / (K * T0) * 0.9 * 0.666).ToString("####0.00")
                        Txt_Ti.Text = (T0 / 0.3).ToString("####0.00")
                        Txt_Td.Text = 0
                        metodo = "ZN-10 | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
                        If CInt(Txt_Tp.Text.Trim) < CInt(Txt_To.Text.Trim) * 2 Then MsgBox("El sistema no cumple con la condición Tp>2*To", vbOKOnly + vbInformation, "Aviso")
                    Case 11
                        Txt_Kc.Text = ((Tp / (K * T0) * 1.2 * 0.666) * ((2 * T0) + (0.5 * T0)) / (2 * T0)).ToString("####0.00")
                        Txt_Ti.Text = ((2 * T0) + (0.5 * T0)).ToString("####0.00")
                        Txt_Td.Text = ((0.5 * T0) * (2 * T0) / ((2 * T0) + (0.5 * T0))).ToString("####0.00")
                        metodo = "ZN-10 | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
                        If CInt(Txt_Tp.Text.Trim) < CInt(Txt_To.Text.Trim) * 2 Then MsgBox("El sistema no cumple con la condición Tp>2*To", vbOKOnly + vbInformation, "Aviso")
                    Case 12
                        Txt_Kc.Text = (1 / K * 0.859 * Math.Pow(T0 / Tp, -0.977)).ToString("####0.00")
                        Txt_Ti.Text = (Tp / (0.674 * Math.Pow(T0 / Tp, -0.68))).ToString("####0.00")
                        Txt_Td.Text = 0
                        metodo = "ITAE-C | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
                        If CInt(Txt_Tp.Text.Trim) < CInt(Txt_To.Text.Trim) Then MsgBox("El sistema no cumple con la condición Tp>T0", vbOKOnly + vbInformation, "Aviso")
                    Case 13
                        Txt_Kc.Text = (1 / K * 1.357 * Math.Pow(T0 / Tp, -0.947)).ToString("####0.00")
                        Txt_Ti.Text = (Tp / (0.842 * Math.Pow(T0 / Tp, -0.738))).ToString("####0.00")
                        Txt_Td.Text = (Tp * 0.381 * Math.Pow(T0 / Tp, 0.995)).ToString("####0.00")
                        metodo = "ITAE-C | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
                        If CInt(Txt_Tp.Text.Trim) < CInt(Txt_To.Text.Trim) Then MsgBox("El sistema no cumple con la condición Tp>T0", vbOKOnly + vbInformation, "Aviso")
                    Case 14
                        Txt_Kc.Text = (1 / K * 0.586 * Math.Pow(T0 / Tp, -0.916)).ToString("####0.00")
                        Txt_Ti.Text = (Tp / (-0.165 * Math.Pow(T0 / Tp, 1) + 1.03)).ToString("####0.00")
                        Txt_Td.Text = 0
                        metodo = "ITAE-SP | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
                        If CInt(Txt_Tp.Text.Trim) < CInt(Txt_To.Text.Trim) Then MsgBox("El sistema no cumple con la condición Tp>T0", vbOKOnly + vbInformation, "Aviso")
                    Case 15
                        Txt_Kc.Text = (1 / K * 0.965 * Math.Pow(T0 / Tp, -0.855)).ToString("####0.00")
                        Txt_Ti.Text = (Tp / (-0.147 * Math.Pow(T0 / Tp, 1) + 0.796)).ToString("####0.00")
                        Txt_Td.Text = (Tp * 0.308 * Math.Pow(T0 / Tp, 0.929)).ToString("####0.00")
                        metodo = "ITAE-SP | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
                    Case 16
                        Txt_Kc.Text = (1 / K * 0.984 * Math.Pow(T0 / Tp, -0.986)).ToString("####0.00")
                        Txt_Ti.Text = (Tp / (0.608 * Math.Pow(T0 / Tp, -0.707))).ToString("####0.00")
                        Txt_Td.Text = 0
                        metodo = "IAE-C | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
                        If CInt(Txt_Tp.Text.Trim) < CInt(Txt_To.Text.Trim) Then MsgBox("El sistema no cumple con la condición Tp>T0", vbOKOnly + vbInformation, "Aviso")
                    Case 17
                        Txt_Kc.Text = (1 / K * 1.435 * Math.Pow(T0 / Tp, -0.921)).ToString("####0.00")
                        Txt_Ti.Text = (Tp / (0.878 * Math.Pow(T0 / Tp, -0.749))).ToString("####0.00")
                        Txt_Td.Text = (Tp * 0.482 * Math.Pow(T0 / Tp, 1.137)).ToString("####0.00")
                        metodo = "IAE-C | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
                        If CInt(Txt_Tp.Text.Trim) < CInt(Txt_To.Text.Trim) Then MsgBox("El sistema no cumple con la condición Tp>T0", vbOKOnly + vbInformation, "Aviso")
                    Case 18
                        Txt_Kc.Text = (1 / K * 0.758 * Math.Pow(T0 / Tp, -0.861)).ToString("####0.00")
                        Txt_Ti.Text = (Tp / (-0.323 * Math.Pow(T0 / Tp, 1) + 1.02)).ToString("####0.00")
                        Txt_Td.Text = 0
                        metodo = "IAE-SP | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
                        If CInt(Txt_Tp.Text.Trim) < CInt(Txt_To.Text.Trim) Then MsgBox("El sistema no cumple con la condición Tp>T0", vbOKOnly + vbInformation, "Aviso")
                    Case 19
                        Txt_Kc.Text = (1 / K * 1.086 * Math.Pow(T0 / Tp, -0.869)).ToString("####0.00")
                        Txt_Ti.Text = (Tp / (-0.13 * Math.Pow(T0 / Tp, 1) + 0.74)).ToString("####0.00")
                        Txt_Td.Text = (Tp * 0.348 * Math.Pow(T0 / Tp, 0.914)).ToString("####0.00")
                        metodo = "IAE-SP | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
                        If CInt(Txt_Tp.Text.Trim) < CInt(Txt_To.Text.Trim) Then MsgBox("El sistema no cumple con la condición Tp>T0", vbOKOnly + vbInformation, "Aviso")
                    Case 20
                        If Txt_Tf.Text <> "" Then
                            Txt_Kc.Text = (Tp / (K * (Tf + T0))).ToString("####0.00")
                            Txt_Ti.Text = Tp.ToString("####0.00")
                            Txt_Td.Text = 0
                            metodo = "LAMBDA | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text & " (Tf: " & Txt_Tf.Text & ")"
                        End If
                    Case 21
                        If Txt_Tf.Text <> "" Then
                            Txt_Kc.Text = ((Tp + T0 / 2) / (K * (Tf + T0 / 2))).ToString("####0.00")
                            Txt_Ti.Text = (Tp + T0 / 2).ToString("####0.00")
                            Txt_Td.Text = (Tp * T0 / (2 * Tp + T0)).ToString("####0.00")
                            metodo = "LAMBDA | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text & " (Tf: " & Txt_Tf.Text & ")"
                        End If
                    Case 22
                        If Txt_Tf.Text <> "" Then
                            Txt_Kc.Text = ((Tp + T0 / 4) / (K * Tf)).ToString("####0.00")
                            Txt_Ti.Text = (Tp + T0 / 4).ToString("####0.00")
                            Txt_Td.Text = 0
                            metodo = "IMC | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text & " (Tf: " & Txt_Tf.Text & ")"
                        End If
                    Case 23
                        If Txt_Tf.Text <> "" Then
                            Txt_Kc.Text = ((1 / K) * (Tp / (Tf + T0))).ToString("####0.00")
                            Txt_Ti.Text = (Math.Min(Tp, 4 * (Tf + T0))).ToString("####0.00")
                            Txt_Td.Text = 0
                            metodo = "SIMC | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text & " (Tf: " & Txt_Tf.Text & ")"
                        End If
                    Case 24
                        If Txt_Tf.Text <> "" Then
                            Txt_Kc.Text = ((1 / K) * ((Tp + T0 / 3) / (Tf + T0))).ToString("####0.00")
                            Txt_Ti.Text = (Math.Min(Tp + T0 / 3, 4 * (Tf + T0))).ToString("####0.00")
                            Txt_Td.Text = 0
                            metodo = "IMPROVED SIMC | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text & " (Tf: " & Txt_Tf.Text & ")"
                        End If
                        'End If
                End Select
                Txt_Ki.Text = (CSng(Txt_Kc.Text) / CSng(Txt_Ti.Text)).ToString("####0.00")
                If Txt_Td.Text > 0 Or Txt_Td.Text <> "" Then Txt_Kd.Text = (CSng(Txt_Kc.Text) * CSng(Txt_Td.Text)).ToString("####0.00") Else Txt_Kd.Text = 0
                '
                Simular()
                '
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Function RShift(ByRef OP() As Single) As Single()
        Try
            Dim imax As Long
            Dim imin As Long
            Dim i As Long

            imax = UBound(OP)
            imin = LBound(OP)
            For i = imax To imin + 1 Step -1
                OP(i) = OP(i - 1)
            Next i
            Return OP
        Catch ex As Exception
            ' IO.File.AppendAllText(Application.StartupPath & "\PIDLab_LOG.txt", String.Format("{0}[{1}]{2}", Environment.NewLine, DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"), ex.ToString()))
        End Try
    End Function
    'Public Function LShift(ByVal OP() As Double) As Double()
    '    Try
    '        Dim imax As Long
    '        Dim imin As Long
    '        Dim i As Long

    '        imax = UBound(OP)
    '        imin = LBound(OP)
    '        For i = imin To imax - 1
    '            OP(i) = OP(i + 1)
    '        Next i
    '        OP(imax) = OP(imax - 1)
    '        Return OP
    '    Catch ex As Exception
    '        'IO.File.AppendAllText(Application.StartupPath & "\PIDLab_LOG.txt", String.Format("{0}[{1}]{2}", Environment.NewLine, DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"), ex.ToString()))
    '    End Try
    'End Function
    Public Function Interp1(ByVal xArr() As Double, ByVal yArr() As Double, ByVal x As Double) As Double
        Try
            If ((x < xArr(LBound(xArr))) Or (x > xArr(UBound(xArr)))) Then 'If ((x < xArr(LBound(xArr))) Or (x > xArr(UBound(xArr)))) Then
                MsgBox("Interp1: x is out of bound")
                Exit Function
            End If
            If xArr(LBound(xArr)) = x Then
                Interp1 = yArr(LBound(yArr))
                Return Interp1
                Exit Function
            End If
            Dim i As Single
            For i = LBound(xArr) To UBound(xArr)
                If xArr(i) >= x Then
                    Interp1 = yArr(i - 1) + (x - xArr(i - 1)) / (xArr(i) - xArr(i - 1)) * (yArr(i) - yArr(i - 1))
                    Return Interp1
                    Exit Function
                End If
            Next i
        Catch ex As Exception
            'IO.File.AppendAllText(Application.StartupPath & "\PIDLab_LOG.txt", String.Format("{0}[{1}]{2}", Environment.NewLine, DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"), ex.ToString()))
        End Try
    End Function
    Sub gridcolor(ByVal dgv As DataGridView)
        'Colorea alternando las celdas
        With dgv
            .EnableHeadersVisualStyles = False
            .ForeColor = Color.Gainsboro
            .CellBorderStyle = DataGridViewCellBorderStyle.None
            .RowsDefaultCellStyle.BackColor = Color.FromArgb(60, 63, 65)
            .AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(55, 58, 60)
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.Gainsboro
            .ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(60, 63, 65)
        End With
    End Sub
    <DllImport("user32.dll", CharSet:=CharSet.Auto)>
    Private Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal msg As Integer, ByVal wParam As Integer, <MarshalAs(UnmanagedType.LPWStr)> ByVal lParam As String) As Int32
    End Function
#End Region
#Region "Código"
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            With My.Application.Info.Version
                Me.Text = "Arduino COM Plotter " & .Major.ToString & "." & .Minor.ToString & "      |      Proyecto[sin guardar]"
            End With
            If Not (System.IO.Directory.Exists(export)) Then
                System.IO.Directory.CreateDirectory(export)
            End If
            IO.File.AppendAllText(Application.StartupPath & "\ACP_LOG.txt", String.Format("{0}[{1}]{2}", Environment.NewLine, "-------------------START-------------", DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss")))
            'Configuración
            Cbo_velocidad_2.Items.Add("9600")
            Cbo_velocidad_2.Items.Add("14400")
            Cbo_velocidad_2.Items.Add("19200")
            Cbo_velocidad_2.Items.Add("38400")
            Cbo_velocidad_2.Items.Add("57600")
            Cbo_velocidad_2.Items.Add("115200")
            Cbo_velocidad_2.SelectedIndex = 0
            GetSerialPortNames()
            Btn_desconectarDark.Enabled = False
            Btn_exportarP.Enabled = False
            Lbl_info.Text = ""
            Lbl_lineas.Text = ""
            'Custom colors
            Dim colorBlue As Integer
            Dim colorGreen As Integer
            Dim colorRed As Integer
            Dim iMyCustomColor As Integer
            Dim iMyCustomColors(colors.Length - 1) As Integer
            For i = 0 To colors.Count - 1
                colorBlue = colors(i).B
                colorGreen = colors(i).G
                colorRed = colors(i).R
                iMyCustomColor = colorBlue << 16 Or colorGreen << 8 Or colorRed
                iMyCustomColors(i) = iMyCustomColor
            Next
            ColorDialog1.CustomColors = iMyCustomColors
            'DGV
            MakeGridViewDoubleBuffered(dgv_vars)
            tbl.Clear()
            'tbl = New DataTable("miTabla")
            'dgv_vars.DataSource = ""
            tbl.Columns.Add(" ", GetType(Boolean))
            tbl.Columns.Add("Nombre", GetType(String))
            tbl.Columns.Add("Valor", GetType(String))
            tbl.Columns.Add("Y min", GetType(String))
            tbl.Columns.Add("Y max", GetType(String))
            tbl.Columns.Add("Eje Y izq", GetType(Boolean))
            tbl.Columns.Add("Serie arriba", GetType(Boolean))
            tbl.Rows.Add(True, "Nombre1", "", "0", "100", True, True)
            tbl.Rows.Add(True, "Nombre2", "", "0", "100", True, True)
            tbl.Rows.Add(True, "Nombre3", "", "-5", "105", False, True)
            '
            dgv_vars.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
            dgv_vars.AllowUserToResizeColumns = True
            dgv_vars.RowHeadersVisible = False
            dgv_vars.DataSource = tbl
            gridcolor(dgv_vars)
            series.Clear()
            Chart1.ChartAreas(1).AlignWithChartArea = "ChartArea1"
            For i = 0 To 2
                series.Add(0.0)
                Chart1.Series.Add("Serie" & i)
                Chart1.Series("Serie" & i).IsXValueIndexed = False
                Chart1.Series("Serie" & i).BorderWidth = 2
                Chart1.Series("Serie" & i).ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
                Chart1.Series("Serie" & i).ChartArea = "ChartArea1"
            Next
            '
            Txt_datos.Text = ""
            Txt_datos.HideSelection = False
            txt_separador.Text = Chr(32)
            txt_inicio.Text = "#"
            '
            'Chart1.ChartAreas(0).BackColor = Color.FromArgb(60, 63, 65)
            'Chart1.ChartAreas(1).BackColor = Color.FromArgb(60, 63, 65)
            Chart1.BackColor = Color.FromArgb(60, 63, 65)
            '
            MakeDoubleBuffered(Chart1)
            MakeDoubleBuffered(Chart_simula)
            '
            For i = 0 To 1
                Chart1.ChartAreas(i).BackColor = Color.FromArgb(60, 63, 65)
                Chart1.ChartAreas(i).AxisX.Title = "Tiempo (segundos)"
                Chart1.ChartAreas(i).AxisY.Title = "SP y PV"
                Chart1.ChartAreas(i).AxisY2.Title = "OP"
                Chart1.ChartAreas(i).AxisX.ScaleView.Zoomable = True
                Chart1.ChartAreas(i).AxisY.ScaleView.Zoomable = True
                Chart1.ChartAreas(i).AxisY2.ScaleView.Zoomable = True
                Chart1.ChartAreas(i).AxisY.LabelStyle.Format = "0.00"
                Chart1.ChartAreas(i).AxisY2.LabelStyle.Format = "0.00"
                Chart1.ChartAreas(i).CursorX.IsUserSelectionEnabled = True
                Chart1.ChartAreas(i).CursorY.IsUserSelectionEnabled = True
                Chart1.ChartAreas(i).CursorX.AutoScroll = True
                Chart1.ChartAreas(i).CursorY.AutoScroll = True
                Chart1.ChartAreas(i).AxisY.Minimum = [Double].NaN
                Chart1.ChartAreas(i).AxisY.Maximum = [Double].NaN
                Chart1.ChartAreas(i).AxisY2.Minimum = [Double].NaN
                Chart1.ChartAreas(i).AxisY2.Maximum = [Double].NaN
                Chart1.ChartAreas(i).AxisY.Maximum = 100
                Chart1.ChartAreas(i).AxisY.Minimum = 0
                Chart1.ChartAreas(i).AxisY2.Maximum = 105
                Chart1.ChartAreas(i).AxisY2.Minimum = -5
                Chart1.ChartAreas(i).AxisX.Minimum = 0
                Chart1.ChartAreas(i).AxisX.Maximum = num_ventana.Value
                Chart1.ChartAreas(i).AxisX.LabelStyle.Format = "0.00"
                'Chart1.ChartAreas(i).AxisX.Interval = 1000 / Num_delay.Value
                Chart1.ChartAreas(i).AxisY.ScaleView.ZoomReset(0)
                Chart1.ChartAreas(i).AxisX.ScaleView.ZoomReset(0)
                Chart1.ChartAreas(i).AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.SmallScroll
                '
                'For x = 0 To Chart1.ChartAreas(i).Axes.Count - 1
                '    Chart1.ChartAreas(i).Axes(0).LineColor = Color.Gainsboro
                '    Chart1.ChartAreas(i).Axes(0).InterlacedColor = Color.Gainsboro
                '    Chart1.ChartAreas(i).Axes(0).TitleForeColor = Color.Gainsboro
                '    Chart1.ChartAreas(i).Axes(0).MajorGrid.LineColor = Color.Gainsboro
                'Next
                '
            Next
            Chart1.ChartAreas(1).Visible = False
            '
            Chart1.Series(0).IsXValueIndexed = False
            Chart1.Series(1).IsXValueIndexed = False
            Chart1.Series(2).IsXValueIndexed = False
            Chart1.Series(0).Color = colors(0) 'Color.Blue
            Chart1.Series(0).Name = dgv_vars(1, 0).Value
            Chart1.Series(0).LegendText = dgv_vars(1, 0).Value
            Chart1.Series(0).YAxisType = DataVisualization.Charting.AxisType.Primary
            Chart1.Series(1).Color = colors(1) 'Color.Fuchsia
            Chart1.Series(1).Name = dgv_vars(1, 1).Value
            Chart1.Series(1).LegendText = dgv_vars(1, 1).Value
            Chart1.Series(1).YAxisType = DataVisualization.Charting.AxisType.Primary
            Chart1.Series(2).Color = colors(2) 'Color.Yellow
            Chart1.Series(2).Name = dgv_vars(1, 2).Value
            Chart1.Series(2).LegendText = dgv_vars(1, 2).Value
            Chart1.Series(2).YAxisType = DataVisualization.Charting.AxisType.Secondary
            '
            'https://docs.microsoft.com/es-es/previous-versions/dd456687%28v%3dvs.140%29
            Chart1.Series(0).IsXValueIndexed = False
            Chart1.Series(1).IsXValueIndexed = False
            Chart1.Series(2).IsXValueIndexed = False
            '
            Chart1.Series.SuspendUpdates()
            '
            Dim root = New DarkTreeNode("Métodos de sintonía")
            Tv_metodos.Nodes.Add(root)
            Tv_metodos.Nodes(0).Nodes.Add(New DarkTreeNode("CC-25"))
            Tv_metodos.Nodes(0).Nodes(0).Nodes.Add(New DarkTreeNode("Autor: Cohen-Coon"))
            Tv_metodos.Nodes(0).Nodes(0).Nodes.Add(New DarkTreeNode("Tipo: Delta de carga"))
            Tv_metodos.Nodes(0).Nodes(0).Nodes.Add(New DarkTreeNode("Especificación: R.A.=25%"))
            Tv_metodos.Nodes(0).Nodes(0).Nodes.Add(New DarkTreeNode("P"))
            Tv_metodos.Nodes(0).Nodes(0).Nodes.Add(New DarkTreeNode("PI"))
            Tv_metodos.Nodes(0).Nodes(0).Nodes.Add(New DarkTreeNode("PID"))
            Tv_metodos.Nodes(0).Nodes.Add(New DarkTreeNode("CC-10"))
            Tv_metodos.Nodes(0).Nodes(1).Nodes.Add(New DarkTreeNode("Autor: Cohen-Coon"))
            Tv_metodos.Nodes(0).Nodes(1).Nodes.Add(New DarkTreeNode("Tipo: Delta de carga"))
            Tv_metodos.Nodes(0).Nodes(1).Nodes.Add(New DarkTreeNode("Especificación: R.A.=10%"))
            Tv_metodos.Nodes(0).Nodes(1).Nodes.Add(New DarkTreeNode("Condición de aplicación: 𝑇𝑝>𝑇o/2"))
            Tv_metodos.Nodes(0).Nodes(1).Nodes.Add(New DarkTreeNode("P"))
            Tv_metodos.Nodes(0).Nodes(1).Nodes.Add(New DarkTreeNode("PI"))
            Tv_metodos.Nodes(0).Nodes(1).Nodes.Add(New DarkTreeNode("PID"))
            Tv_metodos.Nodes(0).Nodes.Add(New DarkTreeNode("ZN-LA-25"))
            Tv_metodos.Nodes(0).Nodes(2).Nodes.Add(New DarkTreeNode("Autor: Ziegler-Nichols"))
            Tv_metodos.Nodes(0).Nodes(2).Nodes.Add(New DarkTreeNode("Tipo: Delta de carga"))
            Tv_metodos.Nodes(0).Nodes(2).Nodes.Add(New DarkTreeNode("Especificación: R.A.=25%"))
            Tv_metodos.Nodes(0).Nodes(2).Nodes.Add(New DarkTreeNode("P"))
            Tv_metodos.Nodes(0).Nodes(2).Nodes.Add(New DarkTreeNode("PI"))
            Tv_metodos.Nodes(0).Nodes(2).Nodes.Add(New DarkTreeNode("PID"))
            Tv_metodos.Nodes(0).Nodes.Add(New DarkTreeNode("ZN-LA-10"))
            Tv_metodos.Nodes(0).Nodes(3).Nodes.Add(New DarkTreeNode("Autor: Ziegler-Nichols"))
            Tv_metodos.Nodes(0).Nodes(3).Nodes.Add(New DarkTreeNode("Tipo: Delta de carga"))
            Tv_metodos.Nodes(0).Nodes(3).Nodes.Add(New DarkTreeNode("Especificación: R.A.=10%"))
            Tv_metodos.Nodes(0).Nodes(3).Nodes.Add(New DarkTreeNode("Condición de aplicación: 𝑇𝑝>2*𝑇o"))
            Tv_metodos.Nodes(0).Nodes(3).Nodes.Add(New DarkTreeNode("P"))
            Tv_metodos.Nodes(0).Nodes(3).Nodes.Add(New DarkTreeNode("PI"))
            Tv_metodos.Nodes(0).Nodes(3).Nodes.Add(New DarkTreeNode("PID"))
            Tv_metodos.Nodes(0).Nodes.Add(New DarkTreeNode("ITAE-C"))
            Tv_metodos.Nodes(0).Nodes(4).Nodes.Add(New DarkTreeNode("Autor: Smith, Murrill y otros"))
            Tv_metodos.Nodes(0).Nodes(4).Nodes.Add(New DarkTreeNode("Tipo: Delta de carga"))
            Tv_metodos.Nodes(0).Nodes(4).Nodes.Add(New DarkTreeNode("PI"))
            Tv_metodos.Nodes(0).Nodes(4).Nodes.Add(New DarkTreeNode("PID"))
            Tv_metodos.Nodes(0).Nodes.Add(New DarkTreeNode("ITAE-SP"))
            Tv_metodos.Nodes(0).Nodes(5).Nodes.Add(New DarkTreeNode("Autor: Smith, Murrill y otros"))
            Tv_metodos.Nodes(0).Nodes(5).Nodes.Add(New DarkTreeNode("Tipo: Delta de SP"))
            Tv_metodos.Nodes(0).Nodes(5).Nodes.Add(New DarkTreeNode("PI"))
            Tv_metodos.Nodes(0).Nodes(5).Nodes.Add(New DarkTreeNode("PID"))
            Tv_metodos.Nodes(0).Nodes.Add(New DarkTreeNode("IAE-C"))
            Tv_metodos.Nodes(0).Nodes(6).Nodes.Add(New DarkTreeNode("Autor: Smith, Murrill y otros"))
            Tv_metodos.Nodes(0).Nodes(6).Nodes.Add(New DarkTreeNode("Tipo: Delta de carga"))
            Tv_metodos.Nodes(0).Nodes(6).Nodes.Add(New DarkTreeNode("PI"))
            Tv_metodos.Nodes(0).Nodes(6).Nodes.Add(New DarkTreeNode("PID"))
            Tv_metodos.Nodes(0).Nodes.Add(New DarkTreeNode("IAE-SP"))
            Tv_metodos.Nodes(0).Nodes(7).Nodes.Add(New DarkTreeNode("Autor: Smith, Murrill y otros"))
            Tv_metodos.Nodes(0).Nodes(7).Nodes.Add(New DarkTreeNode("Tipo: Delta de SP"))
            Tv_metodos.Nodes(0).Nodes(7).Nodes.Add(New DarkTreeNode("PI"))
            Tv_metodos.Nodes(0).Nodes(7).Nodes.Add(New DarkTreeNode("PID"))
            Tv_metodos.Nodes(0).Nodes.Add(New DarkTreeNode("Lambda"))
            Tv_metodos.Nodes(0).Nodes(8).Nodes.Add(New DarkTreeNode("Autor: Rivera"))
            Tv_metodos.Nodes(0).Nodes(8).Nodes.Add(New DarkTreeNode("Tipo: Delta de SP"))
            Tv_metodos.Nodes(0).Nodes(8).Nodes.Add(New DarkTreeNode("Especificación: Tf"))
            Tv_metodos.Nodes(0).Nodes(8).Nodes.Add(New DarkTreeNode("PI"))
            Tv_metodos.Nodes(0).Nodes(8).Nodes.Add(New DarkTreeNode("PID"))
            Tv_metodos.Nodes(0).Nodes.Add(New DarkTreeNode("IMC"))
            Tv_metodos.Nodes(0).Nodes(9).Nodes.Add(New DarkTreeNode("Tipo: Delta de SP"))
            Tv_metodos.Nodes(0).Nodes(9).Nodes.Add(New DarkTreeNode("Tipo: Sin restricciones"))
            Tv_metodos.Nodes(0).Nodes(9).Nodes.Add(New DarkTreeNode("Especificación: Tf"))
            Tv_metodos.Nodes(0).Nodes(9).Nodes.Add(New DarkTreeNode("PI"))
            Tv_metodos.Nodes(0).Nodes.Add(New DarkTreeNode("SIM C"))
            Tv_metodos.Nodes(0).Nodes(10).Nodes.Add(New DarkTreeNode("Autor: Skogestad"))
            Tv_metodos.Nodes(0).Nodes(10).Nodes.Add(New DarkTreeNode("Tipo: Sin restricción"))
            Tv_metodos.Nodes(0).Nodes(10).Nodes.Add(New DarkTreeNode("Especificación: Tf"))
            Tv_metodos.Nodes(0).Nodes(10).Nodes.Add(New DarkTreeNode("PI"))
            Tv_metodos.Nodes(0).Nodes.Add(New DarkTreeNode("Improved SIM C"))
            Tv_metodos.Nodes(0).Nodes(11).Nodes.Add(New DarkTreeNode("Autor: Skogestad"))
            Tv_metodos.Nodes(0).Nodes(11).Nodes.Add(New DarkTreeNode("Tipo: Sin restricciones"))
            Tv_metodos.Nodes(0).Nodes(11).Nodes.Add(New DarkTreeNode("Especificación: Tf"))
            Tv_metodos.Nodes(0).Nodes(11).Nodes.Add(New DarkTreeNode("PI"))
            '
            Txt_K.Text = "0,149"
            Txt_To.Text = "29,5"
            Txt_Tp.Text = "100,5"
            Txt_Tf.Text = "50"
            Txt_PVrngInf.Text = "-40"
            Txt_PVrngSup.Text = "150"
            Txt_muestreo.Text = "1"
            Txt_Tfinal.Text = "300"
            Txt_PVini.Text = "30"
            Txt_OPini.Text = "0"
            Txt_CargaIni.Text = "0"
            Txt_DSP.Text = "5"
            Txt_Dcarga.Text = "0"
            Txt_OPLimSup.Text = "100"
            Txt_OPLimInf.Text = "0"
            Cbo_eq.SelectedIndex = 1
            '
            Cbo_metodos_sim.Items.Add("CC-25 (P)")
            Cbo_metodos_sim.Items.Add("CC-25 (PI)")
            Cbo_metodos_sim.Items.Add("CC-25 (PID)")
            Cbo_metodos_sim.Items.Add("CC-10 (P)")
            Cbo_metodos_sim.Items.Add("CC-10 (PI)")
            Cbo_metodos_sim.Items.Add("CC-10 (PID)")
            Cbo_metodos_sim.Items.Add("ZN-25 (P)")
            Cbo_metodos_sim.Items.Add("ZN-25 (PI)")
            Cbo_metodos_sim.Items.Add("ZN-25 (PID)")
            Cbo_metodos_sim.Items.Add("ZN-10 (P)")
            Cbo_metodos_sim.Items.Add("ZN-10 (PI)")
            Cbo_metodos_sim.Items.Add("ZN-10 (PID)")
            Cbo_metodos_sim.Items.Add("ITAE-C (PI)")
            Cbo_metodos_sim.Items.Add("ITAE-C (PID)")
            Cbo_metodos_sim.Items.Add("ITAE-SP (PI)")
            Cbo_metodos_sim.Items.Add("ITAE-SP (PID)")
            Cbo_metodos_sim.Items.Add("IAE-C (PI)")
            Cbo_metodos_sim.Items.Add("IAE-C (PID)")
            Cbo_metodos_sim.Items.Add("IAE-SP (PI)")
            Cbo_metodos_sim.Items.Add("IAE-SP (PID)")
            Cbo_metodos_sim.Items.Add("LAMBDA (PI)")
            Cbo_metodos_sim.Items.Add("LAMBDA (PID)")
            Cbo_metodos_sim.Items.Add("IMC (PI)")
            Cbo_metodos_sim.Items.Add("SIMC (PI)")
            Cbo_metodos_sim.Items.Add("IMPROVED SIMC (PI)")
            'Cbo_metodos_sim.SelectedIndex = 4
            '
            SendMessage(Txt_K.Handle, &H1501, 0, "%/%")
            SendMessage(Txt_To.Handle, &H1501, 0, "segundos")
            SendMessage(Txt_Tp.Handle, &H1501, 0, "segundos")
            SendMessage(Txt_Tf.Handle, &H1501, 0, "segundos")
            '
            SendMessage(Txt_PVrngSup.Handle, &H1501, 0, "EU")
            SendMessage(Txt_PVrngInf.Handle, &H1501, 0, "segundos")
            SendMessage(Txt_Kc.Handle, &H1501, 0, "%/%")
            SendMessage(Txt_Ti.Handle, &H1501, 0, "segundos")
            SendMessage(Txt_Td.Handle, &H1501, 0, "segundos")
            '
            SendMessage(Txt_muestreo.Handle, &H1501, 0, "segundos")
            SendMessage(Txt_Tfinal.Handle, &H1501, 0, "segundos")
            SendMessage(Txt_PVini.Handle, &H1501, 0, "EU")
            SendMessage(Txt_OPini.Handle, &H1501, 0, "%")
            SendMessage(Txt_CargaIni.Handle, &H1501, 0, "EU")
            SendMessage(Txt_DSP.Handle, &H1501, 0, "%")
            SendMessage(Txt_Dcarga.Handle, &H1501, 0, "&")
            SendMessage(Txt_OPLimSup.Handle, &H1501, 0, "%")
            SendMessage(Txt_OPLimInf.Handle, &H1501, 0, "%")
            '
        Catch ex As Exception
            IO.File.AppendAllText(Application.StartupPath & "\ACP_LOG.txt", String.Format("{0}[{1}]{2}", Environment.NewLine, DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"), ex.ToString()))
            'MsgBox(ex.Message.ToString)
        End Try
    End Sub
    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim result As DialogResult
        result = MsgBox("¿Salir de la aplicación?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Salir")
        If result = DialogResult.Yes Then
            Me.Dispose()
            End
        ElseIf result = DialogResult.No Then
            e.Cancel = True
        End If
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            'Actualizar()
            If datosOK = True Then
                'If Txt_datos.MaxLength < Txt_datos.TextLength Then
                'Txt_datos.Text &= datos_puerto.TrimStart("#") + vbNewLine + vbNewLine
                Tiempo += Math.Round(Num_delay.Value / 1000, 1) 'Tiempo += 1
                contador += Math.Round(Num_delay.Value / 1000, 1) 'contador += 1
                For i = 0 To series.Count - 1
                    'Application.DoEvents()
                    'Eje X
                    Chart1.Series(i).Points.AddXY(Tiempo, series(i))
                    If (contador >= num_ventana.Value) Then 'Scroll cada x tiempo
                        Timer1.Enabled = False
                        If proyecto <> "" Then Guardar()    'Auto-guardado
                        Chart1.ChartAreas(0).AxisX.Maximum += num_ventana.Value
                        Chart1.ChartAreas(0).AxisX.ScaleView.Zoom(Chart1.ChartAreas(0).AxisX.Maximum - num_ventana.Value, Chart1.ChartAreas(0).AxisX.Maximum)
                        contador = 0
                        Chart1.Invalidate()
                        Timer1.Enabled = True
                    End If
                    'Nombres
                    Chart1.Series(i).LegendText = dgv_vars(1, i).Value & "(" & dgv_vars(2, i).Value & ")"
                    Chart1.Series(i).Name = dgv_vars(1, i).Value
                    'Muestro datos en DGV
                    dgv_vars.Rows(i).Cells(2).Value = series(i)
                Next
                'End If
            End If
        Catch ex As Exception
            IO.File.AppendAllText(Application.StartupPath & "\ACP_LOG.txt", String.Format("{0}[{1}]{2}", Environment.NewLine, DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"), ex.ToString()))
        End Try
    End Sub
    Private Sub Txt_datos_TextChanged(sender As Object, e As EventArgs) Handles Txt_datos.TextChanged
        Try
            Dim lineCount As Long = Txt_datos.Lines.Count()
            Dim cada_seg As Single = CSng(Num_delay.Value / 1000)
            Dim segundos As Single = CSng(((lineCount - 1) * cada_seg)) ' Dim segundos As Single = (lineCount - 1 + cada_seg)
            Dim mytime As TimeSpan = TimeSpan.FromSeconds(segundos)
            Dim mydate As DateTime = New DateTime(mytime.Ticks)
            'Dim mydate As DateTime = DateTime.FromOADate(segundos) 'New DateTime(mytime.Ticks)
            Lbl_lineas.Text = lineCount.ToString() & " líneas | Duración " & mydate.ToString("HH:mm:ss")
        Catch ex As Exception
            IO.File.AppendAllText(Application.StartupPath & "\ACP_LOG.txt", String.Format("{0}[{1}]{2}", Environment.NewLine, DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"), ex.ToString()))
        End Try
    End Sub
    Private Sub LogToolStripMenuItem_Click(sender As Object, e As EventArgs)
        If SplitContainer3.Panel1Collapsed = True Then
            SplitContainer3.Panel1.Show()
            SplitContainer3.Panel1Collapsed = False
        Else
            SplitContainer3.Panel1.Hide()
            SplitContainer3.Panel1Collapsed = True
        End If
    End Sub
    Private Sub dgv_vars_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_vars.CellClick
        fila = e.RowIndex
    End Sub
    Private Sub dgv_vars_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles dgv_vars.CurrentCellDirtyStateChanged
        '
        If dgv_vars(0, fila).Value = True Then Chart1.Series(fila).Enabled = True
        If dgv_vars(0, fila).Value = False Then Chart1.Series(fila).Enabled = False
        '
        If dgv_vars(5, fila).Value = True Then Chart1.Series(fila).YAxisType = DataVisualization.Charting.AxisType.Primary
        If dgv_vars(5, fila).Value = False Then Chart1.Series(fila).YAxisType = DataVisualization.Charting.AxisType.Secondary
        '
        If dgv_vars(6, fila).Value = True Then Chart1.Series(fila).ChartArea = "ChartArea1"
        If dgv_vars(6, fila).Value = False Then Chart1.Series(fila).ChartArea = "ChartArea2"
        dgv_vars.EndEdit()
        'Compruebo si tengo que mostrar el chararea2 o no
        Dim chks As Integer = 0
        For a = 0 To dgv_vars.RowCount - 1
            'For b = 0 To dgv_vars.ColumnCount - 1
            If dgv_vars.Rows(a).Cells(6).Value = False Then
                chks += 1
            End If
            'Next
        Next
        If chks > 0 Then Chart1.ChartAreas(1).Visible = True : Chart1.ChartAreas(0).AxisX.Title = "" Else Chart1.ChartAreas(1).Visible = False : Chart1.ChartAreas(0).AxisX.Title = "Tiempo (segundos)"
    End Sub
    Private Sub txt_inicio_TextChanged_1(sender As Object, e As EventArgs) Handles txt_inicio.TextChanged
        Try
            Dim asciis As Byte() = System.Text.Encoding.ASCII.GetBytes(txt_inicio.Text)
            If Asc(txt_inicio.Text) = 32 Then
                lbl_inicio.Text = "Chr(" & Asc(txt_inicio.Text) & ") (espacio)"
            Else
                lbl_inicio.Text = "Chr(" & Asc(txt_inicio.Text) & ") (" & System.Text.Encoding.ASCII.GetString(asciis) & ")"
            End If
        Catch ex As Exception
        End Try
    End Sub
    'Private Sub dgv_vars_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles dgv_vars.CellValidating
    '    Try
    '        'For i = 0 To dgv_vars.RowCount - 1
    '        '    If dgv_vars(3, i).Value >= dgv_vars(4, i).Value Then dgv_vars(4, i).Value += 1
    '        '    If i > 1 Then
    '        '        Chart1.Series(i).YAxisType = DataVisualization.Charting.AxisType.Secondary
    '        '        Chart1.ChartAreas(0).AxisY2.Maximum = dgv_vars(4, i).Value
    '        '        Chart1.ChartAreas(0).AxisY2.Minimum = dgv_vars(3, i).Value
    '        '    Else
    '        '        Chart1.Series(i).YAxisType = DataVisualization.Charting.AxisType.Primary
    '        '        Chart1.ChartAreas(0).AxisY.Maximum = dgv_vars(4, i).Value
    '        '        Chart1.ChartAreas(0).AxisY.Minimum = dgv_vars(3, i).Value
    '        '    End If
    '        'Next
    '    Catch ex As Exception
    '    End Try
    'End Sub
    Private Sub dgv_vars_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgv_vars.CellBeginEdit
        Try
            'Sólo editables los checkboxes y los nombres
            If e.ColumnIndex <> 0 AndAlso e.ColumnIndex <> 1 AndAlso e.ColumnIndex <> 5 AndAlso e.ColumnIndex <> 6 Then
                e.Cancel = True
            End If
        Catch ex As Exception
            IO.File.AppendAllText(Application.StartupPath & "\ACP_LOG.txt", String.Format("{0}[{1}]{2}", Environment.NewLine, DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"), ex.ToString()))
        End Try
    End Sub
    Private Sub Chart1_AxisScrollBarClicked(sender As Object, e As ScrollBarEventArgs)
        Try
            If (e.ButtonType = ScrollBarButtonType.ZoomReset) Then
                e.IsHandled = True
                Chart1.ChartAreas(0).AxisY.ScaleView.ZoomReset(0)
                Chart1.ChartAreas(0).CursorY.SelectionEnd = Double.NaN
                Chart1.ChartAreas(0).AxisX.ScaleView.Zoom(Chart1.ChartAreas(0).AxisX.Maximum - num_ventana.Value, Chart1.ChartAreas(0).AxisX.Maximum)
            End If
        Catch ex As Exception
            IO.File.AppendAllText(Application.StartupPath & "\ACP_LOG.txt", String.Format("{0}[{1}]{2}", Environment.NewLine, DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"), ex.ToString()))
        End Try
    End Sub
    Private Sub Chart1_Click(sender As Object, e As MouseEventArgs) Handles Chart1.Click
        Try
            Dim h As HitTestResult = Chart1.HitTest(e.X, e.Y)
            'Añade notas
            If h.ChartElementType = ChartElementType.DataPoint AndAlso e.Button = MouseButtons.Left Then
                Dim annotationCallout As New CalloutAnnotation()
                annotationCallout.AnchorDataPoint = Chart1.Series(h.Series.Name).Points(h.PointIndex)
                annotationCallout.Text = "#SERIESNAME\nValor: #VALY\nSegundo #VALX{f1}\n"
                annotationCallout.BackColor = h.Series.Color
                annotationCallout.ClipToChartArea = "Default" 'Las notas pueden ponerse incluso por encima de la leyenda
                'annotationCallout.ClipToChartArea = h.ChartArea.Name 'No deja salir las notas del chartarea
                annotationCallout.AllowMoving = True
                annotationCallout.AllowAnchorMoving = True
                annotationCallout.AllowSelecting = True
                annotationCallout.AllowResizing = True
                annotationCallout.AllowTextEditing = True
                Chart1.Annotations.Add(annotationCallout)
                '---------------------------------------------------------------------------------------
                'Dim annotationRectangle As New RectangleAnnotation()
                'annotationRectangle.Text = "#SERIESNAME\nValor: #VALY\nSegundo #VALX\n"
                'annotationRectangle.BackColor = h.Series.Color
                'annotationRectangle.AnchorDataPoint = Chart1.Series(h.Series.Name).Points(h.PointIndex)
                'annotationRectangle.AllowMoving = True
                'annotationRectangle.AllowAnchorMoving = True
                'annotationRectangle.AllowSelecting = True
                'Chart1.Annotations.Add(annotationRectangle)
            End If
            'Borra notas
            If e.Button = MouseButtons.Right Then
                For i = 0 To Chart1.Annotations.Count - 1
                    If Chart1.Annotations(i).IsSelected Then Chart1.Annotations.RemoveAt(i)
                Next
                Chart1.Cursor = Cursors.Default
            End If
            'Cambia colores de las series desde la leyenda
            If h.ChartElementType = ChartElementType.LegendItem AndAlso e.Button = MouseButtons.Right Then
                Dim item As LegendItem = CType(h.Object, LegendItem)
                ColorDialog1.Color = item.Color
                If ColorDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                    item.Color = ColorDialog1.Color
                    Chart1.Series(item.SeriesName).Color = ColorDialog1.Color
                End If
            End If
            'Cambia título de ejes
            If h.ChartElementType = ChartElementType.AxisTitle AndAlso e.Button = MouseButtons.Right Then
                Dim title As String = InputBox("Introduce el nombre del EJE", "Nuevo nombre", "")
                If title.Trim <> "" Then h.Axis.Title = title.Trim
            End If
            '
            Chart1.Invalidate()
        Catch ex As Exception
            IO.File.AppendAllText(Application.StartupPath & "\ACP_LOG.txt", String.Format("{0}[{1}]{2}", Environment.NewLine, DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"), ex.ToString()))
        End Try
    End Sub
    Private Sub Chart1_MouseMove(sender As Object, e As MouseEventArgs) Handles Chart1.MouseMove
        Try
            Chart1.Focus()
            Dim h As Windows.Forms.DataVisualization.Charting.HitTestResult = Chart1.HitTest(e.X, e.Y)
            If h.ChartElementType = DataVisualization.Charting.ChartElementType.DataPoint Then
                ToolTipProvider.SetToolTip(Chart1, h.Series.Name & ": " & h.Series.Points(h.PointIndex).YValues(0) & vbCrLf & "Segundo: " & Math.Round(h.Series.Points(h.PointIndex).XValue, 1))
            End If
            If h.ChartElementType = DataVisualization.Charting.ChartElementType.AxisLabels Then
                If h.Axis.AxisName.ToString = "Y" Then
                    sobreejey = True
                    sobreejey2 = False
                Else
                    sobreejey = False
                    sobreejey2 = True
                End If
                If h.Axis.AxisName.ToString = "Y2" Then
                    sobreejey2 = True
                    sobreejey = False
                Else
                    sobreejey2 = False
                    sobreejey = True
                End If
            Else
                sobreejey = False
                sobreejey2 = False
            End If
        Catch ex As Exception
            IO.File.AppendAllText(Application.StartupPath & "\ACP_LOG.txt", String.Format("{0}[{1}]{2}", Environment.NewLine, DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"), ex.ToString()))
        End Try
    End Sub
    Private Sub Chart1_MouseWheel(sender As Object, e As MouseEventArgs) Handles Chart1.MouseWheel
        Try
            Dim h As Windows.Forms.DataVisualization.Charting.HitTestResult = Chart1.HitTest(e.X, e.Y)
            If h.ChartElementType = DataVisualization.Charting.ChartElementType.AxisLabels Then
                For i = 0 To 1
                    Chart1.ChartAreas(i).AxisY.ScaleView.ZoomReset(0)
                    Chart1.ChartAreas(i).AxisX.ScaleView.ZoomReset(0)
                    Dim k As Single = 0
                    Chart1.ChartAreas(i).AxisY.LabelStyle.Format = "0.00"
                    Chart1.ChartAreas(i).AxisY2.LabelStyle.Format = "0.00"
                    If h.Axis.AxisName.ToString = "Y" AndAlso e.Delta > 0 Then
                        k = (Chart1.ChartAreas(i).AxisY.Maximum - Chart1.ChartAreas(i).AxisY.Minimum) * 5 / 100
                        If Chart1.ChartAreas(i).AxisY.Maximum - k > Chart1.ChartAreas(i).AxisY.Minimum Then
                            Chart1.ChartAreas(i).AxisY.Maximum = Math.Round(Chart1.ChartAreas(i).AxisY.Maximum - k, 2)
                        End If
                        If Chart1.ChartAreas(i).AxisY.Minimum + k < Chart1.ChartAreas(i).AxisY.Maximum Then
                            Chart1.ChartAreas(i).AxisY.Minimum = Math.Round(Chart1.ChartAreas(i).AxisY.Minimum + k, 2)
                        End If
                        dgv_vars(3, 0).Value = Math.Round(Chart1.ChartAreas(i).AxisY.Minimum, 2)
                        dgv_vars(4, 0).Value = Math.Round(Chart1.ChartAreas(i).AxisY.Maximum, 2)
                        If dgv_vars.RowCount > 1 Then dgv_vars(3, 1).Value = Math.Round(Chart1.ChartAreas(i).AxisY.Minimum, 2)
                        If dgv_vars.RowCount > 1 Then dgv_vars(4, 1).Value = Math.Round(Chart1.ChartAreas(i).AxisY.Minimum, 2)
                    End If
                    If h.Axis.AxisName.ToString = "Y" AndAlso e.Delta < 0 Then
                        k = (Chart1.ChartAreas(i).AxisY.Maximum - Chart1.ChartAreas(i).AxisY.Minimum) * 5 / 100
                        Chart1.ChartAreas(i).AxisY.Maximum = Math.Round(Chart1.ChartAreas(i).AxisY.Maximum + k, 2)
                        Chart1.ChartAreas(i).AxisY.Minimum = Math.Round(Chart1.ChartAreas(i).AxisY.Minimum - k, 2)
                        dgv_vars(3, 0).Value = Math.Round(Chart1.ChartAreas(i).AxisY.Minimum, 2)
                        dgv_vars(4, 0).Value = Math.Round(Chart1.ChartAreas(i).AxisY.Maximum, 2)
                        If dgv_vars.RowCount > 1 Then dgv_vars(3, 1).Value = Math.Round(Chart1.ChartAreas(i).AxisY.Minimum, 2)
                        If dgv_vars.RowCount > 1 Then dgv_vars(4, 1).Value = Math.Round(Chart1.ChartAreas(i).AxisY.Minimum, 2)
                    End If
                    '
                    If h.Axis.AxisName.ToString = "Y2" AndAlso e.Delta > 0 AndAlso dgv_vars.RowCount > 1 Then
                        k = (Chart1.ChartAreas(i).AxisY2.Maximum - Chart1.ChartAreas(i).AxisY2.Minimum) * 5 / 100
                        If Chart1.ChartAreas(i).AxisY2.Maximum - k > Chart1.ChartAreas(i).AxisY2.Minimum Then
                            Chart1.ChartAreas(i).AxisY2.Maximum = Math.Round(Chart1.ChartAreas(i).AxisY2.Maximum - k, 2)
                        End If
                        If Chart1.ChartAreas(i).AxisY2.Minimum + k < Chart1.ChartAreas(i).AxisY2.Maximum Then
                            Chart1.ChartAreas(i).AxisY2.Minimum = Math.Round(Chart1.ChartAreas(i).AxisY2.Minimum + k, 2)
                        End If
                        For x = 2 To dgv_vars.RowCount - 1
                            dgv_vars(3, x).Value = Math.Round(Chart1.ChartAreas(i).AxisY2.Minimum, 2)
                            dgv_vars(4, x).Value = Math.Round(Chart1.ChartAreas(i).AxisY2.Maximum, 2)
                        Next
                    End If
                    If h.Axis.AxisName.ToString = "Y2" AndAlso e.Delta < 0 AndAlso dgv_vars.RowCount > 1 Then
                        k = (Chart1.ChartAreas(i).AxisY2.Maximum - Chart1.ChartAreas(i).AxisY2.Minimum) * 5 / 100
                        Chart1.ChartAreas(i).AxisY2.Maximum = Math.Round(Chart1.ChartAreas(i).AxisY2.Maximum + k, 2)
                        Chart1.ChartAreas(i).AxisY2.Minimum = Math.Round(Chart1.ChartAreas(i).AxisY2.Minimum - k, 2)
                        For x = 2 To dgv_vars.RowCount - 1
                            dgv_vars(3, x).Value = Math.Round(Chart1.ChartAreas(i).AxisY2.Minimum, 2)
                            dgv_vars(4, x).Value = Math.Round(Chart1.ChartAreas(i).AxisY2.Maximum, 2)
                        Next
                    End If
                Next
            End If
        Catch ex As Exception
            IO.File.AppendAllText(Application.StartupPath & "\ACP_LOG.txt", String.Format("{0}[{1}]{2}", Environment.NewLine, DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"), ex.ToString()))
        End Try
    End Sub
    Private Sub Chart1_MouseDown(sender As Object, e As MouseEventArgs) Handles Chart1.MouseDown
        Try
            Dim h As Windows.Forms.DataVisualization.Charting.HitTestResult = Chart1.HitTest(e.X, e.Y)
            If h.ChartElementType = DataVisualization.Charting.ChartElementType.AxisLabels AndAlso e.Button = MouseButtons.Left Then
                Dim min As String = ""
                Dim max As String = ""
                If h.Axis.AxisName.ToString = "Y" Then
                    min = InputBox("Introduce el nuevo MÍNIMO del EJE Y Primario", "Nuevo mínimo", "")
                    If IsNumeric(min) Then
                        min = min.Replace(".", decimalSeparator).Replace(",", decimalSeparator)
                        Chart1.ChartAreas(0).AxisY.Minimum = min
                        Chart1.ChartAreas(1).AxisY.Minimum = min
                        dgv_vars(3, 0).Value = min
                        If dgv_vars.RowCount > 1 Then dgv_vars(3, 1).Value = min
                    End If
                    max = InputBox("Introduce el nuevo MÁXIMO del EJE Y Primario", "Nuevo máximo", "")
                    If IsNumeric(max) Then
                        max = max.Replace(".", decimalSeparator).Replace(",", decimalSeparator)
                        Chart1.ChartAreas(0).AxisY.Maximum = max
                        Chart1.ChartAreas(1).AxisY.Maximum = max
                        dgv_vars(4, 0).Value = max
                        If dgv_vars.RowCount > 1 Then dgv_vars(4, 1).Value = max
                    End If
                End If
                If h.Axis.AxisName.ToString = "Y2" Then
                    min = InputBox("Introduce el nuevo MÍNIMO del EJE Y Secundario", "Nuevo mínimo", "")
                    If IsNumeric(min) Then
                        min = min.Replace(".", decimalSeparator).Replace(",", decimalSeparator)
                        Chart1.ChartAreas(0).AxisY2.Minimum = min
                        Chart1.ChartAreas(1).AxisY2.Minimum = min
                    End If
                    max = InputBox("Introduce el nuevo MÁXIMO del EJE Y Secundario", "Nuevo máximo", "")
                    If IsNumeric(max) Then
                        max = max.Replace(".", decimalSeparator).Replace(",", decimalSeparator)
                        Chart1.ChartAreas(0).AxisY2.Maximum = max
                        Chart1.ChartAreas(1).AxisY2.Maximum = max
                    End If
                End If
            End If
        Catch ex As Exception
            IO.File.AppendAllText(Application.StartupPath & "\ACP_LOG.txt", String.Format("{0}[{1}]{2}", Environment.NewLine, DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"), ex.ToString()))
        End Try
    End Sub
    Private Sub Chart1_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles Chart1.PreviewKeyDown
        Try
            Dim k As Single = 0
            If e.KeyCode = Keys.Up Then
                If sobreejey = True Then
                    k = (Chart1.ChartAreas(0).AxisY.Maximum - Chart1.ChartAreas(0).AxisY.Minimum) * 5 / 100
                    Chart1.ChartAreas(0).AxisY.Maximum = Math.Round(Chart1.ChartAreas(0).AxisY.Maximum - k, 2)
                    Chart1.ChartAreas(0).AxisY.Minimum = Math.Round(Chart1.ChartAreas(0).AxisY.Minimum - k, 2)
                    '
                    Chart1.ChartAreas(1).AxisY.Maximum = Math.Round(Chart1.ChartAreas(1).AxisY.Maximum - k, 2)
                    Chart1.ChartAreas(1).AxisY.Minimum = Math.Round(Chart1.ChartAreas(1).AxisY.Minimum - k, 2)
                    dgv_vars(3, 0).Value = Math.Round(Chart1.ChartAreas(0).AxisY.Minimum, 2)
                    dgv_vars(4, 0).Value = Math.Round(Chart1.ChartAreas(0).AxisY.Maximum, 2)
                    If dgv_vars.RowCount > 1 Then dgv_vars(3, 1).Value = Math.Round(Chart1.ChartAreas(0).AxisY.Minimum, 2)
                    If dgv_vars.RowCount > 1 Then dgv_vars(4, 1).Value = Math.Round(Chart1.ChartAreas(0).AxisY.Minimum, 2)
                End If
                If sobreejey2 = True AndAlso dgv_vars.RowCount > 1 Then
                    k = (Chart1.ChartAreas(0).AxisY2.Maximum - Chart1.ChartAreas(0).AxisY2.Minimum) * 5 / 100
                    Chart1.ChartAreas(0).AxisY2.Maximum = Math.Round(Chart1.ChartAreas(0).AxisY2.Maximum - k, 2)
                    Chart1.ChartAreas(0).AxisY2.Minimum = Math.Round(Chart1.ChartAreas(0).AxisY2.Minimum - k, 2)
                    '
                    Chart1.ChartAreas(1).AxisY2.Maximum = Math.Round(Chart1.ChartAreas(0).AxisY2.Maximum - k, 2)
                    Chart1.ChartAreas(1).AxisY2.Minimum = Math.Round(Chart1.ChartAreas(0).AxisY2.Minimum - k, 2)
                    For i = 2 To dgv_vars.RowCount - 1
                        dgv_vars(3, i).Value = Math.Round(Chart1.ChartAreas(0).AxisY2.Minimum, 2)
                        dgv_vars(4, i).Value = Math.Round(Chart1.ChartAreas(0).AxisY2.Maximum, 2)
                    Next
                End If
            End If
            If e.KeyCode = Keys.Down Then
                If sobreejey = True Then
                    k = (Chart1.ChartAreas(0).AxisY.Maximum - Chart1.ChartAreas(0).AxisY.Minimum) * 5 / 100
                    Chart1.ChartAreas(0).AxisY.Maximum = Math.Round(Chart1.ChartAreas(0).AxisY.Maximum + k, 2)
                    Chart1.ChartAreas(0).AxisY.Minimum = Math.Round(Chart1.ChartAreas(0).AxisY.Minimum + k, 2)
                    '
                    Chart1.ChartAreas(1).AxisY.Maximum = Math.Round(Chart1.ChartAreas(1).AxisY.Maximum + k, 2)
                    Chart1.ChartAreas(1).AxisY.Minimum = Math.Round(Chart1.ChartAreas(1).AxisY.Minimum + k, 2)
                    dgv_vars(3, 0).Value = Math.Round(Chart1.ChartAreas(0).AxisY.Minimum, 2)
                    dgv_vars(4, 0).Value = Math.Round(Chart1.ChartAreas(0).AxisY.Maximum, 2)
                    If dgv_vars.RowCount > 1 Then dgv_vars(3, 1).Value = Math.Round(Chart1.ChartAreas(0).AxisY.Minimum, 2)
                    If dgv_vars.RowCount > 1 Then dgv_vars(4, 1).Value = Math.Round(Chart1.ChartAreas(0).AxisY.Minimum, 2)
                End If
                If sobreejey2 = True AndAlso dgv_vars.RowCount > 1 Then
                    k = (Chart1.ChartAreas(0).AxisY2.Maximum - Chart1.ChartAreas(0).AxisY2.Minimum) * 5 / 100
                    Chart1.ChartAreas(0).AxisY2.Maximum = Math.Round(Chart1.ChartAreas(0).AxisY2.Maximum + k, 2)
                    Chart1.ChartAreas(0).AxisY2.Minimum = Math.Round(Chart1.ChartAreas(0).AxisY2.Minimum + k, 2)
                    '
                    Chart1.ChartAreas(1).AxisY2.Maximum = Math.Round(Chart1.ChartAreas(1).AxisY2.Maximum + k, 2)
                    Chart1.ChartAreas(1).AxisY2.Minimum = Math.Round(Chart1.ChartAreas(1).AxisY2.Minimum + k, 2)
                    For i = 2 To dgv_vars.RowCount - 1
                        dgv_vars(3, i).Value = Math.Round(Chart1.ChartAreas(0).AxisY2.Minimum, 2)
                        dgv_vars(4, i).Value = Math.Round(Chart1.ChartAreas(0).AxisY2.Maximum, 2)
                    Next
                End If
            End If
        Catch ex As Exception
            IO.File.AppendAllText(Application.StartupPath & "\ACP_LOG.txt", String.Format("{0}[{1}]{2}", Environment.NewLine, DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"), ex.ToString()))
        End Try
    End Sub
    Private Sub Chart_simula_MouseDown(sender As Object, e As MouseEventArgs) Handles Chart_simula.MouseDown
        Try
            Dim h As Windows.Forms.DataVisualization.Charting.HitTestResult = Chart_simula.HitTest(e.X, e.Y)
            If h.ChartElementType = DataVisualization.Charting.ChartElementType.AxisLabels AndAlso e.Button = MouseButtons.Left Then
                Dim min As String = ""
                Dim max As String = ""
                If h.Axis.AxisName.ToString = "Y" Then
                    min = InputBox("Introduce el nuevo MÍNIMO del EJE Y Primario", "Nuevo mínimo", "")
                    If IsNumeric(min) Then
                        min = min.Replace(".", decimalSeparator).Replace(",", decimalSeparator)
                        Chart_simula.ChartAreas(0).AxisY.Minimum = min
                        dgv_vars(3, 0).Value = min
                        'If dgv_vars.RowCount > 1 Then dgv_vars(3, 1).Value = min
                    End If
                    max = InputBox("Introduce el nuevo MÁXIMO del EJE Y Primario", "Nuevo máximo", "")
                    If IsNumeric(max) Then
                        max = max.Replace(".", decimalSeparator).Replace(",", decimalSeparator)
                        Chart_simula.ChartAreas(0).AxisY.Maximum = max
                        dgv_vars(4, 0).Value = max
                        'If dgv_vars.RowCount > 1 Then dgv_vars(4, 1).Value = max
                    End If
                End If
                If h.Axis.AxisName.ToString = "Y2" Then
                    min = InputBox("Introduce el nuevo MÍNIMO del EJE Y Secundario", "Nuevo mínimo", "")
                    If IsNumeric(min) Then
                        min = min.Replace(".", decimalSeparator).Replace(",", decimalSeparator)
                        Chart_simula.ChartAreas(0).AxisY2.Minimum = min
                    End If
                    max = InputBox("Introduce el nuevo MÁXIMO del EJE Y Secundario", "Nuevo máximo", "")
                    If IsNumeric(max) Then
                        max = max.Replace(".", decimalSeparator).Replace(",", decimalSeparator)
                        Chart_simula.ChartAreas(0).AxisY2.Maximum = max
                    End If
                End If
            End If
        Catch ex As Exception
            IO.File.AppendAllText(Application.StartupPath & "\ACP_LOG.txt", String.Format("{0}[{1}]{2}", Environment.NewLine, DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"), ex.ToString()))
        End Try
    End Sub
    Private Sub btn_abrir_Click_1(sender As Object, e As EventArgs) Handles btn_abrir.Click
        If Not (System.IO.Directory.Exists(export)) Then
            System.IO.Directory.CreateDirectory(export)
        End If
        Dim FBD As New FolderBrowserDialog
        'FBD.RootFolder = Environment.SpecialFolder.MyComputer
        FBD.SelectedPath = export
        If (FBD.ShowDialog() = DialogResult.OK) Then
            proyecto = FBD.SelectedPath
            nombreproyecto = Path.GetFileName(FBD.SelectedPath)
        Else
            Exit Sub
        End If
        Try
            Me.Cursor = Cursors.WaitCursor
            With My.Application.Info.Version
                Me.Text = "Arduino COM Plotter " & .Major.ToString & "." & .Minor.ToString & "      |      Proyecto[" & nombreproyecto & "]"
            End With
            Application.DoEvents()
            'Config
            LeerConfig(proyecto & "\ACP_config.txt")
            'DGV
            dgv_vars.DataSource = ""
                tbl.Clear()
            'tbl.ReadXml(DirList(sel).ToString & "\ACP_dgv.txt")
            tbl.ReadXml(proyecto & "\ACP_dgv.txt")
            dgv_vars.DataSource = tbl
            'LOG
            'Txt_datos.Text = ""
            'Txt_datos.LoadFile(DirList(sel).ToString & "\ACP_txt.txt", RichTextBoxStreamType.PlainText)
            '
            'Dim lineCount As Long = Txt_datos.Lines.Count()
            'Dim cada_seg As Single = CSng(Num_delay.Value / 1000)
            'Dim segundos As Single = CSng(((lineCount - 1) * cada_seg)) ' Dim segundos As Single = (lineCount - 1 + cada_seg)
            'Dim mytime As TimeSpan = TimeSpan.FromSeconds(segundos)
            'Dim mydate As DateTime = New DateTime(mytime.Ticks)
            'Lbl_lineas.Text = lineCount.ToString() & " líneas | Duración " & mydate.ToString("HH:mm:ss")
            Lbl_lineas.Text = ""
            'Chart
            'Borrar series 
            series.Clear()
                Chart1.Annotations.Clear()
                Chart1.Series.Clear()
                For i = 0 To Num_vars.Value - 1
                    series.Add(i)
                Next
            Chart1.Serializer.IsResetWhenLoading = True 'Chart1.Serializer.IsResetWhenLoading = False
            Chart1.Serializer.Load(proyecto & "\ACP_chart.bin")
            Tiempo = Chart1.ChartAreas(0).AxisX.Maximum
            contador = num_ventana.Value - 1
            '
            Btn_guardarP.Enabled = True
            Btn_exportarP.Enabled = True
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            IO.File.AppendAllText(Application.StartupPath & "\ACP_LOG.txt", String.Format("{0}[{1}]{2}", Environment.NewLine, DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"), ex.ToString()))
        End Try
    End Sub
    Private Sub Num_vars_ValueChanged_1(sender As Object, e As EventArgs) Handles Num_vars.ValueChanged
        Try
            If dgv_vars.RowCount < Num_vars.Value Then
                tbl.Rows.Add(True, "Nombre" & Num_vars.Value, "", "0", "100", False, True)
                series.Add(0.0)
                '
                Chart1.Series.Add("Serie" & Num_vars.Value)
                Chart1.Series("Serie" & Num_vars.Value).IsXValueIndexed = False
                Chart1.Series("Serie" & Num_vars.Value).BorderWidth = 2
                Chart1.Series("Serie" & Num_vars.Value).ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
                Chart1.Series("Serie" & Num_vars.Value).ChartArea = "ChartArea1"
                If Num_vars.Value < 17 Then Chart1.Series("Serie" & Num_vars.Value).Color = colors(Num_vars.Value - 1)
                'Chart1.Series("Serie" & Num_vars.Value).ToolTip = "#SERIESNAME\nValor: #VALY\nSegundo #VALX\nMin: #MIN\nMax: #MAX\nMedia: #AVG{D0}"
                '
                'Ejes Y - Asigno Ejes (2 primeras series primary, resto secondary)
                If Num_vars.Value > 1 Then
                    Chart1.Series("Serie" & Num_vars.Value).YAxisType = DataVisualization.Charting.AxisType.Secondary
                Else
                    Chart1.Series("Serie" & Num_vars.Value).YAxisType = DataVisualization.Charting.AxisType.Primary
                End If
                'If Num_vars.Value = 0 Then Chart1.Series("Serie" & Num_vars.Value).Color = Color.Blue
                'If Num_vars.Value = 1 Then Chart1.Series("Serie" & Num_vars.Value).Color = Color.Fuchsia
                'If Num_vars.Value = 2 Then Chart1.Series("Serie" & Num_vars.Value).Color = Color.Yellow
            End If
            If dgv_vars.RowCount > Num_vars.Value Then
                tbl.Rows.RemoveAt(Num_vars.Value)
                series.RemoveAt(Num_vars.Value)
                Chart1.Series.RemoveAt(Num_vars.Value)
            End If
        Catch ex As Exception
            'Console.WriteLine("Num_vars_ValueChanged " & ex.ToString)
        End Try
    End Sub
    Private Sub Num_delay_ValueChanged_1(sender As Object, e As EventArgs) Handles Num_delay.ValueChanged
        Timer1.Interval = Num_delay.Value
        Txt_muestreo.Text = (Num_delay.Value / 1000).ToString
    End Sub
    Private Sub num_ventana_ValueChanged_1(sender As Object, e As EventArgs) Handles num_ventana.ValueChanged
        Try
            If Chart1.Series.Count > 0 Then

                If Chart1.Series(0).Points.Count >= num_ventana.Value Then
                    For i = 0 To 1
                        Chart1.ChartAreas(i).AxisY.ScaleView.ZoomReset(0)
                        Chart1.ChartAreas(i).CursorY.SelectionEnd = Double.NaN
                        'Chart1.ChartAreas(i).AxisX.Maximum = num_ventana.Value
                        Chart1.ChartAreas(i).AxisX.ScaleView.Zoom(Chart1.ChartAreas(i).AxisX.Maximum - num_ventana.Value, Chart1.ChartAreas(i).AxisX.Maximum)
                    Next
                Else
                    For i = 0 To 1
                        Chart1.ChartAreas(i).AxisX.Maximum = num_ventana.Value
                        Chart1.ChartAreas(i).AxisX.ScaleView.Zoom(0, Chart1.ChartAreas(i).AxisX.Maximum)
                    Next
                End If
            End If
        Catch ex As Exception
            'Console.WriteLine("num_ventana " & ex.ToString)
        End Try
    End Sub
    Private Sub Cbo_velocidad_SelectedIndexChanged_1(sender As Object, e As EventArgs)
        Try
            comPort.BaudRate = Cbo_velocidad_2.Text
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Cbo_comports_Click(sender As Object, e As EventArgs) Handles Cbo_comports.Click
        Try
            GetSerialPortNames()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Btn_conectarDark_Click_1(sender As Object, e As EventArgs) Handles Btn_conectarDark.Click
        Connect()
        Timer1.Start()
        Btn_conectarDark.Enabled = False
        Btn_desconectarDark.Enabled = True
        Num_delay.Enabled = False
        txt_separador.Enabled = False
        txt_inicio.Enabled = False
        Num_vars.Enabled = False
        btn_abrir.Enabled = False
        Btn_guardarP.Enabled = True
    End Sub
    Private Sub Btn_desconectarDark_Click_1(sender As Object, e As EventArgs) Handles Btn_desconectarDark.Click
        Disconnect()
        Timer1.Stop()
        Btn_conectarDark.Enabled = True
        Btn_desconectarDark.Enabled = False
        Num_delay.Enabled = True
        txt_separador.Enabled = True
        txt_inicio.Enabled = True
        Num_vars.Enabled = True
        btn_abrir.Enabled = True
    End Sub
    Private Sub txt_separador_TextChanged(sender As Object, e As EventArgs) Handles txt_separador.TextChanged
        Try
            Dim asciis As Byte() = System.Text.Encoding.ASCII.GetBytes(txt_separador.Text)
            If Asc(txt_separador.Text) = 32 Then
                lbl_separador.Text = "Chr(" & Asc(txt_separador.Text) & ") (espacio)"
            Else
                lbl_separador.Text = "Chr(" & Asc(txt_separador.Text) & ") (" & System.Text.Encoding.ASCII.GetString(asciis) & ")"
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Btn_reset_Click(sender As Object, e As EventArgs) Handles Btn_reset.Click
        Try
            With My.Application.Info.Version
                Me.Text = "Arduino COM Plotter " & .Major.ToString & "." & .Minor.ToString & "      |      Proyecto[sin guardar]"
            End With
            Timer1.Stop()
            Btn_desconectarDark.PerformClick()
            Btn_guardarP.Enabled = False
            Btn_exportarP.Enabled = False
            proyecto = ""
            contador = 0
            Tiempo = 0
            Lbl_info.Text = ""
            Lbl_lineas.Text = ""
            Num_vars.Value = 3
            Chart1.Annotations.Clear()
            Chart1.Series.Clear()
            Chart1.ChartAreas(0).AxisX.ScaleView.Zoom(0, num_ventana.Value)
            Chart1.ChartAreas(1).AxisX.ScaleView.Zoom(0, num_ventana.Value)
            'DGV
            tbl.Clear()
            tbl = New DataTable("miTabla")
            dgv_vars.DataSource = ""
            tbl.Columns.Add(" ", GetType(Boolean))
            tbl.Columns.Add("Nombre", GetType(String))
            tbl.Columns.Add("Valor", GetType(String))
            tbl.Columns.Add("Y min", GetType(String))
            tbl.Columns.Add("Y max", GetType(String))
            tbl.Columns.Add("Primario", GetType(Boolean))
            tbl.Columns.Add("Serie arriba", GetType(Boolean))
            tbl.Rows.Add(True, "Nombre1", "", "0", "100", True, True)
            tbl.Rows.Add(True, "Nombre2", "", "0", "100", True, True)
            tbl.Rows.Add(True, "Nombre3", "", "-5", "105", False, True)
            '
            dgv_vars.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
            dgv_vars.AllowUserToResizeColumns = True
            dgv_vars.RowHeadersVisible = False
            dgv_vars.DataSource = tbl
            gridcolor(dgv_vars)
            series.Clear()
            For i = 0 To 2
                series.Add(0.0)
                Chart1.Series.Add("Serie" & i)
                Chart1.Series("Serie" & i).IsXValueIndexed = False
                Chart1.Series("Serie" & i).BorderWidth = 2
                Chart1.Series("Serie" & i).ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
                'Chart1.Series("Serie" & i).ToolTip = "#SERIESNAME\nValor: #VALY\nSegundo #VALX\nMin: #MIN\nMax: #MAX\nMedia: #AVG{D0}"
            Next
            Txt_datos.Text = ""
            Txt_datos.HideSelection = False
            'txt_separador.Text = Chr(32)
            'txt_inicio.Text = "#"
            For i = 0 To 1
                Chart1.ChartAreas(i).AxisX.Title = "Tiempo (segundos)"
                Chart1.ChartAreas(i).AxisX.ScaleView.Zoomable = True
                Chart1.ChartAreas(i).AxisY.ScaleView.Zoomable = True
                Chart1.ChartAreas(i).AxisY2.ScaleView.Zoomable = True
                Chart1.ChartAreas(i).CursorX.IsUserSelectionEnabled = True
                Chart1.ChartAreas(i).CursorY.IsUserSelectionEnabled = True
                Chart1.ChartAreas(i).CursorX.AutoScroll = True
                Chart1.ChartAreas(i).CursorY.AutoScroll = True
                Chart1.ChartAreas(i).AxisY.Minimum = [Double].NaN
                Chart1.ChartAreas(i).AxisY.Maximum = [Double].NaN
                Chart1.ChartAreas(i).AxisY2.Minimum = [Double].NaN
                Chart1.ChartAreas(i).AxisY2.Maximum = [Double].NaN
                Chart1.ChartAreas(i).AxisY.Maximum = 100
                Chart1.ChartAreas(i).AxisY.Minimum = 0
                Chart1.ChartAreas(i).AxisY2.Maximum = 105
                Chart1.ChartAreas(i).AxisY2.Minimum = -5
                Chart1.ChartAreas(i).AxisX.Minimum = 0
                Chart1.ChartAreas(i).AxisX.Maximum = num_ventana.Value
                Chart1.ChartAreas(i).AxisY.ScaleView.ZoomReset(0)
                Chart1.ChartAreas(i).AxisX.ScaleView.ZoomReset(0)
                Chart1.ChartAreas(i).AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.SmallScroll
            Next
            Chart1.ChartAreas(1).Visible = False
            Chart1.Series(0).IsXValueIndexed = False
            Chart1.Series(1).IsXValueIndexed = False
            Chart1.Series(2).IsXValueIndexed = False
            Chart1.Series(0).Color = Color.Blue
            Chart1.Series(0).Name = dgv_vars(1, 0).Value
            Chart1.Series(0).LegendText = dgv_vars(1, 0).Value
            Chart1.Series(0).YAxisType = DataVisualization.Charting.AxisType.Primary
            Chart1.Series(1).Color = Color.Fuchsia
            Chart1.Series(1).Name = dgv_vars(1, 1).Value
            Chart1.Series(1).LegendText = dgv_vars(1, 1).Value
            Chart1.Series(1).YAxisType = DataVisualization.Charting.AxisType.Primary
            Chart1.Series(2).Color = Color.Yellow
            Chart1.Series(2).Name = dgv_vars(1, 2).Value
            Chart1.Series(2).LegendText = dgv_vars(1, 2).Value
            Chart1.Series(2).YAxisType = DataVisualization.Charting.AxisType.Secondary
        Catch ex As Exception
            'Console.WriteLine("RESET " & ex.ToString)
        End Try
    End Sub
    Private Sub btn_captura_Click_1(sender As Object, e As EventArgs) Handles btn_captura.Click
        Try
            If Not (System.IO.Directory.Exists(Application.StartupPath + "\Export\")) Then
                System.IO.Directory.CreateDirectory(Application.StartupPath + "\Export\")
            End If
            Dim img As Image
            If proyecto = "" Then
                Chart1.SaveImage(Application.StartupPath + "\Export\ACP_" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss") + ".png", ChartImageFormat.Png)
                img = Image.FromFile(Application.StartupPath + "\Export\ACP_" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss") + ".png")
                System.Windows.Forms.Clipboard.SetImage(img)
            Else
                Chart1.SaveImage(proyecto + "\ACP_" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss") + ".png", ChartImageFormat.Png)
                img = Image.FromFile(proyecto + "\ACP_" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss") + ".png")
                System.Windows.Forms.Clipboard.SetImage(img)
            End If
            Lbl_info.Text = "Captura guardada correctamente. " & DateTime.Now
        Catch ex As Exception
            Console.WriteLine("Captura " & ex.ToString)
        End Try
    End Sub
    Private Sub Btn_ampliarTiempo_Click_1(sender As Object, e As EventArgs) Handles Btn_ampliarTiempo.Click
        Try
            If Chart1.Series.Count > 0 Then
                Application.DoEvents()
                Chart1.ChartAreas(0).AxisY.ScaleView.ZoomReset(0)
                Chart1.ChartAreas(0).AxisX.ScaleView.ZoomReset(0)
                '
                Chart1.ChartAreas(1).AxisY.ScaleView.ZoomReset(0)
                Chart1.ChartAreas(1).AxisX.ScaleView.ZoomReset(0)
                Chart1.Invalidate()
                'Chart1.ChartAreas(0).AxisX.ScaleView.Zoom(0, Chart1.Series(0).Points.Count)
                'Chart1.ChartAreas(0).AxisX.ScaleView.Zoom(0, Chart1.ChartAreas(0).AxisX.Maximum)
            End If
        Catch ex As Exception
            'Console.WriteLine(Chart1.Series(0).Points.Count)
        End Try
    End Sub
    Private Sub Btn_guardarP_Click(sender As Object, e As EventArgs) Handles Btn_guardarP.Click
        Try
            If Not (System.IO.Directory.Exists(export)) Then
                System.IO.Directory.CreateDirectory(export)
            End If
            If proyecto = "" Then
                Dim Answer As String = InputBox("Especifica el nombre del proyecto")
                If String.ReferenceEquals(Answer, String.Empty) Then
                    Exit Sub
                ElseIf Answer = "" Then
                    Exit Sub
                Else
                    nombreproyecto = Answer
                    proyecto = Application.StartupPath & "\Export\" & Answer
                    If Not (System.IO.Directory.Exists(proyecto)) Then
                        System.IO.Directory.CreateDirectory(proyecto)
                    End If
                    'DGV
                    tbl.WriteXml(proyecto & "\ACP_dgv.txt")
                    'TXT
                    'Txt_datos.SaveFile(proyecto & "\ACP_txt.txt", RichTextBoxStreamType.PlainText)
                    'Chart
                    Dim myStream As New System.IO.MemoryStream()
                    Chart1.Serializer.Save(myStream)
                    File.WriteAllBytes(proyecto & "\ACP_chart.bin", myStream.ToArray())
                    Chart1.SaveImage(proyecto + "\ACP_" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss") + ".png", ChartImageFormat.Png)
                    'Config
                    GuardarConfig(proyecto & "\ACP_config.txt")
                End If
                With My.Application.Info.Version
                    Me.Text = "Arduino COM Plotter " & .Major.ToString & "." & .Minor.ToString & "      |      Proyecto[" & Answer & "]"
                End With
                MsgBox("Proyecto guardado correctamente." + vbNewLine + vbNewLine + "Puedes encontrar el archivo en la carpeta EXPORT.", vbOKOnly + vbInformation, "Guardar")
                Btn_exportarP.Enabled = True
            Else
                'DGV
                tbl.WriteXml(proyecto & "\ACP_dgv.txt")
                'TXT
                Txt_datos.SaveFile(proyecto & "\ACP_txt.txt", RichTextBoxStreamType.PlainText)
                'Chart
                Dim myStream As New System.IO.MemoryStream()
                Chart1.Serializer.Save(myStream)
                File.WriteAllBytes(proyecto & "\ACP_chart.bin", myStream.ToArray())
                Chart1.SaveImage(proyecto + "\ACP_" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss") + ".png", ChartImageFormat.Png)
                'Config
                GuardarConfig(proyecto & "\ACP_config.txt")
                '
                Lbl_info.Text = "Proyecto guardado correctamente. " & DateTime.Now
            End If
            '
        Catch ex As Exception
            Btn_exportarP.Enabled = False
        End Try
    End Sub
    Private Sub Btn_exportarP_Click(sender As Object, e As EventArgs) Handles Btn_exportarP.Click
        Try
            If proyecto <> "" Then
                ZipFile.CreateFromDirectory(proyecto, export + nombreproyecto + "_" + Now.ToString("ddMMyy_HHmmss") + ".zip", CompressionLevel.Optimal, False)
                MsgBox("Proyecto " + nombreproyecto + " exportado correctamente.", MsgBoxStyle.OkOnly, nombreproyecto + "_" + Now.ToString("ddMMyy_HHmmss") + ".zip")
                Process.Start("explorer.exe", export)
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Tv_metodos_MouseDown(sender As Object, e As MouseEventArgs) Handles Tv_metodos.MouseDown
        Try
            metodo = ""
            For Each node In Tv_metodos.SelectedNodes
                If Txt_K.Text <> "" AndAlso Txt_To.Text <> "" AndAlso Txt_To.Text <> "" AndAlso Txt_Tp.Text <> "" Then
                    Dim K As Double = CDbl(Txt_K.Text)
                    Dim T0 As Double = CDbl(Txt_To.Text)
                    Dim Tp As Double = CDbl(Txt_Tp.Text)
                    Dim Tf As Double = CDbl(Txt_Tf.Text)
                    If node.ParentNode.Text = "CC-25" AndAlso node.Text = "P" Then
                        Txt_Kc.Text = ((1 / K) * (Tp / T0) * (1 + (T0 / (3 * Tp)))).ToString("####0.00")
                        Txt_Ti.Text = 0
                        Txt_Td.Text = 0
                        metodo = node.ParentNode.Text & " | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
                    ElseIf node.ParentNode.Text = "CC-25" AndAlso node.Text = "PI" Then
                        Txt_Kc.Text = ((1 / K) * (Tp / T0) * (0.9 + (T0 / (12 * Tp)))).ToString("####0.00")
                        Txt_Ti.Text = (T0 * (30 + 3 * (T0 / Tp)) / (9 + 20 * (T0 / Tp))).ToString("####0.00")
                        Txt_Td.Text = 0
                        metodo = node.ParentNode.Text & " | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
                    ElseIf node.ParentNode.Text = "CC-25" AndAlso node.Text = "PID" Then
                        Txt_Kc.Text = ((1 / K) * (Tp / T0) * (16 * Tp + (3 * T0)) / (12 * Tp)).ToString("####0.00")
                        Txt_Ti.Text = (T0 * (32 + 6 * (T0 / Tp)) / (13 + 8 * (T0 / Tp))).ToString("####0.00")
                        Txt_Td.Text = (4 * T0 / (11 + 2 * (T0 / Tp))).ToString("####0.00")
                        metodo = node.ParentNode.Text & " | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
                    ElseIf node.ParentNode.Text = "CC-10" AndAlso node.Text = "P" Then
                        Txt_Kc.Text = ((1 / K) * (Tp / T0) * (1 + (T0 / (3 * Tp))) * 0.6).ToString("####0.00")
                        Txt_Ti.Text = 0
                        Txt_Td.Text = 0
                        metodo = node.ParentNode.Text & " | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
                        If CInt(Txt_Tp.Text.Trim) < CInt(Txt_To.Text.Trim) / 2 Then MsgBox("El sistema no cumple con la condición 𝑇𝑝>𝑇o/2", vbOKOnly + vbInformation, "Aviso")
                    ElseIf node.ParentNode.Text = "CC-10" AndAlso node.Text = "PI" Then
                        Txt_Kc.Text = ((1 / K) * (Tp / T0) * (0.9 + (T0 / (12 * Tp))) * 0.6).ToString("####0.00")
                        Txt_Ti.Text = (T0 * (30 + 3 * (T0 / Tp)) / (9 + 20 * (T0 / Tp)) * 1.2).ToString("####0.00")
                        Txt_Td.Text = 0
                        metodo = node.ParentNode.Text & " | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
                        If CInt(Txt_Tp.Text.Trim) < CInt(Txt_To.Text.Trim) / 2 Then MsgBox("El sistema no cumple con la condición 𝑇𝑝>𝑇o/2", vbOKOnly + vbInformation, "Aviso")
                    ElseIf node.ParentNode.Text = "CC-10" AndAlso node.Text = "PID" Then
                        Txt_Kc.Text = ((1 / K) * (Tp / T0) * (16 * Tp + (3 * T0)) / (12 * Tp) * 0.6).ToString("####0.00")
                        Txt_Ti.Text = (T0 * (32 + 6 * (T0 / Tp)) / (13 + 8 * (T0 / Tp)) * 1.2).ToString("####0.00")
                        Txt_Td.Text = (4 * T0 / (11 + 2 * (T0 / Tp))).ToString("####0.00")
                        metodo = node.ParentNode.Text & " | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
                        If CInt(Txt_Tp.Text.Trim) < CInt(Txt_To.Text.Trim) / 2 Then MsgBox("El sistema no cumple con la condición 𝑇𝑝>𝑇o/2", vbOKOnly + vbInformation, "Aviso")
                    ElseIf node.ParentNode.Text = "ZN-LA-25" AndAlso node.Text = "P" Then
                        Txt_Kc.Text = (Tp / (K * T0)).ToString("####0.00")
                        Txt_Ti.Text = 0
                        Txt_Td.Text = 0
                        metodo = node.ParentNode.Text & " | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
                    ElseIf node.ParentNode.Text = "ZN-LA-25" AndAlso node.Text = "PI" Then
                        Txt_Kc.Text = (Tp / (K * T0) * 0.9).ToString("####0.00")
                        Txt_Ti.Text = (T0 / 0.3).ToString("####0.00")
                        Txt_Td.Text = 0
                        metodo = node.ParentNode.Text & " | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
                    ElseIf node.ParentNode.Text = "ZN-LA-25" AndAlso node.Text = "PID" Then
                        Txt_Kc.Text = ((Tp / (K * T0) * 1.2) * ((2 * T0) + (0.5 * T0)) / (2 * T0)).ToString("####0.00")
                        Txt_Ti.Text = ((2 * T0) + (0.5 * T0)).ToString("####0.00")
                        Txt_Td.Text = ((0.5 * T0) * (2 * T0) / ((2 * T0) + (0.5 * T0))).ToString("####0.00")
                        metodo = node.ParentNode.Text & " | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
                    ElseIf node.ParentNode.Text = "ZN-LA-10" AndAlso node.Text = "P" Then
                        Txt_Kc.Text = (Tp / (K * T0) * 0.666).ToString("####0.00")
                        Txt_Ti.Text = 0
                        Txt_Td.Text = 0
                        metodo = node.ParentNode.Text & " | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
                        If CInt(Txt_Tp.Text.Trim) < CInt(Txt_To.Text.Trim) * 2 Then MsgBox("El sistema no cumple con la condición Tp>2*To", vbOKOnly + vbInformation, "Aviso")
                    ElseIf node.ParentNode.Text = "ZN-LA-10" AndAlso node.Text = "PI" Then
                        Txt_Kc.Text = (Tp / (K * T0) * 0.9 * 0.666).ToString("####0.00")
                        Txt_Ti.Text = (T0 / 0.3).ToString("####0.00")
                        Txt_Td.Text = 0
                        metodo = node.ParentNode.Text & " | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
                        If CInt(Txt_Tp.Text.Trim) < CInt(Txt_To.Text.Trim) * 2 Then MsgBox("El sistema no cumple con la condición Tp>2*To", vbOKOnly + vbInformation, "Aviso")
                    ElseIf node.ParentNode.Text = "ZN-LA-10" AndAlso node.Text = "PID" Then
                        Txt_Kc.Text = ((Tp / (K * T0) * 1.2 * 0.666) * ((2 * T0) + (0.5 * T0)) / (2 * T0)).ToString("####0.00")
                        Txt_Ti.Text = ((2 * T0) + (0.5 * T0)).ToString("####0.00")
                        Txt_Td.Text = ((0.5 * T0) * (2 * T0) / ((2 * T0) + (0.5 * T0))).ToString("####0.00")
                        metodo = node.ParentNode.Text & " | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
                        If CInt(Txt_Tp.Text.Trim) < CInt(Txt_To.Text.Trim) * 2 Then MsgBox("El sistema no cumple con la condición Tp>2*To", vbOKOnly + vbInformation, "Aviso")
                    ElseIf node.ParentNode.Text = "Lambda" AndAlso node.Text = "PI" Then
                        If Txt_Tf.Text <> "" Then
                            Txt_Kc.Text = (Tp / (K * (Tf + T0))).ToString("####0.00")
                            Txt_Ti.Text = Tp.ToString("####0.00")
                            Txt_Td.Text = 0
                            metodo = node.ParentNode.Text & " | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text & " (Tf: " & Txt_Tf.Text & ")"
                        End If
                    ElseIf node.ParentNode.Text = "Lambda" AndAlso node.Text = "PID" Then
                        If Txt_Tf.Text <> "" Then
                            Txt_Kc.Text = ((Tp + T0 / 2) / (K * (Tf + T0 / 2))).ToString("####0.00")
                            Txt_Ti.Text = (Tp + T0 / 2).ToString("####0.00")
                            Txt_Td.Text = (Tp * T0 / (2 * Tp + T0)).ToString("####0.00")
                            metodo = node.ParentNode.Text & " | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text & " (Tf: " & Txt_Tf.Text & ")"
                        End If
                    ElseIf node.ParentNode.Text = "IMC" AndAlso node.Text = "PI" Then
                        If Txt_Tf.Text <> "" Then
                            Txt_Kc.Text = ((Tp + T0 / 4) / (K * Tf)).ToString("####0.00")
                            Txt_Ti.Text = (Tp + T0 / 4).ToString("####0.00")
                            Txt_Td.Text = 0
                            metodo = node.ParentNode.Text & " | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text & " (Tf: " & Txt_Tf.Text & ")"
                        End If
                    ElseIf node.ParentNode.Text = "ITAE-C" AndAlso node.Text = "PI" Then
                        Txt_Kc.Text = (1 / K * 0.859 * Math.Pow(T0 / Tp, -0.977)).ToString("####0.00")
                        Txt_Ti.Text = (Tp / (0.674 * Math.Pow(T0 / Tp, -0.68))).ToString("####0.00")
                        Txt_Td.Text = 0
                        metodo = node.ParentNode.Text & " | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
                        If CInt(Txt_Tp.Text.Trim) < CInt(Txt_To.Text.Trim) Then MsgBox("El sistema no cumple con la condición Tp>T0", vbOKOnly + vbInformation, "Aviso")
                    ElseIf node.ParentNode.Text = "ITAE-C" AndAlso node.Text = "PID" Then
                        Txt_Kc.Text = (1 / K * 1.357 * Math.Pow(T0 / Tp, -0.947)).ToString("####0.00")
                        Txt_Ti.Text = (Tp / (0.842 * Math.Pow(T0 / Tp, -0.738))).ToString("####0.00")
                        Txt_Td.Text = (Tp * 0.381 * Math.Pow(T0 / Tp, 0.995)).ToString("####0.00")
                        metodo = node.ParentNode.Text & " | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
                        If CInt(Txt_Tp.Text.Trim) < CInt(Txt_To.Text.Trim) Then MsgBox("El sistema no cumple con la condición Tp>T0", vbOKOnly + vbInformation, "Aviso")
                    ElseIf node.ParentNode.Text = "ITAE-SP" AndAlso node.Text = "PI" Then
                        Txt_Kc.Text = (1 / K * 0.586 * Math.Pow(T0 / Tp, -0.916)).ToString("####0.00")
                        Txt_Ti.Text = (Tp / (-0.165 * Math.Pow(T0 / Tp, 1) + 1.03)).ToString("####0.00")
                        Txt_Td.Text = 0
                        metodo = node.ParentNode.Text & " | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
                        If CInt(Txt_Tp.Text.Trim) < CInt(Txt_To.Text.Trim) Then MsgBox("El sistema no cumple con la condición Tp>T0", vbOKOnly + vbInformation, "Aviso")
                    ElseIf node.ParentNode.Text = "ITAE-SP" AndAlso node.Text = "PID" Then
                        Txt_Kc.Text = (1 / K * 0.965 * Math.Pow(T0 / Tp, -0.855)).ToString("####0.00")
                        Txt_Ti.Text = (Tp / (-0.147 * Math.Pow(T0 / Tp, 1) + 0.796)).ToString("####0.00")
                        Txt_Td.Text = (Tp * 0.308 * Math.Pow(T0 / Tp, 0.929)).ToString("####0.00")
                    ElseIf node.ParentNode.Text = "IAE-C" AndAlso node.Text = "PI" Then
                        Txt_Kc.Text = (1 / K * 0.984 * Math.Pow(T0 / Tp, -0.986)).ToString("####0.00")
                        Txt_Ti.Text = (Tp / (0.608 * Math.Pow(T0 / Tp, -0.707))).ToString("####0.00")
                        Txt_Td.Text = 0
                        metodo = node.ParentNode.Text & " | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
                        If CInt(Txt_Tp.Text.Trim) < CInt(Txt_To.Text.Trim) Then MsgBox("El sistema no cumple con la condición Tp>T0", vbOKOnly + vbInformation, "Aviso")
                    ElseIf node.ParentNode.Text = "IAE-C" AndAlso node.Text = "PID" Then
                        Txt_Kc.Text = (1 / K * 1.435 * Math.Pow(T0 / Tp, -0.921)).ToString("####0.00")
                        Txt_Ti.Text = (Tp / (0.878 * Math.Pow(T0 / Tp, -0.749))).ToString("####0.00")
                        Txt_Td.Text = (Tp * 0.482 * Math.Pow(T0 / Tp, 1.137)).ToString("####0.00")
                        metodo = node.ParentNode.Text & " | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
                        If CInt(Txt_Tp.Text.Trim) < CInt(Txt_To.Text.Trim) Then MsgBox("El sistema no cumple con la condición Tp>T0", vbOKOnly + vbInformation, "Aviso")
                    ElseIf node.ParentNode.Text = "IAE-SP" AndAlso node.Text = "PI" Then
                        Txt_Kc.Text = (1 / K * 0.758 * Math.Pow(T0 / Tp, -0.861)).ToString("####0.00")
                        Txt_Ti.Text = (Tp / (-0.323 * Math.Pow(T0 / Tp, 1) + 1.02)).ToString("####0.00")
                        Txt_Td.Text = 0
                        metodo = node.ParentNode.Text & " | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
                        If CInt(Txt_Tp.Text.Trim) < CInt(Txt_To.Text.Trim) Then MsgBox("El sistema no cumple con la condición Tp>T0", vbOKOnly + vbInformation, "Aviso")
                    ElseIf node.ParentNode.Text = "IAE-SP" AndAlso node.Text = "PID" Then
                        Txt_Kc.Text = (1 / K * 1.086 * Math.Pow(T0 / Tp, -0.869)).ToString("####0.00")
                        Txt_Ti.Text = (Tp / (-0.13 * Math.Pow(T0 / Tp, 1) + 0.74)).ToString("####0.00")
                        Txt_Td.Text = (Tp * 0.348 * Math.Pow(T0 / Tp, 0.914)).ToString("####0.00")
                        metodo = node.ParentNode.Text & " | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
                        If CInt(Txt_Tp.Text.Trim) < CInt(Txt_To.Text.Trim) Then MsgBox("El sistema no cumple con la condición Tp>T0", vbOKOnly + vbInformation, "Aviso")
                    ElseIf node.ParentNode.Text = "SIM C" AndAlso node.Text = "PI" Then
                        If Txt_Tf.Text <> "" Then
                            Txt_Kc.Text = ((1 / K) * (Tp / (Tf + T0))).ToString("####0.00")
                            Txt_Ti.Text = (Math.Min(Tp, 4 * (Tf + T0))).ToString("####0.00")
                            Txt_Td.Text = 0
                            metodo = node.ParentNode.Text & " | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text & " (Tf: " & Txt_Tf.Text & ")"
                        End If
                    ElseIf node.ParentNode.Text = "Improved SIM C" AndAlso node.Text = "PI" Then
                        If Txt_Tf.Text <> "" Then
                            Txt_Kc.Text = ((1 / K) * ((Tp + T0 / 3) / (Tf + T0))).ToString("####0.00")
                            Txt_Ti.Text = (Math.Min(Tp + T0 / 3, 4 * (Tf + T0))).ToString("####0.00")
                            Txt_Td.Text = 0
                            metodo = node.ParentNode.Text & " | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text & " (Tf: " & Txt_Tf.Text & ")"
                        End If
                    End If
                    Txt_Ki.Text = (CSng(Txt_Kc.Text) / CSng(Txt_Ti.Text)).ToString("####0.00")
                    If Txt_Td.Text > 0 Or Txt_Td.Text <> "" Then Txt_Kd.Text = (CSng(Txt_Kc.Text) * CSng(Txt_Td.Text)).ToString("####0.00") Else Txt_Kd.Text = 0
                    '
                    'Txt_Ti.Text = Txt_Ti.Text.ToString("####0.00")
                    'Txt_Td.Text = Txt_Td.Text.ToString("####0.00")
                End If
            Next
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Txt_K_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_K.KeyPress
        Try
            e.Handled = Not (Char.IsDigit(e.KeyChar) Or Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 45 Or ((e.KeyChar = "." Or e.KeyChar = ",") And (sender.Text.IndexOf(".") = -1 And sender.Text.IndexOf(",") = -1)))
            If e.KeyChar = "."c AndAlso decimalSeparator <> "."c Then
                e.Handled = True
                SendKeys.Send(",")
            End If
            If e.KeyChar = ","c AndAlso decimalSeparator <> ","c Then
                e.Handled = True
                SendKeys.Send(".")
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Txt_To_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_To.KeyPress
        Try
            e.Handled = Not (Char.IsDigit(e.KeyChar) Or Asc(e.KeyChar) = 8 Or ((e.KeyChar = "." Or e.KeyChar = ",") And (sender.Text.IndexOf(".") = -1 And sender.Text.IndexOf(",") = -1)))
            If e.KeyChar = "."c AndAlso decimalSeparator <> "."c Then
                e.Handled = True
                SendKeys.Send(",")
            End If
            If e.KeyChar = ","c AndAlso decimalSeparator <> ","c Then
                e.Handled = True
                SendKeys.Send(".")
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Txt_Tp_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_Tp.KeyPress
        Try
            e.Handled = Not (Char.IsDigit(e.KeyChar) Or Asc(e.KeyChar) = 8 Or ((e.KeyChar = "." Or e.KeyChar = ",") And (sender.Text.IndexOf(".") = -1 And sender.Text.IndexOf(",") = -1)))
            If e.KeyChar = "."c AndAlso decimalSeparator <> "."c Then
                e.Handled = True
                SendKeys.Send(",")
            End If
            If e.KeyChar = ","c AndAlso decimalSeparator <> ","c Then
                e.Handled = True
                SendKeys.Send(".")
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Txt_Tf_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_Tf.KeyPress
        Try
            e.Handled = Not (Char.IsDigit(e.KeyChar) Or Asc(e.KeyChar) = 8 Or ((e.KeyChar = "." Or e.KeyChar = ",") And (sender.Text.IndexOf(".") = -1 And sender.Text.IndexOf(",") = -1)))
            If e.KeyChar = "."c AndAlso decimalSeparator <> "."c Then
                e.Handled = True
                SendKeys.Send(",")
            End If
            If e.KeyChar = ","c AndAlso decimalSeparator <> ","c Then
                e.Handled = True
                SendKeys.Send(".")
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Txt_Kc_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_Kc.KeyPress
        Try
            e.Handled = Not (Char.IsDigit(e.KeyChar) Or Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 45 Or ((e.KeyChar = "." Or e.KeyChar = ",") And (sender.Text.IndexOf(".") = -1 And sender.Text.IndexOf(",") = -1)))
            If e.KeyChar = "."c AndAlso decimalSeparator <> "."c Then
                e.Handled = True
                SendKeys.Send(",")
            End If
            If e.KeyChar = ","c AndAlso decimalSeparator <> ","c Then
                e.Handled = True
                SendKeys.Send(".")
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Txt_Ti_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_Ti.KeyPress
        Try
            e.Handled = Not (Char.IsDigit(e.KeyChar) Or Asc(e.KeyChar) = 8 Or ((e.KeyChar = "." Or e.KeyChar = ",") And (sender.Text.IndexOf(".") = -1 And sender.Text.IndexOf(",") = -1)))
            If e.KeyChar = "."c AndAlso decimalSeparator <> "."c Then
                e.Handled = True
                SendKeys.Send(",")
            End If
            If e.KeyChar = ","c AndAlso decimalSeparator <> ","c Then
                e.Handled = True
                SendKeys.Send(".")
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Txt_Td_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_Td.KeyPress
        Try
            e.Handled = Not (Char.IsDigit(e.KeyChar) Or Asc(e.KeyChar) = 8 Or ((e.KeyChar = "." Or e.KeyChar = ",") And (sender.Text.IndexOf(".") = -1 And sender.Text.IndexOf(",") = -1)))
            If e.KeyChar = "."c AndAlso decimalSeparator <> "."c Then
                e.Handled = True
                SendKeys.Send(",")
            End If
            If e.KeyChar = ","c AndAlso decimalSeparator <> ","c Then
                e.Handled = True
                SendKeys.Send(".")
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Txt_Ki_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_Ki.KeyPress
        Try
            e.Handled = Not (Char.IsDigit(e.KeyChar) Or Asc(e.KeyChar) = 8 Or ((e.KeyChar = "." Or e.KeyChar = ",") And (sender.Text.IndexOf(".") = -1 And sender.Text.IndexOf(",") = -1)))
            If e.KeyChar = "."c AndAlso decimalSeparator <> "."c Then
                e.Handled = True
                SendKeys.Send(",")
            End If
            If e.KeyChar = ","c AndAlso decimalSeparator <> ","c Then
                e.Handled = True
                SendKeys.Send(".")
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Txt_Kd_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_Kd.KeyPress
        Try
            e.Handled = Not (Char.IsDigit(e.KeyChar) Or Asc(e.KeyChar) = 8 Or ((e.KeyChar = "." Or e.KeyChar = ",") And (sender.Text.IndexOf(".") = -1 And sender.Text.IndexOf(",") = -1)))
            If e.KeyChar = "."c AndAlso decimalSeparator <> "."c Then
                e.Handled = True
                SendKeys.Send(",")
            End If
            If e.KeyChar = ","c AndAlso decimalSeparator <> ","c Then
                e.Handled = True
                SendKeys.Send(".")
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Txt_muestreo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_muestreo.KeyPress
        Try
            e.Handled = Not (Char.IsDigit(e.KeyChar) Or Asc(e.KeyChar) = 8 Or ((e.KeyChar = "." Or e.KeyChar = ",") And (sender.Text.IndexOf(".") = -1 And sender.Text.IndexOf(",") = -1)))
            If e.KeyChar = "."c AndAlso decimalSeparator <> "."c Then
                e.Handled = True
                SendKeys.Send(",")
            End If
            If e.KeyChar = ","c AndAlso decimalSeparator <> ","c Then
                e.Handled = True
                SendKeys.Send(".")
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Btn_simular_Click(sender As Object, e As EventArgs)
        Simular()
    End Sub
    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Me.Close()
    End Sub
    Private Sub Btn_captura_simula_Click(sender As Object, e As EventArgs) Handles Btn_captura_simula.Click
        Try
            If Not (System.IO.Directory.Exists(Application.StartupPath + "\Export\")) Then
                System.IO.Directory.CreateDirectory(Application.StartupPath + "\Export\")
            End If
            Dim img As Image
            If proyecto = "" Then
                Chart_simula.SaveImage(Application.StartupPath + "\Export\ACP_sim_" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss") + ".png", ChartImageFormat.Png)
                img = Image.FromFile(Application.StartupPath + "\Export\ACP_sim_" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss") + ".png")
                System.Windows.Forms.Clipboard.SetImage(img)
            Else
                Chart_simula.SaveImage(proyecto + "\ACP_sim_" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss") + ".png", ChartImageFormat.Png)
                img = Image.FromFile(proyecto + "\ACP_sim_" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss") + ".png")
                System.Windows.Forms.Clipboard.SetImage(img)
            End If
            Lbl_info.Text = "Captura guardada correctamente. " & DateTime.Now
        Catch ex As Exception
            Console.WriteLine("Captura " & ex.ToString)
        End Try
    End Sub
    Private Sub Btn_ampliarTiempo_simula_Click(sender As Object, e As EventArgs) Handles Btn_ampliarTiempo_simula.Click
        Try
            If Chart_simula.Series.Count > 0 Then
                Application.DoEvents()
                Chart_simula.ChartAreas(0).AxisY.ScaleView.ZoomReset(0)
                Chart_simula.ChartAreas(0).AxisX.ScaleView.ZoomReset(0)
                Chart1.Invalidate()
            End If
        Catch ex As Exception
            'Console.WriteLine("Btn_ampliarTiempo_simula_Click " & ex.ToString)
        End Try
    End Sub
    Private Sub ConfiguraciónDelPuertoYLosDatosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConfiguraciónDelPuertoYLosDatosToolStripMenuItem.Click
        If SplitContainer2.Panel1Collapsed = True Then
            SplitContainer2.Panel1Collapsed = False
            SplitContainer2.Panel1.Show()
        Else
            SplitContainer2.Panel1Collapsed = True
            SplitContainer2.Panel1.Hide()
        End If
    End Sub
    Private Sub DatosLogVarToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles DatosLogVarToolStripMenuItem1.Click
        If SplitContainer3.Panel1Collapsed = True Then
            SplitContainer3.Panel1Collapsed = False
            SplitContainer3.Panel1.Show()
        Else
            SplitContainer3.Panel1Collapsed = True
            SplitContainer3.Panel1.Hide()
        End If
    End Sub
    Private Sub DatosSimulaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DatosSimulaToolStripMenuItem.Click
        If SplitContainer3.Panel2Collapsed = True Then
            SplitContainer3.Panel2Collapsed = False
            SplitContainer3.Panel2.Show()
        Else
            SplitContainer3.Panel2Collapsed = True
            SplitContainer3.Panel2.Hide()
        End If
    End Sub
    Private Sub GráficoDeSimulaciónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GráficoDeSimulaciónToolStripMenuItem.Click
        If SplitContainer6.Panel2Collapsed = True Then
            SplitContainer6.Panel2Collapsed = False
            SplitContainer6.Panel2.Show()
        Else
            SplitContainer6.Panel2Collapsed = True
            SplitContainer6.Panel2.Hide()
        End If
    End Sub
    Private Sub Btn_calc_sis_Click(sender As Object, e As EventArgs) Handles Btn_calc_sis.Click
        Form2.Show()
    End Sub
    Private Sub Btn_calc_sismin_Click(sender As Object, e As EventArgs) Handles Btn_calc_sismin.Click
        Form5.Show()
    End Sub
    Private Sub AcercaDeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AcercaDeToolStripMenuItem.Click
        Form3.Show()
    End Sub
    Private Sub AyudaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AyudaToolStripMenuItem.Click
        Process.Start("https://garikoitz.info/blog/?p=674")
    End Sub
    Private Sub Txt_Kc_TextChanged(sender As Object, e As EventArgs) Handles Txt_Kc.TextChanged
        Try
            If CSng(Txt_Kc.Text) > 0.0 AndAlso Txt_Kc.Text <> "" AndAlso Chart_simula.Titles.Count > 0 Then
                metodoman = "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
                'Simular()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Txt_Ti_TextChanged(sender As Object, e As EventArgs) Handles Txt_Ti.TextChanged
        Try
            If CSng(Txt_Ti.Text) > 0.0 AndAlso Txt_Ti.Text <> "" AndAlso Chart_simula.Titles.Count > 0 Then
                Txt_Ki.Text = (CSng(Txt_Kc.Text) / CSng(Txt_Ti.Text)).ToString("####0.00")
                metodoman = "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
                'Simular()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Txt_Td_TextChanged(sender As Object, e As EventArgs) Handles Txt_Td.TextChanged
        Try
            If CSng(Txt_Td.Text) > 0.0 AndAlso Txt_Td.Text <> "" AndAlso Chart_simula.Titles.Count > 0 Then
                Txt_Kd.Text = (CSng(Txt_Kc.Text) * CSng(Txt_Td.Text)).ToString("####0.00")
                metodoman = "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
                'Simular()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Btn_sintonias_Click(sender As Object, e As EventArgs) Handles Btn_sintonias.Click
        Form4.Show()
    End Sub
    Private Sub Cmd_enviar_Click(sender As Object, e As EventArgs) Handles Cmd_enviar.Click
        '
        If comPort.IsOpen Then
            comPort.WriteLine(Txt_enviar.Text.Trim)
        End If
        '
    End Sub
    Private Sub Cbo_metodos_sim_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cbo_metodos_sim.SelectedIndexChanged
        Try
            metodo = ""
            If Txt_K.Text <> "" AndAlso Txt_To.Text <> "" AndAlso Txt_To.Text <> "" AndAlso Txt_Tp.Text <> "" Then
                Dim K As Double = CDbl(Txt_K.Text)
                Dim T0 As Double = CDbl(Txt_To.Text)
                Dim Tp As Double = CDbl(Txt_Tp.Text)
                Dim Tf As Double = CDbl(Txt_Tf.Text)
                Select Case Cbo_metodos_sim.SelectedIndex
                    Case 0
                        Txt_Kc.Text = ((1 / K) * (Tp / T0) * (1 + (T0 / (3 * Tp)))).ToString("####0.00")
                        Txt_Ti.Text = 0
                        Txt_Td.Text = 0
                        metodo = "CC-25 | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
                    Case 1
                        Txt_Kc.Text = ((1 / K) * (Tp / T0) * (0.9 + (T0 / (12 * Tp)))).ToString("####0.00")
                        Txt_Ti.Text = (T0 * (30 + 3 * (T0 / Tp)) / (9 + 20 * (T0 / Tp))).ToString("####0.00")
                        Txt_Td.Text = 0
                        metodo = "CC-25 | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
                    Case 2
                        Txt_Kc.Text = ((1 / K) * (Tp / T0) * (16 * Tp + (3 * T0)) / (12 * Tp)).ToString("####0.00")
                        Txt_Ti.Text = (T0 * (32 + 6 * (T0 / Tp)) / (13 + 8 * (T0 / Tp))).ToString("####0.00")
                        Txt_Td.Text = (4 * T0 / (11 + 2 * (T0 / Tp))).ToString("####0.00")
                        metodo = "CC-25 | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
                    Case 3
                        Txt_Kc.Text = ((1 / K) * (Tp / T0) * (1 + (T0 / (3 * Tp))) * 0.6).ToString("####0.00")
                        Txt_Ti.Text = 0
                        Txt_Td.Text = 0
                        metodo = "CC-10 | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
                        If CInt(Txt_Tp.Text.Trim) < CInt(Txt_To.Text.Trim) / 2 Then MsgBox("El sistema no cumple con la condición 𝑇𝑝>𝑇o/2", vbOKOnly + vbInformation, "Aviso")
                    Case 4
                        Txt_Kc.Text = ((1 / K) * (Tp / T0) * (0.9 + (T0 / (12 * Tp))) * 0.6).ToString("####0.00")
                        Txt_Ti.Text = (T0 * (30 + 3 * (T0 / Tp)) / (9 + 20 * (T0 / Tp)) * 1.2).ToString("####0.00")
                        Txt_Td.Text = 0
                        metodo = "CC-10 | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
                        If CInt(Txt_Tp.Text.Trim) < CInt(Txt_To.Text.Trim) / 2 Then MsgBox("El sistema no cumple con la condición 𝑇𝑝>𝑇o/2", vbOKOnly + vbInformation, "Aviso")
                    Case 5
                        Txt_Kc.Text = ((1 / K) * (Tp / T0) * (16 * Tp + (3 * T0)) / (12 * Tp) * 0.6).ToString("####0.00")
                        Txt_Ti.Text = (T0 * (32 + 6 * (T0 / Tp)) / (13 + 8 * (T0 / Tp)) * 1.2).ToString("####0.00")
                        Txt_Td.Text = (4 * T0 / (11 + 2 * (T0 / Tp))).ToString("####0.00")
                        metodo = "CC-10 | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
                        If CInt(Txt_Tp.Text.Trim) < CInt(Txt_To.Text.Trim) / 2 Then MsgBox("El sistema no cumple con la condición 𝑇𝑝>𝑇o/2", vbOKOnly + vbInformation, "Aviso")
                    Case 6
                        Txt_Kc.Text = (Tp / (K * T0)).ToString("####0.00")
                        Txt_Ti.Text = 0
                        Txt_Td.Text = 0
                        metodo = "ZN-25 | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
                    Case 7
                        Txt_Kc.Text = (Tp / (K * T0) * 0.9).ToString("####0.00")
                        Txt_Ti.Text = (T0 / 0.3).ToString("####0.00")
                        Txt_Td.Text = 0
                        metodo = "ZN-25 | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
                    Case 8
                        Txt_Kc.Text = ((Tp / (K * T0) * 1.2) * ((2 * T0) + (0.5 * T0)) / (2 * T0)).ToString("####0.00")
                        Txt_Ti.Text = ((2 * T0) + (0.5 * T0)).ToString("####0.00")
                        Txt_Td.Text = ((0.5 * T0) * (2 * T0) / ((2 * T0) + (0.5 * T0))).ToString("####0.00")
                        metodo = "ZN-25 | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
                    Case 9
                        Txt_Kc.Text = (Tp / (K * T0) * 0.666).ToString("####0.00")
                        Txt_Ti.Text = 0
                        Txt_Td.Text = 0
                        metodo = "ZN-10 | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
                        If CInt(Txt_Tp.Text.Trim) < CInt(Txt_To.Text.Trim) * 2 Then MsgBox("El sistema no cumple con la condición Tp>2*To", vbOKOnly + vbInformation, "Aviso")
                    Case 10
                        Txt_Kc.Text = (Tp / (K * T0) * 0.9 * 0.666).ToString("####0.00")
                        Txt_Ti.Text = (T0 / 0.3).ToString("####0.00")
                        Txt_Td.Text = 0
                        metodo = "ZN-10 | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
                        If CInt(Txt_Tp.Text.Trim) < CInt(Txt_To.Text.Trim) * 2 Then MsgBox("El sistema no cumple con la condición Tp>2*To", vbOKOnly + vbInformation, "Aviso")
                    Case 11
                        Txt_Kc.Text = ((Tp / (K * T0) * 1.2 * 0.666) * ((2 * T0) + (0.5 * T0)) / (2 * T0)).ToString("####0.00")
                        Txt_Ti.Text = ((2 * T0) + (0.5 * T0)).ToString("####0.00")
                        Txt_Td.Text = ((0.5 * T0) * (2 * T0) / ((2 * T0) + (0.5 * T0))).ToString("####0.00")
                        metodo = "ZN-10 | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
                        If CInt(Txt_Tp.Text.Trim) < CInt(Txt_To.Text.Trim) * 2 Then MsgBox("El sistema no cumple con la condición Tp>2*To", vbOKOnly + vbInformation, "Aviso")
                    Case 12
                        Txt_Kc.Text = (1 / K * 0.859 * Math.Pow(T0 / Tp, -0.977)).ToString("####0.00")
                        Txt_Ti.Text = (Tp / (0.674 * Math.Pow(T0 / Tp, -0.68))).ToString("####0.00")
                        Txt_Td.Text = 0
                        metodo = "ITAE-C | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
                        If CInt(Txt_Tp.Text.Trim) < CInt(Txt_To.Text.Trim) Then MsgBox("El sistema no cumple con la condición Tp>T0", vbOKOnly + vbInformation, "Aviso")
                    Case 13
                        Txt_Kc.Text = (1 / K * 1.357 * Math.Pow(T0 / Tp, -0.947)).ToString("####0.00")
                        Txt_Ti.Text = (Tp / (0.842 * Math.Pow(T0 / Tp, -0.738))).ToString("####0.00")
                        Txt_Td.Text = (Tp * 0.381 * Math.Pow(T0 / Tp, 0.995)).ToString("####0.00")
                        metodo = "ITAE-C | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
                        If CInt(Txt_Tp.Text.Trim) < CInt(Txt_To.Text.Trim) Then MsgBox("El sistema no cumple con la condición Tp>T0", vbOKOnly + vbInformation, "Aviso")
                    Case 14
                        Txt_Kc.Text = (1 / K * 0.586 * Math.Pow(T0 / Tp, -0.916)).ToString("####0.00")
                        Txt_Ti.Text = (Tp / (-0.165 * Math.Pow(T0 / Tp, 1) + 1.03)).ToString("####0.00")
                        Txt_Td.Text = 0
                        metodo = "ITAE-SP | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
                        If CInt(Txt_Tp.Text.Trim) < CInt(Txt_To.Text.Trim) Then MsgBox("El sistema no cumple con la condición Tp>T0", vbOKOnly + vbInformation, "Aviso")
                    Case 15
                        Txt_Kc.Text = (1 / K * 0.965 * Math.Pow(T0 / Tp, -0.855)).ToString("####0.00")
                        Txt_Ti.Text = (Tp / (-0.147 * Math.Pow(T0 / Tp, 1) + 0.796)).ToString("####0.00")
                        Txt_Td.Text = (Tp * 0.308 * Math.Pow(T0 / Tp, 0.929)).ToString("####0.00")
                        metodo = "ITAE-SP | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
                    Case 16
                        Txt_Kc.Text = (1 / K * 0.984 * Math.Pow(T0 / Tp, -0.986)).ToString("####0.00")
                        Txt_Ti.Text = (Tp / (0.608 * Math.Pow(T0 / Tp, -0.707))).ToString("####0.00")
                        Txt_Td.Text = 0
                        metodo = "IAE-C | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
                        If CInt(Txt_Tp.Text.Trim) < CInt(Txt_To.Text.Trim) Then MsgBox("El sistema no cumple con la condición Tp>T0", vbOKOnly + vbInformation, "Aviso")
                    Case 17
                        Txt_Kc.Text = (1 / K * 1.435 * Math.Pow(T0 / Tp, -0.921)).ToString("####0.00")
                        Txt_Ti.Text = (Tp / (0.878 * Math.Pow(T0 / Tp, -0.749))).ToString("####0.00")
                        Txt_Td.Text = (Tp * 0.482 * Math.Pow(T0 / Tp, 1.137)).ToString("####0.00")
                        metodo = "IAE-C | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
                        If CInt(Txt_Tp.Text.Trim) < CInt(Txt_To.Text.Trim) Then MsgBox("El sistema no cumple con la condición Tp>T0", vbOKOnly + vbInformation, "Aviso")
                    Case 18
                        Txt_Kc.Text = (1 / K * 0.758 * Math.Pow(T0 / Tp, -0.861)).ToString("####0.00")
                        Txt_Ti.Text = (Tp / (-0.323 * Math.Pow(T0 / Tp, 1) + 1.02)).ToString("####0.00")
                        Txt_Td.Text = 0
                        metodo = "IAE-SP | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
                        If CInt(Txt_Tp.Text.Trim) < CInt(Txt_To.Text.Trim) Then MsgBox("El sistema no cumple con la condición Tp>T0", vbOKOnly + vbInformation, "Aviso")
                    Case 19
                        Txt_Kc.Text = (1 / K * 1.086 * Math.Pow(T0 / Tp, -0.869)).ToString("####0.00")
                        Txt_Ti.Text = (Tp / (-0.13 * Math.Pow(T0 / Tp, 1) + 0.74)).ToString("####0.00")
                        Txt_Td.Text = (Tp * 0.348 * Math.Pow(T0 / Tp, 0.914)).ToString("####0.00")
                        metodo = "IAE-SP | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
                        If CInt(Txt_Tp.Text.Trim) < CInt(Txt_To.Text.Trim) Then MsgBox("El sistema no cumple con la condición Tp>T0", vbOKOnly + vbInformation, "Aviso")
                    Case 20
                        If Txt_Tf.Text <> "" Then
                            Txt_Kc.Text = (Tp / (K * (Tf + T0))).ToString("####0.00")
                            Txt_Ti.Text = Tp.ToString("####0.00")
                            Txt_Td.Text = 0
                            metodo = "LAMBDA | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text & " (Tf: " & Txt_Tf.Text & ")"
                        End If
                    Case 21
                        If Txt_Tf.Text <> "" Then
                            Txt_Kc.Text = ((Tp + T0 / 2) / (K * (Tf + T0 / 2))).ToString("####0.00")
                            Txt_Ti.Text = (Tp + T0 / 2).ToString("####0.00")
                            Txt_Td.Text = (Tp * T0 / (2 * Tp + T0)).ToString("####0.00")
                            metodo = "LAMBDA | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text & " (Tf: " & Txt_Tf.Text & ")"
                        End If
                    Case 22
                        If Txt_Tf.Text <> "" Then
                            Txt_Kc.Text = ((Tp + T0 / 4) / (K * Tf)).ToString("####0.00")
                            Txt_Ti.Text = (Tp + T0 / 4).ToString("####0.00")
                            Txt_Td.Text = 0
                            metodo = "IMC | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text & " (Tf: " & Txt_Tf.Text & ")"
                        End If
                    Case 23
                        If Txt_Tf.Text <> "" Then
                            Txt_Kc.Text = ((1 / K) * (Tp / (Tf + T0))).ToString("####0.00")
                            Txt_Ti.Text = (Math.Min(Tp, 4 * (Tf + T0))).ToString("####0.00")
                            Txt_Td.Text = 0
                            metodo = "SIMC | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text & " (Tf: " & Txt_Tf.Text & ")"
                        End If
                    Case 24
                        If Txt_Tf.Text <> "" Then
                            Txt_Kc.Text = ((1 / K) * ((Tp + T0 / 3) / (Tf + T0))).ToString("####0.00")
                            Txt_Ti.Text = (Math.Min(Tp + T0 / 3, 4 * (Tf + T0))).ToString("####0.00")
                            Txt_Td.Text = 0
                            metodo = "IMPROVED SIMC | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text & " (Tf: " & Txt_Tf.Text & ")"
                        End If
                        'End If
                End Select
                Txt_Ki.Text = (CSng(Txt_Kc.Text) / CSng(Txt_Ti.Text)).ToString("####0.00")
                If Txt_Td.Text > 0 Or Txt_Td.Text <> "" Then Txt_Kd.Text = (CSng(Txt_Kc.Text) * CSng(Txt_Td.Text)).ToString("####0.00") Else Txt_Kd.Text = 0
                '
                Simular()
                '
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Btn_simular2_Click(sender As Object, e As EventArgs) Handles Btn_simular2.Click
        Simular()
    End Sub
    Private Sub Txt_Tf_TextChanged(sender As Object, e As EventArgs) Handles Txt_Tf.TextChanged
        Try
            If Cbo_metodos_sim.SelectedIndex > 19 Then sintonias(Cbo_metodos_sim.SelectedIndex)
        Catch ex As Exception

        End Try

    End Sub
    Private Sub Txt_Ki_TextChanged(sender As Object, e As EventArgs) Handles Txt_Ki.TextChanged
        Try
            'If Txt_Ki.Text > 0 Or Txt_Ki.Text <> "" Then
            Txt_Ti.Text = (CSng(Txt_Kc.Text) / CSng(Txt_Ki.Text)).ToString("####0.00")
            metodoman = "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
            'Simular()
            'Else
            '    Txt_Ti.Text = "0"
            'End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Txt_Kd_TextChanged(sender As Object, e As EventArgs) Handles Txt_Kd.TextChanged
        Try
            'If CSng(Txt_Kd.Text) > 0.0 AndAlso Txt_Kd.Text <> "" Then
            Txt_Td.Text = (CSng(Txt_Kd.Text) / CSng(Txt_Kc.Text)).ToString("####0.00")
            metodoman = "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
            'Simular()
            'Else
            '    Txt_Td.Text = "0"
            'End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Txt_Kc_MouseWheel(sender As Object, e As MouseEventArgs) Handles Txt_Kc.MouseWheel
        Dim valor As Single = CSng(Txt_Kc.Text)
        If e.Delta > 0 Then
            If valor > 0.09 AndAlso valor < 1 Then valor += 0.01
            If valor > 0.99 AndAlso valor < 10 Then valor += 0.1
            If valor > 9.99 AndAlso valor < 100 Then valor += 1
        Else
            If valor > 0.09 AndAlso valor < 1 Then valor -= 0.01
            If valor > 0.99 AndAlso valor < 10 Then valor -= 0.1
            If valor > 9.99 AndAlso valor < 100 Then valor -= 1
            '
            If valor < 0.1 Then valor = 0.1
        End If
        Txt_Kc.Text = valor
        Threading.Thread.Sleep(500)
        Simular()
    End Sub
    Private Sub Txt_Ki_MouseWheel(sender As Object, e As MouseEventArgs) Handles Txt_Ki.MouseWheel
        Dim valor As Single = CSng(Txt_Ki.Text)
        If e.Delta > 0 Then
            If valor > 0.09 AndAlso valor < 1 Then valor += 0.01
            If valor > 0.99 AndAlso valor < 10 Then valor += 0.1
            If valor > 9.99 AndAlso valor < 100 Then valor += 1
        Else
            If valor > 0.09 AndAlso valor < 1 Then valor -= 0.01
            If valor > 0.99 AndAlso valor < 10 Then valor -= 0.1
            If valor > 9.99 AndAlso valor < 100 Then valor -= 1
            '
            If valor < 0.1 Then valor = 0.1
        End If
        Txt_Ki.Text = valor
        Threading.Thread.Sleep(500)
        Simular()
    End Sub
    Private Sub Txt_Kd_MouseWheel(sender As Object, e As MouseEventArgs) Handles Txt_Kd.MouseWheel
        Dim valor As Single = CSng(Txt_Kd.Text)
        If e.Delta > 0 Then
            If valor > 0.09 AndAlso valor < 1 Then valor += 0.01
            If valor > 0.99 AndAlso valor < 10 Then valor += 0.1
            If valor > 9.99 AndAlso valor < 100 Then valor += 1
            If valor > 99 AndAlso valor < 1000 Then valor += 10
        Else
            If valor > 0.09 AndAlso valor < 1 Then valor -= 0.01
            If valor > 0.99 AndAlso valor < 10 Then valor -= 0.1
            If valor > 9.99 AndAlso valor < 100 Then valor -= 1
            If valor > 99 AndAlso valor < 1000 Then valor -= 10
            '
            If valor < 0.1 Then valor = 0.1
        End If
        Txt_Kd.Text = valor
        Threading.Thread.Sleep(500)
        Simular()
    End Sub
    Private Sub Txt_Ti_MouseWheel(sender As Object, e As MouseEventArgs) Handles Txt_Ti.MouseWheel
        Dim valor As Single = CSng(Txt_Ti.Text)
        If e.Delta > 0 Then
            If valor > 0.09 AndAlso valor < 1 Then valor += 0.01
            If valor > 0.99 AndAlso valor < 10 Then valor += 0.1
            If valor > 9.99 AndAlso valor < 100 Then valor += 1
            If valor > 99 AndAlso valor < 1000 Then valor += 10
        Else
            If valor > 0.09 AndAlso valor < 1 Then valor -= 0.01
            If valor > 0.99 AndAlso valor < 10 Then valor -= 0.1
            If valor > 9.99 AndAlso valor < 100 Then valor -= 1
            If valor > 99 AndAlso valor < 1000 Then valor -= 10
            '
            If valor < 0.1 Then valor = 0.1
        End If
        Txt_Ti.Text = valor
        Threading.Thread.Sleep(500)
        Simular()
    End Sub
    Private Sub Txt_Td_MouseWheel(sender As Object, e As MouseEventArgs) Handles Txt_Td.MouseWheel
        Dim valor As Single = CSng(Txt_Td.Text)
        If e.Delta > 0 Then
            If valor > 0.09 AndAlso valor < 1 Then valor += 0.01
            If valor > 0.99 AndAlso valor < 10 Then valor += 0.1
            If valor > 9.99 AndAlso valor < 100 Then valor += 1
            If valor > 99 AndAlso valor < 1000 Then valor += 10
        Else
            If valor > 0.09 AndAlso valor < 1 Then valor -= 0.01
            If valor > 0.99 AndAlso valor < 10 Then valor -= 0.1
            If valor > 9.99 AndAlso valor < 100 Then valor -= 1
            If valor > 99 AndAlso valor < 1000 Then valor -= 10
            '
            If valor < 0.1 Then valor = 0.1
        End If
        Txt_Td.Text = valor
        Threading.Thread.Sleep(500)
        Simular()
    End Sub
#End Region
End Class