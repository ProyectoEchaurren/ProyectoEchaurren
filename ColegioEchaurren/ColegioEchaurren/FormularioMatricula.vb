Imports MySql.Data.MySqlClient

Public Class FormularioMatricula

    Public varConexion As MySqlConnection

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub FormularioMatricula_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try

            varConexion = New MySqlConnection
            varConexion.ConnectionString = "server=localhost;User Id=root;password=123456;database=bd_echaurren"
            varConexion.Open()

        Catch ex As Exception

            MessageBox.Show("Error al conectar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()

        End Try

    End Sub

    Private Sub TabPage2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage2.Click

    End Sub

    Private Sub Label48_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label48.Click

    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.SelectedIndex = 0 Then
            GroupBox1.Show()
            GroupBox2.Hide()
            GroupBox3.Hide()
            GroupBox4.Hide()
            GroupBox5.Hide()
        ElseIf ComboBox1.SelectedIndex = 1 Then
            GroupBox2.Show()
            GroupBox3.Hide()
            GroupBox4.Hide()
            GroupBox5.Hide()
        ElseIf ComboBox1.SelectedIndex = 2 Then
            GroupBox2.Show()
            GroupBox3.Show()
            GroupBox4.Hide()
            GroupBox5.Hide()
        ElseIf ComboBox1.SelectedIndex = 3 Then
            GroupBox2.Show()
            GroupBox3.Show()
            GroupBox4.Show()
            GroupBox5.Hide()
        ElseIf ComboBox1.SelectedIndex = 4 Then
            GroupBox2.Show()
            GroupBox3.Show()
            GroupBox4.Show()
            GroupBox5.Show()
        End If
    End Sub

    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class