<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CambiarPass
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CambiarPass))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtPassActual = New System.Windows.Forms.TextBox()
        Me.txtNewPass1 = New System.Windows.Forms.TextBox()
        Me.txtNewPass2 = New System.Windows.Forms.TextBox()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(22, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(111, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Contraseña Actual"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(22, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(158, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Ingrese Nueva Contraseña"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(22, 112)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(153, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Repita Nueva Contraseña"
        '
        'txtPassActual
        '
        Me.txtPassActual.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.txtPassActual.Location = New System.Drawing.Point(194, 27)
        Me.txtPassActual.Name = "txtPassActual"
        Me.txtPassActual.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassActual.Size = New System.Drawing.Size(115, 20)
        Me.txtPassActual.TabIndex = 3
        Me.txtPassActual.UseSystemPasswordChar = True
        '
        'txtNewPass1
        '
        Me.txtNewPass1.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.txtNewPass1.Location = New System.Drawing.Point(194, 69)
        Me.txtNewPass1.Name = "txtNewPass1"
        Me.txtNewPass1.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtNewPass1.Size = New System.Drawing.Size(115, 20)
        Me.txtNewPass1.TabIndex = 4
        Me.txtNewPass1.UseSystemPasswordChar = True
        '
        'txtNewPass2
        '
        Me.txtNewPass2.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.txtNewPass2.Location = New System.Drawing.Point(194, 109)
        Me.txtNewPass2.Name = "txtNewPass2"
        Me.txtNewPass2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtNewPass2.Size = New System.Drawing.Size(115, 20)
        Me.txtNewPass2.TabIndex = 5
        Me.txtNewPass2.UseSystemPasswordChar = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Location = New System.Drawing.Point(56, 166)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(98, 40)
        Me.btnGuardar.TabIndex = 6
        Me.btnGuardar.Text = "Guardar Cambios"
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(180, 166)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(98, 40)
        Me.btnCancelar.TabIndex = 7
        Me.btnCancelar.Text = "Salir"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'CambiarPass
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(338, 227)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.txtNewPass2)
        Me.Controls.Add(Me.txtNewPass1)
        Me.Controls.Add(Me.txtPassActual)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "CambiarPass"
        Me.Text = "Cambio de Contraseña"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtPassActual As System.Windows.Forms.TextBox
    Friend WithEvents txtNewPass1 As System.Windows.Forms.TextBox
    Friend WithEvents txtNewPass2 As System.Windows.Forms.TextBox
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
End Class
