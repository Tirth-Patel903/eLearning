
Partial Class UserMasterPage
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Label1.Text = Session("User")
        If (Session("User") Is Nothing) Then
            Response.Redirect("AdminLogin.aspx")
        End If
    End Sub
End Class

