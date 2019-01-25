<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="ChangePasswordFixed.aspx.cs" Inherits="ASPVulnerableLab.Account.ChangePasswordFixed" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form runat="server">
        <div>
       <asp:Label runat="server" ID="OldPasswordLabel" AssociatedControlID="OldPassword">Old password</asp:Label>
        <asp:TextBox runat="server" ID="OldPassword" CssClass="passwordEntry" TextMode="Password" /><br /><br />
        <asp:Label runat="server" ID="NewPasswordLabel" AssociatedControlID="NewPassword">New password</asp:Label>
        <asp:TextBox runat="server" ID="NewPassword" CssClass="passwordEntry" TextMode="Password" /><br /><br />
        <asp:Button ID="ChangePasswordButton" runat="server" OnClick="ChangePassword_Click" Text="Change password"  />
        </div>
    </form>
    <asp:PlaceHolder ID = "ChangePasswordStatus" runat="server" />
</asp:Content>
