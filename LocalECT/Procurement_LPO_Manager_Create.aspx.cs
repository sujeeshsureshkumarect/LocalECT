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
            DataRow dr = dt.NewRow();
            dr["rowid"] = 1;
            dr["productname"] = string.Empty;
            dr["price"] = string.Empty;
            dr["qty"] = string.Empty;
            dr["total"] = string.Empty;
            dt.Rows.Add(dr);
            ViewState["Curtbl"] = dt;
            gvDetails.DataSource = dt;
            gvDetails.DataBind();
        }
        private void AddNewRow()
        {
            int rowIndex = 0;

            if (ViewState["Curtbl"] != null)
            {
                DataTable dt = (DataTable)ViewState["Curtbl"];
                DataRow drCurrentRow = null;
                if (dt.Rows.Count > 0)
                {
                    for (int i = 1; i <= dt.Rows.Count; i++)
                    {
                        TextBox txtname = (TextBox)gvDetails.Rows[rowIndex].Cells[1].FindControl("txtName");
                        TextBox txtprice = (TextBox)gvDetails.Rows[rowIndex].Cells[3].FindControl("txtPrice");
                        TextBox txtQty = (TextBox)gvDetails.Rows[rowIndex].Cells[2].FindControl("txtQty");
                        TextBox txtTotal = (TextBox)gvDetails.Rows[rowIndex].Cells[4].FindControl("txtTotal");
                        drCurrentRow = dt.NewRow();
                        drCurrentRow["rowid"] = i + 1;
                        dt.Rows[i - 1]["productname"] = txtname.Text;
                        dt.Rows[i - 1]["price"] = txtprice.Text;
                        dt.Rows[i - 1]["qty"] = txtQty.Text;
                        dt.Rows[i - 1]["total"] = txtTotal.Text;
                        rowIndex++;
                    }
                    dt.Rows.Add(drCurrentRow);
                    ViewState["Curtbl"] = dt;
                    gvDetails.DataSource = dt;
                    gvDetails.DataBind();
                }
            }
            else
            {
                Response.Write("ViewState Value is Null");
            }
            SetOldData();
        }

        private void SetOldData()
        {
            int rowIndex = 0;
            if (ViewState["Curtbl"] != null)
            {
                DataTable dt = (DataTable)ViewState["Curtbl"];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        TextBox txtname = (TextBox)gvDetails.Rows[rowIndex].Cells[1].FindControl("txtName");
                        TextBox txtprice = (TextBox)gvDetails.Rows[rowIndex].Cells[3].FindControl("txtPrice");
                        TextBox txtQty = (TextBox)gvDetails.Rows[rowIndex].Cells[2].FindControl("txtQty");
                        TextBox txtTotal = (TextBox)gvDetails.Rows[rowIndex].Cells[4].FindControl("txtTotal");

                        txtname.Text = dt.Rows[i]["productname"].ToString();
                        txtprice.Text = dt.Rows[i]["price"].ToString();
                        txtQty.Text = dt.Rows[i]["qty"].ToString();
                        txtTotal.Text = dt.Rows[i]["total"].ToString();
                        rowIndex++;
                    }
                }
            }
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            AddNewRow();
        }
        protected void gvDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (ViewState["Curtbl"] != null)
            {
                DataTable dt = (DataTable)ViewState["Curtbl"];
                DataRow drCurrentRow = null;
                int rowIndex = Convert.ToInt32(e.RowIndex);
                if (dt.Rows.Count > 1)
                {
                    dt.Rows.Remove(dt.Rows[rowIndex]);
                    drCurrentRow = dt.NewRow();
                    ViewState["Curtbl"] = dt;
                    gvDetails.DataSource = dt;
                    gvDetails.DataBind();
                    for (int i = 0; i < gvDetails.Rows.Count - 1; i++)
                    {
                        gvDetails.Rows[i].Cells[0].Text = Convert.ToString(i + 1);
                    }
                    SetOldData();
                }
            }
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
                    lbl_lponum.Text = (maxid + 1).ToString();
                }
                else
                {
                    lbl_lponum.Text = "1";
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
        protected void lnk_Generate_Click(object sender, EventArgs e)
        {

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

        protected void txtQty_TextChanged(object sender, EventArgs e)
        {
            TextBox txtQty = (TextBox)gvDetails.Rows[((sender as TextBox).NamingContainer as GridViewRow).RowIndex].Cells[2].FindControl("txtQty");
            TextBox txtPrice = (TextBox)gvDetails.Rows[((sender as TextBox).NamingContainer as GridViewRow).RowIndex].Cells[3].FindControl("txtPrice");
            TextBox txtTotal = (TextBox)gvDetails.Rows[((sender as TextBox).NamingContainer as GridViewRow).RowIndex].Cells[4].FindControl("txtTotal");

            var qty =
 txtQty.Text.Equals(DBNull.Value) || (txtQty.Text=="")
 ? 0
 : Convert.ToInt32(txtQty.Text);

            var price =
txtPrice.Text.Equals(DBNull.Value) || (txtPrice.Text == "")
? 0
: Convert.ToInt32(txtPrice.Text);

            int total = Convert.ToInt32(qty) * Convert.ToInt32(price);
            txtTotal.Text = total.ToString();
        }

        protected void txtPrice_TextChanged(object sender, EventArgs e)
        {
            TextBox txtQty = (TextBox)gvDetails.Rows[((sender as TextBox).NamingContainer as GridViewRow).RowIndex].Cells[2].FindControl("txtQty");
            TextBox txtPrice = (TextBox)gvDetails.Rows[((sender as TextBox).NamingContainer as GridViewRow).RowIndex].Cells[3].FindControl("txtPrice");
            TextBox txtTotal = (TextBox)gvDetails.Rows[((sender as TextBox).NamingContainer as GridViewRow).RowIndex].Cells[4].FindControl("txtTotal");

            var qty =
 txtQty.Text.Equals(DBNull.Value) || (txtQty.Text == "")
 ? 0
 : Convert.ToInt32(txtQty.Text);

            var price =
txtPrice.Text.Equals(DBNull.Value) || (txtPrice.Text == "")
? 0
: Convert.ToInt32(txtPrice.Text);

            int total = Convert.ToInt32(qty) * Convert.ToInt32(price);
            txtTotal.Text = total.ToString();
        }
    }
}