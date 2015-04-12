using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineReg
{
    public partial class Contact : System.Web.UI.Page
    {
        public string TeamPic = "";
        public string TeamName = "";
        public string TeamDesc = "";
        public string TeamContactInfo = "";

        RegMember _member = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            TeamPic = ((Reg)Page.Master)._org.TeamPic;
            TeamName = ((Reg)Page.Master)._org.TeamName;
            TeamDesc = ((Reg)Page.Master)._org.TeamDesc;
            TeamContactInfo = ((Reg)Page.Master)._org.TeamContactInfo;

            EmailLabel.Text = ((Reg)Page.Master)._org.TeamContactEmail;

            CommonFunctions cf = new CommonFunctions();
            _member = cf.GetMemberSetup(this);
        }
    }
}