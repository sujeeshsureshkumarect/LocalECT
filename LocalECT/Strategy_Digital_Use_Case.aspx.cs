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
using System.Globalization;
using System.IO;

namespace LocalECT
{
  public partial class Digital_Use_Case : System.Web.UI.Page
  {
    InitializeModule.EnumCampus Campus = InitializeModule.EnumCampus.Females;
    Connection_StringCLS myConnection_String = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew);
    SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["ECTDataNew"].ConnectionString);
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
            if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.Digital_Transformation_Program,
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

            string id = Request.QueryString["id"];
            if (id != null)
            {
              bindtotal(id);
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

    public void bindtotal(string id)
    {

      Response.Write(id);

      Connection_StringCLS myConnection_String = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew);
      SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["ECTDataNew"].ConnectionString);

      SqlCommand cmd = new SqlCommand("SELECT [iSerial],[sDigitalUseCase],[dAdded],[sAddedBy],[dUpdated] ,[sUpdatedBy],iDigitalTransformationProgram FROM [dbo].[CS_Digital_Use_Case] where iDigitalTransformationProgram = @iProg", sc);
      cmd.Parameters.AddWithValue("@iProg", id);
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

    private void showErr(string sMsg)
    {
      Session["errMsg"] = sMsg;
      Response.Redirect("ErrPage.aspx");
    }

   

    protected void lnk_Create_Click(object sender, EventArgs e)
    {
      string ids = Request.QueryString["id"];
      Response.Redirect("Strategy_Digital_Use_Case_Create.aspx?id=" + ids);

    }
  }
}
