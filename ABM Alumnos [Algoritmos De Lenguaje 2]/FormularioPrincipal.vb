'
' Created on 2020
'
' Copyright (c) 2023 UsuiSama
'

Module VariableGlobal
    Public Const Titulo As String = "ABM Alumnos [2020]"
    Public Const TituloFormularioModificar As String = "Modificar"
    Public Const TituloFormularioAgregar As String = "Agregar"
End Module

Public Class FormularioPrincipal
    Private Const SelectFrom As String = "SELECT * FROM `mydb3`.`alumnos`;"

    Private Sub FormularioPrincipal_Load(sender As Object, e As EventArgs) Handles Me.Load
        Text = Titulo
        dgvAlumnos.DataSource = EjecutarTransaccionBusqueda(SelectFrom)
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        If ConectarMySQL() Then
            If MsgBox("¿Agregar un NUEVO alumno?", vbYesNo + vbQuestion + vbDefaultButton1, Titulo) = vbYes Then
                Dim FormularioAgregar As New FormularioAgregar()

                FormularioAgregar.ShowDialog(Me)
                If FormularioAgregar.Estado Then
                    dgvAlumnos.DataSource = EjecutarTransaccionBusqueda(SelectFrom)
                Else
                    ConexionMySQL.Close()
                End If
                FormularioAgregar.Dispose()
            Else
                ConexionMySQL.Close()
            End If
        Else
            MsgBox("Error En la Conexion", vbOKOnly + vbCritical + vbDefaultButton1, Titulo)
            ConexionMySQL.Close()
        End If
    End Sub

    Private Function ListaSeleccionada() As DataTable
        Dim ListaAlumnos As New DataTable()
        Dim Fila As Integer = dgvAlumnos.CurrentRow.Index

        For Each Columna As DataGridViewColumn In dgvAlumnos.Columns
            ListaAlumnos.Columns.Add(Columna.Name, dgvAlumnos.Item(Columna.Index, Fila).ValueType)
            If Columna.Index = 0 Then ListaAlumnos.Rows.Add()
            ListaAlumnos.Rows(0)(Columna.Index) = dgvAlumnos.Item(Columna.Index, Fila).Value
        Next
        Return ListaAlumnos
    End Function

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        If ConectarMySQL() Then
            If dgvAlumnos.Rows.Count = 0 Then
                MsgBox("Base De Datos, Vacia!", vbOKOnly + vbExclamation + vbDefaultButton1, Titulo)
                ConexionMySQL.Close()
            Else
                If MsgBox("¿Modificar los datos de este alumno?", vbYesNo + vbQuestion + vbDefaultButton1, Titulo) = vbYes Then
                    Dim FormularioModificar As New FormularioModificar With {
                        .TablaAlumnos = ListaSeleccionada()
                    }

                    FormularioModificar.ShowDialog(Me)
                    If FormularioModificar.Estado Then
                        dgvAlumnos.DataSource = EjecutarTransaccionBusqueda(SelectFrom)
                    Else
                        ConexionMySQL.Close()
                    End If
                    FormularioModificar.Dispose()
                Else
                    ConexionMySQL.Close()
                End If
            End If
        Else
            MsgBox("Error En la Conexion", vbOKOnly + vbCritical + vbDefaultButton1, Titulo)
            ConexionMySQL.Close()
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If ConectarMySQL() Then
            If dgvAlumnos.Rows.Count = 0 Then
                MsgBox("Base De Datos, Vacia!", vbOKOnly + vbExclamation + vbDefaultButton1, Titulo)
                ConexionMySQL.Close()
            Else
                If MsgBox("¿Eliminar este alumno?", vbYesNo + vbQuestion + vbDefaultButton1, Titulo) = vbYes Then
                    Dim DeleteFrom As String = "DELETE FROM `mydb3`.`alumnos` WHERE `DNI` = " & dgvAlumnos.SelectedRows.Item(0).Cells("DNI").Value & ";"

                    If EjecutarTransaccion(DeleteFrom) Then
                        MsgBox("Alumno eliminado correctamente")
                        dgvAlumnos.DataSource = EjecutarTransaccionBusqueda(SelectFrom)
                    Else
                        MsgBox("FALLA EN LA ELIMINACIÓN")
                    End If
                Else
                    ConexionMySQL.Close()
                End If
            End If
        Else
            MsgBox("Error En la Conexion", vbOKOnly + vbCritical + vbDefaultButton1, Titulo)
            ConexionMySQL.Close()
        End If
    End Sub
End Class


