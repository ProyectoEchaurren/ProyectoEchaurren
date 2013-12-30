<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ImprimirPlanillas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ImprimirPlanillas))
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.checkRut = New System.Windows.Forms.CheckBox()
        Me.checkNombre = New System.Windows.Forms.CheckBox()
        Me.checkApellidos = New System.Windows.Forms.CheckBox()
        Me.checkEdad = New System.Windows.Forms.CheckBox()
        Me.checkSexo = New System.Windows.Forms.CheckBox()
        Me.checkCurso = New System.Windows.Forms.CheckBox()
        Me.checkBecas = New System.Windows.Forms.CheckBox()
        Me.checkSalud = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.btnExportarExcel = New System.Windows.Forms.Button()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.btnImprimirPlanilla = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowDrop = True
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToOrderColumns = True
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(12, 12)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(471, 299)
        Me.DataGridView1.TabIndex = 0
        '
        'checkRut
        '
        Me.checkRut.AutoSize = True
        Me.checkRut.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.checkRut.Location = New System.Drawing.Point(505, 62)
        Me.checkRut.Name = "checkRut"
        Me.checkRut.Size = New System.Drawing.Size(53, 17)
        Me.checkRut.TabIndex = 2
        Me.checkRut.Text = "RUN"
        Me.checkRut.UseVisualStyleBackColor = True
        '
        'checkNombre
        '
        Me.checkNombre.AutoSize = True
        Me.checkNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.checkNombre.Location = New System.Drawing.Point(505, 85)
        Me.checkNombre.Name = "checkNombre"
        Me.checkNombre.Size = New System.Drawing.Size(69, 17)
        Me.checkNombre.TabIndex = 3
        Me.checkNombre.Text = "Nombre"
        Me.checkNombre.UseVisualStyleBackColor = True
        '
        'checkApellidos
        '
        Me.checkApellidos.AutoSize = True
        Me.checkApellidos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.checkApellidos.Location = New System.Drawing.Point(505, 108)
        Me.checkApellidos.Name = "checkApellidos"
        Me.checkApellidos.Size = New System.Drawing.Size(77, 17)
        Me.checkApellidos.TabIndex = 4
        Me.checkApellidos.Text = "Apellidos"
        Me.checkApellidos.UseVisualStyleBackColor = True
        '
        'checkEdad
        '
        Me.checkEdad.AutoSize = True
        Me.checkEdad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.checkEdad.Location = New System.Drawing.Point(505, 131)
        Me.checkEdad.Name = "checkEdad"
        Me.checkEdad.Size = New System.Drawing.Size(55, 17)
        Me.checkEdad.TabIndex = 5
        Me.checkEdad.Text = "Edad"
        Me.checkEdad.UseVisualStyleBackColor = True
        '
        'checkSexo
        '
        Me.checkSexo.AutoSize = True
        Me.checkSexo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.checkSexo.Location = New System.Drawing.Point(601, 62)
        Me.checkSexo.Name = "checkSexo"
        Me.checkSexo.Size = New System.Drawing.Size(54, 17)
        Me.checkSexo.TabIndex = 6
        Me.checkSexo.Text = "Sexo"
        Me.checkSexo.UseVisualStyleBackColor = True
        '
        'checkCurso
        '
        Me.checkCurso.AutoSize = True
        Me.checkCurso.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.checkCurso.Location = New System.Drawing.Point(601, 85)
        Me.checkCurso.Name = "checkCurso"
        Me.checkCurso.Size = New System.Drawing.Size(58, 17)
        Me.checkCurso.TabIndex = 7
        Me.checkCurso.Text = "Curso"
        Me.checkCurso.UseVisualStyleBackColor = True
        '
        'checkBecas
        '
        Me.checkBecas.AutoSize = True
        Me.checkBecas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.checkBecas.Location = New System.Drawing.Point(601, 108)
        Me.checkBecas.Name = "checkBecas"
        Me.checkBecas.Size = New System.Drawing.Size(61, 17)
        Me.checkBecas.TabIndex = 8
        Me.checkBecas.Text = "Becas"
        Me.checkBecas.UseVisualStyleBackColor = True
        '
        'checkSalud
        '
        Me.checkSalud.AutoSize = True
        Me.checkSalud.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.checkSalud.Location = New System.Drawing.Point(601, 131)
        Me.checkSalud.Name = "checkSalud"
        Me.checkSalud.Size = New System.Drawing.Size(58, 17)
        Me.checkSalud.TabIndex = 9
        Me.checkSalud.Text = "Salud"
        Me.checkSalud.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(492, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(180, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Seleccionar Campos a Imprimir"
        '
        'PrintDocument1
        '
        '
        'btnExportarExcel
        '
        Me.btnExportarExcel.Image = Global.ColegioEchaurren.My.Resources.Resources.Excel_icon
        Me.btnExportarExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExportarExcel.Location = New System.Drawing.Point(516, 217)
        Me.btnExportarExcel.Name = "btnExportarExcel"
        Me.btnExportarExcel.Size = New System.Drawing.Size(139, 43)
        Me.btnExportarExcel.TabIndex = 12
        Me.btnExportarExcel.Text = "Exportar Excel"
        Me.btnExportarExcel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExportarExcel.UseVisualStyleBackColor = True
        '
        'btnExportar
        '
        Me.btnExportar.Image = Global.ColegioEchaurren.My.Resources.Resources.icono_pdf
        Me.btnExportar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExportar.Location = New System.Drawing.Point(516, 167)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(139, 44)
        Me.btnExportar.TabIndex = 11
        Me.btnExportar.Text = "Exportar a pdf"
        Me.btnExportar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'btnImprimirPlanilla
        '
        Me.btnImprimirPlanilla.Image = Global.ColegioEchaurren.My.Resources.Resources.icono_imprimir
        Me.btnImprimirPlanilla.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnImprimirPlanilla.Location = New System.Drawing.Point(516, 266)
        Me.btnImprimirPlanilla.Name = "btnImprimirPlanilla"
        Me.btnImprimirPlanilla.Size = New System.Drawing.Size(139, 43)
        Me.btnImprimirPlanilla.TabIndex = 1
        Me.btnImprimirPlanilla.Text = "Imprimir Planilla"
        Me.btnImprimirPlanilla.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnImprimirPlanilla.UseVisualStyleBackColor = True
        '
        'ImprimirPlanillas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(687, 326)
        Me.Controls.Add(Me.btnExportarExcel)
        Me.Controls.Add(Me.btnExportar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.checkSalud)
        Me.Controls.Add(Me.checkBecas)
        Me.Controls.Add(Me.checkCurso)
        Me.Controls.Add(Me.checkSexo)
        Me.Controls.Add(Me.checkEdad)
        Me.Controls.Add(Me.checkApellidos)
        Me.Controls.Add(Me.checkNombre)
        Me.Controls.Add(Me.checkRut)
        Me.Controls.Add(Me.btnImprimirPlanilla)
        Me.Controls.Add(Me.DataGridView1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ImprimirPlanillas"
        Me.Text = "Impresión de Planillas"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents btnImprimirPlanilla As System.Windows.Forms.Button
    Friend WithEvents checkRut As System.Windows.Forms.CheckBox
    Friend WithEvents checkNombre As System.Windows.Forms.CheckBox
    Friend WithEvents checkApellidos As System.Windows.Forms.CheckBox
    Friend WithEvents checkEdad As System.Windows.Forms.CheckBox
    Friend WithEvents checkSexo As System.Windows.Forms.CheckBox
    Friend WithEvents checkCurso As System.Windows.Forms.CheckBox
    Friend WithEvents checkBecas As System.Windows.Forms.CheckBox
    Friend WithEvents checkSalud As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents btnExportar As System.Windows.Forms.Button
    Friend WithEvents btnExportarExcel As System.Windows.Forms.Button
End Class
