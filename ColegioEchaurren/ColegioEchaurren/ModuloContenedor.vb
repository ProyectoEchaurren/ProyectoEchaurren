Imports MySql.Data.MySqlClient

Module ModuloContenedor
    Public varTotal As Integer

    Public Function ComprobarRut(ByVal ElNumero As String) As Boolean
        Dim resultado As String
        Dim Multiplicador As Integer
        Dim iNum As Integer
        Dim Suma As Integer
        Dim I As Integer
        Dim Final() As String
        Dim cad(15) As String

        resultado = 0
        Multiplicador = 2
        iNum = 0
        Suma = 0

        ElNumero = Replace(ElNumero, ".", "")

        If ElNumero.Length = 10 Or ElNumero.Length = 9 Then
            For I = (Len(ElNumero)) - 2 To 1 Step -1
                iNum = Mid(ElNumero, I, 1)
                Suma = Suma + iNum * Multiplicador
                Multiplicador = Multiplicador + 1
                If Multiplicador = 8 Then Multiplicador = 2
            Next

            resultado = CStr(11 - (Suma Mod 11))

            If resultado = "10" Then resultado = "K"
            If resultado = "11" Then resultado = "0"
            Final = Split(ElNumero, "-")
            If Final(1) = Right(resultado, 1) Then
                ComprobarRut = True
            Else
                ComprobarRut = False
            End If
        Else
            ComprobarRut = False
        End If
    End Function


    Public Function ingresarAlumno(ByRef fechaMatricula As DateTimePicker, ByRef apellidoPatAlumno As String, _
                              ByRef apellidoMatAlumno As String, ByRef nombresAlumno As String, ByRef RunAlumno As String, _
                              ByRef SexoAlumno As String, ByRef fechaNacimientoAlumno As DateTimePicker, ByRef EdadAlumno As String, _
                              ByRef domicilioCalleAlumn As String, ByRef sectorAlumno As String, ByRef curso As String, _
                              ByRef comunaAlumno As String, ByRef telefAlumno As String, ByRef colegioPresedencia As String, _
                              ByRef cursosRepe As String, ByRef becado As String, _
                              ByRef hermanosEstable As String, ByRef alumnoViveCon As String, ByRef numHijosFam As String, _
                              ByRef lugarocupaHijos As String, ByRef grupoFamiliarCompo As String, _
                              ByRef antecedentesMedicos As String) As Boolean


        Try
            Dim consultaFichaAlumno As String = "INSERT INTO `bd_echaurren`.`fichaalumno` (`ColegioPresedencia`, `CursosRepetidos`, `Becado`, `HermanosEstablecimiento`, `AlumnoViveCon`, `NumHijosFamilia`, `LugarOcupacionHijos`, `GrupoFamiliarComponen`, `AntecedentesMedicos`) VALUES ('" & colegioPresedencia & "', '" & cursosRepe & "', '" & becado & "', '" & hermanosEstable & "', '" & alumnoViveCon & "', '" & numHijosFam & "', '" & lugarocupaHijos & "', '" & grupoFamiliarCompo & "', '" & antecedentesMedicos & "');"
            Dim comando0 As New MySqlCommand(consultaFichaAlumno, FormularioMatricula.varConexion)
            comando0.ExecuteNonQuery()
            Dim consultaIngresoAlumn As String = "INSERT INTO `bd_echaurren`.`alumno` (`RutAlumno`, `NombreCompleto`, `ApePaterno`, `ApeMaterno`, `Sexo`, `FechaNac`, `Edad`, `Domicilio`, `SectorVilla`, `Telefono`, `Curso_idCurso`, `Comuna_idComuna`, `Fichaalumno_idFichaalumno`, `Matricula_NumMatricula`) VALUES ('" & RunAlumno & "', '" & nombresAlumno & "', '" & apellidoPatAlumno & "', '" & apellidoMatAlumno & "', '" & SexoAlumno & "', '" & fechaNacimientoAlumno.Value.ToString("dd/MM/yyyy") & "', '" & EdadAlumno & "', '" & domicilioCalleAlumn & "', '" & sectorAlumno & "', '" & telefAlumno & "', '" & curso & "', '" & comunaAlumno & "', last_insert_id(), '0121134');"
            Dim _comando As New MySqlCommand(consultaIngresoAlumn, FormularioMatricula.varConexion)
            _comando.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function


    Public Function ingresarServSalud(ByRef servicioSalud As String, ByRef otroServicio As String, ByRef seguros As String) As Boolean

        Try
            Dim consultaServSalud As String = "INSERT INTO `bd_echaurren`.`servicio_por_alumno` (`Alumno_RutAlumno`, `Servicio_salud_idServicio_salud`, `Seguros`, `OtrosServicios`) VALUES ('" & FormularioMatricula.txtRutAlumno.Text & "', '" & servicioSalud & "', '" & seguros & "', '" & otroServicio & "');"
            Dim _comando1 As New MySqlCommand(consultaServSalud, FormularioMatricula.varConexion)
            _comando1.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function RegistrarMensualidades(ByRef rut As String, ByRef mes As String, ByRef tipopago As ComboBox, ByRef monto As Integer, ByRef fechavenc As String, ByRef documento As String)
        Dim varConn As MySqlConnection
        Dim varConnString = "server=localhost;User Id=root;password=123456;database=bd_echaurren"
        Dim consulta As String = ""

        Try
            varConn = New MySqlConnection
            varConn.ConnectionString = varConnString
            varConn.Open()
        Catch ex As Exception
            MessageBox.Show("Error al conectar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Try
            If FormularioMatricula.cbbTipoPago.SelectedItem = "Contado" Then
                consulta = "INSERT INTO `bd_echaurren`.`mensualidad` (`RutAlumno`, `NombreMes`, `TipoPago`, `Monto`, `FechaPago`, `Estado`, `NumDocumento`) VALUES ('" & rut & "', '" & mes & "', '" & tipopago.Text & "', '" & monto & "', '" & fechavenc & "', 'PAGADO', '" & documento & "');"
            ElseIf FormularioMatricula.cbbTipoPago.SelectedItem = "Cheque" Or FormularioMatricula.cbbTipoPago.SelectedItem = "Cuponera" Then
                consulta = "INSERT INTO `bd_echaurren`.`mensualidad` (`RutAlumno`, `NombreMes`, `TipoPago`, `Monto`, `FechaPago`, `Estado`, `NumDocumento`) VALUES ('" & rut & "', '" & mes & "', '" & tipopago.Text & "', '" & monto & "', '" & fechavenc & "', 'NO PAGADO', '" & documento & "');"
            End If

            Dim comando As New MySqlCommand(consulta, varConn)
            comando.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show("Error al registrar mensualidades.")
        End Try
    End Function

    Public Function variableTotalMeses(ByRef rut As String) As String
        Dim conn As New MySqlConnection("server=localhost;User Id=root;password=123456;database=bd_echaurren")
        Dim adapter As New MySqlDataAdapter()
        Dim dataSet As New DataSet

        adapter.SelectCommand = New MySqlCommand("SELECT count(*) as total from mensualidad where RutAlumno = '" & rut & "'", conn)
        adapter.Fill(dataSet)

        varTotal = dataSet.Tables(0).Rows("0")("total").ToString()
        Return varTotal

    End Function

    Public Function BuscarRutRealizarPago(ByRef rut As String, ByRef total As Integer) As Boolean
        Dim conn As New MySqlConnection("server=localhost;User Id=root;password=123456;database=bd_echaurren")
        Dim adapter As New MySqlDataAdapter()
        Dim dataSet As New DataSet

        Try

            adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Becado, TipoPago, PorcentajeBeca, Monto, NombreMes, Estado FROM Alumno inner join Mensualidad ON Alumno.RutAlumno = mensualidad.RutAlumno inner join fichaalumno ON alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno WHERE Alumno.RutAlumno = '" & rut & "'", conn)
            adapter.Fill(dataSet)

            RealizarPago.txtNombre.Text = dataSet.Tables(0).Rows("0")("NombreCompleto").ToString & " " & dataSet.Tables(0).Rows("0")("ApePaterno").ToString & " " & dataSet.Tables(0).Rows("0")("ApeMaterno").ToString
            If dataSet.Tables(0).Rows("0")("Becado").ToString = True Then
                RealizarPago.txtBeca.Text = "Becado"
            Else
                RealizarPago.txtBeca.Text = "No Becado"
            End If
            RealizarPago.txtTipoPago.Text = dataSet.Tables(0).Rows("0")("TipoPago").ToString
            RealizarPago.txtPorcentaje.Text = dataSet.Tables(0).Rows("0")("PorcentajeBeca").ToString
            RealizarPago.txtMontoMensual.Text = dataSet.Tables(0).Rows("0")("Monto").ToString
            RealizarPago.checkMarzo.Enabled = True
            RealizarPago.checkAbril.Enabled = True
            RealizarPago.checkMayo.Enabled = True
            RealizarPago.checkJunio.Enabled = True
            RealizarPago.checkJulio.Enabled = True
            RealizarPago.checkAgosto.Enabled = True
            RealizarPago.checkSept.Enabled = True
            RealizarPago.checkOctubre.Enabled = True
            RealizarPago.checkNov.Enabled = True
            RealizarPago.checkDic.Enabled = True

            total = total - 1

            For i = 0 To total
                If dataSet.Tables(0).Rows(i)("NombreMes").ToString = "Marzo" And dataSet.Tables(0).Rows(i)("Estado").ToString = "PAGADO" Then
                    RealizarPago.checkMarzo.Enabled = False
                ElseIf dataSet.Tables(0).Rows(i)("NombreMes").ToString = "Abril" And dataSet.Tables(0).Rows(i)("Estado").ToString = "PAGADO" Then
                    RealizarPago.checkAbril.Enabled = False
                ElseIf dataSet.Tables(0).Rows(i)("NombreMes").ToString = "Mayo" And dataSet.Tables(0).Rows(i)("Estado").ToString = "PAGADO" Then
                    RealizarPago.checkMayo.Enabled = False
                ElseIf dataSet.Tables(0).Rows(i)("NombreMes").ToString = "Junio" And dataSet.Tables(0).Rows(i)("Estado").ToString = "PAGADO" Then
                    RealizarPago.checkJunio.Enabled = False
                ElseIf dataSet.Tables(0).Rows(i)("NombreMes").ToString = "Julio" And dataSet.Tables(0).Rows(i)("Estado").ToString = "PAGADO" Then
                    RealizarPago.checkJulio.Enabled = False
                ElseIf dataSet.Tables(0).Rows(i)("NombreMes").ToString = "Agosto" And dataSet.Tables(0).Rows(i)("Estado").ToString = "PAGADO" Then
                    RealizarPago.checkAgosto.Enabled = False
                ElseIf dataSet.Tables(0).Rows(i)("NombreMes").ToString = "Septiembre" And dataSet.Tables(0).Rows(i)("Estado").ToString = "PAGADO" Then
                    RealizarPago.checkSept.Enabled = False
                ElseIf dataSet.Tables(0).Rows(i)("NombreMes").ToString = "Octubre" And dataSet.Tables(0).Rows(i)("Estado").ToString = "PAGADO" Then
                    RealizarPago.checkOctubre.Enabled = False
                ElseIf dataSet.Tables(0).Rows(i)("NombreMes").ToString = "Noviembre" And dataSet.Tables(0).Rows(i)("Estado").ToString = "PAGADO" Then
                    RealizarPago.checkNov.Enabled = False
                ElseIf dataSet.Tables(0).Rows(i)("NombreMes").ToString = "Diciembre" And dataSet.Tables(0).Rows(i)("Estado").ToString = "PAGADO" Then
                    RealizarPago.checkDic.Enabled = False
                Else
                    Continue For
                End If
            Next i

        Catch ex As Exception
            MessageBox.Show("Alumno No Encontrado", "Error")
        End Try

    End Function

    Public Function BuscarRutBecas(ByRef rut As String) As Boolean
        Dim conn As New MySqlConnection("server=localhost;User Id=root;password=123456;database=bd_echaurren")
        Dim adapter As New MySqlDataAdapter()
        Dim dataSet As New DataSet
        Try
            adapter.SelectCommand = New MySqlCommand("SELECT idFichaalumno, NombreCompleto, ApePaterno, ApeMaterno, Becado, PorcentajeBeca FROM Alumno inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno WHERE Alumno.RutAlumno = '" & rut & "'", conn)
            adapter.Fill(dataSet)
            AdminBecas.txtNombre.Text = dataSet.Tables(0).Rows("0")("NombreCompleto").ToString & " " & dataSet.Tables(0).Rows("0")("ApePaterno").ToString & " " & dataSet.Tables(0).Rows("0")("ApeMaterno").ToString
            If dataSet.Tables(0).Rows("0")("Becado").ToString = True Then
                AdminBecas.txtBeca.Text = "Becado"
            Else
                AdminBecas.txtBeca.Text = "No Becado"
            End If
            AdminBecas.txtPorcentaje.Text = dataSet.Tables(0).Rows("0")("PorcentajeBeca").ToString
            AdminBecas.cbbNewBeca.Enabled = True
            AdminBecas.cbbNewPorcentaje.Enabled = True
            AdminBecas.btnDeshacer.Enabled = True
            AdminBecas.btnGuardar.Enabled = True
            AdminBecas.varIdFicha = dataSet.Tables(0).Rows("0")("idFichaalumno").ToString
            AdminBecas.varOldBeca = AdminBecas.txtBeca.Text
            AdminBecas.varOldPorcentaje = AdminBecas.txtPorcentaje.Text
        Catch ex As Exception
            MessageBox.Show("Alumno No Encontrado", "Error")
        End Try

    End Function

    Public Function GuardarCambiosBecas(ByRef newbeca As String, ByRef newporcentaje As Integer, ByRef idficha As Integer) As Boolean
        Dim varConn As MySqlConnection
        Dim varConnString = "server=localhost;User Id=root;password=123456;database=bd_echaurren"
        Dim consulta As String = ""

        Try
            varConn = New MySqlConnection
            varConn.ConnectionString = varConnString
            varConn.Open()
        Catch ex As Exception
            MessageBox.Show("Error al conectar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Try
            If newbeca = "Becado" Then
                consulta = "UPDATE `bd_echaurren`.`fichaalumno` SET `Becado`='1', `PorcentajeBeca`='" & newporcentaje & "' WHERE `idFichaalumno`='" & idficha & "';"
            ElseIf newbeca = "No Becado" Then
                consulta = "UPDATE `bd_echaurren`.`fichaalumno` SET `Becado`='0', `PorcentajeBeca`='0' WHERE `idFichaalumno`='" & idficha & "';"
            Else
                consulta = "UPDATE `bd_echaurren`.`fichaalumno` SET `Becado`='" & newbeca & "', `PorcentajeBeca`='" & newporcentaje & "' WHERE `idFichaalumno`='" & idficha & "';"
            End If

            Dim comando As New MySqlCommand(consulta, varConn)
            comando.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            MessageBox.Show("Error al guardar los cambios.")
            Return False
        End Try

    End Function

    Public Function PagarMensualidad(ByRef comprobante As String, ByRef mes As String, ByRef rut As String) As Boolean
        Dim varConn As MySqlConnection
        Dim varConnString = "server=localhost;User Id=root;password=123456;database=bd_echaurren"
        Dim consulta As String = ""

        Try
            varConn = New MySqlConnection
            varConn.ConnectionString = varConnString
            varConn.Open()
        Catch ex As Exception
            MessageBox.Show("Error al conectar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Try
            consulta = "UPDATE `bd_echaurren`.`mensualidad` SET `Estado`='PAGADO', `NumComprobante`='" & comprobante & "' WHERE `NombreMes`='" & mes & "' and RutAlumno = '" & rut & "';"
            Dim comando As New MySqlCommand(consulta, varConn)
            comando.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            MessageBox.Show("Error al registrar el pago.")
            Return False
        End Try


    End Function

    Public Function CargarHistorico(ByRef dgv As DataGridView, ByRef rut As String)
        Dim conn As New MySqlConnection("server=localhost;User Id=root;password=123456;database=bd_echaurren")
        Dim adapter As New MySqlDataAdapter()
        Dim dataSet As New DataSet
        adapter.SelectCommand = New MySqlCommand("SELECT alumno.RutAlumno, NombreCompleto, ApePaterno, Curso, Becado, PorcentajeBeca, NombreMes, Monto, TipoPago, Estado from Alumno inner join Mensualidad on alumno.RutAlumno = mensualidad.RutAlumno inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso WHERE Alumno.RutAlumno = '" & rut & "'", conn)
        adapter.Fill(dataSet)
        dgv.DataSource = dataSet.Tables(0)

    End Function

    Public Function ComprobarFiltros(ByRef dgv As DataGridView, ByRef curso As ComboBox, ByRef porcentaje As ComboBox)
        Dim conn As New MySqlConnection("server=localhost;User Id=root;password=123456;database=bd_echaurren")
        Dim adapter As New MySqlDataAdapter()
        Dim dataSet As New DataSet

        If AdminMensualidades.cbFiltroCurso.Text <> "" Then
            If AdminMensualidades.CheckBecado.Checked = True Then
                If AdminMensualidades.cbPorcentaje.Text <> "" Then
                    If AdminMensualidades.CheckPagado.Checked = True Then
                        adapter.SelectCommand = New MySqlCommand("SELECT alumno.RutAlumno, NombreCompleto, ApePaterno, Curso, Becado, PorcentajeBeca, NombreMes, Monto, TipoPago, Estado from Alumno inner join Mensualidad on alumno.RutAlumno = mensualidad.RutAlumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno WHERE Becado = 0 and Estado = 'Pagado' and Curso = '" & curso.Text & "' and PorcentajeBeca = '" & porcentaje.Text & "'", conn)
                    ElseIf AdminMensualidades.CheckAtrasado.Checked = True Then
                        adapter.SelectCommand = New MySqlCommand("SELECT alumno.RutAlumno, NombreCompleto, ApePaterno, Curso, Becado, PorcentajeBeca, NombreMes, Monto, TipoPago, Estado from Alumno inner join Mensualidad on alumno.RutAlumno = mensualidad.RutAlumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno WHERE Becado = 0 and Estado = 'Atrasado' and Curso = '" & curso.Text & "' and PorcentajeBeca = '" & porcentaje.Text & "'", conn)
                    Else
                        adapter.SelectCommand = New MySqlCommand("SELECT alumno.RutAlumno, NombreCompleto, ApePaterno, Curso, Becado, PorcentajeBeca, NombreMes, Monto, TipoPago, Estado from Alumno inner join Mensualidad on alumno.RutAlumno = mensualidad.RutAlumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno WHERE Becado = 0 and Curso = '" & curso.Text & "' and PorcentajeBeca = '" & porcentaje.Text & "'", conn)
                    End If
                Else
                    If AdminMensualidades.CheckPagado.Checked = True Then
                        adapter.SelectCommand = New MySqlCommand("SELECT alumno.RutAlumno, NombreCompleto, ApePaterno, Curso, Becado, PorcentajeBeca, NombreMes, Monto, TipoPago, Estado from Alumno inner join Mensualidad on alumno.RutAlumno = mensualidad.RutAlumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno WHERE Becado = 0 and Estado = 'Pagado' and Curso = '" & curso.Text & "'", conn)
                    ElseIf AdminMensualidades.CheckAtrasado.Checked = True Then
                        adapter.SelectCommand = New MySqlCommand("SELECT alumno.RutAlumno, NombreCompleto, ApePaterno, Curso, Becado, PorcentajeBeca, NombreMes, Monto, TipoPago, Estado from Alumno inner join Mensualidad on alumno.RutAlumno = mensualidad.RutAlumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno WHERE Becado = 0 and Estado = 'Atrasado' and Curso = '" & curso.Text & "'", conn)
                    Else
                        adapter.SelectCommand = New MySqlCommand("SELECT alumno.RutAlumno, NombreCompleto, ApePaterno, Curso, Becado, PorcentajeBeca, NombreMes, Monto, TipoPago, Estado from Alumno inner join Mensualidad on alumno.RutAlumno = mensualidad.RutAlumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno WHERE Becado = 0 and Curso = '" & curso.Text & "'", conn)
                    End If
                End If
            ElseIf AdminMensualidades.CheckNoBecado.Checked = True Then
                If AdminMensualidades.CheckPagado.Checked = True Then
                    adapter.SelectCommand = New MySqlCommand("SELECT alumno.RutAlumno, NombreCompleto, ApePaterno, Curso, Becado, PorcentajeBeca, NombreMes, Monto, TipoPago, Estado from Alumno inner join Mensualidad on alumno.RutAlumno = mensualidad.RutAlumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno WHERE Becado = 1 and Estado = 'Pagado' and Curso = '" & curso.Text & "'", conn)
                ElseIf AdminMensualidades.CheckAtrasado.Checked = True Then
                    adapter.SelectCommand = New MySqlCommand("SELECT alumno.RutAlumno, NombreCompleto, ApePaterno, Curso, Becado, PorcentajeBeca, NombreMes, Monto, TipoPago, Estado from Alumno inner join Mensualidad on alumno.RutAlumno = mensualidad.RutAlumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno WHERE Becado = 1 and Estado = 'Atrasado' and Curso = '" & curso.Text & "'", conn)
                Else
                    adapter.SelectCommand = New MySqlCommand("SELECT alumno.RutAlumno, NombreCompleto, ApePaterno, Curso, Becado, PorcentajeBeca, NombreMes, Monto, TipoPago, Estado from Alumno inner join Mensualidad on alumno.RutAlumno = mensualidad.RutAlumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno WHERE Becado = 1 and Curso ='" & curso.Text & "'", conn)
                End If
            ElseIf AdminMensualidades.CheckPagado.Checked = True Then
                adapter.SelectCommand = New MySqlCommand("SELECT alumno.RutAlumno, NombreCompleto, ApePaterno, Curso, Becado, PorcentajeBeca, NombreMes, Monto, TipoPago, Estado from Alumno inner join Mensualidad on alumno.RutAlumno = mensualidad.RutAlumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno WHERE Estado = 'Pagado' and Curso = '" & curso.Text & "'", conn)
            ElseIf AdminMensualidades.CheckAtrasado.Checked = True Then
                adapter.SelectCommand = New MySqlCommand("SELECT alumno.RutAlumno, NombreCompleto, ApePaterno, Curso, Becado, PorcentajeBeca, NombreMes, Monto, TipoPago, Estado from Alumno inner join Mensualidad on alumno.RutAlumno = mensualidad.RutAlumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno WHERE Estado = 'Atrasado' and Curso = '" & curso.Text & "'", conn)
            Else
                adapter.SelectCommand = New MySqlCommand("SELECT alumno.RutAlumno, NombreCompleto, ApePaterno, Curso, Becado, PorcentajeBeca, NombreMes, Monto, TipoPago, Estado from Alumno inner join Mensualidad on alumno.RutAlumno = mensualidad.RutAlumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno WHERE Curso = '" & curso.Text & "'", conn)
            End If
        ElseIf AdminMensualidades.CheckBecado.Checked = True Then
            If AdminMensualidades.cbPorcentaje.Text <> "" Then
                If AdminMensualidades.CheckPagado.Checked = True Then
                    adapter.SelectCommand = New MySqlCommand("SELECT alumno.RutAlumno, NombreCompleto, ApePaterno, Curso, Becado, PorcentajeBeca, NombreMes, Monto, TipoPago, Estado from Alumno inner join Mensualidad on alumno.RutAlumno = mensualidad.RutAlumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno WHERE Becado = 0 and Estado = 'Pagado' and PorcentajeBeca = '" & porcentaje.Text & "'", conn)
                ElseIf AdminMensualidades.CheckAtrasado.Checked = True Then
                    adapter.SelectCommand = New MySqlCommand("SELECT alumno.RutAlumno, NombreCompleto, ApePaterno, Curso, Becado, PorcentajeBeca, NombreMes, Monto, TipoPago, Estado from Alumno inner join Mensualidad on alumno.RutAlumno = mensualidad.RutAlumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno WHERE Becado = 0 and Estado = 'Atrasado' and PorcentajeBeca = '" & porcentaje.Text & "'", conn)
                Else
                    adapter.SelectCommand = New MySqlCommand("SELECT alumno.RutAlumno, NombreCompleto, ApePaterno, Curso, Becado, PorcentajeBeca, NombreMes, Monto, TipoPago, Estado from Alumno inner join Mensualidad on alumno.RutAlumno = mensualidad.RutAlumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno WHERE Becado = 0 and PorcentajeBeca = '" & porcentaje.Text & "'", conn)
                End If
            Else
                If AdminMensualidades.CheckPagado.Checked = True Then
                    adapter.SelectCommand = New MySqlCommand("SELECT alumno.RutAlumno, NombreCompleto, ApePaterno, Curso, Becado, PorcentajeBeca, NombreMes, Monto, TipoPago, Estado from Alumno inner join Mensualidad on alumno.RutAlumno = mensualidad.RutAlumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno WHERE Becado = 0 and Estado = 'Pagado'", conn)
                ElseIf AdminMensualidades.CheckAtrasado.Checked = True Then
                    adapter.SelectCommand = New MySqlCommand("SELECT alumno.RutAlumno, NombreCompleto, ApePaterno, Curso, Becado, PorcentajeBeca, NombreMes, Monto, TipoPago, Estado from Alumno inner join Mensualidad on alumno.RutAlumno = mensualidad.RutAlumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno WHERE Becado = 0 and Estado = 'Atrasado'", conn)
                Else
                    adapter.SelectCommand = New MySqlCommand("SELECT alumno.RutAlumno, NombreCompleto, ApePaterno, Curso, Becado, PorcentajeBeca, NombreMes, Monto, TipoPago, Estado from Alumno inner join Mensualidad on alumno.RutAlumno = mensualidad.RutAlumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno WHERE Becado = 0", conn)
                End If
            End If
        ElseIf AdminMensualidades.CheckNoBecado.Checked = True Then
            If AdminMensualidades.CheckPagado.Checked = True Then
                adapter.SelectCommand = New MySqlCommand("SELECT alumno.RutAlumno, NombreCompleto, ApePaterno, Curso, Becado, PorcentajeBeca, NombreMes, Monto, TipoPago, Estado from Alumno inner join Mensualidad on alumno.RutAlumno = mensualidad.RutAlumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno WHERE Becado = 1 and Estado = 'Pagado'", conn)
            ElseIf AdminMensualidades.CheckAtrasado.Checked = True Then
                adapter.SelectCommand = New MySqlCommand("SELECT alumno.RutAlumno, NombreCompleto, ApePaterno, Curso, Becado, PorcentajeBeca, NombreMes, Monto, TipoPago, Estado from Alumno inner join Mensualidad on alumno.RutAlumno = mensualidad.RutAlumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno WHERE Becado = 1 and Estado = 'Atrasado'", conn)
            Else
                adapter.SelectCommand = New MySqlCommand("SELECT alumno.RutAlumno, NombreCompleto, ApePaterno, Curso, Becado, PorcentajeBeca, NombreMes, Monto, TipoPago, Estado from Alumno inner join Mensualidad on alumno.RutAlumno = mensualidad.RutAlumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno WHERE Becado = 1", conn)
            End If
        ElseIf AdminMensualidades.CheckPagado.Checked = True Then
            adapter.SelectCommand = New MySqlCommand("SELECT alumno.RutAlumno, NombreCompleto, ApePaterno, Curso, Becado, PorcentajeBeca, NombreMes, Monto, TipoPago, Estado from Alumno inner join Mensualidad on alumno.RutAlumno = mensualidad.RutAlumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno WHERE Estado = 'Pagado'", conn)
        ElseIf AdminMensualidades.CheckAtrasado.Checked = True Then
            adapter.SelectCommand = New MySqlCommand("SELECT alumno.RutAlumno, NombreCompleto, ApePaterno, Curso, Becado, PorcentajeBeca, NombreMes, Monto, TipoPago, Estado from Alumno inner join Mensualidad on alumno.RutAlumno = mensualidad.RutAlumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno WHERE Estado = 'Atrasado'", conn)
        Else
            adapter.SelectCommand = New MySqlCommand("SELECT alumno.RutAlumno, NombreCompleto, ApePaterno, Curso, Becado, PorcentajeBeca, NombreMes, Monto, TipoPago, Estado from Alumno inner join Mensualidad on alumno.RutAlumno = mensualidad.RutAlumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno", conn)
        End If

        adapter.Fill(dataSet)
        dgv.DataSource = dataSet.Tables(0)
    End Function

    Public Function FiltrosAdminAlumnos(ByRef dgv As DataGridView, ByRef rut As String, ByRef nombre As String, ByRef apellido As String, ByRef edad As String, ByRef curso As ComboBox, ByRef salud As ComboBox, ByRef porcentaje As ComboBox)
        Dim conn As New MySqlConnection("server=localhost;User Id=root;password=123456;database=bd_echaurren")
        Dim adapter As New MySqlDataAdapter()
        Dim dataSet As New DataSet

        If FormAlumnosMatriculados.txtRutAlumno.Text <> "" Then
            If FormAlumnosMatriculados.txtNombre.Text <> "" Then
                If FormAlumnosMatriculados.txtApePaterno.Text <> "" Then
                    If FormAlumnosMatriculados.txtEdad.Text <> "" Then
                        If FormAlumnosMatriculados.cbbCurso.Text <> "" Then
                            If FormAlumnosMatriculados.cbBuscarServSalud.Text <> "" Then
                                If FormAlumnosMatriculados.cbBecados.Checked = True Then
                                    If FormAlumnosMatriculados.cbbPorcentaje.Text <> "" Then
                                        adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE RutAlumno = '" & rut & "' and NombreCompleto = '" & nombre & "' and ApePaterno = '" & apellido & "' and Edad = '" & edad & "' and PlanSalud = '" & salud.Text & "' and PorcentajeBeca = '" & porcentaje.Text & "' and Curso = '" & curso.Text & "' and Becado = 1 ", conn)
                                    Else
                                        adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE RutAlumno = '" & rut & "' and NombreCompleto = '" & nombre & "' and ApePaterno = '" & apellido & "' and Edad = '" & edad & "' and PlanSalud = '" & salud.Text & "' and Curso = '" & curso.Text & "' and Becado = 1 ", conn)
                                    End If
                                ElseIf FormAlumnosMatriculados.cbNoBecados.Checked = True Then
                                    adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE RutAlumno = '" & rut & "' and NombreCompleto = '" & nombre & "' and ApePaterno = '" & apellido & "' and Edad = '" & edad & "' and PlanSalud = '" & salud.Text & "' and Curso = '" & curso.Text & "' and Becado = 0 ", conn)
                                Else
                                    adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE RutAlumno = '" & rut & "' and NombreCompleto = '" & nombre & "' and ApePaterno = '" & apellido & "' and Edad = '" & edad & "' and PlanSalud = '" & salud.Text & "' and Curso = '" & curso.Text & "'", conn)
                                End If
                            ElseIf FormAlumnosMatriculados.cbBecados.Checked = True Then
                                If FormAlumnosMatriculados.cbbPorcentaje.Text <> "" Then
                                    adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE RutAlumno = '" & rut & "' and NombreCompleto = '" & nombre & "' and ApePaterno = '" & apellido & "' and Edad = '" & edad & "' and PorcentajeBeca = '" & porcentaje.Text & "' and Curso = '" & curso.Text & "' and Becado = 1 ", conn)
                                Else
                                    adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE RutAlumno = '" & rut & "' and NombreCompleto = '" & nombre & "' and ApePaterno = '" & apellido & "' and Edad = '" & edad & "' and Curso = '" & curso.Text & "' and Becado = 1 ", conn)
                                End If
                            ElseIf FormAlumnosMatriculados.cbNoBecados.Checked = True Then
                                adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE RutAlumno = '" & rut & "' and NombreCompleto = '" & nombre & "' and ApePaterno = '" & apellido & "' and Edad = '" & edad & "' and Curso = '" & curso.Text & "' and Becado = 0 ", conn)
                            Else
                                adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE RutAlumno = '" & rut & "' and NombreCompleto = '" & nombre & "' and ApePaterno = '" & apellido & "' and Edad = '" & edad & "' and Curso = '" & curso.Text & "'", conn)
                            End If
                        ElseIf FormAlumnosMatriculados.cbBuscarServSalud.Text <> "" Then
                            If FormAlumnosMatriculados.cbBecados.Checked = True Then
                                If FormAlumnosMatriculados.cbbPorcentaje.Text <> "" Then
                                    adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE RutAlumno = '" & rut & "' and NombreCompleto = '" & nombre & "' and ApePaterno = '" & apellido & "' and Edad = '" & edad & "' and PlanSalud = '" & salud.Text & "' and PorcentajeBeca = '" & porcentaje.Text & "' and Becado = 1 ", conn)
                                Else
                                    adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE RutAlumno = '" & rut & "' and NombreCompleto = '" & nombre & "' and ApePaterno = '" & apellido & "' and Edad = '" & edad & "' and PlanSalud = '" & salud.Text & "' and Becado = 1 ", conn)
                                End If
                            ElseIf FormAlumnosMatriculados.cbNoBecados.Checked = True Then
                                adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE RutAlumno = '" & rut & "' and NombreCompleto = '" & nombre & "' and ApePaterno = '" & apellido & "' and Edad = '" & edad & "' and PlanSalud = '" & salud.Text & "' and Becado = 0 ", conn)
                            Else
                                adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE RutAlumno = '" & rut & "' and NombreCompleto = '" & nombre & "' and ApePaterno = '" & apellido & "' and Edad = '" & edad & "' and PlanSalud = '" & salud.Text & "'", conn)
                            End If
                        ElseIf FormAlumnosMatriculados.cbBecados.Checked = True Then
                            If FormAlumnosMatriculados.cbbPorcentaje.Text <> "" Then
                                adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE RutAlumno = '" & rut & "' and NombreCompleto = '" & nombre & "' and ApePaterno = '" & apellido & "' and Edad = '" & edad & "' and PorcentajeBeca = '" & porcentaje.Text & "' and Becado = 1 ", conn)
                            Else
                                adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE RutAlumno = '" & rut & "' and NombreCompleto = '" & nombre & "' and ApePaterno = '" & apellido & "' and Edad = '" & edad & "' and Becado = 1 ", conn)
                            End If
                        ElseIf FormAlumnosMatriculados.cbNoBecados.Checked = True Then
                            adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE RutAlumno = '" & rut & "' and NombreCompleto = '" & nombre & "' and ApePaterno = '" & apellido & "' and Edad = '" & edad & "' and Becado = 0 ", conn)
                        Else
                            adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE RutAlumno = '" & rut & "' and NombreCompleto = '" & nombre & "' and ApePaterno = '" & apellido & "' and Edad = '" & edad & "'", conn)
                        End If
                    ElseIf FormAlumnosMatriculados.cbbCurso.Text <> "" Then
                        If FormAlumnosMatriculados.cbBuscarServSalud.Text <> "" Then
                            If FormAlumnosMatriculados.cbBecados.Checked = True Then
                                If FormAlumnosMatriculados.cbbPorcentaje.Text <> "" Then
                                    adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE RutAlumno = '" & rut & "' and NombreCompleto = '" & nombre & "' and ApePaterno = '" & apellido & "' and PlanSalud = '" & salud.Text & "' and PorcentajeBeca = '" & porcentaje.Text & "' and Curso = '" & curso.Text & "' and Becado = 1 ", conn)
                                Else
                                    adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE RutAlumno = '" & rut & "' and NombreCompleto = '" & nombre & "' and ApePaterno = '" & apellido & "' and PlanSalud = '" & salud.Text & "' and Curso = '" & curso.Text & "' and Becado = 1 ", conn)
                                End If
                            ElseIf FormAlumnosMatriculados.cbNoBecados.Checked = True Then
                                adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE RutAlumno = '" & rut & "' and NombreCompleto = '" & nombre & "' and ApePaterno = '" & apellido & "' and PlanSalud = '" & salud.Text & "' and Curso = '" & curso.Text & "' and Becado = 0 ", conn)
                            Else
                                adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE RutAlumno = '" & rut & "' and NombreCompleto = '" & nombre & "' and ApePaterno = '" & apellido & "' and PlanSalud = '" & salud.Text & "' and Curso = '" & curso.Text & "'", conn)
                            End If
                        End If
                    ElseIf FormAlumnosMatriculados.cbBuscarServSalud.Text <> "" Then
                        If FormAlumnosMatriculados.cbBecados.Checked = True Then
                            If FormAlumnosMatriculados.cbbPorcentaje.Text <> "" Then
                                adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE RutAlumno = '" & rut & "' and NombreCompleto = '" & nombre & "' and ApePaterno = '" & apellido & "' and PlanSalud = '" & salud.Text & "' and PorcentajeBeca = '" & porcentaje.Text & "' and Becado = 1 ", conn)
                            Else
                                adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE RutAlumno = '" & rut & "' and NombreCompleto = '" & nombre & "' and ApePaterno = '" & apellido & "' and PlanSalud = '" & salud.Text & "' and Becado = 1 ", conn)
                            End If
                        ElseIf FormAlumnosMatriculados.cbNoBecados.Checked = True Then
                            adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE RutAlumno = '" & rut & "' and NombreCompleto = '" & nombre & "' and ApePaterno = '" & apellido & "' and PlanSalud = '" & salud.Text & "' and Becado = 0 ", conn)
                        Else
                            adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE RutAlumno = '" & rut & "' and NombreCompleto = '" & nombre & "' and ApePaterno = '" & apellido & "' and PlanSalud = '" & salud.Text & "'", conn)
                        End If
                    ElseIf FormAlumnosMatriculados.cbBecados.Checked = True Then
                        If FormAlumnosMatriculados.cbbPorcentaje.Text <> "" Then
                            adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE RutAlumno = '" & rut & "' and NombreCompleto = '" & nombre & "' and ApePaterno = '" & apellido & "' and PorcentajeBeca = '" & porcentaje.Text & "' and Becado = 1 ", conn)
                        Else
                            adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE RutAlumno = '" & rut & "' and NombreCompleto = '" & nombre & "' and ApePaterno = '" & apellido & "' and Becado = 1 ", conn)
                        End If
                    ElseIf FormAlumnosMatriculados.cbNoBecados.Checked = True Then
                        adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE RutAlumno = '" & rut & "' and NombreCompleto = '" & nombre & "' and ApePaterno = '" & apellido & "' and Becado = 0 ", conn)
                    Else
                        adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE RutAlumno = '" & rut & "' and NombreCompleto = '" & nombre & "' and ApePaterno = '" & apellido & "'", conn)
                    End If
                ElseIf FormAlumnosMatriculados.txtEdad.Text <> "" Then
                    If FormAlumnosMatriculados.cbbCurso.Text <> "" Then
                        If FormAlumnosMatriculados.cbBuscarServSalud.Text <> "" Then
                            If FormAlumnosMatriculados.cbBecados.Checked = True Then
                                If FormAlumnosMatriculados.cbbPorcentaje.Text <> "" Then
                                    adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE RutAlumno = '" & rut & "' and NombreCompleto = '" & nombre & "' and Edad = '" & edad & "' and PlanSalud = '" & salud.Text & "' and PorcentajeBeca = '" & porcentaje.Text & "' and Curso = '" & curso.Text & "' and Becado = 1 ", conn)
                                Else
                                    adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE RutAlumno = '" & rut & "' and NombreCompleto = '" & nombre & "' and Edad = '" & edad & "' and PlanSalud = '" & salud.Text & "' and Curso = '" & curso.Text & "' and Becado = 1 ", conn)
                                End If
                            ElseIf FormAlumnosMatriculados.cbNoBecados.Checked = True Then
                                adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE RutAlumno = '" & rut & "' and NombreCompleto = '" & nombre & "' and Edad = '" & edad & "' and PlanSalud = '" & salud.Text & "' and Curso = '" & curso.Text & "' and Becado = 0 ", conn)
                            Else
                                adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE RutAlumno = '" & rut & "' and NombreCompleto = '" & nombre & "' and Edad = '" & edad & "' and PlanSalud = '" & salud.Text & "' and Curso = '" & curso.Text & "'", conn)
                            End If
                        End If
                    End If
                ElseIf FormAlumnosMatriculados.cbbCurso.Text <> "" Then
                    If FormAlumnosMatriculados.cbBuscarServSalud.Text <> "" Then
                        If FormAlumnosMatriculados.cbBecados.Checked = True Then
                            If FormAlumnosMatriculados.cbbPorcentaje.Text <> "" Then
                                adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE RutAlumno = '" & rut & "' and NombreCompleto = '" & nombre & "' and PlanSalud = '" & salud.Text & "' and PorcentajeBeca = '" & porcentaje.Text & "' and Curso = '" & curso.Text & "' and Becado = 1 ", conn)
                            Else
                                adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE RutAlumno = '" & rut & "' and NombreCompleto = '" & nombre & "' and PlanSalud = '" & salud.Text & "' and Curso = '" & curso.Text & "' and Becado = 1 ", conn)
                            End If
                        ElseIf FormAlumnosMatriculados.cbNoBecados.Checked = True Then
                            adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE RutAlumno = '" & rut & "' and NombreCompleto = '" & nombre & "' and PlanSalud = '" & salud.Text & "' and Curso = '" & curso.Text & "' and Becado = 0 ", conn)
                        Else
                            adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE RutAlumno = '" & rut & "' and NombreCompleto = '" & nombre & "' and PlanSalud = '" & salud.Text & "' and Curso = '" & curso.Text & "'", conn)
                        End If
                    End If
                ElseIf FormAlumnosMatriculados.cbBuscarServSalud.Text <> "" Then
                    If FormAlumnosMatriculados.cbBecados.Checked = True Then
                        If FormAlumnosMatriculados.cbbPorcentaje.Text <> "" Then
                            adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE RutAlumno = '" & rut & "' and NombreCompleto = '" & nombre & "' and PlanSalud = '" & salud.Text & "' and PorcentajeBeca = '" & porcentaje.Text & "' and Becado = 1 ", conn)
                        Else
                            adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE RutAlumno = '" & rut & "' and NombreCompleto = '" & nombre & "' and PlanSalud = '" & salud.Text & "' and Becado = 1 ", conn)
                        End If
                    ElseIf FormAlumnosMatriculados.cbNoBecados.Checked = True Then
                        adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE RutAlumno = '" & rut & "' and NombreCompleto = '" & nombre & "' and PlanSalud = '" & salud.Text & "' and Becado = 0 ", conn)
                    Else
                        adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE RutAlumno = '" & rut & "' and NombreCompleto = '" & nombre & "' and PlanSalud = '" & salud.Text & "'", conn)
                    End If
                ElseIf FormAlumnosMatriculados.cbBecados.Checked = True Then
                    If FormAlumnosMatriculados.cbbPorcentaje.Text <> "" Then
                        adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE RutAlumno = '" & rut & "' and NombreCompleto = '" & nombre & "' and PorcentajeBeca = '" & porcentaje.Text & "' and Becado = 1 ", conn)
                    Else
                        adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE RutAlumno = '" & rut & "' and NombreCompleto = '" & nombre & "' and Becado = 1 ", conn)
                    End If
                ElseIf FormAlumnosMatriculados.cbNoBecados.Checked = True Then
                    adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE RutAlumno = '" & rut & "' and NombreCompleto = '" & nombre & "' and Becado = 0 ", conn)
                Else
                    adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE RutAlumno = '" & rut & "' and NombreCompleto = '" & nombre & "'", conn)
                End If
            ElseIf FormAlumnosMatriculados.txtApePaterno.Text <> "" Then
                If FormAlumnosMatriculados.txtEdad.Text <> "" Then
                    If FormAlumnosMatriculados.cbbCurso.Text <> "" Then
                        If FormAlumnosMatriculados.cbBuscarServSalud.Text <> "" Then
                            If FormAlumnosMatriculados.cbBecados.Checked = True Then
                                If FormAlumnosMatriculados.cbbPorcentaje.Text <> "" Then
                                    adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE ApePaterno = '" & apellido & "' and Edad = '" & edad & "' and PlanSalud = '" & salud.Text & "' and PorcentajeBeca = '" & porcentaje.Text & "' and Curso = '" & curso.Text & "' and Becado = 1 ", conn)
                                Else
                                    adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE ApePaterno = '" & apellido & "' and Edad = '" & edad & "' and PlanSalud = '" & salud.Text & "' and Curso = '" & curso.Text & "' and Becado = 1 ", conn)
                                End If
                            ElseIf FormAlumnosMatriculados.cbNoBecados.Checked = True Then
                                adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE ApePaterno = '" & apellido & "' and Edad = '" & edad & "' and PlanSalud = '" & salud.Text & "' and Curso = '" & curso.Text & "' and Becado = 0 ", conn)
                            Else
                                adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE ApePaterno = '" & apellido & "' and Edad = '" & edad & "' and PlanSalud = '" & salud.Text & "' and Curso = '" & curso.Text & "'", conn)
                            End If
                        ElseIf FormAlumnosMatriculados.cbBecados.Checked = True Then
                            If FormAlumnosMatriculados.cbbPorcentaje.Text <> "" Then
                                adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE Becado = 1 and Edad = '" & edad & "' and PorcentajeBeca = '" & porcentaje.Text & "' and Curso = '" & curso.Text & "' and ApePaterno = '" & apellido & "'", conn)
                            Else
                                adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE Becado = 1 and Edad = '" & edad & "' and Curso = '" & curso.Text & "' and ApePaterno = '" & apellido & "'", conn)
                            End If
                        ElseIf FormAlumnosMatriculados.cbNoBecados.Checked = True Then
                            adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE Becado = 0 and Edad = '" & edad & "' and Curso = '" & curso.Text & "' and ApePaterno = '" & apellido & "'", conn)
                        Else
                            adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE Edad = '" & edad & "' and Curso = '" & curso.Text & "' and ApePaterno = '" & apellido & "'", conn)
                        End If
                    ElseIf FormAlumnosMatriculados.cbBecados.Checked = True Then
                        If FormAlumnosMatriculados.cbbPorcentaje.Text <> "" Then
                            adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE Becado = 1 and Edad = '" & edad & "' and PorcentajeBeca = '" & porcentaje.Text & "' and ApePaterno = '" & apellido & "'", conn)
                        Else
                            adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE Becado = 1 and Edad = '" & edad & "' and ApePaterno = '" & apellido & "'", conn)
                        End If
                    ElseIf FormAlumnosMatriculados.cbNoBecados.Checked = True Then
                        adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE Becado = 0 and Edad = '" & edad & "' and ApePaterno = '" & apellido & "'", conn)
                    Else
                        adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE Edad = '" & edad & "' and ApePaterno = '" & apellido & "'", conn)
                    End If
                ElseIf FormAlumnosMatriculados.cbBecados.Checked = True Then
                    If FormAlumnosMatriculados.cbbPorcentaje.Text <> "" Then
                        adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE Becado = 1 and PorcentajeBeca = '" & porcentaje.Text & "' and ApePaterno = '" & apellido & "'", conn)
                    Else
                        adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE Becado = 1 and ApePaterno = '" & apellido & "'", conn)
                    End If
                ElseIf FormAlumnosMatriculados.cbNoBecados.Checked = True Then
                    adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE Becado = 0 and ApePaterno = '" & apellido & "'", conn)
                Else
                    adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE ApePaterno = '" & apellido & "'", conn)
                End If
            ElseIf FormAlumnosMatriculados.txtEdad.Text <> "" Then
                If FormAlumnosMatriculados.cbbCurso.Text <> "" Then
                    If FormAlumnosMatriculados.cbBuscarServSalud.Text <> "" Then
                        If FormAlumnosMatriculados.cbBecados.Checked = True Then
                            If FormAlumnosMatriculados.cbbPorcentaje.Text <> "" Then
                                adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE RutAlumno = '" & rut & "' and Edad = '" & edad & "' and PlanSalud = '" & salud.Text & "' and PorcentajeBeca = '" & porcentaje.Text & "' and Curso = '" & curso.Text & "' and Becado = 1 ", conn)
                            Else
                                adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE RutAlumno = '" & rut & "' and Edad = '" & edad & "' and PlanSalud = '" & salud.Text & "' and Curso = '" & curso.Text & "' and Becado = 1 ", conn)
                            End If
                        ElseIf FormAlumnosMatriculados.cbNoBecados.Checked = True Then
                            adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE RutAlumno = '" & rut & "' and Edad = '" & edad & "' and PlanSalud = '" & salud.Text & "' and Curso = '" & curso.Text & "' and Becado = 0 ", conn)
                        Else
                            adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE RutAlumno = '" & rut & "' and Edad = '" & edad & "' and PlanSalud = '" & salud.Text & "' and Curso = '" & curso.Text & "'", conn)
                        End If
                    End If
                End If
            ElseIf FormAlumnosMatriculados.cbbCurso.Text <> "" Then
                If FormAlumnosMatriculados.cbBuscarServSalud.Text <> "" Then
                    If FormAlumnosMatriculados.cbBecados.Checked = True Then
                        If FormAlumnosMatriculados.cbbPorcentaje.Text <> "" Then
                            adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE RutAlumno = '" & rut & "' and PlanSalud = '" & salud.Text & "' and PorcentajeBeca = '" & porcentaje.Text & "' and Curso = '" & curso.Text & "' and Becado = 1 ", conn)
                        Else
                            adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE RutAlumno = '" & rut & "' and PlanSalud = '" & salud.Text & "' and Curso = '" & curso.Text & "' and Becado = 1 ", conn)
                        End If
                    ElseIf FormAlumnosMatriculados.cbNoBecados.Checked = True Then
                        adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE RutAlumno = '" & rut & "' and PlanSalud = '" & salud.Text & "' and Curso = '" & curso.Text & "' and Becado = 0 ", conn)
                    Else
                        adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE RutAlumno = '" & rut & "' and PlanSalud = '" & salud.Text & "' and Curso = '" & curso.Text & "'", conn)
                    End If
                End If
            ElseIf FormAlumnosMatriculados.cbBuscarServSalud.Text <> "" Then
                If FormAlumnosMatriculados.cbBecados.Checked = True Then
                    If FormAlumnosMatriculados.cbbPorcentaje.Text <> "" Then
                        adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE RutAlumno = '" & rut & "' and PlanSalud = '" & salud.Text & "' and PorcentajeBeca = '" & porcentaje.Text & "' and Becado = 1 ", conn)
                    Else
                        adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE RutAlumno = '" & rut & "' and PlanSalud = '" & salud.Text & "' and Becado = 1 ", conn)
                    End If
                ElseIf FormAlumnosMatriculados.cbNoBecados.Checked = True Then
                    adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE RutAlumno = '" & rut & "' and PlanSalud = '" & salud.Text & "' and Becado = 0 ", conn)
                Else
                    adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE RutAlumno = '" & rut & "' and PlanSalud = '" & salud.Text & "'", conn)
                End If
            ElseIf FormAlumnosMatriculados.cbBecados.Checked = True Then
                If FormAlumnosMatriculados.cbbPorcentaje.Text <> "" Then
                    adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE RutAlumno = '" & rut & "' and PorcentajeBeca = '" & porcentaje.Text & "' and Becado = 1 ", conn)
                Else
                    adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE RutAlumno = '" & rut & "' and Becado = 1 ", conn)
                End If
            ElseIf FormAlumnosMatriculados.cbNoBecados.Checked = True Then
                adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE RutAlumno = '" & rut & "' and Becado = 0 ", conn)
            Else
                adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE RutAlumno = '" & rut & "'", conn)
            End If
        ElseIf FormAlumnosMatriculados.txtNombre.Text <> "" Then
            If FormAlumnosMatriculados.txtApePaterno.Text <> "" Then
                If FormAlumnosMatriculados.txtEdad.Text <> "" Then
                    If FormAlumnosMatriculados.cbbCurso.Text <> "" Then
                        If FormAlumnosMatriculados.cbBuscarServSalud.Text <> "" Then
                            If FormAlumnosMatriculados.cbBecados.Checked = True Then
                                If FormAlumnosMatriculados.cbbPorcentaje.Text <> "" Then
                                    adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE NombreCompleto = '" & nombre & "' and ApePaterno = '" & apellido & "' and Edad = '" & edad & "' and PlanSalud = '" & salud.Text & "' and PorcentajeBeca = '" & porcentaje.Text & "' and Curso = '" & curso.Text & "' and Becado = 1 ", conn)
                                Else
                                    adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE NombreCompleto = '" & nombre & "' and ApePaterno = '" & apellido & "' and Edad = '" & edad & "' and PlanSalud = '" & salud.Text & "' and Curso = '" & curso.Text & "' and Becado = 1 ", conn)
                                End If
                            ElseIf FormAlumnosMatriculados.cbNoBecados.Checked = True Then
                                adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE NombreCompleto = '" & nombre & "' and ApePaterno = '" & apellido & "' and Edad = '" & edad & "' and PlanSalud = '" & salud.Text & "' and Curso = '" & curso.Text & "' and Becado = 0 ", conn)
                            Else
                                adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE NombreCompleto = '" & nombre & "' and ApePaterno = '" & apellido & "' and Edad = '" & edad & "' and PlanSalud = '" & salud.Text & "' and Curso = '" & curso.Text & "'", conn)
                            End If
                        ElseIf FormAlumnosMatriculados.cbBecados.Checked = True Then
                            If FormAlumnosMatriculados.cbbPorcentaje.Text <> "" Then
                                adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE NombreCompleto = '" & nombre & "' and ApePaterno = '" & apellido & "' and Edad = '" & edad & "' and PorcentajeBeca = '" & porcentaje.Text & "' and Curso = '" & curso.Text & "' and Becado = 1 ", conn)
                            Else
                                adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE NombreCompleto = '" & nombre & "' and ApePaterno = '" & apellido & "' and Edad = '" & edad & "' and Curso = '" & curso.Text & "' and Becado = 1 ", conn)
                            End If
                        ElseIf FormAlumnosMatriculados.cbNoBecados.Checked = True Then
                            adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE NombreCompleto = '" & nombre & "' and ApePaterno = '" & apellido & "' and Edad = '" & edad & "' and Curso = '" & curso.Text & "' and Becado = 0 ", conn)
                        Else
                            adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE NombreCompleto = '" & nombre & "' and ApePaterno = '" & apellido & "' and Edad = '" & edad & "' and Curso = '" & curso.Text & "'", conn)
                        End If
                    ElseIf FormAlumnosMatriculados.cbBecados.Checked = True Then
                        If FormAlumnosMatriculados.cbbPorcentaje.Text <> "" Then
                            adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE Becado = 1 and PorcentajeBeca = '" & porcentaje.Text & "' and NombreCompleto = '" & nombre & "' and ApePaterno = '" & apellido & "'", conn)
                        Else
                            adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE Becado = 1 and NombreCompleto = '" & nombre & "' and ApePaterno = '" & apellido & "'", conn)
                        End If
                    ElseIf FormAlumnosMatriculados.cbNoBecados.Checked = True Then
                        adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE Becado = 0 and NombreCompleto = '" & nombre & "' and ApePaterno = '" & apellido & "'", conn)
                    Else
                        adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE NombreCompleto = '" & nombre & "' and ApePaterno = '" & apellido & "' and Edad = '" & edad & "'", conn)
                    End If
                ElseIf FormAlumnosMatriculados.cbBecados.Checked = True Then
                    If FormAlumnosMatriculados.cbbPorcentaje.Text <> "" Then
                        adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE Becado = 1 and PorcentajeBeca = '" & porcentaje.Text & "' and NombreCompleto = '" & nombre & "' and ApePaterno = '" & apellido & "'", conn)
                    Else
                        adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE Becado = 1 and NombreCompleto = '" & nombre & "' and ApePaterno = '" & apellido & "'", conn)
                    End If
                ElseIf FormAlumnosMatriculados.cbNoBecados.Checked = True Then
                    adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE Becado = 0 and NombreCompleto = '" & nombre & "' and ApePaterno = '" & apellido & "'", conn)
                Else
                    adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE NombreCompleto = '" & nombre & "' and ApePaterno = '" & apellido & "'", conn)
                End If
            ElseIf FormAlumnosMatriculados.cbBecados.Checked = True Then
                If FormAlumnosMatriculados.cbbPorcentaje.Text <> "" Then
                    adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE Becado = 1 and PorcentajeBeca = '" & porcentaje.Text & "' and NombreCompleto = '" & nombre & "'", conn)
                Else
                    adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE Becado = 1 and NombreCompleto = '" & nombre & "'", conn)
                End If
            ElseIf FormAlumnosMatriculados.cbNoBecados.Checked = True Then
                adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE Becado = 0 and NombreCompleto = '" & nombre & "'", conn)
            Else
                adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE NombreCompleto = '" & nombre & "'", conn)
            End If
        ElseIf FormAlumnosMatriculados.txtApePaterno.Text <> "" Then
            If FormAlumnosMatriculados.txtEdad.Text <> "" Then
                If FormAlumnosMatriculados.cbbCurso.Text <> "" Then
                    If FormAlumnosMatriculados.cbBuscarServSalud.Text <> "" Then
                        If FormAlumnosMatriculados.cbBecados.Checked = True Then
                            If FormAlumnosMatriculados.cbbPorcentaje.Text <> "" Then
                                adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE Becado = 1 and Edad = '" & edad & "' and Curso = '" & curso.Text & "' and PorcentajeBeca = '" & porcentaje.Text & "' and PlanSalud = '" & salud.Text & "' and ApePaterno = '" & apellido & "'", conn)
                            Else
                                adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE Becado = 1 and Edad = '" & edad & "' and Curso = '" & curso.Text & "' and PlanSalud = '" & salud.Text & "' and ApePaterno = '" & apellido & "'", conn)
                            End If
                        ElseIf FormAlumnosMatriculados.cbNoBecados.Checked = True Then
                            adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE Becado = 0 and Edad = '" & edad & "' and Curso = '" & curso.Text & "' and PlanSalud = '" & salud.Text & "' and ApePaterno = '" & apellido & "'", conn)
                        Else
                            adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE Edad = '" & edad & "' and Curso = '" & curso.Text & "' and PlanSalud = '" & salud.Text & "' and ApePaterno = '" & apellido & "'", conn)
                        End If
                    ElseIf FormAlumnosMatriculados.cbBecados.Checked = True Then
                        If FormAlumnosMatriculados.cbbPorcentaje.Text <> "" Then
                            adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE Becado = 1 and Edad = '" & edad & "' and Curso = '" & curso.Text & "' and PorcentajeBeca = '" & porcentaje.Text & "' and ApePaterno = '" & apellido & "'", conn)
                        Else
                            adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE Becado = 1 and Edad = '" & edad & "' and Curso = '" & curso.Text & "' and ApePaterno = '" & apellido & "'", conn)
                        End If
                    ElseIf FormAlumnosMatriculados.cbNoBecados.Checked = True Then
                        adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE Becado = 0 and Edad = '" & edad & "' and Curso = '" & curso.Text & "' and ApePaterno = '" & apellido & "'", conn)
                    Else
                        adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE Edad = '" & edad & "' and Curso = '" & curso.Text & "' and ApePaterno = '" & apellido & "'", conn)
                    End If
                Else
                    adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE Edad = '" & edad & "' and ApePaterno = '" & apellido & "'", conn)
                End If
            ElseIf FormAlumnosMatriculados.cbBecados.Checked = True Then
                If FormAlumnosMatriculados.cbbPorcentaje.Text <> "" Then
                    adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE Becado = 1 and PorcentajeBeca = '" & porcentaje.Text & "' and ApePaterno = '" & apellido & "'", conn)
                Else
                    adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE Becado = 1 and ApePaterno = '" & apellido & "'", conn)
                End If
            ElseIf FormAlumnosMatriculados.cbNoBecados.Checked = True Then
                adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE Becado = 0 and ApePaterno = '" & apellido & "'", conn)
            Else
                adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE ApePaterno = '" & apellido & "'", conn)
            End If
        ElseIf FormAlumnosMatriculados.txtEdad.Text <> "" Then
            If FormAlumnosMatriculados.cbbCurso.Text <> "" Then
                If FormAlumnosMatriculados.cbBuscarServSalud.Text <> "" Then
                    If FormAlumnosMatriculados.cbBecados.Checked = True Then
                        If FormAlumnosMatriculados.cbbPorcentaje.Text <> "" Then
                            adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE Becado = 1 and Edad = '" & edad & "' and Curso = '" & curso.Text & "' and PorcentajeBeca = '" & porcentaje.Text & "' and PlanSalud = '" & salud.Text & "'", conn)
                        Else
                            adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE Becado = 1 and Edad = '" & edad & "' and Curso = '" & curso.Text & "' and PlanSalud = '" & salud.Text & "'", conn)
                        End If
                    ElseIf FormAlumnosMatriculados.cbNoBecados.Checked = True Then
                        adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE Becado = 0 and Edad = '" & edad & "' and Curso = '" & curso.Text & "' and PlanSalud = '" & salud.Text & "'", conn)
                    Else
                        adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE Edad = '" & edad & "' and Curso = '" & curso.Text & "' and PlanSalud = '" & salud.Text & "'", conn)
                    End If
                ElseIf FormAlumnosMatriculados.cbBecados.Checked = True Then
                    If FormAlumnosMatriculados.cbbPorcentaje.Text <> "" Then
                        adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE Becado = 1 and Edad = '" & edad & "' and Curso = '" & curso.Text & "' and PorcentajeBeca = '" & porcentaje.Text & "'", conn)
                    Else
                        adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE Becado = 1 and Edad = '" & edad & "' and Curso = '" & curso.Text & "'", conn)
                    End If
                ElseIf FormAlumnosMatriculados.cbNoBecados.Checked = True Then
                    adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE Becado = 0 and Edad = '" & edad & "' and Curso = '" & curso.Text & "'", conn)
                Else
                    adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE Edad = '" & edad & "' and Curso = '" & curso.Text & "'", conn)
                End If
            Else
                adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE Edad = '" & edad & "'", conn)
            End If
        ElseIf FormAlumnosMatriculados.cbbCurso.Text <> "" Then
            If FormAlumnosMatriculados.cbBuscarServSalud.Text <> "" Then
                If FormAlumnosMatriculados.cbBecados.Checked = True Then
                    If FormAlumnosMatriculados.cbbPorcentaje.Text <> "" Then
                        adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE Becado = 1 and Curso = '" & curso.Text & "' and PorcentajeBeca = '" & porcentaje.Text & "' and PlanSalud = '" & salud.Text & "'", conn)
                    Else
                        adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE Becado = 1 and Curso = '" & curso.Text & "' and PlanSalud = '" & salud.Text & "'", conn)
                    End If
                ElseIf FormAlumnosMatriculados.cbNoBecados.Checked = True Then
                    adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE Becado = 0 and Curso = '" & curso.Text & "' and PlanSalud = '" & salud.Text & "'", conn)
                Else
                    adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE Curso = '" & curso.Text & "' and PlanSalud = '" & salud.Text & "'", conn)
                End If
            ElseIf FormAlumnosMatriculados.cbBecados.Checked = True Then
                If FormAlumnosMatriculados.cbbPorcentaje.Text <> "" Then
                    adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE Becado = 1 and Curso = '" & curso.Text & "' and PorcentajeBeca = '" & porcentaje.Text & "'", conn)
                Else
                    adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE Becado = 1 and Curso = '" & curso.Text & "'", conn)
                End If
            ElseIf FormAlumnosMatriculados.cbNoBecados.Checked = True Then
                adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE Becado = 0 and Curso = '" & curso.Text & "'", conn)
            Else
                adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE Curso = '" & curso.Text & "'", conn)
            End If
        ElseIf FormAlumnosMatriculados.cbBuscarServSalud.Text <> "" Then
            If FormAlumnosMatriculados.cbBecados.Checked = True Then
                If FormAlumnosMatriculados.cbbPorcentaje.Text <> "" Then
                    adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE Becado = 1 and PorcentajeBeca = '" & porcentaje.Text & "' and PlanSalud = '" & salud.Text & "'", conn)
                Else
                    adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE Becado = 1 and PlanSalud = '" & salud.Text & "'", conn)
                End If
            ElseIf FormAlumnosMatriculados.cbNoBecados.Checked = True Then
                adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE Becado = 0 and PlanSalud = '" & salud.Text & "'", conn)
            Else
                adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE PlanSalud = '" & salud.Text & "'", conn)
            End If
        ElseIf FormAlumnosMatriculados.cbBecados.Checked = True Then
            If FormAlumnosMatriculados.cbbPorcentaje.Text <> "" Then
                adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE Becado = 1 and PorcentajeBeca = '" & porcentaje.Text & "'", conn)
            Else
                adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE Becado = 1", conn)
            End If
        ElseIf FormAlumnosMatriculados.cbNoBecados.Checked = True Then
            adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna WHERE Becado = 0", conn)
        Else
            adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join fichaalumno on alumno.fichaalumno_idfichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.curso_idcurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idcomuna", conn)
        End If

        adapter.Fill(dataSet)
        dgv.DataSource = dataSet.Tables(0)
    End Function

    Public Function CargarFichaPersonal(ByRef rut As String)
        Dim conn As New MySqlConnection("server=localhost;User Id=root;password=123456;database=bd_echaurren")
        Dim adapter As New MySqlDataAdapter()
        Dim dataSet As New DataSet
        Dim total As Integer
        Try
            adapter.SelectCommand = New MySqlCommand("SELECT count(*) as total FROM responsable inner join responsable_alumno ON responsable.RutResponsable = responsable_alumno.Responsable_RutResponsable inner join tipo_responsable ON responsable_alumno.Tipo_responsable_idTipo_responsable = tipo_responsable.idTipo_responsable WHERE Alumno_RutAlumno = '" & rut & "'", conn)
            adapter.Fill(dataSet)
            total = dataSet.Tables(0).Rows("0")("total").ToString()
            If total <> 0 Then
                For i = 1 To total
                    adapter.SelectCommand = New MySqlCommand("SELECT Tipo_responsable, RutResponsable, NombreCompleto, Edad, EstudiosCompletados, CorreoElectronico, Profesion, Trabajo, Cargo, Num1, DireccionParticular FROM responsable inner join responsable_alumno ON responsable.RutResponsable = responsable_alumno.Responsable_RutResponsable inner join tipo_responsable ON responsable_alumno.Tipo_responsable_idTipo_responsable = tipo_responsable.idTipo_responsable inner join direccion ON responsable.Direccion_idDireccion = direccion.idDireccion inner join telefono ON responsable.Telefono_idTelefono = telefono.idTelefono WHERE Alumno_RutAlumno = '" & rut & "'", conn)
                    adapter.Fill(dataSet)
                    If dataSet.Tables(0).Rows(i)("Tipo_responsable").ToString = "tutor economico" Then
                        DetalleInfoAlumno.txtRutTutor.Text = dataSet.Tables(0).Rows(i)("RutResponsable").ToString
                        DetalleInfoAlumno.txtNombreTutor.Text = dataSet.Tables(0).Rows(i)("NombreCompleto").ToString
                        DetalleInfoAlumno.txtFonoTrabTutor.Text = dataSet.Tables(0).Rows(i)("NumTrabajo").ToString
                        DetalleInfoAlumno.txtTrabajoTutor.Text = dataSet.Tables(0).Rows(i)("Trabajo").ToString
                        DetalleInfoAlumno.txtProfesionTutor.Text = dataSet.Tables(0).Rows(i)("Profesion").ToString
                        DetalleInfoAlumno.txtOcupacionTutor.Text = dataSet.Tables(0).Rows(i)("Cargo").ToString
                        DetalleInfoAlumno.txtDomicilioTutor.Text = dataSet.Tables(0).Rows(i)("DireccionParticular").ToString
                        DetalleInfoAlumno.txtFonoTutor.Text = dataSet.Tables(0).Rows(i)("Num1").ToString
                    ElseIf dataSet.Tables(0).Rows(i)("Tipo_responsable").ToString = "padre" Then
                        DetalleInfoAlumno.txtRutPadre.Text = dataSet.Tables(0).Rows(i)("RutResponsable").ToString
                        DetalleInfoAlumno.txtNombrePadre.Text = dataSet.Tables(0).Rows(i)("NombreCompleto").ToString
                        DetalleInfoAlumno.txtEdadPadre.Text = dataSet.Tables(0).Rows(i)("Edad").ToString
                        DetalleInfoAlumno.txtEstudiosPadre.Text = dataSet.Tables(0).Rows(i)("EstudiosCompletados").ToString
                        DetalleInfoAlumno.txtTrabajoPadre.Text = dataSet.Tables(0).Rows(i)("Trabajo").ToString
                        DetalleInfoAlumno.txtCargoPadre.Text = dataSet.Tables(0).Rows(i)("Cargo").ToString
                        DetalleInfoAlumno.txtDireccionPadre.Text = dataSet.Tables(0).Rows(i)("DireccionParticular").ToString
                        DetalleInfoAlumno.txtFonoPadre.Text = dataSet.Tables(0).Rows(i)("Num1").ToString
                    ElseIf dataSet.Tables(0).Rows(i)("Tipo_responsable").ToString = "madre" Then
                        DetalleInfoAlumno.txtRutMadre.Text = dataSet.Tables(0).Rows(i)("RutResponsable").ToString
                        DetalleInfoAlumno.txtNombreMadre.Text = dataSet.Tables(0).Rows(i)("NombreCompleto").ToString
                        DetalleInfoAlumno.txtEdadMadre.Text = dataSet.Tables(0).Rows(i)("Edad").ToString
                        DetalleInfoAlumno.txtEstudiosMadre.Text = dataSet.Tables(0).Rows(i)("EstudiosCompletados").ToString
                        DetalleInfoAlumno.txtTrabajoMadre.Text = dataSet.Tables(0).Rows(i)("Trabajo").ToString
                        DetalleInfoAlumno.txtCargoMadre.Text = dataSet.Tables(0).Rows(i)("Cargo").ToString
                        DetalleInfoAlumno.txtDireccionMadre.Text = dataSet.Tables(0).Rows(i)("DireccionParticular").ToString
                        DetalleInfoAlumno.txtFonoMadre.Text = dataSet.Tables(0).Rows(i)("Num1").ToString
                    ElseIf dataSet.Tables(0).Rows(i)("Tipo_responsable").ToString = "otro" Then
                        DetalleInfoAlumno.txtRutOtro.Text = dataSet.Tables(0).Rows(i)("RutResponsable").ToString
                        DetalleInfoAlumno.txtNombreOtro.Text = dataSet.Tables(0).Rows(i)("NombreCompleto").ToStrin
                        DetalleInfoAlumno.txtDireccionOtro.Text = dataSet.Tables(0).Rows(i)("DireccionParticular").ToString
                        DetalleInfoAlumno.txtFonoOtro.Text = dataSet.Tables(0).Rows(i)("Num1").ToString
                    End If
                Next i
            Else
                MsgBox("Alumno no registra información de responsables", MsgBoxStyle.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("Error al cargar los datos, intente nuevamente", "Error")
        End Try
    End Function

    Public Function CargarContactosFichaPersonal(ByRef rut As String)
        Dim conn As New MySqlConnection("server=localhost;User Id=root;password=123456;database=bd_echaurren")
        Dim adapter As New MySqlDataAdapter()
        Dim dataSet As New DataSet
        Dim total As Integer
        Try
            adapter.SelectCommand = New MySqlCommand("SELECT count(*) as total FROM contacto_emergencia inner join alumno on contacto_emergencia.Alumno_RutAlumno = alumno.RutAlumno WHERE Alumno_RutAlumno = '" & rut & "'", conn)
            adapter.Fill(dataSet)
            total = dataSet.Tables(0).Rows("0")("total").ToString()
            For i = 1 To total
                adapter.SelectCommand = New MySqlCommand("SELECT idContacto_emergencia, NombreContacto, Numero FROM contacto_emergencia inner join alumno ON contacto_emergencia.Alumno_RutAlumno = alumno.RutAlumno WHERE Alumno_RutAlumno = '" & rut & "'", conn)
                adapter.Fill(dataSet)
                If dataSet.Tables(0).Rows(i)("idContacto_emergencia").ToString = "1" Then
                    DetalleInfoAlumno.lblNombreContacto1.Text = dataSet.Tables(0).Rows(i)("NombreContacto").ToString
                    DetalleInfoAlumno.lblFonoContacto1.Text = dataSet.Tables(0).Rows(i)("Numero").ToString
                ElseIf dataSet.Tables(0).Rows(i)("idContacto_emergencia").ToString = "2" Then
                    DetalleInfoAlumno.lblNombreContacto2.Text = dataSet.Tables(0).Rows(i)("NombreContacto").ToString
                    DetalleInfoAlumno.lblFonoContacto2.Text = dataSet.Tables(0).Rows(i)("Numero").ToString
                ElseIf dataSet.Tables(0).Rows(i)("idContacto_emergencia").ToString = "3" Then
                    DetalleInfoAlumno.lblNombreContacto3.Text = dataSet.Tables(0).Rows(i)("NombreContacto").ToString
                    DetalleInfoAlumno.lblFonoContacto3.Text = dataSet.Tables(0).Rows(i)("Numero").ToString
                End If
            Next i
        Catch ex As Exception
            MessageBox.Show("Error al cargar los datos de contacto, intente nuevamente", "Error")
        End Try
    End Function

    Public Function ingresarContactEmergencia(ByRef nombreContacto1 As String, ByRef numContacto1 As String, _
                                              ByRef nombreContacto2 As String, ByRef numContacto2 As String, _
                                              ByRef nombreContacto3 As String, ByRef numContacto3 As String) As Boolean


        Try

            Dim consultaContactEmer1 As String = "INSERT INTO `bd_echaurren`.`contacto_emergencia` (`NombreContacto`, `Numero`, `Alumno_RutAlumno`) VALUES ('" & nombreContacto1 & "', '" & numContacto1 & "', '" & FormularioMatricula.txtRutAlumno.Text & "');"
            Dim consultaContactEmer2 As String = "INSERT INTO `bd_echaurren`.`contacto_emergencia` (`NombreContacto`, `Numero`, `Alumno_RutAlumno`) VALUES ('" & nombreContacto2 & "', '" & numContacto2 & "', '" & FormularioMatricula.txtRutAlumno.Text & "');"
            Dim consultaContactEmer3 As String = "INSERT INTO `bd_echaurren`.`contacto_emergencia` (`NombreContacto`, `Numero`, `Alumno_RutAlumno`) VALUES ('" & nombreContacto3 & "', '" & numContacto3 & "', '" & FormularioMatricula.txtRutAlumno.Text & "');"

            If FormularioMatricula.ComboBox1.Text = "1 Contacto" Then

                Dim _comando2 As New MySqlCommand(consultaContactEmer1, FormularioMatricula.varConexion)
                _comando2.ExecuteNonQuery()
                '   MessageBox.Show("Contacto de emergencia ingresado")
                Return True

            ElseIf FormularioMatricula.ComboBox1.Text = "2 Contactos" Then

                Dim _comando3 As New MySqlCommand(consultaContactEmer1, FormularioMatricula.varConexion)
                _comando3.ExecuteNonQuery()
                Dim _comando4 As New MySqlCommand(consultaContactEmer2, FormularioMatricula.varConexion)
                _comando4.ExecuteNonQuery()
                '    MessageBox.Show("Contactos de emergencia ingresado")
                Return True

            ElseIf FormularioMatricula.ComboBox1.Text = "3 Contactos" Then

                Dim _comando5 As New MySqlCommand(consultaContactEmer1, FormularioMatricula.varConexion)
                _comando5.ExecuteNonQuery()
                Dim _comando6 As New MySqlCommand(consultaContactEmer2, FormularioMatricula.varConexion)
                _comando6.ExecuteNonQuery()
                Dim _comando7 As New MySqlCommand(consultaContactEmer3, FormularioMatricula.varConexion)
                _comando7.ExecuteNonQuery()
                '   MessageBox.Show("Contactos de emergencia ingresados")
                Return True
            End If
        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function insertarPadre(ByRef nombrePadre As String, ByRef rutPadre As String, ByRef edadPadre As String, _
                                   ByRef estudiosPadre As ComboBox, ByRef trabajaEnPadre As String, ByRef telefonoPadre As String, _
                                   ByRef CargoPadre As String, ByRef direccionPadre As String, ByRef correoPadre As String) As Boolean


        Try

            Dim consultaPadre As String = "INSERT INTO `bd_echaurren`.`telefono` (`Num1`) VALUES ('" & telefonoPadre & "');"
            Dim consultaPadre2 As String = "INSERT INTO `bd_echaurren`.`responsable` (`RutResponsable`, `NombreCompleto`, `Edad`, `EstudiosCompletados`, `Correo electronico`, `Trabajo`, `Cargo`, `Telefono_idTelefono`) VALUES ('" & rutPadre & "', '" & nombrePadre & "', '" & edadPadre & "', '" & estudiosPadre.Text & "', '" & correoPadre & "', '" & trabajaEnPadre & "', '" & CargoPadre & "', last_insert_id());"
            Dim consultaPadre3 As String = "INSERT INTO `bd_echaurren`.`direccion` (`DireccionTrabajo`) VALUES ('" & direccionPadre & "');"
            Dim consultaPadre4 As String = "UPDATE `bd_echaurren`.`responsable` SET `Direccion_idDireccion`= last_insert_id() WHERE `RutResponsable`='" & rutPadre & "';"

            Dim _comando8 As New MySqlCommand(consultaPadre, FormularioMatricula.varConexion)
            _comando8.ExecuteNonQuery()
            Dim _comando9 As New MySqlCommand(consultaPadre2, FormularioMatricula.varConexion)
            _comando9.ExecuteNonQuery()
            Dim _comando10 As New MySqlCommand(consultaPadre3, FormularioMatricula.varConexion)
            _comando10.ExecuteNonQuery()
            Dim _comando11 As New MySqlCommand(consultaPadre4, FormularioMatricula.varConexion)
            _comando11.ExecuteNonQuery()
            'MessageBox.Show("padre agregado")
            Return True
        Catch ex As Exception
            ' MessageBox.Show("Error al ingresar padre")
            Return False
        End Try
    End Function

    Public Function insertarMadre(ByRef nombreMadre As String, ByRef rutMadre As String, ByRef edadMadre As String, _
                                   ByRef estudiosMadre As ComboBox, ByRef trabajaEnMadre As String, ByRef telefonoMadre As String, _
                                   ByRef CargoMadre As String, ByRef direccionMadre As String, ByRef correoMadre As String) As Boolean


        Try
            Dim consultaMadre As String = "INSERT INTO `bd_echaurren`.`telefono` (`Num1`) VALUES ('" & telefonoMadre & "');"
            Dim consultaMadre2 As String = "INSERT INTO `bd_echaurren`.`responsable` (`RutResponsable`, `NombreCompleto`, `Edad`, `EstudiosCompletados`, `Correo electronico`, `Trabajo`, `Cargo`, `Telefono_idTelefono`) VALUES ('" & rutMadre & "', '" & nombreMadre & "', '" & edadMadre & "', '" & estudiosMadre.Text & "', '" & correoMadre & "', '" & trabajaEnMadre & "', '" & CargoMadre & "', last_insert_id());"
            Dim consultaMadre3 As String = "INSERT INTO `bd_echaurren`.`direccion` (`DireccionTrabajo`) VALUES ('" & direccionMadre & "');"
            Dim consultaMadre4 As String = "UPDATE `bd_echaurren`.`responsable` SET `Direccion_idDireccion`= last_insert_id() WHERE `RutResponsable`='" & rutMadre & "';"

            Dim _comando12 As New MySqlCommand(consultaMadre, FormularioMatricula.varConexion)
            _comando12.ExecuteNonQuery()
            Dim _comando13 As New MySqlCommand(consultaMadre2, FormularioMatricula.varConexion)
            _comando13.ExecuteNonQuery()
            Dim _comando14 As New MySqlCommand(consultaMadre3, FormularioMatricula.varConexion)
            _comando14.ExecuteNonQuery()
            Dim _comando15 As New MySqlCommand(consultaMadre4, FormularioMatricula.varConexion)
            _comando15.ExecuteNonQuery()
            ' MessageBox.Show("Madre agregada")
            Return True
        Catch ex As Exception
            '   MessageBox.Show("Error al ingresar Madre")
            Return False
        End Try

    End Function

    Public Function insertarTutorEconomico(ByRef nombreTutor As String, ByRef rutTutor As String, ByRef telefono1 As String, _
                                           ByRef telefono2 As String, ByRef telefTrabajo As String, ByRef domicilio As String, _
                                           ByRef lugarTrabajo As String, ByRef ocupaActual As String, ByRef profesion As String) As Boolean

        Try
            Dim consultaTutor As String = "INSERT INTO `bd_echaurren`.`telefono` (`Num1`, `Num2`, `NumTrabajo`) VALUES ('" & telefono1 & "', '" & telefono2 & "', '" & telefTrabajo & "');"
            Dim consultaTuror2 As String = "INSERT INTO `bd_echaurren`.`responsable` (`RutResponsable`, `NombreCompleto`, `Profesion`, `Trabajo`, `Cargo`, `Telefono_idTelefono`) VALUES ('" & rutTutor & "', '" & nombreTutor & "', '" & profesion & "', '" & lugarTrabajo & " ', '" & ocupaActual & "', last_insert_id());"
            Dim consultatutor3 As String = "INSERT INTO `bd_echaurren`.`direccion` (`DireccionParticular`) VALUES ('" & domicilio & "');"
            Dim consultaTutor4 As String = "UPDATE `bd_echaurren`.`responsable` SET `Direccion_idDireccion`= last_insert_id() WHERE `RutResponsable`='" & rutTutor & "';"

            Dim comando16 As New MySqlCommand(consultaTutor, FormularioMatricula.varConexion)
            comando16.ExecuteNonQuery()
            Dim comando17 As New MySqlCommand(consultaTuror2, FormularioMatricula.varConexion)
            comando17.ExecuteNonQuery()
            Dim comando18 As New MySqlCommand(consultatutor3, FormularioMatricula.varConexion)
            comando18.ExecuteNonQuery()
            Dim comando19 As New MySqlCommand(consultaTutor4, FormularioMatricula.varConexion)
            comando19.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            '  MessageBox.Show("Error al ingresar tutor economico")
            Return False
        End Try

    End Function

    Public Function insertarResponsableCompleto(ByRef rutResponsable As String, ByRef nombreComleto As String, ByRef telefono1 As String, _
                                                ByRef telefono2 As String, ByRef telefonoTrabajo As String, ByRef direccionPart As String, _
                                               ByRef direccionTrab As String, ByRef edad As String, ByRef estudiosCompl As ComboBox, _
                                               ByRef Correo As String, ByRef profesion As String, ByRef trabajo As String, _
                                               ByRef cargo As String) As Boolean

        Try
            Dim consulta As String = "INSERT INTO `bd_echaurren`.`telefono` (`Num1`, `Num2`, `NumTrabajo`) VALUES ('" & telefono1 & "', '" & telefono2 & "', '" & telefonoTrabajo & "');"
            Dim consulta1 As String = "INSERT INTO `bd_echaurren`.`responsable` (`RutResponsable`, `NombreCompleto`, `Edad`, `EstudiosCompletados`, `Correo electronico`, `Profesion`, `Trabajo`, `Cargo`, `Telefono_idTelefono`) VALUES ('" & rutResponsable & "', '" & nombreComleto & "', '" & edad & "', '" & estudiosCompl.Text & "', '" & Correo & "', '" & profesion & "', '" & trabajo & "', '" & cargo & "', last_insert_id());"
            Dim consulta2 As String = "INSERT INTO `bd_echaurren`.`direccion` (`DireccionParticular`, `DireccionTrabajo`) VALUES ('" & direccionPart & "', '" & direccionTrab & "');"
            Dim consulta3 As String = "UPDATE `bd_echaurren`.`responsable` SET `Direccion_idDireccion`= last_insert_id() WHERE `RutResponsable`='" & rutResponsable & "';"

            Dim comando As New MySqlCommand(consulta, FormularioMatricula.varConexion)
            comando.ExecuteNonQuery()
            Dim comando1 As New MySqlCommand(consulta1, FormularioMatricula.varConexion)
            comando1.ExecuteNonQuery()
            Dim comando2 As New MySqlCommand(consulta2, FormularioMatricula.varConexion)
            comando2.ExecuteNonQuery()
            Dim comando3 As New MySqlCommand(consulta3, FormularioMatricula.varConexion)
            comando3.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            ' MessageBox.Show("Error al ingresaaaaar responsable completo")
            Return False
        End Try

    End Function

    Public Function insertarAlumno_respons(ByRef rutResponsable As String, ByRef rutAlumno As String, ByRef tipoResp As String, _
                                           ByRef apoderado As Integer, ByRef apodSuplente As Integer) As Boolean

        Try
            Dim consulta As String = "INSERT INTO `bd_echaurren`.`responsable_alumno` (`Responsable_RutResponsable`, `Alumno_RutAlumno`, `Tipo_responsable_idTipo_responsable`, `Apoderado`, `ApoderadoSuplente`, `Matricula_NumMatricula`) VALUES ('" & rutResponsable & "', '" & rutAlumno & "', '" & tipoResp & "', '" & apoderado & "', '" & apodSuplente & "', '121134');"
            Dim _comando As New MySqlCommand(consulta, FormularioMatricula.varConexion)
            _comando.ExecuteNonQuery()
            '  MessageBox.Show("relacion responsable - alumno exitosa")
            Return True
        Catch ex As Exception
            '   MessageBox.Show("error al relacionar responsable - alumno")
            Return False
        End Try

    End Function

    Public Function insertarAlumno_respons_tutor(ByRef rutResponsable As String, ByRef rutAlumno As String, ByRef tipoResp As String, _
                                           ByRef apoderado As Integer, ByRef apodSuplente As Integer, _
                                           ByRef OtroTutor As String) As Boolean

        Try
            Dim consulta As String = "INSERT INTO `bd_echaurren`.`responsable_alumno` (`Responsable_RutResponsable`, `Alumno_RutAlumno`, `Tipo_responsable_idTipo_responsable`, `Apoderado`, `ApoderadoSuplente`, `Otro_tutor`, `Matricula_NumMatricula`) VALUES ('" & rutResponsable & "', '" & rutAlumno & "', '" & tipoResp & "', '" & apoderado & "', '" & apodSuplente & "', '" & OtroTutor & "', '121134');"
            Dim comando As New MySqlCommand(consulta, FormularioMatricula.varConexion)
            comando.ExecuteNonQuery()
            ' MessageBox.Show("relacion responsable, tutor - alumno exitosa")
            Return True
        Catch ex As Exception
            '  MessageBox.Show("error al relacionar responsable, tutor - alumno")
            Return False
        End Try
    End Function



    Public Function insertarOtroApod(ByRef rutOtroApod As String, ByRef rutAlumno As String, ByRef apoderado As Integer, _
                                     ByRef apodSuplente As Integer, ByRef nombreOtroResp As String) As Boolean

        Try

            Dim tipoResp As String = "tr4"
            Dim consulta As String = "INSERT INTO `bd_echaurren`.`responsable` (`RutResponsable`, `NombreCompleto`) VALUES ('" & rutOtroApod & "', '" & nombreOtroResp & "');"
            Dim consulta1 As String = "INSERT INTO `bd_echaurren`.`responsable_alumno` (`Responsable_RutResponsable`, `Alumno_RutAlumno`, `Tipo_responsable_idTipo_responsable`, `Apoderado`, `ApoderadoSuplente`, `Matricula_NumMatricula`) VALUES ('" & rutOtroApod & "', '" & rutAlumno & "', '" & tipoResp & "', '" & apoderado & "', '" & apodSuplente & "', '121134');"

            Dim comando As New MySqlCommand(consulta, FormularioMatricula.varConexion)
            comando.ExecuteNonQuery()
            Dim comando2 As New MySqlCommand(consulta1, FormularioMatricula.varConexion)
            comando2.ExecuteNonQuery()
            ' MessageBox.Show("SE INGRESO OTRO APOD SUPLENTE")
            Return True
        Catch ex As Exception
            '   MessageBox.Show("ERROR AL INGRESO OTRO APOD SUPLENTE")
            Return False
        End Try

    End Function


    Public Sub cambiarNombreColumnas()

        FormAlumnosMatriculados.DataGridView1.Columns(0).HeaderText = "Rut alumno"
        FormAlumnosMatriculados.DataGridView1.Columns(1).HeaderText = "Nombre completo"
        FormAlumnosMatriculados.DataGridView1.Columns(2).HeaderText = "Apellido Paterno"
        FormAlumnosMatriculados.DataGridView1.Columns(3).HeaderText = "Apellido Materno"
        FormAlumnosMatriculados.DataGridView1.Columns(4).HeaderText = "Sexo"
        FormAlumnosMatriculados.DataGridView1.Columns(5).HeaderText = "Fecha de Nacimiento"
        FormAlumnosMatriculados.DataGridView1.Columns(6).HeaderText = "Edad"
        FormAlumnosMatriculados.DataGridView1.Columns(7).HeaderText = "Domicilio"
        FormAlumnosMatriculados.DataGridView1.Columns(8).HeaderText = "Sector o villa"
        FormAlumnosMatriculados.DataGridView1.Columns(9).HeaderText = "Comuna"
        FormAlumnosMatriculados.DataGridView1.Columns(10).HeaderText = "Telefono"
        FormAlumnosMatriculados.DataGridView1.Columns(11).HeaderText = "Colegio de presedencia"
        FormAlumnosMatriculados.DataGridView1.Columns(12).HeaderText = "Curso"
        FormAlumnosMatriculados.DataGridView1.Columns(13).HeaderText = "Cursos repetidos"
        FormAlumnosMatriculados.DataGridView1.Columns(14).HeaderText = "Becado"
        FormAlumnosMatriculados.DataGridView1.Columns(15).HeaderText = "Porcentaje de beca"
        FormAlumnosMatriculados.DataGridView1.Columns(16).HeaderText = "Hermanos en establecimiento"
        FormAlumnosMatriculados.DataGridView1.Columns(17).HeaderText = "Convivencia de alumno"
        FormAlumnosMatriculados.DataGridView1.Columns(18).HeaderText = "Numero de hermanos"
        FormAlumnosMatriculados.DataGridView1.Columns(19).HeaderText = "Lugar que ocupa entre hermanos"
        FormAlumnosMatriculados.DataGridView1.Columns(20).HeaderText = "Cantidad de grupo familiar"
        FormAlumnosMatriculados.DataGridView1.Columns(21).HeaderText = "Antecentes Medicos"
        FormAlumnosMatriculados.DataGridView1.Columns(22).HeaderText = "Numero de matricula"
        FormAlumnosMatriculados.DataGridView1.Columns(23).HeaderText = "Fecha de matricula"


    End Sub

    Public Function cargarComboCurso(ByRef consultaCurso As String, ByRef conexion As MySqlConnection) As Boolean

        Try
            Dim _dataAdapter = New MySqlDataAdapter(consultaCurso, conexion)
            Dim _dataSet = New DataSet
            _dataAdapter.Fill(_dataSet)

            FormularioMatricula.comboCurso.DataSource = _dataSet.Tables(0)
            FormularioMatricula.comboCurso.ValueMember = "idCurso"
            FormularioMatricula.comboCurso.DisplayMember = "Curso"
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function cargarComboComuna(ByRef consultaComuna As String, ByRef conexion As MySqlConnection) As Boolean

        Try
            Dim _dataAdapter = New MySqlDataAdapter(consultaComuna, conexion)
            Dim _dataSet = New DataSet
            _dataAdapter.Fill(_dataSet)

            FormularioMatricula.comboComuna.DataSource = _dataSet.Tables(0)
            FormularioMatricula.comboComuna.ValueMember = "idComuna"
            FormularioMatricula.comboComuna.DisplayMember = "Comuna"
            Return True

        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function cargarComboServSalud(ByRef consultaServSalud As String, ByVal conexion As MySqlConnection)

        Try
            Dim _dataAdapter = New MySqlDataAdapter(consultaServSalud, conexion)
            Dim _dataSet = New DataSet
            _dataAdapter.Fill(_dataSet)

            FormularioMatricula.comboServSalud.DataSource = _dataSet.Tables(0)
            FormularioMatricula.comboServSalud.ValueMember = "idServicio_salud"
            FormularioMatricula.comboServSalud.DisplayMember = "PlanSalud"
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function


    Public Function AutollenarFormulario(ByRef RutAlumno As String, ByRef conexion As MySqlConnection) As Boolean

        Try
            Dim consulta1 As String = "select * from alumno where alumno.RutAlumno = '" & RutAlumno & "'"
            Dim consulta2 As String = "select * from alumno inner join curso on alumno.Curso_idCurso = curso.idCurso where RutAlumno = '" & RutAlumno & "'"
            Dim consulta3 As String = "select * from alumno inner join comuna on alumno.Comuna_idComuna = comuna.idComuna where RutAlumno='" & RutAlumno & "'"
            Dim consulta4 As String = "select * from alumno inner join fichaalumno on alumno.fichaalumno_idFichaalumno = fichaalumno.idFichaalumno where alumno.RutAlumno = '" & RutAlumno & "'"
            Dim consulta5 As String = "select * from servicio_salud inner join servicio_por_alumno on servicio_salud.idServicio_salud = servicio_por_alumno.Servicio_salud_idServicio_salud where alumno_RutAlumno = '" & RutAlumno & "'"
            Dim consulta6 As String = "select * from contacto_emergencia where Alumno_RutAlumno = '" & RutAlumno & "'"
            Dim consulta7 As String = "select * from responsable inner join responsable_alumno on responsable.RutResponsable = responsable_alumno.Responsable_RutResponsable inner join telefono on responsable.Telefono_idTelefono = telefono.idTelefono inner join direccion on responsable.Direccion_idDireccion = direccion.idDireccion where Alumno_RutAlumno = '" & RutAlumno & "'"
            Dim consulta8 As String = "select * from responsable inner join responsable_alumno on responsable.RutResponsable = responsable_alumno.Responsable_RutResponsable inner join telefono on responsable.Telefono_idTelefono = telefono.idTelefono inner join direccion on responsable.Direccion_idDireccion = direccion.idDireccion where Alumno_RutAlumno = '" & RutAlumno & "' and Tipo_responsable_idTipo_responsable = 'tr2'"
            Dim consulta9 As String = "select * from responsable inner join responsable_alumno on responsable.RutResponsable = responsable_alumno.Responsable_RutResponsable where Alumno_RutAlumno = '" & RutAlumno & "'"

            Dim _dataAdapter As New MySqlDataAdapter(consulta1, conexion)
            Dim _dataAdapter2 As New MySqlDataAdapter(consulta2, conexion)
            Dim _dataAdapter3 As New MySqlDataAdapter(consulta3, conexion)
            Dim _dataAdapter4 As New MySqlDataAdapter(consulta4, conexion)
            Dim _dataAdapter5 As New MySqlDataAdapter(consulta5, conexion)
            Dim _dataAdapter6 As New MySqlDataAdapter(consulta6, conexion)
            Dim _dataAdapter7 As New MySqlDataAdapter(consulta7, conexion)
            Dim _dataAdapter8 As New MySqlDataAdapter(consulta8, conexion)
            Dim _dataSet As New DataSet

            _dataAdapter.Fill(_dataSet)
            FormularioMatricula.txtApePatAlumno.Text = _dataSet.Tables(0).Rows("0")("ApePaterno").ToString
            FormularioMatricula.txtApeMatAlumno.Text = _dataSet.Tables(0).Rows("0")("ApeMaterno").ToString
            FormularioMatricula.txtNombresAlumno.Text = _dataSet.Tables(0).Rows("0")("NombreCompleto").ToString
            If _dataSet.Tables(0).Rows("0")("Sexo") = "Masculino" Then
                FormularioMatricula.radioMasc.Checked = True
            Else
                FormularioMatricula.radioFeme.Checked = True
            End If
            FormularioMatricula.dateTimeFechaNac.Value = _dataSet.Tables(0).Rows("0")("FechaNac")
            FormularioMatricula.txtRutAlumno.Text = _dataSet.Tables(0).Rows("0")("RutAlumno").ToString
            FormularioMatricula.txtEdadAlumno.Text = _dataSet.Tables(0).Rows("0")("Edad").ToString
            FormularioMatricula.txtCalleAlumno.Text = _dataSet.Tables(0).Rows("0")("Domicilio").ToString
            FormularioMatricula.txtSectorAlumno.Text = _dataSet.Tables(0).Rows("0")("SectorVilla").ToString
            FormularioMatricula.txtTelefonoAlumno.Text = _dataSet.Tables(0).Rows("0")("Telefono").ToString
            _dataSet.Clear()

            _dataAdapter2.Fill(_dataSet)
            FormularioMatricula.comboCurso.Text = _dataSet.Tables(0).Rows("0")("Curso").ToString
            _dataSet.Clear()

            _dataAdapter3.Fill(_dataSet)
            FormularioMatricula.comboComuna.Text = _dataSet.Tables(0).Rows("0")("Comuna").ToString
            _dataSet.Clear()

            _dataAdapter4.Fill(_dataSet)
            FormularioMatricula.txtColegioPrese.Text = _dataSet.Tables(0).Rows("0")("ColegioPresedencia").ToString
            FormularioMatricula.txtCursosRepetidos.Text = _dataSet.Tables(0).Rows("0")("CursosRepetidos").ToString
            If _dataSet.Tables(0).Rows("0")("HermanosEstablecimiento").ToString = "" Then
                FormularioMatricula.radioHermanosNo.Checked = True
            Else
                FormularioMatricula.radioHermanosSi.Checked = True
                FormularioMatricula.txtHermanosCursos.Text = _dataSet.Tables(0).Rows("0")("HermanosEstablecimiento").ToString
            End If
            If FormularioMatricula.cbViveCon.Text = "Otros (especificar)" Then
                FormularioMatricula.cbViveCon.Text = "Otros (especificar)"
                FormularioMatricula.txtViveConOtros.Text = _dataSet.Tables(0).Rows("0")("AlumnoViveCon").ToString
            Else
                FormularioMatricula.cbViveCon.Text = _dataSet.Tables(0).Rows("0")("AlumnoViveCon").ToString
            End If
            FormularioMatricula.txtNumHijos.Text = _dataSet.Tables(0).Rows("0")("NumHijosFamilia").ToString
            FormularioMatricula.txtLugarHijos.Text = _dataSet.Tables(0).Rows("0")("LugarOcupacionHijos").ToString
            FormularioMatricula.txtGrupoFamiliar.Text = _dataSet.Tables(0).Rows("0")("GrupoFamiliarComponen").ToString
            FormularioMatricula.txtAntecedentesMed.Text = _dataSet.Tables(0).Rows("0")("AntecedentesMedicos").ToString
            FormularioMatricula.CheckBox1.Checked = _dataSet.Tables(0).Rows("0")("Becado")
            _dataSet.Clear()

            _dataAdapter5.Fill(_dataSet)
            If _dataSet.Tables(0).Rows("0")("PlanSalud") = "otro" Then
                FormularioMatricula.comboServSalud.Text = "otro"
                FormularioMatricula.txtOtrosServicios.Text = _dataSet.Tables(0).Rows("0")("OtrosServicios").ToString
                FormularioMatricula.txtSeguros.Text = _dataSet.Tables(0).Rows("0")("Seguros").ToString
            Else
                FormularioMatricula.comboServSalud.Text = _dataSet.Tables(0).Rows("0")("PlanSalud").ToString
                FormularioMatricula.txtSeguros.Text = _dataSet.Tables(0).Rows("0")("Seguros").ToString
            End If
            _dataSet.Clear()

            _dataAdapter6.Fill(_dataSet)
            If _dataSet.Tables(0).Rows.Count = 1 Then
                FormularioMatricula.ComboBox1.Text = "1 Contacto"
                FormularioMatricula.txtNombreContacto.Text = _dataSet.Tables(0).Rows("0")("NombreContacto").ToString
                FormularioMatricula.txtNumContacto.Text = _dataSet.Tables(0).Rows("0")("Numero").ToString
            ElseIf _dataSet.Tables(0).Rows.Count = 2 Then
                FormularioMatricula.ComboBox1.Text = "2 Contactos"
                FormularioMatricula.txtNombreContacto.Text = _dataSet.Tables(0).Rows("0")("NombreContacto").ToString
                FormularioMatricula.txtNumContacto.Text = _dataSet.Tables(0).Rows("0")("Numero").ToString
                FormularioMatricula.txtNombreContacto2.Text = _dataSet.Tables(0).Rows("1")("NombreContacto").ToString
                FormularioMatricula.txtNumContacto2.Text = _dataSet.Tables(0).Rows("1")("Numero").ToString
            Else
                FormularioMatricula.ComboBox1.Text = "3 Contactos"
                FormularioMatricula.txtNombreContacto.Text = _dataSet.Tables(0).Rows("0")("NombreContacto").ToString
                FormularioMatricula.txtNumContacto.Text = _dataSet.Tables(0).Rows("0")("Numero").ToString
                FormularioMatricula.txtNombreContacto2.Text = _dataSet.Tables(0).Rows("1")("NombreContacto").ToString
                FormularioMatricula.txtNumContacto2.Text = _dataSet.Tables(0).Rows("1")("Numero").ToString
                FormularioMatricula.txtNombreContacto3.Text = _dataSet.Tables(0).Rows("2")("NombreContacto").ToString
                FormularioMatricula.txtNumContacto3.Text = _dataSet.Tables(0).Rows("2")("Numero").ToString
            End If
            _dataSet.Clear()
          

            _dataAdapter7.Fill(_dataSet)
            While _dataSet.Tables(0).Rows("0")("Tipo_responsable_idTipo_responsable").ToString <> ""
                While _dataSet.Tables(0).Rows("0")("Tipo_responsable_idTipo_responsable").ToString = "tr1"
                    FormularioMatricula.txtNombrePadre.Text = _dataSet.Tables(0).Rows("0")("NombreCompleto").ToString
                    FormularioMatricula.txtRutPadre.Text = _dataSet.Tables(0).Rows("0")("RutResponsable").ToString
                    FormularioMatricula.txtEdadPadre.Text = _dataSet.Tables(0).Rows("0")("Edad").ToString
                    FormularioMatricula.cbEstudiosPadre.Text = _dataSet.Tables(0).Rows("0")("EstudiosCompletados").ToString
                    FormularioMatricula.txtTrabajaenPadre.Text = _dataSet.Tables(0).Rows("0")("Trabajo").ToString
                    FormularioMatricula.txtCargoPadre.Text = _dataSet.Tables(0).Rows("0")("Cargo").ToString
                    FormularioMatricula.txtTelefonoPadre.Text = _dataSet.Tables(0).Rows("0")("NumTrabajo").ToString
                    FormularioMatricula.txtDireccionPadre.Text = _dataSet.Tables(0).Rows("0")("DireccionTrabajo").ToString
                    FormularioMatricula.txtCorreoPadre.Text = _dataSet.Tables(0).Rows("0")("Correo electronico").ToString
                    FormularioMatricula.checkpadre.Checked = True
                    Exit While
                End While

                While _dataSet.Tables(0).Rows("0")("Tipo_responsable_idTipo_responsable").ToString = "tr2"
                    _dataSet.Clear()
                    _dataAdapter8.Fill(_dataSet)
                    FormularioMatricula.txtNombreMadre.Text = _dataSet.Tables(0).Rows("0")("NombreCompleto").ToString
                    FormularioMatricula.txtRutMadre.Text = _dataSet.Tables(0).Rows("0")("RutResponsable").ToString
                    FormularioMatricula.txtEdadMadre.Text = _dataSet.Tables(0).Rows("0")("Edad").ToString
                    FormularioMatricula.cbEstudiosMadre.Text = _dataSet.Tables(0).Rows("0")("EstudiosCompletados").ToString
                    FormularioMatricula.txtTrabajaenMadre.Text = _dataSet.Tables(0).Rows("0")("Trabajo").ToString
                    FormularioMatricula.txtCargoMadre.Text = _dataSet.Tables(0).Rows("0")("Cargo").ToString
                    FormularioMatricula.txtTelefonoMadre.Text = _dataSet.Tables(0).Rows("0")("NumTrabajo").ToString
                    FormularioMatricula.txtDireccionMadre.Text = _dataSet.Tables(0).Rows("0")("DireccionTrabajo").ToString
                    FormularioMatricula.txtCorreoMadre.Text = _dataSet.Tables(0).Rows("0")("Correo electronico").ToString
                    FormularioMatricula.checkmadre.Checked = True
                    Exit While
                End While
              
                Exit While
            End While
            '  _dataAdapter9.Fill(_dataSet)
            '   FormularioMatricula.txtNombreTutor.Text = _dataSet.Tables(0).Rows("0")("NombreCompleto").ToString
            '  FormularioMatricula.txtRut.Text = _dataSet.Tables(0).Rows("0")("RutResponsable").ToString
            ' FormularioMatricula.txtTelefonoPart.Text = _dataSet.Tables(0).Rows("0")("Num1").ToString
            'FormularioMatricula.txtTelefonoPart2.Text = _dataSet.Tables(0).Rows("0")("Num2").ToString
            'FormularioMatricula.txtTelefonoTrabajo.Text = _dataSet.Tables(0).Rows("0")("Num2").ToString
            'FormularioMatricula.txtDomicilio.Text = _dataSet.Tables(0).Rows("0")("DireccionParticular").ToString
            'FormularioMatricula.txtLugarDeTrabajo.Text = _dataSet.Tables(0).Rows("0")("Trabajo").ToString
            'FormularioMatricula.txtOcupacionAct.Text = _dataSet.Tables(0).Rows("0")("Cargo").ToString
            'FormularioMatricula.txtProfesion.Text = _dataSet.Tables(0).Rows("0")("Profesion").ToString



        Catch ex As Exception
            MessageBox.Show("Alumno no encontrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Function
End Module
