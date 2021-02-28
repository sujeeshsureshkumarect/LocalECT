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
                if (Session["studenttable1"] != null)
                {
                    DataTable dt1 = (DataTable)Session["studenttable1"];
                    RepterDetails.DataSource = dt1;
                    RepterDetails.DataBind();
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
            //hdnMF.Value = "e0a8zjpV";
            if (drp_Campus.SelectedItem.Text == "Males")
            {
                constr = ConfigurationManager.ConnectionStrings["ECTDataMales"].ConnectionString;
                sqlcomd = "SELECT sNo, sName, sAccount, sPhone1, ECTEmail  FROM [Web_Students_Search] where sAccount is not null AND ";
                //sqlcomd = "SELECT sNo, sName, sAccount, sPhone, ECTEmail  FROM Web_Acc_Search where ";
                Campus = (InitializeModule.EnumCampus)int.Parse(drp_Campus.SelectedItem.Value);
                //hdnMF.Value = "yM87jnAJ";
            }
            else
            {
                constr = ConfigurationManager.ConnectionStrings["ECTDataFemales"].ConnectionString;
                sqlcomd = "SELECT sNo, sName, sAccount, sPhone1, ECTEmail  FROM [Web_Students_Search] where sAccount is not null AND ";
                Campus = (InitializeModule.EnumCampus)int.Parse(drp_Campus.SelectedItem.Value);
                //hdnMF.Value = "e0a8zjpV";
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
                sqlcont = "(sPhone1 like '%" + txt_Search.Text + "%' OR sPhone2 like '%" + txt_Search.Text + "%')";
            }
            else if (drp_Criteria.SelectedItem.Text == "Student Account Number")
            {
                sqlcont = "sAccount like '%" + txt_Search.Text + "%'";
            }
            else if (drp_Criteria.SelectedItem.Text == "ECT Email")
            {
                sqlcont = "ECTEmail like '%" + txt_Search.Text + "%'";
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

                Session["studenttable1"] = dt;
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