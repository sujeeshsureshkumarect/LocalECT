using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LocalECT
{
    public partial class Bulk_Acc_BlockUnBlock : System.Web.UI.Page
    {
        InitializeModule.EnumCampus Campus = InitializeModule.EnumCampus.Females;
        string constr = ConfigurationManager.ConnectionStrings["ECTDataFemales"].ConnectionString;
        int CurrentRole = 0;
        int iCYear = 0;
        int iCSem = 0;
        int iTerm = 0;       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CurrentRole"] != null)
            {
                CurrentRole = (int)Session["CurrentRole"];
                if (Session["CurrentCampus"].ToString() == "Males")
                {
                    Campus = InitializeModule.EnumCampus.Males;
                }
                else
                {
                    Campus = InitializeModule.EnumCampus.Females;
                }
                if (!IsPostBack)
                {
                    if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.AccBlockUnBlock,
                        InitializeModule.enumPrivilege.BlockUnblockAccounts, CurrentRole) != true)
                    {
                        Server.Transfer("Authorization.aspx");
                    }

                    FillTerms();
                    
                    iCYear = Convert.ToInt32(Session["CurrentYear"].ToString());
                    iCSem = Convert.ToInt32(Session["CurrentSemester"].ToString()); ;
                    iTerm = iCYear * 10 + iCSem;

                    if (Session["sids"] != null)
                    {
                        string value = Session["sids"].ToString();
                        lnk_Settings.Visible = true;
                        stringsids(value);                        
                    }                    
                }
            }
            else
            {
                Session.RemoveAll();
                Response.Redirect("Login.aspx");
            }
        }
        public void stringsids(string sIDs)
        {
            int iLen = sIDs.Length;
            string sLast = sIDs.Substring(iLen - 1, 1);
            if (sLast == ",")
            {
                sIDs = sIDs.Remove(iLen - 1, 1);
            }
            string s = sIDs;
            string[] uniqueItems = s.Split(',');
                      

            IEnumerable<string> splittedArray = uniqueItems.Distinct<string>();          
            alertsearch.Visible = true;
            lbl_IDs.Text = splittedArray.Count().ToString() + " records selected for Bulk Action";
        }
        private void FillTerms()
        {
            List<Semesters> myTerms = new List<Semesters>();
            SemesterDAL myTermsDAL = new SemesterDAL();
            try
            {
                myTerms = myTermsDAL.GetTerms(InitializeModule.EnumCampus.ECTNew, "", false);
                for (int i = 0; i < myTerms.Count; i++)
                {
                    ddlRegTerm.Items.Add(new ListItem(myTerms[i].ShortDesc, myTerms[i].Term.ToString()));                    
                }
                ddlRegTerm.Items.Insert(0, new ListItem("Unspecified", "0"));
                int iYear = 0;
                int iSem = 0;
                int iTerm = 0;
                iYear = (int)Session["RegYear"];
                iSem = (int)Session["RegSemester"];
                iTerm = iYear * 10 + iSem;
                ddlRegTerm.SelectedValue = iTerm.ToString();
            }
            catch (Exception ex)
            {
                LibraryMOD.ShowErrorMessage(ex);
                //divMsg.InnerText = ex.Message;
            }
            finally
            {
                myTerms.Clear();
            }
        }
        protected void lnk_Settings_Click(object sender, EventArgs e)
        {            
            if (Session["sids"] != null)
            {
                string sIDs = Session["sids"].ToString();
                int iLen = sIDs.Length;
                string sLast = sIDs.Substring(iLen - 1, 1);
                if (sLast == ",")
                {
                    sIDs = sIDs.Remove(iLen - 1, 1);
                }
                string s = sIDs;
                string[] uniqueItems = s.Split(',');

                DataTable dt = new DataTable("sIDs");
                dt.Columns.Add("sID");
                foreach (string value in uniqueItems)
                {
                    dt.Rows.Add(value);
                }

                if(dt.Rows.Count>0)
                {
                    int iEffected = 0;
                    for(int i=0;i<dt.Rows.Count;i++)
                    {
                        string SNo = dt.Rows[i]["sID"].ToString();
                        string sAcc = "0";

                        Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
                        SqlConnection sc = new SqlConnection(myConnection_String.Conn_string);
                        SqlCommand cmd1 = new SqlCommand("SELECT AC.strAccountNo FROM Reg_Applications AS A INNER JOIN Reg_Student_Accounts AS AC ON A.lngStudentNumber = AC.lngStudentNumber Where A.lngStudentNumber=@lngStudentNumber", sc);
                        cmd1.Parameters.AddWithValue("@lngStudentNumber", SNo);
                        DataTable dt1 = new DataTable();
                        SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                        try
                        {
                            sc.Open();
                            da1.Fill(dt1);
                            sc.Close();

                            if(dt1.Rows.Count>0)
                            {
                                sAcc = dt1.Rows[0]["strAccountNo"].ToString();
                                if(sAcc!="0")
                                {
                                    if (chk_Enable1.Checked == true)
                                    {
                                        ddlOnlineStatus_SelectedIndexChanged(SNo, sAcc);//string sNo,string ACC
                                    }
                                    if (chk_Enable2.Checked == true)
                                    {
                                        ddlFinanceCat_SelectedIndexChanged(SNo);//string sNo
                                    }
                                    if (chk_Enable3.Checked == true)
                                    {
                                        ddlACCWanted_SelectedIndexChanged(SNo);//string sNo
                                    }
                                    if (chk_Enable4.Checked == true)
                                    {
                                        ddlRegTerm1_SelectedIndexChanged(sAcc);//string sAcc
                                    }
                                    iEffected++;
                                }                               
                            }
                        }
                        catch(Exception ex)
                        {
                            sc.Close();
                            Console.WriteLine(ex.Message);
                        }
                        finally
                        {
                            sc.Close();
                        }                        
                    }
                    if (Session["sids"] != null)
                    {
                        Session["sids"] = null;
                    }
                    lbl_Msg.Text = "Bulk Operation (Block/Unblock) Completed Successfully-Updated " + iEffected + " students.";
                    div_Alert.Attributes.Add("class", "alert alert-success alert-dismissible");
                    div_msg.Visible = true;
                    lnk_Settings.Visible = false;
                }
            }            
        }

        protected void lnk_Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Acc_Search");
        }
      
        protected void ddlOnlineStatus_SelectedIndexChanged(string sNo,string ACC)
        {
            try
            {
                if (string.IsNullOrEmpty(sNo))
                {
                    lbl_Msg.Text = "Select a student please or the students hasn't account yet.";
                    div_msg.Visible = true;
                    return;
                }
                int iStatus = 0;
                
                iStatus = ddlOnlineStatus.SelectedIndex;
                string sACC = ACC;//getStAcc(sSelectedValue.Value);
                UpdateStAcc(sNo, sACC, iStatus);
            }
            catch (Exception exp)
            {
                Console.WriteLine("{0} Exception caught.", exp);
                //divMsg.InnerText = exp.Message;
            }
            finally
            {

            }
        }
        private void UpdateStAcc(string sSno, string sAcc, int iStatus)
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            try
            {
                string sSQL = "";
                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                int iOnlineUser = getOnlineUser(sSno);
                if (iStatus == 0)
                {

                    Cmd.CommandText = "Delete_Online_User";
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.Add("@UserNo", SqlDbType.Int).Value = iOnlineUser;
                    Cmd.Parameters.Add("@sNo", SqlDbType.VarChar).Value = sSno;
                    Cmd.Parameters.Add("@sAccount", SqlDbType.VarChar).Value = sAcc;
                    Conn.Open();
                    Cmd.ExecuteNonQuery();
                    Conn.Close();
                }

                if (iStatus == 1)
                {
                    Cmd.CommandText = "Create_Online_User";
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.Add("@sNo", SqlDbType.VarChar).Value = sSno;
                    Cmd.Parameters.Add("@sAccount", SqlDbType.VarChar).Value = sAcc;
                    Cmd.Parameters.Add("@iRole", SqlDbType.Int).Value = 111;
                    Conn.Open();
                    Cmd.ExecuteNonQuery();
                    Conn.Close();
                }

                if (iStatus == 2)
                {
                    Cmd.CommandText = "Create_Online_User";
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.Add("@sNo", SqlDbType.VarChar).Value = sSno;
                    Cmd.Parameters.Add("@sAccount", SqlDbType.VarChar).Value = sAcc;
                    Cmd.Parameters.Add("@iRole", SqlDbType.Int).Value = 105;
                    Conn.Open();
                    Cmd.ExecuteNonQuery();
                    Conn.Close();
                }

                sSQL = "UPDATE Reg_Student_Accounts";
                sSQL += " SET intOnlineStatus =" + iStatus;
                sSQL += ",strUserSave='" + Session["CurrentUserName"].ToString() + "',dateLastSave=getDate()";
                sSQL += " Where strAccountNo='" + sAcc + "'";
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = sSQL;
                Conn.Open();
                Cmd.ExecuteNonQuery();
                Conn.Close();

                //lbl_Msg.Text = "Online Status updated successfully";
                //div_Alert.Attributes.Add("class", "alert alert-success alert-dismissible");
                //div_msg.Visible = true;


            }
            catch (Exception exp)
            {
                Console.WriteLine("{0} Exception caught.", exp);                
                //lbl_Msg.Text = "Online Status not updated";
                //div_msg.Visible = true;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }

        }
        private int getOnlineUser(string sNo)
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            Conn.Open();
            int iOnlineUser = 0;
            try
            {
                string sSQL = "SELECT intOnlineUser FROM Reg_Student_Accounts  WHERE [lngStudentNumber]='" + sNo + "'";
                SqlCommand Cmd = new SqlCommand(sSQL, Conn);
                iOnlineUser = Convert.ToInt32("0" + Cmd.ExecuteScalar().ToString());

            }
            catch (Exception exp)
            {
                Console.WriteLine("{0} Exception caught.", exp);
                //divMsg.InnerText = exp.Message;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }
            return iOnlineUser;

        }
        protected void ddlFinanceCat_SelectedIndexChanged(string sNo)
        {
            string sUser = Session["CurrentUserName"].ToString();
            int iFinCat = 1;

            if (ddlFinanceCat.SelectedValue != "1")
            {
                iCYear = Convert.ToInt32(Session["CurrentYear"].ToString());
                iCSem = Convert.ToInt32(Session["CurrentSemester"].ToString()); ;
                iTerm = iCYear * 10 + iCSem;
                int MaxHrs = 18;
                if (iCSem == 3 || iCSem == 4)
                {
                    MaxHrs = 9;
                }
                Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
                SqlConnection sc = new SqlConnection(myConnection_String.Conn_string);
                SqlCommand cmd = new SqlCommand("SELECT [dbo].[GetFinanceCategory] (@iCYear,@iCSem,@sNo,@MaxHrs) as Fincat", sc);
                cmd.Parameters.AddWithValue("@iCYear", iCYear);
                cmd.Parameters.AddWithValue("@iCSem", iCSem);
                cmd.Parameters.AddWithValue("@sNo", sNo);
                cmd.Parameters.AddWithValue("@MaxHrs", MaxHrs);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                try
                {
                    sc.Open();
                    da.Fill(dt);
                    sc.Close();

                    if (dt.Rows.Count > 0)
                    {
                        iFinCat = Convert.ToInt32(dt.Rows[0]["Fincat"]);
                    }
                }
                catch (Exception ex)
                {
                    sc.Close();
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    sc.Close();
                }
            }
            else
            {
                iFinCat = 1;
            }

            int iEffected = LibraryMOD.UpdateFinanceCategory(sNo, iFinCat, sUser);
            if (iEffected > 0)
            {
                //lbl_Msg.Text = "Finance category updated to (" + ddlFinanceCat.SelectedItem.Text + ")";
                //div_Alert.Attributes.Add("class", "alert alert-success alert-dismissible");
                //div_msg.Visible = true;
            }
        }
        protected void ddlACCWanted_SelectedIndexChanged(string sNo)
        {
            try
            {
                if (string.IsNullOrEmpty(sNo))
                {
                    lbl_Msg.Text = "Select a student please or the students hasn't account yet.";
                    div_msg.Visible = true;
                    return;
                }
                bool bStatus = false;
               
                bStatus = Convert.ToBoolean(ddlACCWanted.SelectedIndex);
                //string sNo = ddlIDs.Text;//getStAcc(sSelectedValue.Value);
                UpdateStACCWanted(sNo, ddlACCWanted.SelectedIndex);
            }
            catch (Exception exp)
            {
                Console.WriteLine("{0} Exception caught.", exp);
                //divMsg.InnerText = exp.Message;
            }
            finally
            {

            }
        }
        private void UpdateStACCWanted(string sSno, int iStatus)
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            Conn.Open();
            try
            {
                string sSQL = "";
                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = Conn;


                //     ,[isACCWanted] = 

                sSQL = "UPDATE Reg_Applications";
                sSQL += " SET isACCWanted = " + iStatus;
                sSQL += ",strUserSave='" + Session["CurrentUserName"].ToString() + "',dateLastSave=getDate(),strMachine='localect',strNUser='" + Session["CurrentUserName"].ToString() + "'";
                sSQL += " WHERE lngStudentNumber='" + sSno + "'";
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = sSQL;
                Cmd.ExecuteNonQuery();

                //lbl_Msg.Text = "Is Acc Wanted? updated successfully";
                //div_Alert.Attributes.Add("class", "alert alert-success alert-dismissible");
                //div_msg.Visible = true;

            }
            catch (Exception exp)
            {
                Console.WriteLine("{0} Exception caught.", exp);
                //lbl_Msg.Text = "Is Acc Wanted? not updated";
                //div_msg.Visible = true;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }

        }
        protected void ddlRegTerm1_SelectedIndexChanged(string sAcc)
        {
            try
            {
                if (string.IsNullOrEmpty(sAcc))
                {
                    lbl_Msg.Text = "Select a student please or the students hasn't account yet.";
                    div_msg.Visible = true;
                }
                int iTerm = 0;              
                iTerm = int.Parse(ddlRegTerm.SelectedValue);
                string sAccount = sAcc;//getStAcc(sSelectedValue.Value);
                UpdateRegTerm(sAccount, iTerm);
            }
            catch (Exception exp)
            {
                Console.WriteLine("{0} Exception caught.", exp);
                //divMsg.InnerText = exp.Message;
            }
            finally
            {

            }
        }

        private void UpdateRegTerm(string sAccount, int iTerm)
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            Conn.Open();
            try
            {
                string sSQL = "";
                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                int iYear = 0;
                int iSem = 0;
                iYear = LibraryMOD.SeperateTerm(iTerm, out iSem);


                sSQL = "UPDATE Reg_Student_Accounts";
                sSQL += " SET intRegYear =" + iYear + " , byteRegSem =" + iSem;
                sSQL += ",strUserSave='" + Session["CurrentUserName"].ToString() + "',dateLastSave=getDate(),strMachine='localect',strNUser='" + Session["CurrentUserName"].ToString() + "'";
                sSQL += " WHERE strAccountNo='" + sAccount + "'";

                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = sSQL;
                Cmd.ExecuteNonQuery();
                //ddlRegTerm.SelectedValue = ddlRegTerm.SelectedValue;
                //lbl_Msg.Text = "Reg Term updated successfully";
                //div_Alert.Attributes.Add("class", "alert alert-success alert-dismissible");
                //div_msg.Visible = true;
            }
            catch (Exception exp)
            {
                Console.WriteLine("{0} Exception caught.", exp);
                //lbl_Msg.Text = "Reg Term not updated";
                //div_msg.Visible = true;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }

        }
    }
}