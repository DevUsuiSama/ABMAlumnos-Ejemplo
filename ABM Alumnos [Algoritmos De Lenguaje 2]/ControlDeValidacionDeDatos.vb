Module ControlDeValidacionDeDatos
    '+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
    'I+D [Nuevos Algoritmos 2020] by Usui Sama

    Private Function CrearTablaComponentes(Componentes As DataTable, NombreDeLosComponentes As String(), ValoresAlmacenadoEnLosComponentes As String(),
                                           TotalDeElemento As Integer) As DataTable

        'En este bucle simplente asignamos un inicio que seria [0] y una finalizacion que seria [8-1=7]
        For i As Integer = 0 To TotalDeElemento - 1
            'Con el Metodo Add creamos una nueva columna:
            '   los parametro que solicita este metodo son: Nombre De La Columna, Tipo De Datos [Ejemplo: ("DNI", GetType(String))]
            Componentes.Columns.Add(NombreDeLosComponentes(i), GetType(String))

            'La Logica de esta condicion es la siguiente: 
            '   Cuando la posicion de la columna sea 0 es decir recien empezado el bucle creara una Fila
            If i = 0 Then Componentes.Rows.Add() 'Agrega/Añade una nueva Fila

            'Asignamos los valores del vector ValoresAlmacenadoEnLosComponentes(i) en la tabla Componentes.Rows(0)(NombreDeLosComponentes(i))
            'Componentes.Rows(0)(NombreDeLosComponentes(i)) en el Lenguaje C seria ListaAlumnos.Rows[0][NombreDeLosComponentes[i]] => [Fila][Columna[Posicion]]
            Componentes.Rows(0)(NombreDeLosComponentes(i)) = ValoresAlmacenadoEnLosComponentes(i)
        Next
        Return Componentes
    End Function

    Public Function VerificarSiLasCajasDeTextoEstanVacias(NombreDeLosComponentes As String(), ValoresAlmacenadoEnLosComponentes As String()) As Boolean
        Dim Componentes As New DataTable() 'Creamos un objeto de tipo DataTable
        Dim ComponentesVacio As Boolean = False 'Si Hay Una Caja de Texto Vacia Se Alterara el valor asignado

        '+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+

        'Se llama a un metodo que nos creara una Tabla De Datos
        Componentes = CrearTablaComponentes(Componentes, NombreDeLosComponentes, ValoresAlmacenadoEnLosComponentes, NombreDeLosComponentes.Length)

        '+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+

        'Este bucle inicia como los demas bucle es decir inicia con la posicion [0]
        For Each Columna As DataColumn In Componentes.Columns 'Este Bucle hara un recorrido completo de la columna del DataTable

            'La Logica es la siguiente [Si el dato almacenado el Tabla de Datos es = [ "" o Nothing ] es por que esta vacio]
            If String.IsNullOrEmpty(Componentes.Rows(0)(Columna.ColumnName)) Then

                'Nos mostrara un mensaje con el nombre del componente que este Vacio/
                MsgBox("Ingrese un valor en " & Columna.ColumnName, vbOKOnly + vbExclamation + vbDefaultButton1, Titulo)

                '/////////////////////////////////////////////////////////
                'La logica es la siguiente [ Si El ComponentesVacio es igual a falso le asignamos el valor true ]

                If ComponentesVacio = False Then ComponentesVacio = True 'Le Asignamos el valor [True]

                '/////////////////////////////////////////////////////////
            End If
        Next
        Return ComponentesVacio
    End Function

    Public Function VerificarQueNiUnaCajaEsteVacia(NombreDeLosComponentes As String(), ValoresAlmacenadoEnLosComponentes As String()) As Boolean
        Dim CajaDeTextoVacio As Boolean = False
        Dim Componentes As New DataTable()
        Dim Contador As Integer = 0

        '+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+

        'Se llama a un metodo que nos creara una Tabla De Datos

        Componentes = CrearTablaComponentes(Componentes, NombreDeLosComponentes, ValoresAlmacenadoEnLosComponentes, NombreDeLosComponentes.Length)

        '+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+

        'Este bucle inicia como los demas bucle es decir inicia con la posicion [0]
        For Each Columna As DataColumn In Componentes.Columns 'Este Bucle hara un recorrido completo de la columna del DataTable

            'La Logica es la siguiente [Si el dato almacenado el Tabla de Datos es = [ "" o Nothing ] es por que esta vacio]
            If String.IsNullOrEmpty(Componentes.Rows(0)(Columna.ColumnName)) Then Contador += 1 'Sumamos [Mientras posicion de la columna es [0] => Contador es [0+1=1] 
        Next

        'La logica de la siguiente condicion es [Si el Contador es igual al Length, [Total de elementos que hay en el conjunto], 
        ' es porque no se modificaron los datos del Alumno Y Retornamos un valor True]
        If Contador = NombreDeLosComponentes.Length Then CajaDeTextoVacio = True
        Return CajaDeTextoVacio
    End Function

    '+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
End Module
