Public Class FormularioModificar
    '
    ' Atributos
    '

    '//////////////////////////////////////////////////////////////////////////
    '
    ' Atributos Primordiales Para el Funcionamiento del ABM
    '
    '//////////////////////////////////////////////////////////////////////////

    Private _TablaAlumnos As DataTable 'Nos ayudara a almacenar la fila seleccionada por el usuario
    Private _Estado As Boolean = False 'Nos permitira saber si se concreto la operacion para modificar los datos del alumno o no. 

    '
    ' Metodo Privados
    '

    '//////////////////////////////////////////////////////////////////////////
    '
    ' Boton Foto => [...]
    '
    '//////////////////////////////////////////////////////////////////////////

    Private Sub tbFoto_Click(sender As Object, e As EventArgs) Handles btnFoto.Click
        'la logica es la siguiente [si presionamos el boton [aceptar] que obtenga la Direccion de la imagen] 
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

    ''' <summary>
    ''' El Procedimiento Form1_Load es llamado antes de que el formulario se muestre por primera vez.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub FormularioModificar_Load(sender As Object, e As EventArgs) Handles Me.Load
        Text = TituloFormularioModificar 'Reescribimos el titulo


        'En las siguientes lineas de codigo lo que se hace es asignarle un valor a cada uno de los componentes que almacene String [Cadaena de Caracteres]
        tbNombre.Text = _TablaAlumnos.Rows(0)("Nombre")
        tbApellido.Text = _TablaAlumnos.Rows(0)("Apellido")
        tbDNI.Text = CStr(_TablaAlumnos.Rows(0)("DNI")) 'Convertimos un numero Integer, (entero) a String, (Cadena de Caracteres)
        tbDireccion.Text = _TablaAlumnos.Rows(0)("Direccion")
        tbTelefono.Text = CStr(_TablaAlumnos.Rows(0)("Telefono")) 'Convertimos un numero Long, (entero largo) a String, (Cadena de Caracteres)
        cbLocalidad.Text = _TablaAlumnos.Rows(0)("Localidad")
        tbFoto.Text = _TablaAlumnos.Rows(0)("Foto")
        tbEmail.Text = _TablaAlumnos.Rows(0)("Email")
    End Sub

    Private Function CompararDatosModificados(ValoresAlmacenadoEnLosComponentes As String()) As Boolean

        'Almacenamos los valores almacenados en la tabla en una coleccion de cadena de caracteres
        Dim Auxiliar() As String = {_TablaAlumnos.Rows(0)("Nombre"), _TablaAlumnos.Rows(0)("Apellido"), CStr(_TablaAlumnos.Rows(0)("DNI")),
            _TablaAlumnos.Rows(0)("Direccion"), _TablaAlumnos.Rows(0)("Telefono"), _TablaAlumnos.Rows(0)("Localidad"), _TablaAlumnos.Rows(0)("Foto"),
            _TablaAlumnos.Rows(0)("Email")}

        'Creamos un contador que nos permitira saber si los datos del alumno fueron modificados
        Dim iTotal As Integer = 0

        'En este bucle simplente asingamos un inicio que seria [0] y una finalizacion que seria [8-1=7]
        For i As Integer = 0 To ValoresAlmacenadoEnLosComponentes.Length - 1

            'La logica de la siguiente codicion es [Si los valores almancenado en auxiliar es igual a ValoresAlmacenadoEnLosComponentes,
            ' es por que no se modifico el valor]
            If Auxiliar(i) = ValoresAlmacenadoEnLosComponentes(i) Then iTotal += 1 'Sumamos [Mientras posicion es [0] => Contador es [0+1=1]
        Next

        'La logica de la siguiente condicion es [Si el contador iTotal es igual al Length, [Total de elementos que hay en el conjunto], 
        ' es porque no se modificaron los datos del Alumno Y Retornamos un valor True]
        If iTotal = ValoresAlmacenadoEnLosComponentes.Length Then Return True
        Return False
    End Function

    '//////////////////////////////////////////////////////////////////////////
    '
    ' Boton Modificar
    '
    '//////////////////////////////////////////////////////////////////////////

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
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

                If CompararDatosModificados(ValoresAlmacenadoEnLosComponentes) Then 'Comprobamos que los datos se hayan modificado
                    MsgBox("No Cambiaste los datos, GENIO!!!", vbOKOnly + vbExclamation + vbDefaultButton1, Titulo)
                Else

                    'Scrip SQL => UPDATE Alumnos FROM Nombre='Pedro', Apellido='Gimenez', DNI=4929, Direccion='queti', Telefono=3764, Email='@.com', Foto='imagen', Localidad='queti' WHERE DNI=3030; 
                    Dim UpdateFrom As String = "UPDATE `mydb3`.`alumnos` SET " &
                        "`Nombre` = '" & tbNombre.Text & "', `Apellido` = '" & tbApellido.Text & "', `DNI` = " & tbDNI.Text &
                        ", `Direccion` = '" & tbDireccion.Text & "', `Telefono` = " & tbTelefono.Text & ", " &
            " `Email` = '" & tbEmail.Text & "', `Foto` = '" & tbFoto.Text & "', `Localidad` = '" & cbLocalidad.Text & "' " &
            "WHERE `DNI` = " & CStr(_TablaAlumnos.Rows(0)("DNI")) & ";"

                    If EjecutarTransaccion(UpdateFrom) Then 'Ejecutamos el ScripSQL y Obtenemos un valor Boolean
                        ' [Si se ejecuto sin nigun problema nos devuelve True sino nos devolvera un valor False]
                        MsgBox("Registro modificado correctamente")
                        _Estado = True 'Asignamos un valor True al atributo _Estado
                        Close() 'Cerramos el Formulario
                    Else
                        MsgBox("Falla en la Modificación")
                    End If
                End If
            End If
        End If
    End Sub

    '+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
    ' Metodos y Propiedades con encapsulamiento Publicos 

    Public WriteOnly Property TablaAlumnos() As DataTable
        Set(value As DataTable)
            _TablaAlumnos = value 'Asignamos un DataTabla [Tabla De Datos] a _TablaAlumnos 
        End Set
    End Property

    Public ReadOnly Property Estado() As Boolean
        Get
            Return _Estado 'Retornamos el valor almacenado en el atributo _Estado
        End Get
    End Property

    '+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
End Class