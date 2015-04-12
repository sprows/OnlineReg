using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineReg
{
    public partial class PurchaseHistory : System.Web.UI.Page
    {
        List<RegEvent> _myevents = null;
        List<RegOrder> _myOrders = null;
        RegMember _member = null;

        protected void Page_Load(object sender, EventArgs e)
        {
             CommonFunctions cf = new CommonFunctions();
            _member = cf.GetMemberSetup(this);

            if (_member != null)
            {

                _myevents = DBCommon.GetAllEvents();
                _myOrders = DBCommon.GetOrders(_member.MemberID);

                TheEvents.DataSource = _myOrders;
                TheEvents.DataBind();

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

                RegOrder myorder = (RegOrder)e.Item.DataItem;

                RegEvent myevent = (RegEvent)_myevents.SingleOrDefault(u => u.EventID == myorder.EventID);

                if (myevent != null)
                {
                    Label myEvent = (Label)e.Item.FindControl("EventLabel");
                    Label myPrice = (Label)e.Item.FindControl("EventPrice");
                    Label myDate = (Label)e.Item.FindControl("DatePurchasedLabel");

                    myEvent.Text = myevent.EventName;
                    myPrice.Text = "$" + myevent.EventPrice;
                    myDate.Text = Convert.ToDateTime(myorder.CreateDate).ToShortDateString();
                }

            }

            if (e.Item.ItemType == ListItemType.Footer)
            {
              
            }


        }
    }
}