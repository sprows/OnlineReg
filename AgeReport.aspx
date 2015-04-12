<%@ Page Title="" Language="C#" MasterPageFile="~/Reg.Master" AutoEventWireup="true" CodeBehind="AgeReport.aspx.cs" Inherits="OnlineReg.AgeReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
 <link rel="stylesheet" type="text/css" media="all" href="DatePicker/jsDatePick_ltr.min.css" />

<h1>Player Report</h1>
<div style="padding-left:40px">
<table>
<tr>
<td class='buffer'><asp:Label ID="AgeLabel" runat="server" Text="Age: "></asp:Label></td>
<td class='buffer'><asp:DropDownList ID="AgeDropDownList" runat="server">
    <asp:ListItem>4</asp:ListItem>
    <asp:ListItem>5</asp:ListItem>
    <asp:ListItem>6</asp:ListItem>
    <asp:ListItem>7</asp:ListItem>
    <asp:ListItem>8</asp:ListItem>
    <asp:ListItem>9</asp:ListItem>
    <asp:ListItem>10</asp:ListItem>
    <asp:ListItem>11</asp:ListItem>
     <asp:ListItem>12</asp:ListItem>
     <asp:ListItem>All</asp:ListItem>
    </asp:DropDownList>
</td>
<td><asp:Button ID="RunReportButton" runat="server" Text="Generate Report" 
        onclick="RunReportButton_Click" /></td>
</tr>
</table>

<style>



</style>

<asp:PlaceHolder runat="server" id="ExcelPlaceHolder">
<asp:Image ID="ExcelImage" ImageUrl="content/Excel.png" runat="server" />
    <asp:LinkButton ID="ExportButton" runat="server" onclick="ExportButton_Click"> Export data</asp:LinkButton>
</asp:PlaceHolder>
 <asp:Repeater id="PlayerRepeater"  OnItemDataBound="R1_ItemDataBound"  OnItemCommand="R1_ItemCommand" runat="server" >
        <HeaderTemplate>
        <table border="0" cellpadding="2" cellspacing="2" width="100%">
        <tr>
        <td></td>
        <td><b>Age</b></td>
        <td><b>First</b></td>
        <td><b>Last</b></td>
        <td><b>Sex</b></td>
        <td><b>BirthDate</b></td>
        <td><b>City</b></td>
        <td><b>State</b></td>
        <td><b>Zip</b></td>
        <td><b>Health</b></td>
        </tr>
        </HeaderTemplate>

            <ItemTemplate>
            <tr>
             <td><asp:HiddenField runat="server" ID="HiddenMemberID" Value='<%# DataBinder.Eval(Container.DataItem, "MemberID") %>' />
             </td>
             <td><asp:Label ID="AgeLabel" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Age") %>'></asp:Label>  </td>
             <td><asp:Label ID="FirstNameLabel" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PlayerFirstName") %>'></asp:Label>  </td>
            <td><asp:Label ID="LastNameLabel" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PlayerLastName") %>'></asp:Label>  </td>
            <td><asp:Label ID="SexLabel" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Sex") %>'></asp:Label>  </td>
             <td><asp:Label ID="BirthDate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "BirthDate") %>'></asp:Label>  </td>
            <td><asp:Label ID="CityLabel" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "City") %>'></asp:Label>  </td>
            <td><asp:Label ID="StateLabel" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "State") %>'></asp:Label>  </td>
            <td><asp:Label ID="ZipLabel" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Zip") %>'></asp:Label>  </td>
            <td><asp:Label ID="HealthLabel" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "HeathIssues") %>'></asp:Label>  </td>
            </tr>
            </ItemTemplate>

            <FooterTemplate>
            </table>
            </FooterTemplate>

            </asp:Repeater>


</div>
 



</asp:Content>
