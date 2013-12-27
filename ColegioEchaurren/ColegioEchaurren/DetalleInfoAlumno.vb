Imports System.Drawing.Printing

Public Class DetalleInfoAlumno

    Private Sub DetalleInfoAlumno_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ModuloContenedor.CargarFichaPersonal(Form1.varFichaPersonalAlumno)
        ModuloContenedor.CargarContactosFichaPersonal(Form1.varFichaPersonalAlumno)
    End Sub

    Dim ContenidoDelTexto As PrintPageEventArgs
    Dim WithEvents Reporte As New PrintDocument()

    'Evento Click a un boton, previamente declarado y configurado 

    Private Sub Button_Click(ByVal sender As System.Object, ByVal _
    e As System.EventArgs) Handles Button1.Click
        Configurar()
        'Mandando a imprimir 
        Reporte.Print()

    End Sub


    'Procedimiento de evento Reporte_PrintPage. Construyendo el informe 

    Private Sub Reporte_PrintPage(ByVal sender As System.Object, ByVal _
    e As System.Drawing.Printing.PrintPageEventArgs) Handles _
    Reporte.PrintPage


        'objeto PrintPageEventArgs, cuyas propiedades MarginBounds, Graphics, 
        ' HasMorePage, etc.. no ayudarán a configurar el texto para la impresión 

        ContenidoDelTexto = e

        'Imprimir el contenido de textbox1.text = "Impresión de prueba" 

        ContenidoDelTexto.Graphics.DrawString(lblRutAlumno.Text, New Font("Arial", 12), Brushes.Black, ContenidoDelTexto.MarginBounds.Left, ContenidoDelTexto.MarginBounds.Top)
        ContenidoDelTexto.Graphics.DrawString(txtRutAlumno.Text, New Font("Arial", 12), Brushes.Black, ContenidoDelTexto.MarginBounds.Left, ContenidoDelTexto.MarginBounds.Top)
        ContenidoDelTexto.Graphics.DrawString(lblNombreAlumno.Text, New Font("Arial", 12), Brushes.Black, ContenidoDelTexto.MarginBounds.Left, ContenidoDelTexto.MarginBounds.Top)
        ContenidoDelTexto.Graphics.DrawString(txtNombreAlumno.Text, New Font("Arial", 12), Brushes.Black, ContenidoDelTexto.MarginBounds.Left, ContenidoDelTexto.MarginBounds.Top)
        ContenidoDelTexto.Graphics.DrawString(lblApePat.Text, New Font("Arial", 12), Brushes.Black, ContenidoDelTexto.MarginBounds.Left, ContenidoDelTexto.MarginBounds.Top)
        ContenidoDelTexto.Graphics.DrawString(txtApePat.Text, New Font("Arial", 12), Brushes.Black, ContenidoDelTexto.MarginBounds.Left, ContenidoDelTexto.MarginBounds.Top)
        ContenidoDelTexto.Graphics.DrawString(lblApeMat.Text, New Font("Arial", 12), Brushes.Black, ContenidoDelTexto.MarginBounds.Left, ContenidoDelTexto.MarginBounds.Top)
        ContenidoDelTexto.Graphics.DrawString(txtApeMat.Text, New Font("Arial", 12), Brushes.Black, ContenidoDelTexto.MarginBounds.Left, ContenidoDelTexto.MarginBounds.Top)

        'Breve descripción de las propiedades de Contenidotexto, De abajo 
        'hacia arriba 

        'ContenidoDelTexto.MarginBounds.Left y 
        'ContenidoDelTexto.MarginBoundsTop) 
        'Indica la posición en la hoja, que es el área rectangular 
        ' que representa el área de impresión de la misma 
        'en este caso es el limite 
        'hacia la izquierda, y el limite hacia arriba, que en 
        'enteros sería 100, 100. BrushesBlack es el color de 
        ' la letra y por útlimo la fuente de la letra. 

        'otra propiedad del objeto PrintPageEventArgs es 
        'PageBounds a través de esta se puede recuperar el 
        'área rectangular que representa el área total de la página. 

        'Indica que no hay más páginas a imprimir 
        ContenidoDelTexto.HasMorePages = False

        'Propiedad HasMorePages .- Obtiene o establece un valor que indica si 
        'se debe imprimir una página adicional. Boolean 

    End Sub

    Dim impresora As New PrintDialog()

    Sub Configurar()
        Impresora.document = Reporte
        Impresora.ShowDialog()
        reporte.PrinterSettings = impresora.PrinterSettings
    End Sub
End Class