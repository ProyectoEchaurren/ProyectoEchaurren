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
        Me.FinanzasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RealizarPagoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RegistroDeMensualidadesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AdministracionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AlumnosMatriculadosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AdministrarBecasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DocumentosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImprimirPlanillasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EscanearDocumentosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UsuariosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GestionarUsuariosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CambiarContraseñaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HerramientasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConfigurarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RespaldarBaseDeDatosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LoginToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AyudaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AcercaDeToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.AcercaDeToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.EstadisticasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MatriculasToolStripMenuItem, Me.FinanzasToolStripMenuItem, Me.AdministracionToolStripMenuItem, Me.DocumentosToolStripMenuItem, Me.UsuariosToolStripMenuItem, Me.HerramientasToolStripMenuItem, Me.LoginToolStripMenuItem, Me.AyudaToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(692, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'MatriculasToolStripMenuItem
        '
        Me.MatriculasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CrearMatriculaToolStripMenuItem})
        Me.MatriculasToolStripMenuItem.Enabled = False
        Me.MatriculasToolStripMenuItem.Name = "MatriculasToolStripMenuItem"
        Me.MatriculasToolStripMenuItem.Size = New System.Drawing.Size(74, 20)
        Me.MatriculasToolStripMenuItem.Text = "Matriculas"
        '
        'CrearMatriculaToolStripMenuItem
        '
        Me.CrearMatriculaToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.CrearMatriculaToolStripMenuItem.Image = CType(resources.GetObject("CrearMatriculaToolStripMenuItem.Image"), System.Drawing.Image)
        Me.CrearMatriculaToolStripMenuItem.Name = "CrearMatriculaToolStripMenuItem"
        Me.CrearMatriculaToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.CrearMatriculaToolStripMenuItem.Text = "Crear Matricula"
        '
        'FinanzasToolStripMenuItem
        '
        Me.FinanzasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RealizarPagoToolStripMenuItem, Me.RegistroDeMensualidadesToolStripMenuItem})
        Me.FinanzasToolStripMenuItem.Enabled = False
        Me.FinanzasToolStripMenuItem.Name = "FinanzasToolStripMenuItem"
        Me.FinanzasToolStripMenuItem.Size = New System.Drawing.Size(64, 20)
        Me.FinanzasToolStripMenuItem.Text = "Finanzas"
        '
        'RealizarPagoToolStripMenuItem
        '
        Me.RealizarPagoToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.RealizarPagoToolStripMenuItem.Image = CType(resources.GetObject("RealizarPagoToolStripMenuItem.Image"), System.Drawing.Image)
        Me.RealizarPagoToolStripMenuItem.Name = "RealizarPagoToolStripMenuItem"
        Me.RealizarPagoToolStripMenuItem.Size = New System.Drawing.Size(215, 22)
        Me.RealizarPagoToolStripMenuItem.Text = "Realizar Pago"
        '
        'RegistroDeMensualidadesToolStripMenuItem
        '
        Me.RegistroDeMensualidadesToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.RegistroDeMensualidadesToolStripMenuItem.Name = "RegistroDeMensualidadesToolStripMenuItem"
        Me.RegistroDeMensualidadesToolStripMenuItem.Size = New System.Drawing.Size(215, 22)
        Me.RegistroDeMensualidadesToolStripMenuItem.Text = "Registro de Mensualidades"
        '
        'AdministracionToolStripMenuItem
        '
        Me.AdministracionToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AlumnosMatriculadosToolStripMenuItem, Me.AdministrarBecasToolStripMenuItem, Me.EstadisticasToolStripMenuItem})
        Me.AdministracionToolStripMenuItem.Enabled = False
        Me.AdministracionToolStripMenuItem.Name = "AdministracionToolStripMenuItem"
        Me.AdministracionToolStripMenuItem.Size = New System.Drawing.Size(100, 20)
        Me.AdministracionToolStripMenuItem.Text = "Administracion"
        '
        'AlumnosMatriculadosToolStripMenuItem
        '
        Me.AlumnosMatriculadosToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.AlumnosMatriculadosToolStripMenuItem.Name = "AlumnosMatriculadosToolStripMenuItem"
        Me.AlumnosMatriculadosToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.AlumnosMatriculadosToolStripMenuItem.Text = "Alumnos matriculados"
        '
        'AdministrarBecasToolStripMenuItem
        '
        Me.AdministrarBecasToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.AdministrarBecasToolStripMenuItem.Name = "AdministrarBecasToolStripMenuItem"
        Me.AdministrarBecasToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.AdministrarBecasToolStripMenuItem.Text = "Administrar Becas"
        '
        'DocumentosToolStripMenuItem
        '
        Me.DocumentosToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.DocumentosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ImprimirPlanillasToolStripMenuItem, Me.EscanearDocumentosToolStripMenuItem})
        Me.DocumentosToolStripMenuItem.Enabled = False
        Me.DocumentosToolStripMenuItem.Name = "DocumentosToolStripMenuItem"
        Me.DocumentosToolStripMenuItem.Size = New System.Drawing.Size(87, 20)
        Me.DocumentosToolStripMenuItem.Text = "Documentos"
        '
        'ImprimirPlanillasToolStripMenuItem
        '
        Me.ImprimirPlanillasToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ImprimirPlanillasToolStripMenuItem.Image = CType(resources.GetObject("ImprimirPlanillasToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ImprimirPlanillasToolStripMenuItem.Name = "ImprimirPlanillasToolStripMenuItem"
        Me.ImprimirPlanillasToolStripMenuItem.Size = New System.Drawing.Size(191, 22)
        Me.ImprimirPlanillasToolStripMenuItem.Text = "Imprimir Planillas"
        '
        'EscanearDocumentosToolStripMenuItem
        '
        Me.EscanearDocumentosToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.EscanearDocumentosToolStripMenuItem.Image = CType(resources.GetObject("EscanearDocumentosToolStripMenuItem.Image"), System.Drawing.Image)
        Me.EscanearDocumentosToolStripMenuItem.Name = "EscanearDocumentosToolStripMenuItem"
        Me.EscanearDocumentosToolStripMenuItem.Size = New System.Drawing.Size(191, 22)
        Me.EscanearDocumentosToolStripMenuItem.Text = "Escanear Documentos"
        '
        'UsuariosToolStripMenuItem
        '
        Me.UsuariosToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.UsuariosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GestionarUsuariosToolStripMenuItem, Me.CambiarContraseñaToolStripMenuItem})
        Me.UsuariosToolStripMenuItem.Enabled = False
        Me.UsuariosToolStripMenuItem.Name = "UsuariosToolStripMenuItem"
        Me.UsuariosToolStripMenuItem.Size = New System.Drawing.Size(64, 20)
        Me.UsuariosToolStripMenuItem.Text = "Usuarios"
        '
        'GestionarUsuariosToolStripMenuItem
        '
        Me.GestionarUsuariosToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.GestionarUsuariosToolStripMenuItem.Image = CType(resources.GetObject("GestionarUsuariosToolStripMenuItem.Image"), System.Drawing.Image)
        Me.GestionarUsuariosToolStripMenuItem.Name = "GestionarUsuariosToolStripMenuItem"
        Me.GestionarUsuariosToolStripMenuItem.Size = New System.Drawing.Size(182, 22)
        Me.GestionarUsuariosToolStripMenuItem.Text = "Gestionar Usuarios"
        '
        'CambiarContraseñaToolStripMenuItem
        '
        Me.CambiarContraseñaToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.CambiarContraseñaToolStripMenuItem.Image = CType(resources.GetObject("CambiarContraseñaToolStripMenuItem.Image"), System.Drawing.Image)
        Me.CambiarContraseñaToolStripMenuItem.Name = "CambiarContraseñaToolStripMenuItem"
        Me.CambiarContraseñaToolStripMenuItem.Size = New System.Drawing.Size(182, 22)
        Me.CambiarContraseñaToolStripMenuItem.Text = "Cambiar Contraseña"
        '
        'HerramientasToolStripMenuItem
        '
        Me.HerramientasToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.HerramientasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConfigurarToolStripMenuItem, Me.RespaldarBaseDeDatosToolStripMenuItem})
        Me.HerramientasToolStripMenuItem.Name = "HerramientasToolStripMenuItem"
        Me.HerramientasToolStripMenuItem.Size = New System.Drawing.Size(90, 20)
        Me.HerramientasToolStripMenuItem.Text = "Herramientas"
        '
        'ConfigurarToolStripMenuItem
        '
        Me.ConfigurarToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ConfigurarToolStripMenuItem.Image = CType(resources.GetObject("ConfigurarToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ConfigurarToolStripMenuItem.Name = "ConfigurarToolStripMenuItem"
        Me.ConfigurarToolStripMenuItem.Size = New System.Drawing.Size(201, 22)
        Me.ConfigurarToolStripMenuItem.Text = "Configurar Dispositivos"
        '
        'RespaldarBaseDeDatosToolStripMenuItem
        '
        Me.RespaldarBaseDeDatosToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.RespaldarBaseDeDatosToolStripMenuItem.Image = CType(resources.GetObject("RespaldarBaseDeDatosToolStripMenuItem.Image"), System.Drawing.Image)
        Me.RespaldarBaseDeDatosToolStripMenuItem.Name = "RespaldarBaseDeDatosToolStripMenuItem"
        Me.RespaldarBaseDeDatosToolStripMenuItem.Size = New System.Drawing.Size(201, 22)
        Me.RespaldarBaseDeDatosToolStripMenuItem.Text = "Respaldar Base de Datos"
        '
        'LoginToolStripMenuItem
        '
        Me.LoginToolStripMenuItem.Name = "LoginToolStripMenuItem"
        Me.LoginToolStripMenuItem.Size = New System.Drawing.Size(88, 20)
        Me.LoginToolStripMenuItem.Text = "Iniciar Sesión"
        '
        'AyudaToolStripMenuItem
        '
        Me.AyudaToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.AyudaToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AcercaDeToolStripMenuItem1, Me.AcercaDeToolStripMenuItem2})
        Me.AyudaToolStripMenuItem.Name = "AyudaToolStripMenuItem"
        Me.AyudaToolStripMenuItem.Size = New System.Drawing.Size(53, 20)
        Me.AyudaToolStripMenuItem.Text = "Ayuda"
        '
        'AcercaDeToolStripMenuItem1
        '
        Me.AcercaDeToolStripMenuItem1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.AcercaDeToolStripMenuItem1.Image = CType(resources.GetObject("AcercaDeToolStripMenuItem1.Image"), System.Drawing.Image)
        Me.AcercaDeToolStripMenuItem1.Name = "AcercaDeToolStripMenuItem1"
        Me.AcercaDeToolStripMenuItem1.Size = New System.Drawing.Size(126, 22)
        Me.AcercaDeToolStripMenuItem1.Text = "Ver ayuda"
        '
        'AcercaDeToolStripMenuItem2
        '
        Me.AcercaDeToolStripMenuItem2.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.AcercaDeToolStripMenuItem2.Image = CType(resources.GetObject("AcercaDeToolStripMenuItem2.Image"), System.Drawing.Image)
        Me.AcercaDeToolStripMenuItem2.Name = "AcercaDeToolStripMenuItem2"
        Me.AcercaDeToolStripMenuItem2.Size = New System.Drawing.Size(126, 22)
        Me.AcercaDeToolStripMenuItem2.Text = "Acerca de"
        '
        'EstadisticasToolStripMenuItem
        '
        Me.EstadisticasToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.EstadisticasToolStripMenuItem.Name = "EstadisticasToolStripMenuItem"
        Me.EstadisticasToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.EstadisticasToolStripMenuItem.Text = "Estadisticas"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(692, 322)
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
    Friend WithEvents RegistroDeMensualidadesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AcercaDeToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AcercaDeToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AlumnosMatriculadosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RealizarPagoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AdministrarBecasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DocumentosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImprimirPlanillasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EscanearDocumentosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UsuariosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GestionarUsuariosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CambiarContraseñaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HerramientasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConfigurarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RespaldarBaseDeDatosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EstadisticasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
