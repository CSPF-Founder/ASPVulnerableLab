<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="EditTitle.aspx.cs" Inherits="ASPVulnerableLab.Application.EditTitle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h4>Only authorized persons are allowed here:</h4><br />
        <form id="Form1" runat="server">
            Title:<asp:TextBox Id="NewAppTitle" runat="server"/><br />
           <asp:button ID="ChangeTitleButton" runat="server" Text="Change" onclick="ChangeTitleButton_Click"/>
        </form>
        <asp:PlaceHolder ID = "ChangeTitleStatus" runat="server" />
    </div>
</asp:Content>
