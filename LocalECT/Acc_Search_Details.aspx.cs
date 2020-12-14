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
    public partial class Acc_Search_Details : System.Web.UI.Page
    {
        InitializeModule.EnumCampus Campus = InitializeModule.EnumCampus.Females;
        string constr = ConfigurationManager.ConnectionStrings["ECTDataFemales"].ConnectionString;
        int CurrentRole = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            CurrentRole = (int)Session["CurrentRole"];
            if (Session["CurrentCampus"].ToString() == "Males")
            {
                Campus = InitializeModule.EnumCampus.Males;
            }
            else
            {
                Campus = InitializeModule.EnumCampus.Females;
            }
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
    }
}