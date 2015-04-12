using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Configuration;
using System.Text;
using System.Net;
using System.IO;

namespace OnlineReg
{
    public class CommonFunctions
    {

        public RegMember GetMemberSetup(Page mypage)
        {
            RegMember member = null;

            if (mypage.User.Identity.IsAuthenticated)
            {

                member = DBCommon.GetMember(mypage.User.Identity.Name);

                if (Convert.ToBoolean(member.IsAdmin))
                {
                    ((Reg)mypage.Master).DisplayAdmin();
                }
                else
                {
                    ((Reg)mypage.Master).TurnOffAdmin();
                }

            }
            else
            {
                ((Reg)mypage.Master).TurnOffAdmin();
            }

            return member;
        }

        public string GetPayPalURL(string OrgID, string MemberID, List<EventItem> events)
        {

            string PayPalURL = ConfigurationManager.AppSettings["PayPalURL"];
            string PayPalBusiness = ConfigurationManager.AppSettings["PayPalBusinessEmail"];
            string ImageBannerURL = "http://www.amllregistration.com/content/logo-BB.png";
            string ReturnURL = "http://www.amllregistration.com/ThankYou.aspx";
            string CancelURL = "http://www.amllregistration.com";
            string NotifyURL = "http://www.amllregistration.com/paypal/listener.aspx";
            //string QueryStrings = ConfigurationManager.AppSettings["PayPalURL"] + "?cmd=_xclick-subscriptions&business=" + ConfigurationManager.AppSettings["PayPalBusinessEmail"] + "&item_name=MySocialPromo&image_url=http://www.mysocialpromo.com/images/msp-logo.png&no_shipping=1&return=http://www.mysocialpromo.com/welcome.aspx&cancel_return=http://www.mysocialpromo.com";
            string QueryStrings = PayPalURL + "?cmd=_cart&upload=1&currency_code=US&business=" + PayPalBusiness + "&image_url=" + ImageBannerURL + "&no_shipping=1&return=" + ReturnURL + "&cancel_return=" + CancelURL + "&notify_url=" + NotifyURL;
            string eventstring = "*";
            int i = 1;
            foreach (EventItem e in events)
            {
                QueryStrings = QueryStrings + "&item_name_" + i + "=" + e.EventName + "&amount_" + i + "=" + e.EventPrice;
                eventstring = eventstring + e.EventID + "|";
                i = i + 1;
            }

            //TODO: Strip off last '|'
            if (eventstring.Length > 2)
            {
                eventstring = eventstring.TrimEnd('|');
            }


            QueryStrings = QueryStrings + "&no_note=1&custom=" + OrgID + "|" + MemberID + eventstring;

            //Test ProcessPurchase
            //DBCommon.ProcessPurchase(OrgID + "|" + MemberID + eventstring, "123");

            return QueryStrings;

        }

        public void SendWelcomeEmail(string UserName, string Password, string ToString)
        {

            StringBuilder HTMLEmail = new StringBuilder();

            HTMLEmail.Append("<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>");
            HTMLEmail.Append("<html xmlns='http://www.w3.org/1999/xhtml'>");
            HTMLEmail.Append("<head>");
            HTMLEmail.Append("<meta http-equiv='Content-Type' content='text/html; charset=UTF-8' />");
            HTMLEmail.Append("<title>Welcome to My Social Promo</title>");
            HTMLEmail.Append("</head>");
            HTMLEmail.Append("<body leftmargin='0' marginwidth='0' topmargin='0' marginheight='0' offset='0' style='-webkit-text-size-adjust: none;margin: 0;padding: 0;background-color: #ebebeb;width: 100% !important;'>");
            HTMLEmail.Append("<table width='660' border='0' align='center' cellpadding='0' cellspacing='30' style='margin:0 auto !important;'>");
            HTMLEmail.Append("  <tr>");
            HTMLEmail.Append("    <td><a href='http://www.amllregistration.com/main.aspx'><img src='http://www.amllregistration.com/content/amll.jpg' alt='AMLL' width='600' height='94' border='0' /></a></td>");
            HTMLEmail.Append("  </tr>");
            HTMLEmail.Append("  <tr>");
            HTMLEmail.Append("    <td><table width='600' border='0' cellspacing='0' cellpadding='30' bgcolor='#ffffff' style='background-color:#ffffff; font-family: Helvetica, Arial, sans-serif;");
            HTMLEmail.Append("	font-size: 13px; color: #333; line-height:150%;'>");
            HTMLEmail.Append("      <tr>");
            HTMLEmail.Append("        <td><p style='font-size:18px;'>Password Information</p>");
            HTMLEmail.Append("          <p> You have requested password information.  Please use the info below to log into the AMLL Registration site:</p>");
            HTMLEmail.Append("            <strong>Username: " + UserName + "<br />");
            HTMLEmail.Append("            Password: " + Password + "</strong></p>");
            HTMLEmail.Append("<p> Aston Middletown Little League Registration<br />");
            HTMLEmail.Append("<a href='http://www.amllregistration.com'>www.AMLLRegistration.com</a></p></td>");
            HTMLEmail.Append("      </tr>");
            HTMLEmail.Append("    </table></td>");
            HTMLEmail.Append("  </tr>");
            HTMLEmail.Append("</table>");
            HTMLEmail.Append("</body>");
            HTMLEmail.Append("</html>");

            SendEmail(ToString, "AMLL Password information", HTMLEmail.ToString());


        }

        public void SendEmail(string ToString, string Subject, string Body)
        {

          
            string serviceUri = "http://api.postmarkapp.com/email";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(serviceUri);
            request.Method = "POST";
            //request.ContentType = "application/json";
            request.Accept = "application/json";

            request.Headers.Add("X-Postmark-Server-Token", ConfigurationManager.AppSettings["EmailToken"]);

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                string json = "{From: 'info@amllregistration.com', To: '" + ToString + "', Subject: '" + Subject + "', HtmlBody: \"" + Body + "\"}";

                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();

            }

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            string foo = "";
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream);
                foo = reader.ReadToEnd();
            }


        }
    }
}