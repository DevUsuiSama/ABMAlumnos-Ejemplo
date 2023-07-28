'
' Created on 2020
'
' Copyright (c) 2023 UsuiSama
'

Public Class FormularioModificar
    Private _TablaAlumnos As DataTable
    Private _Estado As Boolean = False

    Private Sub tbFoto_Click(sender As Object, e As EventArgs) Handles btnFoto.Click
        If OpenFileDialog1.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            tbFoto.Text = OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub tbString_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbNombre.KeyPress, tbDireccion.KeyPress, tbApellido.KeyPress
        If Not Char.IsLetter(e.KeyChar) And Not ControlChars.Back = e.KeyChar And Not Char.IsWhiteSpace(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub tbInteger_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbDNI.KeyPress, tbTelefono.KeyPress
        If Not Char.IsDigit(e.KeyChar) And Not ControlChars.Back = e.KeyChar Then
            e.Handled = True
        End If
    End Sub

    Private Sub tbEmail_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbEmail.KeyPress
        If Not e.KeyChar = "." And Not e.KeyChar = "@" And Not Char.IsLetterOrDigit(e.KeyChar) And Not ControlChars.Back = e.KeyChar Then
            e.Handled = True
        End If
    End Sub

    Private Sub cbLocalidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbLocalidad.KeyPress
        If e IsNot Nothing Then
            e.Handled = True
        End If
    End Sub

    Private Sub FormularioModificar_Load(sender As Object, e As EventArgs) Handles Me.Load
        Text = TituloFormularioModificar
        tbNombre.Text = _TablaAlumnos.Rows(0)("Nombre")
        tbApellido.Text = _TablaAlumnos.Rows(0)("Apellido")
        tbDNI.Text = CStr(_TablaAlumnos.Rows(0)("DNI"))
        tbDireccion.Text = _TablaAlumnos.Rows(0)("Direccion")
        tbTelefono.Text = CStr(_TablaAlumnos.Rows(0)("Telefono"))
        cbLocalidad.Text = _TablaAlumnos.Rows(0)("Localidad")
        tbFoto.Text = _TablaAlumnos.Rows(0)("Foto")
        tbEmail.Text = _TablaAlumnos.Rows(0)("Email")
    End Sub

    Private Function CompararDatosModificados(ValoresAlmacenadoEnLosComponentes As String()) As Boolean
        Dim Auxiliar() As String = {_TablaAlumnos.Rows(0)("Nombre"), _TablaAlumnos.Rows(0)("Apellido"), CStr(_TablaAlumnos.Rows(0)("DNI")),
            _TablaAlumnos.Rows(0)("Direccion"), _TablaAlumnos.Rows(0)("Telefono"), _TablaAlumnos.Rows(0)("Localidad"), _TablaAlumnos.Rows(0)("Foto"),
            _TablaAlumnos.Rows(0)("Email")}

        Dim iTotal As Integer = 0

        For i As Integer = 0 To ValoresAlmacenadoEnLosComponentes.Length - 1
            If Auxiliar(i) = ValoresAlmacenadoEnLosComponentes(i) Then iTotal += 1
        Next
        If iTotal = ValoresAlmacenadoEnLosComponentes.Length Then Return True
        Return False
    End Function

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Dim NombreDeLosComponentes As String() = {"Nombre", "Apellido", "DNI", "Direccion",
            "Telefono", "Localidad", "Foto", "Email"}
        Dim ValoresAlmacenadoEnLosComponentes As String() = {tbNombre.Text, tbApellido.Text, tbDNI.Text, tbDireccion.Text,
            tbTelefono.Text, cbLocalidad.Text, tbFoto.Text, tbEmail.Text}

        If VerificarQueNiUnaCajaEsteVacia(NombreDeLosComponentes, ValoresAlmacenadoEnLosComponentes) Then
            MsgBox("Por Favor Ingrese Los Valores Solicitados", vbOKOnly + vbExclamation + vbDefaultButton1, Titulo)
        Else
            If Not VerificarSiLasCajasDeTextoEstanVacias(NombreDeLosComponentes, ValoresAlmacenadoEnLosComponentes) Then
                If CompararDatosModificados(ValoresAlmacenadoEnLosComponentes) Then
                    MsgBox("No Cambiaste los datos, GENIO!!!", vbOKOnly + vbExclamation + vbDefaultButton1, Titulo)
                Else
                    Dim UpdateFrom As String = "UPDATE `mydb3`.`alumnos` SET " &
                        "`Nombre` = '" & tbNombre.Text & "', `Apellido` = '" & tbApellido.Text & "', `DNI` = " & tbDNI.Text &
                        ", `Direccion` = '" & tbDireccion.Text & "', `Telefono` = " & tbTelefono.Text & ", " &
            " `Email` = '" & tbEmail.Text & "', `Foto` = '" & tbFoto.Text & "', `Localidad` = '" & cbLocalidad.Text & "' " &
            "WHERE `DNI` = " & CStr(_TablaAlumnos.Rows(0)("DNI")) & ";"

                    If EjecutarTransaccion(UpdateFrom) Then
                        MsgBox("Registro modificado correctamente")
                        _Estado = True
                        Close()
                    Else
                        MsgBox("Falla en la Modificación")
                    End If
                End If
            End If
        End If
    End Sub

    Public WriteOnly Property TablaAlumnos() As DataTable
        Set(value As DataTable)
            _TablaAlumnos = value
        End Set
    End Property

    Public ReadOnly Property Estado() As Boolean
        Get
            Return _Estado
        End Get
    End Property
End Class