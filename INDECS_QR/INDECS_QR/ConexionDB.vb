Imports System.Data.SqlClient
Imports Sap.Data.Hana

Module ConexionDB


    Public Function ConectatSAPHANNA()

        Dim conn As New HanaConnection("Server=10.10.207.205:30015;UserID=SYSTEM;Password=$LogAdm1n")



        Try
            conn.Open()
            'conn.Close()
            Return True

        Catch ex As HanaException
            MessageBox.Show(ex.Errors(0).Source & " : " &
                            ex.Errors(0).Message & " (" &
                            ex.Errors(0).NativeError.ToString() & ")", "Failed to connect")
            Return False


        End Try
    End Function

    Public Function ConsultaArticulos()

        Dim sql As String = "SELECT " & Chr(34) & "ItemCode" & Chr(34) & "," & Chr(34) & "ItemName" & Chr(34) & " FROM " & Chr(34) & "PREPRODLOG" & Chr(34) & "." & Chr(34) & "OITM" & Chr(34)

        Dim dr As String = 0

        Try
            ConectatSAPHANNA()

            'cmd = New SqlCommand(sql, conn)
            'cmd.CommandType = CommandType.Text

            'cmd.Parameters.Add("@idStaff", SqlDbType.Int)
            'cmd.Parameters("@idStaff").Value = 1
            'dr = cmd.ExecuteReader()

        Catch e As Exception
        End Try


        Return dr

    End Function

End Module
