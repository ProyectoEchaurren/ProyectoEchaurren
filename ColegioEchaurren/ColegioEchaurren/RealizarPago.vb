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
        checkMarzo.Checked = False
        checkAbril.Checked = False
        checkMayo.Checked = False
        checkJunio.Checked = False
        checkJulio.Checked = False
        checkAgosto.Checked = False
        checkSept.Checked = False
        checkOctubre.Checked = False
        checkNov.Checked = False
        checkDic.Checked = False

        checkMarzo.Enabled = False
        checkAbril.Enabled = False
        checkMayo.Enabled = False
        checkJunio.Enabled = False
        checkJulio.Enabled = False
        checkAgosto.Enabled = False
        checkSept.Enabled = False
        checkOctubre.Enabled = False
        checkNov.Enabled = False
        checkDic.Enabled = False

        varMesesCheck = 0
        txtCampoRut.Text = ""
        txtNombre.Text = ""
        txtBeca.Text = ""
        txtTipoPago.Text = ""
        txtPorcentaje.Text = ""
        txtMontoMensual.Text = ""
        txtMontoTotal.Text = ""
        txtComprobante.Text = ""
        txtCampoRut.Focus()
    End Sub

    Private Sub checkMarzo_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles checkMarzo.CheckedChanged
        If txtPorcentaje.Text = "0" Or txtPorcentaje.Text = "" Then
            If checkMarzo.Checked = True And checkMarzo.Enabled = True Then
                varMesesCheck = varMesesCheck + 1
                txtMontoTotal.Text = (txtMontoMensual.Text * varMesesCheck)
            Else
                varMesesCheck = varMesesCheck - 1
                txtMontoTotal.Text = (txtMontoMensual.Text * varMesesCheck)
            End If
        Else
            If checkMarzo.Checked = True And checkMarzo.Enabled = True Then
                varMesesCheck = varMesesCheck + 1
                txtMontoTotal.Text = (txtMontoMensual.Text * varMesesCheck) * (txtPorcentaje.Text / 100)
            Else
                varMesesCheck = varMesesCheck - 1
                txtMontoTotal.Text = (txtMontoMensual.Text * varMesesCheck) * (txtPorcentaje.Text / 100)
            End If
        End If
    End Sub

    Private Sub checkAbril_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles checkAbril.CheckedChanged
        If txtPorcentaje.Text = "0" Or txtPorcentaje.Text = "" Then
            If checkAbril.Checked = True And checkAbril.Enabled = True Then
                varMesesCheck = varMesesCheck + 1
                txtMontoTotal.Text = (txtMontoMensual.Text * varMesesCheck)
            Else
                varMesesCheck = varMesesCheck - 1
                txtMontoTotal.Text = (txtMontoMensual.Text * varMesesCheck)
            End If
        Else
            If checkAbril.Checked = True And checkAbril.Enabled = True Then
                varMesesCheck = varMesesCheck + 1
                txtMontoTotal.Text = (txtMontoMensual.Text * varMesesCheck) * (txtPorcentaje.Text / 100)
            Else
                varMesesCheck = varMesesCheck - 1
                txtMontoTotal.Text = (txtMontoMensual.Text * varMesesCheck) * (txtPorcentaje.Text / 100)
            End If
        End If
    End Sub

    Private Sub checkMayo_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles checkMayo.CheckedChanged
        If txtPorcentaje.Text = "0" Or txtPorcentaje.Text = "" Then
            If checkMayo.Checked = True And checkMayo.Enabled = True Then
                varMesesCheck = varMesesCheck + 1
                txtMontoTotal.Text = (txtMontoMensual.Text * varMesesCheck)
            Else
                varMesesCheck = varMesesCheck - 1
                txtMontoTotal.Text = (txtMontoMensual.Text * varMesesCheck)
            End If
        Else
            If checkMayo.Checked = True And checkMayo.Enabled = True Then
                varMesesCheck = varMesesCheck + 1
                txtMontoTotal.Text = (txtMontoMensual.Text * varMesesCheck) * (txtPorcentaje.Text / 100)
            Else
                varMesesCheck = varMesesCheck - 1
                txtMontoTotal.Text = (txtMontoMensual.Text * varMesesCheck) * (txtPorcentaje.Text / 100)
            End If
        End If
    End Sub

    Private Sub checkJunio_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles checkJunio.CheckedChanged
        If txtPorcentaje.Text = "0" Or txtPorcentaje.Text = "" Then
            If checkJunio.Checked = True And checkJunio.Enabled = True Then
                varMesesCheck = varMesesCheck + 1
                txtMontoTotal.Text = (txtMontoMensual.Text * varMesesCheck)
            Else
                varMesesCheck = varMesesCheck - 1
                txtMontoTotal.Text = (txtMontoMensual.Text * varMesesCheck)
            End If
        Else
            If checkJunio.Checked = True And checkJunio.Enabled = True Then
                varMesesCheck = varMesesCheck + 1
                txtMontoTotal.Text = (txtMontoMensual.Text * varMesesCheck) * (txtPorcentaje.Text / 100)
            Else
                varMesesCheck = varMesesCheck - 1
                txtMontoTotal.Text = (txtMontoMensual.Text * varMesesCheck) * (txtPorcentaje.Text / 100)
            End If
        End If
    End Sub

    Private Sub checkJulio_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles checkJulio.CheckedChanged
        If txtPorcentaje.Text = "0" Or txtPorcentaje.Text = "" Then
            If checkJulio.Checked = True And checkJulio.Enabled = True Then
                varMesesCheck = varMesesCheck + 1
                txtMontoTotal.Text = (txtMontoMensual.Text * varMesesCheck)
            Else
                varMesesCheck = varMesesCheck - 1
                txtMontoTotal.Text = (txtMontoMensual.Text * varMesesCheck)
            End If
        Else
            If checkJulio.Checked = True And checkJulio.Enabled = True Then
                varMesesCheck = varMesesCheck + 1
                txtMontoTotal.Text = (txtMontoMensual.Text * varMesesCheck) * (txtPorcentaje.Text / 100)
            Else
                varMesesCheck = varMesesCheck - 1
                txtMontoTotal.Text = (txtMontoMensual.Text * varMesesCheck) * (txtPorcentaje.Text / 100)
            End If
        End If
    End Sub

    Private Sub checkAgosto_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles checkAgosto.CheckedChanged
        If txtPorcentaje.Text = "0" Or txtPorcentaje.Text = "" Then
            If checkAgosto.Checked = True And checkAgosto.Enabled = True Then
                varMesesCheck = varMesesCheck + 1
                txtMontoTotal.Text = (txtMontoMensual.Text * varMesesCheck)
            Else
                varMesesCheck = varMesesCheck - 1
                txtMontoTotal.Text = (txtMontoMensual.Text * varMesesCheck)
            End If
        Else
            If checkAgosto.Checked = True And checkAgosto.Enabled = True Then
                varMesesCheck = varMesesCheck + 1
                txtMontoTotal.Text = (txtMontoMensual.Text * varMesesCheck) * (txtPorcentaje.Text / 100)
            Else
                varMesesCheck = varMesesCheck - 1
                txtMontoTotal.Text = (txtMontoMensual.Text * varMesesCheck) * (txtPorcentaje.Text / 100)
            End If
        End If
    End Sub

    Private Sub checkSept_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles checkSept.CheckedChanged
        If txtPorcentaje.Text = "0" Or txtPorcentaje.Text = "" Then
            If checkSept.Checked = True And checkSept.Enabled = True Then
                varMesesCheck = varMesesCheck + 1
                txtMontoTotal.Text = (txtMontoMensual.Text * varMesesCheck)
            Else
                varMesesCheck = varMesesCheck - 1
                txtMontoTotal.Text = (txtMontoMensual.Text * varMesesCheck)
            End If
        Else
            If checkSept.Checked = True And checkSept.Enabled = True Then
                varMesesCheck = varMesesCheck + 1
                txtMontoTotal.Text = (txtMontoMensual.Text * varMesesCheck) * (txtPorcentaje.Text / 100)
            Else
                varMesesCheck = varMesesCheck - 1
                txtMontoTotal.Text = (txtMontoMensual.Text * varMesesCheck) * (txtPorcentaje.Text / 100)
            End If
        End If
    End Sub

    Private Sub checkOctubre_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles checkOctubre.CheckedChanged
        If txtPorcentaje.Text = "0" Or txtPorcentaje.Text = "" Then
            If checkOctubre.Checked = True And checkOctubre.Enabled = True Then
                varMesesCheck = varMesesCheck + 1
                txtMontoTotal.Text = (txtMontoMensual.Text * varMesesCheck)
            Else
                varMesesCheck = varMesesCheck - 1
                txtMontoTotal.Text = (txtMontoMensual.Text * varMesesCheck)
            End If
        Else
            If checkOctubre.Checked = True And checkOctubre.Enabled = True Then
                varMesesCheck = varMesesCheck + 1
                txtMontoTotal.Text = (txtMontoMensual.Text * varMesesCheck) * (txtPorcentaje.Text / 100)
            Else
                varMesesCheck = varMesesCheck - 1
                txtMontoTotal.Text = (txtMontoMensual.Text * varMesesCheck) * (txtPorcentaje.Text / 100)
            End If
        End If
    End Sub

    Private Sub checkNov_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles checkNov.CheckedChanged
        If txtPorcentaje.Text = "0" Or txtPorcentaje.Text = "" Then
            If checkNov.Checked = True And checkNov.Enabled = True Then
                varMesesCheck = varMesesCheck + 1
                txtMontoTotal.Text = (txtMontoMensual.Text * varMesesCheck)
            Else
                varMesesCheck = varMesesCheck - 1
                txtMontoTotal.Text = (txtMontoMensual.Text * varMesesCheck)
            End If
        Else
            If checkNov.Checked = True And checkNov.Enabled = True Then
                varMesesCheck = varMesesCheck + 1
                txtMontoTotal.Text = (txtMontoMensual.Text * varMesesCheck) * (txtPorcentaje.Text / 100)
            Else
                varMesesCheck = varMesesCheck - 1
                txtMontoTotal.Text = (txtMontoMensual.Text * varMesesCheck) * (txtPorcentaje.Text / 100)
            End If
        End If
    End Sub

    Private Sub checkDic_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles checkDic.CheckedChanged
        If txtPorcentaje.Text = "0" Or txtPorcentaje.Text = "" Then
            If checkDic.Checked = True And checkDic.Enabled = True Then
                varMesesCheck = varMesesCheck + 1
                txtMontoTotal.Text = (txtMontoMensual.Text * varMesesCheck)
            Else
                varMesesCheck = varMesesCheck - 1
                txtMontoTotal.Text = (txtMontoMensual.Text * varMesesCheck)
            End If
        Else
            If checkDic.Checked = True And checkDic.Enabled = True Then
                varMesesCheck = varMesesCheck + 1
                txtMontoTotal.Text = (txtMontoMensual.Text * varMesesCheck) * (txtPorcentaje.Text / 100)
            Else
                varMesesCheck = varMesesCheck - 1
                txtMontoTotal.Text = (txtMontoMensual.Text * varMesesCheck) * (txtPorcentaje.Text / 100)
            End If
        End If
    End Sub

    Private Sub btnPagar_Click(sender As System.Object, e As System.EventArgs) Handles btnPagar.Click
        If txtComprobante.Text <> "" And txtMontoTotal.Text <> "" Then
            For i = 1 To varMesesCheck
                If checkMarzo.Checked = True And checkMarzo.Enabled = True Then
                    ModuloContenedor.PagarMensualidad(txtComprobante.Text, checkMarzo.Text, txtCampoRut.Text)
                    checkMarzo.Enabled = False
                ElseIf checkAbril.Checked = True And checkAbril.Enabled = True Then
                    ModuloContenedor.PagarMensualidad(txtComprobante.Text, checkAbril.Text, txtCampoRut.Text)
                    checkAbril.Enabled = False
                ElseIf checkMayo.Checked = True And checkMayo.Enabled = True Then
                    ModuloContenedor.PagarMensualidad(txtComprobante.Text, checkMayo.Text, txtCampoRut.Text)
                    checkMayo.Enabled = False
                ElseIf checkJunio.Checked = True And checkJunio.Enabled = True Then
                    ModuloContenedor.PagarMensualidad(txtComprobante.Text, checkJunio.Text, txtCampoRut.Text)
                    checkJunio.Enabled = False
                ElseIf checkJulio.Checked = True And checkJulio.Enabled = True Then
                    ModuloContenedor.PagarMensualidad(txtComprobante.Text, checkJulio.Text, txtCampoRut.Text)
                    checkJulio.Enabled = False
                ElseIf checkAgosto.Checked = True And checkAgosto.Enabled = True Then
                    ModuloContenedor.PagarMensualidad(txtComprobante.Text, checkAgosto.Text, txtCampoRut.Text)
                    checkAgosto.Enabled = False
                ElseIf checkSept.Checked = True And checkSept.Enabled = True Then
                    ModuloContenedor.PagarMensualidad(txtComprobante.Text, checkSept.Text, txtCampoRut.Text)
                    checkSept.Enabled = False
                ElseIf checkOctubre.Checked = True And checkOctubre.Enabled = True Then
                    ModuloContenedor.PagarMensualidad(txtComprobante.Text, checkOctubre.Text, txtCampoRut.Text)
                    checkOctubre.Enabled = False
                ElseIf checkNov.Checked = True And checkNov.Enabled = True Then
                    ModuloContenedor.PagarMensualidad(txtComprobante.Text, checkNov.Text, txtCampoRut.Text)
                    checkNov.Enabled = False
                ElseIf checkDic.Checked = True And checkDic.Enabled = True Then
                    ModuloContenedor.PagarMensualidad(txtComprobante.Text, checkDic.Text, txtCampoRut.Text)
                    checkDic.Enabled = False
                Else
                    MsgBox("Para pagar primero seleccione mes o meses a pagar y no olvide ingresar el N° de Comprobante de la boleta.", MsgBoxStyle.Information, MessageBoxButtons.OK)
                End If
            Next i
            MessageBox.Show("Pago realizado exitosamente.")
        Else
            MsgBox("Para pagar primero ingrese el N° de Comprobante de la boleta.", MsgBoxStyle.Information, MessageBoxButtons.OK)
        End If
        varMesesCheck = 0
    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        If txtComprobante.Text <> "" Or txtMontoTotal.Text <> "" Then
            If MessageBox.Show("¿Está seguro(a) de cancelar la operación?", "¡Alerta!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
                Me.Close()
            End If
        Else
            Me.Close()
        End If
    End Sub
End Class