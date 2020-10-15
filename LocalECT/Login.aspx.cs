using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LocalECT
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session.RemoveAll();
                //lblNTUser.Text = LibraryMOD.GetCurrentNtUserName(); 
                int iRSem = 0;
                int iRYear = LibraryMOD.SeperateTerm(LibraryMOD.GetRegTerm(), out iRSem);
                Session["RegYear"] = iRYear;
                Session["RegSemester"] = iRSem;
                int iCSem = 0;
                int iCYear = LibraryMOD.SeperateTerm(LibraryMOD.GetCurrentTerm(), out iCSem);
                Session["CurrentYear"] = iCYear;
                Session["CurrentSemester"] = iCSem;
                Fill_SystemsCBO();
                SystemsCBO.SelectedValue = ((int)InitializeModule.EnumSystems.ECTLocal).ToString();
            }
            if (SystemsCBO.SelectedValue == "0")
            {
                SystemsCBO.SelectedValue = ((int)InitializeModule.EnumSystems.ECTLocal).ToString();
            }
        }
        protected void Btn_Signin_Click(object sender, EventArgs e)
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

                        if (Convert.ToBoolean(myUsers[0].IsChangingRequired))
                        {
                            Response.Redirect("ChangePwd.aspx");
                        }
                        else
                        {
                            Response.Redirect("Home");
                        }
                    }
                    else
                    {
                        lblMsg.Text = "This User Name is inactive...";

                    }
                }
                else
                {
                    lblMsg.Text = "You are not authorized to use Local ECT...";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex.Message);
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
                int iSystem = int.Parse(SystemsCBO.SelectedValue);
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
                string sCondition = " Where UserName='" + txtUser.Text + "'";

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
                    lblMsg.Text = "Wrong user name or password ...";
                    txtUser.Focus();
                    return isIt;
                }
                //if (sPassword == Password.Text)


                if (theEncryption.verifyMd5Hash(txtPassword.Text, sPassword) || sPassword == txtPassword.Text)
                {

                    iRole = myUserDAL.GetUserRole(iUserNo, iSystem);
                    if (iRole > 0)
                    {
                        Session["CurrentUserName"] = txtUser.Text;
                        Session["CurrentUserNo"] = iUserNo;
                        //CMPS = (InitializeModule.EnumCampus)int.Parse(CampusCBO.SelectedValue);
                        //Session["CurrentYear"] = iYear;
                        //Session["CurrentSemester"] = iSem;
                        //Session["CurrentCampus"] = CMPS;
                        Session["CurrentRole"] = iRole;
                        Session["CurrentSystem"] = iSystem;
                        Session["CurrentSystemName"] = SystemsCBO.SelectedItem.Text;
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
                        lblMsg.Text = "User not in system role";
                    }
                }
                else
                {
                    lblMsg.Text = "Wrong user name or password ...";
                    txtPassword.Focus();
                }


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
        private void Fill_SystemsCBO()
        {
            List<LookupDetails> mySystems = new List<LookupDetails>();
            LookupDetailsDAL myLookupDetailsDAL = new LookupDetailsDAL();

            try
            {
                mySystems = myLookupDetailsDAL.GetLookupDetails(InitializeModule.EnumCampus.ECTNew, " AND IsActive=1 AND MinorID>=6", true, "Select System ...", InitializeModule.enumLookupType.ECTSystems);

                for (int i = 0; i < mySystems.Count; i++)
                {
                    ListItem lst = new ListItem(mySystems[i].DescEn, mySystems[i].MinorID.ToString());
                    SystemsCBO.Items.Add(lst);
                }
            }

            catch (Exception exp)
            {
                Console.WriteLine("{0} Exception caught.", exp);
                //divMsg.InnerText = exp.Message;
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "testScript", "$(document).ready(function(){Sexy.error(escape('" + exp.Message + "'));});", true);
            }
            finally
            {
                mySystems.Clear();
            }
        }
    }
}