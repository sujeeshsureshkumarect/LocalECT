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
using System.Net;
using Microsoft.SharePoint.Client;
using System.Security;

namespace LocalECT
{
    public partial class Strategy_Strategic_Evidence_Submission_Update : System.Web.UI.Page
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
                        if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.Strategic_Evidence,
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
                            fillEvidence();
                            drp_EvidenceRecord.SelectedIndex = drp_EvidenceRecord.Items.IndexOf(drp_EvidenceRecord.Items.FindByValue(id));
                            fillPeriod();
                            fillSubPeriod();
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
        public void fillEvidence()
        {
            SqlCommand cmd = new SqlCommand("select iSerial,sEvidenceRecored from CS_Strategic_Evidence", sc);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                drp_EvidenceRecord.DataSource = dt;
                drp_EvidenceRecord.DataTextField = "sEvidenceRecored";
                drp_EvidenceRecord.DataValueField = "iSerial";
                drp_EvidenceRecord.DataBind();
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
        public void fillPeriod()
        {
            SqlCommand cmd = new SqlCommand("select iSerial,sPeriod from CS_Strategic_Period", sc);
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
        public void fillSubPeriod()
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

        protected void lnk_Create_Click(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];
            if (id != null)
            {
                Response.Redirect("Strategy_Strategic_Evidence_Submission_Home.aspx?id=" + id + "");
            }
        }

        protected void btn_Create_Click(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];
            if (id != null)
            {
                if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.Strategic_Evidence,
                              InitializeModule.enumPrivilege.EditUpdate, CurrentRole) != true)
                {
                    div_msg.Visible = true;
                    div_Alert.Attributes.Add("class", "alert alert-danger alert-dismissible");
                    lbl_Msg.Text = "Sorry-You cannot Create";
                    return;
                }

                string OrganizationalHierarchyApproval = "";
                string OrganizationalHierarchyApprover = "";
                string StrategyPMO = "";
                string ProjectOwner = "";
                string IRQA = "";
                string Section = "";
                string SectionHeadDesignation = "";
                string SectionHead = "";
                string Department = "";

                ServicePointManager.Expect100Continue = true;
                ServicePointManager.DefaultConnectionLimit = 9999;
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;

                String sSQL = "";
                sSQL += " SELECT        Lkp_Department.DepartmentID, Lkp_Department.DepartmentAbbreviation, Lkp_Department.DescEN, Lkp_Department.ManagerID, Lkp_Department.JobIDofDeptHead, Hr_Employee.InternalEmail, Lkp_JobTitle.JobTitleEn ";
                sSQL += " FROM            Lkp_Department LEFT OUTER JOIN ";
                sSQL += "                          Lkp_JobTitle ON Lkp_Department.JobIDofDeptHead = Lkp_JobTitle.JobTitleID LEFT OUTER JOIN ";
                sSQL += "                          Hr_Employee ON Lkp_Department.ManagerID = Hr_Employee.EmployeeID  ";
                sSQL += " 						 where Lkp_Department.DepartmentID in (select iDepartment from CS_Strategic_Evidence where iSerial=@iSerial); ";
                sSQL += "  ";
                sSQL += " SELECT        Lkp_Section.ManagerID, Lkp_Section.JobIDofSectionManager, Hr_Employee.InternalEmail, Lkp_JobTitle.JobTitleEn ";
                sSQL += " FROM            Lkp_Section INNER JOIN ";
                sSQL += "                          Lkp_JobTitle ON Lkp_Section.JobIDofSectionManager = Lkp_JobTitle.JobTitleID INNER JOIN ";
                sSQL += "                          Hr_Employee ON Lkp_Section.ManagerID = Hr_Employee.EmployeeID ";
                sSQL += " WHERE        (Lkp_Section.SectionAbbreviation = 'SPMO'); ";
                sSQL += "  ";
                sSQL += " SELECT        CS_Strategic_Project.iProjectOwner, Hr_Employee.InternalEmail ";
                sSQL += " FROM            CS_Strategic_Project INNER JOIN ";
                sSQL += "                          Hr_Employee ON CS_Strategic_Project.iProjectOwner = Hr_Employee.EmployeeID ";
                sSQL += " 						 where iSerial in (select iProject from CS_Strategic_Evidence where iSerial=@iSerial); ";
                sSQL += "  ";
                sSQL += " SELECT        Lkp_Section.ManagerID, Lkp_Section.JobIDofSectionManager, Hr_Employee.InternalEmail, Lkp_JobTitle.JobTitleEn ";
                sSQL += " FROM            Lkp_Section INNER JOIN ";
                sSQL += "                          Hr_Employee ON Lkp_Section.ManagerID = Hr_Employee.EmployeeID INNER JOIN ";
                sSQL += "                          Lkp_JobTitle ON Lkp_Section.JobIDofSectionManager = Lkp_JobTitle.JobTitleID ";
                sSQL += " WHERE        (Lkp_Section.SectionAbbreviation = 'IRQAO'); ";
                sSQL += "  ";
                sSQL += " SELECT        Lkp_Section.SectionID, Lkp_Section.SectionAbbreviation, Lkp_Section.DescEN, Lkp_Section.ManagerID, Lkp_Section.JobIDofSectionManager, Hr_Employee.InternalEmail, Lkp_JobTitle.JobTitleEn ";
                sSQL += " FROM            Lkp_Section INNER JOIN ";
                sSQL += "                          Hr_Employee ON Lkp_Section.ManagerID = Hr_Employee.EmployeeID INNER JOIN ";
                sSQL += "                          Lkp_JobTitle ON Lkp_Section.JobIDofSectionManager = Lkp_JobTitle.JobTitleID ";
                sSQL += " WHERE        (Lkp_Section.SectionID IN ";
                sSQL += "                              (SELECT        iSection ";
                sSQL += "                                FROM            CS_Strategic_Evidence ";
                sSQL += "                                WHERE        (iSerial = @iSerial))); ";

