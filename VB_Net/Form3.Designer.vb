<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form3
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
		Me.Panel1 = New System.Windows.Forms.Panel()
		Me.DarkButton1 = New DarkUI.Controls.DarkButton()
		Me.Lbl_version = New DarkUI.Controls.DarkLabel()
		Me.DarkTitle1 = New DarkUI.Controls.DarkTitle()
		Me.Pb_logo = New System.Windows.Forms.PictureBox()
		Me.Panel2 = New System.Windows.Forms.Panel()
		Me.PbGPL = New System.Windows.Forms.PictureBox()
		Me.TV_about = New DarkUI.Controls.DarkTreeView()
		Me.Panel1.SuspendLayout()
		CType(Me.Pb_logo, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.Panel2.SuspendLayout()
		CType(Me.PbGPL, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'Panel1
		'
		Me.Panel1.Controls.Add(Me.DarkButton1)
		Me.Panel1.Controls.Add(Me.Lbl_version)
		Me.Panel1.Controls.Add(Me.DarkTitle1)
		Me.Panel1.Controls.Add(Me.Pb_logo)
		Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
		Me.Panel1.Location = New System.Drawing.Point(0, 0)
		Me.Panel1.Name = "Panel1"
		Me.Panel1.Size = New System.Drawing.Size(459, 55)
		Me.Panel1.TabIndex = 1
		'
		'DarkButton1
		'
		Me.DarkButton1.Location = New System.Drawing.Point(427, 0)
		Me.DarkButton1.Name = "DarkButton1"
		Me.DarkButton1.Padding = New System.Windows.Forms.Padding(5)
		Me.DarkButton1.Size = New System.Drawing.Size(32, 32)
		Me.DarkButton1.TabIndex = 2
		Me.DarkButton1.Text = "X"
		'
		'Lbl_version
		'
		Me.Lbl_version.AutoSize = True
		Me.Lbl_version.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
		Me.Lbl_version.Location = New System.Drawing.Point(387, 27)
		Me.Lbl_version.Name = "Lbl_version"
		Me.Lbl_version.Size = New System.Drawing.Size(22, 13)
		Me.Lbl_version.TabIndex = 1
		Me.Lbl_version.Text = "1.0"
		'
		'DarkTitle1
		'
		Me.DarkTitle1.AutoSize = True
		Me.DarkTitle1.Enabled = False
		Me.DarkTitle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.DarkTitle1.Location = New System.Drawing.Point(77, 9)
		Me.DarkTitle1.Name = "DarkTitle1"
		Me.DarkTitle1.Size = New System.Drawing.Size(313, 37)
		Me.DarkTitle1.TabIndex = 1
		Me.DarkTitle1.Text = "Arduino COM Plotter"
		'
		'Pb_logo
		'
		Me.Pb_logo.Image = Global.Arduino_COM_Plotter.My.Resources.Resources.arduinouno_icon
		Me.Pb_logo.Location = New System.Drawing.Point(15, 0)
		Me.Pb_logo.Name = "Pb_logo"
		Me.Pb_logo.Size = New System.Drawing.Size(56, 55)
		Me.Pb_logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
		Me.Pb_logo.TabIndex = 0
		Me.Pb_logo.TabStop = False
		'
		'Panel2
		'
		Me.Panel2.Controls.Add(Me.PbGPL)
		Me.Panel2.Controls.Add(Me.TV_about)
		Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
		Me.Panel2.Location = New System.Drawing.Point(0, 55)
		Me.Panel2.Name = "Panel2"
		Me.Panel2.Size = New System.Drawing.Size(459, 226)
		Me.Panel2.TabIndex = 2
		'
		'PbGPL
		'
		Me.PbGPL.Image = Global.Arduino_COM_Plotter.My.Resources.Resources.gplv3_with_text_136x68
		Me.PbGPL.Location = New System.Drawing.Point(345, 155)
		Me.PbGPL.Name = "PbGPL"
		Me.PbGPL.Size = New System.Drawing.Size(102, 59)
		Me.PbGPL.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
		Me.PbGPL.TabIndex = 2
		Me.PbGPL.TabStop = False
		'
		'TV_about
		'
		Me.TV_about.Dock = System.Windows.Forms.DockStyle.Fill
		Me.TV_about.Location = New System.Drawing.Point(0, 0)
		Me.TV_about.MaxDragChange = 20
		Me.TV_about.Name = "TV_about"
		Me.TV_about.Size = New System.Drawing.Size(459, 226)
		Me.TV_about.TabIndex = 3
		Me.TV_about.Text = "DarkTreeView1"
		'
		'Form3
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
		Me.ClientSize = New System.Drawing.Size(459, 281)
		Me.Controls.Add(Me.Panel2)
		Me.Controls.Add(Me.Panel1)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
		Me.Name = "Form3"
		Me.ShowIcon = False
		Me.ShowInTaskbar = False
		Me.Text = "Form3"
		Me.TopMost = True
		Me.Panel1.ResumeLayout(False)
		Me.Panel1.PerformLayout()
		CType(Me.Pb_logo, System.ComponentModel.ISupportInitialize).EndInit()
		Me.Panel2.ResumeLayout(False)
		CType(Me.PbGPL, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)

	End Sub
	Friend WithEvents Panel1 As Panel
	Friend WithEvents Panel2 As Panel
	Friend WithEvents Pb_logo As PictureBox
	Friend WithEvents DarkTitle1 As DarkUI.Controls.DarkTitle
	Friend WithEvents PbGPL As PictureBox
	Friend WithEvents Lbl_version As DarkUI.Controls.DarkLabel
	Friend WithEvents DarkButton1 As DarkUI.Controls.DarkButton
	Friend WithEvents TV_about As DarkUI.Controls.DarkTreeView
End Class
