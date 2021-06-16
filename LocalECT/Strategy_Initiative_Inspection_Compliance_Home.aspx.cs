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
    public partial class Strategy_Initiative_Inspection_Compliance_Home : System.Web.UI.Page
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
                        string id = Request.QueryString["id"];//KPILevelID
                        bindInitiative_Inspection_Compliance(id);
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

        public void bindInitiative_Inspection_Compliance(string id)
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew);
            SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["ECTDataNew"].ConnectionString);

            SqlCommand cmd = new SqlCommand("SELECT CS_Initiative_Inspection_Compliance.iInatiative, CS_Initiative_Inspection_Compliance.iInspectionComplianceStandard, CS_Initiative_Inspection_Compliance.iInspectionComplianceDomain, CS_Initiative_Inspection_Compliance.InspectionComplianceIndicator, CS_Initiative_Inspection_Compliance.iStrategyVersion, CS_Initiative_Inspection_Compliance.dAdded, CS_Initiative_Inspection_Compliance.sAddedBy, CS_Initiative_Inspection_Compliance.dUpdated, CS_Initiative_Inspection_Compliance.sUpdatedBy, CS_Strategic_Initiative.sInitiativeID, CS_Inspection_Compliance_Standard.sInspectionComplianceStandardID, CS_Inspection_Compliance_Domain.sInspectionComplianceDomainID, CS_Inspection_Compliance_Indicator.sInspectionComplianceIndicatorID, CS_Strategy_Version.sStrategyVersion FROM CS_Inspection_Compliance_Indicator INNER JOIN CS_Initiative_Inspection_Compliance INNER JOIN CS_Strategic_Initiative ON CS_Initiative_Inspection_Compliance.iInatiative = CS_Strategic_Initiative.iSerial INNER JOIN CS_Inspection_Compliance_Standard ON CS_Initiative_Inspection_Compliance.iInspectionComplianceStandard = CS_Inspection_Compliance_Standard.iSerial INNER JOIN CS_Inspection_Compliance_Domain ON CS_Initiative_Inspection_Compliance.iInspectionComplianceDomain = CS_Inspection_Compliance_Domain.iSerial ON CS_Inspection_Compliance_Indicator.iSerial = CS_Initiative_Inspection_Compliance.InspectionComplianceIndicator INNER JOIN CS_Strategy_Version ON CS_Initiative_Inspection_Compliance.iStrategyVersion = CS_Strategy_Version.iSerial where iInatiative=@iInatiative", sc);
            cmd.Parameters.AddWithValue("@iInatiative", id);
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
            Response.Redirect("Strategy_Initiative_Inspection_Compliance_Update?id="+ Request.QueryString["id"] + "");
        }
    }
}