                SqlCommand cmd1 = new SqlCommand(sSQL, sc);
                cmd1.Parameters.AddWithValue("@iSerial", Request.QueryString["id"]);
                DataSet ds1 = new DataSet();
                SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                try
                {
                    sc.Open();
                    da1.Fill(ds1);
                    sc.Close();

                    OrganizationalHierarchyApproval = ds1.Tables[0].Rows[0]["JobTitleEn"].ToString();
                    OrganizationalHierarchyApprover = ds1.Tables[0].Rows[0]["InternalEmail"].ToString();
                    StrategyPMO = ds1.Tables[1].Rows[0]["InternalEmail"].ToString();
                    ProjectOwner = ds1.Tables[2].Rows[0]["InternalEmail"].ToString();
                    IRQA = ds1.Tables[3].Rows[0]["InternalEmail"].ToString();
                    Section = ds1.Tables[4].Rows[0]["SectionAbbreviation"].ToString();
                    SectionHeadDesignation = ds1.Tables[4].Rows[0]["JobTitleEn"].ToString();
                    SectionHead = ds1.Tables[4].Rows[0]["InternalEmail"].ToString();
                    Department = ds1.Tables[0].Rows[0]["DepartmentAbbreviation"].ToString();
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

                String refno = Create16DigitString();

                string login = "ets.services.admin@ect.ac.ae"; //give your username here  
                string password = "Ser71ces@328"; //give your password  
                var securePassword = new SecureString();
                foreach (char c in password)
                {
                    securePassword.AppendChar(c);
                }
                string siteUrl = "https://ectacae.sharepoint.com/sites/ECTPortal/CorpStrategy/";
                ClientContext clientContext = new ClientContext(siteUrl);
                Microsoft.SharePoint.Client.List myList = clientContext.Web.Lists.GetByTitle("CS_Strategic_Evidence_Submission");
                ListItemCreationInformation itemInfo = new ListItemCreationInformation();
                Microsoft.SharePoint.Client.ListItem myItem = myList.AddItem(itemInfo);

                myItem["Title"] = "Initiated";
                myItem["ReferenceID"] = refno;
                myItem["Period"] = drp_Period.SelectedItem.Text;
                myItem["SubPeriod"] = drp_SubPeriod.SelectedItem.Text;
                myItem["SectionHeadNote"] = txt_Note.Text.Trim();
                myItem["OrganizationalHierarchyApproval"] = OrganizationalHierarchyApproval;
                myItem["OrganizationalHierarchyApprover"] = clientContext.Web.EnsureUser(OrganizationalHierarchyApprover);
                myItem["StrategyPMO"] = clientContext.Web.EnsureUser(StrategyPMO);
                myItem["ProjectOwner"] = clientContext.Web.EnsureUser(ProjectOwner);
                myItem["IRQA"] = clientContext.Web.EnsureUser(IRQA);
                myItem["Section"] = Section;
                myItem["SectionHeadDesignation"] = SectionHeadDesignation;
                myItem["SectionHead"] = clientContext.Web.EnsureUser(SectionHead);
                myItem["Department"] = Department;
                myItem["EvidenceRecord"] = drp_EvidenceRecord.SelectedItem.Text;

                try
                {
                    myItem.Update();

                    if (EvidenceDocumetFile.HasFile)
                    {
                        var attachment = new AttachmentCreationInformation();

                        EvidenceDocumetFile.SaveAs(Server.MapPath("~/Strategy/" + EvidenceDocumetFile.FileName));
                        string FileUrl = Server.MapPath("~/Strategy/" + EvidenceDocumetFile.FileName);

                        string filePath = FileUrl;
                        attachment.FileName = Path.GetFileName(filePath);
                        attachment.ContentStream = new MemoryStream(System.IO.File.ReadAllBytes(filePath));
                        Attachment att = myItem.AttachmentFiles.Add(attachment);
                    }

                    var onlineCredentials = new SharePointOnlineCredentials(login, securePassword);
                    clientContext.Credentials = onlineCredentials;
                    clientContext.ExecuteQuery();

                    //if (EvidenceDocumetFile.HasFile)
                    //{
                    //    string FileUrls = Server.MapPath("~/Upload/" + EvidenceDocumetFile.FileName);
                    //    System.IO.File.Delete(FileUrls);
                    //}


                    //lbl_Msg.Text = "Request (ID# " + refno + ") Generated Successfully";
                    //lbl_Msg.Visible = true;
                    //div_msg.Visible = true;
                    //div_Alert.Attributes.Add("class", "alert alert-success alert-dismissible");
                    //btn_Create.Enabled = false;

                    //Get ID usinf Refno
                    string SP_ID = getSPID(refno);

                    //Insert
                    SqlCommand cmd = new SqlCommand("insert into CS_Strategic_Evidence_Submission values (@iEvidence,@iPeriod,@iSubPeriod,@sNote,@sPath,@dAdded,@sAddedBy,@dUpdated,@sUpdatedBy,@sLink)", sc);
                    cmd.Parameters.AddWithValue("@iEvidence", drp_EvidenceRecord.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@iPeriod", drp_Period.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@iSubPeriod", drp_SubPeriod.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@sNote", txt_Note.Text.Trim());
                    string filename = Path.GetFileName(EvidenceDocumetFile.PostedFile.FileName);
                    string path = "/Strategy/" + filename;
                    path = path.Replace(" ", "%20");
                    cmd.Parameters.AddWithValue("@sPath", path);
                    cmd.Parameters.AddWithValue("@dAdded", DateTime.Now);
                    cmd.Parameters.AddWithValue("@sAddedBy", Session["CurrentUserName"].ToString());
                    cmd.Parameters.AddWithValue("@dUpdated", DateTime.Now);
                    cmd.Parameters.AddWithValue("@sUpdatedBy", Session["CurrentUserName"].ToString());
                    cmd.Parameters.AddWithValue("@sLink", SP_ID);
                    try
                    {
                        sc.Open();
                        cmd.ExecuteNonQuery();
                        sc.Close();

                        div_msg.Visible = true;
                        div_Alert.Attributes.Add("class", "alert alert-success alert-dismissible");
                        lbl_Msg.Text = "Strategic Evidence Submission (ID# " + refno + ") Created Successfully";
                        lbl_Msg.Visible = true;
                        btn_Create.Visible = false;
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
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    lbl_Msg.Text = ex.Message;
                    lbl_Msg.Visible = true;
                    div_msg.Visible = true;
                    div_Alert.Attributes.Add("class", "alert alert-danger alert-dismissible");
                }
            }                       
        }

        public string getSPID(string refno)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.DefaultConnectionLimit = 9999;
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;

            string id = "";
            string login = "ets.services.admin@ect.ac.ae"; //give your username here  
            string password = "Ser71ces@328"; //give your password  
            var securePassword = new SecureString();
            foreach (char c in password)
            {
                securePassword.AppendChar(c);
            }
            string siteUrl = "https://ectacae.sharepoint.com/sites/ECTPortal/CorpStrategy/";
            ClientContext clientContext = new ClientContext(siteUrl);
            var onlineCredentials = new SharePointOnlineCredentials(login, securePassword);
            clientContext.Credentials = onlineCredentials;
            List list = clientContext.Web.Lists.GetByTitle("CS_Strategic_Evidence_Submission");
            CamlQuery query = new CamlQuery();


            //clientContext.Web.EnsureUser(mail)
            query.ViewXml = "<View><Query><Where><Eq><FieldRef Name='ReferenceID'/><Value Type='Text'>" + refno + "</Value></Eq></Where></Query></View>";
            //query.ViewXml = "<View></View>";
            Microsoft.SharePoint.Client.ListItemCollection items = list.GetItems(query);
            clientContext.Load(list);
            clientContext.Load(items);
            clientContext.ExecuteQuery();
                        
            foreach (Microsoft.SharePoint.Client.ListItem item in items)
            {
                id = item["ID"].ToString();
            }            
            return id;
        }
        public string Create16DigitString()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[8];
            var random = new Random((int)DateTime.Now.Ticks);
            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            var finalString = new String(stringChars);
            return finalString.ToString();
        }
        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];
            if (id != null)
            {
                Response.Redirect("Strategy_Strategic_Evidence_Submission_Home.aspx?id=" + id + "");
            }
        }
    }
}