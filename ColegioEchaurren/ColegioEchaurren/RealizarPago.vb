Imports MySql.Data.MySqlClient
Public Class RealizarPago

    Public varMesesCheck As Integer = 0
    Public varCantDeshacer As Integer = 0
    Public varMarzo As Boolean
    Public varAbril As Boolean
    Public varMayo As Boolean
    Public varJunio As Boolean
    Public varJulio As Boolean
    Public varAgosto As Boolean
    Public varSept As Boolean
    Public varOctubre As Boolean
    Public varNov As Boolean
    Public varDic As Boolean
    Public varVerificar As Boolean = False

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
                varMarzo = True
            Else
                varMesesCheck = varMesesCheck - 1
                txtMontoTotal.Text = (txtMontoMensual.Text * varMesesCheck)
                varMarzo = False
            End If
        Else
            If checkMarzo.Checked = True And checkMarzo.Enabled = True Then
                varMesesCheck = varMesesCheck + 1
                txtMontoTotal.Text = (txtMontoMensual.Text * varMesesCheck) * (txtPorcentaje.Text / 100)
                varMarzo = True
            Else
                varMesesCheck = varMesesCheck - 1
                txtMontoTotal.Text = (txtMontoMensual.Text * varMesesCheck) * (txtPorcentaje.Text / 100)
                varMarzo = False
            End If
        End If
    End Sub

    Private Sub checkAbril_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles checkAbril.CheckedChanged
        If txtPorcentaje.Text = "0" Or txtPorcentaje.Text = "" Then
            If checkAbril.Checked = True And checkAbril.Enabled = True Then
                varMesesCheck = varMesesCheck + 1
                txtMontoTotal.Text = (txtMontoMensual.Text * varMesesCheck)
                varAbril = True
            Else
                varMesesCheck = varMesesCheck - 1
                txtMontoTotal.Text = (txtMontoMensual.Text * varMesesCheck)
                varAbril = False
            End If
        Else
            If checkAbril.Checked = True And checkAbril.Enabled = True Then
                varMesesCheck = varMesesCheck + 1
                txtMontoTotal.Text = (txtMontoMensual.Text * varMesesCheck) * (txtPorcentaje.Text / 100)
                varAbril = True
            Else
                varMesesCheck = varMesesCheck - 1
                txtMontoTotal.Text = (txtMontoMensual.Text * varMesesCheck) * (txtPorcentaje.Text / 100)
                varAbril = False
            End If
        End If
    End Sub

    Private Sub checkMayo_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles checkMayo.CheckedChanged
        If txtPorcentaje.Text = "0" Or txtPorcentaje.Text = "" Then
            If checkMayo.Checked = True And checkMayo.Enabled = True Then
                varMesesCheck = varMesesCheck + 1
                txtMontoTotal.Text = (txtMontoMensual.Text * varMesesCheck)
                varMayo = True
            Else
                varMesesCheck = varMesesCheck - 1
                txtMontoTotal.Text = (txtMontoMensual.Text * varMesesCheck)
                varMayo = False
            End If
        Else
            If checkMayo.Checked = True And checkMayo.Enabled = True Then
                varMesesCheck = varMesesCheck + 1
                txtMontoTotal.Text = (txtMontoMensual.Text * varMesesCheck) * (txtPorcentaje.Text / 100)
                varMayo = True
            Else
                varMesesCheck = varMesesCheck - 1
                txtMontoTotal.Text = (txtMontoMensual.Text * varMesesCheck) * (txtPorcentaje.Text / 100)
                varMayo = False
            End If
        End If
    End Sub

    Private Sub checkJunio_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles checkJunio.CheckedChanged
        If txtPorcentaje.Text = "0" Or txtPorcentaje.Text = "" Then
            If checkJunio.Checked = True And checkJunio.Enabled = True Then
                varMesesCheck = varMesesCheck + 1
                txtMontoTotal.Text = (txtMontoMensual.Text * varMesesCheck)
                varJunio = True
            Else
                varMesesCheck = varMesesCheck - 1
                txtMontoTotal.Text = (txtMontoMensual.Text * varMesesCheck)
                varJunio = False
            End If
        Else
            If checkJunio.Checked = True And checkJunio.Enabled = True Then
                varMesesCheck = varMesesCheck + 1
                txtMontoTotal.Text = (txtMontoMensual.Text * varMesesCheck) * (txtPorcentaje.Text / 100)
                varJunio = True
            Else
                varMesesCheck = varMesesCheck - 1
                txtMontoTotal.Text = (txtMontoMensual.Text * varMesesCheck) * (txtPorcentaje.Text / 100)
                varJunio = False
            End If
        End If
    End Sub

    Private Sub checkJulio_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles checkJulio.CheckedChanged
        If txtPorcentaje.Text = "0" Or txtPorcentaje.Text = "" Then
            If checkJulio.Checked = True And checkJulio.Enabled = True Then
                varMesesCheck = varMesesCheck + 1
                txtMontoTotal.Text = (txtMontoMensual.Text * varMesesCheck)
                varJulio = True
            Else
                varMesesCheck = varMesesCheck - 1
                txtMontoTotal.Text = (txtMontoMensual.Text * varMesesCheck)
                varJulio = False
            End If
        Else
            If checkJulio.Checked = True And checkJulio.Enabled = True Then
                varMesesCheck = varMesesCheck + 1
                txtMontoTotal.Text = (txtMontoMensual.Text * varMesesCheck) * (txtPorcentaje.Text / 100)
                varJulio = True
            Else
                varMesesCheck = varMesesCheck - 1
                txtMontoTotal.Text = (txtMontoMensual.Text * varMesesCheck) * (txtPorcentaje.Text / 100)
                varJulio = False
            End If
        End If
    End Sub

    Private Sub checkAgosto_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles checkAgosto.CheckedChanged
        If txtPorcentaje.Text = "0" Or txtPorcentaje.Text = "" Then
            If checkAgosto.Checked = True And checkAgosto.Enabled = True Then
                varMesesCheck = varMesesCheck + 1
                txtMontoTotal.Text = (txtMontoMensual.Text * varMesesCheck)
                varAgosto = True
            Else
                varMesesCheck = varMesesCheck - 1
                txtMontoTotal.Text = (txtMontoMensual.Text * varMesesCheck)
                varAgosto = False
            End If
        Else
            If checkAgosto.Checked = True And checkAgosto.Enabled = True Then
                varMesesCheck = varMesesCheck + 1
                txtMontoTotal.Text = (txtMontoMensual.Text * varMesesCheck) * (txtPorcentaje.Text / 100)
                varAgosto = True
            Else
                varMesesCheck = varMesesCheck - 1
                txtMontoTotal.Text = (txtMontoMensual.Text * varMesesCheck) * (txtPorcentaje.Text / 100)
                varAgosto = False
            End If
        End If
    End Sub

    Private Sub checkSept_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles checkSept.CheckedChanged
        If txtPorcentaje.Text = "0" Or txtPorcentaje.Text = "" Then
            If checkSept.Checked = True And checkSept.Enabled = True Then
                varMesesCheck = varMesesCheck + 1
                txtMontoTotal.Text = (txtMontoMensual.Text * varMesesCheck)
                varSept = True
            Else
                varMesesCheck = varMesesCheck - 1
                txtMontoTotal.Text = (txtMontoMensual.Text * varMesesCheck)
                varSept = False
            End If
        Else
            If checkSept.Checked = True And checkSept.Enabled = True Then
                varMesesCheck = varMesesCheck + 1
                txtMontoTotal.Text = (txtMontoMensual.Text * varMesesCheck) * (txtPorcentaje.Text / 100)
                varSept = True
            Else
                varMesesCheck = varMesesCheck - 1
                txtMontoTotal.Text = (txtMontoMensual.Text * varMesesCheck) * (txtPorcentaje.Text / 100)
                varSept = False
            End If
        End If
    End Sub

    Private Sub checkOctubre_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles checkOctubre.CheckedChanged
        If txtPorcentaje.Text = "0" Or txtPorcentaje.Text = "" Then
            If checkOctubre.Checked = True And checkOctubre.Enabled = True Then
                varMesesCheck = varMesesCheck + 1
                txtMontoTotal.Text = (txtMontoMensual.Text * varMesesCheck)
                varOctubre = True
            Else
                varMesesCheck = varMesesCheck - 1
                txtMontoTotal.Text = (txtMontoMensual.Text * varMesesCheck)
                varOctubre = False
            End If
        Else
            If checkOctubre.Checked = True And checkOctubre.Enabled = True Then
                varMesesCheck = varMesesCheck + 1
                txtMontoTotal.Text = (txtMontoMensual.Text * varMesesCheck) * (txtPorcentaje.Text / 100)
                varOctubre = True
            Else
                varMesesCheck = varMesesCheck - 1
                txtMontoTotal.Text = (txtMontoMensual.Text * varMesesCheck) * (txtPorcentaje.Text / 100)
                varOctubre = False
            End If
        End If
    End Sub

    Private Sub checkNov_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles checkNov.CheckedChanged
        If txtPorcentaje.Text = "0" Or txtPorcentaje.Text = "" Then
            If checkNov.Checked = True And checkNov.Enabled = True Then
                varMesesCheck = varMesesCheck + 1
                txtMontoTotal.Text = (txtMontoMensual.Text * varMesesCheck)
                varNov = True
            Else
                varMesesCheck = varMesesCheck - 1
                txtMontoTotal.Text = (txtMontoMensual.Text * varMesesCheck)
                varNov = False
            End If
        Else
            If checkNov.Checked = True And checkNov.Enabled = True Then
                varMesesCheck = varMesesCheck + 1
                txtMontoTotal.Text = (txtMontoMensual.Text * varMesesCheck) * (txtPorcentaje.Text / 100)
                varNov = True
            Else
                varMesesCheck = varMesesCheck - 1
                txtMontoTotal.Text = (txtMontoMensual.Text * varMesesCheck) * (txtPorcentaje.Text / 100)
                varNov = False
            End If
        End If
    End Sub

    Private Sub checkDic_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles checkDic.CheckedChanged
        If txtPorcentaje.Text = "0" Or txtPorcentaje.Text = "" Then
            If checkDic.Checked = True And checkDic.Enabled = True Then
                varMesesCheck = varMesesCheck + 1
                txtMontoTotal.Text = (txtMontoMensual.Text * varMesesCheck)
                varDic = True
            Else
                varMesesCheck = varMesesCheck - 1
                txtMontoTotal.Text = (txtMontoMensual.Text * varMesesCheck)
                varDic = False
            End If
        Else
            If checkDic.Checked = True And checkDic.Enabled = True Then
                varMesesCheck = varMesesCheck + 1
                txtMontoTotal.Text = (txtMontoMensual.Text * varMesesCheck) * (txtPorcentaje.Text / 100)
                varDic = True
            Else
                varMesesCheck = varMesesCheck - 1
                txtMontoTotal.Text = (txtMontoMensual.Text * varMesesCheck) * (txtPorcentaje.Text / 100)
                varDic = False
            End If
        End If
    End Sub

    Private Sub btnDeshacerPago_Click(sender As System.Object, e As System.EventArgs) Handles btnDeshacerPago.Click
        For i = 1 To varCantDeshacer
            If varMarzo = True And checkMarzo.Enabled = False Then
                ModuloContenedor.DeshacerPago("", checkMarzo.Text, txtCampoRut.Text)
                checkMarzo.Enabled = True
                checkMarzo.Checked = False
                varMarzo = False
                varVerificar = True
            ElseIf varAbril = True And checkAbril.Enabled = False Then
                ModuloContenedor.DeshacerPago("", checkAbril.Text, txtCampoRut.Text)
                checkAbril.Enabled = True
                checkAbril.Checked = False
                varAbril = False
                varVerificar = True
            ElseIf varMayo = True And checkMayo.Enabled = False Then
                ModuloContenedor.DeshacerPago("", checkMayo.Text, txtCampoRut.Text)
                checkMayo.Enabled = True
                checkMayo.Checked = False
                varMayo = False
                varVerificar = True
            ElseIf varJunio = True And checkJunio.Enabled = False Then
                ModuloContenedor.DeshacerPago("", checkJunio.Text, txtCampoRut.Text)
                checkJunio.Enabled = True
                checkJunio.Checked = False
                varJunio = False
                varVerificar = True
            ElseIf varJulio = True And checkJulio.Enabled = False Then
                ModuloContenedor.DeshacerPago("", checkJulio.Text, txtCampoRut.Text)
                checkJulio.Enabled = True
                checkJulio.Checked = False
                varJulio = False
                varVerificar = True
            ElseIf varAgosto = True And checkAgosto.Enabled = False Then
                ModuloContenedor.DeshacerPago("", checkAgosto.Text, txtCampoRut.Text)
                checkAgosto.Enabled = True
                checkAgosto.Checked = False
                varAgosto = False
                varVerificar = True
            ElseIf varSept = True And checkSept.Enabled = False Then
                ModuloContenedor.DeshacerPago("", checkSept.Text, txtCampoRut.Text)
                checkSept.Enabled = True
                checkSept.Checked = False
                varSept = False
                varVerificar = True
            ElseIf varOctubre = True And checkOctubre.Enabled = False Then
                ModuloContenedor.DeshacerPago("", checkOctubre.Text, txtCampoRut.Text)
                checkOctubre.Enabled = True
                checkOctubre.Checked = False
                varOctubre = False
                varVerificar = True
            ElseIf varNov = True And checkNov.Enabled = False Then
                ModuloContenedor.DeshacerPago("", checkNov.Text, txtCampoRut.Text)
                checkNov.Enabled = True
                checkNov.Checked = False
                varNov = False
                varVerificar = True
            ElseIf varDic = True And checkDic.Enabled = False Then
                ModuloContenedor.DeshacerPago("", checkDic.Text, txtCampoRut.Text)
                checkDic.Enabled = True
                checkDic.Checked = False
                varDic = False
                varVerificar = True
            End If
        Next i
        If varVerificar = True Then
            txtMontoTotal.Text = ""
            MessageBox.Show("Pago Deshecho.")
            varVerificar = False
            varMesesCheck = 0
            varCantDeshacer = 0
        Else
            MessageBox.Show("No hay pagos por deshacer.")
        End If
    End Sub

    Private Sub btnPagar_Click(sender As System.Object, e As System.EventArgs) Handles btnPagar.Click
        varCantDeshacer = varMesesCheck
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