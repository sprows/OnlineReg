<%@ Page Title="" Language="C#" MasterPageFile="~/Reg.Master" AutoEventWireup="true" CodeBehind="Forgot.aspx.cs" Inherits="OnlineReg.Forgot" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
 <div>
    <div id="content_sec">
     <h1>Forgot Password?</h1>
     <br />
     <div align="center">
     <b>Please enter in the email address you used when you created your account and an email will be sent to you with your password.</b></br></br>
     <table>
            <tr><td align="left">Email:</td><td><asp:TextBox ID="UserNameTextBox" Width="100%" runat="server"></asp:TextBox></td>
            
            <td style="padding-left:15px">
                <asp:Button ID="cmdSendMePassword" runat="server"  
                    Text=" Send me my password " onclick="cmdSendMePassword_Click"/></td></tr>
            <tr><td colspan="3"><br /><asp:Label Font-Bold="true" ID="ErrorMessageLabel" ForeColor="Red" runat="server" Text=""></asp:Label></td></tr>
            </table>
     </div>
   </div>
 </div>
</asp:Content>
