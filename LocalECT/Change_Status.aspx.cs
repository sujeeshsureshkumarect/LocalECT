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
    public partial class Change_Status : System.Web.UI.Page
    {
        int iRegYear = 0;
        int iRegSem = 0;
        int iTerm = 0;
        InitializeModule.EnumCampus Campus = InitializeModule.EnumCampus.Females;
        string constr = ConfigurationManager.ConnectionStrings["ECTDataFemales"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CurrentRole"] != null)
            {
                iRegYear = (int)Session["RegYear"];
                iRegSem = (int)Session["RegSemester"];
                int CurrentRole = (int)Session["CurrentRole"];
                if (!IsPostBack)
                {
                    if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_StudentSearch,
                   InitializeModule.enumPrivilege.ShowBrowse, CurrentRole) != true)
                    {
                        Server.Transfer("Authorization.aspx");
                    }
                    Campus = (InitializeModule.EnumCampus)Session["CurrentCampus"];
                    if (Request.QueryString["sid"] != null && Request.QueryString["sid"] != "")
                    {
                        string value = Request.QueryString["sid"].ToString();
                        lnk_BulkUpdate.Visible = true;
                        //stringsids(value);
                        alertsearch.Visible = true;
                        lbl_IDs.Text = value;                        
                    }
                    else
                    {
                        lnk_BulkUpdate.Visible = false;
                        alertsearch.Visible = false;
                        lbl_IDs.Text = "";
                        lbl_Msg.Text = "No Data Selected for Bulk Operation";
                        div_msg.Visible = true;
                        //Server.Transfer("Authorization.aspx");
                    }
                    FillMainReasons();
                    FillStatuses();
                    FillTerms();
                    iTerm = iRegYear * 10 + iRegSem;
                    ddlStatusTerm.SelectedValue = iTerm.ToString();
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
            //if (s.Length<=10)
            //{
            //    alertsearch.Visible = true;
            //    lbl_IDs.Text = sIDs;
            //}
            alertsearch.Visible = true;
            lbl_IDs.Text = splittedArray.Count().ToString() + " records selected for Bulk Action";
            //sIDs = "'" + s.Replace(",", "','") + "'";

        }
        private void FillMainReasons()
        {
            List<MainReasons> myMainReasons = new List<MainReasons>();
            MainReasonsDAL myMainReasonsDAL = new MainReasonsDAL();
            try
            {
                myMainReasons = myMainReasonsDAL.GetMainReasons(Campus, "", false);
                for (int i = 0; i < myMainReasons.Count; i++)
                {
                    ddlReason.Items.Add(new ListItem(myMainReasons[i].strMainReasonEn, myMainReasons[i].byteMainReason.ToString()));
                }
            }
            catch (Exception ex)
            {
                LibraryMOD.ShowErrorMessage(ex);
                lbl_Msg.Text = ex.Message;
                div_msg.Visible = true;
            }
            finally
            {
                myMainReasons.Clear();
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
                    ddlStatusTerm.Items.Add(new ListItem(myTerms[i].ShortDesc, myTerms[i].Term.ToString()));
                }
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
        private void FillStatuses()
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            Conn.Open();
            try
            {
                string sSQL = "SELECT byteReason, strReasonDesc AS Status";
                sSQL += " FROM dbo.Lkp_Reasons AS S";
                sSQL += " WHERE (byteReason <> 9)";
                sSQL += " ORDER BY Status";
                SqlCommand Cmd = new SqlCommand(sSQL, Conn);
                SqlDataReader Rd = Cmd.ExecuteReader();

                ddlStatus.Items.Clear();
                while (Rd.Read())
                {
                    ddlStatus.Items.Add(new ListItem(Rd["Status"].ToString(), Rd["byteReason"].ToString()));
                }
                Rd.Close();

            }
            catch (Exception ex)
            {
                LibraryMOD.ShowErrorMessage(ex);
                lbl_Msg.Text = ex.Message;
                div_msg.Visible = true;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }
        }
        protected void lnk_BulkUpdate_Click(object sender, EventArgs e)
        {
            Campus = (InitializeModule.EnumCampus)Session["CurrentCampus"];
            Connection_StringCLS connstr = new Connection_StringCLS(Campus);
            SqlConnection sc = new SqlConnection(connstr.Conn_string);
            string sIDs = Request.QueryString["sid"].ToString();
            int iLen = sIDs.Length;
            string sLast = sIDs.Substring(iLen - 1, 1);
            if (sLast == ",")
            {
                sIDs = sIDs.Remove(iLen - 1, 1);
            }
            string s = sIDs;
            string[] uniqueItems = s.Split(',');
            IEnumerable<string> splittedArray = uniqueItems.Distinct<string>();
            // Start loop
            int iEffected = 0;
            foreach (string sid in splittedArray)
            {
                //1. insert Query
                string insertquery = "SELECT     LR.iMax AS SI, A.lngStudentNumber AS SID, " + ddlStatus.SelectedItem.Value + " AS S, " + ddlReason.SelectedItem.Value + " AS SM, " + ddlSubReason.SelectedItem.Value + " AS SS, '" + txt_Remarks.Text.Trim() + "' AS[Desc], GETDATE() AS Expr3, ";
                insertquery += "'" + Session["CurrentUserName"].ToString() + "' AS Expr4, GETDATE() AS Expr5, '" + Session["CurrentUserName"].ToString() + "' AS Expr6, 6 AS Expr7, 0 AS Expr8, 1 AS Expr9, GETDATE() AS Expr10, '" + Session["CurrentUserName"].ToString() + "' AS Expr11 ";
                insertquery += "FROM(SELECT     MAX(iSerial) + 1 AS iMax ";
                insertquery += " FROM          Reg_Students_Request) AS LR CROSS JOIN ";
                insertquery += "Reg_Applications AS A ";
                insertquery += "WHERE (A.lngStudentNumber IN(N'" + sid + "')) AND (A.byteCancelReason <> " + ddlStatus.SelectedItem.Value + " and A.byteCancelReason <> 3 OR A.byteCancelReason IS NULL)";
                SqlCommand cmd = new SqlCommand("insert into Reg_Students_Request " + insertquery + "", sc);
                try
                {
                    sc.Open();
                    cmd.ExecuteNonQuery();
                    sc.Close();

                    SqlCommand cmd1 = new SqlCommand("SELECT MAX(iSerial) AS iMax FROM Reg_Students_Request", sc);
                    DataTable dt1 = new DataTable();
                    SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                    try
                    {
                        sc.Open();
                        da1.Fill(dt1);
                        sc.Close();
                        //2. update Query
                        if (dt1.Rows.Count > 0)
                        {
                            int selectedYear = 0;
                            string SY = "NULL";
                            int selectedSemester = 0;
                            string SS = "NULL";
                            int selectedTerm = 0;
                            string byteCancelReason = "IS NOT NULL";
                            string byteCancelReason1 = "IS NOT NULL";
                            selectedTerm = Convert.ToInt32(ddlStatusTerm.SelectedValue);
                            selectedYear = LibraryMOD.SeperateTerm(selectedTerm, out selectedSemester);
                            int iMax = Convert.ToInt32(dt1.Rows[0]["iMax"]);

                            if (ddlStatus.SelectedItem.Text == "No Status")
                            {
                                SY = "NULL";
                                SS = "NULL";
                                byteCancelReason = "NULL";
                                byteCancelReason1 = "IS NOT NULL";
                            }
                            else
                            {
                                SY = selectedYear.ToString();
                                SS = selectedSemester.ToString();
                                byteCancelReason = "SR.bStatus";
                                byteCancelReason1 = "<> SR.bStatus";
                            }

                            string updatequery = "UPDATE    Reg_Applications ";
                            updatequery += "SET intGraduationYear = " + SY + ", byteGraduationSemester = " + SS + ", byteCancelReason = " + byteCancelReason + ", byteMainReason = SR.bReason, byteSubReason = SR.bSubReason, ";
                            updatequery += "dateGraduation2 = GETDATE(), strUserSave = '" + Session["CurrentUserName"].ToString() + "', dateLastSave = GETDATE(), strNUser = '" + Session["CurrentUserName"].ToString() + "', strMachine = 'LocalECT' ";
                            updatequery += "FROM Reg_Applications INNER JOIN ";
                            updatequery += "Reg_Students_Request AS SR ON Reg_Applications.lngStudentNumber = SR.sStudentNo ";
                            updatequery += "WHERE (SR.iSerial =" + iMax + ") AND ((Reg_Applications.byteCancelReason " + byteCancelReason1 + " and Reg_Applications.byteCancelReason <> 3) OR Reg_Applications.byteCancelReason IS NULL) ";
                            //(Reg_Applications.byteCancelReason<> " + ddlStatus.SelectedItem.Value + " and Reg_Applications.byteCancelReason <> 3 OR Reg_Applications.byteCancelReason IS NULL)
                            SqlCommand cmd2 = new SqlCommand(updatequery, sc);
                            try
                            {
                                sc.Open();
                                //cmd2.ExecuteNonQuery();
                                int irow = 0;
                                irow = cmd2.ExecuteNonQuery();
                                sc.Close();
                                if (irow > 0)
                                {
                                    iEffected++;
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
            lbl_Msg.Text = "Change Status Completed Successfully";
            div_Alert.Attributes.Add("class", "alert alert-success alert-dismissible");
            div_msg.Visible = true;
            lnk_BulkUpdate.Visible = false;
            // End loop
            //Clear Cookies with selected Student ID's
            //if (Session["sids"] != null)
            //{
            //    Session["sids"] = null;
            //}
        }
    }
}