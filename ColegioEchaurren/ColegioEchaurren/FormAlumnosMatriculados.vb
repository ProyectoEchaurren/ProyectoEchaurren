Imports MySql.Data.MySqlClient

Public Class FormAlumnosMatriculados

    Public varConexion1 As MySqlConnection
    Public varConexionString1 As String = "server=localhost;User Id=root;password=123456;database=bd_echaurren"
    Public consultaGrilla As String = "SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, Curso, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, NumMatricula, Fechamatricula FROM alumno inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idComuna inner join matricula on alumno.Matricula_NumMatricula = matricula.NumMatricula"
    Public consultaCargaCombo1 As String = "SELECT * FROM bd_echaurren.servicio_salud;"
    Public consultaCargaComboCurso As String = "SELECT * FROM bd_echaurren.curso;"
    Public varDataSet As DataSet
    Public varDataAdapter As MySqlDataAdapter

    Private Sub FormAlumnosMatriculados_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Form1.varTipoUsuario = "Asistente" Then
            btnCancelarMatri.Enabled = False
        End If

        Try
            varConexion1 = New MySqlConnection
            varConexion1.ConnectionString = varConexionString1
            varConexion1.Open()
        Catch ex As Exception
            MessageBox.Show("Error al conectar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End Try

        Try
            Dim _dataAdapter = New MySqlDataAdapter(consultaCargaCombo1, varConexion1)
            Dim _dataSet = New DataSet
            _dataAdapter.Fill(_dataSet)

            cbBuscarServSalud.DataSource = _dataSet.Tables(0)
            cbBuscarServSalud.ValueMember = "idServicio_salud"
            cbBuscarServSalud.DisplayMember = "PlanSalud"
            If cbBuscarServSalud.SelectedIndex = 0 Then
                cbBuscarServSalud.Text = ""
            End If
        Catch ex As Exception
            MessageBox.Show("Error al cargar servicios de salud", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Try
            Dim _dataAdapter = New MySqlDataAdapter(consultaCargaComboCurso, varConexion1)
            Dim _dataSet = New DataSet
            _dataAdapter.Fill(_dataSet)

            cbbCurso.DataSource = _dataSet.Tables(0)
            cbbCurso.ValueMember = "idCurso"
            cbbCurso.DisplayMember = "Curso"
            If cbbCurso.SelectedIndex = 0 Then
                cbbCurso.Text = ""
            End If
        Catch ex As Exception
            MessageBox.Show("Error al cargar cursos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Try
            varDataAdapter = New MySqlDataAdapter(consultaGrilla, varConexion1)
            varDataSet = New DataSet
            varDataAdapter.Fill(varDataSet)
            DataGridView1.DataSource = varDataSet.Tables(0)
        Catch ex As Exception
            MessageBox.Show("Error al cargar alumnos en grilla")
        End Try

        ModuloContenedor.cambiarNombreColumnas()
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Form1.varFichaPersonalAlumno = ""
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        txtRutAlumno.Text = ""
        txtNombre.Text = ""
        txtApePaterno.Text = ""
        txtEdad.Text = ""
        cbbCurso.Text = ""
        cbBuscarServSalud.Text = ""
        cbBecados.Checked = False
        cbNoBecados.Checked = False
        cbbPorcentaje.Text = ""
        txtRutAlumno.Focus()
        ModuloContenedor.FiltrosAdminAlumnos(DataGridView1, txtRutAlumno.Text, txtNombre.Text, txtApePaterno.Text, txtEdad.Text, cbbCurso, cbBuscarServSalud, cbbPorcentaje)
    End Sub

    Private Sub txtRutAlumno_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtRutAlumno.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            e.Handled = True
            ModuloContenedor.FiltrosAdminAlumnos(DataGridView1, txtRutAlumno.Text, txtNombre.Text, txtApePaterno.Text, txtEdad.Text, cbbCurso, cbBuscarServSalud, cbbPorcentaje)
        End If
    End Sub

    Private Sub txtNombre_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombre.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            e.Handled = True
            ModuloContenedor.FiltrosAdminAlumnos(DataGridView1, txtRutAlumno.Text, txtNombre.Text, txtApePaterno.Text, txtEdad.Text, cbbCurso, cbBuscarServSalud, cbbPorcentaje)
        End If
    End Sub

    Private Sub cbBecados_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles cbBecados.CheckedChanged
        If cbBecados.Checked = True Then
            cbNoBecados.Checked = False
            cbbPorcentaje.Enabled = True
            labelPorcentaje.Enabled = True
        Else
            cbbPorcentaje.SelectedIndex = 0
            cbbPorcentaje.Enabled = False
            labelPorcentaje.Enabled = False
        End If
        ModuloContenedor.FiltrosAdminAlumnos(DataGridView1, txtRutAlumno.Text, txtNombre.Text, txtApePaterno.Text, txtEdad.Text, cbbCurso, cbBuscarServSalud, cbbPorcentaje)
    End Sub

    Private Sub cbNoBecados_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles cbNoBecados.CheckedChanged
        If cbNoBecados.Checked = True Then
            cbBecados.Checked = False
            cbbPorcentaje.SelectedIndex = 0
            cbbPorcentaje.Enabled = False
            labelPorcentaje.Enabled = False
        End If
        ModuloContenedor.FiltrosAdminAlumnos(DataGridView1, txtRutAlumno.Text, txtNombre.Text, txtApePaterno.Text, txtEdad.Text, cbbCurso, cbBuscarServSalud, cbbPorcentaje)
    End Sub

    Private Sub txtApePaterno_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtApePaterno.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            e.Handled = True
            ModuloContenedor.FiltrosAdminAlumnos(DataGridView1, txtRutAlumno.Text, txtNombre.Text, txtApePaterno.Text, txtEdad.Text, cbbCurso, cbBuscarServSalud, cbbPorcentaje)
        End If
    End Sub

    Private Sub txtEdad_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtEdad.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            e.Handled = True
            ModuloContenedor.FiltrosAdminAlumnos(DataGridView1, txtRutAlumno.Text, txtNombre.Text, txtApePaterno.Text, txtEdad.Text, cbbCurso, cbBuscarServSalud, cbbPorcentaje)
        End If
    End Sub

    Private Sub cbbCurso_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbbCurso.SelectedIndexChanged
        ModuloContenedor.FiltrosAdminAlumnos(DataGridView1, txtRutAlumno.Text, txtNombre.Text, txtApePaterno.Text, txtEdad.Text, cbbCurso, cbBuscarServSalud, cbbPorcentaje)
    End Sub

    Private Sub cbBuscarServSalud_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbBuscarServSalud.SelectedIndexChanged
        ModuloContenedor.FiltrosAdminAlumnos(DataGridView1, txtRutAlumno.Text, txtNombre.Text, txtApePaterno.Text, txtEdad.Text, cbbCurso, cbBuscarServSalud, cbbPorcentaje)
    End Sub

    Private Sub cbbPorcentaje_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbbPorcentaje.SelectedIndexChanged
        ModuloContenedor.FiltrosAdminAlumnos(DataGridView1, txtRutAlumno.Text, txtNombre.Text, txtApePaterno.Text, txtEdad.Text, cbbCurso, cbBuscarServSalud, cbbPorcentaje)
    End Sub

    Private Sub btnFichaPersonal_Click(sender As System.Object, e As System.EventArgs) Handles btnFichaPersonal.Click
        If Form1.varFichaPersonalAlumno = "" Then
            MsgBox("Primero debe selecionar un(a) Alumno(a) para ver su ficha personal", MsgBoxStyle.Information, AcceptButton)
        Else
            DetalleInfoAlumno.Show()
        End If
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Form1.varFichaPersonalAlumno = (DataGridView1.Rows(e.RowIndex).Cells(0).Value)
    End Sub

    Private Sub btnCancelarMatri_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelarMatri.Click
        If Form1.varFichaPersonalAlumno = "" Then
            MsgBox("Primero debe selecionar un(a) Alumno(a) para cancelar su matrícula", MsgBoxStyle.Information, AcceptButton)
        Else
            If MessageBox.Show("Está a punto de eliminar al alumno " & Form1.varFichaPersonalAlumno & " de todos los registros. ¿Desea continuar?", "¡Alerta!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
                If MessageBox.Show("¿Está seguro(a) de querer eliminar al alumno " & Form1.varFichaPersonalAlumno & "?" & vbCrLf & "Estos cambios no se pueden deshacer.", "¡Atención!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
                    If ModuloContenedor.CancelarMatri(Form1.varFichaPersonalAlumno) = True Then
                        MsgBox("Alumno " & Form1.varFichaPersonalAlumno & " eliminado completamente de la Base de Datos.", MsgBoxStyle.Information, AcceptButton)
                        ModuloContenedor.FiltrosAdminAlumnos(DataGridView1, txtRutAlumno.Text, txtNombre.Text, txtApePaterno.Text, txtEdad.Text, cbbCurso, cbBuscarServSalud, cbbPorcentaje)
                    End If
                End If
            End If
        End If
    End Sub
End Class