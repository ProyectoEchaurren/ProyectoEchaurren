<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RealizarPago
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RealizarPago))
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtMontoMensual = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnDeshacerPago = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.checkDic = New System.Windows.Forms.CheckBox()
        Me.checkNov = New System.Windows.Forms.CheckBox()
        Me.checkOctubre = New System.Windows.Forms.CheckBox()
        Me.checkSept = New System.Windows.Forms.CheckBox()
        Me.checkAgosto = New System.Windows.Forms.CheckBox()
        Me.checkJulio = New System.Windows.Forms.CheckBox()
        Me.checkJunio = New System.Windows.Forms.CheckBox()
        Me.checkMayo = New System.Windows.Forms.CheckBox()
        Me.checkAbril = New System.Windows.Forms.CheckBox()
        Me.checkMarzo = New System.Windows.Forms.CheckBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtMontoTotal = New System.Windows.Forms.TextBox()
        Me.txtComprobante = New System.Windows.Forms.TextBox()
        Me.btnPagar = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtPorcentaje = New System.Windows.Forms.TextBox()
        Me.txtTipoPago = New System.Windows.Forms.TextBox()
        Me.txtBeca = New System.Windows.Forms.TextBox()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.txtCampoRut = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(559, 72)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(83, 13)
        Me.Label8.TabIndex = 46
        Me.Label8.Text = "Monto Mensual:"
        '
        'txtMontoMensual
        '
        Me.txtMontoMensual.Location = New System.Drawing.Point(562, 88)
        Me.txtMontoMensual.Name = "txtMontoMensual"
        Me.txtMontoMensual.Size = New System.Drawing.Size(100, 20)
        Me.txtMontoMensual.TabIndex = 39
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnDeshacerPago)
        Me.GroupBox1.Controls.Add(Me.btnCancelar)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtMontoTotal)
        Me.GroupBox1.Controls.Add(Me.txtComprobante)
        Me.GroupBox1.Controls.Add(Me.btnPagar)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 144)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(661, 195)
        Me.GroupBox1.TabIndex = 45
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Información de Pago"
        '
        'btnDeshacerPago
        '
        Me.btnDeshacerPago.Location = New System.Drawing.Point(286, 129)
        Me.btnDeshacerPago.Name = "btnDeshacerPago"
        Me.btnDeshacerPago.Size = New System.Drawing.Size(109, 40)
        Me.btnDeshacerPago.TabIndex = 27
        Me.btnDeshacerPago.Text = "Deshacer Pago"
        Me.btnDeshacerPago.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(156, 129)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(109, 40)
        Me.btnCancelar.TabIndex = 26
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.checkDic)
        Me.GroupBox2.Controls.Add(Me.checkNov)
        Me.GroupBox2.Controls.Add(Me.checkOctubre)
        Me.GroupBox2.Controls.Add(Me.checkSept)
        Me.GroupBox2.Controls.Add(Me.checkAgosto)
        Me.GroupBox2.Controls.Add(Me.checkJulio)
        Me.GroupBox2.Controls.Add(Me.checkJunio)
        Me.GroupBox2.Controls.Add(Me.checkMayo)
        Me.GroupBox2.Controls.Add(Me.checkAbril)
        Me.GroupBox2.Controls.Add(Me.checkMarzo)
        Me.GroupBox2.Location = New System.Drawing.Point(416, 31)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(222, 150)
        Me.GroupBox2.TabIndex = 23
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Seleccione Meses a Pagar"
        '
        'checkDic
        '
        Me.checkDic.AutoSize = True
        Me.checkDic.Enabled = False
        Me.checkDic.Location = New System.Drawing.Point(121, 121)
        Me.checkDic.Name = "checkDic"
        Me.checkDic.Size = New System.Drawing.Size(85, 17)
        Me.checkDic.TabIndex = 17
        Me.checkDic.Text = "DICIEMBRE"
        Me.checkDic.UseVisualStyleBackColor = True
        '
        'checkNov
        '
        Me.checkNov.AutoSize = True
        Me.checkNov.Enabled = False
        Me.checkNov.Location = New System.Drawing.Point(121, 98)
        Me.checkNov.Name = "checkNov"
        Me.checkNov.Size = New System.Drawing.Size(90, 17)
        Me.checkNov.TabIndex = 16
        Me.checkNov.Text = "NOVIEMBRE"
        Me.checkNov.UseVisualStyleBackColor = True
        '
        'checkOctubre
        '
        Me.checkOctubre.AutoSize = True
        Me.checkOctubre.Enabled = False
        Me.checkOctubre.Location = New System.Drawing.Point(121, 75)
        Me.checkOctubre.Name = "checkOctubre"
        Me.checkOctubre.Size = New System.Drawing.Size(78, 17)
        Me.checkOctubre.TabIndex = 15
        Me.checkOctubre.Text = "OCTUBRE"
        Me.checkOctubre.UseVisualStyleBackColor = True
        '
        'checkSept
        '
        Me.checkSept.AutoSize = True
        Me.checkSept.Enabled = False
        Me.checkSept.Location = New System.Drawing.Point(121, 52)
        Me.checkSept.Name = "checkSept"
        Me.checkSept.Size = New System.Drawing.Size(95, 17)
        Me.checkSept.TabIndex = 14
        Me.checkSept.Text = "SEPTIEMBRE"
        Me.checkSept.UseVisualStyleBackColor = True
        '
        'checkAgosto
        '
        Me.checkAgosto.AutoSize = True
        Me.checkAgosto.Enabled = False
        Me.checkAgosto.Location = New System.Drawing.Point(121, 29)
        Me.checkAgosto.Name = "checkAgosto"
        Me.checkAgosto.Size = New System.Drawing.Size(71, 17)
        Me.checkAgosto.TabIndex = 13
        Me.checkAgosto.Text = "AGOSTO"
        Me.checkAgosto.UseVisualStyleBackColor = True
        '
        'checkJulio
        '
        Me.checkJulio.AutoSize = True
        Me.checkJulio.Enabled = False
        Me.checkJulio.Location = New System.Drawing.Point(24, 121)
        Me.checkJulio.Name = "checkJulio"
        Me.checkJulio.Size = New System.Drawing.Size(56, 17)
        Me.checkJulio.TabIndex = 12
        Me.checkJulio.Text = "JULIO"
        Me.checkJulio.UseVisualStyleBackColor = True
        '
        'checkJunio
        '
        Me.checkJunio.AutoSize = True
        Me.checkJunio.Enabled = False
        Me.checkJunio.Location = New System.Drawing.Point(24, 98)
        Me.checkJunio.Name = "checkJunio"
        Me.checkJunio.Size = New System.Drawing.Size(58, 17)
        Me.checkJunio.TabIndex = 11
        Me.checkJunio.Text = "JUNIO"
        Me.checkJunio.UseVisualStyleBackColor = True
        '
        'checkMayo
        '
        Me.checkMayo.AutoSize = True
        Me.checkMayo.Enabled = False
        Me.checkMayo.Location = New System.Drawing.Point(24, 75)
        Me.checkMayo.Name = "checkMayo"
        Me.checkMayo.Size = New System.Drawing.Size(57, 17)
        Me.checkMayo.TabIndex = 10
        Me.checkMayo.Text = "MAYO"
        Me.checkMayo.UseVisualStyleBackColor = True
        '
        'checkAbril
        '
        Me.checkAbril.AutoSize = True
        Me.checkAbril.Enabled = False
        Me.checkAbril.Location = New System.Drawing.Point(24, 52)
        Me.checkAbril.Name = "checkAbril"
        Me.checkAbril.Size = New System.Drawing.Size(57, 17)
        Me.checkAbril.TabIndex = 9
        Me.checkAbril.Text = "ABRIL"
        Me.checkAbril.UseVisualStyleBackColor = True
        '
        'checkMarzo
        '
        Me.checkMarzo.AutoSize = True
        Me.checkMarzo.Enabled = False
        Me.checkMarzo.Location = New System.Drawing.Point(24, 29)
        Me.checkMarzo.Name = "checkMarzo"
        Me.checkMarzo.Size = New System.Drawing.Size(65, 17)
        Me.checkMarzo.TabIndex = 8
        Me.checkMarzo.Text = "MARZO"
        Me.checkMarzo.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(227, 38)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(107, 13)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "Monto Total a Pagar:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(16, 38)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(103, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "N° de Comprobante:"
        '
        'txtMontoTotal
        '
        Me.txtMontoTotal.Location = New System.Drawing.Point(230, 54)
        Me.txtMontoTotal.Name = "txtMontoTotal"
        Me.txtMontoTotal.Size = New System.Drawing.Size(165, 20)
        Me.txtMontoTotal.TabIndex = 7
        '
        'txtComprobante
        '
        Me.txtComprobante.Location = New System.Drawing.Point(19, 54)
        Me.txtComprobante.Name = "txtComprobante"
        Me.txtComprobante.Size = New System.Drawing.Size(180, 20)
        Me.txtComprobante.TabIndex = 6
        '
        'btnPagar
        '
        Me.btnPagar.Location = New System.Drawing.Point(19, 129)
        Me.btnPagar.Name = "btnPagar"
        Me.btnPagar.Size = New System.Drawing.Size(109, 40)
        Me.btnPagar.TabIndex = 24
        Me.btnPagar.Text = "Efectuar Pago"
        Me.btnPagar.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(444, 72)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(104, 13)
        Me.Label5.TabIndex = 44
        Me.Label5.Text = "Porcentaje de Beca:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(327, 72)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 13)
        Me.Label4.TabIndex = 43
        Me.Label4.Text = "Tipo de Pago:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(211, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(97, 13)
        Me.Label3.TabIndex = 42
        Me.Label3.Text = "Estado de la Beca:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 13)
        Me.Label2.TabIndex = 41
        Me.Label2.Text = "Nombre de Alumno(a):"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(149, 13)
        Me.Label1.TabIndex = 40
        Me.Label1.Text = "Ingresar R.U.N. de Alumno(a):"
        '
        'txtPorcentaje
        '
        Me.txtPorcentaje.Location = New System.Drawing.Point(447, 88)
        Me.txtPorcentaje.Name = "txtPorcentaje"
        Me.txtPorcentaje.Size = New System.Drawing.Size(77, 20)
        Me.txtPorcentaje.TabIndex = 38
        '
        'txtTipoPago
        '
        Me.txtTipoPago.Location = New System.Drawing.Point(330, 88)
        Me.txtTipoPago.Name = "txtTipoPago"
        Me.txtTipoPago.Size = New System.Drawing.Size(100, 20)
        Me.txtTipoPago.TabIndex = 37
        '
        'txtBeca
        '
        Me.txtBeca.Location = New System.Drawing.Point(214, 88)
        Me.txtBeca.Name = "txtBeca"
        Me.txtBeca.Size = New System.Drawing.Size(100, 20)
        Me.txtBeca.TabIndex = 36
        '
        'txtNombre
        '
        Me.txtNombre.Location = New System.Drawing.Point(16, 88)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(180, 20)
        Me.txtNombre.TabIndex = 35
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Location = New System.Drawing.Point(330, 20)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(75, 23)
        Me.btnLimpiar.TabIndex = 47
        Me.btnLimpiar.Text = "Limpiar"
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'txtCampoRut
        '
        Me.txtCampoRut.Location = New System.Drawing.Point(168, 22)
        Me.txtCampoRut.MaxLength = 12
        Me.txtCampoRut.Name = "txtCampoRut"
        Me.txtCampoRut.Size = New System.Drawing.Size(122, 20)
        Me.txtCampoRut.TabIndex = 34
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(524, 90)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(20, 16)
        Me.Label9.TabIndex = 48
        Me.Label9.Text = "%"
        '
        'RealizarPago
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(685, 358)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtMontoMensual)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtPorcentaje)
        Me.Controls.Add(Me.txtTipoPago)
        Me.Controls.Add(Me.txtBeca)
        Me.Controls.Add(Me.txtNombre)
        Me.Controls.Add(Me.btnLimpiar)
        Me.Controls.Add(Me.txtCampoRut)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "RealizarPago"
        Me.Text = "Realizar Pago"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtMontoMensual As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents checkDic As System.Windows.Forms.CheckBox
    Friend WithEvents checkNov As System.Windows.Forms.CheckBox
    Friend WithEvents checkOctubre As System.Windows.Forms.CheckBox
    Friend WithEvents checkSept As System.Windows.Forms.CheckBox
    Friend WithEvents checkAgosto As System.Windows.Forms.CheckBox
    Friend WithEvents checkJulio As System.Windows.Forms.CheckBox
    Friend WithEvents checkJunio As System.Windows.Forms.CheckBox
    Friend WithEvents checkMayo As System.Windows.Forms.CheckBox
    Friend WithEvents checkAbril As System.Windows.Forms.CheckBox
    Friend WithEvents checkMarzo As System.Windows.Forms.CheckBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtMontoTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtComprobante As System.Windows.Forms.TextBox
    Friend WithEvents btnPagar As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtPorcentaje As System.Windows.Forms.TextBox
    Friend WithEvents txtTipoPago As System.Windows.Forms.TextBox
    Friend WithEvents txtBeca As System.Windows.Forms.TextBox
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents txtCampoRut As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnDeshacerPago As System.Windows.Forms.Button
End Class
