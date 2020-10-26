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
    public partial class Procurement_LPO_Manager_Create : System.Web.UI.Page
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
                if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.Procurment_LPOManager,
                InitializeModule.enumPrivilege.ShowBrowse, CurrentRole) != true)
                {
                    Server.Transfer("Authorization.aspx");

                }
            }

            if (!IsPostBack)
            {
                getmaxlponum();
                binddepartment();
                bindsuppliers();
                lbl_Date.Text = DateTime.Now.ToString("dd/MM/yyyy");
                BindGridview();
            }
        }


        protected void BindGridview()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("rowid", typeof(int));
            dt.Columns.Add("productname", typeof(string));
            dt.Columns.Add("price", typeof(string));
            dt.Columns.Add("qty", typeof(string));
            dt.Columns.Add("total", typeof(string));
            dt.Columns.Add("add", typeof(string));
            dt.Columns.Add("add1", typeof(string));

            for (int i=0;i<10;i++)
            {
                if(i<10)
                {
                    DataRow dr = dt.NewRow();
                    dr["rowid"] = i;
                    dr["productname"] = string.Empty;
                    dr["price"] = string.Empty;
                    dr["qty"] = string.Empty;
                    dr["total"] = string.Empty;
                    dr["add"] = "show";
                    if (i<9)
                    {
                        dr["add1"] = "hide";
                    }
                    else
                    {
                        dr["add1"] = "show";
                    }
                    dt.Rows.Add(dr);
                }
                else
                {
                    DataRow dr = dt.NewRow();
                    dr["rowid"] = i;
                    dr["productname"] = string.Empty;
                    dr["price"] = string.Empty;
                    dr["qty"] = string.Empty;
                    dr["total"] = string.Empty;
                    dr["add"] ="hide";
                    dr["add1"] = "show";
                    dt.Rows.Add(dr);
                }

            }
            //ViewState["Curtbl"] = dt;
            RepterDetails.DataSource = dt;
            RepterDetails.DataBind();
        }
       
        public void getmaxlponum()
        {
            string constr = ConfigurationManager.ConnectionStrings["ECTDataNew"].ConnectionString;
            SqlConnection sc = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand("select MAX(iLPO) as MaxID from PRC_LPO_Header", sc);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();
                if(dt.Rows.Count>0)
                {
                    var id =
  dt.Rows[0]["MaxID"].Equals(DBNull.Value)
  ? 0
  : Convert.ToInt32(dt.Rows[0]["MaxID"]);
                    int maxid = Convert.ToInt32(id);
                    lbl_lponum.Text = (maxid + 1).ToString().PadLeft(3, '0');
                }
                else
                {
                    lbl_lponum.Text = "001";
                }

            }
            catch (Exception exp)
            {
                sc.Close();
                lbl_Msg.Text = exp.Message;
                div_msg.Visible = true;
            }
            finally
            {
                sc.Close();
            }
        }
        public void bindsuppliers()
        {
            string constr = ConfigurationManager.ConnectionStrings["ECTDataNew"].ConnectionString;
            SqlConnection sc = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand("select iSupplier,sSupplierName from PRC_Supplier order by sSupplierName asc", sc);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                drp_Supplier.DataSource = dt;
                drp_Supplier.DataTextField = "sSupplierName";
                drp_Supplier.DataValueField = "iSupplier";
                drp_Supplier.DataBind();

                drp_Supplier.Items.Insert(0, new System.Web.UI.WebControls.ListItem("---Select a Supplier---", "0"));

            }
            catch (Exception exp)
            {
                sc.Close();
                lbl_Msg.Text = exp.Message;
                div_msg.Visible = true;
            }
            finally
            {
                sc.Close();
            }
        }
        public void binddepartment()
        {
            string constr = ConfigurationManager.ConnectionStrings["ECTDataNew"].ConnectionString;
            SqlConnection sc = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand("SELECT dbo.Lkp_Department.DepartmentAbbreviation+'_'+dbo.Lkp_Section.SectionAbbreviation as Department,dbo.Lkp_Section.SectionID FROM dbo.Lkp_Department INNER JOIN dbo.Lkp_Section ON dbo.Lkp_Department.DepartmentID = dbo.Lkp_Section.DepartmentID where dbo.Lkp_Section.SectionID!=-1 order by Department asc", sc);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                drp_dept.DataSource = dt;
                drp_dept.DataTextField = "Department";
                drp_dept.DataValueField = "SectionID";
                drp_dept.DataBind();

                drp_dept.Items.Insert(0, new System.Web.UI.WebControls.ListItem("---Select a Department---", "0"));

            }
            catch (Exception exp)
            {
                sc.Close();
                lbl_Msg.Text = exp.Message;
                div_msg.Visible = true;
            }
            finally
            {
                sc.Close();
            }
        }
       
        protected void drp_Supplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["ECTDataNew"].ConnectionString;
            SqlConnection sc = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand("select * from PRC_Supplier where iSupplier=@iSupplier", sc);
            cmd.Parameters.AddWithValue("@iSupplier", drp_Supplier.SelectedItem.Value);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();
               
                if(dt.Rows.Count>0)
                {
                    lbl_Pobox.Text = dt.Rows[0]["sPOBox"].ToString();
                    lbl_Tel.Text = dt.Rows[0]["sPhone"].ToString();
                    lbl_Fax.Text = dt.Rows[0]["sFax"].ToString();
                }
                else
                {
                    lbl_Pobox.Text = "";
                    lbl_Tel.Text = "";
                    lbl_Fax.Text = "";
                }
            }
            catch (Exception exp)
            {
                sc.Close();
                lbl_Msg.Text = exp.Message;
                div_msg.Visible = true;
            }
            finally
            {
                sc.Close();
            }
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Procurement_LPO_Manager");
        }

        protected void lnk_Generate_Click(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["ECTDataNew"].ConnectionString;
            SqlConnection sc = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand("insert into PRC_LPO_Header values(@iLPO,@sRef,@sBRF,@sRequester,@iRequestFrom,@sInvoice,@sPayment,@sOtherTerm,@iStatus,@sPreparedBy,@sPreparedByJobDesc,@sApprovedBy,@sApprovedByJobDesc,@dDate)", sc);
            cmd.Parameters.AddWithValue("@iLPO", lbl_lponum.Text);
            cmd.Parameters.AddWithValue("@sRef", lbl_Ref.Text);
            cmd.Parameters.AddWithValue("@sBRF", lbl_brf.Text);
            cmd.Parameters.AddWithValue("@sRequester", drp_dept.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@iRequestFrom", drp_Supplier.SelectedItem.Value);
            cmd.Parameters.AddWithValue("@sInvoice", txt_Invoice.Text);
            cmd.Parameters.AddWithValue("@sPayment", txt_Payment.Text);
            cmd.Parameters.AddWithValue("@sOtherTerm", txt_other.Text);
            cmd.Parameters.AddWithValue("@iStatus", 1);
            cmd.Parameters.AddWithValue("@sPreparedBy", Session["CurrentUserName"].ToString());
            cmd.Parameters.AddWithValue("@sPreparedByJobDesc", "Test");
            cmd.Parameters.AddWithValue("@sApprovedBy", Session["CurrentUserName"].ToString());
            cmd.Parameters.AddWithValue("@sApprovedByJobDesc", "Test");
            cmd.Parameters.AddWithValue("@dDate", DateTime.Now);
            try
            {
                sc.Open();
                cmd.ExecuteNonQuery();
                sc.Close();

                foreach (RepeaterItem item in RepterDetails.Items)
                {
                    Label lbl_srno = item.FindControl("lbl_srno") as Label;
                    TextBox txt_desc = item.FindControl("txt_desc") as TextBox;
                    TextBox txt_qty = item.FindControl("txt_qty") as TextBox;
                    TextBox txt_up = item.FindControl("txt_up") as TextBox;
                    TextBox txt_total = item.FindControl("txt_total") as TextBox;
                    string desc = txt_desc.Text;

                    if (!string.IsNullOrEmpty(desc))
                    {
                        //Perform your insert operation.
                        SqlConnection sc1 = new SqlConnection(constr);
                        SqlCommand cmd1 = new SqlCommand("insert into PRC_LPO_Detail values(@iLPO,@iSerial,@sDescription,@cQTY,@cUnitPrice,@sRemark)", sc1);
                        cmd1.Parameters.AddWithValue("@iLPO", lbl_lponum.Text);
                        cmd1.Parameters.AddWithValue("@iSerial", Convert.ToInt32(lbl_srno.Text));
                        cmd1.Parameters.AddWithValue("@sDescription", txt_desc.Text.Trim());
                        cmd1.Parameters.AddWithValue("@cQTY",txt_qty.Text);
                        cmd1.Parameters.AddWithValue("@cUnitPrice", txt_up.Text);
                        cmd1.Parameters.AddWithValue("@sRemark", Math.Round((Convert.ToDouble(txt_qty.Text) * Convert.ToDouble(txt_up.Text)), 2).ToString());
                        try
                        {
                            sc1.Open();
                            cmd1.ExecuteNonQuery();
                            sc1.Close();

                            lbl_Msg.Text = "LPO (ID: " + lbl_lponum.Text + ") Created Successfully";
                            div_msg.Visible = true;
                            div_Alert.Attributes.Add("class", "alert alert-success alert-dismissible");
                            lnk_Generate.Visible = false;
                        }
                        catch(Exception exp)
                        {
                            sc.Close();
                            lbl_Msg.Text = exp.Message;
                            div_msg.Visible = true;
                        }
                        finally
                        {
                            sc.Close();
                        }
                    }
                }
                //Bind Repeater again if required
            }
            catch (Exception exp)
            {
                sc.Close();
                lbl_Msg.Text = exp.Message;
                div_msg.Visible = true;
            }
            finally
            {
                sc.Close();
            }
        }
    }
}