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

            If resultado = "10" Then
                resultado = "K"
            ElseIf resultado = "11" Then
                resultado = "0"
            End If
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
                              ByRef antecedentesMedicos As String, ByRef viveEspecifico As String, ByRef cursosHerm As String, ByRef NumMatri As Integer, ByRef fechamatri As DateTimePicker, ByRef porcentaje As String) As Boolean


        Try
            Dim consultaFichaAlumno As String = "INSERT INTO `bd_echaurren`.`fichaalumno` (`ColegioPresedencia`, `CursosRepetidos`, `Becado`, `PorcentajeBeca`, `HermanosEstablecimiento`, `CursosHermanos`, `AlumnoViveCon`, `NumHijosFamilia`, `LugarOcupacionHijos`, `GrupoFamiliarComponen`, `AntecedentesMedicos`, `ViveEspecifico`) VALUES ('" & colegioPresedencia & "', '" & cursosRepe & "', '" & becado & "', '" & porcentaje & "', '" & hermanosEstable & "', '" & cursosHerm & "', '" & alumnoViveCon & "', '" & numHijosFam & "', '" & lugarocupaHijos & "', '" & grupoFamiliarCompo & "', '" & antecedentesMedicos & "', '" & viveEspecifico & "');"
            Dim comando0 As New MySqlCommand(consultaFichaAlumno, FormularioMatricula.varConexion)
            comando0.ExecuteNonQuery()
            Dim consultaIngresoMatri As String = "INSERT INTO `bd_echaurren`.`matricula` (`NumMatricula`,`Fechamatricula`) VALUES('" & NumMatri & "', '" & fechamatri.Text & "');"
            Dim _comando2 As New MySqlCommand(consultaIngresoMatri, FormularioMatricula.varConexion)
            _comando2.ExecuteNonQuery()
            Dim consultaIngresoAlumn As String = "INSERT INTO `bd_echaurren`.`alumno` (`RutAlumno`, `NombreCompleto`, `ApePaterno`, `ApeMaterno`, `Sexo`, `FechaNac`, `Edad`, `Domicilio`, `SectorVilla`, `Telefono`, `Curso_idCurso`, `Comuna_idComuna`, `Fichaalumno_idFichaalumno`, `Matricula_NumMatricula`) VALUES ('" & RunAlumno & "', '" & nombresAlumno & "', '" & apellidoPatAlumno & "', '" & apellidoMatAlumno & "', '" & SexoAlumno & "', '" & fechaNacimientoAlumno.Value.ToString("dd/MM/yyyy") & "', '" & EdadAlumno & "', '" & domicilioCalleAlumn & "', '" & sectorAlumno & "', '" & telefAlumno & "', '" & curso & "', '" & comunaAlumno & "', last_insert_id(), '" & NumMatri & "');"
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

    Public Function RegistrarMensualidades(ByRef rut As String, ByRef mes As String, ByRef tipopago As ComboBox, ByRef monto As Integer, ByRef fechavenc As String, ByRef documento As String, ByRef montoanual As Integer, ByRef titular As String, ByRef banco As String, ByRef ctacorriente As String)
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
                consulta = "INSERT INTO `bd_echaurren`.`mensualidad` (`RutAlumno`, `NombreMes`, `TipoPago`, `Monto`, `FechaPago`, `Estado`, `NumDocumento`, `MontoTotalAnual`, `NombreTitular`, `NumCtaCorriente`, `NombreBanco`) VALUES ('" & rut & "', '" & mes & "', '" & tipopago.Text & "', '" & monto & "', '" & fechavenc & "', 'PAGADO', '" & documento & "', '" & montoanual & "', '" & titular & "', '" & ctacorriente & "', '" & banco & "');"
            ElseIf FormularioMatricula.cbbTipoPago.SelectedItem = "Cheque" Or FormularioMatricula.cbbTipoPago.SelectedItem = "Letra" Then
                consulta = "INSERT INTO `bd_echaurren`.`mensualidad` (`RutAlumno`, `NombreMes`, `TipoPago`, `Monto`, `FechaPago`, `Estado`, `NumDocumento`, `MontoTotalAnual`, `NombreTitular`, `NumCtaCorriente`, `NombreBanco`) VALUES ('" & rut & "', '" & mes & "', '" & tipopago.Text & "', '" & monto & "', '" & fechavenc & "', 'NO PAGADO', '" & documento & "', '" & montoanual & "', '" & titular & "', '" & ctacorriente & "', '" & banco & "');"
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

    Public Function DeshacerPago(ByRef comprobante As String, ByRef mes As String, ByRef rut As String) As Boolean
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
            consulta = "UPDATE `bd_echaurren`.`mensualidad` SET `Estado`='NO PAGADO', `NumComprobante`='" & comprobante & "' WHERE `NombreMes`='" & mes & "' and RutAlumno = '" & rut & "';"
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

    Public Function ComprobarFiltros(ByRef dgv As DataGridView, ByRef curso As ComboBox, ByRef porcentaje As ComboBox, ByRef mes As String)
        Dim conn As New MySqlConnection("server=localhost;User Id=root;password=123456;database=bd_echaurren")
        Dim adapter As New MySqlDataAdapter()
        Dim dataSet As New DataSet

        If AdminMensualidades.cbFiltroCurso.SelectedIndex <> 0 Then
            If AdminMensualidades.CheckBecado.Checked = True Then
                If AdminMensualidades.cbPorcentaje.Text <> "" Then
                    If AdminMensualidades.CheckPagado.Checked = True Then
                        adapter.SelectCommand = New MySqlCommand("SELECT alumno.RutAlumno, NombreCompleto, ApePaterno, Curso, Becado, PorcentajeBeca, NombreMes, Monto, TipoPago, Estado from Alumno inner join Mensualidad on alumno.RutAlumno = mensualidad.RutAlumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno WHERE Becado = 1 and Estado = 'PAGADO' and Curso = '" & curso.Text & "' and PorcentajeBeca = '" & porcentaje.Text & "' and NombreMes = '" & mes & "'", conn)
                    ElseIf AdminMensualidades.CheckAtrasado.Checked = True Then
                        adapter.SelectCommand = New MySqlCommand("SELECT alumno.RutAlumno, NombreCompleto, ApePaterno, Curso, Becado, PorcentajeBeca, NombreMes, Monto, TipoPago, Estado from Alumno inner join Mensualidad on alumno.RutAlumno = mensualidad.RutAlumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno WHERE Becado = 1 and Estado = 'ATRASADO' and Curso = '" & curso.Text & "' and PorcentajeBeca = '" & porcentaje.Text & "' and NombreMes = '" & mes & "'", conn)
                    Else
                        adapter.SelectCommand = New MySqlCommand("SELECT alumno.RutAlumno, NombreCompleto, ApePaterno, Curso, Becado, PorcentajeBeca, NombreMes, Monto, TipoPago, Estado from Alumno inner join Mensualidad on alumno.RutAlumno = mensualidad.RutAlumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno WHERE Becado = 1 and Curso = '" & curso.Text & "' and PorcentajeBeca = '" & porcentaje.Text & "' and NombreMes = '" & mes & "'", conn)
                    End If
                Else
                    If AdminMensualidades.CheckPagado.Checked = True Then
                        adapter.SelectCommand = New MySqlCommand("SELECT alumno.RutAlumno, NombreCompleto, ApePaterno, Curso, Becado, PorcentajeBeca, NombreMes, Monto, TipoPago, Estado from Alumno inner join Mensualidad on alumno.RutAlumno = mensualidad.RutAlumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno WHERE Becado = 1 and Estado = 'PAGADO' and Curso = '" & curso.Text & "' and NombreMes = '" & mes & "'", conn)
                    ElseIf AdminMensualidades.CheckAtrasado.Checked = True Then
                        adapter.SelectCommand = New MySqlCommand("SELECT alumno.RutAlumno, NombreCompleto, ApePaterno, Curso, Becado, PorcentajeBeca, NombreMes, Monto, TipoPago, Estado from Alumno inner join Mensualidad on alumno.RutAlumno = mensualidad.RutAlumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno WHERE Becado = 1 and Estado = 'ATRASADO' and Curso = '" & curso.Text & "' and NombreMes = '" & mes & "'", conn)
                    Else
                        adapter.SelectCommand = New MySqlCommand("SELECT alumno.RutAlumno, NombreCompleto, ApePaterno, Curso, Becado, PorcentajeBeca, NombreMes, Monto, TipoPago, Estado from Alumno inner join Mensualidad on alumno.RutAlumno = mensualidad.RutAlumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno WHERE Becado = 1 and Curso = '" & curso.Text & "' and NombreMes = '" & mes & "'", conn)
                    End If
                End If
            ElseIf AdminMensualidades.CheckNoBecado.Checked = True Then
                If AdminMensualidades.CheckPagado.Checked = True Then
                    adapter.SelectCommand = New MySqlCommand("SELECT alumno.RutAlumno, NombreCompleto, ApePaterno, Curso, Becado, PorcentajeBeca, NombreMes, Monto, TipoPago, Estado from Alumno inner join Mensualidad on alumno.RutAlumno = mensualidad.RutAlumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno WHERE Becado = 0 and Estado = 'PAGADO' and Curso = '" & curso.Text & "' and NombreMes = '" & mes & "'", conn)
                ElseIf AdminMensualidades.CheckAtrasado.Checked = True Then
                    adapter.SelectCommand = New MySqlCommand("SELECT alumno.RutAlumno, NombreCompleto, ApePaterno, Curso, Becado, PorcentajeBeca, NombreMes, Monto, TipoPago, Estado from Alumno inner join Mensualidad on alumno.RutAlumno = mensualidad.RutAlumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno WHERE Becado = 0 and Estado = 'ATRASADO' and Curso = '" & curso.Text & "' and NombreMes = '" & mes & "'", conn)
                Else
                    adapter.SelectCommand = New MySqlCommand("SELECT alumno.RutAlumno, NombreCompleto, ApePaterno, Curso, Becado, PorcentajeBeca, NombreMes, Monto, TipoPago, Estado from Alumno inner join Mensualidad on alumno.RutAlumno = mensualidad.RutAlumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno WHERE Becado = 0 and Curso ='" & curso.Text & "' and NombreMes = '" & mes & "'", conn)
                End If
            ElseIf AdminMensualidades.CheckPagado.Checked = True Then
                adapter.SelectCommand = New MySqlCommand("SELECT alumno.RutAlumno, NombreCompleto, ApePaterno, Curso, Becado, PorcentajeBeca, NombreMes, Monto, TipoPago, Estado from Alumno inner join Mensualidad on alumno.RutAlumno = mensualidad.RutAlumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno WHERE Estado = 'PAGADO' and Curso = '" & curso.Text & "' and NombreMes = '" & mes & "'", conn)
            ElseIf AdminMensualidades.CheckAtrasado.Checked = True Then
                adapter.SelectCommand = New MySqlCommand("SELECT alumno.RutAlumno, NombreCompleto, ApePaterno, Curso, Becado, PorcentajeBeca, NombreMes, Monto, TipoPago, Estado from Alumno inner join Mensualidad on alumno.RutAlumno = mensualidad.RutAlumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno WHERE Estado = 'ATRASADO' and Curso = '" & curso.Text & "' and NombreMes = '" & mes & "'", conn)
            Else
                adapter.SelectCommand = New MySqlCommand("SELECT alumno.RutAlumno, NombreCompleto, ApePaterno, Curso, Becado, PorcentajeBeca, NombreMes, Monto, TipoPago, Estado from Alumno inner join Mensualidad on alumno.RutAlumno = mensualidad.RutAlumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno WHERE Curso = '" & curso.Text & "' and NombreMes = '" & mes & "'", conn)
            End If
        ElseIf AdminMensualidades.CheckBecado.Checked = True Then
            If AdminMensualidades.cbPorcentaje.Text <> "" Then
                If AdminMensualidades.CheckPagado.Checked = True Then
                    adapter.SelectCommand = New MySqlCommand("SELECT alumno.RutAlumno, NombreCompleto, ApePaterno, Curso, Becado, PorcentajeBeca, NombreMes, Monto, TipoPago, Estado from Alumno inner join Mensualidad on alumno.RutAlumno = mensualidad.RutAlumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno WHERE Becado = 1 and Estado = 'PAGADO' and PorcentajeBeca = '" & porcentaje.Text & "' and NombreMes = '" & mes & "'", conn)
                ElseIf AdminMensualidades.CheckAtrasado.Checked = True Then
                    adapter.SelectCommand = New MySqlCommand("SELECT alumno.RutAlumno, NombreCompleto, ApePaterno, Curso, Becado, PorcentajeBeca, NombreMes, Monto, TipoPago, Estado from Alumno inner join Mensualidad on alumno.RutAlumno = mensualidad.RutAlumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno WHERE Becado = 1 and Estado = 'ATRASADO' and PorcentajeBeca = '" & porcentaje.Text & "' and NombreMes = '" & mes & "'", conn)
                Else
                    adapter.SelectCommand = New MySqlCommand("SELECT alumno.RutAlumno, NombreCompleto, ApePaterno, Curso, Becado, PorcentajeBeca, NombreMes, Monto, TipoPago, Estado from Alumno inner join Mensualidad on alumno.RutAlumno = mensualidad.RutAlumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno WHERE Becado = 1 and PorcentajeBeca = '" & porcentaje.Text & "' and NombreMes = '" & mes & "'", conn)
                End If
            Else
                If AdminMensualidades.CheckPagado.Checked = True Then
                    adapter.SelectCommand = New MySqlCommand("SELECT alumno.RutAlumno, NombreCompleto, ApePaterno, Curso, Becado, PorcentajeBeca, NombreMes, Monto, TipoPago, Estado from Alumno inner join Mensualidad on alumno.RutAlumno = mensualidad.RutAlumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno WHERE Becado = 1 and Estado = 'PAGADO' and NombreMes = '" & mes & "'", conn)
                ElseIf AdminMensualidades.CheckAtrasado.Checked = True Then
                    adapter.SelectCommand = New MySqlCommand("SELECT alumno.RutAlumno, NombreCompleto, ApePaterno, Curso, Becado, PorcentajeBeca, NombreMes, Monto, TipoPago, Estado from Alumno inner join Mensualidad on alumno.RutAlumno = mensualidad.RutAlumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno WHERE Becado = 1 and Estado = 'ATRASADO' and NombreMes = '" & mes & "'", conn)
                Else
                    adapter.SelectCommand = New MySqlCommand("SELECT alumno.RutAlumno, NombreCompleto, ApePaterno, Curso, Becado, PorcentajeBeca, NombreMes, Monto, TipoPago, Estado from Alumno inner join Mensualidad on alumno.RutAlumno = mensualidad.RutAlumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno WHERE Becado = 1 and NombreMes = '" & mes & "'", conn)
                End If
            End If
        ElseIf AdminMensualidades.CheckNoBecado.Checked = True Then
            If AdminMensualidades.CheckPagado.Checked = True Then
                adapter.SelectCommand = New MySqlCommand("SELECT alumno.RutAlumno, NombreCompleto, ApePaterno, Curso, Becado, PorcentajeBeca, NombreMes, Monto, TipoPago, Estado from Alumno inner join Mensualidad on alumno.RutAlumno = mensualidad.RutAlumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno WHERE Becado = 0 and Estado = 'PAGADO' and NombreMes = '" & mes & "'", conn)
            ElseIf AdminMensualidades.CheckAtrasado.Checked = True Then
                adapter.SelectCommand = New MySqlCommand("SELECT alumno.RutAlumno, NombreCompleto, ApePaterno, Curso, Becado, PorcentajeBeca, NombreMes, Monto, TipoPago, Estado from Alumno inner join Mensualidad on alumno.RutAlumno = mensualidad.RutAlumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno WHERE Becado = 0 and Estado = 'ATRASADO' and NombreMes = '" & mes & "'", conn)
            Else
                adapter.SelectCommand = New MySqlCommand("SELECT alumno.RutAlumno, NombreCompleto, ApePaterno, Curso, Becado, PorcentajeBeca, NombreMes, Monto, TipoPago, Estado from Alumno inner join Mensualidad on alumno.RutAlumno = mensualidad.RutAlumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno WHERE Becado = 0 and NombreMes = '" & mes & "'", conn)
            End If
        ElseIf AdminMensualidades.CheckPagado.Checked = True Then
            adapter.SelectCommand = New MySqlCommand("SELECT alumno.RutAlumno, NombreCompleto, ApePaterno, Curso, Becado, PorcentajeBeca, NombreMes, Monto, TipoPago, Estado from Alumno inner join Mensualidad on alumno.RutAlumno = mensualidad.RutAlumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno WHERE Estado = 'PAGADO' and NombreMes = '" & mes & "'", conn)
        ElseIf AdminMensualidades.CheckAtrasado.Checked = True Then
            adapter.SelectCommand = New MySqlCommand("SELECT alumno.RutAlumno, NombreCompleto, ApePaterno, Curso, Becado, PorcentajeBeca, NombreMes, Monto, TipoPago, Estado from Alumno inner join Mensualidad on alumno.RutAlumno = mensualidad.RutAlumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno WHERE Estado = 'ATRASADO' and NombreMes = '" & mes & "'", conn)
        Else
            adapter.SelectCommand = New MySqlCommand("SELECT alumno.RutAlumno, NombreCompleto, ApePaterno, Curso, Becado, PorcentajeBeca, NombreMes, Monto, TipoPago, Estado from Alumno inner join Mensualidad on alumno.RutAlumno = mensualidad.RutAlumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno WHERE NombreMes = '" & mes & "'", conn)
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
            adapter.SelectCommand = New MySqlCommand("SELECT * FROM alumno inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idComuna inner join mensualidad on alumno.RutAlumno = mensualidad.RutAlumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join responsable_alumno on alumno.RutAlumno = responsable_alumno.Alumno_RutAlumno WHERE Alumno.RutAlumno = '" & rut & "'", conn)
            adapter.Fill(dataSet)

            DetalleInfoAlumno.txtNumMatri.Text = dataSet.Tables(0).Rows("0")("Matricula_NumMatricula").ToString
            DetalleInfoAlumno.txtRutAlumno.Text = dataSet.Tables(0).Rows("0")("RutAlumno").ToString
            DetalleInfoAlumno.txtNombreAlumno.Text = dataSet.Tables(0).Rows("0")("NombreCompleto").ToString
            DetalleInfoAlumno.txtApePat.Text = dataSet.Tables(0).Rows("0")("ApePaterno").ToString
            DetalleInfoAlumno.txtApeMat.Text = dataSet.Tables(0).Rows("0")("ApeMaterno").ToString
            DetalleInfoAlumno.txtSexo.Text = dataSet.Tables(0).Rows("0")("Sexo").ToString
            DetalleInfoAlumno.txtFechaNac.Text = dataSet.Tables(0).Rows("0")("FechaNac").ToString
            DetalleInfoAlumno.txtEdadAlumno.Text = dataSet.Tables(0).Rows("0")("Edad").ToString
            DetalleInfoAlumno.txtDomicilio.Text = dataSet.Tables(0).Rows("0")("Domicilio").ToString
            DetalleInfoAlumno.txtVilla.Text = dataSet.Tables(0).Rows("0")("SectorVilla").ToString
            DetalleInfoAlumno.txtComuna.Text = dataSet.Tables(0).Rows("0")("Comuna").ToString
            DetalleInfoAlumno.txtFonoAlumno.Text = dataSet.Tables(0).Rows("0")("Telefono").ToString
            DetalleInfoAlumno.txtCursoActual.Text = dataSet.Tables(0).Rows("0")("Curso").ToString
            DetalleInfoAlumno.txtColegioAnterior.Text = dataSet.Tables(0).Rows("0")("ColegioPresedencia").ToString
            DetalleInfoAlumno.txtRepetidos.Text = dataSet.Tables(0).Rows("0")("CursosRepetidos").ToString
            DetalleInfoAlumno.txtHermanos.Text = dataSet.Tables(0).Rows("0")("HermanosEstablecimiento").ToString
            DetalleInfoAlumno.txtCursoHerm.Text = dataSet.Tables(0).Rows("0")("CursosHermanos").ToString
            If dataSet.Tables(0).Rows("0")("Becado").ToString = True Then
                DetalleInfoAlumno.txtBeca.Text = "Becado"
            Else
                DetalleInfoAlumno.txtBeca.Text = "No Becado"
            End If
            DetalleInfoAlumno.txtPorcentaje.Text = dataSet.Tables(0).Rows("0")("PorcentajeBeca").ToString
            DetalleInfoAlumno.txtTipoPago.Text = dataSet.Tables(0).Rows("0")("TipoPago").ToString
            If dataSet.Tables(0).Rows("0")("AlumnoViveCon").ToString = "Otros" Then
                DetalleInfoAlumno.txtViveOtros.Text = dataSet.Tables(0).Rows("0")("ViveEspecifico").ToString
                DetalleInfoAlumno.txtViveCon.Text = dataSet.Tables(0).Rows("0")("AlumnoViveCon").ToString
            Else
                DetalleInfoAlumno.txtViveCon.Text = dataSet.Tables(0).Rows("0")("AlumnoViveCon").ToString()
            End If
            DetalleInfoAlumno.txtNumHijos.Text = dataSet.Tables(0).Rows("0")("NumHijosFamilia").ToString()
            DetalleInfoAlumno.txtLugarHijos.Text = dataSet.Tables(0).Rows("0")("LugarOcupacionHijos").ToString()
            DetalleInfoAlumno.txtGrupoFam.Text = dataSet.Tables(0).Rows("0")("GrupoFamiliarComponen").ToString()
            DetalleInfoAlumno.txtAntecedentes.Text = dataSet.Tables(0).Rows("0")("AntecedentesMedicos").ToString()
            DetalleInfoAlumno.txtServSalud.Text = dataSet.Tables(0).Rows("0")("PlanSalud").ToString()
            DetalleInfoAlumno.txtSeguros.Text = dataSet.Tables(0).Rows("0")("Seguros").ToString()
            DetalleInfoAlumno.txtOtrosServ.Text = dataSet.Tables(0).Rows("0")("OtrosServicios").ToString()

            dataSet.Clear()
            adapter.SelectCommand = New MySqlCommand("SELECT count(*) as total FROM responsable inner join responsable_alumno ON responsable.RutResponsable = responsable_alumno.Responsable_RutResponsable inner join tipo_responsable ON responsable_alumno.Tipo_responsable_idTipo_responsable = tipo_responsable.idTipo_responsable WHERE Alumno_RutAlumno = '" & rut & "'", conn)
            adapter.Fill(dataSet)
            total = dataSet.Tables(0).Rows("0")("total").ToString()
            If total <> 0 Then
                For i = 1 To total
                    adapter.SelectCommand = New MySqlCommand("SELECT * FROM responsable inner join responsable_alumno ON responsable.RutResponsable = responsable_alumno.Responsable_RutResponsable inner join tipo_responsable ON responsable_alumno.Tipo_responsable_idTipo_responsable = tipo_responsable.idTipo_responsable inner join direccion ON responsable.Direccion_idDireccion = direccion.idDireccion inner join telefono ON responsable.Telefono_idTelefono = telefono.idTelefono WHERE Alumno_RutAlumno = '" & rut & "'", conn)
                    adapter.Fill(dataSet)
                    If dataSet.Tables(0).Rows(i)("Tipo_responsable").ToString = "tutor economico" Then
                        DetalleInfoAlumno.txtRutTutor.Text = dataSet.Tables(0).Rows(i)("RutResponsable").ToString
                        DetalleInfoAlumno.txtNombreTutor.Text = dataSet.Tables(0).Rows(i)("NombreCompleto").ToString
                        DetalleInfoAlumno.txtFonoTrabTutor.Text = dataSet.Tables(0).Rows(i)("NumTrabajo").ToString
                        DetalleInfoAlumno.txtLugarTrabajoTutor.Text = dataSet.Tables(0).Rows(i)("Trabajo").ToString
                        DetalleInfoAlumno.txtProfesionTutor.Text = dataSet.Tables(0).Rows(i)("Profesion").ToString
                        DetalleInfoAlumno.txtOcupacionTutor.Text = dataSet.Tables(0).Rows(i)("Cargo").ToString
                        DetalleInfoAlumno.txtDomicilioTutor.Text = dataSet.Tables(0).Rows(i)("DireccionParticular").ToString
                        DetalleInfoAlumno.txtFonoTutor.Text = dataSet.Tables(0).Rows(i)("Num1").ToString
                        DetalleInfoAlumno.txtFono2Tutor.Text = dataSet.Tables(0).Rows(i)("Num2").ToString
                        DetalleInfoAlumno.txtTutorEco.Text = dataSet.Tables(0).Rows(i)("NombreCompleto").ToString
                        If dataSet.Tables(0).Rows(i)("Apoderado").ToString() = True Then
                            DetalleInfoAlumno.txtApoTitular.Text = dataSet.Tables(0).Rows(i)("NombreCompleto").ToString
                        ElseIf dataSet.Tables(0).Rows(i)("ApoderadoSuplente").ToString() = True Then
                            DetalleInfoAlumno.txtApoSup.Text = dataSet.Tables(0).Rows(i)("NombreCompleto").ToString
                        End If
                    ElseIf dataSet.Tables(0).Rows(i)("Tipo_responsable").ToString = "padre" Then
                        DetalleInfoAlumno.txtRutPadre.Text = dataSet.Tables(0).Rows(i)("RutResponsable").ToString
                        DetalleInfoAlumno.txtNombrePadre.Text = dataSet.Tables(0).Rows(i)("NombreCompleto").ToString
                        DetalleInfoAlumno.txtEdadPadre.Text = dataSet.Tables(0).Rows(i)("EdadResp").ToString
                        DetalleInfoAlumno.txtEstudiosPadre.Text = dataSet.Tables(0).Rows(i)("EstudiosCompletados").ToString
                        DetalleInfoAlumno.txtTrabajoPadre.Text = dataSet.Tables(0).Rows(i)("Trabajo").ToString
                        DetalleInfoAlumno.txtCargoPadre.Text = dataSet.Tables(0).Rows(i)("Cargo").ToString
                        DetalleInfoAlumno.txtDireccionPadre.Text = dataSet.Tables(0).Rows(i)("DireccionTrabajo").ToString
                        DetalleInfoAlumno.txtFonoPadre.Text = dataSet.Tables(0).Rows(i)("Num1").ToString
                        DetalleInfoAlumno.txtCorreoPadre.Text = dataSet.Tables(0).Rows(i)("Correoelectronico").ToString
                        If dataSet.Tables(0).Rows(i)("Apoderado").ToString() = True Then
                            DetalleInfoAlumno.txtApoTitular.Text = dataSet.Tables(0).Rows(i)("NombreCompleto").ToString
                        ElseIf dataSet.Tables(0).Rows(i)("ApoderadoSuplente").ToString() = True Then
                            DetalleInfoAlumno.txtApoSup.Text = dataSet.Tables(0).Rows(i)("NombreCompleto").ToString
                        End If
                    ElseIf dataSet.Tables(0).Rows(i)("Tipo_responsable").ToString = "madre" Then
                        DetalleInfoAlumno.txtRutMadre.Text = dataSet.Tables(0).Rows(i)("RutResponsable").ToString
                        DetalleInfoAlumno.txtNombreMadre.Text = dataSet.Tables(0).Rows(i)("NombreCompleto").ToString
                        DetalleInfoAlumno.txtEdadMadre.Text = dataSet.Tables(0).Rows(i)("EdadResp").ToString
                        DetalleInfoAlumno.txtEstudiosMadre.Text = dataSet.Tables(0).Rows(i)("EstudiosCompletados").ToString
                        DetalleInfoAlumno.txtTrabajoMadre.Text = dataSet.Tables(0).Rows(i)("Trabajo").ToString
                        DetalleInfoAlumno.txtCargoMadre.Text = dataSet.Tables(0).Rows(i)("Cargo").ToString
                        DetalleInfoAlumno.txtDireccionMadre.Text = dataSet.Tables(0).Rows(i)("DireccionTrabajo").ToString
                        DetalleInfoAlumno.txtFonoMadre.Text = dataSet.Tables(0).Rows(i)("Num1").ToString
                        DetalleInfoAlumno.txtCorreoMadre.Text = dataSet.Tables(0).Rows(i)("Correoelectronico").ToString
                        If dataSet.Tables(0).Rows(i)("Apoderado").ToString() = True Then
                            DetalleInfoAlumno.txtApoTitular.Text = dataSet.Tables(0).Rows(i)("NombreCompleto").ToString
                        ElseIf dataSet.Tables(0).Rows(i)("ApoderadoSuplente").ToString() = True Then
                            DetalleInfoAlumno.txtApoSup.Text = dataSet.Tables(0).Rows(i)("NombreCompleto").ToString
                        End If
                    ElseIf dataSet.Tables(0).Rows(i)("Tipo_responsable").ToString = "otro" Then
                        DetalleInfoAlumno.txtRutOtro.Text = dataSet.Tables(0).Rows(i)("RutResponsable").ToString
                        DetalleInfoAlumno.txtNombreOtro.Text = dataSet.Tables(0).Rows(i)("NombreCompleto").ToStrin
                        DetalleInfoAlumno.txtDireccionOtro.Text = dataSet.Tables(0).Rows(i)("DireccionParticular").ToString
                        DetalleInfoAlumno.txtFonoOtro.Text = dataSet.Tables(0).Rows(i)("Num1").ToString
                        If dataSet.Tables(0).Rows(i)("Apoderado").ToString() = True Then
                            DetalleInfoAlumno.txtApoTitular.Text = dataSet.Tables(0).Rows(i)("NombreCompleto").ToString
                        ElseIf dataSet.Tables(0).Rows(i)("ApoderadoSuplente").ToString() = True Then
                            DetalleInfoAlumno.txtApoSup.Text = dataSet.Tables(0).Rows(i)("NombreCompleto").ToString
                        End If
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
                If total = "1" Then
                    DetalleInfoAlumno.lblNombreContacto1.Text = dataSet.Tables(0).Rows(i)("NombreContacto").ToString
                    DetalleInfoAlumno.lblFonoContacto1.Text = dataSet.Tables(0).Rows(i)("Numero").ToString
                ElseIf total = "2" Then
                    If i = "1" Then
                        DetalleInfoAlumno.lblNombreContacto1.Text = dataSet.Tables(0).Rows(i)("NombreContacto").ToString
                        DetalleInfoAlumno.lblFonoContacto1.Text = dataSet.Tables(0).Rows(i)("Numero").ToString
                    ElseIf i = "2" Then
                        DetalleInfoAlumno.lblNombreContacto2.Text = dataSet.Tables(0).Rows(i)("NombreContacto").ToString
                        DetalleInfoAlumno.lblFonoContacto2.Text = dataSet.Tables(0).Rows(i)("Numero").ToString
                    End If
                ElseIf total = "3" Then
                    If i = "1" Then
                        DetalleInfoAlumno.lblNombreContacto1.Text = dataSet.Tables(0).Rows(i)("NombreContacto").ToString
                        DetalleInfoAlumno.lblFonoContacto1.Text = dataSet.Tables(0).Rows(i)("Numero").ToString
                    ElseIf i = "2" Then
                        DetalleInfoAlumno.lblNombreContacto2.Text = dataSet.Tables(0).Rows(i)("NombreContacto").ToString
                        DetalleInfoAlumno.lblFonoContacto2.Text = dataSet.Tables(0).Rows(i)("Numero").ToString
                    ElseIf i = "3" Then
                        DetalleInfoAlumno.lblNombreContacto3.Text = dataSet.Tables(0).Rows(i)("NombreContacto").ToString
                        DetalleInfoAlumno.lblFonoContacto3.Text = dataSet.Tables(0).Rows(i)("Numero").ToString
                    End If
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

    Public Function insertarPadre(ByRef nombrePadre As String, ByRef rutPadre As String, ByRef edadPadre As Integer, _
                                   ByRef estudiosPadre As ComboBox, ByRef trabajaEnPadre As String, ByRef telefonoPadre As String, _
                                   ByRef CargoPadre As String, ByRef direccionPadre As String, ByRef correoPadre As String, ByRef cursomax As String) As Boolean


        Try

            Dim consultaPadre As String = "INSERT INTO `bd_echaurren`.`telefono` (`NumTrabajo`) VALUES ('" & telefonoPadre & "');"
            Dim consultaPadre2 As String = "INSERT INTO `bd_echaurren`.`responsable` (`RutResponsable`, `NombreCompleto`, `EdadResp`, `EstudiosCompletados`, `CursoMax`, `Correoelectronico`, `Trabajo`, `Cargo`, `Telefono_idTelefono`) VALUES ('" & rutPadre & "', '" & nombrePadre & "', '" & edadPadre & "', '" & estudiosPadre.Text & "', '" & cursomax & "', '" & correoPadre & "', '" & trabajaEnPadre & "', '" & CargoPadre & "', last_insert_id());"
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

    Public Function insertarMadre(ByRef nombreMadre As String, ByRef rutMadre As String, ByRef edadMadre As Integer, _
                                   ByRef estudiosMadre As ComboBox, ByRef trabajaEnMadre As String, ByRef telefonoMadre As String, _
                                   ByRef CargoMadre As String, ByRef direccionMadre As String, ByRef correoMadre As String, ByRef cursomax As String) As Boolean


        Try
            Dim consultaMadre As String = "INSERT INTO `bd_echaurren`.`telefono` (`NumTrabajo`) VALUES ('" & telefonoMadre & "');"
            Dim consultaMadre2 As String = "INSERT INTO `bd_echaurren`.`responsable` (`RutResponsable`, `NombreCompleto`, `EdadResp`, `EstudiosCompletados`, `CursoMax`, `Correoelectronico`, `Trabajo`, `Cargo`, `Telefono_idTelefono`) VALUES ('" & rutMadre & "', '" & nombreMadre & "', '" & edadMadre & "', '" & estudiosMadre.Text & "', '" & cursomax & "', '" & correoMadre & "', '" & trabajaEnMadre & "', '" & CargoMadre & "', last_insert_id());"
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
                                               ByRef direccionTrab As String, ByRef edad As Integer, ByRef estudiosCompl As ComboBox, _
                                               ByRef Correo As String, ByRef profesion As String, ByRef trabajo As String, _
                                               ByRef cargo As String) As Boolean

        Try
            Dim consulta As String = "INSERT INTO `bd_echaurren`.`telefono` (`Num1`, `Num2`, `NumTrabajo`) VALUES ('" & telefono1 & "', '" & telefono2 & "', '" & telefonoTrabajo & "');"
            Dim consulta1 As String = "INSERT INTO `bd_echaurren`.`responsable` (`RutResponsable`, `NombreCompleto`, `EdadResp`, `EstudiosCompletados`, `Correoelectronico`, `Profesion`, `Trabajo`, `Cargo`, `Telefono_idTelefono`) VALUES ('" & rutResponsable & "', '" & nombreComleto & "', '" & edad & "', '" & estudiosCompl.Text & "', '" & Correo & "', '" & profesion & "', '" & trabajo & "', '" & cargo & "', last_insert_id());"
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
                                           ByRef apoderado As Integer, ByRef apodSuplente As Integer, ByRef numMatri As String) As Boolean

        Try
            Dim consulta As String = "INSERT INTO `bd_echaurren`.`responsable_alumno` (`Responsable_RutResponsable`, `Alumno_RutAlumno`, `Tipo_responsable_idTipo_responsable`, `Apoderado`, `ApoderadoSuplente`, `Matricula_NumMatricula`) VALUES ('" & rutResponsable & "', '" & rutAlumno & "', '" & tipoResp & "', '" & apoderado & "', '" & apodSuplente & "', '" & numMatri & "');"
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
                                           ByRef OtroTutor As String, ByRef numMatri As String) As Boolean

        Try
            Dim consulta As String = "INSERT INTO `bd_echaurren`.`responsable_alumno` (`Responsable_RutResponsable`, `Alumno_RutAlumno`, `Tipo_responsable_idTipo_responsable`, `Apoderado`, `ApoderadoSuplente`, `Otro_tutor`, `Matricula_NumMatricula`) VALUES ('" & rutResponsable & "', '" & rutAlumno & "', '" & tipoResp & "', '" & apoderado & "', '" & apodSuplente & "', '" & OtroTutor & "', '" & numMatri & "');"
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
                                     ByRef apodSuplente As Integer, ByRef nombreOtroResp As String, ByRef numMatri As String) As Boolean

        Try

            Dim tipoResp As String = "tr4"
            Dim consulta As String = "INSERT INTO `bd_echaurren`.`responsable` (`RutResponsable`, `NombreCompleto`) VALUES ('" & rutOtroApod & "', '" & nombreOtroResp & "');"
            Dim consulta1 As String = "INSERT INTO `bd_echaurren`.`responsable_alumno` (`Responsable_RutResponsable`, `Alumno_RutAlumno`, `Tipo_responsable_idTipo_responsable`, `Apoderado`, `ApoderadoSuplente`, `Matricula_NumMatricula`) VALUES ('" & rutOtroApod & "', '" & rutAlumno & "', '" & tipoResp & "', '" & apoderado & "', '" & apodSuplente & "', '" & numMatri & "');"

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
        FormAlumnosMatriculados.DataGridView1.Columns(11).HeaderText = "Curso"
        FormAlumnosMatriculados.DataGridView1.Columns(12).HeaderText = "Becado"
        FormAlumnosMatriculados.DataGridView1.Columns(13).HeaderText = "Porcentaje de beca"
        FormAlumnosMatriculados.DataGridView1.Columns(14).HeaderText = "Hermanos en establecimiento"
        FormAlumnosMatriculados.DataGridView1.Columns(15).HeaderText = "Convivencia de alumno"
        FormAlumnosMatriculados.DataGridView1.Columns(16).HeaderText = "Antecentes Medicos"
        FormAlumnosMatriculados.DataGridView1.Columns(17).HeaderText = "Numero de matricula"
        FormAlumnosMatriculados.DataGridView1.Columns(18).HeaderText = "Fecha de matricula"



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


    Public Function AutollenarFormulario(ByRef RutAlumno As String, ByRef conexion As MySqlConnection)
        Dim varDia As Date
        Try
            Dim consulta As String = "select * from alumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join comuna on alumno.Comuna_idComuna = comuna.idComuna inner join fichaalumno on alumno.fichaalumno_idFichaalumno = fichaalumno.idFichaalumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud inner join contacto_emergencia ON alumno.RutAlumno = contacto_emergencia.Alumno_RutAlumno inner join responsable inner join responsable_alumno on responsable.RutResponsable = responsable_alumno.Responsable_RutResponsable inner join telefono on responsable.Telefono_idTelefono = telefono.idTelefono inner join direccion on responsable.Direccion_idDireccion = direccion.idDireccion inner join mensualidad on alumno.RutAlumno = mensualidad.RutAlumno where alumno.RutAlumno = '" & RutAlumno & "'"
            Dim _dataAdapter As New MySqlDataAdapter(consulta, conexion)
            Dim _dataSet As New DataSet

            _dataAdapter.Fill(_dataSet)
            FormularioMatricula.txtNumMatri.Text = _dataSet.Tables(0).Rows("0")("Matricula_NumMatricula").ToString
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
            FormularioMatricula.comboCurso.Text = _dataSet.Tables(0).Rows("0")("Curso").ToString
            FormularioMatricula.comboComuna.Text = _dataSet.Tables(0).Rows("0")("Comuna").ToString
            FormularioMatricula.txtColegioPrese.Text = _dataSet.Tables(0).Rows("0")("ColegioPresedencia").ToString
            FormularioMatricula.txtCursosRepetidos.Text = _dataSet.Tables(0).Rows("0")("CursosRepetidos").ToString
            If _dataSet.Tables(0).Rows("0")("HermanosEstablecimiento").ToString = "NULL" Then
                FormularioMatricula.radioHermanosNo.Checked = True
            Else
                FormularioMatricula.radioHermanosSi.Checked = True
                FormularioMatricula.txtHermanosCursos.Text = _dataSet.Tables(0).Rows("0")("CursosHermanos").ToString
            End If
            If _dataSet.Tables(0).Rows("0")("AlumnoViveCon").ToString = "Otros" Then
                FormularioMatricula.cbViveCon.Text = "Otros"
                FormularioMatricula.txtViveConOtros.Text = _dataSet.Tables(0).Rows("0")("ViveEspecifico").ToString
            Else
                FormularioMatricula.cbViveCon.Text = _dataSet.Tables(0).Rows("0")("AlumnoViveCon").ToString
            End If
            FormularioMatricula.txtNumHijos.Text = _dataSet.Tables(0).Rows("0")("NumHijosFamilia").ToString
            FormularioMatricula.txtLugarHijos.Text = _dataSet.Tables(0).Rows("0")("LugarOcupacionHijos").ToString
            FormularioMatricula.txtGrupoFamiliar.Text = _dataSet.Tables(0).Rows("0")("GrupoFamiliarComponen").ToString
            FormularioMatricula.txtAntecedentesMed.Text = _dataSet.Tables(0).Rows("0")("AntecedentesMedicos").ToString
            FormularioMatricula.CheckBox1.Checked = _dataSet.Tables(0).Rows("0")("Becado")
            If _dataSet.Tables(0).Rows("0")("PlanSalud") = "otro" Then
                FormularioMatricula.comboServSalud.Text = "otro"
                FormularioMatricula.txtOtrosServicios.Text = _dataSet.Tables(0).Rows("0")("OtrosServicios").ToString
                FormularioMatricula.txtSeguros.Text = _dataSet.Tables(0).Rows("0")("Seguros").ToString
            Else
                FormularioMatricula.comboServSalud.Text = _dataSet.Tables(0).Rows("0")("PlanSalud").ToString
                FormularioMatricula.txtSeguros.Text = _dataSet.Tables(0).Rows("0")("Seguros").ToString
            End If

            _dataSet.Clear()
            _dataAdapter.SelectCommand = New MySqlCommand("SELECT count(*) as total FROM contacto_emergencia WHERE Alumno_RutAlumno = '" & RutAlumno & "'", conexion)
            _dataAdapter.Fill(_dataSet)
            Dim total As Integer = _dataSet.Tables(0).Rows("0")("total").ToString()
            If total <> 0 Then
                For i = 1 To total
                    _dataAdapter.SelectCommand = New MySqlCommand("SELECT idContacto_emergencia, NombreContacto, Numero FROM contacto_emergencia WHERE Alumno_RutAlumno = '" & RutAlumno & "'", conexion)
                    _dataAdapter.Fill(_dataSet)

                    If total = 1 Then
                        FormularioMatricula.ComboBox1.Text = "1 Contacto"
                        FormularioMatricula.txtNombreContacto.Text = _dataSet.Tables(0).Rows(i)("NombreContacto").ToString
                        FormularioMatricula.txtNumContacto.Text = _dataSet.Tables(0).Rows(i)("Numero").ToString
                        FormularioMatricula.varidCont1 = _dataSet.Tables(0).Rows(i)("idContacto_emergencia").ToString
                    ElseIf total = 2 Then
                        FormularioMatricula.ComboBox1.Text = "2 Contactos"
                        If i = "1" Then
                            FormularioMatricula.txtNombreContacto.Text = _dataSet.Tables(0).Rows(i)("NombreContacto").ToString
                            FormularioMatricula.txtNumContacto.Text = _dataSet.Tables(0).Rows(i)("Numero").ToString
                            FormularioMatricula.varidCont1 = _dataSet.Tables(0).Rows(i)("idContacto_emergencia").ToString
                        ElseIf i = "2" Then
                            FormularioMatricula.txtNombreContacto2.Text = _dataSet.Tables(0).Rows(i)("NombreContacto").ToString
                            FormularioMatricula.txtNumContacto2.Text = _dataSet.Tables(0).Rows(i)("Numero").ToString
                            FormularioMatricula.varidCont2 = _dataSet.Tables(0).Rows(i)("idContacto_emergencia").ToString
                        End If
                    ElseIf total = 3 Then
                        FormularioMatricula.ComboBox1.Text = "3 Contactos"
                        If i = "1" Then
                            FormularioMatricula.txtNombreContacto.Text = _dataSet.Tables(0).Rows(i)("NombreContacto").ToString
                            FormularioMatricula.txtNumContacto.Text = _dataSet.Tables(0).Rows(i)("Numero").ToString
                            FormularioMatricula.varidCont1 = _dataSet.Tables(0).Rows(i)("idContacto_emergencia").ToString
                        ElseIf i = "2" Then
                            FormularioMatricula.txtNombreContacto2.Text = _dataSet.Tables(0).Rows(i)("NombreContacto").ToString
                            FormularioMatricula.txtNumContacto2.Text = _dataSet.Tables(0).Rows(i)("Numero").ToString
                            FormularioMatricula.varidCont2 = _dataSet.Tables(0).Rows(i)("idContacto_emergencia").ToString
                        ElseIf i = "3" Then
                            FormularioMatricula.txtNombreContacto3.Text = _dataSet.Tables(0).Rows(i)("NombreContacto").ToString
                            FormularioMatricula.txtNumContacto3.Text = _dataSet.Tables(0).Rows(i)("Numero").ToString
                            FormularioMatricula.varidCont3 = _dataSet.Tables(0).Rows(i)("idContacto_emergencia").ToString
                        End If
                    Else
                        MsgBox("No se especificaron Contactos de Emergencia, trate de ingresar al menos uno.")
                    End If

                Next i
            End If

            _dataSet.Clear()
            _dataAdapter.SelectCommand = New MySqlCommand("SELECT count(*) as total FROM responsable inner join responsable_alumno ON responsable.RutResponsable = responsable_alumno.Responsable_RutResponsable inner join tipo_responsable ON responsable_alumno.Tipo_responsable_idTipo_responsable = tipo_responsable.idTipo_responsable WHERE Alumno_RutAlumno = '" & RutAlumno & "'", conexion)
            _dataAdapter.Fill(_dataSet)
            total = _dataSet.Tables(0).Rows("0")("total").ToString()
            If total <> 0 Then
                For i = 1 To total
                    _dataAdapter.SelectCommand = New MySqlCommand("SELECT * FROM responsable inner join responsable_alumno ON responsable.RutResponsable = responsable_alumno.Responsable_RutResponsable inner join tipo_responsable ON responsable_alumno.Tipo_responsable_idTipo_responsable = tipo_responsable.idTipo_responsable inner join direccion ON responsable.Direccion_idDireccion = direccion.idDireccion inner join telefono ON responsable.Telefono_idTelefono = telefono.idTelefono WHERE Alumno_RutAlumno = '" & RutAlumno & "'", conexion)
                    _dataAdapter.Fill(_dataSet)

                    If _dataSet.Tables(0).Rows(i)("Tipo_responsable").ToString = "tutor economico" Then
                        FormularioMatricula.txtRut.Text = _dataSet.Tables(0).Rows(i)("RutResponsable").ToString
                        FormularioMatricula.txtNombreTutor.Text = _dataSet.Tables(0).Rows(i)("NombreCompleto").ToString
                        FormularioMatricula.txtTelefonoTrabajo.Text = _dataSet.Tables(0).Rows(i)("NumTrabajo").ToString
                        FormularioMatricula.txtLugarDeTrabajo.Text = _dataSet.Tables(0).Rows(i)("Trabajo").ToString
                        FormularioMatricula.txtProfesion.Text = _dataSet.Tables(0).Rows(i)("Profesion").ToString
                        FormularioMatricula.txtOcupacionAct.Text = _dataSet.Tables(0).Rows(i)("Cargo").ToString
                        FormularioMatricula.txtDomicilio.Text = _dataSet.Tables(0).Rows(i)("DireccionParticular").ToString
                        FormularioMatricula.txtTelefonoPart.Text = _dataSet.Tables(0).Rows(i)("Num1").ToString
                        FormularioMatricula.txtTelefonoPart2.Text = _dataSet.Tables(0).Rows(i)("Num2").ToString
                        FormularioMatricula.txtOtro.Text = _dataSet.Tables(0).Rows(i)("Otro_tutor").ToString
                        If FormularioMatricula.txtOtro.Text <> "" Then
                            FormularioMatricula.RadioButton14.Checked = True
                        End If
                        If FormularioMatricula.txtRut.Text = FormularioMatricula.txtRutPadre.Text Then
                            FormularioMatricula.RadioButton9.Checked = True
                        ElseIf FormularioMatricula.txtRut.Text = FormularioMatricula.txtRutMadre.Text Then
                            FormularioMatricula.RadioButton13.Checked = True
                        End If
                    ElseIf _dataSet.Tables(0).Rows(i)("Tipo_responsable").ToString = "padre" Then
                        FormularioMatricula.txtNombrePadre.Text = _dataSet.Tables(0).Rows(i)("NombreCompleto").ToString
                        FormularioMatricula.txtRutPadre.Text = _dataSet.Tables(0).Rows(i)("RutResponsable").ToString
                        FormularioMatricula.txtEdadPadre.Text = _dataSet.Tables(0).Rows(i)("EdadResp").ToString
                        FormularioMatricula.cbEstudiosPadre.Text = _dataSet.Tables(0).Rows(i)("EstudiosCompletados").ToString
                        FormularioMatricula.txtEstudiosPadre.Text = _dataSet.Tables(0).Rows(i)("CursoMax").ToString
                        FormularioMatricula.txtTrabajaenPadre.Text = _dataSet.Tables(0).Rows(i)("Trabajo").ToString
                        FormularioMatricula.txtCargoPadre.Text = _dataSet.Tables(0).Rows(i)("Cargo").ToString
                        FormularioMatricula.txtTelefonoPadre.Text = _dataSet.Tables(0).Rows(i)("NumTrabajo").ToString
                        FormularioMatricula.txtDireccionPadre.Text = _dataSet.Tables(0).Rows(i)("DireccionTrabajo").ToString
                        FormularioMatricula.txtCorreoPadre.Text = _dataSet.Tables(0).Rows(i)("Correoelectronico").ToString
                        If _dataSet.Tables(0).Rows(i)("Apoderado").ToString = True Then
                            FormularioMatricula.txtNombreApoderado.Text = _dataSet.Tables(0).Rows(i)("NombreCompleto").ToString
                            FormularioMatricula.txtRutOtroApod.Text = _dataSet.Tables(0).Rows(i)("RutResponsable").ToString
                            FormularioMatricula.cbApoderado.Text = "Padre"
                        ElseIf _dataSet.Tables(0).Rows(i)("ApoderadoSuplente").ToString = True Then
                            FormularioMatricula.txtNombreApodSuplent.Text = _dataSet.Tables(0).Rows(i)("NombreCompleto").ToString
                            FormularioMatricula.txtRutOtroApodSuple.Text = _dataSet.Tables(0).Rows(i)("RutResponsable").ToString
                            FormularioMatricula.cbApoSuplente.Text = "Padre"
                        End If
                        FormularioMatricula.checkpadre.Checked = True
                    ElseIf _dataSet.Tables(0).Rows(i)("Tipo_responsable").ToString = "madre" Then
                        FormularioMatricula.txtNombreMadre.Text = _dataSet.Tables(0).Rows(i)("NombreCompleto").ToString
                        FormularioMatricula.txtRutMadre.Text = _dataSet.Tables(0).Rows(i)("RutResponsable").ToString
                        FormularioMatricula.txtEdadMadre.Text = _dataSet.Tables(0).Rows(i)("EdadResp").ToString
                        FormularioMatricula.cbEstudiosMadre.Text = _dataSet.Tables(0).Rows(i)("EstudiosCompletados").ToString
                        FormularioMatricula.txtEstudiosMadre.Text = _dataSet.Tables(0).Rows(i)("CursoMax").ToString
                        FormularioMatricula.txtTrabajaenMadre.Text = _dataSet.Tables(0).Rows(i)("Trabajo").ToString
                        FormularioMatricula.txtCargoMadre.Text = _dataSet.Tables(0).Rows(i)("Cargo").ToString
                        FormularioMatricula.txtTelefonoMadre.Text = _dataSet.Tables(0).Rows(i)("NumTrabajo").ToString
                        FormularioMatricula.txtDireccionMadre.Text = _dataSet.Tables(0).Rows(i)("DireccionTrabajo").ToString
                        FormularioMatricula.txtCorreoMadre.Text = _dataSet.Tables(0).Rows(i)("Correoelectronico").ToString
                        If _dataSet.Tables(0).Rows(i)("Apoderado").ToString = True Then
                            FormularioMatricula.txtNombreApoderado.Text = _dataSet.Tables(0).Rows(i)("NombreCompleto").ToString
                            FormularioMatricula.txtRutOtroApod.Text = _dataSet.Tables(0).Rows(i)("RutResponsable").ToString
                            FormularioMatricula.cbApoderado.Text = "Madre"
                        ElseIf _dataSet.Tables(0).Rows(i)("ApoderadoSuplente").ToString = True Then
                            FormularioMatricula.txtNombreApodSuplent.Text = _dataSet.Tables(0).Rows(i)("NombreCompleto").ToString
                            FormularioMatricula.txtRutOtroApodSuple.Text = _dataSet.Tables(0).Rows(i)("RutResponsable").ToString
                            FormularioMatricula.cbApoSuplente.Text = "Madre"
                        End If
                        FormularioMatricula.checkmadre.Checked = True
                    ElseIf _dataSet.Tables(0).Rows(i)("Tipo_responsable").ToString = "otro" Then
                        If _dataSet.Tables(0).Rows(i)("Apoderado").ToString = True Then
                            FormularioMatricula.txtNombreApoderado.Text = _dataSet.Tables(0).Rows(i)("NombreCompleto").ToString
                            FormularioMatricula.txtRutOtroApod.Text = _dataSet.Tables(0).Rows(i)("RutResponsable").ToString
                            FormularioMatricula.cbApoSuplente.Text = "Otro"
                        ElseIf _dataSet.Tables(0).Rows(i)("ApoderadoSuplente").ToString = True Then
                            FormularioMatricula.txtNombreApodSuplent.Text = _dataSet.Tables(0).Rows(i)("NombreCompleto").ToString
                            FormularioMatricula.txtRutOtroApodSuple.Text = _dataSet.Tables(0).Rows(i)("RutResponsable").ToString
                            FormularioMatricula.cbApoSuplente.Text = "Otro"
                        End If
                    End If

                Next i
            End If

                    _dataSet.Clear()
                    _dataAdapter.SelectCommand = New MySqlCommand("SELECT count(*) as total FROM mensualidad WHERE RutAlumno = '" & RutAlumno & "'", conexion)
                    _dataAdapter.Fill(_dataSet)
                    total = _dataSet.Tables(0).Rows("0")("total").ToString()
                    If total <> 0 Then
                        For i = 1 To total
                    _dataAdapter.SelectCommand = New MySqlCommand("SELECT * FROM mensualidad WHERE RutAlumno = '" & RutAlumno & "'", conexion)
                            _dataAdapter.Fill(_dataSet)

                    FormularioMatricula.cbbTipoPago.Text = _dataSet.Tables(0).Rows(i)("TipoPago").ToString
                    FormularioMatricula.txtMontoAnual.Text = _dataSet.Tables(0).Rows(i)("MontoTotalAnual").ToString
                    FormularioMatricula.txtNombreTitular.Text = _dataSet.Tables(0).Rows(i)("NombreTitular").ToString
                    FormularioMatricula.txtNombreBanco.Text = _dataSet.Tables(0).Rows(i)("NombreBanco").ToString
                    FormularioMatricula.txtCtaCorriente.Text = _dataSet.Tables(0).Rows(i)("NumCtaCorriente").ToString

                            If _dataSet.Tables(0).Rows(i)("NombreMes").ToString = "MARZO" Then
                        FormularioMatricula.txtMontoMarzo.Text = _dataSet.Tables(0).Rows(i)("Monto").ToString
                        FormularioMatricula.txtDocMarzo.Text = _dataSet.Tables(0).Rows(i)("NumDocumento").ToString
                                varDia = _dataSet.Tables(0).Rows(i)("FechaPago").ToString
                                FormularioMatricula.cbbDiaMarzo.Text = varDia.Day
                            ElseIf _dataSet.Tables(0).Rows(i)("NombreMes").ToString = "ABRIL" Then
                        FormularioMatricula.txtMontoAbril.Text = _dataSet.Tables(0).Rows(i)("Monto").ToString
                        FormularioMatricula.txtDocAbril.Text = _dataSet.Tables(0).Rows(i)("NumDocumento").ToString
                                varDia = _dataSet.Tables(0).Rows(i)("FechaPago").ToString
                                FormularioMatricula.cbbDiaAbril.Text = varDia.Day
                            ElseIf _dataSet.Tables(0).Rows(i)("NombreMes").ToString = "MAYO" Then
                        FormularioMatricula.txtMontoMayo.Text = _dataSet.Tables(0).Rows(i)("Monto").ToString
                        FormularioMatricula.txtDocMayo.Text = _dataSet.Tables(0).Rows(i)("NumDocumento").ToString
                                varDia = _dataSet.Tables(0).Rows(i)("FechaPago").ToString
                                FormularioMatricula.cbbDiaMayo.Text = varDia.Day
                            ElseIf _dataSet.Tables(0).Rows(i)("NombreMes").ToString = "JUNIO" Then
                        FormularioMatricula.txtMontoJunio.Text = _dataSet.Tables(0).Rows(i)("Monto").ToString
                        FormularioMatricula.txtDocJunio.Text = _dataSet.Tables(0).Rows(i)("NumDocumento").ToString
                                varDia = _dataSet.Tables(0).Rows(i)("FechaPago").ToString
                                FormularioMatricula.cbbDiaJunio.Text = varDia.Day
                            ElseIf _dataSet.Tables(0).Rows(i)("NombreMes").ToString = "JULIO" Then
                        FormularioMatricula.txtMontoJulio.Text = _dataSet.Tables(0).Rows(i)("Monto").ToString
                        FormularioMatricula.txtDocJulio.Text = _dataSet.Tables(0).Rows(i)("NumDocumento").ToString
                                varDia = _dataSet.Tables(0).Rows(i)("FechaPago").ToString
                                FormularioMatricula.cbbDiaJulio.Text = varDia.Day
                            ElseIf _dataSet.Tables(0).Rows(i)("NombreMes").ToString = "AGOSTO" Then
                        FormularioMatricula.txtMontoAgosto.Text = _dataSet.Tables(0).Rows(i)("Monto").ToString
                        FormularioMatricula.txtDocAgosto.Text = _dataSet.Tables(0).Rows(i)("NumDocumento").ToString
                                varDia = _dataSet.Tables(0).Rows(i)("FechaPago").ToString
                                FormularioMatricula.cbbDiaAgosto.Text = varDia.Day
                            ElseIf _dataSet.Tables(0).Rows(i)("NombreMes").ToString = "SEPTIEMBRE" Then
                        FormularioMatricula.txtMontoSept.Text = _dataSet.Tables(0).Rows(i)("Monto").ToString
                        FormularioMatricula.txtDocSept.Text = _dataSet.Tables(0).Rows(i)("NumDocumento").ToString
                                varDia = _dataSet.Tables(0).Rows(i)("FechaPago").ToString
                                FormularioMatricula.cbbDiaSept.Text = varDia.Day
                            ElseIf _dataSet.Tables(0).Rows(i)("NombreMes").ToString = "OCTUBRE" Then
                        FormularioMatricula.txtMontoOctubre.Text = _dataSet.Tables(0).Rows(i)("Monto").ToString
                        FormularioMatricula.txtDocOctubre.Text = _dataSet.Tables(0).Rows(i)("NumDocumento").ToString
                                varDia = _dataSet.Tables(0).Rows(i)("FechaPago").ToString
                                FormularioMatricula.cbbDiaOctubre.Text = varDia.Day
                            ElseIf _dataSet.Tables(0).Rows(i)("NombreMes").ToString = "NOVIEMBRE" Then
                        FormularioMatricula.txtMontoNov.Text = _dataSet.Tables(0).Rows(i)("Monto").ToString
                        FormularioMatricula.txtDocNov.Text = _dataSet.Tables(0).Rows(i)("NumDocumento").ToString
                                varDia = _dataSet.Tables(0).Rows(i)("FechaPago").ToString
                                FormularioMatricula.cbbDiaNov.Text = varDia.Day
                            ElseIf _dataSet.Tables(0).Rows(i)("NombreMes").ToString = "DICIEMBRE" Then
                        FormularioMatricula.txtMontoDic.Text = _dataSet.Tables(0).Rows(i)("Monto").ToString
                        FormularioMatricula.txtDocDic.Text = _dataSet.Tables(0).Rows(i)("NumDocumento").ToString
                                varDia = _dataSet.Tables(0).Rows(i)("FechaPago").ToString
                                FormularioMatricula.cbbDiaDic.Text = varDia.Day
                            End If
                        Next i
                    End If

        Catch ex As Exception
            MessageBox.Show("Error al cargar datos, es posible que la información esté incompleta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Function

    Public Function CambiarPassword(ByRef passactual As String, ByRef newpass1 As String, ByRef newpass2 As String, ByRef rut As String)
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

        Dim conn As New MySqlConnection("server=localhost;User Id=root;password=123456;database=bd_echaurren")
        Dim adapter As New MySqlDataAdapter()
        Dim dataSet As New DataSet

        Try
            adapter.SelectCommand = New MySqlCommand("SELECT PassUsuario FROM usuario WHERE usuario.RutUsuario = '" & rut & "'", conn)
            adapter.Fill(dataSet)
        Catch ex As Exception
            MessageBox.Show("Usuario no registrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Try
            If newpass1 = newpass2 Then
                If passactual = newpass1 Or passactual = newpass2 Then
                    MessageBox.Show("La nueva contraseña es igual a la contraseña actual, ingrese una nueva.", "¡Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    CambiarPass.txtNewPass1.Text = ""
                    CambiarPass.txtNewPass2.Text = ""
                Else
                    If passactual = dataSet.Tables(0).Rows("0")("PassUsuario").ToString Then
                        consulta = "UPDATE `bd_echaurren`.`usuario` SET `PassUsuario`='" & newpass1 & "' WHERE `RutUsuario`='" & rut & "' and PassUsuario = '" & passactual & "';"
                        Dim comando As New MySqlCommand(consulta, varConn)
                        comando.ExecuteNonQuery()
                        Return True
                    Else
                        MessageBox.Show("Las contraseña actual no coincide con los registros, ingrese nuevamente.", "¡Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If
                End If
            Else
                MessageBox.Show("Las nuevas contraseñas no coinciden, ingrese nuevamente.", "¡Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                CambiarPass.txtNewPass1.Text = ""
                CambiarPass.txtNewPass2.Text = ""
            End If
        Catch ex As Exception
            MessageBox.Show("Error al cambiar de contraseña.")
            Return False
        End Try
    End Function

    Public Function IniciarSesion(ByRef user As String, ByRef pass As String)
        Dim conn As New MySqlConnection("server=localhost;User Id=root;password=123456;database=bd_echaurren")
        Dim adapter As New MySqlDataAdapter()
        Dim dataSet As New DataSet

        Try
            adapter.SelectCommand = New MySqlCommand("SELECT NombreUsuario, TipoUsuario, PassUsuario FROM usuario WHERE usuario.RutUsuario = '" & user & "' and PassUsuario = '" & pass & "'", conn)
            adapter.Fill(dataSet)

            If dataSet.Tables(0).Rows("0")("TipoUsuario").ToString = "Administrador" Then
                Form1.MatriculasToolStripMenuItem.Enabled = True
                Form1.FinanzasToolStripMenuItem.Enabled = True
                Form1.AdministracionToolStripMenuItem.Enabled = True
                Form1.DocumentosToolStripMenuItem.Enabled = True
                Form1.UsuariosToolStripMenuItem.Enabled = True
                Form1.HerramientasToolStripMenuItem.Enabled = True
                Form1.GestionarUsuariosToolStripMenuItem.Enabled = True
                Form1.RespaldarBaseDeDatosToolStripMenuItem.Enabled = True
                Form1.LoginToolStripMenuItem.Text = "Cerrar Sesión"
                Form1.varUsuarioActual = LoginForm1.UsernameTextBox.Text
                Form1.varTipoUsuario = dataSet.Tables(0).Rows("0")("TipoUsuario").ToString
                MsgBox("Bienvenido(a) " & dataSet.Tables(0).Rows("0")("NombreUsuario").ToString, MsgBoxStyle.OkOnly)
                LoginForm1.Close()
            ElseIf dataSet.Tables(0).Rows("0")("TipoUsuario").ToString = "Asistente" Then
                Form1.MatriculasToolStripMenuItem.Enabled = True
                Form1.AdministracionToolStripMenuItem.Enabled = True
                Form1.DocumentosToolStripMenuItem.Enabled = True
                Form1.UsuariosToolStripMenuItem.Enabled = True
                Form1.GestionarUsuariosToolStripMenuItem.Enabled = False
                Form1.HerramientasToolStripMenuItem.Enabled = True
                Form1.GestionarUsuariosToolStripMenuItem.Enabled = False
                Form1.RespaldarBaseDeDatosToolStripMenuItem.Enabled = False
                Form1.LoginToolStripMenuItem.Text = "Cerrar Sesión"
                Form1.varUsuarioActual = LoginForm1.UsernameTextBox.Text
                Form1.varTipoUsuario = dataSet.Tables(0).Rows("0")("TipoUsuario").ToString
                MsgBox("Bienvenido(a) " & dataSet.Tables(0).Rows("0")("NombreUsuario").ToString, MsgBoxStyle.OkOnly)
                LoginForm1.Close()
            Else
                MessageBox.Show("Usuario y/o Contraseña incorrecto(s)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                LoginForm1.UsernameTextBox.Text = ""
                LoginForm1.PasswordTextBox.Text = ""
                LoginForm1.UsernameTextBox.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show("Usuario y/o Contraseña incorrecto(s)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Public Function CargarUsuarios(ByRef dgv As DataGridView)
        Dim conn As New MySqlConnection("server=localhost;User Id=root;password=123456;database=bd_echaurren")
        Dim adapter As New MySqlDataAdapter()
        Dim dataSet As New DataSet
        adapter.SelectCommand = New MySqlCommand("SELECT * FROM usuario", conn)
        adapter.Fill(dataSet)
        dgv.DataSource = dataSet.Tables(0)
    End Function

    Public Function CargarPlanilla(ByRef dgv As DataGridView)
        Dim conn As New MySqlConnection("server=localhost;User Id=root;password=123456;database=bd_echaurren")
        Dim adapter As New MySqlDataAdapter()
        Dim dataSet As New DataSet
        adapter.SelectCommand = New MySqlCommand("SELECT RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Curso, Becado, PlanSalud  FROM Alumno inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join servicio_por_alumno on servicio_por_alumno.alumno_RutAlumno = alumno.RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
        adapter.Fill(dataSet)
        dgv.DataSource = dataSet.Tables(0)
    End Function

    Public Function CrearUser(ByRef nombre As String, ByRef rut As String, ByRef pass As String, ByRef tipo As ComboBox)
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
            consulta = "INSERT INTO `bd_echaurren`.`usuario` (`NombreUsuario`, `RutUsuario`, `PassUsuario`, `TipoUsuario`) VALUES ('" & nombre & "', '" & rut & "', '" & pass & "', '" & tipo.Text & "');"

            Dim comando As New MySqlCommand(consulta, varConn)
            comando.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            MessageBox.Show("Error al crear usuario.")
        End Try
    End Function

    Public Function ActualizarUser(ByRef nombre As String, ByRef rut As String, ByRef pass As String, ByRef tipo As String, ByRef oldnombre As String, ByRef oldrut As String)
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
            consulta = "UPDATE `bd_echaurren`.`usuario` SET `NombreUsuario`='" & nombre & "', `RutUsuario`='" & rut & "', `PassUsuario`='" & pass & "', `TipoUsuario`='" & tipo & "' WHERE `NombreUsuario`='" & oldnombre & "' and RutUsuario = '" & oldrut & "';"

            Dim comando As New MySqlCommand(consulta, varConn)
            comando.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            MessageBox.Show("Error al guardar cambios.")
            Return False
        End Try
    End Function

    Public Function EliminarUser(ByRef rut As String)
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
            consulta = "DELETE FROM `bd_echaurren`.`usuario` WHERE `RutUsuario`='" & rut & "';"
            Dim comando As New MySqlCommand(consulta, varConn)
            comando.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            MessageBox.Show("Error al eliminar usuario.")
            Return False
        End Try
    End Function

    Public Function CancelarMatri(ByRef rut As String)
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
            consulta = "DELETE FROM contacto_emergencia USING contacto_emergencia, alumno WHERE `alumno`.`RutAlumno` = `contacto_emergencia`.`Alumno_RutAlumno` AND alumno.RutAlumno = '" & rut & "';"
            Dim comando As New MySqlCommand(consulta, varConn)
            comando.ExecuteNonQuery()
            consulta = "DELETE FROM mensualidad USING mensualidad, alumno WHERE `alumno`.`RutAlumno` = `mensualidad`.`RutAlumno` AND alumno.RutAlumno = '" & rut & "';"
            Dim comando2 As New MySqlCommand(consulta, varConn)
            comando2.ExecuteNonQuery()
            consulta = "DELETE FROM responsable_alumno USING responsable_alumno, alumno WHERE `alumno`.`RutAlumno` = `responsable_alumno`.`Alumno_RutAlumno` AND alumno.RutAlumno = '" & rut & "';"
            Dim comando3 As New MySqlCommand(consulta, varConn)
            comando3.ExecuteNonQuery()
            consulta = "DELETE FROM servicio_por_alumno USING servicio_por_alumno, alumno WHERE `alumno`.`RutAlumno` = `servicio_por_alumno`.`alumno_RutAlumno` AND alumno.RutAlumno = '" & rut & "';"
            Dim comando4 As New MySqlCommand(consulta, varConn)
            comando4.ExecuteNonQuery()
            consulta = "DELETE FROM alumno Using alumno WHERE alumno.RutAlumno = '" & rut & "';"
            Dim comando5 As New MySqlCommand(consulta, varConn)
            comando5.ExecuteNonQuery()
            consulta = "DELETE FROM fichaalumno Using fichaalumno, alumno WHERE `alumno`.`Fichaalumno_idFichaalumno` = `fichaalumno`.`idFichaalumno` AND alumno.RutAlumno = '" & rut & "';"
            Dim comando6 As New MySqlCommand(consulta, varConn)
            comando6.ExecuteNonQuery()
            consulta = "DELETE FROM alumno Using alumno WHERE `alumno`.`Matricula_NumMatricula` = `matricula`.`NumMatricula` AND alumno.RutAlumno = '" & rut & "';"
            Dim comando7 As New MySqlCommand(consulta, varConn)
            comando7.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            MessageBox.Show("Error al cancelar la matricula.")
            Return False
        End Try
    End Function

    Public Function checkPlanilla(ByRef dgv As DataGridView)
        Dim conn As New MySqlConnection("server=localhost;User Id=root;password=123456;database=bd_echaurren")
        Dim adapter As New MySqlDataAdapter()
        Dim dataSet As New DataSet

        If ImprimirPlanillas.checkRut.Checked = True Then
            If ImprimirPlanillas.checkNombre.Checked = True Then
                If ImprimirPlanillas.checkApellidos.Checked = True Then
                    If ImprimirPlanillas.checkEdad.Checked = True Then
                        If ImprimirPlanillas.checkSexo.Checked = True Then
                            If ImprimirPlanillas.checkCurso.Checked = True Then
                                If ImprimirPlanillas.checkBecas.Checked = True Then
                                    If ImprimirPlanillas.checkSalud.Checked = True Then
                                        adapter.SelectCommand = New MySqlCommand("Select RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Edad, Sexo, Curso, Becado, PlanSalud FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                                    Else
                                        adapter.SelectCommand = New MySqlCommand("Select RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Edad, Sexo, Curso, Becado FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno", conn)
                                    End If
                                ElseIf ImprimirPlanillas.checkSalud.Checked = True Then
                                    adapter.SelectCommand = New MySqlCommand("Select RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Edad, Sexo, Curso, PlanSalud FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                                Else
                                    adapter.SelectCommand = New MySqlCommand("Select RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Edad, Sexo, Curso FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso", conn)
                                End If
                            ElseIf ImprimirPlanillas.checkBecas.Checked = True Then
                                If ImprimirPlanillas.checkSalud.Checked = True Then
                                    adapter.SelectCommand = New MySqlCommand("Select RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Edad, Sexo, Becado, PlanSalud FROM alumno inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                                Else
                                    adapter.SelectCommand = New MySqlCommand("Select RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Edad, Sexo, Becado FROM alumno inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno", conn)
                                End If
                            ElseIf ImprimirPlanillas.checkSalud.Checked = True Then
                                adapter.SelectCommand = New MySqlCommand("Select RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Edad, Sexo, PlanSalud FROM alumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                            Else
                                adapter.SelectCommand = New MySqlCommand("Select RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Edad, Sexo FROM alumno", conn)
                            End If
                        ElseIf ImprimirPlanillas.checkCurso.Checked = True Then
                            If ImprimirPlanillas.checkBecas.Checked = True Then
                                If ImprimirPlanillas.checkSalud.Checked = True Then
                                    adapter.SelectCommand = New MySqlCommand("Select RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Edad, Curso, Becado, PlanSalud FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                                Else
                                    adapter.SelectCommand = New MySqlCommand("Select RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Edad, Curso, Becado FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno", conn)
                                End If
                            ElseIf ImprimirPlanillas.checkSalud.Checked = True Then
                                adapter.SelectCommand = New MySqlCommand("Select RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Edad, Curso, PlanSalud FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                            Else
                                adapter.SelectCommand = New MySqlCommand("Select RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Edad, Curso FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso", conn)
                            End If
                        ElseIf ImprimirPlanillas.checkBecas.Checked = True Then
                            If ImprimirPlanillas.checkSalud.Checked = True Then
                                adapter.SelectCommand = New MySqlCommand("Select RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Edad, Becado, PlanSalud FROM alumno inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                            Else
                                adapter.SelectCommand = New MySqlCommand("Select RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Edad, Becado FROM alumno inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno", conn)
                            End If
                        ElseIf ImprimirPlanillas.checkSalud.Checked = True Then
                            adapter.SelectCommand = New MySqlCommand("Select RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Edad, PlanSalud FROM alumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                        Else
                            adapter.SelectCommand = New MySqlCommand("Select RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Edad FROM alumno", conn)
                        End If
                    ElseIf ImprimirPlanillas.checkSexo.Checked = True Then
                        If ImprimirPlanillas.checkCurso.Checked = True Then
                            If ImprimirPlanillas.checkBecas.Checked = True Then
                                If ImprimirPlanillas.checkSalud.Checked = True Then
                                    adapter.SelectCommand = New MySqlCommand("Select RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, Curso, Becado, PlanSalud FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                                Else
                                    adapter.SelectCommand = New MySqlCommand("Select RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, Curso, Becado FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno", conn)
                                End If
                            ElseIf ImprimirPlanillas.checkSalud.Checked = True Then
                                adapter.SelectCommand = New MySqlCommand("Select RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, Curso, PlanSalud FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                            Else
                                adapter.SelectCommand = New MySqlCommand("Select RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, Curso FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso", conn)
                            End If
                        ElseIf ImprimirPlanillas.checkBecas.Checked = True Then
                            If ImprimirPlanillas.checkSalud.Checked = True Then
                                adapter.SelectCommand = New MySqlCommand("Select RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, Becado, PlanSalud FROM alumno inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                            Else
                                adapter.SelectCommand = New MySqlCommand("Select RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Becado FROM alumno inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno", conn)
                            End If
                        ElseIf ImprimirPlanillas.checkSalud.Checked = True Then
                            adapter.SelectCommand = New MySqlCommand("Select RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo, PlanSalud FROM alumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                        Else
                            adapter.SelectCommand = New MySqlCommand("Select RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Sexo FROM alumno", conn)
                        End If
                    ElseIf ImprimirPlanillas.checkCurso.Checked = True Then
                        If ImprimirPlanillas.checkBecas.Checked = True Then
                            If ImprimirPlanillas.checkSalud.Checked = True Then
                                adapter.SelectCommand = New MySqlCommand("Select RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Curso, Becado, PlanSalud FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                            Else
                                adapter.SelectCommand = New MySqlCommand("Select RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Curso, Becado FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno", conn)
                            End If
                        ElseIf ImprimirPlanillas.checkSalud.Checked = True Then
                            adapter.SelectCommand = New MySqlCommand("Select RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Curso, PlanSalud FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                        Else
                            adapter.SelectCommand = New MySqlCommand("Select RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Curso FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso", conn)
                        End If
                    ElseIf ImprimirPlanillas.checkBecas.Checked = True Then
                        If ImprimirPlanillas.checkSalud.Checked = True Then
                            adapter.SelectCommand = New MySqlCommand("Select RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Becado, PlanSalud FROM alumno inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                        Else
                            adapter.SelectCommand = New MySqlCommand("Select RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Becado FROM alumno inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno", conn)
                        End If
                    ElseIf ImprimirPlanillas.checkSalud.Checked = True Then
                        adapter.SelectCommand = New MySqlCommand("Select RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, PlanSalud FROM alumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                    Else
                        adapter.SelectCommand = New MySqlCommand("Select RutAlumno, NombreCompleto, ApePaterno, ApeMaterno FROM alumno", conn)
                    End If
                ElseIf ImprimirPlanillas.checkEdad.Checked = True Then
                    If ImprimirPlanillas.checkSexo.Checked = True Then
                        If ImprimirPlanillas.checkCurso.Checked = True Then
                            If ImprimirPlanillas.checkBecas.Checked = True Then
                                If ImprimirPlanillas.checkSalud.Checked = True Then
                                    adapter.SelectCommand = New MySqlCommand("Select RutAlumno, NombreCompleto, Edad, Sexo, Curso, Becado, PlanSalud FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                                Else
                                    adapter.SelectCommand = New MySqlCommand("Select RutAlumno, NombreCompleto, Edad, Sexo, Curso, Becado FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno", conn)
                                End If
                            ElseIf ImprimirPlanillas.checkSalud.Checked = True Then
                                adapter.SelectCommand = New MySqlCommand("Select RutAlumno, NombreCompleto, Edad, Sexo, Curso, PlanSalud FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                            Else
                                adapter.SelectCommand = New MySqlCommand("Select RutAlumno, NombreCompleto, Edad, Sexo, Curso FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso", conn)
                            End If
                        ElseIf ImprimirPlanillas.checkBecas.Checked = True Then
                            If ImprimirPlanillas.checkSalud.Checked = True Then
                                adapter.SelectCommand = New MySqlCommand("Select RutAlumno, NombreCompleto, Edad, Sexo, Becado, PlanSalud FROM alumno inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                            Else
                                adapter.SelectCommand = New MySqlCommand("Select RutAlumno, NombreCompleto, Edad, Sexo, Becado FROM alumno inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno", conn)
                            End If
                        ElseIf ImprimirPlanillas.checkSalud.Checked = True Then
                            adapter.SelectCommand = New MySqlCommand("Select RutAlumno, NombreCompleto, Edad, Sexo, PlanSalud FROM alumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                        Else
                            adapter.SelectCommand = New MySqlCommand("Select RutAlumno, NombreCompleto, Edad, Sexo FROM alumno", conn)
                        End If
                    ElseIf ImprimirPlanillas.checkCurso.Checked = True Then
                        If ImprimirPlanillas.checkBecas.Checked = True Then
                            If ImprimirPlanillas.checkSalud.Checked = True Then
                                adapter.SelectCommand = New MySqlCommand("Select RutAlumno, NombreCompleto, Edad, Curso, Becado, PlanSalud FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                            Else
                                adapter.SelectCommand = New MySqlCommand("Select RutAlumno, NombreCompleto, Edad, Curso, Becado FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno", conn)
                            End If
                        ElseIf ImprimirPlanillas.checkSalud.Checked = True Then
                            adapter.SelectCommand = New MySqlCommand("Select RutAlumno, NombreCompleto, Edad, Curso, PlanSalud FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                        Else
                            adapter.SelectCommand = New MySqlCommand("Select RutAlumno, NombreCompleto, Edad, Curso FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso", conn)
                        End If
                    ElseIf ImprimirPlanillas.checkBecas.Checked = True Then
                        If ImprimirPlanillas.checkSalud.Checked = True Then
                            adapter.SelectCommand = New MySqlCommand("Select RutAlumno, NombreCompleto, Edad, Becado, PlanSalud FROM alumno inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                        Else
                            adapter.SelectCommand = New MySqlCommand("Select RutAlumno, NombreCompleto, Edad, Becado FROM alumno inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno", conn)
                        End If
                    ElseIf ImprimirPlanillas.checkSalud.Checked = True Then
                        adapter.SelectCommand = New MySqlCommand("Select RutAlumno, NombreCompleto, Edad, PlanSalud FROM alumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                    Else
                        adapter.SelectCommand = New MySqlCommand("Select RutAlumno, NombreCompleto, Edad FROM alumno", conn)
                    End If
                ElseIf ImprimirPlanillas.checkSexo.Checked = True Then
                    If ImprimirPlanillas.checkCurso.Checked = True Then
                        If ImprimirPlanillas.checkBecas.Checked = True Then
                            If ImprimirPlanillas.checkSalud.Checked = True Then
                                adapter.SelectCommand = New MySqlCommand("Select RutAlumno, NombreCompleto, Sexo, Curso, Becado, PlanSalud FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                            Else
                                adapter.SelectCommand = New MySqlCommand("Select RutAlumno, NombreCompleto, Sexo, Curso, Becado FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno", conn)
                            End If
                        ElseIf ImprimirPlanillas.checkSalud.Checked = True Then
                            adapter.SelectCommand = New MySqlCommand("Select RutAlumno, NombreCompleto, Sexo, Curso, PlanSalud FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                        Else
                            adapter.SelectCommand = New MySqlCommand("Select RutAlumno, NombreCompleto, Sexo, Curso FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso", conn)
                        End If
                    ElseIf ImprimirPlanillas.checkBecas.Checked = True Then
                        If ImprimirPlanillas.checkSalud.Checked = True Then
                            adapter.SelectCommand = New MySqlCommand("Select RutAlumno, NombreCompleto, Sexo, Becado, PlanSalud FROM alumno inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                        Else
                            adapter.SelectCommand = New MySqlCommand("Select RutAlumno, NombreCompleto, Becado FROM alumno inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno", conn)
                        End If
                    ElseIf ImprimirPlanillas.checkSalud.Checked = True Then
                        adapter.SelectCommand = New MySqlCommand("Select RutAlumno, NombreCompleto, Sexo, PlanSalud FROM alumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                    Else
                        adapter.SelectCommand = New MySqlCommand("Select RutAlumno, NombreCompleto, Sexo FROM alumno", conn)
                    End If
                ElseIf ImprimirPlanillas.checkCurso.Checked = True Then
                    If ImprimirPlanillas.checkBecas.Checked = True Then
                        If ImprimirPlanillas.checkSalud.Checked = True Then
                            adapter.SelectCommand = New MySqlCommand("Select RutAlumno, NombreCompleto, Curso, Becado, PlanSalud FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                        Else
                            adapter.SelectCommand = New MySqlCommand("Select RutAlumno, NombreCompleto, Curso, Becado FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno", conn)
                        End If
                    ElseIf ImprimirPlanillas.checkSalud.Checked = True Then
                        adapter.SelectCommand = New MySqlCommand("Select RutAlumno, NombreCompleto, Curso, PlanSalud FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                    Else
                        adapter.SelectCommand = New MySqlCommand("Select RutAlumno, NombreCompleto, Curso FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso", conn)
                    End If
                ElseIf ImprimirPlanillas.checkBecas.Checked = True Then
                    If ImprimirPlanillas.checkSalud.Checked = True Then
                        adapter.SelectCommand = New MySqlCommand("Select RutAlumno, NombreCompleto, Becado, PlanSalud FROM alumno inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                    Else
                        adapter.SelectCommand = New MySqlCommand("Select RutAlumno, NombreCompleto, Becado FROM alumno inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno", conn)
                    End If
                ElseIf ImprimirPlanillas.checkSalud.Checked = True Then
                    adapter.SelectCommand = New MySqlCommand("Select RutAlumno, NombreCompleto, PlanSalud FROM alumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                Else
                    adapter.SelectCommand = New MySqlCommand("Select RutAlumno, NombreCompleto FROM alumno", conn)
                End If
            ElseIf ImprimirPlanillas.checkApellidos.Checked = True Then
                If ImprimirPlanillas.checkEdad.Checked = True Then
                    If ImprimirPlanillas.checkSexo.Checked = True Then
                        If ImprimirPlanillas.checkCurso.Checked = True Then
                            If ImprimirPlanillas.checkBecas.Checked = True Then
                                If ImprimirPlanillas.checkSalud.Checked = True Then
                                    adapter.SelectCommand = New MySqlCommand("Select RutAlumno, ApePaterno, ApeMaterno, Edad, Sexo, Curso, Becado, PlanSalud FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                                Else
                                    adapter.SelectCommand = New MySqlCommand("Select RutAlumno, ApePaterno, ApeMaterno, Edad, Sexo, Curso, Becado FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno", conn)
                                End If
                            ElseIf ImprimirPlanillas.checkSalud.Checked = True Then
                                adapter.SelectCommand = New MySqlCommand("Select RutAlumno, ApePaterno, ApeMaterno, Edad, Sexo, Curso, PlanSalud FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                            Else
                                adapter.SelectCommand = New MySqlCommand("Select RutAlumno, ApePaterno, ApeMaterno, Edad, Sexo, Curso FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso", conn)
                            End If
                        ElseIf ImprimirPlanillas.checkBecas.Checked = True Then
                            If ImprimirPlanillas.checkSalud.Checked = True Then
                                adapter.SelectCommand = New MySqlCommand("Select RutAlumno, ApePaterno, ApeMaterno, Edad, Sexo, Becado, PlanSalud FROM alumno inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                            Else
                                adapter.SelectCommand = New MySqlCommand("Select RutAlumno, ApePaterno, ApeMaterno, Edad, Sexo, Becado FROM alumno inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno", conn)
                            End If
                        ElseIf ImprimirPlanillas.checkSalud.Checked = True Then
                            adapter.SelectCommand = New MySqlCommand("Select RutAlumno, ApePaterno, ApeMaterno, Edad, Sexo, PlanSalud FROM alumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                        Else
                            adapter.SelectCommand = New MySqlCommand("Select RutAlumno, ApePaterno, ApeMaterno, Edad, Sexo FROM alumno", conn)
                        End If
                    ElseIf ImprimirPlanillas.checkCurso.Checked = True Then
                        If ImprimirPlanillas.checkBecas.Checked = True Then
                            If ImprimirPlanillas.checkSalud.Checked = True Then
                                adapter.SelectCommand = New MySqlCommand("Select RutAlumno, ApePaterno, ApeMaterno, Edad, Curso, Becado, PlanSalud FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                            Else
                                adapter.SelectCommand = New MySqlCommand("Select RutAlumno, ApePaterno, ApeMaterno, Edad, Curso, Becado FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno", conn)
                            End If
                        ElseIf ImprimirPlanillas.checkSalud.Checked = True Then
                            adapter.SelectCommand = New MySqlCommand("Select RutAlumno, ApePaterno, ApeMaterno, Edad, Curso, PlanSalud FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                        Else
                            adapter.SelectCommand = New MySqlCommand("Select RutAlumno, ApePaterno, ApeMaterno, Edad, Curso FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso", conn)
                        End If
                    ElseIf ImprimirPlanillas.checkBecas.Checked = True Then
                        If ImprimirPlanillas.checkSalud.Checked = True Then
                            adapter.SelectCommand = New MySqlCommand("Select RutAlumno, ApePaterno, ApeMaterno, Edad, Becado, PlanSalud FROM alumno inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                        Else
                            adapter.SelectCommand = New MySqlCommand("Select RutAlumno, ApePaterno, ApeMaterno, Edad, Becado FROM alumno inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno", conn)
                        End If
                    ElseIf ImprimirPlanillas.checkSalud.Checked = True Then
                        adapter.SelectCommand = New MySqlCommand("Select RutAlumno, ApePaterno, ApeMaterno, Edad, PlanSalud FROM alumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                    Else
                        adapter.SelectCommand = New MySqlCommand("Select RutAlumno, ApePaterno, ApeMaterno, Edad FROM alumno", conn)
                    End If
                ElseIf ImprimirPlanillas.checkSexo.Checked = True Then
                    If ImprimirPlanillas.checkCurso.Checked = True Then
                        If ImprimirPlanillas.checkBecas.Checked = True Then
                            If ImprimirPlanillas.checkSalud.Checked = True Then
                                adapter.SelectCommand = New MySqlCommand("Select RutAlumno, ApePaterno, ApeMaterno, Sexo, Curso, Becado, PlanSalud FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                            Else
                                adapter.SelectCommand = New MySqlCommand("Select RutAlumno, ApePaterno, ApeMaterno, Sexo, Curso, Becado FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno", conn)
                            End If
                        ElseIf ImprimirPlanillas.checkSalud.Checked = True Then
                            adapter.SelectCommand = New MySqlCommand("Select RutAlumno, ApePaterno, ApeMaterno, Sexo, Curso, PlanSalud FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                        Else
                            adapter.SelectCommand = New MySqlCommand("Select RutAlumno, ApePaterno, ApeMaterno, Sexo, Curso FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso", conn)
                        End If
                    ElseIf ImprimirPlanillas.checkBecas.Checked = True Then
                        If ImprimirPlanillas.checkSalud.Checked = True Then
                            adapter.SelectCommand = New MySqlCommand("Select RutAlumno, ApePaterno, ApeMaterno, Sexo, Becado, PlanSalud FROM alumno inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                        Else
                            adapter.SelectCommand = New MySqlCommand("Select RutAlumno, ApePaterno, ApeMaterno, Becado FROM alumno inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno", conn)
                        End If
                    ElseIf ImprimirPlanillas.checkSalud.Checked = True Then
                        adapter.SelectCommand = New MySqlCommand("Select RutAlumno, ApePaterno, ApeMaterno, Sexo, PlanSalud FROM alumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                    Else
                        adapter.SelectCommand = New MySqlCommand("Select RutAlumno, ApePaterno, ApeMaterno, Sexo FROM alumno", conn)
                    End If
                ElseIf ImprimirPlanillas.checkCurso.Checked = True Then
                    If ImprimirPlanillas.checkBecas.Checked = True Then
                        If ImprimirPlanillas.checkSalud.Checked = True Then
                            adapter.SelectCommand = New MySqlCommand("Select RutAlumno, ApePaterno, ApeMaterno, Curso, Becado, PlanSalud FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                        Else
                            adapter.SelectCommand = New MySqlCommand("Select RutAlumno, ApePaterno, ApeMaterno, Curso, Becado FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno", conn)
                        End If
                    ElseIf ImprimirPlanillas.checkSalud.Checked = True Then
                        adapter.SelectCommand = New MySqlCommand("Select RutAlumno, ApePaterno, ApeMaterno, Curso, PlanSalud FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                    Else
                        adapter.SelectCommand = New MySqlCommand("Select RutAlumno, ApePaterno, ApeMaterno, Curso FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso", conn)
                    End If
                ElseIf ImprimirPlanillas.checkBecas.Checked = True Then
                    If ImprimirPlanillas.checkSalud.Checked = True Then
                        adapter.SelectCommand = New MySqlCommand("Select RutAlumno, ApePaterno, ApeMaterno, Becado, PlanSalud FROM alumno inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                    Else
                        adapter.SelectCommand = New MySqlCommand("Select RutAlumno, ApePaterno, ApeMaterno, Becado FROM alumno inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno", conn)
                    End If
                ElseIf ImprimirPlanillas.checkSalud.Checked = True Then
                    adapter.SelectCommand = New MySqlCommand("Select RutAlumno, ApePaterno, ApeMaterno, PlanSalud FROM alumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                Else
                    adapter.SelectCommand = New MySqlCommand("Select RutAlumno, ApePaterno, ApeMaterno FROM alumno", conn)
                End If
            ElseIf ImprimirPlanillas.checkEdad.Checked = True Then
                If ImprimirPlanillas.checkSexo.Checked = True Then
                    If ImprimirPlanillas.checkCurso.Checked = True Then
                        If ImprimirPlanillas.checkBecas.Checked = True Then
                            If ImprimirPlanillas.checkSalud.Checked = True Then
                                adapter.SelectCommand = New MySqlCommand("Select RutAlumno, Edad, Sexo, Curso, Becado, PlanSalud FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                            Else
                                adapter.SelectCommand = New MySqlCommand("Select RutAlumno, Edad, Sexo, Curso, Becado FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno", conn)
                            End If
                        ElseIf ImprimirPlanillas.checkSalud.Checked = True Then
                            adapter.SelectCommand = New MySqlCommand("Select RutAlumno, Edad, Sexo, Curso, PlanSalud FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                        Else
                            adapter.SelectCommand = New MySqlCommand("Select RutAlumno, Edad, Sexo, Curso FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso", conn)
                        End If
                    ElseIf ImprimirPlanillas.checkBecas.Checked = True Then
                        If ImprimirPlanillas.checkSalud.Checked = True Then
                            adapter.SelectCommand = New MySqlCommand("Select RutAlumno, Edad, Sexo, Becado, PlanSalud FROM alumno inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                        Else
                            adapter.SelectCommand = New MySqlCommand("Select RutAlumno, Edad, Sexo, Becado FROM alumno inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno", conn)
                        End If
                    ElseIf ImprimirPlanillas.checkSalud.Checked = True Then
                        adapter.SelectCommand = New MySqlCommand("Select RutAlumno, Edad, Sexo, PlanSalud FROM alumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                    Else
                        adapter.SelectCommand = New MySqlCommand("Select RutAlumno, Edad, Sexo FROM alumno", conn)
                    End If
                ElseIf ImprimirPlanillas.checkCurso.Checked = True Then
                    If ImprimirPlanillas.checkBecas.Checked = True Then
                        If ImprimirPlanillas.checkSalud.Checked = True Then
                            adapter.SelectCommand = New MySqlCommand("Select RutAlumno, Edad, Curso, Becado, PlanSalud FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                        Else
                            adapter.SelectCommand = New MySqlCommand("Select RutAlumno, Edad, Curso, Becado FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno", conn)
                        End If
                    ElseIf ImprimirPlanillas.checkSalud.Checked = True Then
                        adapter.SelectCommand = New MySqlCommand("Select RutAlumno, Edad, Curso, PlanSalud FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                    Else
                        adapter.SelectCommand = New MySqlCommand("Select RutAlumno, Edad, Curso FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso", conn)
                    End If
                ElseIf ImprimirPlanillas.checkBecas.Checked = True Then
                    If ImprimirPlanillas.checkSalud.Checked = True Then
                        adapter.SelectCommand = New MySqlCommand("Select RutAlumno, Edad, Becado, PlanSalud FROM alumno inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                    Else
                        adapter.SelectCommand = New MySqlCommand("Select RutAlumno, Edad, Becado FROM alumno inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno", conn)
                    End If
                ElseIf ImprimirPlanillas.checkSalud.Checked = True Then
                    adapter.SelectCommand = New MySqlCommand("Select RutAlumno, Edad, PlanSalud FROM alumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                Else
                    adapter.SelectCommand = New MySqlCommand("Select RutAlumno, Edad FROM alumno", conn)
                End If
            ElseIf ImprimirPlanillas.checkSexo.Checked = True Then
                If ImprimirPlanillas.checkCurso.Checked = True Then
                    If ImprimirPlanillas.checkBecas.Checked = True Then
                        If ImprimirPlanillas.checkSalud.Checked = True Then
                            adapter.SelectCommand = New MySqlCommand("Select RutAlumno, Sexo, Curso, Becado, PlanSalud FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                        Else
                            adapter.SelectCommand = New MySqlCommand("Select RutAlumno, Sexo, Curso, Becado FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno", conn)
                        End If
                    ElseIf ImprimirPlanillas.checkSalud.Checked = True Then
                        adapter.SelectCommand = New MySqlCommand("Select RutAlumno, Sexo, Curso, PlanSalud FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                    Else
                        adapter.SelectCommand = New MySqlCommand("Select RutAlumno, Sexo, Curso FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso", conn)
                    End If
                ElseIf ImprimirPlanillas.checkBecas.Checked = True Then
                    If ImprimirPlanillas.checkSalud.Checked = True Then
                        adapter.SelectCommand = New MySqlCommand("Select RutAlumno, Sexo, Becado, PlanSalud FROM alumno inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                    Else
                        adapter.SelectCommand = New MySqlCommand("Select RutAlumno, Becado FROM alumno inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno", conn)
                    End If
                ElseIf ImprimirPlanillas.checkSalud.Checked = True Then
                    adapter.SelectCommand = New MySqlCommand("Select RutAlumno, Sexo, PlanSalud FROM alumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                Else
                    adapter.SelectCommand = New MySqlCommand("Select RutAlumno, Sexo FROM alumno", conn)
                End If
            ElseIf ImprimirPlanillas.checkCurso.Checked = True Then
                If ImprimirPlanillas.checkBecas.Checked = True Then
                    If ImprimirPlanillas.checkSalud.Checked = True Then
                        adapter.SelectCommand = New MySqlCommand("Select RutAlumno, Curso, Becado, PlanSalud FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                    Else
                        adapter.SelectCommand = New MySqlCommand("Select RutAlumno, Curso, Becado FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno", conn)
                    End If
                ElseIf ImprimirPlanillas.checkSalud.Checked = True Then
                    adapter.SelectCommand = New MySqlCommand("Select RutAlumno, Curso, PlanSalud FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                Else
                    adapter.SelectCommand = New MySqlCommand("Select RutAlumno, Curso FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso", conn)
                End If
            ElseIf ImprimirPlanillas.checkBecas.Checked = True Then
                If ImprimirPlanillas.checkSalud.Checked = True Then
                    adapter.SelectCommand = New MySqlCommand("Select RutAlumno, Becado, PlanSalud FROM alumno inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                Else
                    adapter.SelectCommand = New MySqlCommand("Select RutAlumno, Becado FROM alumno inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno", conn)
                End If
            ElseIf ImprimirPlanillas.checkSalud.Checked = True Then
                adapter.SelectCommand = New MySqlCommand("Select RutAlumno, PlanSalud FROM alumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
            Else
                adapter.SelectCommand = New MySqlCommand("Select RutAlumno FROM alumno", conn)
            End If
        ElseIf ImprimirPlanillas.checkNombre.Checked = True Then
            If ImprimirPlanillas.checkApellidos.Checked = True Then
                If ImprimirPlanillas.checkEdad.Checked = True Then
                    If ImprimirPlanillas.checkSexo.Checked = True Then
                        If ImprimirPlanillas.checkCurso.Checked = True Then
                            If ImprimirPlanillas.checkBecas.Checked = True Then
                                If ImprimirPlanillas.checkSalud.Checked = True Then
                                    adapter.SelectCommand = New MySqlCommand("Select NombreCompleto, ApePaterno, ApeMaterno, Edad, Sexo, Curso, Becado, PlanSalud FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                                Else
                                    adapter.SelectCommand = New MySqlCommand("Select NombreCompleto, ApePaterno, ApeMaterno, Edad, Sexo, Curso, Becado FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno", conn)
                                End If
                            ElseIf ImprimirPlanillas.checkSalud.Checked = True Then
                                adapter.SelectCommand = New MySqlCommand("Select NombreCompleto, ApePaterno, ApeMaterno, Edad, Sexo, Curso, PlanSalud FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                            Else
                                adapter.SelectCommand = New MySqlCommand("Select NombreCompleto, ApePaterno, ApeMaterno, Edad, Sexo, Curso FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso", conn)
                            End If
                        ElseIf ImprimirPlanillas.checkBecas.Checked = True Then
                            If ImprimirPlanillas.checkSalud.Checked = True Then
                                adapter.SelectCommand = New MySqlCommand("Select NombreCompleto, ApePaterno, ApeMaterno, Edad, Sexo, Becado, PlanSalud FROM alumno inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                            Else
                                adapter.SelectCommand = New MySqlCommand("Select NombreCompleto, ApePaterno, ApeMaterno, Edad, Sexo, Becado FROM alumno inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno", conn)
                            End If
                        ElseIf ImprimirPlanillas.checkSalud.Checked = True Then
                            adapter.SelectCommand = New MySqlCommand("Select NombreCompleto, ApePaterno, ApeMaterno, Edad, Sexo, PlanSalud FROM alumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                        Else
                            adapter.SelectCommand = New MySqlCommand("Select NombreCompleto, ApePaterno, ApeMaterno, Edad, Sexo FROM alumno", conn)
                        End If
                    ElseIf ImprimirPlanillas.checkCurso.Checked = True Then
                        If ImprimirPlanillas.checkBecas.Checked = True Then
                            If ImprimirPlanillas.checkSalud.Checked = True Then
                                adapter.SelectCommand = New MySqlCommand("Select NombreCompleto, ApePaterno, ApeMaterno, Edad, Curso, Becado, PlanSalud FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                            Else
                                adapter.SelectCommand = New MySqlCommand("Select NombreCompleto, ApePaterno, ApeMaterno, Edad, Curso, Becado FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno", conn)
                            End If
                        ElseIf ImprimirPlanillas.checkSalud.Checked = True Then
                            adapter.SelectCommand = New MySqlCommand("Select NombreCompleto, ApePaterno, ApeMaterno, Edad, Curso, PlanSalud FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                        Else
                            adapter.SelectCommand = New MySqlCommand("Select NombreCompleto, ApePaterno, ApeMaterno, Edad, Curso FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso", conn)
                        End If
                    ElseIf ImprimirPlanillas.checkBecas.Checked = True Then
                        If ImprimirPlanillas.checkSalud.Checked = True Then
                            adapter.SelectCommand = New MySqlCommand("Select NombreCompleto, ApePaterno, ApeMaterno, Edad, Becado, PlanSalud FROM alumno inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                        Else
                            adapter.SelectCommand = New MySqlCommand("Select NombreCompleto, ApePaterno, ApeMaterno, Edad, Becado FROM alumno inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno", conn)
                        End If
                    ElseIf ImprimirPlanillas.checkSalud.Checked = True Then
                        adapter.SelectCommand = New MySqlCommand("Select NombreCompleto, ApePaterno, ApeMaterno, Edad, PlanSalud FROM alumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                    Else
                        adapter.SelectCommand = New MySqlCommand("Select NombreCompleto, ApePaterno, ApeMaterno, Edad FROM alumno", conn)
                    End If
                ElseIf ImprimirPlanillas.checkSexo.Checked = True Then
                    If ImprimirPlanillas.checkCurso.Checked = True Then
                        If ImprimirPlanillas.checkBecas.Checked = True Then
                            If ImprimirPlanillas.checkSalud.Checked = True Then
                                adapter.SelectCommand = New MySqlCommand("Select NombreCompleto, ApePaterno, ApeMaterno, Sexo, Curso, Becado, PlanSalud FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                            Else
                                adapter.SelectCommand = New MySqlCommand("Select NombreCompleto, ApePaterno, ApeMaterno, Sexo, Curso, Becado FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno", conn)
                            End If
                        ElseIf ImprimirPlanillas.checkSalud.Checked = True Then
                            adapter.SelectCommand = New MySqlCommand("Select NombreCompleto, ApePaterno, ApeMaterno, Sexo, Curso, PlanSalud FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                        Else
                            adapter.SelectCommand = New MySqlCommand("Select NombreCompleto, ApePaterno, ApeMaterno, Sexo, Curso FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso", conn)
                        End If
                    ElseIf ImprimirPlanillas.checkBecas.Checked = True Then
                        If ImprimirPlanillas.checkSalud.Checked = True Then
                            adapter.SelectCommand = New MySqlCommand("Select NombreCompleto, ApePaterno, ApeMaterno, Sexo, Becado, PlanSalud FROM alumno inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                        Else
                            adapter.SelectCommand = New MySqlCommand("Select NombreCompleto, ApePaterno, ApeMaterno, Becado FROM alumno inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno", conn)
                        End If
                    ElseIf ImprimirPlanillas.checkSalud.Checked = True Then
                        adapter.SelectCommand = New MySqlCommand("Select NombreCompleto, ApePaterno, ApeMaterno, Sexo, PlanSalud FROM alumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                    Else
                        adapter.SelectCommand = New MySqlCommand("Select NombreCompleto, ApePaterno, ApeMaterno, Sexo FROM alumno", conn)
                    End If
                ElseIf ImprimirPlanillas.checkCurso.Checked = True Then
                    If ImprimirPlanillas.checkBecas.Checked = True Then
                        If ImprimirPlanillas.checkSalud.Checked = True Then
                            adapter.SelectCommand = New MySqlCommand("Select NombreCompleto, ApePaterno, ApeMaterno, Curso, Becado, PlanSalud FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                        Else
                            adapter.SelectCommand = New MySqlCommand("Select NombreCompleto, ApePaterno, ApeMaterno, Curso, Becado FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno", conn)
                        End If
                    ElseIf ImprimirPlanillas.checkSalud.Checked = True Then
                        adapter.SelectCommand = New MySqlCommand("Select NombreCompleto, ApePaterno, ApeMaterno, Curso, PlanSalud FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                    Else
                        adapter.SelectCommand = New MySqlCommand("Select NombreCompleto, ApePaterno, ApeMaterno, Curso FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso", conn)
                    End If
                ElseIf ImprimirPlanillas.checkBecas.Checked = True Then
                    If ImprimirPlanillas.checkSalud.Checked = True Then
                        adapter.SelectCommand = New MySqlCommand("Select NombreCompleto, ApePaterno, ApeMaterno, Becado, PlanSalud FROM alumno inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                    Else
                        adapter.SelectCommand = New MySqlCommand("Select NombreCompleto, ApePaterno, ApeMaterno, Becado FROM alumno inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno", conn)
                    End If
                ElseIf ImprimirPlanillas.checkSalud.Checked = True Then
                    adapter.SelectCommand = New MySqlCommand("Select NombreCompleto, ApePaterno, ApeMaterno, PlanSalud FROM alumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                Else
                    adapter.SelectCommand = New MySqlCommand("Select NombreCompleto, ApePaterno, ApeMaterno FROM alumno", conn)
                End If
            ElseIf ImprimirPlanillas.checkEdad.Checked = True Then
                If ImprimirPlanillas.checkSexo.Checked = True Then
                    If ImprimirPlanillas.checkCurso.Checked = True Then
                        If ImprimirPlanillas.checkBecas.Checked = True Then
                            If ImprimirPlanillas.checkSalud.Checked = True Then
                                adapter.SelectCommand = New MySqlCommand("Select NombreCompleto, Edad, Sexo, Curso, Becado, PlanSalud FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                            Else
                                adapter.SelectCommand = New MySqlCommand("Select NombreCompleto, Edad, Sexo, Curso, Becado FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno", conn)
                            End If
                        ElseIf ImprimirPlanillas.checkSalud.Checked = True Then
                            adapter.SelectCommand = New MySqlCommand("Select NombreCompleto, Edad, Sexo, Curso, PlanSalud FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                        Else
                            adapter.SelectCommand = New MySqlCommand("Select NombreCompleto, Edad, Sexo, Curso FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso", conn)
                        End If
                    ElseIf ImprimirPlanillas.checkBecas.Checked = True Then
                        If ImprimirPlanillas.checkSalud.Checked = True Then
                            adapter.SelectCommand = New MySqlCommand("Select NombreCompleto, Edad, Sexo, Becado, PlanSalud FROM alumno inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                        Else
                            adapter.SelectCommand = New MySqlCommand("Select NombreCompleto, Edad, Sexo, Becado FROM alumno inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno", conn)
                        End If
                    ElseIf ImprimirPlanillas.checkSalud.Checked = True Then
                        adapter.SelectCommand = New MySqlCommand("Select NombreCompleto, Edad, Sexo, PlanSalud FROM alumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                    Else
                        adapter.SelectCommand = New MySqlCommand("Select NombreCompleto, Edad, Sexo FROM alumno", conn)
                    End If
                ElseIf ImprimirPlanillas.checkCurso.Checked = True Then
                    If ImprimirPlanillas.checkBecas.Checked = True Then
                        If ImprimirPlanillas.checkSalud.Checked = True Then
                            adapter.SelectCommand = New MySqlCommand("Select NombreCompleto, Edad, Curso, Becado, PlanSalud FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                        Else
                            adapter.SelectCommand = New MySqlCommand("Select NombreCompleto, Edad, Curso, Becado FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno", conn)
                        End If
                    ElseIf ImprimirPlanillas.checkSalud.Checked = True Then
                        adapter.SelectCommand = New MySqlCommand("Select NombreCompleto, Edad, Curso, PlanSalud FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                    Else
                        adapter.SelectCommand = New MySqlCommand("Select NombreCompleto, Edad, Curso FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso", conn)
                    End If
                ElseIf ImprimirPlanillas.checkBecas.Checked = True Then
                    If ImprimirPlanillas.checkSalud.Checked = True Then
                        adapter.SelectCommand = New MySqlCommand("Select NombreCompleto, Edad, Becado, PlanSalud FROM alumno inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                    Else
                        adapter.SelectCommand = New MySqlCommand("Select NombreCompleto, Edad, Becado FROM alumno inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno", conn)
                    End If
                ElseIf ImprimirPlanillas.checkSalud.Checked = True Then
                    adapter.SelectCommand = New MySqlCommand("Select NombreCompleto, Edad, PlanSalud FROM alumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                Else
                    adapter.SelectCommand = New MySqlCommand("Select NombreCompleto, Edad FROM alumno", conn)
                End If
            ElseIf ImprimirPlanillas.checkSexo.Checked = True Then
                If ImprimirPlanillas.checkCurso.Checked = True Then
                    If ImprimirPlanillas.checkBecas.Checked = True Then
                        If ImprimirPlanillas.checkSalud.Checked = True Then
                            adapter.SelectCommand = New MySqlCommand("Select NombreCompleto, Sexo, Curso, Becado, PlanSalud FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                        Else
                            adapter.SelectCommand = New MySqlCommand("Select NombreCompleto, Sexo, Curso, Becado FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno", conn)
                        End If
                    ElseIf ImprimirPlanillas.checkSalud.Checked = True Then
                        adapter.SelectCommand = New MySqlCommand("Select NombreCompleto, Sexo, Curso, PlanSalud FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                    Else
                        adapter.SelectCommand = New MySqlCommand("Select NombreCompleto, Sexo, Curso FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso", conn)
                    End If
                ElseIf ImprimirPlanillas.checkBecas.Checked = True Then
                    If ImprimirPlanillas.checkSalud.Checked = True Then
                        adapter.SelectCommand = New MySqlCommand("Select NombreCompleto, Sexo, Becado, PlanSalud FROM alumno inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                    Else
                        adapter.SelectCommand = New MySqlCommand("Select NombreCompleto, Becado FROM alumno inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno", conn)
                    End If
                ElseIf ImprimirPlanillas.checkSalud.Checked = True Then
                    adapter.SelectCommand = New MySqlCommand("Select NombreCompleto, Sexo, PlanSalud FROM alumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                Else
                    adapter.SelectCommand = New MySqlCommand("Select NombreCompleto, Sexo FROM alumno", conn)
                End If
            ElseIf ImprimirPlanillas.checkCurso.Checked = True Then
                If ImprimirPlanillas.checkBecas.Checked = True Then
                    If ImprimirPlanillas.checkSalud.Checked = True Then
                        adapter.SelectCommand = New MySqlCommand("Select NombreCompleto, Curso, Becado, PlanSalud FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                    Else
                        adapter.SelectCommand = New MySqlCommand("Select NombreCompleto, Curso, Becado FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno", conn)
                    End If
                ElseIf ImprimirPlanillas.checkSalud.Checked = True Then
                    adapter.SelectCommand = New MySqlCommand("Select NombreCompleto, Curso, PlanSalud FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                Else
                    adapter.SelectCommand = New MySqlCommand("Select NombreCompleto, Curso FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso", conn)
                End If
            ElseIf ImprimirPlanillas.checkBecas.Checked = True Then
                If ImprimirPlanillas.checkSalud.Checked = True Then
                    adapter.SelectCommand = New MySqlCommand("Select NombreCompleto, Becado, PlanSalud FROM alumno inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                Else
                    adapter.SelectCommand = New MySqlCommand("Select NombreCompleto, Becado FROM alumno inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno", conn)
                End If
            ElseIf ImprimirPlanillas.checkSalud.Checked = True Then
                adapter.SelectCommand = New MySqlCommand("Select NombreCompleto, PlanSalud FROM alumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
            Else
                adapter.SelectCommand = New MySqlCommand("Select NombreCompleto FROM alumno", conn)
            End If
        ElseIf ImprimirPlanillas.checkApellidos.Checked = True Then
            If ImprimirPlanillas.checkEdad.Checked = True Then
                If ImprimirPlanillas.checkSexo.Checked = True Then
                    If ImprimirPlanillas.checkCurso.Checked = True Then
                        If ImprimirPlanillas.checkBecas.Checked = True Then
                            If ImprimirPlanillas.checkSalud.Checked = True Then
                                adapter.SelectCommand = New MySqlCommand("Select ApePaterno, ApeMaterno, Edad, Sexo, Curso, Becado, PlanSalud FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                            Else
                                adapter.SelectCommand = New MySqlCommand("Select ApePaterno, ApeMaterno, Edad, Sexo, Curso, Becado FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno", conn)
                            End If
                        ElseIf ImprimirPlanillas.checkSalud.Checked = True Then
                            adapter.SelectCommand = New MySqlCommand("Select ApePaterno, ApeMaterno, Edad, Sexo, Curso, PlanSalud FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                        Else
                            adapter.SelectCommand = New MySqlCommand("Select ApePaterno, ApeMaterno, Edad, Sexo, Curso FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso", conn)
                        End If
                    ElseIf ImprimirPlanillas.checkBecas.Checked = True Then
                        If ImprimirPlanillas.checkSalud.Checked = True Then
                            adapter.SelectCommand = New MySqlCommand("Select ApePaterno, ApeMaterno, Edad, Sexo, Becado, PlanSalud FROM alumno inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                        Else
                            adapter.SelectCommand = New MySqlCommand("Select ApePaterno, ApeMaterno, Edad, Sexo, Becado FROM alumno inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno", conn)
                        End If
                    ElseIf ImprimirPlanillas.checkSalud.Checked = True Then
                        adapter.SelectCommand = New MySqlCommand("Select ApePaterno, ApeMaterno, Edad, Sexo, PlanSalud FROM alumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                    Else
                        adapter.SelectCommand = New MySqlCommand("Select ApePaterno, ApeMaterno, Edad, Sexo FROM alumno", conn)
                    End If
                ElseIf ImprimirPlanillas.checkCurso.Checked = True Then
                    If ImprimirPlanillas.checkBecas.Checked = True Then
                        If ImprimirPlanillas.checkSalud.Checked = True Then
                            adapter.SelectCommand = New MySqlCommand("Select ApePaterno, ApeMaterno, Edad, Curso, Becado, PlanSalud FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                        Else
                            adapter.SelectCommand = New MySqlCommand("Select ApePaterno, ApeMaterno, Edad, Curso, Becado FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno", conn)
                        End If
                    ElseIf ImprimirPlanillas.checkSalud.Checked = True Then
                        adapter.SelectCommand = New MySqlCommand("Select ApePaterno, ApeMaterno, Edad, Curso, PlanSalud FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                    Else
                        adapter.SelectCommand = New MySqlCommand("Select ApePaterno, ApeMaterno, Edad, Curso FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso", conn)
                    End If
                ElseIf ImprimirPlanillas.checkBecas.Checked = True Then
                    If ImprimirPlanillas.checkSalud.Checked = True Then
                        adapter.SelectCommand = New MySqlCommand("Select ApePaterno, ApeMaterno, Edad, Becado, PlanSalud FROM alumno inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                    Else
                        adapter.SelectCommand = New MySqlCommand("Select ApePaterno, ApeMaterno, Edad, Becado FROM alumno inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno", conn)
                    End If
                ElseIf ImprimirPlanillas.checkSalud.Checked = True Then
                    adapter.SelectCommand = New MySqlCommand("Select ApePaterno, ApeMaterno, Edad, PlanSalud FROM alumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                Else
                    adapter.SelectCommand = New MySqlCommand("Select ApePaterno, ApeMaterno, Edad FROM alumno", conn)
                End If
            ElseIf ImprimirPlanillas.checkSexo.Checked = True Then
                If ImprimirPlanillas.checkCurso.Checked = True Then
                    If ImprimirPlanillas.checkBecas.Checked = True Then
                        If ImprimirPlanillas.checkSalud.Checked = True Then
                            adapter.SelectCommand = New MySqlCommand("Select ApePaterno, ApeMaterno, Sexo, Curso, Becado, PlanSalud FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                        Else
                            adapter.SelectCommand = New MySqlCommand("Select ApePaterno, ApeMaterno, Sexo, Curso, Becado FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno", conn)
                        End If
                    ElseIf ImprimirPlanillas.checkSalud.Checked = True Then
                        adapter.SelectCommand = New MySqlCommand("Select ApePaterno, ApeMaterno, Sexo, Curso, PlanSalud FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                    Else
                        adapter.SelectCommand = New MySqlCommand("Select ApePaterno, ApeMaterno, Sexo, Curso FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso", conn)
                    End If
                ElseIf ImprimirPlanillas.checkBecas.Checked = True Then
                    If ImprimirPlanillas.checkSalud.Checked = True Then
                        adapter.SelectCommand = New MySqlCommand("Select ApePaterno, ApeMaterno, Sexo, Becado, PlanSalud FROM alumno inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                    Else
                        adapter.SelectCommand = New MySqlCommand("Select ApePaterno, ApeMaterno, Becado FROM alumno inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno", conn)
                    End If
                ElseIf ImprimirPlanillas.checkSalud.Checked = True Then
                    adapter.SelectCommand = New MySqlCommand("Select ApePaterno, ApeMaterno, Sexo, PlanSalud FROM alumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                Else
                    adapter.SelectCommand = New MySqlCommand("Select ApePaterno, ApeMaterno, Sexo FROM alumno", conn)
                End If
            ElseIf ImprimirPlanillas.checkCurso.Checked = True Then
                If ImprimirPlanillas.checkBecas.Checked = True Then
                    If ImprimirPlanillas.checkSalud.Checked = True Then
                        adapter.SelectCommand = New MySqlCommand("Select ApePaterno, ApeMaterno, Curso, Becado, PlanSalud FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                    Else
                        adapter.SelectCommand = New MySqlCommand("Select ApePaterno, ApeMaterno, Curso, Becado FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno", conn)
                    End If
                ElseIf ImprimirPlanillas.checkSalud.Checked = True Then
                    adapter.SelectCommand = New MySqlCommand("Select ApePaterno, ApeMaterno, Curso, PlanSalud FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                Else
                    adapter.SelectCommand = New MySqlCommand("Select ApePaterno, ApeMaterno, Curso FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso", conn)
                End If
            ElseIf ImprimirPlanillas.checkBecas.Checked = True Then
                If ImprimirPlanillas.checkSalud.Checked = True Then
                    adapter.SelectCommand = New MySqlCommand("Select ApePaterno, ApeMaterno, Becado, PlanSalud FROM alumno inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                Else
                    adapter.SelectCommand = New MySqlCommand("Select ApePaterno, ApeMaterno, Becado FROM alumno inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno", conn)
                End If
            ElseIf ImprimirPlanillas.checkSalud.Checked = True Then
                adapter.SelectCommand = New MySqlCommand("Select ApePaterno, ApeMaterno, PlanSalud FROM alumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
            Else
                adapter.SelectCommand = New MySqlCommand("Select ApePaterno, ApeMaterno FROM alumno", conn)
            End If
        ElseIf ImprimirPlanillas.checkEdad.Checked = True Then
            If ImprimirPlanillas.checkSexo.Checked = True Then
                If ImprimirPlanillas.checkCurso.Checked = True Then
                    If ImprimirPlanillas.checkBecas.Checked = True Then
                        If ImprimirPlanillas.checkSalud.Checked = True Then
                            adapter.SelectCommand = New MySqlCommand("Select Edad, Sexo, Curso, Becado, PlanSalud FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                        Else
                            adapter.SelectCommand = New MySqlCommand("Select Edad, Sexo, Curso, Becado FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno", conn)
                        End If
                    ElseIf ImprimirPlanillas.checkSalud.Checked = True Then
                        adapter.SelectCommand = New MySqlCommand("Select Edad, Sexo, Curso, PlanSalud FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                    Else
                        adapter.SelectCommand = New MySqlCommand("Select Edad, Sexo, Curso FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso", conn)
                    End If
                ElseIf ImprimirPlanillas.checkBecas.Checked = True Then
                    If ImprimirPlanillas.checkSalud.Checked = True Then
                        adapter.SelectCommand = New MySqlCommand("Select Edad, Sexo, Becado, PlanSalud FROM alumno inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                    Else
                        adapter.SelectCommand = New MySqlCommand("Select Edad, Sexo, Becado FROM alumno inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno", conn)
                    End If
                ElseIf ImprimirPlanillas.checkSalud.Checked = True Then
                    adapter.SelectCommand = New MySqlCommand("Select Edad, Sexo, PlanSalud FROM alumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                Else
                    adapter.SelectCommand = New MySqlCommand("Select Edad, Sexo FROM alumno", conn)
                End If
            ElseIf ImprimirPlanillas.checkCurso.Checked = True Then
                If ImprimirPlanillas.checkBecas.Checked = True Then
                    If ImprimirPlanillas.checkSalud.Checked = True Then
                        adapter.SelectCommand = New MySqlCommand("Select Edad, Curso, Becado, PlanSalud FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                    Else
                        adapter.SelectCommand = New MySqlCommand("Select Edad, Curso, Becado FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno", conn)
                    End If
                ElseIf ImprimirPlanillas.checkSalud.Checked = True Then
                    adapter.SelectCommand = New MySqlCommand("Select Edad, Curso, PlanSalud FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                Else
                    adapter.SelectCommand = New MySqlCommand("Select Edad, Curso FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso", conn)
                End If
            ElseIf ImprimirPlanillas.checkBecas.Checked = True Then
                If ImprimirPlanillas.checkSalud.Checked = True Then
                    adapter.SelectCommand = New MySqlCommand("Select Edad, Becado, PlanSalud FROM alumno inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                Else
                    adapter.SelectCommand = New MySqlCommand("Select Edad, Becado FROM alumno inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno", conn)
                End If
            ElseIf ImprimirPlanillas.checkSalud.Checked = True Then
                adapter.SelectCommand = New MySqlCommand("Select Edad, PlanSalud FROM alumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
            Else
                adapter.SelectCommand = New MySqlCommand("Select Edad FROM alumno", conn)
            End If
        ElseIf ImprimirPlanillas.checkSexo.Checked = True Then
            If ImprimirPlanillas.checkCurso.Checked = True Then
                If ImprimirPlanillas.checkBecas.Checked = True Then
                    If ImprimirPlanillas.checkSalud.Checked = True Then
                        adapter.SelectCommand = New MySqlCommand("Select Sexo, Curso, Becado, PlanSalud FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                    Else
                        adapter.SelectCommand = New MySqlCommand("Select Sexo, Curso, Becado FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno", conn)
                    End If
                ElseIf ImprimirPlanillas.checkSalud.Checked = True Then
                    adapter.SelectCommand = New MySqlCommand("Select Sexo, Curso, PlanSalud FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                Else
                    adapter.SelectCommand = New MySqlCommand("Select Sexo, Curso FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso", conn)
                End If
            ElseIf ImprimirPlanillas.checkBecas.Checked = True Then
                If ImprimirPlanillas.checkSalud.Checked = True Then
                    adapter.SelectCommand = New MySqlCommand("Select Sexo, Becado, PlanSalud FROM alumno inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                Else
                    adapter.SelectCommand = New MySqlCommand("Select Becado FROM alumno inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno", conn)
                End If
            ElseIf ImprimirPlanillas.checkSalud.Checked = True Then
                adapter.SelectCommand = New MySqlCommand("Select Sexo, PlanSalud FROM alumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
            Else
                adapter.SelectCommand = New MySqlCommand("Select Sexo FROM alumno", conn)
            End If
        ElseIf ImprimirPlanillas.checkCurso.Checked = True Then
            If ImprimirPlanillas.checkBecas.Checked = True Then
                If ImprimirPlanillas.checkSalud.Checked = True Then
                    adapter.SelectCommand = New MySqlCommand("Select Curso, Becado, PlanSalud FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
                Else
                    adapter.SelectCommand = New MySqlCommand("Select Curso, Becado FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno", conn)
                End If
            ElseIf ImprimirPlanillas.checkSalud.Checked = True Then
                adapter.SelectCommand = New MySqlCommand("Select Curso, PlanSalud FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
            Else
                adapter.SelectCommand = New MySqlCommand("Select Curso FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso", conn)
            End If
        ElseIf ImprimirPlanillas.checkBecas.Checked = True Then
            If ImprimirPlanillas.checkSalud.Checked = True Then
                adapter.SelectCommand = New MySqlCommand("Select Becado, PlanSalud FROM alumno inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
            Else
                adapter.SelectCommand = New MySqlCommand("Select Becado FROM alumno inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno", conn)
            End If
        ElseIf ImprimirPlanillas.checkSalud.Checked = True Then
            adapter.SelectCommand = New MySqlCommand("Select PlanSalud FROM alumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
        Else
            adapter.SelectCommand = New MySqlCommand("Select RutAlumno, NombreCompleto, ApePaterno, ApeMaterno, Edad, Sexo, Curso, Becado, PlanSalud FROM alumno inner join curso on alumno.Curso_idCurso = curso.idCurso inner join fichaalumno on alumno.Fichaalumno_idFichaalumno = fichaalumno.idFichaalumno inner join servicio_por_alumno on alumno.RutAlumno = servicio_por_alumno.alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
        End If

        adapter.Fill(dataSet)
        dgv.DataSource = dataSet.Tables(0)
    End Function

    Public Function ActualizarMatriculas(ByRef fechamatri As DateTimePicker, ByRef apePaterno As String, ByRef apeMaterno As String, ByRef nombreAlumno As String, ByRef rutAlumno As String, ByRef sexo As String, ByRef fechanac As DateTimePicker, ByRef edad As Integer, ByRef domicilio As String, ByRef villa As String, ByRef curso As String, ByRef comuna As String, ByRef telefono As String, ByRef colegio As String, ByRef repetidos As String, ByRef becado As String, ByRef hermanos As String, ByRef cursohermano As String, ByRef vivecon As String, ByRef hijos As Integer, ByRef lugarhijos As Integer, ByRef grupofamilia As String, ByRef antecedentes As String, ByRef servsalud As String, ByRef otroserv As String, ByRef seguros As String, ByRef oldAlumno As String, ByRef nummatri As Integer, ByRef viveespecifico As String, ByRef porcentaje As String)
        Try
            Dim consulta2 As String = "UPDATE `bd_echaurren`.`alumno`, `fichaalumno`, `servicio_por_alumno`, `curso`, `comuna`, `matricula` SET `NombreCompleto` = '" & nombreAlumno & "', `ApePaterno` = '" & apePaterno & "', `ApeMaterno` = '" & apeMaterno & "', `Sexo` = '" & sexo & "', `FechaNac` = '" & fechanac.Text & "', `Edad` = '" & edad & "', `Domicilio` ='" & domicilio & "', `SectorVilla` = '" & villa & "', `Telefono` = '" & telefono & "', `idCurso` = '" & curso & "', `idComuna` = '" & comuna & "', `ColegioPresedencia` = '" & colegio & "', `CursosRepetidos` = '" & repetidos & "', `Becado` = '" & becado & "', `PorcentajeBeca` = '" & porcentaje & "', `HermanosEstablecimiento` = '" & hermanos & "', `CursosHermanos` = '" & cursohermano & "', `AlumnoViveCon` = '" & vivecon & "', `NumHijosFamilia` = '" & hijos & "', `LugarOcupacionHijos` = '" & lugarhijos & "', `GrupoFamiliarComponen` = '" & grupofamilia & "', `AntecedentesMedicos` = '" & antecedentes & "', `ViveEspecifico` = '" & viveespecifico & "', `Seguros` = '" & seguros & "', `Servicio_salud_idServicio_salud` = '" & servsalud & "', `OtrosServicios` = '" & otroserv & "', `Fechamatricula` = '" & fechamatri.Text & "' WHERE `RutAlumno` = '" & oldAlumno & "' and `alumno`.`Fichaalumno_idFichaalumno` = `fichaalumno`.`idFichaalumno` and `alumno`.`RutAlumno` = `servicio_por_alumno`.`alumno_RutAlumno` and `alumno`.`Comuna_idComuna` = `comuna`.`idComuna` and `alumno`.`Curso_idCurso` = `curso`.`idCurso` and `alumno`.`Matricula_NumMatricula` = `matricula`.`NumMatricula`;"
            Dim _comando8 As New MySqlCommand(consulta2, FormularioMatricula.varConexion)
            _comando8.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function ActualizarContactos(ByRef NomCont1 As String, ByRef NumCont1 As String, ByRef NomCont2 As String, ByRef NumCont2 As String, ByRef NomCont3 As String, ByRef NumCont3 As String, ByRef rutAlumno As String, ByRef oldAlumno As String, ByRef idCont1 As String, ByRef idCont2 As String, ByRef idCont3 As String)
        Try
            Dim consulta As String
            Dim consulta2 As String
            Dim consulta3 As String
            If FormularioMatricula.ComboBox1.Text = "1 Contacto" Then
                consulta = "UPDATE `bd_echaurren`.`contacto_emergencia` SET `NombreContacto` = '" & NomCont1 & "', `Numero` = '" & NumCont1 & "', `Alumno_RutAlumno` = '" & rutAlumno & "' WHERE `Alumno_RutAlumno` = '" & oldAlumno & "' and `idContacto_emergencia`='" & idCont1 & "';"
                Dim _comando7 As New MySqlCommand(consulta, FormularioMatricula.varConexion)
                _comando7.ExecuteNonQuery()
            ElseIf FormularioMatricula.ComboBox1.Text = "2 Contactos" Then
                consulta = "UPDATE `bd_echaurren`.`contacto_emergencia` SET `NombreContacto` = '" & NomCont1 & "', `Numero` = '" & NumCont1 & "', `Alumno_RutAlumno` = '" & rutAlumno & "' WHERE `Alumno_RutAlumno` = '" & oldAlumno & "' and `idContacto_emergencia`='" & idCont1 & "';"
                Dim _comando7 As New MySqlCommand(consulta, FormularioMatricula.varConexion)
                _comando7.ExecuteNonQuery()
                consulta2 = "UPDATE `bd_echaurren`.`contacto_emergencia` SET `NombreContacto` = '" & NomCont2 & "', `Numero` = '" & NumCont2 & "', `Alumno_RutAlumno` = '" & rutAlumno & "' WHERE `Alumno_RutAlumno` = '" & oldAlumno & "' and `idContacto_emergencia`='" & idCont2 & "';"
                Dim _comando8 As New MySqlCommand(consulta2, FormularioMatricula.varConexion)
                _comando8.ExecuteNonQuery()
            ElseIf FormularioMatricula.ComboBox1.Text = "3 Contactos" Then
                consulta = "UPDATE `bd_echaurren`.`contacto_emergencia` SET `NombreContacto` = '" & NomCont1 & "', `Numero` = '" & NumCont1 & "', `Alumno_RutAlumno` = '" & rutAlumno & "' WHERE `Alumno_RutAlumno` = '" & oldAlumno & "' and `idContacto_emergencia`='" & idCont1 & "';"
                Dim _comando7 As New MySqlCommand(consulta, FormularioMatricula.varConexion)
                _comando7.ExecuteNonQuery()
                consulta2 = "UPDATE `bd_echaurren`.`contacto_emergencia` SET `NombreContacto` = '" & NomCont2 & "', `Numero` = '" & NumCont2 & "', `Alumno_RutAlumno` = '" & rutAlumno & "' WHERE `Alumno_RutAlumno` = '" & oldAlumno & " and `idContacto_emergencia`='" & idCont2 & "';"
                Dim _comando8 As New MySqlCommand(consulta2, FormularioMatricula.varConexion)
                _comando8.ExecuteNonQuery()
                consulta3 = "UPDATE `bd_echaurren`.`contacto_emergencia` SET `NombreContacto` = '" & NomCont3 & "', `Numero` = '" & NumCont3 & "', `Alumno_RutAlumno` = '" & rutAlumno & "' WHERE `Alumno_RutAlumno` = '" & oldAlumno & " and `idContacto_emergencia`='" & idCont3 & "';"
                Dim _comando9 As New MySqlCommand(consulta3, FormularioMatricula.varConexion)
                _comando9.ExecuteNonQuery()
            End If

            Return True

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function updateAlumno_respons(ByRef rutResponsable As String, ByRef rutAlumno As String, ByRef tipoResp As String, _
                                           ByRef apoderado As Integer, ByRef apodSuplente As Integer, ByRef matricula As Integer, ByRef oldResp As String, ByRef oldAlumno As String) As Boolean

        Try
            Dim consulta As String = "UPDATE `bd_echaurren`.`responsable_alumno` SET `Responsable_RutResponsable`='" & rutResponsable & "', `Alumno_RutAlumno`='" & rutAlumno & "', `Tipo_responsable_idTipo_responsable`='" & tipoResp & "', `Apoderado`='" & apoderado & "', `ApoderadoSuplente`='" & apodSuplente & "', `Matricula_NumMatricula`='" & matricula & "' WHERE `Responsable_RutResponsable`='" & oldResp & "' and`Alumno_RutAlumno`='" & oldAlumno & "' and`Tipo_responsable_idTipo_responsable`='tr1';"

            Dim _comando As New MySqlCommand(consulta, FormularioMatricula.varConexion)
            _comando.ExecuteNonQuery()
            '  MessageBox.Show("relacion responsable - alumno exitosa")
            Return True
        Catch ex As Exception
            '   MessageBox.Show("error al relacionar responsable - alumno")
            Return False
        End Try

    End Function

    Public Function updateOtroApod(ByRef rutOtroApod As String, ByRef rutAlumno As String, ByRef apoderado As Integer, _
                                     ByRef apodSuplente As Integer, ByRef nombreOtroResp As String, ByRef matricula As Integer, ByRef oldResp As String, ByRef oldAlumno As String) As Boolean

        Try

            Dim tipoResp As String = "tr4"
            Dim consulta As String = "UPDATE `bd_echaurren`.`responsable` SET `RutResponsable`='" & rutOtroApod & "', `NombreCompleto`='" & nombreOtroResp & "' WHERE `RutResponsable`='" & oldResp & "';"
            Dim consulta1 As String = "UPDATE `bd_echaurren`.`responsable_alumno` SET `Responsable_RutResponsable`='" & rutOtroApod & "', `Alumno_RutAlumno`='" & rutAlumno & "', `Tipo_responsable_idTipo_responsable`='" & tipoResp & "', `Apoderado`='" & apoderado & "', `ApoderadoSuplente`='" & apodSuplente & "', `Matricula_NumMatricula`='" & matricula & "' WHERE `Responsable_RutResponsable`='" & oldResp & "' and`Alumno_RutAlumno`='" & oldAlumno & "' and`Tipo_responsable_idTipo_responsable`='tr4';"

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

    Public Function updateResp(ByRef nombre As String, ByRef rut As String, ByRef edad As String, _
                                   ByRef estudios As ComboBox, ByRef trabajaEn As String, ByRef telefono As String, _
                                   ByRef Cargo As String, ByRef direccion As String, ByRef correo As String, ByRef oldRut As String) As Boolean


        Try

            Dim consulta As String = "UPDATE `bd_echaurren`.`responsable`, `telefono`, `direccion` SET `RutResponsable` = '" & rut & "', `NombreCompleto` = '" & nombre & "', `EdadResp` = '" & edad & "', `EstudiosCompletados` = '" & estudios.Text & "', `Correoelectronico` = '" & correo & "', `Trabajo` = '" & trabajaEn & "', `Cargo` = '" & Cargo & "', `Num1` = '" & telefono & "', `DireccionTrabajo` = '" & direccion & "' WHERE `RutResponsable` = '" & oldRut & "' and `responsable`.`Telefono_idTelefono` = `telefono`.`idTelefono` and `responsable`.`Direccion_idDireccion` = `direccion`.`idDireccion`;"

            Dim _comando8 As New MySqlCommand(consulta, FormularioMatricula.varConexion)
            _comando8.ExecuteNonQuery()
            'MessageBox.Show("padre agregado")
            Return True
        Catch ex As Exception
            ' MessageBox.Show("Error al ingresar padre")
            Return False
        End Try
    End Function

    Public Function updateResponsableCompleto(ByRef rutResponsable As String, ByRef nombreComleto As String, ByRef telefono1 As String, _
                                                ByRef telefono2 As String, ByRef telefonoTrabajo As String, ByRef direccionPart As String, _
                                               ByRef direccionTrab As String, ByRef edad As String, ByRef estudiosCompl As ComboBox, _
                                               ByRef Correo As String, ByRef profesion As String, ByRef trabajo As String, _
                                               ByRef cargo As String, ByRef oldRut As String) As Boolean

        Try
            Dim consulta As String = "UPDATE `bd_echaurren`.`responsable`, `telefono`, `direccion` SET `RutResponsable` = '" & rutResponsable & "', `NombreCompleto` = '" & nombreComleto & "', `EdadResp` = '" & edad & "', `EstudiosCompletados` = '" & estudiosCompl.Text & "', `Correoelectronico` = '" & Correo & "', `Profesion` = '" & profesion & "', `Trabajo` = '" & trabajo & "', `Cargo` = '" & cargo & "', `Num1` = '" & telefono1 & "', `Num2` = '" & telefono2 & "', `NumTrabajo` = '" & telefonoTrabajo & "', `DireccionParticular` = '" & direccionPart & "', `DireccionTrabajo` = '" & direccionTrab & "' WHERE `RutResponsable` = '" & oldRut & "' and `responsable`.`Telefono_idTelefono` = `telefono`.`idTelefono` and `responsable`.`Direccion_idDireccion` = `direccion`.`idDireccion`;"

            Dim comando As New MySqlCommand(consulta, FormularioMatricula.varConexion)
            comando.ExecuteNonQuery()
        Catch ex As Exception
            ' MessageBox.Show("Error al ingresaaaaar responsable completo")
            Return False
        End Try

    End Function

    Public Function updateTutorEconomico(ByRef nombreTutor As String, ByRef rutTutor As String, ByRef telefono1 As String, _
                                           ByRef telefono2 As String, ByRef telefTrabajo As String, ByRef domicilio As String, _
                                           ByRef lugarTrabajo As String, ByRef ocupaActual As String, ByRef profesion As String, ByRef oldRut As String) As Boolean

        Try
            Dim consultaTutor As String = "DELETE FROM responsable Using responsable, telefono, direccion WHERE responsable.RutResponsable = '" & oldRut & "' and `responsable`.`Telefono_idTelefono` = `telefono`.`idTelefono` and `responsable`.`Direccion_idDireccion` = `direccion`.`idDireccion`;"
            Dim consultaTutor2 As String = "INSERT INTO `bd_echaurren`.`telefono` (`Num1`, `Num2`, `NumTrabajo`) VALUES ('" & telefono1 & "', '" & telefono2 & "', '" & telefTrabajo & "');"
            Dim consultaTutor3 As String = "INSERT INTO `bd_echaurren`.`responsable` (`RutResponsable`, `NombreCompleto`, `Profesion`, `Trabajo`, `Cargo`, `Telefono_idTelefono`) VALUES ('" & rutTutor & "', '" & nombreTutor & "', '" & profesion & "', '" & lugarTrabajo & " ', '" & ocupaActual & "', last_insert_id());"
            Dim consultatutor4 As String = "INSERT INTO `bd_echaurren`.`direccion` (`DireccionParticular`) VALUES ('" & domicilio & "');"
            Dim consultaTutor5 As String = "UPDATE `bd_echaurren`.`responsable` SET `Direccion_idDireccion`= last_insert_id() WHERE `RutResponsable`='" & rutTutor & "';"
            Dim comando1 As New MySqlCommand(consultaTutor, FormularioMatricula.varConexion)
            comando1.ExecuteNonQuery()
            Dim comando2 As New MySqlCommand(consultaTutor2, FormularioMatricula.varConexion)
            comando2.ExecuteNonQuery()
            Dim comando3 As New MySqlCommand(consultaTutor3, FormularioMatricula.varConexion)
            comando3.ExecuteNonQuery()
            Dim comando4 As New MySqlCommand(consultatutor4, FormularioMatricula.varConexion)
            comando4.ExecuteNonQuery()
            Dim comando5 As New MySqlCommand(consultaTutor5, FormularioMatricula.varConexion)
            comando5.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            '  MessageBox.Show("Error al ingresar tutor economico")
            Return False
        End Try

    End Function

    Public Function updateAlumno_respons_tutor(ByRef rutResponsable As String, ByRef rutAlumno As String, ByRef tipoResp As String, _
                                           ByRef apoderado As Integer, ByRef apodSuplente As Integer, _
                                           ByRef OtroTutor As String, ByRef matricula As Integer, ByRef oldResp As String, ByRef oldAlumno As String) As Boolean

        Try
            Dim consulta As String = "DELETE FROM `bd_echaurren`.`responsable_alumno` WHERE `responsable_alumno`.`Responsable_RutResponsable` = '" & oldResp & "';"
            Dim consulta2 As String = "INSERT INTO `bd_echaurren`.`responsable_alumno` (`Responsable_RutResponsable`, `Alumno_RutAlumno`, `Tipo_responsable_idTipo_responsable`, `Apoderado`, `ApoderadoSuplente`, `Otro_tutor`, `Matricula_NumMatricula`) VALUES('" & rutResponsable & "', '" & rutAlumno & "', '" & tipoResp & "', '" & apoderado & "', '" & apodSuplente & "', '" & OtroTutor & "', '" & matricula & "'); "
            Dim comando As New MySqlCommand(consulta, FormularioMatricula.varConexion)
            comando.ExecuteNonQuery()
            Dim comando2 As New MySqlCommand(consulta2, FormularioMatricula.varConexion)
            comando2.ExecuteNonQuery()
            ' MessageBox.Show("relacion responsable, tutor - alumno exitosa")
            Return True
        Catch ex As Exception
            '  MessageBox.Show("error al relacionar responsable, tutor - alumno")
            Return False
        End Try
    End Function

    Public Function ActualizarMensualidades(ByRef rut As String, ByRef mes As String, ByRef tipopago As ComboBox, ByRef monto As Integer, ByRef fechavenc As String, ByRef documento As String, ByRef montoanual As Integer, ByRef titular As String, ByRef banco As String, ByRef ctacorriente As String)
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
                consulta = "UPDATE `bd_echaurren`.`mensualidad` SET `RutAlumno`='" & rut & "', `NombreMes`='" & mes & "', `TipoPago`='" & tipopago.Text & "', `Monto`='" & monto & "', `FechaPago`='" & fechavenc & "', `Estado`='PAGADO', `NumDocumento`='" & documento & "', `MontoTotalAnual`='" & montoanual & "', `NombreTitular`='" & titular & "', `NombreBanco`='" & banco & "', `NumCtaCorriente`='" & ctacorriente & "' WHERE `RutAlumno`='" & rut & "' and `NombreMes`='" & mes & "';"
            ElseIf FormularioMatricula.cbbTipoPago.SelectedItem = "Cheque" Or FormularioMatricula.cbbTipoPago.SelectedItem = "Letra" Then
                consulta = "UPDATE `bd_echaurren`.`mensualidad` SET `RutAlumno`='" & rut & "', `NombreMes`='" & mes & "', `TipoPago`='" & tipopago.Text & "', `Monto`='" & monto & "', `FechaPago`='" & fechavenc & "', `Estado`='NO PAGADO', `NumDocumento`='" & documento & "', `MontoTotalAnual`='" & montoanual & "', `NombreTitular`='" & titular & "', `NombreBanco`='" & banco & "', `NumCtaCorriente`='" & ctacorriente & "' WHERE `RutAlumno`='" & rut & "' and `NombreMes`='" & mes & "';"
            End If

            Dim comando As New MySqlCommand(consulta, varConn)
            comando.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show("Error al registrar mensualidades.")
        End Try
    End Function

    Public Function VencMensualidad()
        Dim conn As New MySqlConnection("server=localhost;User Id=root;password=123456;database=bd_echaurren")
        Dim adapter As New MySqlDataAdapter()
        Dim dataSet As New DataSet
        Dim consulta As String = ""
        Dim NombreMes As String
        Dim FechaActual As Date = Today
        Dim FechaVenc As Date
        Dim RutAlumno As String
        Dim total As Integer
        Dim resultado As Integer

        Try
            conn.Open()
        Catch ex As Exception
            MessageBox.Show("Error al conectar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        adapter.SelectCommand = New MySqlCommand("SELECT count(*) as total FROM mensualidad WHERE Estado = 'NO PAGADO'", conn)
        adapter.Fill(dataSet)
        total = dataSet.Tables(0).Rows("0")("total").ToString()
        If total <> 0 Then
            For i = 1 To total
                adapter.SelectCommand = New MySqlCommand("SELECT * FROM mensualidad WHERE Estado = 'NO PAGADO'", conn)
                adapter.Fill(dataSet)

                FechaVenc = dataSet.Tables(0).Rows(i)("FechaPago").ToString
                NombreMes = dataSet.Tables(0).Rows(i)("NombreMes").ToString
                RutAlumno = dataSet.Tables(0).Rows(i)("RutAlumno").ToString

                resultado = Date.Compare(FechaVenc, FechaActual)

                If resultado < 0 Then
                    consulta = "UPDATE `bd_echaurren`.`mensualidad` SET `Estado`='ATRASADO' WHERE `NombreMes`='" & NombreMes & "' and RutAlumno = '" & RutAlumno & "' and Estado = 'NO PAGADO';"
                    Dim comando As New MySqlCommand(consulta, conn)
                    comando.ExecuteNonQuery()
                End If
            Next i
        End If


    End Function
End Module

