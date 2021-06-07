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


namespace LocalECT
{
    public partial class Strategy_Department_Manage_Sections : System.Web.UI.Page
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
                        //InitializeModule.enumPrivilege.ShowBrowse, CurrentRole) != true)
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
                        string id = Request.QueryString["id"];
                        if (id != null)
                        {                            
                            fillPermissionslst(id);
                            fillObjectPrivilegeslst(id);
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
        private void fillPermissionslst(string DeptID)
        {
            List<Privilege> myPrivileges = new List<Privilege>();
            //RoleDAL myRoleDAL = new RoleDAL();
            try
            {
                ObjPermissionLST.Items.Clear();

                myPrivileges = GetRoleObjPermissions(DeptID);

                for (int i = 0; i < myPrivileges.Count; i++)
                {
                    ObjPermissionLST.Items.Add(new ListItem(myPrivileges[i].PriviligeNameEn, myPrivileges[i].PrivilegeID.ToString()));
                }

            }
            catch (Exception exp)
            {
                Console.WriteLine("{0} Exception caught.", exp);
            }
            finally
            {
                myPrivileges.Clear();
            }
        }

        public List<Privilege> GetRoleObjPermissions(string DeptID)
        {

            InitializeModule.EnumCampus iCampus = InitializeModule.EnumCampus.ECTNew;
            Connection_StringCLS sConn = new Connection_StringCLS(iCampus);

            SqlConnection Conn = new SqlConnection(sConn.Conn_string.ToString());

            SqlCommand Cmd = new SqlCommand("SELECT DepartmentID, SectionID, DescEN FROM Lkp_Section where SectionID<>-1 and DepartmentID=@DepartmentID order by DescEN", Conn);
            Cmd.Parameters.AddWithValue("@DepartmentID", DeptID);
            Conn.Open();
            SqlDataReader Rd = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
            List<Privilege> results = new List<Privilege>();

            //int i = 0;
            try
            {
                while (Rd.Read())
                {
                    Privilege MyPrivilege = new Privilege();
                    MyPrivilege.PrivilegeID = int.Parse(Rd["SectionID"].ToString());
                    MyPrivilege.PriviligeNameEn = Rd["DescEN"].ToString();
                    MyPrivilege.DefaultEffect = int.Parse(Rd["DepartmentID"].ToString());                    
                    results.Add(MyPrivilege);
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                //'Response.Write(ex.Message) 

                Rd.Close();
                Rd.Dispose();
                Conn.Close();
                Conn.Dispose();
            }
            //myStatus.Clear() 

            return results;

        }
        private void fillObjectPrivilegeslst(string DeptID)
        {
            List<Privilege> myPrivileges = new List<Privilege>();
            //PrivilegeDAL myPrivilegesDAL = new PrivilegeDAL();
            try
            {
                PermissionsLST.Items.Clear();

                myPrivileges = GetObjectPrivileges(DeptID);

                for (int i = 0; i < myPrivileges.Count; i++)
                {
                    PermissionsLST.Items.Add(new ListItem(myPrivileges[i].PriviligeNameEn, myPrivileges[i].PrivilegeID.ToString()));
                }

            }
            catch (Exception exp)
            {
                Console.WriteLine("{0} Exception caught.", exp);
            }
            finally
            {

                myPrivileges.Clear();

            }
        }
        public List<Privilege> GetObjectPrivileges(string DeptID)
        {

            InitializeModule.EnumCampus iCampus = InitializeModule.EnumCampus.ECTNew;
            //iCampus = InitializeModule.EnumCampus.ECTNew;
            Connection_StringCLS sConn = new Connection_StringCLS(iCampus);


            //, OP.ObjectID
           

            SqlConnection Conn = new SqlConnection(sConn.Conn_string.ToString());

            SqlCommand Cmd = new SqlCommand("SELECT DepartmentID, SectionID, DescEN FROM Lkp_Section where SectionID<>-1 and DepartmentID<>@DepartmentID order by DescEN", Conn);
            Cmd.Parameters.AddWithValue("@DepartmentID", DeptID);
            Conn.Open();
            SqlDataReader Rd = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
            List<Privilege> results = new List<Privilege>();

            //int i = 0;
            try
            {
                while (Rd.Read())
                {
                    Privilege MyPrivilege = new Privilege();
                    MyPrivilege.PrivilegeID = int.Parse(Rd["SectionID"].ToString());
                    MyPrivilege.PriviligeNameEn = Rd["DescEN"].ToString();
                    MyPrivilege.DefaultEffect = int.Parse(Rd["DepartmentID"].ToString());
                    results.Add(MyPrivilege);
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                //'Response.Write(ex.Message) 

                Rd.Close();
                Rd.Dispose();
                Conn.Close();
                Conn.Dispose();
            }
            //myStatus.Clear() 

            return results;

        }
        //Add Section to Department
        protected void AddPermissionCMD_Click(object sender, EventArgs e)
        {
            SqlConnection Conn = new SqlConnection();
            InitializeModule.EnumCampus iCampus = InitializeModule.EnumCampus.ECTNew;
            Connection_StringCLS sConn = new Connection_StringCLS(iCampus);
            Conn.ConnectionString = sConn.Conn_string;
            Conn.Open();
            
            int r = 0;

            try
            {
                int ObjId = int.Parse(Request.QueryString["id"]);
                bool isDuplicate = false;

                foreach (ListItem lst in PermissionsLST.Items)
                {
                    if (lst.Selected == true)
                    {
                        foreach (ListItem olst in ObjPermissionLST.Items)
                        {
                            if (lst.Value == olst.Value)
                            {
                                isDuplicate = true;
                            }
                            else
                            {
                                isDuplicate = false;
                            }
                        }

                        if (isDuplicate != true)
                        {
                           r += AddPermissionToRole(ObjId, int.Parse(lst.Value),Conn);
                        }
                    }
                }
                fillPermissionslst(ObjId.ToString());
                fillObjectPrivilegeslst(ObjId.ToString());
            }
            catch (Exception exp)
            {
                Console.WriteLine("{0} Exception caught.", exp);
            }
            finally
            {

                Conn.Close();
                Conn.Dispose();
            }
        }
        //Add Section to Department
        public int AddPermissionToRole(int DeptID, int SectionID, SqlConnection Conn)
        {
            int iEffected = 0;
            try
            {
                SqlCommand Cmd = new SqlCommand("update Lkp_Section set DepartmentID=@DepartmentID where SectionID=@SectionID", Conn);
                Cmd.Parameters.Add(new SqlParameter("@DepartmentID", DeptID));
                Cmd.Parameters.Add(new SqlParameter("@SectionID", SectionID));   
                iEffected = Cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex.Message);
            }
            finally
            {
                //Conn.Close();
            }
            return iEffected;
        }
        //Remove Section from Department
        protected void RemovePermissionCMD_Click(object sender, EventArgs e)
        {
            SqlConnection Conn = new SqlConnection();
            InitializeModule.EnumCampus iCampus = InitializeModule.EnumCampus.ECTNew;
            Connection_StringCLS sConn = new Connection_StringCLS(iCampus);
            Conn.ConnectionString = sConn.Conn_string;
            Conn.Open();

            int r = 0;

            try
            {
                int ObjId = int.Parse(Request.QueryString["id"]);             
                foreach (ListItem lst in ObjPermissionLST.Items)
                {
                    if (lst.Selected == true)
                    {
                       r = RemovePermissionFromRole(ObjId, int.Parse(lst.Value), Conn);
                    }
                }
                fillPermissionslst(ObjId.ToString());
                fillObjectPrivilegeslst(ObjId.ToString());
            }
            catch (Exception exp)
            {
                Console.WriteLine("{0} Exception caught.", exp);
            }
            finally
            {

                Conn.Close();
                Conn.Dispose();
            }
        }
        //Remove Section from Department
        public int RemovePermissionFromRole(int DeptID, int SectionID, SqlConnection Conn)
        {
            int iEffected = 0;
            try
            {
                SqlCommand Cmd = new SqlCommand("update Lkp_Section set DepartmentID=@DepartmentID where SectionID=@SectionID", Conn);
                Cmd.Parameters.Add(new SqlParameter("@DepartmentID", "-1"));
                Cmd.Parameters.Add(new SqlParameter("@SectionID", SectionID));
                iEffected = Cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex.Message);
            }
            finally
            {
                //Conn.Close();
            }
            return iEffected;
        }
    }
}