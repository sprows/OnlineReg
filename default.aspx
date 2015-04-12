<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="OnlineReg._default" %>
<%@ Register src="controls/Head.ascx" tagname="Header" tagprefix="uc1" %>
<%@ Register src="controls/HeaderMenu.ascx" tagname="HeaderMenu" tagprefix="uc2" %>
<%@ Register src="controls/footer.ascx" tagname="footer" tagprefix="uc3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" xmlns:fb="http://ogp.me/ns/fb#" xmlns:fb="https://www.facebook.com/2008/fbml">
<form id="form1" runat="server">
<uc1:Header ID="HeaderControl" runat="server" />
<body>
<div class="clear"></div>
<div class="clear"></div>
<div id="wrapper_sec">
<uc2:HeaderMenu ID="HeaderMenu" runat="server" />
<div>
    <div id="content_sec">
      <h1>Aston Middletown Little Leauge Online Registration</h1>
      <div class="banner">
        <div class="left">
          <div class="banner_left">
            <h3 class="title">Aston Middletown Little Leauge</h3>
            <p> Aston Middletown Little Leauge is a premier little league based in Aston township. Serving ballplayers in Aston and Middletown communities.  </p>
           
            <img src="content/AMLLTeam.jpg"" class="banner_image"></div>
          <div class="clear"></div>
        </div>
        <div class="banner_right">
          <p class="headline">Please Login or create your account</span></p>
           
          XXXXXXXXXX
          <br />
          <br />
        </div>
      </div>
    </div>
  </div>
  <div class="clear"></div>
  <uc3:footer ID="footer1" runat="server" />
</div>
</form>
</form>
</body>
</html>

