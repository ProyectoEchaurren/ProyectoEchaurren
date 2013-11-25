Public Class Form1

    Public ColumnaRutHistorico As String
    Public FichaPersonalAlumno As String

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
                RecursosHumanosToolStripMenuItem.Enabled = False
                LoginToolStripMenuItem.Text = "Iniciar Sesión"
            End If
        End If
    End Sub

    Private Sub AcercaDeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AdministracionToolStripMenuItem.Click

    End Sub

    Private Sub CrearMatriculaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CrearMatriculaToolStripMenuItem.Click
        FormularioMatricula.MdiParent = Me
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
End Class
