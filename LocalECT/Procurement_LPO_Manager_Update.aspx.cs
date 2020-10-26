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
    public partial class Procurement_LPO_Manager_Update : System.Web.UI.Page
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
                binddepartment();
                bindsuppliers();
                string id = Request.QueryString["seqid"];
                if (id != null)
                {
                    BindGridview(id);
                }
            }
        }
        protected void BindGridview(string id)
        {
            string constr = ConfigurationManager.ConnectionStrings["ECTDataNew"].ConnectionString;
            SqlConnection sc = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand("SELECT dbo.PRC_Supplier.sSupplierName, dbo.PRC_Supplier.sPhone, dbo.PRC_Supplier.sFax, dbo.PRC_Supplier.sPOBox, dbo.PRC_LPO_Header.* FROM dbo.PRC_LPO_Header INNER JOIN dbo.PRC_Supplier ON dbo.PRC_LPO_Header.iRequestFrom = dbo.PRC_Supplier.iSupplier where iLPO=@iLPO;SELECT [iLPO],[iSerial],[sDescription],[cQTY],[cUnitPrice],[sRemark], (cQTY*cUnitPrice) as Total FROM [ECTDataNew].[dbo].[PRC_LPO_Detail] where iLPO=@iLPO order by iSerial asc", sc);
            cmd.Parameters.AddWithValue("@iLPO", id);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(ds);
                sc.Close();

                //LPO Header
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lbl_Ref.Text = ds.Tables[0].Rows[0]["sRef"].ToString();
                    lbl_Date.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["dDate"]).ToString("dd/MM/yyyy");
                    lbl_brf.Text = ds.Tables[0].Rows[0]["sBRF"].ToString();
                    lbl_lponum.Text = ds.Tables[0].Rows[0]["iLPO"].ToString().PadLeft(3, '0');
                    drp_dept.SelectedIndex = drp_dept.Items.IndexOf(drp_dept.Items.FindByText(ds.Tables[0].Rows[0]["sRequester"].ToString()));
                    drp_Supplier.SelectedIndex = drp_Supplier.Items.IndexOf(drp_Supplier.Items.FindByValue(ds.Tables[0].Rows[0]["iRequestFrom"].ToString()));
                    lbl_Pobox.Text = ds.Tables[0].Rows[0]["sPOBox"].ToString();
                    lbl_Tel.Text = ds.Tables[0].Rows[0]["sPhone"].ToString();
                    lbl_Fax.Text = ds.Tables[0].Rows[0]["sFax"].ToString();

                    txt_Invoice.Text = ds.Tables[0].Rows[0]["sInvoice"].ToString();
                    txt_Payment.Text = ds.Tables[0].Rows[0]["sPayment"].ToString();
                    txt_other.Text = ds.Tables[0].Rows[0]["sOtherTerm"].ToString();
                }

                //LPO Detail
                if (ds.Tables[1].Rows.Count > 0)
                {
                    binditems(ds.Tables[1],id);                    
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

        public void binditems(DataTable dt1,string id)
        {
            DataTable dt = new DataTable();
            dt = dt1;
            dt.Columns.Add("add", typeof(string));
            dt.Columns.Add("add1", typeof(string));
            int i = dt1.Rows.Count;
            if (i < 10)
            {
                for (int j = i; j < 10; j++)
                {
                    if (j < 10)
                    {
                        DataRow dr = dt.NewRow();
                        dr["iLPO"] = id;
                        dr["iSerial"] = j;
                        dr["sDescription"] = string.Empty;
                        dr["cQTY"] = Convert.ToDecimal(0);
                        dr["cUnitPrice"] = Convert.ToDecimal(0);
                        dr["sRemark"] = string.Empty;
                        dr["Total"] = Convert.ToDecimal(0);
                        dr["add"] = "show";
                        if (j < 9)
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
                        dr["iLPO"] = id;
                        dr["iSerial"] = j;
                        dr["sDescription"] = string.Empty;
                        dr["cQTY"] = Convert.ToDecimal(0);
                        dr["cUnitPrice"] = Convert.ToDecimal(0);
                        dr["sRemark"] = string.Empty;
                        dr["Total"] = Convert.ToDecimal(0);
                        dr["add"] = "hide";
                        dr["add1"] = "show";
                        dt.Rows.Add(dr);
                    }

                }
            }

            Session["itemtable"] = dt;

            RepterDetails.DataSource = dt;
            RepterDetails.DataBind();

            //Get the totoal value use LinQ
            double totalPrice = dt.Select().Sum(p => Convert.ToDouble(p["Total"]));
            //Fill the result into textbox
            (RepterDetails.Controls[RepterDetails.Controls.Count - 1].Controls[0].FindControl("total1") as Label).Text = Math.Round(totalPrice, 2).ToString("0.00");

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

                if (dt.Rows.Count > 0)
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

            DataTable dt1=Session["itemtable"] as DataTable;
            RepterDetails.DataSource = dt1;
            RepterDetails.DataBind();

            //Get the totoal value use LinQ
            double totalPrice = dt1.Select().Sum(p => Convert.ToDouble(p["Total"]));
            //Fill the result into textbox
            (RepterDetails.Controls[RepterDetails.Controls.Count - 1].Controls[0].FindControl("total1") as Label).Text = Math.Round(totalPrice, 2).ToString("0.00");
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Procurement_LPO_Manager");
        }

        protected void lnk_Generate_Click(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["ECTDataNew"].ConnectionString;
            SqlConnection sc = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand("update PRC_LPO_Header set sRequester=@sRequester,iRequestFrom=@iRequestFrom,sInvoice=@sInvoice,sPayment=@sPayment,sOtherTerm=@sOtherTerm,iStatus=@iStatus,sPreparedBy=@sPreparedBy,sPreparedByJobDesc=@sPreparedByJobDesc,sApprovedBy=@sApprovedBy,sApprovedByJobDesc=@sApprovedByJobDesc where iLPO=@iLPO", sc);
            cmd.Parameters.AddWithValue("@iLPO", lbl_lponum.Text);
            //cmd.Parameters.AddWithValue("@sRef", lbl_Ref.Text);
            //cmd.Parameters.AddWithValue("@sBRF", lbl_brf.Text);
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
            //cmd.Parameters.AddWithValue("@dDate", DateTime.Now);
            try
            {
                sc.Open();
                cmd.ExecuteNonQuery();
                sc.Close();

                //Delete Old Detail Table
                SqlConnection sc2 = new SqlConnection(constr);
                SqlCommand cmd2 = new SqlCommand("delete from PRC_LPO_Detail where iLPO=@iLPO", sc2);
                cmd2.Parameters.AddWithValue("@iLPO", lbl_lponum.Text);
                try
                {
                    sc2.Open();
                    cmd2.ExecuteNonQuery();
                    sc2.Close();
                }
                catch(Exception exp)
                {
                    sc2.Close();
                    lbl_Msg.Text = exp.Message;
                    div_msg.Visible = true;
                }
                finally
                {
                    sc2.Close();
                }


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
                        cmd1.Parameters.AddWithValue("@cQTY", txt_qty.Text);
                        cmd1.Parameters.AddWithValue("@cUnitPrice", txt_up.Text);
                        cmd1.Parameters.AddWithValue("@sRemark", Math.Round((Convert.ToDouble(txt_qty.Text) * Convert.ToDouble(txt_up.Text)), 2).ToString());
                        try
                        {
                            sc1.Open();
                            cmd1.ExecuteNonQuery();
                            sc1.Close();

                            lbl_Msg.Text = "LPO (ID: " + lbl_lponum.Text + ") Updated Successfully";
                            div_msg.Visible = true;
                            div_Alert.Attributes.Add("class", "alert alert-success alert-dismissible");
                            lnk_Generate.Visible = false;
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

            DataTable dt1 = Session["itemtable"] as DataTable;
            RepterDetails.DataSource = dt1;
            RepterDetails.DataBind();

            //Get the totoal value use LinQ
            double totalPrice = dt1.Select().Sum(p => Convert.ToDouble(p["Total"]));
            //Fill the result into textbox
            (RepterDetails.Controls[RepterDetails.Controls.Count - 1].Controls[0].FindControl("total1") as Label).Text = Math.Round(totalPrice, 2).ToString("0.00");
        }

        protected void DeleteBTN_Command(object sender, CommandEventArgs e)
        {
            int iSerial = 0;
            int iLPO = 0;
            iSerial = int.Parse(e.CommandArgument.ToString());
            iLPO = int.Parse(e.CommandName.ToString());

            string constr = ConfigurationManager.ConnectionStrings["ECTDataNew"].ConnectionString;
            SqlConnection sc = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand("delete from PRC_LPO_Detail where iSerial=@iSerial and iLPO=@iLPO", sc);
            cmd.Parameters.AddWithValue("@iSerial", iSerial);
            cmd.Parameters.AddWithValue("@iLPO", iLPO);
            try
            {
                sc.Open();
                cmd.ExecuteNonQuery();
                sc.Close();

                lbl_Msg.Text = "Item Deleted Successfully";
                div_msg.Visible = true;
                div_Alert.Attributes.Add("class", "alert alert-success alert-dismissible");

                string id = Request.QueryString["seqid"];
                if (id != null)
                {
                    BindGridview(id);
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

    }
}