using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
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
                    if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_ACC_Search,
                    InitializeModule.enumPrivilege.ACCAddStPayment, CurrentRole) != true)
                    {
                        Server.Transfer("Authorization.aspx");
                    }
                    FillTerms();
                    iCYear = Convert.ToInt32(Session["CurrentYear"].ToString());
                    iCSem = Convert.ToInt32(Session["CurrentSemester"].ToString()); ;
                    iTerm = iCYear * 10 + iCSem;
                    ddlRegTerm.SelectedValue = iCYear.ToString() + iCSem.ToString();
                    if (Request.QueryString["sAcc"] != null && Request.QueryString["sAcc"] != "")
                    {
                        string sAcc = Request.QueryString["sAcc"];
                        bindstudentdata(sAcc);
                        generatevoucher_entry();
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
                lbl_Msg.Text = ex.Message;
                div_msg.Visible = true;
            }
            finally
            {
                myTerms.Clear();
            }
        }
        protected void lnk_update_Click(object sender, EventArgs e)
        {
            if(ddlPaymentWay.SelectedItem.Value=="3")//Cheque
            {
                if(string.IsNullOrEmpty(txtCheque.Text))
                {
                    lbl_Msg.Text = "Enter Cheque Number";
                    div_msg.Visible = true;
                    return;
                }
                if (string.IsNullOrEmpty(txtDueDate.Text))
                {
                    lbl_Msg.Text = "Enter Due Date";
                    div_msg.Visible = true;
                    return;
                }
                else
                {
                    DateTime due = Convert.ToDateTime(txtDueDate.Text.Trim());
                    if(DateTime.Now>due)
                    {
                        lbl_Msg.Text = "Due Date must be higher than current date";
                        div_msg.Visible = true;
                        return;
                    }
                    else
                    {
                        updatefeespayment();
                    }
                }
            }
            else
            {
                updatefeespayment();
            }
        }

        public void updatefeespayment()
        {
            if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_ACC_Search,
                   InitializeModule.enumPrivilege.ACCManageStPayment, CurrentRole) != true)
            {
                //lbl_Msg.Text = "Sorry you cannot update payment.";
                //div_msg.Visible = true;
                //return;
            }
            string sVoucher = AddVoucher();
            int iEntry = GetNewEntry(sVoucher);
            string sMsg = "Payment not saved !";
            bool isUpdated = false;
            if (hdnPaymentStatus.Value == "1")//New Payment
            {
                isUpdated = UpdatePayment(true);
                if (isUpdated)
                {
                    sMsg = "Payment added.";
                    //Check for First Payment and CX Update and Change Student to 105 Role based on Payment Value.
                    checkfirstpayment(lblACC.Text);//checking that its first payment done by student or not
                    lbl_Msg.Text = "Payment Created Succesfully";
                    div_Alert.Attributes.Add("class", "alert alert-success alert-dismissible");
                    div_msg.Visible = true;
                    lnk_update.Enabled = false;
                }
            }

        }
        public void checkfirstpayment(string sAcc)
        {
            //checking that its first payment done by student or not
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection sc = new SqlConnection(myConnection_String.Conn_string);
            SqlCommand cmd = new SqlCommand("SELECT count(strAccountNo) as Count FROM [ECTData].[dbo].[Acc_Voucher_Detail] where strAccountNo=@strAccountNo", sc);
            cmd.Parameters.AddWithValue("@strAccountNo", sAcc);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                if (dt.Rows.Count > 0)
                {
                    int count = Convert.ToInt32(dt.Rows[0]["Count"]);
                    if (count == 1)//First Payment
                    {
                        int opportunityid = 0;
                        string sSID = ddlIDs.Text;
                        int iSerial = GetSerial(sSID);
                        Session["StudentSerialNo"] = iSerial;
                        SqlCommand cmd1 = new SqlCommand("select iOpportunityID from Reg_Applications where lngSerial=@lngSerial", sc);
                        cmd1.Parameters.AddWithValue("@lngSerial", iSerial);
                        DataTable dt1 = new DataTable();
                        SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                        try
                        {
                            sc.Open();
                            da1.Fill(dt1);
                            sc.Close();

                            if (dt1.Rows.Count > 0)
                            {
                                opportunityid = Convert.ToInt32(dt1.Rows[0]["iOpportunityID"]);
                            }
                        }
                        catch (Exception ex)
                        {
                            sc.Close();
                            Console.WriteLine(ex.Message);
                        }
                        finally
                        {
                            sc.Close();
                        }
                        //Check Payment >= Payment Value
                        if(Convert.ToDouble(txtPayment.Text)>=Convert.ToDouble(hdncAdmissionPaymentValue.Value))
                        {
                            //Call API Function Update Opportunity
                            lnkOpportunity_Command(opportunityid);
                            updateuserole();
                        }
                    }
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
        public void updateuserole()
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);           
            try
            {
                string sSQL = "";
                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                int iStatus = 2;
           
                Cmd.CommandText = "Create_Online_User";
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.Add("@sNo", SqlDbType.VarChar).Value = ddlIDs.Text;
                Cmd.Parameters.Add("@sAccount", SqlDbType.VarChar).Value = lblACC.Text;
                Cmd.Parameters.Add("@iRole", SqlDbType.Int).Value = 105;
                Conn.Open();
                Cmd.ExecuteNonQuery();
                Conn.Close();


                sSQL = "UPDATE Reg_Student_Accounts";
                sSQL += " SET intOnlineStatus =" + iStatus;
                sSQL += ",strUserSave='" + Session["CurrentUserName"].ToString() + "',dateLastSave=getDate()";
                sSQL += " Where strAccountNo='" + lblACC.Text + "'";
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = sSQL;
                Conn.Open();
                Cmd.ExecuteNonQuery();
                Conn.Close();
            }
            catch (Exception exp)
            {
                //Console.WriteLine("{0} Exception caught.", exp);                
                lbl_Msg.Text = "Online Status not updated";
                div_msg.Visible = true;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
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
                lbl_Msg.Text = ex.Message;
                div_msg.Visible = true;
            }
            return iserial;
        }
        public void lnkOpportunity_Command(int opportunityid)
        {
            string sSID = ddlIDs.Text;
            int iOpportunity = 0;
            if (isOpportunitySet(sSID, out iOpportunity))
            {

            }
            else
            {
                if (iOpportunity > 0 && iOpportunity.ToString() == opportunityid.ToString())
                {
                    //this.ClientScript.RegisterStartupScript(this.GetType(), "test", "setOpportunity();", true);
                    ServicePointManager.Expect100Continue = true;
                    ServicePointManager.DefaultConnectionLimit = 9999;
                    ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
                    string accessToken = InitializeModule.CxPwd;

                    using (var httpClient = new HttpClient())
                    {
                        using (var request = new HttpRequestMessage(new HttpMethod("GET"), "https://ect.custhelp.com/services/rest/connect/v1.4/opportunities/" + opportunityid + ""))
                        {
                            request.Headers.TryAddWithoutValidation("Authorization", accessToken);
                            request.Headers.TryAddWithoutValidation("OSvC-CREST-Application-Context", "application/x-www-form-urlencoded");

                            request.Content = new StringContent("{\n\t\"customFields\": {\n\t\t\"c\": {\n\t\t\t\"paymentstatus\": {\n                \"id\": 1094,\n                \"lookupName\": \"Payment Succeeded\"\n            }\n\t\t}\n\t},\n\t\"statusWithType\": {\n        \"status\": {\n            \"id\": 11\n        }\n    }\n}");
                            request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                            var task = httpClient.SendAsync(request);
                            task.Wait();
                            var response = task.Result;
                            string s = response.Content.ReadAsStringAsync().Result;
                            //If Status 200
                            if (response.IsSuccessStatusCode == true)
                            {
                                SetOpportunity(sSID);
                            }
                        }
                    }
                }
                else
                {                    
                    lbl_Msg.Text = "Opportunity ID must be saved first.";
                    div_msg.Visible = true;
                    //div_msg.Visible = true;
                }
            }
        }
        private bool isOpportunitySet(string sSID, out int iOpportunity)
        {
            bool isSet = false;
            iOpportunity = 0;
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            Conn.Open();
            try
            {

                string sSQL = "SELECT iOpportunityID, isOpportunitySet";
                sSQL += " FROM Reg_Applications";
                sSQL += " WHERE (lngStudentNumber = '" + sSID + "')";

                SqlCommand Cmd = new SqlCommand(sSQL, Conn);
                SqlDataReader Rd = Cmd.ExecuteReader();

                while (Rd.Read())
                {
                    iOpportunity = Convert.ToInt32(Rd["iOpportunityID"].ToString());
                    isSet = Convert.ToBoolean(Rd["isOpportunitySet"].ToString());
                }
                Rd.Close();

            }
            catch (Exception ex)
            {
                LibraryMOD.ShowErrorMessage(ex);
                lbl_Msg.Text = ex.Message;
                div_msg.Visible = true;
                //div_msg.Visible = true;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }
            return isSet;
        }
        public static bool SetOpportunity(string sSID)
        {
            bool isSet = false;
            //U cannot use var from out of the scope. (Campus)
            InitializeModule.EnumCampus campus = InitializeModule.EnumCampus.Males;
            if (sSID.Contains("AF") || sSID.Contains("ESF"))
            {
                campus = InitializeModule.EnumCampus.Females;
            }
            Connection_StringCLS myConnection_String = new Connection_StringCLS(campus);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            Conn.Open();
            try
            {

                string sSQL = "UPDATE Reg_Applications SET isOpportunitySet=1";
                sSQL += " WHERE (lngStudentNumber = '" + sSID + "')";

                SqlCommand Cmd = new SqlCommand(sSQL, Conn);
                isSet = (Cmd.ExecuteNonQuery() > 0);


            }
            catch (Exception ex)
            {
                LibraryMOD.ShowErrorMessage(ex);
                //divMsg.InnerText = ex.Message;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }
            return isSet;
        }
        private bool UpdatePayment(bool isAdd)
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            Conn.Open();
            bool isUpdated = false;
            try
            {


                switch (ddlStatus.SelectedValue)
                {
                    //case "0"://Entry
                        
                    //    lbl_Msg.Text = "Sorry you cannot set status :Entry.";
                    //    div_msg.Visible = true;
                    //    return false;

                    //    break;
                    case "1"://Paid
                        if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_ACC_Search,
                        InitializeModule.enumPrivilege.ACCChequePaid, CurrentRole) != true)
                        {                            
                            lbl_Msg.Text = "Sorry you cannot set status :Paid.";
                            div_msg.Visible = true;
                            return false;
                        }
                        break;
                    case "2"://Returned
                        if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_ACC_Search,
                        InitializeModule.enumPrivilege.ACCChequeReturned, CurrentRole) != true)
                        {                            
                            lbl_Msg.Text = "Sorry you cannot set status :Returned.";
                            div_msg.Visible = true;
                            return false;
                        }
                        break;
                    case "3"://Insurance
                        if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_ACC_Search,
                        InitializeModule.enumPrivilege.ACCChequeInsurance, CurrentRole) != true)
                        {                            
                            lbl_Msg.Text = "Sorry you cannot set status :Insurance.";
                            div_msg.Visible = true;
                            return false;
                        }
                        break;
                    case "4"://Canceled
                        if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_ACC_Search,
                        InitializeModule.enumPrivilege.ACCChequeCanceled, CurrentRole) != true)
                        {                            
                            lbl_Msg.Text = "Sorry you cannot set status :Canceled.";
                            div_msg.Visible = true;
                            return false;
                        }
                        break;

                }

                string sSQL = "";
                int iCheque = 0;

                DateTime datepayment;
                DateTime datedue;
                if (string.IsNullOrEmpty(txtDatePayment.Text.Trim()))
                {
                    datepayment = DateTime.Now;
                }
                else
                {
                    datepayment = Convert.ToDateTime(txtDatePayment.Text.Trim());
                }
                if (string.IsNullOrEmpty(txtDueDate.Text.Trim()))
                {
                    datedue = DateTime.Now;
                }
                else
                {
                    datedue = Convert.ToDateTime(txtDueDate.Text.Trim());
                }

                bool isFound = false;
                if (!isAdd)
                {
                    isFound = (hdnCheque.Value != "");

                }

                if (isAdd || !isFound)
                {
                    if (!string.IsNullOrEmpty(txtCheque.Text) && ddlPaymentWay.SelectedValue == "3")
                    {
                        iCheque = AddCheque();
                    }
                }
                else
                {
                    iCheque = Convert.ToInt32("0" + hdnCheque.Value);
                }

                int iCampaus = 1;
                if (Session["CurrentCampus"].ToString() == "Males")
                {
                    iCampaus = 1;
                }
                else
                {
                    iCampaus = 2;
                }



                if (isAdd)
                {
                    if (iCheque > 0)//Include Cheque
                    {
                        sSQL = "INSERT INTO Acc_Voucher_Detail";
                        sSQL += " (intFy,byteFSemester,strVoucherNo,lngEntryNo,strAccountNo,datePayment,curDebit,curCredit,bytePaymentWay,";
                        sSQL += " byteStatus,lngCheque,dateDue,intBank,byteCurrency,strRemark,strUserCreate,dateCreate,intCampus)";
                        sSQL += " VALUES(" + iCYear + "," + iCSem + ",'" + lblVoucher.Text + "'," + lblEntryNo.Text + ",'" + lblACC.Text + "'";
                        sSQL += ",'" + datepayment + "',0," + txtPayment.Text + "," + ddlPaymentWay.SelectedValue + "," + ddlStatus.SelectedValue;
                        sSQL += "," + iCheque + ",'" + datedue + "'," + ddlBank.SelectedValue + ",0,'" + txtPRemark.Text + "'";
                        sSQL += ",'" + Session["CurrentUserName"] + "',GetDate()," + iCampaus + ")";
                    }
                    else
                    {
                        sSQL = "INSERT INTO Acc_Voucher_Detail";
                        sSQL += " (intFy,byteFSemester,strVoucherNo,lngEntryNo,strAccountNo,datePayment,curDebit,curCredit,bytePaymentWay,";
                        sSQL += " byteStatus,byteCurrency,strRemark,strUserCreate,dateCreate,intCampus)";
                        sSQL += " VALUES(" + iCYear + "," + iCSem + ",'" + lblVoucher.Text + "'," + lblEntryNo.Text + ",'" + lblACC.Text + "'";
                        sSQL += ",'" + datepayment + "',0," + txtPayment.Text + "," + ddlPaymentWay.SelectedValue + "," + ddlStatus.SelectedValue;
                        sSQL += ",0,'" + txtPRemark.Text + "','" + Session["CurrentUserName"] + "',GetDate()," + iCampaus + ")";
                    }
                }
                else
                {


                    if (ddlPaymentWay.SelectedValue == "3")
                    {
                        if (isFound)
                        {
                            UpdateCheque(iCheque);
                        }

                        sSQL = "UPDATE Acc_Voucher_Detail SET";
                        sSQL += " curCredit=" + txtPayment.Text + ",bytePaymentWay=" + ddlPaymentWay.SelectedValue + ",byteStatus=" + ddlStatus.SelectedValue;
                        sSQL += ",lngCheque=" + iCheque + ",dateDue='" + datedue + "',intBank=" + ddlBank.SelectedValue;
                        sSQL += ",strRemark='" + txtPRemark.Text + "',strUserSave='" + Session["CurrentUserName"] + "',dateLastSave=GetDate()";
                        sSQL += " WHERE intFy=" + iCYear + " AND byteFSemester=" + iCSem + " AND strVoucherNo='" + lblVoucher.Text + "' AND lngEntryNo=" + lblEntryNo.Text;
                    }
                    else
                    {
                        sSQL = "UPDATE Acc_Voucher_Detail SET";
                        sSQL += " curCredit=" + txtPayment.Text + ",bytePaymentWay=" + ddlPaymentWay.SelectedValue + ",byteStatus=" + ddlStatus.SelectedValue;
                        //sSQL += ",lngCheque=" + iCheque + ",dateDue='" + txtDueDate.Text + "',intBank=" + ddlBank.SelectedValue;
                        sSQL += ",strRemark='" + txtPRemark.Text + "',strUserSave='" + Session["CurrentUserName"] + "',dateLastSave=GetDate()";
                        sSQL += " WHERE intFy=" + iCYear + " AND byteFSemester=" + iCSem + " AND strVoucherNo='" + lblVoucher.Text + "' AND lngEntryNo=" + lblEntryNo.Text;

                    }


                }

                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandText = sSQL;
                int iEffected = 0;
                iEffected = Cmd.ExecuteNonQuery();

                isUpdated = (iEffected > 0);

            }
            catch (Exception exp)
            {
                lbl_Msg.Text = exp.Message;
                div_msg.Visible = true;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }
            return isUpdated;
        }
        private bool UpdateCheque(int iCheque)
        {
            DateTime datepayment = Convert.ToDateTime(txtDatePayment.Text.Trim());
            DateTime datedue = Convert.ToDateTime(txtDueDate.Text.Trim());
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            Conn.Open();
            bool isUpdated = false;
            try
            {

                string sSQL = "UPDATE Acc_Cheques SET";
                sSQL += " strChequeNo='" + txtCheque.Text + "',dateCheque='" + datepayment + "',dateDue='" + datedue + "'";
                sSQL += ",intBank=" + ddlBank.SelectedValue + ",byteStatus=" + ddlStatus.SelectedValue + ",curValue=" + txtPayment.Text;
                sSQL += ",strUserSave='" + Session["CurrentUserName"] + "',dateLastSave=GetDate()";
                sSQL += " WHERE lngCheque=" + iCheque;

                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandText = sSQL;
                int iEffected = 0;
                iEffected = Cmd.ExecuteNonQuery();
                isUpdated = (iEffected > 0);
            }
            catch (Exception exp)
            {
                lbl_Msg.Text = exp.Message;
                div_msg.Visible = true;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }
            return isUpdated;
        }
        private int AddCheque()
        {
            DateTime datepayment = Convert.ToDateTime(txtDatePayment.Text.Trim());
            DateTime datedue = Convert.ToDateTime(txtDueDate.Text.Trim());
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            Conn.Open();
            int iCheque = 0;
            try
            {
                iCheque = GetNewCheque();
                string sSQL = "INSERT INTO Acc_Cheques";
                sSQL += " (lngCheque,strChequeNo,dateCheque,dateDue,intBank,byteStatus,curValue,byteCurrency,strUserCreate,dateCreate)";
                sSQL += " Values(" + iCheque + ",'" + txtCheque.Text + "','" + datepayment + "','" + datedue + "'," + ddlBank.SelectedValue;
                sSQL += "," + ddlStatus.SelectedValue + "," + txtPayment.Text + ",0,'" + Session["CurrentUserName"] + "',GetDate())";

                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandText = sSQL;
                int iEffected = 0;
                iEffected = Cmd.ExecuteNonQuery();
                if (iEffected == 0)
                {
                    iCheque = 0;
                }
            }
            catch (Exception exp)
            {
                lbl_Msg.Text = exp.Message;
                div_msg.Visible = true;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }
            return iCheque;
        }
        private int GetNewCheque()
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            Conn.Open();
            int iCheque = 0;
            try
            {
                string sSQL = "SELECT MAX(lngCheque) FROM Acc_Cheques";
                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandText = sSQL;
                iCheque = Convert.ToInt32("0" + Cmd.ExecuteScalar().ToString()) + 1;
            }
            catch (Exception exp)
            {
                lbl_Msg.Text = exp.Message;
                div_msg.Visible = true;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }
            return iCheque;
        }
        private string AddVoucher()
        {
            string sVoucher = "";
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            Conn.Open();
            try
            {
                sVoucher = NewVoucher();

                string sSQL = "INSERT INTO Acc_Voucher_Header";
                sSQL += " (intFy,byteFSemester,strVoucherNo,dateVoucher,strAccountNo,lngStudentNumber,isPrinted,strUserCreate,dateCreate)";
                sSQL += " VALUES(" + iCYear + "," + iCSem + ",'" + sVoucher + "',GetDate(),'" + lblACC.Text;
                sSQL += "','" + ddlIDs.Text + "',0,'" + Session["CurrentUserName"].ToString() + "',GetDate())";
                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandText = sSQL;
                int iEffected = Cmd.ExecuteNonQuery();
                if (iEffected == 0)
                {
                    sVoucher = "";
                }
                //grdVH.DataBind();

            }
            catch (Exception exp)
            {
                lbl_Msg.Text = exp.Message;
                div_msg.Visible = true;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }
            return sVoucher;
        }
        protected void lnk_Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Acc_Search");
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
            SqlCommand cmd = new SqlCommand("select [strAccountNo],[strStudentName],[lngStudentNumber],iAdmissionPaymentType,cAdmissionPaymentValue from [Reg_Student_Accounts] where [strAccountNo]=@strAccountNo", sc);
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
                    hdniAdmissionPaymentType.Value = dt.Rows[0]["iAdmissionPaymentType"].ToString();
                    hdncAdmissionPaymentValue.Value = dt.Rows[0]["cAdmissionPaymentValue"].ToString();
                }
            }
            catch(Exception ex)
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
        public void generatevoucher_entry()
        {
            lblVoucher.Text = NewVoucher();
            lblEntryNo.Text = GetNewEntry(lblVoucher.Text).ToString();
        }
        private string NewVoucher()
        {
            string sVoucher = "";
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            Conn.Open();
            try
            {
                int iCampus = (int)Campus;
                string sCampus = string.Format("{0:00}", iCampus);

                string sSQL = "SELECT dateStartSemester FROM Reg_Semesters AS S WHERE intStudyYear =" + iCYear + " AND byteSemester =" + iCSem;
                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandText = sSQL;
                SqlDataReader Rd = Cmd.ExecuteReader();
                DateTime dDate = DateTime.Today.Date;
                while (Rd.Read())
                {
                    dDate = Convert.ToDateTime(Rd["dateStartSemester"]);
                }
                Rd.Close();
                string sDate = string.Format("{0:yy}", dDate) + string.Format("{0:MM}", dDate);
                sSQL = "SELECT MAX(CONVERT(INT, RIGHT(strVoucherNo, 5))) AS Voucher";
                sSQL += " FROM Acc_Voucher_Header";
                sSQL += " WHERE intFy = " + iCYear + " AND byteFSemester = " + iCSem;
                Cmd.CommandText = sSQL;
                int iMax = Convert.ToInt32("0" + Cmd.ExecuteScalar().ToString()) + 1;

                sVoucher = sCampus + sDate + string.Format("{0:00000}", iMax);

            }
            catch (Exception exp)
            {
                lbl_Msg.Text = exp.Message;
                div_msg.Visible = true;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }
            return sVoucher;

        }
        private int GetNewEntry(string sVoucher)
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            Conn.Open();
            int iEntry = 0;
            try
            {
                string sSQL = "SELECT Max(lngEntryNo)";
                sSQL += " FROM Acc_Voucher_Detail";
                sSQL += " WHERE intFy=" + iCYear + " AND byteFSemester=" + iCSem + " AND strVoucherNo='" + sVoucher + "'";
                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandText = sSQL;
                iEntry = Convert.ToInt32("0" + Cmd.ExecuteScalar().ToString()) + 1;
            }
            catch (Exception exp)
            {
                lbl_Msg.Text = exp.Message;
                div_msg.Visible = true;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }
            return iEntry;
        }
    }
}