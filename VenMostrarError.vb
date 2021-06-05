Public Class VenMostrarError


    Private strError As String

    Sub New(_error As String)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        strError = _error

    End Sub
    Private Sub VenSetearHijosError_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        TextBox1.Text = strError
    End Sub
End Class