<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GestordeUsuarios
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GestordeUsuarios))
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.txtNombreUser = New System.Windows.Forms.TextBox()
        Me.txtRutUser = New System.Windows.Forms.TextBox()
        Me.txtPassUser = New System.Windows.Forms.TextBox()
        Me.txtTipoUser = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnCrear = New System.Windows.Forms.Button()
        Me.btnActualizar = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(12, 12)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(544, 146)
        Me.DataGridView1.TabIndex = 0
        '
        'txtNombreUser
        '
        Me.txtNombreUser.Location = New System.Drawing.Point(12, 192)
        Me.txtNombreUser.Name = "txtNombreUser"
        Me.txtNombreUser.Size = New System.Drawing.Size(164, 20)
        Me.txtNombreUser.TabIndex = 1
        '
        'txtRutUser
        '
        Me.txtRutUser.Location = New System.Drawing.Point(204, 192)
        Me.txtRutUser.Name = "txtRutUser"
        Me.txtRutUser.Size = New System.Drawing.Size(100, 20)
        Me.txtRutUser.TabIndex = 2
        '
        'txtPassUser
        '
        Me.txtPassUser.Location = New System.Drawing.Point(330, 192)
        Me.txtPassUser.Name = "txtPassUser"
        Me.txtPassUser.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassUser.Size = New System.Drawing.Size(100, 20)
        Me.txtPassUser.TabIndex = 3
        Me.txtPassUser.UseSystemPasswordChar = True
        '
        'txtTipoUser
        '
        Me.txtTipoUser.Location = New System.Drawing.Point(456, 192)
        Me.txtTipoUser.Name = "txtTipoUser"
        Me.txtTipoUser.Size = New System.Drawing.Size(100, 20)
        Me.txtTipoUser.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 176)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Nombre Usuario"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(201, 176)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Rut Usuario"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(327, 176)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Contraseña"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(453, 176)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Tipo de Usuario"
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Location = New System.Drawing.Point(12, 233)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(89, 34)
        Me.btnLimpiar.TabIndex = 9
        Me.btnLimpiar.Text = "Limpiar Campos"
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Location = New System.Drawing.Point(236, 233)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(99, 34)
        Me.btnGuardar.TabIndex = 10
        Me.btnGuardar.Text = "Guardar Cambios"
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Location = New System.Drawing.Point(355, 233)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(93, 34)
        Me.btnEliminar.TabIndex = 11
        Me.btnEliminar.Text = "Eliminar Usuario"
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnCrear
        '
        Me.btnCrear.Location = New System.Drawing.Point(123, 233)
        Me.btnCrear.Name = "btnCrear"
        Me.btnCrear.Size = New System.Drawing.Size(93, 34)
        Me.btnCrear.TabIndex = 12
        Me.btnCrear.Text = "Crear Usuario"
        Me.btnCrear.UseVisualStyleBackColor = True
        '
        'btnActualizar
        '
        Me.btnActualizar.Location = New System.Drawing.Point(467, 233)
        Me.btnActualizar.Name = "btnActualizar"
        Me.btnActualizar.Size = New System.Drawing.Size(89, 34)
        Me.btnActualizar.TabIndex = 13
        Me.btnActualizar.Text = "Actualizar Grilla"
        Me.btnActualizar.UseVisualStyleBackColor = True
        '
        'GestordeUsuarios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(568, 279)
        Me.Controls.Add(Me.btnActualizar)
        Me.Controls.Add(Me.btnCrear)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.btnLimpiar)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtTipoUser)
        Me.Controls.Add(Me.txtPassUser)
        Me.Controls.Add(Me.txtRutUser)
        Me.Controls.Add(Me.txtNombreUser)
        Me.Controls.Add(Me.DataGridView1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "GestordeUsuarios"
        Me.Text = "Gestor de Usuarios"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents txtNombreUser As System.Windows.Forms.TextBox
    Friend WithEvents txtRutUser As System.Windows.Forms.TextBox
    Friend WithEvents txtPassUser As System.Windows.Forms.TextBox
    Friend WithEvents txtTipoUser As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents btnCrear As System.Windows.Forms.Button
    Friend WithEvents btnActualizar As System.Windows.Forms.Button
End Class
