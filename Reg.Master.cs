using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineReg
{
    public partial class Reg : System.Web.UI.MasterPage
    {
        public RegMember _member = null;
        public RegOrg _org = DBCommon.GetOrg();
        
       

        protected void Page_Load(object sender, EventArgs e)
        {
        
        }

        public void DisplayAdmin()
        {
            HeaderMenu.DisplayAdmin();
        }

        public void TurnOffAdmin()
        {
            HeaderMenu.TurnOffAdmin();
        }

    }
}