Imports MySql.Data.MySqlClient
Imports System.Drawing.Printing

Public Class FormularioMatricula

    Public indiceTab As Integer
    Public varAñoActual As Integer
    Public varConexion As MySqlConnection
    Public varConexionString As String = "server=localhost;User Id=root;password=123456;database=bd_echaurren"
    Public consultaCargaCombo As String = "SELECT * FROM bd_echaurren.servicio_salud;"
    Public consultaCargaComboCurso As String = "SELECT * FROM bd_echaurren.curso;"
    Public consultaCargaComboComuna As String = "SELECT * FROM bd_echaurren.comuna;"
    Dim ContenidoDelTexto As PrintPageEventArgs
    Dim WithEvents Reporte As New PrintDocument()

    Public oldTutor As String
    Public oldAlumno As String
    Public oldPadre As String
    Public oldMadre As String
    Public oldApoderado As String
    Public oldSuplente As String
    Public varidCont1 As Integer
    Public varidCont2 As Integer
    Public varidCont3 As Integer



    Private Sub FormularioMatricula_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        DateTimePicker1.Format = DateTimePickerFormat.Custom
        DateTimePicker1.CustomFormat = "dd/MM/yyyy"
        DateTimePicker1.MaxDate = Now()

        dateTimeFechaNac.Format = DateTimePickerFormat.Custom
        dateTimeFechaNac.CustomFormat = "dd/MM/yyyy"
        dateTimeFechaNac.MaxDate = Now()

        varAñoActual = Year(Now)

        Try
            varConexion = New MySqlConnection
            varConexion.ConnectionString = varConexionString
            varConexion.Open()
        Catch ex As Exception
            MessageBox.Show("Error al conectar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End Try

        If ModuloContenedor.cargarComboCurso(consultaCargaComboCurso, varConexion) = True Then
        Else
            MessageBox.Show("Error al cargar los cursos")
        End If

        If ModuloContenedor.cargarComboComuna(consultaCargaComboComuna, varConexion) = True Then
        Else
            MessageBox.Show("Error al cargar comunas")
        End If

        If ModuloContenedor.cargarComboServSalud(consultaCargaCombo, varConexion) = True Then
        Else
            MessageBox.Show("Error al cargar servicios de salud", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

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
            And txtCalleAlumno.Text = "" And txtSectorAlumno.Text = "" Or txtTelefonoAlumno.Text = "" Or txtColegioPrese.Text = "" Or txtCursosRepetidos.Text = "" Then

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
        If MessageBox.Show("¿Está seguro(a) de querer salir?", "¡Alerta!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
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
        If cbApoderado.SelectedIndex = "2" Then
            txtNombreApoderado.Enabled = True
            txtRutOtroApod.Enabled = True
            txtNombreApoderado.Focus()
        Else
            txtNombreApoderado.Enabled = False
            txtRutOtroApod.Enabled = False
        End If
    End Sub

    Private Sub ComboBox13_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbApoSuplente.SelectedIndexChanged
        If cbApoSuplente.SelectedIndex = "2" Then
            txtNombreApodSuplent.Enabled = True
            txtRutOtroApodSuple.Enabled = True
            txtNombreApodSuplent.Focus()
        Else
            txtNombreApodSuplent.Enabled = False
            txtRutOtroApodSuple.Enabled = False
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
        If txtRutAntiguo.Text <> "" Or MessageBox.Show("El alumno a matricular, ¿Es alumno antiguo?", "¡Pregunta!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            Dim valorSexo As String = ""
            Dim varHermano As String = ""
            Dim varViveCon As String = ""
            Dim becado As Integer
            Dim servSalud As String = ""
            Dim otroServSalud As String = ""
            Dim varApoderadoPadre As Integer = 0
            Dim varApoderadoSuplePadre As Integer = 0
            Dim varApoderadoMadre As Integer = 0
            Dim varApoderadoSupleMadre As Integer = 0
            Dim varResponsablePadre As String = "tr1"
            Dim varResponsableMadre As String = "tr2"
            Dim varResponsableTutor As String = "tr3"
            Dim varapoderadoOtro As Integer = 0
            Dim varApoderadoSupleOtro As Integer = 0
            Dim varTutor As Integer = 0
            Dim varTutor2 As Integer = 0
            Dim varCurso As String = ""
            Dim varComuna As String = ""

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
                varHermano = "No"
            Else
                varHermano = "Si"
            End If

            If cbApoderado.Text = "Padre" Then
                varApoderadoPadre = 1
            ElseIf cbApoderado.Text = "Madre" Then
                varApoderadoMadre = 1
            ElseIf cbApoderado.Text = "Otro" Then
            End If

            If cbApoSuplente.Text = "Padre" Then
                varApoderadoSuplePadre = 1
            ElseIf cbApoSuplente.Text = "Madre" Then
                varApoderadoSupleMadre = 1
            ElseIf cbApoSuplente.Text = "Otro" Then
            End If

            varComuna = comboComuna.SelectedValue
            varCurso = comboCurso.SelectedValue
            servSalud = comboServSalud.SelectedValue

            '-------------------------------------------------

            If ModuloContenedor.ActualizarMatriculas(DateTimePicker1, txtApePatAlumno.Text, txtApeMatAlumno.Text, txtNombresAlumno.Text, _
                                               txtRutAlumno.Text, valorSexo, dateTimeFechaNac, txtEdadAlumno.Text, txtCalleAlumno.Text, _
                                               txtSectorAlumno.Text, varCurso, varComuna, txtTelefonoAlumno.Text, _
                                               txtColegioPrese.Text, txtCursosRepetidos.Text, becado, varHermano, txtHermanosCursos.Text, _
                                               varViveCon, txtNumHijos.Text, txtLugarHijos.Text, txtGrupoFamiliar.Text, txtAntecedentesMed.Text, servSalud, _
                                               otroServSalud, txtSeguros.Text, oldAlumno, txtNumMatri.Text, txtViveConOtros.Text) = True Then
            Else
                MessageBox.Show("Error al actualizar datos de alumno(a)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            ModuloContenedor.ActualizarContactos(txtNombreContacto.Text, txtNumContacto.Text, txtNombreContacto2.Text, txtNumContacto2.Text, txtNombreContacto3.Text, txtNumContacto3.Text, txtRutAlumno.Text, oldAlumno, varidCont1, varidCont2, varidCont3)

            If checkIguales.Checked = True Then
                varapoderadoOtro = 1
                varApoderadoSupleOtro = 1
                ModuloContenedor.updateOtroApod(txtRutOtroApodSuple.Text, txtRutAlumno.Text, varapoderadoOtro, varApoderadoSupleOtro, _
                                              txtNombreApodSuplent.Text, txtNumMatri.Text, oldApoderado, oldAlumno)

            ElseIf cbApoderado.Text = "Otro" And cbApoSuplente.Text = "Otro" Then
                varapoderadoOtro = 1
                varApoderadoSupleOtro = 0
                ModuloContenedor.updateOtroApod(txtRutOtroApod.Text, txtRutAlumno.Text, varapoderadoOtro, varApoderadoSupleOtro, _
                                              txtNombreApoderado.Text, txtNumMatri.Text, oldApoderado, oldAlumno)
                varapoderadoOtro = 0
                varApoderadoSupleOtro = 1
                ModuloContenedor.updateOtroApod(txtRutOtroApodSuple.Text, txtRutAlumno.Text, varapoderadoOtro, varApoderadoSupleOtro, _
                                              txtNombreApodSuplent.Text, txtNumMatri.Text, oldSuplente, oldAlumno)

            ElseIf checkIguales.Checked = False And cbApoderado.Text = "Otro" Then
                varapoderadoOtro = 1
                varApoderadoSupleOtro = 0
                ModuloContenedor.updateOtroApod(txtRutOtroApod.Text, txtRutAlumno.Text, varapoderadoOtro, varApoderadoSupleOtro, _
                                              txtNombreApoderado.Text, txtNumMatri.Text, oldApoderado, oldAlumno)

            ElseIf checkIguales.Checked = False And cbApoSuplente.Text = "Otro" Then
                varapoderadoOtro = 0
                varApoderadoSupleOtro = 1
                ModuloContenedor.updateOtroApod(txtRutOtroApodSuple.Text, txtRutAlumno.Text, varapoderadoOtro, varApoderadoSupleOtro, _
                                              txtNombreApodSuplent.Text, txtNumMatri.Text, oldSuplente, oldAlumno)
            End If

            '------------------------------------------------------------------------

            If RadioButton14.Checked = True And RadioButton9.Checked = False And RadioButton13.Checked = False Then

                ModuloContenedor.updateTutorEconomico(txtNombreTutor.Text, txtRut.Text, txtTelefonoPart.Text, txtTelefonoPart2.Text, _
                                                    txtTelefonoTrabajo.Text, txtDomicilio.Text, txtLugarDeTrabajo.Text, _
                                                        txtOcupacionAct.Text, txtProfesion.Text, oldTutor)
                ModuloContenedor.updateAlumno_respons_tutor(txtRut.Text, txtRutAlumno.Text, varResponsableTutor, varTutor, _
                                                          varTutor2, txtOtro.Text, txtNumMatri.Text, oldTutor, oldAlumno)
            End If
            

            If checkpadre.Checked = True And RadioButton9.Checked = True Then

                ModuloContenedor.updateResponsableCompleto(txtRut.Text, txtNombreTutor.Text, txtTelefonoPart.Text, txtTelefonoPart2.Text, _
                                                             txtTelefonoTrabajo.Text, txtDomicilio.Text, txtDireccionPadre.Text, _
                                                             txtEdadPadre.Text, cbEstudiosPadre, txtCorreoPadre.Text, txtProfesion.Text, _
                                                             txtLugarDeTrabajo.Text, txtOcupacionAct.Text, oldPadre)
                ModuloContenedor.updateAlumno_respons(txtRutPadre.Text, txtRutAlumno.Text, varResponsablePadre, varApoderadoPadre, _
                                                         varApoderadoSuplePadre, txtNumMatri.Text, oldPadre, oldAlumno)
                ModuloContenedor.updateAlumno_respons(txtRutPadre.Text, txtRutAlumno.Text, varResponsableTutor, varApoderadoPadre, _
                                                         varApoderadoSuplePadre, txtNumMatri.Text, oldPadre, oldAlumno)
            End If

            If checkmadre.Checked = True And RadioButton13.Checked = True Then

                ModuloContenedor.updateResponsableCompleto(txtRut.Text, txtNombreTutor.Text, txtTelefonoPart.Text, txtTelefonoPart2.Text, _
                                                             txtTelefonoTrabajo.Text, txtDomicilio.Text, txtDireccionMadre.Text, _
                                                             txtEdadMadre.Text, cbEstudiosMadre, txtCorreoMadre.Text, txtProfesion.Text, _
                                                             txtLugarDeTrabajo.Text, txtOcupacionAct.Text, oldMadre)
                ModuloContenedor.updateAlumno_respons(txtRutMadre.Text, txtRutAlumno.Text, varResponsableMadre, varApoderadoMadre, _
                                                        varApoderadoSupleMadre, txtNumMatri.Text, oldMadre, oldAlumno)
                ModuloContenedor.updateAlumno_respons(txtRutMadre.Text, txtRutAlumno.Text, varResponsableTutor, varApoderadoMadre, _
                                                        varApoderadoSupleMadre, txtNumMatri.Text, oldMadre, oldAlumno)
            End If

            If checkpadre.Checked = True And RadioButton9.Checked = False Then

                ModuloContenedor.updateResp(txtNombrePadre.Text, txtRutPadre.Text, txtEdadPadre.Text, cbEstudiosPadre, _
                                                 txtTrabajaenPadre.Text, txtTelefonoPadre.Text, txtCargoPadre.Text, _
                                                txtDireccionPadre.Text, txtCorreoPadre.Text, oldPadre)
                ModuloContenedor.updateAlumno_respons(txtRutPadre.Text, txtRutAlumno.Text, varResponsablePadre, varApoderadoPadre, _
                                                       varApoderadoSuplePadre, txtNumMatri.Text, oldPadre, oldAlumno)
            End If

            If checkmadre.Checked = True And RadioButton13.Checked = False Then

                ModuloContenedor.updateResp(txtNombreMadre.Text, txtRutMadre.Text, txtEdadMadre.Text, cbEstudiosMadre, _
                                                txtTrabajaenMadre.Text, txtTelefonoMadre.Text, txtCargoMadre.Text, _
                                                txtDireccionMadre.Text, txtCorreoMadre.Text, oldMadre)
                ModuloContenedor.updateAlumno_respons(txtRutMadre.Text, txtRutAlumno.Text, varResponsableMadre, varApoderadoMadre, _
                                                        varApoderadoSupleMadre, txtNumMatri.Text, oldPadre, oldAlumno)
            End If

            If txtMontoMarzo.Text <> "" And cbbDiaMarzo.Text <> "Día" And txtDocMarzo.Text <> "" Then
                ModuloContenedor.ActualizarMensualidades(txtRutAlumno.Text, lblMarzo.Text, cbbTipoPago, txtMontoMarzo.Text, varAñoActual & "-03-" & cbbDiaMarzo.Text, txtDocMarzo.Text, txtMontoAnual.Text, txtNombreTitular.Text, txtNombreBanco.Text, txtCtaCorriente.Text)
            Else
                MsgBox("Asegurese de llenar los campos correspondientes al mes de Marzo", MsgBoxStyle.Exclamation)
                Exit Sub
            End If
            If txtMontoAbril.Text <> "" And cbbDiaAbril.Text <> "Día" And txtDocAbril.Text <> "" Then
                ModuloContenedor.ActualizarMensualidades(txtRutAlumno.Text, lblAbril.Text, cbbTipoPago, txtMontoAbril.Text, varAñoActual & "-04-" & cbbDiaAbril.Text, txtDocAbril.Text, txtMontoAnual.Text, txtNombreTitular.Text, txtNombreBanco.Text, txtCtaCorriente.Text)
            Else
                MsgBox("Asegurese de llenar los campos correspondientes al mes de Abril", MsgBoxStyle.Exclamation)
                Exit Sub
            End If
            If txtMontoMayo.Text <> "" And cbbDiaMayo.Text <> "Día" And txtDocMayo.Text <> "" Then
                ModuloContenedor.ActualizarMensualidades(txtRutAlumno.Text, lblMayo.Text, cbbTipoPago, txtMontoMayo.Text, varAñoActual & "-05-" & cbbDiaMayo.Text, txtDocMayo.Text, txtMontoAnual.Text, txtNombreTitular.Text, txtNombreBanco.Text, txtCtaCorriente.Text)
            Else
                MsgBox("Asegurese de llenar los campos correspondientes al mes de Mayo", MsgBoxStyle.Exclamation)
                Exit Sub
            End If
            If txtMontoJunio.Text <> "" And cbbDiaJunio.Text <> "Día" And txtDocJunio.Text <> "" Then
                ModuloContenedor.ActualizarMensualidades(txtRutAlumno.Text, lblJunio.Text, cbbTipoPago, txtMontoJunio.Text, varAñoActual & "-06-" & cbbDiaJunio.Text, txtDocJunio.Text, txtMontoAnual.Text, txtNombreTitular.Text, txtNombreBanco.Text, txtCtaCorriente.Text)
            Else
                MsgBox("Asegurese de llenar los campos correspondientes al mes de Junio", MsgBoxStyle.Exclamation)
                Exit Sub
            End If
            If txtMontoJulio.Text <> "" And cbbDiaJulio.Text <> "Día" And txtDocJulio.Text <> "" Then
                ModuloContenedor.ActualizarMensualidades(txtRutAlumno.Text, lblJulio.Text, cbbTipoPago, txtMontoJulio.Text, varAñoActual & "-07-" & cbbDiaJulio.Text, txtDocJulio.Text, txtMontoAnual.Text, txtNombreTitular.Text, txtNombreBanco.Text, txtCtaCorriente.Text)
            Else
                MsgBox("Asegurese de llenar los campos correspondientes al mes de Julio", MsgBoxStyle.Exclamation)
                Exit Sub
            End If
            If txtMontoAgosto.Text <> "" And cbbDiaAgosto.Text <> "Día" And txtDocAgosto.Text <> "" Then
                ModuloContenedor.ActualizarMensualidades(txtRutAlumno.Text, lblAgosto.Text, cbbTipoPago, txtMontoAgosto.Text, varAñoActual & "-08-" & cbbDiaAgosto.Text, txtDocAgosto.Text, txtMontoAnual.Text, txtNombreTitular.Text, txtNombreBanco.Text, txtCtaCorriente.Text)
            Else
                MsgBox("Asegurese de llenar los campos correspondientes al mes de Agosto", MsgBoxStyle.Exclamation)
                Exit Sub
            End If
            If txtMontoSept.Text <> "" And cbbDiaSept.Text <> "Día" And txtDocSept.Text <> "" Then
                ModuloContenedor.ActualizarMensualidades(txtRutAlumno.Text, lblSept.Text, cbbTipoPago, txtMontoSept.Text, varAñoActual & "-09-" & cbbDiaSept.Text, txtDocSept.Text, txtMontoAnual.Text, txtNombreTitular.Text, txtNombreBanco.Text, txtCtaCorriente.Text)
            Else
                MsgBox("Asegurese de llenar los campos correspondientes al mes de Septiembre", MsgBoxStyle.Exclamation)
                Exit Sub
            End If
            If txtMontoOctubre.Text <> "" And cbbDiaOctubre.Text <> "Día" And txtDocOctubre.Text <> "" Then
                ModuloContenedor.ActualizarMensualidades(txtRutAlumno.Text, lblOctubre.Text, cbbTipoPago, txtMontoOctubre.Text, varAñoActual & "-10-" & cbbDiaOctubre.Text, txtDocOctubre.Text, txtMontoAnual.Text, txtNombreTitular.Text, txtNombreBanco.Text, txtCtaCorriente.Text)
            Else
                MsgBox("Asegurese de llenar los campos correspondientes al mes de Octubre", MsgBoxStyle.Exclamation)
                Exit Sub
            End If
            If txtMontoNov.Text <> "" And cbbDiaNov.Text <> "Día" And txtDocNov.Text <> "" Then
                ModuloContenedor.ActualizarMensualidades(txtRutAlumno.Text, lblNov.Text, cbbTipoPago, txtMontoNov.Text, varAñoActual & "-11-" & cbbDiaNov.Text, txtDocNov.Text, txtMontoAnual.Text, txtNombreTitular.Text, txtNombreBanco.Text, txtCtaCorriente.Text)
            Else
                MsgBox("Asegurese de llenar los campos correspondientes al mes de Noviembre", MsgBoxStyle.Exclamation)
                Exit Sub
            End If
            If txtMontoDic.Text <> "" And cbbDiaDic.Text <> "Día" And txtDocDic.Text <> "" Then
                ModuloContenedor.ActualizarMensualidades(txtRutAlumno.Text, lblDic.Text, cbbTipoPago, txtMontoDic.Text, varAñoActual & "-12-" & cbbDiaDic.Text, txtDocDic.Text, txtMontoAnual.Text, txtNombreTitular.Text, txtNombreBanco.Text, txtCtaCorriente.Text)
            Else
                MsgBox("Asegurese de llenar los campos correspondientes al mes de Diciembre", MsgBoxStyle.Exclamation)
                Exit Sub
            End If

        ElseIf txtRutAntiguo.Text = "" Or MessageBox.Show("El alumno a matricular, ¿Es alumno nuevo?", "¡Pregunta!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            Dim valorSexo As String = ""
            Dim varHermano As String = ""
            Dim varViveCon As String = ""
            Dim becado As Integer
            Dim servSalud As String = ""
            Dim otroServSalud As String = ""
            Dim varApoderadoPadre As Integer = 0
            Dim varApoderadoSuplePadre As Integer = 0
            Dim varApoderadoMadre As Integer = 0
            Dim varApoderadoSupleMadre As Integer = 0
            Dim varResponsablePadre As String = "tr1"
            Dim varResponsableMadre As String = "tr2"
            Dim varResponsableTutor As String = "tr3"
            Dim varapoderadoOtro As Integer = 0
            Dim varApoderadoSupleOtro As Integer = 0
            Dim varTutor As Integer = 0
            Dim varTutor2 As Integer = 0
            Dim varCurso As String = ""
            Dim varComuna As String = ""

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
                varHermano = "No"
            Else
                varHermano = "Si"
            End If

            varComuna = comboComuna.SelectedValue
            varCurso = comboCurso.SelectedValue
            servSalud = comboServSalud.SelectedValue

            If ModuloContenedor.ingresarAlumno(DateTimePicker1, txtApePatAlumno.Text, txtApeMatAlumno.Text, txtNombresAlumno.Text, _
                                               txtRutAlumno.Text, valorSexo, dateTimeFechaNac, txtEdadAlumno.Text, txtCalleAlumno.Text, _
                                               txtSectorAlumno.Text, varCurso, varComuna, txtTelefonoAlumno.Text, _
                                               txtColegioPrese.Text, txtCursosRepetidos.Text, becado, varHermano, _
                                               cbViveCon.Text, txtNumHijos.Text, txtLugarHijos.Text, txtGrupoFamiliar.Text, txtAntecedentesMed.Text, txtViveConOtros.Text, txtHermanosCursos.Text, txtNumMatri.Text, DateTimePicker1) = True Then
            Else
                MessageBox.Show("Error al ingresar alumno", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If


            If ModuloContenedor.ingresarServSalud(servSalud, txtOtrosServicios.Text, txtSeguros.Text) = True Then
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

            If cbApoderado.Text = "Padre" Then
                varApoderadoPadre = 1
            ElseIf cbApoderado.Text = "Madre" Then
                varApoderadoMadre = 1
            ElseIf cbApoderado.Text = "Otro" Then
            End If

            If cbApoSuplente.Text = "Padre" Then
                varApoderadoSuplePadre = 1
            ElseIf cbApoSuplente.Text = "Madre" Then
                varApoderadoSupleMadre = 1
            ElseIf cbApoSuplente.Text = "Otro" Then
            End If

            If checkpadre.Checked = True And RadioButton9.Checked = True Then

                ModuloContenedor.insertarResponsableCompleto(txtRut.Text, txtNombreTutor.Text, txtTelefonoPart.Text, txtTelefonoPart2.Text, _
                                                             txtTelefonoTrabajo.Text, txtDomicilio.Text, txtDireccionPadre.Text, _
                                                             txtEdadPadre.Text, cbEstudiosPadre, txtCorreoPadre.Text, txtProfesion.Text, _
                                                             txtLugarDeTrabajo.Text, txtOcupacionAct.Text)
                ModuloContenedor.insertarAlumno_respons(txtRutPadre.Text, txtRutAlumno.Text, varResponsablePadre, varApoderadoPadre, _
                                                         varApoderadoSuplePadre, txtNumMatri.Text)
                ModuloContenedor.insertarAlumno_respons(txtRutPadre.Text, txtRutAlumno.Text, varResponsableTutor, varApoderadoPadre, _
                                                         varApoderadoSuplePadre, txtNumMatri.Text)
            End If

            If checkmadre.Checked = True And RadioButton13.Checked = True Then

                ModuloContenedor.insertarResponsableCompleto(txtRut.Text, txtNombreTutor.Text, txtTelefonoPart.Text, txtTelefonoPart2.Text, _
                                                             txtTelefonoTrabajo.Text, txtDomicilio.Text, txtDireccionMadre.Text, _
                                                             txtEdadMadre.Text, cbEstudiosMadre, txtCorreoMadre.Text, txtProfesion.Text, _
                                                             txtLugarDeTrabajo.Text, txtOcupacionAct.Text)
                ModuloContenedor.insertarAlumno_respons(txtRutMadre.Text, txtRutAlumno.Text, varResponsableMadre, varApoderadoMadre, _
                                                        varApoderadoSupleMadre, txtNumMatri.Text)
                ModuloContenedor.insertarAlumno_respons(txtRutMadre.Text, txtRutAlumno.Text, varResponsableTutor, varApoderadoMadre, _
                                                        varApoderadoSupleMadre, txtNumMatri.Text)
            End If

            If checkpadre.Checked = True And RadioButton9.Checked = False Then

                ModuloContenedor.insertarPadre(txtNombrePadre.Text, txtRutPadre.Text, txtEdadPadre.Text, cbEstudiosPadre, _
                                                 txtTrabajaenPadre.Text, txtTelefonoPadre.Text, txtCargoPadre.Text, _
                                                txtDireccionPadre.Text, txtCorreoPadre.Text, txtEstudiosPadre.Text)
                ModuloContenedor.insertarAlumno_respons(txtRutPadre.Text, txtRutAlumno.Text, varResponsablePadre, varApoderadoPadre, _
                                                       varApoderadoSuplePadre, txtNumMatri.Text)
            End If

            If checkmadre.Checked = True And RadioButton13.Checked = False Then

                ModuloContenedor.insertarMadre(txtNombreMadre.Text, txtRutMadre.Text, txtEdadMadre.Text, cbEstudiosMadre, _
                                                txtTrabajaenMadre.Text, txtTelefonoMadre.Text, txtCargoMadre.Text, _
                                                txtDireccionMadre.Text, txtCorreoMadre.Text, txtEstudiosMadre.Text)
                ModuloContenedor.insertarAlumno_respons(txtRutMadre.Text, txtRutAlumno.Text, varResponsableMadre, varApoderadoMadre, _
                                                        varApoderadoSupleMadre, txtNumMatri.Text)
            End If

            If checkIguales.Checked = True Then
                varapoderadoOtro = 1
                varApoderadoSupleOtro = 1
                ModuloContenedor.insertarOtroApod(txtRutOtroApodSuple.Text, txtRutAlumno.Text, varapoderadoOtro, varApoderadoSupleOtro, _
                                              txtNombreApodSuplent.Text, txtNumMatri.Text)

            ElseIf cbApoderado.Text = "Otro" And cbApoSuplente.Text = "Otro" Then
                varapoderadoOtro = 1
                varApoderadoSupleOtro = 0
                ModuloContenedor.insertarOtroApod(txtRutOtroApod.Text, txtRutAlumno.Text, varapoderadoOtro, varApoderadoSupleOtro, _
                                              txtNombreApoderado.Text, txtNumMatri.Text)
                varapoderadoOtro = 0
                varApoderadoSupleOtro = 1
                ModuloContenedor.insertarOtroApod(txtRutOtroApodSuple.Text, txtRutAlumno.Text, varapoderadoOtro, varApoderadoSupleOtro, _
                                              txtNombreApodSuplent.Text, txtNumMatri.Text)

            ElseIf checkIguales.Checked = False And cbApoderado.Text = "Otro" Then
                varapoderadoOtro = 1
                varApoderadoSupleOtro = 0
                ModuloContenedor.insertarOtroApod(txtRutOtroApod.Text, txtRutAlumno.Text, varapoderadoOtro, varApoderadoSupleOtro, _
                                              txtNombreApoderado.Text, txtNumMatri.Text)

            ElseIf checkIguales.Checked = False And cbApoSuplente.Text = "Otro" Then
                varapoderadoOtro = 0
                varApoderadoSupleOtro = 1
                ModuloContenedor.insertarOtroApod(txtRutOtroApodSuple.Text, txtRutAlumno.Text, varapoderadoOtro, varApoderadoSupleOtro, _
                                              txtNombreApodSuplent.Text, txtNumMatri.Text)
            End If


            If RadioButton14.Checked = True And RadioButton9.Checked = False And RadioButton13.Checked = False Then

                ModuloContenedor.insertarTutorEconomico(txtNombreTutor.Text, txtRut.Text, txtTelefonoPart.Text, txtTelefonoPart2.Text, _
                                                    txtTelefonoTrabajo.Text, txtDomicilio.Text, txtLugarDeTrabajo.Text, _
                                                        txtOcupacionAct.Text, txtProfesion.Text)
                ModuloContenedor.insertarAlumno_respons_tutor(txtRut.Text, txtRutAlumno.Text, varResponsableTutor, varTutor, _
                                                          varTutor2, txtOtro.Text, txtNumMatri.Text)
            End If

            '---Inicio de Ingreso de Mensualidades y Tipo de Pago a Base de Datos---'

            If txtMontoMarzo.Text <> "" And cbbDiaMarzo.Text <> "Día" And txtDocMarzo.Text <> "" Then
                ModuloContenedor.RegistrarMensualidades(txtRutAlumno.Text, lblMarzo.Text, cbbTipoPago, txtMontoMarzo.Text, varAñoActual & "-03-" & cbbDiaMarzo.Text, txtDocMarzo.Text, txtMontoAnual.Text, txtNombreTitular.Text, txtNombreBanco.Text, txtCtaCorriente.Text)
            Else
                MsgBox("Asegurese de llenar los campos correspondientes al mes de Marzo", MsgBoxStyle.Exclamation)
                Exit Sub
            End If
            If txtMontoAbril.Text <> "" And cbbDiaAbril.Text <> "Día" And txtDocAbril.Text <> "" Then
                ModuloContenedor.RegistrarMensualidades(txtRutAlumno.Text, lblAbril.Text, cbbTipoPago, txtMontoAbril.Text, varAñoActual & "-04-" & cbbDiaAbril.Text, txtDocAbril.Text, txtMontoAnual.Text, txtNombreTitular.Text, txtNombreBanco.Text, txtCtaCorriente.Text)
            Else
                MsgBox("Asegurese de llenar los campos correspondientes al mes de Abril", MsgBoxStyle.Exclamation)
                Exit Sub
            End If
            If txtMontoMayo.Text <> "" And cbbDiaMayo.Text <> "Día" And txtDocMayo.Text <> "" Then
                ModuloContenedor.RegistrarMensualidades(txtRutAlumno.Text, lblMayo.Text, cbbTipoPago, txtMontoMayo.Text, varAñoActual & "-05-" & cbbDiaMayo.Text, txtDocMayo.Text, txtMontoAnual.Text, txtNombreTitular.Text, txtNombreBanco.Text, txtCtaCorriente.Text)
            Else
                MsgBox("Asegurese de llenar los campos correspondientes al mes de Mayo", MsgBoxStyle.Exclamation)
                Exit Sub
            End If
            If txtMontoJunio.Text <> "" And cbbDiaJunio.Text <> "Día" And txtDocJunio.Text <> "" Then
                ModuloContenedor.RegistrarMensualidades(txtRutAlumno.Text, lblJunio.Text, cbbTipoPago, txtMontoJunio.Text, varAñoActual & "-06-" & cbbDiaJunio.Text, txtDocJunio.Text, txtMontoAnual.Text, txtNombreTitular.Text, txtNombreBanco.Text, txtCtaCorriente.Text)
            Else
                MsgBox("Asegurese de llenar los campos correspondientes al mes de Junio", MsgBoxStyle.Exclamation)
                Exit Sub
            End If
            If txtMontoJulio.Text <> "" And cbbDiaJulio.Text <> "Día" And txtDocJulio.Text <> "" Then
                ModuloContenedor.RegistrarMensualidades(txtRutAlumno.Text, lblJulio.Text, cbbTipoPago, txtMontoJulio.Text, varAñoActual & "-07-" & cbbDiaJulio.Text, txtDocJulio.Text, txtMontoAnual.Text, txtNombreTitular.Text, txtNombreBanco.Text, txtCtaCorriente.Text)
            Else
                MsgBox("Asegurese de llenar los campos correspondientes al mes de Julio", MsgBoxStyle.Exclamation)
                Exit Sub
            End If
            If txtMontoAgosto.Text <> "" And cbbDiaAgosto.Text <> "Día" And txtDocAgosto.Text <> "" Then
                ModuloContenedor.RegistrarMensualidades(txtRutAlumno.Text, lblAgosto.Text, cbbTipoPago, txtMontoAgosto.Text, varAñoActual & "-08-" & cbbDiaAgosto.Text, txtDocAgosto.Text, txtMontoAnual.Text, txtNombreTitular.Text, txtNombreBanco.Text, txtCtaCorriente.Text)
            Else
                MsgBox("Asegurese de llenar los campos correspondientes al mes de Agosto", MsgBoxStyle.Exclamation)
                Exit Sub
            End If
            If txtMontoSept.Text <> "" And cbbDiaSept.Text <> "Día" And txtDocSept.Text <> "" Then
                ModuloContenedor.RegistrarMensualidades(txtRutAlumno.Text, lblSept.Text, cbbTipoPago, txtMontoSept.Text, varAñoActual & "-09-" & cbbDiaSept.Text, txtDocSept.Text, txtMontoAnual.Text, txtNombreTitular.Text, txtNombreBanco.Text, txtCtaCorriente.Text)
            Else
                MsgBox("Asegurese de llenar los campos correspondientes al mes de Septiembre", MsgBoxStyle.Exclamation)
                Exit Sub
            End If
            If txtMontoOctubre.Text <> "" And cbbDiaOctubre.Text <> "Día" And txtDocOctubre.Text <> "" Then
                ModuloContenedor.RegistrarMensualidades(txtRutAlumno.Text, lblOctubre.Text, cbbTipoPago, txtMontoOctubre.Text, varAñoActual & "-10-" & cbbDiaOctubre.Text, txtDocOctubre.Text, txtMontoAnual.Text, txtNombreTitular.Text, txtNombreBanco.Text, txtCtaCorriente.Text)
            Else
                MsgBox("Asegurese de llenar los campos correspondientes al mes de Octubre", MsgBoxStyle.Exclamation)
                Exit Sub
            End If
            If txtMontoNov.Text <> "" And cbbDiaNov.Text <> "Día" And txtDocNov.Text <> "" Then
                ModuloContenedor.RegistrarMensualidades(txtRutAlumno.Text, lblNov.Text, cbbTipoPago, txtMontoNov.Text, varAñoActual & "-11-" & cbbDiaNov.Text, txtDocNov.Text, txtMontoAnual.Text, txtNombreTitular.Text, txtNombreBanco.Text, txtCtaCorriente.Text)
            Else
                MsgBox("Asegurese de llenar los campos correspondientes al mes de Noviembre", MsgBoxStyle.Exclamation)
                Exit Sub
            End If
            If txtMontoDic.Text <> "" And cbbDiaDic.Text <> "Día" And txtDocDic.Text <> "" Then
                ModuloContenedor.RegistrarMensualidades(txtRutAlumno.Text, lblDic.Text, cbbTipoPago, txtMontoDic.Text, varAñoActual & "-12-" & cbbDiaDic.Text, txtDocDic.Text, txtMontoAnual.Text, txtNombreTitular.Text, txtNombreBanco.Text, txtCtaCorriente.Text)
            Else
                MsgBox("Asegurese de llenar los campos correspondientes al mes de Diciembre", MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            '---Fin de Ingreso de Mensualidades y Tipo de Pago a Base de Datos---'
        End If

        MessageBox.Show("Alumno matriculado con exito", "Matricula", MessageBoxButtons.OK, MessageBoxIcon.Information)
        If MessageBox.Show("¿Desea imprimir una(s) copia(s) de los formularios creados?", "¡Atención!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Configurar()
            Reporte.Print()
            If MessageBox.Show("¿Desea generar una nueva matrícula para otro alumno?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                TabPage2.Show()
            End If
        Else
            'guardar copia archivos en computador
            If MessageBox.Show("¿Desea generar una nueva matrícula para otro alumno?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                TabPage2.Show()
            End If
        End If
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

    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles checkIguales.CheckedChanged

        While checkIguales.Checked = True

            txtNombreApodSuplent.Text = txtNombreApoderado.Text
            txtRutOtroApodSuple.Text = txtRutOtroApod.Text
            Exit While
        End While

        While checkIguales.Checked = False

            txtNombreApodSuplent.Text = ""
            txtRutOtroApodSuple.Text = ""
            Exit While
        End While
    End Sub

    Private Sub btnBuscarAlumAnt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarAlumAnt.Click

        ModuloContenedor.AutollenarFormulario(txtRutAntiguo.Text, varConexion)

        oldTutor = txtRut.Text
        oldAlumno = txtRutAlumno.Text
        oldPadre = txtRutPadre.Text
        oldMadre = txtRutMadre.Text
        oldApoderado = txtRutOtroApod.Text
        oldSuplente = txtRutOtroApodSuple.Text

    End Sub

    Public Sub LimpiarTextBox(frm As TabPage)
        ' recorre todos los controles que hay en el formulario
        For Each Control In frm.Controls
            ' verifica que el control es de tipo TextBox
            If TypeOf Control Is TextBox Or TypeOf Control Is ComboBox Then
                '... Si es un Textbox, entonces lo limpia
                Control.Text = ""
            ElseIf TypeOf Control Is CheckBox Or TypeOf Control Is RadioButton Then
                Control.Checked = False
            End If
        Next
    End Sub

    Private Sub btnLimpiar_Click(sender As System.Object, e As System.EventArgs) Handles btnLimpiar.Click
        Call LimpiarTextBox(TabPage2)
    End Sub

    Private Sub btnLimpiar2_Click(sender As System.Object, e As System.EventArgs) Handles btnLimpiar2.Click
        Call LimpiarTextBox(TabPage4)
        txtNombreContacto.Text = ""
        txtNumContacto.Text = ""
        txtNombreContacto2.Text = ""
        txtNumContacto2.Text = ""
        txtNombreContacto3.Text = ""
        txtNumContacto3.Text = ""
    End Sub

    Private Sub btnLimpiar3_Click(sender As System.Object, e As System.EventArgs) Handles btnLimpiar3.Click
        Call LimpiarTextBox(TabPage1)
    End Sub

    Private Sub btnLimpiar4_Click(sender As System.Object, e As System.EventArgs) Handles btnLimpiar4.Click
        Call LimpiarTextBox(TabPage3)
    End Sub

    Private Sub txtTelefonoAlumno_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtTelefonoAlumno.KeyPress
        If Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
            MsgBox("Ingrese sólo números.")
        End If
    End Sub

    Private Sub txtEdadAlumno_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtEdadAlumno.KeyPress
        If Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
            MsgBox("Ingrese sólo números.")
        End If
    End Sub

    Private Sub txtNumContacto_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumContacto.KeyPress
        If Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
            MsgBox("Ingrese sólo números.")
        End If
    End Sub

    Private Sub txtNumContacto2_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumContacto2.KeyPress
        If Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
            MsgBox("Ingrese sólo números.")
        End If
    End Sub

    Private Sub txtNumContacto3_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumContacto3.KeyPress
        If Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
            MsgBox("Ingrese sólo números.")
        End If
    End Sub

    Private Sub txtEdadPadre_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtEdadPadre.KeyPress
        If Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
            MsgBox("Ingrese sólo números.")
        End If
    End Sub

    Private Sub txtTelefonoPadre_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtTelefonoPadre.KeyPress
        If Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
            MsgBox("Ingrese sólo números.")
        End If
    End Sub

    Private Sub txtEdadMadre_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtEdadMadre.KeyPress
        If Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
            MsgBox("Ingrese sólo números.")
        End If
    End Sub

    Private Sub txtTelefonoMadre_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtTelefonoMadre.KeyPress
        If Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
            MsgBox("Ingrese sólo números.")
        End If
    End Sub

    Private Sub txtTelefonoPart_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtTelefonoPart.KeyPress
        If Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
            MsgBox("Ingrese sólo números.")
        End If
    End Sub

    Private Sub txtTelefonoPart2_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtTelefonoPart2.KeyPress
        If Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
            MsgBox("Ingrese sólo números.")
        End If
    End Sub

    Private Sub txtTelefonoTrabajo_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtTelefonoTrabajo.KeyPress
        If Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
            MsgBox("Ingrese sólo números.")
        End If
    End Sub

    Private Sub Reporte_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles Reporte.PrintPage

        'objeto PrintPageEventArgs, cuyas propiedades MarginBounds, Graphics, 
        ' HasMorePage, etc.. no ayudarán a configurar el texto para la impresión 

        ContenidoDelTexto = e

        'Imprimir el contenido de textbox1.text = "Impresión de prueba" 

        ContenidoDelTexto.Graphics.DrawString(Label5.Text, New Font("Arial", 12), Brushes.Black, ContenidoDelTexto.MarginBounds.Left, ContenidoDelTexto.MarginBounds.Top)
        ContenidoDelTexto.Graphics.DrawString(txtRutAlumno.Text, New Font("Arial", 12), Brushes.Black, ContenidoDelTexto.MarginBounds.Left, ContenidoDelTexto.MarginBounds.Top)
        ContenidoDelTexto.Graphics.DrawString(Label4.Text, New Font("Arial", 12), Brushes.Black, ContenidoDelTexto.MarginBounds.Left, ContenidoDelTexto.MarginBounds.Top)
        ContenidoDelTexto.Graphics.DrawString(txtNombresAlumno.Text, New Font("Arial", 12), Brushes.Black, ContenidoDelTexto.MarginBounds.Left, ContenidoDelTexto.MarginBounds.Top)
        ContenidoDelTexto.Graphics.DrawString(Label2.Text, New Font("Arial", 12), Brushes.Black, ContenidoDelTexto.MarginBounds.Left, ContenidoDelTexto.MarginBounds.Top)
        ContenidoDelTexto.Graphics.DrawString(txtApePatAlumno.Text, New Font("Arial", 12), Brushes.Black, ContenidoDelTexto.MarginBounds.Left, ContenidoDelTexto.MarginBounds.Top)
        ContenidoDelTexto.Graphics.DrawString(Label3.Text, New Font("Arial", 12), Brushes.Black, ContenidoDelTexto.MarginBounds.Left, ContenidoDelTexto.MarginBounds.Top)
        ContenidoDelTexto.Graphics.DrawString(txtApeMatAlumno.Text, New Font("Arial", 12), Brushes.Black, ContenidoDelTexto.MarginBounds.Left, ContenidoDelTexto.MarginBounds.Top)

        'Breve descripción de las propiedades de Contenidotexto, De abajo 
        'hacia arriba 

        'ContenidoDelTexto.MarginBounds.Left y 
        'ContenidoDelTexto.MarginBoundsTop) 
        'Indica la posición en la hoja, que es el área rectangular 
        ' que representa el área de impresión de la misma 
        'en este caso es el limite 
        'hacia la izquierda, y el limite hacia arriba, que en 
        'enteros sería 100, 100. BrushesBlack es el color de 
        ' la letra y por útlimo la fuente de la letra. 

        'otra propiedad del objeto PrintPageEventArgs es 
        'PageBounds a través de esta se puede recuperar el 
        'área rectangular que representa el área total de la página. 

        'Indica que no hay más páginas a imprimir 
        ContenidoDelTexto.HasMorePages = False

        'Propiedad HasMorePages .- Obtiene o establece un valor que indica si 
        'se debe imprimir una página adicional. Boolean 

    End Sub

    Dim impresora As New PrintDialog()

    Sub Configurar()
        Impresora.document = Reporte
        Impresora.ShowDialog()
        reporte.PrinterSettings = impresora.PrinterSettings
    End Sub

    Private Sub cbbTipoPago_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbbTipoPago.SelectedIndexChanged
        If cbbTipoPago.SelectedItem = "Cheque" Then
            cbbTipoSerie.Visible = True
            lblSerieCheque.Visible = True
        Else
            cbbTipoSerie.Visible = False
            lblSerieCheque.Visible = False
        End If
    End Sub

    Private Sub txtDocMarzo_LostFocus(sender As Object, e As System.EventArgs) Handles txtDocMarzo.LostFocus
        If cbbTipoSerie.SelectedItem = "Correlativo" Then
            txtDocAbril.Text = txtDocMarzo.Text + 1
            txtDocMayo.Text = txtDocMarzo.Text + 2
            txtDocJunio.Text = txtDocMarzo.Text + 3
            txtDocJulio.Text = txtDocMarzo.Text + 4
            txtDocAgosto.Text = txtDocMarzo.Text + 5
            txtDocSept.Text = txtDocMarzo.Text + 6
            txtDocOctubre.Text = txtDocMarzo.Text + 7
            txtDocNov.Text = txtDocMarzo.Text + 8
            txtDocDic.Text = txtDocMarzo.Text + 9
        ElseIf cbbTipoSerie.SelectedItem = "Único" Then
            txtDocAbril.Text = txtDocMarzo.Text
            txtDocMayo.Text = txtDocMarzo.Text
            txtDocJunio.Text = txtDocMarzo.Text
            txtDocJulio.Text = txtDocMarzo.Text
            txtDocAgosto.Text = txtDocMarzo.Text
            txtDocSept.Text = txtDocMarzo.Text
            txtDocOctubre.Text = txtDocMarzo.Text
            txtDocNov.Text = txtDocMarzo.Text
            txtDocDic.Text = txtDocMarzo.Text
        End If
    End Sub

    Private Sub txtMontoMarzo_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtMontoMarzo.TextChanged
        If checkMontosIguales.Checked = True Then
            txtMontoAbril.Text = txtMontoMarzo.Text
            txtMontoMayo.Text = txtMontoMarzo.Text
            txtMontoJunio.Text = txtMontoMarzo.Text
            txtMontoJulio.Text = txtMontoMarzo.Text
            txtMontoAgosto.Text = txtMontoMarzo.Text
            txtMontoSept.Text = txtMontoMarzo.Text
            txtMontoOctubre.Text = txtMontoMarzo.Text
            txtMontoNov.Text = txtMontoMarzo.Text
            txtMontoDic.Text = txtMontoMarzo.Text
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged_1(sender As System.Object, e As System.EventArgs) Handles checkDiaFijo.CheckedChanged
        If checkDiaFijo.Checked = True Then
            cbbDiaAbril.Text = cbbDiaMarzo.Text
            cbbDiaMayo.Text = cbbDiaMarzo.Text
            cbbDiaJunio.Text = cbbDiaMarzo.Text
            cbbDiaJulio.Text = cbbDiaMarzo.Text
            cbbDiaAgosto.Text = cbbDiaMarzo.Text
            cbbDiaSept.Text = cbbDiaMarzo.Text
            cbbDiaOctubre.Text = cbbDiaMarzo.Text
            cbbDiaNov.Text = cbbDiaMarzo.Text
            cbbDiaDic.Text = cbbDiaMarzo.Text
        Else
            cbbDiaAbril.Text = ""
            cbbDiaMayo.Text = ""
            cbbDiaJunio.Text = ""
            cbbDiaJulio.Text = ""
            cbbDiaAgosto.Text = ""
            cbbDiaSept.Text = ""
            cbbDiaOctubre.Text = ""
            cbbDiaNov.Text = ""
            cbbDiaDic.Text = ""
        End If
    End Sub

    Private Sub checkMontosIguales_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles checkMontosIguales.CheckedChanged
        If checkMontosIguales.Checked = False Then
            txtMontoAbril.Text = ""
            txtMontoMayo.Text = ""
            txtMontoJunio.Text = ""
            txtMontoJulio.Text = ""
            txtMontoAgosto.Text = ""
            txtMontoSept.Text = ""
            txtMontoOctubre.Text = ""
            txtMontoNov.Text = ""
            txtMontoDic.Text = ""
        Else
            txtMontoAbril.Text = txtMontoMarzo.Text
            txtMontoMayo.Text = txtMontoMarzo.Text
            txtMontoJunio.Text = txtMontoMarzo.Text
            txtMontoJulio.Text = txtMontoMarzo.Text
            txtMontoAgosto.Text = txtMontoMarzo.Text
            txtMontoSept.Text = txtMontoMarzo.Text
            txtMontoOctubre.Text = txtMontoMarzo.Text
            txtMontoNov.Text = txtMontoMarzo.Text
            txtMontoDic.Text = txtMontoMarzo.Text
        End If
    End Sub

    Private Sub cbbDiaMarzo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbbDiaMarzo.SelectedIndexChanged
        If checkDiaFijo.Checked = True Then
            cbbDiaAbril.Text = cbbDiaMarzo.Text
            cbbDiaMayo.Text = cbbDiaMarzo.Text
            cbbDiaJunio.Text = cbbDiaMarzo.Text
            cbbDiaJulio.Text = cbbDiaMarzo.Text
            cbbDiaAgosto.Text = cbbDiaMarzo.Text
            cbbDiaSept.Text = cbbDiaMarzo.Text
            cbbDiaOctubre.Text = cbbDiaMarzo.Text
            cbbDiaNov.Text = cbbDiaMarzo.Text
            cbbDiaDic.Text = cbbDiaMarzo.Text
        End If
    End Sub
End Class