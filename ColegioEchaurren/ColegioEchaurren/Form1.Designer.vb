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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FinanzasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MatriculasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CurricularToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AyudaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AcercaDeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LoginToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImpresionDePlanillasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DigitalizarDocumentosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PagosRecibidosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RegistroDeMensualidadesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TransferenciasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CrearMatriculaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CancelarMatriculaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AdministrarMatriculasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MatriculasToolStripMenuItem, Me.CurricularToolStripMenuItem, Me.FinanzasToolStripMenuItem, Me.AyudaToolStripMenuItem, Me.AcercaDeToolStripMenuItem, Me.LoginToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(605, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FinanzasToolStripMenuItem
        '
        Me.FinanzasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PagosRecibidosToolStripMenuItem, Me.RegistroDeMensualidadesToolStripMenuItem, Me.TransferenciasToolStripMenuItem})
        Me.FinanzasToolStripMenuItem.Name = "FinanzasToolStripMenuItem"
        Me.FinanzasToolStripMenuItem.Size = New System.Drawing.Size(64, 20)
        Me.FinanzasToolStripMenuItem.Text = "Finanzas"
        '
        'MatriculasToolStripMenuItem
        '
        Me.MatriculasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CrearMatriculaToolStripMenuItem, Me.AdministrarMatriculasToolStripMenuItem, Me.CancelarMatriculaToolStripMenuItem})
        Me.MatriculasToolStripMenuItem.Name = "MatriculasToolStripMenuItem"
        Me.MatriculasToolStripMenuItem.Size = New System.Drawing.Size(74, 20)
        Me.MatriculasToolStripMenuItem.Text = "Matriculas"
        '
        'CurricularToolStripMenuItem
        '
        Me.CurricularToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ImpresionDePlanillasToolStripMenuItem, Me.DigitalizarDocumentosToolStripMenuItem})
        Me.CurricularToolStripMenuItem.Name = "CurricularToolStripMenuItem"
        Me.CurricularToolStripMenuItem.Size = New System.Drawing.Size(71, 20)
        Me.CurricularToolStripMenuItem.Text = "Curricular"
        '
        'AyudaToolStripMenuItem
        '
        Me.AyudaToolStripMenuItem.Name = "AyudaToolStripMenuItem"
        Me.AyudaToolStripMenuItem.Size = New System.Drawing.Size(53, 20)
        Me.AyudaToolStripMenuItem.Text = "Ayuda"
        '
        'AcercaDeToolStripMenuItem
        '
        Me.AcercaDeToolStripMenuItem.Name = "AcercaDeToolStripMenuItem"
        Me.AcercaDeToolStripMenuItem.Size = New System.Drawing.Size(71, 20)
        Me.AcercaDeToolStripMenuItem.Text = "Acerca de"
        '
        'LoginToolStripMenuItem
        '
        Me.LoginToolStripMenuItem.Name = "LoginToolStripMenuItem"
        Me.LoginToolStripMenuItem.Size = New System.Drawing.Size(49, 20)
        Me.LoginToolStripMenuItem.Text = "Login"
        '
        'ImpresionDePlanillasToolStripMenuItem
        '
        Me.ImpresionDePlanillasToolStripMenuItem.Name = "ImpresionDePlanillasToolStripMenuItem"
        Me.ImpresionDePlanillasToolStripMenuItem.Size = New System.Drawing.Size(197, 22)
        Me.ImpresionDePlanillasToolStripMenuItem.Text = "Impresión de Planillas"
        '
        'DigitalizarDocumentosToolStripMenuItem
        '
        Me.DigitalizarDocumentosToolStripMenuItem.Name = "DigitalizarDocumentosToolStripMenuItem"
        Me.DigitalizarDocumentosToolStripMenuItem.Size = New System.Drawing.Size(197, 22)
        Me.DigitalizarDocumentosToolStripMenuItem.Text = "Digitalizar Documentos"
        '
        'PagosRecibidosToolStripMenuItem
        '
        Me.PagosRecibidosToolStripMenuItem.Name = "PagosRecibidosToolStripMenuItem"
        Me.PagosRecibidosToolStripMenuItem.Size = New System.Drawing.Size(215, 22)
        Me.PagosRecibidosToolStripMenuItem.Text = "Pagos Recibidos"
        '
        'RegistroDeMensualidadesToolStripMenuItem
        '
        Me.RegistroDeMensualidadesToolStripMenuItem.Name = "RegistroDeMensualidadesToolStripMenuItem"
        Me.RegistroDeMensualidadesToolStripMenuItem.Size = New System.Drawing.Size(215, 22)
        Me.RegistroDeMensualidadesToolStripMenuItem.Text = "Registro de Mensualidades"
        '
        'TransferenciasToolStripMenuItem
        '
        Me.TransferenciasToolStripMenuItem.Name = "TransferenciasToolStripMenuItem"
        Me.TransferenciasToolStripMenuItem.Size = New System.Drawing.Size(215, 22)
        Me.TransferenciasToolStripMenuItem.Text = "Transferencias"
        '
        'CrearMatriculaToolStripMenuItem
        '
        Me.CrearMatriculaToolStripMenuItem.Name = "CrearMatriculaToolStripMenuItem"
        Me.CrearMatriculaToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.CrearMatriculaToolStripMenuItem.Text = "Crear Matricula"
        '
        'CancelarMatriculaToolStripMenuItem
        '
        Me.CancelarMatriculaToolStripMenuItem.Name = "CancelarMatriculaToolStripMenuItem"
        Me.CancelarMatriculaToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.CancelarMatriculaToolStripMenuItem.Text = "Cancelar Matricula"
        '
        'AdministrarMatriculasToolStripMenuItem
        '
        Me.AdministrarMatriculasToolStripMenuItem.Name = "AdministrarMatriculasToolStripMenuItem"
        Me.AdministrarMatriculasToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.AdministrarMatriculasToolStripMenuItem.Text = "Administrar Matriculas"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(605, 319)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Colegio Echaurren"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FinanzasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MatriculasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CurricularToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AyudaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AcercaDeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LoginToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CrearMatriculaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AdministrarMatriculasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CancelarMatriculaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImpresionDePlanillasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DigitalizarDocumentosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PagosRecibidosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RegistroDeMensualidadesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TransferenciasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
