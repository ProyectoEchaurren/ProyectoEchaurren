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

End Module
