Imports MySql.Data.MySqlClient
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf


Public Class ImprimirPlanillas

    Private Sub ImprimirPlanillas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ModuloContenedor.CargarPlanilla(DataGridView1)
    End Sub

    Private Sub btnImprimirPlanilla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimirPlanilla.Click
        Me.PrintDocument1.Print()
    End Sub

    ' Variable a nivel de clase para recordar en qué punto nos hemos quedado
    Dim i As Integer = 0

    Private Sub printDocument1_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        ' Definimos la fuente que vamos a usar para imprimir
        ' en este caso Arial de 10
        Dim printFont As System.Drawing.Font = New System.Drawing.Font("Arial", 8)
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

    Private Sub checkRut_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles checkRut.CheckedChanged
        ModuloContenedor.checkPlanilla(DataGridView1)
    End Sub

    Private Sub checkNombre_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles checkNombre.CheckedChanged
        ModuloContenedor.checkPlanilla(DataGridView1)
    End Sub

    Private Sub checkApellidos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles checkApellidos.CheckedChanged
        ModuloContenedor.checkPlanilla(DataGridView1)
    End Sub

    Private Sub checkEdad_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles checkEdad.CheckedChanged
        ModuloContenedor.checkPlanilla(DataGridView1)
    End Sub

    Private Sub checkSexo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles checkSexo.CheckedChanged
        ModuloContenedor.checkPlanilla(DataGridView1)
    End Sub

    Private Sub checkCurso_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles checkCurso.CheckedChanged
        ModuloContenedor.checkPlanilla(DataGridView1)
    End Sub

    Private Sub checkBecas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles checkBecas.CheckedChanged
        ModuloContenedor.checkPlanilla(DataGridView1)
    End Sub

    Private Sub checkSalud_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles checkSalud.CheckedChanged
        ModuloContenedor.checkPlanilla(DataGridView1)
    End Sub

    Public Function GetColumnasSize(ByVal dg As DataGridView) As Single()
        Dim values As Single() = New Single(dg.ColumnCount - 1) {}
        For i As Integer = 0 To dg.ColumnCount - 1
            values(i) = CSng(dg.Columns(i).Width)
        Next
        Return values
    End Function

    Public Sub ExportarDatosPDF(ByVal document As Document)
        'Se crea un objeto PDFTable con el numero de columnas del DataGridView.
        Dim datatable As New PdfPTable(DataGridView1.ColumnCount)
        'Se asignan algunas propiedades para el diseño del PDF.
        datatable.DefaultCell.Padding = 3
        Dim headerwidths As Single() = GetColumnasSize(DataGridView1)
        datatable.SetWidths(headerwidths)
        datatable.WidthPercentage = 100
        datatable.DefaultCell.BorderWidth = 2
        datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER
        'Se crea el encabezado en el PDF.
        Dim encabezado As New Paragraph("ALUMNOS", New Font(Font.Name = "Tahoma", 20, Font.Bold))

        'Se crea el texto abajo del encabezado.
        Dim texto As New Phrase("Datos del alumno" + Now.Date(), New Font(Font.Name = "Tahoma", 14, Font.Bold))
        'Se capturan los nombres de las columnas del DataGridView.
        For i As Integer = 0 To DataGridView1.ColumnCount - 1
            datatable.AddCell(DataGridView1.Columns(i).HeaderText)
        Next
        datatable.HeaderRows = 1
        datatable.DefaultCell.BorderWidth = 1
        'Se generan las columnas del DataGridView.
        For i As Integer = 0 To DataGridView1.RowCount - 1
            For j As Integer = 0 To DataGridView1.ColumnCount - 1
                datatable.AddCell(DataGridView1(j, i).Value.ToString())
            Next
            datatable.CompleteRow()
        Next
        'Se agrega el PDFTable al documento.
        document.Add(encabezado)
        document.Add(texto)
        document.Add(datatable)
    End Sub

    Private Sub btnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportar.Click

        Dim myStream As Stream
        Dim saveFileDialog1 As New SaveFileDialog()

        saveFileDialog1.Filter = "PDF document (*.pdf)|*.pdf"
        saveFileDialog1.FilterIndex = 2
        saveFileDialog1.RestoreDirectory = True

        If saveFileDialog1.ShowDialog() = DialogResult.OK Then
            myStream = saveFileDialog1.OpenFile()
            If (myStream IsNot Nothing) Then
                ' Code to write the stream goes here.
                Try
                    Dim doc As New Document(PageSize.A4.Rotate(), 10, 10, 10, 10)
                    PdfWriter.GetInstance(doc, myStream)
                    doc.Open()
                    ExportarDatosPDF(doc)
                    doc.Close()
                    myStream.Close()
                Catch ex As Exception
                    MessageBox.Show("No se puede generar el documento PDF.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End If
    End Sub

    Public Function GridAExcel(ByVal DGV As DataGridView) As Boolean

        'Creamos las variables

        Dim exApp As New Microsoft.Office.Interop.Excel.Application
        Dim exLibro As Microsoft.Office.Interop.Excel.Workbook
        Dim exHoja As Microsoft.Office.Interop.Excel.Worksheet

        Try

            exLibro = exApp.Workbooks.Add
            exHoja = exLibro.Worksheets.Add()

            ' ¿Cuantas columnas y cuantas filas?
            Dim NCol As Integer = DGV.ColumnCount
            Dim NRow As Integer = DGV.RowCount
            'recorremos todas las filas, y por cada fila todas las columnas
            'y vamos escribiendo.
            For i As Integer = 1 To NCol
                exHoja.Cells.Item(1, i) = DGV.Columns(i - 1).Name.ToString
            Next

            For Fila As Integer = 0 To NRow - 1
                For Col As Integer = 0 To NCol - 1
                    exHoja.Cells.Item(Fila + 2, Col + 1) =
                    DGV.Rows(Fila).Cells(Col).Value()
                Next

            Next

            'Titulo en negrita, Alineado
            exHoja.Rows.Item(1).Font.Bold = 1
            exHoja.Rows.Item(1).HorizontalAlignment = 3
            exHoja.Columns.AutoFit()
            'para visualizar el libro
            exApp.Application.Visible = True
            exHoja = Nothing
            exLibro = Nothing
            exApp = Nothing
            Return True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al exportar a Excel")

            Return False
        End Try

    End Function

    Private Sub btnExportarExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportarExcel.Click
        GridAExcel(DataGridView1)
    End Sub
End Class