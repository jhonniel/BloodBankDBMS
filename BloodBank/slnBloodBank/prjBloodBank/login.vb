Imports System.Data.SqlClient

Public Class login
    Public UserName As String
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim str As String = base64Encode(txtPassword.Text)
        If txtUsername.Text.Length <= 0 Then
            MessageBox.Show("Please enter username")
        ElseIf txtPassword.Text.Length <= 0 Then
            MessageBox.Show("Please enter password")
        End If
        Dim user As String = txtUsername.Text
        Dim pass As String = str
        UserName = txtUsername.Text
        FunctionLogin(user, pass)
        txtPassword.Clear()
        txtUsername.Clear()
    End Sub
End Class