Imports Newtonsoft.Json
Imports System.Text


Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ConexionHANA As Boolean = False

        Dim oCompany As SAPbobsCOM.Company

        'Conexion DB-HANA
        'oCompany.CompanyDB = System.Configuration.ConfigurationManager.AppSettings("CompanyDB")
        'oCompany.DbServerType = SAPbobsCOM.BoDataServerTypes.dst_HANADB
        'oCompany.Server = System.Configuration.ConfigurationManager.AppSettings("Server")
        'oCompany.DbUserName = System.Configuration.ConfigurationManager.AppSettings("DbUserName")
        'oCompany.DbPassword = System.Configuration.ConfigurationManager.AppSettings("DbPassword")
        'oCompany.SLDServer = System.Configuration.ConfigurationManager.AppSettings("SLDServer")
        'oCompany.UserName = System.Configuration.ConfigurationManager.AppSettings("UserName")
        'oCompany.Password = System.Configuration.ConfigurationManager.AppSettings("Password")
        'oCompany.UseTrusted = System.Configuration.ConfigurationManager.AppSettings("UseTrusted")
        'oCompany.language = SAPbobsCOM.BoSuppLangs.ln_English


        'If oCompany.Connect() <> 0 Then
        ' Dim errNumero As Integer = 0
        ' Dim errMensaje As String = ""
        ' oCompany.GetLastError(errNumero, errMensaje)
        ' oCompany.Disconnect()
        ' System.Runtime.InteropServices.Marshal.ReleaseComObject(oCompany)
        ' oCompany = Nothing
        'Grabo Login de errores
        'ExecutionLog("ERROR ConexionDB ", errNumero & errMensaje)
        'Muestro mensaje
        'MsgBox("Ha ocurrido el siguiente error al intentar conectar a la Base de Datos " + oCompany.CompanyDB + " en SAP\n\n" + errMensaje, MsgBoxStyle.OkOnly)

        'Else


        'End If



        'ConexionHANA = ConectatSAPHANNA()

        'MsgBox("La conexion fue: " & ConexionHANA)

        If ConexionHANA Then

            MsgBox("La conexion fue: " & ConexionHANA)

            ConsultaArticulos()


        End If

        Dim miobjJSON As New ObjectoJSON

        miobjJSON.fecha = "2021-02-12"
        miobjJSON.cuit = 30677517707
        miobjJSON.ptoVta = 11
        miobjJSON.tipoCmp = 1
        miobjJSON.nroCmp = 8332
        miobjJSON.importe = 1790.03
        miobjJSON.moneda = "DOL"
        miobjJSON.ctz = 88.45
        miobjJSON.tipoDocRec = 80
        miobjJSON.nroDocRec = 30677517707
        miobjJSON.tipoCodAut = "E"
        miobjJSON.codAut = "71078632014795"

        Dim miJSON As Array
        Dim miFileJSON As String
        Dim miBase64 As String

        '---- Conversion JSON
        miFileJSON = JsonConvert.SerializeObject(miobjJSON)

        MsgBox("JSON: " & miFileJSON)



        '--- conversion Base64

        'miJSON = {miobjJSON.fecha, miobjJSON.cuit, miobjJSON.ptoVta, miobjJSON.tipoCmp, miobjJSON.nroCmp, miobjJSON.importe, miobjJSON.moneda, miobjJSON.ctz, miobjJSON.tipoDocRec, miobjJSON.nroDocRec, miobjJSON.tipoCodAut, miobjJSON.codAut}
        Dim unicode As New UnicodeEncoding()
        Dim encodedBytes = unicode.GetBytes(miFileJSON)

        miBase64 = Convert.ToBase64String(encodedBytes)

        MsgBox("Base64: " & miBase64)

    End Sub
End Class
