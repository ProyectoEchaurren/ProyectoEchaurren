Public Class DetalleInfoAlumno

    Private Sub DetalleInfoAlumno_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ModuloContenedor.CargarFichaPersonal(Form1.varFichaPersonalAlumno)
        ModuloContenedor.CargarContactosFichaPersonal(Form1.varFichaPersonalAlumno)
    End Sub
End Class