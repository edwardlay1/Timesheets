Imports System.IO

Public Class frmChangePass

    'When the save button is clicked, check if the old password is correct
    'And the New password Is typed exactly the same twice, then overwrite the old password file
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        Try

            If txtOldPass.Text = "" Then

                MsgBox("Please enter your old password!")

            ElseIf txtOldPass.Text <> frmlogin.password Then

                MsgBox("Old password is incorrect!")

            ElseIf txtNewPass.Text = "" Then

                MsgBox("Please enter a new password!")

            ElseIf txtNewPass.Text = frmlogin.password Then

                MsgBox("Your new password is the same as your old password!")

            ElseIf TxtConfPass.Text = "" Then

                MsgBox("Please confirm your new password!")

            ElseIf txtNewPass.Text <> TxtConfPass.Text Then

                MsgBox("Passwords do not match!")

            Else

                Dim password As New StreamWriter("password.txt")

                Dim sourcetext, character As String
                Dim encryptedText As String = ""

                Dim temp, loops As Integer

                sourcetext = txtNewPass.Text

                For loops = 1 To Len(sourcetext)

                    character = Mid(sourcetext, loops, 1)
                    temp = Asc(character) + 13
                    encryptedText &= Chr(temp)

                Next

                password.WriteLine(encryptedText)

                password.Close()

                frmLogin.password = txtNewPass.Text

                clear()
                Me.Close()

            End If

        Catch ex As Exception

            MessageBox.Show(ex.Message & " Please try again.")

        End Try

    End Sub

    'Code to clear the textboxes and set the focus to txtOldPass
    Private Sub clear()

        txtOldPass.Clear()
        txtNewPass.Clear()
        TxtConfPass.Clear()
        txtOldPass.Focus()

    End Sub
    'When the cancel button is clicked, go back to the login form
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click

        clear()
        Me.Close()

    End Sub

    'When the form loads, set the focus to txtOldPass
    Private Sub frmChangePass_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        txtOldPass.Focus()

    End Sub

    'When the form is closed, exit the program
    Private Sub frmChangePass_Closed(sender As Object, e As EventArgs) Handles Me.Closed

        Me.Close()

    End Sub

End Class