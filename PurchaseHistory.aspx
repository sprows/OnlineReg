<%@ Page Title="" Language="C#" MasterPageFile="~/Reg.Master" AutoEventWireup="true" CodeBehind="PurchaseHistory.aspx.cs" Inherits="OnlineReg.PurchaseHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
<h1>Purchase History</h1>

<br />
 <div style="padding-left:40px">  <asp:Repeater id="TheEvents" runat="server" OnItemDataBound="R1_ItemDataBound" >
        <HeaderTemplate>
        <table border="0" cellpadding="2" cellspacing="2">
        <tr>
        <td> </td>
        <td><b>Name</b></td>
        <td style="padding-left:5px"><b>Price</b></td>
        <td style="padding-left:5px"><b>Date Purchased</b></td>
        </tr>
        </HeaderTemplate>

            <ItemTemplate>
            <tr>
             <td><asp:HiddenField runat="server" ID="HiddenEventID" Value='' /></td>
            <td><asp:Label ID="EventLabel" runat="server"></asp:Label>  </td>      
            <td style="padding-left:5px"><asp:Label ID="EventPrice" runat="server"></asp:Label>  </td>
            <td style="padding-left:5px"><asp:Label ID="DatePurchasedLabel" runat="server"></asp:Label>  </td>        
            </tr>
            </ItemTemplate>

            <FooterTemplate>
            </table>
            </FooterTemplate>

</asp:Repeater>
</div>
</asp:Content>
