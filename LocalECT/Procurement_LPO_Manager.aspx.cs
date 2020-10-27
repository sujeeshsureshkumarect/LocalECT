using CrystalDecisions.CrystalReports.Engine;
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
            ReportDocument myReport = new ReportDocument();
            string reportPath = "";
            reportPath = Server.MapPath("Reports/CrystalReport1.rpt");
            int r = 0;
            r = int.Parse(e.CommandArgument.ToString());

            string constr = ConfigurationManager.ConnectionStrings["ECTDataNew"].ConnectionString;
            SqlConnection sc = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand("SELECT dbo.PRC_LPO_Detail.iSerial, dbo.PRC_LPO_Detail.sDescription, dbo.PRC_LPO_Detail.cQTY, dbo.PRC_LPO_Detail.cUnitPrice, dbo.PRC_LPO_Detail.sRemark, dbo.PRC_LPO_Header.iLPO as iLPO, dbo.PRC_LPO_Header.sRef, dbo.PRC_LPO_Header.sBRF, dbo.PRC_LPO_Header.sRequester, dbo.PRC_LPO_Header.iRequestFrom, dbo.PRC_LPO_Header.sInvoice, dbo.PRC_LPO_Header.sPayment, dbo.PRC_LPO_Header.sOtherTerm, dbo.PRC_LPO_Header.iStatus, dbo.PRC_LPO_Header.sPreparedBy, dbo.PRC_LPO_Header.sPreparedByJobDesc, dbo.PRC_LPO_Header.sApprovedBy, dbo.PRC_LPO_Header.sApprovedByJobDesc, dbo.PRC_LPO_Header.dDate, dbo.PRC_Supplier.sSupplierName, dbo.PRC_Supplier.sPhone, dbo.PRC_Supplier.sFax,dbo.PRC_Supplier.sPOBox FROM dbo.PRC_LPO_Header INNER JOIN dbo.PRC_LPO_Detail ON dbo.PRC_LPO_Header.iLPO = dbo.PRC_LPO_Detail.iLPO INNER JOIN dbo.PRC_Supplier ON dbo.PRC_LPO_Header.iRequestFrom = dbo.PRC_Supplier.iSupplier where dbo.PRC_LPO_Header.iLPO=@iLPO", sc);
            cmd.Parameters.AddWithValue("@iLPO", r);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                myReport.Load(reportPath);
                myReport.SetDataSource(dt);
                myReport.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Page.Response, true, "ECTReport");

            }
            catch (Exception exp)
            {
                sc.Close();
                Console.WriteLine("{0} Exception caught.", exp.Message);
            }
            finally
            {
                sc.Close();
            }
        }
        protected void PrintWOFooter_Command(object sender, CommandEventArgs e)
        {
            ReportDocument myReport = new ReportDocument();
            string reportPath = "";
            reportPath = Server.MapPath("Reports/CrystalReport1.rpt");
            int r = 0;
            r = int.Parse(e.CommandArgument.ToString());

            string constr = ConfigurationManager.ConnectionStrings["ECTDataNew"].ConnectionString;
            SqlConnection sc = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand("SELECT dbo.PRC_LPO_Detail.iSerial, dbo.PRC_LPO_Detail.sDescription, dbo.PRC_LPO_Detail.cQTY, dbo.PRC_LPO_Detail.cUnitPrice, dbo.PRC_LPO_Detail.sRemark, dbo.PRC_LPO_Header.iLPO as iLPO, dbo.PRC_LPO_Header.sRef, dbo.PRC_LPO_Header.sBRF, dbo.PRC_LPO_Header.sRequester, dbo.PRC_LPO_Header.iRequestFrom, dbo.PRC_LPO_Header.sInvoice, dbo.PRC_LPO_Header.sPayment, dbo.PRC_LPO_Header.sOtherTerm, dbo.PRC_LPO_Header.iStatus, dbo.PRC_LPO_Header.sPreparedBy, dbo.PRC_LPO_Header.sPreparedByJobDesc, dbo.PRC_LPO_Header.sApprovedBy, dbo.PRC_LPO_Header.sApprovedByJobDesc, dbo.PRC_LPO_Header.dDate, dbo.PRC_Supplier.sSupplierName, dbo.PRC_Supplier.sPhone, dbo.PRC_Supplier.sFax,dbo.PRC_Supplier.sPOBox FROM dbo.PRC_LPO_Header INNER JOIN dbo.PRC_LPO_Detail ON dbo.PRC_LPO_Header.iLPO = dbo.PRC_LPO_Detail.iLPO INNER JOIN dbo.PRC_Supplier ON dbo.PRC_LPO_Header.iRequestFrom = dbo.PRC_Supplier.iSupplier where dbo.PRC_LPO_Header.iLPO=@iLPO", sc);
            cmd.Parameters.AddWithValue("@iLPO", r);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                myReport.Load(reportPath);
                myReport.SetDataSource(dt);

                PictureObject pic1;
                pic1 = (PictureObject)myReport.ReportDefinition.ReportObjects["picLogo"];
                pic1.ObjectFormat.EnableSuppress = true;

                pic1 = (PictureObject)myReport.ReportDefinition.ReportObjects["picfooter"];
                pic1.ObjectFormat.EnableSuppress = true;

                myReport.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Page.Response, true, "ECTReport");

            }
            catch (Exception exp)
            {
                sc.Close();
                Console.WriteLine("{0} Exception caught.", exp.Message);
            }
            finally
            {
                sc.Close();
            }
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