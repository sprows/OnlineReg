using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace OnlineReg
{
    public partial class EditPlayer : System.Web.UI.Page
    {
        RegMember _member = null;
        string _memberID = "";
        string _playerID = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            ValidateLabel.Visible = false;

            if (Request.QueryString["id"] != null)
            {
                string[] HolderArray = Request.QueryString["id"].Split('|');
                _memberID = HolderArray[0];
                _playerID = HolderArray[1];

            }


            if (!Page.IsPostBack)
            {
                CommonFunctions cf = new CommonFunctions();
                _member = cf.GetMemberSetup(this);


                
                if (_member != null)
                {
                    if (Convert.ToBoolean(_member.IsAdmin))
                    {
                       //They are an Admin -- No check needed
                        LoadUpPlayer();
                    }
                    else 
                    { //Not Admin -- make sure this is one of their players

                        if (_playerID != "") //Do not load up player information -- New Player
                        {

                            List<RegPlayer> myPlayers = DBCommon.GetPlayers(_member.MemberID);
                            if (myPlayers.Any(p => p.PlayerID == Convert.ToDecimal(_playerID)))
                            {
                                //It is theirs!  Load it up
                                LoadUpPlayer();

                            }
                            else
                            {   //They do not have access -- Take them back to the main page
                                Response.Redirect("main.aspx");
                            }
                        }
                    }

                }
                else
                {
                    //Not authenticated -- lets bring them back to the logon page
                    Response.Redirect("main.aspx");


                }
            }
        }

        private void LoadUpPlayer()
        {
            if (_playerID.Length > 0)
            {

                RegPlayer player = DBCommon.LoadPlayer(Convert.ToDecimal(_playerID));
                SetUpPlayers(player);

                MessageLabel.Text = "Edit Information for ";
                NameLabel.Text = player.PlayerFirstName + " " + player.PlayerLastName;
            }
            else
            {
                MessageLabel.Text = "Add a new player";
            }

            ClearValidation();

        }

      
        private void SetUpPlayers(RegPlayer play)
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

        }

        void ClearValidation()
        {
            ChildFirstNameValidate1.Visible = false;
            ChildLastNameValidate1.Visible = false;
            StreetAddressValidate1.Visible = false;
            CityTextBoxValidate1.Visible = false;
            StateValidate1.Visible = false;
            ZipTextValidate1.Visible = false;
            BirthDateValidate1.Visible = false;
            SexValidate1.Visible = false;
        }

        private string ValidatePlayer()
        {
            StringBuilder ValidateMsg = new StringBuilder();

            if (ChildFirstNameTextBox1.Text.Trim().Length > 0)
            { //We have a kid #!

                if (ChildLastNameTextBox1.Text.Trim().Length == 0)
                {
                    ValidateMsg.AppendLine("Last Name is required.<br/>");
                    ChildLastNameValidate1.Visible = true;

                }


                if (StreetAddressTextBox1.Text.Trim().Length == 0)
                {
                    ValidateMsg.AppendLine("Street Address is required.<br/>");
                    StreetAddressValidate1.Visible = true;

                }

                if (CityTextBox1.Text.Trim().Length == 0)
                {
                    ValidateMsg.AppendLine("City is required.<br/>");
                    CityTextBoxValidate1.Visible = true;

                }

                if (StateTextBox1.Text.Trim().Length == 0)
                {
                    ValidateMsg.AppendLine("State is required.<br/>");
                    StateValidate1.Visible = true;

                }

                if (ZipTextBox1.Text.Trim().Length == 0)
                {
                    ValidateMsg.AppendLine("Zip is required.<br/>");
                    ZipTextValidate1.Visible = true;

                }

                if (BirthDateTextBox1.Text.Trim().Length == 0)
                {
                    ValidateMsg.AppendLine("Birth Date is required.<br/>");
                    BirthDateValidate1.Visible = true;

                }

                if (SexCombo1.Text.Trim().Length == 0)
                {
                    ValidateMsg.AppendLine("M/F is required.<br/>");
                    SexValidate1.Visible = true;

                }

            }
            else
            {
                ValidateMsg.AppendLine("Please enter in information.<br/>");
                SexValidate1.Visible = true;
            }

            return ValidateMsg.ToString();
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            string ValidateText = ValidatePlayer();

            if (ValidateText.Length > 0)
            {
                ValidateLabel.Visible = true;
                ValidateLabel.Text = ValidateText;
            }
            else
            {

                DBCommon.SavePlayer(Convert.ToDecimal(_memberID), _playerID, ChildFirstNameTextBox1.Text, ChildLastNameTextBox1.Text, StreetAddressTextBox1.Text, CityTextBox1.Text, StateTextBox1.Text, ZipTextBox1.Text, BirthDateTextBox1.Text, SexCombo1.Text, OtherSpringSportCombo1.Text, PrimaryCommitmentCombo1.Text, MedicalIssuesTextBox1.Text);
                Response.Redirect("EditProfile.aspx");
            }
        }

        protected void AddButton_Click(object sender, EventArgs e)
        {

        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditProfile.aspx");
        }

    }
}