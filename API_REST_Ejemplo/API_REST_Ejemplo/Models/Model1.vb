Imports System
Imports System.Data.Entity
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Linq

Partial Public Class Model1
    Inherits DbContext

    Public Sub New()
        MyBase.New("name=Model1")
    End Sub

    Public Overridable Property Clientes As DbSet(Of Clientes)

    Protected Overrides Sub OnModelCreating(ByVal modelBuilder As DbModelBuilder)
        modelBuilder.Entity(Of Clientes)() _
            .Property(Function(e) e.RazonSocial) _
            .IsUnicode(False)

        modelBuilder.Entity(Of Clientes)() _
            .Property(Function(e) e.Contacto) _
            .IsUnicode(False)

        modelBuilder.Entity(Of Clientes)() _
            .Property(Function(e) e.Domicilio) _
            .IsUnicode(False)

        modelBuilder.Entity(Of Clientes)() _
            .Property(Function(e) e.Ciudad) _
            .IsUnicode(False)

        modelBuilder.Entity(Of Clientes)() _
            .Property(Function(e) e.Provincia) _
            .IsUnicode(False)

        modelBuilder.Entity(Of Clientes)() _
            .Property(Function(e) e.Pais) _
            .IsUnicode(False)

        modelBuilder.Entity(Of Clientes)() _
            .Property(Function(e) e.Telefono) _
            .IsUnicode(False)
    End Sub
End Class
