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
    }
}