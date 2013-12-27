Public Class EscanearDocs
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        If txtNombreArchivo.Text = "" Then
            MsgBox("Ingrese un nombre para su archivo escaneado.")
        ElseIf txtRuta.Text = "" Then
            MsgBox("Seleccione la ruta donde desea guardar su archivo escaneado.")
        Else
            Dim CD As New WIA.CommonDialog
            Try
                Dim F As WIA.ImageFile = CD.ShowAcquireImage(WIA.WiaDeviceType.ScannerDeviceType)
                F.SaveFile(txtRuta.Text & "\" & txtNombreArchivo.Text & "." & F.FileExtension)
            Catch ex As Exception
                MessageBox.Show("No se encontró ningún dispositivo para la digitalización.")
            End Try
        End If
    End Sub
    
        'Private Sub escanearPro(ByVal nombreArchivo, ByVal ruta1, ByVal tamannoEscaneo)
        'Al terminar el escaneo se generara un pdf, no un tif
        'Dim fileName As String 'nombre del archivo que generaremos
        'Dim N As Integer 'numero de escaneos seguidos que realizaremos, lo suyo es que sea 1, pero esto es a gusto del consumidor
        '    N = 1
        '    fileName = String.Format(ruta1 & "\" & nombreArchivo & ".pdf", 1) 'ponemos la ruta, el nombre del archivo y el tipo de archivo (en este caso .pdf)
        '    Call EZTwain.LogFile(1)
        '    Call EZTwain.SetHideUI(1)
        '    If EZTwain.OpenDefaultSource() Then
        '        Call EZTwain.SelectFeeder(0) 'esta linea es la que define que es un escaner flatbed, para ponerlo ADF el 1 lo ponemos false (si no funciona ponganse en contacto conmigo)
        '        Call EZTwain.SetPixelType(2) 'yo escaneo en color (provad con otros numeros para ver otros tipos de escaneo, como el blanco-negro)
        '        Call EZTwain.SetBitDepth(1)
        '        Call EZTwain.SetResolution(300) 'resolucion de la imagen
        '        Call EZTwain.SetAutoScan(1) 'ESTA LINEA ES NUESTRA SALVADORA, ya que es la encargada de decirle al escaner que escanee y punto, sin mostrar ventanas adicionales ni nada, que escanee con los parametros que le hemos dado y ya esta

        '        Call EZTwain.SetRegion(0, 0, 10.1, 10.1) 'area que decidimos escanear

        '        EZTwain.AcquireToFilename(Me.Handle, fileName) 'esta linea realiza el escaneo y la creacion del documento
        '    End If
        '   If EZTwain.LastErrorCode() <> 0 Then
        '       Call EZTwain.ReportLastError("No es posible Escanear.")
        '   End If
        'End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            txtRuta.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub


    Private Sub btnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
End Class