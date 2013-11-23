Imports MySql.Data.MySqlClient

Public Class FormAlumnosMatriculados

    Public varConexion1 As MySqlConnection
    Public varConexionString1 As String = "server=localhost;User Id=root;password=123456;database=bd_echaurren"
    Public consultaGrilla As String = "SELECT * FROM bd_echaurren.alumno;"
    Public consultaCargaCombo1 As String = "SELECT * FROM bd_echaurren.servicio_salud;"
    Public varDataSet As DataSet
    Public varDataAdapter As MySqlDataAdapter

    Private Sub FormAlumnosMatriculados_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

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
        Catch ex As Exception
            MessageBox.Show("Error al cargar servicios de salud", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

End Class