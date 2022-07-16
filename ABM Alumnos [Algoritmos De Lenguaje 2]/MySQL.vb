Imports MySql.Data.MySqlClient

Module MySQL
    Public ConexionMySQL As New MySqlConnection

    Public Function ConectarMySQL() As Boolean
        Dim EstadoDeLaConexion As Boolean = True
        Try
            If ConexionMySQL.State = ConnectionState.Closed Then 'Condicion para saber si la conexion esta cerrada

                'Parametros para realizar la conexion a la base de datos:
                ' Server = Servidor sea local o no
                ' Port = Puerto, por defecto se utiliza 3306 usado para el protocolo MySQL
                ' DataBase = El nombre de nuestra Base De Datos
                ' User = El Nombre de nuestro Usuario
                ' Password = la contraseña
                ConexionMySQL.ConnectionString = "Server=localhost;Port=3306;Database=mydb3;User=test;Password=123"
                ConexionMySQL.Open() 'Abre una conexion a la base de datos
            End If
        Catch ex As Exception
            EstadoDeLaConexion = False
        End Try
        Return EstadoDeLaConexion
    End Function

    ''' <summary>
    ''' Busca solamente una columna con su filas [En este caso queremos que busque solamente la columna DNI con sus filas]
    ''' </summary>
    ''' <param name="SQL"></param>
    ''' <param name="Identificador"></param>
    ''' <returns></returns>
    Public Function EjecutarTransaccionComparacion(SQL As String, Identificador As String) As Boolean
        Dim Comando As MySqlCommand
        Dim LeerDatos As MySqlDataReader
        Dim Estado As Boolean = False
        Try
            If ConectarMySQL() Then
                Comando = ConexionMySQL.CreateCommand()
                Comando.CommandText = SQL
                Comando.CommandType = CommandType.Text
                LeerDatos = Comando.ExecuteReader() 'ExecuteReader() realiza dicha Consulta y le asigna a LeerDatos
                Try
                    While LeerDatos.Read() 'Mientra sea verdadero podemos leer los datos obtenidos en la consulta

                        'La logica de la siguiente condicion es [Si la Columna 0 es decir [DNI] es igual al Identificador [DNI] son iguales].
                        'Asignamos el valor True a la variable boolean Estado
                        If LeerDatos.GetString(0) = Identificador Then Estado = True
                    End While
                    LeerDatos.Close() 'Siempre cerrar Despues de leer los datos consultado
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        ConexionMySQL.Close()
        Return Estado
    End Function

    ''' <summary>
    ''' Solo se utiliza cuando se realiza una busqueda que tengan varias fila y columnas
    ''' </summary>
    ''' <param name="SQL">Script SQL</param>
    ''' <returns>Tabla De Datos [DataTable]</returns>
    Public Function EjecutarTransaccionBusqueda(SQL As String) As DataTable
        Dim Comando As MySqlCommand
        Dim TablaDeDatos As New DataTable()
        Dim AdaptadorDeDatos As New MySqlDataAdapter()
        Try
            If ConectarMySQL() Then 'Nos Conectamos a la base de datoss
                Comando = ConexionMySQL.CreateCommand() 'Le Asignamos los valores de CreateCommand() a Comando
                Comando.CommandText = SQL 'Le asignamos un ScriptSQL
                Comando.CommandType = CommandType.Text 'Le asignamos como tiene que interpretar los comando asignados
                AdaptadorDeDatos.SelectCommand = Comando 'asignamos nuestro comando a la propiedad SelectCommand
                Try
                    AdaptadorDeDatos.Fill(TablaDeDatos) 'Adapta los datos consultado en una DataTable [Tabla De Datos]
                Catch ex As Exception 'Recolector de Errores/Excepciones
                    MsgBox(ex.Message) 'Nos mostrara un mensaje con el motivo del error
                End Try
            End If
        Catch ex As Exception 'Recolector de Errores/Excepciones
            MsgBox(ex.Message) 'Nos mostrara un mensaje con el motivo del error
        End Try
        ConexionMySQL.Close() 'Es importante Cerrar La Conexion a la Base de Datos. ¿Porque es necesario?:
        '   1. Segun los Ingenieros de MySQL el motivo principal es el limite de conexiones que tiene en si el Servidor, sea local o no,
        '      si pasamos ese umbral, simplemente nos saltara un error en la ejecucion de la consulta con el siguiente mensaje =>
        '      ["demasiadas conexiones abiertas"]
        '   2. Es buena Practica siempre cerrar la conexion
        Return TablaDeDatos
    End Function

    ''' <summary>
    ''' Solo se utiliza cuando se Inserta, Actualiza y/o Eliminan Los Datos. [Insert And/Or Update And/Or Delete]
    ''' </summary>
    ''' <param name="SQL">Script SQL</param>
    ''' <returns>Verdadero o Falso [False/True]</returns>
    Public Function EjecutarTransaccion(SQL As String) As Boolean
        Dim Comando As MySqlCommand
        Dim EstadoDeLaOperacion As Boolean = True
        Try
            If ConectarMySQL() Then
                Comando = ConexionMySQL.CreateCommand()
                Comando.CommandText = SQL
                Comando.CommandType = CommandType.Text
                Comando.Connection = ConexionMySQL

                'La Instrucciones que funcionan con este metodo son los siguientes:
                '   1. Insert
                '   2. Update
                '   3. Delete
                Comando.ExecuteNonQuery() 'Este Metodo Permite Modificar/Alterar los valores almacenados en la Base De Datos
            Else
                EstadoDeLaOperacion = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            EstadoDeLaOperacion = False
        End Try
        ConexionMySQL.Close()
        Return EstadoDeLaOperacion
    End Function
End Module
