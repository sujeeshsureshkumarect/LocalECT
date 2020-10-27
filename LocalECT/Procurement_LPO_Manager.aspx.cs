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
    public partial class Procurement_LPO_Manager : System.Web.UI.Page
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
                bindlpo();
            }
        }
        protected void PrintBTN_Command(object sender, CommandEventArgs e)
        {
            int r = 0;
            r = int.Parse(e.CommandArgument.ToString());
        }
        public void bindlpo()
        {
            string constr = ConfigurationManager.ConnectionStrings["ECTDataNew"].ConnectionString;
            SqlConnection sc = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand("SELECT dbo.PRC_LPO_Header.iLPO, dbo.PRC_LPO_Header.sRef, dbo.PRC_LPO_Header.sBRF, dbo.PRC_LPO_Header.sRequester, dbo.PRC_LPO_Header.sInvoice, dbo.PRC_LPO_Header.sPayment, dbo.PRC_LPO_Header.sOtherTerm, dbo.PRC_LPO_Header.iStatus, dbo.PRC_LPO_Header.sPreparedBy, dbo.PRC_LPO_Header.sPreparedByJobDesc, dbo.PRC_LPO_Header.sApprovedBy, dbo.PRC_LPO_Header.sApprovedByJobDesc, dbo.PRC_LPO_Header.dDate, dbo.PRC_Supplier.sSupplierName as Company FROM dbo.PRC_LPO_Header INNER JOIN dbo.PRC_Supplier ON dbo.PRC_LPO_Header.iRequestFrom = dbo.PRC_Supplier.iSupplier order by dbo.PRC_LPO_Header.dDate asc", sc);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                RepterDetails.DataSource = dt;
                RepterDetails.DataBind();
            }
            catch (Exception exp)
            {
                sc.Close();
                throw exp;
            }
            finally
            {
                sc.Close();
            }
        }
    }
}