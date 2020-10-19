using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LocalECT
{
    public partial class Manage_Users : System.Web.UI.Page
    {
        UserDAL myUserDAL = new UserDAL();
        int RoleID = 0;
        DataView dv = new DataView();
        int CurrentRole = 0;
        string sUserName = "";
        protected void Page_Load(object sender, EventArgs e)
        {          
            //Security
            if (Session["CurrentRole"] != null)
            {
                CurrentRole = (int)Session["CurrentRole"];
            }
            else
            {
                Session.RemoveAll();
                Response.Redirect("Login.aspx");
            }
            //int CurrentRole = 0;
            string sUserName = Session["CurrentUserName"].ToString();
            //CurrentRole = (int)Session["CurrentRole"];
            if (!IsPostBack)
            {
                if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_RolesManager,
                InitializeModule.enumPrivilege.ShowBrowse, CurrentRole) != true)
                {
                    Server.Transfer("Authorization.aspx");
                }
            }

            RoleID = int.Parse(Request.QueryString["RoleID"]);
            if (!IsPostBack)
            {
                fillUserslst();
                fillRoleUserslst();
                RoleDAL myRolesDAL = new RoleDAL();
                RoleLBL.Text = myRolesDAL.GetRoleDesc(RoleID);
            }
        }
        private void fillUserslst()
        {

            try
            {

                dv = myUserDAL.GetDataView(false, 0, "");
                UsersLST.DataSource = dv;

                UsersLST.DataValueField = dv.Table.Columns[0].ColumnName;
                UsersLST.DataTextField = dv.Table.Columns[1].ColumnName;
                UsersLST.DataBind();


            }
            catch (Exception exp)
            {
                Console.WriteLine("{0} Exception caught.", exp);
                lbl_Msg.Text = exp.Message;
                div_msg.Visible = true;
            }
            finally
            {

                Session["UsersDV"] = dv;

            }
        }
        private void fillRoleUserslst()
        {
            List<User> myUsers = new List<User>();

            try
            {
                RoleUsersLST.Items.Clear();

                myUsers = myUserDAL.GetRoleUsers(InitializeModule.EnumCampus.ECTNew, RoleID, "", false);

                for (int i = 0; i < myUsers.Count; i++)
                {
                    RoleUsersLST.Items.Add(new ListItem(myUsers[i].UserName, myUsers[i].UserNo.ToString()));
                }

            }
            catch (Exception exp)
            {
                Console.WriteLine("{0} Exception caught.", exp);
                lbl_Msg.Text = exp.Message;
                div_msg.Visible = true;
            }
            finally
            {

                myUsers.Clear();

            }
        }


        private int AddUsers()
        {
            SqlConnection Conn = new SqlConnection();

            int r = 0;
            try
            {
                InitializeModule.EnumCampus iCampus = InitializeModule.EnumCampus.ECTNew;
                Connection_StringCLS sConn = new Connection_StringCLS(iCampus);

                Conn.ConnectionString = sConn.Conn_string;

                Conn.Open();
                bool isDuplicate = false;
                foreach (ListItem lst in UsersLST.Items)
                {
                    if (lst.Selected == true)
                    {
                        foreach (ListItem rlst in RoleUsersLST.Items)
                        {
                            if (lst.Value == rlst.Value)
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
                            r += myUserDAL.AddUsersToRole(int.Parse(lst.Value), RoleID, Conn, sUserName);
                        }
                    }
                }



            }
            catch (Exception exp)
            {
                Console.WriteLine("{0} Exception caught.", exp);
                lbl_Msg.Text = exp.Message;
                div_msg.Visible = true;
            }
            finally
            {

                Conn.Close();
                Conn.Dispose();

            }
            return r;
        }

        private int DeleteUsers()
        {
            SqlConnection Conn = new SqlConnection();
            int r = 0;
            try
            {
                InitializeModule.EnumCampus iCampus = InitializeModule.EnumCampus.ECTNew;
                Connection_StringCLS sConn = new Connection_StringCLS(iCampus);

                Conn.ConnectionString = sConn.Conn_string;
                string sCondition = " Where RoleID=" + RoleID + " AND UserNo IN (0";

                Conn.Open();

                foreach (ListItem lst in RoleUsersLST.Items)
                {
                    if (lst.Selected == true)
                    {
                        sCondition += "," + lst.Value;
                    }
                }
                sCondition += ")";


                r = myUserDAL.DeleteUsersFromRole(sCondition, Conn, sUserName);

            }
            catch (Exception exp)
            {
                Console.WriteLine("{0} Exception caught.", exp);
                lbl_Msg.Text = exp.Message;
                div_msg.Visible = true;
            }
            finally
            {

                Conn.Close();
                Conn.Dispose();
            }
            return r;
        }
        protected void RemoveCMD_Click(object sender, EventArgs e)
        {
            DeleteUsers();
            fillRoleUserslst();
        }

        protected void AddCMD_Click(object sender, EventArgs e)
        {
            AddUsers();
            fillRoleUserslst();
        }
 

        protected void SearchCMD_Click(object sender, EventArgs e)
        {
            if (Session["UsersDV"] != null)
            {
                dv = (DataView)Session["UsersDV"];
                if (UserSerachTXT.Text != "")
                {
                    dv.RowFilter = "UserName like '%" + UserSerachTXT.Text + "%'";

                }
                else
                {
                    dv.RowFilter = "";

                }
                UsersLST.DataSource = dv;
                UsersLST.DataBind();

            }
        }

        protected void AddUserCMD_Click(object sender, EventArgs e)
        {
            Response.Redirect("User_Setup.aspx?RoleID=" + RoleID);
        }
    }
}