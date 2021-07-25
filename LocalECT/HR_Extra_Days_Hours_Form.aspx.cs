using Excel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.SharePoint.Client;
using Microsoft.SharePoint;
using System.Web.UI.WebControls;
using DataTable = System.Data.DataTable;
using System.Security;
using System.IO;
using System.Text;
using System.Globalization;
using System.Net;

namespace LocalECT
{
    public partial class HR_Extra_Days_Hours_Form : System.Web.UI.Page
    {
        SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["ECTDataNew"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CurrentRole"] != null)
            {
                if (!IsPostBack)
                {
                    bindemployeeprofile();
                    approvalDetails();
                    DateTime TodayDate = DateTime.Today;
                    Today_Date.Text = TodayDate.ToString("dd/MM/yyyy");


                }
            }
            else
            {
                Session.RemoveAll();
                Response.Redirect("Login.aspx");
            }
        }
        protected void lnk_Generate_Click(object sender, EventArgs e)
        {

            sentdatatoSPLIst();




        }

        public void bindemployeeprofile()
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
                    //lbl_EmpID.Text = "E" + dt.Rows[0]["EmployeeID"].ToString();
                    lbl_EmpName.Text = dt.Rows[0]["EmployeeDisplayName"].ToString();
                    //Lbl_Position.Text = dt.Rows[0]["JobTitleEn"].ToString();
                    //lbl_Dept.Text = dt.Rows[0]["DepartmentAbbreviation"].ToString();
                    //   txt_Gender.Text = dt.Rows[0]["Gender"].ToString();
                    //  txtCategory.Text = dt.Rows[0]["Category"].ToString();
                    // txtPhoneNumber.Text = dt.Rows[0]["MobilePhoneNumber"].ToString();
                    UserEmail.Value = dt.Rows[0]["EmployeeEmail"].ToString();
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


        public void sentdatatoSPLIst()
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.DefaultConnectionLimit = 9999;
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;

            String refno = Create16DigitString();

            string login = "ets.services.admin@ect.ac.ae"; //give your username here  
            string password = "Ser71ces@328"; //give your password  
            var securePassword = new SecureString();
            foreach (char c in password)
            {
                securePassword.AppendChar(c);
            }
            string siteUrl = "https://ectacae.sharepoint.com/sites/ECTPortal/eservices/hrservices";
            ClientContext clientContext = new ClientContext(siteUrl);
            Microsoft.SharePoint.Client.List myList = clientContext.Web.Lists.GetByTitle("HR-Services");
            ListItemCreationInformation itemInfo = new ListItemCreationInformation();
            Microsoft.SharePoint.Client.ListItem myItem = myList.AddItem(itemInfo);

            myItem["Title"] = "Initiated";
            myItem["Reference"] = refno;
            myItem["ServiceID"] = lbl_ServiceID.Text.Trim();
            myItem["Contact"] = "--";
            var dataTable = "<hr/><table><tr><th>#</th><th>Name of Emplyees</th><th>Overtime Date</th><th>Overtime Time</th><th>Overtime Purpose</th><th>Redumption Date</th></tr>";
            dataTable += "<tr><td>" + SL1.Text + "</td><td>" + Employees_Names1.Text + "</td><td>" + Overtime_Date1.Text + "</td><td>" + Overtime_Time1.Text + "</td><td>" + Overtime_Purpose1.Text + "</td><td>" + Redumption_Date1.Text + "</td></tr>";
            dataTable += "<tr><td>" + SL2.Text + "</td><td>" + Employees_Names2.Text + "</td><td>" + Overtime_Date2.Text + "</td><td>" + Overtime_Time2.Text + "</td><td>" + Overtime_Purpose2.Text + "</td><td>" + Redumption_Date2.Text + "</td></tr>";
            dataTable += "<tr><td>" + SL3.Text + "</td><td>" + Employees_Names3.Text + "</td><td>" + Overtime_Date3.Text + "</td><td>" + Overtime_Time3.Text + "</td><td>" + Overtime_Purpose3.Text + "</td><td>" + Redumption_Date3.Text + "</td></tr>";
            dataTable += "<tr><td>" + SL4.Text + "</td><td>" + Employees_Names4.Text + "</td><td>" + Overtime_Date4.Text + "</td><td>" + Overtime_Time4.Text + "</td><td>" + Overtime_Purpose4.Text + "</td><td>" + Redumption_Date4.Text + "</td></tr>";
            dataTable += "<tr><td>" + SL5.Text + "</td><td>" + Employees_Names5.Text + "</td><td>" + Overtime_Date5.Text + "</td><td>" + Overtime_Time5.Text + "</td><td>" + Overtime_Purpose5.Text + "</td><td>" + Redumption_Date5.Text + "</td></tr></table><br/><hr/>";
            String RequestVar = "<b>Service ID:</b> " + lbl_ServiceID.Text + "<br/> <b>Service Name:</b> " + lbl_ServiceNameEn.Text + "<br/><b>From:</b>" + lbl_EmpName.Text + "<br/><b>To:</b>" + lbl_To.Text + "<br/><b>Date:</b>" + Today_Date.Text + "<br/>";

