<%@ Page Title="" Language="C#" MasterPageFile="~/Reg.Master" AutoEventWireup="true" CodeBehind="ManagePlayers.aspx.cs" Inherits="OnlineReg.ManagePlayers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">

<h1>Manage Players</h1>

<table><tr><td><h2>Add a Player:</h2></td><td><asp:Button ID="AddPlayerButton" 
        runat="server" Text="Add Player" onclick="AddPlayerButton_Click" /></td></tr></table> 
<br />

   <asp:Repeater id="ManagePlayersRepeater"  OnItemDataBound="R1_ItemDataBound"  OnItemCommand="R1_ItemCommand" runat="server" >
        <HeaderTemplate>
        <table border="0" cellpadding="2" cellspacing="2" width="100%">
        <tr>
        <td></td>
        <td><b>Logon</b></td>
        <td><b>First</b></td>
        <td><b>Last</b></td>
        <td><b>Email</b></td>
        <td><b>Phone</b></td>
        <td><b>First</b></td>
        <td><b>Last</b></td>
        <td><b>Email</b></td>
        <td><b>Phone</b></td>
        <td><b>Created</b></td>
        <td></td>
        <td></td>
        <td></td>
        </tr>
        </HeaderTemplate>

            <ItemTemplate>
            <tr>
             <td><asp:HiddenField runat="server" ID="HiddenMemberID" Value='<%# DataBinder.Eval(Container.DataItem, "MemberID") %>' />
             </td>
             <td><asp:Label ID="LogonLabel" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Username") %>'></asp:Label>  </td>
            <td><asp:Label ID="Parent1FirstNameLabel" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Parent1FirstName") %>'></asp:Label>  </td>
            <td><asp:Label ID="Parent1LastNameLabel" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Parent1LastName") %>'></asp:Label>  </td>
            <td><asp:Label ID="Parent1EmailLabel" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Parent1Email") %>'></asp:Label>  </td>
            <td><asp:Label ID="Parent1PhoneLabel" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Parent1Phone") %>'></asp:Label>  </td>
            <td><asp:Label ID="Parent2FirstNameLabel" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Parent2FirstName") %>'></asp:Label>  </td>
            <td><asp:Label ID="Parent2LastNameLabel" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Parent2LastName") %>'></asp:Label>  </td>
            <td><asp:Label ID="Parent2EmailLabel" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Parent2Email") %>'></asp:Label>  </td>
            <td><asp:Label ID="Parent2PhoneLabel" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Parent2Phone") %>'></asp:Label>  </td>
            <td><asp:Label ID="Label1" runat="server" Text='<%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "CreateDate")).ToShortDateString() %>'></asp:Label>  </td>                                           
            <td><asp:LinkButton ID="EditLinkButton" CssClass="HeaderStyle" CommandName="Edit" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "MemberID") %>' Text="[Edit]" runat="server" /></td>
            <td><asp:LinkButton ID="EventsLinkButton" CssClass="HeaderStyle" CommandName="Events" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "MemberID") %>' Text="[Events]" runat="server" /></td>
            <td><asp:LinkButton ID="MakeAdminLinkButton" CssClass="HeaderStyle" CommandName="Admin" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "MemberID") %>' Text="[Make Admin]" runat="server" /></td>
            </tr>
            </ItemTemplate>

            <FooterTemplate>
            </table>
            </FooterTemplate>

            </asp:Repeater>

</asp:Content>
