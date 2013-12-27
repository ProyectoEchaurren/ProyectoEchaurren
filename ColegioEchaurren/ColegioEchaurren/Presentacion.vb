Public Class Presentacion
    Private Sub Presentacion_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Timer1.Start()
        Timer1.Interval = 500
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        If ProgressBar1.Value = 100 Then
            Me.Hide()
            Form1.Show()
            Timer1.Dispose()
        End If
        ProgressBar1.Increment(25)
    End Sub
End Class