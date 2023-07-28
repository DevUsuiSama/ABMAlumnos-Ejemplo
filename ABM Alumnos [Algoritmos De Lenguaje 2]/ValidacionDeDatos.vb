'
' Created on 2020
'
' Copyright (c) 2023 UsuiSama
'

Module ValidacionDeDatos
    Private Function CrearTablaComponentes(Componentes As DataTable, NombreDeLosComponentes As String(), ValoresAlmacenadoEnLosComponentes As String(),
                                           TotalDeElemento As Integer) As DataTable
        For i As Integer = 0 To TotalDeElemento - 1
            Componentes.Columns.Add(NombreDeLosComponentes(i), GetType(String))
            If i = 0 Then Componentes.Rows.Add()
            Componentes.Rows(0)(NombreDeLosComponentes(i)) = ValoresAlmacenadoEnLosComponentes(i)
        Next
        Return Componentes
    End Function

    Public Function VerificarSiLasCajasDeTextoEstanVacias(NombreDeLosComponentes As String(), ValoresAlmacenadoEnLosComponentes As String()) As Boolean
        Dim Componentes As New DataTable()
        Dim ComponentesVacio As Boolean = False

        Componentes = CrearTablaComponentes(Componentes, NombreDeLosComponentes, ValoresAlmacenadoEnLosComponentes, NombreDeLosComponentes.Length)
        For Each Columna As DataColumn In Componentes.Columns
            If String.IsNullOrEmpty(Componentes.Rows(0)(Columna.ColumnName)) Then
                MsgBox("Ingrese un valor en " & Columna.ColumnName, vbOKOnly + vbExclamation + vbDefaultButton1, Titulo)
                If ComponentesVacio = False Then ComponentesVacio = True
            End If
        Next
        Return ComponentesVacio
    End Function

    Public Function VerificarQueNiUnaCajaEsteVacia(NombreDeLosComponentes As String(), ValoresAlmacenadoEnLosComponentes As String()) As Boolean
        Dim CajaDeTextoVacio As Boolean = False
        Dim Componentes As New DataTable()
        Dim Contador As Integer = 0

        Componentes = CrearTablaComponentes(Componentes, NombreDeLosComponentes, ValoresAlmacenadoEnLosComponentes, NombreDeLosComponentes.Length)
        For Each Columna As DataColumn In Componentes.Columns
            If String.IsNullOrEmpty(Componentes.Rows(0)(Columna.ColumnName)) Then Contador += 1
        Next
        If Contador = NombreDeLosComponentes.Length Then CajaDeTextoVacio = True
        Return CajaDeTextoVacio
    End Function
End Module
