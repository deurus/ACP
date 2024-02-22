<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form5
	Inherits System.Windows.Forms.Form

	'Form reemplaza a Dispose para limpiar la lista de componentes.
	<System.Diagnostics.DebuggerNonUserCode()> _
	Protected Overrides Sub Dispose(ByVal disposing As Boolean)
		Try
			If disposing AndAlso components IsNot Nothing Then
				components.Dispose()
			End If
		Finally
			MyBase.Dispose(disposing)
		End Try
	End Sub

	'Requerido por el Diseñador de Windows Forms
	Private components As System.ComponentModel.IContainer

	'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
	'Se puede modificar usando el Diseñador de Windows Forms.  
	'No lo modifique con el editor de código.
	<System.Diagnostics.DebuggerStepThrough()> _
	Private Sub InitializeComponent()
		Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
		Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
		Me.DarkSectionPanel3 = New DarkUI.Controls.DarkSectionPanel()
		Me.DarkLabel13 = New DarkUI.Controls.DarkLabel()
		Me.Txt_Tp = New DarkUI.Controls.DarkTextBox()
		Me.DarkLabel14 = New DarkUI.Controls.DarkLabel()
		Me.Txt_To = New DarkUI.Controls.DarkTextBox()
		Me.DarkLabel15 = New DarkUI.Controls.DarkLabel()
		Me.Txt_K = New DarkUI.Controls.DarkTextBox()
		Me.Btn_calcular = New DarkUI.Controls.DarkButton()
		Me.DarkSectionPanel1 = New DarkUI.Controls.DarkSectionPanel()
		Me.Txt_grado = New DarkUI.Controls.DarkTextBox()
		Me.DarkLabel2 = New DarkUI.Controls.DarkLabel()
		Me.DarkLabel1 = New DarkUI.Controls.DarkLabel()
		Me.Cbo_OP = New DarkUI.Controls.DarkComboBox()
		Me.DarkLabel16 = New DarkUI.Controls.DarkLabel()
		Me.Cbo_PV = New DarkUI.Controls.DarkComboBox()
		Me.Txt_Tfin = New DarkUI.Controls.DarkTextBox()
		Me.DarkLabel5 = New DarkUI.Controls.DarkLabel()
		Me.DarkLabel6 = New DarkUI.Controls.DarkLabel()
		Me.Txt_Tini = New DarkUI.Controls.DarkTextBox()
		Me.Txt_debug = New System.Windows.Forms.RichTextBox()
		Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
		Me.DarkSectionPanel3.SuspendLayout()
		Me.DarkSectionPanel1.SuspendLayout()
		CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'DarkSectionPanel3
		'
		Me.DarkSectionPanel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.DarkSectionPanel3.Controls.Add(Me.DarkLabel13)
		Me.DarkSectionPanel3.Controls.Add(Me.Txt_Tp)
		Me.DarkSectionPanel3.Controls.Add(Me.DarkLabel14)
		Me.DarkSectionPanel3.Controls.Add(Me.Txt_To)
		Me.DarkSectionPanel3.Controls.Add(Me.DarkLabel15)
		Me.DarkSectionPanel3.Controls.Add(Me.Txt_K)
		Me.DarkSectionPanel3.Location = New System.Drawing.Point(219, 12)
		Me.DarkSectionPanel3.Name = "DarkSectionPanel3"
		Me.DarkSectionPanel3.SectionHeader = "Datos calculados"
		Me.DarkSectionPanel3.Size = New System.Drawing.Size(141, 120)
		Me.DarkSectionPanel3.TabIndex = 7
		'
		'DarkLabel13
		'
		Me.DarkLabel13.AutoSize = True
		Me.DarkLabel13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.DarkLabel13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.DarkLabel13.Location = New System.Drawing.Point(19, 92)
		Me.DarkLabel13.Name = "DarkLabel13"
		Me.DarkLabel13.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.DarkLabel13.Size = New System.Drawing.Size(40, 13)
		Me.DarkLabel13.TabIndex = 27
		Me.DarkLabel13.Text = "Tp (s)"
		'
		'Txt_Tp
		'
		Me.Txt_Tp.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
		Me.Txt_Tp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.Txt_Tp.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.Txt_Tp.Location = New System.Drawing.Point(61, 90)
		Me.Txt_Tp.Name = "Txt_Tp"
		Me.Txt_Tp.ReadOnly = True
		Me.Txt_Tp.Size = New System.Drawing.Size(65, 20)
		Me.Txt_Tp.TabIndex = 26
		'
		'DarkLabel14
		'
		Me.DarkLabel14.AutoSize = True
		Me.DarkLabel14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.DarkLabel14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.DarkLabel14.Location = New System.Drawing.Point(19, 66)
		Me.DarkLabel14.Name = "DarkLabel14"
		Me.DarkLabel14.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.DarkLabel14.Size = New System.Drawing.Size(40, 13)
		Me.DarkLabel14.TabIndex = 25
		Me.DarkLabel14.Text = "T0 (s)"
		'
		'Txt_To
		'
		Me.Txt_To.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
		Me.Txt_To.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.Txt_To.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.Txt_To.Location = New System.Drawing.Point(61, 64)
		Me.Txt_To.Name = "Txt_To"
		Me.Txt_To.ReadOnly = True
		Me.Txt_To.Size = New System.Drawing.Size(65, 20)
		Me.Txt_To.TabIndex = 24
		'
		'DarkLabel15
		'
		Me.DarkLabel15.AutoSize = True
		Me.DarkLabel15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.DarkLabel15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.DarkLabel15.Location = New System.Drawing.Point(8, 40)
		Me.DarkLabel15.Name = "DarkLabel15"
		Me.DarkLabel15.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.DarkLabel15.Size = New System.Drawing.Size(51, 13)
		Me.DarkLabel15.TabIndex = 23
		Me.DarkLabel15.Text = "K (%/%)"
		'
		'Txt_K
		'
		Me.Txt_K.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
		Me.Txt_K.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.Txt_K.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.Txt_K.Location = New System.Drawing.Point(61, 38)
		Me.Txt_K.Name = "Txt_K"
		Me.Txt_K.ReadOnly = True
		Me.Txt_K.Size = New System.Drawing.Size(65, 20)
		Me.Txt_K.TabIndex = 22
		'
		'Btn_calcular
		'
		Me.Btn_calcular.Image = Global.Arduino_COM_Plotter.My.Resources.Resources.Calculator
		Me.Btn_calcular.Location = New System.Drawing.Point(219, 136)
		Me.Btn_calcular.Name = "Btn_calcular"
		Me.Btn_calcular.Padding = New System.Windows.Forms.Padding(5)
		Me.Btn_calcular.Size = New System.Drawing.Size(141, 60)
		Me.Btn_calcular.TabIndex = 28
		Me.Btn_calcular.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
		'
		'DarkSectionPanel1
		'
		Me.DarkSectionPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.DarkSectionPanel1.Controls.Add(Me.Txt_grado)
		Me.DarkSectionPanel1.Controls.Add(Me.DarkLabel2)
		Me.DarkSectionPanel1.Controls.Add(Me.DarkLabel1)
		Me.DarkSectionPanel1.Controls.Add(Me.Cbo_OP)
		Me.DarkSectionPanel1.Controls.Add(Me.DarkLabel16)
		Me.DarkSectionPanel1.Controls.Add(Me.Cbo_PV)
		Me.DarkSectionPanel1.Controls.Add(Me.Txt_Tfin)
		Me.DarkSectionPanel1.Controls.Add(Me.DarkLabel5)
		Me.DarkSectionPanel1.Controls.Add(Me.DarkLabel6)
		Me.DarkSectionPanel1.Controls.Add(Me.Txt_Tini)
		Me.DarkSectionPanel1.Location = New System.Drawing.Point(12, 12)
		Me.DarkSectionPanel1.Name = "DarkSectionPanel1"
		Me.DarkSectionPanel1.SectionHeader = "Datos obtenidos del gráfico"
		Me.DarkSectionPanel1.Size = New System.Drawing.Size(201, 184)
		Me.DarkSectionPanel1.TabIndex = 6
		'
		'Txt_grado
		'
		Me.Txt_grado.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
		Me.Txt_grado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.Txt_grado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.Txt_grado.Location = New System.Drawing.Point(113, 151)
		Me.Txt_grado.Name = "Txt_grado"
		Me.Txt_grado.Size = New System.Drawing.Size(65, 20)
		Me.Txt_grado.TabIndex = 29
		Me.Txt_grado.Text = "5"
		'
		'DarkLabel2
		'
		Me.DarkLabel2.AutoSize = True
		Me.DarkLabel2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.DarkLabel2.Location = New System.Drawing.Point(71, 154)
		Me.DarkLabel2.Name = "DarkLabel2"
		Me.DarkLabel2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.DarkLabel2.Size = New System.Drawing.Size(36, 13)
		Me.DarkLabel2.TabIndex = 28
		Me.DarkLabel2.Text = "Grado"
		'
		'DarkLabel1
		'
		Me.DarkLabel1.AutoSize = True
		Me.DarkLabel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.DarkLabel1.Location = New System.Drawing.Point(61, 75)
		Me.DarkLabel1.Name = "DarkLabel1"
		Me.DarkLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.DarkLabel1.Size = New System.Drawing.Size(49, 13)
		Me.DarkLabel1.TabIndex = 27
		Me.DarkLabel1.Text = "Serie OP"
		'
		'Cbo_OP
		'
		Me.Cbo_OP.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
		Me.Cbo_OP.FormattingEnabled = True
		Me.Cbo_OP.Location = New System.Drawing.Point(113, 71)
		Me.Cbo_OP.Name = "Cbo_OP"
		Me.Cbo_OP.Size = New System.Drawing.Size(65, 21)
		Me.Cbo_OP.TabIndex = 26
		'
		'DarkLabel16
		'
		Me.DarkLabel16.AutoSize = True
		Me.DarkLabel16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.DarkLabel16.Location = New System.Drawing.Point(62, 48)
		Me.DarkLabel16.Name = "DarkLabel16"
		Me.DarkLabel16.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.DarkLabel16.Size = New System.Drawing.Size(48, 13)
		Me.DarkLabel16.TabIndex = 25
		Me.DarkLabel16.Text = "Serie PV"
		'
		'Cbo_PV
		'
		Me.Cbo_PV.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
		Me.Cbo_PV.FormattingEnabled = True
		Me.Cbo_PV.Location = New System.Drawing.Point(113, 44)
		Me.Cbo_PV.Name = "Cbo_PV"
		Me.Cbo_PV.Size = New System.Drawing.Size(65, 21)
		Me.Cbo_PV.TabIndex = 24
		'
		'Txt_Tfin
		'
		Me.Txt_Tfin.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
		Me.Txt_Tfin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.Txt_Tfin.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.Txt_Tfin.Location = New System.Drawing.Point(113, 125)
		Me.Txt_Tfin.Name = "Txt_Tfin"
		Me.Txt_Tfin.Size = New System.Drawing.Size(65, 20)
		Me.Txt_Tfin.TabIndex = 23
		'
		'DarkLabel5
		'
		Me.DarkLabel5.AutoSize = True
		Me.DarkLabel5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.DarkLabel5.Location = New System.Drawing.Point(46, 128)
		Me.DarkLabel5.Name = "DarkLabel5"
		Me.DarkLabel5.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.DarkLabel5.Size = New System.Drawing.Size(64, 13)
		Me.DarkLabel5.TabIndex = 22
		Me.DarkLabel5.Text = "Tiempo final"
		'
		'DarkLabel6
		'
		Me.DarkLabel6.AutoSize = True
		Me.DarkLabel6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.DarkLabel6.Location = New System.Drawing.Point(39, 102)
		Me.DarkLabel6.Name = "DarkLabel6"
		Me.DarkLabel6.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.DarkLabel6.Size = New System.Drawing.Size(71, 13)
		Me.DarkLabel6.TabIndex = 21
		Me.DarkLabel6.Text = "Tiempo inicial"
		'
		'Txt_Tini
		'
		Me.Txt_Tini.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
		Me.Txt_Tini.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.Txt_Tini.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.Txt_Tini.Location = New System.Drawing.Point(113, 99)
		Me.Txt_Tini.Name = "Txt_Tini"
		Me.Txt_Tini.Size = New System.Drawing.Size(65, 20)
		Me.Txt_Tini.TabIndex = 20
		'
		'Txt_debug
		'
		Me.Txt_debug.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
		Me.Txt_debug.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Txt_debug.Location = New System.Drawing.Point(384, 12)
		Me.Txt_debug.Name = "Txt_debug"
		Me.Txt_debug.Size = New System.Drawing.Size(465, 184)
		Me.Txt_debug.TabIndex = 29
		Me.Txt_debug.Text = ""
		'
		'Chart1
		'
		Me.Chart1.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
		ChartArea1.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
		ChartArea1.Name = "ChartArea1"
		Me.Chart1.ChartAreas.Add(ChartArea1)
		Me.Chart1.Location = New System.Drawing.Point(12, 202)
		Me.Chart1.Name = "Chart1"
		Series1.ChartArea = "ChartArea1"
		Series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine
		Series1.Name = "Series1"
		Me.Chart1.Series.Add(Series1)
		Me.Chart1.Size = New System.Drawing.Size(837, 228)
		Me.Chart1.TabIndex = 59
		Me.Chart1.Text = "Chart1"
		'
		'Form5
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
		Me.ClientSize = New System.Drawing.Size(870, 436)
		Me.Controls.Add(Me.Chart1)
		Me.Controls.Add(Me.Txt_debug)
		Me.Controls.Add(Me.Btn_calcular)
		Me.Controls.Add(Me.DarkSectionPanel3)
		Me.Controls.Add(Me.DarkSectionPanel1)
		Me.Name = "Form5"
		Me.ShowIcon = False
		Me.Text = "Cálculo por mínimos cuadrados"
		Me.TopMost = True
		Me.DarkSectionPanel3.ResumeLayout(False)
		Me.DarkSectionPanel3.PerformLayout()
		Me.DarkSectionPanel1.ResumeLayout(False)
		Me.DarkSectionPanel1.PerformLayout()
		CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)

	End Sub
	Friend WithEvents DarkSectionPanel3 As DarkUI.Controls.DarkSectionPanel
	Friend WithEvents DarkLabel13 As DarkUI.Controls.DarkLabel
	Friend WithEvents Txt_Tp As DarkUI.Controls.DarkTextBox
	Friend WithEvents DarkLabel14 As DarkUI.Controls.DarkLabel
	Friend WithEvents Txt_To As DarkUI.Controls.DarkTextBox
	Friend WithEvents DarkLabel15 As DarkUI.Controls.DarkLabel
	Friend WithEvents Txt_K As DarkUI.Controls.DarkTextBox
	Friend WithEvents Btn_calcular As DarkUI.Controls.DarkButton
	Friend WithEvents DarkSectionPanel1 As DarkUI.Controls.DarkSectionPanel
	Friend WithEvents DarkLabel1 As DarkUI.Controls.DarkLabel
	Friend WithEvents Cbo_OP As DarkUI.Controls.DarkComboBox
	Friend WithEvents DarkLabel16 As DarkUI.Controls.DarkLabel
	Friend WithEvents Cbo_PV As DarkUI.Controls.DarkComboBox
	Friend WithEvents Txt_Tfin As DarkUI.Controls.DarkTextBox
	Friend WithEvents DarkLabel5 As DarkUI.Controls.DarkLabel
	Friend WithEvents DarkLabel6 As DarkUI.Controls.DarkLabel
	Friend WithEvents Txt_Tini As DarkUI.Controls.DarkTextBox
	Friend WithEvents Txt_debug As RichTextBox
	Friend WithEvents Chart1 As DataVisualization.Charting.Chart
	Friend WithEvents Txt_grado As DarkUI.Controls.DarkTextBox
	Friend WithEvents DarkLabel2 As DarkUI.Controls.DarkLabel
End Class
