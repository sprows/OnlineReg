using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace OnlineReg
{
    public partial class main : System.Web.UI.Page
    {
        public string TeamPic = "";
        public string TeamName = "";
        public string TeamDesc = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            TeamPic = ((Reg)Page.Master)._org.TeamPic;
            TeamName = ((Reg)Page.Master)._org.TeamName;
            TeamDesc = ((Reg)Page.Master)._org.TeamDesc;

            if (Page.User.Identity.IsAuthenticated)
            {
                if (DBCommon.HasAPlayer(Page.User.Identity.Name))
                {
                    Response.Redirect("EditProfile.aspx");
                }
                else
                {
                    Response.Redirect("Profile.aspx");
                }

            }
            else
            {
                ((Reg)Page.Master).TurnOffAdmin();
            }
            
        }

        protected void CreateAccountButton_Click(object sender, EventArgs e)
        {

            if (UserNameTextBox.Text.Trim().ToUpper() == "PAPER")
            {
                //bail
                return;
            }


            if (PasswordTextBox.Text.Length >= 6 && Password2TextBox.Text.Length >= 6)
            {
                RegexUtilities utils = new RegexUtilities();
                if (utils.IsValidEmail(EmailTextBox.Text))
                {

                    if (PasswordTextBox.Text.ToUpper().Trim() != Password2TextBox.Text.ToUpper().Trim())
                    {
                        ErrorMessageLabel2.Visible = true;
                        ErrorMessageLabel2.Text = "Passwords do not match.  Please Re-try typing your passwords.";


                    }
                    else
                    {
                        if (!DBCommon.EmailDoesExist(EmailTextBox.Text.Trim()))
                        {

                            //Yay!! - we are in!!
                            DBCommon.CreateAccount(DBCommon.GetMyOrgID(), EmailTextBox.Text,PasswordTextBox.Text);
                            FormsAuthentication.RedirectFromLoginPage(EmailTextBox.Text, true);

                        }
                        else
                        {
                            ErrorMessageLabel2.Visible = true;
                            ErrorMessageLabel2.Text = "Email already exists.  Please choose another or Login.";
                        }




                    }
                }
                else
                {
                    ErrorMessageLabel2.Visible = true;
                    ErrorMessageLabel2.Text = "Please enter in a valid email.";

                }

            }
            else
            {
                ErrorMessageLabel2.Visible = true;
                ErrorMessageLabel2.Text = "Passwords have to be greater then 6 characters.";

            }

        }
        
        protected void cmdLogin_Click(object sender, EventArgs e)
        {


            if (UserNameTextBox.Text.Trim().ToUpper() == "PAPER")
            {
                //bail
                return;
            }
            
            RegMember myMember = DBCommon.GetMember(UserNameTextBox.Text, PasswordLogonTextBox.Text);

            if (myMember != null)
            {
                //Set Cookie
                HttpCookie newCookie = new HttpCookie("RegOnline");
                newCookie.Expires = DateTime.MinValue;
                newCookie.Value = myMember.OrgID.ToString();

                Response.Cookies.Add(newCookie);

                FormsAuthentication.SetAuthCookie(UserNameTextBox.Text, true);
                Response.Redirect("main.aspx");

                //FormsAuthentication.RedirectFromLoginPage(UserNameTextBox.Text, true);
            }
            else
            {
                UserNameTextBox.Text = "";
                PasswordLogonTextBox.Text = "";
                ErrorMessageLabel1.Visible = true;
                ErrorMessageLabel1.Text = "Invalid email/password";
            }

        }

        protected void ForgotButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("forgot.aspx");
        }


    }
}