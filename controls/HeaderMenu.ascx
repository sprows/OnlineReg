<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HeaderMenu.ascx.cs" Inherits="OnlineReg.controls.HeaderMenu" %>
<div id="masthead">
    <div class="inner">
      <div class="logo_box"><a href="main.aspx"><img src="content/<%=HeaderBannerPic %>" alt="" class="logo" /></a></div>
      <div class="slogan">
        <h4><%=TeamHeaderName%>
          </h4>
      </div>
      <div class="clear"></div>
      <div class="navigation">
          <ul>
            <li><a href="main.aspx">Home</a></li>
             <asp:PlaceHolder ID="ProfilePlaceHolder" runat="server">
                <li><asp:LinkButton ID="ProfileLinkButton" runat="server" onclick="ProfileLinkButton_Click">My Profile</asp:LinkButton></li></asp:PlaceHolder>
                <asp:PlaceHolder ID="PurchaseHistoryHolder" runat="server"><li><asp:LinkButton ID="PurchaseHistoryButton" runat="server" 
                  onclick="PurchaseHistoryButton_Click">Purchase History</asp:LinkButton></li></asp:PlaceHolder>
                  <asp:PlaceHolder ID="ContactHolder" runat="server"><li><asp:LinkButton ID="ContactButton" runat="server" onclick="ContactButton_Click">Contact</asp:LinkButton></li></asp:PlaceHolder>
                 <asp:PlaceHolder ID="ManageEventsPlaceHolder" runat="server"><li><asp:LinkButton ID="ManageEventsLinkButton" runat="server" 
                         onclick="ManageEventsLinkButton_Click">Admin Events</asp:LinkButton></li></asp:PlaceHolder>
                <asp:PlaceHolder ID="ManagePlayersPlaceHolder" runat="server"><li><asp:LinkButton ID="ManagePlayersLinkButton" runat="server" 
                        onclick="ManagePlayersLinkButton_Click" >Admin Players</asp:LinkButton></li></asp:PlaceHolder>
                 <asp:PlaceHolder ID="ReportsPlaceHolder" runat="server"><li><asp:LinkButton ID="ReportsLinkButton" runat="server" 
                         onclick="ReportsLinkButton_Click">Reports</asp:LinkButton></li></asp:PlaceHolder>
                 <asp:PlaceHolder ID="LogoutPlaceHolder" runat="server">
                <li><asp:LinkButton ID="LogOut" runat="server" onclick="LogOut_Click">Log Out</asp:LinkButton></li></asp:PlaceHolder>

          </ul>
          <div style="width:900px;" align="right"><asp:Literal ID="EmailLiteral" runat="server"></asp:Literal></div>
      </div>
    </div>
  </div>