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
End Class