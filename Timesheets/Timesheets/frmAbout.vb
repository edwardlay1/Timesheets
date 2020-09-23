Public Class frmAbout

    'When the OK button is clicked, close the form
    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click

        btnOK.Focus()
        Me.Close()

    End Sub

    'When the form loads, set the focus to the OK button
    Private Sub frmAbout_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        btnOK.Focus()

    End Sub

End Class