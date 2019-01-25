<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="ASPVulnerableLab.Account.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:PlaceHolder ID="RegisterFormPage" runat="server">
        <form id="Form1"  method="post" runat="server" >
        <table> 
        <tr><td>New UserName: </td><td><asp:TextBox Id="Username" runat="server" name="username"/></td><td><span id="status"></span></td></tr>
        <tr><td>New Password :</td><td><asp:TextBox id="Password" runat="server" type="password" name="password"/></td></tr>
        <tr><td>New Secret :</td><td><asp:TextBox id="Secret" runat="server" /></td></tr>

         <tr><td><asp:button ID="Button1" runat="server" Text="Register" onclick="RegisterButton_Click"/></td></tr>
        </table>  
            <asp:HiddenField runat="server" ID="Privilege" Value="1" />
        </form>
    </asp:PlaceHolder>
</asp:Content>
