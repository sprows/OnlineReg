using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineReg
{
    public partial class ThankYou : System.Web.UI.Page
    {
        public string ThankYouMess = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            ThankYouMess = ((Reg)Page.Master)._org.ThankYouMessage;
        }
    }
}