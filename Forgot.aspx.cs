using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineReg
{
    public partial class Forgot : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            ErrorMessageLabel.Visible = false;
        }

        protected void cmdSendMePassword_Click(object sender, EventArgs e)
        {

            CommonFunctions cf = new CommonFunctions();
            RegMember mem = DBCommon.GetMember(UserNameTextBox.Text.Trim());

            if (mem == null)
            {
                ErrorMessageLabel.Visible = true;
                ErrorMessageLabel.Text = "This user does not exist.";
            }
            else
            {
                cf.SendWelcomeEmail(mem.Username, mem.Password, mem.Username);

                ErrorMessageLabel.Visible = true;
                ErrorMessageLabel.ForeColor = System.Drawing.Color.Black;
                ErrorMessageLabel.Text = "An Email has been sent to this user with their password.";
                cmdSendMePassword.Enabled = false;


            }
          
            
        }
    }
}