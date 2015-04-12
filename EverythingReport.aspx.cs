using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineReg
{
    public partial class EverythingReport : System.Web.UI.Page
    {
        RegMember _member = null;

        protected void Page_Load(object sender, EventArgs e)
        {

            PlayerRepeater.Visible = false;
            ExcelPlaceHolder.Visible = false;

            CommonFunctions cf = new CommonFunctions();
            _member = cf.GetMemberSetup(this);

            if (_member != null)
            {
                if (Convert.ToBoolean(_member.IsAdmin))
                {
                    if (!Page.IsPostBack)
                    {
                        DateTime cutoffdate = Convert.ToDateTime(((Reg)Page.Master)._org.CutOffDate);
                    }

                }
                else
                {
                    AgeLabel.Visible = false;
                    AgeDropDownList.Visible = false;
                    RunReportButton.Visible = false;

                }
            }
            else
            {
                AgeLabel.Visible = false;
                AgeDropDownList.Visible = false;
                RunReportButton.Visible = false;

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

            }

        }

        public void R1_ItemCommand(Object Sender, RepeaterCommandEventArgs e)
        {

        }


        protected void ExportButton_Click(object sender, EventArgs e)
        {
            string theAge = "";

            if (AgeDropDownList.SelectedItem != null)
            {
                theAge = AgeDropDownList.SelectedItem.ToString();
            }

           // DBCommon.ExportTableData(DBCommon.ToDataTable<vEverythingReport>(DBCommon.GetEverythingReport(theAge)), theAge.ToString() + "EverythingReport.xls", Response);
            DBCommon.ExportTableData(DBCommon.ToDataTable<GetEverythingDataResult>(DBCommon.GetEverythingReportSP(theAge)), theAge.ToString() + "EverythingReport", Response);

        }

        protected void RunReportButton_Click(object sender, EventArgs e)
        {

            if (_member != null)
            {
                if (Convert.ToBoolean(_member.IsAdmin))
                {

                    PlayerRepeater.Visible = true;
                    ExcelPlaceHolder.Visible = true;

                   string theAge = "";

                    if (AgeDropDownList.SelectedItem != null)
                    {
                        theAge = AgeDropDownList.SelectedItem.ToString();
                    }


                    PlayerRepeater.DataSource = DBCommon.GetEverythingReportSP(theAge);  //DBCommon.GetEverythingReport(theAge);
                    PlayerRepeater.DataBind();

                }
            }
        }

    }
}