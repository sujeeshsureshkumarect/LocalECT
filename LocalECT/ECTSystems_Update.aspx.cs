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
    public partial class ECTSystems_Update : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CurrentRole"] != null)
            {
                if (!IsPostBack)
                {
                    string id = Request.QueryString["seqid"];
                    if (id != null)
                    {
                        bindectsystem(id);
                    }
                }
            }
            else
            {
                Session.RemoveAll();
                Response.Redirect("Login.aspx");
            }
        }
        public void bindectsystem(string id)
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew);
            SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["ECTDataNew"].ConnectionString);
            SqlCommand cmd = new SqlCommand("select * from [Cmn_LookupDetails] where [SeqID]=@SeqID", sc);
            cmd.Parameters.AddWithValue("@SeqID", id);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                if (dt.Rows.Count > 0)
                {
                    txt_Header.Text = dt.Rows[0]["DescEn"].ToString();
                    txt_Detail.Text = dt.Rows[0]["DescAr"].ToString();                    
                    bool isActive = Convert.ToBoolean(dt.Rows[0]["isActive"]);
                    int boolInt = isActive ? 1 : 0;
                    drp_Status.SelectedIndex = drp_Status.Items.IndexOf(drp_Status.Items.FindByValue(boolInt.ToString()));
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
        protected void btn_Create_Click(object sender, EventArgs e)
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew);
            SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["ECTDataNew"].ConnectionString);

            SqlCommand cmd = new SqlCommand("update Cmn_LookupDetails set DescEn=@DescEn,DescAr=@DescAr,isActive=@isActive,LastUpdateUserID=@LastUpdateUserID,LastUpdateDate=@LastUpdateDate where SeqID=@SeqID", sc);
            cmd.Parameters.AddWithValue("@DescEn", txt_Header.Text.Trim());
            cmd.Parameters.AddWithValue("@DescAr", txt_Detail.Text.Trim());           
            cmd.Parameters.AddWithValue("@isActive", drp_Status.SelectedItem.Value);
            cmd.Parameters.AddWithValue("@LastUpdateUserID", Session["CurrentUserNo"].ToString());
            cmd.Parameters.AddWithValue("@LastUpdateDate", DateTime.Now);
            cmd.Parameters.AddWithValue("@SeqID", Request.QueryString["seqid"]);
            try
            {
                sc.Open();
                cmd.ExecuteNonQuery();
                sc.Close();

                div_msg.Visible = true;

                bindectsystem(Request.QueryString["id"]);
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
            Response.Redirect("ECTSystems_Home");
        }
    }
}