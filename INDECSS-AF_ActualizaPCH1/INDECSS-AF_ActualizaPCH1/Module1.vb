Module Module1

    Sub Main()

        Dim oCompany As New SAPbobsCOM.Company


        Dim baseDeDatosEMPRESA As String = "SAPB1_TEST"
        'PFZ setting de conexion en duro
        'oCompany.CompanyDB = "CNP_CIERRE_B"
        'oCompany.DbServerType = SAPbobsCOM.BoDataServerTypes.dst_MSSQL2016
        'oCompany.Server = "VMCNP050"
        'oCompany.DbUserName = "sa"
        'oCompany.DbPassword = "AriJavi2019*"
        'oCompany.SLDServer = "VMCNP119"
        'oCompany.UserName = "manager"
        'oCompany.Password = "accendo"
        'oCompany.UseTrusted = False
        'oCompany.language = SAPbobsCOM.BoSuppLangs.ln_English

        'PFZ setting de conexion
        oCompany.CompanyDB = System.Configuration.ConfigurationManager.AppSettings("CompanyDB")
        oCompany.DbServerType = SAPbobsCOM.BoDataServerTypes.dst_HANADB
        oCompany.Server = System.Configuration.ConfigurationManager.AppSettings("Server")
        oCompany.DbUserName = System.Configuration.ConfigurationManager.AppSettings("DbUserName")
        oCompany.DbPassword = System.Configuration.ConfigurationManager.AppSettings("DbPassword")
        oCompany.SLDServer = System.Configuration.ConfigurationManager.AppSettings("SLDServer")
        oCompany.UserName = System.Configuration.ConfigurationManager.AppSettings("UserName")
        oCompany.Password = System.Configuration.ConfigurationManager.AppSettings("Password")
        oCompany.UseTrusted = System.Configuration.ConfigurationManager.AppSettings("UseTrusted")
        oCompany.language = SAPbobsCOM.BoSuppLangs.ln_English


        If oCompany.Connect() <> 0 Then
            Dim errNumero As Integer = 0
            Dim errMensaje As String = ""
            oCompany.GetLastError(errNumero, errMensaje)
            oCompany.Disconnect()
            System.Runtime.InteropServices.Marshal.ReleaseComObject(oCompany)
            oCompany = Nothing
            'Grabo Login de errores
            ExecutionLog("ERROR ConexionDB ", errNumero & errMensaje)
            'Muestro mensaje
            'MsgBox("Ha ocurrido el siguiente error al intentar conectar a la Base de Datos " + baseDeDatosEMPRESA + " en SAP\n\n" + errMensaje, MsgBoxStyle.OkOnly)
        Else
            'inicia transaction para asegurarse de que si NO se realicen con éxito todas las operaciones, deshaga cualquier cambio realizado hasta antes del error en caso de ocurrir
            ExecutionLog("ConexionDB", "Starting Cache...")

            '---- BLOQUE DE LLAMADAS A PROCESOS  -------
            'Pagos Parcial/Total
            Actualizacion_PCH1(oCompany, oCompany.CompanyDB)


            '---- FIN - BLOQUE DE PROCESOS  -------
            'Finaliza seguimiento
            ExecutionLog("ConexionDB", "Finishing Cache...")

        End If

        'MsgBox("Las operaciones fueron realizadas con éxito, revise por favor ...", MsgBoxStyle.OkOnly)
        ExecutionLog("Interfce finalizando OK", "Finishing Cache...Commit - OK")

        If oCompany.Connect Then

            'MsgBox("Entre a compny conectada FINAL...")

            oCompany.Disconnect()
            System.Runtime.InteropServices.Marshal.ReleaseComObject(oCompany)
            oCompany = Nothing
        End If


    End Sub

End Module
