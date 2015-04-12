using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineReg
{
    public partial class ManageEvents : System.Web.UI.Page
    {
        RegMember _member = null;
        List<RegEvent> _myevents = null;

        protected void Page_Load(object sender, EventArgs e)
        {
                CommonFunctions cf = new CommonFunctions();
                _member = cf.GetMemberSetup(this);

                ValidateLabel.Visible = false;
                ManageEventsRepeater.Visible = false;

                if (_member != null)
                {
                    if (Convert.ToBoolean(_member.IsAdmin))
                    {
                        ManageEventsRepeater.Visible = true;

                        _myevents = DBCommon.GetAllEvents();
                        ManageEventsRepeater.DataSource = _myevents;
                        ManageEventsRepeater.DataBind();
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

                RegEvent myevent = (RegEvent)e.Item.DataItem;

                Label status = (Label)e.Item.FindControl("StatusLabel");
                LinkButton mylink = (LinkButton)e.Item.FindControl("ToggleLinkButton");
                if (Convert.ToBoolean(myevent.Enabled))
                {
                    status.Text = "Active";
                    mylink.Text = "[Toggle OFF]";
                }
                else
                {
                    status.Text = "Disabled";
                    mylink.Text = "[Toggle ON]";
                }


                //Add $$$
                Label PriceLabel = (Label)e.Item.FindControl("EventPriceLabel");
                PriceLabel.Text = "$" + PriceLabel.Text;

                //Multiple Items to a cart
                //http://stackoverflow.com/questions/3308898/paying-for-multiple-items-at-once-via-paypal

                //PayPal variables
                //https://cms.paypal.com/mx/cgi-bin/?cmd=_render-content&content_ID=developer/e_howto_html_Appx_websitestandard_htmlvariables

                //notify_url -- send IPN website as a parameter

            }

        }

        public void R1_ItemCommand(Object Sender, RepeaterCommandEventArgs e)
        {

            string EventID = e.CommandArgument.ToString();

            DBCommon.ToggleEventStatus(Convert.ToDecimal(EventID));

            //Rebind the grid
            ManageEventsRepeater.DataSource = DBCommon.GetAllEvents();
            ManageEventsRepeater.DataBind();
  
        }

        // IsNumeric Function
        bool IsNumeric(object Expression)
        {
            // Variable to collect the Return value of the TryParse method.
            bool isNum;

            // Define variable to collect out parameter of the TryParse method. If the conversion fails, the out parameter is zero.
            double retNum;

            // The TryParse method converts a string in a specified style and culture-specific format to its double-precision floating point number equivalent.
            // The TryParse method does not generate an exception if the conversion fails. If the conversion passes, True is returned. If it does not, False is returned.
            isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }

        protected void AddEventButton_Click(object sender, EventArgs e)
        {
            if (IsNumeric(EventPriceTextBox.Text))
            {

                if (EventLabelTextBox.Text.Trim().Length > 0)
                {
                    DBCommon.InsertEvent(EventLabelTextBox.Text, EventPriceTextBox.Text);

                    EventLabelTextBox.Text = "";
                    EventPriceTextBox.Text = "";

                    //Rebind the grid
                    ManageEventsRepeater.DataSource = DBCommon.GetAllEvents();
                    ManageEventsRepeater.DataBind();

                }
                else
                {
                    ValidateLabel.Text = "The Name can not be blank.";
                    ValidateLabel.Visible = true;
                }

                
            }
            else
            {
                ValidateLabel.Text = "The Price has to be a number.";
                ValidateLabel.Visible = true;
            }
        }
    }
}