using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LocalECT
{
    public partial class ECTSystems_Create : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CurrentRole"] != null)
            {
                int CurrentRole = (int)Session["CurrentRole"];
                if (!IsPostBack)
                {
                    if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.Setting_SystemsManager,
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
        }

        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ECTSystems_Home.aspx");
        }

        protected void btn_Create_Click(object sender, EventArgs e)
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew);
            SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["ECTDataNew"].ConnectionString);

            int minorid = 0;
            SqlCommand cmd1 = new SqlCommand("select max(minorid) as lastminorid from [ECTDataNew].[dbo].[Cmn_LookupDetails] where MajorID=200 ", sc);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd1);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                if(dt.Rows.Count>0)
                {
                    minorid = Convert.ToInt32(dt.Rows[0]["lastminorid"]);
                    minorid = minorid + 1;
                }
            }
            catch(Exception ex)
            {
                sc.Close();
                Console.WriteLine("{0} Exception caught.", ex);
            }
            finally
            {
                sc.Close();
            }

            SqlCommand cmd = new SqlCommand("insert into Cmn_LookupDetails (MajorID,MinorID,DescEn,DescAr,IsActive,CreationUserID,CreationDate) values (@MajorID,@MinorID,@DescEn,@DescAr,@IsActive,@CreationUserID,@CreationDate)", sc);
            cmd.Parameters.AddWithValue("@MajorID", 200);
            cmd.Parameters.AddWithValue("@MinorID", minorid);
            cmd.Parameters.AddWithValue("@DescEn", txt_Header.Text.Trim());
            cmd.Parameters.AddWithValue("@DescAr", txt_Detail.Text.Trim());
            cmd.Parameters.AddWithValue("@IsActive", drp_Status.SelectedItem.Value);
            cmd.Parameters.AddWithValue("@CreationUserID", Session["CurrentUserNo"].ToString());
            cmd.Parameters.AddWithValue("@CreationDate", DateTime.Now);
            try
            {
                sc.Open();
                cmd.ExecuteNonQuery();
                sc.Close();

                txt_Header.Text = "";
                txt_Detail.Text = "";
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
    }
}