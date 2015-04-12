<%@ Page Title="" Language="C#" MasterPageFile="~/Reg.Master" AutoEventWireup="true" CodeBehind="Summer.aspx.cs" Inherits="OnlineReg.Summer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">

<h1>Fall Ball Season Registration</h1>

 <div align="center"><p class="headline">Fall Ball registration is currently closed.</p>
</br></br>

<%--<p class="headline"><b>Rising Star Summer session registration is currently closed.</b></p>--%>
</div><br /><br />

<asp:panel runat="server" id="SummerPanel">

<div style="padding-left:40px">  
<b>The following players are elgible for the Fall Ball season:</b>
<br /><br />

<asp:Repeater id="PlayerRepeater" runat="server" OnItemDataBound="R1_ItemDataBound" >
        <HeaderTemplate>
        <table width="70%" border="0" cellpadding="2" cellspacing="2">
        <tr>
        <td> </td>
        <td><b>First Name</b></td>
        <td><b>Last Name</b></td>
        <td><b>Age</b></td>
        <td><b>Price</b></td>
        <td style="padding-left:5px"><b>Sign up?</b></td>
        </tr>
        </HeaderTemplate>

            <ItemTemplate>
            <tr>
            <td><asp:HiddenField runat="server" ID="HiddenPlayerID" Value='<%# DataBinder.Eval(Container.DataItem, "PlayerID") %>' /></td>
            <td style="padding-left:5px"><asp:Label ID="PlayerFirstName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PlayerFirstName") %>'></asp:Label>  </td>
            <td style="padding-left:5px"><asp:Label ID="PlayerLastName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PlayerLastName") %>'></asp:Label>  </td>
             <td style="padding-left:5px"><asp:Label ID="PlayerAge" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Age") %>'></asp:Label>  </td>
             <td style="padding-left:5px">$60</td>                
             <td style="padding-left:5px"><asp:CheckBox ID="ChBox" runat="server" /></td>
            </tr>
            </ItemTemplate>

            <FooterTemplate>
            </table>
            </FooterTemplate>

</asp:Repeater>

<asp:Label Font-Bold="true" ID="ErrorMessageLabel" ForeColor="Red" runat="server" Text=""></asp:Label>
<br />   
    <asp:Button ID="SignUpButton" runat="server" Text="Sign Up" 
        onclick="SignUpButton_Click" />

</div>
</asp:panel>

</asp:Content>
