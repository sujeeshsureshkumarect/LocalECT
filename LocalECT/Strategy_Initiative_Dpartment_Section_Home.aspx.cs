using System;
using System.Collections;
using System.Configuration;
using LocalECT.DAL;
using System.Data;
//using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
//using System.Xml.Linq;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;

namespace LocalECT
{
    public partial class Strategy_Initiative_Dpartment_Section_Home : System.Web.UI.Page
    {
        int CurrentRole = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["CurrentRole"] != null)
                {
                    CurrentRole = (int)Session["CurrentRole"];
                    if (!IsPostBack)
                    {
                        //if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.LinkManager,
                        //InitializeModule.enumPrivilege.ShowBrowse, CurrentRole) != true)
                        //{
                        //    Server.Transfer("Authorization.aspx");
                        //}
                    }
                }
                else
                {
                    Session.RemoveAll();
                    Response.Redirect("Login.aspx");

                }
                if (Session["CurrentUserName"] != null)
                {
                    if (!IsPostBack)
                    {
                        string id = Request.QueryString["id"];//iInitiative
                        bindInitiative_Dpartment_Section(id);
                    }
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine("{0} Exception caught.", exp);
            }
            finally
            {

            }
        }

        public void bindInitiative_Dpartment_Section(string id)
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew);
            SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["ECTDataNew"].ConnectionString);

            SqlCommand cmd = new SqlCommand("SELECT CS_Initiative_Dpartment_Section.iInitiative, CS_Initiative_Dpartment_Section.iDepartment, CS_Initiative_Dpartment_Section.iSection, CS_Initiative_Dpartment_Section.isPrincipal, CS_Strategic_Initiative.sInitiativeID, Lkp_Department.DescEN, Lkp_Department.DepartmentAbbreviation, Lkp_Section.SectionAbbreviation, Lkp_Section.DescEN AS Expr1 FROM CS_Initiative_Dpartment_Section INNER JOIN CS_Strategic_Initiative ON CS_Initiative_Dpartment_Section.iInitiative = CS_Strategic_Initiative.iSerial INNER JOIN Lkp_Department ON CS_Initiative_Dpartment_Section.iDepartment = Lkp_Department.DepartmentID INNER JOIN Lkp_Section ON CS_Initiative_Dpartment_Section.iSection = Lkp_Section.SectionID where iInitiative=@iInitiative", sc);
            cmd.Parameters.AddWithValue("@iInitiative", id);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                Repeater1.DataSource = dt;
                Repeater1.DataBind();
            }
            catch (Exception ex)
            {
                sc.Close();
                Console.WriteLine("{0} Exception caught.", ex);
            }
            finally
            {
                sc.Close();
            }
        }

        protected void lnk_Create_Click(object sender, EventArgs e)
        {
            Response.Redirect("Strategy_Initiative_Dpartment_Section_Update?id=" + Request.QueryString["id"] + "");
        }
    }
}