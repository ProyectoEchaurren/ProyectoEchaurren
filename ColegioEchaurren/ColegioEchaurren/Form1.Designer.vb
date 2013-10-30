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
        Me.MatriculasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CrearMatriculaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AdministrarMatriculasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FinanzasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RealizarPagoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RegistroDeMensualidadesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TransferenciasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AdministracionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AlumnosMatriculadosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RecursosHumanosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LoginToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AyudaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AcercaDeToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.AcercaDeToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MatriculasToolStripMenuItem, Me.FinanzasToolStripMenuItem, Me.AdministracionToolStripMenuItem, Me.RecursosHumanosToolStripMenuItem, Me.LoginToolStripMenuItem, Me.AyudaToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(605, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'MatriculasToolStripMenuItem
        '
        Me.MatriculasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CrearMatriculaToolStripMenuItem, Me.AdministrarMatriculasToolStripMenuItem})
        Me.MatriculasToolStripMenuItem.Enabled = False
        Me.MatriculasToolStripMenuItem.Name = "MatriculasToolStripMenuItem"
        Me.MatriculasToolStripMenuItem.Size = New System.Drawing.Size(74, 20)
        Me.MatriculasToolStripMenuItem.Text = "Matriculas"
        '
        'CrearMatriculaToolStripMenuItem
        '
        Me.CrearMatriculaToolStripMenuItem.Name = "CrearMatriculaToolStripMenuItem"
        Me.CrearMatriculaToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.CrearMatriculaToolStripMenuItem.Text = "Crear Matricula"
        '
        'AdministrarMatriculasToolStripMenuItem
        '
        Me.AdministrarMatriculasToolStripMenuItem.Name = "AdministrarMatriculasToolStripMenuItem"
        Me.AdministrarMatriculasToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.AdministrarMatriculasToolStripMenuItem.Text = "Administrar Matriculas"
        '
        'FinanzasToolStripMenuItem
        '
        Me.FinanzasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RealizarPagoToolStripMenuItem, Me.RegistroDeMensualidadesToolStripMenuItem, Me.TransferenciasToolStripMenuItem})
        Me.FinanzasToolStripMenuItem.Enabled = False
        Me.FinanzasToolStripMenuItem.Name = "FinanzasToolStripMenuItem"
        Me.FinanzasToolStripMenuItem.Size = New System.Drawing.Size(64, 20)
        Me.FinanzasToolStripMenuItem.Text = "Finanzas"
        '
        'RealizarPagoToolStripMenuItem
        '
        Me.RealizarPagoToolStripMenuItem.Name = "RealizarPagoToolStripMenuItem"
        Me.RealizarPagoToolStripMenuItem.Size = New System.Drawing.Size(215, 22)
        Me.RealizarPagoToolStripMenuItem.Text = "Realizar Pago"
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
        'AdministracionToolStripMenuItem
        '
        Me.AdministracionToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AlumnosMatriculadosToolStripMenuItem})
        Me.AdministracionToolStripMenuItem.Enabled = False
        Me.AdministracionToolStripMenuItem.Name = "AdministracionToolStripMenuItem"
        Me.AdministracionToolStripMenuItem.Size = New System.Drawing.Size(100, 20)
        Me.AdministracionToolStripMenuItem.Text = "Administracion"
        '
        'AlumnosMatriculadosToolStripMenuItem
        '
        Me.AlumnosMatriculadosToolStripMenuItem.Name = "AlumnosMatriculadosToolStripMenuItem"
        Me.AlumnosMatriculadosToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.AlumnosMatriculadosToolStripMenuItem.Text = "Alumnos matriculados"
        '
        'RecursosHumanosToolStripMenuItem
        '
        Me.RecursosHumanosToolStripMenuItem.Enabled = False
        Me.RecursosHumanosToolStripMenuItem.Name = "RecursosHumanosToolStripMenuItem"
        Me.RecursosHumanosToolStripMenuItem.Size = New System.Drawing.Size(119, 20)
        Me.RecursosHumanosToolStripMenuItem.Text = "Recursos humanos"
        '
        'LoginToolStripMenuItem
        '
        Me.LoginToolStripMenuItem.Name = "LoginToolStripMenuItem"
        Me.LoginToolStripMenuItem.Size = New System.Drawing.Size(88, 20)
        Me.LoginToolStripMenuItem.Text = "Iniciar Sesión"
        '
        'AyudaToolStripMenuItem
        '
        Me.AyudaToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AcercaDeToolStripMenuItem1, Me.AcercaDeToolStripMenuItem2})
        Me.AyudaToolStripMenuItem.Name = "AyudaToolStripMenuItem"
        Me.AyudaToolStripMenuItem.Size = New System.Drawing.Size(53, 20)
        Me.AyudaToolStripMenuItem.Text = "Ayuda"
        '
        'AcercaDeToolStripMenuItem1
        '
        Me.AcercaDeToolStripMenuItem1.Name = "AcercaDeToolStripMenuItem1"
        Me.AcercaDeToolStripMenuItem1.Size = New System.Drawing.Size(126, 22)
        Me.AcercaDeToolStripMenuItem1.Text = "Ver ayuda"
        '
        'AcercaDeToolStripMenuItem2
        '
        Me.AcercaDeToolStripMenuItem2.Name = "AcercaDeToolStripMenuItem2"
        Me.AcercaDeToolStripMenuItem2.Size = New System.Drawing.Size(126, 22)
        Me.AcercaDeToolStripMenuItem2.Text = "Acerca de"
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
    Friend WithEvents AyudaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AdministracionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LoginToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CrearMatriculaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AdministrarMatriculasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RegistroDeMensualidadesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TransferenciasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AcercaDeToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AcercaDeToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RecursosHumanosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AlumnosMatriculadosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RealizarPagoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
