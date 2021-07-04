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
    public partial class Strategy_Strategic_Goal_Update : System.Web.UI.Page
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
                        if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.Strategic_Goal,
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
                        fillStrategic_Theme();
                        fillStrategy_Version();
                        fillStipulation();
                        fillInspectionComplianceStandard();

                        if (!string.IsNullOrEmpty(drp_Theme.SelectedValue))
                        {
                            drp_StrategyVersion.SelectedIndex = drp_StrategyVersion.Items.IndexOf(drp_StrategyVersion.Items.FindByValue(getStrategy_Version(drp_Theme.SelectedItem.Value)));
                        }

                        string id = Request.QueryString["id"];
                        string t = Request.QueryString["t"];
                        if (id != null)
                        {
                            bindStrategic_Goal(id);
                            btn_Create.Text = "Update";
                            lbl_Header.Text = "Edit Strategic Goal";
                            hyp_ImagePath.Visible = true;
                            if (t == "v")//View
                            {
                                btn_Create.Visible = false;
                                lbl_Header.Text = "View Strategic Goal";
                                txt_StrategicGoalID.Enabled = false;
                                txt_StrategicGoalDesc.Enabled = false;
                                drp_StipulationID.Enabled = false;
                                drp_InspectionComplianceStandardID.Enabled = false;
                                txt_Order.Enabled = false;
                                drp_StrategyVersion.Enabled = false;
                                txt_Abbreviation.Enabled = false;
                                drp_Theme.Enabled = false;
                                flp_Upload.Visible = false;
                                txt_Level.Enabled = false;
                            }
                            else if (t == "e")//Edit
                            {
                                btn_Create.Visible = true;
                                lbl_Header.Text = "Edit Strategic Goal";
                                txt_StrategicGoalID.Enabled = true;
                                txt_StrategicGoalDesc.Enabled = true;
                                drp_StipulationID.Enabled = true;
                                drp_InspectionComplianceStandardID.Enabled = true;
                                txt_Order.Enabled = true;
                                drp_StrategyVersion.Enabled = false;
                                txt_Abbreviation.Enabled = true;
                                drp_Theme.Enabled = true;
                                flp_Upload.Visible = true;
                                txt_Level.Enabled = true;
                            }
                        }
                        else
                        {
                            btn_Create.Text = "Create";
                            lbl_Header.Text = "Create New Strategic Goal";
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
        public string getStrategy_Version(string id)
        {
            string sid = "";
            SqlCommand cmd = new SqlCommand("select iStrategyVersion from CS_Strategic_Theme where iSerial=@iSerial", sc);
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
        public void fillStipulation()
        {
            SqlCommand cmd = new SqlCommand("select iSerial,sStipulationID from CS_Stipulation", sc);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                drp_StipulationID.DataSource = dt;
                drp_StipulationID.DataTextField = "sStipulationID";
                drp_StipulationID.DataValueField = "iSerial";
                drp_StipulationID.DataBind();
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
        public void fillInspectionComplianceStandard()
        {
            SqlCommand cmd = new SqlCommand("select iSerial,sInspectionComplianceStandardID from CS_Inspection_Compliance_Standard", sc);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                drp_InspectionComplianceStandardID.DataSource = dt;
                drp_InspectionComplianceStandardID.DataTextField = "sInspectionComplianceStandardID";
                drp_InspectionComplianceStandardID.DataValueField = "iSerial";
                drp_InspectionComplianceStandardID.DataBind();
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
        public void fillStrategic_Theme()
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
        public void bindStrategic_Goal(string id)
        {
            SqlCommand cmd = new SqlCommand("select * from CS_Strategic_Goal where iSerial=@iSerial", sc);
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
                    txt_StrategicGoalID.Text = dt.Rows[0]["sStrategicGoalID"].ToString();
                    txt_StrategicGoalDesc.Text = dt.Rows[0]["sStrategicGoalDesc"].ToString();
                    drp_StipulationID.SelectedIndex = drp_StipulationID.Items.IndexOf(drp_StipulationID.Items.FindByValue(dt.Rows[0]["iStipulation"].ToString()));
                    drp_InspectionComplianceStandardID.SelectedIndex = drp_InspectionComplianceStandardID.Items.IndexOf(drp_InspectionComplianceStandardID.Items.FindByValue(dt.Rows[0]["iInspectioncomplianceStandard"].ToString()));
                    txt_Order.Text = dt.Rows[0]["iOrder"].ToString();
                    drp_StrategyVersion.SelectedIndex = drp_StrategyVersion.Items.IndexOf(drp_StrategyVersion.Items.FindByValue(dt.Rows[0]["iStrategyVersion"].ToString()));
                    txt_Abbreviation.Text = dt.Rows[0]["sAbbreviation"].ToString();
                    drp_Theme.SelectedIndex = drp_Theme.Items.IndexOf(drp_Theme.Items.FindByValue(dt.Rows[0]["iTheme"].ToString()));
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
                if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.Strategic_Goal,
                              InitializeModule.enumPrivilege.EditUpdate, CurrentRole) != true)
                {
                    div_msg.Visible = true;
                    div_Alert.Attributes.Add("class", "alert alert-danger alert-dismissible");
                    lbl_Msg.Text = "Sorry-You cannot Edit";
                    return;
                }
                //Update
                SqlCommand cmd = new SqlCommand("update CS_Strategic_Goal set sStrategicGoalID=@sStrategicGoalID,sStrategicGoalDesc=@sStrategicGoalDesc,iStipulation=@iStipulation,iInspectioncomplianceStandard=@iInspectioncomplianceStandard,iOrder=@iOrder,iStrategyVersion=@iStrategyVersion,sAbbreviation=@sAbbreviation,iTheme=@iTheme,sImagePath=@sImagePath,iLevel=@iLevel,dUpdated=@dUpdated,sUpdatedBy=@sUpdatedBy where iSerial=@iSerial", sc);
                cmd.Parameters.AddWithValue("@sStrategicGoalID", txt_StrategicGoalID.Text.Trim());
                cmd.Parameters.AddWithValue("@sStrategicGoalDesc", txt_StrategicGoalDesc.Text.Trim());
                cmd.Parameters.AddWithValue("@iStipulation", drp_StipulationID.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iInspectioncomplianceStandard", drp_InspectionComplianceStandardID.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iOrder", txt_Order.Text.Trim());
                cmd.Parameters.AddWithValue("@iStrategyVersion", drp_StrategyVersion.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@sAbbreviation", txt_Abbreviation.Text.Trim());
                cmd.Parameters.AddWithValue("@iTheme", drp_Theme.SelectedItem.Value);
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

                    div_msg.Visible = true;
                    lbl_Msg.Text = "Strategic Goal Updated Successfully";

                    bindStrategic_Goal(id);
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
                if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.Strategic_Goal,
                             InitializeModule.enumPrivilege.EditUpdate, CurrentRole) != true)
                {
                    div_msg.Visible = true;
                    div_Alert.Attributes.Add("class", "alert alert-danger alert-dismissible");
                    lbl_Msg.Text = "Sorry-You cannot Add";
                    return;
                }
                //Insert
                SqlCommand cmd = new SqlCommand("insert into CS_Strategic_Goal values (@sStrategicGoalID,@sStrategicGoalDesc,@iStipulation,@iInspectioncomplianceStandard,@iOrder,@iStrategyVersion,@dAdded,@sAddedBy,@dUpdated,@sUpdatedBy,@sAbbreviation,@iTheme,@sImagePath,@iLevel)", sc);
                cmd.Parameters.AddWithValue("@sStrategicGoalID", txt_StrategicGoalID.Text.Trim());
                cmd.Parameters.AddWithValue("@sStrategicGoalDesc", txt_StrategicGoalDesc.Text.Trim());
                cmd.Parameters.AddWithValue("@iStipulation", drp_StipulationID.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iInspectioncomplianceStandard", drp_InspectionComplianceStandardID.SelectedItem.Value);                
                cmd.Parameters.AddWithValue("@iOrder", txt_Order.Text.Trim());
                cmd.Parameters.AddWithValue("@iStrategyVersion", drp_StrategyVersion.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@dAdded", DateTime.Now);
                cmd.Parameters.AddWithValue("@sAddedBy", Session["CurrentUserName"].ToString());
                cmd.Parameters.AddWithValue("@dUpdated", DateTime.Now);
                cmd.Parameters.AddWithValue("@sUpdatedBy", Session["CurrentUserName"].ToString());                
                cmd.Parameters.AddWithValue("@sAbbreviation", txt_Abbreviation.Text.Trim());
                cmd.Parameters.AddWithValue("@iTheme", drp_Theme.SelectedItem.Value);
                if (Imagepath == "empty")
                {
                    cmd.Parameters.AddWithValue("@sImagePath", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@sImagePath", Imagepath);
                }
                cmd.Parameters.AddWithValue("@iLevel", txt_Level.Text.Trim());
                try
                {
                    sc.Open();
                    cmd.ExecuteNonQuery();
                    sc.Close();

                    div_msg.Visible = true;
                    lbl_Msg.Text = "Strategic Goal Created Successfully";

                    txt_StrategicGoalID.Text = "";
                    txt_StrategicGoalDesc.Text = "";
                    txt_Order.Text = "";
                    txt_Abbreviation.Text = "";
                    Imagepath = "";
                    txt_Level.Text = "";
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
            //Response.Redirect("Strategy_Strategic_Goal_Home");
            string id = Request.QueryString["id"];
            string f = Request.QueryString["f"];
            if (id != null && f != null)
            {
                Response.Redirect("Strategy_Strategic_Goal_Home.aspx?f=m&id=" + id + "");
            }
            else
            {
                Response.Redirect("Strategy_Strategic_Goal_Home");
            }
        }

        protected void lnk_Back_Click(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];
            string f = Request.QueryString["f"];
            if (id != null && f != null)
            {
                Response.Redirect("Strategy_Strategic_Goal_Home.aspx?f=m&id=" + id + "");
            }
            else
            {
                Response.Redirect("Strategy_Strategic_Goal_Home");
            }
        }

        protected void drp_Theme_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(drp_Theme.SelectedValue))
            {
                drp_StrategyVersion.SelectedIndex = drp_StrategyVersion.Items.IndexOf(drp_StrategyVersion.Items.FindByValue(getStrategy_Version(drp_Theme.SelectedItem.Value)));
            }
        }
    }
}