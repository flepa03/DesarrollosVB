Imports System.Data
Imports System.Data.Entity
Imports System.Data.Entity.Infrastructure
Imports System.Linq
Imports System.Net
Imports System.Net.Http
Imports System.Web.Http
Imports System.Web.Http.Description
Imports API_REST_Ejemplo

Namespace Controllers
    Public Class ClientesController
        Inherits System.Web.Http.ApiController

        Private db As New Model1

        ' GET: api/Clientes
        Function GetClientes() As IQueryable(Of Clientes)
            Return db.Clientes
        End Function

        ' GET: api/Clientes/5
        <ResponseType(GetType(Clientes))>
        Function GetClientes(ByVal id As Integer) As IHttpActionResult
            Dim clientes As Clientes = db.Clientes.Find(id)
            If IsNothing(clientes) Then
                Return NotFound()
            End If

            Return Ok(clientes)
        End Function

        ' PUT: api/Clientes/5
        <ResponseType(GetType(Void))>
        Function PutClientes(ByVal id As Integer, ByVal clientes As Clientes) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            If Not id = clientes.ID Then
                Return BadRequest()
            End If

            db.Entry(clientes).State = EntityState.Modified

            Try
                db.SaveChanges()
            Catch ex As DbUpdateConcurrencyException
                If Not (ClientesExists(id)) Then
                    Return NotFound()
                Else
                    Throw
                End If
            End Try

            Return StatusCode(HttpStatusCode.NoContent)
        End Function

        ' POST: api/Clientes
        <ResponseType(GetType(Clientes))>
        Function PostClientes(ByVal clientes As Clientes) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            db.Clientes.Add(clientes)
            db.SaveChanges()

            Return CreatedAtRoute("DefaultApi", New With {.id = clientes.ID}, clientes)
        End Function

        ' DELETE: api/Clientes/5
        <ResponseType(GetType(Clientes))>
        Function DeleteClientes(ByVal id As Integer) As IHttpActionResult
            Dim clientes As Clientes = db.Clientes.Find(id)
            If IsNothing(clientes) Then
                Return NotFound()
            End If

            db.Clientes.Remove(clientes)
            db.SaveChanges()

            Return Ok(clientes)
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Private Function ClientesExists(ByVal id As Integer) As Boolean
            Return db.Clientes.Count(Function(e) e.ID = id) > 0
        End Function
    End Class
End Namespace