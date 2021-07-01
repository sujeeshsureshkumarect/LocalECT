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
    public partial class ECT_Services_Update : System.Web.UI.Page
    {
        Connection_StringCLS myConnection_String = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew);
        SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["ECTDataNew"].ConnectionString);
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
                        if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.STDServicesManagement,
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
                        string id = Request.QueryString["id"];
                        if (id != null)
                        {
                            getempemail();
                            bindservices(id);
                        }
                    }


                    //Host
                    if(UserEmail.Value== txt_Host.Text)
                    {
                        //Permission Check
                        if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.STDServicesManagement,
                        InitializeModule.enumPrivilege.CanUpdateServiceHost, CurrentRole) != true)
                        {
                            txt_ServiceEn.Enabled = false;
                            txt_ServiceAr.Enabled = false;
                            txt_ServiceHeaderEn.Enabled = false;
                            txt_ServiceHeaderAr.Enabled = false;
                            txt_ServiceDescEn.Enabled = false;
                            txt_ServiceDescAr.Enabled = false;
                            txt_Audience.Enabled = false;
                            txt_Host.Enabled = false;
                            txt_Finance.Enabled = false;
                            drp_Status.Enabled = false;
                        }
                        else
                        {
                            txt_ServiceEn.Enabled = true;
                            txt_ServiceAr.Enabled = true;
                            txt_ServiceHeaderEn.Enabled = true;
                            txt_ServiceHeaderAr.Enabled = true;
                            txt_ServiceDescEn.Enabled = true;
                            txt_ServiceDescAr.Enabled = true;
                            txt_Audience.Enabled = true;
                            txt_Host.Enabled = true;
                            txt_Finance.Enabled = false;//Only by Finance
                            drp_Status.Enabled = true;
                        }
                    }
                    else
                    {
                        txt_ServiceEn.Enabled = false;
                        txt_ServiceAr.Enabled = false;
                        txt_ServiceHeaderEn.Enabled = false;
                        txt_ServiceHeaderAr.Enabled = false;
                        txt_ServiceDescEn.Enabled = false;
                        txt_ServiceDescAr.Enabled = false;
                        txt_Audience.Enabled = false;
                        txt_Host.Enabled = false;
                        txt_Finance.Enabled = false;
                        drp_Status.Enabled = false;
                    }

                    //Finance
                    //if (UserEmail.Value == txt_Finance.Text)
                    //{
                        //Permission Check
                        if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.STDServicesManagement,
                        InitializeModule.enumPrivilege.CanUpdateServiceFinance, CurrentRole) != true)
                        {                            
                            txt_Finance.Enabled = false;                           
                        }
                        else
                        {                           
                            txt_Finance.Enabled = true;//Only by Finance                            
                        }
                    //}
                    //else
                    //{                        
                    //    txt_Finance.Enabled = false;                        
                    //}
                    if (Session["CurrentRole"].ToString() == "91")//SIS Admin
                    {
                        txt_ServiceEn.Enabled = true;
                        txt_ServiceAr.Enabled = true;
                        txt_ServiceHeaderEn.Enabled = true;
                        txt_ServiceHeaderAr.Enabled = true;
                        txt_ServiceDescEn.Enabled = true;
                        txt_ServiceDescAr.Enabled = true;
                        txt_Audience.Enabled = true;
                        txt_Host.Enabled = true;
                        txt_Finance.Enabled = true;
                        drp_Status.Enabled = true;
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
        public void getempemail()
        {
            SqlCommand cmd = new SqlCommand("select * from HR_Employee_Academic_Admin_Managers where EmployeeID='" + Session["EmployeeID"].ToString() + "'", sc);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                if (dt.Rows.Count > 0)
                {
                    UserEmail.Value = dt.Rows[0]["EmployeeEmail"].ToString();
                }
                else
                {
                    UserEmail.Value = null;
                }
            }
            catch (Exception ex)
            {
                sc.Close();
                Console.WriteLine("{0} Exception caught.", ex.Message);
            }
            finally
            {
                sc.Close();
            }
        }
        public void bindservices(string id)
        {
            SqlCommand cmd = new SqlCommand("select * from ECT_Services where ServiceID=@ServiceID", sc);
            cmd.Parameters.AddWithValue("@ServiceID", id);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                if(dt.Rows.Count>0)
                {
                    lbl_ID.Text = dt.Rows[0]["ServiceID"].ToString();
                    txt_ServiceEn.Text = dt.Rows[0]["ServiceEn"].ToString();
                    txt_ServiceAr.Text = dt.Rows[0]["ServiceAr"].ToString();
                    txt_ServiceHeaderEn.Text = dt.Rows[0]["ServiceHeaderEn"].ToString();
                    txt_ServiceHeaderAr.Text = dt.Rows[0]["ServiceHeaderAr"].ToString();
                    txt_ServiceDescEn.Text = dt.Rows[0]["ServiceDescEn"].ToString();
                    txt_ServiceDescAr.Text = dt.Rows[0]["ServiceDescAr"].ToString();
                    txt_Audience.Text = dt.Rows[0]["Audience"].ToString();
                    txt_Host.Text = dt.Rows[0]["Host"].ToString();
                    txt_Finance.Text = dt.Rows[0]["Finance"].ToString();
                    if (dt.Rows[0]["isActive"] != DBNull.Value)
                    {
                        bool isActive = Convert.ToBoolean(dt.Rows[0]["isActive"]);
                        int boolInt = isActive ? 1 : 0;
                        drp_Status.SelectedIndex = drp_Status.Items.IndexOf(drp_Status.Items.FindByValue(boolInt.ToString()));
                    } 
                    else
                    {
                        drp_Status.SelectedIndex = drp_Status.Items.IndexOf(drp_Status.Items.FindByValue(dt.Rows[0]["isActive"].ToString()));
                    }
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
            SqlCommand cmd = new SqlCommand("update ECT_Services set ServiceEn=@ServiceEn,ServiceAr=@ServiceAr,ServiceHeaderEn=@ServiceHeaderEn,ServiceHeaderAr=@ServiceHeaderAr,ServiceDescEn=@ServiceDescEn,ServiceDescAr=@ServiceDescAr,Audience=@Audience,Host=@Host,Finance=@Finance,isActive=@isActive where ServiceID=@ServiceID", sc);
            cmd.Parameters.AddWithValue("@ServiceEn", txt_ServiceEn.Text.Trim());
            cmd.Parameters.AddWithValue("@ServiceAr", txt_ServiceAr.Text.Trim());
            cmd.Parameters.AddWithValue("@ServiceHeaderEn", txt_ServiceHeaderEn.Text.Trim());
            cmd.Parameters.AddWithValue("@ServiceHeaderAr", txt_ServiceHeaderAr.Text.Trim());
            cmd.Parameters.AddWithValue("@ServiceDescEn", txt_ServiceDescEn.Text.Trim());
            cmd.Parameters.AddWithValue("@ServiceDescAr", txt_ServiceDescAr.Text.Trim());
            cmd.Parameters.AddWithValue("@Audience", txt_Audience.Text.Trim());
            cmd.Parameters.AddWithValue("@Host", txt_Host.Text.Trim());
            cmd.Parameters.AddWithValue("@Finance", txt_Finance.Text.Trim());
            cmd.Parameters.AddWithValue("@isActive", drp_Status.SelectedItem.Value);
            cmd.Parameters.AddWithValue("@ServiceID", lbl_ID.Text);
            try
            {
                sc.Open();
                cmd.ExecuteNonQuery();
                sc.Close();

                lbl_Msg.Text = "Service Updated Successfully";
                div_msg.Visible = true;

                bindservices(lbl_ID.Text);
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

        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ECT_Services_Management");
        }
    }
}