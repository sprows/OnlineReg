<%@ Page Title="" Language="C#" MasterPageFile="~/Reg.Master" AutoEventWireup="true" CodeBehind="EverythingReport.aspx.cs" Inherits="OnlineReg.EverythingReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">

 <link rel="stylesheet" type="text/css" media="all" href="DatePicker/jsDatePick_ltr.min.css" />
<h1>Everything Report</h1>
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

<asp:PlaceHolder runat="server" id="ExcelPlaceHolder">
<asp:Image ID="ExcelImage" ImageUrl="content/Excel.png" runat="server" />
    <asp:LinkButton ID="ExportButton" runat="server" onclick="ExportButton_Click"> Export data</asp:LinkButton>
</asp:PlaceHolder>
 <asp:Repeater id="PlayerRepeater"  OnItemDataBound="R1_ItemDataBound"  OnItemCommand="R1_ItemCommand" runat="server" >
        <HeaderTemplate>
        <table border="0" cellpadding="2" cellspacing="2" width="100%">
        <tr>
        <td></td>
        <td><b>Username</b></td>
        <td><b>FirstName</b></td>
        <td><b>LastName</b></td>
        <td><b>Email</b></td>
        <td><b>Phone</b></td>
        <td><b>FirstName</b></td>
        <td><b>LastName</b></td>
        <td><b>Email</b></td>
        <td><b>Phone</b></td>
        <td><b>Age</b></td>
        <td><b>FirstName</b></td>
        <td><b>LastName</b></td>
        <td><b>Street</b></td>
        <td><b>City</b></td>
        <td><b>Zip</b></td>
        <td><b>BirthDate</b></td>
        <td><b>Sex</b></td>
        <td><b>OtherSport</b></td>
        <td><b>Primary</b></td>
        </tr>
        </HeaderTemplate>

            <ItemTemplate>
            <tr>
             <td><asp:HiddenField runat="server" ID="HiddenMemberID" Value='<%# DataBinder.Eval(Container.DataItem, "MemberID") %>' />
             </td>
             <td><asp:Label ID="UsernameLabel" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Username") %>'></asp:Label>  </td>
            <td><asp:Label ID="G1FirstNameLabel" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Guardian1FirstName") %>'></asp:Label>  </td>
            <td><asp:Label ID="G1LastNameLabel" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Guardian1LastName") %>'></asp:Label>  </td>
             <td><asp:Label ID="G1EmailLabel" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Guardian1Email") %>'></asp:Label>  </td>
            <td><asp:Label ID="G1PhoneLabel" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Guardian1Phone") %>'></asp:Label>  </td>
            <td><asp:Label ID="G2FirstNameLabel" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Guardian2FirstName") %>'></asp:Label>  </td>
            <td><asp:Label ID="G2LastNameLabel" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Guardian2LastName") %>'></asp:Label>  </td>
             <td><asp:Label ID="G2EmailLabel" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Guardian2Email") %>'></asp:Label>  </td>
            <td><asp:Label ID="G2PhoneLabel" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Guardian2Phone") %>'></asp:Label>  </td>
             <td><asp:Label ID="AgeLabel" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Age") %>'></asp:Label>  </td>
              <td><asp:Label ID="FirstNameLabel" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Playerfirstname") %>'></asp:Label>  </td>
                <td><asp:Label ID="LastNameLabel" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Playerlastname") %>'></asp:Label>  </td>
               <td><asp:Label ID="StreetLabel" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "StreetAddress") %>'></asp:Label>  </td>
                <td><asp:Label ID="CityLabel" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "City") %>'></asp:Label>  </td>
                 <td><asp:Label ID="ZipLabel" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Zip") %>'></asp:Label>  </td>
                 <td><asp:Label ID="BirthDateLabel" runat="server" Text='<%# string.Format("{0:MM/dd/yyyy}", DataBinder.Eval(Container.DataItem, "BirthDate"))  %>'></asp:Label>  </td>
                  <td><asp:Label ID="SexLabel" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Sex") %>'></asp:Label>  </td>
                   <td><asp:Label ID="OtherSportLabel" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "OtherSpringSport") %>'></asp:Label>  </td>
                    <td><asp:Label ID="PrimaryLabel" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PrimaryCommitment") %>'></asp:Label>  </td>
            </tr>
            </ItemTemplate>

            <FooterTemplate>
            </table>
            </FooterTemplate>

            </asp:Repeater>


</div>

</asp:Content>
