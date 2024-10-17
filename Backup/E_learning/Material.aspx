<%@ Page Language="VB" MasterPageFile="~/UserMasterPage.master" AutoEventWireup="false" CodeFile="Material.aspx.vb" Inherits="Material" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%">
        <tr>
            <td>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false">
    <Columns>
        <asp:BoundField DataField="Name" HeaderText="File Name" />
        <asp:TemplateField ItemStyle-HorizontalAlign="Center">
            <ItemTemplate>
                <asp:LinkButton ID="lnkView" runat="server" Text="View" OnClick="View" CommandArgument='<%# Eval("Id") %>'></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>

            </td>
        </tr>
        <tr>
            <td>
                   <asp:Literal ID="ltEmbed" runat="server" /></td>
        </tr>
    </table>
</asp:Content>

