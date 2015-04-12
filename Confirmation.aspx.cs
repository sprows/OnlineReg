using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace OnlineReg
{
    public partial class Confirmation : System.Web.UI.Page
    {
        RegMember _member = null;
        decimal TotalAmount = 0;
        public List<EventItem> events = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            CommonFunctions cf = new CommonFunctions();
            _member = cf.GetMemberSetup(this);
            ValidateLabel.Text = "";


            ChTerms1.Text = ((Reg)Page.Master)._org.TeamRestriction1;
            ChTerms2.Text = ((Reg)Page.Master)._org.TeamRestriction2;

            if (ChTerms1.Text.Length == 0)
            {
                //Mark it as checked and hide it
                ChTerms1.Visible = false;
                ChTerms1.Checked = true;
            }

            if (ChTerms2.Text.Length == 0)
            {
                //Mark it as checked and hide it
                ChTerms2.Visible = false;
                ChTerms2.Checked = true;
            }

            if (_member != null)
            {
                if (Request.QueryString["pids"] != null)
                {
                    //We have IDs
                    CreateSummarySection(Request.QueryString["pids"]);
                    KidsLabel.Text = "** You have entered in " +  DBCommon.GetPlayerCount(_member.MemberID) + " players. Please make sure this matches up with your purchases.";
                }
            }

        }

        private void CreateSummarySection(string PIDs)
        {
            events = new List<EventItem>();
            List<RegEvent> theEvents = DBCommon.GetEvents();

            string[] theEventsIDs = PIDs.Split(',');

            foreach (string eID in theEventsIDs)
            {
                    EventItem eItem = new EventItem();
                    eItem.EventID = eID;

                    RegEvent theEvent = null;
                    theEvent = theEvents.SingleOrDefault(p => p.EventID == Convert.ToDecimal(eItem.EventID));

                    if (theEvent != null)
                    {
                        eItem.EventName = Server.UrlEncode(theEvent.EventName);
                        eItem.EventPrice = theEvent.EventPrice;
                    }

                    events.Add(eItem);   
            }

            TheEvents.DataSource = events;
            TheEvents.DataBind();

            CommonFunctions cf = new CommonFunctions();
            PayPalLabel.Text = cf.GetPayPalURL(DBCommon.GetMyOrgID().ToString(), _member.MemberID.ToString(), events);
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

                EventItem myevent = (EventItem)e.Item.DataItem;

                Label myEvent = (Label)e.Item.FindControl("EventLabel");
                Label myPrice = (Label)e.Item.FindControl("EventPrice");
                HiddenField myEventID = (HiddenField)e.Item.FindControl("HiddenEventID");

                myEvent.Text = Server.UrlDecode(myevent.EventName);
                myPrice.Text = "$" + Server.UrlDecode(myevent.EventPrice);
                myEventID.Value = Server.UrlDecode(myevent.EventID.ToString());

                TotalAmount = TotalAmount + Convert.ToDecimal(myevent.EventPrice);
              
            }

           if (e.Item.ItemType == ListItemType.Footer)
           {
               Label myTotal = (Label)e.Item.FindControl("TotalLabel");
               myTotal.Text = "$" + TotalAmount.ToString();
           }


        }

        protected void PurchaseButton_Click(object sender, EventArgs e)
        {
            if (PayPalLabel.Text.Length > 0)
            {



                if (ChTerms1.Checked && ChTerms2.Checked)
                {
                    Response.Redirect(PayPalLabel.Text);
                }
                else
                {
                    ValidateLabel.Text = "You must check off the terms above before you may continue to purchase."; 
                }
            }
        }

    }


    
}