<%@ Page Title="" Language="C#" MasterPageFile="~/Reg.Master" AutoEventWireup="true" CodeBehind="FallBallReport.aspx.cs" Inherits="OnlineReg.FallBallReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
<h1>Fall Ball Registration Report</h1>

<asp:PlaceHolder runat="server" id="ExcelPlaceHolder">
<div style="padding-left:40px">
<asp:Image ID="ExcelImage" ImageUrl="content/Excel.png" runat="server" />
    <asp:LinkButton ID="ExportButton" runat="server" onclick="ExportButton_Click"> Export data</asp:LinkButton>
</asp:PlaceHolder>



<asp:Repeater id="PlayerRepeater"  OnItemDataBound="R1_ItemDataBound"  OnItemCommand="R1_ItemCommand" runat="server" >
        <HeaderTemplate>
        <table border="0" cellpadding="2" cellspacing="2" width="100%">
        <tr>
        <td><b>Guardian</b></td>
        <td><b></b></td>
        <td><b>Phone</b></td>
        <td><b>Player</b></td>
        <td><b></b></td>
        <td><b>Age</b></td>
        <td><b>League</b></td>
        <td><b>Team</b></td>
        <td><b>Created</b></td>
        </tr>
        </HeaderTemplate>

            <ItemTemplate>
            <tr>
             <td><asp:Label ID="GFnameLabel" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Parent1FirstName") %>'></asp:Label>  </td>
             <td><asp:Label ID="GLnameLabel" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Parent1LastName") %>'></asp:Label>  </td>
            <td><asp:Label ID="PhoneLabel" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Parent1Phone") %>'></asp:Label>  </td>
            <td><asp:Label ID="PlayerFName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PlayerFirstName") %>'></asp:Label>  </td>
             <td><asp:Label ID="PlayerLName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PlayerLastName") %>'></asp:Label>  </td>
            <td><asp:Label ID="AgeLabel" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Age") %>'></asp:Label>  </td>
            <td><asp:Label ID="LeagueLabel" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "LeagueName") %>'></asp:Label>  </td>
            <td><asp:Label ID="TeamLabel" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TeamName") %>'></asp:Label>  </td>
             <td><asp:Label ID="CreatedLabel" runat="server" Text='<%# string.Format("{0:MM/dd/yyyy}", DataBinder.Eval(Container.DataItem, "CreatedDate"))  %>'></asp:Label>  </td>


            
            </tr>
            </ItemTemplate>

            <FooterTemplate>
            </table>
            </FooterTemplate>

   </asp:Repeater>

</div>
</asp:Content>
