<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form2
	Inherits System.Windows.Forms.Form

	'Form reemplaza a Dispose para limpiar la lista de componentes.
	<System.Diagnostics.DebuggerNonUserCode()>
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
	<System.Diagnostics.DebuggerStepThrough()>
	Private Sub InitializeComponent()
		Me.components = New System.ComponentModel.Container()
		Me.DarkSectionPanel1 = New DarkUI.Controls.DarkSectionPanel()
		Me.DarkLabel16 = New DarkUI.Controls.DarkLabel()
		Me.Cbo_PV = New DarkUI.Controls.DarkComboBox()
		Me.Txt_Tfin = New DarkUI.Controls.DarkTextBox()
		Me.DarkLabel5 = New DarkUI.Controls.DarkLabel()
		Me.DarkLabel6 = New DarkUI.Controls.DarkLabel()
		Me.Txt_Tini = New DarkUI.Controls.DarkTextBox()
		Me.Txt_OPfinal = New DarkUI.Controls.DarkTextBox()
		Me.DarkLabel3 = New DarkUI.Controls.DarkLabel()
		Me.DarkLabel4 = New DarkUI.Controls.DarkLabel()
		Me.Txt_OPini = New DarkUI.Controls.DarkTextBox()
		Me.Txt_PVfin = New DarkUI.Controls.DarkTextBox()
		Me.DarkLabel2 = New DarkUI.Controls.DarkLabel()
		Me.DarkLabel1 = New DarkUI.Controls.DarkLabel()
		Me.Txt_pvini = New DarkUI.Controls.DarkTextBox()
		Me.DarkSectionPanel2 = New DarkUI.Controls.DarkSectionPanel()
		Me.DarkLabel18 = New DarkUI.Controls.DarkLabel()
		Me.Txt_rangominOP = New DarkUI.Controls.DarkTextBox()
		Me.Txt_rangomaxOP = New DarkUI.Controls.DarkTextBox()
		Me.DarkLabel17 = New DarkUI.Controls.DarkLabel()
		Me.Txt_rangominPV = New DarkUI.Controls.DarkTextBox()
		Me.DarkLabel7 = New DarkUI.Controls.DarkLabel()
		Me.DarkLabel8 = New DarkUI.Controls.DarkLabel()
		Me.Txt_rangomaxPV = New DarkUI.Controls.DarkTextBox()
		Me.DarkSectionPanel3 = New DarkUI.Controls.DarkSectionPanel()
		Me.Btn_calcular = New DarkUI.Controls.DarkButton()
		Me.DarkLabel13 = New DarkUI.Controls.DarkLabel()
		Me.Txt_Tp = New DarkUI.Controls.DarkTextBox()
		Me.DarkLabel14 = New DarkUI.Controls.DarkLabel()
		Me.Txt_To = New DarkUI.Controls.DarkTextBox()
		Me.DarkLabel15 = New DarkUI.Controls.DarkLabel()
		Me.Txt_K = New DarkUI.Controls.DarkTextBox()
		Me.DarkLabel12 = New DarkUI.Controls.DarkLabel()
		Me.Txt_T2 = New DarkUI.Controls.DarkTextBox()
		Me.DarkLabel11 = New DarkUI.Controls.DarkLabel()
		Me.Txt_T1 = New DarkUI.Controls.DarkTextBox()
		Me.DarkLabel10 = New DarkUI.Controls.DarkLabel()
		Me.Txt_dOP = New DarkUI.Controls.DarkTextBox()
		Me.DarkLabel9 = New DarkUI.Controls.DarkLabel()
		Me.Txt_dPV = New DarkUI.Controls.DarkTextBox()
		Me.Btn_aceptar = New DarkUI.Controls.DarkButton()
		Me.Txt_debug = New System.Windows.Forms.RichTextBox()
		Me.DarkButton1 = New DarkUI.Controls.DarkButton()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
		Me.Chk_anotaciones = New DarkUI.Controls.DarkCheckBox()
		Me.DarkSectionPanel1.SuspendLayout()
		Me.DarkSectionPanel2.SuspendLayout()
		Me.DarkSectionPanel3.SuspendLayout()
		Me.SuspendLayout()
		'
		'DarkSectionPanel1
		'
		Me.DarkSectionPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.DarkSectionPanel1.Controls.Add(Me.DarkLabel16)
		Me.DarkSectionPanel1.Controls.Add(Me.Cbo_PV)
		Me.DarkSectionPanel1.Controls.Add(Me.Txt_Tfin)
		Me.DarkSectionPanel1.Controls.Add(Me.DarkLabel5)
		Me.DarkSectionPanel1.Controls.Add(Me.DarkLabel6)
		Me.DarkSectionPanel1.Controls.Add(Me.Txt_Tini)
		Me.DarkSectionPanel1.Controls.Add(Me.Txt_OPfinal)
		Me.DarkSectionPanel1.Controls.Add(Me.DarkLabel3)
		Me.DarkSectionPanel1.Controls.Add(Me.DarkLabel4)
		Me.DarkSectionPanel1.Controls.Add(Me.Txt_OPini)
		Me.DarkSectionPanel1.Controls.Add(Me.Txt_PVfin)
		Me.DarkSectionPanel1.Controls.Add(Me.DarkLabel2)
		Me.DarkSectionPanel1.Controls.Add(Me.DarkLabel1)
		Me.DarkSectionPanel1.Controls.Add(Me.Txt_pvini)
		Me.DarkSectionPanel1.Location = New System.Drawing.Point(12, 12)
		Me.DarkSectionPanel1.Name = "DarkSectionPanel1"
		Me.DarkSectionPanel1.SectionHeader = "Datos obtenidos del gráfico"
		Me.DarkSectionPanel1.Size = New System.Drawing.Size(168, 234)
		Me.DarkSectionPanel1.TabIndex = 2
		'
		'DarkLabel16
		'
		Me.DarkLabel16.AutoSize = True
		Me.DarkLabel16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.DarkLabel16.Location = New System.Drawing.Point(32, 92)
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
		Me.Cbo_PV.Location = New System.Drawing.Point(86, 90)
		Me.Cbo_PV.Name = "Cbo_PV"
		Me.Cbo_PV.Size = New System.Drawing.Size(65, 21)
		Me.Cbo_PV.TabIndex = 24
		Me.ToolTip1.SetToolTip(Me.Cbo_PV, "Selecciona la serie que contiene la variable de proceso")
		'
		'Txt_Tfin
		'
		Me.Txt_Tfin.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
		Me.Txt_Tfin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.Txt_Tfin.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.Txt_Tfin.Location = New System.Drawing.Point(86, 195)
		Me.Txt_Tfin.Name = "Txt_Tfin"
		Me.Txt_Tfin.Size = New System.Drawing.Size(65, 20)
		Me.Txt_Tfin.TabIndex = 23
		Me.Txt_Tfin.Text = "242"
		'
		'DarkLabel5
		'
		Me.DarkLabel5.AutoSize = True
		Me.DarkLabel5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.DarkLabel5.Location = New System.Drawing.Point(17, 197)
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
		Me.DarkLabel6.Location = New System.Drawing.Point(10, 171)
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
		Me.Txt_Tini.Location = New System.Drawing.Point(86, 169)
		Me.Txt_Tini.Name = "Txt_Tini"
		Me.Txt_Tini.Size = New System.Drawing.Size(65, 20)
		Me.Txt_Tini.TabIndex = 20
		Me.Txt_Tini.Text = "223"
		'
		'Txt_OPfinal
		'
		Me.Txt_OPfinal.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
		Me.Txt_OPfinal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.Txt_OPfinal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.Txt_OPfinal.Location = New System.Drawing.Point(86, 143)
		Me.Txt_OPfinal.Name = "Txt_OPfinal"
		Me.Txt_OPfinal.Size = New System.Drawing.Size(65, 20)
		Me.Txt_OPfinal.TabIndex = 19
		Me.Txt_OPfinal.Text = "51"
		'
		'DarkLabel3
		'
		Me.DarkLabel3.AutoSize = True
		Me.DarkLabel3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.DarkLabel3.Location = New System.Drawing.Point(37, 145)
		Me.DarkLabel3.Name = "DarkLabel3"
		Me.DarkLabel3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.DarkLabel3.Size = New System.Drawing.Size(44, 13)
		Me.DarkLabel3.TabIndex = 18
		Me.DarkLabel3.Text = "OP final"
		'
		'DarkLabel4
		'
		Me.DarkLabel4.AutoSize = True
		Me.DarkLabel4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.DarkLabel4.Location = New System.Drawing.Point(30, 119)
		Me.DarkLabel4.Name = "DarkLabel4"
		Me.DarkLabel4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.DarkLabel4.Size = New System.Drawing.Size(51, 13)
		Me.DarkLabel4.TabIndex = 17
		Me.DarkLabel4.Text = "OP inicial"
		'
		'Txt_OPini
		'
		Me.Txt_OPini.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
		Me.Txt_OPini.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.Txt_OPini.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.Txt_OPini.Location = New System.Drawing.Point(86, 117)
		Me.Txt_OPini.Name = "Txt_OPini"
		Me.Txt_OPini.Size = New System.Drawing.Size(65, 20)
		Me.Txt_OPini.TabIndex = 16
		Me.Txt_OPini.Text = "37"
		'
		'Txt_PVfin
		'
		Me.Txt_PVfin.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
		Me.Txt_PVfin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.Txt_PVfin.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.Txt_PVfin.Location = New System.Drawing.Point(86, 64)
		Me.Txt_PVfin.Name = "Txt_PVfin"
		Me.Txt_PVfin.Size = New System.Drawing.Size(65, 20)
		Me.Txt_PVfin.TabIndex = 15
		Me.Txt_PVfin.Text = "46,05"
		'
		'DarkLabel2
		'
		Me.DarkLabel2.AutoSize = True
		Me.DarkLabel2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.DarkLabel2.Location = New System.Drawing.Point(37, 66)
		Me.DarkLabel2.Name = "DarkLabel2"
		Me.DarkLabel2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.DarkLabel2.Size = New System.Drawing.Size(43, 13)
		Me.DarkLabel2.TabIndex = 14
		Me.DarkLabel2.Text = "PV final"
		'
		'DarkLabel1
		'
		Me.DarkLabel1.AutoSize = True
		Me.DarkLabel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.DarkLabel1.Location = New System.Drawing.Point(30, 40)
		Me.DarkLabel1.Name = "DarkLabel1"
		Me.DarkLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.DarkLabel1.Size = New System.Drawing.Size(50, 13)
		Me.DarkLabel1.TabIndex = 13
		Me.DarkLabel1.Text = "PV inicial"
		'
		'Txt_pvini
		'
		Me.Txt_pvini.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
		Me.Txt_pvini.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.Txt_pvini.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.Txt_pvini.Location = New System.Drawing.Point(86, 38)
		Me.Txt_pvini.Name = "Txt_pvini"
		Me.Txt_pvini.Size = New System.Drawing.Size(65, 20)
		Me.Txt_pvini.TabIndex = 12
		Me.Txt_pvini.Text = "40,90"
		'
		'DarkSectionPanel2
		'
		Me.DarkSectionPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.DarkSectionPanel2.Controls.Add(Me.DarkLabel18)
		Me.DarkSectionPanel2.Controls.Add(Me.Txt_rangominOP)
		Me.DarkSectionPanel2.Controls.Add(Me.Txt_rangomaxOP)
		Me.DarkSectionPanel2.Controls.Add(Me.DarkLabel17)
		Me.DarkSectionPanel2.Controls.Add(Me.Txt_rangominPV)
		Me.DarkSectionPanel2.Controls.Add(Me.DarkLabel7)
		Me.DarkSectionPanel2.Controls.Add(Me.DarkLabel8)
		Me.DarkSectionPanel2.Controls.Add(Me.Txt_rangomaxPV)
		Me.DarkSectionPanel2.Location = New System.Drawing.Point(12, 252)
		Me.DarkSectionPanel2.Name = "DarkSectionPanel2"
		Me.DarkSectionPanel2.SectionHeader = "Rango PV y OP"
		Me.DarkSectionPanel2.Size = New System.Drawing.Size(168, 100)
		Me.DarkSectionPanel2.TabIndex = 3
		'
		'DarkLabel18
		'
		Me.DarkLabel18.AutoSize = True
		Me.DarkLabel18.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.DarkLabel18.Location = New System.Drawing.Point(109, 30)
		Me.DarkLabel18.Name = "DarkLabel18"
		Me.DarkLabel18.Size = New System.Drawing.Size(22, 13)
		Me.DarkLabel18.TabIndex = 19
		Me.DarkLabel18.Text = "OP"
		'
		'Txt_rangominOP
		'
		Me.Txt_rangominOP.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
		Me.Txt_rangominOP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.Txt_rangominOP.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.Txt_rangominOP.Location = New System.Drawing.Point(101, 72)
		Me.Txt_rangominOP.Name = "Txt_rangominOP"
		Me.Txt_rangominOP.Size = New System.Drawing.Size(38, 20)
		Me.Txt_rangominOP.TabIndex = 18
		Me.Txt_rangominOP.Text = "0"
		'
		'Txt_rangomaxOP
		'
		Me.Txt_rangomaxOP.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
		Me.Txt_rangomaxOP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.Txt_rangomaxOP.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.Txt_rangomaxOP.Location = New System.Drawing.Point(101, 46)
		Me.Txt_rangomaxOP.Name = "Txt_rangomaxOP"
		Me.Txt_rangomaxOP.Size = New System.Drawing.Size(38, 20)
		Me.Txt_rangomaxOP.TabIndex = 17
		Me.Txt_rangomaxOP.Text = "255"
		'
		'DarkLabel17
		'
		Me.DarkLabel17.AutoSize = True
		Me.DarkLabel17.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.DarkLabel17.Location = New System.Drawing.Point(65, 30)
		Me.DarkLabel17.Name = "DarkLabel17"
		Me.DarkLabel17.Size = New System.Drawing.Size(21, 13)
		Me.DarkLabel17.TabIndex = 16
		Me.DarkLabel17.Text = "PV"
		'
		'Txt_rangominPV
		'
		Me.Txt_rangominPV.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
		Me.Txt_rangominPV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.Txt_rangominPV.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.Txt_rangominPV.Location = New System.Drawing.Point(57, 72)
		Me.Txt_rangominPV.Name = "Txt_rangominPV"
		Me.Txt_rangominPV.Size = New System.Drawing.Size(38, 20)
		Me.Txt_rangominPV.TabIndex = 15
		Me.Txt_rangominPV.Text = "-40"
		'
		'DarkLabel7
		'
		Me.DarkLabel7.AutoSize = True
		Me.DarkLabel7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.DarkLabel7.Location = New System.Drawing.Point(30, 74)
		Me.DarkLabel7.Name = "DarkLabel7"
		Me.DarkLabel7.Size = New System.Drawing.Size(24, 13)
		Me.DarkLabel7.TabIndex = 14
		Me.DarkLabel7.Text = "Min"
		'
		'DarkLabel8
		'
		Me.DarkLabel8.AutoSize = True
		Me.DarkLabel8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.DarkLabel8.Location = New System.Drawing.Point(28, 48)
		Me.DarkLabel8.Name = "DarkLabel8"
		Me.DarkLabel8.Size = New System.Drawing.Size(27, 13)
		Me.DarkLabel8.TabIndex = 13
		Me.DarkLabel8.Text = "Max"
		'
		'Txt_rangomaxPV
		'
		Me.Txt_rangomaxPV.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
		Me.Txt_rangomaxPV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.Txt_rangomaxPV.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.Txt_rangomaxPV.Location = New System.Drawing.Point(57, 46)
		Me.Txt_rangomaxPV.Name = "Txt_rangomaxPV"
		Me.Txt_rangomaxPV.Size = New System.Drawing.Size(38, 20)
		Me.Txt_rangomaxPV.TabIndex = 12
		Me.Txt_rangomaxPV.Text = "150"
		'
		'DarkSectionPanel3
		'
		Me.DarkSectionPanel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.DarkSectionPanel3.Controls.Add(Me.Btn_calcular)
		Me.DarkSectionPanel3.Controls.Add(Me.DarkLabel13)
		Me.DarkSectionPanel3.Controls.Add(Me.Txt_Tp)
		Me.DarkSectionPanel3.Controls.Add(Me.DarkLabel14)
		Me.DarkSectionPanel3.Controls.Add(Me.Txt_To)
		Me.DarkSectionPanel3.Controls.Add(Me.DarkLabel15)
		Me.DarkSectionPanel3.Controls.Add(Me.Txt_K)
		Me.DarkSectionPanel3.Controls.Add(Me.DarkLabel12)
		Me.DarkSectionPanel3.Controls.Add(Me.Txt_T2)
		Me.DarkSectionPanel3.Controls.Add(Me.DarkLabel11)
		Me.DarkSectionPanel3.Controls.Add(Me.Txt_T1)
		Me.DarkSectionPanel3.Controls.Add(Me.DarkLabel10)
		Me.DarkSectionPanel3.Controls.Add(Me.Txt_dOP)
		Me.DarkSectionPanel3.Controls.Add(Me.DarkLabel9)
		Me.DarkSectionPanel3.Controls.Add(Me.Txt_dPV)
		Me.DarkSectionPanel3.Location = New System.Drawing.Point(205, 12)
		Me.DarkSectionPanel3.Name = "DarkSectionPanel3"
		Me.DarkSectionPanel3.SectionHeader = "Datos calculados"
		Me.DarkSectionPanel3.Size = New System.Drawing.Size(155, 293)
		Me.DarkSectionPanel3.TabIndex = 4
		'
		'Btn_calcular
		'
		Me.Btn_calcular.Image = Global.Arduino_COM_Plotter.My.Resources.Resources.Calculator
		Me.Btn_calcular.Location = New System.Drawing.Point(19, 231)
		Me.Btn_calcular.Name = "Btn_calcular"
		Me.Btn_calcular.Padding = New System.Windows.Forms.Padding(5)
		Me.Btn_calcular.Size = New System.Drawing.Size(121, 44)
		Me.Btn_calcular.TabIndex = 28
		Me.Btn_calcular.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
		Me.ToolTip1.SetToolTip(Me.Btn_calcular, "Calcula variables de sistema")
		'
		'DarkLabel13
		'
		Me.DarkLabel13.AutoSize = True
		Me.DarkLabel13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.DarkLabel13.ForeColor = System.Drawing.Color.Lime
		Me.DarkLabel13.Location = New System.Drawing.Point(30, 196)
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
		Me.Txt_Tp.Location = New System.Drawing.Point(72, 194)
		Me.Txt_Tp.Name = "Txt_Tp"
		Me.Txt_Tp.ReadOnly = True
		Me.Txt_Tp.Size = New System.Drawing.Size(65, 20)
		Me.Txt_Tp.TabIndex = 26
		'
		'DarkLabel14
		'
		Me.DarkLabel14.AutoSize = True
		Me.DarkLabel14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.DarkLabel14.ForeColor = System.Drawing.Color.Lime
		Me.DarkLabel14.Location = New System.Drawing.Point(30, 170)
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
		Me.Txt_To.Location = New System.Drawing.Point(72, 168)
		Me.Txt_To.Name = "Txt_To"
		Me.Txt_To.ReadOnly = True
		Me.Txt_To.Size = New System.Drawing.Size(65, 20)
		Me.Txt_To.TabIndex = 24
		'
		'DarkLabel15
		'
		Me.DarkLabel15.AutoSize = True
		Me.DarkLabel15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.DarkLabel15.ForeColor = System.Drawing.Color.Lime
		Me.DarkLabel15.Location = New System.Drawing.Point(19, 144)
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
		Me.Txt_K.Location = New System.Drawing.Point(72, 142)
		Me.Txt_K.Name = "Txt_K"
		Me.Txt_K.ReadOnly = True
		Me.Txt_K.Size = New System.Drawing.Size(65, 20)
		Me.Txt_K.TabIndex = 22
		'
		'DarkLabel12
		'
		Me.DarkLabel12.AutoSize = True
		Me.DarkLabel12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.DarkLabel12.Location = New System.Drawing.Point(8, 118)
		Me.DarkLabel12.Name = "DarkLabel12"
		Me.DarkLabel12.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.DarkLabel12.Size = New System.Drawing.Size(58, 13)
		Me.DarkLabel12.TabIndex = 21
		Me.DarkLabel12.Text = "T2 (63,2%)"
		'
		'Txt_T2
		'
		Me.Txt_T2.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
		Me.Txt_T2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.Txt_T2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.Txt_T2.Location = New System.Drawing.Point(72, 116)
		Me.Txt_T2.Name = "Txt_T2"
		Me.Txt_T2.Size = New System.Drawing.Size(65, 20)
		Me.Txt_T2.TabIndex = 20
		'
		'DarkLabel11
		'
		Me.DarkLabel11.AutoSize = True
		Me.DarkLabel11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.DarkLabel11.Location = New System.Drawing.Point(8, 92)
		Me.DarkLabel11.Name = "DarkLabel11"
		Me.DarkLabel11.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.DarkLabel11.Size = New System.Drawing.Size(58, 13)
		Me.DarkLabel11.TabIndex = 19
		Me.DarkLabel11.Text = "T1 (28,3%)"
		'
		'Txt_T1
		'
		Me.Txt_T1.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
		Me.Txt_T1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.Txt_T1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.Txt_T1.Location = New System.Drawing.Point(72, 90)
		Me.Txt_T1.Name = "Txt_T1"
		Me.Txt_T1.Size = New System.Drawing.Size(65, 20)
		Me.Txt_T1.TabIndex = 18
		'
		'DarkLabel10
		'
		Me.DarkLabel10.AutoSize = True
		Me.DarkLabel10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.DarkLabel10.Location = New System.Drawing.Point(16, 66)
		Me.DarkLabel10.Name = "DarkLabel10"
		Me.DarkLabel10.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.DarkLabel10.Size = New System.Drawing.Size(50, 13)
		Me.DarkLabel10.TabIndex = 17
		Me.DarkLabel10.Text = "Delta OP"
		'
		'Txt_dOP
		'
		Me.Txt_dOP.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
		Me.Txt_dOP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.Txt_dOP.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.Txt_dOP.Location = New System.Drawing.Point(72, 64)
		Me.Txt_dOP.Name = "Txt_dOP"
		Me.Txt_dOP.ReadOnly = True
		Me.Txt_dOP.Size = New System.Drawing.Size(65, 20)
		Me.Txt_dOP.TabIndex = 16
		'
		'DarkLabel9
		'
		Me.DarkLabel9.AutoSize = True
		Me.DarkLabel9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.DarkLabel9.Location = New System.Drawing.Point(16, 40)
		Me.DarkLabel9.Name = "DarkLabel9"
		Me.DarkLabel9.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.DarkLabel9.Size = New System.Drawing.Size(49, 13)
		Me.DarkLabel9.TabIndex = 15
		Me.DarkLabel9.Text = "Delta PV"
		'
		'Txt_dPV
		'
		Me.Txt_dPV.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
		Me.Txt_dPV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.Txt_dPV.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.Txt_dPV.Location = New System.Drawing.Point(72, 38)
		Me.Txt_dPV.Name = "Txt_dPV"
		Me.Txt_dPV.ReadOnly = True
		Me.Txt_dPV.Size = New System.Drawing.Size(65, 20)
		Me.Txt_dPV.TabIndex = 14
		'
		'Btn_aceptar
		'
		Me.Btn_aceptar.Location = New System.Drawing.Point(205, 314)
		Me.Btn_aceptar.Name = "Btn_aceptar"
		Me.Btn_aceptar.Padding = New System.Windows.Forms.Padding(5)
		Me.Btn_aceptar.Size = New System.Drawing.Size(155, 38)
		Me.Btn_aceptar.TabIndex = 5
		Me.Btn_aceptar.Text = "Aceptar"
		Me.ToolTip1.SetToolTip(Me.Btn_aceptar, "Pasa las variables del sistema al formulario principal")
		'
		'Txt_debug
		'
		Me.Txt_debug.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
		Me.Txt_debug.ForeColor = System.Drawing.Color.Gainsboro
		Me.Txt_debug.Location = New System.Drawing.Point(411, 12)
		Me.Txt_debug.Name = "Txt_debug"
		Me.Txt_debug.Size = New System.Drawing.Size(479, 270)
		Me.Txt_debug.TabIndex = 6
		Me.Txt_debug.Text = ""
		'
		'DarkButton1
		'
		Me.DarkButton1.Location = New System.Drawing.Point(366, 131)
		Me.DarkButton1.Name = "DarkButton1"
		Me.DarkButton1.Padding = New System.Windows.Forms.Padding(5)
		Me.DarkButton1.Size = New System.Drawing.Size(27, 74)
		Me.DarkButton1.TabIndex = 7
		Me.DarkButton1.Text = ">>"
		Me.ToolTip1.SetToolTip(Me.DarkButton1, "Muestra detalles de cálculo")
		'
		'Chk_anotaciones
		'
		Me.Chk_anotaciones.Checked = True
		Me.Chk_anotaciones.CheckState = System.Windows.Forms.CheckState.Checked
		Me.Chk_anotaciones.Location = New System.Drawing.Point(411, 288)
		Me.Chk_anotaciones.Name = "Chk_anotaciones"
		Me.Chk_anotaciones.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Chk_anotaciones.Size = New System.Drawing.Size(230, 17)
		Me.Chk_anotaciones.TabIndex = 8
		Me.Chk_anotaciones.Text = "Mostrar anotaciones T1 y T2 en gráfico"
		'
		'Form2
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
		Me.ClientSize = New System.Drawing.Size(399, 364)
		Me.Controls.Add(Me.Chk_anotaciones)
		Me.Controls.Add(Me.DarkButton1)
		Me.Controls.Add(Me.Txt_debug)
		Me.Controls.Add(Me.Btn_aceptar)
		Me.Controls.Add(Me.DarkSectionPanel3)
		Me.Controls.Add(Me.DarkSectionPanel2)
		Me.Controls.Add(Me.DarkSectionPanel1)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
		Me.Name = "Form2"
		Me.Text = "Cálculo de K, T0 y Tp"
		Me.TopMost = True
		Me.DarkSectionPanel1.ResumeLayout(False)
		Me.DarkSectionPanel1.PerformLayout()
		Me.DarkSectionPanel2.ResumeLayout(False)
		Me.DarkSectionPanel2.PerformLayout()
		Me.DarkSectionPanel3.ResumeLayout(False)
		Me.DarkSectionPanel3.PerformLayout()
		Me.ResumeLayout(False)

	End Sub
	Friend WithEvents DarkSectionPanel1 As DarkUI.Controls.DarkSectionPanel
	Friend WithEvents Txt_Tfin As DarkUI.Controls.DarkTextBox
	Friend WithEvents DarkLabel5 As DarkUI.Controls.DarkLabel
	Friend WithEvents DarkLabel6 As DarkUI.Controls.DarkLabel
	Friend WithEvents Txt_Tini As DarkUI.Controls.DarkTextBox
	Friend WithEvents Txt_OPfinal As DarkUI.Controls.DarkTextBox
	Friend WithEvents DarkLabel3 As DarkUI.Controls.DarkLabel
	Friend WithEvents DarkLabel4 As DarkUI.Controls.DarkLabel
	Friend WithEvents Txt_OPini As DarkUI.Controls.DarkTextBox
	Friend WithEvents Txt_PVfin As DarkUI.Controls.DarkTextBox
	Friend WithEvents DarkLabel2 As DarkUI.Controls.DarkLabel
	Friend WithEvents DarkLabel1 As DarkUI.Controls.DarkLabel
	Friend WithEvents Txt_pvini As DarkUI.Controls.DarkTextBox
	Friend WithEvents DarkSectionPanel2 As DarkUI.Controls.DarkSectionPanel
	Friend WithEvents Txt_rangominPV As DarkUI.Controls.DarkTextBox
	Friend WithEvents DarkLabel7 As DarkUI.Controls.DarkLabel
	Friend WithEvents DarkLabel8 As DarkUI.Controls.DarkLabel
	Friend WithEvents Txt_rangomaxPV As DarkUI.Controls.DarkTextBox
	Friend WithEvents DarkSectionPanel3 As DarkUI.Controls.DarkSectionPanel
	Friend WithEvents DarkLabel12 As DarkUI.Controls.DarkLabel
	Friend WithEvents Txt_T2 As DarkUI.Controls.DarkTextBox
	Friend WithEvents DarkLabel11 As DarkUI.Controls.DarkLabel
	Friend WithEvents Txt_T1 As DarkUI.Controls.DarkTextBox
	Friend WithEvents DarkLabel10 As DarkUI.Controls.DarkLabel
	Friend WithEvents Txt_dOP As DarkUI.Controls.DarkTextBox
	Friend WithEvents DarkLabel9 As DarkUI.Controls.DarkLabel
	Friend WithEvents Txt_dPV As DarkUI.Controls.DarkTextBox
	Friend WithEvents Btn_aceptar As DarkUI.Controls.DarkButton
	Friend WithEvents Btn_calcular As DarkUI.Controls.DarkButton
	Friend WithEvents DarkLabel13 As DarkUI.Controls.DarkLabel
	Friend WithEvents Txt_Tp As DarkUI.Controls.DarkTextBox
	Friend WithEvents DarkLabel14 As DarkUI.Controls.DarkLabel
	Friend WithEvents Txt_To As DarkUI.Controls.DarkTextBox
	Friend WithEvents DarkLabel15 As DarkUI.Controls.DarkLabel
	Friend WithEvents Txt_K As DarkUI.Controls.DarkTextBox
	Friend WithEvents DarkLabel16 As DarkUI.Controls.DarkLabel
	Friend WithEvents Cbo_PV As DarkUI.Controls.DarkComboBox
	Friend WithEvents Txt_debug As RichTextBox
	Friend WithEvents DarkButton1 As DarkUI.Controls.DarkButton
	Friend WithEvents ToolTip1 As ToolTip
	Friend WithEvents Chk_anotaciones As DarkUI.Controls.DarkCheckBox
	Friend WithEvents DarkLabel18 As DarkUI.Controls.DarkLabel
	Friend WithEvents Txt_rangominOP As DarkUI.Controls.DarkTextBox
	Friend WithEvents Txt_rangomaxOP As DarkUI.Controls.DarkTextBox
	Friend WithEvents DarkLabel17 As DarkUI.Controls.DarkLabel
End Class
