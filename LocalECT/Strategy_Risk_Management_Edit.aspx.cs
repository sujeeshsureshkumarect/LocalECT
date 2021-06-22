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
  public partial class CS_Risk_Management_Edit : System.Web.UI.Page
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
                        fillRiskType();
                        fillStipulationGuidelines();
                        fillInspectionComplianceGuidelines();
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
        public void fillRiskType()
        {
            SqlCommand cmd = new SqlCommand("select iSerial,sRiskType from CS_Risk_Type", sc);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                drp_RiskType.DataSource = dt;
                drp_RiskType.DataTextField = "sRiskType";
                drp_RiskType.DataValueField = "iSerial";
                drp_RiskType.DataBind();
            }
            catch (Exception ex)
            {
                sc.Close();
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sc.Close();
            }
        }
        public void fillStipulationGuidelines()
        {
            SqlCommand cmd = new SqlCommand("select iSerial,sGuidelinesID from CS_Stipulation_Guidelines", sc);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                drp_StipulationGuidelines.DataSource = dt;
                drp_StipulationGuidelines.DataTextField = "sGuidelinesID";
                drp_StipulationGuidelines.DataValueField = "iSerial";
                drp_StipulationGuidelines.DataBind();
            }
            catch (Exception ex)
            {
                sc.Close();
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sc.Close();
            }
        }
        public void fillInspectionComplianceGuidelines()
        {
            SqlCommand cmd = new SqlCommand("select iSerial,sInspectionComplianceGuidelinesID from CS_Inspection_Compliance_Guidelines", sc);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                drp_InspectionComplianceGuidelines.DataSource = dt;
                drp_InspectionComplianceGuidelines.DataTextField = "sInspectionComplianceGuidelinesID";
                drp_InspectionComplianceGuidelines.DataValueField = "iSerial";
                drp_InspectionComplianceGuidelines.DataBind();
            }
            catch (Exception ex)
            {
                sc.Close();
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sc.Close();
            }
        }
        public void bindlink(string id)
    {
      SqlCommand cmd = new SqlCommand("select * from CS_Risk_Management  where iSerial=@iLink", sc);
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
          txt_Risk.Text = dt.Rows[0]["sRiskManagement"].ToString();
                    txt_Statement.Text= dt.Rows[0]["sStatement"].ToString();
                    drp_RiskType.SelectedIndex = drp_RiskType.Items.IndexOf(drp_RiskType.Items.FindByValue(dt.Rows[0]["iRiskType"].ToString()));
                    drp_StipulationGuidelines.SelectedIndex = drp_StipulationGuidelines.Items.IndexOf(drp_StipulationGuidelines.Items.FindByValue(dt.Rows[0]["iStipulationGuidelines"].ToString()));
                    drp_InspectionComplianceGuidelines.SelectedIndex = drp_InspectionComplianceGuidelines.Items.IndexOf(drp_InspectionComplianceGuidelines.Items.FindByValue(dt.Rows[0]["iInspectionComplianceGuidelines"].ToString()));
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

            SqlCommand cmd = new SqlCommand("update CS_Risk_Management set sRiskManagement=@sProg,dUpdated=@dAdded,sUpdatedBy=@sAddedby,sStatement=@sStatement,iRiskType=@iRiskType,iStipulationGuidelines=@iStipulationGuidelines,iInspectionComplianceGuidelines=@iInspectionComplianceGuidelines where iSerial=@iLink", sc);

            cmd.Parameters.AddWithValue("@sProg", txt_Risk.Text.Trim());
            cmd.Parameters.AddWithValue("@dAdded", DateTime.Now);
            cmd.Parameters.AddWithValue("@sAddedby", Session["CurrentUserName"].ToString());

            cmd.Parameters.AddWithValue("@sStatement", txt_Statement.Text.Trim());
            cmd.Parameters.AddWithValue("@iRiskType", drp_RiskType.SelectedItem.Value);
            cmd.Parameters.AddWithValue("@iStipulationGuidelines", drp_StipulationGuidelines.SelectedItem.Value);
            cmd.Parameters.AddWithValue("@iInspectionComplianceGuidelines", drp_InspectionComplianceGuidelines.SelectedItem.Value);

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
      Response.Redirect("Strategy_Risk_Management");
    }
  }
}
