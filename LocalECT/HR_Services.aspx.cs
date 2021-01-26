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
    public partial class HR_Services : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CurrentRole"] != null)
            {
                if (!IsPostBack)
                {
                    gethrservices();
                }
            }
            else
            {
                Session.RemoveAll();
                Response.Redirect("Login.aspx");
            }
        }

        public void gethrservices()
        {
            var services = new DAL.DAL();
            DataTable dtStudentServices = services.gethrservices();
            RepterDetails.DataSource = dtStudentServices;
            RepterDetails.DataBind();
        }

    }
}