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
    public partial class Strategy_Strategic_Objective_Sub_Stipulation_Update : System.Web.UI.Page
    {
        int CurrentRole = 0;
        Connection_StringCLS myConnection_String = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew);
        SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["ECTDataNew"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["CurrentRole"] != null)
                {
                    CurrentRole = (int)Session["CurrentRole"];
                    if (!IsPostBack)
                    {
                        if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.Strategic_Initiative,
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
                        fillStrategicObjective();
                        drp_StrategicObjective.SelectedIndex = drp_StrategicObjective.Items.IndexOf(drp_StrategicObjective.Items.FindByValue(Request.QueryString["id"]));
                        fillMOERelicensureSubStipulation();
                        string id = Request.QueryString["id"];

                        btn_Create.Text = "Create";
                        lbl_Header.Text = "Create New";

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

        public void fillStrategicObjective()
        {
            SqlCommand cmd = new SqlCommand("select iSerial,sStrategicObjectiveID from CS_Strategic_Objective where iSerial=@iSerial", sc);
            cmd.Parameters.AddWithValue("@iSerial", Request.QueryString["id"]);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                drp_StrategicObjective.DataSource = dt;
                drp_StrategicObjective.DataTextField = "sStrategicObjectiveID";
                drp_StrategicObjective.DataValueField = "iSerial";
                drp_StrategicObjective.DataBind();
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
        public void fillMOERelicensureSubStipulation()
        {
            SqlCommand cmd = new SqlCommand("select iSerial,sSubStipulationID from CS_Sub_Stipulation where iSerial not in (select iSubStipulation from CS_Strategic_Objective_Sub_Stipulation where iStrategicObjective=@iStrategicObjective)", sc);
            cmd.Parameters.AddWithValue("@iStrategicObjective", Request.QueryString["id"]);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                drp_MOERelicensureSubStipulation.DataSource = dt;
                drp_MOERelicensureSubStipulation.DataTextField = "sSubStipulationID";
                drp_MOERelicensureSubStipulation.DataValueField = "iSerial";
                drp_MOERelicensureSubStipulation.DataBind();
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

        protected void btn_Create_Click(object sender, EventArgs e)
        {
            if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.Strategic_Initiative,
                             InitializeModule.enumPrivilege.EditUpdate, CurrentRole) != true)
            {
                div_msg.Visible = true;
                div_Alert.Attributes.Add("class", "alert alert-danger alert-dismissible");
                lbl_Msg.Text = "Sorry-You cannot Add";
                return;
            }

            string id = Request.QueryString["id"];

            SqlCommand cmd = new SqlCommand("insert into CS_Strategic_Objective_Sub_Stipulation values (@iStrategicObjective,@iSubStipulation,@dAdded,@sAddedBy,@dUpdated,@sUpdatedBy)", sc);
            cmd.Parameters.AddWithValue("@iStrategicObjective", drp_StrategicObjective.SelectedItem.Value);
            cmd.Parameters.AddWithValue("@iSubStipulation", drp_MOERelicensureSubStipulation.SelectedItem.Value);
            cmd.Parameters.AddWithValue("@dAdded", DateTime.Now);
            cmd.Parameters.AddWithValue("@sAddedBy", Session["CurrentUserName"].ToString());
            cmd.Parameters.AddWithValue("@dUpdated", DateTime.Now);
            cmd.Parameters.AddWithValue("@sUpdatedBy", Session["CurrentUserName"].ToString());
            try
            {
                sc.Open();
                cmd.ExecuteNonQuery();
                sc.Close();

                div_msg.Visible = true;
                lbl_Msg.Text = "Created Successfully";

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

        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Strategy_Strategic_Objective_Sub_Stipulation_Home?id=" + Request.QueryString["id"] + "");
        }

        protected void lnk_Create_Click(object sender, EventArgs e)
        {
            Response.Redirect("Strategy_Strategic_Objective_Sub_Stipulation_Home?id=" + Request.QueryString["id"] + "");
        }
    }
}