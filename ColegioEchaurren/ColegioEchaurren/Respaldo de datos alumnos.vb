Imports System.IO.StreamReader
Imports System.IO
Imports MySql.Data.MySqlClient

Public Class Respaldo_de_datos_alumnos

    Private Sub btnRestaurar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRestaurar.Click

        Dim abrir As New OpenFileDialog
        Dim carpeta As New FolderBrowserDialog

        abrir.DefaultExt = "sql"
        Dim pathmysql As String
        Dim comando As String
        Dim arg As String
        abrir.Filter = "File MYSQL (*.sql)|*.sql"
        pathmysql = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\MySQL AB\MYSQL Server 5.6", "Location", 0)
        If pathmysql = Nothing Then
            MsgBox("No se encontro en tu equipo Mysql, escoge la carpeta donde esta ubicado")
            carpeta.ShowDialog()
            pathmysql = carpeta.SelectedPath
        End If

        If abrir.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Try
                comando = pathmysql & "\bin\mysql.exe"
                comando.Replace("\\", "\")
                arg = " --user=root --password=123456 --host=localhost --database bd_echaurren < " & Chr(34) & abrir.FileName & Chr(34)
                Dim proceso As New Process
                proceso.StartInfo.FileName = "cmd.exe"
                proceso.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
                proceso.StartInfo.UseShellExecute = False
                proceso.StartInfo.RedirectStandardOutput = True
                proceso.StartInfo.RedirectStandardInput = True
                proceso.StartInfo.CreateNoWindow = True
                proceso.Start()
                Dim escribeconsola As StreamWriter = proceso.StandardInput
                Dim leyendoconsola As StreamReader = proceso.StandardOutput
                escribeconsola.WriteLine(comando & arg)
                escribeconsola.Close()
                proceso.WaitForExit()
                proceso.Close()
                MessageBox.Show("Base de datos restaurada!", "Respaldo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show("Error al restaurar Base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End If
    End Sub

    Private Sub btnCopiaSeguridad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopiaSeguridad.Click

        Dim respaldar As New SaveFileDialog
        Dim carpeta As New FolderBrowserDialog

        respaldar.DefaultExt = "sql"
        Dim pathmysql As String
        Dim comando As String
        pathmysql = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\MySQL AB\MYSQL Server 5.6", "Location", 0)
        If pathmysql = Nothing Then
            MsgBox("No se encontro en tu equipo Mysql, escoge la carpeta donde esta ubicado")
            carpeta.ShowDialog()
            pathmysql = carpeta.SelectedPath
        End If
        respaldar.Filter = "File MYSQL (*.sql)|*.sql"
        If respaldar.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Try
                comando = pathmysql & "\bin\mysqldump --user=root --password=123456 --databases bd_echaurren -r """ & respaldar.FileName & """"
                Shell(comando, AppWinStyle.MinimizedFocus, True)
                MessageBox.Show("Respaldo exitoso!", "Respaldar Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MsgBox("Ocurrio un error al respaldar", MsgBoxStyle.Critical, "Informacion")
            End Try

        End If
    End Sub

End Class

