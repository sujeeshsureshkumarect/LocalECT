using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
//////using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
////using System.Xml.Linq;
using System.Collections.Generic;

namespace LocalECT
{
    public partial class ChangePwd : System.Web.UI.Page
    {
        int UserNumber;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CurrentRole"] != null)
            {
                if (!IsPostBack)
                {
                    int UserNumber = 0;

                    if (Session["CurrentUserName"] != null && Session["CurrentUserNo"] != null)
                    {
                        TxtUserName.Text = Session["CurrentUserName"].ToString();
                        UserNumber = Convert.ToInt32(Session["CurrentUserNo"]);
                    }
                }
            }
            else
            {
                Session.RemoveAll();
                Response.Redirect("Login.aspx");
            }
        }
        protected void ButSubmit_Click(object sender, EventArgs e)
        {
            List<User> myUsers = new List<User>();
            UserDAL myUserDAL = new UserDAL();

            UserNumber = Convert.ToInt32(Session["CurrentUserNo"]);
            string sCondition = " Where UserName='" + TxtUserName.Text + "' AND UserNo = " + UserNumber.ToString();
            myUsers = myUserDAL.GetUser(InitializeModule.EnumCampus.ECTNew, sCondition, false);
            int status = (int)InitializeModule.enumModes.EditMode;
            if (myUsers.Count > 0)
            {
                //Password Encryption 
                EncryptionCls theEncryption = new EncryptionCls();

                string sEncryptedPwd = theEncryption.getMd5Hash(TxtNewPWD.Text);

                // if (myUsers[0].Password == TxtOldPwd.Text)
                if (theEncryption.verifyMd5Hash(TxtOldPwd.Text, myUsers[0].Password))

                //if (myUsers[0].Password == TxtOldPwd.Text)
                {

                    //myUsers[0].Password = TxtNewPWD.Text;
                    myUsers[0].Password = sEncryptedPwd;

                    myUsers[0].IsChangingRequired = 0;

                    int affectedrows = myUserDAL.UpdateUser(InitializeModule.EnumCampus.ECTNew, status,
                        myUsers[0].UserNo, myUsers[0].UserName, myUsers[0].Password, myUsers[0].EmployeeID,
                        myUsers[0].UILanguage, myUsers[0].AcademicYear, myUsers[0].Semester, myUsers[0].MarksYear,
                        myUsers[0].MarksSemester, myUsers[0].GradesPCName, myUsers[0].ADUserName, myUsers[0].IsActive,
                        DateTime.Now, 0, myUsers[0].AllowedCampus, myUsers[0].LecturerID, myUsers[0].IsLecturer,
                        myUsers[0].IsChangingRequired, myUsers[0].Campus, myUsers[0].CreationUserID, myUsers[0].CreationDate,
                        myUsers[0].LastUpdateUserID, DateTime.Today.Date, myUsers[0].PCName, myUsers[0].NetUserName);
                    if (affectedrows > 0)
                    {
                        lblMsgs.Text = "Your password is changed successfully, You must Logout and log in again.";
                        this.OldPwdRequiredFieldValidator.Enabled = false;
                        this.NewPwdCompareValidator.Enabled = false;
                        this.NewPwdRequiredFieldValidator.Enabled = false;
                        this.LinkSave.Enabled = false;
                    }
                }
                else
                {
                    lblMsgs.Text = "Your old password worng, Please check your old password again.";
                }
            }
        }
    }
}