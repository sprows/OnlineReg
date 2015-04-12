<%@ Page Title="" Language="C#" MasterPageFile="~/Reg.Master" AutoEventWireup="true" CodeBehind="ListEvents.aspx.cs"  Inherits="OnlineReg.ListEvents" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">

<h1>Purchase Registration</h1>

 <p class="headline"><asp:Label ID="MessageLabel" runat="server" Text=""></asp:Label><asp:Label ID="NameLabel" ForeColor="Black" Font-Bold="true" runat="server" Text=""></asp:Label></p>
<br />

  

  <div style="padding-left:40px"> 
    <%--<asp:Label ID="InfoMessage" runat="server" Text="*** Note:  &nbsp;&nbsp;Early Bird Prices are listed below.  &nbsp;&nbsp;After January 31st Prices rise by <b>$25 per child</b>.  &nbsp;&nbsp;Please act now to take advantage of the Early Bird Special!"></asp:Label>--%>
Little League changed the age determinations starting in 2015.  This will impact your player's "Baseball age" if the player was born on or after January 1, 2006.
<br /><br />
Use the <a href='http://www.littleleague.org/leagueofficers/Determine_League_Age.htm' target="_blank">Find my players age</a> link to determine what package you should purchase for your player.
<br />
  <br />
  <asp:Label ID="AgeLabel" runat="server" Text=""></asp:Label>
  <br />
<br />
<b>Select an approipiate Package(s) and check out:</b><br /><br />
  <asp:Repeater id="EventsRepeater" runat="server" OnItemDataBound="R1_ItemDataBound" >
        <HeaderTemplate>
        <table border="0" cellpadding="2" cellspacing="2">
        <tr>
        <td> </td>
        <td><b>Name</b></td>
        <td style="padding-left:5px"><b>Price</b></td>
        <td style="padding-left:5px"><b>Purchase?</b></td>
        </tr>
        </HeaderTemplate>

            <ItemTemplate>
            <tr>
            <td><asp:HiddenField runat="server" ID="HiddenEventID" Value='<%# DataBinder.Eval(Container.DataItem, "EventID") %>' /></td>
            <td style="padding-left:5px"><asp:Label ID="EventLabel" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "EventName") %>'></asp:Label>  </td>      
            <td style="padding-left:5px"><asp:Label ID="EventPrice" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "EventPrice") %>'></asp:Label>  </td>
             <td style="padding-left:5px"><asp:CheckBox ID="ChBox" runat="server" /></td>
            </tr>
            </ItemTemplate>

            <FooterTemplate>
            </table>
            </FooterTemplate>

</asp:Repeater>
<br /><br />
<asp:Button ID="PurchaseButton" runat="server" Text="Check Out" 
        onclick="PurchaseButton_Click" />
    <asp:Button ID="SaveButton" runat="server" onclick="SaveButton_Click" 
        Text="Save" />
</div>
        <asp:Label ID="AdminLabel" Visible="false" runat="server"></asp:Label>
</asp:Content>
