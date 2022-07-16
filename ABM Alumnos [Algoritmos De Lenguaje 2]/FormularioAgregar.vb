Public Class FormularioAgregar
    '
    ' Atributos
    '

    '//////////////////////////////////////////////////////////////////////////
    '
    ' Atributos Primordial Para el Funcionamiento del ABM
    '
    '/////////////////////////////////////////////////////////////////////////

    Private _Estado As Boolean = False 'Nos permitira saber si se concreto la operacion para modificar los datos del alumno o no. 

    '
    ' Metodo Privados
    '

    ''' <summary>
    ''' El Procedimiento Form1_Load es llamado antes de que el formulario se muestre por primera vez.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub FormularioAgregar_Load(sender As Object, e As EventArgs) Handles Me.Load
        'En esta linea de codigo obtenemos la Tabla de Datos Consultada a la Base de Datos
        Text = TituloFormularioAgregar
    End Sub

    '//////////////////////////////////////////////////////////////////////////
    '
    ' Boton Agregar
    '
    '//////////////////////////////////////////////////////////////////////////

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Dim NombreDeLosComponentes As String() = {"Nombre", "Apellido", "DNI", "Direccion",
            "Telefono", "Localidad", "Foto", "Email"} 'Lista de Componentes sin su identificador [ejemplo: txtDNI = DNI]

        Dim ValoresAlmacenadoEnLosComponentes As String() = {tbNombre.Text, tbApellido.Text, tbDNI.Text, tbDireccion.Text,
            tbTelefono.Text, cbLocalidad.Text, tbFoto.Text, tbEmail.Text} 'Lista De Los Valores Almacenado en Cada Componente

        'Llamamos al metodo VerificarQueNiUnaCajaEsteVacia() que nos permitira saber si Todas la cajas estan vacias o no.
        If VerificarQueNiUnaCajaEsteVacia(NombreDeLosComponentes, ValoresAlmacenadoEnLosComponentes) Then
            MsgBox("Por Favor Ingrese Los Valores Solicitados", vbOKOnly + vbExclamation + vbDefaultButton1, Titulo)
        Else

            'Llamamos al metodo VerificarSiLasCajasDeTextoEstanVacias() que nos permitira saber si ALGUNAS cajas de texto o caja de combo estan vacias o no.
            If Not VerificarSiLasCajasDeTextoEstanVacias(NombreDeLosComponentes, ValoresAlmacenadoEnLosComponentes) Then

                'ScriptSQL => SELECT DNI FROM ALUMNOS;
                Dim SelectDNIFrom As String = "SELECT `mydb3`.`alumnos`.`DNI` FROM `mydb3`.`alumnos`;"

                'Realizamos una consulta a la base de datos para comparar si el DNI ya existe o no.
                If EjecutarTransaccionComparacion(SelectDNIFrom, tbDNI.Text) Then
                    MsgBox("Los DNI son Iguales, CAPO", vbOKOnly + vbExclamation + vbDefaultButton1, Titulo)
                Else
                    'Tenga en cuenta que este script sql funciona si usted tiene programado su base de dato con AUTO_INCREMENT
                    'Scrip SQL => INSERT INTO Alumnos (Nombre, Apellido, DNI, Direccion, Telefono, Email, Foto, Localidad) VALUES ('Pedro', 'Gimenez', 4929, 'queti', 3764, '@.com', 'imagen', 'queti');
                    Dim InsertFrom As String = "INSERT INTO `mydb3`.`alumnos`(`Nombre`, `Apellido`, `DNI`, `Direccion`, `Telefono`, `Email`, `Foto`, `Localidad`)" &
            "VALUES ('" & tbNombre.Text & "', '" & tbApellido.Text & "', " & tbDNI.Text & ", '" & tbDireccion.Text & "', " & tbTelefono.Text & ", " &
            "'" & tbEmail.Text & "', '" & tbFoto.Text & "', '" & cbLocalidad.Text & "');"

                    If EjecutarTransaccion(InsertFrom) Then 'Ejecutamos el ScripSQL y Obtenemos un valor Boolean
                        ' [Si se ejecuto sin nigun problema nos devuelve True sino nos devolvera un valor False]
                        MsgBox("Registro insertado correctamente")
                        _Estado = True 'Asignamos un valor True al atributo _Estado
                        Close()
                    Else
                        MsgBox("FALLA EN LA INSERCION")
                    End If
                End If
            End If
        End If
    End Sub

    '//////////////////////////////////////////////////////////////////////////
    '
    ' Boton Foto => [...]
    '
    '//////////////////////////////////////////////////////////////////////////

    Private Sub tbFoto_Click(sender As Object, e As EventArgs) Handles btnFoto.Click
        If OpenFileDialog1.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            tbFoto.Text = OpenFileDialog1.FileName
        End If
    End Sub

    ''' <summary>
    ''' Evento Para Las Caja De Texto o TextBox [Nombre, Apellido, Direccion]
    ''' [<c>Control De Validacion de Datos [Evita que se agreguen numeros]</c>]
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub tbString_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbNombre.KeyPress, tbDireccion.KeyPress, tbApellido.KeyPress
        If Not Char.IsLetter(e.KeyChar) And Not ControlChars.Back = e.KeyChar And Not Char.IsWhiteSpace(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    ''' <summary>
    ''' Evento Para Las Caja De Texto o TextBox [DNI, Telefono]
    ''' [<c>Control De Validacion de Datos [Evita que se agreguen letras]</c>]
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub tbInteger_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbDNI.KeyPress, tbTelefono.KeyPress
        If Not Char.IsDigit(e.KeyChar) And Not ControlChars.Back = e.KeyChar Then
            e.Handled = True
        End If
    End Sub

    ''' <summary>
    ''' Evento Para Las Caja De Texto o TextBox [DNI, Telefono]
    ''' [<c>Control De Validacion de Datos [Evita que se agreguen Simbolos demas]</c>]
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub tbEmail_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbEmail.KeyPress
        If Not e.KeyChar = "." And Not e.KeyChar = "@" And Not Char.IsLetterOrDigit(e.KeyChar) And Not ControlChars.Back = e.KeyChar Then
            e.Handled = True
        End If
    End Sub

    ''' <summary>
    ''' Evento Para Las Caja De Texto o TextBox [DNI, Telefono]
    ''' [<c>Control De Validacion de Datos [Evita que se agreguen cualquier simbolo, numero, letra o espacio]</c>]
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub cbLocalidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbLocalidad.KeyPress
        If e IsNot Nothing Then
            e.Handled = True
        End If
    End Sub

    '+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
    ' Metodos y Propiedades con encapsulamiento Publicos 

    Public ReadOnly Property Estado() As Boolean
        Get
            Return _Estado 'Retornamos el valor almacenado en el atributo _Estado
        End Get
    End Property
End Class


