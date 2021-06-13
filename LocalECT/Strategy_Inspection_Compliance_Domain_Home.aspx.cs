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
    public partial class Strategy_Inspection_Compliance_Domain_Home : System.Web.UI.Page
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
                        string sid = Request.QueryString["sid"];
                        if (sid != null)
                        {
                            bindInspection_Compliance_Domain(sid);
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

        public void bindInspection_Compliance_Domain(string sid)
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew);
            SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["ECTDataNew"].ConnectionString);

            SqlCommand cmd = new SqlCommand("SELECT CS_Inspection_Compliance_Domain.iSerial, CS_Inspection_Compliance_Domain.sInspectionComplianceDomainID, CS_Inspection_Compliance_Domain.sInspectionComplianceDomainDesc,CS_Inspection_Compliance_Domain.iInspectionComplianceStandard, CS_Inspection_Compliance_Domain.iOrder, CS_Inspection_Compliance_Domain.dAdded, CS_Inspection_Compliance_Domain.sAddedBy,CS_Inspection_Compliance_Domain.dUpdated, CS_Inspection_Compliance_Domain.sUpdatedBy, CS_Inspection_Compliance_Standard.sInspectionComplianceStandardID FROM CS_Inspection_Compliance_Domain INNER JOIN CS_Inspection_Compliance_Standard ON CS_Inspection_Compliance_Domain.iInspectionComplianceStandard = CS_Inspection_Compliance_Standard.iSerial where iInspectionComplianceStandard=@iInspectionComplianceStandard", sc);
            cmd.Parameters.AddWithValue("@iInspectionComplianceStandard", sid);
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
            string sid = Request.QueryString["sid"];
            Response.Redirect("Strategy_Inspection_Compliance_Domain_Update?sid=" + sid + "");
        }
    }
}