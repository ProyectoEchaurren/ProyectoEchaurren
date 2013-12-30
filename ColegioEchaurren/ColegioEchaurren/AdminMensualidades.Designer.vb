<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AdminMensualidades
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AdminMensualidades))
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.labelPorcentaje = New System.Windows.Forms.Label()
        Me.cbPorcentaje = New System.Windows.Forms.ComboBox()
        Me.CheckAtrasado = New System.Windows.Forms.CheckBox()
        Me.CheckPagado = New System.Windows.Forms.CheckBox()
        Me.CheckNoBecado = New System.Windows.Forms.CheckBox()
        Me.CheckBecado = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbFiltroCurso = New System.Windows.Forms.ComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnExportarExcel = New System.Windows.Forms.Button()
        Me.btnExportarPdf = New System.Windows.Forms.Button()
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
        Me.DataGridView1.Size = New System.Drawing.Size(616, 411)
        Me.DataGridView1.TabIndex = 0
        Me.DataGridView1.TabStop = False
        '
        'labelPorcentaje
        '
        Me.labelPorcentaje.AutoSize = True
        Me.labelPorcentaje.Enabled = False
        Me.labelPorcentaje.Location = New System.Drawing.Point(672, 147)
        Me.labelPorcentaje.Name = "labelPorcentaje"
        Me.labelPorcentaje.Size = New System.Drawing.Size(100, 13)
        Me.labelPorcentaje.TabIndex = 27
        Me.labelPorcentaje.Text = "Porcentaje de beca"
        '
        'cbPorcentaje
        '
        Me.cbPorcentaje.Enabled = False
        Me.cbPorcentaje.FormattingEnabled = True
        Me.cbPorcentaje.Items.AddRange(New Object() {"", "0", "5", "10", "15", "20", "25", "30", "35", "40", "45", "50", "55", "60", "65", "70", "75", "80", "85", "90", "95", "100"})
        Me.cbPorcentaje.Location = New System.Drawing.Point(662, 163)
        Me.cbPorcentaje.Name = "cbPorcentaje"
        Me.cbPorcentaje.Size = New System.Drawing.Size(121, 21)
        Me.cbPorcentaje.TabIndex = 26
        '
        'CheckAtrasado
        '
        Me.CheckAtrasado.AutoSize = True
        Me.CheckAtrasado.Location = New System.Drawing.Point(729, 204)
        Me.CheckAtrasado.Name = "CheckAtrasado"
        Me.CheckAtrasado.Size = New System.Drawing.Size(73, 17)
        Me.CheckAtrasado.TabIndex = 25
        Me.CheckAtrasado.Text = "Atrasados"
        Me.CheckAtrasado.UseVisualStyleBackColor = True
        '
        'CheckPagado
        '
        Me.CheckPagado.AutoSize = True
        Me.CheckPagado.Location = New System.Drawing.Point(646, 204)
        Me.CheckPagado.Name = "CheckPagado"
        Me.CheckPagado.Size = New System.Drawing.Size(68, 17)
        Me.CheckPagado.TabIndex = 24
        Me.CheckPagado.Text = "Pagados"
        Me.CheckPagado.UseVisualStyleBackColor = True
        '
        'CheckNoBecado
        '
        Me.CheckNoBecado.AutoSize = True
        Me.CheckNoBecado.Location = New System.Drawing.Point(729, 121)
        Me.CheckNoBecado.Name = "CheckNoBecado"
        Me.CheckNoBecado.Size = New System.Drawing.Size(85, 17)
        Me.CheckNoBecado.TabIndex = 23
        Me.CheckNoBecado.Text = "No Becados"
        Me.CheckNoBecado.UseVisualStyleBackColor = True
        '
        'CheckBecado
        '
        Me.CheckBecado.AutoSize = True
        Me.CheckBecado.Location = New System.Drawing.Point(646, 121)
        Me.CheckBecado.Name = "CheckBecado"
        Me.CheckBecado.Size = New System.Drawing.Size(68, 17)
        Me.CheckBecado.TabIndex = 22
        Me.CheckBecado.Text = "Becados"
        Me.CheckBecado.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(677, 92)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(92, 13)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "Filtros de Alumnos"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(680, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 13)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Filtrar por Curso"
        '
        'cbFiltroCurso
        '
        Me.cbFiltroCurso.FormattingEnabled = True
        Me.cbFiltroCurso.Items.AddRange(New Object() {"", "4to", "5to"})
        Me.cbFiltroCurso.Location = New System.Drawing.Point(661, 42)
        Me.cbFiltroCurso.Name = "cbFiltroCurso"
        Me.cbFiltroCurso.Size = New System.Drawing.Size(121, 21)
        Me.cbFiltroCurso.TabIndex = 19
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(661, 236)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(121, 49)
        Me.Button1.TabIndex = 28
        Me.Button1.Text = "Ver Historial de Pagos"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnExportarExcel
        '
        Me.btnExportarExcel.Image = Global.ColegioEchaurren.My.Resources.Resources.Excel_icon
        Me.btnExportarExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExportarExcel.Location = New System.Drawing.Point(146, 429)
        Me.btnExportarExcel.Name = "btnExportarExcel"
        Me.btnExportarExcel.Size = New System.Drawing.Size(143, 48)
        Me.btnExportarExcel.TabIndex = 30
        Me.btnExportarExcel.Text = "Exportar a Excel"
        Me.btnExportarExcel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExportarExcel.UseVisualStyleBackColor = True
        '
        'btnExportarPdf
        '
        Me.btnExportarPdf.Image = Global.ColegioEchaurren.My.Resources.Resources.icono_pdf
        Me.btnExportarPdf.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExportarPdf.Location = New System.Drawing.Point(12, 429)
        Me.btnExportarPdf.Name = "btnExportarPdf"
        Me.btnExportarPdf.Size = New System.Drawing.Size(128, 48)
        Me.btnExportarPdf.TabIndex = 29
        Me.btnExportarPdf.Text = "Exportar a pdf"
        Me.btnExportarPdf.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExportarPdf.UseVisualStyleBackColor = True
        '
        'AdminMensualidades
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(825, 484)
        Me.Controls.Add(Me.btnExportarExcel)
        Me.Controls.Add(Me.btnExportarPdf)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.labelPorcentaje)
        Me.Controls.Add(Me.cbPorcentaje)
        Me.Controls.Add(Me.CheckAtrasado)
        Me.Controls.Add(Me.CheckPagado)
        Me.Controls.Add(Me.CheckNoBecado)
        Me.Controls.Add(Me.CheckBecado)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cbFiltroCurso)
        Me.Controls.Add(Me.DataGridView1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "AdminMensualidades"
        Me.Text = "Administrador de Mensualidades"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents labelPorcentaje As System.Windows.Forms.Label
    Friend WithEvents cbPorcentaje As System.Windows.Forms.ComboBox
    Friend WithEvents CheckAtrasado As System.Windows.Forms.CheckBox
    Friend WithEvents CheckPagado As System.Windows.Forms.CheckBox
    Friend WithEvents CheckNoBecado As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBecado As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbFiltroCurso As System.Windows.Forms.ComboBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents btnExportarPdf As System.Windows.Forms.Button
    Friend WithEvents btnExportarExcel As System.Windows.Forms.Button
End Class
