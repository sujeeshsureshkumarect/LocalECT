using System;
using System.Collections;
using System.Configuration;
using System.Data;
//////using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
////using System.Xml.Linq;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Drawing;

namespace LocalECT
{
    public partial class User_Setup : System.Web.UI.Page
    {
        UserDAL myUserDAL = new UserDAL();
        DataView dv = new DataView();
        int RoleID = 0;
        int CurrentRole = 0;
        List<ECTNewLecturers> myLecturers = new List<ECTNewLecturers>();
        ECTNewLecturersDAL myLecturersDAL = new ECTNewLecturersDAL();
        string sUserName = "";
        string sNetUserName = "";
        string sPCName = "";
        protected void Page_Load(object sender, EventArgs e)
        {  
            if (Session["CurrentRole"] != null)
            {
                CurrentRole = (int)Session["CurrentRole"];
                Session["ProfilePIcUsers"] = "";
            }
            else
            {
                Session.RemoveAll();
                Response.Redirect("Login.aspx");
            }
            sUserName = Convert.ToString(Session["CurrentUserName"]);
            sNetUserName = Convert.ToString(Session["CurrentNetUserName"]);
            sPCName = Convert.ToString(Session["CurrentPCName"]);
            //CurrentRole = Convert.ToInt32 (  Session["CurrentRole"]);
            if (!IsPostBack)
            {
                if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.Setting_UsersSetup,
                InitializeModule.enumPrivilege.ShowBrowse, CurrentRole) != true)
                {
                    Server.Transfer("Authorization.aspx");

                }
            }

            lbl_Msg.Text = "";

            if (!IsPostBack)
            {
                Session["myList"] = null;
                FillTerms();
                fillUserslst();
                FillEmployees();
                FillCampusLecturers();
                FillLecturers();
                FillRoles();
            }

