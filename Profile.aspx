<%@ Page Title="" Language="C#" MasterPageFile="~/Reg.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="OnlineReg.Profile" %>
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

        new JsDatePick({
            useMode: 2,
            target: "<%=BirthDateTextBox2.ClientID %>",
            dateFormat: "%d-%M-%Y"
        });

        new JsDatePick({
            useMode: 2,
            target: "<%=BirthDateTextBox3.ClientID %>",
            dateFormat: "%d-%M-%Y"
        });
    };
</script>

 <p class="headline"><asp:Label ID="MessageLabel" runat="server" Text="Please enter in your information"></asp:Label><asp:Label ID="NameLabel" ForeColor="Black" Font-Bold="true" runat="server" Text=""></asp:Label></p>
 
 <div style="padding-left:40px">  
 <table>
 <tr><td colspan="4" style="font-weight:bold;">Parent/Guardian #1</td></tr>
 <tr>
 <td class='buffer'>First Name:<asp:Label ID="MothersFirstNameValidate" runat="server" Text=" **" Font-Bold="true" ForeColor="Red"></asp:Label></td><td class='buffer'><asp:TextBox Width="100%" ID="MothersFirstNameTextBox" runat="server"></asp:TextBox></td>
 <td class='buffer'>Last Name:<asp:Label ID="MothersLastNameValidate" runat="server" Text=" **" Font-Bold="true" ForeColor="Red"></asp:Label></td><td class='buffer'><asp:TextBox Width="100%" ID="MothersLastNameTextBox" runat="server"></asp:TextBox></td>
 </tr>
 <tr>
 <td class='buffer'>Email:<asp:Label ID="MothersEmailValidate" runat="server" Text=" **" Font-Bold="true" ForeColor="Red"></asp:Label></td><td class='buffer'><asp:TextBox Width="100%" ID="MothersEmailTextBox" runat="server"></asp:TextBox></td>
 <td class='buffer'>Occupation:</td><td class='buffer'><asp:TextBox Width="100%" ID="MothersOccupation" runat="server"></asp:TextBox></td></tr>
 <tr>
 <td class='buffer'>Phone number:<asp:Label ID="MothersPhoneValidate" runat="server" Text=" **" Font-Bold="true" ForeColor="Red"></asp:Label></td><td><asp:TextBox ID="MothersPhoneTextBox" runat="server"></asp:TextBox></td>
 <td class='buffer'>Participation<br />Interest:</td>
 <td colspan="2">
     <table width="100%">
     <tr>
        <td class='buffer'><asp:CheckBox ID="MSponsorshipSignCB" CssClass="buffer" Text=" Sponsorships: Sign" runat="server" /></td>
        <td class='buffer'><asp:CheckBox ID="MAMLLTournamentsCB" CssClass="buffer" Text=" AMLL Tournaments" runat="server" /></td>
     </tr>
     <tr>
        <td class='buffer'><asp:CheckBox ID="MSponsorshipTeamCB" CssClass="buffer" Text=" Sponsorships: Team" runat="server" /></td>
        <td class='buffer'><asp:CheckBox ID="MTeamParentCB" CssClass="buffer" Text=" Team Parent" runat="server" /></td>
     </tr>
     <tr>
        <td class='buffer'><asp:CheckBox ID="MFieldMaintenanceCB" CssClass="buffer" Text=" Field Maintenance" runat="server" /></td>
        <td class='buffer'><asp:CheckBox ID="MFundRaising" CssClass="buffer" Text=" Baseball Olympics" runat="server" /></td>
     </tr>
     <tr>
        <td class='buffer'><asp:CheckBox ID="MOpeningClosingDayCB" CssClass="buffer" Text=" Opening/Closing Day" runat="server" /></td>
        <td class='buffer'><asp:CheckBox ID="MCoachingCB" CssClass="buffer" Text=" Coaching" runat="server" /></td>
     </tr>
     </table>
 </td>
 </tr>
 <tr><td colspan="4" style="font-weight:bold;">Parent/Guardian #2</td></tr>
 <tr>
 <td class='buffer'>First Name:<asp:Label ID="FathersFirstNameValidate" runat="server" Text=" **" Font-Bold="true" ForeColor="Red"></asp:Label></td><td class='buffer'><asp:TextBox Width="100%" ID="FathersFirstNameTextBox" runat="server"></asp:TextBox></td>
 <td class='buffer'>Last Name:<asp:Label ID="FathersLastNameValidate" runat="server" Text=" **" Font-Bold="true" ForeColor="Red"></asp:Label></td><td class='buffer'><asp:TextBox Width="100%" ID="FathersLastNameTextBox" runat="server"></asp:TextBox></td>
 </tr>
 <tr><td class='buffer'>Email:<asp:Label ID="FathersEmailValidate" runat="server" Text=" **" Font-Bold="true" ForeColor="Red"></asp:Label></td><td class='buffer'><asp:TextBox Width="100%" ID="FathersEmailTextBox" runat="server"></asp:TextBox></td>
    <td class='buffer'>Occupation:</td><td class='buffer'><asp:TextBox Width="100%" ID="FathersOccupation" runat="server"></asp:TextBox></td></tr>
 <tr>
 <td class='buffer'>Phone number:<asp:Label ID="FathersPhoneValidate" runat="server" Text=" **" Font-Bold="true" ForeColor="Red"></asp:Label></td><td><asp:TextBox Width="100%" ID="FathersPhoneTextBox" runat="server"></asp:TextBox></td>
 <td class='buffer'>Participation<br />Interest:</td>
 <td colspan="2">
     <table width="100%">
     <tr>
        <td class='buffer'><asp:CheckBox ID="DSponsorshipSignCB" CssClass="buffer" Text=" Sponsorships: Sign" runat="server" /></td>
        <td class='buffer'><asp:CheckBox ID="DAMLLTournamentsCB" CssClass="buffer" Text=" AMLL Tournaments" runat="server" /></td>
     </tr>
     <tr>
        <td class='buffer'><asp:CheckBox ID="DSponsorshipTeamCB" CssClass="buffer" Text=" Sponsorships: Team" runat="server" /></td>
        <td class='buffer'><asp:CheckBox ID="DTeamParentCB" CssClass="buffer" Text=" Team Parent" runat="server" /></td>
     </tr>
     <tr>
        <td class='buffer'><asp:CheckBox ID="DFieldMaintenanceCB" CssClass="buffer" Text=" Field Maintenance" runat="server" /></td>
        <td class='buffer'><asp:CheckBox ID="DFundRaising" CssClass="buffer" Text=" Baseball Olympics" runat="server" /></td>
     </tr>
     <tr>
        <td class='buffer'><asp:CheckBox ID="DOpeningClosingDayCB" CssClass="buffer" Text=" Opening/Closing Day" runat="server" /></td>
        <td class='buffer'><asp:CheckBox ID="DCoachingCB" CssClass="buffer" Text=" Coaching" runat="server" /></td>
     </tr>
     </table>
 </td>
 </tr>
  <tr><td colspan="4" style="font-weight:bold;">General Information</td></tr>
  <tr><td class='buffer'>Family Doctor:</td><td><asp:TextBox ID="FamilyDrTextBox" runat="server"></asp:TextBox></td>
      <td class='buffer'>Doctor Phone:</td><td><asp:TextBox Width="100%" ID="FamilyDrPhoneTextBox" runat="server"></asp:TextBox></td>
  </tr>
  <tr><td class='buffer'>Hospitalization Plan</td><td colspan="3"><asp:TextBox ID="HospitalizationTextBox" Width="100%" runat="server"></asp:TextBox></td>
  </tr>

  <tr><td colspan="4" style="font-weight:bold;"><br />Child 1</td></tr>
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
  
  <tr><td colspan="4" style="font-weight:bold;"><br />Child 2</td></tr>
  <tr>
    <td class='buffer'>First Name:<asp:Label ID="ChildFirstNameValidate2" runat="server" Text=" **" Font-Bold="true" ForeColor="Red"></asp:Label></td><td class='buffer'><asp:TextBox Width="100%" ID="ChildFirstNameTextBox2" runat="server"></asp:TextBox></td>
    <td class='buffer'>Last Name:<asp:Label ID="ChildLastNameValidate2" runat="server" Text=" **" Font-Bold="true" ForeColor="Red"></asp:Label></td><td class='buffer'><asp:TextBox Width="100%" ID="ChildLastNameTextBox2" runat="server"></asp:TextBox></td>
  </tr>
  <tr>
    <td class='buffer'>Street Address:<asp:Label ID="StreetAddressValidate2" runat="server" Text=" **" Font-Bold="true" ForeColor="Red"></asp:Label></td><td colspan= "3" class='buffer'><asp:TextBox Width="100%" ID="StreetAddressTextBox2" runat="server"></asp:TextBox></td>
  </tr>
   <tr>
     <td class='buffer'>City:<asp:Label ID="CityTextBoxValidate2" runat="server" Text=" **" Font-Bold="true" ForeColor="Red"></asp:Label></td>
     <td colspan="3">
      <table>
       <tr>
         <td><asp:TextBox Width="100%" ID="CityTextBox2" runat="server"></asp:TextBox></td>
         <td class='buffer'> State:<asp:Label ID="StateValidate2" runat="server" Text=" **" Font-Bold="true" ForeColor="Red"></asp:Label></td>
         <td class='buffer'><asp:TextBox Width="100%" ID="StateTextBox2" runat="server"></asp:TextBox></td>
         <td class='buffer'> Zip:<asp:Label ID="ZipTextValidate2" runat="server" Text=" **" Font-Bold="true" ForeColor="Red"></asp:Label></td>
         <td class='buffer'><asp:TextBox Width="100%" ID="ZipTextBox2" runat="server"></asp:TextBox>
       </tr>
     </table>
     </td>
  </tr>
   <tr>
    <td class='buffer'>BirthDate:<asp:Label ID="BirthDateValidate2" runat="server" Text=" **" Font-Bold="true" ForeColor="Red"></asp:Label></td><td class='buffer'><asp:TextBox Width="100%" ID="BirthDateTextBox2" runat="server"></asp:TextBox></td>
    <td class='buffer'>M/F:<asp:Label ID="SexValidate2" runat="server" Text=" **" Font-Bold="true" ForeColor="Red"></asp:Label></td><td class='buffer'>
        <asp:DropDownList ID="SexCombo2" runat="server">
           <asp:ListItem></asp:ListItem>
           <asp:ListItem>M</asp:ListItem>
           <asp:ListItem>F</asp:ListItem>
        </asp:DropDownList>
        </td>
  </tr>
  <tr>
    <td class='buffer'>Child Plays Other</br>Spring Sport?:</td><td class='buffer'><asp:DropDownList ID="OtherSpringSportCombo2" runat="server">
           <asp:ListItem></asp:ListItem>
           <asp:ListItem>Y</asp:ListItem>
           <asp:ListItem>N</asp:ListItem>
        </asp:DropDownList></td>
    <td class='buffer'>Is AMLL Primary</br>Commitment?:</td><td class='buffer'> <asp:DropDownList ID="PrimaryCommitmentCombo2" runat="server">
            <asp:ListItem></asp:ListItem>
           <asp:ListItem>Y</asp:ListItem>
           <asp:ListItem>N</asp:ListItem>
        </asp:DropDownList></td>
  </tr>
  <tr>
    <td class='buffer'>Medical Issues:</td><td colspan="3" class='buffer'><asp:TextBox Width="100%" ID="MedicalIssuesTextBox2" runat="server"></asp:TextBox></td>
  </tr>
    <tr><td colspan="4" style="font-weight:bold;"><br />Child 3</td></tr>
  <tr>
    <td class='buffer'>First Name:<asp:Label ID="ChildFirstNameValidate3" runat="server" Text=" **" Font-Bold="true" ForeColor="Red"></asp:Label></td><td class='buffer'><asp:TextBox Width="100%" ID="ChildFirstNameTextBox3" runat="server"></asp:TextBox></td>
    <td class='buffer'>Last Name:<asp:Label ID="ChildLastNameValidate3" runat="server" Text=" **" Font-Bold="true" ForeColor="Red"></asp:Label></td><td class='buffer'><asp:TextBox Width="100%" ID="ChildLastNameTextBox3" runat="server"></asp:TextBox></td>
  </tr>
  <tr>
    <td class='buffer'>Street Address:<asp:Label ID="StreetAddressValidate3" runat="server" Text=" **" Font-Bold="true" ForeColor="Red"></asp:Label></td><td colspan= "3" class='buffer'><asp:TextBox Width="100%" ID="StreetAddressTextBox3" runat="server"></asp:TextBox></td>
  </tr>
   <tr>
     <td class='buffer'>City:<asp:Label ID="CityTextBoxValidate3" runat="server" Text=" **" Font-Bold="true" ForeColor="Red"></asp:Label></td>
     <td colspan="3">
      <table>
       <tr>
         <td><asp:TextBox Width="100%" ID="CityTextBox3" runat="server"></asp:TextBox></td>
         <td class='buffer'> State:<asp:Label ID="StateValidate3" runat="server" Text=" **" Font-Bold="true" ForeColor="Red"></asp:Label></td>
         <td class='buffer'><asp:TextBox Width="100%" ID="StateTextBox3" runat="server"></asp:TextBox></td>
         <td class='buffer'> Zip:<asp:Label ID="ZipTextValidate3" runat="server" Text=" **" Font-Bold="true" ForeColor="Red"></asp:Label></td>
         <td class='buffer'><asp:TextBox Width="100%" ID="ZipTextBox3" runat="server"></asp:TextBox>
       </tr>
     </table>
     </td>
  </tr>
   <tr>
    <td class='buffer'>BirthDate:<asp:Label ID="BirthDateValidate3" runat="server" Text=" **" Font-Bold="true" ForeColor="Red"></asp:Label></td><td class='buffer'><asp:TextBox Width="100%" ID="BirthDateTextBox3" runat="server"></asp:TextBox></td>
    <td class='buffer'>M/F:<asp:Label ID="SexValidate3" runat="server" Text=" **" Font-Bold="true" ForeColor="Red"></asp:Label></td><td class='buffer'>
        <asp:DropDownList ID="SexCombo3" runat="server">
           <asp:ListItem></asp:ListItem>
           <asp:ListItem>M</asp:ListItem>
           <asp:ListItem>F</asp:ListItem>
        </asp:DropDownList>
        </td>
  </tr>
  <tr>
    <td class='buffer'>Child Plays Other</br>Spring Sport?:</td><td class='buffer'><asp:DropDownList ID="OtherSpringSportCombo3" runat="server">
           <asp:ListItem></asp:ListItem>
           <asp:ListItem>Y</asp:ListItem>
           <asp:ListItem>N</asp:ListItem>
        </asp:DropDownList></td>
    <td class='buffer'>Is AMLL Primary</br>Commitment?:</td><td class='buffer'> <asp:DropDownList ID="PrimaryCommitmentCombo3" runat="server">
            <asp:ListItem></asp:ListItem>
           <asp:ListItem>Y</asp:ListItem>
           <asp:ListItem>N</asp:ListItem>
        </asp:DropDownList></td>
  </tr>
  <tr>
    <td class='buffer'>Medical Issues:</td><td colspan="3" class='buffer'><asp:TextBox Width="100%" ID="MedicalIssuesTextBox3" runat="server"></asp:TextBox></td>
  </tr>
  <tr><td  colspan="3">
     
      </td><td align="right"><asp:Button ID="SaveButton" 
          runat="server" Text="Save" onclick="SaveButton_Click" 
          /></td></tr>
  <tr><td colspan="4"> <asp:Label ID="ValidateLabel" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label></td></tr>
     
 </table>
 </div>
 <asp:Label ID="MemberID" Visible="false" runat="server"></asp:Label>
 <asp:Label ID="Player1" Visible="false" runat="server"></asp:Label>
 <asp:Label ID="Player2" Visible="false" runat="server"></asp:Label>
 <asp:Label ID="Player3" Visible="false" runat="server"></asp:Label>
 <asp:Label ID="AdminLabel" Visible="false" runat="server"></asp:Label>
</asp:Content>
