Imports MySql.Data.MySqlClient
Imports System.Net.Mime.MediaTypeNames
Imports Microsoft.Office.Interop
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.IO
Imports Microsoft.Office.Interop.Word


Public Class AdminMensualidades

    Public varConexion1 As MySqlConnection
    Public varConexionString1 As String = "server=localhost;User Id=root;password=123456;database=bd_echaurren"
    Public consultaCargaComboCurso As String = "SELECT * FROM bd_echaurren.curso;"
    Public varDataSet As DataSet
    Public varMesActual As Integer
    Public varNombreMesActual As String
    Public varDataAdapter As MySqlDataAdapter

    Dim Obj_Excel As Object
    Dim Obj_Libro As Object
    Dim Obj_Hoja As Object

    Private Sub AdminMensualidades_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        varMesActual = Month(Now)
        varNombreMesActual = MonthName(varMesActual)

        If varNombreMesActual = "enero" Or varNombreMesActual = "febrero" Then
            varNombreMesActual = "diciembre"
        End If

        Try

            varConexion1 = New MySqlConnection
            varConexion1.ConnectionString = varConexionString1
            varConexion1.Open()
        Catch ex As Exception
            MessageBox.Show("Error al conectar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End Try

        Try
            Dim _dataAdapter = New MySqlDataAdapter(consultaCargaComboCurso, varConexion1)
            Dim _dataSet = New DataSet
            _dataAdapter.Fill(_dataSet)

            cbFiltroCurso.DataSource = _dataSet.Tables(0)
            cbFiltroCurso.ValueMember = "idCurso"
            cbFiltroCurso.DisplayMember = "Curso"
            If cbFiltroCurso.SelectedIndex = 0 Then
                cbFiltroCurso.Text = ""
            End If
        Catch ex As Exception
            MessageBox.Show("Error al cargar cursos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        ModuloContenedor.ComprobarFiltros(DataGridView1, cbFiltroCurso, cbPorcentaje, varNombreMesActual)

    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBecado.CheckedChanged
        If CheckBecado.Checked = True Then
            CheckNoBecado.Checked = False
            cbPorcentaje.Enabled = True
            labelPorcentaje.Enabled = True
        Else
            cbPorcentaje.SelectedIndex = 0
            cbPorcentaje.Enabled = False
            labelPorcentaje.Enabled = False
        End If
        ModuloContenedor.ComprobarFiltros(DataGridView1, cbFiltroCurso, cbPorcentaje, varNombreMesActual)
    End Sub

    Private Sub CheckNoBecado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckNoBecado.CheckedChanged
        If CheckNoBecado.Checked = True Then
            CheckBecado.Checked = False
            cbPorcentaje.SelectedIndex = 0
            cbPorcentaje.Enabled = False
            labelPorcentaje.Enabled = False
        End If
        ModuloContenedor.ComprobarFiltros(DataGridView1, cbFiltroCurso, cbPorcentaje, varNombreMesActual)
    End Sub

    Private Sub CheckPagado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckPagado.CheckedChanged
        If CheckPagado.Checked = True Then
            CheckAtrasado.Checked = False
        End If
        ModuloContenedor.ComprobarFiltros(DataGridView1, cbFiltroCurso, cbPorcentaje, varNombreMesActual)
    End Sub

    Private Sub CheckAtrasado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckAtrasado.CheckedChanged
        If CheckAtrasado.Checked = True Then
            CheckPagado.Checked = False
        End If
        ModuloContenedor.ComprobarFiltros(DataGridView1, cbFiltroCurso, cbPorcentaje, varNombreMesActual)
    End Sub

    Private Sub cbFiltroCurso_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbFiltroCurso.SelectedIndexChanged
        ModuloContenedor.ComprobarFiltros(DataGridView1, cbFiltroCurso, cbPorcentaje, varNombreMesActual)
    End Sub

    Private Sub cbPorcentaje_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbPorcentaje.SelectedIndexChanged
        ModuloContenedor.ComprobarFiltros(DataGridView1, cbFiltroCurso, cbPorcentaje, varNombreMesActual)
    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Form1.varColumnaRutHistorico = (DataGridView1.Rows(e.RowIndex).Cells(0).Value)
    End Sub

    Private Sub DataGridView1_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Form1.varColumnaRutHistorico = (DataGridView1.Rows(e.RowIndex).Cells(0).Value)
        HistorialdePagos.Show()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Form1.varColumnaRutHistorico = "" Then
            MsgBox("Primero debe selecionar un Alumno(a) para ver su historial de mensualidades.", MsgBoxStyle.Information, AcceptButton)
        Else
            HistorialdePagos.Show()
        End If
    End Sub

    Public Function GetColumnasSize(ByVal dg As DataGridView) As Single()
        Dim values As Single() = New Single(dg.ColumnCount - 1) {}
        For i As Integer = 0 To dg.ColumnCount - 1
            values(i) = CSng(dg.Columns(i).Width)
        Next
        Return values
    End Function

    Public Sub ExportarDatosPDF(ByVal document As iTextSharp.text.Document)
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
        Dim encabezado As New iTextSharp.text.Paragraph("MENSUALIDADES", New iTextSharp.text.Font(Font.Name = "Tahoma", 20, iTextSharp.text.Font.BOLD))

        'Se crea el texto abajo del encabezado.
        Dim texto As New Phrase("Mensualidades de alumnos " + Now.Date(), New iTextSharp.text.Font(Font.Name = "Tahoma", 14, iTextSharp.text.Font.BOLD))
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

    Private Sub btnExportarPdf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportarPdf.Click


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
                    Dim doc As New iTextSharp.text.Document(PageSize.A4.Rotate(), 10, 10, 10, 10)
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