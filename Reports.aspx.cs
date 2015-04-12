using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


namespace OnlineReg
{
    public partial class Reports : System.Web.UI.Page
    {
        RegMember _member = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            CommonFunctions cf = new CommonFunctions();
            _member = cf.GetMemberSetup(this);

            ReportListPlaceHolder.Visible = false;
            ExcelPlaceHolder.Visible = false;
            PaidRepeater.Visible = false;
           

            if (_member != null)
            {
                if (Convert.ToBoolean(_member.IsAdmin))
                {
                    ReportListPlaceHolder.Visible = true;
                    

                    
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

                vMemberPaid myMember = (vMemberPaid)e.Item.DataItem;

                if (myMember.MoneyPaid == null)
                {
                    Label myLabel = (Label)e.Item.FindControl("MoneyPaidLabel");
                    myLabel.Text = "Not Paid";
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
           

        }


        protected void ExportButton_Click(object sender, EventArgs e)
        {
            DBCommon.ExportTableData(DBCommon.ToDataTable<vMemberPaid>(DBCommon.GetMembersPaid()), "MembersPaidReport", Response);

        }

        protected void PaidLinkButton_Click(object sender, EventArgs e)
        {

            if (Convert.ToBoolean(_member.IsAdmin))
            {

                PaidRepeater.Visible = true;
                ExcelPlaceHolder.Visible = true;
                ReportListPlaceHolder.Visible = false;

                ReportLabel.Text = "Paid Status Report";

                using (MemberDataDataContext db = new MemberDataDataContext())
                {
                    PaidRepeater.DataSource = DBCommon.GetMembersPaid();
                    PaidRepeater.DataBind();

                }
            }
        }

        protected void PlayerReportLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgeReport.aspx");
        }

        protected void EverythingReportLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("EverythingReport.aspx");
            
        }

        protected void RisingStarLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("RisingStarReport.aspx");
        }

        protected void FallBall_Click(object sender, EventArgs e)
        {
            Response.Redirect("FallBallReport.aspx");
            
        }

        protected void NotPaidLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("NotPaidReport.aspx");
        }

        protected void NotPaidLastYearButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("NotPaidSignedUpLastYearReport.aspx");
        }
    }
}