<%@ Page Title="" Language="C#" MasterPageFile="~/Reg.Master" AutoEventWireup="true" CodeBehind="EditProfile.aspx.cs" Inherits="OnlineReg.EditProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
 
 <div style="padding-left:40px">
 <p class="headline"><asp:Label ID="MessageLabel" runat="server" Text="Please review below and make sure your Player/Profile information is valid.  If everything is OK, Please continue to register for the 2015 AMLL season"></asp:Label> 
   <asp:Button ID="RegistrationButton" runat="server" 
         Text="Take me to Registration" onclick="RegistrationButton_Click" />
      </p>

 <asp:Repeater id="PlayerRepeater"  OnItemDataBound="R1_ItemDataBound"  OnItemCommand="R1_ItemCommand" runat="server" >
        <HeaderTemplate>
        <table border="0" cellpadding="2" cellspacing="2">
        <tr>
        <td></td>
        <%--<td><b>Age</b></td>--%>
        <td><b>First</b></td>
        <td><b>Last</b></td>
        <td><b>Sex</b></td>
        <td><b>BirthDate</b></td>
        <td><b>Edit</b></td>
        <td><b>Delete</b></td>
        </tr>
        </HeaderTemplate>

            <ItemTemplate>
            <tr>
             <td><asp:HiddenField runat="server" ID="HiddenMemberID" Value='<%# DataBinder.Eval(Container.DataItem, "MemberID") %>' />
             </td>
            <%-- <td><asp:Label ID="AgeLabel" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Age") %>'></asp:Label>  </td>--%>
             <td><asp:Label ID="FirstNameLabel" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PlayerFirstName") %>'></asp:Label>  </td>
            <td><asp:Label ID="LastNameLabel" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PlayerLastName") %>'></asp:Label>  </td>
            <td><asp:Label ID="SexLabel" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Sex") %>'></asp:Label>  </td>
             <td><asp:Label ID="BirthDate" runat="server" Text='<%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "BirthDate")).ToString("dd-MMM-yyyy") %>'></asp:Label>  </td>
             <td><asp:LinkButton ID="EditLinkButton" CssClass="HeaderStyle" CommandName="Edit" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "MemberID") + "|" + DataBinder.Eval(Container.DataItem, "PlayerID") %>' Text="[Edit]" runat="server" /></td>
             <td><asp:LinkButton ID="DeleteLinkButton" CssClass="HeaderStyle" OnClientClick='return confirm("Are you sure you want to delete this player?");' CommandName="Delete" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "PlayerID") %>' Text="[Delete]" runat="server" /></td>
            </tr>
            </ItemTemplate>
            <FooterTemplate>
            </table>
            </FooterTemplate>
   </asp:Repeater>
   <br />
   <asp:Button ID="AddPlayerButton" runat="server" Text="Add a new player"  onclick="AddPlayerButton_Click" />
      <br /><br /> 

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
  </table>
  <br />
  <asp:Button ID="SaveProfile" runat="server" Text="Save Profile" 
         onclick="SaveProfile_Click" />

</div>
</asp:Content>
