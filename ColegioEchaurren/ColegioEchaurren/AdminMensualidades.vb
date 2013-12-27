Imports MySql.Data.MySqlClient
Public Class AdminMensualidades

    Public varConexion1 As MySqlConnection
    Public varConexionString1 As String = "server=localhost;User Id=root;password=123456;database=bd_echaurren"
    Public consultaCargaComboCurso As String = "SELECT * FROM bd_echaurren.curso;"
    Public varDataSet As DataSet
    Public varMesActual As Integer
    Public varNombreMesActual As String
    Public varDataAdapter As MySqlDataAdapter

    Private Sub AdminMensualidades_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        varMesActual = Month(Now)
        varNombreMesActual = MonthName(varMesActual)

        Try

            varConexion1 = New MySqlConnection
            varConexion1.ConnectionString = varConexionString1
            varConexion1.Open()
        Catch ex As Exception
            MessageBox.Show("Error al conectar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End Try

        Try
            Dim _dataAdapter = New MySqlDataAdapter(consultaCargaComboCurso, varConexion1)
            Dim _dataSet = New DataSet
            _dataAdapter.Fill(_dataSet)

            cbFiltroCurso.DataSource = _dataSet.Tables(0)
            cbFiltroCurso.ValueMember = "idCurso"
            cbFiltroCurso.DisplayMember = "Curso"
            If cbFiltroCurso.SelectedIndex = 0 Then
                cbFiltroCurso.Text = ""
            End If
        Catch ex As Exception
            MessageBox.Show("Error al cargar cursos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        ModuloContenedor.ComprobarFiltros(DataGridView1, cbFiltroCurso, cbPorcentaje, varNombreMesActual)
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBecado.CheckedChanged
        If CheckBecado.Checked = True Then
            CheckNoBecado.Checked = False
            cbPorcentaje.Enabled = True
            labelPorcentaje.Enabled = True
        Else
            cbPorcentaje.SelectedIndex = 0
            cbPorcentaje.Enabled = False
            labelPorcentaje.Enabled = False
        End If
        ModuloContenedor.ComprobarFiltros(DataGridView1, cbFiltroCurso, cbPorcentaje, varNombreMesActual)
    End Sub

    Private Sub CheckNoBecado_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckNoBecado.CheckedChanged
        If CheckNoBecado.Checked = True Then
            CheckBecado.Checked = False
            cbPorcentaje.SelectedIndex = 0
            cbPorcentaje.Enabled = False
            labelPorcentaje.Enabled = False
        End If
        ModuloContenedor.ComprobarFiltros(DataGridView1, cbFiltroCurso, cbPorcentaje, varNombreMesActual)
    End Sub

    Private Sub CheckPagado_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckPagado.CheckedChanged
        If CheckPagado.Checked = True Then
            CheckAtrasado.Checked = False
        End If
        ModuloContenedor.ComprobarFiltros(DataGridView1, cbFiltroCurso, cbPorcentaje, varNombreMesActual)
    End Sub

    Private Sub CheckAtrasado_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckAtrasado.CheckedChanged
        If CheckAtrasado.Checked = True Then
            CheckPagado.Checked = False
        End If
        ModuloContenedor.ComprobarFiltros(DataGridView1, cbFiltroCurso, cbPorcentaje, varNombreMesActual)
    End Sub

    Private Sub cbFiltroCurso_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbFiltroCurso.SelectedIndexChanged
        ModuloContenedor.ComprobarFiltros(DataGridView1, cbFiltroCurso, cbPorcentaje, varNombreMesActual)
    End Sub

    Private Sub cbPorcentaje_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbPorcentaje.SelectedIndexChanged
        ModuloContenedor.ComprobarFiltros(DataGridView1, cbFiltroCurso, cbPorcentaje, varNombreMesActual)
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Form1.varColumnaRutHistorico = (DataGridView1.Rows(e.RowIndex).Cells(0).Value)
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Form1.varColumnaRutHistorico = (DataGridView1.Rows(e.RowIndex).Cells(0).Value)
        HistorialdePagos.Show()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        If Form1.varColumnaRutHistorico = "" Then
            MsgBox("Primero debe selecionar un Alumno(a) para ver su historial de mensualidades.", MsgBoxStyle.Information, AcceptButton)
        Else
            HistorialdePagos.Show()
        End If
    End Sub
End Class