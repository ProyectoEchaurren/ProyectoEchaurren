Public Class AdminBecas

    Private Sub txtCampoRut_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCampoRut.KeyPress
        If InStr(1, "0123456789,-" & Chr(8) & Chr(13), e.KeyChar) = 0 Then
            e.KeyChar = ""
            e.Handled = True
            MsgBox("Porfavor ingresar sólo dígitos y guión")
        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            e.Handled = True
            If ComprobarRut(txtCampoRut.Text) = False Then
                MsgBox("El Rut ingresado no es valido")
                txtCampoRut.Focus()
            Else
                BuscarRutBecas(txtCampoRut.Text)
                My.Computer.Keyboard.SendKeys("{tab}", True)
            End If
        End If
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        txtCampoRut.Text = ""
        txtNombre.Text = ""
        txtBeca.Text = ""
        txtPorcentaje.Text = ""
        cbbNewBeca.Text = ""
        cbbNewBeca.Enabled = False
        txtNewPorcentaje.Text = ""
        txtNewPorcentaje.Enabled = False
        txtCampoRut.Focus()
    End Sub

    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        If txtCampoRut.Text = "" And txtNombre.Text = "" And txtBeca.Text = "" And txtPorcentaje.Text = "" Then
            Me.Close()
        Else
            If MessageBox.Show("¿Está seguro(a) de salir sin guardar?", "¡Alerta!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
                Me.Close()
            End If
        End If
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles btnDeshacer.Click
        cbbNewBeca.Text = ""
        txtNewPorcentaje.Text = ""
    End Sub

    Private Sub cbbNewBeca_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbbNewBeca.SelectedIndexChanged
        If cbbNewBeca.SelectedIndex = "2" Then
            txtNewPorcentaje.Text = "0%"
        End If
    End Sub
End Class