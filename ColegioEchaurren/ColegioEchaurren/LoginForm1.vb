Public Class LoginForm1

    ' TODO: inserte el código para realizar autenticación personalizada usando el nombre de usuario y la contraseña proporcionada 
    ' (Consulte http://go.microsoft.com/fwlink/?LinkId=35339).  
    ' El objeto principal personalizado se puede adjuntar al objeto principal del subproceso actual como se indica a continuación: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' donde CustomPrincipal es la implementación de IPrincipal utilizada para realizar la autenticación. 
    ' Posteriormente, My.User devolverá la información de identidad encapsulada en el objeto CustomPrincipal
    ' como el nombre de usuario, nombre para mostrar, etc.

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        If UsernameTextBox.Text = "admin" Then
            Form1.MatriculasToolStripMenuItem.Enabled = True
            Form1.FinanzasToolStripMenuItem.Enabled = True
            Form1.AdministracionToolStripMenuItem.Enabled = True
            Form1.RecursosHumanosToolStripMenuItem.Enabled = True
            Form1.LoginToolStripMenuItem.Text = "Cerrar Sesión"
            Me.Close()
        ElseIf UsernameTextBox.Text = "asistente" Then
            Form1.MatriculasToolStripMenuItem.Enabled = True
            Form1.AdministracionToolStripMenuItem.Enabled = True
            Form1.LoginToolStripMenuItem.Text = "Cerrar Sesión"
            Me.Close()
        Else
            MessageBox.Show("Usuario y/o contraseña incorrecto(s)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            UsernameTextBox.Text = ""
            PasswordTextBox.Text = ""
            UsernameTextBox.Focus()
        End If
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub
End Class
