Imports MySql.Data.MySqlClient

Public Class FormularioMatricula
    Public indiceTab As Integer
    Public varConexion As MySqlConnection
    Public varConexionString As String = "server=localhost;User Id=root;password=123456;database=bd_echaurren"

    Private Sub FormularioMatricula_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        dateTimeFechaNac.Format = DateTimePickerFormat.Custom
        dateTimeFechaNac.CustomFormat = "dd/MM/yyyy"
        dateTimeFechaNac.MaxDate = Now()

        Try

            varConexion = New MySqlConnection
            varConexion.ConnectionString = varConexionString
            varConexion.Open()

        Catch ex As Exception

            MessageBox.Show("Error al conectar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()

        End Try

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged_1(sender As System.Object, e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.SelectedIndex = 0 Then
            GroupBox1.Show()
            GroupBox2.Hide()
            GroupBox3.Hide()
            GroupBox4.Hide()
            GroupBox5.Hide()
        ElseIf ComboBox1.SelectedIndex = 1 Then
            GroupBox2.Show()
            GroupBox3.Hide()
            GroupBox4.Hide()
            GroupBox5.Hide()
        ElseIf ComboBox1.SelectedIndex = 2 Then
            GroupBox2.Show()
            GroupBox3.Show()
            GroupBox4.Hide()
            GroupBox5.Hide()
        ElseIf ComboBox1.SelectedIndex = 3 Then
            GroupBox2.Show()
            GroupBox3.Show()
            GroupBox4.Show()
            GroupBox5.Hide()
        ElseIf ComboBox1.SelectedIndex = 4 Then
            GroupBox2.Show()
            GroupBox3.Show()
            GroupBox4.Show()
            GroupBox5.Show()
        End If
    End Sub

    Private Sub RadioButton14_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton14.CheckedChanged
        If RadioButton14.Checked = True Then
            txtOtro.Enabled = True
            txtOtro.Focus()
        Else
            txtOtro.Enabled = False
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        indiceTab = TabControl1.SelectedIndex
        TabControl1.DeselectTab(indiceTab)
    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar2.Click
        indiceTab = TabControl1.SelectedIndex
        TabControl1.DeselectTab(indiceTab)
    End Sub

    Private Sub btnVolver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        indiceTab = TabControl1.SelectedIndex
        TabControl1.SelectTab(indiceTab - 1)
    End Sub

    Private Sub btnVolver2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVolver2.Click
        indiceTab = TabControl1.SelectedIndex
        TabControl1.SelectTab(indiceTab - 1)
    End Sub

    Private Sub btnSalir3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir3.Click
        If MessageBox.Show("¿Está seguro(a) de salir sin guardar?", "¡Alerta!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub btnSalir2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir2.Click
        If MessageBox.Show("¿Está seguro(a) de salir sin guardar?", "¡Alerta!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        If MessageBox.Show("¿Está seguro(a) de salir sin guardar?", "¡Alerta!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub btnTerminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTerminar.Click

        If RadioButton9.Checked = False And RadioButton13.Checked = False And RadioButton14.Checked = False Then

            MessageBox.Show("Debe seleccionar uno de los tipos de tutor economico", "Matricula - Contrato de servicio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        While RadioButton14.Checked = True
            If txtOtro.Text = "" Then
                MessageBox.Show("Debe ingresar otro tipo de tutor economico", "Matricula - Contrato de servicio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

        End While


        If txtNombreTutor.Text = "" Or txtRut.Text = "" Or txtTelefonoPart.Text = "" Or txtTelefonoTrabajo.Text = "" Or txtDomicilio.Text = "" Or txtLugarDeTrabajo.Text = "" Or txtOcupacionAct.Text = "" Or txtProfesion.Text = "" Then

            MessageBox.Show("Debe llenar todos los datos del tutor economico", "Matricula - Contrato de servicio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If radioMasc.Checked = False And radioFeme.Checked = False Then
            MessageBox.Show("Debe seleccionar uno de los dos sexos", "Matricula - Ficha de matricula", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If radioHermanosSi.Checked = False And radioHermanosNo.Checked = False Then
            MessageBox.Show("Debe seleccionar hermanos en establecimiento", "Matricula - Ficha de matricula", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        While radioHermanosSi.Checked = True
            If txtHermanosCursos.Text = "" Then
                MessageBox.Show("Debe indicar los cursos de hermanos", "Matricula - Ficha de matricula", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
        End While

        If txtNombreApodSuplent.Text = "" Then
            MessageBox.Show("Debe ingresar nombre de apoderado suplente", "Matricula - Ficha de matricula", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        '---------------------------------------------------------------------------------------------------
        '---------------------------------------------------------------------------------------------------
        '---------------------------------------------------------------------------------------------------
        '---------------------------------------------------------------------------------------------------
        '---------------------------------------------------------------------------------------------------
        '---------------------------------------------------------------------------------------------------
        '---------------------------------------------------------------------------------------------------

       

    End Sub

    Private Sub radioHermanosSi_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radioHermanosSi.CheckedChanged
        If radioHermanosSi.Checked = True Then
            txtHermanosCursos.Enabled = True
            txtHermanosCursos.Focus()
        Else
            txtHermanosCursos.Enabled = False
        End If
    End Sub

    Private Sub txtOtrosServicios_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If txtOtrosServicios.Text <> "" Then
            comboIsapre.SelectedText = ""
        End If
    End Sub

    Private Sub comboIsapre_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If comboIsapre.SelectedText <> "" Then
            txtOtrosServicios.Text = ""
        End If
    End Sub

    Private Sub ComboBox14_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbViveCon.SelectedIndexChanged
        If cbViveCon.SelectedIndex = "4" Then
            txtViveConOtros.Enabled = True
            txtViveConOtros.Focus()
        Else
            txtViveConOtros.Enabled = False
        End If
    End Sub

    Private Sub cbEstudiosMadre_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)
        If cbEstudiosMadre.Text = "" Then
            txtEstudiosMadre.Enabled = False
        Else
            txtEstudiosMadre.Enabled = True
            txtEstudiosMadre.Focus()
        End If
    End Sub

    Private Sub cbEstudiosPadre_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)
        If cbEstudiosPadre.Text = "" Then
            txtEstudiosPadre.Enabled = False
        Else
            txtEstudiosPadre.Enabled = True
            txtEstudiosPadre.Focus()
        End If
    End Sub
End Class