using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineReg
{
    public partial class rd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["url"] != null)
            {

                string URL = Request.QueryString["url"].ToString();
                string OrdID = DBCommon.GetOrgID(URL);

                //if (OrdID.Length == 0)
               // {
                    //Look in Event table
                    //Get EventID and set special cookie for detailed event
                    // ---- DetailedEventCookie == EventID
                    //Get Org ID from Event and set it to RegOnline cookie
                    // ---- RegOnlineCookie == OrgID (same as below)
                    //Redirect to Main.aspx
               // }
               // else
               // {
                    HttpCookie newCookie = new HttpCookie("RegOnline");
                    newCookie.Expires = DateTime.MinValue;
                    newCookie.Value = OrdID;

                    Response.Cookies.Add(newCookie);
                    Response.Redirect("main.aspx");

               // }

            }
        }
    }
}