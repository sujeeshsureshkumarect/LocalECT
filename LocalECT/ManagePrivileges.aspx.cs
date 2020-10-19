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
    public partial class ManagePrivileges : System.Web.UI.Page
    {
        PrivilegeDAL myPrivilegesDAL = new PrivilegeDAL();

        int CurrentRole = 0;
        int iObjectID = 0;
        string sUserName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
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
            sUserName = Session["CurrentUserName"].ToString();
            //CurrentRole = (int)Session["CurrentRole"];
            if (!IsPostBack)
            {
                if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.Setting_RolesManager,
                InitializeModule.enumPrivilege.ShowBrowse, CurrentRole) != true)
                {
                    Server.Transfer("Authorization.aspx");

                }
            }
            iObjectID = int.Parse(Request.QueryString["ObjectID"]);
            ObjectLBL.Text = Request.QueryString["ObjectName"] + " Privileges";
            if (!IsPostBack)
            {
                fillPrivilegeslst();
                fillObjectPrivilegeslst(true);
            }
        }
        private void fillPrivilegeslst()
        {
            List<Privilege> myPrivileges = new List<Privilege>();

            try
            {
                PrivilegesLST.Items.Clear();

                myPrivileges = myPrivilegesDAL.GetPrivilege(InitializeModule.EnumCampus.ECTNew, "", false);

                for (int i = 0; i < myPrivileges.Count; i++)
                {
                    PrivilegesLST.Items.Add(new ListItem(myPrivileges[i].PriviligeNameEn, myPrivileges[i].PrivilegeID.ToString()));
                }

            }
            catch (Exception exp)
            {
                Console.WriteLine("{0} Exception caught.", exp);
                div_msg.Visible = true;
                lbl_Msg.Text = exp.Message;
            }
            finally
            {

                myPrivileges.Clear();

            }
        }

        private void fillObjectPrivilegeslst(bool isFillDefaultOnly)
        {
            List<Privilege> myPrivileges = new List<Privilege>();

            try
            {
                ObjectPrivilegesLST.Items.Clear();

                //SELECT P.PrivilegeID, P.PriviligeNameEn, P.DefaultEffect";
                //sSQL += " FROM dbo.Cmn_Privilege AS P INNER JOIN dbo.Cmn_Permissions AS OP ON P.PrivilegeID = OP.PrivilegeID

                myPrivileges = myPrivilegesDAL.GetObjectPrivileges(" Where OP.ObjectID=" + iObjectID);  // + " AND P.DefaultEffect=" + InitializeModule.TRUE_VALUE

                for (int i = 0; i < myPrivileges.Count; i++)
                {
                    ObjectPrivilegesLST.Items.Add(new ListItem(myPrivileges[i].PriviligeNameEn, myPrivileges[i].PrivilegeID.ToString()));
                }

            }
            catch (Exception exp)
            {
                Console.WriteLine("{0} Exception caught.", exp);
                div_msg.Visible = true;
                lbl_Msg.Text = exp.Message;
            }
            finally
            {

                myPrivileges.Clear();

            }
        }
        private int AddPrivileges()
        {
            SqlConnection Conn = new SqlConnection();
            InitializeModule.EnumCampus iCampus = InitializeModule.EnumCampus.ECTNew;
            Connection_StringCLS sConn = new Connection_StringCLS(iCampus);

            Conn.ConnectionString = sConn.Conn_string;

            Conn.Open();

            int r = 0;
            try
            {

                bool isDuplicate = false;
                foreach (ListItem lst in PrivilegesLST.Items)
                {
                    if (lst.Selected == true)
                    {
                        foreach (ListItem olst in ObjectPrivilegesLST.Items)
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
                            r += myPrivilegesDAL.AddPrivilegeToObject(iObjectID, int.Parse(lst.Value), Conn, sUserName);
                        }
                    }
                }



            }
            catch (Exception exp)
            {
                Console.WriteLine("{0} Exception caught.", exp);
                div_msg.Visible = true;
                lbl_Msg.Text = exp.Message;
            }
            finally
            {

                Conn.Close();
                Conn.Dispose();
            }
            return r;
        }

        private int DeletePrivileges()
        {
            SqlConnection Conn = new SqlConnection();
            InitializeModule.EnumCampus iCampus = InitializeModule.EnumCampus.ECTNew;
            Connection_StringCLS sConn = new Connection_StringCLS(iCampus);

            Conn.ConnectionString = sConn.Conn_string;

            Conn.Open();
            int r = 0;
            try
            {
                string sCondition = " Where ObjectID=" + iObjectID + " AND PrivilegeID IN (0";

                foreach (ListItem lst in ObjectPrivilegesLST.Items)
                {
                    if (lst.Selected == true)
                    {
                        sCondition += "," + lst.Value;
                    }
                }
                sCondition += ")";


                r = myPrivilegesDAL.DeletePrivilegeFromObject(sCondition, Conn, sUserName);

            }
            catch (Exception exp)
            {
                Console.WriteLine("{0} Exception caught.", exp);
                div_msg.Visible = true;
                lbl_Msg.Text = exp.Message;
            }
            finally
            {

                Conn.Close();
                Conn.Dispose();
            }
            return r;
        }
        protected void AddCMD_Click(object sender, EventArgs e)
        {
            AddPrivileges();
            fillObjectPrivilegeslst(false);


        }
        protected void RemoveCMD_Click(object sender, EventArgs e)
        {
            DeletePrivileges();
            fillObjectPrivilegeslst(false);
        }
    }
}