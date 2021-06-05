Module Module2
    Public Sub Actualizacion_PCH1(oCompany As SAPbobsCOM.Company, db As String)

        '======  Actualizacion de la PCH1 con los datos de la Recepcion - @INDECS_AF ================

        Dim rsOPCH, rsPCH1, rsINDECSAF, rsActInd, rsPDN1, rsOPDN As SAPbobsCOM.Recordset

        rsOPCH = oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset)
        rsPCH1 = oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset)
        rsINDECSAF = oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset)
        rsActInd = oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset)
        rsPDN1 = oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset)
        rsOPDN = oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset)


        'Compongo el sql
        Dim sqlOPCH, sqlPCH1, sqlINDECS, sqlActInd, sqlPDN1, sqlOPDN As String

        sqlINDECS = "SELECT * FROM " & Chr(34) & db & Chr(34) & "." & Chr(34) & "@INDECS_AF" & Chr(34) & " WHERE " & Chr(34) & "ODRFENTRY" & Chr(34) & " > 0 AND " &
            Chr(34) & "STATUS" & Chr(34) & "='1'"

        'MsgBox(sqlINDECS)

        rsINDECSAF.DoQuery(sqlINDECS)

        rsINDECSAF.MoveFirst()

        Do While Not rsINDECSAF.EoF

            sqlOPCH = "SELECT * FROM " & Chr(34) & db & Chr(34) & "." & Chr(34) & "OPCH" & Chr(34) & " WHERE " & Chr(34) & "draftKey" & Chr(34) & "=" & rsINDECSAF.Fields.Item("ODRFENTRY").Value &
                " AND " & Chr(34) & "DocStatus" & Chr(34) & " ='O'"

            'MsgBox(sqlOPCH)

            rsOPCH.DoQuery(sqlOPCH)

            If rsOPCH.RecordCount > 0 Then
                'Si encontro al menos 1, actualizo PCH1
                sqlPCH1 = "UPDATE " & Chr(34) & db & Chr(34) & "." & Chr(34) & "PCH1" & Chr(34) & " SET " & Chr(34) & "BaseRef" & Chr(34) & "='" & rsINDECSAF.Fields.Item("BaseRef").Value &
"', " & Chr(34) & "BaseType" & Chr(34) & "=20, " & Chr(34) & "BaseEntry" & Chr(34) & "=" & rsINDECSAF.Fields.Item("BaseEntry").Value & ", " & Chr(34) & "BaseLine" & Chr(34) &
"=0 WHERE " & Chr(34) & "DocEntry" & Chr(34) & "=" & rsOPCH.Fields.Item("DocEntry").Value & " AND " & Chr(34) & "BaseRef" & Chr(34) & " IS NULL"

                'MsgBox(sqlPCH1)

                rsPCH1.DoQuery(sqlPCH1)

                'CR - 05/11/2020: se debe actualizar tambien la PDN1
                sqlPDN1 = "UPDATE " & Chr(34) & db & Chr(34) & "." & Chr(34) & "PDN1" & Chr(34) & " SET " & Chr(34) & "TargetType" & Chr(34) & "=18, " &
Chr(34) & "TrgetEntry" & Chr(34) & "=" & rsOPCH.Fields.Item("DocEntry").Value & "," & Chr(34) & "LineStatus" & Chr(34) & "='C' WHERE " & Chr(34) & "DocEntry" & Chr(34) & "=" & rsINDECSAF.Fields.Item("DOCENTRYPDN1").Value

                rsPCH1.DoQuery(sqlPCH1)



                'Actualizo la INDECS_AF
                sqlActInd = "UPDATE " & Chr(34) & db & Chr(34) & "." & Chr(34) & "@INDECS_AF" & Chr(34) & " Set " & Chr(34) & "PCH1TARGET" & Chr(34) & "=" & rsOPCH.Fields.Item("DocEntry").Value &
", " & Chr(34) & "STATUS" & Chr(34) & "='2' WHERE " & Chr(34) & "ID" & Chr(34) & "=" & rsINDECSAF.Fields.Item("ID").Value

                'MsgBox(sqlActInd)

                rsActInd.DoQuery(sqlActInd)

            End If

            '-----------------------------------------------------------------------
            'Verifico si hace falta cerrar ('C') la cabecera - OPDN si todas las lines estan cerradas
            'sqlPDN1 = "SELECT * FROM " & Chr(34) & db & Chr(34) & "." & Chr(34) & "PDN1" & Chr(34) & " WHERE " & Chr(34) & "LineStatus" & Chr(34) & "<> 'C' AND " &
            'Chr(34) & "DocEntry" & Chr(34) & "=" & rsINDECSAF.Fields.Item("ODRFENTRY").Value

            'rsPDN1.DoQuery(sqlPDN1)

            'If rsPDN1.RecordCount = 0 Then

            'Cierro tambien OPDN
            'sqlOPDN = "UPDATE " & Chr(34) & db & Chr(34) & "." & Chr(34) & "OPDN" & Chr(34) & " SET " & Chr(34) & "DocStatus" & Chr(34) & "='C' WHERE " &
            'Chr(34) & "DocEntry" & Chr(34) & "=" & rsINDECSAF.Fields.Item("DOCENTRYPDN1").Value

            'rsOPDN.DoQuery(sqlOPDN)

            'End If
            '-----------------------------------------------------------------------

            rsINDECSAF.MoveNext()

        Loop

        'MsgBox("Finalizado Actualizacion PCH1")


    End Sub




    Public Sub ExecutionLog(source As String, message As String)

        Dim mExecutionLogPath As String = System.Configuration.ConfigurationManager.AppSettings("ExecutionLogPath")

        System.IO.File.AppendAllText(mExecutionLogPath + "_" + Date.Now.ToString("yyyyMMdd") + ".txt",
                DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff") + " | " + source + " | " + message + System.Environment.NewLine)
    End Sub

End Module
