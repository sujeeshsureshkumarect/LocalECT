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
    public partial class Attendace_Warning_Management : System.Web.UI.Page
    {
        InitializeModule.EnumCampus Campus = InitializeModule.EnumCampus.Females;
        string constr = ConfigurationManager.ConnectionStrings["ECTDataFemales"].ConnectionString;
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
                        //Server.Transfer("Authorization.aspx");
                    }

                    if (Session["Attendace_Warning_Table"] != null)
                    {
                        DataTable dt1 = (DataTable)Session["Attendace_Warning_Table"];
                        RepterDetails.DataSource = dt1;
                        RepterDetails.DataBind();
                    }
                    FillTerms();
                    
                    
                    if (Session["iiRegYear"] != null && Session["iiRegSem"] != null)
                    {
                        int iYear = 0;
                        int iSem = 0;
                        int iTerm = 0;
                        iYear = (int)Session["iiRegYear"];
                        iSem = (int)Session["iiRegSem"];
                        iTerm = iYear * 10 + iSem;
                        ddlTerm.SelectedValue = iTerm.ToString();
                    }
                    if(Session["CurrentCampus"]!= null)
                    {
                        drp_Campus.SelectedIndex = drp_Campus.Items.IndexOf(drp_Campus.Items.FindByText(Session["CurrentCampus"].ToString()));
                    }
                }
            }
            else
            {
                Session.RemoveAll();
                Response.Redirect("Login.aspx");
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
                    ddlTerm.Items.Add(new ListItem(myTerms[i].ShortDesc, myTerms[i].Term.ToString()));

                }
                int iYear = 0;
                int iSem = 0;
                int iTerm = 0;
                iYear = (int)Session["CurrentYear"];
                iSem = (int)Session["CurrentSemester"];
                iTerm = iYear * 10 + iSem;
                ddlTerm.SelectedValue = iTerm.ToString();
            }
            catch (Exception ex)
            {
                LibraryMOD.ShowErrorMessage(ex);
                lbl_Msg.Text = ex.Message;
                div_msg.Visible = true;
            }
            finally
            {
                myTerms.Clear();
            }
        }
        //Delete
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS((InitializeModule.EnumCampus)Session["CurrentCampus"]);
            SqlConnection sc = new SqlConnection(myConnection_String.Conn_string);

            //Get the reference of the clicked button.
            LinkButton button = (sender as LinkButton);

            //Get the command argument
            string dateWarning = button.CommandArgument;//dateWarning
            DateTime dtime = Convert.ToDateTime(dateWarning);
            string strCourse = button.CommandName;//strCourse
            string lngStudentNumber = button.ToolTip;//lngStudentNumber
            
            //Apply Permission
            //if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_StudentSearch,
            //        InitializeModule.enumPrivilege.CreateAccount, CurrentRole) != true)
            //{
            //    Server.Transfer("Authorization.aspx");
            //}

            SqlCommand cmd = new SqlCommand("delete from Reg_Students_Warning where (strCourse=@strCourse and lngStudentNumber=@lngStudentNumber and dateWarning=@dateWarning)", sc);
            cmd.Parameters.AddWithValue("@dateWarning", dtime);
            cmd.Parameters.AddWithValue("@strCourse", strCourse);
            cmd.Parameters.AddWithValue("@lngStudentNumber", lngStudentNumber);
            try
            {
                sc.Open();
                cmd.ExecuteNonQuery();                
                sc.Close();

                lbl_Msg.Text = "Warning Deleted Successfully";
                div_Alert.Attributes.Add("class", "alert alert-success alert-dismissible");
                div_msg.Visible = true;

                lnk_Search_Click(null, null);
            }
            catch(Exception ex)
            {
                sc.Close();
                lbl_Msg.Text = ex.Message;
                div_msg.Visible = true;
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sc.Close();
            }
        }
        //Publish
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS((InitializeModule.EnumCampus)Session["CurrentCampus"]);
            SqlConnection sc = new SqlConnection(myConnection_String.Conn_string);

            //Get the reference of the clicked button.
            LinkButton button = (sender as LinkButton);

            //Get the command argument
            string dateWarning = button.CommandArgument;//dateWarning
            DateTime dtime = Convert.ToDateTime(dateWarning);
            string strCourse = button.CommandName;//strCourse
            string lngStudentNumber = button.ToolTip;//lngStudentNumber

            //Apply Permission
            //if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_StudentSearch,
            //        InitializeModule.enumPrivilege.CreateAccount, CurrentRole) != true)
            //{
            //    Server.Transfer("Authorization.aspx");
            //}

            SqlCommand cmd = new SqlCommand("update Reg_Students_Warning set isPublished=@isPublished where (strCourse=@strCourse and lngStudentNumber=@lngStudentNumber and dateWarning=@dateWarning)", sc);
            cmd.Parameters.AddWithValue("@isPublished", 1);
            cmd.Parameters.AddWithValue("@dateWarning", dtime);
            cmd.Parameters.AddWithValue("@strCourse", strCourse);
            cmd.Parameters.AddWithValue("@lngStudentNumber", lngStudentNumber);
            try
            {
                sc.Open();
                cmd.ExecuteNonQuery();                
                sc.Close();

                lbl_Msg.Text = "Warning Published Successfully";
                div_Alert.Attributes.Add("class", "alert alert-success alert-dismissible");
                div_msg.Visible = true;

                lnk_Search_Click(null, null);
            }
            catch (Exception ex)
            {
                sc.Close();
                lbl_Msg.Text = ex.Message;
                div_msg.Visible = true;
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sc.Close();
            }
        }
        //Convert to Grade
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS((InitializeModule.EnumCampus)Session["CurrentCampus"]);
            SqlConnection sc = new SqlConnection(myConnection_String.Conn_string);

            //Get the reference of the clicked button.
            LinkButton button = (sender as LinkButton);

            //Get the command argument
            string dateWarning = button.CommandArgument;//dateWarning
            DateTime dtime = Convert.ToDateTime(dateWarning);
            string strCourse = button.CommandName;//strCourse
            string lngStudentNumber = button.ToolTip;//lngStudentNumber
            string byteWarningType = button.ValidationGroup;//byteWarningType

            //Apply Permission
            //if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_StudentSearch,
            //        InitializeModule.enumPrivilege.CreateAccount, CurrentRole) != true)
            //{
            //    Server.Transfer("Authorization.aspx");
            //}

            if(byteWarningType=="4")
            {
                //Update
                SqlCommand cmd = new SqlCommand("UPDATE Reg_Grade_Header SET strGrade = @strGrade, strUserSave =@strUserSave, dateLastSave =GETDATE(), strMachine =@strMachine, strNUser =@strNUser WHERE (intStudyYear = @intStudyYear) AND (byteSemester = @byteSemester) AND (strCourse = @strCourse) AND (lngStudentNumber = @lngStudentNumber)", sc);
                cmd.Parameters.AddWithValue("@strGrade", "EW");
                cmd.Parameters.AddWithValue("@strUserSave", Session["CurrentUserName"].ToString());
                cmd.Parameters.AddWithValue("@strMachine", "LOCALECT");
                cmd.Parameters.AddWithValue("@strNUser", Session["CurrentUserName"].ToString());
                cmd.Parameters.AddWithValue("@intStudyYear", Session["iiRegYear"].ToString());
                cmd.Parameters.AddWithValue("@byteSemester", Session["iiRegSem"].ToString());
                cmd.Parameters.AddWithValue("@strCourse", strCourse);
                cmd.Parameters.AddWithValue("@lngStudentNumber", lngStudentNumber);
                try
                {
                    sc.Open();
                    int irow = 0;
                    irow = cmd.ExecuteNonQuery();
                    sc.Close();

                    if (irow > 0)
                    {
                        lbl_Msg.Text = "Grade Converted Successfully";
                        div_Alert.Attributes.Add("class", "alert alert-success alert-dismissible");
                        div_msg.Visible = true;
                    }
                    else
                    {
                        SqlCommand cmd1 = new SqlCommand("select strDegree,strSpecialization from Reg_Applications where lngStudentNumber=@lngStudentNumber;SELECT * FROM Course_Balance_View_BothSides where (iYear = @iYear) AND (Sem = @Sem) and (Student=@Student) and (Course=@Course)", sc);
                        cmd1.Parameters.AddWithValue("@lngStudentNumber", lngStudentNumber);
                        cmd1.Parameters.AddWithValue("@iYear", Session["iiRegYear"].ToString());
                        cmd1.Parameters.AddWithValue("@Sem", Session["iiRegSem"].ToString());
                        cmd1.Parameters.AddWithValue("@Student", lngStudentNumber);
                        cmd1.Parameters.AddWithValue("@Course", strCourse);
                        DataSet ds1 = new DataSet();
                        SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                        try
                        {
                            sc.Open();
                            da1.Fill(ds1);
                            sc.Close();

                            if(ds1.Tables[0].Rows.Count>0 && ds1.Tables[1].Rows.Count > 0)
                            {
                                //Insert
                                string sSQL = "";
                                sSQL += " INSERT INTO Reg_Grade_Header ";
                                sSQL += " (intStudyYear, byteSemester, byteShift, strCourse, byteClass, lngStudentNumber, byteRefCollege, curUseMark, strGrade, strDegree, strMajor, AttMark, strUserCreate, dateCreate, strMachine, strNUser) ";
                                sSQL += " VALUES (@intStudyYear, @byteSemester, @byteShift, @strCourse, @byteClass, @lngStudentNumber, 0, 0, @strGrade, @strDegree, @strMajor, 0, @strUserCreate, GETDATE(), @strMachine, @strNUser) ";
                                SqlCommand cmd2 = new SqlCommand(sSQL, sc);
                                cmd2.Parameters.AddWithValue("@intStudyYear", Session["iiRegYear"].ToString());
                                cmd2.Parameters.AddWithValue("@byteSemester", Session["iiRegSem"].ToString());
                                cmd2.Parameters.AddWithValue("@byteShift", ds1.Tables[1].Rows[0]["Shift"].ToString());
                                cmd2.Parameters.AddWithValue("@strCourse", strCourse);
                                cmd2.Parameters.AddWithValue("@byteClass", ds1.Tables[1].Rows[0]["Class"].ToString());
                                cmd2.Parameters.AddWithValue("@lngStudentNumber", lngStudentNumber);
                                cmd2.Parameters.AddWithValue("@strGrade", "EW");
                                cmd2.Parameters.AddWithValue("@strDegree", ds1.Tables[0].Rows[0]["strDegree"].ToString());
                                cmd2.Parameters.AddWithValue("@strMajor", ds1.Tables[0].Rows[0]["strSpecialization"].ToString());
                                cmd2.Parameters.AddWithValue("@strUserCreate", Session["CurrentUserName"].ToString());
                                cmd2.Parameters.AddWithValue("@strMachine", "LOCALECT");
                                cmd2.Parameters.AddWithValue("@strNUser", Session["CurrentUserName"].ToString());
                                try
                                {
                                    sc.Open();
                                    cmd2.ExecuteNonQuery();
                                    sc.Close();

                                    lbl_Msg.Text = "Grade Converted Successfully";
                                    div_Alert.Attributes.Add("class", "alert alert-success alert-dismissible");
                                    div_msg.Visible = true;
                                }
                                catch(Exception ex)
                                {
                                    sc.Close();
                                    lbl_Msg.Text = ex.Message;
                                    div_msg.Visible = true;
                                    Console.WriteLine(ex.Message);
                                }
                                finally
                                {
                                    sc.Close();
                                }
                            }
                        }
                        catch(Exception ex)
                        {
                            sc.Close();
                            lbl_Msg.Text = ex.Message;
                            div_msg.Visible = true;
                            Console.WriteLine(ex.Message);
                        }
                        finally
                        {
                            sc.Close();
                        }                        
                    }                   
                    lnk_Search_Click(null, null);
                }
                catch (Exception ex)
                {
                    sc.Close();
                    lbl_Msg.Text = ex.Message;
                    div_msg.Visible = true;
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    sc.Close();
                }
            }
            else
            {
                lbl_Msg.Text = "You cannot perform this action-Convert to Grade work with (EW) only";
                div_msg.Visible = true;
                return;
            }           
        }

        protected void lnk_Execute_Click(object sender, EventArgs e)
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS((InitializeModule.EnumCampus)Session["CurrentCampus"]);
            SqlConnection sc = new SqlConnection(myConnection_String.Conn_string);

            string sIDs = hdn_Selected_Sids.Value;
            int iLen = sIDs.Length;
            string sLast = sIDs.Substring(iLen - 1, 1);
            if (sLast == ",")
            {
                sIDs = sIDs.Remove(iLen - 1, 1);
            }
            string s = sIDs;
            string[] uniqueItems = s.Split(',');
            IEnumerable<string> splittedArray = uniqueItems.Distinct<string>();
            int iEffected = 0;
            if (drp_Bulk.SelectedItem.Text == "Delete")
            {
                int totalcount = splittedArray.Count();
                foreach (string sid in splittedArray)
                {
                    string[] items = sid.Split('_');
                    string dateWarning = items[0];//dateWarning
                    DateTime dtime = Convert.ToDateTime(dateWarning);
                    string strCourse = items[1];//strCourse
                    string lngStudentNumber = items[2];//lngStudentNumber

                    //Delete Function
                    SqlCommand cmd = new SqlCommand("delete from Reg_Students_Warning where (strCourse=@strCourse and lngStudentNumber=@lngStudentNumber and dateWarning=@dateWarning)", sc);
                    cmd.Parameters.AddWithValue("@dateWarning", dtime);
                    cmd.Parameters.AddWithValue("@strCourse", strCourse);
                    cmd.Parameters.AddWithValue("@lngStudentNumber", lngStudentNumber);
                    try
                    {
                        sc.Open();
                        cmd.ExecuteNonQuery();                
                        sc.Close();
                        iEffected++;
                    }
                    catch (Exception ex)
                    {
                        sc.Close();
                        //lbl_Msg.Text = ex.Message;
                        //div_msg.Visible = true;
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        sc.Close();
                    }
                }
                lbl_Msg.Text = "(" + iEffected + "/" + totalcount + ") Warning(s) Deleted Successfully";
                div_Alert.Attributes.Add("class", "alert alert-success alert-dismissible");
                div_msg.Visible = true;
            }
            else if (drp_Bulk.SelectedItem.Text == "Publish")
            {
                int totalcount = splittedArray.Count();
                foreach (string sid in splittedArray)
                {
                    string[] items = sid.Split('_');
                    string dateWarning = items[0];//dateWarning
                    DateTime dtime = Convert.ToDateTime(dateWarning);
                    string strCourse = items[1];//strCourse
                    string lngStudentNumber = items[2];//lngStudentNumber

                    //Publish Function
                    SqlCommand cmd = new SqlCommand("update Reg_Students_Warning set isPublished=@isPublished where (strCourse=@strCourse and lngStudentNumber=@lngStudentNumber and dateWarning=@dateWarning)", sc);
                    cmd.Parameters.AddWithValue("@isPublished", 1);
                    cmd.Parameters.AddWithValue("@dateWarning", dtime);
                    cmd.Parameters.AddWithValue("@strCourse", strCourse);
                    cmd.Parameters.AddWithValue("@lngStudentNumber", lngStudentNumber);
                    try
                    {
                        sc.Open();
                        cmd.ExecuteNonQuery();
                        sc.Close();

                        iEffected++;
                    }
                    catch (Exception ex)
                    {
                        sc.Close();
                        //lbl_Msg.Text = ex.Message;
                        //div_msg.Visible = true;
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        sc.Close();
                    }
                }
                lbl_Msg.Text = "(" + iEffected + "/" + totalcount + ") Warning(s) Published Successfully";
                div_Alert.Attributes.Add("class", "alert alert-success alert-dismissible");
                div_msg.Visible = true;
            }
            else if (drp_Bulk.SelectedItem.Text == "Convert to Grade")
            {
                int totalcount = splittedArray.Count();
                foreach (string sid in splittedArray)
                {
                    string[] items = sid.Split('_');
                    string dateWarning = items[0];//dateWarning
                    DateTime dtime = Convert.ToDateTime(dateWarning);
                    string strCourse = items[1];//strCourse
                    string lngStudentNumber = items[2];//lngStudentNumber
                    string byteWarningType = items[3];//byteWarningType

                    //Grade Convert Function
                    if (byteWarningType == "4")
                    {
                        //Update
                        SqlCommand cmd = new SqlCommand("UPDATE Reg_Grade_Header SET strGrade = @strGrade, strUserSave =@strUserSave, dateLastSave =GETDATE(), strMachine =@strMachine, strNUser =@strNUser WHERE (intStudyYear = @intStudyYear) AND (byteSemester = @byteSemester) AND (strCourse = @strCourse) AND (lngStudentNumber = @lngStudentNumber)", sc);
                        cmd.Parameters.AddWithValue("@strGrade", "EW");
                        cmd.Parameters.AddWithValue("@strUserSave", Session["CurrentUserName"].ToString());
                        cmd.Parameters.AddWithValue("@strMachine", "LOCALECT");
                        cmd.Parameters.AddWithValue("@strNUser", Session["CurrentUserName"].ToString());
                        cmd.Parameters.AddWithValue("@intStudyYear", Session["iiRegYear"].ToString());
                        cmd.Parameters.AddWithValue("@byteSemester", Session["iiRegSem"].ToString());
                        cmd.Parameters.AddWithValue("@strCourse", strCourse);
                        cmd.Parameters.AddWithValue("@lngStudentNumber", lngStudentNumber);
                        try
                        {
                            sc.Open();
                            int irow = 0;
                            irow = cmd.ExecuteNonQuery();
                            sc.Close();

                            if (irow > 0)
                            {
                                iEffected++;
                            }
                            else
                            {
                                SqlCommand cmd1 = new SqlCommand("select strDegree,strSpecialization from Reg_Applications where lngStudentNumber=@lngStudentNumber;SELECT * FROM Course_Balance_View_BothSides where (iYear = @iYear) AND (Sem = @Sem) and (Student=@Student) and (Course=@Course)", sc);
                                cmd1.Parameters.AddWithValue("@lngStudentNumber", lngStudentNumber);
                                cmd1.Parameters.AddWithValue("@iYear", Session["iiRegYear"].ToString());
                                cmd1.Parameters.AddWithValue("@Sem", Session["iiRegSem"].ToString());
                                cmd1.Parameters.AddWithValue("@Student", lngStudentNumber);
                                cmd1.Parameters.AddWithValue("@Course", strCourse);
                                DataSet ds1 = new DataSet();
                                SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                                try
                                {
                                    sc.Open();
                                    da1.Fill(ds1);
                                    sc.Close();

                                    if (ds1.Tables[0].Rows.Count > 0)
                                    {
                                        //Insert
                                        string sSQL = "";
                                        sSQL += " INSERT INTO Reg_Grade_Header ";
                                        sSQL += " (intStudyYear, byteSemester, byteShift, strCourse, byteClass, lngStudentNumber, byteRefCollege, curUseMark, strGrade, strDegree, strMajor, AttMark, strUserCreate, dateCreate, strMachine, strNUser) ";
                                        sSQL += " VALUES (@intStudyYear, @byteSemester, @byteShift, @strCourse, @byteClass, @lngStudentNumber, 0, 0, @strGrade, @strDegree, @strMajor, 0, @strUserCreate, GETDATE(), @strMachine, @strNUser) ";
                                        SqlCommand cmd2 = new SqlCommand(sSQL, sc);
                                        cmd2.Parameters.AddWithValue("@intStudyYear", Session["iiRegYear"].ToString());
                                        cmd2.Parameters.AddWithValue("@byteSemester", Session["iiRegSem"].ToString());
                                        cmd2.Parameters.AddWithValue("@byteShift", ds1.Tables[1].Rows[0]["Shift"].ToString());
                                        cmd2.Parameters.AddWithValue("@strCourse", strCourse);
                                        cmd2.Parameters.AddWithValue("@byteClass", ds1.Tables[1].Rows[0]["Class"].ToString());
                                        cmd2.Parameters.AddWithValue("@lngStudentNumber", lngStudentNumber);
                                        cmd2.Parameters.AddWithValue("@strGrade", "EW");
                                        cmd2.Parameters.AddWithValue("@strDegree", ds1.Tables[0].Rows[0]["strDegree"].ToString());
                                        cmd2.Parameters.AddWithValue("@strMajor", ds1.Tables[0].Rows[0]["strSpecialization"].ToString());
                                        cmd2.Parameters.AddWithValue("@strUserCreate", Session["CurrentUserName"].ToString());
                                        cmd2.Parameters.AddWithValue("@strMachine", "LOCALECT");
                                        cmd2.Parameters.AddWithValue("@strNUser", Session["CurrentUserName"].ToString());
                                        try
                                        {
                                            sc.Open();
                                            cmd2.ExecuteNonQuery();
                                            sc.Close();

                                            iEffected++;
                                        }
                                        catch (Exception ex)
                                        {
                                            sc.Close();
                                            //lbl_Msg.Text = ex.Message;
                                            //div_msg.Visible = true;
                                            Console.WriteLine(ex.Message);
                                        }
                                        finally
                                        {
                                            sc.Close();
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    sc.Close();
                                    //lbl_Msg.Text = ex.Message;
                                    //div_msg.Visible = true;
                                    Console.WriteLine(ex.Message);
                                }
                                finally
                                {
                                    sc.Close();
                                }
                            }                            
                        }
                        catch (Exception ex)
                        {
                            sc.Close();
                            //lbl_Msg.Text = ex.Message;
                            //div_msg.Visible = true;
                            Console.WriteLine(ex.Message);
                        }
                        finally
                        {
                            sc.Close();
                        }
                    }
                }
                lbl_Msg.Text = "(" + iEffected + "/" + totalcount + ") Grade(s) Converted Successfully";
                div_Alert.Attributes.Add("class", "alert alert-success alert-dismissible");
                div_msg.Visible = true;
            }
            else
            {

            }
            lnk_Search_Click(null, null);
        }

        protected void lnk_Search_Click(object sender, EventArgs e)
        {
            String sqlcomd = "";
            int iRegYear = 0;
            int iRegSem = 0;
            int iRegTerm = 0;
            iRegTerm = Convert.ToInt32(ddlTerm.SelectedValue);
            iRegYear = LibraryMOD.SeperateTerm(iRegTerm, out iRegSem);
            if (drp_Campus.SelectedItem.Text == "Males")
            {
                constr = ConfigurationManager.ConnectionStrings["ECTDataMales"].ConnectionString;
                //sqlcomd = "SELECT  dbo.Reg_Applications.lngStudentNumber, dbo.Reg_Students_Data.strLastDescEn, dbo.Reg_Specializations.strCaption, dbo.Reg_Students_Data.sECTemail, dbo.Reg_Students_Data.dateCreate, dbo.Reg_Applications.byteCancelReason, dbo.Lkp_Reasons.strReasonDesc FROM            dbo.Reg_Applications INNER JOIN dbo.Reg_Students_Data ON dbo.Reg_Applications.lngSerial = dbo.Reg_Students_Data.lngSerial INNER JOIN dbo.Reg_Specializations ON dbo.Reg_Applications.strCollege = dbo.Reg_Specializations.strCollege AND dbo.Reg_Applications.strDegree = dbo.Reg_Specializations.strDegree AND dbo.Reg_Applications.strSpecialization = dbo.Reg_Specializations.strSpecialization LEFT OUTER JOIN dbo.Lkp_Reasons ON dbo.Reg_Applications.byteCancelReason = dbo.Lkp_Reasons.byteReason WHERE (dbo.Reg_Students_Data.byteShift = 3 OR dbo.Reg_Students_Data.byteShift = 4 OR dbo.Reg_Students_Data.byteShift = 8) AND";
                //sqlcomd = "SELECT sNo, sName, sAccount, sPhone1, ECTEmail,iSerial FROM Web_Students_Search where";
                sqlcomd = "SELECT dateWarning, strCourse, lngStudentNumber, byteWarningType, CONVERT(varchar(10), CONVERT(date, dateWarning), 23) AS dateWarning1, isPublished FROM Reg_Students_Warning WHERE (intStudyYear = @intStudyYear) AND (byteSemester = @byteSemester)";
                Campus = (InitializeModule.EnumCampus)int.Parse(drp_Campus.SelectedItem.Value);
            }
            else
            {
                constr = ConfigurationManager.ConnectionStrings["ECTDataFemales"].ConnectionString;
                //sqlcomd = "SELECT  dbo.Reg_Applications.lngStudentNumber, dbo.Reg_Students_Data.strLastDescEn, dbo.Reg_Specializations.strCaption, dbo.Reg_Students_Data.sECTemail, dbo.Reg_Students_Data.dateCreate, dbo.Reg_Applications.byteCancelReason, dbo.Lkp_Reasons.strReasonDesc FROM            dbo.Reg_Applications INNER JOIN dbo.Reg_Students_Data ON dbo.Reg_Applications.lngSerial = dbo.Reg_Students_Data.lngSerial INNER JOIN dbo.Reg_Specializations ON dbo.Reg_Applications.strCollege = dbo.Reg_Specializations.strCollege AND dbo.Reg_Applications.strDegree = dbo.Reg_Specializations.strDegree AND dbo.Reg_Applications.strSpecialization = dbo.Reg_Specializations.strSpecialization LEFT OUTER JOIN dbo.Lkp_Reasons ON dbo.Reg_Applications.byteCancelReason = dbo.Lkp_Reasons.byteReason WHERE (dbo.Reg_Students_Data.byteShift = 1 OR dbo.Reg_Students_Data.byteShift = 2 OR dbo.Reg_Students_Data.byteShift = 9) AND";
                //sqlcomd = "SELECT sNo, sName, sAccount, sPhone1, ECTEmail,iSerial FROM Web_Students_Search where ";
                sqlcomd = "SELECT dateWarning, strCourse, lngStudentNumber, byteWarningType, CONVERT(varchar(10), CONVERT(date, dateWarning), 23) AS dateWarning1, isPublished FROM Reg_Students_Warning WHERE (intStudyYear = @intStudyYear) AND (byteSemester = @byteSemester)";
                Campus = (InitializeModule.EnumCampus)int.Parse(drp_Campus.SelectedItem.Value);
            }
            Session["CurrentCampus"] = Campus;
            Session["iiRegYear"] = iRegYear;
            Session["iiRegSem"] = iRegSem;
            //Session["iiRegTerm"] = Convert.ToInt32(ddlTerm.SelectedValue);

            SqlConnection sc = new SqlConnection(constr);
            //SqlCommand cmd = new SqlCommand(sqlcomd + " " + sqlcont+ " ORDER BY dbo.Reg_Students_Data.strLastDescEn ASC, dbo.Reg_Students_Data.dateCreate DESC", sc);
            SqlCommand cmd = new SqlCommand(sqlcomd, sc);
            cmd.Parameters.AddWithValue("@intStudyYear", iRegYear);
            cmd.Parameters.AddWithValue("@byteSemester", iRegSem);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                Session["Attendace_Warning_Table"] = dt;
                RepterDetails.DataSource = dt;
                RepterDetails.DataBind();

                alertsearch.Visible = true;
                lbl_Count.Text = dt.Rows.Count.ToString() + " entry(s) found.";

            }
            catch (Exception ex)
            {
                sc.Close();
                throw ex;
            }
            finally
            {
                sc.Close();
            }
        }
    }
}