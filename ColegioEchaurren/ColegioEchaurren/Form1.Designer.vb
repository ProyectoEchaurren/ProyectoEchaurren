<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.Opción1ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Opción2ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.BToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.CToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.CabasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Opción1ToolStripMenuItem, Me.Opción2ToolStripMenuItem, Me.CabasToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(605, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'Opción1ToolStripMenuItem
        '
        Me.Opción1ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AToolStripMenuItem, Me.BToolStripMenuItem, Me.CToolStripMenuItem})
        Me.Opción1ToolStripMenuItem.Name = "Opción1ToolStripMenuItem"
        Me.Opción1ToolStripMenuItem.Size = New System.Drawing.Size(67, 20)
        Me.Opción1ToolStripMenuItem.Text = "Opción 1"
        '
        'AToolStripMenuItem
        '
        Me.AToolStripMenuItem.Name = "AToolStripMenuItem"
        Me.AToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.AToolStripMenuItem.Text = "a"
        '
        'BToolStripMenuItem
        '
        Me.BToolStripMenuItem.Name = "BToolStripMenuItem"
        Me.BToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.BToolStripMenuItem.Text = "b"
        '
        'CToolStripMenuItem
        '
        Me.CToolStripMenuItem.Name = "CToolStripMenuItem"
        Me.CToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.CToolStripMenuItem.Text = "c"
        '
        'Opción2ToolStripMenuItem
        '
        Me.Opción2ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AToolStripMenuItem1, Me.BToolStripMenuItem1, Me.CToolStripMenuItem1})
        Me.Opción2ToolStripMenuItem.Name = "Opción2ToolStripMenuItem"
        Me.Opción2ToolStripMenuItem.Size = New System.Drawing.Size(67, 20)
        Me.Opción2ToolStripMenuItem.Text = "Opción 2"
        '
        'AToolStripMenuItem1
        '
        Me.AToolStripMenuItem1.Name = "AToolStripMenuItem1"
        Me.AToolStripMenuItem1.Size = New System.Drawing.Size(152, 22)
        Me.AToolStripMenuItem1.Text = "a"
        '
        'BToolStripMenuItem1
        '
        Me.BToolStripMenuItem1.Name = "BToolStripMenuItem1"
        Me.BToolStripMenuItem1.Size = New System.Drawing.Size(152, 22)
        Me.BToolStripMenuItem1.Text = "b"
        '
        'CToolStripMenuItem1
        '
        Me.CToolStripMenuItem1.Name = "CToolStripMenuItem1"
        Me.CToolStripMenuItem1.Size = New System.Drawing.Size(152, 22)
        Me.CToolStripMenuItem1.Text = "c"
        '
        'CabasToolStripMenuItem
        '
        Me.CabasToolStripMenuItem.Name = "CabasToolStripMenuItem"
        Me.CabasToolStripMenuItem.Size = New System.Drawing.Size(51, 20)
        Me.CabasToolStripMenuItem.Text = "Cabas"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(605, 319)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.Text = "Colegio Echaurren"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents Opción1ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Opción2ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CabasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
