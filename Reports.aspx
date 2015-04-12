<%@ Page Title="" Language="C#" MasterPageFile="~/Reg.Master" AutoEventWireup="true" CodeBehind="Reports.aspx.cs" Inherits="OnlineReg.Reports" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
<h1><asp:Label ID="ReportLabel" runat="server" Text="Reports"></asp:Label></h1>
<div style="padding-left:40px">
<br /><br />




<asp:PlaceHolder ID="ReportListPlaceHolder" runat="server">
<table>
<tr><td><asp:LinkButton ID="PaidLinkButton" runat="server" onclick="PaidLinkButton_Click">Paid Status Report</asp:LinkButton></td></tr>
<tr><td><asp:LinkButton ID="NotPaidLinkButton" runat="server" onclick="NotPaidLinkButton_Click">Not Paid Status Report (New signups)</asp:LinkButton></td></tr>
<tr><td><asp:LinkButton ID="NotPaidLastYearLinkButton" runat="server" onclick="NotPaidLastYearButton_Click">Not Paid Status Report (Signed up last year)</asp:LinkButton><br /><br /></td></tr>
<tr><td style="height: 18px"><asp:LinkButton ID="PlayerReportLinkButton" 
        runat="server" onclick="PlayerReportLinkButton_Click">Player Report</asp:LinkButton></td></tr>
<tr><td style="height: 18px">
<asp:LinkButton ID="EverythingReportLinkButton" 
        runat="server" onclick="EverythingReportLinkButton_Click">Everything Report</asp:LinkButton></td></tr>
<tr><td style="height: 18px">
<asp:LinkButton ID="RisingStarLinkButton" 
        runat="server" onclick="RisingStarLinkButton_Click">Rising Star Report</asp:LinkButton>
</td></tr>
<tr><td style="height: 18px">
<asp:LinkButton ID="FallBallLinkButton" 
        runat="server" onclick="FallBall_Click">Fall Ball Report</asp:LinkButton>
</td></tr>        
</table>
</asp:PlaceHolder>

<asp:PlaceHolder runat="server" id="ExcelPlaceHolder">
<asp:Image ID="ExcelImage" ImageUrl="content/Excel.png" runat="server" />
    <asp:LinkButton ID="ExportButton" runat="server" onclick="ExportButton_Click"> Export data</asp:LinkButton>
</asp:PlaceHolder>
 <asp:Repeater id="PaidRepeater"  OnItemDataBound="R1_ItemDataBound"  OnItemCommand="R1_ItemCommand" runat="server" >
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
        <td><b>MoneyPaid</b></td>
        <td><b>Players</b></td>
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
            <td><asp:Label ID="MoneyPaidLabel" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "MoneyPaid") %>'></asp:Label>  </td>
             <td><asp:Label ID="PlayerCountLabel" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PlayerCount") %>'></asp:Label>  </td>
            <td><asp:Label ID="Label1" runat="server" Text='<%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "CreateDate")).ToShortDateString() %>'></asp:Label>  </td>                                           
            <td><asp:LinkButton ID="EditLinkButton" CssClass="HeaderStyle" CommandName="Edit" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "MemberID") %>' Text="[Edit]" runat="server" /></td>
            <td><asp:LinkButton ID="EventsLinkButton" CssClass="HeaderStyle" CommandName="Events" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "MemberID") %>' Text="[Events]" runat="server" /></td>
            </tr>
            </ItemTemplate>

            <FooterTemplate>
            </table>
            </FooterTemplate>

            </asp:Repeater>
            </div>
</asp:Content>
