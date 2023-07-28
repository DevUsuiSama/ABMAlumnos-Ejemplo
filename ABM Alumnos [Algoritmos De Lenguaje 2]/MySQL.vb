'
' Created on 2020
'
' Copyright (c) 2023 UsuiSama
'
Imports MySql.Data.MySqlClient

Module MySQL
    Public ConexionMySQL As New MySqlConnection

    Public Function ConectarMySQL() As Boolean
        Dim EstadoDeLaConexion As Boolean = True
        Try
            If ConexionMySQL.State = ConnectionState.Closed Then
                ConexionMySQL.ConnectionString = "Server=localhost;Port=3306;Database=mydb3;User=%%;Password=%%"
                ConexionMySQL.Open()
            End If
        Catch ex As Exception
            EstadoDeLaConexion = False
        End Try
        Return EstadoDeLaConexion
    End Function

    Public Function EjecutarTransaccionComparacion(SQL As String, Identificador As String) As Boolean
        Dim Comando As MySqlCommand
        Dim LeerDatos As MySqlDataReader
        Dim Estado As Boolean = False
        Try
            If ConectarMySQL() Then
                Comando = ConexionMySQL.CreateCommand()
                Comando.CommandText = SQL
                Comando.CommandType = CommandType.Text
                LeerDatos = Comando.ExecuteReader()
                Try
                    While LeerDatos.Read()
                        If LeerDatos.GetString(0) = Identificador Then Estado = True
                    End While
                    LeerDatos.Close()
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

    Public Function EjecutarTransaccionBusqueda(SQL As String) As DataTable
        Dim Comando As MySqlCommand
        Dim TablaDeDatos As New DataTable()
        Dim AdaptadorDeDatos As New MySqlDataAdapter()
        Try
            If ConectarMySQL() Then
                Comando = ConexionMySQL.CreateCommand()
                Comando.CommandText = SQL
                Comando.CommandType = CommandType.Text
                AdaptadorDeDatos.SelectCommand = Comando
                Try
                    AdaptadorDeDatos.Fill(TablaDeDatos)
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        ConexionMySQL.Close()
        Return TablaDeDatos
    End Function

    Public Function EjecutarTransaccion(SQL As String) As Boolean
        Dim Comando As MySqlCommand
        Dim EstadoDeLaOperacion As Boolean = True
        Try
            If ConectarMySQL() Then
                Comando = ConexionMySQL.CreateCommand()
                Comando.CommandText = SQL
                Comando.CommandType = CommandType.Text
                Comando.Connection = ConexionMySQL
                Comando.ExecuteNonQuery()
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
