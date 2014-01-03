<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formReportes
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
        Me.components = New System.ComponentModel.Container()
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim ReportDataSource2 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim ReportDataSource3 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim ReportDataSource4 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(formReportes))
        Me.alumnoBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.bd_echaurrenDataSet = New ColegioEchaurren.bd_echaurrenDataSet()
        Me.mensualidadBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.fichaalumnoBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.alumnoTableAdapter = New ColegioEchaurren.bd_echaurrenDataSetTableAdapters.alumnoTableAdapter()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.ReportViewer2 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.ReportViewer3 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.ReportViewer4 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.mensualidadTableAdapter = New ColegioEchaurren.bd_echaurrenDataSetTableAdapters.mensualidadTableAdapter()
        Me.fichaalumnoTableAdapter = New ColegioEchaurren.bd_echaurrenDataSetTableAdapters.fichaalumnoTableAdapter()
        CType(Me.alumnoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bd_echaurrenDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.mensualidadBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.fichaalumnoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.SuspendLayout()
        '
        'alumnoBindingSource
        '
        Me.alumnoBindingSource.DataMember = "alumno"
        Me.alumnoBindingSource.DataSource = Me.bd_echaurrenDataSet
        '
        'bd_echaurrenDataSet
        '
        Me.bd_echaurrenDataSet.DataSetName = "bd_echaurrenDataSet"
        Me.bd_echaurrenDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'mensualidadBindingSource
        '
        Me.mensualidadBindingSource.DataMember = "mensualidad"
        Me.mensualidadBindingSource.DataSource = Me.bd_echaurrenDataSet
        '
        'fichaalumnoBindingSource
        '
        Me.fichaalumnoBindingSource.DataMember = "fichaalumno"
        Me.fichaalumnoBindingSource.DataSource = Me.bd_echaurrenDataSet
        '
        'alumnoTableAdapter
        '
        Me.alumnoTableAdapter.ClearBeforeFill = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Location = New System.Drawing.Point(12, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(769, 392)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.ReportViewer1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(761, 366)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Alumnos por sexo"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'ReportViewer1
        '
        ReportDataSource1.Name = "DataSet1"
        ReportDataSource1.Value = Me.alumnoBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "ColegioEchaurren.Report1.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(765, 370)
        Me.ReportViewer1.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.ReportViewer2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(761, 366)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Pagos atrasados y al dia"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'ReportViewer2
        '
        ReportDataSource2.Name = "DataSet1"
        ReportDataSource2.Value = Me.mensualidadBindingSource
        Me.ReportViewer2.LocalReport.DataSources.Add(ReportDataSource2)
        Me.ReportViewer2.LocalReport.ReportEmbeddedResource = "ColegioEchaurren.Report2.rdlc"
        Me.ReportViewer2.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer2.Name = "ReportViewer2"
        Me.ReportViewer2.Size = New System.Drawing.Size(765, 370)
        Me.ReportViewer2.TabIndex = 0
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.ReportViewer3)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(761, 366)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Cantidad de becados y no becados"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'ReportViewer3
        '
        ReportDataSource3.Name = "DataSet1"
        ReportDataSource3.Value = Me.fichaalumnoBindingSource
        Me.ReportViewer3.LocalReport.DataSources.Add(ReportDataSource3)
        Me.ReportViewer3.LocalReport.ReportEmbeddedResource = "ColegioEchaurren.Report3.rdlc"
        Me.ReportViewer3.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer3.Name = "ReportViewer3"
        Me.ReportViewer3.Size = New System.Drawing.Size(765, 370)
        Me.ReportViewer3.TabIndex = 0
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.ReportViewer4)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(761, 366)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Cantidad de alumnos por convivencia familiar"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'ReportViewer4
        '
        ReportDataSource4.Name = "DataSet1"
        ReportDataSource4.Value = Me.fichaalumnoBindingSource
        Me.ReportViewer4.LocalReport.DataSources.Add(ReportDataSource4)
        Me.ReportViewer4.LocalReport.ReportEmbeddedResource = "ColegioEchaurren.Report4.rdlc"
        Me.ReportViewer4.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer4.Name = "ReportViewer4"
        Me.ReportViewer4.Size = New System.Drawing.Size(765, 370)
        Me.ReportViewer4.TabIndex = 0
        '
        'mensualidadTableAdapter
        '
        Me.mensualidadTableAdapter.ClearBeforeFill = True
        '
        'fichaalumnoTableAdapter
        '
        Me.fichaalumnoTableAdapter.ClearBeforeFill = True
        '
        'formReportes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(793, 416)
        Me.Controls.Add(Me.TabControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "formReportes"
        Me.Text = "formReportes"
        CType(Me.alumnoBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bd_echaurrenDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.mensualidadBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.fichaalumnoBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents alumnoBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents bd_echaurrenDataSet As ColegioEchaurren.bd_echaurrenDataSet
    Friend WithEvents alumnoTableAdapter As ColegioEchaurren.bd_echaurrenDataSetTableAdapters.alumnoTableAdapter
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents ReportViewer2 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents mensualidadBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents mensualidadTableAdapter As ColegioEchaurren.bd_echaurrenDataSetTableAdapters.mensualidadTableAdapter
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents ReportViewer3 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents fichaalumnoBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents fichaalumnoTableAdapter As ColegioEchaurren.bd_echaurrenDataSetTableAdapters.fichaalumnoTableAdapter
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents ReportViewer4 As Microsoft.Reporting.WinForms.ReportViewer
End Class
