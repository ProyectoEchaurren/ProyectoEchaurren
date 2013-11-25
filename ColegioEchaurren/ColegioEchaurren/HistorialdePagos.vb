Public Class HistorialdePagos
    Private Sub HistorialdePagos_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        MsgBox(Form1.ColumnaRutHistorico)
        ModuloContenedor.CargarHistorico(DataGridViewHistorico, Form1.ColumnaRutHistorico)
    End Sub
End Class