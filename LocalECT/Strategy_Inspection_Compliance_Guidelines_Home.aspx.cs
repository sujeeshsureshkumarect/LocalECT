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
    public partial class Strategy_Inspection_Compliance_Guidelines_Home : System.Web.UI.Page
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
                        if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.Compliance_Standard,
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
                        string InspectionComplianceStandardID = Request.QueryString["sid"];//InspectionComplianceStandardID
                        string InspectionComplianceDomainID = Request.QueryString["did"];//InspectionComplianceDomainID
                        //string InspectionComplianceIndicatorID = Request.QueryString["iid"];//InspectionComplianceIndicatorID
                        if (InspectionComplianceStandardID != null && InspectionComplianceDomainID != null)
                        {
                            bindInspection_Compliance_Guidelines(InspectionComplianceStandardID, InspectionComplianceDomainID);
                        }
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

        public void bindInspection_Compliance_Guidelines(string InspectionComplianceStandardID, string InspectionComplianceDomainID)
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew);
            SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["ECTDataNew"].ConnectionString);

            SqlCommand cmd = new SqlCommand("SELECT CS_Inspection_Compliance_Guidelines.iSerial, CS_Inspection_Compliance_Guidelines.sInspectionComplianceGuidelinesID, CS_Inspection_Compliance_Guidelines.sInspectionComplianceGuidelinesDesc, CS_Inspection_Compliance_Guidelines.iInspectionComplianceStandard, CS_Inspection_Compliance_Guidelines.iInspectionComplianceDomain,  CS_Inspection_Compliance_Guidelines.iOrder, CS_Inspection_Compliance_Guidelines.dAdded, CS_Inspection_Compliance_Guidelines.sAddedBy, CS_Inspection_Compliance_Guidelines.dUpdated, CS_Inspection_Compliance_Guidelines.sUpdatedBy, CS_Inspection_Compliance_Standard.sInspectionComplianceStandardID, CS_Inspection_Compliance_Domain.sInspectionComplianceDomainID FROM CS_Inspection_Compliance_Guidelines INNER JOIN CS_Inspection_Compliance_Standard ON CS_Inspection_Compliance_Guidelines.iInspectionComplianceStandard = CS_Inspection_Compliance_Standard.iSerial INNER JOIN CS_Inspection_Compliance_Domain ON CS_Inspection_Compliance_Guidelines.iInspectionComplianceDomain = CS_Inspection_Compliance_Domain.iSerial where CS_Inspection_Compliance_Guidelines.iInspectionComplianceStandard=@iInspectionComplianceStandard and CS_Inspection_Compliance_Guidelines.iInspectionComplianceDomain=@iInspectionComplianceDomain", sc);
            cmd.Parameters.AddWithValue("@iInspectionComplianceStandard", InspectionComplianceStandardID);
            cmd.Parameters.AddWithValue("@iInspectionComplianceDomain", InspectionComplianceDomainID);
            //cmd.Parameters.AddWithValue("@iInspectionComplianceIndicator", InspectionComplianceIndicatorID);
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
            string InspectionComplianceStandardID = Request.QueryString["sid"];//InspectionComplianceStandardID
            string InspectionComplianceDomainID = Request.QueryString["did"];//InspectionComplianceDomainID
            //string InspectionComplianceIndicatorID = Request.QueryString["iid"];//InspectionComplianceIndicatorID
            Response.Redirect("Strategy_Inspection_Compliance_Guidelines_Update?sid=" + InspectionComplianceStandardID + "&did=" + InspectionComplianceDomainID + "");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            string InspectionComplianceStandardID = Request.QueryString["sid"];//InspectionComplianceStandardID
            //string InspectionComplianceDomainID = Request.QueryString["did"];//InspectionComplianceDomainID
            Response.Redirect("Strategy_Inspection_Compliance_Domain_Home?sid=" + InspectionComplianceStandardID + "");
        }
    }
}