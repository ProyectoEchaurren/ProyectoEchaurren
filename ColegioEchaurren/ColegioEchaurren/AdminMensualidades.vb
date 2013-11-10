Public Class AdminMensualidades

    Private Sub AdminMensualidades_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ModuloContenedor.ComprobarFiltros(DataGridView1, cbFiltroCurso, cbPorcentaje)
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
        ModuloContenedor.ComprobarFiltros(DataGridView1, cbFiltroCurso, cbPorcentaje)
    End Sub

    Private Sub CheckNoBecado_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckNoBecado.CheckedChanged
        If CheckNoBecado.Checked = True Then
            CheckBecado.Checked = False
            cbPorcentaje.SelectedIndex = 0
            cbPorcentaje.Enabled = False
            labelPorcentaje.Enabled = False
        End If
        ModuloContenedor.ComprobarFiltros(DataGridView1, cbFiltroCurso, cbPorcentaje)
    End Sub

    Private Sub CheckPagado_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckPagado.CheckedChanged
        If CheckPagado.Checked = True Then
            CheckAtrasado.Checked = False
        End If
        ModuloContenedor.ComprobarFiltros(DataGridView1, cbFiltroCurso, cbPorcentaje)
    End Sub

    Private Sub CheckAtrasado_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckAtrasado.CheckedChanged
        If CheckAtrasado.Checked = True Then
            CheckPagado.Checked = False
        End If
        ModuloContenedor.ComprobarFiltros(DataGridView1, cbFiltroCurso, cbPorcentaje)
    End Sub

    Private Sub cbFiltroCurso_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbFiltroCurso.SelectedIndexChanged
        ModuloContenedor.ComprobarFiltros(DataGridView1, cbFiltroCurso, cbPorcentaje)
    End Sub

    Private Sub cbPorcentaje_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbPorcentaje.SelectedIndexChanged
        ModuloContenedor.ComprobarFiltros(DataGridView1, cbFiltroCurso, cbPorcentaje)
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        ColumnaRutHistorico = (DataGridView1.Rows(e.RowIndex).Cells(0).Value)
        HistorialdePagos.Show()
    End Sub
End Class