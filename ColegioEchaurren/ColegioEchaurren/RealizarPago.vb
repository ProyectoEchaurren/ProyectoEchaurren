Public Class RealizarPago
    Private Sub txtCampoRut_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCampoRut.KeyPress
        If InStr(1, "0123456789,-" & Chr(8) & Chr(13), e.KeyChar) = 0 Then
            e.KeyChar = ""
            e.Handled = True
            MsgBox("Porfavor ingresar sólo dígitos y guión")
        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            e.Handled = True

            ComprobarRut(txtCampoRut.Text)
            If ComprobarRut(txtCampoRut.Text) = False Then
                MsgBox("El Rut ingresado no es valido")
                txtCampoRut.Focus()
            Else
                My.Computer.Keyboard.SendKeys("{tab}", True)
            End If
        End If
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        txtCampoRut.Text = ""
        txtNombre.Text = ""
        txtBeca.Text = ""
        txtTipoPago.Text = ""
        txtPorcentaje.Text = ""
        txtMontoMensual.Text = ""
        txtMontoTotal.Text = ""
        txtCampoRut.Focus()
    End Sub

End Class