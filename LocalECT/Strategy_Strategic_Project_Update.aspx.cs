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
                        if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.Strategic_Project,
                        InitializeModule.enumPrivilege.ShowBrowse, CurrentRole) != true)
                        {
                            //Server.Transfer("Authorization.aspx");
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
                        //fillProjectOwner();

                        fillDepartment();
                        fillSection();

                        fillProjectOwner();

                        fillStrategicGoal();
                        fillStrategy_Version();
                        fillMarketCompetitiveImplication();

                        if (!string.IsNullOrEmpty(drp_StrategicGoal.SelectedValue))
                        {
                            drp_StrategyVersion.SelectedIndex = drp_StrategyVersion.Items.IndexOf(drp_StrategyVersion.Items.FindByValue(getStrategy_Version(drp_StrategicGoal.SelectedItem.Value)));
                        }
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
                                txt_ProjectOwner.Enabled = false;
                                txt_HierarchyProjectOwner.Enabled = false;
                                drp_Department.Enabled = false;
                                drp_Section.Enabled = false;
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
                                txt_ProjectOwner.Enabled = false;

                                txt_HierarchyProjectOwner.Enabled = false;
                                drp_Department.Enabled = true;
                                drp_Section.Enabled = true;

                                drp_StrategicGoal.Enabled = true;
                                txt_Order.Enabled = true;
                                drp_StrategyVersion.Enabled = false;
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
        public void fillDepartment()
        {
            SqlCommand cmd = new SqlCommand("select DepartmentID,DescEN from Lkp_Department where (Lkp_Department.IsActive = 1) and (Lkp_Department.DepartmentID<>-1)", sc);
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
                SqlCommand cmd = new SqlCommand("select SectionID,DescEN from Lkp_Section where DepartmentID=@DepartmentID", sc);
                cmd.Parameters.AddWithValue("@DepartmentID", drp_Department.SelectedItem.Value);               
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
        public void getProjectOwner(string userid,string jobid)
        {
            SqlCommand cmd = new SqlCommand("select EmployeeID,SurnameEn,FirstNameEn,FamilyNameEn from Hr_Employee where EmployeeID=@EmployeeID;select JobTitleID,JobTitleEn from Lkp_JobTitle where JobTitleID=@JobTitleID", sc);
            cmd.Parameters.AddWithValue("@EmployeeID", userid);
            cmd.Parameters.AddWithValue("@JobTitleID", jobid);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(ds);
                sc.Close();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    txt_ProjectOwner.Text = ds.Tables[0].Rows[0]["EmployeeID"].ToString() + "_" + ds.Tables[0].Rows[0]["SurnameEn"].ToString() + " " + ds.Tables[0].Rows[0]["FirstNameEn"].ToString() + " " + ds.Tables[0].Rows[0]["FamilyNameEn"].ToString();
                    hdn_ProjectOwner.Value = ds.Tables[0].Rows[0]["EmployeeID"].ToString();                                                       
                }
                if(ds.Tables[1].Rows.Count > 0)
                {
                    txt_HierarchyProjectOwner.Text = ds.Tables[1].Rows[0]["JobTitleID"].ToString() + "_" + ds.Tables[1].Rows[0]["JobTitleEn"].ToString();
                    hdn_iHierarchyProjectOwner.Value = ds.Tables[1].Rows[0]["JobTitleID"].ToString();
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
            SqlCommand cmd = new SqlCommand("SELECT Lkp_Section.ManagerID, Lkp_Section.JobIDofSectionManager, Lkp_JobTitle.JobTitleID,Lkp_JobTitle.JobTitleEn, Hr_Employee.EmployeeID, Hr_Employee.FirstNameEn, Hr_Employee.FamilyNameEn, Hr_Employee.SurnameEn FROM Lkp_Section INNER JOIN Hr_Employee ON Lkp_Section.ManagerID = Hr_Employee.EmployeeID INNER JOIN Lkp_JobTitle ON Lkp_Section.JobIDofSectionManager = Lkp_JobTitle.JobTitleID where Lkp_Section.SectionID=@SectionID", sc);
            cmd.Parameters.AddWithValue("@SectionID", drp_Section.SelectedItem.Value);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                //drp_ProjectOwner.DataSource = dt;
                //drp_ProjectOwner.DataTextField = "ManagerID";
                //drp_ProjectOwner.DataValueField = "ManagerID";
                //drp_ProjectOwner.DataBind();

                txt_ProjectOwner.Text = dt.Rows[0]["EmployeeID"].ToString()+"_"+dt.Rows[0]["SurnameEn"].ToString()+" "+ dt.Rows[0]["FirstNameEn"].ToString()+" "+ dt.Rows[0]["FamilyNameEn"].ToString();
                hdn_ProjectOwner.Value = dt.Rows[0]["ManagerID"].ToString();

                txt_HierarchyProjectOwner.Text = dt.Rows[0]["JobTitleID"].ToString() + "_" + dt.Rows[0]["JobTitleEn"].ToString();
                hdn_iHierarchyProjectOwner.Value = dt.Rows[0]["JobIDofSectionManager"].ToString();

                //getProjectOwner(drp_ProjectOwner.SelectedItem.Value);
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
        public string getStrategy_Version(string id)
        {
            string sid = "";
            SqlCommand cmd = new SqlCommand("select iStrategyVersion from CS_Strategic_Goal where iSerial=@iSerial", sc);
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
                    //drp_ProjectOwner.SelectedIndex = drp_ProjectOwner.Items.IndexOf(drp_ProjectOwner.Items.FindByValue(dt.Rows[0]["iProjectOwner"].ToString()));
                    //getProjectOwner(dt.Rows[0]["iProjectOwner"].ToString());
                    drp_Department.SelectedIndex = drp_Department.Items.IndexOf(drp_Department.Items.FindByValue(dt.Rows[0]["iOwnerDepartment"].ToString()));
                    fillSection();
                    drp_Section.SelectedIndex = drp_Section.Items.IndexOf(drp_Section.Items.FindByValue(dt.Rows[0]["iOwnerSection"].ToString()));

                    getProjectOwner(dt.Rows[0]["iProjectOwner"].ToString(), dt.Rows[0]["iHierarchyProjectOwner"].ToString());
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
                if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.Strategic_Project,
                              InitializeModule.enumPrivilege.EditUpdate, CurrentRole) != true)
                {
                    div_msg.Visible = true;
                    div_Alert.Attributes.Add("class", "alert alert-danger alert-dismissible");
                    lbl_Msg.Text = "Sorry-You cannot Edit";
                    return;
                }
                //Update
                SqlCommand cmd = new SqlCommand("update CS_Strategic_Project set sStrategicProjectID=@sStrategicProjectID,sStrategicProjectDesc=@sStrategicProjectDesc,iHierarchyProjectOwner=@iHierarchyProjectOwner,iProjectOwner=@iProjectOwner,iStrategicGoal=@iStrategicGoal,iOrder=@iOrder,iStrategyVersion=@iStrategyVersion,sAbbreviation=@sAbbreviation,sImagePath=@sImagePath,iMarketCompetitiveImplication=@iMarketCompetitiveImplication,iOwnerDepartment=@iOwnerDepartment,iOwnerSection=@iOwnerSection,iLevel=@iLevel,dUpdated=@dUpdated,sUpdatedBy=@sUpdatedBy where iSerial=@iSerial", sc);
                cmd.Parameters.AddWithValue("@sStrategicProjectID", txt_StrategicProjectID.Text.Trim());
                cmd.Parameters.AddWithValue("@sStrategicProjectDesc", txt_StrategicProjectDesc.Text.Trim());
                cmd.Parameters.AddWithValue("@iHierarchyProjectOwner", hdn_iHierarchyProjectOwner.Value);
                cmd.Parameters.AddWithValue("@iProjectOwner", hdn_ProjectOwner.Value);
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
                cmd.Parameters.AddWithValue("@iOwnerDepartment", drp_Department.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iOwnerSection", drp_Section.SelectedItem.Value);
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
                if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.Strategic_Project,
                             InitializeModule.enumPrivilege.EditUpdate, CurrentRole) != true)
                {
                    div_msg.Visible = true;
                    div_Alert.Attributes.Add("class", "alert alert-danger alert-dismissible");
                    lbl_Msg.Text = "Sorry-You cannot Add";
                    return;
                }
                //Insert
                SqlCommand cmd = new SqlCommand("insert into CS_Strategic_Project values (@sStrategicProjectID,@sStrategicProjectDesc,@iHierarchyProjectOwner,@iProjectOwner,@iStrategicGoal,@iOrder,@iStrategyVersion,@dAdded,@sAddedBy,@dUpdated,@sUpdatedBy,@sAbbreviation,@sImagePath,@iMarketCompetitiveImplication,@iOwnerDepartment,@iOwnerSection,@iLevel)", sc);
                cmd.Parameters.AddWithValue("@sStrategicProjectID", txt_StrategicProjectID.Text.Trim());
                cmd.Parameters.AddWithValue("@sStrategicProjectDesc", txt_StrategicProjectDesc.Text.Trim());
                cmd.Parameters.AddWithValue("@iHierarchyProjectOwner", hdn_iHierarchyProjectOwner.Value);
                cmd.Parameters.AddWithValue("@iProjectOwner", hdn_ProjectOwner.Value);
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
                cmd.Parameters.AddWithValue("@iOwnerDepartment", drp_Department.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iOwnerSection", drp_Section.SelectedItem.Value);
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
                    //txt_OwnerDepartment.Text = "";
                    //hdn_iOwnerDepartment.Value = "";
                    //txt_OwnerSection.Text = "";
                    //hdn_iOwnerSection.Value = "";
                    txt_Level.Text = "";
                    txt_ProjectOwner.Text = "";
                    hdn_iHierarchyProjectOwner.Value = "";
                    //getProjectOwner(drp_ProjectOwner.SelectedItem.Value);
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
            //Response.Redirect("Strategy_Strategic_Project_Home");
            string id = Request.QueryString["id"];
            string f = Request.QueryString["f"];
            if (id != null && f != null)
            {
                Response.Redirect("Strategy_Strategic_Project_Home.aspx?f=m&id=" + id + "");
            }
            else
            {
                Response.Redirect("Strategy_Strategic_Project_Home");
            }
        }

        protected void lnk_Back_Click(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];
            string f = Request.QueryString["f"];
            if (id != null && f != null)
            {
                Response.Redirect("Strategy_Strategic_Project_Home.aspx?f=m&id=" + id + "");
            }
            else
            {
                Response.Redirect("Strategy_Strategic_Project_Home");
            }
        }
        protected void drp_StrategicGoal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(drp_StrategicGoal.SelectedValue))
            {
                drp_StrategyVersion.SelectedIndex = drp_StrategyVersion.Items.IndexOf(drp_StrategyVersion.Items.FindByValue(getStrategy_Version(drp_StrategicGoal.SelectedItem.Value)));
            }
        }

        protected void drp_Department_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillSection();
            fillProjectOwner();
        }

        protected void drp_Section_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillProjectOwner();
        }
    }
}