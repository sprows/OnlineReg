using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace OnlineReg
{
    public partial class Profile : System.Web.UI.Page
    {
        RegMember _member = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.MaintainScrollPositionOnPostBack = true;
            ClearValidation();

            //Load Profile
            //if (Page.User.Identity.IsAuthenticated)
            //{
                if (!Page.IsPostBack)
                {
                    CommonFunctions cf = new CommonFunctions();
                    _member = cf.GetMemberSetup(this);

                    if (_member != null)
                    {
                        if (Convert.ToBoolean(_member.IsAdmin))
                        {
                            AdminLabel.Text = "yep";

                            if (Request.QueryString["memid"] != null)
                            {
                                //Load new Member
                                _member = DBCommon.GetMember(Convert.ToDecimal(Request.QueryString["memid"]));
                                MessageLabel.Text = "Edit Information for ";
                                NameLabel.Text = _member.Parent1FirstName + " " + _member.Parent1LastName;


                            }
                            else if (Request.QueryString["p"] != null)
                            {
                                MemberID.Text = DBCommon.CreateAccount(1, "PAPER", "PAPER");
                                _member = DBCommon.GetMember(Convert.ToDecimal(MemberID.Text));
                                LoadMember(_member);

                            }

                        }

                        MemberID.Text = _member.MemberID.ToString();
                        LoadMember(_member);

                    }
                    else
                    { 
                        //Not authenticated -- lets bring them back to the logon page
                        Response.Redirect("main.aspx");


                    }
                }
            //}

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

            //Children
            List<RegPlayer> players = DBCommon.LoadPlayers(mem.MemberID);
            SetUpPlayers(players);

        }

        private void SetUpPlayers(List<RegPlayer> players)
        {
            int i = 1;
            foreach (RegPlayer play in players)
            {
                if (i == 1)
                {
                    ChildFirstNameTextBox1.Text = play.PlayerFirstName;
                    ChildLastNameTextBox1.Text = play.PlayerLastName;
                    StreetAddressTextBox1.Text = play.StreetAddress;
                    CityTextBox1.Text = play.City;
                    StateTextBox1.Text = play.State;
                    ZipTextBox1.Text = play.Zip;
                    BirthDateTextBox1.Text = Convert.ToDateTime(play.BirthDate).ToString("dd-MMM-yyyy");
                    SexCombo1.Text = play.Sex;

                    if (play.OtherSpringSport != null)
                    {

                        if (play.OtherSpringSport.Value)
                        {
                            OtherSpringSportCombo1.Text = "Y";
                        }
                        else
                        {
                            OtherSpringSportCombo1.Text = "N";
                        }
                    }
                    else
                    {
                        OtherSpringSportCombo1.Text = "";
                    }

                    if (play.PrimaryCommitment != null)
                    {

                        if (play.PrimaryCommitment.Value)
                        {
                            PrimaryCommitmentCombo1.Text = "Y";
                        }
                        else
                        {
                            PrimaryCommitmentCombo1.Text = "N";
                        }
                    }
                    else
                    {
                        PrimaryCommitmentCombo1.Text = "";
                    }

                    MedicalIssuesTextBox1.Text = play.HeathIssues;

                    Player1.Text = play.PlayerID.ToString();
                }

                if (i == 2)
                {
                    ChildFirstNameTextBox2.Text = play.PlayerFirstName;
                    ChildLastNameTextBox2.Text = play.PlayerLastName;
                    StreetAddressTextBox2.Text = play.StreetAddress;
                    CityTextBox2.Text = play.City;
                    StateTextBox2.Text = play.State;
                    ZipTextBox2.Text = play.Zip;
                    BirthDateTextBox2.Text = Convert.ToDateTime(play.BirthDate).ToString("dd-MMM-yyyy");
                    SexCombo2.Text = play.Sex;

                    if (play.OtherSpringSport != null)
                    {

                        if (play.OtherSpringSport.Value)
                        {
                            OtherSpringSportCombo2.Text = "Y";
                        }
                        else
                        {
                            OtherSpringSportCombo2.Text = "N";
                        }
                    }
                    else
                    {
                        OtherSpringSportCombo2.Text = "";
                    }

                    if (play.PrimaryCommitment != null)
                    {

                        if (play.PrimaryCommitment.Value)
                        {
                            PrimaryCommitmentCombo2.Text = "Y";
                        }
                        else
                        {
                            PrimaryCommitmentCombo2.Text = "N";
                        }
                    }
                    else
                    {
                        PrimaryCommitmentCombo2.Text = "";
                    }

                    MedicalIssuesTextBox2.Text = play.HeathIssues;

                    Player2.Text = play.PlayerID.ToString();

                }

                if (i == 3)
                {
                    ChildFirstNameTextBox3.Text = play.PlayerFirstName;
                    ChildLastNameTextBox3.Text = play.PlayerLastName;
                    StreetAddressTextBox3.Text = play.StreetAddress;
                    CityTextBox3.Text = play.City;
                    StateTextBox3.Text = play.State;
                    ZipTextBox3.Text = play.Zip;
                    BirthDateTextBox3.Text = Convert.ToDateTime(play.BirthDate).ToString("dd-MMM-yyyy");
                    SexCombo3.Text = play.Sex;

                    if (play.OtherSpringSport != null)
                    {

                        if (play.OtherSpringSport.Value)
                        {
                            OtherSpringSportCombo3.Text = "Y";
                        }
                        else
                        {
                            OtherSpringSportCombo3.Text = "N";
                        }
                    }
                    else
                    {
                        OtherSpringSportCombo3.Text = "";
                    }

                    if (play.PrimaryCommitment != null)
                    {

                        if (play.PrimaryCommitment.Value)
                        {
                            PrimaryCommitmentCombo3.Text = "Y";
                        }
                        else
                        {
                            PrimaryCommitmentCombo3.Text = "N";
                        }
                    }
                    else
                    {
                        PrimaryCommitmentCombo3.Text = "";
                    }

                    MedicalIssuesTextBox3.Text = play.HeathIssues;

                    Player3.Text = play.PlayerID.ToString();

                }

                i = i + 1;

            }
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
            ValidateLabel.Text = "";
            ValidateLabel.Visible = false;

            MothersFirstNameValidate.Visible = false;
            MothersLastNameValidate.Visible = false;
            MothersEmailValidate.Visible = false;
            MothersPhoneValidate.Visible = false;

            FathersFirstNameValidate.Visible = false;
            FathersLastNameValidate.Visible = false;
            FathersEmailValidate.Visible = false;
            FathersPhoneValidate.Visible = false;

            ChildFirstNameValidate1.Visible = false;
            ChildLastNameValidate1.Visible = false;
            StreetAddressValidate1.Visible = false;
            CityTextBoxValidate1.Visible = false;
            StateValidate1.Visible = false;
            ZipTextValidate1.Visible = false;
            BirthDateValidate1.Visible = false;
            SexValidate1.Visible = false;

            ChildFirstNameValidate2.Visible = false;
            ChildLastNameValidate2.Visible = false;
            StreetAddressValidate2.Visible = false;
            CityTextBoxValidate2.Visible = false;
            StateValidate2.Visible = false;
            ZipTextValidate2.Visible = false;
            BirthDateValidate2.Visible = false;
            SexValidate2.Visible = false;

            ChildFirstNameValidate2.Visible = false;
            ChildLastNameValidate2.Visible = false;
            StreetAddressValidate2.Visible = false;
            CityTextBoxValidate2.Visible = false;
            StateValidate2.Visible = false;
            ZipTextValidate2.Visible = false;
            BirthDateValidate2.Visible = false;
            SexValidate2.Visible = false;

            ChildFirstNameValidate3.Visible = false;
            ChildLastNameValidate3.Visible = false;
            StreetAddressValidate3.Visible = false;
            CityTextBoxValidate3.Visible = false;
            StateValidate3.Visible = false;
            ZipTextValidate3.Visible = false;
            BirthDateValidate3.Visible = false;
            SexValidate3.Visible = false;

        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {

            string ValidateText = ValidateForm();

            if (ValidateText.Length > 0)
            {
                ValidateLabel.Visible = true;
                ValidateLabel.Text = ValidateText;
            }
            else
            {
                //Lets Save
                SaveProfile();
                if (Page.User.Identity.IsAuthenticated)
                {
                    if (DBCommon.HasAPlayer(Page.User.Identity.Name))
                    {
                        if (AdminLabel.Text == "yep")
                        {
                            Response.Redirect("ManagePlayers.aspx");
                        }
                        else
                        {
                            Response.Redirect("EditProfile.aspx");
                        }
                        
                    }
              
                }
                
            }

        }

        private void SaveProfile()
        {

            decimal memberid = 0;

            if (MemberID.Text.Length > 0)
            {
                memberid = Convert.ToDecimal(MemberID.Text);
            }

           
            //mem.HomePhones

            MemberID.Text = DBCommon.SaveMember(memberid, FamilyDrPhoneTextBox.Text, FamilyDrTextBox.Text, MothersPhoneTextBox.Text, MothersEmailTextBox.Text, MothersFirstNameTextBox.Text, MothersLastNameTextBox.Text, MothersOccupation.Text, FathersPhoneTextBox.Text, FathersEmailTextBox.Text, FathersFirstNameTextBox.Text, FathersLastNameTextBox.Text, FathersOccupation.Text);


            SaveParticipations(memberid);

            SavePlayers(memberid);
         
        }

        private void SavePlayers(decimal memberid)
        {
            string player1 = "";
            string player2 = "";
            string player3 = "";

            if (ChildFirstNameTextBox1.Text.Trim().Length > 0)
            {
                if (Player1.Text.Length > 0)
                {
                    player1 = Player1.Text;
                }

                Player1.Text = DBCommon.SavePlayer(memberid, player1, ChildFirstNameTextBox1.Text, ChildLastNameTextBox1.Text, StreetAddressTextBox1.Text, CityTextBox1.Text, StateTextBox1.Text, ZipTextBox1.Text, BirthDateTextBox1.Text, SexCombo1.Text, OtherSpringSportCombo1.Text, PrimaryCommitmentCombo1.Text, MedicalIssuesTextBox1.Text);
            }

            if (ChildFirstNameTextBox2.Text.Trim().Length > 0)
            {
                if (Player2.Text.Length > 0)
                {
                    player2 = Player2.Text;
                }

                Player2.Text = DBCommon.SavePlayer(memberid, player2, ChildFirstNameTextBox2.Text, ChildLastNameTextBox2.Text, StreetAddressTextBox2.Text, CityTextBox2.Text, StateTextBox2.Text, ZipTextBox2.Text, BirthDateTextBox2.Text, SexCombo2.Text, OtherSpringSportCombo2.Text, PrimaryCommitmentCombo2.Text, MedicalIssuesTextBox2.Text);
            }

            if (ChildFirstNameTextBox3.Text.Trim().Length > 0)
            {
                if (Player3.Text.Length > 0)
                {
                    player3 = Player3.Text;
                }

                Player3.Text = DBCommon.SavePlayer(memberid, player3, ChildFirstNameTextBox3.Text, ChildLastNameTextBox3.Text, StreetAddressTextBox3.Text, CityTextBox3.Text, StateTextBox3.Text, ZipTextBox3.Text, BirthDateTextBox3.Text, SexCombo3.Text, OtherSpringSportCombo3.Text, PrimaryCommitmentCombo3.Text, MedicalIssuesTextBox3.Text);
            }
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

        private string ValidateForm()
        {
            StringBuilder ValidateMsg = new StringBuilder() ;

            if (MothersFirstNameTextBox.Text.Trim().Length == 0)
            {
                ValidateMsg.AppendLine("Parent/Guardian #1 FirstName is required.<br/>");
                MothersFirstNameValidate.Visible = true;
            }

            if (MothersLastNameTextBox.Text.Trim().Length == 0)
            {
                ValidateMsg.AppendLine("Parent/Guardian #1 LastName is required.<br/>");
                MothersLastNameValidate.Visible = true;
            }

            if (MothersEmailTextBox.Text.Trim().Length == 0)
            {
                ValidateMsg.AppendLine("Parent/Guardian #1 Email is required.<br/>");
                MothersEmailValidate.Visible = true;

            }

            if (MothersPhoneTextBox.Text.Trim().Length == 0)
            {
                ValidateMsg.AppendLine("Parent/Guardian #1 Phone is required.<br/>");
                MothersPhoneValidate.Visible = true;

            }

            //************************

            if (FathersFirstNameTextBox.Text.Trim().Length > 0)
            {
                if (FathersFirstNameTextBox.Text.Trim().Length == 0)
                {
                    ValidateMsg.AppendLine("Parent/Guardian #2 FirstName is required.<br/>");
                    FathersFirstNameValidate.Visible = true;
                }

                if (FathersLastNameTextBox.Text.Trim().Length == 0)
                {
                    ValidateMsg.AppendLine("Parent/Guardian #2 LastName is required.<br/>");
                    FathersLastNameValidate.Visible = true;
                }

                if (FathersEmailTextBox.Text.Trim().Length == 0)
                {
                    ValidateMsg.AppendLine("Parent/Guardian #2 Email is required.<br/>");
                    FathersEmailValidate.Visible = true;

                }

                if (FathersPhoneTextBox.Text.Trim().Length == 0)
                {
                    ValidateMsg.AppendLine("Parent/Guardian #2 Phone is required.<br/>");
                    FathersPhoneValidate.Visible = true;

                }
            }

            //************************

            if (ChildFirstNameTextBox1.Text.Trim().Length > 0)
            { //We have a kid #!

                if (ChildLastNameTextBox1.Text.Trim().Length == 0)
                {
                    ValidateMsg.AppendLine("Child 1 Last Name is required.<br/>");
                    ChildLastNameValidate1.Visible = true;

                }


                if (StreetAddressTextBox1.Text.Trim().Length == 0)
                {
                    ValidateMsg.AppendLine("Child 1 Street Address is required.<br/>");
                    StreetAddressValidate1.Visible = true;

                }

                if (CityTextBox1.Text.Trim().Length == 0)
                {
                    ValidateMsg.AppendLine("Child 1 City is required.<br/>");
                    CityTextBoxValidate1.Visible = true;

                }

                if (StateTextBox1.Text.Trim().Length == 0)
                {
                    ValidateMsg.AppendLine("Child 1 State is required.<br/>");
                    StateValidate1.Visible = true;

                }

                if (ZipTextBox1.Text.Trim().Length == 0)
                {
                    ValidateMsg.AppendLine("Child 1 Zip is required.<br/>");
                    ZipTextValidate1.Visible = true;

                }

                if (BirthDateTextBox1.Text.Trim().Length == 0)
                {
                    ValidateMsg.AppendLine("Child 1 Birth Date is required.<br/>");
                    BirthDateValidate1.Visible = true;

                }

                if (SexCombo1.Text.Trim().Length == 0)
                {
                    ValidateMsg.AppendLine("Child 1 M/F is required.<br/>");
                    SexValidate1.Visible = true;

                }

            }

            //************************

            if (ChildFirstNameTextBox2.Text.Trim().Length > 0)
            { //We have a kid #2

                if (ChildLastNameTextBox2.Text.Trim().Length == 0)
                {
                    ValidateMsg.AppendLine("Child 2 Last Name is required<br/>.");
                    ChildLastNameValidate2.Visible = true;

                }


                if (StreetAddressTextBox2.Text.Trim().Length == 0)
                {
                    ValidateMsg.AppendLine("Child 2 Street Address is required.<br/>");
                    StreetAddressValidate2.Visible = true;

                }

                if (CityTextBox2.Text.Trim().Length == 0)
                {
                    ValidateMsg.AppendLine("Child 2 City is required.<br/>");
                    CityTextBoxValidate2.Visible = true;

                }

                if (StateTextBox2.Text.Trim().Length == 0)
                {
                    ValidateMsg.AppendLine("Child 2 State is required.<br/>");
                    StateValidate2.Visible = true;

                }

                if (ZipTextBox2.Text.Trim().Length == 0)
                {
                    ValidateMsg.AppendLine("Child 2 Zip is required.<br/>");
                    ZipTextValidate2.Visible = true;

                }

                if (BirthDateTextBox2.Text.Trim().Length == 0)
                {
                    ValidateMsg.AppendLine("Child 2 Birth Date is required.<br/>");
                    BirthDateValidate2.Visible = true;

                }

                if (SexCombo2.Text.Trim().Length == 0)
                {
                    ValidateMsg.AppendLine("Child 2 M/F is required.<br/>");
                    SexValidate2.Visible = true;

                }

            }

            //************************

            if (ChildFirstNameTextBox3.Text.Trim().Length > 0)
            { //We have a kid #3

                if (ChildLastNameTextBox3.Text.Trim().Length == 0)
                {
                    ValidateMsg.AppendLine("Child 3 Last Name is required.<br/>");
                    ChildLastNameValidate3.Visible = true;

                }


                if (StreetAddressTextBox3.Text.Trim().Length == 0)
                {
                    ValidateMsg.AppendLine("Child 3 Street Address is required.<br/>");
                    StreetAddressValidate3.Visible = true;

                }

                if (CityTextBox3.Text.Trim().Length == 0)
                {
                    ValidateMsg.AppendLine("Child 3 City is required.<br/>");
                    CityTextBoxValidate3.Visible = true;

                }

                if (StateTextBox3.Text.Trim().Length == 0)
                {
                    ValidateMsg.AppendLine("Child 3 State is required.<br/>");
                    StateValidate3.Visible = true;

                }

                if (ZipTextBox3.Text.Trim().Length == 0)
                {
                    ValidateMsg.AppendLine("Child 3 Zip is required.<br/>");
                    ZipTextValidate3.Visible = true;

                }

                if (BirthDateTextBox3.Text.Trim().Length == 0)
                {
                    ValidateMsg.AppendLine("Child 3 Birth Date is required.<br/>");
                    BirthDateValidate3.Visible = true;

                }

                if (SexCombo3.Text.Trim().Length == 0)
                {
                    ValidateMsg.AppendLine("Child 3 M/F is required.<br/>");
                    SexValidate3.Visible = true;

                }

            }

            if ((ChildFirstNameTextBox1.Text.Trim().Length == 0) && (ChildFirstNameTextBox2.Text.Trim().Length == 0) && (ChildFirstNameTextBox3.Text.Trim().Length == 0))
            {
                ValidateMsg.AppendLine("At least one child has to be added.<br/>");
            }




            return ValidateMsg.ToString();
        }
    }
}