Imports MySql.Data.MySqlClient

Public Class FormularioMatricula
    Public indiceTab As Integer
    Public varConexion As MySqlConnection
    Public varConexionString As String = "server=localhost;User Id=root;password=123456;database=bd_echaurren"

    Private Sub FormularioMatricula_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        dateTimeFechaNac.Format = DateTimePickerFormat.Custom
        dateTimeFechaNac.CustomFormat = "dd/MM/yyyy"
        dateTimeFechaNac.MaxDate = Now()

        dtpMatricula.Format = DateTimePickerFormat.Custom
        dtpMatricula.CustomFormat = "yyyy"
        dtpMatricula.MaxDate = Now()

        Try

            varConexion = New MySqlConnection
            varConexion.ConnectionString = varConexionString
            varConexion.Open()

        Catch ex As Exception

            MessageBox.Show("Error al conectar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()

        End Try

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
    Private Sub RadioButton12_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton12.CheckedChanged
        If RadioButton12.Checked = True Then
            txtViveConOtros.Enabled = True
            txtViveConOtros.Focus()
        Else
            txtViveConOtros.Enabled = False
        End If
    End Sub

    Private Sub RadioButton14_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton14.CheckedChanged
        If RadioButton14.Checked = True Then
            txtOtro.Enabled = True
            txtOtro.Focus()
        Else
            txtOtro.Enabled = False
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        txtNombreApoderado2.Text = txtNombreApoderado.Text
        txtNombreTutor2.Text = txtNombreTutor.Text
        indiceTab = TabControl1.SelectedIndex
        TabControl1.DeselectTab(indiceTab)
    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar2.Click
        indiceTab = TabControl1.SelectedIndex
        TabControl1.DeselectTab(indiceTab)
    End Sub

    Private Sub btnVolver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        indiceTab = TabControl1.SelectedIndex
        TabControl1.SelectTab(indiceTab - 1)
    End Sub

    Private Sub btnVolver2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVolver2.Click
        indiceTab = TabControl1.SelectedIndex
        TabControl1.SelectTab(indiceTab - 1)
    End Sub

    Private Sub checkConBeca_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles checkConBeca.CheckedChanged
        If checkConBeca.Checked = True Then
            checkSinBeca.Checked = False
        End If
    End Sub

    Private Sub checkSinBeca_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles checkSinBeca.CheckedChanged
        If checkSinBeca.Checked = True Then
            checkConBeca.Checked = False
        End If
    End Sub

    Private Sub btnSalir3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir3.Click
        If MessageBox.Show("¿Está seguro(a) de salir sin guardar?", "¡Alerta!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub btnSalir2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir2.Click
        If MessageBox.Show("¿Está seguro(a) de salir sin guardar?", "¡Alerta!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        If MessageBox.Show("¿Está seguro(a) de salir sin guardar?", "¡Alerta!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub btnTerminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTerminar.Click
        Me.Close()
    End Sub

    Private Sub radioHermanosSi_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radioHermanosSi.CheckedChanged
        If radioHermanosSi.Checked = True Then
            txtHermanosCursos.Enabled = True
            txtHermanosCursos.Focus()
        Else
            txtHermanosCursos.Enabled = False
        End If
    End Sub

    Private Sub rbBasicaPadre_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbBasicaPadre.CheckedChanged
        If rbBasicaPadre.Checked = True Then
            txtBasicaPadre.Enabled = True
            txtBasicaPadre.Focus()
        Else
            txtBasicaPadre.Enabled = False
        End If
    End Sub

    Private Sub rbMediaPadre_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbMediaPadre.CheckedChanged
        If rbMediaPadre.Checked = True Then
            txtMediaPadre.Enabled = True
            txtMediaPadre.Focus()
        Else
            txtMediaPadre.Enabled = False
        End If
    End Sub

    Private Sub rbTecnicoPadre_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbTecnicoPadre.CheckedChanged
        If rbTecnicoPadre.Checked = True Then
            txtTecnicoPadre.Enabled = True
            txtTecnicoPadre.Focus()
        Else
            txtTecnicoPadre.Enabled = False
        End If
    End Sub

    Private Sub rbUniverPadre_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbUniverPadre.CheckedChanged
        If rbUniverPadre.Checked = True Then
            txtUniverPadre.Enabled = True
            txtUniverPadre.Focus()
        Else
            txtUniverPadre.Enabled = False
        End If
    End Sub

    Private Sub rbBasicaMadre_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbBasicaMadre.CheckedChanged
        If rbBasicaMadre.Checked = True Then
            txtBasicaMadre.Enabled = True
            txtBasicaMadre.Focus()
        Else
            txtBasicaMadre.Enabled = False
        End If
    End Sub

    Private Sub rbMediaMadre_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbMediaMadre.CheckedChanged
        If rbMediaMadre.Checked = True Then
            txtMediaMadre.Enabled = True
            txtMediaMadre.Focus()
        Else
            txtMediaMadre.Enabled = False
        End If
    End Sub

    Private Sub rbTecnicoMadre_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbTecnicoMadre.CheckedChanged
        If rbTecnicoMadre.Checked = True Then
            txtTecnicoMadre.Enabled = True
            txtTecnicoMadre.Focus()
        Else
            txtTecnicoMadre.Enabled = False
        End If
    End Sub

    Private Sub rbUniverMadre_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbUniverMadre.CheckedChanged
        If rbUniverMadre.Checked = True Then
            txtUniverMadre.Enabled = True
            txtUniverMadre.Focus()
        Else
            txtUniverMadre.Enabled = False
        End If
    End Sub

    Private Sub txtOtrosServicios_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOtrosServicios.TextChanged
        If txtOtrosServicios.Text <> "" Then
            comboIsapre.SelectedText = ""
            radioFonasaA.Checked = False
            radioFonasaB.Checked = False
            radioFonasaC.Checked = False
        End If
    End Sub

    Private Sub comboIsapre_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles comboIsapre.SelectedIndexChanged
        If comboIsapre.SelectedText <> "" Then
            txtOtrosServicios.Text = ""
            radioFonasaA.Checked = False
            radioFonasaB.Checked = False
            radioFonasaC.Checked = False
        End If
    End Sub

    Private Sub radioFonasaA_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radioFonasaA.CheckedChanged
        If radioFonasaA.Checked = True Then
            txtOtrosServicios.Text = ""
            comboIsapre.SelectedText = ""
        End If
    End Sub

    Private Sub radioFonasaB_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radioFonasaB.CheckedChanged
        If radioFonasaB.Checked = True Then
            txtOtrosServicios.Text = ""
            comboIsapre.SelectedText = ""
        End If
    End Sub

    Private Sub radioFonasaC_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radioFonasaC.CheckedChanged
        If radioFonasaC.Checked = True Then
            txtOtrosServicios.Text = ""
            comboIsapre.SelectedText = ""
        End If
    End Sub
End Class