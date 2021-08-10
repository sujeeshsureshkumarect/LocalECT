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
    public partial class Strategy_Strategic_KPI_Detail_Update : System.Web.UI.Page
    {
        int CurrentRole = 0;
        Connection_StringCLS myConnection_String = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew);
        SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["ECTDataNew"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            string strRefPage = "";
            if (Request.UrlReferrer != null)
            {
                strRefPage = Request.UrlReferrer.Segments[Request.UrlReferrer.Segments.Length - 1];
            }
            else
            {
                Server.Transfer("Authorization.aspx");
            }
            try
            {
                if (Session["CurrentRole"] != null)
                {
                    CurrentRole = (int)Session["CurrentRole"];
                    if (!IsPostBack)
                    {
                        if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.Strategic_Initiative,
                        InitializeModule.enumPrivilege.CS_Execute, CurrentRole) != true)
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
                        string id = Request.QueryString["id"];//iInitiative
                        string sid = Request.QueryString["sid"];//KPIID           
                        string did = Request.QueryString["did"];//DetailsID   
                        string t = Request.QueryString["t"];

                        fillKPI();
                        drp_KPI.SelectedIndex = drp_KPI.Items.IndexOf(drp_KPI.Items.FindByValue(Request.QueryString["sid"]));
                        fillStrategyVersion();
                        if (!string.IsNullOrEmpty(drp_KPI.SelectedValue))
                        {
                            drp_StrategyVersion.SelectedIndex = drp_StrategyVersion.Items.IndexOf(drp_StrategyVersion.Items.FindByValue(getStrategy_Version(drp_KPI.SelectedItem.Value)));
                        }

                        fillStrategic_Period();
                        if (!string.IsNullOrEmpty(drp_KPI.SelectedValue))
                        {
                            drp_Period.SelectedIndex = drp_Period.Items.IndexOf(drp_Period.Items.FindByValue(getTask_Period(drp_KPI.SelectedItem.Value)));
                        }
                        fillStrategicSub_Period();


                        fillDepartment();
                        if (!string.IsNullOrEmpty(drp_KPI.SelectedValue))
                        {
                            drp_Department.SelectedIndex = drp_Department.Items.IndexOf(drp_Department.Items.FindByValue(getTask_Department(drp_KPI.SelectedItem.Value)));
                        }
                        fillSection();
                        if (!string.IsNullOrEmpty(drp_KPI.SelectedValue))
                        {
                            drp_Section.SelectedIndex = drp_Section.Items.IndexOf(drp_Section.Items.FindByValue(getTask_Section(drp_KPI.SelectedItem.Value)));
                        }

                        fillKPI_Status();                        

                        if (did != null)
                        {
                            bindStrategic_KPI_Detail(did);                            
                            btn_Create.Text = "Update";
                            lbl_Header.Text = "Edit KPI Detail-Execute";
                            if (t == "v")//View
                            {
                                btn_Create.Visible = false;
                                lbl_Header.Text = "View KPI Detail-Execute";

                                drp_SubPeriod.Enabled = false;
                                txt_Value.Enabled = false;
                                drp_KPIStatus.Enabled = false;
                                txt_Note.Enabled = false;
                                txt_SubPeriodTarget.Enabled = false;
                            }
                            else if (t == "e")//Edit
                            {
                                btn_Create.Visible = true;
                                lbl_Header.Text = "Edit KPI Detail-Execute";

                                drp_SubPeriod.Enabled = true;
                                txt_Value.Enabled = true;
                                drp_KPIStatus.Enabled = true;
                                txt_Note.Enabled = true;
                                txt_SubPeriodTarget.Enabled = true;
                            }
                            if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.Strategic_Initiative,
                        InitializeModule.enumPrivilege.CS_UpdateTarget, CurrentRole) != true)
                            {
                                txt_SubPeriodTarget.Enabled = false;
                            }
                        }
                        else
                        {
                            btn_Create.Text = "Create";
                            lbl_Header.Text = "Create New KPI Detail-Execute";
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
        public void fillKPI()
        {
            SqlCommand cmd = new SqlCommand("select iSerial,sKPIID from CS_Strategic_KPI where iInitiative=@iInitiative", sc);
            cmd.Parameters.AddWithValue("@iInitiative", Request.QueryString["id"]);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                drp_KPI.DataSource = dt;
                drp_KPI.DataTextField = "sKPIID";
                drp_KPI.DataValueField = "iSerial";
                drp_KPI.DataBind();
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
        public void fillStrategyVersion()
        {
            SqlCommand cmd = new SqlCommand("select iSerial,sStrategyVersion from CS_Strategy_Version", sc);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                drp_StrategyVersion.DataSource = dt;
                drp_StrategyVersion.DataTextField = "sStrategyVersion";
                drp_StrategyVersion.DataValueField = "iSerial";
                drp_StrategyVersion.DataBind();
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
        public string getStrategy_Version(string id)
        {
            string sid = "";
            SqlCommand cmd = new SqlCommand("select iStrategyVersion from CS_Strategic_KPI where iSerial=@iSerial", sc);
            cmd.Parameters.AddWithValue("@iSerial", id);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                if (dt.Rows.Count > 0)
                {
                    sid = dt.Rows[0]["iStrategyVersion"].ToString();
                }
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
            return sid;
        }      
        public string getTask_Period(string id)
        {
            string sid = "";
            SqlCommand cmd = new SqlCommand("select iPeriod from CS_Strategic_KPI where iSerial=@iSerial", sc);
            cmd.Parameters.AddWithValue("@iSerial", id);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                if (dt.Rows.Count > 0)
                {
                    sid = dt.Rows[0]["iPeriod"].ToString();
                }
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
            return sid;
        }
        public string getTask_Department(string id)
        {
            string sid = "";
            SqlCommand cmd = new SqlCommand("select iDepartment from CS_Strategic_KPI where iSerial=@iSerial", sc);
            cmd.Parameters.AddWithValue("@iSerial", id);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                if (dt.Rows.Count > 0)
                {
                    sid = dt.Rows[0]["iDepartment"].ToString();
                }
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
            return sid;
        }
        public string getTask_Section(string id)
        {
            string sid = "";
            SqlCommand cmd = new SqlCommand("select iSection from CS_Strategic_KPI where iSerial=@iSerial", sc);
            cmd.Parameters.AddWithValue("@iSerial", id);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                if (dt.Rows.Count > 0)
                {
                    sid = dt.Rows[0]["iSection"].ToString();
                }
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
            return sid;
        }
        public void fillStrategic_Period()
        {
            if (!string.IsNullOrEmpty(drp_StrategyVersion.SelectedValue))
            {
                SqlCommand cmd = new SqlCommand("select iSerial,sPeriod from CS_Strategic_Period where iStrategyVersion=@iStrategyVersion", sc);
                cmd.Parameters.AddWithValue("@iStrategyVersion", drp_StrategyVersion.SelectedItem.Value);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                try
                {
                    sc.Open();
                    da.Fill(dt);
                    sc.Close();

                    drp_Period.DataSource = dt;
                    drp_Period.DataTextField = "sPeriod";
                    drp_Period.DataValueField = "iSerial";
                    drp_Period.DataBind();
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
        }
        public void fillStrategicSub_Period()
        {
            if (!string.IsNullOrEmpty(drp_Period.SelectedValue))
            {
                SqlCommand cmd = new SqlCommand("select iSerial,sSubPeriod from CS_Strategic_Sub_Period where iPeriod=@iPeriod", sc);
                cmd.Parameters.AddWithValue("@iPeriod", drp_Period.SelectedItem.Value);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                try
                {
                    sc.Open();
                    da.Fill(dt);
                    sc.Close();

                    drp_SubPeriod.DataSource = dt;
                    drp_SubPeriod.DataTextField = "sSubPeriod";
                    drp_SubPeriod.DataValueField = "iSerial";
                    drp_SubPeriod.DataBind();
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
        }
        public void fillDepartment()
        {
            SqlCommand cmd = new SqlCommand("select DepartmentID,DescEN from Lkp_Department where (Lkp_Department.IsActive = 1) and (Lkp_Department.DepartmentID<>-1) and Lkp_Department.DepartmentID in (SELECT [iDepartment] FROM [CS_Initiative_Dpartment_Section] where iInitiative=@iInitiative)", sc);
            cmd.Parameters.AddWithValue("@iInitiative", Request.QueryString["id"]);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                drp_Department.DataSource = dt;
                drp_Department.DataTextField = "DescEN";
                drp_Department.DataValueField = "DepartmentID";
                drp_Department.DataBind();
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
        public void fillSection()
        {
            if (!string.IsNullOrEmpty(drp_Department.SelectedValue))
            {
                SqlCommand cmd = new SqlCommand("select SectionID,DescEN from Lkp_Section where DepartmentID=@DepartmentID and Lkp_Section.SectionID in (SELECT [iSection] FROM [CS_Initiative_Dpartment_Section] where iInitiative=@iInitiative and iDepartment=@DepartmentID)", sc);
                cmd.Parameters.AddWithValue("@DepartmentID", drp_Department.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iInitiative", Request.QueryString["id"]);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                try
                {
                    sc.Open();
                    da.Fill(dt);
                    sc.Close();

                    drp_Section.DataSource = dt;
                    drp_Section.DataTextField = "DescEN";
                    drp_Section.DataValueField = "SectionID";
                    drp_Section.DataBind();
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
        }

        public void fillKPI_Status()
        {
            SqlCommand cmd = new SqlCommand("select iSerial,sKPIStatus from CS_Strategic_KPI_Status", sc);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                drp_KPIStatus.DataSource = dt;
                drp_KPIStatus.DataTextField = "sKPIStatus";
                drp_KPIStatus.DataValueField = "iSerial";
                drp_KPIStatus.DataBind();
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
        public void bindStrategic_KPI_Detail(string did)
        {
            SqlCommand cmd = new SqlCommand("select * from CS_Strategic_KPI_Detail where iSerial=@iSerial", sc);
            cmd.Parameters.AddWithValue("@iSerial", did);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                if (dt.Rows.Count > 0)
                {
                    drp_Period.SelectedIndex = drp_Period.Items.IndexOf(drp_Period.Items.FindByValue(dt.Rows[0]["iPeriod"].ToString()));
                    fillStrategicSub_Period();
                    drp_SubPeriod.SelectedIndex = drp_SubPeriod.Items.IndexOf(drp_SubPeriod.Items.FindByValue(dt.Rows[0]["iSubPeriod"].ToString()));
                    drp_KPI.SelectedIndex = drp_KPI.Items.IndexOf(drp_KPI.Items.FindByValue(dt.Rows[0]["iKPI"].ToString()));                    
                    drp_Department.SelectedIndex = drp_Department.Items.IndexOf(drp_Department.Items.FindByValue(dt.Rows[0]["iDepartment"].ToString()));
                    fillSection();
                    drp_Section.SelectedIndex = drp_Section.Items.IndexOf(drp_Section.Items.FindByValue(dt.Rows[0]["iSection"].ToString()));
                    txt_Value.Text = dt.Rows[0]["cValue"].ToString();
                    drp_KPIStatus.SelectedIndex = drp_KPIStatus.Items.IndexOf(drp_KPIStatus.Items.FindByValue(dt.Rows[0]["iKPIStatus"].ToString()));                    
                    drp_StrategyVersion.SelectedIndex = drp_StrategyVersion.Items.IndexOf(drp_StrategyVersion.Items.FindByValue(dt.Rows[0]["iStrategyVersion"].ToString()));
                    txt_Note.Text = dt.Rows[0]["sNote"].ToString();
                    txt_SubPeriodTarget.Text= dt.Rows[0]["cSubPeriodTarget"].ToString();
                }
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


        protected void lnk_Back_Click(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];//iInitiative
            string sid = Request.QueryString["sid"];//KPIID           
            string did = Request.QueryString["did"];//DetailsID   
            

            string f = Request.QueryString["f"];
            if (f != null)
            {
                Response.Redirect("Strategy_Strategic_KPI_Detail_Home.aspx?f=m&id=" + id + "&sid=" + sid + "");
            }
            else
            {
                Response.Redirect("Strategy_Strategic_KPI_Detail_Home.aspx?id=" + id + "&sid=" + sid + "");
            }
        }

        protected void drp_Department_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillSection();           
        }

        protected void btn_Create_Click(object sender, EventArgs e)
        {
            string did = Request.QueryString["did"];
            if (did != null)
            {
                if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.Strategic_Initiative,
                              InitializeModule.enumPrivilege.CS_Execute, CurrentRole) != true)
                {
                    div_msg.Visible = true;
                    div_Alert.Attributes.Add("class", "alert alert-danger alert-dismissible");
                    lbl_Msg.Text = "Sorry-You cannot Edit";
                    return;
                }

                //Update
                SqlCommand cmd = new SqlCommand("update CS_Strategic_KPI_Detail set iPeriod=@iPeriod,iSubPeriod=@iSubPeriod,cValue=@cValue,iKPI=@iKPI,dStart=@dStart,dEnd=@dEnd,iDepartment=@iDepartment,iSection=@iSection,iKPIStatus=@iKPIStatus,sNote=@sNote,iStrategyVersion=@iStrategyVersion,dUpdated=@dUpdated,sUpdatedBy=@sUpdatedBy,cSubPeriodTarget=@cSubPeriodTarget where iSerial=@iSerial", sc);
                cmd.Parameters.AddWithValue("@iPeriod", drp_Period.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iSubPeriod", drp_SubPeriod.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@cValue", txt_Value.Text.Trim());
                cmd.Parameters.AddWithValue("@iKPI", drp_KPI.SelectedItem.Value);                
                cmd.Parameters.AddWithValue("@iDepartment", drp_Department.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iSection", drp_Section.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iKPIStatus", drp_KPIStatus.SelectedItem.Value);                
                cmd.Parameters.AddWithValue("@sNote", txt_Note.Text.Trim());               
                cmd.Parameters.AddWithValue("@iStrategyVersion", drp_StrategyVersion.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@dUpdated", DateTime.Now);
                cmd.Parameters.AddWithValue("@sUpdatedBy", Session["CurrentUserName"].ToString());
                cmd.Parameters.AddWithValue("@cSubPeriodTarget", txt_SubPeriodTarget.Text.Trim());
                cmd.Parameters.AddWithValue("@iSerial", did);
                try
                {
                    sc.Open();
                    cmd.ExecuteNonQuery();
                    sc.Close();

                    div_msg.Visible = true;
                    lbl_Msg.Text = "KPI Detail-Execute Updated Successfully";
                    div_Alert.Attributes.Add("class", "alert alert-success alert-dismissible");

                    bindStrategic_KPI_Detail(did);
                }
                catch (Exception ex)
                {
                    sc.Close();
                    Console.WriteLine(ex.Message);

                    div_msg.Visible = true;
                    lbl_Msg.Text = ex.Message;
                    div_Alert.Attributes.Add("class", "alert alert-danger alert-dismissible");
                }
                finally
                {
                    sc.Close();
                }
            }
            else
            {
                if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.Strategic_Initiative,
                             InitializeModule.enumPrivilege.CS_Execute, CurrentRole) != true)
                {
                    div_msg.Visible = true;
                    div_Alert.Attributes.Add("class", "alert alert-danger alert-dismissible");
                    lbl_Msg.Text = "Sorry-You cannot Add";
                    return;
                }

                //Insert
                SqlCommand cmd = new SqlCommand("insert into CS_Strategic_KPI_Detail values (@iPeriod,@iSubPeriod,@cValue,@iKPI,@iDepartment,@iSection,@iStrategyVersion,@dAdded,@sAddedBy,@dUpdated,@sUpdatedBy,@iKPIStatus,@sNote,@cSubPeriodTarget)", sc);
                cmd.Parameters.AddWithValue("@iPeriod", drp_Period.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iSubPeriod", drp_SubPeriod.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@cValue", txt_Value.Text.Trim());
                cmd.Parameters.AddWithValue("@iKPI", drp_KPI.SelectedItem.Value);                
                cmd.Parameters.AddWithValue("@iDepartment", drp_Department.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iSection", drp_Section.SelectedItem.Value);                               
                cmd.Parameters.AddWithValue("@iStrategyVersion", drp_StrategyVersion.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@dAdded", DateTime.Now);
                cmd.Parameters.AddWithValue("@sAddedBy", Session["CurrentUserName"].ToString());
                cmd.Parameters.AddWithValue("@dUpdated", DateTime.Now);
                cmd.Parameters.AddWithValue("@sUpdatedBy", Session["CurrentUserName"].ToString());
                cmd.Parameters.AddWithValue("@iKPIStatus", drp_KPIStatus.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@sNote", txt_Note.Text.Trim());
                cmd.Parameters.AddWithValue("@cSubPeriodTarget", txt_SubPeriodTarget.Text.Trim());
                try
                {
                    sc.Open();
                    cmd.ExecuteNonQuery();
                    sc.Close();

                    div_msg.Visible = true;
                    lbl_Msg.Text = "KPI Detail-Execute Created Successfully";
                    div_Alert.Attributes.Add("class", "alert alert-success alert-dismissible");

                    txt_Value.Text = "";
                    txt_Note.Text = "";
                    txt_SubPeriodTarget.Text = "";
                }
                catch (Exception ex)
                {
                    sc.Close();
                    Console.WriteLine(ex.Message);

                    div_msg.Visible = true;
                    lbl_Msg.Text = ex.Message;
                    div_Alert.Attributes.Add("class", "alert alert-danger alert-dismissible");
                }
                finally
                {
                    sc.Close();
                }
            }
        }

        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];//iInitiative
            string sid = Request.QueryString["sid"];//KPIID           
            string did = Request.QueryString["did"];//DetailsID   
            //Response.Redirect("Strategy_Strategic_KPI_Detail_Home.aspx?id=" + id + "&sid=" + sid + "");

            string f = Request.QueryString["f"];
            if (f != null)
            {
                Response.Redirect("Strategy_Strategic_KPI_Detail_Home.aspx?f=m&id=" + id + "&sid=" + sid + "");
            }
            else
            {
                Response.Redirect("Strategy_Strategic_KPI_Detail_Home.aspx?id=" + id + "&sid=" + sid + "");
            }
        }
    }
}