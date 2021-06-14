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
    public partial class Strategy_Strategic_Project_Update : System.Web.UI.Page
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
                        fillProjectOwner();
                        fillStrategicGoal();
                        fillStrategy_Version();
                        fillMarketCompetitiveImplication();                   
                        string id = Request.QueryString["id"];
                        string t = Request.QueryString["t"];
                        if (id != null)
                        {
                            bindStrategic_Project(id);
                            btn_Create.Text = "Update";
                            lbl_Header.Text = "Edit Strategic Project";
                            hyp_ImagePath.Visible = true;
                            if (t == "v")//View
                            {
                                btn_Create.Visible = false;
                                lbl_Header.Text = "View Strategic Project";
                                txt_StrategicProjectID.Enabled = false;
                                txt_StrategicProjectDesc.Enabled = false;
                                drp_ProjectOwner.Enabled = false;
                                txt_HierarchyProjectOwner.Enabled = false;
                                txt_OwnerDepartment.Enabled = false;
                                txt_OwnerSection.Enabled = false;
                                drp_StrategicGoal.Enabled = false;
                                txt_Order.Enabled = false;
                                drp_StrategyVersion.Enabled = false;
                                txt_Abbreviation.Enabled = false;
                                drp_MarketCompetitiveImplication.Enabled = false;
                                flp_Upload.Visible = false;
                                txt_Level.Enabled = false;
                            }
                            else if (t == "e")//Edit
                            {
                                btn_Create.Visible = true;
                                lbl_Header.Text = "Edit Strategic Project";
                                txt_StrategicProjectID.Enabled = true;
                                txt_StrategicProjectDesc.Enabled = true;
                                drp_ProjectOwner.Enabled = true;

                                txt_HierarchyProjectOwner.Enabled = false;
                                txt_OwnerDepartment.Enabled = false;
                                txt_OwnerSection.Enabled = false;

                                drp_StrategicGoal.Enabled = true;
                                txt_Order.Enabled = true;
                                drp_StrategyVersion.Enabled = true;
                                txt_Abbreviation.Enabled = true;
                                drp_MarketCompetitiveImplication.Enabled = true;
                                flp_Upload.Visible = true;
                                txt_Level.Enabled = true;
                            }
                        }
                        else
                        {
                            btn_Create.Text = "Create";
                            lbl_Header.Text = "Create New Strategic Project";
                            hyp_ImagePath.Visible = false;
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
        public void getProjectOwner(string id)
        {
            SqlCommand cmd = new SqlCommand("select EmployeeID,EmployeeDisplayName,JobTitleEn,JobTitleID,DepartmentDesc,DepartmentID,section,SectionID from HR_Employee_Academic_Admin_Managers where EmployeeID=@EmployeeID", sc);
            cmd.Parameters.AddWithValue("@EmployeeID", id);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();  
                
                if(dt.Rows.Count>0)
                {
                    txt_HierarchyProjectOwner.Text = dt.Rows[0]["JobTitleEn"].ToString();
                    hdn_iHierarchyProjectOwner.Value = dt.Rows[0]["JobTitleID"].ToString();

                    txt_OwnerDepartment.Text = dt.Rows[0]["DepartmentDesc"].ToString();
                    hdn_iOwnerDepartment.Value = dt.Rows[0]["DepartmentID"].ToString();

                    txt_OwnerSection.Text = dt.Rows[0]["section"].ToString();
                    hdn_iOwnerSection.Value = dt.Rows[0]["SectionID"].ToString();
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
        public void fillProjectOwner()
        {
            SqlCommand cmd = new SqlCommand("select EmployeeID,EmployeeDisplayName from HR_Employee_Academic_Admin_Managers order by EmployeeDisplayName", sc);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                drp_ProjectOwner.DataSource = dt;
                drp_ProjectOwner.DataTextField = "EmployeeDisplayName";
                drp_ProjectOwner.DataValueField = "EmployeeID";
                drp_ProjectOwner.DataBind();

                getProjectOwner(drp_ProjectOwner.SelectedItem.Value);
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
        public void fillStrategicGoal()
        {
            SqlCommand cmd = new SqlCommand("select iSerial,sStrategicGoalID from CS_Strategic_Goal", sc);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                drp_StrategicGoal.DataSource = dt;
                drp_StrategicGoal.DataTextField = "sStrategicGoalID";
                drp_StrategicGoal.DataValueField = "iSerial";
                drp_StrategicGoal.DataBind();
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
        public void fillStrategy_Version()
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
        public void fillMarketCompetitiveImplication()
        {
            SqlCommand cmd = new SqlCommand("select iSerial,sMarketCompetitiveImplication from CS_Market_Competitive_Implication", sc);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                drp_MarketCompetitiveImplication.DataSource = dt;
                drp_MarketCompetitiveImplication.DataTextField = "sMarketCompetitiveImplication";
                drp_MarketCompetitiveImplication.DataValueField = "iSerial";
                drp_MarketCompetitiveImplication.DataBind();
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
        public void bindStrategic_Project(string id)
        {
            SqlCommand cmd = new SqlCommand("select * from CS_Strategic_Project where iSerial=@iSerial", sc);
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
                    txt_StrategicProjectID.Text = dt.Rows[0]["sStrategicProjectID"].ToString();
                    txt_StrategicProjectDesc.Text = dt.Rows[0]["sStrategicProjectDesc"].ToString();
                    drp_ProjectOwner.SelectedIndex = drp_ProjectOwner.Items.IndexOf(drp_ProjectOwner.Items.FindByValue(dt.Rows[0]["iProjectOwner"].ToString()));
                    getProjectOwner(dt.Rows[0]["iProjectOwner"].ToString());
                    drp_StrategicGoal.SelectedIndex = drp_StrategicGoal.Items.IndexOf(drp_StrategicGoal.Items.FindByValue(dt.Rows[0]["iStrategicGoal"].ToString()));
                    txt_Order.Text = dt.Rows[0]["iOrder"].ToString();
                    drp_StrategyVersion.SelectedIndex = drp_StrategyVersion.Items.IndexOf(drp_StrategyVersion.Items.FindByValue(dt.Rows[0]["iStrategyVersion"].ToString()));
                    txt_Abbreviation.Text = dt.Rows[0]["sAbbreviation"].ToString();
                    hyp_ImagePath.NavigateUrl = dt.Rows[0]["sImagePath"].ToString();
                    drp_MarketCompetitiveImplication.SelectedIndex = drp_MarketCompetitiveImplication.Items.IndexOf(drp_MarketCompetitiveImplication.Items.FindByValue(dt.Rows[0]["iMarketCompetitiveImplication"].ToString()));                    
                    txt_Level.Text = dt.Rows[0]["iLevel"].ToString();
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
        protected void btn_Create_Click(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];
            string Imagepath = "";
            if (flp_Upload.HasFile == true)
            {
                foreach (HttpPostedFile uploadedFile in flp_Upload.PostedFiles)
                {
                    string filetype = Path.GetExtension(uploadedFile.FileName);
                    if (filetype.ToLower() == ".jpg" || filetype.ToLower() == ".jpeg" || filetype.ToLower() == ".jfif" || filetype.ToLower() == ".pjpeg" || filetype.ToLower() == ".png" || filetype.ToLower() == ".webp")
                    {
                        string fileName = Guid.NewGuid() + Path.GetExtension(uploadedFile.FileName);
                        System.Drawing.Image upImage = System.Drawing.Image.FromStream(uploadedFile.InputStream);
                        upImage.Save(Path.Combine(Server.MapPath("~/Strategy/"), fileName));
                        Imagepath += String.Format("{0}", "~/Strategy/" + fileName);
                    }
                    else
                    {
                        div_msg.Visible = true;
                        div_Alert.Attributes.Add("class", "alert alert-success alert-dismissible");
                        lbl_Msg.Text = "Only .JPG,.PNG,.BMP files are allowed";
                        return;
                    }
                }
            }
            else
            {
                Imagepath = "empty";
            }
            if (id != null)
            {
                //Update
                SqlCommand cmd = new SqlCommand("update CS_Strategic_Project set sStrategicProjectID=@sStrategicProjectID,sStrategicProjectDesc=@sStrategicProjectDesc,iHierarchyProjectOwner=@iHierarchyProjectOwner,iProjectOwner=@iProjectOwner,iStrategicGoal=@iStrategicGoal,iOrder=@iOrder,iStrategyVersion=@iStrategyVersion,sAbbreviation=@sAbbreviation,sImagePath=@sImagePath,iMarketCompetitiveImplication=@iMarketCompetitiveImplication,iOwnerDepartment=@iOwnerDepartment,iOwnerSection=@iOwnerSection,iLevel=@iLevel,dUpdated=@dUpdated,sUpdatedBy=@sUpdatedBy where iSerial=@iSerial", sc);
                cmd.Parameters.AddWithValue("@sStrategicProjectID", txt_StrategicProjectID.Text.Trim());
                cmd.Parameters.AddWithValue("@sStrategicProjectDesc", txt_StrategicProjectDesc.Text.Trim());
                cmd.Parameters.AddWithValue("@iHierarchyProjectOwner", hdn_iHierarchyProjectOwner.Value);
                cmd.Parameters.AddWithValue("@iProjectOwner", drp_ProjectOwner.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iStrategicGoal", drp_StrategicGoal.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iOrder", txt_Order.Text.Trim());
                cmd.Parameters.AddWithValue("@iStrategyVersion", drp_StrategyVersion.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@sAbbreviation", txt_Abbreviation.Text.Trim());                
                if (Imagepath == "empty")
                {
                    cmd.Parameters.AddWithValue("@sImagePath", hyp_ImagePath.NavigateUrl);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@sImagePath", Imagepath);
                }
                cmd.Parameters.AddWithValue("@iMarketCompetitiveImplication", drp_MarketCompetitiveImplication.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iOwnerDepartment", hdn_iOwnerDepartment.Value);
                cmd.Parameters.AddWithValue("@iOwnerSection", hdn_iOwnerSection.Value);
                cmd.Parameters.AddWithValue("@iLevel", txt_Level.Text.Trim());
                cmd.Parameters.AddWithValue("@dUpdated", DateTime.Now);
                cmd.Parameters.AddWithValue("@sUpdatedBy", Session["CurrentUserName"].ToString());
                cmd.Parameters.AddWithValue("@iSerial", id);
                try
                {
                    sc.Open();
                    cmd.ExecuteNonQuery();
                    sc.Close();

                    div_msg.Visible = true;
                    lbl_Msg.Text = "Strategic Project Updated Successfully";

                    bindStrategic_Project(id);
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
                SqlCommand cmd = new SqlCommand("insert into CS_Strategic_Project values (@sStrategicProjectID,@sStrategicProjectDesc,@iHierarchyProjectOwner,@iProjectOwner,@iStrategicGoal,@iOrder,@iStrategyVersion,@dAdded,@sAddedBy,@dUpdated,@sUpdatedBy,@sAbbreviation,@sImagePath,@iMarketCompetitiveImplication,@iOwnerDepartment,@iOwnerSection,@iLevel)", sc);
                cmd.Parameters.AddWithValue("@sStrategicProjectID", txt_StrategicProjectID.Text.Trim());
                cmd.Parameters.AddWithValue("@sStrategicProjectDesc", txt_StrategicProjectDesc.Text.Trim());
                cmd.Parameters.AddWithValue("@iHierarchyProjectOwner", hdn_iHierarchyProjectOwner.Value);
                cmd.Parameters.AddWithValue("@iProjectOwner", drp_ProjectOwner.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iStrategicGoal", drp_StrategicGoal.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iOrder", txt_Order.Text.Trim());
                cmd.Parameters.AddWithValue("@iStrategyVersion", drp_StrategyVersion.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@dAdded", DateTime.Now);
                cmd.Parameters.AddWithValue("@sAddedBy", Session["CurrentUserName"].ToString());
                cmd.Parameters.AddWithValue("@dUpdated", DateTime.Now);
                cmd.Parameters.AddWithValue("@sUpdatedBy", Session["CurrentUserName"].ToString());
                cmd.Parameters.AddWithValue("@sAbbreviation", txt_Abbreviation.Text.Trim());                
                if (Imagepath == "empty")
                {
                    cmd.Parameters.AddWithValue("@sImagePath", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@sImagePath", Imagepath);
                }
                cmd.Parameters.AddWithValue("@iMarketCompetitiveImplication", drp_MarketCompetitiveImplication.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iOwnerDepartment", hdn_iOwnerDepartment.Value);
                cmd.Parameters.AddWithValue("@iOwnerSection", hdn_iOwnerSection.Value);
                cmd.Parameters.AddWithValue("@iLevel", txt_Level.Text.Trim());
                try
                {
                    sc.Open();
                    cmd.ExecuteNonQuery();
                    sc.Close();

                    div_msg.Visible = true;
                    lbl_Msg.Text = "Strategic Project Created Successfully";

                    txt_StrategicProjectID.Text = "";
                    txt_StrategicProjectDesc.Text = "";
                    txt_Order.Text = "";
                    txt_Abbreviation.Text = "";
                    Imagepath = "";
                    txt_HierarchyProjectOwner.Text = "";
                    hdn_iHierarchyProjectOwner.Value = "";
                    txt_OwnerDepartment.Text = "";
                    hdn_iOwnerDepartment.Value = "";
                    txt_OwnerSection.Text = "";
                    hdn_iOwnerSection.Value = "";
                    txt_Level.Text = "";
                    drp_ProjectOwner.SelectedIndex = 0;
                    getProjectOwner(drp_ProjectOwner.SelectedItem.Value);
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

        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Strategy_Strategic_Project_Home");
        }

        protected void drp_ProjectOwner_SelectedIndexChanged(object sender, EventArgs e)
        {
            getProjectOwner(drp_ProjectOwner.SelectedItem.Value);
        }
    }
}