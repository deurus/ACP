#Region "Imports"
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
Public Class Form4
#Region "Variables"
    'General
    Dim decimalSeparator As String = Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator
    'Simula
    Dim result_tnow() As Single
    Dim result_SP() As Single
    Dim result_PV() As Single
    Dim result_OP() As Single
    Dim result_DV() As Single
    Dim Kc_simula As Single = 0
    Dim Ti_simula As Single = 0
    Dim Td_simula As Single = 0
    Dim metodo As String = ""
    Dim sobreejey As Boolean = False
    Dim sobreejey2 As Boolean = False
    Dim IAE_sim As Single = 0
#End Region
    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Txt_K.Text = CSng(Form1.Txt_K.Text)
            Txt_To.Text = CSng(Form1.Txt_To.Text)
            Txt_Tp.Text = CSng(Form1.Txt_Tp.Text)
            Txt_Tf.Text = CSng(Form1.Txt_Tf.Text)
            Sintonias(CSng(Txt_K.Text), CSng(Txt_To.Text), CSng(Txt_Tp.Text), CSng(Txt_Tf.Text))
            '
            Txt_PVrngSup.Text = Form1.Txt_PVrngSup.Text
            Txt_PVrngInf.Text = Form1.Txt_PVrngInf.Text
            Cbo_eq.SelectedIndex = Form1.Cbo_eq.SelectedIndex
            Txt_muestreo.Text = Form1.Txt_muestreo.Text
            Txt_Tfinal.Text = Form1.Txt_Tfinal.Text
            Txt_PVini.Text = Form1.Txt_PVini.Text
            Txt_OPini.Text = Form1.Txt_OPini.Text
            Txt_CargaIni.Text = Form1.Txt_CargaIni.Text
            Txt_DSP.Text = Form1.Txt_DSP.Text
            Txt_Dcarga.Text = Form1.Txt_Dcarga.Text
            Txt_OPLimSup.Text = Form1.Txt_OPLimSup.Text
            Txt_OPLimInf.Text = Form1.Txt_OPLimInf.Text
            '
            'Txt_Ki.Text = (CSng(Txt_Kc.Text) / CSng(Txt_Ti.Text)).ToString("####0.00")
            'If Txt_Td.Text > 0 Then Txt_Kd.Text = (CSng(Txt_Kc.Text) * CSng(Txt_Td.Text)).ToString("####0.00") Else Txt_kd.Text = 0
            'End If
            '
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub Form4_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Application.DoEvents()
    End Sub
    Private Sub Txt_K_TextChanged(sender As Object, e As EventArgs) Handles Txt_K.TextChanged
        If Txt_K.Text <> "" AndAlso Txt_To.Text <> "" AndAlso Txt_Tf.Text <> "" AndAlso Txt_Tf.Text <> "" Then Sintonias(CSng(Txt_K.Text), CSng(Txt_To.Text), CSng(Txt_Tp.Text), CSng(Txt_Tf.Text))
    End Sub
    Private Sub Txt_To_TextChanged(sender As Object, e As EventArgs) Handles Txt_To.TextChanged
        If Txt_K.Text <> "" AndAlso Txt_To.Text <> "" AndAlso Txt_Tf.Text <> "" AndAlso Txt_Tf.Text <> "" Then Sintonias(CSng(Txt_K.Text), CSng(Txt_To.Text), CSng(Txt_Tp.Text), CSng(Txt_Tf.Text))
    End Sub
    Private Sub Txt_Tp_TextChanged(sender As Object, e As EventArgs) Handles Txt_Tp.TextChanged
        If Txt_K.Text <> "" AndAlso Txt_To.Text <> "" AndAlso Txt_Tf.Text <> "" AndAlso Txt_Tf.Text <> "" Then Sintonias(CSng(Txt_K.Text), CSng(Txt_To.Text), CSng(Txt_Tp.Text), CSng(Txt_Tf.Text))
    End Sub
    Private Sub Txt_Tf_TextChanged(sender As Object, e As EventArgs) Handles Txt_Tf.TextChanged
        If Txt_K.Text <> "" AndAlso Txt_To.Text <> "" AndAlso Txt_Tf.Text <> "" AndAlso Txt_Tf.Text <> "" Then Sintonias(CSng(Txt_K.Text), CSng(Txt_To.Text), CSng(Txt_Tp.Text), CSng(Txt_Tf.Text))
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
    Private Sub Sintonias(ByVal K As Single, ByVal T0 As Single, ByVal Tp As Single, ByVal Tf As Single)
        Try
            'Dim Kc, Ti, Td As Single
            If K > 0 AndAlso T0 <> 0 AndAlso Tp > 0 Then
                '--"CC-25" AndAlso node.Text = "P" 
                Lbl_Pcc25_Kc.Text = ((1 / K) * (Tp / T0) * (1 + (T0 / (3 * Tp)))).ToString("####0.00")
                '--"CC-25" AndAlso node.Text = "PI" 
                'Kc = ((1 / K) * (Tp / T0) * (0.9 + (T0 / (12 * Tp))))
                'Ti = (T0 * (30 + 3 * (T0 / Tp)) / (9 + 20 * (T0 / Tp)))
                Lbl_PIcc25_Kc.Text = ((1 / K) * (Tp / T0) * (0.9 + (T0 / (12 * Tp)))).ToString("####0.00")
                Lbl_PIcc25_Ti.Text = (T0 * (30 + 3 * (T0 / Tp)) / (9 + 20 * (T0 / Tp))).ToString("####0.00")
                '--"CC-25" AndAlso node.Text = "PID"
                Lbl_PIDcc25_Kc.Text = ((1 / K) * (Tp / T0) * (16 * Tp + (3 * T0)) / (12 * Tp)).ToString("####0.00")
                Lbl_PIDcc25_Ti.Text = (T0 * (32 + 6 * (T0 / Tp)) / (13 + 8 * (T0 / Tp))).ToString("####0.00")
                Lbl_PIDcc25_Td.Text = (4 * T0 / (11 + 2 * (T0 / Tp))).ToString("####0.00")
                '--"CC-10" AndAlso node.Text = "P"
                Lbl_Pcc10_Kc.Text = ((1 / K) * (Tp / T0) * (1 + (T0 / (3 * Tp))) * 0.6).ToString("####0.00")
                '--"CC-10" AndAlso node.Text = "PI" 
                Lbl_PIcc10_Kc.Text = ((1 / K) * (Tp / T0) * (0.9 + (T0 / (12 * Tp))) * 0.6).ToString("####0.00")
                Lbl_PIcc10_Ti.Text = (T0 * (30 + 3 * (T0 / Tp)) / (9 + 20 * (T0 / Tp)) * 1.2).ToString("####0.00")
                '--"CC-10" AndAlso node.Text = "PID" 
                Lbl_PIDcc10_Kc.Text = ((1 / K) * (Tp / T0) * (16 * Tp + (3 * T0)) / (12 * Tp) * 0.6).ToString("####0.00")
                Lbl_PIDcc10_Ti.Text = (T0 * (32 + 6 * (T0 / Tp)) / (13 + 8 * (T0 / Tp)) * 1.2).ToString("####0.00")
                Lbl_PIDcc10_Td.Text = (4 * T0 / (11 + 2 * (T0 / Tp))).ToString("####0.00")
                '--"ZN-LA-25" AndAlso node.Text = "P" 
                Lbl_Pzn25_Kc.Text = (Tp / (K * T0)).ToString("####0.00")
                '--"ZN-LA-25" AndAlso node.Text = "PI"
                Lbl_PIzn25_Kc.Text = (Tp / (K * T0) * 0.9).ToString("####0.00")
                Lbl_PIzn25_Ti.Text = (T0 / 0.3).ToString("####0.00")
                '--"ZN-LA-25" AndAlso node.Text = "PID" Then
                Lbl_PIDzn25_Kc.Text = ((Tp / (K * T0) * 1.2) * ((2 * T0) + (0.5 * T0)) / (2 * T0)).ToString("####0.00")
                Lbl_PIDzn25_Ti.Text = ((2 * T0) + (0.5 * T0)).ToString("####0.00")
                Lbl_PIDzn25_Td.Text = ((0.5 * T0) * (2 * T0) / ((2 * T0) + (0.5 * T0))).ToString("####0.00")
                '--"ZN-LA-10" AndAlso node.Text = "P" Then
                Lbl_Pzn10_Kc.Text = (Tp / (K * T0) * 0.666).ToString("####0.00")
                '--"ZN-LA-10" AndAlso node.Text = "PI" Then
                Lbl_PIzn10_Kc.Text = (Tp / (K * T0) * 0.9 * 0.666).ToString("####0.00")
                Lbl_PIzn10_Ti.Text = (T0 / 0.3).ToString("####0.00")
                '--"ZN-LA-10" AndAlso node.Text = "PID" Then
                Lbl_PIDzn10_Kc.Text = ((Tp / (K * T0) * 1.2 * 0.666) * ((2 * T0) + (0.5 * T0)) / (2 * T0)).ToString("####0.00")
                Lbl_PIDzn10_Ti.Text = ((2 * T0) + (0.5 * T0)).ToString("####0.00")
                Lbl_PIDzn10_Td.Text = ((0.5 * T0) * (2 * T0) / ((2 * T0) + (0.5 * T0))).ToString("####0.00")
                '--"Lambda" AndAlso node.Text = "PI"
                If Tf > 0 Then
                    Lbl_PIlambda_Kc.Text = (Tp / (K * (Tf + T0))).ToString("####0.00")
                    Lbl_PIlambda_Ti.Text = Tp.ToString("####0.00")
                End If
                '--"Lambda" AndAlso node.Text = "PID" 
                If Tf > 0 Then
                    Lbl_PIDlambda_Kc.Text = ((Tp + T0 / 2) / (K * (Tf + T0 / 2))).ToString("####0.00")
                    Lbl_PIDlambda_Ti.Text = (Tp + T0 / 2).ToString("####0.00")
                    Lbl_PIDlambda_Td.Text = (Tp * T0 / (2 * Tp + T0)).ToString("####0.00")
                End If
                '--"IMC" AndAlso node.Text = "PI"
                If Tf > 0 Then
                    Lbl_PIimc_Kc.Text = ((Tp + T0 / 4) / (K * Tf)).ToString("####0.00")
                    Lbl_PIimc_Ti.Text = (Tp + T0 / 4).ToString("####0.00")
                End If
                '--"ITAE-C" AndAlso node.Text = "PI" Then
                Lbl_PIitaec_Kc.Text = (1 / K * 0.859 * Math.Pow(T0 / Tp, -0.977)).ToString("####0.00")
                Lbl_PIitaec_Ti.Text = (Tp / (0.674 * Math.Pow(T0 / Tp, -0.68))).ToString("####0.00")
                '--"ITAE-C" AndAlso node.Text = "PID" Then
                Lbl_PIDitaec_Kc.Text = (1 / K * 1.357 * Math.Pow(T0 / Tp, -0.947)).ToString("####0.00")
                Lbl_PIDitaec_Ti.Text = (Tp / (0.842 * Math.Pow(T0 / Tp, -0.738))).ToString("####0.00")
                Lbl_PIDitaec_Td.Text = (Tp * 0.381 * Math.Pow(T0 / Tp, 0.995)).ToString("####0.00")
                '--"ITAE-SP" AndAlso node.Text = "PI" Then
                Lbl_PIitaesp_Kc.Text = (1 / K * 0.586 * Math.Pow(T0 / Tp, -0.916)).ToString("####0.00")
                Lbl_PIitaesp_Ti.Text = (Tp / (-0.165 * Math.Pow(T0 / Tp, 1) + 1.03)).ToString("####0.00")
                '--"ITAE-SP" AndAlso node.Text = "PID" Then
                Lbl_PIDitaesp_Kc.Text = (1 / K * 0.965 * Math.Pow(T0 / Tp, -0.855)).ToString("####0.00")
                Lbl_PIDitaesp_Ti.Text = (Tp / (-0.147 * Math.Pow(T0 / Tp, 1) + 0.796)).ToString("####0.00")
                Lbl_PIDitaesp_Td.Text = (Tp * 0.308 * Math.Pow(T0 / Tp, 0.929)).ToString("####0.00")
                '--"IAE-C" AndAlso node.Text = "PI" Then
                Lbl_PIiaec_Kc.Text = (1 / K * 0.984 * Math.Pow(T0 / Tp, -0.986)).ToString("####0.00")
                Lbl_PIiaec_Ti.Text = (Tp / (0.608 * Math.Pow(T0 / Tp, -0.707))).ToString("####0.00")
                '--"IAE-C" AndAlso node.Text = "PID" Then
                Lbl_PIDiaec_Kc.Text = (1 / K * 1.435 * Math.Pow(T0 / Tp, -0.921)).ToString("####0.00")
                Lbl_PIDiaec_Ti.Text = (Tp / (0.878 * Math.Pow(T0 / Tp, -0.749))).ToString("####0.00")
                Lbl_PIDiaec_Td.Text = (Tp * 0.482 * Math.Pow(T0 / Tp, 1.137)).ToString("####0.00")
                '--"IAE-SP" AndAlso node.Text = "PI" Then
                Lbl_PIiaesp_Kc.Text = (1 / K * 0.758 * Math.Pow(T0 / Tp, -0.861)).ToString("####0.00")
                Lbl_PIiaesp_Ti.Text = (Tp / (-0.323 * Math.Pow(T0 / Tp, 1) + 1.02)).ToString("####0.00")
                '--"IAE-SP" AndAlso node.Text = "PID" Then
                Lbl_PIDiaesp_Kc.Text = (1 / K * 1.086 * Math.Pow(T0 / Tp, -0.869)).ToString("####0.00")
                Lbl_PIDiaesp_Ti.Text = (Tp / (-0.13 * Math.Pow(T0 / Tp, 1) + 0.74)).ToString("####0.00")
                Lbl_PIDiaesp_Td.Text = (Tp * 0.348 * Math.Pow(T0 / Tp, 0.914)).ToString("####0.00")
                '--"SIM C" AndAlso node.Text = "PI" Then
                If Tf > 0 Then
                    Lbl_PIsimc_Kc.Text = ((1 / K) * (Tp / (Tf + T0))).ToString("####0.00")
                    Lbl_PIsimc_Ti.Text = (Math.Min(Tp, 4 * (Tf + T0))).ToString("####0.00")
                End If
                '--"Improved SIM C" AndAlso node.Text = "PI"
                If Tf > 0 Then
                    Lbl_PIimpsimc_Kc.Text = ((1 / K) * ((Tp + T0 / 3) / (Tf + T0))).ToString("####0.00")
                    Lbl_PIimpsimc_Ti.Text = (Math.Min(Tp + T0 / 3, 4 * (Tf + T0))).ToString("####0.00")
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Graficar()
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
                AX(i, 2) = Form1.Interp1(dblCoeffX, dblCoeffY, i * Ts / 60)
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
                'calcula error
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
                If Eq = "I-PD" Then dProp = -Kc * (PV - PV1) * KEUPor
                '***********************
                'calcula accion integral
                '***********************
                Ik = Ik1 + Ts / 2 * (myError + myError1)
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
                Console.WriteLine("Error: " & myError & " SP: " & SP & " PV: " & PV & " dPV: " & dPV1)
                '********************************
                'desliza el vector de MV, dpvpred
                '********************************
                MV = Form1.RShift(MV)
                Application.DoEvents()
            Next i
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
            Chart_simula.Titles.Add(metodo)
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
            For j = 1 To imax - 1 Step stepgeneral
                Chart_simula.Series(0).Points.AddXY(result_tnow(j), result_SP(j))
                Chart_simula.Series(1).Points.AddXY(result_tnow(j), result_PV(j))
                Chart_simula.Series(2).Points.AddXY(result_tnow(j), result_OP(j))
                Chart_simula.Series(3).Points.AddXY(result_tnow(j), result_DV(j))
                IAE_sim += Math.Abs(result_SP(j) - result_PV(j)) 'SP-PV
            Next j
            Chart_simula.Titles.Add("IAE: " & IAE_sim.ToString("####0.00"))
            Chart_simula.Titles(2).Font = New Font("Microsoft Sans Serif", 8, FontStyle.Regular)
            Chart_simula.Titles(2).ForeColor = Color.Gainsboro
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
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString)
            'MsgBox("Ocurrió un error al generar la simulación. Comprueba bien todos los campos.", vbExclamation + vbOKOnly, "Error al Simular")
        End Try
    End Sub
    Private Sub Lbl_Pcc25_Kc_Click(sender As Object, e As EventArgs) Handles Lbl_Pcc25_Kc.Click
        Txt_Kc.Text = Lbl_Pcc25_Kc.Text
        Txt_Ti.Text = 0
        Txt_Td.Text = 0
        metodo = "CC-25 | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
        Graficar()
        Txt_Ki.Text = 0
        Txt_Td.Text = 0
    End Sub
    Private Sub Lbl_PIcc25_Kc_Click(sender As Object, e As EventArgs) Handles Lbl_PIcc25_Kc.Click
        Txt_Kc.Text = Lbl_PIcc25_Kc.Text
        Txt_Ti.Text = Lbl_PIcc25_Ti.Text
        Txt_Td.Text = 0
        metodo = "CC-25 | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
        Graficar()
        Txt_Ki.Text = (CSng(Txt_Kc.Text) / CSng(Txt_Ti.Text)).ToString("####0.00")
        If Txt_Td.Text > 0 Then Txt_Kd.Text = (CSng(Txt_Kc.Text) * CSng(Txt_Td.Text)).ToString("####0.00") Else Txt_Kd.Text = 0
    End Sub
    Private Sub Lbl_PIcc25_Ti_Click(sender As Object, e As EventArgs) Handles Lbl_PIcc25_Ti.Click
        Txt_Kc.Text = Lbl_PIcc25_Kc.Text
        Txt_Ti.Text = Lbl_PIcc25_Ti.Text
        Txt_Td.Text = 0
        metodo = "CC-25 | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
        Graficar()
        Txt_Ki.Text = (CSng(Txt_Kc.Text) / CSng(Txt_Ti.Text)).ToString("####0.00")
        If Txt_Td.Text > 0 Then Txt_Kd.Text = (CSng(Txt_Kc.Text) * CSng(Txt_Td.Text)).ToString("####0.00") Else Txt_Kd.Text = 0
    End Sub
    Private Sub Lbl_PIDcc25_Kc_Click(sender As Object, e As EventArgs) Handles Lbl_PIDcc25_Kc.Click
        Txt_Kc.Text = Lbl_PIDcc25_Kc.Text
        Txt_Ti.Text = Lbl_PIDcc25_Ti.Text
        Txt_Td.Text = Lbl_PIDcc25_Td.Text
        metodo = "CC-25 | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
        Graficar()
        Txt_Ki.Text = (CSng(Txt_Kc.Text) / CSng(Txt_Ti.Text)).ToString("####0.00")
        If Txt_Td.Text > 0 Then Txt_Kd.Text = (CSng(Txt_Kc.Text) * CSng(Txt_Td.Text)).ToString("####0.00") Else Txt_Kd.Text = 0
    End Sub
    Private Sub Lbl_PIDcc25_Ti_Click(sender As Object, e As EventArgs) Handles Lbl_PIDcc25_Ti.Click
        Txt_Kc.Text = Lbl_PIDcc25_Kc.Text
        Txt_Ti.Text = Lbl_PIDcc25_Ti.Text
        Txt_Td.Text = Lbl_PIDcc25_Td.Text
        metodo = "CC-25 | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
        Graficar()
        Txt_Ki.Text = (CSng(Txt_Kc.Text) / CSng(Txt_Ti.Text)).ToString("####0.00")
        If Txt_Td.Text > 0 Then Txt_Kd.Text = (CSng(Txt_Kc.Text) * CSng(Txt_Td.Text)).ToString("####0.00") Else Txt_Kd.Text = 0
    End Sub
    Private Sub Lbl_PIDcc25_Td_Click(sender As Object, e As EventArgs) Handles Lbl_PIDcc25_Td.Click
        Txt_Kc.Text = Lbl_PIDcc25_Kc.Text
        Txt_Ti.Text = Lbl_PIDcc25_Ti.Text
        Txt_Td.Text = Lbl_PIDcc25_Td.Text
        metodo = "CC-25 | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
        Graficar()
        Txt_Ki.Text = (CSng(Txt_Kc.Text) / CSng(Txt_Ti.Text)).ToString("####0.00")
        If Txt_Td.Text > 0 Then Txt_Kd.Text = (CSng(Txt_Kc.Text) * CSng(Txt_Td.Text)).ToString("####0.00") Else Txt_Kd.Text = 0
    End Sub
    Private Sub Lbl_Pcc10_Kc_Click(sender As Object, e As EventArgs) Handles Lbl_Pcc10_Kc.Click
        Txt_Kc.Text = Lbl_Pcc10_Kc.Text
        Txt_Ti.Text = 0
        Txt_Td.Text = 0
        metodo = "CC-10 | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
        Graficar()
        Txt_Ki.Text = 0
        Txt_Td.Text = 0
    End Sub
    Private Sub Lbl_PIcc10_Kc_Click(sender As Object, e As EventArgs) Handles Lbl_PIcc10_Kc.Click
        Txt_Kc.Text = Lbl_PIcc10_Kc.Text
        Txt_Ti.Text = Lbl_PIcc10_Ti.Text
        Txt_Td.Text = 0
        metodo = "CC-10 | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
        Graficar()
        Txt_Ki.Text = (CSng(Txt_Kc.Text) / CSng(Txt_Ti.Text)).ToString("####0.00")
        If Txt_Td.Text > 0 Then Txt_Kd.Text = (CSng(Txt_Kc.Text) * CSng(Txt_Td.Text)).ToString("####0.00") Else Txt_Kd.Text = 0
    End Sub
    Private Sub Lbl_PIcc10_Ti_Click(sender As Object, e As EventArgs) Handles Lbl_PIcc10_Ti.Click
        Txt_Kc.Text = Lbl_PIcc10_Kc.Text
        Txt_Ti.Text = Lbl_PIcc10_Ti.Text
        Txt_Td.Text = 0
        metodo = "CC-10 | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
        Graficar()
        Txt_Ki.Text = (CSng(Txt_Kc.Text) / CSng(Txt_Ti.Text)).ToString("####0.00")
        If Txt_Td.Text > 0 Then Txt_Kd.Text = (CSng(Txt_Kc.Text) * CSng(Txt_Td.Text)).ToString("####0.00") Else Txt_Kd.Text = 0
    End Sub
    Private Sub Lbl_PIDcc10_Kc_Click(sender As Object, e As EventArgs) Handles Lbl_PIDcc10_Kc.Click
        Txt_Kc.Text = Lbl_PIDcc10_Kc.Text
        Txt_Ti.Text = Lbl_PIDcc10_Ti.Text
        Txt_Td.Text = Lbl_PIDcc10_Td.Text
        metodo = "CC-10 | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
        Graficar()
        Txt_Ki.Text = (CSng(Txt_Kc.Text) / CSng(Txt_Ti.Text)).ToString("####0.00")
        If Txt_Td.Text > 0 Then Txt_Kd.Text = (CSng(Txt_Kc.Text) * CSng(Txt_Td.Text)).ToString("####0.00") Else Txt_Kd.Text = 0
    End Sub
    Private Sub Lbl_PIDcc10_Ti_Click(sender As Object, e As EventArgs) Handles Lbl_PIDcc10_Ti.Click
        Txt_Kc.Text = Lbl_PIDcc10_Kc.Text
        Txt_Ti.Text = Lbl_PIDcc10_Ti.Text
        Txt_Td.Text = Lbl_PIDcc10_Td.Text
        metodo = "CC-10 | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
        Graficar()
        Txt_Ki.Text = (CSng(Txt_Kc.Text) / CSng(Txt_Ti.Text)).ToString("####0.00")
        If Txt_Td.Text > 0 Then Txt_Kd.Text = (CSng(Txt_Kc.Text) * CSng(Txt_Td.Text)).ToString("####0.00") Else Txt_Kd.Text = 0
    End Sub
    Private Sub Lbl_PIDcc10_Td_Click(sender As Object, e As EventArgs) Handles Lbl_PIDcc10_Td.Click
        Txt_Kc.Text = Lbl_PIDcc10_Kc.Text
        Txt_Ti.Text = Lbl_PIDcc10_Ti.Text
        Txt_Td.Text = Lbl_PIDcc10_Td.Text
        metodo = "CC-10 | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
        Graficar()
        Txt_Ki.Text = (CSng(Txt_Kc.Text) / CSng(Txt_Ti.Text)).ToString("####0.00")
        If Txt_Td.Text > 0 Then Txt_Kd.Text = (CSng(Txt_Kc.Text) * CSng(Txt_Td.Text)).ToString("####0.00") Else Txt_Kd.Text = 0
    End Sub
    Private Sub Lbl_Pzn25_Kc_Click(sender As Object, e As EventArgs) Handles Lbl_Pzn25_Kc.Click
        Txt_Kc.Text = Lbl_Pzn25_Kc.Text
        Txt_Ti.Text = 0
        Txt_Td.Text = 0
        metodo = "ZN-25 | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
        Graficar()
        Txt_Ki.Text = 0
        Txt_Td.Text = 0
    End Sub
    Private Sub Lbl_PIzn25_Kc_Click(sender As Object, e As EventArgs) Handles Lbl_PIzn25_Kc.Click
        Txt_Kc.Text = Lbl_PIzn25_Kc.Text
        Txt_Ti.Text = Lbl_PIzn25_Ti.Text
        Txt_Td.Text = 0
        metodo = "ZN-25 | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
        Graficar()
        Txt_Ki.Text = (CSng(Txt_Kc.Text) / CSng(Txt_Ti.Text)).ToString("####0.00")
        If Txt_Td.Text > 0 Then Txt_Kd.Text = (CSng(Txt_Kc.Text) * CSng(Txt_Td.Text)).ToString("####0.00") Else Txt_Kd.Text = 0
    End Sub
    Private Sub Lbl_PIzn25_Ti_Click(sender As Object, e As EventArgs) Handles Lbl_PIzn25_Ti.Click
        Txt_Kc.Text = Lbl_PIzn25_Kc.Text
        Txt_Ti.Text = Lbl_PIzn25_Ti.Text
        Txt_Td.Text = 0
        metodo = "ZN-25 | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
        Graficar()
        Txt_Ki.Text = (CSng(Txt_Kc.Text) / CSng(Txt_Ti.Text)).ToString("####0.00")
        If Txt_Td.Text > 0 Then Txt_Kd.Text = (CSng(Txt_Kc.Text) * CSng(Txt_Td.Text)).ToString("####0.00") Else Txt_Kd.Text = 0
    End Sub
    Private Sub Lbl_PIDzn25_Kc_Click(sender As Object, e As EventArgs) Handles Lbl_PIDzn25_Kc.Click
        Txt_Kc.Text = Lbl_PIDzn25_Kc.Text
        Txt_Ti.Text = Lbl_PIDzn25_Ti.Text
        Txt_Td.Text = Lbl_PIDzn25_Td.Text
        metodo = "ZN-25 | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
        Graficar()
        Txt_Ki.Text = (CSng(Txt_Kc.Text) / CSng(Txt_Ti.Text)).ToString("####0.00")
        If Txt_Td.Text > 0 Then Txt_Kd.Text = (CSng(Txt_Kc.Text) * CSng(Txt_Td.Text)).ToString("####0.00") Else Txt_Kd.Text = 0
    End Sub
    Private Sub Lbl_PIDzn25_Ti_Click(sender As Object, e As EventArgs) Handles Lbl_PIDzn25_Ti.Click
        Txt_Kc.Text = Lbl_PIDzn25_Kc.Text
        Txt_Ti.Text = Lbl_PIDzn25_Ti.Text
        Txt_Td.Text = Lbl_PIDzn25_Td.Text
        metodo = "ZN-25 | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
        Graficar()
        Txt_Ki.Text = (CSng(Txt_Kc.Text) / CSng(Txt_Ti.Text)).ToString("####0.00")
        If Txt_Td.Text > 0 Then Txt_Kd.Text = (CSng(Txt_Kc.Text) * CSng(Txt_Td.Text)).ToString("####0.00") Else Txt_Kd.Text = 0
    End Sub
    Private Sub Lbl_PIDzn25_Td_Click(sender As Object, e As EventArgs) Handles Lbl_PIDzn25_Td.Click
        Txt_Kc.Text = Lbl_PIDzn25_Kc.Text
        Txt_Ti.Text = Lbl_PIDzn25_Ti.Text
        Txt_Td.Text = Lbl_PIDzn25_Td.Text
        metodo = "ZN-25 | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
        Graficar()
        Txt_Ki.Text = (CSng(Txt_Kc.Text) / CSng(Txt_Ti.Text)).ToString("####0.00")
        If Txt_Td.Text > 0 Then Txt_Kd.Text = (CSng(Txt_Kc.Text) * CSng(Txt_Td.Text)).ToString("####0.00") Else Txt_Kd.Text = 0
    End Sub
    Private Sub Lbl_Pzn10_Kc_Click(sender As Object, e As EventArgs) Handles Lbl_Pzn10_Kc.Click
        Txt_Kc.Text = Lbl_Pzn10_Kc.Text
        Txt_Ti.Text = 0
        Txt_Td.Text = 0
        metodo = "ZN-10 | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
        Graficar()
        Txt_Ki.Text = 0
        Txt_Td.Text = 0
    End Sub
    Private Sub Lbl_PIzn10_Kc_Click(sender As Object, e As EventArgs) Handles Lbl_PIzn10_Kc.Click
        Txt_Kc.Text = Lbl_PIzn10_Kc.Text
        Txt_Ti.Text = Lbl_PIzn10_Ti.Text
        Txt_Td.Text = 0
        metodo = "ZN-10 | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
        Graficar()
        Txt_Ki.Text = (CSng(Txt_Kc.Text) / CSng(Txt_Ti.Text)).ToString("####0.00")
        If Txt_Td.Text > 0 Then Txt_Kd.Text = (CSng(Txt_Kc.Text) * CSng(Txt_Td.Text)).ToString("####0.00") Else Txt_Kd.Text = 0
    End Sub
    Private Sub Lbl_PIzn10_Ti_Click(sender As Object, e As EventArgs) Handles Lbl_PIzn10_Ti.Click
        Txt_Kc.Text = Lbl_PIzn10_Kc.Text
        Txt_Ti.Text = Lbl_PIzn10_Ti.Text
        Txt_Td.Text = 0
        metodo = "ZN-10 | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
        Graficar()
        Txt_Ki.Text = (CSng(Txt_Kc.Text) / CSng(Txt_Ti.Text)).ToString("####0.00")
        If Txt_Td.Text > 0 Then Txt_Kd.Text = (CSng(Txt_Kc.Text) * CSng(Txt_Td.Text)).ToString("####0.00") Else Txt_Kd.Text = 0
    End Sub
    Private Sub Lbl_PIDzn10_Kc_Click(sender As Object, e As EventArgs) Handles Lbl_PIDzn10_Kc.Click
        Txt_Kc.Text = Lbl_PIDzn10_Kc.Text
        Txt_Ti.Text = Lbl_PIDzn10_Ti.Text
        Txt_Td.Text = Lbl_PIDzn10_Td.Text
        metodo = "ZN-10 | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
        Graficar()
        Txt_Ki.Text = (CSng(Txt_Kc.Text) / CSng(Txt_Ti.Text)).ToString("####0.00")
        If Txt_Td.Text > 0 Then Txt_Kd.Text = (CSng(Txt_Kc.Text) * CSng(Txt_Td.Text)).ToString("####0.00") Else Txt_Kd.Text = 0
    End Sub
    Private Sub Lbl_PIDzn10_Ti_Click(sender As Object, e As EventArgs) Handles Lbl_PIDzn10_Ti.Click
        Txt_Kc.Text = Lbl_PIDzn10_Kc.Text
        Txt_Ti.Text = Lbl_PIDzn10_Ti.Text
        Txt_Td.Text = Lbl_PIDzn10_Td.Text
        metodo = "ZN-10 | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
        Graficar()
        Txt_Ki.Text = (CSng(Txt_Kc.Text) / CSng(Txt_Ti.Text)).ToString("####0.00")
        If Txt_Td.Text > 0 Then Txt_Kd.Text = (CSng(Txt_Kc.Text) * CSng(Txt_Td.Text)).ToString("####0.00") Else Txt_Kd.Text = 0
    End Sub
    Private Sub Lbl_PIDzn10_Td_Click(sender As Object, e As EventArgs) Handles Lbl_PIDzn10_Td.Click
        Txt_Kc.Text = Lbl_PIDzn10_Kc.Text
        Txt_Ti.Text = Lbl_PIDzn10_Ti.Text
        Txt_Td.Text = Lbl_PIDzn10_Td.Text
        metodo = "ZN-10 | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
        Graficar()
        Txt_Ki.Text = (CSng(Txt_Kc.Text) / CSng(Txt_Ti.Text)).ToString("####0.00")
        If Txt_Td.Text > 0 Then Txt_Kd.Text = (CSng(Txt_Kc.Text) * CSng(Txt_Td.Text)).ToString("####0.00") Else Txt_Kd.Text = 0
    End Sub
    Private Sub Lbl_PIlambda_Kc_Click(sender As Object, e As EventArgs) Handles Lbl_PIlambda_Kc.Click
        Txt_Kc.Text = Lbl_PIlambda_Kc.Text
        Txt_Ti.Text = Lbl_PIlambda_Ti.Text
        Txt_Td.Text = 0
        metodo = "Lambda | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text & " (Tf: " & Txt_Tf.Text & ")"
        Graficar()
        Txt_Ki.Text = (CSng(Txt_Kc.Text) / CSng(Txt_Ti.Text)).ToString("####0.00")
        If Txt_Td.Text > 0 Then Txt_Kd.Text = (CSng(Txt_Kc.Text) * CSng(Txt_Td.Text)).ToString("####0.00") Else Txt_Kd.Text = 0
    End Sub
    Private Sub Lbl_PIlambda_Ti_Click(sender As Object, e As EventArgs) Handles Lbl_PIlambda_Ti.Click
        Txt_Kc.Text = Lbl_PIlambda_Kc.Text
        Txt_Ti.Text = Lbl_PIlambda_Ti.Text
        Txt_Td.Text = 0
        metodo = "Lambda | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text & " (Tf: " & Txt_Tf.Text & ")"
        Graficar()
        Txt_Ki.Text = (CSng(Txt_Kc.Text) / CSng(Txt_Ti.Text)).ToString("####0.00")
        If Txt_Td.Text > 0 Then Txt_Kd.Text = (CSng(Txt_Kc.Text) * CSng(Txt_Td.Text)).ToString("####0.00") Else Txt_Kd.Text = 0
    End Sub
    Private Sub Lbl_PIDlambda_Kc_Click(sender As Object, e As EventArgs) Handles Lbl_PIDlambda_Kc.Click
        Txt_Kc.Text = Lbl_PIDlambda_Kc.Text
        Txt_Ti.Text = Lbl_PIDlambda_Ti.Text
        Txt_Td.Text = Lbl_PIDlambda_Td.Text
        metodo = "Lambda | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text & " (Tf: " & Txt_Tf.Text & ")"
        Graficar()
        Txt_Ki.Text = (CSng(Txt_Kc.Text) / CSng(Txt_Ti.Text)).ToString("####0.00")
        If Txt_Td.Text > 0 Then Txt_Kd.Text = (CSng(Txt_Kc.Text) * CSng(Txt_Td.Text)).ToString("####0.00") Else Txt_Kd.Text = 0
    End Sub
    Private Sub Lbl_PIDlambda_Ti_Click(sender As Object, e As EventArgs) Handles Lbl_PIDlambda_Ti.Click
        Txt_Kc.Text = Lbl_PIDlambda_Kc.Text
        Txt_Ti.Text = Lbl_PIDlambda_Ti.Text
        Txt_Td.Text = Lbl_PIDlambda_Td.Text
        metodo = "Lambda | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text & " (Tf: " & Txt_Tf.Text & ")"
        Graficar()
        Txt_Ki.Text = (CSng(Txt_Kc.Text) / CSng(Txt_Ti.Text)).ToString("####0.00")
        If Txt_Td.Text > 0 Then Txt_Kd.Text = (CSng(Txt_Kc.Text) * CSng(Txt_Td.Text)).ToString("####0.00") Else Txt_Kd.Text = 0
    End Sub
    Private Sub Lbl_PIDlambda_Td_Click(sender As Object, e As EventArgs) Handles Lbl_PIDlambda_Td.Click
        Txt_Kc.Text = Lbl_PIDlambda_Kc.Text
        Txt_Ti.Text = Lbl_PIDlambda_Ti.Text
        Txt_Td.Text = Lbl_PIDlambda_Td.Text
        metodo = "Lambda | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text & " (Tf: " & Txt_Tf.Text & ")"
        Graficar()
        Txt_Ki.Text = (CSng(Txt_Kc.Text) / CSng(Txt_Ti.Text)).ToString("####0.00")
        If Txt_Td.Text > 0 Then Txt_Kd.Text = (CSng(Txt_Kc.Text) * CSng(Txt_Td.Text)).ToString("####0.00") Else Txt_Kd.Text = 0
    End Sub
    Private Sub Lbl_PIimc_Kc_Click(sender As Object, e As EventArgs) Handles Lbl_PIimc_Kc.Click
        Txt_Kc.Text = Lbl_PIimc_Kc.Text
        Txt_Ti.Text = Lbl_PIimc_Ti.Text
        Txt_Td.Text = 0
        metodo = "IMC | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text & " (Tf: " & Txt_Tf.Text & ")"
        Graficar()
        Txt_Ki.Text = (CSng(Txt_Kc.Text) / CSng(Txt_Ti.Text)).ToString("####0.00")
        If Txt_Td.Text > 0 Then Txt_Kd.Text = (CSng(Txt_Kc.Text) * CSng(Txt_Td.Text)).ToString("####0.00") Else Txt_Kd.Text = 0
    End Sub
    Private Sub Lbl_PIimc_Ti_Click(sender As Object, e As EventArgs) Handles Lbl_PIimc_Ti.Click
        Txt_Kc.Text = Lbl_PIimc_Kc.Text
        Txt_Ti.Text = Lbl_PIimc_Ti.Text
        Txt_Td.Text = 0
        metodo = "IMC | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text & " (Tf: " & Txt_Tf.Text & ")"
        Graficar()
        Txt_Ki.Text = (CSng(Txt_Kc.Text) / CSng(Txt_Ti.Text)).ToString("####0.00")
        If Txt_Td.Text > 0 Then Txt_Kd.Text = (CSng(Txt_Kc.Text) * CSng(Txt_Td.Text)).ToString("####0.00") Else Txt_Kd.Text = 0
    End Sub
    Private Sub Lbl_PIitaec_Kc_Click(sender As Object, e As EventArgs) Handles Lbl_PIitaec_Kc.Click
        Txt_Kc.Text = Lbl_PIitaec_Kc.Text
        Txt_Ti.Text = Lbl_PIitaec_Ti.Text
        Txt_Td.Text = 0
        metodo = "ITAE-C | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
        Graficar()
        Txt_Ki.Text = (CSng(Txt_Kc.Text) / CSng(Txt_Ti.Text)).ToString("####0.00")
        If Txt_Td.Text > 0 Then Txt_Kd.Text = (CSng(Txt_Kc.Text) * CSng(Txt_Td.Text)).ToString("####0.00") Else Txt_Kd.Text = 0
    End Sub
    Private Sub Lbl_PIitaec_Ti_Click(sender As Object, e As EventArgs) Handles Lbl_PIitaec_Ti.Click
        Txt_Kc.Text = Lbl_PIitaec_Kc.Text
        Txt_Ti.Text = Lbl_PIitaec_Ti.Text
        Txt_Td.Text = 0
        metodo = "ITAE-C | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
        Graficar()
        Txt_Ki.Text = (CSng(Txt_Kc.Text) / CSng(Txt_Ti.Text)).ToString("####0.00")
        If Txt_Td.Text > 0 Then Txt_Kd.Text = (CSng(Txt_Kc.Text) * CSng(Txt_Td.Text)).ToString("####0.00") Else Txt_Kd.Text = 0
    End Sub
    Private Sub Lbl_PIDitaec_Kc_Click(sender As Object, e As EventArgs) Handles Lbl_PIDitaec_Kc.Click
        Txt_Kc.Text = Lbl_PIDitaec_Kc.Text
        Txt_Ti.Text = Lbl_PIDitaec_Ti.Text
        Txt_Td.Text = Lbl_PIDitaec_Td.Text
        metodo = "ITAE-C | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
        Graficar()
        Txt_Ki.Text = (CSng(Txt_Kc.Text) / CSng(Txt_Ti.Text)).ToString("####0.00")
        If Txt_Td.Text > 0 Then Txt_Kd.Text = (CSng(Txt_Kc.Text) * CSng(Txt_Td.Text)).ToString("####0.00") Else Txt_Kd.Text = 0
    End Sub
    Private Sub Lbl_PIDitaec_Ti_Click(sender As Object, e As EventArgs) Handles Lbl_PIDitaec_Ti.Click
        Txt_Kc.Text = Lbl_PIDitaec_Kc.Text
        Txt_Ti.Text = Lbl_PIDitaec_Ti.Text
        Txt_Td.Text = Lbl_PIDitaec_Td.Text
        metodo = "ITAE-C | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
        Graficar()
        Txt_Ki.Text = (CSng(Txt_Kc.Text) / CSng(Txt_Ti.Text)).ToString("####0.00")
        If Txt_Td.Text > 0 Then Txt_Kd.Text = (CSng(Txt_Kc.Text) * CSng(Txt_Td.Text)).ToString("####0.00") Else Txt_Kd.Text = 0
    End Sub
    Private Sub Lbl_PIDitaec_Td_Click(sender As Object, e As EventArgs) Handles Lbl_PIDitaec_Td.Click
        Txt_Kc.Text = Lbl_PIDitaec_Kc.Text
        Txt_Ti.Text = Lbl_PIDitaec_Ti.Text
        Txt_Td.Text = Lbl_PIDitaec_Td.Text
        metodo = "ITAE-C | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
        Graficar()
        Txt_Ki.Text = (CSng(Txt_Kc.Text) / CSng(Txt_Ti.Text)).ToString("####0.00")
        If Txt_Td.Text > 0 Then Txt_Kd.Text = (CSng(Txt_Kc.Text) * CSng(Txt_Td.Text)).ToString("####0.00") Else Txt_Kd.Text = 0
    End Sub
    Private Sub Lbl_PIitaesp_Kc_Click(sender As Object, e As EventArgs) Handles Lbl_PIitaesp_Kc.Click
        Txt_Kc.Text = Lbl_PIitaesp_Kc.Text
        Txt_Ti.Text = Lbl_PIitaesp_Ti.Text
        Txt_Td.Text = 0
        metodo = "ITAE-SP | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
        Graficar()
        Txt_Ki.Text = (CSng(Txt_Kc.Text) / CSng(Txt_Ti.Text)).ToString("####0.00")
        If Txt_Td.Text > 0 Then Txt_Kd.Text = (CSng(Txt_Kc.Text) * CSng(Txt_Td.Text)).ToString("####0.00") Else Txt_Kd.Text = 0
    End Sub
    Private Sub Lbl_PIitaesp_Ti_Click(sender As Object, e As EventArgs) Handles Lbl_PIitaesp_Ti.Click
        Txt_Kc.Text = Lbl_PIitaesp_Kc.Text
        Txt_Ti.Text = Lbl_PIitaesp_Ti.Text
        Txt_Td.Text = 0
        metodo = "ITAE-SP | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
        Graficar()
        Txt_Ki.Text = (CSng(Txt_Kc.Text) / CSng(Txt_Ti.Text)).ToString("####0.00")
        If Txt_Td.Text > 0 Then Txt_Kd.Text = (CSng(Txt_Kc.Text) * CSng(Txt_Td.Text)).ToString("####0.00") Else Txt_Kd.Text = 0
    End Sub
    Private Sub Lbl_PIDitaesp_Kc_Click(sender As Object, e As EventArgs) Handles Lbl_PIDitaesp_Kc.Click
        Txt_Kc.Text = Lbl_PIDitaesp_Kc.Text
        Txt_Ti.Text = Lbl_PIDitaesp_Ti.Text
        Txt_Td.Text = Lbl_PIDitaesp_Td.Text
        metodo = "ITAE-SP | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
        Graficar()
        Txt_Ki.Text = (CSng(Txt_Kc.Text) / CSng(Txt_Ti.Text)).ToString("####0.00")
        If Txt_Td.Text > 0 Then Txt_Kd.Text = (CSng(Txt_Kc.Text) * CSng(Txt_Td.Text)).ToString("####0.00") Else Txt_Kd.Text = 0
    End Sub
    Private Sub Lbl_PIDitaesp_Ti_Click(sender As Object, e As EventArgs) Handles Lbl_PIDitaesp_Ti.Click
        Txt_Kc.Text = Lbl_PIDitaesp_Kc.Text
        Txt_Ti.Text = Lbl_PIDitaesp_Ti.Text
        Txt_Td.Text = Lbl_PIDitaesp_Td.Text
        metodo = "ITAE-SP | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
        Graficar()
        Txt_Ki.Text = (CSng(Txt_Kc.Text) / CSng(Txt_Ti.Text)).ToString("####0.00")
        If Txt_Td.Text > 0 Then Txt_Kd.Text = (CSng(Txt_Kc.Text) * CSng(Txt_Td.Text)).ToString("####0.00") Else Txt_Kd.Text = 0
    End Sub
    Private Sub Lbl_PIDitaesp_Td_Click(sender As Object, e As EventArgs) Handles Lbl_PIDitaesp_Td.Click
        Txt_Kc.Text = Lbl_PIDitaesp_Kc.Text
        Txt_Ti.Text = Lbl_PIDitaesp_Ti.Text
        Txt_Td.Text = Lbl_PIDitaesp_Td.Text
        metodo = "ITAE-SP | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
        Graficar()
        Txt_Ki.Text = (CSng(Txt_Kc.Text) / CSng(Txt_Ti.Text)).ToString("####0.00")
        If Txt_Td.Text > 0 Then Txt_Kd.Text = (CSng(Txt_Kc.Text) * CSng(Txt_Td.Text)).ToString("####0.00") Else Txt_Kd.Text = 0
    End Sub
    Private Sub Lbl_PIiaec_Kc_Click(sender As Object, e As EventArgs) Handles Lbl_PIiaec_Kc.Click
        Txt_Kc.Text = Lbl_PIiaec_Kc.Text
        Txt_Ti.Text = Lbl_PIiaec_Ti.Text
        Txt_Td.Text = 0
        metodo = "IAE-C | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
        Graficar()
        Txt_Ki.Text = (CSng(Txt_Kc.Text) / CSng(Txt_Ti.Text)).ToString("####0.00")
        If Txt_Td.Text > 0 Then Txt_Kd.Text = (CSng(Txt_Kc.Text) * CSng(Txt_Td.Text)).ToString("####0.00") Else Txt_Kd.Text = 0
    End Sub
    Private Sub Lbl_PIiaec_Ti_Click(sender As Object, e As EventArgs) Handles Lbl_PIiaec_Ti.Click
        Txt_Kc.Text = Lbl_PIiaec_Kc.Text
        Txt_Ti.Text = Lbl_PIiaec_Ti.Text
        Txt_Td.Text = 0
        metodo = "IAE-C | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
        Graficar()
        Txt_Ki.Text = (CSng(Txt_Kc.Text) / CSng(Txt_Ti.Text)).ToString("####0.00")
        If Txt_Td.Text > 0 Then Txt_Kd.Text = (CSng(Txt_Kc.Text) * CSng(Txt_Td.Text)).ToString("####0.00") Else Txt_Kd.Text = 0
    End Sub
    Private Sub Lbl_PIDiaec_Kc_Click(sender As Object, e As EventArgs) Handles Lbl_PIDiaec_Kc.Click
        Txt_Kc.Text = Lbl_PIDiaec_Kc.Text
        Txt_Ti.Text = Lbl_PIDiaec_Ti.Text
        Txt_Td.Text = Lbl_PIDiaec_Td.Text
        metodo = "IAE-C | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
        Graficar()
        Txt_Ki.Text = (CSng(Txt_Kc.Text) / CSng(Txt_Ti.Text)).ToString("####0.00")
        If Txt_Td.Text > 0 Then Txt_Kd.Text = (CSng(Txt_Kc.Text) * CSng(Txt_Td.Text)).ToString("####0.00") Else Txt_Kd.Text = 0
    End Sub
    Private Sub Lbl_PIDiaec_Ti_Click(sender As Object, e As EventArgs) Handles Lbl_PIDiaec_Ti.Click
        Txt_Kc.Text = Lbl_PIDiaec_Kc.Text
        Txt_Ti.Text = Lbl_PIDiaec_Ti.Text
        Txt_Td.Text = Lbl_PIDiaec_Td.Text
        metodo = "IAE-C | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
        Graficar()
        Txt_Ki.Text = (CSng(Txt_Kc.Text) / CSng(Txt_Ti.Text)).ToString("####0.00")
        If Txt_Td.Text > 0 Then Txt_Kd.Text = (CSng(Txt_Kc.Text) * CSng(Txt_Td.Text)).ToString("####0.00") Else Txt_Kd.Text = 0
    End Sub
    Private Sub Lbl_PIDiaec_Td_Click(sender As Object, e As EventArgs) Handles Lbl_PIDiaec_Td.Click
        Txt_Kc.Text = Lbl_PIDiaec_Kc.Text
        Txt_Ti.Text = Lbl_PIDiaec_Ti.Text
        Txt_Td.Text = Lbl_PIDiaec_Td.Text
        metodo = "IAE-C | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
        Graficar()
        Txt_Ki.Text = (CSng(Txt_Kc.Text) / CSng(Txt_Ti.Text)).ToString("####0.00")
        If Txt_Td.Text > 0 Then Txt_Kd.Text = (CSng(Txt_Kc.Text) * CSng(Txt_Td.Text)).ToString("####0.00") Else Txt_Kd.Text = 0
    End Sub
    Private Sub Lbl_PIiaesp_Kc_Click(sender As Object, e As EventArgs) Handles Lbl_PIiaesp_Kc.Click
        Txt_Kc.Text = Lbl_PIiaesp_Kc.Text
        Txt_Ti.Text = Lbl_PIiaesp_Ti.Text
        Txt_Td.Text = 0
        metodo = "IAE-SP | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
        Graficar()
        Txt_Ki.Text = (CSng(Txt_Kc.Text) / CSng(Txt_Ti.Text)).ToString("####0.00")
        If Txt_Td.Text > 0 Then Txt_Kd.Text = (CSng(Txt_Kc.Text) * CSng(Txt_Td.Text)).ToString("####0.00") Else Txt_Kd.Text = 0
    End Sub
    Private Sub Lbl_PIiaesp_Ti_Click(sender As Object, e As EventArgs) Handles Lbl_PIiaesp_Ti.Click
        Txt_Kc.Text = Lbl_PIiaesp_Kc.Text
        Txt_Ti.Text = Lbl_PIiaesp_Ti.Text
        Txt_Td.Text = 0
        metodo = "IAE-SP | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
        Graficar()
        Txt_Ki.Text = (CSng(Txt_Kc.Text) / CSng(Txt_Ti.Text)).ToString("####0.00")
        If Txt_Td.Text > 0 Then Txt_Kd.Text = (CSng(Txt_Kc.Text) * CSng(Txt_Td.Text)).ToString("####0.00") Else Txt_Kd.Text = 0
    End Sub
    Private Sub Lbl_PIDiaesp_Kc_Click(sender As Object, e As EventArgs) Handles Lbl_PIDiaesp_Kc.Click
        Txt_Kc.Text = Lbl_PIDiaesp_Kc.Text
        Txt_Ti.Text = Lbl_PIDiaesp_Ti.Text
        Txt_Td.Text = Lbl_PIDiaesp_Td.Text
        metodo = "IAE-SP | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
        Graficar()
        Txt_Ki.Text = (CSng(Txt_Kc.Text) / CSng(Txt_Ti.Text)).ToString("####0.00")
        If Txt_Td.Text > 0 Then Txt_Kd.Text = (CSng(Txt_Kc.Text) * CSng(Txt_Td.Text)).ToString("####0.00") Else Txt_Kd.Text = 0
    End Sub
    Private Sub Lbl_PIDiaesp_Ti_Click(sender As Object, e As EventArgs) Handles Lbl_PIDiaesp_Ti.Click
        Txt_Kc.Text = Lbl_PIDiaesp_Kc.Text
        Txt_Ti.Text = Lbl_PIDiaesp_Ti.Text
        Txt_Td.Text = Lbl_PIDiaesp_Td.Text
        metodo = "IAE-SP | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
        Graficar()
        Txt_Ki.Text = (CSng(Txt_Kc.Text) / CSng(Txt_Ti.Text)).ToString("####0.00")
        If Txt_Td.Text > 0 Then Txt_Kd.Text = (CSng(Txt_Kc.Text) * CSng(Txt_Td.Text)).ToString("####0.00") Else Txt_Kd.Text = 0
    End Sub
    Private Sub Lbl_PIDiaesp_Td_Click(sender As Object, e As EventArgs) Handles Lbl_PIDiaesp_Td.Click
        Txt_Kc.Text = Lbl_PIDiaesp_Kc.Text
        Txt_Ti.Text = Lbl_PIDiaesp_Ti.Text
        Txt_Td.Text = Lbl_PIDiaesp_Td.Text
        metodo = "IAE-SP | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
        Graficar()
        Txt_Ki.Text = (CSng(Txt_Kc.Text) / CSng(Txt_Ti.Text)).ToString("####0.00")
        If Txt_Td.Text > 0 Then Txt_Kd.Text = (CSng(Txt_Kc.Text) * CSng(Txt_Td.Text)).ToString("####0.00") Else Txt_Kd.Text = 0
    End Sub
    Private Sub Lbl_PIsimc_Kc_Click(sender As Object, e As EventArgs) Handles Lbl_PIsimc_Kc.Click
        Txt_Kc.Text = Lbl_PIsimc_Kc.Text
        Txt_Ti.Text = Lbl_PIsimc_Ti.Text
        Txt_Td.Text = 0
        metodo = "SIM C | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
        Graficar()
        Txt_Ki.Text = (CSng(Txt_Kc.Text) / CSng(Txt_Ti.Text)).ToString("####0.00")
        If Txt_Td.Text > 0 Then Txt_Kd.Text = (CSng(Txt_Kc.Text) * CSng(Txt_Td.Text)).ToString("####0.00") Else Txt_Kd.Text = 0
    End Sub
    Private Sub Lbl_PIsimc_Ti_Click(sender As Object, e As EventArgs) Handles Lbl_PIsimc_Ti.Click
        Txt_Kc.Text = Lbl_PIsimc_Kc.Text
        Txt_Ti.Text = Lbl_PIsimc_Ti.Text
        Txt_Td.Text = 0
        metodo = "SIM C | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
        Graficar()
        Txt_Ki.Text = (CSng(Txt_Kc.Text) / CSng(Txt_Ti.Text)).ToString("####0.00")
        If Txt_Td.Text > 0 Then Txt_Kd.Text = (CSng(Txt_Kc.Text) * CSng(Txt_Td.Text)).ToString("####0.00") Else Txt_Kd.Text = 0
    End Sub
    Private Sub Lbl_PIimpsimc_Kc_Click(sender As Object, e As EventArgs) Handles Lbl_PIimpsimc_Kc.Click
        Txt_Kc.Text = Lbl_PIimpsimc_Kc.Text
        Txt_Ti.Text = Lbl_PIimpsimc_Ti.Text
        Txt_Td.Text = 0
        metodo = "IMPROVED SIM C | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
        Graficar()
        Txt_Ki.Text = (CSng(Txt_Kc.Text) / CSng(Txt_Ti.Text)).ToString("####0.00")
        If Txt_Td.Text > 0 Then Txt_Kd.Text = (CSng(Txt_Kc.Text) * CSng(Txt_Td.Text)).ToString("####0.00") Else Txt_Kd.Text = 0
    End Sub
    Private Sub Lbl_PIimpsimc_Ti_Click(sender As Object, e As EventArgs) Handles Lbl_PIimpsimc_Ti.Click
        Txt_Kc.Text = Lbl_PIimpsimc_Kc.Text
        Txt_Ti.Text = Lbl_PIimpsimc_Ti.Text
        Txt_Td.Text = 0
        metodo = "IMPROVED SIM C | " & "Kc: " & Txt_Kc.Text & " Ti: " & Txt_Ti.Text & " Td: " & Txt_Td.Text
        Graficar()
        Txt_Ki.Text = (CSng(Txt_Kc.Text) / CSng(Txt_Ti.Text)).ToString("####0.00")
        If Txt_Td.Text > 0 Then Txt_Kd.Text = (CSng(Txt_Kc.Text) * CSng(Txt_Td.Text)).ToString("####0.00") Else Txt_Kd.Text = 0
    End Sub
    Private Sub Btn_save_Click(sender As Object, e As EventArgs) Handles Btn_save.Click
        Try
            Using printImage As Bitmap = New Bitmap(TableLayoutPanel1.Width, TableLayoutPanel1.Height)
                'Draw the TableLayoutPanel control to the temporary bitmap image
                TableLayoutPanel1.DrawToBitmap(printImage, New Rectangle(0, 0, printImage.Width, printImage.Height))
                '
                Clipboard.SetImage(DirectCast(printImage, Image))
                '
                Dim saveFileDialog1 As New SaveFileDialog()
                saveFileDialog1.Filter = "Imagen PNG (*.png)|*.png"
                saveFileDialog1.RestoreDirectory = True
                saveFileDialog1.FileName = "Tabla_Sintonias[K_" & Txt_K.Text & "_T0_" & Txt_To.Text & "_Tp_" & Txt_Tp.Text & "_Tf_" & Txt_Tf.Text & "]_" & DateTime.Now.ToString("HHmmss") & ".png"
                If saveFileDialog1.ShowDialog() = DialogResult.OK Then
                    printImage.Save(saveFileDialog1.FileName)
                End If
                'printImage.Save(Application.StartupPath & "\Tabla_Sintonias" & DateTime.Now.ToString("ddMMyyyyHHmmss") & ".png", ImageFormat.Png)
            End Using
        Catch ex As Exception

        End Try
    End Sub
End Class