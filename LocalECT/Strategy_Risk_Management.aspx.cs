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
  public partial class CS_Risk_Management : System.Web.UI.Page
  {
    InitializeModule.EnumCampus Campus = InitializeModule.EnumCampus.Females;
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
            if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.LinkManager,
            InitializeModule.enumPrivilege.ShowBrowse, CurrentRole) != true)
            {
              //Server.Transfer("Authorization.aspx");
            }
          }
        }
        else
        {
          //showErr("Session is expired, Login again please...");
          Session.RemoveAll();
          Response.Redirect("Login.aspx");

        }
        if (Session["CurrentUserName"] != null)
        {
          if (!IsPostBack)
          {
            bindtotal();
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

    private void showErr(string sMsg)
    {
      Session["errMsg"] = sMsg;
      Response.Redirect("ErrPage.aspx");
    }

    public void bindtotal()
    {
      Connection_StringCLS myConnection_String = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew);
      SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["ECTDataNew"].ConnectionString);

      SqlCommand cmd = new SqlCommand("SELECT CS_Risk_Management.iSerial, CS_Risk_Management.sRiskManagement, CS_Risk_Management.dAdded, CS_Risk_Management.sAddedBy, CS_Risk_Management.dUpdated, CS_Risk_Management.sUpdatedBy, CS_Risk_Management.sStatement, CS_Risk_Management.iRiskType, CS_Risk_Management.iStipulationGuidelines, CS_Risk_Management.iInspectionComplianceGuidelines, CS_Stipulation_Guidelines.sGuidelinesID, CS_Risk_Type.sRiskType, CS_Inspection_Compliance_Guidelines.sInspectionComplianceGuidelinesID FROM CS_Risk_Management INNER JOIN CS_Risk_Type ON CS_Risk_Management.iRiskType = CS_Risk_Type.iSerial INNER JOIN CS_Stipulation_Guidelines ON CS_Risk_Management.iStipulationGuidelines = CS_Stipulation_Guidelines.iSerial INNER JOIN CS_Inspection_Compliance_Guidelines ON CS_Risk_Management.iInspectionComplianceGuidelines = CS_Inspection_Compliance_Guidelines.iSerial", sc);
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
