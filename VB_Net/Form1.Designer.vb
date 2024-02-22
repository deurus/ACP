<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
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
		Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
		Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
		Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
		Dim ChartArea3 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
		Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
		Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
		Me.DarkSectionPanel7 = New DarkUI.Controls.DarkSectionPanel()
		Me.DarkGroupBox1 = New DarkUI.Controls.DarkGroupBox()
		Me.Cmd_enviar = New DarkUI.Controls.DarkButton()
		Me.Txt_enviar = New DarkUI.Controls.DarkTextBox()
		Me.txt_inicio = New DarkUI.Controls.DarkTextBox()
		Me.txt_separador = New DarkUI.Controls.DarkTextBox()
		Me.num_ventana = New DarkUI.Controls.DarkNumericUpDown()
		Me.Num_vars = New DarkUI.Controls.DarkNumericUpDown()
		Me.Num_delay = New DarkUI.Controls.DarkNumericUpDown()
		Me.Label7 = New System.Windows.Forms.Label()
		Me.lbl_inicio = New System.Windows.Forms.Label()
		Me.Label6 = New System.Windows.Forms.Label()
		Me.lbl_separador = New System.Windows.Forms.Label()
		Me.Label5 = New System.Windows.Forms.Label()
		Me.Label4 = New System.Windows.Forms.Label()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.DarkGroupBox2 = New DarkUI.Controls.DarkGroupBox()
		Me.Cbo_velocidad_2 = New DarkUI.Controls.DarkComboBox()
		Me.Cbo_comports = New DarkUI.Controls.DarkComboBox()
		Me.Btn_desconectarDark = New DarkUI.Controls.DarkButton()
		Me.Btn_conectarDark = New DarkUI.Controls.DarkButton()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.DarkStatusStrip1 = New DarkUI.Controls.DarkStatusStrip()
		Me.Lbl_lineas = New System.Windows.Forms.ToolStripStatusLabel()
		Me.SplitContainer3 = New System.Windows.Forms.SplitContainer()
		Me.DarkSectionPanel4 = New DarkUI.Controls.DarkSectionPanel()
		Me.SplitContainer4 = New System.Windows.Forms.SplitContainer()
		Me.DarkSectionPanel5 = New DarkUI.Controls.DarkSectionPanel()
		Me.Txt_datos = New System.Windows.Forms.RichTextBox()
		Me.DarkSectionPanel6 = New DarkUI.Controls.DarkSectionPanel()
		Me.dgv_vars = New System.Windows.Forms.DataGridView()
		Me.DarkSectionPanel1 = New DarkUI.Controls.DarkSectionPanel()
		Me.SplitContainer5 = New System.Windows.Forms.SplitContainer()
		Me.DarkSectionPanel2 = New DarkUI.Controls.DarkSectionPanel()
		Me.Btn_calc_sismin = New DarkUI.Controls.DarkButton()
		Me.Btn_sintonias = New DarkUI.Controls.DarkButton()
		Me.DarkLabel4 = New DarkUI.Controls.DarkLabel()
		Me.Btn_calc_sis = New DarkUI.Controls.DarkButton()
		Me.Tv_metodos = New DarkUI.Controls.DarkTreeView()
		Me.DarkGroupBox5 = New DarkUI.Controls.DarkGroupBox()
		Me.DarkLabel3 = New DarkUI.Controls.DarkLabel()
		Me.DarkLabel2 = New DarkUI.Controls.DarkLabel()
		Me.DarkLabel1 = New DarkUI.Controls.DarkLabel()
		Me.Txt_Tp = New DarkUI.Controls.DarkTextBox()
		Me.Txt_To = New DarkUI.Controls.DarkTextBox()
		Me.Txt_K = New DarkUI.Controls.DarkTextBox()
		Me.Txt_Tf = New DarkUI.Controls.DarkTextBox()
		Me.DarkSectionPanel3 = New DarkUI.Controls.DarkSectionPanel()
		Me.Btn_simular2 = New DarkUI.Controls.DarkButton()
		Me.DarkGroupBox4 = New DarkUI.Controls.DarkGroupBox()
		Me.DarkLabel18 = New DarkUI.Controls.DarkLabel()
		Me.DarkLabel12 = New DarkUI.Controls.DarkLabel()
		Me.DarkLabel17 = New DarkUI.Controls.DarkLabel()
		Me.DarkLabel16 = New DarkUI.Controls.DarkLabel()
		Me.DarkLabel15 = New DarkUI.Controls.DarkLabel()
		Me.DarkLabel14 = New DarkUI.Controls.DarkLabel()
		Me.DarkLabel13 = New DarkUI.Controls.DarkLabel()
		Me.DarkLabel11 = New DarkUI.Controls.DarkLabel()
		Me.DarkLabel10 = New DarkUI.Controls.DarkLabel()
		Me.Txt_OPLimInf = New DarkUI.Controls.DarkTextBox()
		Me.Txt_OPLimSup = New DarkUI.Controls.DarkTextBox()
		Me.Txt_Dcarga = New DarkUI.Controls.DarkTextBox()
		Me.Txt_DSP = New DarkUI.Controls.DarkTextBox()
		Me.Txt_CargaIni = New DarkUI.Controls.DarkTextBox()
		Me.Txt_OPini = New DarkUI.Controls.DarkTextBox()
		Me.Txt_PVini = New DarkUI.Controls.DarkTextBox()
		Me.Txt_Tfinal = New DarkUI.Controls.DarkTextBox()
		Me.Txt_muestreo = New DarkUI.Controls.DarkTextBox()
		Me.DarkGroupBox3 = New DarkUI.Controls.DarkGroupBox()
		Me.DarkLabel20 = New DarkUI.Controls.DarkLabel()
		Me.DarkLabel19 = New DarkUI.Controls.DarkLabel()
		Me.Txt_Kd = New DarkUI.Controls.DarkTextBox()
		Me.Txt_Ki = New DarkUI.Controls.DarkTextBox()
		Me.Cbo_eq = New DarkUI.Controls.DarkComboBox()
		Me.DarkLabel7 = New DarkUI.Controls.DarkLabel()
		Me.DarkLabel8 = New DarkUI.Controls.DarkLabel()
		Me.DarkLabel9 = New DarkUI.Controls.DarkLabel()
		Me.DarkLabel6 = New DarkUI.Controls.DarkLabel()
		Me.DarkLabel5 = New DarkUI.Controls.DarkLabel()
		Me.Txt_Td = New DarkUI.Controls.DarkTextBox()
		Me.Txt_Ti = New DarkUI.Controls.DarkTextBox()
		Me.Txt_Kc = New DarkUI.Controls.DarkTextBox()
		Me.Txt_PVrngInf = New DarkUI.Controls.DarkTextBox()
		Me.Txt_PVrngSup = New DarkUI.Controls.DarkTextBox()
		Me.SplitContainer6 = New System.Windows.Forms.SplitContainer()
		Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
		Me.DarkToolStrip2 = New DarkUI.Controls.DarkToolStrip()
		Me.Btn_ampliarTiempo = New System.Windows.Forms.ToolStripButton()
		Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
		Me.btn_captura = New System.Windows.Forms.ToolStripButton()
		Me.txtdebug = New System.Windows.Forms.RichTextBox()
		Me.Chart_simula = New System.Windows.Forms.DataVisualization.Charting.Chart()
		Me.DarkToolStrip3 = New DarkUI.Controls.DarkToolStrip()
		Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel()
		Me.Cbo_metodos_sim = New System.Windows.Forms.ToolStripComboBox()
		Me.Btn_ampliarTiempo_simula = New System.Windows.Forms.ToolStripButton()
		Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
		Me.Btn_captura_simula = New System.Windows.Forms.ToolStripButton()
		Me.DarkStatusStrip2 = New DarkUI.Controls.DarkStatusStrip()
		Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
		Me.Lbl_info = New System.Windows.Forms.ToolStripStatusLabel()
		Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
		Me.DarkToolStrip1 = New DarkUI.Controls.DarkToolStrip()
		Me.ToolStripLabel5 = New System.Windows.Forms.ToolStripLabel()
		Me.btn_abrir = New System.Windows.Forms.ToolStripButton()
		Me.Btn_reset = New System.Windows.Forms.ToolStripButton()
		Me.ToolStripLabel6 = New System.Windows.Forms.ToolStripLabel()
		Me.Btn_guardarP = New System.Windows.Forms.ToolStripButton()
		Me.Btn_exportarP = New System.Windows.Forms.ToolStripButton()
		Me.DarkMenuStrip1 = New DarkUI.Controls.DarkMenuStrip()
		Me.ArchivoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.VerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.ConfiguraciónDelPuertoYLosDatosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.DatosLogVarToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
		Me.PIDDatosDeSimulaciónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.DatosSimulaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.GráficoDeSimulaciónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
		Me.AyudaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
		Me.AcercaDeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.GarikoitzinfoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
		Me.Cbo_SincEjes = New System.Windows.Forms.ToolStripComboBox()
		CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SplitContainer1.Panel1.SuspendLayout()
		Me.SplitContainer1.Panel2.SuspendLayout()
		Me.SplitContainer1.SuspendLayout()
		CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SplitContainer2.Panel1.SuspendLayout()
		Me.SplitContainer2.Panel2.SuspendLayout()
		Me.SplitContainer2.SuspendLayout()
		Me.DarkSectionPanel7.SuspendLayout()
		Me.DarkGroupBox1.SuspendLayout()
		CType(Me.num_ventana, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.Num_vars, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.Num_delay, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.DarkGroupBox2.SuspendLayout()
		Me.DarkStatusStrip1.SuspendLayout()
		CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SplitContainer3.Panel1.SuspendLayout()
		Me.SplitContainer3.Panel2.SuspendLayout()
		Me.SplitContainer3.SuspendLayout()
		Me.DarkSectionPanel4.SuspendLayout()
		CType(Me.SplitContainer4, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SplitContainer4.Panel1.SuspendLayout()
		Me.SplitContainer4.Panel2.SuspendLayout()
		Me.SplitContainer4.SuspendLayout()
		Me.DarkSectionPanel5.SuspendLayout()
		Me.DarkSectionPanel6.SuspendLayout()
		CType(Me.dgv_vars, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.DarkSectionPanel1.SuspendLayout()
		CType(Me.SplitContainer5, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SplitContainer5.Panel1.SuspendLayout()
		Me.SplitContainer5.Panel2.SuspendLayout()
		Me.SplitContainer5.SuspendLayout()
		Me.DarkSectionPanel2.SuspendLayout()
		Me.DarkGroupBox5.SuspendLayout()
		Me.DarkSectionPanel3.SuspendLayout()
		Me.DarkGroupBox4.SuspendLayout()
		Me.DarkGroupBox3.SuspendLayout()
		CType(Me.SplitContainer6, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SplitContainer6.Panel1.SuspendLayout()
		Me.SplitContainer6.Panel2.SuspendLayout()
		Me.SplitContainer6.SuspendLayout()
		CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.DarkToolStrip2.SuspendLayout()
		CType(Me.Chart_simula, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.DarkToolStrip3.SuspendLayout()
		Me.DarkStatusStrip2.SuspendLayout()
		Me.DarkToolStrip1.SuspendLayout()
		Me.DarkMenuStrip1.SuspendLayout()
		Me.SuspendLayout()
		'
		'SplitContainer1
		'
		Me.SplitContainer1.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
		Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
		Me.SplitContainer1.IsSplitterFixed = True
		Me.SplitContainer1.Location = New System.Drawing.Point(0, 57)
		Me.SplitContainer1.Name = "SplitContainer1"
		'
		'SplitContainer1.Panel1
		'
		Me.SplitContainer1.Panel1.Controls.Add(Me.SplitContainer2)
		Me.SplitContainer1.Panel1MinSize = 365
		'
		'SplitContainer1.Panel2
		'
		Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer6)
		Me.SplitContainer1.Panel2.Controls.Add(Me.DarkStatusStrip2)
		Me.SplitContainer1.Size = New System.Drawing.Size(1008, 686)
		Me.SplitContainer1.SplitterDistance = 365
		Me.SplitContainer1.TabIndex = 0
		'
		'SplitContainer2
		'
		Me.SplitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
		Me.SplitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
		Me.SplitContainer2.IsSplitterFixed = True
		Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
		Me.SplitContainer2.Name = "SplitContainer2"
		Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
		'
		'SplitContainer2.Panel1
		'
		Me.SplitContainer2.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
		Me.SplitContainer2.Panel1.Controls.Add(Me.DarkSectionPanel7)
		Me.SplitContainer2.Panel1MinSize = 225
		'
		'SplitContainer2.Panel2
		'
		Me.SplitContainer2.Panel2.Controls.Add(Me.DarkStatusStrip1)
		Me.SplitContainer2.Panel2.Controls.Add(Me.SplitContainer3)
		Me.SplitContainer2.Size = New System.Drawing.Size(365, 686)
		Me.SplitContainer2.SplitterDistance = 225
		Me.SplitContainer2.TabIndex = 0
		'
		'DarkSectionPanel7
		'
		Me.DarkSectionPanel7.Controls.Add(Me.DarkGroupBox1)
		Me.DarkSectionPanel7.Controls.Add(Me.DarkGroupBox2)
		Me.DarkSectionPanel7.Dock = System.Windows.Forms.DockStyle.Fill
		Me.DarkSectionPanel7.Location = New System.Drawing.Point(0, 0)
		Me.DarkSectionPanel7.Name = "DarkSectionPanel7"
		Me.DarkSectionPanel7.SectionHeader = "Configuración"
		Me.DarkSectionPanel7.Size = New System.Drawing.Size(363, 223)
		Me.DarkSectionPanel7.TabIndex = 0
		'
		'DarkGroupBox1
		'
		Me.DarkGroupBox1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
		Me.DarkGroupBox1.Controls.Add(Me.Cmd_enviar)
		Me.DarkGroupBox1.Controls.Add(Me.Txt_enviar)
		Me.DarkGroupBox1.Controls.Add(Me.txt_inicio)
		Me.DarkGroupBox1.Controls.Add(Me.txt_separador)
		Me.DarkGroupBox1.Controls.Add(Me.num_ventana)
		Me.DarkGroupBox1.Controls.Add(Me.Num_vars)
		Me.DarkGroupBox1.Controls.Add(Me.Num_delay)
		Me.DarkGroupBox1.Controls.Add(Me.Label7)
		Me.DarkGroupBox1.Controls.Add(Me.lbl_inicio)
		Me.DarkGroupBox1.Controls.Add(Me.Label6)
		Me.DarkGroupBox1.Controls.Add(Me.lbl_separador)
		Me.DarkGroupBox1.Controls.Add(Me.Label5)
		Me.DarkGroupBox1.Controls.Add(Me.Label4)
		Me.DarkGroupBox1.Controls.Add(Me.Label3)
		Me.DarkGroupBox1.Location = New System.Drawing.Point(8, 109)
		Me.DarkGroupBox1.Name = "DarkGroupBox1"
		Me.DarkGroupBox1.Size = New System.Drawing.Size(346, 109)
		Me.DarkGroupBox1.TabIndex = 1
		Me.DarkGroupBox1.TabStop = False
		Me.DarkGroupBox1.Text = "Trama de datos"
		'
		'Cmd_enviar
		'
		Me.Cmd_enviar.Location = New System.Drawing.Point(233, 81)
		Me.Cmd_enviar.Name = "Cmd_enviar"
		Me.Cmd_enviar.Padding = New System.Windows.Forms.Padding(5)
		Me.Cmd_enviar.Size = New System.Drawing.Size(102, 23)
		Me.Cmd_enviar.TabIndex = 31
		Me.Cmd_enviar.Text = "Enviar"
		'
		'Txt_enviar
		'
		Me.Txt_enviar.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
		Me.Txt_enviar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.Txt_enviar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.Txt_enviar.Location = New System.Drawing.Point(233, 55)
		Me.Txt_enviar.MaxLength = 64
		Me.Txt_enviar.Name = "Txt_enviar"
		Me.Txt_enviar.Size = New System.Drawing.Size(102, 20)
		Me.Txt_enviar.TabIndex = 30
		'
		'txt_inicio
		'
		Me.txt_inicio.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
		Me.txt_inicio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.txt_inicio.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.txt_inicio.Location = New System.Drawing.Point(73, 79)
		Me.txt_inicio.MaxLength = 1
		Me.txt_inicio.Name = "txt_inicio"
		Me.txt_inicio.Size = New System.Drawing.Size(41, 20)
		Me.txt_inicio.TabIndex = 29
		'
		'txt_separador
		'
		Me.txt_separador.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
		Me.txt_separador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.txt_separador.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.txt_separador.Location = New System.Drawing.Point(73, 53)
		Me.txt_separador.MaxLength = 1
		Me.txt_separador.Name = "txt_separador"
		Me.txt_separador.Size = New System.Drawing.Size(41, 20)
		Me.txt_separador.TabIndex = 28
		'
		'num_ventana
		'
		Me.num_ventana.Increment = New Decimal(New Integer() {60, 0, 0, 0})
		Me.num_ventana.Location = New System.Drawing.Point(283, 24)
		Me.num_ventana.Maximum = New Decimal(New Integer() {18000, 0, 0, 0})
		Me.num_ventana.Minimum = New Decimal(New Integer() {60, 0, 0, 0})
		Me.num_ventana.Name = "num_ventana"
		Me.num_ventana.Size = New System.Drawing.Size(52, 20)
		Me.num_ventana.TabIndex = 27
		Me.num_ventana.Value = New Decimal(New Integer() {60, 0, 0, 0})
		'
		'Num_vars
		'
		Me.Num_vars.Location = New System.Drawing.Point(73, 24)
		Me.Num_vars.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
		Me.Num_vars.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
		Me.Num_vars.Name = "Num_vars"
		Me.Num_vars.Size = New System.Drawing.Size(41, 20)
		Me.Num_vars.TabIndex = 26
		Me.Num_vars.Value = New Decimal(New Integer() {3, 0, 0, 0})
		'
		'Num_delay
		'
		Me.Num_delay.Increment = New Decimal(New Integer() {1000, 0, 0, 0})
		Me.Num_delay.Location = New System.Drawing.Point(166, 24)
		Me.Num_delay.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
		Me.Num_delay.Minimum = New Decimal(New Integer() {100, 0, 0, 0})
		Me.Num_delay.Name = "Num_delay"
		Me.Num_delay.Size = New System.Drawing.Size(52, 20)
		Me.Num_delay.TabIndex = 25
		Me.Num_delay.Value = New Decimal(New Integer() {1000, 0, 0, 0})
		'
		'Label7
		'
		Me.Label7.AutoSize = True
		Me.Label7.ForeColor = System.Drawing.Color.Gainsboro
		Me.Label7.Location = New System.Drawing.Point(230, 28)
		Me.Label7.Name = "Label7"
		Me.Label7.Size = New System.Drawing.Size(47, 13)
		Me.Label7.TabIndex = 23
		Me.Label7.Text = "Ventana"
		Me.ToolTip1.SetToolTip(Me.Label7, "Ventana de Tiempo del gráfico")
		'
		'lbl_inicio
		'
		Me.lbl_inicio.AutoSize = True
		Me.lbl_inicio.ForeColor = System.Drawing.Color.Gainsboro
		Me.lbl_inicio.Location = New System.Drawing.Point(126, 81)
		Me.lbl_inicio.Name = "lbl_inicio"
		Me.lbl_inicio.Size = New System.Drawing.Size(13, 13)
		Me.lbl_inicio.TabIndex = 22
		Me.lbl_inicio.Text = "_"
		'
		'Label6
		'
		Me.Label6.AutoSize = True
		Me.Label6.ForeColor = System.Drawing.Color.Gainsboro
		Me.Label6.Location = New System.Drawing.Point(6, 81)
		Me.Label6.Name = "Label6"
		Me.Label6.Size = New System.Drawing.Size(61, 13)
		Me.Label6.TabIndex = 21
		Me.Label6.Text = "Inicio datos"
		'
		'lbl_separador
		'
		Me.lbl_separador.AutoSize = True
		Me.lbl_separador.ForeColor = System.Drawing.Color.Gainsboro
		Me.lbl_separador.Location = New System.Drawing.Point(126, 55)
		Me.lbl_separador.Name = "lbl_separador"
		Me.lbl_separador.Size = New System.Drawing.Size(13, 13)
		Me.lbl_separador.TabIndex = 19
		Me.lbl_separador.Text = "_"
		'
		'Label5
		'
		Me.Label5.AutoSize = True
		Me.Label5.ForeColor = System.Drawing.Color.Gainsboro
		Me.Label5.Location = New System.Drawing.Point(11, 55)
		Me.Label5.Name = "Label5"
		Me.Label5.Size = New System.Drawing.Size(56, 13)
		Me.Label5.TabIndex = 17
		Me.Label5.Text = "Separador"
		'
		'Label4
		'
		Me.Label4.AutoSize = True
		Me.Label4.ForeColor = System.Drawing.Color.Gainsboro
		Me.Label4.Location = New System.Drawing.Point(17, 28)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(50, 13)
		Me.Label4.TabIndex = 15
		Me.Label4.Text = "Variables"
		'
		'Label3
		'
		Me.Label3.AutoSize = True
		Me.Label3.ForeColor = System.Drawing.Color.Gainsboro
		Me.Label3.Location = New System.Drawing.Point(126, 28)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(34, 13)
		Me.Label3.TabIndex = 13
		Me.Label3.Text = "Delay"
		'
		'DarkGroupBox2
		'
		Me.DarkGroupBox2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
		Me.DarkGroupBox2.Controls.Add(Me.Cbo_velocidad_2)
		Me.DarkGroupBox2.Controls.Add(Me.Cbo_comports)
		Me.DarkGroupBox2.Controls.Add(Me.Btn_desconectarDark)
		Me.DarkGroupBox2.Controls.Add(Me.Btn_conectarDark)
		Me.DarkGroupBox2.Controls.Add(Me.Label2)
		Me.DarkGroupBox2.Controls.Add(Me.Label1)
		Me.DarkGroupBox2.Location = New System.Drawing.Point(8, 28)
		Me.DarkGroupBox2.Name = "DarkGroupBox2"
		Me.DarkGroupBox2.Size = New System.Drawing.Size(346, 75)
		Me.DarkGroupBox2.TabIndex = 2
		Me.DarkGroupBox2.TabStop = False
		Me.DarkGroupBox2.Text = "Puerto"
		'
		'Cbo_velocidad_2
		'
		Me.Cbo_velocidad_2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
		Me.Cbo_velocidad_2.FormattingEnabled = True
		Me.Cbo_velocidad_2.Location = New System.Drawing.Point(83, 47)
		Me.Cbo_velocidad_2.Name = "Cbo_velocidad_2"
		Me.Cbo_velocidad_2.Size = New System.Drawing.Size(75, 21)
		Me.Cbo_velocidad_2.TabIndex = 15
		'
		'Cbo_comports
		'
		Me.Cbo_comports.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
		Me.Cbo_comports.FormattingEnabled = True
		Me.Cbo_comports.Location = New System.Drawing.Point(83, 20)
		Me.Cbo_comports.Name = "Cbo_comports"
		Me.Cbo_comports.Size = New System.Drawing.Size(75, 21)
		Me.Cbo_comports.TabIndex = 14
		'
		'Btn_desconectarDark
		'
		Me.Btn_desconectarDark.Location = New System.Drawing.Point(254, 20)
		Me.Btn_desconectarDark.Name = "Btn_desconectarDark"
		Me.Btn_desconectarDark.Padding = New System.Windows.Forms.Padding(5)
		Me.Btn_desconectarDark.Size = New System.Drawing.Size(84, 47)
		Me.Btn_desconectarDark.TabIndex = 13
		Me.Btn_desconectarDark.Text = "Desconectar"
		'
		'Btn_conectarDark
		'
		Me.Btn_conectarDark.Location = New System.Drawing.Point(164, 20)
		Me.Btn_conectarDark.Name = "Btn_conectarDark"
		Me.Btn_conectarDark.Padding = New System.Windows.Forms.Padding(5)
		Me.Btn_conectarDark.Size = New System.Drawing.Size(84, 47)
		Me.Btn_conectarDark.TabIndex = 12
		Me.Btn_conectarDark.Text = "Conectar"
		'
		'Label2
		'
		Me.Label2.AutoSize = True
		Me.Label2.ForeColor = System.Drawing.Color.Gainsboro
		Me.Label2.Location = New System.Drawing.Point(25, 50)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(54, 13)
		Me.Label2.TabIndex = 11
		Me.Label2.Text = "Velocidad"
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.ForeColor = System.Drawing.Color.Gainsboro
		Me.Label1.Location = New System.Drawing.Point(9, 23)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(70, 13)
		Me.Label1.TabIndex = 10
		Me.Label1.Text = "Puertos COM"
		'
		'DarkStatusStrip1
		'
		Me.DarkStatusStrip1.AutoSize = False
		Me.DarkStatusStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
		Me.DarkStatusStrip1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.DarkStatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Lbl_lineas})
		Me.DarkStatusStrip1.Location = New System.Drawing.Point(0, 429)
		Me.DarkStatusStrip1.Name = "DarkStatusStrip1"
		Me.DarkStatusStrip1.Padding = New System.Windows.Forms.Padding(0, 5, 0, 3)
		Me.DarkStatusStrip1.Size = New System.Drawing.Size(365, 28)
		Me.DarkStatusStrip1.SizingGrip = False
		Me.DarkStatusStrip1.TabIndex = 2
		Me.DarkStatusStrip1.Text = "DarkStatusStrip1"
		'
		'Lbl_lineas
		'
		Me.Lbl_lineas.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
		Me.Lbl_lineas.Name = "Lbl_lineas"
		Me.Lbl_lineas.Size = New System.Drawing.Size(365, 15)
		Me.Lbl_lineas.Spring = True
		Me.Lbl_lineas.Text = "Lbllineas"
		'
		'SplitContainer3
		'
		Me.SplitContainer3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
		Me.SplitContainer3.Location = New System.Drawing.Point(0, 0)
		Me.SplitContainer3.Name = "SplitContainer3"
		Me.SplitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal
		'
		'SplitContainer3.Panel1
		'
		Me.SplitContainer3.Panel1.Controls.Add(Me.DarkSectionPanel4)
		'
		'SplitContainer3.Panel2
		'
		Me.SplitContainer3.Panel2.Controls.Add(Me.DarkSectionPanel1)
		Me.SplitContainer3.Panel2MinSize = 100
		Me.SplitContainer3.Size = New System.Drawing.Size(365, 457)
		Me.SplitContainer3.SplitterDistance = 201
		Me.SplitContainer3.TabIndex = 1
		'
		'DarkSectionPanel4
		'
		Me.DarkSectionPanel4.Controls.Add(Me.SplitContainer4)
		Me.DarkSectionPanel4.Dock = System.Windows.Forms.DockStyle.Fill
		Me.DarkSectionPanel4.Location = New System.Drawing.Point(0, 0)
		Me.DarkSectionPanel4.Name = "DarkSectionPanel4"
		Me.DarkSectionPanel4.SectionHeader = "Datos"
		Me.DarkSectionPanel4.Size = New System.Drawing.Size(363, 199)
		Me.DarkSectionPanel4.TabIndex = 0
		'
		'SplitContainer4
		'
		Me.SplitContainer4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.SplitContainer4.Dock = System.Windows.Forms.DockStyle.Fill
		Me.SplitContainer4.Location = New System.Drawing.Point(1, 25)
		Me.SplitContainer4.Name = "SplitContainer4"
		'
		'SplitContainer4.Panel1
		'
		Me.SplitContainer4.Panel1.Controls.Add(Me.DarkSectionPanel5)
		Me.SplitContainer4.Panel1Collapsed = True
		'
		'SplitContainer4.Panel2
		'
		Me.SplitContainer4.Panel2.Controls.Add(Me.DarkSectionPanel6)
		Me.SplitContainer4.Size = New System.Drawing.Size(361, 173)
		Me.SplitContainer4.SplitterDistance = 85
		Me.SplitContainer4.TabIndex = 0
		'
		'DarkSectionPanel5
		'
		Me.DarkSectionPanel5.Controls.Add(Me.Txt_datos)
		Me.DarkSectionPanel5.Dock = System.Windows.Forms.DockStyle.Fill
		Me.DarkSectionPanel5.Location = New System.Drawing.Point(0, 0)
		Me.DarkSectionPanel5.Name = "DarkSectionPanel5"
		Me.DarkSectionPanel5.SectionHeader = "Log"
		Me.DarkSectionPanel5.Size = New System.Drawing.Size(83, 98)
		Me.DarkSectionPanel5.TabIndex = 0
		'
		'Txt_datos
		'
		Me.Txt_datos.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
		Me.Txt_datos.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Txt_datos.Dock = System.Windows.Forms.DockStyle.Fill
		Me.Txt_datos.ForeColor = System.Drawing.Color.White
		Me.Txt_datos.Location = New System.Drawing.Point(1, 25)
		Me.Txt_datos.Name = "Txt_datos"
		Me.Txt_datos.ReadOnly = True
		Me.Txt_datos.Size = New System.Drawing.Size(81, 72)
		Me.Txt_datos.TabIndex = 0
		Me.Txt_datos.Text = ""
		'
		'DarkSectionPanel6
		'
		Me.DarkSectionPanel6.Controls.Add(Me.dgv_vars)
		Me.DarkSectionPanel6.Dock = System.Windows.Forms.DockStyle.Fill
		Me.DarkSectionPanel6.Location = New System.Drawing.Point(0, 0)
		Me.DarkSectionPanel6.Name = "DarkSectionPanel6"
		Me.DarkSectionPanel6.SectionHeader = "Variables"
		Me.DarkSectionPanel6.Size = New System.Drawing.Size(359, 171)
		Me.DarkSectionPanel6.TabIndex = 0
		'
		'dgv_vars
		'
		Me.dgv_vars.AllowUserToAddRows = False
		Me.dgv_vars.AllowUserToDeleteRows = False
		Me.dgv_vars.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
		Me.dgv_vars.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.dgv_vars.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.dgv_vars.Dock = System.Windows.Forms.DockStyle.Fill
		Me.dgv_vars.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
		Me.dgv_vars.Location = New System.Drawing.Point(1, 25)
		Me.dgv_vars.Name = "dgv_vars"
		Me.dgv_vars.Size = New System.Drawing.Size(357, 145)
		Me.dgv_vars.TabIndex = 0
		'
		'DarkSectionPanel1
		'
		Me.DarkSectionPanel1.Controls.Add(Me.SplitContainer5)
		Me.DarkSectionPanel1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.DarkSectionPanel1.Location = New System.Drawing.Point(0, 0)
		Me.DarkSectionPanel1.Name = "DarkSectionPanel1"
		Me.DarkSectionPanel1.SectionHeader = "PID Ajuste y Simulación"
		Me.DarkSectionPanel1.Size = New System.Drawing.Size(363, 250)
		Me.DarkSectionPanel1.TabIndex = 0
		'
		'SplitContainer5
		'
		Me.SplitContainer5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.SplitContainer5.Dock = System.Windows.Forms.DockStyle.Fill
		Me.SplitContainer5.Location = New System.Drawing.Point(1, 25)
		Me.SplitContainer5.Name = "SplitContainer5"
		'
		'SplitContainer5.Panel1
		'
		Me.SplitContainer5.Panel1.Controls.Add(Me.DarkSectionPanel2)
		'
		'SplitContainer5.Panel2
		'
		Me.SplitContainer5.Panel2.Controls.Add(Me.DarkSectionPanel3)
		Me.SplitContainer5.Size = New System.Drawing.Size(361, 224)
		Me.SplitContainer5.SplitterDistance = 125
		Me.SplitContainer5.TabIndex = 0
		'
		'DarkSectionPanel2
		'
		Me.DarkSectionPanel2.Controls.Add(Me.Btn_calc_sismin)
		Me.DarkSectionPanel2.Controls.Add(Me.Btn_sintonias)
		Me.DarkSectionPanel2.Controls.Add(Me.DarkLabel4)
		Me.DarkSectionPanel2.Controls.Add(Me.Btn_calc_sis)
		Me.DarkSectionPanel2.Controls.Add(Me.Tv_metodos)
		Me.DarkSectionPanel2.Controls.Add(Me.DarkGroupBox5)
		Me.DarkSectionPanel2.Controls.Add(Me.Txt_Tf)
		Me.DarkSectionPanel2.Dock = System.Windows.Forms.DockStyle.Fill
		Me.DarkSectionPanel2.Location = New System.Drawing.Point(0, 0)
		Me.DarkSectionPanel2.Name = "DarkSectionPanel2"
		Me.DarkSectionPanel2.SectionHeader = "Ajuste"
		Me.DarkSectionPanel2.Size = New System.Drawing.Size(123, 222)
		Me.DarkSectionPanel2.TabIndex = 0
		'
		'Btn_calc_sismin
		'
		Me.Btn_calc_sismin.BackColor = System.Drawing.Color.FromArgb(CType(CType(57, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(62, Byte), Integer))
		Me.Btn_calc_sismin.ButtonStyle = DarkUI.Controls.DarkButtonStyle.Flat
		Me.Btn_calc_sismin.Image = Global.Arduino_COM_Plotter.My.Resources.Resources.cepo16
		Me.Btn_calc_sismin.Location = New System.Drawing.Point(70, 3)
		Me.Btn_calc_sismin.Name = "Btn_calc_sismin"
		Me.Btn_calc_sismin.Padding = New System.Windows.Forms.Padding(5)
		Me.Btn_calc_sismin.Size = New System.Drawing.Size(20, 20)
		Me.Btn_calc_sismin.TabIndex = 25
		Me.ToolTip1.SetToolTip(Me.Btn_calc_sismin, "Calcular Sistema")
		'
		'Btn_sintonias
		'
		Me.Btn_sintonias.BackColor = System.Drawing.Color.FromArgb(CType(CType(57, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(62, Byte), Integer))
		Me.Btn_sintonias.ButtonStyle = DarkUI.Controls.DarkButtonStyle.Flat
		Me.Btn_sintonias.Image = Global.Arduino_COM_Plotter.My.Resources.Resources.ayuda_16
		Me.Btn_sintonias.Location = New System.Drawing.Point(96, 3)
		Me.Btn_sintonias.Name = "Btn_sintonias"
		Me.Btn_sintonias.Padding = New System.Windows.Forms.Padding(5)
		Me.Btn_sintonias.Size = New System.Drawing.Size(20, 20)
		Me.Btn_sintonias.TabIndex = 24
		Me.ToolTip1.SetToolTip(Me.Btn_sintonias, "Resumen de Sintonías")
		'
		'DarkLabel4
		'
		Me.DarkLabel4.AutoSize = True
		Me.DarkLabel4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.DarkLabel4.Location = New System.Drawing.Point(30, 146)
		Me.DarkLabel4.Name = "DarkLabel4"
		Me.DarkLabel4.Size = New System.Drawing.Size(31, 13)
		Me.DarkLabel4.TabIndex = 23
		Me.DarkLabel4.Text = "Tf (s)"
		Me.ToolTip1.SetToolTip(Me.DarkLabel4, "Cte. Tiempo Deseada en Lazo Cerrado")
		'
		'Btn_calc_sis
		'
		Me.Btn_calc_sis.BackColor = System.Drawing.Color.FromArgb(CType(CType(57, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(62, Byte), Integer))
		Me.Btn_calc_sis.ButtonStyle = DarkUI.Controls.DarkButtonStyle.Flat
		Me.Btn_calc_sis.Image = Global.Arduino_COM_Plotter.My.Resources.Resources.Calculator
		Me.Btn_calc_sis.Location = New System.Drawing.Point(44, 3)
		Me.Btn_calc_sis.Name = "Btn_calc_sis"
		Me.Btn_calc_sis.Padding = New System.Windows.Forms.Padding(5)
		Me.Btn_calc_sis.Size = New System.Drawing.Size(20, 20)
		Me.Btn_calc_sis.TabIndex = 20
		Me.ToolTip1.SetToolTip(Me.Btn_calc_sis, "Calcular Sistema")
		'
		'Tv_metodos
		'
		Me.Tv_metodos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
			Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.Tv_metodos.Location = New System.Drawing.Point(4, 167)
		Me.Tv_metodos.MaxDragChange = 20
		Me.Tv_metodos.Name = "Tv_metodos"
		Me.Tv_metodos.Size = New System.Drawing.Size(115, 20)
		Me.Tv_metodos.TabIndex = 18
		Me.Tv_metodos.Text = "DarkTreeView1"
		Me.Tv_metodos.Visible = False
		'
		'DarkGroupBox5
		'
		Me.DarkGroupBox5.BorderColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
		Me.DarkGroupBox5.Controls.Add(Me.DarkLabel3)
		Me.DarkGroupBox5.Controls.Add(Me.DarkLabel2)
		Me.DarkGroupBox5.Controls.Add(Me.DarkLabel1)
		Me.DarkGroupBox5.Controls.Add(Me.Txt_Tp)
		Me.DarkGroupBox5.Controls.Add(Me.Txt_To)
		Me.DarkGroupBox5.Controls.Add(Me.Txt_K)
		Me.DarkGroupBox5.Location = New System.Drawing.Point(10, 33)
		Me.DarkGroupBox5.Name = "DarkGroupBox5"
		Me.DarkGroupBox5.Size = New System.Drawing.Size(103, 104)
		Me.DarkGroupBox5.TabIndex = 19
		Me.DarkGroupBox5.TabStop = False
		Me.DarkGroupBox5.Text = "Sistema"
		'
		'DarkLabel3
		'
		Me.DarkLabel3.AutoSize = True
		Me.DarkLabel3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.DarkLabel3.Location = New System.Drawing.Point(17, 76)
		Me.DarkLabel3.Name = "DarkLabel3"
		Me.DarkLabel3.Size = New System.Drawing.Size(34, 13)
		Me.DarkLabel3.TabIndex = 22
		Me.DarkLabel3.Text = "Tp (s)"
		'
		'DarkLabel2
		'
		Me.DarkLabel2.AutoSize = True
		Me.DarkLabel2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.DarkLabel2.Location = New System.Drawing.Point(17, 50)
		Me.DarkLabel2.Name = "DarkLabel2"
		Me.DarkLabel2.Size = New System.Drawing.Size(34, 13)
		Me.DarkLabel2.TabIndex = 21
		Me.DarkLabel2.Text = "T0 (s)"
		'
		'DarkLabel1
		'
		Me.DarkLabel1.AutoSize = True
		Me.DarkLabel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.DarkLabel1.Location = New System.Drawing.Point(7, 24)
		Me.DarkLabel1.Name = "DarkLabel1"
		Me.DarkLabel1.Size = New System.Drawing.Size(44, 13)
		Me.DarkLabel1.TabIndex = 20
		Me.DarkLabel1.Text = "K (%/%)"
		'
		'Txt_Tp
		'
		Me.Txt_Tp.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
		Me.Txt_Tp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.Txt_Tp.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.Txt_Tp.Location = New System.Drawing.Point(54, 73)
		Me.Txt_Tp.Name = "Txt_Tp"
		Me.Txt_Tp.Size = New System.Drawing.Size(43, 20)
		Me.Txt_Tp.TabIndex = 18
		Me.Txt_Tp.Text = "100,5"
		'
		'Txt_To
		'
		Me.Txt_To.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
		Me.Txt_To.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.Txt_To.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.Txt_To.Location = New System.Drawing.Point(54, 47)
		Me.Txt_To.Name = "Txt_To"
		Me.Txt_To.Size = New System.Drawing.Size(43, 20)
		Me.Txt_To.TabIndex = 17
		Me.Txt_To.Text = "29,5"
		'
		'Txt_K
		'
		Me.Txt_K.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
		Me.Txt_K.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.Txt_K.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.Txt_K.Location = New System.Drawing.Point(54, 21)
		Me.Txt_K.Name = "Txt_K"
		Me.Txt_K.Size = New System.Drawing.Size(43, 20)
		Me.Txt_K.TabIndex = 16
		Me.Txt_K.Text = "0,149"
		'
		'Txt_Tf
		'
		Me.Txt_Tf.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
		Me.Txt_Tf.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.Txt_Tf.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.Txt_Tf.Location = New System.Drawing.Point(64, 143)
		Me.Txt_Tf.Name = "Txt_Tf"
		Me.Txt_Tf.Size = New System.Drawing.Size(43, 20)
		Me.Txt_Tf.TabIndex = 19
		Me.Txt_Tf.Text = "50"
		'
		'DarkSectionPanel3
		'
		Me.DarkSectionPanel3.Controls.Add(Me.Btn_simular2)
		Me.DarkSectionPanel3.Controls.Add(Me.DarkGroupBox4)
		Me.DarkSectionPanel3.Controls.Add(Me.DarkGroupBox3)
		Me.DarkSectionPanel3.Dock = System.Windows.Forms.DockStyle.Fill
		Me.DarkSectionPanel3.Location = New System.Drawing.Point(0, 0)
		Me.DarkSectionPanel3.Name = "DarkSectionPanel3"
		Me.DarkSectionPanel3.SectionHeader = "Simulación"
		Me.DarkSectionPanel3.Size = New System.Drawing.Size(230, 222)
		Me.DarkSectionPanel3.TabIndex = 0
		'
		'Btn_simular2
		'
		Me.Btn_simular2.BackColor = System.Drawing.Color.FromArgb(CType(CType(57, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(62, Byte), Integer))
		Me.Btn_simular2.ButtonStyle = DarkUI.Controls.DarkButtonStyle.Flat
		Me.Btn_simular2.Image = Global.Arduino_COM_Plotter.My.Resources.Resources.chart_curve16
		Me.Btn_simular2.Location = New System.Drawing.Point(66, 3)
		Me.Btn_simular2.Name = "Btn_simular2"
		Me.Btn_simular2.Padding = New System.Windows.Forms.Padding(5)
		Me.Btn_simular2.Size = New System.Drawing.Size(20, 20)
		Me.Btn_simular2.TabIndex = 27
		Me.ToolTip1.SetToolTip(Me.Btn_simular2, "Calcular Sistema")
		'
		'DarkGroupBox4
		'
		Me.DarkGroupBox4.BorderColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
		Me.DarkGroupBox4.Controls.Add(Me.DarkLabel18)
		Me.DarkGroupBox4.Controls.Add(Me.DarkLabel12)
		Me.DarkGroupBox4.Controls.Add(Me.DarkLabel17)
		Me.DarkGroupBox4.Controls.Add(Me.DarkLabel16)
		Me.DarkGroupBox4.Controls.Add(Me.DarkLabel15)
		Me.DarkGroupBox4.Controls.Add(Me.DarkLabel14)
		Me.DarkGroupBox4.Controls.Add(Me.DarkLabel13)
		Me.DarkGroupBox4.Controls.Add(Me.DarkLabel11)
		Me.DarkGroupBox4.Controls.Add(Me.DarkLabel10)
		Me.DarkGroupBox4.Controls.Add(Me.Txt_OPLimInf)
		Me.DarkGroupBox4.Controls.Add(Me.Txt_OPLimSup)
		Me.DarkGroupBox4.Controls.Add(Me.Txt_Dcarga)
		Me.DarkGroupBox4.Controls.Add(Me.Txt_DSP)
		Me.DarkGroupBox4.Controls.Add(Me.Txt_CargaIni)
		Me.DarkGroupBox4.Controls.Add(Me.Txt_OPini)
		Me.DarkGroupBox4.Controls.Add(Me.Txt_PVini)
		Me.DarkGroupBox4.Controls.Add(Me.Txt_Tfinal)
		Me.DarkGroupBox4.Controls.Add(Me.Txt_muestreo)
		Me.DarkGroupBox4.Location = New System.Drawing.Point(114, 33)
		Me.DarkGroupBox4.Name = "DarkGroupBox4"
		Me.DarkGroupBox4.Size = New System.Drawing.Size(109, 262)
		Me.DarkGroupBox4.TabIndex = 26
		Me.DarkGroupBox4.TabStop = False
		Me.DarkGroupBox4.Text = "Simulación"
		'
		'DarkLabel18
		'
		Me.DarkLabel18.AutoSize = True
		Me.DarkLabel18.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.DarkLabel18.Location = New System.Drawing.Point(9, 232)
		Me.DarkLabel18.Name = "DarkLabel18"
		Me.DarkLabel18.Size = New System.Drawing.Size(46, 13)
		Me.DarkLabel18.TabIndex = 39
		Me.DarkLabel18.Text = "OP.L.Inf"
		'
		'DarkLabel12
		'
		Me.DarkLabel12.AutoSize = True
		Me.DarkLabel12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.DarkLabel12.Location = New System.Drawing.Point(2, 206)
		Me.DarkLabel12.Name = "DarkLabel12"
		Me.DarkLabel12.Size = New System.Drawing.Size(53, 13)
		Me.DarkLabel12.TabIndex = 38
		Me.DarkLabel12.Text = "OP.L.Sup"
		'
		'DarkLabel17
		'
		Me.DarkLabel17.AutoSize = True
		Me.DarkLabel17.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.DarkLabel17.Location = New System.Drawing.Point(9, 180)
		Me.DarkLabel17.Name = "DarkLabel17"
		Me.DarkLabel17.Size = New System.Drawing.Size(46, 13)
		Me.DarkLabel17.TabIndex = 37
		Me.DarkLabel17.Text = "D.Carga"
		'
		'DarkLabel16
		'
		Me.DarkLabel16.AutoSize = True
		Me.DarkLabel16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.DarkLabel16.Location = New System.Drawing.Point(23, 154)
		Me.DarkLabel16.Name = "DarkLabel16"
		Me.DarkLabel16.Size = New System.Drawing.Size(32, 13)
		Me.DarkLabel16.TabIndex = 36
		Me.DarkLabel16.Text = "D.SP"
		'
		'DarkLabel15
		'
		Me.DarkLabel15.AutoSize = True
		Me.DarkLabel15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.DarkLabel15.Location = New System.Drawing.Point(6, 129)
		Me.DarkLabel15.Name = "DarkLabel15"
		Me.DarkLabel15.Size = New System.Drawing.Size(49, 13)
		Me.DarkLabel15.TabIndex = 35
		Me.DarkLabel15.Text = "Carga.Ini"
		'
		'DarkLabel14
		'
		Me.DarkLabel14.AutoSize = True
		Me.DarkLabel14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.DarkLabel14.Location = New System.Drawing.Point(19, 103)
		Me.DarkLabel14.Name = "DarkLabel14"
		Me.DarkLabel14.Size = New System.Drawing.Size(36, 13)
		Me.DarkLabel14.TabIndex = 34
		Me.DarkLabel14.Text = "OP.Ini"
		'
		'DarkLabel13
		'
		Me.DarkLabel13.AutoSize = True
		Me.DarkLabel13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.DarkLabel13.Location = New System.Drawing.Point(20, 76)
		Me.DarkLabel13.Name = "DarkLabel13"
		Me.DarkLabel13.Size = New System.Drawing.Size(35, 13)
		Me.DarkLabel13.TabIndex = 33
		Me.DarkLabel13.Text = "PV.Ini"
		'
		'DarkLabel11
		'
		Me.DarkLabel11.AutoSize = True
		Me.DarkLabel11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.DarkLabel11.Location = New System.Drawing.Point(16, 50)
		Me.DarkLabel11.Name = "DarkLabel11"
		Me.DarkLabel11.Size = New System.Drawing.Size(39, 13)
		Me.DarkLabel11.TabIndex = 31
		Me.DarkLabel11.Text = "T.Final"
		'
		'DarkLabel10
		'
		Me.DarkLabel10.AutoSize = True
		Me.DarkLabel10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.DarkLabel10.Location = New System.Drawing.Point(36, 24)
		Me.DarkLabel10.Name = "DarkLabel10"
		Me.DarkLabel10.Size = New System.Drawing.Size(19, 13)
		Me.DarkLabel10.TabIndex = 30
		Me.DarkLabel10.Text = "Ts"
		'
		'Txt_OPLimInf
		'
		Me.Txt_OPLimInf.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
		Me.Txt_OPLimInf.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.Txt_OPLimInf.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.Txt_OPLimInf.Location = New System.Drawing.Point(58, 229)
		Me.Txt_OPLimInf.Name = "Txt_OPLimInf"
		Me.Txt_OPLimInf.Size = New System.Drawing.Size(44, 20)
		Me.Txt_OPLimInf.TabIndex = 29
		'
		'Txt_OPLimSup
		'
		Me.Txt_OPLimSup.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
		Me.Txt_OPLimSup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.Txt_OPLimSup.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.Txt_OPLimSup.Location = New System.Drawing.Point(58, 203)
		Me.Txt_OPLimSup.Name = "Txt_OPLimSup"
		Me.Txt_OPLimSup.Size = New System.Drawing.Size(44, 20)
		Me.Txt_OPLimSup.TabIndex = 28
		'
		'Txt_Dcarga
		'
		Me.Txt_Dcarga.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
		Me.Txt_Dcarga.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.Txt_Dcarga.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.Txt_Dcarga.Location = New System.Drawing.Point(58, 177)
		Me.Txt_Dcarga.Name = "Txt_Dcarga"
		Me.Txt_Dcarga.Size = New System.Drawing.Size(44, 20)
		Me.Txt_Dcarga.TabIndex = 27
		'
		'Txt_DSP
		'
		Me.Txt_DSP.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
		Me.Txt_DSP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.Txt_DSP.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.Txt_DSP.Location = New System.Drawing.Point(58, 151)
		Me.Txt_DSP.Name = "Txt_DSP"
		Me.Txt_DSP.Size = New System.Drawing.Size(44, 20)
		Me.Txt_DSP.TabIndex = 26
		'
		'Txt_CargaIni
		'
		Me.Txt_CargaIni.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
		Me.Txt_CargaIni.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.Txt_CargaIni.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.Txt_CargaIni.Location = New System.Drawing.Point(58, 125)
		Me.Txt_CargaIni.Name = "Txt_CargaIni"
		Me.Txt_CargaIni.Size = New System.Drawing.Size(44, 20)
		Me.Txt_CargaIni.TabIndex = 25
		'
		'Txt_OPini
		'
		Me.Txt_OPini.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
		Me.Txt_OPini.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.Txt_OPini.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.Txt_OPini.Location = New System.Drawing.Point(58, 99)
		Me.Txt_OPini.Name = "Txt_OPini"
		Me.Txt_OPini.Size = New System.Drawing.Size(44, 20)
		Me.Txt_OPini.TabIndex = 24
		'
		'Txt_PVini
		'
		Me.Txt_PVini.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
		Me.Txt_PVini.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.Txt_PVini.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.Txt_PVini.Location = New System.Drawing.Point(58, 73)
		Me.Txt_PVini.Name = "Txt_PVini"
		Me.Txt_PVini.Size = New System.Drawing.Size(44, 20)
		Me.Txt_PVini.TabIndex = 23
		'
		'Txt_Tfinal
		'
		Me.Txt_Tfinal.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
		Me.Txt_Tfinal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.Txt_Tfinal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.Txt_Tfinal.Location = New System.Drawing.Point(58, 47)
		Me.Txt_Tfinal.Name = "Txt_Tfinal"
		Me.Txt_Tfinal.Size = New System.Drawing.Size(44, 20)
		Me.Txt_Tfinal.TabIndex = 22
		'
		'Txt_muestreo
		'
		Me.Txt_muestreo.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
		Me.Txt_muestreo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.Txt_muestreo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.Txt_muestreo.Location = New System.Drawing.Point(58, 21)
		Me.Txt_muestreo.Name = "Txt_muestreo"
		Me.Txt_muestreo.Size = New System.Drawing.Size(44, 20)
		Me.Txt_muestreo.TabIndex = 21
		'
		'DarkGroupBox3
		'
		Me.DarkGroupBox3.BorderColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
		Me.DarkGroupBox3.Controls.Add(Me.DarkLabel20)
		Me.DarkGroupBox3.Controls.Add(Me.DarkLabel19)
		Me.DarkGroupBox3.Controls.Add(Me.Txt_Kd)
		Me.DarkGroupBox3.Controls.Add(Me.Txt_Ki)
		Me.DarkGroupBox3.Controls.Add(Me.Cbo_eq)
		Me.DarkGroupBox3.Controls.Add(Me.DarkLabel7)
		Me.DarkGroupBox3.Controls.Add(Me.DarkLabel8)
		Me.DarkGroupBox3.Controls.Add(Me.DarkLabel9)
		Me.DarkGroupBox3.Controls.Add(Me.DarkLabel6)
		Me.DarkGroupBox3.Controls.Add(Me.DarkLabel5)
		Me.DarkGroupBox3.Controls.Add(Me.Txt_Td)
		Me.DarkGroupBox3.Controls.Add(Me.Txt_Ti)
		Me.DarkGroupBox3.Controls.Add(Me.Txt_Kc)
		Me.DarkGroupBox3.Controls.Add(Me.Txt_PVrngInf)
		Me.DarkGroupBox3.Controls.Add(Me.Txt_PVrngSup)
		Me.DarkGroupBox3.Location = New System.Drawing.Point(8, 33)
		Me.DarkGroupBox3.Name = "DarkGroupBox3"
		Me.DarkGroupBox3.Size = New System.Drawing.Size(100, 245)
		Me.DarkGroupBox3.TabIndex = 21
		Me.DarkGroupBox3.TabStop = False
		Me.DarkGroupBox3.Text = "Controlador"
		'
		'DarkLabel20
		'
		Me.DarkLabel20.AutoSize = True
		Me.DarkLabel20.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.DarkLabel20.Location = New System.Drawing.Point(30, 181)
		Me.DarkLabel20.Name = "DarkLabel20"
		Me.DarkLabel20.Size = New System.Drawing.Size(16, 13)
		Me.DarkLabel20.TabIndex = 34
		Me.DarkLabel20.Text = "Ki"
		'
		'DarkLabel19
		'
		Me.DarkLabel19.AutoSize = True
		Me.DarkLabel19.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.DarkLabel19.Location = New System.Drawing.Point(26, 206)
		Me.DarkLabel19.Name = "DarkLabel19"
		Me.DarkLabel19.Size = New System.Drawing.Size(20, 13)
		Me.DarkLabel19.TabIndex = 33
		Me.DarkLabel19.Text = "Kd"
		'
		'Txt_Kd
		'
		Me.Txt_Kd.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
		Me.Txt_Kd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.Txt_Kd.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.Txt_Kd.Location = New System.Drawing.Point(49, 203)
		Me.Txt_Kd.Name = "Txt_Kd"
		Me.Txt_Kd.Size = New System.Drawing.Size(44, 20)
		Me.Txt_Kd.TabIndex = 32
		'
		'Txt_Ki
		'
		Me.Txt_Ki.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
		Me.Txt_Ki.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.Txt_Ki.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.Txt_Ki.Location = New System.Drawing.Point(49, 177)
		Me.Txt_Ki.Name = "Txt_Ki"
		Me.Txt_Ki.Size = New System.Drawing.Size(44, 20)
		Me.Txt_Ki.TabIndex = 31
		'
		'Cbo_eq
		'
		Me.Cbo_eq.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
		Me.Cbo_eq.FormattingEnabled = True
		Me.Cbo_eq.Items.AddRange(New Object() {"PID", "PI-D", "I-PD"})
		Me.Cbo_eq.Location = New System.Drawing.Point(13, 72)
		Me.Cbo_eq.Name = "Cbo_eq"
		Me.Cbo_eq.Size = New System.Drawing.Size(80, 21)
		Me.Cbo_eq.TabIndex = 30
		Me.ToolTip1.SetToolTip(Me.Cbo_eq, "Tipo de Ecuación")
		'
		'DarkLabel7
		'
		Me.DarkLabel7.AutoSize = True
		Me.DarkLabel7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.DarkLabel7.Location = New System.Drawing.Point(26, 155)
		Me.DarkLabel7.Name = "DarkLabel7"
		Me.DarkLabel7.Size = New System.Drawing.Size(20, 13)
		Me.DarkLabel7.TabIndex = 29
		Me.DarkLabel7.Text = "Td"
		'
		'DarkLabel8
		'
		Me.DarkLabel8.AutoSize = True
		Me.DarkLabel8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.DarkLabel8.Location = New System.Drawing.Point(30, 129)
		Me.DarkLabel8.Name = "DarkLabel8"
		Me.DarkLabel8.Size = New System.Drawing.Size(16, 13)
		Me.DarkLabel8.TabIndex = 28
		Me.DarkLabel8.Text = "Ti"
		'
		'DarkLabel9
		'
		Me.DarkLabel9.AutoSize = True
		Me.DarkLabel9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.DarkLabel9.Location = New System.Drawing.Point(26, 103)
		Me.DarkLabel9.Name = "DarkLabel9"
		Me.DarkLabel9.Size = New System.Drawing.Size(20, 13)
		Me.DarkLabel9.TabIndex = 27
		Me.DarkLabel9.Text = "Kc"
		'
		'DarkLabel6
		'
		Me.DarkLabel6.AutoSize = True
		Me.DarkLabel6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.DarkLabel6.Location = New System.Drawing.Point(10, 51)
		Me.DarkLabel6.Name = "DarkLabel6"
		Me.DarkLabel6.Size = New System.Drawing.Size(36, 13)
		Me.DarkLabel6.TabIndex = 26
		Me.DarkLabel6.Text = "PV.Inf"
		'
		'DarkLabel5
		'
		Me.DarkLabel5.AutoSize = True
		Me.DarkLabel5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.DarkLabel5.Location = New System.Drawing.Point(3, 24)
		Me.DarkLabel5.Name = "DarkLabel5"
		Me.DarkLabel5.Size = New System.Drawing.Size(43, 13)
		Me.DarkLabel5.TabIndex = 24
		Me.DarkLabel5.Text = "PV.Sup"
		'
		'Txt_Td
		'
		Me.Txt_Td.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
		Me.Txt_Td.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.Txt_Td.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.Txt_Td.Location = New System.Drawing.Point(49, 151)
		Me.Txt_Td.Name = "Txt_Td"
		Me.Txt_Td.Size = New System.Drawing.Size(44, 20)
		Me.Txt_Td.TabIndex = 25
		'
		'Txt_Ti
		'
		Me.Txt_Ti.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
		Me.Txt_Ti.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.Txt_Ti.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.Txt_Ti.Location = New System.Drawing.Point(49, 125)
		Me.Txt_Ti.Name = "Txt_Ti"
		Me.Txt_Ti.Size = New System.Drawing.Size(44, 20)
		Me.Txt_Ti.TabIndex = 24
		'
		'Txt_Kc
		'
		Me.Txt_Kc.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
		Me.Txt_Kc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.Txt_Kc.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.Txt_Kc.Location = New System.Drawing.Point(49, 99)
		Me.Txt_Kc.Name = "Txt_Kc"
		Me.Txt_Kc.Size = New System.Drawing.Size(44, 20)
		Me.Txt_Kc.TabIndex = 23
		'
		'Txt_PVrngInf
		'
		Me.Txt_PVrngInf.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
		Me.Txt_PVrngInf.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.Txt_PVrngInf.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.Txt_PVrngInf.Location = New System.Drawing.Point(49, 47)
		Me.Txt_PVrngInf.Name = "Txt_PVrngInf"
		Me.Txt_PVrngInf.Size = New System.Drawing.Size(44, 20)
		Me.Txt_PVrngInf.TabIndex = 22
		'
		'Txt_PVrngSup
		'
		Me.Txt_PVrngSup.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
		Me.Txt_PVrngSup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.Txt_PVrngSup.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.Txt_PVrngSup.Location = New System.Drawing.Point(49, 21)
		Me.Txt_PVrngSup.Name = "Txt_PVrngSup"
		Me.Txt_PVrngSup.Size = New System.Drawing.Size(44, 20)
		Me.Txt_PVrngSup.TabIndex = 21
		'
		'SplitContainer6
		'
		Me.SplitContainer6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.SplitContainer6.Dock = System.Windows.Forms.DockStyle.Fill
		Me.SplitContainer6.Location = New System.Drawing.Point(0, 0)
		Me.SplitContainer6.Name = "SplitContainer6"
		Me.SplitContainer6.Orientation = System.Windows.Forms.Orientation.Horizontal
		'
		'SplitContainer6.Panel1
		'
		Me.SplitContainer6.Panel1.Controls.Add(Me.Chart1)
		Me.SplitContainer6.Panel1.Controls.Add(Me.DarkToolStrip2)
		'
		'SplitContainer6.Panel2
		'
		Me.SplitContainer6.Panel2.Controls.Add(Me.txtdebug)
		Me.SplitContainer6.Panel2.Controls.Add(Me.Chart_simula)
		Me.SplitContainer6.Panel2.Controls.Add(Me.DarkToolStrip3)
		Me.SplitContainer6.Size = New System.Drawing.Size(639, 658)
		Me.SplitContainer6.SplitterDistance = 350
		Me.SplitContainer6.TabIndex = 4
		'
		'Chart1
		'
		Me.Chart1.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
		ChartArea1.AxisX.InterlacedColor = System.Drawing.Color.Gainsboro
		ChartArea1.AxisX.LabelStyle.ForeColor = System.Drawing.Color.Gainsboro
		ChartArea1.AxisX.LineColor = System.Drawing.Color.Gainsboro
		ChartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.Gainsboro
		ChartArea1.AxisX.MajorTickMark.LineColor = System.Drawing.Color.Gainsboro
		ChartArea1.AxisX.MinorGrid.LineColor = System.Drawing.Color.Gainsboro
		ChartArea1.AxisX.MinorTickMark.LineColor = System.Drawing.Color.Gainsboro
		ChartArea1.AxisX.TitleForeColor = System.Drawing.Color.Gainsboro
		ChartArea1.AxisX2.LabelStyle.ForeColor = System.Drawing.Color.Gainsboro
		ChartArea1.AxisX2.LineColor = System.Drawing.Color.Gainsboro
		ChartArea1.AxisX2.MajorGrid.LineColor = System.Drawing.Color.Gainsboro
		ChartArea1.AxisX2.MajorTickMark.LineColor = System.Drawing.Color.Gainsboro
		ChartArea1.AxisX2.MinorGrid.LineColor = System.Drawing.Color.Gainsboro
		ChartArea1.AxisX2.MinorTickMark.LineColor = System.Drawing.Color.Gainsboro
		ChartArea1.AxisX2.TitleForeColor = System.Drawing.Color.Gainsboro
		ChartArea1.AxisY.LabelStyle.ForeColor = System.Drawing.Color.Gainsboro
		ChartArea1.AxisY.LineColor = System.Drawing.Color.Gainsboro
		ChartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.Gainsboro
		ChartArea1.AxisY.MajorTickMark.LineColor = System.Drawing.Color.Gainsboro
		ChartArea1.AxisY.MinorGrid.LineColor = System.Drawing.Color.Gainsboro
		ChartArea1.AxisY.MinorTickMark.LineColor = System.Drawing.Color.Gainsboro
		ChartArea1.AxisY.TitleForeColor = System.Drawing.Color.Gainsboro
		ChartArea1.AxisY2.LabelStyle.ForeColor = System.Drawing.Color.Gainsboro
		ChartArea1.AxisY2.LineColor = System.Drawing.Color.Gainsboro
		ChartArea1.AxisY2.MajorGrid.LineColor = System.Drawing.Color.Gainsboro
		ChartArea1.AxisY2.MajorTickMark.LineColor = System.Drawing.Color.Gainsboro
		ChartArea1.AxisY2.MinorGrid.LineColor = System.Drawing.Color.Gainsboro
		ChartArea1.AxisY2.MinorTickMark.LineColor = System.Drawing.Color.Gainsboro
		ChartArea1.AxisY2.TitleForeColor = System.Drawing.Color.Gainsboro
		ChartArea1.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
		ChartArea1.BorderColor = System.Drawing.Color.Gainsboro
		ChartArea1.Name = "ChartArea1"
		ChartArea2.AxisX.InterlacedColor = System.Drawing.Color.Gainsboro
		ChartArea2.AxisX.LabelStyle.ForeColor = System.Drawing.Color.Gainsboro
		ChartArea2.AxisX.LineColor = System.Drawing.Color.Gainsboro
		ChartArea2.AxisX.MajorGrid.LineColor = System.Drawing.Color.Gainsboro
		ChartArea2.AxisX.MajorTickMark.LineColor = System.Drawing.Color.Gainsboro
		ChartArea2.AxisX.MinorGrid.LineColor = System.Drawing.Color.Gainsboro
		ChartArea2.AxisX.MinorTickMark.LineColor = System.Drawing.Color.Gainsboro
		ChartArea2.AxisX.ScaleBreakStyle.LineColor = System.Drawing.Color.Gainsboro
		ChartArea2.AxisX.TitleForeColor = System.Drawing.Color.Gainsboro
		ChartArea2.AxisX2.InterlacedColor = System.Drawing.Color.Gainsboro
		ChartArea2.AxisX2.LabelStyle.ForeColor = System.Drawing.Color.Gainsboro
		ChartArea2.AxisX2.LineColor = System.Drawing.Color.Gainsboro
		ChartArea2.AxisX2.MajorGrid.LineColor = System.Drawing.Color.Gainsboro
		ChartArea2.AxisX2.MajorTickMark.LineColor = System.Drawing.Color.Gainsboro
		ChartArea2.AxisX2.MinorGrid.LineColor = System.Drawing.Color.Gainsboro
		ChartArea2.AxisX2.MinorTickMark.LineColor = System.Drawing.Color.Gainsboro
		ChartArea2.AxisX2.ScaleBreakStyle.LineColor = System.Drawing.Color.Gainsboro
		ChartArea2.AxisX2.TitleForeColor = System.Drawing.Color.Gainsboro
		ChartArea2.AxisY.InterlacedColor = System.Drawing.Color.Gainsboro
		ChartArea2.AxisY.LabelStyle.ForeColor = System.Drawing.Color.Gainsboro
		ChartArea2.AxisY.LineColor = System.Drawing.Color.Gainsboro
		ChartArea2.AxisY.MajorGrid.LineColor = System.Drawing.Color.Gainsboro
		ChartArea2.AxisY.MajorTickMark.LineColor = System.Drawing.Color.Gainsboro
		ChartArea2.AxisY.MinorGrid.LineColor = System.Drawing.Color.Gainsboro
		ChartArea2.AxisY.MinorTickMark.LineColor = System.Drawing.Color.Gainsboro
		ChartArea2.AxisY.ScaleBreakStyle.LineColor = System.Drawing.Color.Gainsboro
		ChartArea2.AxisY.TitleForeColor = System.Drawing.Color.Gainsboro
		ChartArea2.AxisY2.InterlacedColor = System.Drawing.Color.Gainsboro
		ChartArea2.AxisY2.LabelStyle.ForeColor = System.Drawing.Color.Gainsboro
		ChartArea2.AxisY2.LineColor = System.Drawing.Color.Gainsboro
		ChartArea2.AxisY2.MajorGrid.LineColor = System.Drawing.Color.Gainsboro
		ChartArea2.AxisY2.MajorTickMark.LineColor = System.Drawing.Color.Gainsboro
		ChartArea2.AxisY2.MinorGrid.LineColor = System.Drawing.Color.Gainsboro
		ChartArea2.AxisY2.MinorTickMark.LineColor = System.Drawing.Color.Gainsboro
		ChartArea2.AxisY2.ScaleBreakStyle.LineColor = System.Drawing.Color.Gainsboro
		ChartArea2.AxisY2.TitleForeColor = System.Drawing.Color.Gainsboro
		ChartArea2.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
		ChartArea2.BorderColor = System.Drawing.Color.Gainsboro
		ChartArea2.Name = "ChartArea2"
		Me.Chart1.ChartAreas.Add(ChartArea1)
		Me.Chart1.ChartAreas.Add(ChartArea2)
		Me.Chart1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.Chart1.IsSoftShadows = False
		Legend1.Alignment = System.Drawing.StringAlignment.Center
		Legend1.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
		Legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top
		Legend1.ForeColor = System.Drawing.Color.Gainsboro
		Legend1.Name = "Legend1"
		Me.Chart1.Legends.Add(Legend1)
		Me.Chart1.Location = New System.Drawing.Point(0, 28)
		Me.Chart1.Name = "Chart1"
		Me.Chart1.Size = New System.Drawing.Size(637, 320)
		Me.Chart1.TabIndex = 5
		Me.Chart1.Text = "Chart1"
		'
		'DarkToolStrip2
		'
		Me.DarkToolStrip2.AutoSize = False
		Me.DarkToolStrip2.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
		Me.DarkToolStrip2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.DarkToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Btn_ampliarTiempo, Me.ToolStripLabel1, Me.btn_captura, Me.Cbo_SincEjes})
		Me.DarkToolStrip2.Location = New System.Drawing.Point(0, 0)
		Me.DarkToolStrip2.Name = "DarkToolStrip2"
		Me.DarkToolStrip2.Padding = New System.Windows.Forms.Padding(5, 0, 1, 0)
		Me.DarkToolStrip2.Size = New System.Drawing.Size(637, 28)
		Me.DarkToolStrip2.TabIndex = 6
		Me.DarkToolStrip2.Text = "DarkToolStrip2"
		'
		'Btn_ampliarTiempo
		'
		Me.Btn_ampliarTiempo.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
		Me.Btn_ampliarTiempo.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
		Me.Btn_ampliarTiempo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.Btn_ampliarTiempo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.Btn_ampliarTiempo.Image = Global.Arduino_COM_Plotter.My.Resources.Resources.Hor_Vert2_16
		Me.Btn_ampliarTiempo.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.Btn_ampliarTiempo.Name = "Btn_ampliarTiempo"
		Me.Btn_ampliarTiempo.Size = New System.Drawing.Size(23, 25)
		Me.Btn_ampliarTiempo.Text = "Mostrar la línea de Tiempo completa"
		'
		'ToolStripLabel1
		'
		Me.ToolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
		Me.ToolStripLabel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
		Me.ToolStripLabel1.Enabled = False
		Me.ToolStripLabel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.ToolStripLabel1.Name = "ToolStripLabel1"
		Me.ToolStripLabel1.Size = New System.Drawing.Size(10, 25)
		Me.ToolStripLabel1.Text = "|"
		'
		'btn_captura
		'
		Me.btn_captura.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
		Me.btn_captura.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
		Me.btn_captura.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.btn_captura.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.btn_captura.Image = Global.Arduino_COM_Plotter.My.Resources.Resources.cam16
		Me.btn_captura.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.btn_captura.Name = "btn_captura"
		Me.btn_captura.Padding = New System.Windows.Forms.Padding(5, 10, 5, 0)
		Me.btn_captura.Size = New System.Drawing.Size(30, 25)
		Me.btn_captura.Text = "Capturar imagen del gráfico"
		'
		'txtdebug
		'
		Me.txtdebug.BackColor = System.Drawing.SystemColors.WindowFrame
		Me.txtdebug.Location = New System.Drawing.Point(98, 282)
		Me.txtdebug.Name = "txtdebug"
		Me.txtdebug.Size = New System.Drawing.Size(427, 40)
		Me.txtdebug.TabIndex = 7
		Me.txtdebug.Text = ""
		Me.txtdebug.Visible = False
		'
		'Chart_simula
		'
		Me.Chart_simula.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
		ChartArea3.AxisX.InterlacedColor = System.Drawing.Color.Gainsboro
		ChartArea3.AxisX.LabelStyle.ForeColor = System.Drawing.Color.Gainsboro
		ChartArea3.AxisX.LineColor = System.Drawing.Color.Gainsboro
		ChartArea3.AxisX.MajorGrid.LineColor = System.Drawing.Color.Gainsboro
		ChartArea3.AxisX.MajorTickMark.LineColor = System.Drawing.Color.Gainsboro
		ChartArea3.AxisX.MinorGrid.LineColor = System.Drawing.Color.Gainsboro
		ChartArea3.AxisX.MinorTickMark.LineColor = System.Drawing.Color.Gainsboro
		ChartArea3.AxisX.TitleForeColor = System.Drawing.Color.Gainsboro
		ChartArea3.AxisX2.LabelStyle.ForeColor = System.Drawing.Color.Gainsboro
		ChartArea3.AxisX2.LineColor = System.Drawing.Color.Gainsboro
		ChartArea3.AxisX2.MajorGrid.LineColor = System.Drawing.Color.Gainsboro
		ChartArea3.AxisX2.MajorTickMark.LineColor = System.Drawing.Color.Gainsboro
		ChartArea3.AxisX2.MinorGrid.LineColor = System.Drawing.Color.Gainsboro
		ChartArea3.AxisX2.MinorTickMark.LineColor = System.Drawing.Color.Gainsboro
		ChartArea3.AxisX2.TitleForeColor = System.Drawing.Color.Gainsboro
		ChartArea3.AxisY.LabelStyle.ForeColor = System.Drawing.Color.Gainsboro
		ChartArea3.AxisY.LineColor = System.Drawing.Color.Gainsboro
		ChartArea3.AxisY.MajorGrid.LineColor = System.Drawing.Color.Gainsboro
		ChartArea3.AxisY.MajorTickMark.LineColor = System.Drawing.Color.Gainsboro
		ChartArea3.AxisY.MinorGrid.LineColor = System.Drawing.Color.Gainsboro
		ChartArea3.AxisY.MinorTickMark.LineColor = System.Drawing.Color.Gainsboro
		ChartArea3.AxisY2.LabelStyle.ForeColor = System.Drawing.Color.Gainsboro
		ChartArea3.AxisY2.LineColor = System.Drawing.Color.Gainsboro
		ChartArea3.AxisY2.MajorGrid.LineColor = System.Drawing.Color.Gainsboro
		ChartArea3.AxisY2.MajorTickMark.LineColor = System.Drawing.Color.Gainsboro
		ChartArea3.AxisY2.MinorGrid.LineColor = System.Drawing.Color.Gainsboro
		ChartArea3.AxisY2.MinorTickMark.LineColor = System.Drawing.Color.Gainsboro
		ChartArea3.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
		ChartArea3.BorderColor = System.Drawing.Color.Gainsboro
		ChartArea3.Name = "ChartArea1"
		Me.Chart_simula.ChartAreas.Add(ChartArea3)
		Me.Chart_simula.Dock = System.Windows.Forms.DockStyle.Fill
		Me.Chart_simula.Location = New System.Drawing.Point(0, 28)
		Me.Chart_simula.Name = "Chart_simula"
		Me.Chart_simula.Size = New System.Drawing.Size(637, 274)
		Me.Chart_simula.TabIndex = 6
		Me.Chart_simula.Text = "Chart2"
		'
		'DarkToolStrip3
		'
		Me.DarkToolStrip3.AutoSize = False
		Me.DarkToolStrip3.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
		Me.DarkToolStrip3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.DarkToolStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel3, Me.Cbo_metodos_sim, Me.Btn_ampliarTiempo_simula, Me.ToolStripLabel2, Me.Btn_captura_simula})
		Me.DarkToolStrip3.Location = New System.Drawing.Point(0, 0)
		Me.DarkToolStrip3.Name = "DarkToolStrip3"
		Me.DarkToolStrip3.Padding = New System.Windows.Forms.Padding(5, 0, 1, 0)
		Me.DarkToolStrip3.Size = New System.Drawing.Size(637, 28)
		Me.DarkToolStrip3.TabIndex = 0
		Me.DarkToolStrip3.Text = "DarkToolStrip3"
		'
		'ToolStripLabel3
		'
		Me.ToolStripLabel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
		Me.ToolStripLabel3.Enabled = False
		Me.ToolStripLabel3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.ToolStripLabel3.Name = "ToolStripLabel3"
		Me.ToolStripLabel3.Size = New System.Drawing.Size(50, 25)
		Me.ToolStripLabel3.Text = "Sintonía"
		'
		'Cbo_metodos_sim
		'
		Me.Cbo_metodos_sim.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
		Me.Cbo_metodos_sim.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.Cbo_metodos_sim.Name = "Cbo_metodos_sim"
		Me.Cbo_metodos_sim.Size = New System.Drawing.Size(121, 28)
		'
		'Btn_ampliarTiempo_simula
		'
		Me.Btn_ampliarTiempo_simula.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
		Me.Btn_ampliarTiempo_simula.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
		Me.Btn_ampliarTiempo_simula.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.Btn_ampliarTiempo_simula.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.Btn_ampliarTiempo_simula.Image = Global.Arduino_COM_Plotter.My.Resources.Resources.Hor_Vert2_16
		Me.Btn_ampliarTiempo_simula.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.Btn_ampliarTiempo_simula.Name = "Btn_ampliarTiempo_simula"
		Me.Btn_ampliarTiempo_simula.Size = New System.Drawing.Size(23, 25)
		Me.Btn_ampliarTiempo_simula.Text = "Mostrar la línea de Tiempo completa"
		'
		'ToolStripLabel2
		'
		Me.ToolStripLabel2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
		Me.ToolStripLabel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
		Me.ToolStripLabel2.Enabled = False
		Me.ToolStripLabel2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.ToolStripLabel2.Name = "ToolStripLabel2"
		Me.ToolStripLabel2.Size = New System.Drawing.Size(10, 25)
		Me.ToolStripLabel2.Text = "|"
		'
		'Btn_captura_simula
		'
		Me.Btn_captura_simula.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
		Me.Btn_captura_simula.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
		Me.Btn_captura_simula.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.Btn_captura_simula.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.Btn_captura_simula.Image = Global.Arduino_COM_Plotter.My.Resources.Resources.cam16
		Me.Btn_captura_simula.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.Btn_captura_simula.Name = "Btn_captura_simula"
		Me.Btn_captura_simula.Size = New System.Drawing.Size(23, 25)
		Me.Btn_captura_simula.Text = "Capturar imagen del gráfico de simulación"
		'
		'DarkStatusStrip2
		'
		Me.DarkStatusStrip2.AutoSize = False
		Me.DarkStatusStrip2.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
		Me.DarkStatusStrip2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.DarkStatusStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.Lbl_info})
		Me.DarkStatusStrip2.Location = New System.Drawing.Point(0, 658)
		Me.DarkStatusStrip2.Name = "DarkStatusStrip2"
		Me.DarkStatusStrip2.Padding = New System.Windows.Forms.Padding(0, 5, 0, 3)
		Me.DarkStatusStrip2.Size = New System.Drawing.Size(639, 28)
		Me.DarkStatusStrip2.SizingGrip = False
		Me.DarkStatusStrip2.TabIndex = 3
		Me.DarkStatusStrip2.Text = "DarkStatusStrip2"
		'
		'ToolStripStatusLabel1
		'
		Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
		Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(0, 0)
		Me.ToolStripStatusLabel1.Spring = True
		'
		'Lbl_info
		'
		Me.Lbl_info.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
		Me.Lbl_info.Name = "Lbl_info"
		Me.Lbl_info.Size = New System.Drawing.Size(41, 15)
		Me.Lbl_info.Text = "lblinfo"
		'
		'Timer1
		'
		Me.Timer1.Interval = 1000
		'
		'DarkToolStrip1
		'
		Me.DarkToolStrip1.AutoSize = False
		Me.DarkToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
		Me.DarkToolStrip1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.DarkToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel5, Me.btn_abrir, Me.Btn_reset, Me.ToolStripLabel6, Me.Btn_guardarP, Me.Btn_exportarP})
		Me.DarkToolStrip1.Location = New System.Drawing.Point(0, 24)
		Me.DarkToolStrip1.Name = "DarkToolStrip1"
		Me.DarkToolStrip1.Padding = New System.Windows.Forms.Padding(5, 0, 1, 0)
		Me.DarkToolStrip1.Size = New System.Drawing.Size(1008, 33)
		Me.DarkToolStrip1.TabIndex = 3
		Me.DarkToolStrip1.Text = "DarkToolStrip1"
		'
		'ToolStripLabel5
		'
		Me.ToolStripLabel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
		Me.ToolStripLabel5.Enabled = False
		Me.ToolStripLabel5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.ToolStripLabel5.Name = "ToolStripLabel5"
		Me.ToolStripLabel5.Size = New System.Drawing.Size(54, 30)
		Me.ToolStripLabel5.Text = "Proyecto"
		'
		'btn_abrir
		'
		Me.btn_abrir.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
		Me.btn_abrir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.btn_abrir.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.btn_abrir.Image = Global.Arduino_COM_Plotter.My.Resources.Resources.abrir_azul16
		Me.btn_abrir.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.btn_abrir.Name = "btn_abrir"
		Me.btn_abrir.Padding = New System.Windows.Forms.Padding(5, 10, 5, 0)
		Me.btn_abrir.Size = New System.Drawing.Size(30, 30)
		Me.btn_abrir.Text = "Abrir Proyecto"
		'
		'Btn_reset
		'
		Me.Btn_reset.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
		Me.Btn_reset.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.Btn_reset.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.Btn_reset.Image = Global.Arduino_COM_Plotter.My.Resources.Resources.Borrar_2_16
		Me.Btn_reset.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.Btn_reset.Name = "Btn_reset"
		Me.Btn_reset.Padding = New System.Windows.Forms.Padding(5, 0, 5, 0)
		Me.Btn_reset.Size = New System.Drawing.Size(30, 30)
		Me.Btn_reset.Text = "Reset"
		'
		'ToolStripLabel6
		'
		Me.ToolStripLabel6.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
		Me.ToolStripLabel6.Enabled = False
		Me.ToolStripLabel6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.ToolStripLabel6.Name = "ToolStripLabel6"
		Me.ToolStripLabel6.Size = New System.Drawing.Size(10, 30)
		Me.ToolStripLabel6.Text = "|"
		'
		'Btn_guardarP
		'
		Me.Btn_guardarP.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
		Me.Btn_guardarP.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.Btn_guardarP.Enabled = False
		Me.Btn_guardarP.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.Btn_guardarP.Image = Global.Arduino_COM_Plotter.My.Resources.Resources.Save16
		Me.Btn_guardarP.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.Btn_guardarP.Name = "Btn_guardarP"
		Me.Btn_guardarP.Padding = New System.Windows.Forms.Padding(5, 10, 5, 0)
		Me.Btn_guardarP.Size = New System.Drawing.Size(30, 30)
		Me.Btn_guardarP.Text = "Guardar Proyecto"
		'
		'Btn_exportarP
		'
		Me.Btn_exportarP.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
		Me.Btn_exportarP.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.Btn_exportarP.Enabled = False
		Me.Btn_exportarP.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.Btn_exportarP.Image = Global.Arduino_COM_Plotter.My.Resources.Resources.save_zip_blue
		Me.Btn_exportarP.Name = "Btn_exportarP"
		Me.Btn_exportarP.Padding = New System.Windows.Forms.Padding(5, 0, 5, 0)
		Me.Btn_exportarP.Size = New System.Drawing.Size(30, 30)
		Me.Btn_exportarP.Text = "Exportar Proyecto a ZIP"
		'
		'DarkMenuStrip1
		'
		Me.DarkMenuStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
		Me.DarkMenuStrip1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.DarkMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ArchivoToolStripMenuItem, Me.VerToolStripMenuItem, Me.ToolStripMenuItem1, Me.GarikoitzinfoToolStripMenuItem})
		Me.DarkMenuStrip1.Location = New System.Drawing.Point(0, 0)
		Me.DarkMenuStrip1.Name = "DarkMenuStrip1"
		Me.DarkMenuStrip1.Padding = New System.Windows.Forms.Padding(3, 2, 0, 2)
		Me.DarkMenuStrip1.Size = New System.Drawing.Size(1008, 24)
		Me.DarkMenuStrip1.TabIndex = 4
		Me.DarkMenuStrip1.Text = "DarkMenuStrip1"
		'
		'ArchivoToolStripMenuItem
		'
		Me.ArchivoToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
		Me.ArchivoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SalirToolStripMenuItem})
		Me.ArchivoToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.ArchivoToolStripMenuItem.Name = "ArchivoToolStripMenuItem"
		Me.ArchivoToolStripMenuItem.Size = New System.Drawing.Size(60, 20)
		Me.ArchivoToolStripMenuItem.Text = "Archivo"
		'
		'SalirToolStripMenuItem
		'
		Me.SalirToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
		Me.SalirToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
		Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(96, 22)
		Me.SalirToolStripMenuItem.Text = "Salir"
		'
		'VerToolStripMenuItem
		'
		Me.VerToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
		Me.VerToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConfiguraciónDelPuertoYLosDatosToolStripMenuItem, Me.DatosLogVarToolStripMenuItem1, Me.PIDDatosDeSimulaciónToolStripMenuItem})
		Me.VerToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.VerToolStripMenuItem.Name = "VerToolStripMenuItem"
		Me.VerToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
		Me.VerToolStripMenuItem.Text = "Ver"
		'
		'ConfiguraciónDelPuertoYLosDatosToolStripMenuItem
		'
		Me.ConfiguraciónDelPuertoYLosDatosToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
		Me.ConfiguraciónDelPuertoYLosDatosToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.ConfiguraciónDelPuertoYLosDatosToolStripMenuItem.Name = "ConfiguraciónDelPuertoYLosDatosToolStripMenuItem"
		Me.ConfiguraciónDelPuertoYLosDatosToolStripMenuItem.Size = New System.Drawing.Size(196, 22)
		Me.ConfiguraciónDelPuertoYLosDatosToolStripMenuItem.Text = "Configuración"
		'
		'DatosLogVarToolStripMenuItem1
		'
		Me.DatosLogVarToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
		Me.DatosLogVarToolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.DatosLogVarToolStripMenuItem1.Name = "DatosLogVarToolStripMenuItem1"
		Me.DatosLogVarToolStripMenuItem1.Size = New System.Drawing.Size(196, 22)
		Me.DatosLogVarToolStripMenuItem1.Text = "Datos"
		'
		'PIDDatosDeSimulaciónToolStripMenuItem
		'
		Me.PIDDatosDeSimulaciónToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
		Me.PIDDatosDeSimulaciónToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DatosSimulaToolStripMenuItem, Me.GráficoDeSimulaciónToolStripMenuItem})
		Me.PIDDatosDeSimulaciónToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.PIDDatosDeSimulaciónToolStripMenuItem.Name = "PIDDatosDeSimulaciónToolStripMenuItem"
		Me.PIDDatosDeSimulaciónToolStripMenuItem.Size = New System.Drawing.Size(196, 22)
		Me.PIDDatosDeSimulaciónToolStripMenuItem.Text = "PID ajuste y simulación"
		'
		'DatosSimulaToolStripMenuItem
		'
		Me.DatosSimulaToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
		Me.DatosSimulaToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.DatosSimulaToolStripMenuItem.Name = "DatosSimulaToolStripMenuItem"
		Me.DatosSimulaToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
		Me.DatosSimulaToolStripMenuItem.Text = "Datos"
		'
		'GráficoDeSimulaciónToolStripMenuItem
		'
		Me.GráficoDeSimulaciónToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
		Me.GráficoDeSimulaciónToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.GráficoDeSimulaciónToolStripMenuItem.Name = "GráficoDeSimulaciónToolStripMenuItem"
		Me.GráficoDeSimulaciónToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
		Me.GráficoDeSimulaciónToolStripMenuItem.Text = "Gráfico"
		'
		'ToolStripMenuItem1
		'
		Me.ToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
		Me.ToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AyudaToolStripMenuItem, Me.ToolStripSeparator2, Me.AcercaDeToolStripMenuItem})
		Me.ToolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
		Me.ToolStripMenuItem1.Size = New System.Drawing.Size(24, 20)
		Me.ToolStripMenuItem1.Text = "?"
		'
		'AyudaToolStripMenuItem
		'
		Me.AyudaToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
		Me.AyudaToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.AyudaToolStripMenuItem.Name = "AyudaToolStripMenuItem"
		Me.AyudaToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
		Me.AyudaToolStripMenuItem.Text = "Ayuda"
		'
		'ToolStripSeparator2
		'
		Me.ToolStripSeparator2.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
		Me.ToolStripSeparator2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.ToolStripSeparator2.Margin = New System.Windows.Forms.Padding(0, 0, 0, 1)
		Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
		Me.ToolStripSeparator2.Size = New System.Drawing.Size(177, 6)
		'
		'AcercaDeToolStripMenuItem
		'
		Me.AcercaDeToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
		Me.AcercaDeToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.AcercaDeToolStripMenuItem.Name = "AcercaDeToolStripMenuItem"
		Me.AcercaDeToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
		Me.AcercaDeToolStripMenuItem.Text = "Acerca de"
		'
		'GarikoitzinfoToolStripMenuItem
		'
		Me.GarikoitzinfoToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
		Me.GarikoitzinfoToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
		Me.GarikoitzinfoToolStripMenuItem.Enabled = False
		Me.GarikoitzinfoToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(153, Byte), Integer))
		Me.GarikoitzinfoToolStripMenuItem.Name = "GarikoitzinfoToolStripMenuItem"
		Me.GarikoitzinfoToolStripMenuItem.Size = New System.Drawing.Size(88, 20)
		Me.GarikoitzinfoToolStripMenuItem.Text = "garikoitz.info"
		'
		'ColorDialog1
		'
		Me.ColorDialog1.AnyColor = True
		Me.ColorDialog1.FullOpen = True
		'
		'Cbo_SincEjes
		'
		Me.Cbo_SincEjes.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
		Me.Cbo_SincEjes.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.Cbo_SincEjes.Name = "Cbo_SincEjes"
		Me.Cbo_SincEjes.Size = New System.Drawing.Size(140, 28)
		'
		'Form1
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
		Me.ClientSize = New System.Drawing.Size(1008, 743)
		Me.Controls.Add(Me.SplitContainer1)
		Me.Controls.Add(Me.DarkToolStrip1)
		Me.Controls.Add(Me.DarkMenuStrip1)
		Me.DoubleBuffered = True
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.KeyPreview = True
		Me.MainMenuStrip = Me.DarkMenuStrip1
		Me.Name = "Form1"
		Me.Text = "Arduino COM Plotter"
		Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
		Me.SplitContainer1.Panel1.ResumeLayout(False)
		Me.SplitContainer1.Panel2.ResumeLayout(False)
		CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.SplitContainer1.ResumeLayout(False)
		Me.SplitContainer2.Panel1.ResumeLayout(False)
		Me.SplitContainer2.Panel2.ResumeLayout(False)
		CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
		Me.SplitContainer2.ResumeLayout(False)
		Me.DarkSectionPanel7.ResumeLayout(False)
		Me.DarkGroupBox1.ResumeLayout(False)
		Me.DarkGroupBox1.PerformLayout()
		CType(Me.num_ventana, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.Num_vars, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.Num_delay, System.ComponentModel.ISupportInitialize).EndInit()
		Me.DarkGroupBox2.ResumeLayout(False)
		Me.DarkGroupBox2.PerformLayout()
		Me.DarkStatusStrip1.ResumeLayout(False)
		Me.DarkStatusStrip1.PerformLayout()
		Me.SplitContainer3.Panel1.ResumeLayout(False)
		Me.SplitContainer3.Panel2.ResumeLayout(False)
		CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).EndInit()
		Me.SplitContainer3.ResumeLayout(False)
		Me.DarkSectionPanel4.ResumeLayout(False)
		Me.SplitContainer4.Panel1.ResumeLayout(False)
		Me.SplitContainer4.Panel2.ResumeLayout(False)
		CType(Me.SplitContainer4, System.ComponentModel.ISupportInitialize).EndInit()
		Me.SplitContainer4.ResumeLayout(False)
		Me.DarkSectionPanel5.ResumeLayout(False)
		Me.DarkSectionPanel6.ResumeLayout(False)
		CType(Me.dgv_vars, System.ComponentModel.ISupportInitialize).EndInit()
		Me.DarkSectionPanel1.ResumeLayout(False)
		Me.SplitContainer5.Panel1.ResumeLayout(False)
		Me.SplitContainer5.Panel2.ResumeLayout(False)
		CType(Me.SplitContainer5, System.ComponentModel.ISupportInitialize).EndInit()
		Me.SplitContainer5.ResumeLayout(False)
		Me.DarkSectionPanel2.ResumeLayout(False)
		Me.DarkSectionPanel2.PerformLayout()
		Me.DarkGroupBox5.ResumeLayout(False)
		Me.DarkGroupBox5.PerformLayout()
		Me.DarkSectionPanel3.ResumeLayout(False)
		Me.DarkGroupBox4.ResumeLayout(False)
		Me.DarkGroupBox4.PerformLayout()
		Me.DarkGroupBox3.ResumeLayout(False)
		Me.DarkGroupBox3.PerformLayout()
		Me.SplitContainer6.Panel1.ResumeLayout(False)
		Me.SplitContainer6.Panel2.ResumeLayout(False)
		CType(Me.SplitContainer6, System.ComponentModel.ISupportInitialize).EndInit()
		Me.SplitContainer6.ResumeLayout(False)
		CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.DarkToolStrip2.ResumeLayout(False)
		Me.DarkToolStrip2.PerformLayout()
		CType(Me.Chart_simula, System.ComponentModel.ISupportInitialize).EndInit()
		Me.DarkToolStrip3.ResumeLayout(False)
		Me.DarkToolStrip3.PerformLayout()
		Me.DarkStatusStrip2.ResumeLayout(False)
		Me.DarkStatusStrip2.PerformLayout()
		Me.DarkToolStrip1.ResumeLayout(False)
		Me.DarkToolStrip1.PerformLayout()
		Me.DarkMenuStrip1.ResumeLayout(False)
		Me.DarkMenuStrip1.PerformLayout()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents SplitContainer1 As SplitContainer
	Friend WithEvents SplitContainer2 As SplitContainer
	Friend WithEvents GroupBox1 As GroupBox
	Friend WithEvents Label1 As Label
	Friend WithEvents Label2 As Label
	Friend WithEvents Timer1 As Timer
	Friend WithEvents SplitContainer3 As SplitContainer
	Friend WithEvents Txt_datos As RichTextBox
	Friend WithEvents ToolTip1 As ToolTip
	Friend WithEvents dgv_vars As DataGridView
	Friend WithEvents btn_abrir As ToolStripButton
	Friend WithEvents Btn_conectarDark As DarkUI.Controls.DarkButton
	Friend WithEvents Btn_desconectarDark As DarkUI.Controls.DarkButton
	Friend WithEvents DarkStatusStrip1 As DarkUI.Controls.DarkStatusStrip
	Friend WithEvents Lbl_lineas As ToolStripStatusLabel
	Friend WithEvents DarkStatusStrip2 As DarkUI.Controls.DarkStatusStrip
	Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
	Friend WithEvents Lbl_info As ToolStripStatusLabel
	Friend WithEvents DarkToolStrip1 As DarkUI.Controls.DarkToolStrip
	Friend WithEvents ToolStripLabel5 As ToolStripLabel
	Friend WithEvents ToolStripLabel6 As ToolStripLabel
	Friend WithEvents Cbo_comports As DarkUI.Controls.DarkComboBox
	Friend WithEvents DarkGroupBox1 As DarkUI.Controls.DarkGroupBox
	Friend WithEvents Label7 As Label
	Friend WithEvents lbl_inicio As Label
	Friend WithEvents Label6 As Label
	Friend WithEvents lbl_separador As Label
	Friend WithEvents Label5 As Label
	Friend WithEvents Label4 As Label
	Friend WithEvents Label3 As Label
	Friend WithEvents DarkGroupBox2 As DarkUI.Controls.DarkGroupBox
	Friend WithEvents Num_delay As DarkUI.Controls.DarkNumericUpDown
	Friend WithEvents Num_vars As DarkUI.Controls.DarkNumericUpDown
	Friend WithEvents num_ventana As DarkUI.Controls.DarkNumericUpDown
	Friend WithEvents txt_separador As DarkUI.Controls.DarkTextBox
	Friend WithEvents txt_inicio As DarkUI.Controls.DarkTextBox
	Friend WithEvents Cbo_velocidad_2 As DarkUI.Controls.DarkComboBox
	Friend WithEvents Btn_reset As ToolStripButton
	Friend WithEvents DarkSectionPanel1 As DarkUI.Controls.DarkSectionPanel
	Friend WithEvents SplitContainer5 As SplitContainer
	Friend WithEvents DarkSectionPanel2 As DarkUI.Controls.DarkSectionPanel
	Friend WithEvents DarkSectionPanel3 As DarkUI.Controls.DarkSectionPanel
	Friend WithEvents Tv_metodos As DarkUI.Controls.DarkTreeView
	Friend WithEvents DarkGroupBox4 As DarkUI.Controls.DarkGroupBox
	Friend WithEvents Txt_OPLimInf As DarkUI.Controls.DarkTextBox
	Friend WithEvents Txt_OPLimSup As DarkUI.Controls.DarkTextBox
	Friend WithEvents Txt_Dcarga As DarkUI.Controls.DarkTextBox
	Friend WithEvents Txt_DSP As DarkUI.Controls.DarkTextBox
	Friend WithEvents Txt_CargaIni As DarkUI.Controls.DarkTextBox
	Friend WithEvents Txt_OPini As DarkUI.Controls.DarkTextBox
	Friend WithEvents Txt_PVini As DarkUI.Controls.DarkTextBox
	Friend WithEvents Txt_Tfinal As DarkUI.Controls.DarkTextBox
	Friend WithEvents Txt_muestreo As DarkUI.Controls.DarkTextBox
	Friend WithEvents DarkGroupBox3 As DarkUI.Controls.DarkGroupBox
	Friend WithEvents Txt_Td As DarkUI.Controls.DarkTextBox
	Friend WithEvents Txt_Ti As DarkUI.Controls.DarkTextBox
	Friend WithEvents Txt_Kc As DarkUI.Controls.DarkTextBox
	Friend WithEvents Txt_PVrngInf As DarkUI.Controls.DarkTextBox
	Friend WithEvents Txt_PVrngSup As DarkUI.Controls.DarkTextBox
	Friend WithEvents DarkGroupBox5 As DarkUI.Controls.DarkGroupBox
	Friend WithEvents Txt_Tf As DarkUI.Controls.DarkTextBox
	Friend WithEvents Txt_Tp As DarkUI.Controls.DarkTextBox
	Friend WithEvents Txt_To As DarkUI.Controls.DarkTextBox
	Friend WithEvents Txt_K As DarkUI.Controls.DarkTextBox
	Friend WithEvents DarkLabel4 As DarkUI.Controls.DarkLabel
	Friend WithEvents DarkLabel3 As DarkUI.Controls.DarkLabel
	Friend WithEvents DarkLabel2 As DarkUI.Controls.DarkLabel
	Friend WithEvents DarkLabel1 As DarkUI.Controls.DarkLabel
	Friend WithEvents DarkLabel7 As DarkUI.Controls.DarkLabel
	Friend WithEvents DarkLabel8 As DarkUI.Controls.DarkLabel
	Friend WithEvents DarkLabel9 As DarkUI.Controls.DarkLabel
	Friend WithEvents DarkLabel6 As DarkUI.Controls.DarkLabel
	Friend WithEvents DarkLabel5 As DarkUI.Controls.DarkLabel
	Friend WithEvents DarkLabel15 As DarkUI.Controls.DarkLabel
	Friend WithEvents DarkLabel14 As DarkUI.Controls.DarkLabel
	Friend WithEvents DarkLabel13 As DarkUI.Controls.DarkLabel
	Friend WithEvents DarkLabel11 As DarkUI.Controls.DarkLabel
	Friend WithEvents DarkLabel10 As DarkUI.Controls.DarkLabel
	Friend WithEvents DarkLabel18 As DarkUI.Controls.DarkLabel
	Friend WithEvents DarkLabel12 As DarkUI.Controls.DarkLabel
	Friend WithEvents DarkLabel17 As DarkUI.Controls.DarkLabel
	Friend WithEvents DarkLabel16 As DarkUI.Controls.DarkLabel
	Friend WithEvents SplitContainer6 As SplitContainer
	Friend WithEvents Chart1 As DataVisualization.Charting.Chart
	Friend WithEvents DarkToolStrip2 As DarkUI.Controls.DarkToolStrip
	Friend WithEvents btn_captura As ToolStripButton
	Friend WithEvents ToolStripLabel1 As ToolStripLabel
	Friend WithEvents Btn_ampliarTiempo As ToolStripButton
	Friend WithEvents Chart_simula As DataVisualization.Charting.Chart
	Friend WithEvents Btn_guardarP As ToolStripButton
	Friend WithEvents Btn_exportarP As ToolStripButton
	Friend WithEvents DarkMenuStrip1 As DarkUI.Controls.DarkMenuStrip
	Friend WithEvents ArchivoToolStripMenuItem As ToolStripMenuItem
	Friend WithEvents SalirToolStripMenuItem As ToolStripMenuItem
	Friend WithEvents VerToolStripMenuItem As ToolStripMenuItem
	Friend WithEvents PIDDatosDeSimulaciónToolStripMenuItem As ToolStripMenuItem
	Friend WithEvents DarkToolStrip3 As DarkUI.Controls.DarkToolStrip
	Friend WithEvents Btn_captura_simula As ToolStripButton
	Friend WithEvents ConfiguraciónDelPuertoYLosDatosToolStripMenuItem As ToolStripMenuItem
	Friend WithEvents ToolStripLabel2 As ToolStripLabel
	Friend WithEvents Btn_ampliarTiempo_simula As ToolStripButton
	Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
	Friend WithEvents AcercaDeToolStripMenuItem As ToolStripMenuItem
	Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
	Friend WithEvents AyudaToolStripMenuItem As ToolStripMenuItem
	Friend WithEvents DarkSectionPanel4 As DarkUI.Controls.DarkSectionPanel
	Friend WithEvents SplitContainer4 As SplitContainer
	Friend WithEvents DarkSectionPanel5 As DarkUI.Controls.DarkSectionPanel
	Friend WithEvents DarkSectionPanel6 As DarkUI.Controls.DarkSectionPanel
	Friend WithEvents DarkSectionPanel7 As DarkUI.Controls.DarkSectionPanel
	Friend WithEvents DatosLogVarToolStripMenuItem1 As ToolStripMenuItem
	Friend WithEvents GráficoDeSimulaciónToolStripMenuItem As ToolStripMenuItem
	Friend WithEvents DatosSimulaToolStripMenuItem As ToolStripMenuItem
	Friend WithEvents Btn_calc_sis As DarkUI.Controls.DarkButton
	Friend WithEvents GarikoitzinfoToolStripMenuItem As ToolStripMenuItem
	Friend WithEvents Cbo_eq As DarkUI.Controls.DarkComboBox
	Friend WithEvents DarkLabel20 As DarkUI.Controls.DarkLabel
	Friend WithEvents DarkLabel19 As DarkUI.Controls.DarkLabel
	Friend WithEvents Txt_Kd As DarkUI.Controls.DarkTextBox
	Friend WithEvents Txt_Ki As DarkUI.Controls.DarkTextBox
	Friend WithEvents Btn_sintonias As DarkUI.Controls.DarkButton
	Friend WithEvents Btn_calc_sismin As DarkUI.Controls.DarkButton
	Friend WithEvents txtdebug As RichTextBox
	Friend WithEvents Cmd_enviar As DarkUI.Controls.DarkButton
	Friend WithEvents Txt_enviar As DarkUI.Controls.DarkTextBox
	Friend WithEvents ColorDialog1 As ColorDialog
	Friend WithEvents ToolStripLabel3 As ToolStripLabel
	Friend WithEvents Cbo_metodos_sim As ToolStripComboBox
	Friend WithEvents Btn_simular2 As DarkUI.Controls.DarkButton
	Friend WithEvents Cbo_SincEjes As ToolStripComboBox
End Class
