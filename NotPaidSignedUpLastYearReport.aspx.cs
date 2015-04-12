using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineReg
{
    public partial class NotPaidSignedUpLastYearReport : System.Web.UI.Page
    {
        RegMember _member = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            CommonFunctions cf = new CommonFunctions();
            _member = cf.GetMemberSetup(this);

            if (_member != null)
            {
                if (Convert.ToBoolean(_member.IsAdmin))
                {
                    PaidRepeater.DataSource = DBCommon.NotGetMembersPaidLastYear();
                    PaidRepeater.DataBind();

                    PaidRepeater.Visible = true;
                    PaidRepeater.Visible = true;
                }

            }

        }

        protected void ExportButton_Click(object sender, EventArgs e)
        {
            DBCommon.ExportTableData(DBCommon.ToDataTable<vNotMemberPaidLastYear>(DBCommon.NotGetMembersPaidLastYear()), "NotMembersLastYearPaidReport", Response);

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


        }
    }
}