            myItem["Request"] = RequestVar + dataTable.ToString();
            myItem["EmpID"] = "--";
            myItem["Employee_x0020_Name"] = lbl_EmpName.Text.Trim();
            myItem["Requestor"] = clientContext.Web.EnsureUser(UserEmail.Value);
            String approvers = Approvers.Value;
            string[] users = approvers.Split(',');
            var approvalMembers = users
                .Select(loginName => FieldUserValue.FromUser(loginName))
                .ToList();

            myItem["Approvers"] = approvalMembers;

            string[] ApprovalsList = Approvals.Value.Split(',');


            myItem["ApprovalNeeded"] = ApprovalsList;
            myItem["ApprovalStatus"] = "--";
            myItem["RequestNote"] = "--";
            //  myItem["Finance"] = clientContext.Web.EnsureUser(Session["FinanceEmail"].ToString());
            //   myItem["FinanceAction"] = "Initiate";
            //myItem["FinanceNote"] = "";
            //myItem["Host"] = clientContext.Web.EnsureUser(Session["HostEmail"].ToString());//Session["HostEmail"].ToString();
            //myItem["HostAction"] = "Initiate";
            //myItem["HostNote"] = "";
            ////myItem["Provider"] = "";
            //myItem["ProviderAction"] = "Initiate";
            //myItem["ProviderNote"] = "";
            //myItem["Status"] = "Finance Approval Needed";
            //myItem["Modified"] = DateTime.Now;
            //myItem["Created"] = DateTime.Now;
            //myItem["Created By"] = hdf_StudentEmail.Value;
            //myItem["Modified By"] = hdf_StudentEmail.Value;
            try
            {
                myItem.Update();

                //   if (EvidenceDocumetFile.HasFile)
                //   {
                //   var attachment = new AttachmentCreationInformation();

                //  EvidenceDocumetFile.SaveAs(Server.MapPath("~/Upload/" + EvidenceDocumetFile.FileName));
                // string FileUrl = Server.MapPath("~/Upload/" + EvidenceDocumetFile.FileName);

                //   string filePath = FileUrl;
                //  attachment.FileName = Path.GetFileName(filePath);
                //   attachment.ContentStream = new MemoryStream(System.IO.File.ReadAllBytes(filePath));
                //   Attachment att = myItem.AttachmentFiles.Add(attachment);
                //  }

                var onlineCredentials = new SharePointOnlineCredentials(login, securePassword);
                clientContext.Credentials = onlineCredentials;
                clientContext.ExecuteQuery();

                //  if (EvidenceDocumetFile.HasFile)
                //  {
                //    string FileUrls = Server.MapPath("~/Upload/" + EvidenceDocumetFile.FileName);
                //     System.IO.File.Delete(FileUrls);
                //   }


                lbl_Msg.Text = "Request (ID# " + refno + ") Generated Successfully";
                lbl_Msg.Visible = true;
                div_msg.Visible = true;
                lnk_Generate.Enabled = false;
            }
            catch (Exception e)
            {
                Response.Write("<script>alert(e.Message);</script>");
            }
            //Console.ReadLine();
        }
        public string Create16DigitString()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[8];
            var random = new Random();
            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            var finalString = new String(stringChars);
            return finalString.ToString();
        }
        //public void approvalDetails()
        //{
        //    SqlCommand cmd = new SqlCommand("select * from HR_Employee_Academic_Admin_Managers where EmployeeID='" + Session["EmployeeID"].ToString() + "'", sc);
        //    DataTable dt = new DataTable();
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    try
        //    {
        //        sc.Open();
        //        da.Fill(dt);
        //        sc.Close();

        //        if (dt.Rows.Count > 0)
        //        {


        //            String IsFaculty = dt.Rows[0]["IsFaculty"].ToString();

        //            if (IsFaculty == "Yes")
        //            {
        //                Approvers.Value = dt.Rows[0]["HOD_Email"].ToString() + "," + dt.Rows[0]["Dean_Email"].ToString() + "," + dt.Rows[0]["ProvostEmail"].ToString() + "," + dt.Rows[0]["HRManagerEmail"].ToString() + "," + dt.Rows[0]["CheifFincialAdminEmail"].ToString();
        //                Approvals.Value = "Dept Head Approval,Dean Approval,Provost Approval,HR Approval,Finance and Admin Approval";
        //            }
        //            else
        //            {
        //                Approvers.Value = dt.Rows[0]["HOD_Email"].ToString() + "," + dt.Rows[0]["HRManagerEmail"].ToString() + "," + dt.Rows[0]["CheifFincialAdminEmail"].ToString();
        //                Approvals.Value = "Dept Head Approval,HR Approval,Finance and Admin Approval";
        //            }

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        sc.Close();
        //        Console.WriteLine("{0} Exception caught.", ex.Message);
        //    }
        //    finally
        //    {
        //        sc.Close();
        //    }

        //}
        public void approvalDetails()
        {
            string hostdesc = "HR Representative Approval";
            string hostmail = "hr@ect.ac.ae";

            SqlCommand cmd1 = new SqlCommand("SELECT [Host] FROM [ECTDataNew].[dbo].[ECT_Services] where ServiceID=@ServiceID", sc);
            cmd1.Parameters.AddWithValue("@ServiceID", lbl_ServiceID.Text);
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            try
            {
                sc.Open();
                da1.Fill(dt1);
                sc.Close();

                if (dt1.Rows.Count > 0)
                {
                    hostdesc = "HR Representative Approval";
                    hostmail = dt1.Rows[0]["Host"].ToString();
                }
                else
                {
                    hostdesc = "HR Representative Approval";
                    hostmail = "hr@ect.ac.ae";
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


            Approvers.Value = "";
            Approvals.Value = "";
            SqlCommand cmd = new SqlCommand("select * from HR_Employee_Academic_Admin_Managers where EmployeeID='" + Session["EmployeeID"].ToString() + "'", sc);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                //if (dt.Rows.Count > 0)
                //{


                //    String IsFaculty = dt.Rows[0]["IsFaculty"].ToString();

                //    if (IsFaculty == "Yes")
                //    {
                //        Approvers.Value = dt.Rows[0]["HOD_Email"].ToString() + "," + dt.Rows[0]["Dean_Email"].ToString() + "," + dt.Rows[0]["ProvostEmail"].ToString() + "," + hostmail + "," + dt.Rows[0]["HRManagerEmail"].ToString() + "," + dt.Rows[0]["CheifFincialAdminEmail"].ToString();
                //        Approvals.Value = "Dept Head Approval,Dean Approval,Provost Approval,HR Representative Approval,HR Head Approval,Finance and Admin Approval";
                //    }
                //    else
                //    {
                //        Approvers.Value = dt.Rows[0]["HOD_Email"].ToString() + "," + hostmail + "," + dt.Rows[0]["HRManagerEmail"].ToString() + "," + dt.Rows[0]["CheifFincialAdminEmail"].ToString();
                //        Approvals.Value = "Dept Head Approval,HR Representative Approval,HR Head Approval,Finance and Admin Approval";
                //    }

                //}
                if (dt.Rows.Count > 0)
                {

                    string mymail = dt.Rows[0]["EmployeeEmail"].ToString();
                    string hodmail = dt.Rows[0]["HOD_Email"].ToString();
                    string deanmail = dt.Rows[0]["Dean_Email"].ToString();
                    string provostmail = "provost@ect.ac.ae";
                    string presidentmail = "president@ect.ac.ae";

                    if (mymail == provostmail)//Provost
                    {
                        Approvers.Value = presidentmail + "," + hostmail + "," + dt.Rows[0]["HRManagerEmail"].ToString() + "," + dt.Rows[0]["CheifFincialAdminEmail"].ToString();
                        Approvals.Value = "President Approval,HR Representative Approval,HR Head Approval,Finance and Admin Approval";
                    }
                    else if (mymail == presidentmail)//President
                    {
                        Approvers.Value = hostmail + "," + dt.Rows[0]["HRManagerEmail"].ToString() + "," + dt.Rows[0]["CheifFincialAdminEmail"].ToString();
                        Approvals.Value = "HR Representative Approval,HR Head Approval,Finance and Admin Approval";
                    }
                    else if (mymail == dt.Rows[0]["HRManagerEmail"].ToString())//HR Manager
                    {
                        Approvers.Value = hostmail + "," + dt.Rows[0]["CheifFincialAdminEmail"].ToString();
                        Approvals.Value = "HR Representative Approval,Finance and Admin Approval";
                    }
                    else if (mymail == dt.Rows[0]["CheifFincialAdminEmail"].ToString())//CFAO
                    {
                        Approvers.Value = presidentmail + "," + hostmail + "," + dt.Rows[0]["HRManagerEmail"].ToString();
                        Approvals.Value = "President Approval,HR Representative Approval,HR Head Approval";
                    }
                    else if (mymail == hodmail)
                    {
                        //Yes
                        if (hodmail == deanmail)
                        {
                            String IsFaculty = dt.Rows[0]["IsFaculty"].ToString();

                            if (IsFaculty == "Yes")
                            {
                                Approvers.Value = dt.Rows[0]["ProvostEmail"].ToString() + "," + hostmail + "," + dt.Rows[0]["HRManagerEmail"].ToString() + "," + dt.Rows[0]["CheifFincialAdminEmail"].ToString();
                                Approvals.Value = "Provost Approval,HR Representative Approval,HR Head Approval,Finance and Admin Approval";
                            }
                            else
                            {
                                Approvers.Value = presidentmail + "," + hostmail + "," + dt.Rows[0]["HRManagerEmail"].ToString() + "," + dt.Rows[0]["CheifFincialAdminEmail"].ToString();
                                Approvals.Value = "President Approval,HR Representative Approval,HR Head Approval,Finance and Admin Approval";
                            }
                        }
                        else
                        {
                            String IsFaculty = dt.Rows[0]["IsFaculty"].ToString();

                            if (IsFaculty == "Yes")
                            {
                                Approvers.Value = dt.Rows[0]["Dean_Email"].ToString() + "," + dt.Rows[0]["ProvostEmail"].ToString() + "," + hostmail + "," + dt.Rows[0]["HRManagerEmail"].ToString() + "," + dt.Rows[0]["CheifFincialAdminEmail"].ToString();
                                Approvals.Value = "Dean Approval,Provost Approval,HR Representative Approval,HR Head Approval,Finance and Admin Approval";
                            }
                            else
                            {
                                Approvers.Value = dt.Rows[0]["Dean_Email"].ToString() + "," + hostmail + "," + dt.Rows[0]["HRManagerEmail"].ToString() + "," + dt.Rows[0]["CheifFincialAdminEmail"].ToString();
                                Approvals.Value = "Dept Head Approval,HR Representative Approval,HR Head Approval,Finance and Admin Approval";
                            }
                        }
                    }
                    else
                    {
                        String IsFaculty = dt.Rows[0]["IsFaculty"].ToString();

                        if (IsFaculty == "Yes")
                        {
                            Approvers.Value = dt.Rows[0]["HOD_Email"].ToString() + "," + dt.Rows[0]["Dean_Email"].ToString() + "," + dt.Rows[0]["ProvostEmail"].ToString() + "," + hostmail + "," + dt.Rows[0]["HRManagerEmail"].ToString() + "," + dt.Rows[0]["CheifFincialAdminEmail"].ToString();
                            Approvals.Value = "Dept Head Approval,Dean Approval,Provost Approval,HR Representative Approval,HR Head Approval,Finance and Admin Approval";
                        }
                        else
                        {
                            //Approvers.Value = dt.Rows[0]["HOD_Email"].ToString() + "," + hostmail + "," + dt.Rows[0]["HRManagerEmail"].ToString() + "," + dt.Rows[0]["CheifFincialAdminEmail"].ToString();
                            //Approvals.Value = "Dept Head Approval,HR Representative Approval,HR Head Approval,Finance and Admin Approval";
                            Approvers.Value = dt.Rows[0]["HOD_Email"].ToString() + "," + dt.Rows[0]["Dean_Email"].ToString() + "," + hostmail + "," + dt.Rows[0]["HRManagerEmail"].ToString() + "," + dt.Rows[0]["CheifFincialAdminEmail"].ToString();
                            Approvals.Value = "Section Head Approval,Dept Head Approval,HR Representative Approval,HR Head Approval,Finance and Admin Approval";
                        }
                    }

                    if (Session["EmployeeID"].ToString() == "10100")//Exception-Mr. Mohannad Taher Mohammad Al Shayeb    Director - Student Affairs and Enrollment
                    {
                        Approvers.Value = "wesam.alanqar@ect.ac.ae" + "," + hostmail + "," + dt.Rows[0]["HRManagerEmail"].ToString() + "," + dt.Rows[0]["CheifFincialAdminEmail"].ToString();
                        Approvals.Value = "Dean Approval,HR Representative Approval,HR Head Approval,Finance and Admin Approval";
                    }
                    if (Session["EmployeeID"].ToString() == "10046" || Session["EmployeeID"].ToString() == "10028")//Exception-Mr. Moustafa Sobhy Moustafa Sabbah    Manager - Student Affairs & Mr.  Suhib Ahmad Hussein Alamereyyeh    Manager - Student Registration
                    {
                        Approvers.Value = "mohannad.alshayeb@ect.ac.ae" + "," + "wesam.alanqar@ect.ac.ae" + "," + hostmail + "," + dt.Rows[0]["HRManagerEmail"].ToString() + "," + dt.Rows[0]["CheifFincialAdminEmail"].ToString();
                        Approvals.Value = "Dept Head Approval,Dean Approval,HR Representative Approval,HR Head Approval,Finance and Admin Approval";
                    }
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
    }
}