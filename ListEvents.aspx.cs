using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace OnlineReg
{
    public partial class ListEvents : System.Web.UI.Page
    {
        List<RegEvent> _myevents = null;
        List<RegOrder> _myOrders = null;
        RegMember _member = null;

        protected void Page_Load(object sender, EventArgs e)
        {

          
            AgeLabel.Text = ((Reg)Page.Master)._org.TeamMessage;

                CommonFunctions cf = new CommonFunctions();
                _member = cf.GetMemberSetup(this);

                SaveButton.Visible = false;

                if (_member != null)
                {

                    if (Convert.ToBoolean(_member.IsAdmin))
                    {
                        if (Request.QueryString["memid"] != null)
                        {
                            //Load new Member
                            _member = DBCommon.GetMember(Convert.ToDecimal(Request.QueryString["memid"]));
                            MessageLabel.Text = "Edit Information for ";
                            NameLabel.Text = _member.Parent1FirstName + " " + _member.Parent1LastName;
                            PurchaseButton.Visible = false;
                            SaveButton.Visible = true;

                            AdminLabel.Text = "yep";

                        }
                    }

                    //Check for DetailedEventCookie
                    //If exists then get eventid and send them to DetailEventpage.aspx?id=EventID
                    //Else just continue on to the next code below


                    //Just for Rising Sun Summer Session
                    //if (Request.QueryString.Count == 0)
                    //{
                    //    Response.Redirect("Summer.aspx");
                            
                    //}

                    _myevents = DBCommon.GetEvents();
                    _myOrders = DBCommon.GetOrders(_member.MemberID);

                    LoadEvents();
                }
               
        }

        private void LoadEvents()
        {
            if (!Page.IsPostBack)
            {
                EventsRepeater.DataSource = _myevents;
                EventsRepeater.DataBind();
            }
        }

        protected void PurchaseButton_Click(object sender, EventArgs e)
        {
            List<EventItem> events = new List<EventItem>();
            string eventIDs = "";

            //List<RegEvent> theEvents = DBCommon.GetEvents();

            for (int i = 0; i < EventsRepeater.Items.Count; i++)
            {
                if (((CheckBox)EventsRepeater.Items[i].FindControl("ChBox")).Checked)
                {
                    eventIDs = eventIDs + ((HiddenField)EventsRepeater.Items[i].FindControl("HiddenEventID")).Value + ",";
                }
            }

            if (eventIDs.Length > 0)
            {
                eventIDs = eventIDs.TrimEnd(',');
            }

            if (eventIDs.Length > 0)
            {
                Response.Redirect("Confirmation.aspx?pids=" + eventIDs);
            }
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < EventsRepeater.Items.Count; i++)
            {

                EventItem eItem = new EventItem();
                eItem.EventID = ((HiddenField)EventsRepeater.Items[i].FindControl("HiddenEventID")).Value;

                RegOrder theOrder = null;
                theOrder = _myOrders.SingleOrDefault(p => p.EventID == Convert.ToDecimal(eItem.EventID));

                if (((CheckBox)EventsRepeater.Items[i].FindControl("ChBox")).Checked)
                {
            
                    if (theOrder != null)
                    {
                        //Already checked .. Leave it alone
                    }
                    else
                    {
                        //Newly checked ... Insert It with a MANUAL flag
                        DBCommon.InsertOrder(_member.MemberID, Convert.ToDecimal(eItem.EventID), "MANUAL");
                    }
                }
                else //Not checked or Unchecked
                {

                    if (theOrder != null)
                    {
                        //This is being unchecked .. Delete it
                        DBCommon.DeleteOrder(theOrder.OrderID);
                    }
                    else
                    {
                        //Nothing is happening ... leave it alone
                    }

                }
            }

            Response.Redirect("ManagePlayers.aspx");

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

                //Do we have any Orders for this event? 
                if (_myOrders.Any(c => c.EventID.ToString() == ((HiddenField)e.Item.FindControl("HiddenEventID")).Value))
                {
                    CheckBox cb = (CheckBox)e.Item.FindControl("ChBox");

                    if (AdminLabel.Text == "yep")
                    {
                        cb.Checked = true;
                    }
                    else
                    {
                        cb.Enabled = false;
                        cb.Text = " Already Purchased";

                    }
                    

                    //cb.Checked = true;
                }

                //Add $$$
                Label PriceLabel = (Label)e.Item.FindControl("EventPrice");
                PriceLabel.Text = "$" + PriceLabel.Text;

                //Multiple Items to a cart
                //http://stackoverflow.com/questions/3308898/paying-for-multiple-items-at-once-via-paypal

                //PayPal variables
                //https://cms.paypal.com/mx/cgi-bin/?cmd=_render-content&content_ID=developer/e_howto_html_Appx_websitestandard_htmlvariables

                //notify_url -- send IPN website as a parameter


            }

           
        }

       

        
    }
}