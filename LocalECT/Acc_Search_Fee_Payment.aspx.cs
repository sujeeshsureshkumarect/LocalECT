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
    public partial class Acc_Search_Fee_Payment : System.Web.UI.Page
    {
        InitializeModule.EnumCampus Campus = InitializeModule.EnumCampus.Females;
        string constr = ConfigurationManager.ConnectionStrings["ECTDataFemales"].ConnectionString;
        int CurrentRole = 0;
        int iCYear = 0;
        int iCSem = 0;
        int iTerm = 0;
        string sOAcc = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CurrentRole"] != null)
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
                if (!IsPostBack)
                {
                    if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_ACC_Search,
                        InitializeModule.enumPrivilege.ShowBrowse, CurrentRole) != true)
                    {
                        Server.Transfer("Authorization.aspx");
                    }
                    //if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_ACC_Search,
                    //InitializeModule.enumPrivilege.ACCAddStPayment, CurrentRole) != true)
                    //{
                    //    Server.Transfer("Authorization.aspx");
                    //}
                    FillTerms();
                    iCYear = Convert.ToInt32(Session["CurrentYear"].ToString());
                    iCSem = Convert.ToInt32(Session["CurrentSemester"].ToString()); ;
                    iTerm = iCYear * 10 + iCSem;
                    ddlRegTerm.SelectedValue = iCYear.ToString() + iCSem.ToString();
                    if (Request.QueryString["sAcc"] != null && Request.QueryString["sAcc"] != "")
                    {
                        string sAcc = Request.QueryString["sAcc"];
                        bindstudentdata(sAcc);
                    }
                    txtDatePayment.Text = string.Format("{0:yyyy-MM-dd}", DateTime.Today.Date);
                }
                else
                {
                    iTerm = Convert.ToInt32(ddlRegTerm.SelectedValue);
                    iCYear = LibraryMOD.SeperateTerm(iTerm, out iCSem);
                }
            }
            else
            {
                Session.RemoveAll();
                Response.Redirect("Login.aspx");
            }
        }
        private void FillTerms()
        {
            List<Semesters> myTerms = new List<Semesters>();
            SemesterDAL myTermsDAL = new SemesterDAL();
            try
            {
                myTerms = myTermsDAL.GetTerms(InitializeModule.EnumCampus.ECTNew, "", true);
                for (int i = 0; i < myTerms.Count; i++)
                {
                    //Terms.Items.Add(new ListItem(myTerms[i].ShortDesc, myTerms[i].Term.ToString()));
                    ddlRegTerm.Items.Add(new ListItem(myTerms[i].ShortDesc, myTerms[i].Term.ToString()));
                    //ddlRegTerm1.Items.Add(new ListItem(myTerms[i].ShortDesc, myTerms[i].Term.ToString()));
                    //TestimonyTerm.Items.Add(new ListItem(myTerms[i].ShortDesc, myTerms[i].Term.ToString()));
                }

            }
            catch (Exception ex)
            {
                LibraryMOD.ShowErrorMessage(ex);
                //divMsg.InnerText = ex.Message;
            }
            finally
            {
                myTerms.Clear();
            }
        }
        protected void lnk_update_Click(object sender, EventArgs e)
        {

        }

        protected void lnk_Cancel_Click(object sender, EventArgs e)
        {

        }

        protected void ddlPaymentWay_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddlPaymentWay.SelectedItem.Value=="3")
            {
                cheque.Visible = true;
            }
            else
            {
                cheque.Visible = false;
            }
        }
        public void bindstudentdata(string sAcc)
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection sc = new SqlConnection(myConnection_String.Conn_string);
            SqlCommand cmd = new SqlCommand("select [strAccountNo],[strStudentName],[lngStudentNumber] from [Reg_Student_Accounts] where [strAccountNo]=@strAccountNo", sc);
            cmd.Parameters.AddWithValue("@strAccountNo", sAcc);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                if(dt.Rows.Count>0)
                {
                    lblACC.Text = dt.Rows[0]["strAccountNo"].ToString();
                    txtName.Text = dt.Rows[0]["strStudentName"].ToString();
                    ddlIDs.Text = dt.Rows[0]["lngStudentNumber"].ToString();
                }
            }
            catch(Exception ex)
            {
                sc.Close();
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sc.Close();
            }
        }
    }
}