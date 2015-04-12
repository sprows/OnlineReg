<%@ Page Title="" Language="C#" MasterPageFile="~/Reg.Master" AutoEventWireup="true" CodeBehind="EditPlayer.aspx.cs" Inherits="OnlineReg.EditPlayer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
  <link rel="stylesheet" type="text/css" media="all" href="DatePicker/jsDatePick_ltr.min.css" />
<script type="text/javascript" src="DatePicker/jsDatePick.min.1.3.js"></script>

<script type="text/javascript">
    window.onload = function () {
        new JsDatePick({
            useMode: 2,
            target: "<%=BirthDateTextBox1.ClientID %>",
            dateFormat: "%d-%M-%Y"
        });
    };
</script>

 
<div style="padding-left:40px">

<p class="headline"><asp:Label ID="MessageLabel" runat="server" Text="Please enter in your information"></asp:Label><asp:Label ID="NameLabel" ForeColor="Black" Font-Bold="true" runat="server" Text=""></asp:Label></p>

 
<table>
<tr><td colspan="4" style="font-weight:bold;"><br />Player</td></tr>
  <tr>
    <td class='buffer'>First Name:<asp:Label ID="ChildFirstNameValidate1" runat="server" Text=" **" Font-Bold="true" ForeColor="Red"></asp:Label></td><td class='buffer'><asp:TextBox Width="100%" ID="ChildFirstNameTextBox1" runat="server"></asp:TextBox></td>
    <td class='buffer'>Last Name:<asp:Label ID="ChildLastNameValidate1" runat="server" Text=" **" Font-Bold="true" ForeColor="Red"></asp:Label></td><td class='buffer'><asp:TextBox Width="100%" ID="ChildLastNameTextBox1" runat="server"></asp:TextBox></td>
  </tr>
  <tr>
    <td class='buffer'>Street Address:<asp:Label ID="StreetAddressValidate1" runat="server" Text=" **" Font-Bold="true" ForeColor="Red"></asp:Label></td><td colspan= "3" class='buffer'><asp:TextBox Width="100%" ID="StreetAddressTextBox1" runat="server"></asp:TextBox></td>
  </tr>
   <tr>
     <td class='buffer'>City:<asp:Label ID="CityTextBoxValidate1" runat="server" Text=" **" Font-Bold="true" ForeColor="Red"></asp:Label></td>
     <td colspan="3">
      <table>
       <tr>
         <td><asp:TextBox Width="100%" ID="CityTextBox1" runat="server"></asp:TextBox></td>
         <td class='buffer'> State:<asp:Label ID="StateValidate1" runat="server" Text=" **" Font-Bold="true" ForeColor="Red"></asp:Label></td>
         <td class='buffer'><asp:TextBox Width="100%" ID="StateTextBox1" runat="server"></asp:TextBox></td>
         <td class='buffer'> Zip:<asp:Label ID="ZipTextValidate1" runat="server" Text=" **" Font-Bold="true" ForeColor="Red"></asp:Label></td>
         <td class='buffer'><asp:TextBox Width="100%" ID="ZipTextBox1" runat="server"></asp:TextBox>
       </tr>
     </table>
     </td>
  </tr>
   <tr>
    <td class='buffer'>BirthDate:<asp:Label ID="BirthDateValidate1" runat="server" Text=" **" Font-Bold="true" ForeColor="Red"></asp:Label></td><td class='buffer'><asp:TextBox Width="100%" ID="BirthDateTextBox1" runat="server"></asp:TextBox></td>
    <td class='buffer'>M/F:<asp:Label ID="SexValidate1" runat="server" Text=" **" Font-Bold="true" ForeColor="Red"></asp:Label></td><td class='buffer'>
        <asp:DropDownList ID="SexCombo1" runat="server">
           <asp:ListItem></asp:ListItem>
           <asp:ListItem>M</asp:ListItem>
           <asp:ListItem>F</asp:ListItem>
        </asp:DropDownList>
        </td>
  </tr>
  <tr>
    <td class='buffer'>Child Plays Other</br>Spring Sport?:</td><td class='buffer'><asp:DropDownList ID="OtherSpringSportCombo1" runat="server">
           <asp:ListItem></asp:ListItem>
           <asp:ListItem>Y</asp:ListItem>
           <asp:ListItem>N</asp:ListItem>
        </asp:DropDownList></td>
    <td class='buffer'>Is AMLL Primary</br>Commitment?:</td><td class='buffer'> <asp:DropDownList ID="PrimaryCommitmentCombo1" runat="server">
            <asp:ListItem></asp:ListItem>
           <asp:ListItem>Y</asp:ListItem>
           <asp:ListItem>N</asp:ListItem>
        </asp:DropDownList></td>
  </tr>
  <tr>
    <td class='buffer'>Medical Issues:</td><td colspan="3" class='buffer'><asp:TextBox Width="100%" ID="MedicalIssuesTextBox1" runat="server"></asp:TextBox></td>
  </tr>
  <tr><td></td><td></td><td>
      &nbsp;</td><td align="right">
          <asp:Button ID="CancelButton" runat="server" 
          Text="Cancel " onclick="CancelButton_Click" /> <asp:Button ID="SaveButton" runat="server" 
          Text="Save Player" onclick="SaveButton_Click" /></td></tr>

  <tr><td colspan="4"><tr><td colspan="4"> <asp:Label ID="ValidateLabel" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label></td></tr></td></tr>    
</table>
</div>


</asp:Content>
