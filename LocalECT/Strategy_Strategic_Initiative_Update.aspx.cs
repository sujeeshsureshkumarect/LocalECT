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
    public partial class Strategy_Strategic_Initiative_Update : System.Web.UI.Page
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
                        fillUniversityStatus();
                        fillInitiativePriority();
                        fillInitiativeMaturity();
                        fillDigitalTransformationProgram();
                        fillDigitalUseCase();
                        fillEnterpriseModel();
                        fillStrategyVersion();
                        fillValuePropositionImpact();

                        fillDepartment();
                        fillSection();

                        fillTheme();
                        fillGoal();
                        fillProject();
                        fillObjective();

                        if (!string.IsNullOrEmpty(drp_Objective.SelectedValue))
                        {
                            drp_StrategyVersion.SelectedIndex = drp_StrategyVersion.Items.IndexOf(drp_StrategyVersion.Items.FindByValue(getStrategy_Version(drp_Objective.SelectedItem.Value)));
                        }

                        string id = Request.QueryString["id"];
                        string t = Request.QueryString["t"];
                        if (id != null)
                        {
                            bindStrategic_Initiative(id);
                            btn_Create.Text = "Update";
                            lbl_Header.Text = "Edit Strategic Initiative";
                            hyp_ImagePath.Visible = true;
                            if (t == "v")//View
                            {
                                btn_Create.Visible = false;
                                lbl_Header.Text = "View Strategic Initiative";
                                txt_InitiativeID.Enabled = false;
                                txt_InitiativeDesc.Enabled = false;
                                drp_UniversityStatus.Enabled = false;
                                drp_InitiativePriority.Enabled = false;
                                drp_InitiativeMaturity.Enabled = false;
                                drp_DigitalTransformationProgram.Enabled = false;
                                drp_DigitalUseCase.Enabled = false;
                                drp_EnterpriseModel.Enabled = false;
                                drp_Department.Enabled = false;
                                drp_Section.Enabled = false;
                                drp_Theme.Enabled = false;
                                drp_Goal.Enabled = false;
                                drp_Project.Enabled = false;
                                drp_Objective.Enabled = false;
                                txt_Order.Enabled = false;
                                drp_StrategyVersion.Enabled = false;
                                txt_Abbreviation.Enabled = false;
                                drp_ValuePropositionImpact.Enabled = false;
                                flp_Upload.Visible = false;
                                txt_Level.Enabled = false;
                            }
                            else if (t == "e")//Edit
                            {
                                btn_Create.Visible = true;
                                lbl_Header.Text = "Edit Strategic Initiative";
                                txt_InitiativeID.Enabled = true;
                                txt_InitiativeDesc.Enabled = true;
                                drp_UniversityStatus.Enabled = true;
                                drp_InitiativePriority.Enabled = true;
                                drp_InitiativeMaturity.Enabled = true;
                                drp_DigitalTransformationProgram.Enabled = true;
                                drp_DigitalUseCase.Enabled = true;
                                drp_EnterpriseModel.Enabled = true;
                                drp_Department.Enabled = true;
                                drp_Section.Enabled = true;
                                drp_Theme.Enabled = true;
                                drp_Goal.Enabled = true;
                                drp_Project.Enabled = true;
                                drp_Objective.Enabled = true;
                                txt_Order.Enabled = true;
                                drp_StrategyVersion.Enabled = false;
                                txt_Abbreviation.Enabled = true;
                                drp_ValuePropositionImpact.Enabled = true;
                                flp_Upload.Visible = true;
                                txt_Level.Enabled = true;
                            }
                        }
                        else
                        {
                            btn_Create.Text = "Create";
                            lbl_Header.Text = "Create New Strategic Initiative";
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
        public void fillUniversityStatus()
        {
            SqlCommand cmd = new SqlCommand("select iSerial,sUniversityStatus from CS_University_Status", sc);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                drp_UniversityStatus.DataSource = dt;
                drp_UniversityStatus.DataTextField = "sUniversityStatus";
                drp_UniversityStatus.DataValueField = "iSerial";
                drp_UniversityStatus.DataBind();
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
        public void fillInitiativePriority()
        {
            SqlCommand cmd = new SqlCommand("select iSerial,sInitiativePriority from CS_Initiative_Priority", sc);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                drp_InitiativePriority.DataSource = dt;
                drp_InitiativePriority.DataTextField = "sInitiativePriority";
                drp_InitiativePriority.DataValueField = "iSerial";
                drp_InitiativePriority.DataBind();
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
        public void fillInitiativeMaturity()
        {
            SqlCommand cmd = new SqlCommand("select iSerial,sInitiativeMaturity from CS_Initiative_Maturity", sc);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                drp_InitiativeMaturity.DataSource = dt;
                drp_InitiativeMaturity.DataTextField = "sInitiativeMaturity";
                drp_InitiativeMaturity.DataValueField = "iSerial";
                drp_InitiativeMaturity.DataBind();
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
        public void fillDigitalTransformationProgram()
        {
            SqlCommand cmd = new SqlCommand("select iSerial,sDigitalTransformationProgram from CS_Digital_Transformation_Program", sc);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                drp_DigitalTransformationProgram.DataSource = dt;
                drp_DigitalTransformationProgram.DataTextField = "sDigitalTransformationProgram";
                drp_DigitalTransformationProgram.DataValueField = "iSerial";
                drp_DigitalTransformationProgram.DataBind();
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
        public void fillDigitalUseCase()
        {
            SqlCommand cmd = new SqlCommand("select iSerial,sDigitalUseCase from CS_Digital_Use_Case", sc);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                drp_DigitalUseCase.DataSource = dt;
                drp_DigitalUseCase.DataTextField = "sDigitalUseCase";
                drp_DigitalUseCase.DataValueField = "iSerial";
                drp_DigitalUseCase.DataBind();
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
        public void fillEnterpriseModel()
        {
            SqlCommand cmd = new SqlCommand("select iSerial,sEnterpriseModel from CS_Enterprise_Model", sc);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                drp_EnterpriseModel.DataSource = dt;
                drp_EnterpriseModel.DataTextField = "sEnterpriseModel";
                drp_EnterpriseModel.DataValueField = "iSerial";
                drp_EnterpriseModel.DataBind();
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

                //fillSection();
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
        public void fillTheme()
        {
            SqlCommand cmd = new SqlCommand("select iSerial,sThemeCode from CS_Strategic_Theme", sc);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                drp_Theme.DataSource = dt;
                drp_Theme.DataTextField = "sThemeCode";
                drp_Theme.DataValueField = "iSerial";
                drp_Theme.DataBind();

                //fillGoal();
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
        public void fillGoal()
        {
            if(!string.IsNullOrEmpty(drp_Theme.SelectedValue))
            {
                SqlCommand cmd = new SqlCommand("select iSerial,sStrategicGoalID from CS_Strategic_Goal where iTheme=@iTheme", sc);
                cmd.Parameters.AddWithValue("@iTheme", drp_Theme.SelectedItem.Value);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                try
                {
                    sc.Open();
                    da.Fill(dt);
                    sc.Close();

                    drp_Goal.DataSource = dt;
                    drp_Goal.DataTextField = "sStrategicGoalID";
                    drp_Goal.DataValueField = "iSerial";
                    drp_Goal.DataBind();

                    //fillProject();
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
        public void fillProject()
        {
            if (!string.IsNullOrEmpty(drp_Goal.SelectedValue))
            {
                SqlCommand cmd = new SqlCommand("select iSerial,sStrategicProjectID from CS_Strategic_Project where iStrategicGoal=@iStrategicGoal", sc);
                cmd.Parameters.AddWithValue("@iStrategicGoal", drp_Goal.SelectedItem.Value);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                try
                {
                    sc.Open();
                    da.Fill(dt);
                    sc.Close();

                    drp_Project.DataSource = dt;
                    drp_Project.DataTextField = "sStrategicProjectID";
                    drp_Project.DataValueField = "iSerial";
                    drp_Project.DataBind();

                    //fillObjective();
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
        public void fillObjective()
        {
            if (!string.IsNullOrEmpty(drp_Project.SelectedValue))
            {
                SqlCommand cmd = new SqlCommand("select iSerial,sStrategicObjectiveID from CS_Strategic_Objective where iStrategicProject=@iStrategicProject", sc);
                cmd.Parameters.AddWithValue("@iStrategicProject", drp_Project.SelectedItem.Value);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                try
                {
                    sc.Open();
                    da.Fill(dt);
                    sc.Close();

                    drp_Objective.DataSource = dt;
                    drp_Objective.DataTextField = "sStrategicObjectiveID";
                    drp_Objective.DataValueField = "iSerial";
                    drp_Objective.DataBind();
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
        public string getStrategy_Version(string id)
        {
            string sid = "";
            SqlCommand cmd = new SqlCommand("select iStrategyVersion from CS_Strategic_Objective where iSerial=@iSerial", sc);
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
        public void fillValuePropositionImpact()
        {
            SqlCommand cmd = new SqlCommand("select iSerial,sValuePropositionImpact from CS_Value_Proposition_Impact", sc);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                drp_ValuePropositionImpact.DataSource = dt;
                drp_ValuePropositionImpact.DataTextField = "sValuePropositionImpact";
                drp_ValuePropositionImpact.DataValueField = "iSerial";
                drp_ValuePropositionImpact.DataBind();
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
        public void bindStrategic_Initiative(string id)
        {
            SqlCommand cmd = new SqlCommand("select * from CS_Strategic_Initiative where iSerial=@iSerial", sc);
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
                    txt_InitiativeID.Text = dt.Rows[0]["sInitiativeID"].ToString();
                    txt_InitiativeDesc.Text = dt.Rows[0]["sInitiativeDesc"].ToString();
                    drp_UniversityStatus.SelectedIndex = drp_UniversityStatus.Items.IndexOf(drp_UniversityStatus.Items.FindByValue(dt.Rows[0]["iUniversityStatus"].ToString()));
                    drp_InitiativePriority.SelectedIndex = drp_InitiativePriority.Items.IndexOf(drp_InitiativePriority.Items.FindByValue(dt.Rows[0]["iInitiativePriority"].ToString()));
                    drp_InitiativeMaturity.SelectedIndex = drp_InitiativeMaturity.Items.IndexOf(drp_InitiativeMaturity.Items.FindByValue(dt.Rows[0]["iInitiativeMaturity"].ToString()));
                    drp_DigitalTransformationProgram.SelectedIndex = drp_DigitalTransformationProgram.Items.IndexOf(drp_DigitalTransformationProgram.Items.FindByValue(dt.Rows[0]["iDigitalTransformationProgram"].ToString()));
                    drp_DigitalUseCase.SelectedIndex = drp_DigitalUseCase.Items.IndexOf(drp_DigitalUseCase.Items.FindByValue(dt.Rows[0]["iDigitalUseCase"].ToString()));
                    drp_EnterpriseModel.SelectedIndex = drp_EnterpriseModel.Items.IndexOf(drp_EnterpriseModel.Items.FindByValue(dt.Rows[0]["iEnterpriseModel"].ToString()));
                    drp_Department.SelectedIndex = drp_Department.Items.IndexOf(drp_Department.Items.FindByValue(dt.Rows[0]["iDepartment"].ToString()));
                    fillSection();
                    drp_Section.SelectedIndex = drp_Section.Items.IndexOf(drp_Section.Items.FindByValue(dt.Rows[0]["iSection"].ToString()));
                    drp_Theme.SelectedIndex = drp_Theme.Items.IndexOf(drp_Theme.Items.FindByValue(dt.Rows[0]["iTheme"].ToString()));
                    fillGoal();
                    drp_Goal.SelectedIndex = drp_Goal.Items.IndexOf(drp_Goal.Items.FindByValue(dt.Rows[0]["iGoal"].ToString()));
                    fillProject();
                    drp_Project.SelectedIndex = drp_Project.Items.IndexOf(drp_Project.Items.FindByValue(dt.Rows[0]["iProject"].ToString()));
                    fillObjective();
                    drp_Objective.SelectedIndex = drp_Objective.Items.IndexOf(drp_Objective.Items.FindByValue(dt.Rows[0]["iObjective"].ToString()));
                    txt_Order.Text = dt.Rows[0]["iOrder"].ToString();
                    drp_StrategyVersion.SelectedIndex = drp_StrategyVersion.Items.IndexOf(drp_StrategyVersion.Items.FindByValue(dt.Rows[0]["iStrategyVersion"].ToString()));
                    txt_Abbreviation.Text = dt.Rows[0]["sAbbreviation"].ToString();
                    drp_ValuePropositionImpact.SelectedIndex = drp_ValuePropositionImpact.Items.IndexOf(drp_ValuePropositionImpact.Items.FindByValue(dt.Rows[0]["iValuePropositionImpact"].ToString()));
                    hyp_ImagePath.NavigateUrl = dt.Rows[0]["sImagePath"].ToString();
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
                SqlCommand cmd = new SqlCommand("update CS_Strategic_Initiative set sInitiativeID=@sInitiativeID,sInitiativeDesc=@sInitiativeDesc,iUniversityStatus=@iUniversityStatus,iInitiativePriority=@iInitiativePriority,iInitiativeMaturity=@iInitiativeMaturity,iDigitalTransformationProgram=@iDigitalTransformationProgram,iDigitalUseCase=@iDigitalUseCase,iEnterpriseModel=@iEnterpriseModel,iDepartment=@iDepartment,iSection=@iSection,iTheme=@iTheme,iGoal=@iGoal,iProject=@iProject,iObjective=@iObjective,iOrder=@iOrder,iStrategyVersion=@iStrategyVersion,sAbbreviation=@sAbbreviation,iValuePropositionImpact=@iValuePropositionImpact,sImagePath=@sImagePath,iLevel=@iLevel,dUpdated=@dUpdated,sUpdatedBy=@sUpdatedBy where iSerial=@iSerial", sc);
                cmd.Parameters.AddWithValue("@sInitiativeID", txt_InitiativeID.Text.Trim());
                cmd.Parameters.AddWithValue("@sInitiativeDesc", txt_InitiativeDesc.Text.Trim());
                cmd.Parameters.AddWithValue("@iUniversityStatus", drp_UniversityStatus.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iInitiativePriority", drp_InitiativePriority.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iInitiativeMaturity", drp_InitiativeMaturity.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iDigitalTransformationProgram", drp_DigitalTransformationProgram.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iDigitalUseCase", drp_DigitalUseCase.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iEnterpriseModel", drp_EnterpriseModel.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iDepartment", drp_Department.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iSection", drp_Section.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iTheme", drp_Theme.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iGoal", drp_Goal.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iProject", drp_Project.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iObjective", drp_Objective.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iOrder", txt_Order.Text.Trim());
                cmd.Parameters.AddWithValue("@iStrategyVersion", drp_StrategyVersion.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@sAbbreviation", txt_Abbreviation.Text.Trim());
                cmd.Parameters.AddWithValue("@iValuePropositionImpact", drp_ValuePropositionImpact.SelectedItem.Value);
                if (Imagepath == "empty")
                {
                    cmd.Parameters.AddWithValue("@sImagePath", hyp_ImagePath.NavigateUrl);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@sImagePath", Imagepath);
                }
                cmd.Parameters.AddWithValue("@iLevel", txt_Level.Text.Trim());
                cmd.Parameters.AddWithValue("@dUpdated", DateTime.Now);
                cmd.Parameters.AddWithValue("@sUpdatedBy", Session["CurrentUserName"].ToString());
                cmd.Parameters.AddWithValue("@iSerial", id);
                try
                {
                    sc.Open();
                    cmd.ExecuteNonQuery();
                    sc.Close();


                    SqlCommand cmd1 = new SqlCommand("update CS_Initiative_Dpartment_Section set iDepartment=@iDepartment,iSection=@iSection where (iInitiative=@iInitiative and isPrincipal=1)", sc);                    
                    cmd1.Parameters.AddWithValue("@iDepartment", drp_Department.SelectedItem.Value);
                    cmd1.Parameters.AddWithValue("@iSection", drp_Section.SelectedItem.Value);
                    cmd1.Parameters.AddWithValue("@iInitiative", id);
                    try
                    {
                        sc.Open();
                        cmd1.ExecuteNonQuery();
                        sc.Close();
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

                    div_msg.Visible = true;
                    lbl_Msg.Text = "Strategic Initiative Updated Successfully";
                    div_Alert.Attributes.Add("class", "alert alert-success alert-dismissible");

                    bindStrategic_Initiative(id);
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
                //Insert
                SqlCommand cmd = new SqlCommand("insert into CS_Strategic_Initiative values (@sInitiativeID,@sInitiativeDesc,@iUniversityStatus,@iInitiativePriority,@iInitiativeMaturity,@iDigitalTransformationProgram,@iDigitalUseCase,@iEnterpriseModel,@iDepartment,@iSection,@iTheme,@iGoal,@iProject,@iObjective,@iOrder,@iStrategyVersion,@sAbbreviation,@sImagePath,@dAdded,@sAddedBy,@dUpdated,@sUpdatedBy,@iValuePropositionImpact,@iLevel);select SCOPE_IDENTITY();", sc);
                cmd.Parameters.AddWithValue("@sInitiativeID", txt_InitiativeID.Text.Trim());
                cmd.Parameters.AddWithValue("@sInitiativeDesc", txt_InitiativeDesc.Text.Trim());
                cmd.Parameters.AddWithValue("@iUniversityStatus", drp_UniversityStatus.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iInitiativePriority", drp_InitiativePriority.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iInitiativeMaturity", drp_InitiativeMaturity.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iDigitalTransformationProgram", drp_DigitalTransformationProgram.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iDigitalUseCase", drp_DigitalUseCase.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iEnterpriseModel", drp_EnterpriseModel.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iDepartment", drp_Department.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iSection", drp_Section.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iTheme", drp_Theme.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iGoal", drp_Goal.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iProject", drp_Project.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iObjective", drp_Objective.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iOrder", txt_Order.Text.Trim());
                cmd.Parameters.AddWithValue("@iStrategyVersion", drp_StrategyVersion.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@sAbbreviation", txt_Abbreviation.Text.Trim());
                if (Imagepath == "empty")
                {
                    cmd.Parameters.AddWithValue("@sImagePath", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@sImagePath", Imagepath);
                }
                cmd.Parameters.AddWithValue("@dAdded", DateTime.Now);
                cmd.Parameters.AddWithValue("@sAddedBy", Session["CurrentUserName"].ToString());
                cmd.Parameters.AddWithValue("@dUpdated", DateTime.Now);
                cmd.Parameters.AddWithValue("@sUpdatedBy", Session["CurrentUserName"].ToString());               
                cmd.Parameters.AddWithValue("@iValuePropositionImpact", drp_ValuePropositionImpact.SelectedItem.Value);               
                cmd.Parameters.AddWithValue("@iLevel", txt_Level.Text.Trim());
                try
                {
                    sc.Open();
                    //cmd.ExecuteNonQuery();
                    int Initiative_ID = Convert.ToInt32(cmd.ExecuteScalar());
                    sc.Close();

                    SqlCommand cmd1 = new SqlCommand("insert into CS_Initiative_Dpartment_Section values (@iInitiative,@iDepartment,@iSection,@isPrincipal)", sc);
                    cmd1.Parameters.AddWithValue("@iInitiative", Initiative_ID);
                    cmd1.Parameters.AddWithValue("@iDepartment", drp_Department.SelectedItem.Value);
                    cmd1.Parameters.AddWithValue("@iSection", drp_Section.SelectedItem.Value);
                    cmd1.Parameters.AddWithValue("@isPrincipal", 1);
                    try
                    {
                        sc.Open();
                        cmd1.ExecuteNonQuery();
                        sc.Close();
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

                    div_msg.Visible = true;
                    lbl_Msg.Text = "Strategic Initiative Created Successfully";
                    div_Alert.Attributes.Add("class", "alert alert-success alert-dismissible");

                    txt_InitiativeID.Text = "";
                    txt_InitiativeDesc.Text = "";
                    txt_Order.Text = "";
                    txt_Abbreviation.Text = "";
                    Imagepath = "";
                    txt_Level.Text = "";
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
            Response.Redirect("Strategy_Strategic_Initiative_Home");
        }

        protected void drp_Department_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillSection();
        }

        protected void drp_Theme_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillGoal();
            fillProject();
            fillObjective();
            if (!string.IsNullOrEmpty(drp_Objective.SelectedValue))
            {
                drp_StrategyVersion.SelectedIndex = drp_StrategyVersion.Items.IndexOf(drp_StrategyVersion.Items.FindByValue(getStrategy_Version(drp_Objective.SelectedItem.Value)));
            }

        }

        protected void drp_Goal_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillProject();
            fillObjective();
            if (!string.IsNullOrEmpty(drp_Objective.SelectedValue))
            {
                drp_StrategyVersion.SelectedIndex = drp_StrategyVersion.Items.IndexOf(drp_StrategyVersion.Items.FindByValue(getStrategy_Version(drp_Objective.SelectedItem.Value)));
            }
        }

        protected void drp_Project_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillObjective();
            if(!string.IsNullOrEmpty(drp_Objective.SelectedValue))
            {
                drp_StrategyVersion.SelectedIndex = drp_StrategyVersion.Items.IndexOf(drp_StrategyVersion.Items.FindByValue(getStrategy_Version(drp_Objective.SelectedItem.Value)));
            }
        }

        protected void drp_Objective_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(drp_Objective.SelectedValue))
            {
                drp_StrategyVersion.SelectedIndex = drp_StrategyVersion.Items.IndexOf(drp_StrategyVersion.Items.FindByValue(getStrategy_Version(drp_Objective.SelectedItem.Value)));
            }
        }
    }
}