<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="EditSecret.aspx.cs" Inherits="ASPVulnerableLab.Account.EditSecret" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <form runat="server">
            Current Secret: <asp:PlaceHolder ID="CurrentSecretPlace" runat="server" /><br />
            New Secret:<asp:TextBox Id="NewSecret" runat="server"/><br />
           <asp:button ID="ChangeSecretButton" runat="server" Text="Change" onclick="ChangeSecretButton_Click"/>
        </form>
        <asp:PlaceHolder ID = "ChangeSecretStatus" runat="server" />
    </div>
</asp:Content>
