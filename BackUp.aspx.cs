using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineReg
{
    public partial class BackUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["s"] != null)
            {
                if (Request.QueryString["s"].ToString() == "tomrocks")
                {
                    DBCommon.BackUpTables();
                }
            }

        }
    }
}