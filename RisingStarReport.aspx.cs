using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineReg
{
    public partial class RisingStarReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            RegMember _member = null;

            PlayerRepeater.Visible = false;
            ExcelPlaceHolder.Visible = false;

            CommonFunctions cf = new CommonFunctions();
            _member = cf.GetMemberSetup(this);

            if (_member != null)
            {
                if (Convert.ToBoolean(_member.IsAdmin))
                {
                    PlayerRepeater.DataSource = DBCommon.GetRisingStarView();
                    PlayerRepeater.DataBind();

                    PlayerRepeater.Visible = true;
                    ExcelPlaceHolder.Visible = true;
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

            }

        }

        public void R1_ItemCommand(Object Sender, RepeaterCommandEventArgs e)
        {

        }


        protected void ExportButton_Click(object sender, EventArgs e)
        {

            DBCommon.ExportTableData(DBCommon.ToDataTable<vRisingStarRegistration>(DBCommon.GetRisingStarView()), "RisingStarReport", Response);

        }
    }
}