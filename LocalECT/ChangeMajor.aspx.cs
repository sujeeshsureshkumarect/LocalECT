using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LocalECT
{
    public partial class ChangeMajor : System.Web.UI.Page
    {
        int CurrentRole = 0;
        InitializeModule.EnumCampus Campus = InitializeModule.EnumCampus.Males;

        int iRegYear = 2019;
        int iRegSem = 2;
        int iRegTerm;
        string sConn = "";
        string sCCollege = "";
        string sCDegree = "";
        string sCMajor = "";
        string sUser = "";
        string sNCollege, sNDegree, sNMajor;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    iRegTerm = LibraryMOD.GetRegTerm();
                    iRegYear = LibraryMOD.SeperateTerm(iRegTerm, out iRegSem);
                    Session["RegYear"] = iRegYear;
                    Session["RegSemester"] = iRegSem;
                }
                else
                {
                    if (Session["RegYear"] != null)
                    {
                        iRegYear = Convert.ToInt32(Session["RegYear"].ToString());
                        iRegSem = Convert.ToInt32(Session["RegSemester"].ToString());
                    }
                }

                if (Session["CurrentRole"] != null)
                {

                    CurrentRole = (int)Session["CurrentRole"];
                    Campus = (InitializeModule.EnumCampus)Session["CurrentCampus"];
                    sUser = Session["CurrentUserName"].ToString();
                    if (!IsPostBack)
                    {
                        if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Student_Data,
                        InitializeModule.enumPrivilege.ChangeMajor, CurrentRole) != true)
                        {
                            Server.Transfer("Authorization.aspx");
                        }
                    }
                }
                else
                {
                    Session.RemoveAll();
                    Response.Redirect("Login.aspx");
                }                
                lbl_Msg.Text = "";

                Connection_StringCLS ConnectionString;

                switch (Campus)
                {
                    case InitializeModule.EnumCampus.Males:
                        ConnectionString = new Connection_StringCLS(InitializeModule.EnumCampus.Males);
                        sConn = ConnectionString.Conn_string;
                        break;
                    case InitializeModule.EnumCampus.Females:
                        ConnectionString = new Connection_StringCLS(InitializeModule.EnumCampus.Females);
                        sConn = ConnectionString.Conn_string;
                        break;
                }

                CopyDS.ConnectionString = sConn;

                if (!IsPostBack)
                {
                    if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Student_Data,
                        InitializeModule.enumPrivilege.ChangeMajor, CurrentRole) != true)
                    {
                        //chkMajorOnly.Enabled = false;
                    }
                    if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Student_Data,
                        InitializeModule.enumPrivilege.CopyStudent, CurrentRole) != true)
                    {
                        //RunCMD.Enabled = false;
                    }
                    if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Student_Data,
                        InitializeModule.enumPrivilege.ImportGrades, CurrentRole) != true)
                    {
                        //cmdImport.Enabled = false;
                    }
                    if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Student_Data,
                        InitializeModule.enumPrivilege.ChangeID, CurrentRole) != true)
                    {
                        //chkNoOnly.Enabled = false;
                    }

                    if (Request.QueryString["sid"] != null && Request.QueryString["sid"] != "")
                    {
                        Campus = (InitializeModule.EnumCampus)Session["CurrentCampus"];
                        string sid = Request.QueryString["sid"];
                        hdnSerial.Value = GetSerial(sid).ToString();
                        lblStudentNo.Text = sid;
                        bindstudentdata(sid);

                        FillDDLs();

                        ddlTerm.SelectedValue = (iRegYear * 10 + iRegSem).ToString();
                    }

                }
            }
            catch (Exception ex)
            {
                LibraryMOD.ShowErrorMessage(ex);
                lbl_Msg.Text = ex.Message;
                div_msg.Visible = true;
            }
            finally
            {

            }
        }
        private int GetSerial(string sNumber)
        {
            int iserial = 0;
            try
            {
                ApplicationsDAL myapp = new ApplicationsDAL();
                iserial = myapp.GetSerial(Campus, sNumber);


            }
            catch (Exception ex)
            {
            }
            return iserial;
        }
        public void bindstudentdata(string sid)
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection sc = new SqlConnection(myConnection_String.Conn_string);
            SqlCommand cmd = new SqlCommand("select [strAccountNo],[strStudentName],[lngStudentNumber],iAdmissionPaymentType,cAdmissionPaymentValue from [Reg_Student_Accounts] where [lngStudentNumber]=@lngStudentNumber", sc);
            cmd.Parameters.AddWithValue("@lngStudentNumber", sid);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                if (dt.Rows.Count > 0)
                {
                    lblName.Text = dt.Rows[0]["strStudentName"].ToString();
                }
            }
            catch (Exception ex)
            {
                sc.Close();
                lbl_Msg.Text = ex.Message;
                div_msg.Visible = true;
            }
            finally
            {
                sc.Close();
            }
        }
        private void FillDDLs()
        {
            try
            {
                string sKey = "";
                lblOldMajor.Text = GetCurrentMajor(lblStudentNo.Text, out sKey, out sCCollege, out sCDegree, out sCMajor);
                FillTerms();
                FillMajors(sKey);
            }
            catch (Exception ex)
            {
                LibraryMOD.ShowErrorMessage(ex);
                lbl_Msg.Text = ex.Message;
                div_msg.Visible = true;
            }
            finally
            {

            }
        }
        private void FillTerms()
        {
            List<Semesters> myTerms = new List<Semesters>();
            SemesterDAL myTermsDAL = new SemesterDAL();
            try
            {
                myTerms = myTermsDAL.GetTerms(InitializeModule.EnumCampus.ECTNew, "", false);
                for (int i = 0; i < myTerms.Count; i++)
                {
                    ddlTerm.Items.Add(new ListItem(myTerms[i].ShortDesc, myTerms[i].Term.ToString()));
                }
            }
            catch (Exception ex)
            {
                LibraryMOD.ShowErrorMessage(ex);
                lbl_Msg.Text = ex.Message;
                div_msg.Visible = true;
            }
            finally
            {
                myTerms.Clear();
            }
        }

        private void FillMajors(string sCurrentMajor)
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            Conn.Open();
            try
            {
                string sAltMajor = "";


                string sSQL = "SELECT strKey, strMajor FROM Reg_Specializations";
                //sSQL += " WHERE strKey<>'" + sCurrentMajor + "' AND bAvailable=1";
                sSQL += " WHERE bAvailable=1";
                sSQL += " ORDER BY intSerial";
                SqlCommand Cmd = new SqlCommand(sSQL, Conn);
                SqlDataReader Rd = Cmd.ExecuteReader();

                ddlMajor.Items.Clear();

                while (Rd.Read())
                {
                    ddlMajor.Items.Add(new ListItem(Rd["strMajor"].ToString(), Rd["strKey"].ToString()));

                }
                Rd.Close();


                string sDegree = sCurrentMajor.Substring(2, 2);

                //Get the Parent Major
                if (sDegree != "03")//not Bachelor
                {
                    sSQL = "SELECT strAltMajor FROM Reg_Specializations";
                    sSQL += " WHERE strKey='" + sCurrentMajor + "'";
                    Cmd.CommandText = sSQL;
                    Rd = Cmd.ExecuteReader();

                    while (Rd.Read())
                    {

                        sAltMajor = Rd["strAltMajor"].ToString();

                    }
                    Rd.Close();
                    if (sAltMajor.Length != 2)
                    {
                        sAltMajor = '0' + sAltMajor;
                    }
                    sAltMajor = sCurrentMajor.Substring(0, 4) + sAltMajor;

                    //Add the inactive parent major to the list
                    sSQL = "SELECT strKey, strMajor FROM Reg_Specializations";
                    sSQL += " WHERE strKey='" + sAltMajor + "' AND (bAvailable = 0) and strKey<>'" + sCurrentMajor + "'";
                    Cmd.CommandText = sSQL;
                    Rd = Cmd.ExecuteReader();

                    while (Rd.Read())
                    {

                        ddlMajor.Items.Add(new ListItem(Rd["strMajor"].ToString(), Rd["strKey"].ToString()));

                    }
                    Rd.Close();
                }
                else
                {

                    //Add the inactive bachelor parents major to the list
                    sSQL = "SELECT strKey, strMajor FROM Reg_Specializations";
                    sSQL += " WHERE strDegree='3' AND (bAvailable = 0) and strKey<>'" + sCurrentMajor + "'";
                    Cmd.CommandText = sSQL;
                    Rd = Cmd.ExecuteReader();

                    while (Rd.Read())
                    {
                        ddlMajor.Items.Add(new ListItem(Rd["strMajor"].ToString(), Rd["strKey"].ToString()));
                    }
                    Rd.Close();
                }

            }
            catch (Exception ex)
            {
                LibraryMOD.ShowErrorMessage(ex);
                lbl_Msg.Text = ex.Message;
                div_msg.Visible = true;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }
        }

        private string GetCurrentMajor(string sID, out string sKey, out string sCollege, out string sDegree, out string sMajor)
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            Conn.Open();
            string sCurrentMajor = "";
            sKey = "";
            sCollege = "";
            sDegree = "";
            sMajor = "";
            try
            {
                string sSQL = "SELECT S.strKey, S.strMajor, S.strCollege, S.strDegree, S.strSpecialization";
                sSQL += " FROM  Reg_Specializations AS S INNER JOIN Reg_Applications AS A ON S.strCollege = A.strCollege AND S.strDegree = A.strDegree AND S.strSpecialization = A.strSpecialization";
                sSQL += " WHERE A.lngStudentNumber = '" + sID + "'";

                SqlCommand Cmd = new SqlCommand(sSQL, Conn);
                SqlDataReader Rd = Cmd.ExecuteReader();

                while (Rd.Read())
                {
                    sCurrentMajor = Rd["strMajor"].ToString();
                    sKey = Rd["strKey"].ToString();
                    hdnKey.Value = sKey;
                    sCollege = Rd["strCollege"].ToString();
                    sDegree = Rd["strDegree"].ToString();
                    sMajor = Rd["strSpecialization"].ToString();
                }
                Rd.Close();

            }
            catch (Exception ex)
            {
                LibraryMOD.ShowErrorMessage(ex);
                lbl_Msg.Text = ex.Message;
                div_msg.Visible = true;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }
            return sCurrentMajor;
        }

        protected void RunCMD_Click(object sender, EventArgs e)
        {

        }

        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentSearch");
        }

        protected void SidDS_Selected(object sender, SqlDataSourceStatusEventArgs e)
        {
            DbCommand command = e.Command;
            //lnkNewId.Text = command.Parameters["@RETURN_VALUE"].Value.ToString();
        }
        protected void CopyDS_Inserted(object sender, SqlDataSourceStatusEventArgs e)
        {
            try
            {
                DbCommand command = e.Command;
                hdnNewSerial.Value = command.Parameters["@RETURN_VALUE"].Value.ToString();
                Session["StudentSerialNo"] = int.Parse(hdnNewSerial.Value);
            }
            catch (Exception ex)
            {
                LibraryMOD.ShowErrorMessage(ex);
                lbl_Msg.Text = ex.Message;
                div_msg.Visible = true;
            }
            finally
            {

            }
        }
    }
}