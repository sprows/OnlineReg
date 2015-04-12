<%@ Page Title="" Language="C#" MasterPageFile="~/Reg.Master" AutoEventWireup="true" CodeBehind="main.aspx.cs" Inherits="OnlineReg.main" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div>
    <div id="content_sec">
      <h1><%=TeamName%> Online Registration</h1>
      <div class="banner">
        <div class="left">
          <div class="banner_left">
            <h3 class="title"><%=TeamName%></h3>
            <p> <%=TeamDesc%>  </p>
           
            <img src="content/<%=TeamPic %>"" class="banner_image"></div>
          <div class="clear"></div>
        </div>
        <div class="banner_right">
          <p class="headline">Please Login or create your account for the first time</span></p>
          <table>
            <tr><td>
            <table>
            <tr><td align="left" class="HeaderStyle">Email:</td><td><asp:TextBox ID="UserNameTextBox" Width="100%" runat="server"></asp:TextBox></td></tr>
            <tr><td align="left" class="HeaderStyle">Password:</td><td><asp:TextBox ID="PasswordLogonTextBox" Width="100%" TextMode="Password" runat="server"></asp:TextBox></td></tr>
            <tr><td><asp:LinkButton ID="ForgotButton" runat="server" 
                    onclick="ForgotButton_Click">Forgot Password?</asp:LinkButton></td><td align="right"><asp:Button ID="cmdLogin" runat="server"  
                    Text="Log Into your Account" onclick="cmdLogin_Click" /></td></tr>
            <tr><td colspan="2"><asp:Label Font-Bold="true" ID="ErrorMessageLabel1" ForeColor="Red" runat="server" Text=""></asp:Label></td></tr>
            </table>
                
            </td>
            <td style="width:40px;">  </td>
                
                
            <td>
             <table>
             <tr>
                <td><p>Email </p></td>
                <td colspan="2" align="right"><asp:TextBox ID="EmailTextBox" CssClass="textfield"  runat="server"></asp:TextBox></td>
            </tr>
           
              <tr>
                <td><p>Password </p></td>
                <td colspan="2" align="right"><asp:TextBox ID="PasswordTextBox" TextMode="Password" CssClass="textfield"  runat="server"></asp:TextBox></td>
                </tr>
              <tr>
                <td><p>Re-type Password</p></td>
                <td colspan="2" align="right"><asp:TextBox ID="Password2TextBox" TextMode="Password" CssClass="textfield" runat="server"></asp:TextBox></td>
              </tr>
              <tr><td></td><td align="right"><asp:Button ID="CreateAccountButton" runat="server"  
                      Text="Create Account" onclick="CreateAccountButton_Click" /></td></tr>
              <tr><td colspan="2"><asp:Label Font-Bold="true" ID="ErrorMessageLabel2" ForeColor="Red" runat="server" Text=""></asp:Label></td></tr>
         </table>
            
            </td>
            </tr>
          </table> 
          <br />
          <br />
        </div>
      </div>
    </div>
  </div>
</asp:Content>
