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
    public partial class Procurement_Supplier_Manager : System.Web.UI.Page
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
                if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.Procurment_SupplierManager,
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
            SqlCommand cmd = new SqlCommand("select * from PRC_Supplier order by iSupplier asc", sc);
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
            int iSupplier = 0;
            iSupplier = int.Parse(e.CommandArgument.ToString());
            string constr = ConfigurationManager.ConnectionStrings["ECTDataNew"].ConnectionString;
            SqlConnection sc = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand("delete from PRC_Supplier where iSupplier=@iSupplier", sc);
            cmd.Parameters.AddWithValue("@iSupplier", iSupplier);
            try
            {
                sc.Open();
                cmd.ExecuteNonQuery();
                sc.Close();

                lbl_Msg.Text = "Supplier (ID: " + iSupplier + ") Deleted Successfully";
                div_msg.Visible = true;
                div_Alert.Attributes.Add("class", "alert alert-success alert-dismissible");

                bindprivileges();
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
        private int Get_Privilege(int iSupplier)
        {
            int r = 0;
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["ECTDataNew"].ConnectionString;
                SqlConnection sc = new SqlConnection(constr);
                SqlCommand cmd = new SqlCommand("select * from PRC_Supplier where iSupplier=@iSupplier", sc);
                cmd.Parameters.AddWithValue("@iSupplier", iSupplier);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                try
                {
                    sc.Open();
                    da.Fill(dt);
                    sc.Close();
                    if (dt.Rows.Count > 0)
                    {
                        RoleIDLBL.Text = iSupplier.ToString();
                        NameTXT.Text = dt.Rows[0]["sSupplierName"].ToString();
                        TextBox1.Text = dt.Rows[0]["sPhone"].ToString();
                        TextBox2.Text = dt.Rows[0]["sFax"].ToString();
                        TextBox3.Text = dt.Rows[0]["sPOBox"].ToString();                        
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

                SqlCommand cmd = new SqlCommand("select max([iSupplier]) as MaxID FROM [ECTDataNew].[dbo].[PRC_Supplier]", Conn);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                try
                {
                    Conn.Open();
                    da.Fill(dt);
                    Conn.Close();
                }
                catch (Exception exp)
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
                if (dt.Rows.Count > 0)
                {
                    var id =
    dt.Rows[0]["MaxID"].Equals(DBNull.Value)
    ? 0
    : Convert.ToInt32(dt.Rows[0]["MaxID"]);

                    int maxid = Convert.ToInt32(id);
                    RoleIDLBL.Text = (maxid + 1).ToString();
                    NameTXT.Text = "";
                    TextBox1.Text = "";
                    TextBox2.Text = "";
                    TextBox3.Text = "";
                    isDataChanged.Value = true.ToString();
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
                    lbl_Msg.Text = "Edit Supplier or add new one!";
                    div_msg.Visible = true;
                    return;
                }
                else
                {
                    localRoleID = int.Parse(RoleIDLBL.Text);

                }

                int idataStatus = int.Parse(DataStatus.Value);

                string query = "";
                if (idataStatus == 2)//New Mode
                {
                    query = "insert into PRC_Supplier values (@sSupplierName,@sPhone,@sFax,@sPOBox)";
                }
                else if (idataStatus == 3)//Edit Mode
                {
                    query = "update PRC_Supplier set sSupplierName=@sSupplierName,sPhone=@sPhone,sFax=@sFax,sPOBox=@sPOBox where iSupplier=@iSupplier";
                }
                else
                {
                    query = "update PRC_Supplier set sSupplierName=@sSupplierName,sPhone=@sPhone,sFax=@sFax,sPOBox=@sPOBox where iSupplier=@iSupplier";
                }

                SqlCommand cmd = new SqlCommand(query, sc);
                cmd.Parameters.AddWithValue("@iSupplier", RoleIDLBL.Text.Trim());
                cmd.Parameters.AddWithValue("@sSupplierName", NameTXT.Text.Trim());
                cmd.Parameters.AddWithValue("@sPhone", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@sFax", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@sPOBox", TextBox3.Text.Trim());
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

        }
    }
}