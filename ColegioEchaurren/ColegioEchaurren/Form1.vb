Public Class Form1

    Public varColumnaRutHistorico As String
    Public varFichaPersonalAlumno As String
    Public varUsuarioActual As String
    Public varTipoUsuario As String

    Private Sub LoginToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoginToolStripMenuItem.Click
        If LoginToolStripMenuItem.Text = "Iniciar Sesión" Then
            LoginForm1.MdiParent = Me
            LoginForm1.Show()
        Else
            If MessageBox.Show("¿Está seguro(a) de querer cerrar la sesión?", "¡Alerta!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
                For Each ChildForm As Form In Me.MdiChildren
                    ChildForm.Close()
                Next
                MatriculasToolStripMenuItem.Enabled = False
                FinanzasToolStripMenuItem.Enabled = False
                AdministracionToolStripMenuItem.Enabled = False
                DocumentosToolStripMenuItem.Enabled = False
                UsuariosToolStripMenuItem.Enabled = False
                LoginToolStripMenuItem.Text = "Iniciar Sesión"
            End If
        End If
    End Sub

    Private Sub CrearMatriculaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CrearMatriculaToolStripMenuItem.Click
        FormularioMatricula.Show()
    End Sub

    Private Sub AlumnosMatriculadosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AlumnosMatriculadosToolStripMenuItem.Click
        FormAlumnosMatriculados.MdiParent = Me
        FormAlumnosMatriculados.Show()
    End Sub

    Private Sub AcercaDeToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AcercaDeToolStripMenuItem2.Click
        AboutBox1.MdiParent = Me
        AboutBox1.Show()
    End Sub

    Private Sub RealizarPagoToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RealizarPagoToolStripMenuItem.Click
        RealizarPago.MdiParent = Me
        RealizarPago.Show()
    End Sub

    Private Sub RegistroDeMensualidadesToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RegistroDeMensualidadesToolStripMenuItem.Click
        AdminMensualidades.MdiParent = Me
        AdminMensualidades.Show()
    End Sub

    Private Sub AdministrarBecasToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AdministrarBecasToolStripMenuItem.Click
        AdminBecas.MdiParent = Me
        AdminBecas.Show()
    End Sub

    Private Sub CambiarContraseñaToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CambiarContraseñaToolStripMenuItem.Click
        CambiarPass.MdiParent = Me
        CambiarPass.Show()
    End Sub

    Private Sub EscanearDocumentosToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles EscanearDocumentosToolStripMenuItem.Click
        EscanearDocs.MdiParent = Me
        EscanearDocs.Show()
    End Sub

    Private Sub ImprimirPlanillasToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ImprimirPlanillasToolStripMenuItem.Click
        ImprimirPlanillas.MdiParent = Me
        ImprimirPlanillas.Show()
    End Sub

    Private Sub GestionarUsuariosToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles GestionarUsuariosToolStripMenuItem.Click
        GestordeUsuarios.MdiParent = Me
        GestordeUsuarios.Show()
    End Sub

    Private Sub Form1_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Presentacion.Close()
    End Sub

    Private Sub AcercaDeToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles AcercaDeToolStripMenuItem1.Click
        Ayuda.MdiParent = Me
        Ayuda.Show()
    End Sub
End Class
