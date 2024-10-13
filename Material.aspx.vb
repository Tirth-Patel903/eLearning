Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Partial Class Material
    Inherits System.Web.UI.Page
    Private Sub BindGrid()
        Dim constr As String = ConfigurationManager.ConnectionStrings("Mycon").ConnectionString
        Using con As New SqlConnection(constr)
            Using cmd As New SqlCommand()
                cmd.CommandText = "select Id, Name from MyFile"
                cmd.Connection = con
                con.Open()
                GridView1.DataSource = cmd.ExecuteReader()
                GridView1.DataBind()
                con.Close()
            End Using
        End Using
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        BindGrid()
    End Sub

    Protected Sub View(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim id As Integer = Integer.Parse(TryCast(sender, LinkButton).CommandArgument)
        Dim embed As String = "<object data=""{0}{1}"" type=""application/pdf"" width=""500px"" height=""600px"">"
        embed += "If you are unable to view file, you can download from <a href = ""{0}{1}&download=1"">here</a>"
        embed += " or download <a target = ""_blank"" href = ""http://get.adobe.com/reader/"">Adobe PDF Reader</a> to view the file."
        embed += "</object>"
        ltEmbed.Text = String.Format(embed, ResolveUrl("~/Handler.ashx?Id="), ID)

    End Sub
End Class
