Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Data
Partial Class AdminLogin
    Inherits System.Web.UI.Page
    Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("Mycon").ConnectionString)
    Dim cmd As New SqlCommand()
    Dim da As New SqlDataAdapter()
    Dim ds As New DataSet()
    Dim str As String
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        If con.State = ConnectionState.Closed Then
            con.Open()
        End If

        str = "select * from Alogin where UserId=@uid and Password=@pwd"
        cmd = New SqlCommand(str, con)
        cmd.Parameters.AddWithValue("@uid", TextBox1.Text)
        cmd.Parameters.AddWithValue("@pwd", TextBox2.Text)
        da = New SqlDataAdapter(cmd)
        ds = New DataSet()
        da.Fill(ds)
        Session("User") = TextBox1.Text
        Dim cnt As Integer
        cnt = ds.Tables(0).Rows.Count
        If (cnt = 0) Then
            Label2.Text = "Invalid Username or password..."
        Else
            Response.Redirect("AHome.aspx")



        End If
        cmd = New SqlCommand("select * from Registration where UserId=@Userid and Password=@Password", con)
        cmd.Parameters.AddWithValue("@Userid", TextBox1.Text)
        cmd.Parameters.AddWithValue("@Password", TextBox2.Text)
        da = New SqlDataAdapter(cmd)
        ds = New DataSet()
        da.Fill(ds)
        Session("User") = TextBox1.Text
        Dim cntt As Integer
        cntt = ds.Tables(0).Rows.Count
        If (cntt = 0) Then
            Label2.Text = "Invalid Username or password..."
        Else
            Response.Redirect("HOME.aspx")



        End If

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox1.Focus()

    End Sub
End Class
