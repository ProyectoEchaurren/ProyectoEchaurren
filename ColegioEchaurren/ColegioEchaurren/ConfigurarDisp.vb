Imports System.Drawing.Printing

Public Class ConfigurarDisp

    ' función que retorna verdadero si hay una impresora instalada  
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''  
    Public Function PrinterInstalled() As Boolean

        On Error Resume Next

        Dim Impresora As String
        Impresora = PrintDialog1.PrinterSettings.PrinterName

        If Err.Number Then
            PrinterInstalled = False
        Else
            PrinterInstalled = True
        End If

        On Error GoTo 0

    End Function

    Private Sub btnVerificar_Click(sender As System.Object, e As System.EventArgs) Handles btnVerificar.Click
        ' verifica si hay una impresora instalada  
        If PrinterInstalled() Then
            If MessageBox.Show("Ya hay una impresora instalada, ¿Desea agregar otra impresora más?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
                Shell("rundll32 shell32.dll,SHHelpShortcuts_RunDLL AddPrinter", vbNormalFocus)
            End If
        Else
            If MessageBox.Show("No Hay una impresora instalada. ¿ Desea abrir el cuadro de diálogo de windows para instalar una impresora ? ", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
                ' cuadro de diálogo de windows para instalar una nueva imp.  
                Shell("rundll32 shell32.dll,SHHelpShortcuts_RunDLL AddPrinter", vbNormalFocus)
            End If
        End If
    End Sub

    Private Sub btnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub ConfigurarDisp_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim pd As New PrintDocument
        Dim Impresoras As String

        ' Default printer      
        Dim DefaultPrinter As String = pd.PrinterSettings.PrinterName

        ' recorre las impresoras instaladas  
        For Each Impresoras In PrinterSettings.InstalledPrinters
            ListBox1.Items.Add(Impresoras.ToString)
        Next
        ' selecciona la impresora predeterminada  
        ListBox1.Text = DefaultPrinter

    End Sub

    Private Sub btnAcutalizar_Click(sender As System.Object, e As System.EventArgs) Handles btnActualizar.Click
        Me.ListBox1.Items.Clear()
        ConfigurarDisp_Load(sender, e)
    End Sub
End Class