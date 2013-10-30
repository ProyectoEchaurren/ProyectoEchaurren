Imports MySql.Data.MySqlClient

Public Class FormularioMatricula
    Public indiceTab As Integer
    Public varConexion As MySqlConnection
    Public varConexionString As String = "server=localhost;User Id=root;password=123456;database=bd_echaurren"
    Public consultaCargaCombo As String = "SELECT * FROM bd_echaurren.servicio_salud;"

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


        Try
            Dim _dataAdapter = New MySqlDataAdapter(consultaCargaCombo, varConexion)
            Dim _dataSet = New DataSet
            _dataAdapter.Fill(_dataSet)

            comboServSalud.DataSource = _dataSet.Tables(0)
            comboServSalud.ValueMember = "idServicio_salud"
            comboServSalud.DisplayMember = "PlanSalud"
        Catch ex As Exception
            MessageBox.Show("Error al cargar servicios de salud", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
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

        If cbApoderado.Text = "" Then
            MessageBox.Show("Debe seleccionar un apoderado", "Antecedentes familiares", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        While cbApoderado.SelectedIndex = "3"
            If txtNombreApoderado.Text = "" Then
                MessageBox.Show("Debe seleccionar otro apoderado", "Antecedentes familiares", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            Exit While
        End While

        If cbApoSuplente.Text = "" Then
            MessageBox.Show("Debe seleccionar un apoderado suplente", "Antecedentes familiares", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        While cbApoSuplente.SelectedIndex = "3"
            If txtNombreApodSuplent.Text = "" Then
                MessageBox.Show("Debe ingresar otro apoderado suplente", "Antecedentes familiares", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            Exit While
        End While

        If RadioButton9.Checked = False And RadioButton13.Checked = False And RadioButton14.Checked = False Then
            MessageBox.Show("Debe elegir un tipo de tutor economico", "Antecedentes familiares", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        While RadioButton14.Checked = True
            If txtOtro.Text = "" Then
                MessageBox.Show("Debe ingresar otro tipo de tutor economico", "Antecedentes familiares", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            Exit While
        End While

        If txtNombreTutor.Text = "" Or txtRut.Text = "" Or txtTelefonoPart.Text = "" Or txtTelefonoTrabajo.Text = "" Or txtDomicilio.Text = "" _
            Or txtLugarDeTrabajo.Text = "" Or txtOcupacionAct.Text = "" Or txtProfesion.Text = "" Then
            MessageBox.Show("Debe ingresar todos los datos del tutor economico", "Antecedentes familiares", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If


        indiceTab = TabControl1.SelectedIndex
        TabControl1.DeselectTab(indiceTab)
    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar2.Click

        If txtApePatAlumno.Text = "" Or txtApeMatAlumno.Text = "" And txtNombresAlumno.Text = "" And txtEdadAlumno.Text = "" _
            And txtCalleAlumno.Text = "" And txtSectorAlumno.Text = "" Or txtCurso.Text = "" Or txtComunaAlumno.Text = "" _
            Or txtTelefonoAlumno.Text = "" Or txtColegioPrese.Text = "" Or txtCursosRepetidos.Text = "" Then

            MessageBox.Show("Debe ingresar todos los datos del alumno", "Datos de alumno", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        While radioHermanosSi.Checked = True
            If txtHermanosCursos.Text = "" Then
                MessageBox.Show("Debe ingresar los cursos de hermanos", "Datos de alumno", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
        End While

        If txtNumHijos.Text = "" Or txtLugarHijos.Text = "" Or txtGrupoFamiliar.Text = "" Then
            MessageBox.Show("Debe ingresar los datos de convivencia", "Datos de alumno", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        While cbViveCon.Text = ""
            MessageBox.Show("Debe seleccionar algun tipo de convivencia", "Datos de alumno", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
            Exit While
        End While
       
        While cbViveCon.SelectedIndex = "4"
            If txtViveConOtros.Text = "" Then
                MessageBox.Show("Debe ingresar otro tipo de conviviente", "Datos de alumno", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            Exit While
        End While


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
            comboServSalud.SelectedText = ""
        End If
    End Sub

    Private Sub comboIsapre_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If comboServSalud.SelectedText <> "" Then
            txtOtrosServicios.Text = ""
        End If
    End Sub

    Private Sub ComboBox14_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbViveCon.SelectedIndexChanged
        If cbViveCon.SelectedIndex = "4" Then
            txtViveConOtros.Enabled = True
            txtViveConOtros.Focus()
        Else
            txtViveConOtros.Enabled = False
        End If
    End Sub

    Private Sub cbEstudiosMadre_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If cbEstudiosMadre.Text = "" Then
            txtEstudiosMadre.Enabled = False
        Else
            txtEstudiosMadre.Enabled = True
            txtEstudiosMadre.Focus()
        End If
    End Sub

    Private Sub cbEstudiosPadre_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If cbEstudiosPadre.Text = "" Then
            txtEstudiosPadre.Enabled = False
        Else
            txtEstudiosPadre.Enabled = True
            txtEstudiosPadre.Focus()
        End If
    End Sub

    Private Sub ComboBox12_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbApoderado.SelectedIndexChanged
        If cbApoderado.SelectedIndex = "3" Then
            txtNombreApoderado.Enabled = True
            txtNombreApoderado.Focus()
        Else
            txtNombreApoderado.Enabled = False
        End If
    End Sub

    Private Sub ComboBox13_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbApoSuplente.SelectedIndexChanged
        If cbApoSuplente.SelectedIndex = "3" Then
            txtNombreApodSuplent.Enabled = True
            txtNombreApodSuplent.Focus()
        Else
            txtNombreApodSuplent.Enabled = False
        End If
    End Sub


    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        indiceTab = TabControl1.SelectedIndex
        TabControl1.SelectTab(indiceTab - 1)
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        indiceTab = TabControl1.SelectedIndex
        TabControl1.SelectTab(indiceTab - 1)
    End Sub

    Private Sub txtOtrosServicios_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOtrosServicios.TextChanged
        If txtOtrosServicios.Text <> "" Then
            comboServSalud.Enabled = False
        ElseIf txtOtrosServicios.Text = "" Then
            comboServSalud.Enabled = True
        End If
    End Sub

    Private Sub txtRutAlumno_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtRutAlumno.KeyPress
        If InStr(1, "0123456789,-" & Chr(8) & Chr(13), e.KeyChar) = 0 Then
            e.KeyChar = ""
            e.Handled = True
            MsgBox("Porfavor ingresar sólo dígitos y guión")
        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            e.Handled = True

            ComprobarRut(txtRutAlumno.Text)
            If ComprobarRut(txtRutAlumno.Text) = False Then
                MsgBox("El Rut ingresado no es valido")
                txtRutAlumno.Focus()
            Else
                My.Computer.Keyboard.SendKeys("{tab}", True)
            End If
        End If
    End Sub

    Private Sub txtRutPadre_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtRutPadre.KeyPress
        If InStr(1, "0123456789,-" & Chr(8) & Chr(13), e.KeyChar) = 0 Then
            e.KeyChar = ""
            e.Handled = True
            MsgBox("Porfavor ingresar sólo dígitos y guión")
        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            e.Handled = True

            ComprobarRut(txtRutPadre.Text)
            If ComprobarRut(txtRutPadre.Text) = False Then
                MsgBox("El Rut ingresado no es valido")
                txtRutPadre.Focus()
            Else
                My.Computer.Keyboard.SendKeys("{tab}", True)
            End If
        End If
    End Sub

    Private Sub txtRutMadre_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtRutMadre.KeyPress
        If InStr(1, "0123456789,-" & Chr(8) & Chr(13), e.KeyChar) = 0 Then
            e.KeyChar = ""
            e.Handled = True
            MsgBox("Porfavor ingresar sólo dígitos y guión")
        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            e.Handled = True

            ComprobarRut(txtRutMadre.Text)
            If ComprobarRut(txtRutMadre.Text) = False Then
                MsgBox("El Rut ingresado no es valido")
                txtRutMadre.Focus()
            Else
                My.Computer.Keyboard.SendKeys("{tab}", True)
            End If
        End If
    End Sub

    Private Sub txtRut_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtRut.KeyPress
        If InStr(1, "0123456789,-" & Chr(8) & Chr(13), e.KeyChar) = 0 Then
            e.KeyChar = ""
            e.Handled = True
            MsgBox("Porfavor ingresar sólo dígitos y guión")
        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            e.Handled = True

            ComprobarRut(txtRut.Text)
            If ComprobarRut(txtRut.Text) = False Then
                MsgBox("El Rut ingresado no es valido")
                txtRut.Focus()
            Else
                My.Computer.Keyboard.SendKeys("{tab}", True)
            End If
        End If
    End Sub
End Class