Imports MySql.Data.MySqlClient

Module ModuloContenedor

    Public ColumnaRutHistorico As String

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

            Dim consultaIngresoAlumn As String = "INSERT INTO `bd_echaurren`.`alumno` (`RutAlumno`, `NombreCompleto`, `ApePaterno`, `ApeMaterno`, `Sexo`, `FechaNac`, `Edad`, `Domicilio(calle)`, `SectorVilla`, `Comuna`, `Telefono`, `ColegioPresedencia`, `Curso`, `CursosRepetidos`, `Becado`, `HermanosEstablecimiento`, `AlumnoViveCon`, `NumHijosFamilia`, `LugarOcupacionHijos`, `GrupoFamiliarComponen`, `AntecedentesMedicos`, `NumMatricula`, `FechaMatricula`) VALUES ('" & RunAlumno & "', '" & nombresAlumno & "', '" & apellidoPatAlumno & "', '" & apellidoMatAlumno & "', '" & SexoAlumno & "', '" & fechaNacimientoAlumno.Value.ToString("dd/MM/yyyy") & "', '" & EdadAlumno & "', '" & domicilioCalleAlumn & "', '" & sectorAlumno & "', '" & comunaAlumno & "', '" & telefAlumno & "', '" & colegioPrese & "', '" & curso & "', '" & cursosRepet & "', '" & becado & "', '" & hermanosCurso & "', '" & AlumnViveCon & "', '" & numHijos & "', '" & lugarHijos & "', '" & grupoFami & "', '" & anteMedicos & "', '350', '" & fechaMatricula.Value.ToString("dd/MM/yyyy") & "');"
            Dim _comando As New MySqlCommand(consultaIngresoAlumn, FormularioMatricula.varConexion)
            _comando.ExecuteNonQuery()
            MessageBox.Show("Alumno ingresado", "Matricula", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return True

        Catch ex As Exception
            MessageBox.Show("Error al ingresar alumno", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try

    End Function


    Public Function ingresarServSalud(ByRef servicioSalud As String, ByRef otroServicio As String, ByRef seguros As String) As Boolean

        Try
            Dim consultaServSalud As String = "INSERT INTO `bd_echaurren`.`servicio_por_alumno` (`Alumno_RutAlumno`, `Servicio_salud_idServicio_salud`, `Seguros`, `OtrosServicios`) VALUES ('" & FormularioMatricula.txtRutAlumno.Text & "', '" & servicioSalud & "', '" & seguros & "', '" & otroServicio & "');"
            Dim _comando1 As New MySqlCommand(consultaServSalud, FormularioMatricula.varConexion)
            _comando1.ExecuteNonQuery()
            MessageBox.Show("Servicio salud ingresado")
            Return True
        Catch ex As Exception
            MessageBox.Show("Error al ingresar servicio de salud", "Error")
            Return False
        End Try

    End Function

    Public Function FiltrarRut(ByRef rut As String) As String
        Dim nombre As String
        Dim becado As Boolean
        Dim tipopago As String
        Dim monto As Integer
        Dim conn As New MySqlConnection("server=localhost;User Id=root;password=123456;database=bd_echaurren")
        Try
            Dim consultaRut As String = "SELECT NombreCompleto, Becado FROM `bd_echaurren`.`alumno` WHERE RutAlumno = '" & rut & "';"
            Dim _comando1 As New MySqlCommand(consultaRut, conn)
            _comando1.ExecuteNonQuery()
            nombre = "NombreCompleto"
            becado = "Becado"
            tipopago = "alo"
            monto = "123"
            Return True
        Catch ex As Exception
            MessageBox.Show("Alumno No Encontrado", "Error")
            Return False
        End Try

        Return nombre
        Return becado
        Return tipopago
        Return monto

    End Function

    Public Function CargarHistorico(ByRef dgv As DataGridView, ByRef rut As String)
        Dim conn As New MySqlConnection("server=localhost;User Id=root;password=123456;database=bd_echaurren")
        Dim adapter As New MySqlDataAdapter()
        Dim dataSet As New DataSet
        adapter.SelectCommand = New MySqlCommand("SELECT alumno.RutAlumno, NombreCompleto, ApePaterno, Curso, Becado, PorcentajeBeca, NombreMes, Monto, TipoPago, Estado from Alumno inner join Mensualidad WHERE RutAlumno = '" & rut & "'", conn)
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

    Public Function ingresarContactEmergencia(ByRef nombreContacto1 As String, ByRef numContacto1 As String, _
                                              ByRef nombreContacto2 As String, ByRef numContacto2 As String, _
                                              ByRef nombreContacto3 As String, ByRef numContacto3 As String) As Boolean


        Dim consultaContactEmer1 As String = "INSERT INTO `bd_echaurren`.`contacto_emergencia` (`NombreContacto`, `Numero`, `Alumno_RutAlumno`) VALUES ('" & nombreContacto1 & "', '" & numContacto1 & "', '" & FormularioMatricula.txtRutAlumno.Text & "');"
        Dim consultaContactEmer2 As String = "INSERT INTO `bd_echaurren`.`contacto_emergencia` (`NombreContacto`, `Numero`, `Alumno_RutAlumno`) VALUES ('" & nombreContacto2 & "', '" & numContacto2 & "', '" & FormularioMatricula.txtRutAlumno.Text & "');"
        Dim consultaContactEmer3 As String = "INSERT INTO `bd_echaurren`.`contacto_emergencia` (`NombreContacto`, `Numero`, `Alumno_RutAlumno`) VALUES ('" & nombreContacto3 & "', '" & numContacto3 & "', '" & FormularioMatricula.txtRutAlumno.Text & "');"

        Try
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
            MessageBox.Show("Error al ingresar contactos de emergencia")
            Return False
        End Try

    End Function

    Public Function insertarPadre(ByRef nombrePadre As String, ByRef rutPadre As String, ByRef edadPadre As String, _
                                   ByRef estudiosPadre As ComboBox, ByRef trabajaEnPadre As String, ByRef telefonoPadre As String, _
                                   ByRef CargoPadre As String, ByRef direccionPadre As String, ByRef correoPadre As String) As Boolean

        Dim consultaPadre As String = "INSERT INTO `bd_echaurren`.`telefono` (`Num1`) VALUES ('" & telefonoPadre & "');"
        Dim consultaPadre2 As String = "INSERT INTO `bd_echaurren`.`responsable` (`RutResponsable`, `NombreCompleto`, `Edad`, `EstudiosCompletados`, `Correo electronico`, `Trabajo`, `Cargo`, `Telefono_idTelefono`) VALUES ('" & rutPadre & "', '" & nombrePadre & "', '" & edadPadre & "', '" & estudiosPadre.Text & "', '" & correoPadre & "', '" & trabajaEnPadre & "', '" & CargoPadre & "', last_insert_id());"
        Dim consultaPadre3 As String = "INSERT INTO `bd_echaurren`.`direccion` (`DireccionTrabajo`) VALUES ('" & direccionPadre & "');"
        Dim consultaPadre4 As String = "UPDATE `bd_echaurren`.`responsable` SET `Direccion_idDireccion`= last_insert_id() WHERE `RutResponsable`='" & rutPadre & "';"

        Try
            Dim _comando8 As New MySqlCommand(consultaPadre, FormularioMatricula.varConexion)
            _comando8.ExecuteNonQuery()
            Dim _comando9 As New MySqlCommand(consultaPadre2, FormularioMatricula.varConexion)
            _comando9.ExecuteNonQuery()
            Dim _comando10 As New MySqlCommand(consultaPadre3, FormularioMatricula.varConexion)
            _comando10.ExecuteNonQuery()
            Dim _comando11 As New MySqlCommand(consultaPadre4, FormularioMatricula.varConexion)
            _comando11.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function insertarMadre(ByRef nombreMadre As String, ByRef rutMadre As String, ByRef edadMadre As String, _
                                   ByRef estudiosMadre As ComboBox, ByRef trabajaEnMadre As String, ByRef telefonoMadre As String, _
                                   ByRef CargoMadre As String, ByRef direccionMadre As String, ByRef correoMadre As String) As Boolean


        Dim consultaMadre As String = "INSERT INTO `bd_echaurren`.`telefono` (`Num1`) VALUES ('" & telefonoMadre & "');"
        Dim consultaMadre2 As String = "INSERT INTO `bd_echaurren`.`responsable` (`RutResponsable`, `NombreCompleto`, `Edad`, `EstudiosCompletados`, `Correo electronico`, `Trabajo`, `Cargo`, `Telefono_idTelefono`) VALUES ('" & rutMadre & "', '" & nombreMadre & "', '" & edadMadre & "', '" & estudiosMadre.Text & "', '" & correoMadre & "', '" & trabajaEnMadre & "', '" & CargoMadre & "', last_insert_id());"
        Dim consultaMadre3 As String = "INSERT INTO `bd_echaurren`.`direccion` (`DireccionTrabajo`) VALUES ('" & direccionMadre & "');"
        Dim consultaMadre4 As String = "UPDATE `bd_echaurren`.`responsable` SET `Direccion_idDireccion`= last_insert_id() WHERE `RutResponsable`='" & rutMadre & "';"


        Try
            Dim _comando12 As New MySqlCommand(consultaMadre, FormularioMatricula.varConexion)
            _comando12.ExecuteNonQuery()
            Dim _comando13 As New MySqlCommand(consultaMadre2, FormularioMatricula.varConexion)
            _comando13.ExecuteNonQuery()
            Dim _comando14 As New MySqlCommand(consultaMadre3, FormularioMatricula.varConexion)
            _comando14.ExecuteNonQuery()
            Dim _comando15 As New MySqlCommand(consultaMadre4, FormularioMatricula.varConexion)
            _comando15.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function
End Module
