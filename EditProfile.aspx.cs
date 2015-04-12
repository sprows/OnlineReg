using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineReg
{
    public partial class EditProfile : System.Web.UI.Page
    {
        RegMember _member = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            CommonFunctions cf = new CommonFunctions();
            _member = cf.GetMemberSetup(this);

            if (_member != null)
            {

                //Load
                if (!Page.IsPostBack)
                {
                    LoadMember(_member);
                    LoadPlayers(_member);
                    ClearValidation();
                }

                if (Convert.ToBoolean(_member.IsAdmin))
                {

                }
                else
                {//Not Admin


                }
            }
        }

        private void LoadPlayers(RegMember mem)
        {
            PlayerRepeater.DataSource = DBCommon.LoadPlayers(mem.MemberID);
            PlayerRepeater.DataBind();

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

            }

        }

        public void R1_ItemCommand(Object Sender, RepeaterCommandEventArgs e)
        {

            string PlayerID = e.CommandArgument.ToString();

            if (e.CommandName == "Edit")
            {
                Response.Redirect("EditPlayer.aspx?id=" + PlayerID);

            }
            else if (e.CommandName == "Delete")
            {
                DBCommon.DeletePlayer(Convert.ToDecimal(PlayerID));
                Response.Redirect("EditProfile.aspx");
            }
    
        }

       
        private void LoadMember(RegMember mem)
        {

            //Main Detail
            FamilyDrPhoneTextBox.Text = mem.DoctorPhone;
            FamilyDrTextBox.Text = mem.FamilyDoctor;

            MothersPhoneTextBox.Text = mem.Parent1Phone;
            MothersEmailTextBox.Text = mem.Parent1Email;
            MothersFirstNameTextBox.Text = mem.Parent1FirstName;
            MothersLastNameTextBox.Text = mem.Parent1LastName;
            MothersOccupation.Text = mem.Parent1Occupation;

            FathersPhoneTextBox.Text = mem.Parent2Phone;
            FathersEmailTextBox.Text = mem.Parent2Email;
            FathersFirstNameTextBox.Text = mem.Parent2FirstName;
            FathersLastNameTextBox.Text = mem.Parent2LastName;
            FathersOccupation.Text = mem.Parent2Occupation;

            //Participations
            //Parent 1
            List<RegParticipation> part1 = DBCommon.LoadParticipations(mem.MemberID, 1);
            LoadParticipation(part1, 1);

            //Parent 2
            List<RegParticipation> part2 = DBCommon.LoadParticipations(mem.MemberID, 2);
            LoadParticipation(part2, 2);

        }

        private void LoadParticipation(List<RegParticipation> part, decimal ParentID)
        {
            foreach (RegParticipation p in part)
            {
                switch (Convert.ToInt32(p.ActivityID))
                {
                    case 1:
                        if (ParentID == 1)
                        {
                            MSponsorshipSignCB.Checked = true;
                        }
                        else
                        {
                            DSponsorshipSignCB.Checked = true;
                        }
                        break;
                    case 2:
                        if (ParentID == 1)
                        {
                            MSponsorshipTeamCB.Checked = true;
                        }
                        else
                        {
                            DSponsorshipTeamCB.Checked = true;
                        }
                        break;
                    case 3:
                        if (ParentID == 1)
                        {
                            MFieldMaintenanceCB.Checked = true;
                        }
                        else
                        {
                            DFieldMaintenanceCB.Checked = true;
                        }
                        break;
                    case 4:
                        if (ParentID == 1)
                        {
                            MOpeningClosingDayCB.Checked = true;
                        }
                        else
                        {
                            DOpeningClosingDayCB.Checked = true;
                        }
                        break;
                    case 5:
                        if (ParentID == 1)
                        {
                            MAMLLTournamentsCB.Checked = true;
                        }
                        else
                        {
                            DAMLLTournamentsCB.Checked = true;
                        }
                        break;
                    case 6:
                        if (ParentID == 1)
                        {
                            MTeamParentCB.Checked = true;
                        }
                        else
                        {
                            DTeamParentCB.Checked = true;
                        }

                        break;
                    case 7:
                        if (ParentID == 1)
                        {
                            MFundRaising.Checked = true;
                        }
                        else
                        {
                            DFundRaising.Checked = true;
                        }
                        break;
                    case 8:
                        if (ParentID == 1)
                        {
                            MCoachingCB.Checked = true;
                        }
                        else
                        {
                            DCoachingCB.Checked = true;
                        }

                        break;

                    default:
                        break;
                }

            }
        }

        private void ClearValidation()
        {
            //ValidateLabel.Text = "";
            //ValidateLabel.Visible = false;

            MothersFirstNameValidate.Visible = false;
            MothersLastNameValidate.Visible = false;
            MothersEmailValidate.Visible = false;
            MothersPhoneValidate.Visible = false;

            FathersFirstNameValidate.Visible = false;
            FathersLastNameValidate.Visible = false;
            FathersEmailValidate.Visible = false;
            FathersPhoneValidate.Visible = false;

        }

        protected void AddPlayerButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditPlayer.aspx?id=" + _member.MemberID.ToString() + "|");
        }

        protected void SaveProfile_Click(object sender, EventArgs e)
        {
            DBCommon.SaveMember(_member.MemberID, FamilyDrPhoneTextBox.Text, FamilyDrTextBox.Text, MothersPhoneTextBox.Text, MothersEmailTextBox.Text, MothersFirstNameTextBox.Text, MothersLastNameTextBox.Text, MothersOccupation.Text, FathersPhoneTextBox.Text, FathersEmailTextBox.Text, FathersFirstNameTextBox.Text, FathersLastNameTextBox.Text, FathersOccupation.Text);
            SaveParticipations(_member.MemberID);
        }

        private void SaveParticipations(decimal memberid)
        {
            //Get rid of all of them - Parent1
            DBCommon.DeleteParticipations(1, memberid);

            //Get rid of all of them - Parent2
            DBCommon.DeleteParticipations(2, memberid);

            //Add them
            AddParticipation(1, MSponsorshipSignCB, memberid, 1);
            AddParticipation(1, MSponsorshipTeamCB, memberid, 2);
            AddParticipation(1, MFieldMaintenanceCB, memberid, 3);
            AddParticipation(1, MOpeningClosingDayCB, memberid, 4);
            AddParticipation(1, MAMLLTournamentsCB, memberid, 5);
            AddParticipation(1, MTeamParentCB, memberid, 6);
            AddParticipation(1, MFundRaising, memberid, 7);
            AddParticipation(1, MCoachingCB, memberid, 8);

            AddParticipation(2, DSponsorshipSignCB, memberid, 1);
            AddParticipation(2, DSponsorshipTeamCB, memberid, 2);
            AddParticipation(2, DFieldMaintenanceCB, memberid, 3);
            AddParticipation(2, DOpeningClosingDayCB, memberid, 4);
            AddParticipation(2, DAMLLTournamentsCB, memberid, 5);
            AddParticipation(2, DTeamParentCB, memberid, 6);
            AddParticipation(2, DFundRaising, memberid, 7);
            AddParticipation(2, DCoachingCB, memberid, 8);


        }

        private void AddParticipation(decimal parentid, CheckBox cb, decimal memberid, decimal partid)
        {
            if (cb.Checked)
            {
                DBCommon.InsertParticipation(memberid, partid, parentid);
            }

        }

        protected void RegistrationButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListEvents.aspx");

        }


    }
}