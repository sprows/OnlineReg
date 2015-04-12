using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineReg
{
    public partial class ManagePlayers : System.Web.UI.Page
    {
        RegMember _member = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            CommonFunctions cf = new CommonFunctions();
            _member = cf.GetMemberSetup(this);

            ManagePlayersRepeater.Visible = false;

            if (_member != null)
            {
                if (Convert.ToBoolean(_member.IsAdmin))
                {
                    ManagePlayersRepeater.Visible = true;

                    ManagePlayersRepeater.DataSource = DBCommon.GetAllMembers();
                    ManagePlayersRepeater.DataBind();
                }
            }
        }

        public void R1_ItemDataBound(Object Sender, RepeaterItemEventArgs e)
        {

            // This event is raised for the header, the footer, separators, and items.

            // Execute the following logic for Items and Alternating Items.
            if (e.Item.ItemType == ListItemType.Header)
            {
            }

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {

                RegMember myMember = (RegMember)e.Item.DataItem;

                LinkButton mylink = (LinkButton)e.Item.FindControl("MakeAdminLinkButton");

                if (Convert.ToBoolean(myMember.IsAdmin))
                {
                    mylink.Text = "[Remove Admin]";
                }
              
            }

        }

        public void R1_ItemCommand(Object Sender, RepeaterCommandEventArgs e)
        {

            string MemberID = e.CommandArgument.ToString();

            if (e.CommandName == "Edit")
            {
                Response.Redirect("Profile.aspx?memid=" + MemberID);

            }
            else if (e.CommandName == "Events")
            {
                Response.Redirect("ListEvents.aspx?memid=" + MemberID);
            }
            else if (e.CommandName == "Admin")
            {
                DBCommon.ToggleAdmin(Convert.ToDecimal(MemberID));

                //Rebind the grid
                ManagePlayersRepeater.DataSource = DBCommon.GetAllMembers();
                ManagePlayersRepeater.DataBind();
            }
            
        }

        protected void AddPlayerButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Profile.aspx?p=y");
        }
    }
}