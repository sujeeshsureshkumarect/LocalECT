using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;

namespace LocalECT
{
    public partial class StudentSearch : System.Web.UI.Page
    {
        InitializeModule.EnumCampus Campus = InitializeModule.EnumCampus.Females;
        string constr = ConfigurationManager.ConnectionStrings["ECTDataFemales"].ConnectionString;
        int iCYear = 0;
        int iCSem = 0;
        int iTerm = 0;
        int CurrentRole = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CurrentRole"] != null)
            {
                CurrentRole = (int)Session["CurrentRole"];
                if (!IsPostBack)
                {
                    if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_StudentSearch,
                    InitializeModule.enumPrivilege.ShowBrowse, CurrentRole) != true)
                    {
                        Server.Transfer("Authorization.aspx");
                    }

                    if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Student_Data,
                        InitializeModule.enumPrivilege.AddNew, CurrentRole) != true)
                    {
                        lnk_add.Visible = false;
                    }
                    else
                    {
                        lnk_add.Visible = true;
                    }

                    if(Session["studenttable"]!=null)
                    {
                        DataTable dt1 = (DataTable)Session["studenttable"];
                        RepterDetails.DataSource = dt1;
                        RepterDetails.DataBind();
                    }
                }
            }
            else
            {
                Session.RemoveAll();
                Response.Redirect("Login.aspx");
            }
        }

        protected void lnk_Search_Click(object sender, EventArgs e)
        {
            String sqlcomd = "";
            string sqlcont = "";
            if (drp_Campus.SelectedItem.Text == "Males")
            {
                constr = ConfigurationManager.ConnectionStrings["ECTDataMales"].ConnectionString;
                //sqlcomd = "SELECT  dbo.Reg_Applications.lngStudentNumber, dbo.Reg_Students_Data.strLastDescEn, dbo.Reg_Specializations.strCaption, dbo.Reg_Students_Data.sECTemail, dbo.Reg_Students_Data.dateCreate, dbo.Reg_Applications.byteCancelReason, dbo.Lkp_Reasons.strReasonDesc FROM            dbo.Reg_Applications INNER JOIN dbo.Reg_Students_Data ON dbo.Reg_Applications.lngSerial = dbo.Reg_Students_Data.lngSerial INNER JOIN dbo.Reg_Specializations ON dbo.Reg_Applications.strCollege = dbo.Reg_Specializations.strCollege AND dbo.Reg_Applications.strDegree = dbo.Reg_Specializations.strDegree AND dbo.Reg_Applications.strSpecialization = dbo.Reg_Specializations.strSpecialization LEFT OUTER JOIN dbo.Lkp_Reasons ON dbo.Reg_Applications.byteCancelReason = dbo.Lkp_Reasons.byteReason WHERE (dbo.Reg_Students_Data.byteShift = 3 OR dbo.Reg_Students_Data.byteShift = 4 OR dbo.Reg_Students_Data.byteShift = 8) AND";
                //sqlcomd = "SELECT sNo, sName, sAccount, sPhone1, ECTEmail,iSerial FROM Web_Students_Search where";
                sqlcomd = "SELECT Web_Students_Search.sAccount,Web_Students_Search.LTR,Web_Students_Search.Status,Web_Students_Search.sNo, Web_Students_Search.iSerial, Web_Students_Search.sName, Web_Students_Search.sAccount, Web_Students_Search.sPhone1, Web_Students_Search.sPhone2, Web_Students_Search.bShift, Web_Students_Search.sCollege, Web_Students_Search.sDegree, Web_Students_Search.sMajor, Web_Students_Search.iYear, Web_Students_Search.bSemester, Web_Students_Search.bType, Web_Students_Search.UID, Web_Students_Search.ECTEmail, Reg_Specializations.strCaption FROM Web_Students_Search INNER JOIN Reg_Specializations ON Web_Students_Search.sCollege = Reg_Specializations.strCollege AND Web_Students_Search.sDegree = Reg_Specializations.strDegree AND Web_Students_Search.sMajor = Reg_Specializations.strSpecialization where ";
                Campus = (InitializeModule.EnumCampus)int.Parse(drp_Campus.SelectedItem.Value);
            }
            else
            {
                constr = ConfigurationManager.ConnectionStrings["ECTDataFemales"].ConnectionString;
                //sqlcomd = "SELECT  dbo.Reg_Applications.lngStudentNumber, dbo.Reg_Students_Data.strLastDescEn, dbo.Reg_Specializations.strCaption, dbo.Reg_Students_Data.sECTemail, dbo.Reg_Students_Data.dateCreate, dbo.Reg_Applications.byteCancelReason, dbo.Lkp_Reasons.strReasonDesc FROM            dbo.Reg_Applications INNER JOIN dbo.Reg_Students_Data ON dbo.Reg_Applications.lngSerial = dbo.Reg_Students_Data.lngSerial INNER JOIN dbo.Reg_Specializations ON dbo.Reg_Applications.strCollege = dbo.Reg_Specializations.strCollege AND dbo.Reg_Applications.strDegree = dbo.Reg_Specializations.strDegree AND dbo.Reg_Applications.strSpecialization = dbo.Reg_Specializations.strSpecialization LEFT OUTER JOIN dbo.Lkp_Reasons ON dbo.Reg_Applications.byteCancelReason = dbo.Lkp_Reasons.byteReason WHERE (dbo.Reg_Students_Data.byteShift = 1 OR dbo.Reg_Students_Data.byteShift = 2 OR dbo.Reg_Students_Data.byteShift = 9) AND";
                //sqlcomd = "SELECT sNo, sName, sAccount, sPhone1, ECTEmail,iSerial FROM Web_Students_Search where ";
                sqlcomd = "SELECT Web_Students_Search.sAccount,Web_Students_Search.LTR,Web_Students_Search.Status,Web_Students_Search.sNo, Web_Students_Search.iSerial, Web_Students_Search.sName, Web_Students_Search.sAccount, Web_Students_Search.sPhone1, Web_Students_Search.sPhone2, Web_Students_Search.bShift, Web_Students_Search.sCollege, Web_Students_Search.sDegree, Web_Students_Search.sMajor, Web_Students_Search.iYear, Web_Students_Search.bSemester, Web_Students_Search.bType, Web_Students_Search.UID, Web_Students_Search.ECTEmail, Reg_Specializations.strCaption FROM Web_Students_Search INNER JOIN Reg_Specializations ON Web_Students_Search.sCollege = Reg_Specializations.strCollege AND Web_Students_Search.sDegree = Reg_Specializations.strDegree AND Web_Students_Search.sMajor = Reg_Specializations.strSpecialization where ";
                Campus = (InitializeModule.EnumCampus)int.Parse(drp_Campus.SelectedItem.Value);
            }
            Session["CurrentCampus"] = Campus;

            string sIDsCon = "";
            if (drp_Type.SelectedItem.Text=="Like")
            {
                string sIDs = txt_Search.Text.Replace("\r\n", ";");
                int iLen = sIDs.Length;
                string sLast = sIDs.Substring(iLen - 1, 1);
                if (sLast == ";")
                {
                    sIDs = sIDs.Remove(iLen - 1, 1);
                }
                sIDsCon = "";
                if (drp_Criteria.SelectedItem.Text == "Student ID")
                {
                    //sqlcont = "sNo like '%" + txt_Search.Text + "%'";
                    sIDsCon=getIDsCondition(sIDs,"sNo");
                }
                else if (drp_Criteria.SelectedItem.Text == "Student Name")
                {
                    //sqlcont = "sName like '%" + txt_Search.Text + "%'";
                    sIDsCon=getIDsCondition(sIDs, "sName");
                }
                else if (drp_Criteria.SelectedItem.Text == "Phone Number")
                {
                    // sqlcont = "(sPhone1 like '%" + txt_Search.Text + "%' OR sPhone2 like '%" + txt_Search.Text + "%')";
                    sIDsCon=getIDsCondition(sIDs, "sPhone1");
                    string sIDsCon1 = getIDsCondition(sIDs, "sPhone2");

                    sIDsCon = sIDsCon + " OR " + sIDsCon1;
                }
                else if (drp_Criteria.SelectedItem.Text == "Student Account Number")
                {
                    //sqlcont = "sAccount like '%" + txt_Search.Text + "%'";
                    sIDsCon = getIDsCondition(sIDs, "sAccount");
                }
                else if (drp_Criteria.SelectedItem.Text == "ECT Email")
                {
                    //sqlcont = "ECTEmail like '%" + txt_Search.Text + "%'";
                    sIDsCon = getIDsCondition(sIDs, "ECTEmail");
                }
                else if (drp_Criteria.SelectedItem.Text == "Major Name")
                {
                    //sqlcont = "strCaption like '%" + txt_Search.Text + "%'";
                    sIDsCon = getIDsCondition(sIDs, "strCaption");
                }
                else if (drp_Criteria.SelectedItem.Text == "LTR")
                {
                    //sqlcont = "strCaption like '%" + txt_Search.Text + "%'";
                    sIDsCon = getIDsCondition(sIDs, "LTR");
                }
                else if (drp_Criteria.SelectedItem.Text == "Status")
                {
                    //sqlcont = "strCaption like '%" + txt_Search.Text + "%'";
                    sIDsCon = getIDsCondition(sIDs, "Status");
                }
            }
            else
            {
                string sIDs = txt_Search.Text.Replace("\r\n", ",");
                int iLen = sIDs.Length;
                string sLast = sIDs.Substring(iLen - 1, 1);
                if (sLast == ",")
                {
                    sIDs = sIDs.Remove(iLen - 1, 1);
                }
                string s = sIDs;
                sIDs = "'" + s.Replace(",", "','") + "'";
                sIDsCon = "";
                if (drp_Criteria.SelectedItem.Text == "Student ID")
                {
                    sIDsCon = "sNo in ("+ sIDs + ")";
                }
                else if (drp_Criteria.SelectedItem.Text == "Student Name")
                {
                    sIDsCon = "sName in (" + sIDs + ")";
                }
                else if (drp_Criteria.SelectedItem.Text == "Phone Number")
                {
                    sIDsCon = "(sPhone1 in (" + sIDs + ") OR sPhone2 in (" + sIDs + "))";
                }
                else if (drp_Criteria.SelectedItem.Text == "Student Account Number")
                {
                    sIDsCon = "sAccount in (" + sIDs + ")";
                }
                else if (drp_Criteria.SelectedItem.Text == "ECT Email")
                {
                    sIDsCon = "ECTEmail in (" + sIDs + ")";
                }
                else if (drp_Criteria.SelectedItem.Text == "Major Name")
                {
                    sIDsCon = "strCaption in (" + sIDs + ")";
                }
                else if (drp_Criteria.SelectedItem.Text == "LTR")
                {
                    sIDsCon = "LTR in (" + sIDs + ")";
                }
                else if (drp_Criteria.SelectedItem.Text == "Status")
                {
                    sIDsCon = "Status in (" + sIDs + ")";
                }
            }
            
            SqlConnection sc = new SqlConnection(constr);
            //SqlCommand cmd = new SqlCommand(sqlcomd + " " + sqlcont+ " ORDER BY dbo.Reg_Students_Data.strLastDescEn ASC, dbo.Reg_Students_Data.dateCreate DESC", sc);
            SqlCommand cmd = new SqlCommand(sqlcomd + " " + sIDsCon + " ORDER BY sName asc", sc);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();


                Session["studenttable"]= dt;
                RepterDetails.DataSource = dt;
                RepterDetails.DataBind();

                alertsearch.Visible = true;
                lbl_Count.Text = dt.Rows.Count.ToString() + " entry(s) found.";

            }
            catch(Exception ex)
            {
                sc.Close();
                throw ex;
            }
            finally
            {
                sc.Close();
            }
        }
        private string getIDsCondition(string sIDs,string columnname)
        {
            string sCon = " (";
            try
            {
                string[] sSeperated;
                sSeperated = sIDs.Split(';');
                int iCount = sSeperated.Length;

                foreach (string sID in sSeperated)
                {
                    sCon += " "+ columnname + " like '%" + sID + "%'";
                    iCount -= 1;
                    if (iCount > 0)
                    {
                        sCon += " Or";
                    }
                    else
                    {
                        sCon += ")";
                    }
                }
            }
            catch (Exception exp)
            {
                //Console.WriteLine("{0} Exception caught.", exp);
                //divMsg.InnerText = exp.Message;
            }
            finally
            {

            }

            return sCon;
        }      
        protected void lnk_add_Click(object sender, EventArgs e)
        {
            Campus = (InitializeModule.EnumCampus)int.Parse(drp_Campus.SelectedItem.Value);
            Session["CurrentCampus"] = Campus;
            //if (drp_Campus.SelectedItem.Text=="Males")
            //{
            Response.Redirect("Student_Profile.aspx");
            //}
            //else
            //{
            //    Response.Redirect("Student_Profile.aspx");
            //}
        }     
        protected void lnk_Execute_Click(object sender, EventArgs e)
        {
            string sids = hdn_Selected_Sids.Value;
            Session["sids"] = sids;
            if(drp_Bulk.SelectedItem.Text== "Change Status")
            {
                Response.Redirect(drp_Bulk.SelectedItem.Value);
            }
            else
            {

            }
        }

        protected void lnk_Transcript_Menu_Click(object sender, EventArgs e)
        {
            //Get the reference of the clicked button.
            LinkButton button = (sender as LinkButton);

            //Get the command argument
            string commandArgument = button.CommandArgument;
            string CommandName = button.CommandName;

            if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Advising,
                    InitializeModule.enumPrivilege.ShowBrowse, CurrentRole) != true)
            {
                //divMsg.InnerText = "Sorry you dont have a permissions to print the transcript";
                //lbl_Msg.Text = "Sorry you dont have a permissions to print the transcript";
                //div_msg.Visible = true;
                Server.Transfer("Authorization.aspx");
                //return;

            }
            int iYear = 0;
            int iSem = 0;
            int iPrevYear = 0;
            byte bPrevSemester = 0;
            int iTerm = LibraryMOD.GetCurrentTerm();
            iYear = LibraryMOD.SeperateTerm(int.Parse(iTerm.ToString()), out iSem);

            if (iSem == 1)
            {
                bPrevSemester = 4;
                iPrevYear = iYear - 1;
            }
            else
            {
                bPrevSemester = byte.Parse((iSem - 1).ToString());
                iPrevYear = iYear;
            }

            int iPrevTerm = (iPrevYear * 10) + bPrevSemester;

            //Open transcript page

            Session["CurrentStudent"] = commandArgument;
            Session["CurrentStudentName"] = CommandName;

            Response.Redirect("Transcript.aspx?PreviousTerm=" + iPrevTerm);
        }
        private string Get_New_Acc()
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS((InitializeModule.EnumCampus)Session["CurrentCampus"]);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            Conn.Open();
            string sNewAcc = "";
            try
            {

                string sSQL = "SELECT sNewACC FROM New_ACC";
                SqlCommand Cmd = new SqlCommand(sSQL, Conn);

                sNewAcc = Cmd.ExecuteScalar().ToString();

            }
            catch (Exception exp)
            {
                //Console.WriteLine("{0} Exception caught.", exp);
                //divMsg.InnerText = exp.Message;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }
            return sNewAcc;
        }
        protected void lnk_Create_ACC_Click(object sender, EventArgs e)
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS((InitializeModule.EnumCampus)Session["CurrentCampus"]);
            SqlConnection sc = new SqlConnection(myConnection_String.Conn_string);
            //Get the reference of the clicked button.
            LinkButton button = (sender as LinkButton);

            //Get the command argument
            string commandArgument = button.CommandArgument;//lngStudentNumber
            string CommandName = button.CommandName;//sName
            string sPhone1 = button.ValidationGroup;
            if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_StudentSearch,
                    InitializeModule.enumPrivilege.CreateAccount, CurrentRole) != true)
            {
                Server.Transfer("Authorization.aspx");
            }
            //Get Account Number
            SqlCommand cmd = new SqlCommand("SELECT A.lngStudentNumber, AC.strAccountNo FROM Reg_Applications AS A INNER JOIN Reg_Student_Accounts AS AC ON A.lngStudentNumber = AC.lngStudentNumber where A.lngStudentNumber=@lngStudentNumber;SELECT A.lngStudentNumber, AC.strAccountNo FROM Reg_Applications AS A INNER JOIN Reg_Student_Accounts AS AC ON A.lngStudentNumber = AC.lngStudentNumber where A.lngStudentNumber in (select sReference from Reg_Applications where lngStudentNumber=@lngStudentNumber)", sc);
            cmd.Parameters.AddWithValue("@lngStudentNumber", commandArgument);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(ds);
                sc.Close();

                if (ds.Tables[0].Rows.Count > 0) //If Student has Account Number
                {
                    //No Actions
                    Response.Write("<script>alert('Student already has an account (# "+ ds.Tables[0].Rows[0]["strAccountNo"].ToString() + ").');</script>");
                    return;
                }
                else if (ds.Tables[1].Rows.Count > 0)
                {
                    //If Reference has Account Number
                    //Then update it.
                    string sAcc = ds.Tables[1].Rows[0]["strAccountNo"].ToString();

                    SqlCommand cmd1 = new SqlCommand("update Reg_Student_Accounts set lngStudentNumber=@lngStudentNumbernew,intRegYear=@intRegYear,byteRegSem=@byteRegSem,strUserSave=@strUserSave,dateLastSave=@dateLastSave where strAccountNo=@strAccountNo", sc);
                    cmd1.Parameters.AddWithValue("@strAccountNo", sAcc);
                    cmd1.Parameters.AddWithValue("@lngStudentNumbernew", commandArgument);                    
                    cmd1.Parameters.AddWithValue("@intRegYear", Convert.ToInt32(Session["CurrentYear"]));
                    cmd1.Parameters.AddWithValue("@byteRegSem", Session["CurrentSemester"].ToString());
                    cmd1.Parameters.AddWithValue("@strUserSave", Session["CurrentUserName"].ToString());
                    cmd1.Parameters.AddWithValue("@dateLastSave", DateTime.Now);
                    try
                    {
                        sc.Open();                        
                        cmd1.ExecuteNonQuery();
                        sc.Close();


                        SqlCommand cmd11 = new SqlCommand("UPDATE Reg_Applications SET strAccountNo= AC.strAccountNo FROM Reg_Applications INNER JOIN Reg_Student_Accounts AS AC ON Reg_Applications.lngStudentNumber = AC.lngStudentNumber where Reg_Applications.lngStudentNumber=@lngStudentNumber", sc);
                        cmd11.Parameters.AddWithValue("@lngStudentNumber", commandArgument);
                        try
                        {
                            sc.Open();
                            cmd11.ExecuteNonQuery();
                            sc.Close();
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

                        if (sAcc != null || sAcc != "" || sAcc != "0")
                        {
                            //Create SIS User(111)
                            SqlCommand Cmd = new SqlCommand();
                            Cmd.Connection = sc;
                            Cmd.CommandText = "Create_Online_User";
                            Cmd.CommandType = CommandType.StoredProcedure;
                            Cmd.Parameters.Add("@sNo", SqlDbType.VarChar).Value = commandArgument;
                            Cmd.Parameters.Add("@sAccount", SqlDbType.VarChar).Value = sAcc;
                            Cmd.Parameters.Add("@iRole", SqlDbType.Int).Value = 111;
                            try
                            {
                                sc.Open();
                                Cmd.ExecuteNonQuery();
                                sc.Close();
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

                            int iStatus = 1;
                            string sSQL = "UPDATE Reg_Student_Accounts";
                            sSQL += " SET intOnlineStatus =" + iStatus;
                            sSQL += ",strUserSave='" + Session["CurrentUserName"].ToString() + "',dateLastSave=getDate()";
                            sSQL += " Where strAccountNo='" + sAcc + "'";
                            Cmd.CommandType = CommandType.Text;
                            Cmd.CommandText = sSQL;
                            try
                            {
                                sc.Open();
                                Cmd.ExecuteNonQuery();
                                sc.Close();
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
                        Response.Write("<script>alert('Student account (# " + sAcc + ") created Successfully-(From Reference).');</script>");
                        Response.Redirect("Acc_Search_Edit?sAcc="+ sAcc + "");
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
                else //Student have no accounts yet
                {                   
                    SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);                    
                    string newAcc = Get_New_Acc();
                    try
                    {
                        SqlCommand Cmd = new SqlCommand();
                        Cmd.CommandText = "Add_Account";
                        Cmd.CommandType = CommandType.StoredProcedure;
                        Cmd.Connection = Conn;
                        Cmd.Parameters.Add("@strAccountNo", SqlDbType.VarChar).Value = newAcc;
                        Cmd.Parameters.Add("@strStudentName", SqlDbType.VarChar).Value = CommandName;
                        Cmd.Parameters.Add("@lngStudentNumber", SqlDbType.VarChar).Value = commandArgument;
                        Cmd.Parameters.Add("@strPhone1", SqlDbType.VarChar).Value = sPhone1;
                        Cmd.Parameters.Add("@byteAccountStatus", SqlDbType.SmallInt).Value = 0;
                        //int iTerm = Convert.ToInt32(ddlRegTerm.SelectedValue);
                        //int iYear = 0;
                        //int iSem = 0;
                        //iYear = LibraryMOD.SeperateTerm(iTerm, out iSem);
                        int iCSem = 0;
                        int iCYear = LibraryMOD.SeperateTerm(LibraryMOD.GetCurrentTerm(), out iCSem);
                        Cmd.Parameters.Add("@intRegYear", SqlDbType.Int).Value = iCYear;
                        Cmd.Parameters.Add("@byteRegSem", SqlDbType.SmallInt).Value = iCSem;
                        Cmd.Parameters.Add("@intDelegation", SqlDbType.Int).Value = 0;
                        Cmd.Parameters.Add("@curDelegation", SqlDbType.Decimal).Value = 0;
                        Cmd.Parameters.Add("@strDelegationNote", SqlDbType.VarChar).Value = DBNull.Value;
                        Cmd.Parameters.Add("@strNote", SqlDbType.VarChar).Value = DBNull.Value;
                        Cmd.Parameters.Add("@byteType", SqlDbType.SmallInt).Value = 0;
                        Cmd.Parameters.Add("@intOnlineStatus", SqlDbType.Int).Value = 1;
                        //Cmd.Parameters.Add("@intOnlineUser", SqlDbType.Int).Value = 0;
                        //Cmd.Parameters.Add("@strOnlinePWD", SqlDbType.VarChar).Value = "";
                        string sUser = Session["CurrentUserName"].ToString();
                        Cmd.Parameters.Add("@sUser", SqlDbType.VarChar).Value = sUser;
                        Conn.Open();
                        Cmd.ExecuteNonQuery();
                        Conn.Close();


                        SqlCommand cmd11 = new SqlCommand("UPDATE Reg_Applications SET strAccountNo= AC.strAccountNo FROM Reg_Applications INNER JOIN Reg_Student_Accounts AS AC ON Reg_Applications.lngStudentNumber = AC.lngStudentNumber where Reg_Applications.lngStudentNumber=@lngStudentNumber", Conn);
                        cmd11.Parameters.AddWithValue("@lngStudentNumber", commandArgument);
                        try
                        {
                            Conn.Open();
                            cmd11.ExecuteNonQuery();
                            Conn.Close();
                        }
                        catch (Exception ex)
                        {
                            Conn.Close();
                            Console.WriteLine(ex.Message);
                        }
                        finally
                        {
                            Conn.Close();
                        }

                        if (newAcc != null || newAcc != "" || newAcc != "0")
                        {
                            //Create SIS User(111)
                            SqlCommand Cmd5 = new SqlCommand();
                            Cmd5.Connection = sc;
                            Cmd5.CommandText = "Create_Online_User";
                            Cmd5.CommandType = CommandType.StoredProcedure;
                            Cmd5.Parameters.Add("@sNo", SqlDbType.VarChar).Value = commandArgument;
                            Cmd5.Parameters.Add("@sAccount", SqlDbType.VarChar).Value = newAcc;
                            Cmd5.Parameters.Add("@iRole", SqlDbType.Int).Value = 111;
                            try
                            {
                                sc.Open();
                                Cmd5.ExecuteNonQuery();
                                sc.Close();
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


                            int iStatus = 1;
                            string sSQL = "UPDATE Reg_Student_Accounts";
                            sSQL += " SET intOnlineStatus =" + iStatus;
                            sSQL += ",strUserSave='" + Session["CurrentUserName"].ToString() + "',dateLastSave=getDate()";
                            sSQL += " Where strAccountNo='" + newAcc + "'";
                            Cmd.CommandType = CommandType.Text;
                            Cmd.CommandText = sSQL;
                            try
                            {
                                sc.Open();
                                Cmd.ExecuteNonQuery();
                                sc.Close();
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
                    // return newAcc;
                    Response.Write("<script>alert('Student account (# " + newAcc + ") created Successfully.');</script>");
                    Response.Redirect("Acc_Search_Edit?sAcc=" + newAcc + "");
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
    }
}