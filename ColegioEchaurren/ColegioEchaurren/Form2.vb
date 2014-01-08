Imports System
Imports System.Data
Imports MySql.Data.MySqlClient

Imports CrystalDecisions.Web
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class Form2

    Private Sub Form2_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim ConnectString As String = "server=localhost;User Id=root;password=123456;database=bd_echaurren"
        Dim dataSet As New DataSet()
        Dim dataSetConn As New MySqlConnection(ConnectString)
        Dim dataAdapter As New MySqlDataAdapter
        Dim query As String = "SELECT * FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idComuna inner join matricula on alumno.Matricula_NumMatricula = matricula.NumMatricula inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno inner join responsable_alumno on alumno.RutAlumno = responsable_alumno.Alumno_RutAlumno inner join responsable on responsable.RutResponsable = responsable_alumno.Responsable_RutResponsable inner join mensualidad on alumno.RutAlumno = mensualidad.RutAlumno WHERE alumno.RutAlumno = '" & FormularioMatricula.txtRutAlumno.Text & "';"

        Try
            dataSetConn.Open()
            dataAdapter.SelectCommand = New MySqlCommand(query, dataSetConn)
            dataAdapter.MissingSchemaAction = MissingSchemaAction.Add
            dataAdapter.MissingMappingAction = MissingMappingAction.Passthrough
            dataAdapter.Fill(dataSet)

            CrystalReport13.SetDataSource(dataSet)
            CrystalReport13.Refresh()
            CrystalReportViewer1.ReportSource = CrystalReport13
        Catch ex As Exception
            MsgBox("Error al recuperar datos para impresión.")
        End Try
    End Sub
End Class