Imports System.Drawing.Drawing2D
Public Class Form5
    Private Const Xmin As Single = -10.0F
    Private Const Xmax As Single = 10.0F
    Private Const Ymin As Single = -10.0F
    Private Const Ymax As Single = 10.0F
    Private DrawingTransform, InverseTransform As Matrix

    Private HasSolution As Boolean = False
    Private BestCoeffs As New List(Of Double)
    Private Points As New List(Of PointF)()

    Dim err As Double = 0

    Private Sub Btn_calcular_Click(sender As Object, e As EventArgs) Handles Btn_calcular.Click
        Me.Cursor = Cursors.WaitCursor
        Chart1.Titles.Clear()
        Chart1.Legends.Clear()
        Chart1.Series.Clear()
        Chart1.ChartAreas.Clear()
        '
        Dim Tini As Single = CSng(Txt_Tini.Text.Trim)
        Dim Tfin As Single = CSng(Txt_Tfin.Text.Trim)
        Dim Ts As Single = CSng(Form1.Num_delay.Value) / 1000
        If Points.Count > 0 Then Points.Clear()
        Try
            For i = (Tini / Ts) To (Tfin / Ts)
                Dim pts() As PointF = {New PointF(My.Forms.Form1.Chart1.Series(Cbo_OP.SelectedIndex).Points(i).XValue,
                                                  My.Forms.Form1.Chart1.Series(Cbo_PV.SelectedIndex).Points(i).YValues(0))}
                InverseTransform.TransformPoints(pts)
                ' Save the point.
                Points.Add(pts(0))
            Next
            '
            Txt_debug.Clear()
            Application.DoEvents()
            Dim start_time As Date = Date.Now
            ' Find a good fit.
            Dim degree As Integer = CInt(Txt_grado.Text)
            If BestCoeffs.Count > 0 Then BestCoeffs.Clear()
            BestCoeffs = FindPolynomialLeastSquaresFit(Points, degree)
            HasSolution = True
            Dim stop_time As Date = Date.Now
            Dim elapsed As TimeSpan = stop_time - start_time
            Console.WriteLine("Time: " &
                elapsed.TotalSeconds.ToString("0.00") & " seconds")
            Dim txt As String = ""
            For Each coeff As Double In BestCoeffs
                txt += " " + coeff.ToString()
            Next coeff
            Txt_debug.Text += vbCrLf
            Txt_debug.Text += "--Coeficientes--" + vbCrLf
            Txt_debug.Text += txt.Substring(1)
            'txtCoeffs.Text = txt.Substring(1)
            ' Display the error.
            ShowError()
            ' We have a solution.
            HasSolution = True
            '
            Chart1.ChartAreas.Add("0")
            Chart1.ChartAreas(0).BackColor = Color.FromArgb(60, 63, 65)
            Chart1.Series.Add("MinY")
            Chart1.Series(0).ChartType = DataVisualization.Charting.SeriesChartType.FastLine
            Chart1.Series(0).Color = Color.Blue
            Chart1.Series(0).BorderWidth = 2
            Chart1.Series(0).IsXValueIndexed = False
            Chart1.Series(0).ToolTip = "#VALY{f2}\n #VALX{f1}"
            'Chart1.Series.Add("MinX")
            'Chart1.Series(1).ChartType = DataVisualization.Charting.SeriesChartType.FastLine
            'Chart1.Series(1).Color = Color.Red
            'Chart1.Series(1).BorderWidth = 2
            'Chart1.Series(1).IsXValueIndexed = False
            'Chart1.Series(1).ToolTip = "#VALY{f2}\n #VALX{f1}"
            'Const dx As Single = (Xmax - Xmin) / 100
            'Const dy As Single = (Ymax - Ymin) / 100
            Dim count As Integer = 0
            For Each pt As PointF In Points
                'Chart1.Series(0).Points.AddXY(pt.X - dx, pt.Y - dy)
                'Chart1.Series(0).Points.AddXY(pt.X, pt.Y)
                Chart1.Series(0).Points.AddXY(count, pt.Y)
                'Chart1.Series(1).Points.AddXY(count, pt.X)
                count += 1
            Next pt
            'Const x_step As Double = 0.1
            'Dim y0 As Double = F(BestCoeffs, Xmin)
            'For x As Double = Xmin + x_step To Xmax Step x_step
            '    Dim y1 As Double = F(BestCoeffs, x)
            '    'e.Graphics.DrawLine(thin_pen, CSng(x - x_step), CSng(y0), CSng(x), CSng(y1))
            '    Chart1.Series(0).Points.AddXY(CSng(x - x_step), CSng(y0))
            '    y0 = y1
            'Next x
            Chart1.ChartAreas(0).AxisY.Minimum = Double.NaN
            Chart1.ChartAreas(0).AxisY.Maximum = Double.NaN
            Chart1.ChartAreas(0).RecalculateAxesScale()
            Chart1.ChartAreas(0).AxisX.ScaleView.Zoomable = True
            Chart1.ChartAreas(0).AxisY.ScaleView.Zoomable = True
            Chart1.ChartAreas(0).CursorX.IsUserSelectionEnabled = True
            Chart1.ChartAreas(0).CursorY.IsUserSelectionEnabled = True
            Chart1.ChartAreas(0).CursorX.AutoScroll = True
            Chart1.ChartAreas(0).CursorY.AutoScroll = True
            Chart1.ChartAreas(0).AxisY.IsStartedFromZero = False
            Chart1.ChartAreas(0).AxisX.IsStartedFromZero = True
            Chart1.ChartAreas(0).AxisX.LabelStyle.Format = "#.#"
            Chart1.ChartAreas(0).AxisX.Title = ""
            'Chart1.ChartAreas(0).AxisX.Minimum = 0
            Chart1.ChartAreas(0).RecalculateAxesScale()
            'Const x_step As Double = 0.1
            'Dim y0 As Double = F(BestCoeffs, Xmin)
            'For x As Double = Xmin + x_step To Xmax Step x_step
            '    Dim y1 As Double = F(BestCoeffs, x)
            '    'e.Graphics.DrawLine(thin_pen, CSng(x - x_step), CSng(y0), CSng(x), CSng(y1))
            '    Chart1.Series(0).Points.AddXY(x, 1)
            '    y0 = y1
            'Next x
            '
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString)
        End Try
    End Sub
    ' Draw the axes.
    Private Sub DrawAxes(ByVal gr As Graphics)
        Using thin_pen As New Pen(Color.Black, 0)
            Const xthick As Single = 0.2F
            Const ythick As Single = 0.2F
            gr.DrawLine(thin_pen, Xmin, 0, Xmax, 0)
            For x As Single = Xmin To Xmax Step 1.0F
                gr.DrawLine(thin_pen, x, -ythick, x, ythick)
            Next x
            gr.DrawLine(thin_pen, 0, Ymin, 0, Ymax)
            For y As Single = Ymin To Ymax Step 1.0F
                gr.DrawLine(thin_pen, -xthick, y, xthick, y)
            Next y
        End Using
    End Sub
    Private Sub ShowError()
        ' Get the error.

        Err = Math.Sqrt(ErrorSquared(Points, BestCoeffs))
        Txt_debug.Text += vbCrLf
        Txt_debug.Text += "--ShowError--" + vbCrLf
        Txt_debug.Text += err.ToString()
    End Sub
    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim world_rect As New RectangleF(Xmin, Ymin, Xmax - Xmin, Ymax - Ymin)
        Dim pts() As PointF =
        {
            New PointF(0, Form1.Chart1.ClientSize.Height),
            New PointF(Form1.Chart1.ClientSize.Width, Form1.Chart1.ClientSize.Height),
            New PointF(0, 0)
        }
        DrawingTransform = New Matrix(world_rect, pts)
        InverseTransform = DrawingTransform.Clone()
        InverseTransform.Invert()
        '
        If Form1.Chart1.Series.Count > 0 Then
            For i = 0 To Form1.Chart1.Series.Count - 1
                Cbo_PV.Items.Add(My.Forms.Form1.Chart1.Series(i).Name)
                Cbo_OP.Items.Add(My.Forms.Form1.Chart1.Series(i).Name)
            Next
        End If
        '
        If My.Forms.Form1.Chart1.Series.Count > 2 Then Txt_Tini.Text = 0
        If My.Forms.Form1.Chart1.Series.Count > 2 Then Txt_Tfin.Text = My.Forms.Form1.Chart1.Series(0).Points.Count - 2
    End Sub
    '--------------------------------------------------------------------------------------------
    Public Function F(ByVal coeffs As List(Of Double), ByVal x As Double) As Double
        Dim total As Double = 0
        Dim x_factor As Double = 1
        For i As Integer = 0 To coeffs.Count - 1
            total += x_factor * coeffs(i)
            x_factor *= x
        Next i
        Return total
    End Function
    ' Return the error squared.
    Public Function ErrorSquared(ByVal points As List(Of PointF), ByVal coeffs As List(Of Double)) As Double
        Dim total As Double = 0
        For Each pt As PointF In points
            Dim dy As Double = pt.Y - F(coeffs, pt.X)
            total += dy * dy
        Next pt
        Return total
    End Function
    ' Find the least squares linear fit.
    Public Function FindPolynomialLeastSquaresFit(ByVal points As List(Of PointF), ByVal degree As Integer) As List(Of Double)
        ' Allocate space for (degree + 1) equations with 
        ' (degree + 2) terms each (including the constant term).
        Dim coeffs(degree, degree + 1) As Double

        ' Calculate the coefficients for the equations.
        For j As Integer = 0 To degree
            ' Calculate the coefficients for the jth equation.

            ' Calculate the constant term for this equation.
            coeffs(j, degree + 1) = 0
            For Each pt As PointF In points
                coeffs(j, degree + 1) -= Math.Pow(pt.X, j) * pt.Y
            Next pt

            ' Calculate the other coefficients.
            For a_sub As Integer = 0 To degree
                ' Calculate the dth coefficient.
                coeffs(j, a_sub) = 0
                For Each pt As PointF In points
                    coeffs(j, a_sub) -= Math.Pow(pt.X, a_sub + j)
                Next pt
            Next a_sub
        Next j

        ' Solve the equations.
        Dim answer() As Double = GaussianElimination(coeffs)

        ' Return the result converted into a List(Of Double).
        Return answer.ToList()
    End Function

    ' Perform Gaussian elimination on these coefficients.
    ' Return the array of values that gives the solution.
    Private Function GaussianElimination(ByVal coeffs(,) As Double) As Double()
        Dim max_equation As Integer = coeffs.GetUpperBound(0)
        Dim max_coeff As Integer = coeffs.GetUpperBound(1)
        For i As Integer = 0 To max_equation
            ' Use equation_coeffs(i, i) to eliminate the ith
            ' coefficient in all of the other equations.

            ' Find a row with non-zero ith coefficient.
            If (coeffs(i, i) = 0) Then
                For j As Integer = i + 1 To max_equation
                    ' See if this one works.
                    If (coeffs(j, i) <> 0) Then
                        ' This one works. Swap equations i and j.
                        ' This starts at k = i because all
                        ' coefficients to the left are 0.
                        For k As Integer = i To max_coeff
                            Dim temp As Double = coeffs(i, k)
                            coeffs(i, k) = coeffs(j, k)
                            coeffs(j, k) = temp
                        Next k
                        Exit For
                    End If
                Next j
            End If

            ' Make sure we found an equation with
            ' a non-zero ith coefficient.
            Dim coeff_i_i As Double = coeffs(i, i)
            If coeff_i_i = 0 Then
                Throw New ArithmeticException(String.Format(
                    "There is no unique solution for these points.",
                    coeffs.GetUpperBound(0) - 1))
            End If

            ' Normalize the ith equation.
            For j As Integer = i To max_coeff
                coeffs(i, j) /= coeff_i_i
            Next j

            ' Use this equation value to zero out
            ' the other equations' ith coefficients.
            For j As Integer = 0 To max_equation
                ' Skip the ith equation.
                If (j <> i) Then
                    ' Zero the jth equation's ith coefficient.
                    Dim coef_j_i As Double = coeffs(j, i)
                    For d As Integer = 0 To max_coeff
                        coeffs(j, d) -= coeffs(i, d) * coef_j_i
                    Next d
                End If
            Next j
        Next i

        ' At this point, the ith equation contains
        ' 2 non-zero entries:
        '      The ith entry which is 1
        '      The last entry coeffs(max_coeff)
        ' This means Ai = equation_coef(max_coeff).
        Dim solution(max_equation) As Double
        For i As Integer = 0 To max_equation
            solution(i) = coeffs(i, max_coeff)
        Next i

        ' Return the solution values.
        Return solution
    End Function
    'Private Sub picGraph_MouseClick(sender As Object, e As MouseEventArgs)
    '    ' Transform the point to world coordinates.
    '    Dim pts() As PointF = {New PointF(e.X, e.Y)}
    '    InverseTransform.TransformPoints(pts)

    '    ' Save the point.
    '    Points.Add(pts(0))
    '    picGraph.Refresh()
    'End Sub
    'Private Sub picGraph_Paint(sender As Object, e As PaintEventArgs)
    '    ' Use the drawing transformation.
    '    e.Graphics.Transform = DrawingTransform
    '    ' Draw the axes.
    '    DrawAxes(e.Graphics)
    '    ' Draw the curve.
    '    If (HasSolution) Then
    '        Using thin_pen As New Pen(Color.Blue, 0)
    '            Const x_step As Double = 0.1
    '            Dim y0 As Double = F(BestCoeffs, Xmin)
    '            For x As Double = Xmin + x_step To Xmax Step x_step
    '                Dim y1 As Double = F(BestCoeffs, x)
    '                e.Graphics.DrawLine(thin_pen,
    '                    CSng(x - x_step), CSng(y0), CSng(x), CSng(y1))
    '                y0 = y1
    '            Next x
    '        End Using
    '    End If
    '    ' Draw the points.
    '    Const dx As Single = (Xmax - Xmin) / 100
    '    Const dy As Single = (Ymax - Ymin) / 100
    '    Using thin_pen As New Pen(Color.Black, 0)
    '        For Each pt As PointF In Points
    '            e.Graphics.FillRectangle(Brushes.White,
    '                pt.X - dx, pt.Y - dy, 2 * dx, 2 * dy)
    '            e.Graphics.DrawRectangle(thin_pen,
    '                pt.X - dx, pt.Y - dy, 2 * dx, 2 * dy)
    '        Next pt
    '    End Using
    'End Sub
End Class