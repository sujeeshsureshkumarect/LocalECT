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
    public partial class Strategy_Strategic_Goal_Home : System.Web.UI.Page
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
                        bindStrategic_Goal();
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

        public void bindStrategic_Goal()
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew);
            SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["ECTDataNew"].ConnectionString);

            SqlCommand cmd = new SqlCommand("SELECT CS_Strategic_Goal.iSerial, CS_Strategic_Goal.sStrategicGoalID, CS_Strategic_Goal.sStrategicGoalDesc, CS_Strategic_Goal.iStipulation, CS_Strategic_Goal.iInspectioncomplianceStandard, CS_Strategic_Goal.iOrder, CS_Strategic_Goal.iStrategyVersion, CS_Strategic_Goal.dAdded, CS_Strategic_Goal.sAddedBy, CS_Strategic_Goal.dUpdated, CS_Strategic_Goal.sUpdatedBy, CS_Strategic_Goal.sAbbreviation, CS_Strategic_Goal.iTheme, CS_Strategic_Goal.sImagePath, CS_Strategic_Goal.iLevel, CS_Inspection_Compliance_Standard.sInspectionComplianceStandardID, CS_Stipulation.sStipulationID, CS_Strategic_Theme.sThemeCode, CS_Strategy_Version.sStrategyVersion FROM CS_Strategic_Theme INNER JOIN CS_Strategy_Version INNER JOIN CS_Stipulation INNER JOIN CS_Strategic_Goal ON CS_Stipulation.iSerial = CS_Strategic_Goal.iStipulation INNER JOIN CS_Inspection_Compliance_Standard ON CS_Strategic_Goal.iInspectioncomplianceStandard = CS_Inspection_Compliance_Standard.iSerial ON CS_Strategy_Version.iSerial = CS_Strategic_Goal.iStrategyVersion ON CS_Strategic_Theme.iSerial = CS_Strategic_Goal.iTheme", sc);
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