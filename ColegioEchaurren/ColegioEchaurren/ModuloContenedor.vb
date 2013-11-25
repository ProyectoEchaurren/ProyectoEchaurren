Imports MySql.Data.MySqlClient

Module ModuloContenedor

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
    End Function


    Public Function ingresarAlumno(ByRef fechaMatricula As DateTimePicker, ByRef becado As Integer, ByRef apellidoPatAlumno As String, _
                              ByRef apellidoMatAlumno As String, ByRef nombresAlumno As String, ByRef RunAlumno As String, _
                              ByRef SexoAlumno As String, ByRef fechaNacimientoAlumno As DateTimePicker, ByRef EdadAlumno As String, _
                              ByRef domicilioCalleAlumn As String, ByRef sectorAlumno As String, ByRef curso As String, _
                              ByRef comunaAlumno As String, ByRef telefAlumno As String, ByRef colegioPrese As String, _
                              ByRef cursosRepet As String, ByRef hermanosCurso As String, ByRef AlumnViveCon As String, _
                              ByRef numHijos As String, ByRef lugarHijos As String, ByRef grupoFami As String, _
                              ByRef anteMedicos As String) As Boolean


        Try
            Dim consultaIngresoAlumn As String = "INSERT INTO `bd_echaurren`.`alumno` (`RutAlumno`, `NombreCompleto`, `ApePaterno`, `ApeMaterno`, `Sexo`, `FechaNac`, `Edad`, `Domicilio`, `SectorVilla`, `Comuna`, `Telefono`, `ColegioPresedencia`, `Curso`, `CursosRepetidos`, `Becado`, `HermanosEstablecimiento`, `AlumnoViveCon`, `NumHijosFamilia`, `LugarOcupacionHijos`, `GrupoFamiliarComponen`, `AntecedentesMedicos`, `NumMatricula`, `FechaMatricula`) VALUES ('" & RunAlumno & "', '" & nombresAlumno & "', '" & apellidoPatAlumno & "', '" & apellidoMatAlumno & "', '" & SexoAlumno & "', '" & fechaNacimientoAlumno.Value.ToString("dd/MM/yyyy") & "', '" & EdadAlumno & "', '" & domicilioCalleAlumn & "', '" & sectorAlumno & "', '" & comunaAlumno & "', '" & telefAlumno & "', '" & colegioPrese & "', '" & curso & "', '" & cursosRepet & "', '" & becado & "', '" & hermanosCurso & "', '" & AlumnViveCon & "', '" & numHijos & "', '" & lugarHijos & "', '" & grupoFami & "', '" & anteMedicos & "', '009', '" & fechaMatricula.Value.ToString("dd/MM/yyyy") & "');"
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

    Public Function BuscarRutRealizarPago(ByRef rut As String) As Boolean
        Dim conn As New MySqlConnection("server=localhost;User Id=root;password=123456;database=bd_echaurren")
        Dim adapter As New MySqlDataAdapter()
        Dim dataSet As New DataSet
        Try
            adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Becado, TipoPago, PorcentajeBeca, Monto FROM Alumno inner join Mensualidad on Alumno.RutAlumno = mensualidad.RutAlumno WHERE Alumno.RutAlumno = '" & rut & "'", conn)
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

        Catch ex As Exception
            MessageBox.Show("Alumno No Encontrado", "Error")
        End Try

    End Function

    Public Function BuscarRutBecas(ByRef rut As String) As Boolean
        Dim conn As New MySqlConnection("server=localhost;User Id=root;password=123456;database=bd_echaurren")
        Dim adapter As New MySqlDataAdapter()
        Dim dataSet As New DataSet
        Try
            adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Becado, PorcentajeBeca FROM Alumno WHERE Alumno.RutAlumno = '" & rut & "'", conn)
            adapter.Fill(dataSet)
            AdminBecas.txtNombre.Text = dataSet.Tables(0).Rows("0")("NombreCompleto").ToString & " " & dataSet.Tables(0).Rows("0")("ApePaterno").ToString & " " & dataSet.Tables(0).Rows("0")("ApeMaterno").ToString
            If dataSet.Tables(0).Rows("0")("Becado").ToString = True Then
                AdminBecas.txtBeca.Text = "Becado"
            Else
                AdminBecas.txtBeca.Text = "No Becado"
            End If
            AdminBecas.txtPorcentaje.Text = dataSet.Tables(0).Rows("0")("PorcentajeBeca").ToString
            AdminBecas.cbbNewBeca.Enabled = True
            AdminBecas.txtNewPorcentaje.Enabled = True
        Catch ex As Exception
            MessageBox.Show("Alumno No Encontrado", "Error")
        End Try

    End Function

    Public Function CargarHistorico(ByRef dgv As DataGridView, ByRef rut As String)
        Dim conn As New MySqlConnection("server=localhost;User Id=root;password=123456;database=bd_echaurren")
        Dim adapter As New MySqlDataAdapter()
        Dim dataSet As New DataSet
        adapter.SelectCommand = New MySqlCommand("SELECT alumno.RutAlumno, NombreCompleto, ApePaterno, Curso, Becado, PorcentajeBeca, NombreMes, Monto, TipoPago, Estado from Alumno inner join Mensualidad on alumno.RutAlumno = mensualidad.RutAlumno WHERE Alumno.RutAlumno = '" & rut & "'", conn)
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
                        adapter.SelectCommand = New MySqlCommand("SELECT alumno.RutAlumno, NombreCompleto, ApePaterno, Curso, Becado, PorcentajeBeca, NombreMes, Monto, TipoPago, Estado from Alumno inner join Mensualidad WHERE Becado = 0 and Estado = 'Pagado' and Curso = '" & curso.Text & "' and PorcentajeBeca = '" & porcentaje.Text & "'", conn)
                    ElseIf AdminMensualidades.CheckAtrasado.Checked = True Then
                        adapter.SelectCommand = New MySqlCommand("SELECT alumno.RutAlumno, NombreCompleto, ApePaterno, Curso, Becado, PorcentajeBeca, NombreMes, Monto, TipoPago, Estado from Alumno inner join Mensualidad WHERE Becado = 0 and Estado = 'Atrasado' and Curso = '" & curso.Text & "' and PorcentajeBeca = '" & porcentaje.Text & "'", conn)
                    Else
                        adapter.SelectCommand = New MySqlCommand("SELECT alumno.RutAlumno, NombreCompleto, ApePaterno, Curso, Becado, PorcentajeBeca, NombreMes, Monto, TipoPago, Estado from Alumno inner join Mensualidad WHERE Becado = 0 and Curso = '" & curso.Text & "' and PorcentajeBeca = '" & porcentaje.Text & "'", conn)
                    End If
                Else
                    If AdminMensualidades.CheckPagado.Checked = True Then
                        adapter.SelectCommand = New MySqlCommand("SELECT alumno.RutAlumno, NombreCompleto, ApePaterno, Curso, Becado, PorcentajeBeca, NombreMes, Monto, TipoPago, Estado from Alumno inner join Mensualidad WHERE Becado = 0 and Estado = 'Pagado' and Curso = '" & curso.Text & "'", conn)
                    ElseIf AdminMensualidades.CheckAtrasado.Checked = True Then
                        adapter.SelectCommand = New MySqlCommand("SELECT alumno.RutAlumno, NombreCompleto, ApePaterno, Curso, Becado, PorcentajeBeca, NombreMes, Monto, TipoPago, Estado from Alumno inner join Mensualidad WHERE Becado = 0 and Estado = 'Atrasado' and Curso = '" & curso.Text & "'", conn)
                    Else
                        adapter.SelectCommand = New MySqlCommand("SELECT alumno.RutAlumno, NombreCompleto, ApePaterno, Curso, Becado, PorcentajeBeca, NombreMes, Monto, TipoPago, Estado from Alumno inner join Mensualidad WHERE Becado = 0 and Curso = '" & curso.Text & "'", conn)
                    End If
                End If
            ElseIf AdminMensualidades.CheckNoBecado.Checked = True Then
                If AdminMensualidades.CheckPagado.Checked = True Then
                    adapter.SelectCommand = New MySqlCommand("SELECT alumno.RutAlumno, NombreCompleto, ApePaterno, Curso, Becado, PorcentajeBeca, NombreMes, Monto, TipoPago, Estado from Alumno inner join Mensualidad WHERE Becado = 1 and Estado = 'Pagado' and Curso = '" & curso.Text & "'", conn)
                ElseIf AdminMensualidades.CheckAtrasado.Checked = True Then
                    adapter.SelectCommand = New MySqlCommand("SELECT alumno.RutAlumno, NombreCompleto, ApePaterno, Curso, Becado, PorcentajeBeca, NombreMes, Monto, TipoPago, Estado from Alumno inner join Mensualidad WHERE Becado = 1 and Estado = 'Atrasado' and Curso = '" & curso.Text & "'", conn)
                Else
                    adapter.SelectCommand = New MySqlCommand("SELECT alumno.RutAlumno, NombreCompleto, ApePaterno, Curso, Becado, PorcentajeBeca, NombreMes, Monto, TipoPago, Estado from Alumno inner join Mensualidad WHERE Becado = 1 and Curso ='" & curso.Text & "'", conn)
                End If
            ElseIf AdminMensualidades.CheckPagado.Checked = True Then
                adapter.SelectCommand = New MySqlCommand("SELECT alumno.RutAlumno, NombreCompleto, ApePaterno, Curso, Becado, PorcentajeBeca, NombreMes, Monto, TipoPago, Estado from Alumno inner join Mensualidad WHERE Estado = 'Pagado' and Curso = '" & curso.Text & "'", conn)
            ElseIf AdminMensualidades.CheckAtrasado.Checked = True Then
                adapter.SelectCommand = New MySqlCommand("SELECT alumno.RutAlumno, NombreCompleto, ApePaterno, Curso, Becado, PorcentajeBeca, NombreMes, Monto, TipoPago, Estado from Alumno inner join Mensualidad WHERE Estado = 'Atrasado' and Curso = '" & curso.Text & "'", conn)
            Else
                adapter.SelectCommand = New MySqlCommand("SELECT alumno.RutAlumno, NombreCompleto, ApePaterno, Curso, Becado, PorcentajeBeca, NombreMes, Monto, TipoPago, Estado from Alumno inner join Mensualidad WHERE Curso = '" & curso.Text & "'", conn)
            End If
        ElseIf AdminMensualidades.CheckBecado.Checked = True Then
            If AdminMensualidades.cbPorcentaje.Text <> "" Then
                If AdminMensualidades.CheckPagado.Checked = True Then
                    adapter.SelectCommand = New MySqlCommand("SELECT alumno.RutAlumno, NombreCompleto, ApePaterno, Curso, Becado, PorcentajeBeca, NombreMes, Monto, TipoPago, Estado from Alumno inner join Mensualidad WHERE Becado = 0 and Estado = 'Pagado' and PorcentajeBeca = '" & porcentaje.Text & "'", conn)
                ElseIf AdminMensualidades.CheckAtrasado.Checked = True Then
                    adapter.SelectCommand = New MySqlCommand("SELECT alumno.RutAlumno, NombreCompleto, ApePaterno, Curso, Becado, PorcentajeBeca, NombreMes, Monto, TipoPago, Estado from Alumno inner join Mensualidad WHERE Becado = 0 and Estado = 'Atrasado' and PorcentajeBeca = '" & porcentaje.Text & "'", conn)
                Else
                    adapter.SelectCommand = New MySqlCommand("SELECT alumno.RutAlumno, NombreCompleto, ApePaterno, Curso, Becado, PorcentajeBeca, NombreMes, Monto, TipoPago, Estado from Alumno inner join Mensualidad WHERE Becado = 0 and PorcentajeBeca = '" & porcentaje.Text & "'", conn)
                End If
            Else
                If AdminMensualidades.CheckPagado.Checked = True Then
                    adapter.SelectCommand = New MySqlCommand("SELECT alumno.RutAlumno, NombreCompleto, ApePaterno, Curso, Becado, PorcentajeBeca, NombreMes, Monto, TipoPago, Estado from Alumno inner join Mensualidad WHERE Becado = 0 and Estado = 'Pagado'", conn)
                ElseIf AdminMensualidades.CheckAtrasado.Checked = True Then
                    adapter.SelectCommand = New MySqlCommand("SELECT alumno.RutAlumno, NombreCompleto, ApePaterno, Curso, Becado, PorcentajeBeca, NombreMes, Monto, TipoPago, Estado from Alumno inner join Mensualidad WHERE Becado = 0 and Estado = 'Atrasado'", conn)
                Else
                    adapter.SelectCommand = New MySqlCommand("SELECT alumno.RutAlumno, NombreCompleto, ApePaterno, Curso, Becado, PorcentajeBeca, NombreMes, Monto, TipoPago, Estado from Alumno inner join Mensualidad WHERE Becado = 0", conn)
                End If
            End If
        ElseIf AdminMensualidades.CheckNoBecado.Checked = True Then
            If AdminMensualidades.CheckPagado.Checked = True Then
                adapter.SelectCommand = New MySqlCommand("SELECT alumno.RutAlumno, NombreCompleto, ApePaterno, Curso, Becado, PorcentajeBeca, NombreMes, Monto, TipoPago, Estado from Alumno inner join Mensualidad WHERE Becado = 1 and Estado = 'Pagado'", conn)
            ElseIf AdminMensualidades.CheckAtrasado.Checked = True Then
                adapter.SelectCommand = New MySqlCommand("SELECT alumno.RutAlumno, NombreCompleto, ApePaterno, Curso, Becado, PorcentajeBeca, NombreMes, Monto, TipoPago, Estado from Alumno inner join Mensualidad WHERE Becado = 1 and Estado = 'Atrasado'", conn)
            Else
                adapter.SelectCommand = New MySqlCommand("SELECT alumno.RutAlumno, NombreCompleto, ApePaterno, Curso, Becado, PorcentajeBeca, NombreMes, Monto, TipoPago, Estado from Alumno inner join Mensualidad WHERE Becado = 1", conn)
            End If
        ElseIf AdminMensualidades.CheckPagado.Checked = True Then
            adapter.SelectCommand = New MySqlCommand("SELECT alumno.RutAlumno, NombreCompleto, ApePaterno, Curso, Becado, PorcentajeBeca, NombreMes, Monto, TipoPago, Estado from Alumno inner join Mensualidad WHERE Estado = 'Pagado'", conn)
        ElseIf AdminMensualidades.CheckAtrasado.Checked = True Then
            adapter.SelectCommand = New MySqlCommand("SELECT alumno.RutAlumno, NombreCompleto, ApePaterno, Curso, Becado, PorcentajeBeca, NombreMes, Monto, TipoPago, Estado from Alumno inner join Mensualidad WHERE Estado = 'Atrasado'", conn)
        Else
            adapter.SelectCommand = New MySqlCommand("SELECT alumno.RutAlumno, NombreCompleto, ApePaterno, Curso, Becado, PorcentajeBeca, NombreMes, Monto, TipoPago, Estado from Alumno inner join Mensualidad", conn)
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
                                        adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud WHERE RutAlumno = '" & rut & "', NombreCompleto = '" & nombre & "', ApePaterno = '" & apellido & "', Edad = '" & edad & "', PlanSalud = '" & salud.Text & "', PorcentajeBeca = '" & porcentaje.Text & "', Curso = '" & curso.Text & "', Becado = 1 ", conn)
                                    Else
                                        adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud WHERE RutAlumno = '" & rut & "', NombreCompleto = '" & nombre & "', ApePaterno = '" & apellido & "', Edad = '" & edad & "', PlanSalud = '" & salud.Text & "', Curso = '" & curso.Text & "', Becado = 1 ", conn)
                                    End If
                                ElseIf FormAlumnosMatriculados.cbNoBecados.Checked = True Then
                                    adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud WHERE RutAlumno = '" & rut & "', NombreCompleto = '" & nombre & "', ApePaterno = '" & apellido & "', Edad = '" & edad & "', PlanSalud = '" & salud.Text & "', Curso = '" & curso.Text & "', Becado = 0 ", conn)
                                Else
                                    adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud WHERE RutAlumno = '" & rut & "', NombreCompleto = '" & nombre & "', ApePaterno = '" & apellido & "', Edad = '" & edad & "', PlanSalud = '" & salud.Text & "', Curso = '" & curso.Text & "'", conn)
                                End If
                            ElseIf FormAlumnosMatriculados.cbBecados.Checked = True Then
                                If FormAlumnosMatriculados.cbbPorcentaje.Text <> "" Then
                                    adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud WHERE RutAlumno = '" & rut & "', NombreCompleto = '" & nombre & "', ApePaterno = '" & apellido & "', Edad = '" & edad & "', PorcentajeBeca = '" & porcentaje.Text & "', Curso = '" & curso.Text & "', Becado = 1 ", conn)
                                Else
                                    adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud WHERE RutAlumno = '" & rut & "', NombreCompleto = '" & nombre & "', ApePaterno = '" & apellido & "', Edad = '" & edad & "', Curso = '" & curso.Text & "', Becado = 1 ", conn)
                                End If
                            ElseIf FormAlumnosMatriculados.cbNoBecados.Checked = True Then
                                adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud WHERE RutAlumno = '" & rut & "', NombreCompleto = '" & nombre & "', ApePaterno = '" & apellido & "', Edad = '" & edad & "', Curso = '" & curso.Text & "', Becado = 0 ", conn)
                            Else
                                adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud WHERE RutAlumno = '" & rut & "', NombreCompleto = '" & nombre & "', ApePaterno = '" & apellido & "', Edad = '" & edad & "', Curso = '" & curso.Text & "'", conn)
                            End If
                        ElseIf FormAlumnosMatriculados.cbBuscarServSalud.Text <> "" Then
                            If FormAlumnosMatriculados.cbBecados.Checked = True Then
                                If FormAlumnosMatriculados.cbbPorcentaje.Text <> "" Then
                                    adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud WHERE RutAlumno = '" & rut & "', NombreCompleto = '" & nombre & "', ApePaterno = '" & apellido & "', Edad = '" & edad & "', PlanSalud = '" & salud.Text & "', PorcentajeBeca = '" & porcentaje.Text & "', Becado = 1 ", conn)
                                Else
                                    adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud WHERE RutAlumno = '" & rut & "', NombreCompleto = '" & nombre & "', ApePaterno = '" & apellido & "', Edad = '" & edad & "', PlanSalud = '" & salud.Text & "', Becado = 1 ", conn)
                                End If
                            ElseIf FormAlumnosMatriculados.cbNoBecados.Checked = True Then
                                adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud WHERE RutAlumno = '" & rut & "', NombreCompleto = '" & nombre & "', ApePaterno = '" & apellido & "', Edad = '" & edad & "', PlanSalud = '" & salud.Text & "', Becado = 0 ", conn)
                            Else
                                adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud WHERE RutAlumno = '" & rut & "', NombreCompleto = '" & nombre & "', ApePaterno = '" & apellido & "', Edad = '" & edad & "', PlanSalud = '" & salud.Text & "'", conn)
                            End If
                        ElseIf FormAlumnosMatriculados.cbBecados.Checked = True Then
                            If FormAlumnosMatriculados.cbbPorcentaje.Text <> "" Then
                                adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud WHERE RutAlumno = '" & rut & "', NombreCompleto = '" & nombre & "', ApePaterno = '" & apellido & "', Edad = '" & edad & "', PorcentajeBeca = '" & porcentaje.Text & "', Becado = 1 ", conn)
                            Else
                                adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud WHERE RutAlumno = '" & rut & "', NombreCompleto = '" & nombre & "', ApePaterno = '" & apellido & "', Edad = '" & edad & "', Becado = 1 ", conn)
                            End If
                        ElseIf FormAlumnosMatriculados.cbNoBecados.Checked = True Then
                            adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud WHERE RutAlumno = '" & rut & "', NombreCompleto = '" & nombre & "', ApePaterno = '" & apellido & "', Edad = '" & edad & "', Becado = 0 ", conn)
                        Else
                            adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud WHERE RutAlumno = '" & rut & "', NombreCompleto = '" & nombre & "', ApePaterno = '" & apellido & "', Edad = '" & edad & "'", conn)
                        End If
                    ElseIf FormAlumnosMatriculados.cbbCurso.Text <> "" Then
                        If FormAlumnosMatriculados.cbBuscarServSalud.Text <> "" Then
                            If FormAlumnosMatriculados.cbBecados.Checked = True Then
                                If FormAlumnosMatriculados.cbbPorcentaje.Text <> "" Then
                                    adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud WHERE RutAlumno = '" & rut & "', NombreCompleto = '" & nombre & "', ApePaterno = '" & apellido & "', PlanSalud = '" & salud.Text & "', PorcentajeBeca = '" & porcentaje.Text & "', Curso = '" & curso.Text & "', Becado = 1 ", conn)
                                Else
                                    adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud WHERE RutAlumno = '" & rut & "', NombreCompleto = '" & nombre & "', ApePaterno = '" & apellido & "', PlanSalud = '" & salud.Text & "', Curso = '" & curso.Text & "', Becado = 1 ", conn)
                                End If
                            ElseIf FormAlumnosMatriculados.cbNoBecados.Checked = True Then
                                adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud WHERE RutAlumno = '" & rut & "', NombreCompleto = '" & nombre & "', ApePaterno = '" & apellido & "', PlanSalud = '" & salud.Text & "', Curso = '" & curso.Text & "', Becado = 0 ", conn)
                            Else
                                adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud WHERE RutAlumno = '" & rut & "', NombreCompleto = '" & nombre & "', ApePaterno = '" & apellido & "', PlanSalud = '" & salud.Text & "', Curso = '" & curso.Text & "'", conn)
                            End If
                        End If
                    ElseIf FormAlumnosMatriculados.cbBuscarServSalud.Text <> "" Then
                        If FormAlumnosMatriculados.cbBecados.Checked = True Then
                            If FormAlumnosMatriculados.cbbPorcentaje.Text <> "" Then
                                adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud WHERE RutAlumno = '" & rut & "', NombreCompleto = '" & nombre & "', ApePaterno = '" & apellido & "', PlanSalud = '" & salud.Text & "', PorcentajeBeca = '" & porcentaje.Text & "', Becado = 1 ", conn)
                            Else
                                adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud WHERE RutAlumno = '" & rut & "', NombreCompleto = '" & nombre & "', ApePaterno = '" & apellido & "', PlanSalud = '" & salud.Text & "', Becado = 1 ", conn)
                            End If
                        ElseIf FormAlumnosMatriculados.cbNoBecados.Checked = True Then
                            adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud WHERE RutAlumno = '" & rut & "', NombreCompleto = '" & nombre & "', ApePaterno = '" & apellido & "', PlanSalud = '" & salud.Text & "', Becado = 0 ", conn)
                        Else
                            adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud WHERE RutAlumno = '" & rut & "', NombreCompleto = '" & nombre & "', ApePaterno = '" & apellido & "', PlanSalud = '" & salud.Text & "'", conn)
                        End If
                    ElseIf FormAlumnosMatriculados.cbBecados.Checked = True Then
                        If FormAlumnosMatriculados.cbbPorcentaje.Text <> "" Then
                            adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud WHERE RutAlumno = '" & rut & "', NombreCompleto = '" & nombre & "', ApePaterno = '" & apellido & "', PorcentajeBeca = '" & porcentaje.Text & "', Becado = 1 ", conn)
                        Else
                            adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud WHERE RutAlumno = '" & rut & "', NombreCompleto = '" & nombre & "', ApePaterno = '" & apellido & "', Becado = 1 ", conn)
                        End If
                    ElseIf FormAlumnosMatriculados.cbNoBecados.Checked = True Then
                        adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud WHERE RutAlumno = '" & rut & "', NombreCompleto = '" & nombre & "', ApePaterno = '" & apellido & "', Becado = 0 ", conn)
                    Else
                        adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud WHERE RutAlumno = '" & rut & "', NombreCompleto = '" & nombre & "', ApePaterno = '" & apellido & "'", conn)
                    End If
                ElseIf FormAlumnosMatriculados.txtEdad.Text <> "" Then
                    If FormAlumnosMatriculados.cbbCurso.Text <> "" Then
                        If FormAlumnosMatriculados.cbBuscarServSalud.Text <> "" Then
                            If FormAlumnosMatriculados.cbBecados.Checked = True Then
                                If FormAlumnosMatriculados.cbbPorcentaje.Text <> "" Then
                                    adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud WHERE RutAlumno = '" & rut & "', NombreCompleto = '" & nombre & "', Edad = '" & edad & "', PlanSalud = '" & salud.Text & "', PorcentajeBeca = '" & porcentaje.Text & "', Curso = '" & curso.Text & "', Becado = 1 ", conn)
                                Else
                                    adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud WHERE RutAlumno = '" & rut & "', NombreCompleto = '" & nombre & "', Edad = '" & edad & "', PlanSalud = '" & salud.Text & "', Curso = '" & curso.Text & "', Becado = 1 ", conn)
                                End If
                            ElseIf FormAlumnosMatriculados.cbNoBecados.Checked = True Then
                                adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud WHERE RutAlumno = '" & rut & "', NombreCompleto = '" & nombre & "', Edad = '" & edad & "', PlanSalud = '" & salud.Text & "', Curso = '" & curso.Text & "', Becado = 0 ", conn)
                            Else
                                adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud WHERE RutAlumno = '" & rut & "', NombreCompleto = '" & nombre & "', Edad = '" & edad & "', PlanSalud = '" & salud.Text & "', Curso = '" & curso.Text & "'", conn)
                            End If
                        End If
                    End If
                ElseIf FormAlumnosMatriculados.cbbCurso.Text <> "" Then
                    If FormAlumnosMatriculados.cbBuscarServSalud.Text <> "" Then
                        If FormAlumnosMatriculados.cbBecados.Checked = True Then
                            If FormAlumnosMatriculados.cbbPorcentaje.Text <> "" Then
                                adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud WHERE RutAlumno = '" & rut & "', NombreCompleto = '" & nombre & "', PlanSalud = '" & salud.Text & "', PorcentajeBeca = '" & porcentaje.Text & "', Curso = '" & curso.Text & "', Becado = 1 ", conn)
                            Else
                                adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud WHERE RutAlumno = '" & rut & "', NombreCompleto = '" & nombre & "', PlanSalud = '" & salud.Text & "', Curso = '" & curso.Text & "', Becado = 1 ", conn)
                            End If
                        ElseIf FormAlumnosMatriculados.cbNoBecados.Checked = True Then
                            adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud WHERE RutAlumno = '" & rut & "', NombreCompleto = '" & nombre & "', PlanSalud = '" & salud.Text & "', Curso = '" & curso.Text & "', Becado = 0 ", conn)
                        Else
                            adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud WHERE RutAlumno = '" & rut & "', NombreCompleto = '" & nombre & "', PlanSalud = '" & salud.Text & "', Curso = '" & curso.Text & "'", conn)
                        End If
                    End If
                ElseIf FormAlumnosMatriculados.cbBuscarServSalud.Text <> "" Then
                    If FormAlumnosMatriculados.cbBecados.Checked = True Then
                        If FormAlumnosMatriculados.cbbPorcentaje.Text <> "" Then
                            adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud WHERE RutAlumno = '" & rut & "', NombreCompleto = '" & nombre & "', PlanSalud = '" & salud.Text & "', PorcentajeBeca = '" & porcentaje.Text & "', Becado = 1 ", conn)
                        Else
                            adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud WHERE RutAlumno = '" & rut & "', NombreCompleto = '" & nombre & "', PlanSalud = '" & salud.Text & "', Becado = 1 ", conn)
                        End If
                    ElseIf FormAlumnosMatriculados.cbNoBecados.Checked = True Then
                        adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud WHERE RutAlumno = '" & rut & "', NombreCompleto = '" & nombre & "', PlanSalud = '" & salud.Text & "', Becado = 0 ", conn)
                    Else
                        adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud WHERE RutAlumno = '" & rut & "', NombreCompleto = '" & nombre & "', PlanSalud = '" & salud.Text & "'", conn)
                    End If
                ElseIf FormAlumnosMatriculados.cbBecados.Checked = True Then
                    If FormAlumnosMatriculados.cbbPorcentaje.Text <> "" Then
                        adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud WHERE RutAlumno = '" & rut & "', NombreCompleto = '" & nombre & "', PorcentajeBeca = '" & porcentaje.Text & "', Becado = 1 ", conn)
                    Else
                        adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud WHERE RutAlumno = '" & rut & "', NombreCompleto = '" & nombre & "', Becado = 1 ", conn)
                    End If
                ElseIf FormAlumnosMatriculados.cbNoBecados.Checked = True Then
                    adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud WHERE RutAlumno = '" & rut & "', NombreCompleto = '" & nombre & "', Becado = 0 ", conn)
                Else
                    adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud WHERE RutAlumno = '" & rut & "', NombreCompleto = '" & nombre & "'", conn)
                End If
            ElseIf FormAlumnosMatriculados.txtApePaterno.Text <> "" Then
                If FormAlumnosMatriculados.txtEdad.Text <> "" Then
                    If FormAlumnosMatriculados.cbbCurso.Text <> "" Then
                        If FormAlumnosMatriculados.cbBuscarServSalud.Text <> "" Then
                            If FormAlumnosMatriculados.cbBecados.Checked = True Then
                                If FormAlumnosMatriculados.cbbPorcentaje.Text <> "" Then
                                    adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud WHERE RutAlumno = '" & rut & "', ApePaterno = '" & apellido & "', Edad = '" & edad & "', PlanSalud = '" & salud.Text & "', PorcentajeBeca = '" & porcentaje.Text & "', Curso = '" & curso.Text & "', Becado = 1 ", conn)
                                Else
                                    adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud WHERE RutAlumno = '" & rut & "', ApePaterno = '" & apellido & "', Edad = '" & edad & "', PlanSalud = '" & salud.Text & "', Curso = '" & curso.Text & "', Becado = 1 ", conn)
                                End If
                            ElseIf FormAlumnosMatriculados.cbNoBecados.Checked = True Then
                                adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud WHERE RutAlumno = '" & rut & "', ApePaterno = '" & apellido & "', Edad = '" & edad & "', PlanSalud = '" & salud.Text & "', Curso = '" & curso.Text & "', Becado = 0 ", conn)
                            Else
                                adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud WHERE RutAlumno = '" & rut & "', ApePaterno = '" & apellido & "', Edad = '" & edad & "', PlanSalud = '" & salud.Text & "', Curso = '" & curso.Text & "'", conn)
                            End If
                        End If
                    End If
                End If
            ElseIf FormAlumnosMatriculados.txtEdad.Text <> "" Then
                If FormAlumnosMatriculados.cbbCurso.Text <> "" Then
                    If FormAlumnosMatriculados.cbBuscarServSalud.Text <> "" Then
                        If FormAlumnosMatriculados.cbBecados.Checked = True Then
                            If FormAlumnosMatriculados.cbbPorcentaje.Text <> "" Then
                                adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud WHERE RutAlumno = '" & rut & "', Edad = '" & edad & "', PlanSalud = '" & salud.Text & "', PorcentajeBeca = '" & porcentaje.Text & "', Curso = '" & curso.Text & "', Becado = 1 ", conn)
                            Else
                                adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud WHERE RutAlumno = '" & rut & "', Edad = '" & edad & "', PlanSalud = '" & salud.Text & "', Curso = '" & curso.Text & "', Becado = 1 ", conn)
                            End If
                        ElseIf FormAlumnosMatriculados.cbNoBecados.Checked = True Then
                            adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud WHERE RutAlumno = '" & rut & "', Edad = '" & edad & "', PlanSalud = '" & salud.Text & "', Curso = '" & curso.Text & "', Becado = 0 ", conn)
                        Else
                            adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud WHERE RutAlumno = '" & rut & "', Edad = '" & edad & "', PlanSalud = '" & salud.Text & "', Curso = '" & curso.Text & "'", conn)
                        End If
                    End If
                End If
            ElseIf FormAlumnosMatriculados.cbbCurso.Text <> "" Then
                If FormAlumnosMatriculados.cbBuscarServSalud.Text <> "" Then
                    If FormAlumnosMatriculados.cbBecados.Checked = True Then
                        If FormAlumnosMatriculados.cbbPorcentaje.Text <> "" Then
                            adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud WHERE RutAlumno = '" & rut & "', PlanSalud = '" & salud.Text & "', PorcentajeBeca = '" & porcentaje.Text & "', Curso = '" & curso.Text & "', Becado = 1 ", conn)
                        Else
                            adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud WHERE RutAlumno = '" & rut & "', PlanSalud = '" & salud.Text & "', Curso = '" & curso.Text & "', Becado = 1 ", conn)
                        End If
                    ElseIf FormAlumnosMatriculados.cbNoBecados.Checked = True Then
                        adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud WHERE RutAlumno = '" & rut & "', PlanSalud = '" & salud.Text & "', Curso = '" & curso.Text & "', Becado = 0 ", conn)
                    Else
                        adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud WHERE RutAlumno = '" & rut & "', PlanSalud = '" & salud.Text & "', Curso = '" & curso.Text & "'", conn)
                    End If
                End If
            ElseIf FormAlumnosMatriculados.cbBuscarServSalud.Text <> "" Then
                If FormAlumnosMatriculados.cbBecados.Checked = True Then
                    If FormAlumnosMatriculados.cbbPorcentaje.Text <> "" Then
                        adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud WHERE RutAlumno = '" & rut & "', PlanSalud = '" & salud.Text & "', PorcentajeBeca = '" & porcentaje.Text & "', Becado = 1 ", conn)
                    Else
                        adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud WHERE RutAlumno = '" & rut & "', PlanSalud = '" & salud.Text & "', Becado = 1 ", conn)
                    End If
                ElseIf FormAlumnosMatriculados.cbNoBecados.Checked = True Then
                    adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud WHERE RutAlumno = '" & rut & "', PlanSalud = '" & salud.Text & "', Becado = 0 ", conn)
                Else
                    adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud WHERE RutAlumno = '" & rut & "', PlanSalud = '" & salud.Text & "'", conn)
                End If
            ElseIf FormAlumnosMatriculados.cbBecados.Checked = True Then
                If FormAlumnosMatriculados.cbbPorcentaje.Text <> "" Then
                    adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud WHERE RutAlumno = '" & rut & "', PorcentajeBeca = '" & porcentaje.Text & "', Becado = 1 ", conn)
                Else
                    adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud WHERE RutAlumno = '" & rut & "', Becado = 1 ", conn)
                End If
            ElseIf FormAlumnosMatriculados.cbNoBecados.Checked = True Then
                adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud WHERE RutAlumno = '" & rut & "', Becado = 0 ", conn)
            Else
                adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud WHERE RutAlumno = '" & rut & "'", conn)
            End If
        ElseIf FormAlumnosMatriculados.txtNombre.Text <> "" Then
            If FormAlumnosMatriculados.txtApePaterno.Text <> "" Then
                If FormAlumnosMatriculados.txtEdad.Text <> "" Then
                    If FormAlumnosMatriculados.cbbCurso.Text <> "" Then
                        If FormAlumnosMatriculados.cbBuscarServSalud.Text <> "" Then
                            If FormAlumnosMatriculados.cbBecados.Checked = True Then
                                If FormAlumnosMatriculados.cbbPorcentaje.Text <> "" Then
                                    adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud WHERE NombreCompleto = '" & nombre & "', ApePaterno = '" & apellido & "', Edad = '" & edad & "', PlanSalud = '" & salud.Text & "', PorcentajeBeca = '" & porcentaje.Text & "', Curso = '" & curso.Text & "', Becado = 1 ", conn)
                                Else
                                    adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud WHERE NombreCompleto = '" & nombre & "', ApePaterno = '" & apellido & "', Edad = '" & edad & "', PlanSalud = '" & salud.Text & "', Curso = '" & curso.Text & "', Becado = 1 ", conn)
                                End If
                            ElseIf FormAlumnosMatriculados.cbNoBecados.Checked = True Then
                                adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud WHERE NombreCompleto = '" & nombre & "', ApePaterno = '" & apellido & "', Edad = '" & edad & "', PlanSalud = '" & salud.Text & "', Curso = '" & curso.Text & "', Becado = 0 ", conn)
                            Else
                                adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud WHERE NombreCompleto = '" & nombre & "', ApePaterno = '" & apellido & "', Edad = '" & edad & "', PlanSalud = '" & salud.Text & "', Curso = '" & curso.Text & "'", conn)
                            End If
                        ElseIf FormAlumnosMatriculados.cbBecados.Checked = True Then
                            If FormAlumnosMatriculados.cbbPorcentaje.Text <> "" Then
                                adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud WHERE NombreCompleto = '" & nombre & "', ApePaterno = '" & apellido & "', Edad = '" & edad & "', PorcentajeBeca = '" & porcentaje.Text & "', Curso = '" & curso.Text & "', Becado = 1 ", conn)
                            Else
                                adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud WHERE NombreCompleto = '" & nombre & "', ApePaterno = '" & apellido & "', Edad = '" & edad & "', Curso = '" & curso.Text & "', Becado = 1 ", conn)
                            End If
                        ElseIf FormAlumnosMatriculados.cbNoBecados.Checked = True Then
                            adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud WHERE NombreCompleto = '" & nombre & "', ApePaterno = '" & apellido & "', Edad = '" & edad & "', Curso = '" & curso.Text & "', Becado = 0 ", conn)
                        Else
                            adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud WHERE NombreCompleto = '" & nombre & "', ApePaterno = '" & apellido & "', Edad = '" & edad & "', Curso = '" & curso.Text & "'", conn)
                        End If
                    End If
                End If
            Else
                adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud WHERE NombreCompleto = '" & nombre & "'", conn)
            End If
        ElseIf FormAlumnosMatriculados.txtApePaterno.Text <> "" Then
            If FormAlumnosMatriculados.txtEdad.Text <> "" Then
                If FormAlumnosMatriculados.cbbCurso.Text <> "" Then
                    If FormAlumnosMatriculados.cbBuscarServSalud.Text <> "" Then
                        If FormAlumnosMatriculados.cbBecados.Checked = True Then
                            If FormAlumnosMatriculados.cbbPorcentaje.Text <> "" Then
                                adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud WHERE Becado = 1, Edad = '" & edad & "', Curso = '" & curso.Text & "', PorcentajeBeca = '" & porcentaje.Text & "', PlanSalud = '" & salud.Text & "', ApePaterno = '" & apellido & "'", conn)
                            Else
                                adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud WHERE Becado = 1, Edad = '" & edad & "', Curso = '" & curso.Text & "', PlanSalud = '" & salud.Text & "', ApePaterno = '" & apellido & "'", conn)
                            End If
                        ElseIf FormAlumnosMatriculados.cbNoBecados.Checked = True Then
                            adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud WHERE Becado = 0, Edad = '" & edad & "', Curso = '" & curso.Text & "', PlanSalud = '" & salud.Text & "', ApePaterno = '" & apellido & "'", conn)
                        Else
                            adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud WHERE Edad = '" & edad & "', Curso = '" & curso.Text & "', PlanSalud = '" & salud.Text & "', ApePaterno = '" & apellido & "'", conn)
                        End If
                    ElseIf FormAlumnosMatriculados.cbBecados.Checked = True Then
                        If FormAlumnosMatriculados.cbbPorcentaje.Text <> "" Then
                            adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud WHERE Becado = 1, Edad = '" & edad & "', Curso = '" & curso.Text & "', PorcentajeBeca = '" & porcentaje.Text & "', ApePaterno = '" & apellido & "'", conn)
                        Else
                            adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud WHERE Becado = 1, Edad = '" & edad & "', Curso = '" & curso.Text & "', ApePaterno = '" & apellido & "'", conn)
                        End If
                    ElseIf FormAlumnosMatriculados.cbNoBecados.Checked = True Then
                        adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud WHERE Becado = 0, Edad = '" & edad & "', Curso = '" & curso.Text & "', ApePaterno = '" & apellido & "'", conn)
                    Else
                        adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud WHERE Edad = '" & edad & "', Curso = '" & curso.Text & "', ApePaterno = '" & apellido & "'", conn)
                    End If
                Else
                    adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud WHERE Edad = '" & edad & "', ApePaterno = '" & apellido & "'", conn)
                End If
            Else
                adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud WHERE ApePaterno = '" & apellido & "'", conn)
            End If
        ElseIf FormAlumnosMatriculados.txtEdad.Text <> "" Then
            If FormAlumnosMatriculados.cbbCurso.Text <> "" Then
                If FormAlumnosMatriculados.cbBuscarServSalud.Text <> "" Then
                    If FormAlumnosMatriculados.cbBecados.Checked = True Then
                        If FormAlumnosMatriculados.cbbPorcentaje.Text <> "" Then
                            adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud WHERE Becado = 1, Edad = '" & edad & "', Curso = '" & curso.Text & "', PorcentajeBeca = '" & porcentaje.Text & "', PlanSalud = '" & salud.Text & "'", conn)
                        Else
                            adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud WHERE Becado = 1, Edad = '" & edad & "', Curso = '" & curso.Text & "', PlanSalud = '" & salud.Text & "'", conn)
                        End If
                    ElseIf FormAlumnosMatriculados.cbNoBecados.Checked = True Then
                        adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud WHERE Becado = 0, Edad = '" & edad & "', Curso = '" & curso.Text & "', PlanSalud = '" & salud.Text & "'", conn)
                    Else
                        adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud WHERE Edad = '" & edad & "', Curso = '" & curso.Text & "', PlanSalud = '" & salud.Text & "'", conn)
                    End If
                ElseIf FormAlumnosMatriculados.cbBecados.Checked = True Then
                    If FormAlumnosMatriculados.cbbPorcentaje.Text <> "" Then
                        adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud WHERE Becado = 1, Edad = '" & edad & "', Curso = '" & curso.Text & "', PorcentajeBeca = '" & porcentaje.Text & "'", conn)
                    Else
                        adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud WHERE Becado = 1, Edad = '" & edad & "', Curso = '" & curso.Text & "'", conn)
                    End If
                ElseIf FormAlumnosMatriculados.cbNoBecados.Checked = True Then
                    adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud WHERE Becado = 0, Edad = '" & edad & "', Curso = '" & curso.Text & "'", conn)
                Else
                    adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud WHERE Edad = '" & edad & "', Curso = '" & curso.Text & "'", conn)
                End If
            Else
                adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud WHERE Edad = '" & edad & "'", conn)
            End If
        ElseIf FormAlumnosMatriculados.cbbCurso.Text <> "" Then
            If FormAlumnosMatriculados.cbBuscarServSalud.Text <> "" Then
                If FormAlumnosMatriculados.cbBecados.Checked = True Then
                    If FormAlumnosMatriculados.cbbPorcentaje.Text <> "" Then
                        adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud WHERE Becado = 1, Curso = '" & curso.Text & "', PorcentajeBeca = '" & porcentaje.Text & "', PlanSalud = '" & salud.Text & "'", conn)
                    Else
                        adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud WHERE Becado = 1, Curso = '" & curso.Text & "', PlanSalud = '" & salud.Text & "'", conn)
                    End If
                ElseIf FormAlumnosMatriculados.cbNoBecados.Checked = True Then
                    adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud WHERE Becado = 0, Curso = '" & curso.Text & "', PlanSalud = '" & salud.Text & "'", conn)
                Else
                    adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud WHERE Curso = '" & curso.Text & "', PlanSalud = '" & salud.Text & "'", conn)
                End If
            ElseIf FormAlumnosMatriculados.cbBecados.Checked = True Then
                If FormAlumnosMatriculados.cbbPorcentaje.Text <> "" Then
                    adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud WHERE Becado = 1, Curso = '" & curso.Text & "', PorcentajeBeca = '" & porcentaje.Text & "'", conn)
                Else
                    adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud WHERE Becado = 1, Curso = '" & curso.Text & "'", conn)
                End If
            ElseIf FormAlumnosMatriculados.cbNoBecados.Checked = True Then
                adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud WHERE Becado = 0, Curso = '" & curso.Text & "'", conn)
            Else
                adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud WHERE Curso = '" & curso.Text & "'", conn)
            End If
        ElseIf FormAlumnosMatriculados.cbBuscarServSalud.Text <> "" Then
            If FormAlumnosMatriculados.cbBecados.Checked = True Then
                If FormAlumnosMatriculados.cbbPorcentaje.Text <> "" Then
                    adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud WHERE Becado = 1, PorcentajeBeca = '" & porcentaje.Text & "', PlanSalud = '" & salud.Text & "'", conn)
                Else
                    adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud WHERE Becado = 1, PlanSalud = '" & salud.Text & "'", conn)
                End If
            ElseIf FormAlumnosMatriculados.cbNoBecados.Checked = True Then
                adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud WHERE Becado = 0, PlanSalud = '" & salud.Text & "'", conn)
            Else
                adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud WHERE PlanSalud = '" & salud.Text & "'", conn)
            End If
        ElseIf FormAlumnosMatriculados.cbBecados.Checked = True Then
            If FormAlumnosMatriculados.cbbPorcentaje.Text <> "" Then
                adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud WHERE Becado = 1, PorcentajeBeca = '" & porcentaje.Text & "'", conn)
            Else
                adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud WHERE Becado = 1", conn)
            End If
        ElseIf FormAlumnosMatriculados.cbNoBecados.Checked = True Then
            adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud WHERE Becado = 0", conn)
        Else
            adapter.SelectCommand = New MySqlCommand("SELECT NombreCompleto, ApePaterno, ApeMaterno, Sexo, FechaNac, Edad, Domicilio, SectorVilla, Comuna, Telefono, ColegioPresedencia, Curso, CursosRepetidos, Becado, PorcentajeBeca, HermanosEstablecimiento, AlumnoViveCon, AntecedentesMedicos, PlanSalud FROM alumno inner join servicio_por_alumno ON alumno.RutAlumno = servicio_por_alumno.Alumno_RutAlumno inner join servicio_salud on servicio_por_alumno.Servicio_salud_idServicio_salud = servicio_salud.idServicio_salud", conn)
        End If

        adapter.Fill(dataSet)
        dgv.DataSource = dataSet.Tables(0)
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
                MessageBox.Show("Contacto de emergencia ingresado")
                Return True

            ElseIf FormularioMatricula.ComboBox1.Text = "2 Contactos" Then

                Dim _comando3 As New MySqlCommand(consultaContactEmer1, FormularioMatricula.varConexion)
                _comando3.ExecuteNonQuery()
                Dim _comando4 As New MySqlCommand(consultaContactEmer2, FormularioMatricula.varConexion)
                _comando4.ExecuteNonQuery()
                MessageBox.Show("Contactos de emergencia ingresado")
                Return True

            ElseIf FormularioMatricula.ComboBox1.Text = "3 Contactos" Then

                Dim _comando5 As New MySqlCommand(consultaContactEmer1, FormularioMatricula.varConexion)
                _comando5.ExecuteNonQuery()
                Dim _comando6 As New MySqlCommand(consultaContactEmer2, FormularioMatricula.varConexion)
                _comando6.ExecuteNonQuery()
                Dim _comando7 As New MySqlCommand(consultaContactEmer3, FormularioMatricula.varConexion)
                _comando7.ExecuteNonQuery()
                MessageBox.Show("Contactos de emergencia ingresados")
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
            MessageBox.Show("padre agregado")
            Return True
        Catch ex As Exception
            MessageBox.Show("Error al ingresar padreeeeeeeeeeeeeeeeeeeee")
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
            MessageBox.Show("Madre agregada")
            Return True
        Catch ex As Exception
            MessageBox.Show("Error al ingresar Madreeeeeeeeeeeeeeeeeeeee")
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
            MessageBox.Show("Erroooooooooooooooor al ingresaaaaaaaaaaaaaaaaaaaaar")
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
            MessageBox.Show("Erroooooooooooooooor al ingresaaaaar responsable completo")
            Return False
        End Try

    End Function

    Public Function insertarAlumno_respons(ByRef rutResponsable As String, ByRef rutAlumno As String, ByRef tipoResp As String, _
                                           ByRef apoderado As Integer, ByRef apodSuplente As Integer) As Boolean

        Try
            Dim consulta As String = "INSERT INTO `bd_echaurren`.`responsable_alumno` (`Responsable_RutResponsable`, `Alumno_RutAlumno`, `Tipo_responsable_idTipo_responsable`, `Apoderado`, `ApoderadoSuplente`) VALUES ('" & rutResponsable & "', '" & rutAlumno & "', '" & tipoResp & "', '" & apoderado & "', '" & apodSuplente & "');"
            Dim _comando As New MySqlCommand(consulta, FormularioMatricula.varConexion)
            _comando.ExecuteNonQuery()
            MessageBox.Show("relacion responsable - alumno exitosa")
            Return True
        Catch ex As Exception
            MessageBox.Show("error al relacionar responsable - alumno")
            Return False
        End Try

    End Function

    Public Function insertarAlumno_respons_tutor(ByRef rutResponsable As String, ByRef rutAlumno As String, ByRef tipoResp As String, _
                                           ByRef apoderado As Integer, ByRef apodSuplente As Integer, _
                                           ByRef OtroTutor As String) As Boolean

        Try
            Dim consulta As String = "INSERT INTO `bd_echaurren`.`responsable_alumno` (`Responsable_RutResponsable`, `Alumno_RutAlumno`, `Tipo_responsable_idTipo_responsable`, `Apoderado`, `ApoderadoSuplente`, `Otro_tutor`) VALUES ('" & rutResponsable & "', '" & rutAlumno & "', '" & tipoResp & "', '" & apoderado & "', '" & apodSuplente & "', '" & OtroTutor & "');"
            Dim comando As New MySqlCommand(consulta, FormularioMatricula.varConexion)
            comando.ExecuteNonQuery()
            MessageBox.Show("relacion responsable, tutor - alumno exitosa")
            Return True
        Catch ex As Exception
            MessageBox.Show("error al relacionar responsable, tutor - alumno")
            Return False
        End Try
    End Function



    Public Function insertarOtroApod(ByRef rutOtroApod As String, ByRef rutAlumno As String, ByRef apoderado As Integer, _
                                     ByRef apodSuplente As Integer, ByRef nombreOtroResp As String) As Boolean

        Try

            Dim tipoResp As String = "tr4"
            Dim consulta As String = "INSERT INTO `bd_echaurren`.`responsable` (`RutResponsable`, `NombreCompleto`) VALUES ('" & rutOtroApod & "', '" & nombreOtroResp & "');"
            Dim consulta1 As String = "INSERT INTO `bd_echaurren`.`responsable_alumno` (`Responsable_RutResponsable`, `Alumno_RutAlumno`, `Tipo_responsable_idTipo_responsable`, `Apoderado`, `ApoderadoSuplente`) VALUES ('" & rutOtroApod & "', '" & rutAlumno & "', '" & tipoResp & "', '" & apoderado & "', '" & apodSuplente & "');"

            Dim comando As New MySqlCommand(consulta, FormularioMatricula.varConexion)
            comando.ExecuteNonQuery()
            Dim comando2 As New MySqlCommand(consulta1, FormularioMatricula.varConexion)
            comando2.ExecuteNonQuery()
            MessageBox.Show("SE INGRESO OTRO APOD SUPLENTE")
            Return True
        Catch ex As Exception
            MessageBox.Show("ERROR AL INGRESO OTRO APOD SUPLENTE")
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
End Module
