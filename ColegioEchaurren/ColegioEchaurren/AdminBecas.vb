Public Class AdminBecas

    Public varOldBeca As String
    Public varOldPorcentaje As Integer
    Public varIdFicha As Integer

    Private Sub txtCampoRut_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCampoRut.KeyPress
        If InStr(1, "0123456789,-,K,k" & Chr(8) & Chr(13), e.KeyChar) = 0 Then
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
        cbbNewPorcentaje.Text = ""
        cbbNewPorcentaje.Enabled = False
        btnDeshacer.Enabled = False
        txtCampoRut.Focus()
    End Sub

    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        If cbbNewBeca.Text <> "" And cbbNewPorcentaje.Text <> "" Then
            If MessageBox.Show("¿Está seguro(a) de salir sin guardar?", "¡Alerta!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
                Me.Close()
            End If
        Else
            Me.Close()
        End If
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles btnDeshacer.Click
        If cbbNewBeca.Text <> "" And cbbNewPorcentaje.Text <> "" Then
            cbbNewBeca.Text = ""
            cbbNewPorcentaje.Text = ""
            cbbNewBeca.Enabled = True
            cbbNewPorcentaje.Enabled = True
            ModuloContenedor.GuardarCambiosBecas(varOldBeca, varOldPorcentaje, varIdFicha)
            If ModuloContenedor.GuardarCambiosBecas(varOldBeca, varOldPorcentaje, varIdFicha) = True Then
                MessageBox.Show("Cambios deshechos exitosamente.")
            End If
        Else
            MsgBox("No ha realizado ningun cambio que deshacer.", MsgBoxStyle.Information, AcceptButton)
        End If
    End Sub

    Private Sub cbbNewBeca_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbbNewBeca.SelectedIndexChanged
        If cbbNewBeca.SelectedIndex = "2" Then
            cbbNewPorcentaje.Text = "0"
            cbbNewPorcentaje.Enabled = False
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        If cbbNewBeca.Text <> "" And cbbNewPorcentaje.Text <> "" Then
            ModuloContenedor.GuardarCambiosBecas(cbbNewBeca.Text, cbbNewPorcentaje.Text, varIdFicha)
            If ModuloContenedor.GuardarCambiosBecas(cbbNewBeca.Text, cbbNewPorcentaje.Text, varIdFicha) = True Then
                MessageBox.Show("Cambios guardados exitosamente.")
            End If
        Else
            MsgBox("No ha realizado ningun cambio que guardar.", MsgBoxStyle.Information, AcceptButton)
        End If
    End Sub
End Class