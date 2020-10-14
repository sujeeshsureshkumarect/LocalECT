using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LocalECT
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CurrentRole"] != null)
            {
                if (!IsPostBack)
                {
                    // bindnewsfeed();
                }
            }
            else
            {
                Session.RemoveAll();
                Response.Redirect("Login.aspx");
            }
        }

        //public void bindnewsfeed()
        //{
        //    Connection_StringCLS myConnection_String = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew);
        //    SqlConnection sc = new SqlConnection(myConnection_String.Conn_string);
        //    SqlCommand cmd = new SqlCommand("select TOP (5) * from ECT_SIS_News_Feed where isActive=1 order by dDate desc", sc);
        //    DataTable dt = new DataTable();
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    try
        //    {
        //        sc.Open();
        //        da.Fill(dt);
        //        sc.Close();

        //        RepeaterNews.DataSource = dt;
        //        RepeaterNews.DataBind();
        //    }
        //    catch (Exception ex)
        //    {
        //        sc.Close();
        //        Console.WriteLine("{0} Exception caught.", ex);
        //    }
        //    finally
        //    {
        //        sc.Close();
        //    }
        //}
    }
}