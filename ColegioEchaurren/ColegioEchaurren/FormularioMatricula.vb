Public Class FormularioMatricula

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub FormularioMatricula_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

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