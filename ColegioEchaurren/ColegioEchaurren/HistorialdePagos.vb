Imports MySql.Data.MySqlClient
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.IO

Public Class HistorialdePagos
    Private Sub HistorialdePagos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ModuloContenedor.CargarHistorico(DataGridViewHistorico, Form1.varColumnaRutHistorico)
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
        Dim datatable As New PdfPTable(DataGridViewHistorico.ColumnCount)
        'Se asignan algunas propiedades para el diseño del PDF.
        datatable.DefaultCell.Padding = 3
        Dim headerwidths As Single() = GetColumnasSize(DataGridViewHistorico)
        datatable.SetWidths(headerwidths)
        datatable.WidthPercentage = 100
        datatable.DefaultCell.BorderWidth = 2
        datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER
        'Se crea el encabezado en el PDF.
        Dim encabezado As New Paragraph("HISTORIAL", New Font(Font.Name = "Tahoma", 20, Font.Bold))

        'Se crea el texto abajo del encabezado.
        Dim texto As New Phrase("Historial de pagos " + Now.Date(), New Font(Font.Name = "Tahoma", 14, Font.Bold))
        'Se capturan los nombres de las columnas del DataGridView.
        For i As Integer = 0 To DataGridViewHistorico.ColumnCount - 1
            datatable.AddCell(DataGridViewHistorico.Columns(i).HeaderText)
        Next
        datatable.HeaderRows = 1
        datatable.DefaultCell.BorderWidth = 1
        'Se generan las columnas del DataGridView.
        For i As Integer = 0 To DataGridViewHistorico.RowCount - 1
            For j As Integer = 0 To DataGridViewHistorico.ColumnCount - 1
                datatable.AddCell(DataGridViewHistorico(j, i).Value.ToString())
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

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        GridAExcel(DataGridViewHistorico)
    End Sub
End Class