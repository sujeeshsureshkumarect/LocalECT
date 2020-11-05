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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CurrentRole"] != null)
            {
                int CurrentRole = (int)Session["CurrentRole"];
                if (!IsPostBack)
                {
                    if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_StudentSearch,
                    InitializeModule.enumPrivilege.ShowBrowse, CurrentRole) != true)
                    {
                        Server.Transfer("Authorization.aspx");
                    }

                    //if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Student_Data,
                    //    InitializeModule.enumPrivilege.AddNew, CurrentRole) != true)
                    //{
                    //    lnk_add.Visible = false;
                    //}
                    //else
                    //{
                    //    lnk_add.Visible = true;
                    //}
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
                sqlcomd = "SELECT  dbo.Reg_Applications.lngStudentNumber, dbo.Reg_Students_Data.strLastDescEn, dbo.Reg_Specializations.strCaption, dbo.Reg_Students_Data.sECTemail, dbo.Reg_Students_Data.dateCreate, dbo.Reg_Applications.byteCancelReason, dbo.Lkp_Reasons.strReasonDesc FROM            dbo.Reg_Applications INNER JOIN dbo.Reg_Students_Data ON dbo.Reg_Applications.lngSerial = dbo.Reg_Students_Data.lngSerial INNER JOIN dbo.Reg_Specializations ON dbo.Reg_Applications.strCollege = dbo.Reg_Specializations.strCollege AND dbo.Reg_Applications.strDegree = dbo.Reg_Specializations.strDegree AND dbo.Reg_Applications.strSpecialization = dbo.Reg_Specializations.strSpecialization LEFT OUTER JOIN dbo.Lkp_Reasons ON dbo.Reg_Applications.byteCancelReason = dbo.Lkp_Reasons.byteReason WHERE (dbo.Reg_Students_Data.byteShift = 3 OR dbo.Reg_Students_Data.byteShift = 4 OR dbo.Reg_Students_Data.byteShift = 8) AND";
                Campus = (InitializeModule.EnumCampus)int.Parse(drp_Campus.SelectedItem.Value);
            }
            else
            {
                constr = ConfigurationManager.ConnectionStrings["ECTDataFemales"].ConnectionString;
                sqlcomd = "SELECT  dbo.Reg_Applications.lngStudentNumber, dbo.Reg_Students_Data.strLastDescEn, dbo.Reg_Specializations.strCaption, dbo.Reg_Students_Data.sECTemail, dbo.Reg_Students_Data.dateCreate, dbo.Reg_Applications.byteCancelReason, dbo.Lkp_Reasons.strReasonDesc FROM            dbo.Reg_Applications INNER JOIN dbo.Reg_Students_Data ON dbo.Reg_Applications.lngSerial = dbo.Reg_Students_Data.lngSerial INNER JOIN dbo.Reg_Specializations ON dbo.Reg_Applications.strCollege = dbo.Reg_Specializations.strCollege AND dbo.Reg_Applications.strDegree = dbo.Reg_Specializations.strDegree AND dbo.Reg_Applications.strSpecialization = dbo.Reg_Specializations.strSpecialization LEFT OUTER JOIN dbo.Lkp_Reasons ON dbo.Reg_Applications.byteCancelReason = dbo.Lkp_Reasons.byteReason WHERE (dbo.Reg_Students_Data.byteShift = 1 OR dbo.Reg_Students_Data.byteShift = 2 OR dbo.Reg_Students_Data.byteShift = 9) AND";
                Campus = (InitializeModule.EnumCampus)int.Parse(drp_Campus.SelectedItem.Value);
            }
            Session["CurrentCampus"] = Campus;
            if (drp_Criteria.SelectedItem.Text== "Student ID")
            {
                sqlcont = "Reg_Applications.lngStudentNumber like '%"+txt_Search.Text+"%'";
            }
            else if (drp_Criteria.SelectedItem.Text == "Student Name")
            {
                sqlcont = "Reg_Students_Data.strLastDescEn like '%" + txt_Search.Text + "%'";
            }
            else if (drp_Criteria.SelectedItem.Text == "Phone Number")
            {
                sqlcont = "(Reg_Students_Data.strPhone1 like '%" + txt_Search.Text + "%' OR Reg_Students_Data.strPhone2 like '%" + txt_Search.Text + "%')";
            }
            else if (drp_Criteria.SelectedItem.Text == "ECT Email")
            {
                sqlcont = "Reg_Students_Data.sECTemail like '%" + txt_Search.Text + "%'";
            }

            SqlConnection sc = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand(sqlcomd + " " + sqlcont+ " ORDER BY dbo.Reg_Students_Data.strLastDescEn ASC, dbo.Reg_Students_Data.dateCreate DESC", sc);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

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
    }
}