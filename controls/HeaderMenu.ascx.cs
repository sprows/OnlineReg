using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace OnlineReg.controls
{
    public partial class HeaderMenu : System.Web.UI.UserControl
    {
        public string HeaderBannerPic = "";
        public string TeamHeaderName = "";
      

        protected void Page_Load(object sender, EventArgs e)
        {
            EmailLiteral.Text = "";
            LogoutPlaceHolder.Visible = false;
            ProfilePlaceHolder.Visible = false;
            PurchaseHistoryHolder.Visible = false;
            ContactHolder.Visible = false;

            HeaderBannerPic = ((Reg)Page.Master)._org.HeaderBannerPic;
            TeamHeaderName = ((Reg)Page.Master)._org.TeamHeaderName;

        

            if (Page.User.Identity.IsAuthenticated)
            {
                EmailLiteral.Text = Page.User.Identity.Name;
                LogoutPlaceHolder.Visible = true;
                ProfilePlaceHolder.Visible = true;
                PurchaseHistoryHolder.Visible = true;
                ContactHolder.Visible = true;
              
            }
        }

        protected void LogOut_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            LogoutPlaceHolder.Visible = false;
            ProfilePlaceHolder.Visible = false;
            PurchaseHistoryHolder.Visible = false;
            
            EmailLiteral.Text = "";
            Response.Redirect("main.aspx");

        }

        protected void ProfileLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditProfile.aspx");
        }

        protected void ManageEventsLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageEvents.aspx");
        }

        protected void ManagePlayersLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManagePlayers.aspx");
        }

        public void DisplayAdmin()
        {
            ManageEventsPlaceHolder.Visible = true;
            ManagePlayersPlaceHolder.Visible = true;
            ReportsPlaceHolder.Visible = true;
        }

        public void TurnOffAdmin()
        {
            ManageEventsPlaceHolder.Visible = false;
            ManagePlayersPlaceHolder.Visible = false;
            ReportsPlaceHolder.Visible = false;
        }

        protected void PurchaseHistoryButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("PurchaseHistory.aspx");
        }

        protected void ContactButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Contact.aspx");
        }

        protected void ReportsLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Reports.aspx");

        }

       

    }
}