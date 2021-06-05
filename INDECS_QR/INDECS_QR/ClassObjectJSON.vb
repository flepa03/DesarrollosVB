Public Class ObjectoJSON

    Property ver As Integer
    Property fecha As String
    Property cuit As Double
    Property ptoVta As Integer
    Property tipoCmp As Integer
    Property nroCmp As Integer
    Property importe As Decimal
    Property moneda As String
    Property ctz As Decimal
    Property tipoDocRec As Integer
    Property nroDocRec As Double
    Property tipoCodAut As String
    Property codAut As String



    Sub New()

        ver = 1
        fecha = ""
        cuit = 0
        ptoVta = 0
        tipoCmp = 0
        nroCmp = 0
        importe = 0
        moneda = "PES"
        ctz = 1
        tipoDocRec = 0
        nroDocRec = 0
        tipoCodAut = "E"
        codAut = ""

    End Sub


End Class
