using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Printing;
using System.Globalization;
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
                    FillBanks();
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
                    txtDatePayment.Text = string.Format("{0:dd/MM/yyyy}", DateTime.Today.Date);
                    txtDueDate.Text = string.Format("{0:dd/MM/yyyy}", DateTime.Today.Date.AddDays(30));
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

        public void bindentries(string voucherno)
        {
            lnk_Print.Visible = true;

            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection sc = new SqlConnection(myConnection_String.Conn_string);
            SqlCommand cmd = new SqlCommand("SELECT Acc_Voucher_Detail.strVoucherNo, Acc_Voucher_Detail.lngEntryNo, Acc_Voucher_Detail.curCredit, Acc_Cheques.dateDue, Acc_PaymentsTypes.strPaymentTypeEn, Acc_Cheques.strChequeNo, Acc_Cheques.lngCheque FROM Acc_Voucher_Detail INNER JOIN Acc_PaymentsTypes ON Acc_Voucher_Detail.bytePaymentWay = Acc_PaymentsTypes.bytePaymentType LEFT OUTER JOIN Acc_Cheques ON Acc_Voucher_Detail.lngCheque = Acc_Cheques.lngCheque where Acc_Voucher_Detail.strVoucherNo=@strVoucherNo order by lngEntryNo asc", sc);
            cmd.Parameters.AddWithValue("@strVoucherNo", voucherno);
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
        public void FillBanks()
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection sc = new SqlConnection(myConnection_String.Conn_string);
            SqlCommand cmd = new SqlCommand("SELECT [intBank], [strBankEn] FROM [Acc_Banks] ORDER BY [strBankEn]", sc);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                ddlBank.DataSource = dt;
                ddlBank.DataTextField = "strBankEn";
                ddlBank.DataValueField = "intBank";
                ddlBank.DataBind();
                
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
                    //DateTime due = Convert.ToDateTime(txtDueDate.Text.Trim());
                    DateTime due = Convert.ToDateTime(DateTime.ParseExact(txtDueDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture));
                    if (DateTime.Now>due)
                    {
                        lbl_Msg.Text = "Due Date must be higher than current date";
                        div_msg.Visible = true;
                        return;
                    }
                    else
                    {
                        if (hdnPaymentStatus.Value == "2")//Add Entries to Same Voucher
                        {
                            updatefeespaymententry();
                        }
                        else if (hdnPaymentStatus.Value == "3")//Update Selected Entry to Same Voucher
                        {
                            updatefeespaymentupdateentry();
                        }
                        else
                        {
                            updatefeespayment();
                        }                            
                    }
                }
            }
            else
            {
                //updatefeespayment();
                if (hdnPaymentStatus.Value == "2")//Add Entries to Same Voucher
                {
                    updatefeespaymententry();
                }
                else if (hdnPaymentStatus.Value == "3")//Update Selected Entry to Same Voucher
                {
                    updatefeespaymentupdateentry();
                }
                else
                {
                    updatefeespayment();
                }
            }
        }

        public void updatefeespayment()
        {
            if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_ACC_Search,
                   InitializeModule.enumPrivilege.ACCManageStPayment, CurrentRole) != true)
            {
                lbl_Msg.Text = "Sorry you cannot update payment.";
                div_msg.Visible = true;
                div_Alert.Attributes.Add("class", "alert alert-success alert-dismissible");
                return;
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
                    lbl_Msg.Text = "Payment Added Succesfully";
                    div_Alert.Attributes.Add("class", "alert alert-success alert-dismissible");
                    div_msg.Visible = true;
                    lnk_update.Enabled = true;

                    lblEntryNo.Text = GetNewEntry(lblVoucher.Text).ToString();
                    bindentries(lblVoucher.Text);
                    hdnPaymentStatus.Value = "2";//Add Entries to Same Voucher

                    ddlPaymentWay.SelectedIndex = 0;
                    txtCheque.Text = "";
                    txtDueDate.Text = string.Format("{0:dd/MM/yyyy}", DateTime.Today.Date.AddDays(30));
                    txtPayment.Text = "";
                    txtPRemark.Text = "";
                    cheque.Visible = false;
                    //ddlBank.SelectedIndex = 0;
                }
            }
        }
        public void updatefeespaymententry()
        {
            if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_ACC_Search,
                   InitializeModule.enumPrivilege.ACCManageStPayment, CurrentRole) != true)
            {
                lbl_Msg.Text = "Sorry you cannot update payment.";
                div_msg.Visible = true;
                div_Alert.Attributes.Add("class", "alert alert-success alert-dismissible");
                return;
            }
            //string sVoucher = AddVoucher();
            int iEntry = GetNewEntry(lblVoucher.Text.Trim());
            string sMsg = "Payment not saved !";
            bool isUpdated = false;
            if (hdnPaymentStatus.Value == "2")//Add Entries to Same Voucher
            {
                isUpdated = UpdatePayment(true);
                if (isUpdated)
                {
                    sMsg = "Payment added.";
                    //Check for First Payment and CX Update and Change Student to 105 Role based on Payment Value.
                    //checkfirstpayment(lblACC.Text);//checking that its first payment done by student or not
                    lbl_Msg.Text = "Payment Added Succesfully";
                    div_Alert.Attributes.Add("class", "alert alert-success alert-dismissible");
                    div_msg.Visible = true;
                    lnk_update.Enabled = true;

                    lblEntryNo.Text = GetNewEntry(lblVoucher.Text).ToString();
                    bindentries(lblVoucher.Text);
                    hdnPaymentStatus.Value = "2";//Add Entries to Same Voucher

                    ddlPaymentWay.SelectedIndex = 0;
                    txtCheque.Text = "";
                    txtDueDate.Text = string.Format("{0:dd/MM/yyyy}", DateTime.Today.Date.AddDays(30));
                    txtPayment.Text = "";
                    txtPRemark.Text = "";
                    cheque.Visible = false;
                    //ddlBank.SelectedIndex = 0;
                }
            }
        }

        public void updatefeespaymentupdateentry()
        {
            if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_ACC_Search,
                   InitializeModule.enumPrivilege.ACCManageStPayment, CurrentRole) != true)
            {
                lbl_Msg.Text = "Sorry you cannot update payment.";
                div_msg.Visible = true;
                div_Alert.Attributes.Add("class", "alert alert-success alert-dismissible");
                return;
            }
            //string sVoucher = AddVoucher();
            //int iEntry = GetNewEntry(lblVoucher.Text.Trim());
            string sMsg = "Payment not saved !";
            bool isUpdated = false;
            if (hdnPaymentStatus.Value == "3")//Update Selected Entry to Same Voucher
            {
                isUpdated = UpdatePayment(false);
                if (isUpdated)
                {
                    sMsg = "Payment updated.";
                    //Check for First Payment and CX Update and Change Student to 105 Role based on Payment Value.
                    //checkfirstpayment(lblACC.Text);//checking that its first payment done by student or not
                    lbl_Msg.Text = "Payment Updated Succesfully";
                    div_Alert.Attributes.Add("class", "alert alert-success alert-dismissible");
                    div_msg.Visible = true;
                    lnk_update.Enabled = true;

                    lblEntryNo.Text = GetNewEntry(lblVoucher.Text).ToString();
                    bindentries(lblVoucher.Text);
                    hdnPaymentStatus.Value = "2";//Add Entries to Same Voucher

                    ddlPaymentWay.SelectedIndex = 0;
                    txtCheque.Text = "";
                    txtDueDate.Text = string.Format("{0:dd/MM/yyyy}", DateTime.Today.Date.AddDays(30));
                    txtPayment.Text = "";
                    txtPRemark.Text = "";
                    cheque.Visible = false;
                    //ddlBank.SelectedIndex = 0;
                }
            }
        }

        protected void EditBTN_Command(object sender, CommandEventArgs e)
        {
            int r = 0;
            r = Get_Entry(int.Parse(e.CommandArgument.ToString()));
        }
        protected void DeleteBTN_Command(object sender, CommandEventArgs e)
        {
            int lngEntryNo = 0;
            lngEntryNo = int.Parse(e.CommandArgument.ToString());
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection sc = new SqlConnection(myConnection_String.Conn_string);
            SqlCommand cmd = new SqlCommand("delete from Acc_Voucher_Detail where strVoucherNo=@strVoucherNo and lngEntryNo=@lngEntryNo", sc);
            cmd.Parameters.AddWithValue("@strVoucherNo", lblVoucher.Text.Trim());
            cmd.Parameters.AddWithValue("@lngEntryNo", lngEntryNo);
            try
            {
                sc.Open();
                cmd.ExecuteNonQuery();
                sc.Close();

                int lngCheque = 0;
                if(string.IsNullOrEmpty(e.CommandName.ToString()))
                {

                }
                else
                {
                    lngCheque = int.Parse(e.CommandName.ToString());
                    if (lngCheque > 0)
                    {
                        SqlCommand cmd1 = new SqlCommand("delete from Acc_Cheques where lngCheque=@lngCheque", sc);
                        cmd1.Parameters.AddWithValue("@lngCheque", lngCheque);
                        try
                        {
                            sc.Open();
                            cmd1.ExecuteNonQuery();
                            sc.Close();
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
                    }
                }               


                lbl_Msg.Text = "Voucher# "+lblVoucher.Text+" - (Entry: " + lngEntryNo + ") Deleted Successfully";
                div_msg.Visible = true;
                div_Alert.Attributes.Add("class", "alert alert-success alert-dismissible");

                lblEntryNo.Text = GetNewEntry(lblVoucher.Text).ToString();
                bindentries(lblVoucher.Text);
                hdnPaymentStatus.Value = "2";//Add Entries to Same Voucher

                ddlPaymentWay.SelectedIndex = 0;
                txtCheque.Text = "";
                txtDueDate.Text = "";
                txtPayment.Text = "";
                txtPRemark.Text = "";
            }
            catch (Exception exp)
            {
                sc.Close();
                Console.WriteLine("{0} Exception caught.", exp);
                lbl_Msg.Text = exp.Message;
                div_msg.Visible = true;
            }
            finally
            {
                sc.Close();
            }
        }
        private int Get_Entry(int lngEntryNo)
        {
            int r = 0;
            try
            {
                Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
                SqlConnection sc = new SqlConnection(myConnection_String.Conn_string);
                SqlCommand cmd = new SqlCommand("SELECT Acc_Voucher_Detail.strVoucherNo, Acc_Voucher_Detail.strRemark, Acc_Voucher_Detail.datePayment, Acc_Voucher_Detail.lngEntryNo, Acc_Voucher_Detail.curCredit, Acc_Cheques.dateDue, Acc_PaymentsTypes.strPaymentTypeEn, Acc_Cheques.strChequeNo, Acc_Cheques.lngCheque, Acc_Banks.strBankEn FROM Acc_Voucher_Detail INNER JOIN Acc_PaymentsTypes ON Acc_Voucher_Detail.bytePaymentWay = Acc_PaymentsTypes.bytePaymentType LEFT OUTER JOIN Acc_Banks ON Acc_Voucher_Detail.intBank = Acc_Banks.intBank LEFT OUTER JOIN Acc_Cheques ON Acc_Voucher_Detail.lngCheque = Acc_Cheques.lngCheque where Acc_Voucher_Detail.strVoucherNo=@strVoucherNo and Acc_Voucher_Detail.lngEntryNo=@lngEntryNo", sc);
                cmd.Parameters.AddWithValue("@strVoucherNo", lblVoucher.Text.Trim());
                cmd.Parameters.AddWithValue("@lngEntryNo", lngEntryNo);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                try
                {
                    sc.Open();
                    da.Fill(dt);
                    sc.Close();
                    if (dt.Rows.Count > 0)
                    {
                        txtDatePayment.Text = Convert.ToDateTime(dt.Rows[0]["datePayment"]).ToString("dd/MM/yyyy");
                        txtPayment.Text = dt.Rows[0]["curCredit"].ToString();
                        ddlPaymentWay.SelectedIndex = ddlPaymentWay.Items.IndexOf(ddlPaymentWay.Items.FindByText(dt.Rows[0]["strPaymentTypeEn"].ToString()));
                        lblEntryNo.Text = lngEntryNo.ToString();
                        if (dt.Rows[0]["strPaymentTypeEn"].ToString() == "Cheque")
                        {
                            cheque.Visible = true;
                            txtCheque.Text= dt.Rows[0]["strChequeNo"].ToString();
                            txtDueDate.Text= Convert.ToDateTime(dt.Rows[0]["dateDue"]).ToString("dd/MM/yyyy");
                            ddlBank.SelectedIndex = ddlBank.Items.IndexOf(ddlBank.Items.FindByText(dt.Rows[0]["strBankEn"].ToString()));
                            hdnChquenoUpdate.Value= dt.Rows[0]["lngCheque"].ToString();
                            hdnCheque.Value = dt.Rows[0]["lngCheque"].ToString();
                        }
                        else
                        {
                            cheque.Visible = false;
                        }
                        txtPRemark.Text = dt.Rows[0]["strRemark"].ToString();
                        hdnPaymentStatus.Value = "3";//Update Selected Entry to Same Voucher
                    }
                    else
                    {
                        lbl_Msg.Text = "No Data Available.";
                        div_msg.Visible = true;
                    }

                }
                catch (Exception exp)
                {
                    sc.Close();
                    Console.WriteLine("{0} Exception caught.", exp);
                    lbl_Msg.Text = exp.Message;
                    div_msg.Visible = true;
                }
                finally
                {
                    sc.Close();
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
                    DateTime date = DateTime.ParseExact(txtDatePayment.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    datepayment = Convert.ToDateTime(date);
                }
                if (string.IsNullOrEmpty(txtDueDate.Text.Trim()))
                {
                    datedue = DateTime.Now;
                }
                else
                {
                    DateTime date = DateTime.ParseExact(txtDueDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    datedue = Convert.ToDateTime(date);
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
            DateTime datepayment;
            DateTime date = DateTime.ParseExact(txtDatePayment.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            datepayment = Convert.ToDateTime(date);


            DateTime datedue;
            DateTime date1 = DateTime.ParseExact(txtDueDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            datedue = Convert.ToDateTime(date1);

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
            DateTime datepayment;
            DateTime date = DateTime.ParseExact(txtDatePayment.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            datepayment = Convert.ToDateTime(date);


            DateTime datedue;
            DateTime date1 = DateTime.ParseExact(txtDueDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            datedue = Convert.ToDateTime(date1);

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

        protected void lnk_Print_Click(object sender, EventArgs e)
        {
            if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_ACC_Search,
         InitializeModule.enumPrivilege.Print, CurrentRole) != true)
            {               
                //lbl_Msg.Text = InitializeModule.MsgPrintAuthorization;
                //div_msg.Visible = true;
                //return;
            }

            if (!string.IsNullOrEmpty(lblVoucher.Text))
            {
                UpdateVoucher(lblVoucher.Text, true);//Close the printing
                Export(InitializeModule.ECT_Buttons.Print);
            }
        }
        private bool UpdateVoucher(string sVoucher, bool isPrinted)
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            Conn.Open();
            bool isUpdated = false;
            try
            {

                string sSQL = "UPDATE Acc_Voucher_Header SET";
                sSQL += " isPrinted=" + Convert.ToInt32(isPrinted);
                sSQL += ",strUserSave='" + Session["CurrentUserName"] + "',dateLastSave=GetDate()";
                sSQL += " WHERE intFy=" + iCYear;
                sSQL += " AND byteFSemester=" + iCSem;
                sSQL += " AND strVoucherNo='" + sVoucher + "'";

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
        private void Export(InitializeModule.ECT_Buttons iExport)
        {
            ReportDocument myReport = new ReportDocument();

            try
            {
                DataTable rptDS = new DataTable();
                rptDS = Prepare_Report(GetSQL(lblVoucher.Text));

                string reportPath = Server.MapPath("Reports/CrystalReport3_AccVoucher.rpt");
                myReport.Load(reportPath);
                myReport.SetDataSource(rptDS);
                ////txtPrinter.Text = DefaultPrinterName();
                //myReport.PrintOptions.PrinterName = "";
                ////
                //myReport.PrintOptions.PaperSize = SetPaperSize(myReport.PrintOptions.PrinterName);
                //myReport.PrintToPrinter(1, false, 0, 0);
                myReport.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Page.Response, true, "ECTReport");

                //myReport.PrintOptions.PaperOrientation = PaperOrientation.Portrait;


                //TextObject txt;
                //txt = (TextObject)myReport.ReportDefinition.ReportObjects["txtTitle"];

                //txt.Text = GetCaption();


                //switch (iExport)
                //{
                //    case InitializeModule.ECT_Buttons.Print:
                //        myReport.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Page.Response, true, "ECTReport");
                //        break;
                //    case InitializeModule.ECT_Buttons.ToExcel:
                //        myReport.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.ExcelRecord, Page.Response, true, "ECTReport");
                //        break;
                //    case InitializeModule.ECT_Buttons.ToWord:
                //        myReport.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.WordForWindows, Page.Response, true, "ECTReport");
                //        break;
                //}
                Session["CurrentReport"] = myReport;
                //Response.Redirect("RPTViewer.aspx?sPage=ProgramMirror.aspx");
            }
            catch (Exception exp)
            {
                Console.WriteLine("{0} Exception caught.", exp);
                lbl_Msg.Text = exp.Message;
                div_msg.Visible = true;
            }
            finally
            {
                myReport.Close();
                myReport.Dispose();
            }
        }
        private string GetSQL(string sVoucher)
        {
            string sSQL = "";
            try
            {
                sSQL = "SELECT VH.strVoucherNo, VH.dateVoucher, VH.strAccountNo, A.strStudentName, A.lngStudentNumber, VD.lngEntryNo, VD.curCredit, VD.bytePaymentWay,";
                sSQL += " PT.strPaymentTypeEn AS PWay, C.strChequeNo, VD.dateDue, B.strBankEn AS Bank, VD.strRemark";
                sSQL += " FROM Acc_Voucher_Header AS VH INNER JOIN Acc_Voucher_Detail AS VD ON VH.intFy = VD.intFy AND VH.byteFSemester = VD.byteFSemester AND VH.strVoucherNo = VD.strVoucherNo INNER JOIN";
                sSQL += " Acc_PaymentsTypes AS PT ON VD.bytePaymentWay = PT.bytePaymentType LEFT OUTER JOIN Acc_Cheques AS C ON VD.lngCheque = C.lngCheque INNER JOIN";
                sSQL += " Reg_Student_Accounts AS A ON VH.strAccountNo = A.strAccountNo LEFT OUTER JOIN Acc_Banks AS B ON VD.intBank = B.intBank";
                sSQL += " WHERE VH.strVoucherNo = '" + sVoucher + "' AND VH.intFy = " + iCYear + " AND VH.byteFSemester =" + iCSem;
            }
            catch (Exception exp)
            {
                lbl_Msg.Text = exp.Message;
                div_msg.Visible = true;
            }
            finally
            {

            }
            return sSQL;
        }
        private DataTable Prepare_Report(string sSQL)
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            Conn.Open();

            DataTable dt = new DataTable();
            DataRow dr;
            DataSet ds = new DataSet();
            try
            {
                //VH.strVoucherNo, VH.dateVoucher, VH.strAccountNo, A.strStudentName, A.lngStudentNumber,
                //VD.lngEntryNo, VD.curCredit, VD.bytePaymentWay
                //PT.strPaymentTypeEn AS PType, C.strChequeNo, VD.dateDue, B.strBankEn AS Bank,
                //VD.bytePaymentWay AS PWay, VH.strRemark"
                DataColumn myCol;

                myCol = new DataColumn("iSerial", Type.GetType("System.Int32"));
                dt.Columns.Add(myCol);
                myCol = new DataColumn("sVoucher", Type.GetType("System.String"));
                dt.Columns.Add(myCol);
                myCol = new DataColumn("sVoucherDate", Type.GetType("System.String"));
                dt.Columns.Add(myCol);
                myCol = new DataColumn("sAccount", Type.GetType("System.String"));
                dt.Columns.Add(myCol);
                myCol = new DataColumn("sName", Type.GetType("System.String"));
                dt.Columns.Add(myCol);
                myCol = new DataColumn("sID", Type.GetType("System.String"));
                dt.Columns.Add(myCol);
                myCol = new DataColumn("dAmount", Type.GetType("System.Double"));
                dt.Columns.Add(myCol);
                myCol = new DataColumn("iWay", Type.GetType("System.Int32"));
                dt.Columns.Add(myCol);
                myCol = new DataColumn("sWay", Type.GetType("System.String"));
                dt.Columns.Add(myCol);
                myCol = new DataColumn("sCheque", Type.GetType("System.String"));
                dt.Columns.Add(myCol);
                myCol = new DataColumn("sDueDate", Type.GetType("System.String"));
                dt.Columns.Add(myCol);
                myCol = new DataColumn("sBank", Type.GetType("System.String"));
                dt.Columns.Add(myCol);
                myCol = new DataColumn("sRemark", Type.GetType("System.String"));
                dt.Columns.Add(myCol);
                myCol = new DataColumn("sCash", Type.GetType("System.String"));
                dt.Columns.Add(myCol);
                myCol = new DataColumn("sUser", Type.GetType("System.String"));
                dt.Columns.Add(myCol);

                SqlCommand Cmd = new SqlCommand(sSQL, Conn);
                SqlDataReader Rd = Cmd.ExecuteReader();

                string sCash = Campus.ToString();
                string sUser = Session["CurrentUserName"].ToString();


                while (Rd.Read())
                {
                    dr = dt.NewRow();
                    dr["iSerial"] = Convert.ToInt32(Rd["lngEntryNo"]);
                    dr["sVoucher"] = Rd["strVoucherNo"].ToString();
                    dr["sVoucherDate"] = string.Format("{0:dd/MM/yyyy}", Convert.ToDateTime(Rd["dateVoucher"]));
                    dr["sAccount"] = Rd["strAccountNo"].ToString();
                    dr["sName"] = Rd["strStudentName"].ToString();
                    dr["sID"] = Rd["lngStudentNumber"].ToString();
                    dr["dAmount"] = Convert.ToDouble(Rd["curCredit"]);
                    dr["iWay"] = Convert.ToInt32(Rd["bytePaymentWay"]);
                    dr["sWay"] = Rd["PWay"].ToString();


                    if (!Rd["strChequeNo"].Equals(DBNull.Value))
                    {
                        dr["sCheque"] = Rd["strChequeNo"].ToString();
                        dr["sDueDate"] = string.Format("{0:dd/MM/yyyy}", Convert.ToDateTime(Rd["dateDue"]));
                        dr["sBank"] = Rd["Bank"].ToString();
                    }

                    dr["sRemark"] = Rd["strRemark"].ToString();

                    dr["sCash"] = sCash;
                    dr["sUser"] = sUser;

                    dt.Rows.Add(dr);
                }
                Rd.Close();
                dt.TableName = "tblVoucher";
                dt.AcceptChanges();
                //ds.Tables.Add(dt);


            }
            catch (Exception exp)
            {
                Console.WriteLine("{0} Exception caught.", exp);
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }
            return dt;
        }
    }
}