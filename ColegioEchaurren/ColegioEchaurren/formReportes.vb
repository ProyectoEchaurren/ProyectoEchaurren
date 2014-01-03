Public Class formReportes

    Private Sub formReportes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'bd_echaurrenDataSet.fichaalumno' Puede moverla o quitarla según sea necesario.
        Me.fichaalumnoTableAdapter.Fill(Me.bd_echaurrenDataSet.fichaalumno)
        'TODO: esta línea de código carga datos en la tabla 'bd_echaurrenDataSet.mensualidad' Puede moverla o quitarla según sea necesario.
        Me.mensualidadTableAdapter.Fill(Me.bd_echaurrenDataSet.mensualidad)
        'TODO: esta línea de código carga datos en la tabla 'bd_echaurrenDataSet.alumno' Puede moverla o quitarla según sea necesario.
        Me.alumnoTableAdapter.Fill(Me.bd_echaurrenDataSet.alumno)

        Me.ReportViewer1.RefreshReport()
        Me.ReportViewer1.RefreshReport()
        Me.ReportViewer2.RefreshReport()
        Me.ReportViewer3.RefreshReport()
        Me.ReportViewer4.RefreshReport()
    End Sub

   
End Class