Module VariableGlobal
    '+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
    'Cadenas de caracteres Constantes con encapsulamiento Publico

    'Este Titulo se mostrara en cada mensaje de texto y en el Formulario Principal
    Public Const Titulo As String = "ABM Alumnos Drex" 'La palabra reservada [Const] nos permitir definir que el siguiente atributo,
    'no se puede alterar el valor asignado.

    'Este Titulo se mostrara en el Formulario Modificar
    Public Const TituloFormularioModificar As String = "Modificar" 'La palabra reservada [Const] nos permitir definir que el siguiente atributo,
    'no se puede alterar el valor asignado.

    'Y este ultimo Titulo se mostrara en el Formulario agregar
    Public Const TituloFormularioAgregar As String = "Agregar" 'La palabra reservada [Const] nos permitir definir que el siguiente atributo,
    'no se puede alterar el valor asignado.

    '+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
End Module

Public Class FormularioPrincipal
    ''' <summary>
    ''' Atributo tipo String Constante de Nombre SelectFrom que se le asigna un cadena caracteres.
    ''' Script SQL:
    '''     Obtiene la tabla completa de la base de datos.
    ''' </summary>
    ''' <remarks>
    ''' <example> ScripSQL Acortado:
    ''' <code>SELECT * FROM Alumnos</code>
    ''' </example>
    ''' </remarks>
    Private Const SelectFrom As String = "SELECT * FROM `mydb3`.`alumnos`;"

    ''' <summary>
    ''' El Procedimiento Form1_Load es llamado antes de que el formulario se muestre por primera vez.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub FormularioPrincipal_Load(sender As Object, e As EventArgs) Handles Me.Load
        'En esta linea de codigo obtenemos la Tabla de Datos Consultada a la Base de Datos
        Text = Titulo
        dgvAlumnos.DataSource = EjecutarTransaccionBusqueda(SelectFrom)
    End Sub

    '//////////////////////////////////////////////////////////////////////////
    '
    ' Boton Agregar
    '
    '//////////////////////////////////////////////////////////////////////////

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        If ConectarMySQL() Then 'Comprobamos que la conexion se haya establecido Correctamente

            'Preguntamos al usuario si quiere Agregar un nuevo Alumno
            If MsgBox("¿Agregar un NUEVO alumno?", vbYesNo + vbQuestion + vbDefaultButton1, Titulo) = vbYes Then

                'Creamos un objeto de tipo FormularioAgregar()
                Dim FormularioAgregar As New FormularioAgregar()

                FormularioAgregar.ShowDialog(Me) 'Permite que se visualize nuestro Formularios

                If FormularioAgregar.Estado Then 'Preguntamos si Se Agrego un Nuevo Alumno o Se Cancelo Dicha Operacion
                    dgvAlumnos.DataSource = EjecutarTransaccionBusqueda(SelectFrom) 'Actualizar DataGridView
                Else
                    ConexionMySQL.Close()
                End If

                FormularioAgregar.Dispose() 'Liberamos los Recursos utilizados en FormularioAgregar
            Else
                ConexionMySQL.Close()
            End If
        Else
            MsgBox("Error En la Conexion", vbOKOnly + vbCritical + vbDefaultButton1, Titulo)
            ConexionMySQL.Close()
        End If
    End Sub

    '//////////////////////////////////////////////////////////////////////////
    '
    ' Lista Seleccionada
    '
    '//////////////////////////////////////////////////////////////////////////

    Private Function ListaSeleccionada() As DataTable
        Dim ListaAlumnos As New DataTable() 'Se crea un objeto de tipo DataTable
        Dim Fila As Integer = dgvAlumnos.CurrentRow.Index 'Obtiene la fila seleccionado por el usuario

        'La siguiente linea crea una tabla desde 0

        'Este bucle inicia como los demas bucle es decir inicia con la posicion [0]
        For Each Columna As DataGridViewColumn In dgvAlumnos.Columns 'Este Bucle hara un recorrido completo de la columna del DataGridView

            'Con el Metodo Add creamos una nueva columna:
            '   los parametro que solicita este metodo son: Nombre De La Columna, Tipo De Datos [Ejemplo: ("DNI", GetType(String))]
            ListaAlumnos.Columns.Add(Columna.Name, dgvAlumnos.Item(Columna.Index, Fila).ValueType)

            'La Logica de esta condicion es la siguiente: 
            '   Cuando la posicion de la columna sea 0 es decir recien empezado el bucle creara una Fila
            If Columna.Index = 0 Then ListaAlumnos.Rows.Add() 'Agregar Nueva Fila

            'Asignamos los valores del DataGridView a nuestra Tabla
            'La Propiedad Item Solicita dos Parametros:
            '   1. Posicion de la Columna o Nombre de la Columna
            '   2. Posicion de la fila
            '
            'ListaAlumnos.Rows(0)(Columna.Index) en el Lenguaje C seria ListaAlumnos.Rows[0][Columna.Index] => [Fila][Columna]
            ListaAlumnos.Rows(0)(Columna.Index) = dgvAlumnos.Item(Columna.Index, Fila).Value
        Next
        Return ListaAlumnos
    End Function

    '//////////////////////////////////////////////////////////////////////////
    '
    ' Boton Modificar
    '
    '//////////////////////////////////////////////////////////////////////////

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        If ConectarMySQL() Then 'Comprobamos que la conexion se haya establecido Correctamente

            If dgvAlumnos.Rows.Count = 0 Then 'La logica es la siguiente [Si el contador de filas es 0 es porque esta vacio la tabla]
                MsgBox("Base De Datos, Vacia!", vbOKOnly + vbExclamation + vbDefaultButton1, Titulo)
                ConexionMySQL.Close()
            Else
                'Preguntamos al usuario si quiere Modificar el Alumno Seleccionado
                If MsgBox("¿Modificar los datos de este alumno?", vbYesNo + vbQuestion + vbDefaultButton1, Titulo) = vbYes Then

                    'Creamos un objeto de tipo FormularioModificar
                    Dim FormularioModificar As New FormularioModificar

                    'Llamamos a la propieda TablaAlumnos y le asignamos el metodo ListaSeleccionada
                    FormularioModificar.TablaAlumnos = ListaSeleccionada()

                    FormularioModificar.ShowDialog(Me) 'Permite que se visualize nuestro Formularios

                    If FormularioModificar.Estado Then 'Preguntamos si Se Modifico un Nuevo Alumno o Se Cancelo Dicha Operacion
                        dgvAlumnos.DataSource = EjecutarTransaccionBusqueda(SelectFrom) 'Actualizar DataGridView
                    Else
                        ConexionMySQL.Close()
                    End If

                    FormularioModificar.Dispose() 'Liberamos los Recursos utilizados en FormularioModificars
                Else
                    ConexionMySQL.Close()
                End If
            End If
        Else
            MsgBox("Error En la Conexion", vbOKOnly + vbCritical + vbDefaultButton1, Titulo)
            ConexionMySQL.Close()
        End If
    End Sub

    '//////////////////////////////////////////////////////////////////////////
    '
    ' Boton Eliminar
    '
    '//////////////////////////////////////////////////////////////////////////

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If ConectarMySQL() Then 'Comprobamos que la conexion se haya establecido Correctamente
            If dgvAlumnos.Rows.Count = 0 Then 'La logica es la siguiente [Si el contador de filas es 0 es porque esta vacio la tabla]
                MsgBox("Base De Datos, Vacia!", vbOKOnly + vbExclamation + vbDefaultButton1, Titulo)
                ConexionMySQL.Close()
            Else
                'Preguntamos al usuario si quiere Eliminar el Alumno Seleccionado
                If MsgBox("¿Eliminar este alumno?", vbYesNo + vbQuestion + vbDefaultButton1, Titulo) = vbYes Then

                    'Script SQL Delete => DELETE FROM Alumnos WHERE DNI=3030;
                    Dim DeleteFrom As String = "DELETE FROM `mydb3`.`alumnos` WHERE `DNI` = " & dgvAlumnos.SelectedRows.Item(0).Cells("DNI").Value & ";"

                    If EjecutarTransaccion(DeleteFrom) Then 'Ejecutamos el ScripSQL y Obtenemos un valor Boolean
                        ' [Si se ejecuto sin nigun problema nos devuelve True sino nos devolvera un valor False]

                        MsgBox("Alumno eliminado correctamente")

                        dgvAlumnos.DataSource = EjecutarTransaccionBusqueda(SelectFrom) 'Actualizamos el DataGridView
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


