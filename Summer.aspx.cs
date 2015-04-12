using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineReg
{
    public partial class Summer : System.Web.UI.Page
    {
        List<vEverythingReport> _summerPlayers = null;
        List<RegSpecEvent> _SpecialEvents = null;
        RegMember _member = null;

        protected void Page_Load(object sender, EventArgs e)
        {

            SummerPanel.Visible = false; //Turned off
            ErrorMessageLabel.Visible = false;

            CommonFunctions cf = new CommonFunctions();
            _member = cf.GetMemberSetup(this);

            if (_member != null)
            {
                //SummerPanel.Visible = true;
                //_SpecialEvents = DBCommon.GetPaidRisingStarSummerPlayers(_member.MemberID);
                //_summerPlayers = DBCommon.GetRisingStarSummerPlayers(_member.MemberID);

                //if (_summerPlayers.Count == 0)
                //{
                //    ErrorMessageLabel.Visible = true;
                //    SignUpButton.Visible = false;
                //    ErrorMessageLabel.Text = "You currently do not have any Players that are 5,6 or 7.";
                //}
                //else
                //{
                //    LoadEvents();
                //}

                return;


            }
            else
            {
                SummerPanel.Visible = false;
            }

            
        }

        private void LoadEvents()
        {
            if (!Page.IsPostBack)
            {
                PlayerRepeater.DataSource = _summerPlayers;
                PlayerRepeater.DataBind();
            }
        }

        public void R1_ItemDataBound(Object Sender, RepeaterItemEventArgs e)
        {

            // This event is raised for the header, the footer, separators, and items.

            // Execute the following logic for Items and Alternating Items.
            if (e.Item.ItemType == ListItemType.Header)
            {
            }
            else
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    //Do we have any Orders for this event?
                    if (_SpecialEvents != null)
                    {
                        if (_SpecialEvents.Any(c => c.PlayerID.ToString() == ((HiddenField)e.Item.FindControl("HiddenPlayerID")).Value))
                        {
                            CheckBox cb = (CheckBox)e.Item.FindControl("ChBox");

                            cb.Enabled = false;
                            cb.Text = " Already Purchased";
                        }
                    }

                }
            }


        }

        protected void SignUpButton_Click(object sender, EventArgs e)
        {
            string PayPalURL = "";

          
            CommonFunctions cf = new CommonFunctions();
            List<EventItem> myItems = null;

            myItems = GetSelectedPlayers();
            if (myItems.Count > 0)
            {
                //PayPalURL = cf.GetPayPalURL("SS", _member.MemberID.ToString(), myItems);
                PayPalURL = cf.GetPayPalURL("FB", _member.MemberID.ToString(), myItems);

                if (PayPalURL.Length > 0)
                {
                    Response.Redirect(PayPalURL);
                }

            }
           
        }

        private List<EventItem> GetSelectedPlayers()
        {
            List<EventItem> myEvents = new List<EventItem>();

            foreach (RepeaterItem ri in PlayerRepeater.Items)
            {
                CheckBox chk = (CheckBox)ri.FindControl("ChBox");

                if (chk.Checked)
                {
                    Label firstNameLabel = (Label)ri.FindControl("PlayerFirstName");
                    Label lastNameLabel = (Label)ri.FindControl("PlayerLastName");
                    HiddenField hd = (HiddenField)ri.FindControl("HiddenPlayerID");

                    EventItem myEvent = new EventItem();
                    myEvent.EventPrice = "60";
                    myEvent.EventName = "AMLL 2014 FallBall: " + firstNameLabel.Text + " " + lastNameLabel.Text;
                    myEvent.EventID = hd.Value;

                    myEvents.Add(myEvent);
                    
                }

            }

            return myEvents;
        }

        
    }
}