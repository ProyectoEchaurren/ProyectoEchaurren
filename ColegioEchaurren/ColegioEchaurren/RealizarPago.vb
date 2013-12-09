Imports MySql.Data.MySqlClient
Public Class RealizarPago

    Public varMesesCheck As Integer = 0
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
                variableTotalMeses(txtCampoRut.Text)
                BuscarRutRealizarPago(txtCampoRut.Text, ModuloContenedor.varTotal)
                My.Computer.Keyboard.SendKeys("{tab}", True)
            End If
        End If
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles btnLimpiar.Click
        txtCampoRut.Text = ""
        txtNombre.Text = ""
        txtBeca.Text = ""
        txtTipoPago.Text = ""
        txtPorcentaje.Text = ""
        txtMontoMensual.Text = ""
        txtMontoTotal.Text = ""
        varMesesCheck = 0
        txtCampoRut.Focus()
    End Sub

    Private Sub checkMarzo_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles checkMarzo.CheckedChanged
        If checkMarzo.Checked = True And checkMarzo.Enabled = True Then
            varMesesCheck = varMesesCheck + 1
            txtMontoTotal.Text = (txtMontoMensual.Text * varMesesCheck) * (txtPorcentaje.Text / 100)
        Else
            varMesesCheck = varMesesCheck - 1
            txtMontoTotal.Text = (txtMontoMensual.Text * varMesesCheck) * (txtPorcentaje.Text / 100)
        End If
    End Sub

    Private Sub checkAbril_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles checkAbril.CheckedChanged
        If checkAbril.Checked = True And checkAbril.Enabled = True Then
            varMesesCheck = varMesesCheck + 1
            txtMontoTotal.Text = (txtMontoMensual.Text * varMesesCheck) * (txtPorcentaje.Text / 100)
        Else
            varMesesCheck = varMesesCheck - 1
            txtMontoTotal.Text = (txtMontoMensual.Text * varMesesCheck) * (txtPorcentaje.Text / 100)
        End If
    End Sub

    Private Sub checkMayo_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles checkMayo.CheckedChanged
        If checkMayo.Checked = True And checkMayo.Enabled = True Then
            varMesesCheck = varMesesCheck + 1
            txtMontoTotal.Text = (txtMontoMensual.Text * varMesesCheck) * (txtPorcentaje.Text / 100)
        Else
            varMesesCheck = varMesesCheck - 1
            txtMontoTotal.Text = (txtMontoMensual.Text * varMesesCheck) * (txtPorcentaje.Text / 100)
        End If
    End Sub

    Private Sub checkJunio_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles checkJunio.CheckedChanged
        If checkJunio.Checked = True And checkJunio.Enabled = True Then
            varMesesCheck = varMesesCheck + 1
            txtMontoTotal.Text = (txtMontoMensual.Text * varMesesCheck) * (txtPorcentaje.Text / 100)
        Else
            varMesesCheck = varMesesCheck - 1
            txtMontoTotal.Text = (txtMontoMensual.Text * varMesesCheck) * (txtPorcentaje.Text / 100)
        End If
    End Sub

    Private Sub checkJulio_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles checkJulio.CheckedChanged
        If checkJulio.Checked = True And checkJulio.Enabled = True Then
            varMesesCheck = varMesesCheck + 1
            txtMontoTotal.Text = (txtMontoMensual.Text * varMesesCheck) * (txtPorcentaje.Text / 100)
        Else
            varMesesCheck = varMesesCheck - 1
            txtMontoTotal.Text = (txtMontoMensual.Text * varMesesCheck) * (txtPorcentaje.Text / 100)
        End If
    End Sub

    Private Sub checkAgosto_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles checkAgosto.CheckedChanged
        If checkAgosto.Checked = True And checkAgosto.Enabled = True Then
            varMesesCheck = varMesesCheck + 1
            txtMontoTotal.Text = (txtMontoMensual.Text * varMesesCheck) * (txtPorcentaje.Text / 100)
        Else
            varMesesCheck = varMesesCheck - 1
            txtMontoTotal.Text = (txtMontoMensual.Text * varMesesCheck) * (txtPorcentaje.Text / 100)
        End If
    End Sub

    Private Sub checkSept_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles checkSept.CheckedChanged
        If checkSept.Checked = True And checkSept.Enabled = True Then
            varMesesCheck = varMesesCheck + 1
            txtMontoTotal.Text = (txtMontoMensual.Text * varMesesCheck) * (txtPorcentaje.Text / 100)
        Else
            varMesesCheck = varMesesCheck - 1
            txtMontoTotal.Text = (txtMontoMensual.Text * varMesesCheck) * (txtPorcentaje.Text / 100)
        End If
    End Sub

    Private Sub checkOctubre_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles checkOctubre.CheckedChanged
        If checkOctubre.Checked = True And checkOctubre.Enabled = True Then
            varMesesCheck = varMesesCheck + 1
            txtMontoTotal.Text = (txtMontoMensual.Text * varMesesCheck) * (txtPorcentaje.Text / 100)
        Else
            varMesesCheck = varMesesCheck - 1
            txtMontoTotal.Text = (txtMontoMensual.Text * varMesesCheck) * (txtPorcentaje.Text / 100)
        End If
    End Sub

    Private Sub checkNov_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles checkNov.CheckedChanged
        If checkNov.Checked = True And checkNov.Enabled = True Then
            varMesesCheck = varMesesCheck + 1
            txtMontoTotal.Text = (txtMontoMensual.Text * varMesesCheck) * (txtPorcentaje.Text / 100)
        Else
            varMesesCheck = varMesesCheck - 1
            txtMontoTotal.Text = (txtMontoMensual.Text * varMesesCheck) * (txtPorcentaje.Text / 100)
        End If
    End Sub

    Private Sub checkDic_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles checkDic.CheckedChanged
        If checkDic.Checked = True And checkDic.Enabled = True Then
            varMesesCheck = varMesesCheck + 1
            txtMontoTotal.Text = (txtMontoMensual.Text * varMesesCheck) * (txtPorcentaje.Text / 100)
        Else
            varMesesCheck = varMesesCheck - 1
            txtMontoTotal.Text = (txtMontoMensual.Text * varMesesCheck) * (txtPorcentaje.Text / 100)
        End If
    End Sub
End Class