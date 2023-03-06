Imports MySql.Data.MySqlClient
Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'koneksi()
        If TextBox1.Text = "" Or TextBox2.Text = "" Then
            MsgBox("Masukan Username dan Password")
        Else
            Call koneksi()
            cmd = New MySqlCommand("Select * From tbl_user where username='" & TextBox1.Text & "' and password ='" & TextBox2.Text & "'", con)
            rd = cmd.ExecuteReader
            rd.Read()
            If rd.HasRows Then

                Me.Hide()
                'Form2.Label10.Text = rd!username
                Form2.Label10.Text = rd!username
                Form2.Show()
                'Form2.PanelHome.Show()
            Else
                MsgBox("Silahkan Masukan Username dan password yang Benar")
            End If
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub
End Class
