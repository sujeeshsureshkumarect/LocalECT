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
    public partial class Strategy_Strategic_Objective_Sub_Stipulation_Home : System.Web.UI.Page
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
                        if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.Strategic_Initiative,
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
                if (Session["CurrentUserName"] != null)
                {
                    if (!IsPostBack)
                    {
                        string id = Request.QueryString["id"];//iStrategicObjective
                        bindStrategic_Objective_Sub_Stipulation(id);
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

        public void bindStrategic_Objective_Sub_Stipulation(string id)
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew);
            SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["ECTDataNew"].ConnectionString);

            SqlCommand cmd = new SqlCommand("SELECT CS_Strategic_Objective_Sub_Stipulation.iStrategicObjective, CS_Strategic_Objective_Sub_Stipulation.iSubStipulation, CS_Strategic_Objective_Sub_Stipulation.dAdded, CS_Strategic_Objective_Sub_Stipulation.sAddedBy, CS_Strategic_Objective_Sub_Stipulation.dUpdated, CS_Strategic_Objective_Sub_Stipulation.sUpdatedBy, CS_Strategic_Objective.sStrategicObjectiveID, CS_Strategic_Objective.sStrategicObjectiveDesc, CS_Sub_Stipulation.sSubStipulationID, CS_Sub_Stipulation.sSubStipulationDesc FROM CS_Strategic_Objective_Sub_Stipulation INNER JOIN CS_Strategic_Objective ON CS_Strategic_Objective_Sub_Stipulation.iStrategicObjective = CS_Strategic_Objective.iSerial INNER JOIN CS_Sub_Stipulation ON CS_Strategic_Objective_Sub_Stipulation.iSubStipulation = CS_Sub_Stipulation.iSerial where iStrategicObjective=@iStrategicObjective", sc);
            cmd.Parameters.AddWithValue("@iStrategicObjective", id);
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
            Response.Redirect("Strategy_Strategic_Objective_Sub_Stipulation_Update?id=" + Request.QueryString["id"] + "");
        }
    }
}