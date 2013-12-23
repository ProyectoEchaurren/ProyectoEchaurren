Public Class HistorialdePagos
    Private Sub HistorialdePagos_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ModuloContenedor.CargarHistorico(DataGridViewHistorico, Form1.varColumnaRutHistorico)
    End Sub
End Class