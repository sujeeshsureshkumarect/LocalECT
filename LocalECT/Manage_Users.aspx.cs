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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CurrentRole"] != null)
            {
                if (!IsPostBack)
                {

                }
            }
            else
            {
                Session.RemoveAll();
                Response.Redirect("Login.aspx");
            }
        }

        protected void RemoveCMD_Click(object sender, EventArgs e)
        {

        }

        protected void AddCMD_Click(object sender, EventArgs e)
        {

        }
 

        protected void SearchCMD_Click(object sender, EventArgs e)
        {

        }

        protected void AddUserCMD_Click(object sender, EventArgs e)
        {

        }
    }
}