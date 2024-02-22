Imports System.Runtime.InteropServices
Imports DarkUI.Controls

Public Class Form3
    Public Const WM_NCLBUTTONDOWN As Integer = &HA1
    Public Const HT_CAPTION As Integer = &H2

    <DllImportAttribute("user32.dll")>
    Public Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal Msg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
    End Function

    <DllImportAttribute("user32.dll")>
    Public Shared Function ReleaseCapture() As Boolean
    End Function
    Private Sub Form3_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown, Panel1.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            ReleaseCapture()
            SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0)
        End If
    End Sub
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With My.Application.Info.Version
            Lbl_version.Text = .Major.ToString & "." & .Minor.ToString
        End With
        '
        Dim root = New DarkTreeNode("Historial de cambios")
        TV_about.Nodes.Add(root)
        TV_about.Nodes(0).Nodes.Add(New DarkTreeNode("0.6"))
        TV_about.Nodes(0).Nodes(0).Nodes.Add(New DarkTreeNode("- Añadida posibilidad de enviar comandos serial."))
        TV_about.Nodes(0).Nodes(0).Nodes.Add(New DarkTreeNode("- Añadida posibilidad de cambiar de color las series mediante clic derecho en la leyenda."))
        TV_about.Nodes(0).Nodes(0).Nodes.Add(New DarkTreeNode("- Añadida posibilidad de mover series entre el eje primario y secundario."))
        TV_about.Nodes(0).Nodes(0).Nodes.Add(New DarkTreeNode("- Añadida posibilidad de separar las series en dos áreas. Los ejes de las áreas está relacionados."))
        TV_about.Nodes(0).Nodes(0).Nodes.Add(New DarkTreeNode("- Cambiada la forma de seleccionar el método de sintonía en Simulación."))
        TV_about.Nodes(0).Nodes(0).Nodes.Add(New DarkTreeNode("- Añadida posibilidad de aumentar o disminuir los valores de Kc, Ti, Td, Ki y Kd con la rueda del ratón."))
        TV_about.Nodes(0).Nodes.Add(New DarkTreeNode("0.5"))
        TV_about.Nodes(0).Nodes(1).Nodes.Add(New DarkTreeNode("- Corrección de errores en el cálculo de la simulación."))
        TV_about.Nodes(0).Nodes(1).Nodes.Add(New DarkTreeNode("- Corrección de errores en el cálculo de K, T0 y Tp cuando el delay era diferente de 1 segundo."))
        TV_about.Nodes(0).Nodes.Add(New DarkTreeNode("0.41"))
        TV_about.Nodes(0).Nodes(2).Nodes.Add(New DarkTreeNode("- Corrección de errores en las escalas de los ejes."))
        TV_about.Nodes(0).Nodes.Add(New DarkTreeNode("0.4"))
        TV_about.Nodes(0).Nodes(3).Nodes.Add(New DarkTreeNode("- Ahora se pueden cambiar las escalas de los ejes Y primario y secundario situándose encima y girando la rueda del mouse."))
        TV_about.Nodes(0).Nodes(3).Nodes.Add(New DarkTreeNode("- También se pueden mover las series situando el ratón sobre el eje Y y pulsando las flechas de arriba y abajo."))
        TV_about.Nodes(0).Nodes(3).Nodes.Add(New DarkTreeNode("- Haciendo clic sobre el eje Y nos pregunta el mínimo y máximo."))
        TV_about.Nodes(0).Nodes(3).Nodes.Add(New DarkTreeNode("- Corrección de errores y optimización de código."))
        TV_about.Nodes(0).Nodes.Add(New DarkTreeNode("0.3"))
        TV_about.Nodes(0).Nodes(4).Nodes.Add(New DarkTreeNode("- Se pueden ocultar paneles y el gráfico de simulación."))
        TV_about.Nodes(0).Nodes(4).Nodes.Add(New DarkTreeNode("- Se incorpora el cálculo de K, To y Tp."))
        TV_about.Nodes(0).Nodes(4).Nodes.Add(New DarkTreeNode("- Se pueden hacer anotaciones de texto sobre las series del gráfico."))
        TV_about.Nodes(0).Nodes(4).Nodes.Add(New DarkTreeNode("- Corrección de errores."))
        TV_about.Nodes(0).Nodes.Add(New DarkTreeNode("0.2"))
        TV_about.Nodes(0).Nodes(5).Nodes.Add(New DarkTreeNode("- Se puede guardar el proyecto."))
        TV_about.Nodes(0).Nodes(5).Nodes.Add(New DarkTreeNode("- Se puede hacer una captura de la gráfica."))
        TV_about.Nodes(0).Nodes(5).Nodes.Add(New DarkTreeNode("- Se puede ver la línea de tiempo completa."))
        TV_about.Nodes(0).Nodes(5).Nodes.Add(New DarkTreeNode("- Se puede configurar la ventana de tiempo de visualización de la captura."))
        TV_about.Nodes(0).Nodes(5).Nodes.Add(New DarkTreeNode("- Se incorpora la parte de PID Ajuste y Simulación"))
        TV_about.Nodes(0).Nodes.Add(New DarkTreeNode("0.1"))
        TV_about.Nodes(0).Nodes(6).Nodes.Add(New DarkTreeNode("- Comienza la aventura."))
    End Sub
    Private Sub DarkButton1_Click(sender As Object, e As EventArgs) Handles DarkButton1.Click
        Me.Close()
    End Sub
    Private Sub PbGPL_DoubleClick(sender As Object, e As EventArgs) Handles PbGPL.DoubleClick
        Process.Start("https://www.gnu.org/licenses/gpl-3.0.html")
    End Sub
End Class