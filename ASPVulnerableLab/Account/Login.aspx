<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ASPVulnerableLab.Account.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   <asp:PlaceHolder ID="LoginFormPage" runat="server">
        <form id="Form1"  method="post" runat="server" >
        <table> 
        <tr><td>UserName: </td><td><asp:TextBox Id="Username" runat="server" name="username"/></td><td><span id="status"></span></td></tr>
        <tr><td>Password :</td><td><asp:TextBox id="Password" runat="server" type="password" name="password"/></td></tr>
         <tr><td><asp:button ID="Button1" runat="server" Text="Login" onclick="LoginButton_Click"/></td></tr>
        </table>  
        </form>
    </asp:PlaceHolder>
</asp:Content>
