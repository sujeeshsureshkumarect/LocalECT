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
    public partial class Security_Roles : System.Web.UI.Page
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
                if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_RolesManager,
                InitializeModule.enumPrivilege.ShowBrowse, CurrentRole) != true)
                {
                    Server.Transfer("Authorization.aspx");

                }
            }

            lbl_Msg.Text = "";
            if (!IsPostBack)
            {
                fill_Terms();
                Fill_SystemsCBO();
                bindroles();
            }
        }
        private void fill_Terms()
        {
            List<Semesters> myTerms = new List<Semesters>();
            SemesterDAL myTermsDAL = new SemesterDAL();
            try
            {

                myTerms = myTermsDAL.GetTerms(InitializeModule.EnumCampus.ECTNew, "", true);

                for (int i = 0; i < myTerms.Count; i++)
                {
                    TermsCBO.Items.Add(new ListItem(myTerms[i].ShortDesc.ToString(), myTerms[i].Term.ToString()));
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
                myTerms.Clear();

            }
        }
        protected void EditBTN_Command(object sender, CommandEventArgs e)
        {
            int r = 0;
            r = Get_Role(int.Parse(e.CommandArgument.ToString()));

        }

        private int Get_Role(int RoleID)
        {
            int r = 0;
            List<_Role> myRoles = new List<_Role>();
            RoleDAL myRolesDAL = new RoleDAL();

            int iTerm = 0;


            try
            {
                myRoles = myRolesDAL.GetRole(InitializeModule.EnumCampus.ECTNew, " Where RoleID=" + RoleID, false);
                for (int i = 0; i < myRoles.Count; i++)
                {
                    RoleIDLBL.Text = RoleID.ToString();
                    NameTXT.Text = myRoles[i].RoleNameEn.ToString();
                    iTerm = LibraryMOD.GetTerm(myRoles[i].MarksYear, myRoles[i].MarksSemester);
                    TermsCBO.SelectedValue = iTerm.ToString();
                    SystemsCBO.SelectedValue = myRoles[i].SystemID.ToString();
                    DataStatus.Value = ((int)InitializeModule.enumModes.EditMode).ToString();
                    //isDataChanged.Value = myRoles[i].isDataChanged.ToString(); 
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


            }
            return r;
        }
        private void Fill_SystemsCBO()
        {
            List<LookupDetails> mySystems = new List<LookupDetails>();
            LookupDetailsDAL myLookupDetailsDAL = new LookupDetailsDAL();

            try
            {
                mySystems = myLookupDetailsDAL.GetLookupDetails(InitializeModule.EnumCampus.ECTNew, "", true, "Select System ...", InitializeModule.enumLookupType.ECTSystems);

                for (int i = 0; i < mySystems.Count; i++)
                {
                    ListItem lst = new ListItem(mySystems[i].DescEn, mySystems[i].MinorID.ToString());
                    SystemsCBO.Items.Add(lst);
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
                mySystems.Clear();

            }
        }
        protected void NewCMD_Click(object sender, EventArgs e)
        {
            RoleDAL myRolesDAL = new RoleDAL();
            Connection_StringCLS myConnection_String = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            Conn.Open();
            try
            {
                DataStatus.Value = ((int)InitializeModule.enumModes.NewMode).ToString();

                RoleIDLBL.Text = (LibraryMOD.GetMaxID(Conn, "RoleID", "Cmn_Role") + 1).ToString();
                NameTXT.Text = "";
                isDataChanged.Value = true.ToString();
                TermsCBO.SelectedValue = LibraryMOD.GetCurrentTerm().ToString();
                SystemsCBO.SelectedValue = "0";

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
            }
        }
        public void bindroles()
        {
            string constr = ConfigurationManager.ConnectionStrings["ECTDataNew"].ConnectionString;
            SqlConnection sc = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand("SELECT Cmn_Role.RoleID AS [RoleID], Cmn_Role.RoleNameEn AS [RoleName], Cmn_LookupDetails.DescEn AS System FROM Cmn_Role INNER JOIN Cmn_LookupDetails ON Cmn_Role.SystemID = Cmn_LookupDetails.MinorID WHERE (Cmn_LookupDetails.MajorID = 200) ORDER BY Cmn_Role.RoleNameEn, Cmn_LookupDetails.DescEn", sc);
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
            catch (Exception ex)
            {
                sc.Close();
                throw ex;
            }
            finally
            {
                sc.Close();
            }
        }
        protected void SaveCMD_Click(object sender, EventArgs e)
        {
            SaveData();
            bindroles();
        }
        private void SaveData()
        {
            RoleDAL myRolesDAL = new RoleDAL();

            try
            {
                int localRoleID = 0;
                if (string.IsNullOrEmpty(RoleIDLBL.Text))
                {
                    lbl_Msg.Text = "Edit Role or add new one!";
                    div_msg.Visible = true;
                    return;
                }
                else
                {
                    localRoleID = int.Parse(RoleIDLBL.Text);

                }
                int localYear = 0;
                int localSemester = 0;
                int localTerm = int.Parse(TermsCBO.SelectedValue);
                int iSystem = int.Parse(SystemsCBO.SelectedValue);
                int idataStatus = int.Parse(DataStatus.Value);


                localYear = LibraryMOD.SeperateTerm(localTerm, out localSemester);

                int r = myRolesDAL.UpdateRole(InitializeModule.EnumCampus.ECTNew, idataStatus, localRoleID, "", NameTXT.Text, localYear
                    , localSemester, iSystem, "", 0, DateTime.Today.Date, 0, DateTime.Today.Date, "", sUserName);

                if (r > 0)
                {                    
                    lbl_Msg.Text = "Data Updated Successfully";
                    div_msg.Visible = true;
                    div_Alert.Attributes.Add("class", "alert alert-success alert-dismissible");
                }

                DataStatus.Value = ((int)InitializeModule.enumModes.EditMode).ToString();
                //RolesGRD.DataBind(); to be opened
            }

            catch (Exception exp)
            {
                Console.WriteLine("{0} Exception caught.", exp);                
                lbl_Msg.Text = exp.Message;
                div_msg.Visible = true;
            }
            finally
            {


            }

        }
    }
}