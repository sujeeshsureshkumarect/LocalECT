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
    public partial class Acc_Search : System.Web.UI.Page
    {
        InitializeModule.EnumCampus Campus = InitializeModule.EnumCampus.Females;
        string constr = ConfigurationManager.ConnectionStrings["ECTDataFemales"].ConnectionString;
        int CurrentRole = 0;
        int iCYear = 0;
        int iCSem = 0;
        int iTerm = 0;
        string sOAcc = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CurrentRole"] != null)
            {
                CurrentRole = (int)Session["CurrentRole"];
                if (!IsPostBack)
                {
                    if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_ACC_Search,
              InitializeModule.enumPrivilege.ShowBrowse, CurrentRole) != true)
                    {
                        Server.Transfer("Authorization.aspx");
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
                sqlcomd = "SELECT sNo, sName, sAccount, sPhone  FROM Web_Acc_Search where ";
                Campus = (InitializeModule.EnumCampus)int.Parse(drp_Campus.SelectedItem.Value);
            }
            else
            {
                constr = ConfigurationManager.ConnectionStrings["ECTDataFemales"].ConnectionString;
                sqlcomd = "SELECT sNo, sName, sAccount, sPhone  FROM Web_Acc_Search where ";
                Campus = (InitializeModule.EnumCampus)int.Parse(drp_Campus.SelectedItem.Value);
            }
            Session["CurrentCampus"] = Campus;
            if (drp_Criteria.SelectedItem.Text == "Student ID")
            {
                sqlcont = "sNo like '%" + txt_Search.Text + "%'";
            }
            else if (drp_Criteria.SelectedItem.Text == "Student Name")
            {
                sqlcont = "sName like '%" + txt_Search.Text + "%'";
            }
            else if (drp_Criteria.SelectedItem.Text == "Phone Number")
            {
                sqlcont = "sPhone like '%" + txt_Search.Text + "%'";
            }
            else if (drp_Criteria.SelectedItem.Text == "Student Account Number")
            {
                sqlcont = "sAccount like '%" + txt_Search.Text + "%'";
            }

            SqlConnection sc = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand(sqlcomd + " " + sqlcont + " ORDER BY sName asc", sc);
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