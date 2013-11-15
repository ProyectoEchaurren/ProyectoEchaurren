Imports MySql.Data.MySqlClient

Public Class FormularioMatricula

    Public indiceTab As Integer
    Public varConexion As MySqlConnection
    Public varConexionString As String = "server=localhost;User Id=root;password=123456;database=bd_echaurren"
    Public consultaCargaCombo As String = "SELECT * FROM bd_echaurren.servicio_salud;"


    Private Sub FormularioMatricula_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        DateTimePicker1.Format = DateTimePickerFormat.Custom
        DateTimePicker1.CustomFormat = "dd/MM/yyyy"
        DateTimePicker1.MaxDate = Now()

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
        ElseIf ComboBox1.SelectedIndex = 1 Then
            GroupBox2.Show()
            GroupBox3.Hide()
        ElseIf ComboBox1.SelectedIndex = 2 Then
            GroupBox2.Show()
            GroupBox3.Show()
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

        While checkpadre.Checked = True

            If txtNombrePadre.Text = "" Or txtRutPadre.Text = "" Or txtEdadPadre.Text = "" Or cbEstudiosPadre.Text = "" _
                Or txtEstudiosPadre.Text = "" Or txtTrabajaenPadre.Text = "" Or txtTelefonoPadre.Text = "" Or txtCargoPadre.Text = "" _
                Or txtDireccionPadre.Text = "" Or txtCorreoPadre.Text = "" Then
                MessageBox.Show("Debe ingresar todos los datos del padre", "Antecedentes familiares", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            Exit While

        End While

        While checkmadre.Checked = True

            If txtNombreMadre.Text = "" Or txtRutMadre.Text = "" Or txtEdadMadre.Text = "" Or cbEstudiosMadre.Text = "" _
                Or txtEstudiosMadre.Text = "" Or txtTrabajaenMadre.Text = "" Or txtTelefonoMadre.Text = "" Or txtCargoMadre.Text = "" _
                Or txtDireccionMadre.Text = "" Or txtCorreoMadre.Text = "" Then
                MessageBox.Show("Debe ingresar todos los datos de la madre", "Antecedentes familiares", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            Exit While
        End While


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
            Exit While
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

        If txtOtrosServicios.Enabled = True And txtOtrosServicios.Text = "" Then
            MessageBox.Show("Debe ingresar otro tipo de servicio de salud", "Datos alumno", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If


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

        If cbViveCon.SelectedIndex <> "4" Then
            txtViveConOtros.Text = ""
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

    Private Sub txtRutAlumno_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRutAlumno.KeyPress
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

    Private Sub txtRutPadre_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRutPadre.KeyPress
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

    Private Sub txtRutMadre_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRutMadre.KeyPress
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

    Private Sub txtRut_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRut.KeyPress
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

    Private Sub btnTerminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTerminar.Click

        Dim valorSexo As String = ""
        Dim varHermano As String = ""
        Dim varViveCon As String = ""
        Dim becado As Integer
        Dim servSalud As String = ""
        Dim otroServSalud As String = ""
        '
        If CheckBox1.Checked = False Then
            becado = 0
        ElseIf CheckBox1.Checked = True Then
            becado = 1
        End If

        If radioMasc.Checked = True Then
            valorSexo = "Masculino"
        ElseIf radioFeme.Checked = True Then
            valorSexo = "Femenino"
        End If

        If radioHermanosNo.Checked = True Then
            varHermano = "Sin hermanos"
        Else
            varHermano = txtHermanosCursos.Text
        End If

        If cbViveCon.Text = "Otros (especificar)" Then
            varViveCon = txtViveConOtros.Text
        Else
            varViveCon = cbViveCon.Text
        End If

        If ModuloContenedor.ingresarAlumno(DateTimePicker1, becado, txtApePatAlumno.Text, txtApeMatAlumno.Text, txtNombresAlumno.Text, _
                                      txtRutAlumno.Text, valorSexo, dateTimeFechaNac, txtEdadAlumno.Text, txtCalleAlumno.Text, _
                                         txtSectorAlumno.Text, txtCurso.Text, txtComunaAlumno.Text, txtTelefonoAlumno.Text, _
                                             txtColegioPrese.Text, txtCursosRepetidos.Text, varHermano, varViveCon, txtNumHijos.Text, _
                                              txtLugarHijos.Text, txtGrupoFamiliar.Text, txtAntecedentesMed.Text) = True Then
            MessageBox.Show("Alumno ingresado", "Matricula", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            MessageBox.Show("Error al ingresar alumno", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If


        If comboServSalud.Text = "masvida" Then
            servSalud = "ss0"
        ElseIf comboServSalud.Text = "colmena" Then
            servSalud = "ss1"
        ElseIf comboServSalud.Text = "banmedica" Then
            servSalud = "ss2"
        ElseIf comboServSalud.Text = "consalud" Then
            servSalud = "ss3"
        ElseIf comboServSalud.Text = "cruz blanca" Then
            servSalud = "ss4"
        ElseIf comboServSalud.Text = "vida tres" Then
            servSalud = "ss5"
        ElseIf comboServSalud.Text = "ferrosalud" Then
            servSalud = "ss6"
        ElseIf comboServSalud.Text = "fonasa a" Then
            servSalud = "ss7"
        ElseIf comboServSalud.Text = "fonasa b" Then
            servSalud = "ss8"
        ElseIf comboServSalud.Text = "fonasa c" Then
            servSalud = "ss9"
        ElseIf comboServSalud.Text = "otro" Then
            servSalud = "ss99"
            otroServSalud = txtOtrosServicios.Text
        End If


        If ModuloContenedor.ingresarServSalud(servSalud, otroServSalud, txtSeguros.Text) = True Then
            MessageBox.Show("Servicio salud ingresado")
        Else
            MessageBox.Show("Error al ingresar servicio de salud", "Error")
            Exit Sub
        End If

        If ModuloContenedor.ingresarContactEmergencia(txtNombreContacto.Text, txtNumContacto.Text, txtNombreContacto2.Text, _
                                                      txtNumContacto2.Text, txtNombreContacto3.Text, txtNumContacto3.Text) = True Then
        Else
            MessageBox.Show("Error al ingresar contactos de emergencia")
            Exit Sub
        End If

        '   If ModuloContenedor.insertarPadre(txtNombrePadre.Text, txtRutPadre.Text, txtEdadPadre.Text, cbEstudiosPadre, _
        '                                    txtTrabajaenPadre.Text, txtTelefonoPadre.Text, txtCargoPadre.Text, _
        '                                      txtDireccionPadre.Text, txtCorreoPadre.Text) = True Then
        'MessageBox.Show("padre agregado")
        'Else
        'Exit Sub
        'End If

        ' If ModuloContenedor.insertarMadre(txtNombreMadre.Text, txtRutMadre.Text, txtEdadMadre.Text, cbEstudiosMadre, _
        '                              txtTrabajaenMadre.Text, txtTelefonoMadre.Text, txtCargoMadre.Text, _
        '                                      txtDireccionMadre.Text, txtCorreoMadre.Text) = True Then
        'MessageBox.Show("Madre agregada")
        'Else
        'Exit Sub
        'End If


    End Sub

    Private Sub comboServSalud_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles comboServSalud.SelectedIndexChanged

        While comboServSalud.Text = "otro"
            txtOtrosServicios.Enabled = True
            Exit While
        End While

        While comboServSalud.Text <> "otro"
            txtOtrosServicios.Text = ""
            txtOtrosServicios.Enabled = False
            Exit While
        End While
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        While ComboBox1.Text = "1 Contacto"
            If txtNombreContacto.Text = "" Or txtNumContacto.Text = "" Then
                MessageBox.Show("Debe ingresar el contacto de emergencia", "Datos de alumno", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            Exit While
        End While
        
        While ComboBox1.Text = "2 Contactos"
            If txtNombreContacto.Text = "" Or txtNumContacto.Text = "" Or txtNombreContacto2.Text = "" Or txtNumContacto2.Text = "" Then
                MessageBox.Show("Debe ingresar los contactos de emergencia", "Datos de alumno", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            Exit While
        End While

        While ComboBox1.Text = "3 Contactos"
            If txtNombreContacto.Text = "" Or txtNumContacto.Text = "" Or txtNombreContacto2.Text = "" Or txtNumContacto2.Text = "" _
            Or txtNombreContacto3.Text = "" Or txtNumContacto3.Text = "" Then
                MessageBox.Show("Debe ingresar los contactos de emergencia", "Datos de alumno", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            Exit While
        End While

        indiceTab = TabControl1.SelectedIndex
        TabControl1.DeselectTab(indiceTab)
    End Sub

    Private Sub Button2_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If MessageBox.Show("¿Está seguro(a) de salir sin guardar?", "¡Alerta!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub checkpadre_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles checkpadre.CheckedChanged
        While checkpadre.Checked = True

            txtNombrePadre.Enabled = True
            txtRutPadre.Enabled = True
            txtEdadPadre.Enabled = True
            cbEstudiosPadre.Enabled = True
            txtEstudiosPadre.Enabled = True
            txtTrabajaenPadre.Enabled = True
            txtTelefonoPadre.Enabled = True
            txtCargoPadre.Enabled = True
            txtDireccionPadre.Enabled = True
            txtCorreoPadre.Enabled = True
            Exit While

        End While

        While checkpadre.Checked = False

            txtNombrePadre.Enabled = False
            txtRutPadre.Enabled = False
            txtEdadPadre.Enabled = False
            cbEstudiosPadre.Enabled = False
            txtEstudiosPadre.Enabled = False
            txtTrabajaenPadre.Enabled = False
            txtTelefonoPadre.Enabled = False
            txtCargoPadre.Enabled = False
            txtDireccionPadre.Enabled = False
            txtCorreoPadre.Enabled = False

            txtNombrePadre.Text = ""
            txtRutPadre.Text = ""
            txtEdadPadre.Text = ""
            cbEstudiosPadre.Text = ""
            txtEstudiosPadre.Text = ""
            txtTrabajaenPadre.Text = ""
            txtTelefonoPadre.Text = ""
            txtCargoPadre.Text = ""
            txtDireccionPadre.Text = ""
            txtCorreoPadre.Text = ""

            Exit While

        End While
    End Sub

    Private Sub checkmadre_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles checkmadre.CheckedChanged

        While checkmadre.Checked = True

            txtNombreMadre.Enabled = True
            txtRutMadre.Enabled = True
            txtEdadMadre.Enabled = True
            cbEstudiosMadre.Enabled = True
            txtEstudiosMadre.Enabled = True
            txtTrabajaenMadre.Enabled = True
            txtTelefonoMadre.Enabled = True
            txtCargoMadre.Enabled = True
            txtDireccionMadre.Enabled = True
            txtCorreoMadre.Enabled = True
            Exit While

        End While

        While checkmadre.Checked = False

            txtNombreMadre.Enabled = False
            txtRutMadre.Enabled = False
            txtEdadMadre.Enabled = False
            cbEstudiosMadre.Enabled = False
            txtEstudiosMadre.Enabled = False
            txtTrabajaenMadre.Enabled = False
            txtTelefonoMadre.Enabled = False
            txtCargoMadre.Enabled = False
            txtDireccionMadre.Enabled = False
            txtCorreoMadre.Enabled = False

            txtNombreMadre.Text = ""
            txtRutMadre.Text = ""
            txtEdadMadre.Text = ""
            cbEstudiosMadre.Text = ""
            txtEstudiosMadre.Text = ""
            txtTrabajaenMadre.Text = ""
            txtTelefonoMadre.Text = ""
            txtCargoMadre.Text = ""
            txtDireccionMadre.Text = ""
            txtCorreoMadre.Text = ""

            Exit While
        End While
    End Sub

    Private Sub RadioButton9_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton9.CheckedChanged

        While RadioButton9.Checked = True

            txtNombreTutor.Text = txtNombrePadre.Text
            txtRut.Text = txtRutPadre.Text
            txtTelefonoTrabajo.Text = txtTelefonoPadre.Text
            txtLugarDeTrabajo.Text = txtTrabajaenPadre.Text
            txtOcupacionAct.Text = txtCargoPadre.Text
            Exit While
        End While
    End Sub

    Private Sub RadioButton13_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton13.CheckedChanged

        While RadioButton13.Checked = True

            txtNombreTutor.Text = txtNombreMadre.Text
            txtRut.Text = txtRutMadre.Text
            txtTelefonoTrabajo.Text = txtTelefonoMadre.Text
            txtLugarDeTrabajo.Text = txtTrabajaenMadre.Text
            txtOcupacionAct.Text = txtCargoMadre.Text
            Exit While
        End While
    End Sub
End Class