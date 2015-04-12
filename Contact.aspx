<%@ Page Title="" Language="C#" MasterPageFile="~/Reg.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="OnlineReg.Contact" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
<div>
    <div id="content_sec">
      <h1>Contact</h1>
      <div class="banner">
        <div class="left">
          <div class="banner_left">
            <h3 class="title"><%=TeamName %></h3>
            <p><%=TeamDesc%></p>
           
            <img src="content/<%=TeamPic %>"" class="banner_image"></div>
          <div class="clear"></div>
        </div>
        <div class="banner_right">
          <p class="headline"><%=TeamContactInfo %><br /><br /> Email: <asp:Label ID="EmailLabel" ForeColor="Black" Font-Bold="true" runat="server" Text=""></asp:Label></p>
          
          <br />
          <br />
        </div>
      </div>
    </div>
  </div>
</asp:Content>
