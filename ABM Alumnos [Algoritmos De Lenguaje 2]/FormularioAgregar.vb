'
' Created on 2020
'
' Copyright (c) 2023 UsuiSama
'

Public Class FormularioAgregar
    Private _Estado As Boolean = False

    Private Sub FormularioAgregar_Load(sender As Object, e As EventArgs) Handles Me.Load
        Text = TituloFormularioAgregar
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Dim NombreDeLosComponentes As String() = {"Nombre", "Apellido", "DNI", "Direccion",
            "Telefono", "Localidad", "Foto", "Email"}
        Dim ValoresAlmacenadoEnLosComponentes As String() = {tbNombre.Text, tbApellido.Text, tbDNI.Text, tbDireccion.Text,
            tbTelefono.Text, cbLocalidad.Text, tbFoto.Text, tbEmail.Text}

        If VerificarQueNiUnaCajaEsteVacia(NombreDeLosComponentes, ValoresAlmacenadoEnLosComponentes) Then
            MsgBox("Por Favor Ingrese Los Valores Solicitados", vbOKOnly + vbExclamation + vbDefaultButton1, Titulo)
        Else
            If Not VerificarSiLasCajasDeTextoEstanVacias(NombreDeLosComponentes, ValoresAlmacenadoEnLosComponentes) Then
                Dim SelectDNIFrom As String = "SELECT `mydb3`.`alumnos`.`DNI` FROM `mydb3`.`alumnos`;"

                If EjecutarTransaccionComparacion(SelectDNIFrom, tbDNI.Text) Then
                    MsgBox("Los DNI son Iguales, CAPO", vbOKOnly + vbExclamation + vbDefaultButton1, Titulo)
                Else
                    Dim InsertFrom As String = "INSERT INTO `mydb3`.`alumnos`(`Nombre`, `Apellido`, `DNI`, `Direccion`, `Telefono`, `Email`, `Foto`, `Localidad`)" &
            "VALUES ('" & tbNombre.Text & "', '" & tbApellido.Text & "', " & tbDNI.Text & ", '" & tbDireccion.Text & "', " & tbTelefono.Text & ", " &
            "'" & tbEmail.Text & "', '" & tbFoto.Text & "', '" & cbLocalidad.Text & "');"
                    If EjecutarTransaccion(InsertFrom) Then
                        MsgBox("Registro insertado correctamente")
                        _Estado = True
                        Close()
                    Else
                        MsgBox("FALLA EN LA INSERCION")
                    End If
                End If
            End If
        End If
    End Sub

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

    Public ReadOnly Property Estado() As Boolean
        Get
            Return _Estado
        End Get
    End Property
End Class


