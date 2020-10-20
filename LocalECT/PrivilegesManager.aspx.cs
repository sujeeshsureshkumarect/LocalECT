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
    public partial class PrivilegesManager : System.Web.UI.Page
    {
        LibraryMOD myLibrary = new LibraryMOD();
        int CurrentRole = 0;
        string sUserName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CurrentRole"] != null)
            {
                CurrentRole = (int)Session["CurrentRole"];
            }
            else
            {
                Session.RemoveAll();
                Response.Redirect("Login.aspx");
            }
            sUserName = Session["CurrentUserName"].ToString();
            //CurrentRole = (int)Session["CurrentRole"];
            if (!IsPostBack)
            {
                if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.Setting_RolesManager,
                InitializeModule.enumPrivilege.ShowBrowse, CurrentRole) != true)
                {
                    Server.Transfer("Authorization.aspx");

                }
            }

            lbl_Msg.Text = "";
            if (!IsPostBack)
            {
                bindprivileges();
            }
        }
        public void bindprivileges()
        {
            string constr = ConfigurationManager.ConnectionStrings["ECTDataNew"].ConnectionString;
            SqlConnection sc = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand("select * from Cmn_Privilege order by PrivilegeID asc", sc);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                RepterDetails.DataSource = dt;
                RepterDetails.DataBind();
            }
            catch (Exception ex)
            {
                sc.Close();
                throw ex;
            }
            finally
            {
                sc.Close();
            }
        }
        protected void EditBTN_Command(object sender, CommandEventArgs e)
        {
            int r = 0;
            r = Get_Privilege(int.Parse(e.CommandArgument.ToString()));            
        }
        protected void DeleteBTN_Command(object sender, CommandEventArgs e)
        {
            int PrivilegeID = 0;
            PrivilegeID = int.Parse(e.CommandArgument.ToString());
            string constr = ConfigurationManager.ConnectionStrings["ECTDataNew"].ConnectionString;
            SqlConnection sc = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand("delete from Cmn_Privilege where PrivilegeID=@PrivilegeID", sc);
            cmd.Parameters.AddWithValue("@PrivilegeID", PrivilegeID);
            try
            {
                sc.Open();
                cmd.ExecuteNonQuery();
                sc.Close();

                lbl_Msg.Text = "Privilege (ID: "+ PrivilegeID + ") Deleted Successfully";
                div_msg.Visible = true;
                div_Alert.Attributes.Add("class", "alert alert-success alert-dismissible");

                bindprivileges();
            }
            catch(Exception exp)
            {
                sc.Close();
                Console.WriteLine("{0} Exception caught.", exp);
                lbl_Msg.Text = exp.Message;
                div_msg.Visible = true;
            }
            finally
            {
                sc.Close();
            }
        }
        private int Get_Privilege(int PrivilegeID)
        {
            int r = 0;
            try
            {            
                string constr = ConfigurationManager.ConnectionStrings["ECTDataNew"].ConnectionString;
                SqlConnection sc = new SqlConnection(constr);
                SqlCommand cmd = new SqlCommand("select * from Cmn_Privilege where PrivilegeID=@PrivilegeID", sc);
                cmd.Parameters.AddWithValue("@PrivilegeID", PrivilegeID);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                try
                {
                    sc.Open();
                    da.Fill(dt);
                    sc.Close();
                    if(dt.Rows.Count>0)
                    {
                        RoleIDLBL.Text = PrivilegeID.ToString();
                        NameTXT.Text = dt.Rows[0]["PriviligeNameEn"].ToString();
                        TextBox1.Text = dt.Rows[0]["PrivilegeNameAr"].ToString();
                        SystemsCBO.SelectedIndex = SystemsCBO.Items.IndexOf(SystemsCBO.Items.FindByValue(dt.Rows[0]["DefaultEffect"].ToString()));
                        DataStatus.Value = ((int)InitializeModule.enumModes.EditMode).ToString();
                    }
                    else
                    {
                        lbl_Msg.Text = "No Data Available.";
                        div_msg.Visible = true;
                    }

                }
                catch (Exception exp)
                {
                    sc.Close();
                    Console.WriteLine("{0} Exception caught.", exp);
                    lbl_Msg.Text = exp.Message;
                    div_msg.Visible = true;
                }
                finally
                {
                    sc.Close();
                }

            }
            catch (Exception exp)
            {
                Console.WriteLine("{0} Exception caught.", exp);
                lbl_Msg.Text = exp.Message;
                div_msg.Visible = true;
            }
            finally
            {


            }
            return r;
        }

        protected void NewCMD_Click(object sender, EventArgs e)
        {
            div_msg.Visible = false;
            Connection_StringCLS myConnection_String = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);            
            try
            {
                DataStatus.Value = ((int)InitializeModule.enumModes.NewMode).ToString();

                SqlCommand cmd = new SqlCommand("select max([PrivilegeID]) as MaxID FROM [ECTDataNew].[dbo].[Cmn_Privilege]", Conn);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                try
                {
                    Conn.Open();
                    da.Fill(dt);
                    Conn.Close();
                }
                catch(Exception exp)
                {
                    Conn.Close();
                    Console.WriteLine("{0} Exception caught.", exp);
                    lbl_Msg.Text = exp.Message;
                    div_msg.Visible = true;
                }
                finally
                {
                    Conn.Close();
                }
                if(dt.Rows.Count>0)
                {
                    int maxid = Convert.ToInt32(dt.Rows[0]["MaxID"]);
                    RoleIDLBL.Text = (maxid + 1).ToString();
                    NameTXT.Text = "";
                    TextBox1.Text = "";
                    isDataChanged.Value = true.ToString();
                    SystemsCBO.SelectedValue = "0";
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine("{0} Exception caught.", exp);
                lbl_Msg.Text = exp.Message;
                div_msg.Visible = true;
            }
            finally
            {
                Conn.Close();
            }
        }

        protected void SaveCMD_Click(object sender, EventArgs e)
        {
            SaveData();
            bindprivileges();
        }
        private void SaveData()
        {
            string constr = ConfigurationManager.ConnectionStrings["ECTDataNew"].ConnectionString;
            SqlConnection sc = new SqlConnection(constr);
            try
            {
                int localRoleID = 0;
                if (string.IsNullOrEmpty(RoleIDLBL.Text))
                {
                    lbl_Msg.Text = "Edit Role or add new one!";
                    div_msg.Visible = true;
                    return;
                }
                else
                {
                    localRoleID = int.Parse(RoleIDLBL.Text);

                }

                int idataStatus = int.Parse(DataStatus.Value);

                string query = "";
                if(idataStatus==2)//New Mode
                {
                    query = "insert into Cmn_Privilege values (@PrivilegeID,@PrivilegeNameAr,@PriviligeNameEn,@DefaultEffect)";
                }
                else if(idataStatus==3)//Edit Mode
                {
                    query = "update Cmn_Privilege set PrivilegeNameAr=@PrivilegeNameAr,PriviligeNameEn=@PriviligeNameEn,DefaultEffect=@DefaultEffect where PrivilegeID=@PrivilegeID";
                }
                else
                {
                    query = "update Cmn_Privilege set PrivilegeNameAr=@PrivilegeNameAr,PriviligeNameEn=@PriviligeNameEn,DefaultEffect=@DefaultEffect where PrivilegeID=@PrivilegeID";
                }

                SqlCommand cmd = new SqlCommand(query, sc);
                cmd.Parameters.AddWithValue("@PrivilegeID", RoleIDLBL.Text.Trim());
                cmd.Parameters.AddWithValue("@PrivilegeNameAr", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@PriviligeNameEn", NameTXT.Text.Trim());
                cmd.Parameters.AddWithValue("@DefaultEffect", SystemsCBO.SelectedItem.Text);
                try
                {
                    sc.Open();
                    cmd.ExecuteNonQuery();
                    sc.Close();

                    lbl_Msg.Text = "Data Updated Successfully";
                    div_msg.Visible = true;
                    div_Alert.Attributes.Add("class", "alert alert-success alert-dismissible");
                    DataStatus.Value = ((int)InitializeModule.enumModes.EditMode).ToString();
                }
                catch(Exception exp)
                {
                    sc.Close();
                    Console.WriteLine("{0} Exception caught.", exp);
                    lbl_Msg.Text = exp.Message;
                    div_msg.Visible = true;
                }
                finally
                {
                    sc.Close();
                }
            }

            catch (Exception exp)
            {
                Console.WriteLine("{0} Exception caught.", exp);
                lbl_Msg.Text = exp.Message;
                div_msg.Visible = true;
            }
            finally
            {


            }

        }
    }
}