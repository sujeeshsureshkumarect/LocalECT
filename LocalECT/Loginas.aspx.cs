using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LocalECT
{
    public partial class Loginas : System.Web.UI.Page
    {
        SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["ECTDataMales"].ConnectionString);
        SqlConnection sc1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ECTDataNew"].ConnectionString);
        int CurrentRole = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CurrentRole"] != null)
            {
                CurrentRole = (int)Session["CurrentRole"];
                if (!IsPostBack)
                {
                    //if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_StudentSearch,
                    //InitializeModule.enumPrivilege.ShowBrowse, CurrentRole) != true)
                    //{
                    //    Server.Transfer("Authorization.aspx");
                    //}

                    if(CurrentRole==106|| CurrentRole == 6|| CurrentRole == 31|| CurrentRole == 1 || CurrentRole == 83 || CurrentRole == 172 || CurrentRole == 5 || CurrentRole == 91 || CurrentRole == 104 || CurrentRole == 177)//All System Admin Roles
                    {
                        //Allow
                    }
                    else
                    {
                        Server.Transfer("Authorization.aspx");
                    }

                    bindusers();
                }
            }
            else
            {
                Session.RemoveAll();
                Response.Redirect("Login.aspx");
            }
        }

        public void bindusers()
        {
            SqlCommand cmd = new SqlCommand("SELECT Cmn_User.UserName, Hr_Employee.FirstNameEn+' '+Hr_Employee.FamilyNameEn+'-'+ Cmn_User.UserName as name FROM Cmn_User INNER JOIN Hr_Employee ON Cmn_User.EmployeeID = Hr_Employee.EmployeeID WHERE (Cmn_User.IsActive = 1) AND (Cmn_User.isStudent = 0) order by name", sc1);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc1.Open();
                da.Fill(dt);
                sc1.Close();

                if(dt.Rows.Count>0)
                {
                    drp_Users.DataSource = dt;
                    drp_Users.DataBind();
                    drp_Users.DataTextField = "name";
                    drp_Users.DataValueField = "UserName";
                    drp_Users.DataBind();
                }
            }
            catch(Exception ex)
            {
                sc1.Close();
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sc1.Close();
            }
        }

        protected void btn_Login_Click(object sender, EventArgs e)
        {
            try
            {
                if (isAuthorized())
                {
                    List<User> myUsers = new List<User>();
                    UserDAL myUserDAL = new UserDAL();

                    string sCondition = " Where UserName='" + Session["CurrentUserName"] + "' ";
                    sCondition += " AND UserNo = " + Session["CurrentUserNo"];
                    sCondition += " AND IsActive = " + InitializeModule.TRUE_VALUE;

                    myUsers = myUserDAL.GetUser(InitializeModule.EnumCampus.ECTNew, sCondition, false);


                    int iAdded = add_log(Session["CurrentUserName"].ToString(), Session["CurrentPCName"].ToString(), Session["CurrentNetUserName"].ToString(), Convert.ToInt32(Session["CurrentUserNo"]));

                    if (myUsers.Count > 0)
                    {

                        //if (Convert.ToBoolean(myUsers[0].IsChangingRequired))
                        //{
                        //    Response.Redirect("ChangePwd.aspx");
                        //}
                        //else
                        //{
                            //Response.Redirect("Home");
                            //Added New on 19-05-2021
                            //if (Session["cpage"] != null)
                            //{
                            //    Response.Redirect(Session["cpage"].ToString(), false);
                            //    Context.ApplicationInstance.CompleteRequest(); // end response
                            //}
                            //else
                            //{
                                Response.Redirect("Home", false);
                                Context.ApplicationInstance.CompleteRequest(); // end response
                            //}
                        //}
                    }
                    else
                    {
                       // lblMsg.Text = "This User Name is inactive...";

                    }
                }
                else
                {
                    //lblMsg.Text = "You are not authorized to use " + SystemsCBO.SelectedItem.Text + "...";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex.Message);
            }
        }
        private int add_log(string sUser, string sPCName, string sNtUser, int iUserID)
        {
            int iAdded = 0;

            Connection_StringCLS myConnection_String = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew);
            SqlConnection conn = new SqlConnection(myConnection_String.Conn_string);
            conn.Open();
            try
            {
                string sSQL = "";

                sSQL = "INSERT INTO ECT_User_Log (sUser,dTime,sPCName,sNtUser,iUserID) VALUES ('" + sUser + "',GETDATE(),'" + sPCName + "','" + sNtUser + "'," + iUserID + ")";

                SqlCommand cmd = new SqlCommand(sSQL, conn);

                iAdded = cmd.ExecuteNonQuery();
                return iAdded;
            }
            catch (Exception ex)
            {
                return iAdded;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        private bool isAuthorized()
        {
            bool isIt = false;
            List<User> myUsers = new List<User>();
            List<Applications> myApplication = new List<Applications>();
            UserDAL myUserDAL = new UserDAL();
            InitializeModule.EnumCampus CMPS;
            try
            {
                string sPassword = "";
                int iUserNo = 0;
                int iSystem = int.Parse(Session["CurrentSystem"].ToString());
                int iRole = 0;
                int iLecturer = 0;
                //int iYear = 0;
                //int iSem = 0;
                int iCampus = 0;
                string sName = "";
                string sNo = "";
                int iMarkYear = 0;
                int iMarkSem = 0;

                EncryptionCls theEncryption = new EncryptionCls();
                string sCondition = " Where UserName='" + drp_Users.SelectedItem.Value + "'";

                //string sCondition = " Where UserName='" + theEncryption.getMd5Hash (UserName.Text) + "'";

                myUsers = myUserDAL.GetUser(InitializeModule.EnumCampus.ECTNew, sCondition, false);

                for (int i = 0; i < myUsers.Count; i++)
                {
                    iUserNo = myUsers[i].UserNo;
                    sPassword = myUsers[i].Password;
                    iLecturer = myUsers[i].LecturerID;
                    //iYear = myUsers[i].AcademicYear;
                    //iSem = myUsers[i].Semester;
                    iCampus = myUsers[i].Campus;
                    iMarkYear = myUsers[i].MarksYear;
                    iMarkSem = myUsers[i].MarksSemester;
                    Session["EmployeeID"] = myUsers[i].EmployeeID;
                }
                if (iUserNo == 0)
                {
                    //lblMsg.Text = "Wrong user name or password ...";
                    //txtUser.Focus();
                    return isIt;
                }
                //if (sPassword == Password.Text)


                //if (theEncryption.verifyMd5Hash(txtPassword.Text, sPassword) || sPassword == txtPassword.Text)
                //{

                    iRole = myUserDAL.GetUserRole(iUserNo, iSystem);
                    if (iRole > 0)
                    {
                        Session["CurrentUserName"] = drp_Users.SelectedItem.Value;
                        Session["CurrentUserNo"] = iUserNo;
                        //CMPS = (InitializeModule.EnumCampus)int.Parse(CampusCBO.SelectedValue);
                        //Session["CurrentYear"] = iYear;
                        //Session["CurrentSemester"] = iSem;
                        //Session["CurrentCampus"] = CMPS;
                        Session["CurrentRole"] = iRole;
                        Session["CurrentSystem"] = iSystem;
                        Session["CurrentSystemName"] = Session["CurrentSystemName"].ToString();
                        Session["CurrentLecturer"] = iLecturer;
                        Session["MarkYear"] = iMarkYear;
                        Session["MarkSemester"] = iMarkSem;

                        //server name
                        Session["CurrentPCName"] = LibraryMOD.GetComputerName(Request.UserHostAddress);
                        Session["CurrentNetUserName"] = LibraryMOD.GetCurrentNtUserName();
                        //string sPc = HttpContext.Current.Request.UserHostName;
                        //if (Session["CurrentNetUserName"].ToString()==""  )
                        //{
                        //    Session["CurrentNetUserName"] = "" + WindowsIdentity.GetCurrent().Name;
                        //}


                        //string[] computer_name = System.Net.Dns.GetHostEntry(Request.ServerVariables["remote_addr"]).HostName.Split(new Char[] { '.' });
                        //String ecn = System.Environment.MachineName;

                        if (iRole == 105 || iRole == 111)
                        {
                            Student_SearchDAL mySearch = new Student_SearchDAL();

                            //Student not allowed to use localect any more 20042020
                            sNo = LibraryMOD.GetSIDFromUser((InitializeModule.EnumCampus)iCampus, iUserNo);
                            bool isEnable = false; //Enable_Disable(sNo, (InitializeModule.EnumCampus)iCampus);
                            if (!isEnable)
                            {
                                return false;
                            }

                            sName = mySearch.Sync_Students_No((InitializeModule.EnumCampus)iCampus, sNo);
                            CMPS = (InitializeModule.EnumCampus)iCampus;
                            Session["CurrentCampus"] = CMPS;
                            Session["CurrentStudent"] = sNo;
                            Session["CurrentStudentName"] = sName;
                            Session["CurrentYear"] = Session["RegYear"];
                            Session["CurrentSemester"] = Session["RegSemester"];
                            int iCurrentMajorCampus = LibraryMOD.GetCurrentStCampus(sNo, (InitializeModule.EnumCampus)iCampus);
                            Session["CurrentMajorCampus"] = iCurrentMajorCampus;

                        }

                        isIt = true;
                        //if (iUserNo == 1)
                        //{
                        //    divMsg.InnerText = "netuser= " + Session["CurrentNetUserName"].ToString();
                        //    divMsg.InnerText += "  ecn= " + ecn;
                        //    divMsg.InnerText += "  pc= " + Session["CurrentPCName"];
                        //    isIt = false;

                        //}
                    }
                    else
                    {
                        //lblMsg.Text = "User not in system role";
                    }
                //}
                //else
                //{
                //    lblMsg.Text = "Wrong user name or password ...";
                //    txtPassword.Focus();
                //}


            }
            catch (Exception exp)
            {
                Console.WriteLine("{0} Exception caught.", exp);
                //divMsg.InnerText = exp.Message;
            }
            finally
            {
                myUsers.Clear();
                myApplication.Clear();
            }
            return isIt;
        }
    }
}