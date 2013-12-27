Public Class ImprimirPlanillas
    
    Private Sub ImprimirPlanillas_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ModuloContenedor.CargarPlanilla(DataGridView1)
    End Sub

    Private Sub btnImprimirPlanilla_Click(sender As System.Object, e As System.EventArgs) Handles btnImprimirPlanilla.Click
        Me.PrintDocument1.Print()
    End Sub

    ' Variable a nivel de clase para recordar en qué punto nos hemos quedado
    Dim i As Integer = 0

    Private Sub printDocument1_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        ' Definimos la fuente que vamos a usar para imprimir
        ' en este caso Arial de 10
        Dim printFont As System.Drawing.Font = New Font("Arial", 8)
        Dim topMargin As Double = e.MarginBounds.Top
        Dim yPos As Double = 0
        Dim linesPerPage As Double = 0
        Dim count As Integer = 0
        Dim texto As String = ""
        Dim row As System.Windows.Forms.DataGridViewRow

        ' Calculamos el número de líneas que caben en cada página
        linesPerPage = e.MarginBounds.Height / printFont.GetHeight(e.Graphics)

        ' Imprimimos las cabeceras
        Dim header As DataGridViewHeaderCell
        For Each column As DataGridViewColumn In DataGridView1.Columns
            header = column.HeaderCell
            texto += vbTab + header.FormattedValue.ToString()
        Next

        yPos = topMargin + (count * printFont.GetHeight(e.Graphics))
        e.Graphics.DrawString(texto, printFont, System.Drawing.Brushes.Black, 10, yPos)
        ' Dejamos una línea de separación
        count += 2

        ' Recorremos las filas del DataGridView hasta que llegemos
        ' a las líneas que nos caben en cada página o al final del grid.
        While count < linesPerPage AndAlso i < DataGridView1.Rows.Count
            row = DataGridView1.Rows(i)
            texto = ""
            For Each celda As System.Windows.Forms.DataGridViewCell In row.Cells
                'Comprobamos que la celda tenga algún valor, en caso de 
                'permitir añadir filas esto es muy importante
                If celda.Value IsNot Nothing Then
                    texto += vbTab + celda.Value.ToString()
                End If
            Next

            ' Calculamos la posición en la que se escribe la línea
            yPos = topMargin + (count * printFont.GetHeight(e.Graphics))

            ' Escribimos la línea con el objeto Graphics
            e.Graphics.DrawString(texto, printFont, System.Drawing.Brushes.Black, 10, yPos)
            ' Incrementamos los contadores
            count += 1
            i += 1
        End While

        ' Una vez fuera del bucle comprobamos si nos quedan más filas
        ' por imprimir, si quedan saldrán en la siguente página
        If i < DataGridView1.Rows.Count Then
            e.HasMorePages = True
        Else
            ' si llegamos al final, se establece HasMorePages a
            ' false para que se acabe la impresión
            e.HasMorePages = False
            ' Es necesario poner el contador a 0 porque, por ejemplo si se hace
            ' una impresión desde PrintPreviewDialog, se vuelve disparar este
            ' evento como si fuese la primera vez, y si i está con el valor de la
            ' última fila del grid no se imprime nada
            i = 0
        End If
    End Sub

    Private Sub checkRut_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles checkRut.CheckedChanged
        ModuloContenedor.checkPlanilla(DataGridView1)
    End Sub

    Private Sub checkNombre_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles checkNombre.CheckedChanged
        ModuloContenedor.checkPlanilla(DataGridView1)
    End Sub

    Private Sub checkApellidos_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles checkApellidos.CheckedChanged
        ModuloContenedor.checkPlanilla(DataGridView1)
    End Sub

    Private Sub checkEdad_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles checkEdad.CheckedChanged
        ModuloContenedor.checkPlanilla(DataGridView1)
    End Sub

    Private Sub checkSexo_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles checkSexo.CheckedChanged
        ModuloContenedor.checkPlanilla(DataGridView1)
    End Sub

    Private Sub checkCurso_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles checkCurso.CheckedChanged
        ModuloContenedor.checkPlanilla(DataGridView1)
    End Sub

    Private Sub checkBecas_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles checkBecas.CheckedChanged
        ModuloContenedor.checkPlanilla(DataGridView1)
    End Sub

    Private Sub checkSalud_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles checkSalud.CheckedChanged
        ModuloContenedor.checkPlanilla(DataGridView1)
    End Sub
End Class