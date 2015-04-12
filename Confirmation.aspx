<%@ Page Title="" Language="C#" MasterPageFile="~/Reg.Master" AutoEventWireup="true" CodeBehind="Confirmation.aspx.cs" Inherits="OnlineReg.Confirmation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
<asp:Label ID="PayPalLabel" Visible="false" runat="server"></asp:Label>

<h1>Summary of purchase</h1>

 <div style="padding-left:40px"><p class="headline"><asp:Label ID="MessageLabel" runat="server" Text="Please review your purchase choices."></asp:Label></p>
<br />
   <asp:Repeater id="TheEvents" runat="server" OnItemDataBound="R1_ItemDataBound" >
        <HeaderTemplate>
        <table border="0" cellpadding="2" cellspacing="2">
        <tr>
        <td> </td>
        <td><b>Name</b></td>
        <td style="padding-left:5px"><b>Price</b></td>
        </tr>
        </HeaderTemplate>

            <ItemTemplate>
            <tr>
             <td><asp:HiddenField runat="server" ID="HiddenEventID" Value='' /></td>
            <td><asp:Label ID="EventLabel" runat="server"></asp:Label>  </td>      
            <td style="padding-left:5px"><asp:Label ID="EventPrice" runat="server"></asp:Label>  </td>
                   
            </tr>
            </ItemTemplate>

            <FooterTemplate>
            <tr>
            <td></td>
            <td><b>Total:</b></td>
            <td style="padding-left:5px"><asp:Label ID="TotalLabel" Font-Bold="true" runat="server"></asp:Label></td>
            </tr>
            </table>
            </FooterTemplate>

</asp:Repeater>

<br />
<asp:Label ID="KidsLabel" runat="server" Text=""></asp:Label>
<br />
<br />
<table>
<td><asp:CheckBox ID="ChTerms1" runat="server" Text="" /></td>
</tr>
<tr>
<td>
<asp:CheckBox ID="ChTerms2" runat="server" Text="" />
</td>
</tr>
<tr>
<td>
<br /><br />
<asp:Button ID="PurchaseButton" runat="server" Text="Purchase" 
        onclick="PurchaseButton_Click" />
<asp:Label ID="ValidateLabel" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
</td>
</tr>
</table>
</div>


</asp:Content>
