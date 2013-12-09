Public Class HistorialdePagos
    Private Sub HistorialdePagos_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        MsgBox(Form1.varColumnaRutHistorico)
        ModuloContenedor.CargarHistorico(DataGridViewHistorico, Form1.varColumnaRutHistorico)
    End Sub
End Class