            if (!string.IsNullOrEmpty(Request.QueryString["RoleID"]))
            {
                RoleID = int.Parse(Request.QueryString["RoleID"]);
                if (RoleID > 0)
                {
                    RolesCBO.SelectedValue = RoleID.ToString();
                }
            }
        }
        private void FillTerms()
        {
            List<Semesters> myTerms = new List<Semesters>();
            SemesterDAL myTermsDAL = new SemesterDAL();
            try
            {
                myTerms = myTermsDAL.GetTerms(InitializeModule.EnumCampus.ECTNew, "", true);
                for (int i = 0; i < myTerms.Count; i++)
                {
                    PTermCBO.Items.Add(new ListItem(myTerms[i].ShortDesc, myTerms[i].Term.ToString()));
                    MTermCBO.Items.Add(new ListItem(myTerms[i].ShortDesc, myTerms[i].Term.ToString()));
                }
            }
            catch (Exception ex)
            {


                LibraryMOD.ShowErrorMessage(ex);
                //divMsg.InnerText = ex.Message;
                lbl_Msg.Text = ex.Message;
                div_msg.Visible = true;
            }
            finally
            {
                myTerms.Clear();

            }
        }

        private void fillUserslst()
        {

            try
            {
                dv = myUserDAL.GetDataView(false, 0, "");
                UsersLST.DataSource = dv;

                UsersLST.DataValueField = dv.Table.Columns[0].ColumnName;
                UsersLST.DataTextField = dv.Table.Columns[1].ColumnName;
                UsersLST.DataBind();
            }
            catch (Exception ex)
            {
                LibraryMOD.ShowErrorMessage(ex);
                //divMsg.InnerText = ex.Message;
                lbl_Msg.Text = ex.Message;
                div_msg.Visible = true;
            }
            finally
            {

                Session["UsersDV"] = dv;

            }
        }

        private void FillEmployees()
        {
            List<Employee> myEmployee = new List<Employee>();
            EmployeeDAL myEmployeeDAL = new EmployeeDAL();
            try
            {
                myEmployee = myEmployeeDAL.GetList(InitializeModule.EnumCampus.ECTNew, "", true);
                for (int i = 0; i < myEmployee.Count; i++)
                {

                    EmployeeCBO.Items.Add(new ListItem(myEmployee[i].Name, myEmployee[i].EmployeeID.ToString()));

                }

            }
            catch (Exception ex)
            {

                LibraryMOD.ShowErrorMessage(ex);
                //divMsg.InnerText = ex.Message;
                lbl_Msg.Text = ex.Message;
                div_msg.Visible = true;
            }
            finally
            {
                myEmployee.Clear();

            }
        }

        private void FillCampusLecturers()
        {

            try
            {
                myLecturers = myLecturersDAL.GetCampusLecturer(InitializeModule.EnumCampus.Males, " bActive=1", true);
                for (int i = 0; i < myLecturers.Count; i++)
                {

                    LecturerMCBO.Items.Add(new ListItem(myLecturers[i].LecturerNameEn, myLecturers[i].LecturerID.ToString()));

                }
                myLecturers.Clear();
                myLecturers = myLecturersDAL.GetCampusLecturer(InitializeModule.EnumCampus.Females, " bActive=1", true);
                for (int i = 0; i < myLecturers.Count; i++)
                {

                    LecturerFCBO.Items.Add(new ListItem(myLecturers[i].LecturerNameEn, myLecturers[i].LecturerID.ToString()));

                }

            }
            catch (Exception ex)
            {

                LibraryMOD.ShowErrorMessage(ex);
                //divMsg.InnerText = ex.Message;
                lbl_Msg.Text = ex.Message;
                div_msg.Visible = true;
            }
            finally
            {
                myLecturers.Clear();

            }
        }

        private void FillLecturers()
        {
            try
            {
                myLecturers = myLecturersDAL.GetList(InitializeModule.EnumCampus.ECTNew, "", true);
                for (int i = 0; i < myLecturers.Count; i++)
                {

                    LecturerCBO.Items.Add(new ListItem(myLecturers[i].LecturerNameEn, myLecturers[i].LecturerID.ToString()));

                }
                Session["myList"] = myLecturers; ;

            }
            catch (Exception ex)
            {

                LibraryMOD.ShowErrorMessage(ex);
                //divMsg.InnerText = ex.Message;
                lbl_Msg.Text = ex.Message;
                div_msg.Visible = true;
            }
            finally
            {
                //myLecturers.Clear();

            }
        }

        private void FillRoles()
        {
            List<_Role> myRoles = new List<_Role>();
            RoleDAL myRoleDAL = new RoleDAL();
            try
            {
                myRoles = myRoleDAL.GetRole(InitializeModule.EnumCampus.ECTNew, "", true);
                for (int i = 0; i < myRoles.Count; i++)
                {

                    RolesCBO.Items.Add(new ListItem(myRoles[i].RoleNameEn, myRoles[i].RoleID.ToString()));

                }

            }
            catch (Exception ex)
            {

                LibraryMOD.ShowErrorMessage(ex);
                //divMsg.InnerText = ex.Message;
                lbl_Msg.Text = ex.Message;
                div_msg.Visible = true;
            }
            finally
            {
                myRoles.Clear();

            }
        }


        protected void UsersLST_SelectedIndexChanged(object sender, EventArgs e)
        {
            int iUser = 0;
            if (!string.IsNullOrEmpty(UsersLST.SelectedValue))
            {
                iUser = int.Parse(UsersLST.SelectedValue);
                GetUser(iUser);
                getprofilepic(iUser);
            }
            lbl_Msg.Text = "";
            div_msg.Visible = false;
        }
        public void getprofilepic(int iUser)
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew);

            SqlConnection sc = new SqlConnection(myConnection_String.Conn_string);
            SqlCommand cmd = new SqlCommand("select EmployeeID from [Cmn_User] where UserNo=@UserNo", sc);
            cmd.Parameters.AddWithValue("@UserNo", iUser);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            string employeeid = "";
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                if(dt.Rows.Count>0)
                {
                    employeeid = dt.Rows[0]["EmployeeID"].ToString();
                }
            }
            catch(Exception ex)
            {
                sc.Close();
                lbl_Msg.Text = ex.Message;
                div_msg.Visible = true;
            }
            finally
            {
                sc.Close();
            }

            var services = new DAL.DAL();
            DataTable dtEmployeeProfile = services.GetEmployeeProfilePic(employeeid, myConnection_String.Conn_string);
            if (dtEmployeeProfile.Rows.Count > 0)
            {
                Session["ProfilePIcUsers"] = dtEmployeeProfile.Rows[0]["PIC"].ToString();               
            }
            else
            {
                Session["ProfilePIcUsers"] = "";
            }
        }

        private void GetUser(int iUser)
        {
            List<User> myUsers = new List<User>();

            try
            {
                myUsers = myUserDAL.GetUser(InitializeModule.EnumCampus.ECTNew, " Where UserNo=" + iUser, false);
                for (int i = 0; i < myUsers.Count; i++)
                {
                    UserIDLBL.Text = myUsers[i].UserNo.ToString();

                    NameTXT.Text = myUsers[i].UserName;

                    //b/c password encrypted in DB dont return password return empty

                    //PasswordTXT.TextMode = TextBoxMode.SingleLine; 
                    //PasswordTXT.Text = myUsers[i].Password;

                    //PasswordTXT.TextMode = TextBoxMode.Password;
                    //ConfirmTXT.Text = myUsers[i].Password;


                    //if(myUsers[i].EmployeeID!=0){
                    EmployeeCBO.SelectedValue = myUsers[i].EmployeeID.ToString();
                    //}
                    //if (myUsers[i].LecturerID != 0)
                    //{
                    int iLecturer = myUsers[i].LecturerID;
                    LecturerCBO.SelectedValue = iLecturer.ToString();
                    //}
                    int iPTerm = LibraryMOD.GetTerm(myUsers[i].AcademicYear, myUsers[i].Semester);
                    int iMTerm = LibraryMOD.GetTerm(myUsers[i].MarksYear, myUsers[i].MarksSemester);
                    txtGradesPCName.Text = myUsers[i].GradesPCName;
                    txtADUserName.Text = myUsers[i].ADUserName;

                    isDataChanged.Value = false.ToString();
                    DataStatus.Value = ((int)InitializeModule.enumModes.EditMode).ToString();
                    PTermCBO.SelectedValue = iPTerm.ToString();
                    MTermCBO.SelectedValue = iMTerm.ToString();
                    AllowedCampus_ddl.SelectedValue = myUsers[i].AllowedCampus.ToString();

                    myLecturers = (List<ECTNewLecturers>)Session["myList"];

                    int iIndex = myLecturers.FindIndex(delegate (ECTNewLecturers L) { return L.LecturerID == iLecturer; });
                    LecturerMCBO.SelectedValue = myLecturers[iIndex].MCampusID.ToString();
                    LecturerFCBO.SelectedValue = myLecturers[iIndex].FCampusID.ToString();
                    //myLecturers.Clear();
                    chkIsActive.Checked = Convert.ToBoolean(myUsers[i].IsActive);
                    chkIsChangingPasswordRequired.Checked = Convert.ToBoolean(myUsers[i].IsChangingRequired);
                    if (chkIsActive.Checked == true)
                    {
                        chkIsActive.Text = "Active";
                        chkIsActive.ForeColor = System.Drawing.Color.Blue;
                    }
                    else
                    {
                        chkIsActive.Text = "In Active";
                        chkIsActive.ForeColor = System.Drawing.Color.Red;

                    }
                }

            }
            catch (Exception ex)
            {
                LibraryMOD.ShowErrorMessage(ex);
                //divMsg.InnerText = ex.Message;
                lbl_Msg.Text = ex.Message;
                div_msg.Visible = true;
            }
            finally
            {
                myUsers.Clear();
            }
        }
        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            switch (DataStatus.Value)
            {

                case "3": //edit mode
                    args.IsValid = false;
                    if (PasswordTXT.Text == "" && ConfirmTXT.Text == "")
                    {
                        args.IsValid = true;
                    }
                    if (PasswordTXT.Text == ConfirmTXT.Text)
                    {
                        args.IsValid = true;
                    }

                    break;

                case "2":  //new mode
                    if (PasswordTXT.Text == "" || ConfirmTXT.Text == "")
                    {
                        //divMsg.InnerText = "Please enter and confirm the password.";
                        lbl_Msg.Text = "Please enter and confirm the password.";
                        div_msg.Visible = true;
                        args.IsValid = false;
                    }
                    break;

                default:
                    break;

            }
        }

        protected void chkIsActive_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIsActive.Checked == true)
            {
                chkIsActive.Text = "Active";
                chkIsActive.ForeColor = System.Drawing.Color.Blue;
            }
            else
            {
                chkIsActive.Text = "In Active";
                chkIsActive.ForeColor = System.Drawing.Color.Red;

            }
        }

        protected void AllowedCampus_ddl_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void AddtoRoleCMD_Click(object sender, EventArgs e)
        {
            AddUsertoRole();
        }
        private void AddUsertoRole()
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            try
            {
                Conn.Open();
                if (string.IsNullOrEmpty(UserIDLBL.Text))
                {
                    //divMsg.InnerText = "No Record Selected !";
                    lbl_Msg.Text = "No Record Selected !";
                    div_msg.Visible = true;
                    return;
                }

                int iUser = int.Parse(UserIDLBL.Text);
                RoleID = int.Parse(RolesCBO.SelectedValue);

                int iEffected = myUserDAL.AddUsersToRole(iUser, RoleID, Conn, sUserName);
                if (iEffected < 0)
                {
                    //divMsg.InnerText = "User Already in Role";
                    lbl_Msg.Text = "User Already in Role";
                    div_msg.Visible = true;
                }
                else
                {
                    //divMsg.InnerText = "User Added to Role Successfully";
                    lbl_Msg.Text = "User Added to Role Successfully";
                    div_msg.Visible = true;
                    div_Alert.Attributes.Add("class", "alert alert-success alert-dismissible");
                    grdvUserRoles.DataBind();
                }

            }
            catch (Exception ex)
            {
                LibraryMOD.ShowErrorMessage(ex);
                //divMsg.InnerText = ex.Message;
                lbl_Msg.Text = ex.Message;
                div_msg.Visible = true;
            }
            finally
            {
                Conn.Close();

            }
        }
        protected void lnkGetPc_Click(object sender, EventArgs e)
        {
            System.Collections.Specialized.NameValueCollection Var = this.Page.Request.ServerVariables;
            string sPCName = LibraryMOD.GetComputerName(Request.UserHostAddress);
            // Var["REMOTE_HOST"] + ";" + Var["REMOTE_ADDR"] + ";" + Var["LOGON_USER"];
            // 
            //sPCName = GetCookie("IhabAdm");
            txtGradesPCName.Text = sPCName;
        }

        protected void lnkGetCookie_Click(object sender, EventArgs e)
        {
            lblCookie.Text = GetCookie(NameTXT.Text);
        }
        protected void lnkSetCookie_Click(object sender, EventArgs e)
        {
            SetCookie(NameTXT.Text, txtGradesPCName.Text);
        }
        private void SetCookie(string sCookie, string sValue)
        {
            HttpCookie aCookie = new HttpCookie(sCookie.ToLower());
            aCookie.Value = sValue.ToLower();
            aCookie.Expires = DateTime.Now.AddDays(360);
            Response.Cookies.Add(aCookie);
        }
        private string GetCookie(string sCookie)
        {
            string sValue = "";
            if (Request.Cookies[sCookie.ToLower()] != null)
            {
                HttpCookie aCookie = Request.Cookies[sCookie.ToLower()];
                sValue = Server.HtmlEncode(aCookie.Value.ToLower());
            }
            return sValue;
        }
        protected void SearchTXT_TextChanged(object sender, EventArgs e)
        {
            SearchCMD_Click(null,null);
        }    

        protected void SearchCMD_Click(object sender, EventArgs e)
        {
            if (Session["UsersDV"] != null)
            {
                EncryptionCls theEncryption = new EncryptionCls();



                dv = (DataView)Session["UsersDV"];
                if (SearchTXT.Text != "")
                {
                    //dv.RowFilter = "UserName ='" + theEncryption.getMd5Hash(SearchTXT.Text) + "'";
                    dv.RowFilter = "UserName like '%" + SearchTXT.Text + "%'";

                }
                else
                {
                    dv.RowFilter = "";

                }
                UsersLST.DataSource = dv;
                UsersLST.DataBind();

            }
        }

        protected void NewCMD_Click(object sender, EventArgs e)
        {
            AddNewUser();
        }
        private void AddNewUser()
        {
            string TableName = myUserDAL.TableName;
            string ColName = LibraryMOD.GetFieldName(myUserDAL.UserNoFN);
            int iMax = 1;
            Connection_StringCLS myConnection_String = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            try
            {
                Conn.Open();
                Initialize_Controls();
                iMax += LibraryMOD.GetMaxID(Conn, ColName, TableName);
                UserIDLBL.Text = iMax.ToString();
                DataStatus.Value = ((int)InitializeModule.enumModes.NewMode).ToString();

            }
            catch (Exception ex)
            {
                LibraryMOD.ShowErrorMessage(ex);
                //divMsg.InnerText = ex.Message;
                lbl_Msg.Text = ex.Message;
                div_msg.Visible = true;                
            }
            finally
            {
                Conn.Close();
                AddtoRoleCMD.Enabled = false;
            }
        }
        private void SaveData()
        {

            try
            {
                if (string.IsNullOrEmpty(UserIDLBL.Text))
                {
                    //divMsg.InnerText = "No Record Selected !";
                    lbl_Msg.Text = "No Record Selected !";
                    div_msg.Visible = true;
                    return;
                }
                if (!Page.IsValid)
                {
                    return;
                }
                EncryptionCls theEncryption = new EncryptionCls();
                int iUser = int.Parse(UserIDLBL.Text);
                string sUser = NameTXT.Text;

                //string sUser =theEncryption.getMd5Hash( NameTXT.Text);

                string sPwd = PasswordTXT.Text;
                //Password Encryption 


                string sEncryptedPwd = "";
                if (sPwd != "")
                {
                    sEncryptedPwd = theEncryption.getMd5Hash(sPwd);
                }


                int iEmp = int.Parse(EmployeeCBO.SelectedValue);
                int iLec = int.Parse(LecturerCBO.SelectedValue);
                int iYear = 0;
                int iSem = 0;
                int iMYear = 0;
                int iMSem = 0;
                int iUserNo = 0;
                int iAllowedCampus = Convert.ToInt32(AllowedCampus_ddl.SelectedValue);
                string sADUserName = txtADUserName.Text;

                int iIsActive = Convert.ToInt32(chkIsActive.Checked);
                byte iISChangingPasswordRequired = Convert.ToByte(chkIsChangingPasswordRequired.Checked);
                if (string.IsNullOrEmpty(txtGradesPCName.Text))
                {
                    txtGradesPCName.Text = "---";
                }
                string sGradesPCName = txtGradesPCName.Text;

                iYear = LibraryMOD.SeperateTerm(int.Parse(PTermCBO.SelectedValue), out iSem);
                iMYear = LibraryMOD.SeperateTerm(int.Parse(MTermCBO.SelectedValue), out iMSem);
                int iDataStatus = int.Parse(DataStatus.Value);

                int iEffected = 0;
                iEffected = myUserDAL.UpdateUser(InitializeModule.EnumCampus.ECTNew, iDataStatus,
                    iUser, sUser, sEncryptedPwd, iEmp, 0, iYear, iSem, iMYear, iMSem, sGradesPCName, sADUserName, iIsActive, iISChangingPasswordRequired,
                     DateTime.Now, 0, iAllowedCampus, iLec,
                     iUserNo, DateTime.Now, iUserNo, DateTime.Now, sPCName, sNetUserName);


                if (iEffected > 0)
                {
                    int MalesID = int.Parse(LecturerMCBO.SelectedValue.ToString());
                    int FemalesID = int.Parse(LecturerFCBO.SelectedValue.ToString());
                    iEffected = myLecturersDAL.UpdateLecturers(InitializeModule.EnumCampus.ECTNew, iLec, MalesID, FemalesID, "", sUserName);
                    if (iEffected > 0)
                    {
                        myLecturers = (List<ECTNewLecturers>)Session["myList"];
                        int iIndex = myLecturers.FindIndex(delegate (ECTNewLecturers L) { return L.LecturerID == iLec; });
                        myLecturers[iIndex].MCampusID = MalesID;
                        myLecturers[iIndex].FCampusID = FemalesID;
                        Session["myList"] = myLecturers;
                    }
                    //divMsg.InnerText = "Data Updated Successfully";
                    lbl_Msg.Text = "Data Updated Successfully";
                    div_msg.Visible = true;
                    div_Alert.Attributes.Add("class", "alert alert-success alert-dismissible");
                    DataStatus.Value = ((int)InitializeModule.enumModes.EditMode).ToString();
                }
                else
                {
                    //divMsg.InnerText = "Data Not Updated Successfully";
                    lbl_Msg.Text = "Data Not Updated Successfully";
                    div_msg.Visible = true;                    
                }



            }
            catch (Exception ex)
            {
                LibraryMOD.ShowErrorMessage(ex);
                //divMsg.InnerText = ex.Message;
                lbl_Msg.Text = ex.Message;
                div_msg.Visible = true;                
            }
            finally
            {
                AddtoRoleCMD.Enabled = true;

            }

        }
        protected void SaveCMD_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        protected void DeleteCMD_Click(object sender, EventArgs e)
        {
           DeleteData();
        }
        private void DeleteData()
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            try
            {
                Conn.Open();
                if (!string.IsNullOrEmpty(UserIDLBL.Text))
                {
                    int iEffected = myUserDAL.DeleteUser(InitializeModule.EnumCampus.ECTNew, int.Parse(UserIDLBL.Text));
                    if (iEffected > 0)
                    {
                        iEffected = myUserDAL.DeleteUsersFromRole(" Where UserNo=" + UserIDLBL.Text, Conn, "");
                        //divMsg.InnerText = "Record Deleted Successfully";
                        lbl_Msg.Text = "Record Deleted Successfully";
                        div_msg.Visible = true;
                        div_Alert.Attributes.Add("class", "alert alert-success alert-dismissible");
                        Initialize_Controls();
                    }
                }
                else
                {
                    //divMsg.InnerText = "No Record Selected !";
                    lbl_Msg.Text = "No Record Selected !";
                    div_msg.Visible = true;                    
                }
            }
            catch (Exception ex)
            {
                LibraryMOD.ShowErrorMessage(ex);
                //divMsg.InnerText = ex.Message;
                lbl_Msg.Text = ex.Message;
                div_msg.Visible = true;                
            }
            finally
            {
                Conn.Close();

            }
        }

        private void Initialize_Controls()
        {
            UserIDLBL.Text = "";
            NameTXT.Text = "";
            PasswordTXT.Text = "";
            ConfirmTXT.Text = "";
            //EmployeeCBO.SelectedValue = "0";
            //LecturerCBO.SelectedValue = "0";
            PTermCBO.SelectedValue = "0";
            MTermCBO.SelectedValue = "0";
            DataStatus.Value = ((int)InitializeModule.enumModes.EditMode).ToString();
            AllowedCampus_ddl.SelectedValue = "-1";
            txtADUserName.Text = "";
            txtGradesPCName.Text = "---";
        }
    }
}