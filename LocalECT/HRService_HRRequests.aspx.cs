using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Security;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace LocalECT
{
    public partial class HRService_HRRequests : System.Web.UI.Page
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
                        bindmyrequests();                    
                }
            }
            else
            {
                Session.RemoveAll();
                Response.Redirect("Login.aspx");
            }
        }

        public void getempemail()
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
                    UserEmail.Value = dt.Rows[0]["EmployeeEmail"].ToString();
                }
                else
                {
                    UserEmail.Value = null;
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
        protected void lnk_refresh_Click(object sender, EventArgs e)
        {            
                bindmyrequests();            
        }
        public void bindmyrequests()
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.DefaultConnectionLimit = 9999;
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;

            string login = "ets.services.admin@ect.ac.ae"; //give your username here  
            string password = "Ser71ces@328"; //give your password  
            var securePassword = new SecureString();
            foreach (char c in password)
            {
                securePassword.AppendChar(c);
            }
            string siteUrl = "https://ectacae.sharepoint.com/sites/ECTPortal/eservices/hrservices";
            ClientContext clientContext = new ClientContext(siteUrl);
            var onlineCredentials = new SharePointOnlineCredentials(login, securePassword);
            clientContext.Credentials = onlineCredentials;
            List list = clientContext.Web.Lists.GetByTitle("HR-Services");
            CamlQuery query = new CamlQuery();
            
            string hrcondition = "Approval process completed successfully";//show all which is not approved
            query.ViewXml = "<View><Query><Where><Neq><FieldRef Name='Title'/><Value Type='Text'>" + hrcondition + "</Value></Neq></Where></Query></View>";
            Microsoft.SharePoint.Client.ListItemCollection items = list.GetItems(query);
            clientContext.Load(list);
            clientContext.Load(items);
            clientContext.ExecuteQuery();           

            // create a data table
            DataTable LDT = new DataTable();
            LDT.Columns.Add("ID");
            LDT.Columns.Add("Reference");
            LDT.Columns.Add("Request");
            LDT.Columns.Add("Status");
            LDT.Columns.Add("ServiceID");
            LDT.Columns.Add("EmpID");
            LDT.Columns.Add("EmployeeName");
            LDT.Columns.Add("Created", System.Type.GetType("System.DateTime"));
            
            //fill datatatable
            foreach (Microsoft.SharePoint.Client.ListItem item in items)
            {
                LDT.Rows.Add(item["ID"], item["Reference"], item["Request"], item["Title"], item["ServiceID"], item["EmpID"], item["Employee_x0020_Name"], Convert.ToDateTime(item["Created"]));
            }
            LDT.DefaultView.Sort = "Created DESC";
            Repeater1.DataSource = LDT;
            Repeater1.DataBind();
        }
    }
}