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
    public partial class Student_Service_Requests : System.Web.UI.Page
    {
        int CurrentRole = 0;
        InitializeModule.EnumCampus Campus = InitializeModule.EnumCampus.Males;
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
                    if (Request.QueryString["sEmail"] != null && Request.QueryString["sEmail"] != "" && Request.QueryString["sEmail"] != "-")
                    {
                        //Connection_StringCLS connstr = new Connection_StringCLS(Campus);
                        //string studentid = Request.QueryString["sid"].ToString();
                        //var services = new DAL.DAL();
                        //DataTable dtStudentServices = services.GetStudentDetailsID(studentid, connstr.Conn_string);
                        //if (dtStudentServices.Rows.Count > 0)
                        //{                           
                        //   Session["Student_emails"] = dtStudentServices.Rows[0]["sECTemail"].ToString();
                           bindmyrequests(Request.QueryString["sEmail"].ToString());
                        
                    }
                    else
                    {
                        DataTable dt = new DataTable();
                        Repeater1.DataSource = dt;
                        Repeater1.DataBind();
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
            if (Request.QueryString["sEmail"] != null && Request.QueryString["sEmail"] != "" && Request.QueryString["sEmail"] != "-")
            {
                bindmyrequests(Request.QueryString["sEmail"].ToString());
            }
            else
            {
                DataTable dt = new DataTable();
                Repeater1.DataSource = dt;
                Repeater1.DataBind();
            }
        }
        public void bindmyrequests(string studentemail)
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
            query.ViewXml = "<View><Query><Where><Eq><FieldRef Name='Requester' LookupId='TRUE'/><Value Type='User'>" + userid + "</Value></Eq></Where></Query><RowLimit>100</RowLimit></View>";
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
            LDT.Columns.Add("Status");
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
                LDT.Rows.Add(item["ID"], item["Title"], item["Status"], item["Request"], item["Requester"], Convert.ToDateTime(item["Created"]), show);
            }
            LDT.DefaultView.Sort = "Created DESC";
            Repeater1.DataSource = LDT;
            Repeater1.DataBind();
        }
    }
}