<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Respaldo_de_datos_alumnos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Respaldo_de_datos_alumnos))
        Me.btnCopiaSeguridad = New System.Windows.Forms.Button()
        Me.btnRestaurar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnCopiaSeguridad
        '
        Me.btnCopiaSeguridad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCopiaSeguridad.Image = Global.ColegioEchaurren.My.Resources.Resources.Backup_center_icon
        Me.btnCopiaSeguridad.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCopiaSeguridad.Location = New System.Drawing.Point(67, 133)
        Me.btnCopiaSeguridad.Name = "btnCopiaSeguridad"
        Me.btnCopiaSeguridad.Size = New System.Drawing.Size(144, 101)
        Me.btnCopiaSeguridad.TabIndex = 1
        Me.btnCopiaSeguridad.Text = "CREAR COPIA DE SEGURIDAD"
        Me.btnCopiaSeguridad.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnCopiaSeguridad.UseVisualStyleBackColor = True
        '
        'btnRestaurar
        '
        Me.btnRestaurar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRestaurar.Image = Global.ColegioEchaurren.My.Resources.Resources._988b71e986
        Me.btnRestaurar.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnRestaurar.Location = New System.Drawing.Point(67, 26)
        Me.btnRestaurar.Name = "btnRestaurar"
        Me.btnRestaurar.Size = New System.Drawing.Size(144, 101)
        Me.btnRestaurar.TabIndex = 0
        Me.btnRestaurar.Text = "RESTAURAR COPIA"
        Me.btnRestaurar.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnRestaurar.UseVisualStyleBackColor = True
        '
        'Respaldo_de_datos_alumnos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 262)
        Me.Controls.Add(Me.btnCopiaSeguridad)
        Me.Controls.Add(Me.btnRestaurar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Respaldo_de_datos_alumnos"
        Me.Text = "Respaldo_de_datos_alumnos"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnRestaurar As System.Windows.Forms.Button
    Friend WithEvents btnCopiaSeguridad As System.Windows.Forms.Button
End Class
