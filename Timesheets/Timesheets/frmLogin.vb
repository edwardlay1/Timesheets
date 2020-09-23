Imports System.IO

Public Class frmLogin

    Public password As String
    Dim pass As StreamReader

    ' On start-up, read in the password into the password variable
    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If Application.OpenForms().OfType(Of frmMain).Any Then

            frmMain.Close()

        End If

        txtPassword.Focus()

        Try

            readpass()

        Catch ex As FileNotFoundException

            MessageBox.Show("Password file missing!" + vbNewLine + "The program will now exit.")
            Me.Close()

        Catch ex As Exception

            MessageBox.Show(ex.Message + vbNewLine + "The program will now exit.")
            Me.Close()

        End Try

    End Sub

    ' Subroutine to read in the password file
    Private Sub readpass()

        pass = New StreamReader("password.txt")

        Dim sourcetext, character As String
        Dim encryptedText As String = ""

        Dim temp, loops As Integer

        sourcetext = pass.ReadLine

        If sourcetext = "" Then

            Throw New Exception("Password file empty")
            Exit Sub

        End If

        pass.Close()

        For loops = 1 To Len(sourcetext)

            character = Mid(sourcetext, loops, 1)
            temp = Asc(character) - 13
            encryptedText &= Chr(temp)

        Next

        password = encryptedText

    End Sub

    ' When the login button is pressed, validate the password, then switch to the main form
    ' or tell the user what is wrong
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click

        Try

            If txtPassword.Text = "" Then

                MsgBox("Please enter a password!")

            ElseIf txtPassword.Text = password Then

                frmMain.Show()
                txtPassword.Clear()
                txtPassword.Focus()
                Me.Hide()
                frmMain.muiOpen.PerformClick()

            Else

                MsgBox("Incorrect password!")

            End If

        Catch ex As Exception

            MessageBox.Show(ex.Message & " Please try again.")

        End Try


    End Sub

    '  Code to exit the program when the close(x) button is clicked
    Private Sub frmLogin_Closed(sender As Object, e As EventArgs) Handles Me.Closed

        Application.Exit()

    End Sub

End Class
