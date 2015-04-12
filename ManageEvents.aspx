<%@ Page Title="" Language="C#" MasterPageFile="~/Reg.Master" AutoEventWireup="true" ValidateRequest="false" CodeBehind="ManageEvents.aspx.cs" Inherits="OnlineReg.ManageEvents" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">

<h1>Manage Events</h1>
<div style="padding-left:40px">
<h2>Add an Event:</h2>

<table>
<tr>
<td><asp:Label ID="ENLabel" runat="server" Text="Event:"></asp:Label></td>
<td><asp:TextBox ID="EventLabelTextBox" runat="server" Width="184px"></asp:TextBox></td>
<td><asp:Label ID="EPLabel" runat="server" Text="Price:"></asp:Label></td>
<td><asp:TextBox ID="EventPriceTextBox" runat="server" Width="48px"></asp:TextBox></td>
<td><asp:Button ID="AddEventButton" runat="server" Text="Add Event" 
        onclick="AddEventButton_Click" /></td>
</tr>
<tr><td colspan="5"><asp:Label ID="ValidateLabel" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label></td></tr>
    
</table>


<br />

   <asp:Repeater id="ManageEventsRepeater" OnItemDataBound="R1_ItemDataBound"  OnItemCommand="R1_ItemCommand" runat="server" >
        <HeaderTemplate>
        <table border="0" cellpadding="2" cellspacing="2" width="100%">
        <tr>
        <td></td>
        <td><b>Event</b></td>
        <td><b>Price</b></td>
        <td><b>Active</b></td>
        <td></td>
        </tr>
        </HeaderTemplate>

            <ItemTemplate>
            <tr>
             <td><asp:HiddenField runat="server" ID="HiddenEventID" Value='<%# DataBinder.Eval(Container.DataItem, "EventID") %>' />
             </td>
            <td><asp:Label ID="EventLabel" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "EventName") %>'></asp:Label>  </td>      
             <td><asp:Label ID="EventPriceLabel" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "EventPrice") %>'></asp:Label>  </td>
             <td><asp:Label ID="StatusLabel" runat="server" Text=''></asp:Label>  </td>
             <td> <asp:LinkButton ID="ToggleLinkButton" CssClass="HeaderStyle" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "EventID") %>' Text="[Toggle]" runat="server" /></td>
            </tr>
            </ItemTemplate>

            <FooterTemplate>
            </table>
            </FooterTemplate>

            </asp:Repeater>
            </div>
</asp:Content>
