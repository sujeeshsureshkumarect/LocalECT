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
    public partial class Strategy_SubStipulation_Guidelines_Home : System.Web.UI.Page
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
                        string StipulationID = Request.QueryString["id"];//StipulationID
                        string SubStipulationID = Request.QueryString["sid"];//SubStipulationID
                        if (StipulationID != null && SubStipulationID!=null)
                        {
                            bindsubstipulationguidelines(StipulationID, SubStipulationID);
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

        public void bindsubstipulationguidelines(string StipulationID,string SubStipulationID)
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew);
            SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["ECTDataNew"].ConnectionString);

            SqlCommand cmd = new SqlCommand("SELECT CS_Stipulation_Guidelines.iSerial, CS_Stipulation_Guidelines.sGuidelinesID, CS_Stipulation_Guidelines.sGuidelinesDesc, CS_Stipulation_Guidelines.iStipulation, CS_Stipulation_Guidelines.iSubStipulation, CS_Stipulation_Guidelines.iOrder, CS_Stipulation_Guidelines.dAdded, CS_Stipulation_Guidelines.sAddedBy, CS_Stipulation_Guidelines.dUpdated, CS_Stipulation_Guidelines.sUpdatedBy, CS_Stipulation.sStipulationID, CS_Sub_Stipulation.sSubStipulationID FROM CS_Stipulation_Guidelines INNER JOIN CS_Stipulation ON CS_Stipulation_Guidelines.iStipulation = CS_Stipulation.iSerial INNER JOIN CS_Sub_Stipulation ON CS_Stipulation_Guidelines.iSubStipulation = CS_Sub_Stipulation.iSerial where CS_Stipulation_Guidelines.iStipulation=@iStipulation and CS_Stipulation_Guidelines.iSubStipulation=@iSubStipulation", sc);
            cmd.Parameters.AddWithValue("@iStipulation", StipulationID);
            cmd.Parameters.AddWithValue("@iSubStipulation", SubStipulationID);
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
            string StipulationID = Request.QueryString["id"];//StipulationID
            string SubStipulationID = Request.QueryString["sid"];//SubStipulationID
            Response.Redirect("Strategy_SubStipulation_Guidelines_Update?id=" + StipulationID + "&sid="+ SubStipulationID + "");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            string StipulationID = Request.QueryString["id"];//StipulationID
            Response.Redirect("Strategy_SubStipulation_Home?id=" + StipulationID + "");
        }
    }
}