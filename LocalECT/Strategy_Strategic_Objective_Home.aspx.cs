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
    public partial class Strategy_Strategic_Objective_Home : System.Web.UI.Page
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
                        if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.Strategic_Objective,
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
                        bindStrategic_Objective();
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

        public void bindStrategic_Objective()
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew);
            SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["ECTDataNew"].ConnectionString);

            SqlCommand cmd = new SqlCommand("SELECT CS_Strategic_Objective.iSerial, CS_Strategic_Objective.sStrategicObjectiveID, CS_Strategic_Objective.sStrategicObjectiveDesc, CS_Strategic_Objective.iInspectionComplianceDomain, CS_Strategic_Objective.iOrder, CS_Strategic_Objective.iStrategyVersion, CS_Strategic_Objective.dAdded, CS_Strategic_Objective.sAddedBy, CS_Strategic_Objective.dUpdated, CS_Strategic_Objective.sUpdatedBy, CS_Strategic_Objective.sAbbreviation, CS_Strategic_Objective.iStrategicProject, CS_Strategic_Objective.sImagePath, CS_Strategic_Objective.iSubStipulation, CS_Strategic_Objective.iLevel, CS_Inspection_Compliance_Domain.sInspectionComplianceDomainID, CS_Strategy_Version.sStrategyVersion, CS_Sub_Stipulation.sSubStipulationID, CS_Strategic_Project.sStrategicProjectID FROM CS_Strategic_Objective INNER JOIN CS_Inspection_Compliance_Domain ON CS_Strategic_Objective.iInspectionComplianceDomain = CS_Inspection_Compliance_Domain.iSerial INNER JOIN CS_Strategy_Version ON CS_Strategic_Objective.iStrategyVersion = CS_Strategy_Version.iSerial INNER JOIN CS_Strategic_Project ON CS_Strategic_Objective.iStrategicProject = CS_Strategic_Project.iSerial INNER JOIN CS_Sub_Stipulation ON CS_Strategic_Objective.iSubStipulation = CS_Sub_Stipulation.iSerial", sc);
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
    }
}