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
            if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.Risk_Management,
            InitializeModule.enumPrivilege.ShowBrowse, CurrentRole) != true)
            {
              Server.Transfer("Authorization.aspx");
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

      SqlCommand cmd = new SqlCommand("SELECT CS_Risk_Management.iSerial, CS_Risk_Management.sRiskManagement, CS_Risk_Management.sStatementSerialNo, CS_Risk_Management.sStatement, CS_Risk_Management.iFramework, CS_Risk_Management.iRegisatryFramework, CS_Risk_Management.iReLicensureGuideline, CS_Risk_Management.dAdded, CS_Risk_Management.sAddedBy, CS_Risk_Management.dUpdated, CS_Risk_Management.sUpdatedBy, CS_Risk_Management_Framework.sFramework, CS_Risk_Management_Registry_Framework.sRegistryFramework, CS_Stipulation_Guidelines.sGuidelinesID FROM CS_Risk_Management INNER JOIN CS_Risk_Management_Framework ON CS_Risk_Management.iFramework = CS_Risk_Management_Framework.iSerial INNER JOIN CS_Risk_Management_Registry_Framework ON CS_Risk_Management.iRegisatryFramework = CS_Risk_Management_Registry_Framework.iSerial INNER JOIN CS_Stipulation_Guidelines ON CS_Risk_Management.iReLicensureGuideline = CS_Stipulation_Guidelines.iSerial", sc);
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
