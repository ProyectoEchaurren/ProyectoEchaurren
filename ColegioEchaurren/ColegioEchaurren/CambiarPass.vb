Public Class CambiarPass

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        If txtPassActual.Text <> "" Or txtNewPass1.Text <> "" Or txtNewPass2.Text <> "" Then
            If MessageBox.Show("¿Desea cancelar la operación y salir?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
                Me.Close()
            End If
        Else
            Me.Close()
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        If ModuloContenedor.CambiarPassword(txtPassActual.Text, txtNewPass1.Text, txtNewPass2.Text, Form1.varUsuarioActual) = True Then
            MessageBox.Show("Contraseña cambiada exitosamente.", "Colegio Echaurren", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtPassActual.Text = ""
            txtNewPass1.Text = ""
            txtNewPass2.Text = ""
        End If
    End Sub
End Class