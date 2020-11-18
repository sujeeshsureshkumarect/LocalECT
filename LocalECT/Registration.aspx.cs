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
    public partial class Registration : System.Web.UI.Page
    {
        InitializeModule.EnumCampus Campus = InitializeModule.EnumCampus.Females;
        string constr = ConfigurationManager.ConnectionStrings["ECTDataFemales"].ConnectionString;
        int CurrentRole = 0;
        List<MirrorCLS> myList = new List<MirrorCLS>();
        Plans myPlan = new Plans();
        int iRegYear = 0;
        int iRegSem = 0;
        int iTerm = 0;
        byte bShift = 0;
        string sCourse = "";
        byte bClass = 0;
        string sNo = "";
        string sName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CurrentRole"] != null)
            {
                iRegYear = (int)Session["RegYear"];
                iRegSem = (int)Session["RegSemester"];
                CurrentRole = (int)Session["CurrentRole"];

                if (!IsPostBack)
                {
                    if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Registration,
                   InitializeModule.enumPrivilege.ShowBrowse, CurrentRole) != true)
                    {
                        Server.Transfer("Authorization.aspx");
                    }
                }
                if (!IsPostBack)
                {
                    if (Session["CurrentCampus"] != null)
                    {
                        string sCampus = Session["CurrentCampus"].ToString();
                        Campus = (InitializeModule.EnumCampus)Session["CurrentCampus"];
                        Campus_ddl.SelectedValue = ((int)Campus).ToString();
                    }
                    Session["myList"] = null;
                    Session["myPlan"] = null;
                    if (Session["CurrentStudent"] != null)
                    {
                        //sSelectedValue.Value = Session["CurrentStudent"].ToString();
                        //sSelectedText.Value = Session["CurrentStudentName"].ToString();
                        //sNo = sSelectedValue.Value;
                        //sName = sSelectedText.Value;
                        if (LibraryMOD.IsFileVerifiedFromRegistrar(sNo, Campus) == InitializeModule.FALSE_VALUE)
                        {                           
                            Server.Transfer("Authorization.aspx");
                            return;
                        }
                    }                    
                }
                else
                {
                    Campus = (InitializeModule.EnumCampus)int.Parse(Campus_ddl.SelectedValue);
                    if (Session["myList"] != null)
                    {
                        myList = (List<MirrorCLS>)Session["myList"];
                        myPlan = (Plans)Session["myPlan"];

                    }
                    //sNo = sSelectedValue.Value;
                    //sName = sSelectedText.Value;
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
            if (Campus_ddl.SelectedItem.Text == "Males")
            {
                constr = ConfigurationManager.ConnectionStrings["ECTDataMales"].ConnectionString;
                sqlcomd = "SELECT sNo, sName, sAccount, sPhone1, ECTEmail  FROM [Web_Students_Search] where ";
                //sqlcomd = "SELECT sNo, sName, sAccount, sPhone, ECTEmail  FROM Web_Acc_Search where ";
                Campus = (InitializeModule.EnumCampus)int.Parse(Campus_ddl.SelectedItem.Value);
                //hdnMF.Value = "yM87jnAJ";
            }
            else
            {
                constr = ConfigurationManager.ConnectionStrings["ECTDataFemales"].ConnectionString;
                sqlcomd = "SELECT sNo, sName, sAccount, sPhone1, ECTEmail  FROM [Web_Students_Search] where ";
                Campus = (InitializeModule.EnumCampus)int.Parse(Campus_ddl.SelectedItem.Value);
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
            //else if (drp_Criteria.SelectedItem.Text == "Student Account Number")
            //{
            //    sqlcont = "sAccount like '%" + txt_Search.Text + "%'";
            //}
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