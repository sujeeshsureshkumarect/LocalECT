using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LocalECT
{
    public partial class Student_Service_Requests_Approvers : System.Web.UI.Page
    {
        int CurrentRole = 0;
        InitializeModule.EnumCampus Campus = InitializeModule.EnumCampus.Males;
        SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["ECTDataNew"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CurrentRole"] != null)
            {
                CurrentRole = (int)Session["CurrentRole"];
                if (Session["CurrentCampus"] != null)
                {
                    Campus = (InitializeModule.EnumCampus)Session["CurrentCampus"];
                }
                else
                {
                    Campus = InitializeModule.EnumCampus.Males;
                }
                if (!IsPostBack)
                {
                    SqlCommand cmd = new SqlCommand("SELECT * from Hr_EmployeeProfileRpt where EmployeeID=" + Session["EmployeeID"].ToString() + "", sc);
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    try
                    {
                        sc.Open();
                        da.Fill(dt);
                        sc.Close();

                        if (dt.Rows.Count > 0)
                        {
                            bindmyrequests_finance(dt.Rows[0]["InternalEmail"].ToString());//ahmad.abuqaran@ect.ac.ae  dt.Rows[0]["InternalEmail"].ToString()
                            bindmyrequests_host(dt.Rows[0]["InternalEmail"].ToString());//suhib.alamereyyeh@ect.ac.ae
                            bindmyrequests_provider(dt.Rows[0]["InternalEmail"].ToString());//mohamad.shaath@ect.ac.ae
                        }
                        else
                        {
                            DataTable dt1 = new DataTable();
                            Repeater1.DataSource = dt1;
                            Repeater1.DataBind();

                            Repeater2.DataSource = dt1;
                            Repeater2.DataBind();

                            Repeater3.DataSource = dt1;
                            Repeater3.DataBind();
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
            else
            {
                Session.RemoveAll();
                Response.Redirect("Login.aspx");
            }
        }
        protected void lnk_refresh_Click(object sender, EventArgs e)
        {           
            SqlCommand cmd = new SqlCommand("SELECT * from Hr_EmployeeProfileRpt where EmployeeID=" + Session["EmployeeID"].ToString() + "", sc);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                if (dt.Rows.Count > 0)
                {
                    bindmyrequests_finance(dt.Rows[0]["InternalEmail"].ToString());
                    bindmyrequests_host(dt.Rows[0]["InternalEmail"].ToString());
                    bindmyrequests_provider(dt.Rows[0]["InternalEmail"].ToString());
                }
                else
                {
                    DataTable dt1 = new DataTable();
                    Repeater1.DataSource = dt1;
                    Repeater1.DataBind();

                    Repeater2.DataSource = dt1;
                    Repeater2.DataBind();

                    Repeater3.DataSource = dt1;
                    Repeater3.DataBind();
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
        public void bindmyrequests_finance(string studentemail)
        {
            string login = "ets.services.admin@ect.ac.ae"; //give your username here  
            string password = "Ser71ces@328"; //give your password  
            var securePassword = new SecureString();
            foreach (char c in password)
            {
                securePassword.AppendChar(c);
            }
            string siteUrl = "https://ectacae.sharepoint.com/sites/ECTPortal/eservices/studentservices";
            ClientContext clientContext = new ClientContext(siteUrl);
            var onlineCredentials = new SharePointOnlineCredentials(login, securePassword);
            clientContext.Credentials = onlineCredentials;
            List list = clientContext.Web.Lists.GetByTitle("Students_Requests");
            CamlQuery query = new CamlQuery();
            string mail = studentemail;

            Microsoft.SharePoint.Client.User user = clientContext.Web.EnsureUser(mail);
            clientContext.Load(user, x => x.Id);
            clientContext.ExecuteQuery();
            //string thisWillBeUsersLoginName = user.Id;
            int userid = user.Id;

            //clientContext.Web.EnsureUser(mail)
            string hrcondition = "Approve";
            query.ViewXml = "<View><Query><Where><And><Eq><FieldRef Name='Finance' LookupId='TRUE'/><Value Type='User'>" + userid + "</Value></Eq><Neq><FieldRef Name='FinanceAction'/><Value Type='Choice'>" + hrcondition + "</Value></Neq></And></Where></Query><RowLimit>100</RowLimit></View>";
            //query.ViewXml = "<View></View>";
            Microsoft.SharePoint.Client.ListItemCollection items = list.GetItems(query);
            clientContext.Load(list);
            clientContext.Load(items);
            clientContext.ExecuteQuery();

            string show = "N";
            if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Student_Data,
              InitializeModule.enumPrivilege.FetchRequest, CurrentRole) != true)
            {
                show = "N";
            }
            else
            {
                show = "Y";
            }

            // create a data table
            DataTable LDT = new DataTable();
            LDT.Columns.Add("ID");
            LDT.Columns.Add("Title");
            LDT.Columns.Add("FinanceAction");
            LDT.Columns.Add("ServiceID");
            LDT.Columns.Add("Requester");
            LDT.Columns.Add("Created", System.Type.GetType("System.DateTime"));
            LDT.Columns.Add("Show");
            //fill datatatable
            foreach (Microsoft.SharePoint.Client.ListItem item in items)
            {
                //var userValue = (FieldUserValue)item["Requester"];
                //var user = clientContext.Web.GetUserById(userValue.LookupId);
                //clientContext.Load(user, x => x.LoginName);
                //clientContext.ExecuteQuery();
                //string thisWillBeUsersLoginName = user.LoginName;
                //string request = item["Request"].ToString();
                LDT.Rows.Add(item["ID"], item["Title"], item["FinanceAction"], item["Request"], item["Requester"], Convert.ToDateTime(item["Created"]), show);
            }
            LDT.DefaultView.Sort = "Created DESC";
            Repeater1.DataSource = LDT;
            Repeater1.DataBind();
        }
        public void bindmyrequests_host(string studentemail)
        {
            string login = "ets.services.admin@ect.ac.ae"; //give your username here  
            string password = "Ser71ces@328"; //give your password  
            var securePassword = new SecureString();
            foreach (char c in password)
            {
                securePassword.AppendChar(c);
            }
            string siteUrl = "https://ectacae.sharepoint.com/sites/ECTPortal/eservices/studentservices";
            ClientContext clientContext = new ClientContext(siteUrl);
            var onlineCredentials = new SharePointOnlineCredentials(login, securePassword);
            clientContext.Credentials = onlineCredentials;
            List list = clientContext.Web.Lists.GetByTitle("Students_Requests");
            CamlQuery query = new CamlQuery();
            string mail = studentemail;

            Microsoft.SharePoint.Client.User user = clientContext.Web.EnsureUser(mail);
            clientContext.Load(user, x => x.Id);
            clientContext.ExecuteQuery();
            //string thisWillBeUsersLoginName = user.Id;
            int userid = user.Id;

            //clientContext.Web.EnsureUser(mail)
            string hrcondition = "Approve";
            query.ViewXml = "<View><Query><Where><And><Eq><FieldRef Name='Host' LookupId='TRUE'/><Value Type='User'>" + userid + "</Value></Eq><Neq><FieldRef Name='HostAction'/><Value Type='Choice'>" + hrcondition + "</Value></Neq></And></Where></Query><RowLimit>100</RowLimit></View>";
            //query.ViewXml = "<View></View>";
            Microsoft.SharePoint.Client.ListItemCollection items = list.GetItems(query);
            clientContext.Load(list);
            clientContext.Load(items);
            clientContext.ExecuteQuery();

            string show = "N";
            if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Student_Data,
              InitializeModule.enumPrivilege.FetchRequest, CurrentRole) != true)
            {
                show = "N";
            }
            else
            {
                show = "Y";
            }

            // create a data table
            DataTable LDT = new DataTable();
            LDT.Columns.Add("ID");
            LDT.Columns.Add("Title");
            LDT.Columns.Add("HostAction");
            LDT.Columns.Add("ServiceID");
            LDT.Columns.Add("Requester");
            LDT.Columns.Add("Created", System.Type.GetType("System.DateTime"));
            LDT.Columns.Add("Show");
            //fill datatatable
            foreach (Microsoft.SharePoint.Client.ListItem item in items)
            {
                //var userValue = (FieldUserValue)item["Requester"];
                //var user = clientContext.Web.GetUserById(userValue.LookupId);
                //clientContext.Load(user, x => x.LoginName);
                //clientContext.ExecuteQuery();
                //string thisWillBeUsersLoginName = user.LoginName;
                //string request = item["Request"].ToString();
                LDT.Rows.Add(item["ID"], item["Title"], item["HostAction"], item["Request"], item["Requester"], Convert.ToDateTime(item["Created"]), show);
            }
            LDT.DefaultView.Sort = "Created DESC";
            Repeater2.DataSource = LDT;
            Repeater2.DataBind();
        }
        public void bindmyrequests_provider(string studentemail)
        {
            string login = "ets.services.admin@ect.ac.ae"; //give your username here  
            string password = "Ser71ces@328"; //give your password  
            var securePassword = new SecureString();
            foreach (char c in password)
            {
                securePassword.AppendChar(c);
            }
            string siteUrl = "https://ectacae.sharepoint.com/sites/ECTPortal/eservices/studentservices";
            ClientContext clientContext = new ClientContext(siteUrl);
            var onlineCredentials = new SharePointOnlineCredentials(login, securePassword);
            clientContext.Credentials = onlineCredentials;
            List list = clientContext.Web.Lists.GetByTitle("Students_Requests");
            CamlQuery query = new CamlQuery();
            string mail = studentemail;

            Microsoft.SharePoint.Client.User user = clientContext.Web.EnsureUser(mail);
            clientContext.Load(user, x => x.Id);
            clientContext.ExecuteQuery();
            //string thisWillBeUsersLoginName = user.Id;
            int userid = user.Id;

            //clientContext.Web.EnsureUser(mail)
            string hrcondition = "Done";
            query.ViewXml = "<View><Query><Where><And><Eq><FieldRef Name='Provider' LookupId='TRUE'/><Value Type='User'>" + userid + "</Value></Eq><Neq><FieldRef Name='ProviderAction'/><Value Type='Choice'>" + hrcondition + "</Value></Neq></And></Where></Query><RowLimit>100</RowLimit></View>";
            //query.ViewXml = "<View></View>";
            Microsoft.SharePoint.Client.ListItemCollection items = list.GetItems(query);
            clientContext.Load(list);
            clientContext.Load(items);
            clientContext.ExecuteQuery();

            string show = "N";
            if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Student_Data,
              InitializeModule.enumPrivilege.FetchRequest, CurrentRole) != true)
            {
                show = "N";
            }
            else
            {
                show = "Y";
            }

            // create a data table
            DataTable LDT = new DataTable();
            LDT.Columns.Add("ID");
            LDT.Columns.Add("Title");
            LDT.Columns.Add("ProviderAction");
            LDT.Columns.Add("ServiceID");
            LDT.Columns.Add("Requester");
            LDT.Columns.Add("Created", System.Type.GetType("System.DateTime"));
            LDT.Columns.Add("Show");
            //fill datatatable
            foreach (Microsoft.SharePoint.Client.ListItem item in items)
            {
                //var userValue = (FieldUserValue)item["Requester"];
                //var user = clientContext.Web.GetUserById(userValue.LookupId);
                //clientContext.Load(user, x => x.LoginName);
                //clientContext.ExecuteQuery();
                //string thisWillBeUsersLoginName = user.LoginName;
                //string request = item["Request"].ToString();
                LDT.Rows.Add(item["ID"], item["Title"], item["ProviderAction"], item["Request"], item["Requester"], Convert.ToDateTime(item["Created"]), show);
            }
            LDT.DefaultView.Sort = "Created DESC";
            Repeater3.DataSource = LDT;
            Repeater3.DataBind();
        }
    }
}