Public Class VenPrincipal


    Private Sub VenPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try

            CnnStr = My.Settings.StringConexion
        Catch ex As Exception
            MessageBox.Show(ex.Message & ", la aplicacion se cerrara", "COCK", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Application.Exit()
        End Try
    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click

        Application.Exit()
    End Sub

    Private Sub VenPrincipal_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Application.Exit()
    End Sub

    Private Sub ExportacionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportacionToolStripMenuItem.Click
        VenExMassalin.Show()
        VenExMassalin.Focus()
    End Sub

    Private Sub ExportaciónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportaciónToolStripMenuItem.Click
        VenExMondelez.Show()
        VenExMondelez.Focus()
    End Sub

    Private Sub ListadoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ListadoToolStripMenuItem.Click
        VenClientesMassalin.Show()
        VenClientesMassalin.Focus()
    End Sub

    Private Sub ListadoToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ListadoToolStripMenuItem1.Click
        VenClientesMondelez.Show()
        VenClientesMondelez.Focus()
    End Sub

    Private Sub AsignarHijosAutomaticamenteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AsignarHijosAutomaticamenteToolStripMenuItem.Click
        Dim venSetearHijos As New VenSetearHijosMassalin()
        venSetearHijos.ShowDialog()
    End Sub

    Private Sub AsignarHijosAutomaticamenteToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AsignarHijosAutomaticamenteToolStripMenuItem1.Click
        Dim venSetearHijos As New VenSetearHijosMondelez()
        venSetearHijos.ShowDialog()
    End Sub

    Private Sub ActualizarDatosMondelezToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ActualizarDatosMondelezToolStripMenuItem.Click

        VenElegirArchivoSoloHijos.ShowDialog()
    End Sub

    Private Sub ImportarDesdeExcelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportarDesdeExcelToolStripMenuItem.Click

        ImportarClientesMassalinExcel.ShowDialog()
    End Sub

    Private Sub ImportarDesdeExcelToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ImportarDesdeExcelToolStripMenuItem1.Click

        ImportarClientesMondelezExcel.ShowDialog()
    End Sub
End Class
