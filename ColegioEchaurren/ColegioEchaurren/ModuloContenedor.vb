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
End Module
