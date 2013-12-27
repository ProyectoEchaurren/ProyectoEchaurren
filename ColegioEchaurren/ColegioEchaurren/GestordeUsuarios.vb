Public Class GestordeUsuarios
    Dim varNombreUser As String
    Dim varRutUser As String

    Private Sub GestordeUsuarios_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ModuloContenedor.CargarUsuarios(DataGridView1)
    End Sub

    Private Sub btnLimpiar_Click(sender As System.Object, e As System.EventArgs) Handles btnLimpiar.Click
        txtNombreUser.Text = ""
        txtRutUser.Text = ""
        txtPassUser.Text = ""
        txtTipoUser.Text = ""
        txtNombreUser.Focus()
    End Sub

    Private Sub btnCrear_Click(sender As System.Object, e As System.EventArgs) Handles btnCrear.Click
        If txtNombreUser.Text = "" Or txtRutUser.Text = "" Or txtPassUser.Text = "" Or txtTipoUser.Text = "" Then
            MsgBox("Debe completar todos los campos para poder crear un nuevo usuario.")
        Else
            If ComprobarRut(txtRutUser.Text) = False Then
                MsgBox("El Rut ingresado no es valido")
                txtRutUser.Focus()
            Else
                If ModuloContenedor.CrearUser(txtNombreUser.Text, txtRutUser.Text, txtPassUser.Text, txtTipoUser.Text) = True Then
                    MsgBox("Usuario Creado Exitosamente.")
                    ModuloContenedor.CargarUsuarios(DataGridView1)
                End If
            End If
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminar.Click
        If MessageBox.Show("¿Está usted seguro(a) de querer eliminar al usuario" & varRutUser & "?", "¡Atención!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
            If ModuloContenedor.EliminarUser(varRutUser) = True Then
                MsgBox("Usuario Eliminado Exitosamente.")
                ModuloContenedor.CargarUsuarios(DataGridView1)
            End If
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        If txtNombreUser.Text = "" Or txtRutUser.Text = "" Or txtPassUser.Text = "" Or txtTipoUser.Text = "" Then
            MsgBox("Debe completar todos los campos para poder guardar cambios en usuario.")
        Else
            If ComprobarRut(txtRutUser.Text) = False Then
                MsgBox("El Rut ingresado no es valido")
                txtRutUser.Focus()
            Else
                If ModuloContenedor.ActualizarUser(txtNombreUser.Text, txtRutUser.Text, txtPassUser.Text, txtTipoUser.Text, varNombreUser, varRutUser) = True Then
                    MsgBox("Cambios Guardados Exitosamente.")
                    ModuloContenedor.CargarUsuarios(DataGridView1)
                End If
            End If
        End If
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        varNombreUser = (DataGridView1.Rows(e.RowIndex).Cells(1).Value)
        varRutUser = (DataGridView1.Rows(e.RowIndex).Cells(2).Value)
        txtNombreUser.Text = (DataGridView1.Rows(e.RowIndex).Cells(1).Value)
        txtRutUser.Text = (DataGridView1.Rows(e.RowIndex).Cells(2).Value)
        txtPassUser.Text = (DataGridView1.Rows(e.RowIndex).Cells(3).Value)
        txtTipoUser.Text = (DataGridView1.Rows(e.RowIndex).Cells(4).Value)
    End Sub

    Private Sub btnActualizar_Click(sender As System.Object, e As System.EventArgs) Handles btnActualizar.Click
        ModuloContenedor.CargarUsuarios(DataGridView1)
    End Sub
End Class