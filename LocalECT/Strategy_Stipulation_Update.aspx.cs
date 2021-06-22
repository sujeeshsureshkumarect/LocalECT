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
    public partial class Strategy_Stipulation_Update : System.Web.UI.Page
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
                        //if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.LinkManager,
                        //InitializeModule.enumPrivilege.EditUpdate, CurrentRole) != true)
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
                        string id = Request.QueryString["id"];
                        if (id != null)
                        {
                            bindstipulation(id);
                            btn_Create.Text = "Update";
                            txt_Stipulation_ID.Enabled = false;
                            lbl_Header.Text = "Edit MOE Re-licensure Stipulation";
                        }
                        else
                        {
                            btn_Create.Text = "Create";
                            txt_Stipulation_ID.Enabled = true;
                            lbl_Header.Text = "Create New MOE Re-licensure Stipulation";
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
        public void bindstipulation(string id)
        {
            SqlCommand cmd = new SqlCommand("select * from CS_Stipulation where iSerial=@iSerial", sc);
            cmd.Parameters.AddWithValue("@iSerial", id);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                if(dt.Rows.Count>0)
                {
                    txt_Stipulation_ID.Text = dt.Rows[0]["sStipulationID"].ToString();
                    txt_Stipulation_Desc.Text = dt.Rows[0]["sStipulationDesc"].ToString();
                    txt_Stipulation_Order.Text = dt.Rows[0]["iOrder"].ToString();
                }
            }
            catch(Exception ex)
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
            string id = Request.QueryString["id"];
            if (id != null)
            {
                //Update
                SqlCommand cmd = new SqlCommand("update CS_Stipulation set sStipulationID=@sStipulationID,sStipulationDesc=@sStipulationDesc,dUpdated=@dUpdated,sUpdatedBy=@sUpdatedBy,iOrder=@iOrder where iSerial=@iSerial", sc);
                cmd.Parameters.AddWithValue("@sStipulationID", txt_Stipulation_ID.Text.Trim());
                cmd.Parameters.AddWithValue("@sStipulationDesc", txt_Stipulation_Desc.Text.Trim());
                cmd.Parameters.AddWithValue("@dUpdated", DateTime.Now);
                cmd.Parameters.AddWithValue("@sUpdatedBy", Session["CurrentUserName"].ToString());
                cmd.Parameters.AddWithValue("@iOrder", txt_Stipulation_Order.Text.Trim());
                cmd.Parameters.AddWithValue("@iSerial", id);
                try
                {
                    sc.Open();
                    cmd.ExecuteNonQuery();
                    sc.Close();

                    div_msg.Visible = true;
                    lbl_Msg.Text = "MOE Re-licensure Stipulation Updated Successfully";

                    bindstipulation(id);
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
            else
            {
                //Insert
                SqlCommand cmd = new SqlCommand("insert into CS_Stipulation values (@sStipulationID,@sStipulationDesc,@dAdded,@sAddedBy,@dUpdated,@sUpdatedBy,@iOrder)", sc);
                cmd.Parameters.AddWithValue("@sStipulationID",txt_Stipulation_ID.Text.Trim());
                cmd.Parameters.AddWithValue("@sStipulationDesc",txt_Stipulation_Desc.Text.Trim());
                cmd.Parameters.AddWithValue("@dAdded",DateTime.Now);
                cmd.Parameters.AddWithValue("@sAddedBy", Session["CurrentUserName"].ToString());
                cmd.Parameters.AddWithValue("@dUpdated", DateTime.Now);
                cmd.Parameters.AddWithValue("@sUpdatedBy", Session["CurrentUserName"].ToString());
                cmd.Parameters.AddWithValue("@iOrder",txt_Stipulation_Order.Text.Trim());
                try
                {
                    sc.Open();
                    cmd.ExecuteNonQuery();
                    sc.Close();

                    div_msg.Visible = true;
                    lbl_Msg.Text = "MOE Re-licensure Stipulation Created Successfully";

                    txt_Stipulation_ID.Text = "";
                    txt_Stipulation_Desc.Text = "";
                    txt_Stipulation_Order.Text = "";
                }
                catch(Exception ex)
                {
                    sc.Close();
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    sc.Close();
                }
            }
        }

        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Strategy_Stipulation_Home");
        }
    }
}