Imports System.Data
Imports System.Data.SqlClient
Partial Class userregistration
    Inherits System.Web.UI.Page
    Dim cmd = New SqlCommand
    Dim con As New SqlConnection
   

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox1.Focus()



    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        cmd = New SqlCommand("insert into Registration values(@Userid,@Username,@Lastname,@Email,@Password,@Gender)", con)
        cmd.Parameters.AddWithValue("@Userid", TextBox1.Text)
        cmd.Parameters.AddWithValue("@Username", TextBox2.Text)
        cmd.Parameters.AddWithValue("@Lastname", TextBox3.Text)
        cmd.Parameters.AddWithValue("@Email", TextBox4.Text)
        cmd.Parameters.AddWithValue("@Password", TextBox5.Text)
        cmd.Parameters.AddWithValue("@Gender", TextBox6.Text)
        cmd.ExecuteNonQuery()
        MsgBox("ok")

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        con = New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\MEET\Desktop\E_learning\App_Data\Mydb.mdf;Integrated Security=True;User Instance=True")
        con.Open()
    End Sub
End Class
