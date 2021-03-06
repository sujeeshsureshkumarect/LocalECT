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

            SqlCommand cmd = new SqlCommand("SELECT CS_Initiative_Risk.iSerial, CS_Initiative_Risk.iInitiative, CS_Initiative_Risk.iFramework, CS_Initiative_Risk.iRegistryFramework, CS_Initiative_Risk.sStatementSerialNo, CS_Initiative_Risk.sStatement, CS_Initiative_Risk.iReLicensureGuideline, CS_Initiative_Risk.dAdded, CS_Initiative_Risk.sAddedBy, CS_Initiative_Risk.dUpdated, CS_Initiative_Risk.sUpdatedBy, CS_Strategic_Initiative.sInitiativeID, CS_Risk_Management_Framework.sFramework, CS_Risk_Management_Registry_Framework.sRegistryFramework, CS_Stipulation_Guidelines.sGuidelinesID FROM CS_Risk_Management_Registry_Framework INNER JOIN CS_Strategic_Initiative INNER JOIN CS_Initiative_Risk ON CS_Strategic_Initiative.iSerial = CS_Initiative_Risk.iInitiative INNER JOIN CS_Risk_Management_Framework ON CS_Initiative_Risk.iFramework = CS_Risk_Management_Framework.iSerial ON CS_Risk_Management_Registry_Framework.iSerial = CS_Initiative_Risk.iRegistryFramework INNER JOIN CS_Stipulation_Guidelines ON CS_Initiative_Risk.iReLicensureGuideline = CS_Stipulation_Guidelines.iSerial where iInitiative=@iInitiative", sc);
            cmd.Parameters.AddWithValue("@iInitiative", Request.QueryString["id"]);
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
            string id = Request.QueryString["id"];
            Response.Redirect("Strategy_Risk_Management_Create?id=" + id + "");
        }
    }
}
