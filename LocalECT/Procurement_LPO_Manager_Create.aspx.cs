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
    public partial class Procurement_LPO_Manager_Create : System.Web.UI.Page
    {
        LibraryMOD myLibrary = new LibraryMOD();
        int CurrentRole = 0;
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
            sUserName = Session["CurrentUserName"].ToString();
            //CurrentRole = (int)Session["CurrentRole"];
            if (!IsPostBack)
            {
                if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.Procurment_LPOManager,
                InitializeModule.enumPrivilege.ShowBrowse, CurrentRole) != true)
                {
                    Server.Transfer("Authorization.aspx");

                }
            }

            if (!IsPostBack)
            {

            }
        }

        public void bindsuppliers()
        {

        }
        protected void lnk_Generate_Click(object sender, EventArgs e)
        {

        }
    }
}