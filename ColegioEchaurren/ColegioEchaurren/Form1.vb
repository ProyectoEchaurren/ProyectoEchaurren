Public Class Form1

    Private Sub FinanzasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FinanzasToolStripMenuItem.Click

    End Sub

    Private Sub LoginToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoginToolStripMenuItem.Click
        If LoginToolStripMenuItem.Text = "Login" Then
            LoginForm1.MdiParent = Me
            LoginForm1.Show()
        Else
            If MessageBox.Show("¿Está seguro(a) de querer cerrar la sesión?", "¡Alerta!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
                MatriculasToolStripMenuItem.Enabled = False
                FinanzasToolStripMenuItem.Enabled = False
                AdministracionToolStripMenuItem.Enabled = False
                RecursosHumanosToolStripMenuItem.Enabled = False
                LoginToolStripMenuItem.Text = "Login"
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
End Class
