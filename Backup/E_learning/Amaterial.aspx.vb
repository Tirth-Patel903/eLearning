Imports System.Data.SqlClient
Imports System.Data
Imports System.Configuration
Imports System.IO
Partial Class Amaterial
    Inherits System.Web.UI.Page
    Private Sub BindGrid()
        'Dim constr As String = ConfigurationManager.ConnectionStrings("Mycon").ConnectionString
        'Using con As New SqlConnection(constr)
        '    Using cmd As New SqlCommand()
        '        cmd.CommandText = "select Id, Name from MyFile"
        '        cmd.Connection = con
        '        con.Open()
        '        GridView1.DataSource = cmd.ExecuteReader()
        '        GridView1.DataBind()
        '        con.Close()
        '    End Using
        'End Using
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        BindGrid()
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim filename As String = Path.GetFileName(FileUpload1.PostedFile.FileName)
        Dim contentType As String = FileUpload1.PostedFile.ContentType
        Using fs As Stream = FileUpload1.PostedFile.InputStream
            Using br As New BinaryReader(fs)
                Dim bytes As Byte() = br.ReadBytes(fs.Length)
                Dim constr As String = ConfigurationManager.ConnectionStrings("Mycon").ConnectionString
                Using con As New SqlConnection(constr)
                    Dim query As String = "insert into MyFile values (@Name, @ContentType, @Data)"
                    Using cmd As New SqlCommand(query)
                        cmd.Connection = con
                        cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = filename
                        cmd.Parameters.Add("@ContentType", SqlDbType.VarChar).Value = contentType
                        cmd.Parameters.Add("@Data", SqlDbType.Binary).Value = bytes
                        con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                        GridView1.DataBind()
                    End Using
                End Using
            End Using
        End Using
        '   Response.Redirect(Request.Url.AbsoluteUri)

    End Sub
End Class
