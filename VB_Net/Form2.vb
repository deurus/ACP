Imports System.Windows.Forms.DataVisualization.Charting
Imports System.Drawing.Drawing2D
'http://www.vb-helper.com/howto_net_polynomial_least_squares.html
'https://www.controleng.com/articles/tuning-pid-control-loops-for-fast-response/
'https://www.controleng.com/articles/fundamentals-of-lambda-tuning/
Public Class Form2
    'Vars
    Dim culture As System.Globalization.CultureInfo = System.Globalization.CultureInfo.CurrentCulture
    Dim decimalSeparator As String = Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator
    Private Shared Function Interpolary(xArray As Double(), yArray As Double(), y As Double) As Double
        Dim points = xArray.Select(Of (x As Double, y As Double))(Function(xa, i) (xa, xArray(i))).OrderBy(Function(xy) Math.Abs(xy.y - y)).Take(2)
        Dim m = (points.Last().y - points.First().y) / (points.Last().x - points.First().x)
        Dim b = points.First().y / (points.First().x * m)
        Return m * y + b
    End Function
    Private Shared Function Interpolarx(xArray As Double(), yArray As Double(), x As Double) As Double
        Dim points = xArray.Select(Of (x As Double, y As Double))(Function(xa, i) (xa, yArray(i))).OrderBy(Function(xy) Math.Abs(xy.x - x)).Take(2)
        Dim m = (points.Last().y - points.First().y) / (points.Last().x - points.First().x)
        Dim b = points.First().y / (points.First().x * m)
        Return m * x + b
    End Function
    Private Shared Function Interpolate(xArray As Single(), yArray As Single(), x As Single) As Single
        Dim points = xArray.Select(Of (x As Single, y As Single))(Function(xa, i) (xa, yArray(i))).OrderBy(Function(xy) Math.Abs(xy.x - x)).Take(2)
        Dim m = (points.Last().y - points.First().y) / (points.Last().x - points.First().x)
        Dim b = points.First().y / (points.First().x * m)
        If Single.IsNaN(b) Then b = 0
        Return m * x + b
    End Function
    Private Sub Btn_aceptar_Click(sender As Object, e As EventArgs) Handles Btn_aceptar.Click
        My.Forms.Form1.Txt_K.Text = Txt_K.Text
        My.Forms.Form1.Txt_To.Text = Txt_To.Text
        My.Forms.Form1.Txt_Tp.Text = Txt_Tp.Text
        '
        My.Forms.Form1.Txt_PVrngSup.Text = Txt_rangomaxPV.Text.Trim
        My.Forms.Form1.Txt_PVrngInf.Text = Txt_rangominPV.Text.Trim
        Me.Hide()
    End Sub
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Form1.Chart1.Series.Count > 0 Then
            For i = 0 To Form1.Chart1.Series.Count - 1
                Cbo_PV.Items.Add(My.Forms.Form1.Chart1.Series(i).Name)
            Next
        End If
    End Sub
    Private Sub Txt_pvini_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_pvini.KeyPress
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
    Private Sub Txt_PVfin_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_PVfin.KeyPress
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
    Private Sub Txt_OPini_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_OPini.KeyPress
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
    Private Sub Txt_OPfinal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_OPfinal.KeyPress
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
    Private Sub Txt_Tini_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_Tini.KeyPress
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
    Private Sub Txt_Tfin_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_Tfin.KeyPress
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
    Private Sub Btn_calcular_Click(sender As Object, e As EventArgs) Handles Btn_calcular.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim PVInt As Boolean = False
            Dim PVInt_conta As Integer = 0
            Dim PVini As Single = CSng(Txt_pvini.Text.Trim)
            Dim PVfin As Single = CSng(Txt_PVfin.Text.Trim)
            Dim dPV As Single = Math.Abs(PVini - PVfin)
            If PVini Mod 1 = 0 And PVfin Mod 1 = 0 Then Txt_dPV.Text = dPV.ToString Else Txt_dPV.Text = dPV.ToString("####0.00")
            Dim OPini As Single = CSng(Txt_OPini.Text.Trim)
            Dim OPfin As Single = CSng(Txt_OPfinal.Text.Trim)
            Dim dOP As Single = Math.Abs(OPini - OPfin)
            If OPini Mod 1 = 0 And OPfin Mod 1 = 0 Then Txt_dOP.Text = dOP.ToString Else Txt_dOP.Text = dOP.ToString("####0.00")
            Dim Tini As Single = CSng(Txt_Tini.Text.Trim)
            Dim Tfin As Single = CSng(Txt_Tfin.Text.Trim)
            Dim rangoPV As Single = Math.Abs(CSng(Txt_rangomaxPV.Text.Trim) - Txt_rangominPV.Text.Trim)
            Dim rangoOP As Single = Math.Abs(CSng(Txt_rangomaxOP.Text.Trim) - Txt_rangominOP.Text.Trim)
            Dim Ts As Single = CSng(Form1.Num_delay.Value) / 1000
            '
            Dim T1 As Single = 0
            Dim T2 As Single = 0
            Dim fecha As DateTime = DateTime.Now
            Txt_debug.Text = "Cálculo realizado " & fecha.ToString("dd/MM/yyyy HH:mm:ss") + vbCrLf
            Dim T1tmp, T2tmp As Single
            If PVini > PVfin Then
                If PVini Mod 1 = 0 Then T1tmp = Math.Round(PVini - 0.283 * dPV) Else T1tmp = Math.Round(PVini - 0.283 * dPV, 2)
            End If
            If PVini < PVfin Then
                If PVini Mod 1 = 0 Then T1tmp = Math.Round(PVini + 0.283 * dPV) Else T1tmp = Math.Round(PVini + 0.283 * dPV, 2)
            End If
            '
            If PVini > PVfin Then
                If PVini Mod 1 = 0 Then T2tmp = Math.Round(PVini - 0.632 * dPV) Else T2tmp = Math.Round(PVini - 0.632 * dPV, 2)
            End If
            If PVini < PVfin Then
                If PVini Mod 1 = 0 Then T2tmp = Math.Round(PVini + 0.632 * dPV) Else T2tmp = Math.Round(PVini + 0.632 * dPV, 2)
            End If
            Txt_debug.AppendText("PV 28,3% = " & T1tmp & " EU" + vbCrLf)
            Txt_debug.AppendText("PV 63,2% = " & T2tmp & " EU" + vbCrLf)
            'Si no existe cojo el valor más próximo
            'Dim x As New List(Of Double)
            'Dim Y1 As New List(Of Double)
            'Dim yT2 As New List(Of Double)
            '
            Dim decimales As Integer = My.Forms.Form1.Chart1.Series(Cbo_PV.SelectedIndex).Points(Tini / Ts).YValues(0).ToString.Length -
                InStr(My.Forms.Form1.Chart1.Series(Cbo_PV.SelectedIndex).Points(Tini / Ts).YValues(0).ToString, ",")
            Dim decimalconversion As String = ""
            If decimales = 1 Then decimalconversion = "###0.0"
            If decimales = 2 Then decimalconversion = "####0.00"
            If decimales = 3 Then decimalconversion = "#####0.000"
            If decimales = 4 Then decimalconversion = "######0.0000"
            If decimales = 5 Then decimalconversion = "######0.00000"
            '
            Dim dataPointT1 As DataPoint
            Dim yvals((Tfin / Ts) - (Tini / Ts)) As Single
            Dim xvals((Tfin / Ts) - (Tini / Ts)) As Single
            dataPointT1 = My.Forms.Form1.Chart1.Series(Cbo_PV.SelectedIndex).Points.FindByValue(T1tmp, "Y", Tini / Ts)
            If Not dataPointT1 Is Nothing AndAlso dataPointT1.XValue < Tfin Then
                Txt_debug.AppendText("T1(28,3%) encontrado en el segundo " & dataPointT1.XValue.ToString & " con valor exacto." + vbCrLf)
            Else
                'Encontrar el valor más cercano
                For i = (Tini / Ts) To (Tfin / Ts)
                    yvals(i - (Tini / Ts)) = My.Forms.Form1.Chart1.Series(Cbo_PV.SelectedIndex).Points(i).YValues(0)
                    xvals(i - (Tini / Ts)) = My.Forms.Form1.Chart1.Series(Cbo_PV.SelectedIndex).Points(i).XValue
                Next
                Dim nearestT1 = yvals.Min(Function(a) Math.Abs(a - T1tmp))
                dataPointT1 = My.Forms.Form1.Chart1.Series(Cbo_PV.SelectedIndex).Points.FindByValue((T1tmp + nearestT1).ToString(decimalconversion), "Y", Tini / Ts)
                If Not dataPointT1 Is Nothing AndAlso dataPointT1.XValue < Tfin Then
                    Txt_debug.AppendText("T1(28,3%) encontrado en el segundo " & dataPointT1.XValue.ToString("###0.0") & " con valor aproximado " + (T1tmp + nearestT1).ToString(decimalconversion) + " EU." + vbCrLf)
                Else
                    dataPointT1 = My.Forms.Form1.Chart1.Series(Cbo_PV.SelectedIndex).Points.FindByValue((T1tmp - nearestT1).ToString(decimalconversion), "Y", Tini / Ts)
                    Txt_debug.AppendText("T1(28,3%) encontrado en el segundo " & dataPointT1.XValue.ToString("###0.0") & " con valor aproximado " + (T1tmp - nearestT1).ToString(decimalconversion) + " EU." + vbCrLf)
                End If
            End If
            '
            Dim dataPointT2 As DataPoint
            dataPointT2 = My.Forms.Form1.Chart1.Series(Cbo_PV.SelectedIndex).Points.FindByValue(T2tmp, "Y", Tini / Ts)
            If Not dataPointT2 Is Nothing AndAlso dataPointT2.XValue < Tfin Then
                Txt_debug.AppendText("T2(63,2%) encontrado en el segundo " & dataPointT2.XValue.ToString(decimalconversion) & " con valor exacto." + vbCrLf)
            Else
                'Encontrar el valor más cercano
                For i = (Tini / Ts) To (Tfin / Ts)
                    yvals(i - (Tini / Ts)) = My.Forms.Form1.Chart1.Series(Cbo_PV.SelectedIndex).Points(i).YValues(0)
                    xvals(i - (Tini / Ts)) = My.Forms.Form1.Chart1.Series(Cbo_PV.SelectedIndex).Points(i).XValue
                Next
                Dim nearestT2 = yvals.Min(Function(a) Math.Abs(a - T2tmp))
                dataPointT2 = My.Forms.Form1.Chart1.Series(Cbo_PV.SelectedIndex).Points.FindByValue((T2tmp + nearestT2).ToString(decimalconversion), "Y", Tini / Ts)
                If Not dataPointT2 Is Nothing AndAlso dataPointT2.XValue < Tfin Then
                    Txt_debug.AppendText("T2(63,2%) encontrado en el segundo " & dataPointT2.XValue.ToString("###0.0") & " con valor aproximado " + (T2tmp + nearestT2).ToString(decimalconversion) + " EU." + vbCrLf)
                Else
                    dataPointT2 = My.Forms.Form1.Chart1.Series(Cbo_PV.SelectedIndex).Points.FindByValue((T2tmp - nearestT2).ToString(decimalconversion), "Y", Tini / Ts)
                    Txt_debug.AppendText("T2(63,2%) encontrado en el segundo " & dataPointT2.XValue.ToString("###0.0") & " con valor aproximado " + (T2tmp - nearestT2).ToString(decimalconversion) + " EU." + vbCrLf)
                End If
            End If
                '
                If Chk_anotaciones.Checked = True Then
                Dim annotationCallout As New CalloutAnnotation()
                annotationCallout.AnchorDataPoint = My.Forms.Form1.Chart1.Series(Cbo_PV.SelectedIndex).Points((dataPointT1.XValue / Ts) - 1)
                annotationCallout.Text = "T1(28,3%)\nValor: #VALY\nSegundo #VALX{f1}\n"
                annotationCallout.BackColor = My.Forms.Form1.Chart1.Series(Cbo_PV.SelectedIndex).Color
                annotationCallout.ClipToChartArea = "Default"
                annotationCallout.AllowMoving = True
                annotationCallout.AllowAnchorMoving = True
                annotationCallout.AllowSelecting = True
                annotationCallout.AllowResizing = True
                annotationCallout.AllowTextEditing = True
                My.Forms.Form1.Chart1.Annotations.Add(annotationCallout)
                '
                annotationCallout = New CalloutAnnotation()
                annotationCallout.AnchorDataPoint = My.Forms.Form1.Chart1.Series(Cbo_PV.SelectedIndex).Points((dataPointT2.XValue / Ts) - 1)
                annotationCallout.Text = "T2(63,2%)\nValor: #VALY\nSegundo #VALX{f1}\n"
                annotationCallout.BackColor = My.Forms.Form1.Chart1.Series(Cbo_PV.SelectedIndex).Color
                annotationCallout.ClipToChartArea = "Default"
                annotationCallout.AllowMoving = True
                annotationCallout.AllowAnchorMoving = True
                annotationCallout.AllowSelecting = True
                annotationCallout.AllowResizing = True
                annotationCallout.AllowTextEditing = True
                My.Forms.Form1.Chart1.Annotations.Add(annotationCallout)
                My.Forms.Form1.Chart1.Invalidate()
            End If
            '
            Txt_T1.Text = (dataPointT1.XValue).ToString("###0.0")
            Txt_T2.Text = (dataPointT2.XValue).ToString("###0.0")
            'Variables del sistema
            Txt_K.Text = ((100 * dPV / rangoPV) / (100 * dOP / rangoOP)).ToString("#####0.000") '%/%
            Txt_Tp.Text = (1.5 * (dataPointT2.XValue - dataPointT1.XValue)).ToString("####0.00") 'seg
            Txt_To.Text = (Math.Max((dataPointT2.XValue - Tini) - CSng(Txt_Tp.Text), CSng(My.Forms.Form1.Num_delay.Value) / 1000)).ToString("####0.00") 'si da negativo como mínimo tiene que ser el Tiempo de muestreo
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            'MsgBox(ex.ToString)
            MsgBox("Ocurrió algún error al calcular, revisa los campos.")
        End Try
    End Sub
    Private Sub DarkButton1_Click(sender As Object, e As EventArgs) Handles DarkButton1.Click
        If Me.Width = 415 Then
            Me.Width = 921
            DarkButton1.Text = "<<"
            Exit Sub
        End If
        If Me.Width = 921 Then
            Me.Width = 415
            DarkButton1.Text = ">>"
        End If
    End Sub
    Private Sub Txt_rangomaxPV_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_rangomaxPV.KeyPress
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
    Private Sub Txt_rangominPV_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_rangominPV.KeyPress
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
    Private Sub Txt_rangomaxOP_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_rangomaxOP.KeyPress
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
    Private Sub Txt_rangominOP_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_rangominOP.KeyPress
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
End Class