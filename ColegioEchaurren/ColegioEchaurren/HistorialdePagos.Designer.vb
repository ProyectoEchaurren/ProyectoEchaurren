<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HistorialdePagos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(HistorialdePagos))
        Me.DataGridViewHistorico = New System.Windows.Forms.DataGridView()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.DataGridViewHistorico, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridViewHistorico
        '
        Me.DataGridViewHistorico.AllowUserToAddRows = False
        Me.DataGridViewHistorico.AllowUserToDeleteRows = False
        Me.DataGridViewHistorico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewHistorico.Location = New System.Drawing.Point(12, 12)
        Me.DataGridViewHistorico.Name = "DataGridViewHistorico"
        Me.DataGridViewHistorico.ReadOnly = True
        Me.DataGridViewHistorico.Size = New System.Drawing.Size(818, 319)
        Me.DataGridViewHistorico.TabIndex = 0
        '
        'btnExportar
        '
        Me.btnExportar.Image = Global.ColegioEchaurren.My.Resources.Resources.icono_pdf
        Me.btnExportar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExportar.Location = New System.Drawing.Point(12, 347)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(161, 44)
        Me.btnExportar.TabIndex = 1
        Me.btnExportar.Text = "Exportar historial a pdf"
        Me.btnExportar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Image = Global.ColegioEchaurren.My.Resources.Resources.Excel_icon
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.Location = New System.Drawing.Point(179, 347)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(142, 44)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Exportar a Excel"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.UseVisualStyleBackColor = True
        '
        'HistorialdePagos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(842, 405)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnExportar)
        Me.Controls.Add(Me.DataGridViewHistorico)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "HistorialdePagos"
        Me.Text = "Historial de Pagos"
        CType(Me.DataGridViewHistorico, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataGridViewHistorico As System.Windows.Forms.DataGridView
    Friend WithEvents btnExportar As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
