Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class Clientes
    Public Property ID As Integer

    Public Property Codigo As Integer?

    <StringLength(100)>
    Public Property RazonSocial As String

    <StringLength(100)>
    Public Property Contacto As String

    <StringLength(100)>
    Public Property Domicilio As String

    <StringLength(100)>
    Public Property Ciudad As String

    <StringLength(50)>
    Public Property Provincia As String

    <StringLength(50)>
    Public Property Pais As String

    <StringLength(50)>
    Public Property Telefono As String

    Public Property Saldo As Decimal?

    Public Property Status As Boolean?
End Class
