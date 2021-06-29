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
    public partial class Strategy_Strategic_Objective_Update : System.Web.UI.Page
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
                        if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.Strategic_Objective,
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
                        fillStrategy_Version();
                        //fillSubStipulation();
                        fillInspectionComplianceDomain();
                        fillStrategicProject();

                        if (!string.IsNullOrEmpty(drp_StrategicProject.SelectedValue))
                        {
                            drp_StrategyVersion.SelectedIndex = drp_StrategyVersion.Items.IndexOf(drp_StrategyVersion.Items.FindByValue(getStrategy_Version(drp_StrategicProject.SelectedItem.Value)));
                        }

                        string id = Request.QueryString["id"];
                        string t = Request.QueryString["t"];
                        if (id != null)
                        {
                            bindStrategic_Objective(id);
                            btn_Create.Text = "Update";
                            lbl_Header.Text = "Edit Strategic Objective";
                            hyp_ImagePath.Visible = true;
                            if (t == "v")//View
                            {
                                btn_Create.Visible = false;
                                lbl_Header.Text = "View Strategic Objective";
                                txt_StrategicObjectiveID.Enabled = false;
                                txt_StrategicObjectiveDesc.Enabled = false;
                                drp_InspectionComplianceDomainID.Enabled = false;                                
                                txt_Order.Enabled = false;
                                drp_StrategyVersion.Enabled = false;
                                txt_Abbreviation.Enabled = false;
                                drp_StrategicProject.Enabled = false;
                                flp_Upload.Visible = false;
                                //drp_SubStipulation.Enabled = false;
                                txt_Level.Enabled = false;
                            }
                            else if (t == "e")//Edit
                            {
                                btn_Create.Visible = true;
                                lbl_Header.Text = "Edit Strategic Objective";
                                txt_StrategicObjectiveID.Enabled = true;
                                txt_StrategicObjectiveDesc.Enabled = true;
                                drp_InspectionComplianceDomainID.Enabled = true;
                                txt_Order.Enabled = true;
                                drp_StrategyVersion.Enabled = false;
                                txt_Abbreviation.Enabled = true;
                                drp_StrategicProject.Enabled = true;
                                flp_Upload.Visible = true;
                                //drp_SubStipulation.Enabled = true;
                                txt_Level.Enabled = true;
                            }
                        }
                        else
                        {
                            btn_Create.Text = "Create";
                            lbl_Header.Text = "Create New Strategic Objective";
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
            SqlCommand cmd = new SqlCommand("select iStrategyVersion from CS_Strategic_Project where iSerial=@iSerial", sc);
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
        //public void fillSubStipulation()
        //{
        //    SqlCommand cmd = new SqlCommand("select iSerial,sSubStipulationID from CS_Sub_Stipulation", sc);
        //    DataTable dt = new DataTable();
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    try
        //    {
        //        sc.Open();
        //        da.Fill(dt);
        //        sc.Close();

        //        drp_SubStipulation.DataSource = dt;
        //        drp_SubStipulation.DataTextField = "sSubStipulationID";
        //        drp_SubStipulation.DataValueField = "iSerial";
        //        drp_SubStipulation.DataBind();
        //    }
        //    catch (Exception ex)
        //    {
        //        sc.Close();
        //        Console.WriteLine(ex.Message);
        //    }
        //    finally
        //    {
        //        sc.Close();
        //    }
        //}
        public void fillInspectionComplianceDomain()
        {
            SqlCommand cmd = new SqlCommand("select iSerial,sInspectionComplianceDomainID from CS_Inspection_Compliance_Domain", sc);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                drp_InspectionComplianceDomainID.DataSource = dt;
                drp_InspectionComplianceDomainID.DataTextField = "sInspectionComplianceDomainID";
                drp_InspectionComplianceDomainID.DataValueField = "iSerial";
                drp_InspectionComplianceDomainID.DataBind();
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
        public void fillStrategicProject()
        {
            SqlCommand cmd = new SqlCommand("select iSerial,sStrategicProjectID from CS_Strategic_Project", sc);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                drp_StrategicProject.DataSource = dt;
                drp_StrategicProject.DataTextField = "sStrategicProjectID";
                drp_StrategicProject.DataValueField = "iSerial";
                drp_StrategicProject.DataBind();
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
        public void bindStrategic_Objective(string id)
        {
            SqlCommand cmd = new SqlCommand("select * from CS_Strategic_Objective where iSerial=@iSerial", sc);
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
                    txt_StrategicObjectiveID.Text = dt.Rows[0]["sStrategicObjectiveID"].ToString();
                    txt_StrategicObjectiveDesc.Text = dt.Rows[0]["sStrategicObjectiveDesc"].ToString();
                    drp_InspectionComplianceDomainID.SelectedIndex = drp_InspectionComplianceDomainID.Items.IndexOf(drp_InspectionComplianceDomainID.Items.FindByValue(dt.Rows[0]["iInspectionComplianceDomain"].ToString()));
                    txt_Order.Text = dt.Rows[0]["iOrder"].ToString();
                    drp_StrategyVersion.SelectedIndex = drp_StrategyVersion.Items.IndexOf(drp_StrategyVersion.Items.FindByValue(dt.Rows[0]["iStrategyVersion"].ToString()));
                    txt_Abbreviation.Text = dt.Rows[0]["sAbbreviation"].ToString();
                    drp_StrategicProject.SelectedIndex = drp_StrategicProject.Items.IndexOf(drp_StrategicProject.Items.FindByValue(dt.Rows[0]["iStrategicProject"].ToString()));
                    hyp_ImagePath.NavigateUrl = dt.Rows[0]["sImagePath"].ToString();
                    //drp_SubStipulation.SelectedIndex = drp_SubStipulation.Items.IndexOf(drp_SubStipulation.Items.FindByValue(dt.Rows[0]["iSubStipulation"].ToString()));
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
                if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.Strategic_Objective,
                              InitializeModule.enumPrivilege.EditUpdate, CurrentRole) != true)
                {
                    div_msg.Visible = true;
                    div_Alert.Attributes.Add("class", "alert alert-danger alert-dismissible");
                    lbl_Msg.Text = "Sorry-You cannot Edit";
                    return;
                }
                //Update
                SqlCommand cmd = new SqlCommand("update CS_Strategic_Objective set sStrategicObjectiveID=@sStrategicObjectiveID,sStrategicObjectiveDesc=@sStrategicObjectiveDesc,iInspectionComplianceDomain=@iInspectionComplianceDomain,iOrder=@iOrder,iStrategyVersion=@iStrategyVersion,sAbbreviation=@sAbbreviation,iStrategicProject=@iStrategicProject,sImagePath=@sImagePath,iLevel=@iLevel,dUpdated=@dUpdated,sUpdatedBy=@sUpdatedBy where iSerial=@iSerial", sc);
                cmd.Parameters.AddWithValue("@sStrategicObjectiveID", txt_StrategicObjectiveID.Text.Trim());
                cmd.Parameters.AddWithValue("@sStrategicObjectiveDesc", txt_StrategicObjectiveDesc.Text.Trim());
                cmd.Parameters.AddWithValue("@iInspectionComplianceDomain", drp_InspectionComplianceDomainID.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iOrder", txt_Order.Text.Trim());
                cmd.Parameters.AddWithValue("@iStrategyVersion", drp_StrategyVersion.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@sAbbreviation", txt_Abbreviation.Text.Trim());
                cmd.Parameters.AddWithValue("@iStrategicProject", drp_StrategicProject.SelectedItem.Value);
                if (Imagepath == "empty")
                {
                    cmd.Parameters.AddWithValue("@sImagePath", hyp_ImagePath.NavigateUrl);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@sImagePath", Imagepath);
                }
                //cmd.Parameters.AddWithValue("@iSubStipulation", drp_SubStipulation.SelectedItem.Value);
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
                    lbl_Msg.Text = "Strategic Objective Updated Successfully";

                    bindStrategic_Objective(id);
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
                if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.Strategic_Objective,
                             InitializeModule.enumPrivilege.EditUpdate, CurrentRole) != true)
                {
                    div_msg.Visible = true;
                    div_Alert.Attributes.Add("class", "alert alert-danger alert-dismissible");
                    lbl_Msg.Text = "Sorry-You cannot Add";
                    return;
                }
                //Insert
                SqlCommand cmd = new SqlCommand("insert into CS_Strategic_Objective values (@sStrategicObjectiveID,@sStrategicObjectiveDesc,@iInspectionComplianceDomain,@iOrder,@iStrategyVersion,@dAdded,@sAddedBy,@dUpdated,@sUpdatedBy,@sAbbreviation,@iStrategicProject,@sImagePath,@iLevel)", sc);
                cmd.Parameters.AddWithValue("@sStrategicObjectiveID", txt_StrategicObjectiveID.Text.Trim());
                cmd.Parameters.AddWithValue("@sStrategicObjectiveDesc", txt_StrategicObjectiveDesc.Text.Trim());
                cmd.Parameters.AddWithValue("@iInspectionComplianceDomain", drp_InspectionComplianceDomainID.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iOrder", txt_Order.Text.Trim());
                cmd.Parameters.AddWithValue("@iStrategyVersion", drp_StrategyVersion.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@dAdded", DateTime.Now);
                cmd.Parameters.AddWithValue("@sAddedBy", Session["CurrentUserName"].ToString());
                cmd.Parameters.AddWithValue("@dUpdated", DateTime.Now);
                cmd.Parameters.AddWithValue("@sUpdatedBy", Session["CurrentUserName"].ToString());
                cmd.Parameters.AddWithValue("@sAbbreviation", txt_Abbreviation.Text.Trim());
                cmd.Parameters.AddWithValue("@iStrategicProject", drp_StrategicProject.SelectedItem.Value);
                if (Imagepath == "empty")
                {
                    cmd.Parameters.AddWithValue("@sImagePath", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@sImagePath", Imagepath);
                }
                //cmd.Parameters.AddWithValue("@iSubStipulation", drp_SubStipulation.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iLevel", txt_Level.Text.Trim());
                try
                {
                    sc.Open();
                    cmd.ExecuteNonQuery();
                    sc.Close();

                    div_msg.Visible = true;
                    lbl_Msg.Text = "Strategic Objective Created Successfully";

                    txt_StrategicObjectiveID.Text = "";
                    txt_StrategicObjectiveDesc.Text = "";
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
            Response.Redirect("Strategy_Strategic_Objective_Home");
        }

        protected void drp_StrategicProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(drp_StrategicProject.SelectedValue))
            {
                drp_StrategyVersion.SelectedIndex = drp_StrategyVersion.Items.IndexOf(drp_StrategyVersion.Items.FindByValue(getStrategy_Version(drp_StrategicProject.SelectedItem.Value)));
            }
        }
    }
}