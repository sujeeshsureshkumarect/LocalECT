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
  public partial class CS_IRQA_Recommendation_Edit : System.Web.UI.Page
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
            if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.LinkManager,
            InitializeModule.enumPrivilege.EditUpdate, CurrentRole) != true)
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

            string id = Request.QueryString["id"];
            if (id != null)
            {
              bindlink(id);
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

    public void bindlink(string id)
    {
      SqlCommand cmd = new SqlCommand("select * from CS_IRQA_Recommendation  where iSerial=@iLink", sc);
      cmd.Parameters.AddWithValue("@iLink", id);
      DataTable dt = new DataTable();
      SqlDataAdapter da = new SqlDataAdapter(cmd);
      try
      {
        sc.Open();
        da.Fill(dt);
        sc.Close();

        if (dt.Rows.Count > 0)
        {
          txt_Rec.Text = dt.Rows[0]["sIRQARecommendation"].ToString();
        }
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

    protected void btn_Create_Click(object sender, EventArgs e)
    {
      Connection_StringCLS myConnection_String = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew);
      SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["ECTDataNew"].ConnectionString);

      SqlCommand cmd = new SqlCommand("update CS_IRQA_Recommendation set sIRQARecommendation=@sRec,dUpdated=@dAdded,sUpdatedBy=@sAddedby where iSerial=@iLink", sc);

      cmd.Parameters.AddWithValue("@sRec", txt_Rec.Text.Trim());
      cmd.Parameters.AddWithValue("@dAdded", DateTime.Now);
      cmd.Parameters.AddWithValue("@sAddedby", Session["CurrentUserName"].ToString());

      cmd.Parameters.AddWithValue("@iLink", Request.QueryString["id"]);
      try
      {
        sc.Open();
        cmd.ExecuteNonQuery();
        sc.Close();

        div_msg.Visible = true;
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

    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
      Response.Redirect("Strategy_IRQA_Recommendation");
    }
  }
}
