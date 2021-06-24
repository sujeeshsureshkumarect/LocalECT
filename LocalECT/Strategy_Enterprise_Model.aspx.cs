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
  public partial class Strategy_Enterprise_Model : System.Web.UI.Page
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
            if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.Enterprise_Model,
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

      SqlCommand cmd = new SqlCommand("SELECT [iSerial],[sEnterpriseModel],[dAdded],[sAddedBy],[dUpdated] ,[sUpdatedBy] FROM [dbo].[CS_Enterprise_Model]", sc);
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
