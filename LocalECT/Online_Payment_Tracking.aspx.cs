using Microsoft.SharePoint.Client;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LocalECT
{
    public partial class Online_Payment_Tracking : System.Web.UI.Page
    {
        int CurrentRole = 0;
        InitializeModule.EnumCampus Campus = InitializeModule.EnumCampus.Males;
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
            if (!IsPostBack)
            {
                if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Reg_Balance,
                    InitializeModule.enumPrivilege.ShowBrowse, CurrentRole) != true)
                {
                    Server.Transfer("Authorization.aspx");

                }
                //FillTerms();
                // ddlRegTerm.SelectedValue = Session["CurrentYear"].ToString() + Session["CurrentSemester"].ToString();
                //if (Session["payment_tracking_table"] != null)
                //{
                //    DataTable dt1 = (DataTable)Session["payment_tracking_table"];
                //    RepterDetails.DataSource = dt1;
                //    RepterDetails.DataBind();
                //}
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
                    //   ddlRegTerm.Items.Add(new ListItem(myTerms[i].ShortDesc, myTerms[i].Term.ToString()));

                }
                int iYear = 0;
                int iSem = 0;
                int iTerm = 0;
                iYear = (int)Session["RegYear"];
                iSem = (int)Session["RegSemester"];
                iTerm = iYear * 10 + iSem;
                // ddlRegTerm.SelectedValue = iTerm.ToString();
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
        private string getIDsCondition(string sIDs, string columnname)
        {
            string sCon = " AND (";
            try
            {
                string[] sSeperated;
                sSeperated = sIDs.Split(';');
                int iCount = sSeperated.Length;
                foreach (string sID in sSeperated)
                {
                    sCon += " " + columnname + " like '%" + sID + "%'";
                    iCount -= 1;
                    if (iCount > 0)
                    {
                        sCon += " Or";
                    }
                    else
                    {
                        sCon += ")";
                    }
                }
            }
            catch (Exception exp)
            {
                //Console.WriteLine("{0} Exception caught.", exp);
                //divMsg.InnerText = exp.Message;
            }
            finally
            {
            }
            return sCon;
        }
        protected void lnk_FieldGenerate_Click(object sender, EventArgs e)
        {
            if (drp_Campus.SelectedItem.Text == "Males")
            {
                Campus = InitializeModule.EnumCampus.Males;
            }
            else
            {
                Campus = InitializeModule.EnumCampus.Females;
            }
            string sWhere = " WHERE (1=1) ";
            
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection sc = new SqlConnection(myConnection_String.Conn_string);

            string sSQL = "";


            sSQL = "SELECT  iSerial AS [Serial#], sOrder AS [Order], sACC AS Account, sSID AS SID, sService AS Service, dDate AS RDate, (CASE WHEN isCaptured = 1 THEN 'Yes' ELSE 'No' END) ";
            sSQL += " AS isCaptured, dCaptured AS Captured, sVoucherNo AS VoucherNo, (CASE WHEN isCanceled = 1 THEN 'Yes' ELSE 'No' END) AS isCanceled,cAmount,cVAT,tOrder FROM Acc_Payment_Order AS PO  ";

            if (txtSID.Text != "")
            {

                sWhere += " AND sSID like '%" + txtSID.Text + "%'  ";

            }

            if (txtACC.Text != "")
            {
                sWhere += "  AND sACC like '%" + txtACC.Text + "%'  ";
            }

            sSQL += sWhere;
            sSQL += " AND dDate BETWEEN '" + DDateFrom.Text + " 00:00:00.000' AND '" + DDateTo.Text + " 23:59:59.999'  ORDER BY RDate DESC ";

            SqlCommand cmd1 = new SqlCommand(sSQL, sc);
            cmd1.CommandTimeout = 180;
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            try
            {
                sc.Open();
                da1.Fill(dt1);
                sc.Close();

                Session["payment_tracking_table"] = dt1;
                RepterDetails.DataSource = dt1;
                RepterDetails.DataBind();                
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
            //trackorder("vsnQorTsufEfrEyq");
        }
        public string trackorder(string orderid,out DateTime creationTime)
        {
            string amount = "0";
            creationTime = DateTime.Now;
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.DefaultConnectionLimit = 9999;
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;

            var handler = new HttpClientHandler();
            handler.UseCookies = false;

            using (var httpClient = new HttpClient(handler))
            {
                using (var request = new HttpRequestMessage(new HttpMethod("GET"), "https://eu-gateway.mastercard.com/api/rest/version/59/merchant/7006448/order/"+ orderid + ""))
                {
                    request.Headers.TryAddWithoutValidation("OSvC-CREST-Application-Context", "application/x-www-form-urlencoded");
                    request.Headers.TryAddWithoutValidation("Authorization", "Basic bWVyY2hhbnQuNzAwNjQ0ODpmMjQ3NDg2N2NjN2RiYmEwOTZiMGU0MzczMjcxZDNmMA==");
                    request.Headers.TryAddWithoutValidation("Cookie", "TS01250d6c=015fce43d2fca420deeff3394ac6cb9ee8417cf3f4a8c14db62f044b58840da2efa7910bdf713eed4f148fed10e7a3e4f28102f5de");

                    var task = httpClient.SendAsync(request);
                    task.Wait();
                    var response = task.Result;
                    string s = response.Content.ReadAsStringAsync().Result;
                    if (response.IsSuccessStatusCode == true)
                    {
                        var x = JObject.Parse(s);
                        amount = (string)x["totalCapturedAmount"];
                        creationTime = Convert.ToDateTime((string)x["creationTime"]);
                    } 
                    else
                    {
                        var x = JObject.Parse(s);
                        amount = (string)x["result"];
                    }
                }
            }
            return amount;
        }

        protected void lnk_Create_Voucher_Click(object sender, EventArgs e)
        {
            LinkButton button = (sender as LinkButton);
            string orderid = button.CommandArgument;
            DateTime creationTime;
            string voucherNumber = button.ToolTip;
            if (drp_Campus.SelectedItem.Text == "Males")
            {
                Campus = InitializeModule.EnumCampus.Males;
            }
            else
            {
                Campus = InitializeModule.EnumCampus.Females;
            }
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection sc = new SqlConnection(myConnection_String.Conn_string);

            if (string.IsNullOrEmpty(voucherNumber))//Add Voucher
            {
                if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.Online_Payment_Tracking,
                InitializeModule.enumPrivilege.AddOnlinePayment, CurrentRole) != true)
                {
                    lbl_Msg.Text = "You don't have the permission to Add Voucher";
                    div_msg.Visible = true;
                    return;
                }
                else
                {
                    //Create Voucher
                    string amount = trackorder(orderid, out creationTime);                   
                    if (amount != "ERROR")
                    {
                        //Create Voucher
                        SqlCommand cmd = new SqlCommand("select * from Acc_Payment_Order where sOrder=@sOrder", sc);
                        cmd.Parameters.AddWithValue("@sOrder", orderid);
                        DataTable dt = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        try
                        {
                            sc.Open();
                            da.Fill(dt);
                            sc.Close();

                            if (dt.Rows.Count > 0)
                            {
                                double totalCapturedAmount = Convert.ToDouble(amount);
                                double cAmount = 0;
                                double cVAT = 0;
                                int iPaidfor = 0;
                                if (dt.Rows[0]["sService"].ToString() == "Tution Fees")
                                {
                                    cAmount = totalCapturedAmount;
                                    cVAT = 0;
                                    iPaidfor = 0;
                                }
                                else//Student Services: 1XXX
                                {
                                    double dGrossAmount = totalCapturedAmount;
                                    double dPmtAmount = Math.Round((dGrossAmount / 1.05), 2);
                                    double dVAT = Math.Round((dGrossAmount - dPmtAmount), 2);
                                    cAmount = dPmtAmount;
                                    cVAT = dVAT;
                                    string serviceID = dt.Rows[0]["sService"].ToString().Substring(dt.Rows[0]["sService"].ToString().LastIndexOf(' ') + 1);
                                    SqlCommand cmd1 = new SqlCommand("select * from [ECTDataNew].[dbo].[ECT_Services] where ServiceID=@ServiceID", sc);
                                    cmd1.Parameters.AddWithValue("@ServiceID", serviceID);
                                    DataTable dt1 = new DataTable();
                                    SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                                    try
                                    {
                                        sc.Open();
                                        da1.Fill(dt1);
                                        sc.Close();

                                        if (dt1.Rows.Count > 0)
                                        {
                                            iPaidfor = Convert.ToInt32(dt1.Rows[0]["FeesType"]);
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        sc.Close();
                                        Console.WriteLine(ex.Message);
                                        lbl_Msg.Text = ex.Message;
                                        div_msg.Visible = true;
                                    }
                                    finally
                                    {
                                        sc.Close();
                                    }
                                }
                                createvouchers(dt.Rows[0]["sACC"].ToString(), dt.Rows[0]["sSID"].ToString(), orderid, cAmount, cVAT, iPaidfor, creationTime);
                            }
                        }
                        catch (Exception ex)
                        {
                            sc.Close();
                            Console.WriteLine(ex.Message);
                            lbl_Msg.Text = ex.Message;
                            div_msg.Visible = true;
                        }
                        finally
                        {
                            sc.Close();
                        }
                    }
                    else
                    {
                        //Unable to find payment for Order# LGKPF2I2mBlAJxqQ
                        SqlCommand cmd = new SqlCommand("update Acc_Payment_Order set isCanceled='True' where sOrder=@sOrder", sc);
                        cmd.Parameters.AddWithValue("@sOrder", orderid);
                        try
                        {
                            sc.Open();
                            cmd.ExecuteNonQuery();
                            sc.Close();

                            //Response.Write("<script>alert('Unable to find payment for Order# " + orderid + "');</script>");
                            lbl_Msg.Text = "Unable to find payment for Order# " + orderid + "";
                            div_msg.Visible = true;
                        }
                        catch (Exception ex)
                        {
                            sc.Close();
                            Console.WriteLine(ex.Message);
                            lbl_Msg.Text = ex.Message;
                            div_msg.Visible = true;
                        }
                        finally
                        {
                            sc.Close();
                        }
                    }
                }
            }
            else //Create Request
            {
                if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.Online_Payment_Tracking,
                InitializeModule.enumPrivilege.CreateOnlineRequest, CurrentRole) != true)
                {
                    lbl_Msg.Text = "You don't have the permission to Create Request";
                    div_msg.Visible = true;
                    return;
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("select * from Acc_Payment_Order where sOrder=@sOrder", sc);
                    cmd.Parameters.AddWithValue("@sOrder", orderid);
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    try
                    {
                        sc.Open();
                        da.Fill(dt);
                        sc.Close();

                        if (dt.Rows.Count > 0)
                        {
                            if (!string.IsNullOrEmpty(dt.Rows[0]["tOrder"].ToString())&& !string.IsNullOrEmpty(dt.Rows[0]["sVoucherNo"].ToString()))
                            {
                                //Create Request
                                StringReader theReader = new StringReader(dt.Rows[0]["tOrder"].ToString());
                                DataSet theDataSet = new DataSet();
                                theDataSet.ReadXml(theReader);
                                sentdatatoSPLIst(dt.Rows[0]["sVoucherNo"].ToString(), theDataSet.Tables[0], orderid);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        sc.Close();
                        Console.WriteLine(ex.Message);
                        lbl_Msg.Text = ex.Message;
                        div_msg.Visible = true;
                    }
                    finally
                    {
                        sc.Close();
                    }
                }
            }          
            lnk_FieldGenerate_Click(null, null);
        }
        public void sentdatatoSPLIst(string sVoucher,DataTable dt,string sOrder)
        {
            if (drp_Campus.SelectedItem.Text == "Males")
            {
                Campus = InitializeModule.EnumCampus.Males;
            }
            else
            {
                Campus = InitializeModule.EnumCampus.Females;
            }
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection sc = new SqlConnection(myConnection_String.Conn_string);

            DataTable CurrentdtSPList = dt;

            string login = "ets.services.admin@ect.ac.ae"; //give your username here  
            string password = "Ser71ces@328"; //give your password
            var securePassword = new SecureString();
            foreach (char c in password)
            {
                securePassword.AppendChar(c);
            }
            string siteUrl = "https://ectacae.sharepoint.com/sites/ECTPortal/eservices/studentservices";
            ClientContext clientContext = new ClientContext(siteUrl);
            Microsoft.SharePoint.Client.List myList = clientContext.Web.Lists.GetByTitle("Students_Requests");
            ListItemCreationInformation itemInfo = new ListItemCreationInformation();
            Microsoft.SharePoint.Client.ListItem myItem = myList.AddItem(itemInfo);
            //string refno = Create16DigitString();
            myItem["Title"] = CurrentdtSPList.Rows[0]["Title"].ToString();
            //myItem["RequestID"] = refno;
            myItem["Year"] = CurrentdtSPList.Rows[0]["Year"].ToString();
            myItem["Semester"] = CurrentdtSPList.Rows[0]["Semester"].ToString();
            myItem["Request"] = CurrentdtSPList.Rows[0]["Request"].ToString();
            myItem["RequestNote"] = CurrentdtSPList.Rows[0]["RequestNote"].ToString();
            myItem["ServiceID"] = CurrentdtSPList.Rows[0]["ServiceID"].ToString();
            myItem["Fees"] = CurrentdtSPList.Rows[0]["Fees"].ToString();
            //myItem["Requester"] = clientContext.Web.EnsureUser(hdf_StudentEmail.Value);
            myItem["Requester"] = clientContext.Web.EnsureUser(CurrentdtSPList.Rows[0]["Requester"].ToString());
            myItem["StudentID"] = CurrentdtSPList.Rows[0]["StudentID"].ToString();
            myItem["StudentName"] = CurrentdtSPList.Rows[0]["StudentName"].ToString();
            myItem["Contact"] = CurrentdtSPList.Rows[0]["Contact"].ToString();
            myItem["Finance"] = clientContext.Web.EnsureUser(CurrentdtSPList.Rows[0]["Finance"].ToString());
            myItem["FinanceAction"] = CurrentdtSPList.Rows[0]["FinanceAction"].ToString();
            myItem["FinanceNote"] = "";
            myItem["Host"] = clientContext.Web.EnsureUser(CurrentdtSPList.Rows[0]["Host"].ToString());
            myItem["HostAction"] = CurrentdtSPList.Rows[0]["HostAction"].ToString();
            myItem["HostNote"] = "";
            //myItem["Provider"] = "";
            myItem["ProviderAction"] = CurrentdtSPList.Rows[0]["ProviderAction"].ToString();
            myItem["ProviderNote"] = "";
            myItem["Status"] = CurrentdtSPList.Rows[0]["Status"].ToString();
            myItem["Payment_Ref"] = sVoucher;
            //myItem["Modified"] = DateTime.Now;
            //myItem["Created"] = DateTime.Now;
            //myItem["Created By"] = hdf_StudentEmail.Value;
            //myItem["Modified By"] = hdf_StudentEmail.Value;
            try
            {
                myItem.Update();

                

                var onlineCredentials = new SharePointOnlineCredentials(login, securePassword);
                clientContext.Credentials = onlineCredentials;
                clientContext.ExecuteQuery();

                SqlCommand cmd = new SqlCommand("update Acc_Payment_Order set tOrder=@tOrder where sOrder=@sOrder", sc);
                cmd.Parameters.AddWithValue("@tOrder", DBNull.Value);
                cmd.Parameters.AddWithValue("@sOrder", sOrder);
                try
                {
                    sc.Open();
                    cmd.ExecuteNonQuery();
                    sc.Close();
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


                lbl_Msg.Text = "Request (ID# " + CurrentdtSPList.Rows[0]["Title"].ToString() + ") Generated Successfully";
                div_Alert.Attributes.Add("class", "alert alert-success alert-dismissible");
                div_msg.Visible = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }            
        }
        public void createvouchers(string sAcc,string sSID,string sPmtOrder,double dPmtAmount,double dVAT,int iPaidfor,DateTime creationTime)
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection sc = new SqlConnection(myConnection_String.Conn_string);
            string sPmtSession = sPmtOrder;            
            string sPmtResultIndicator = "";
            string sPmtResult = "SUCCESS";            
                   
            string sVoucher = "";
            if (sPmtResult == "SUCCESS")
            {                
                sVoucher = AddVoucher(sAcc, sSID, sPmtSession, "Order:" + sPmtOrder);
               // lblReceiptNo.Text = sVoucher;
                if (sVoucher != "")
                {

                    int iEffected = AddPayment(sVoucher, sPmtSession, "Order:" + sPmtOrder, iPaidfor, dPmtAmount, dVAT);
                    if (iEffected == 0)
                    {
                        //lblResult.Text = "Error: Payment not registered in the system.";
                        //divMsg.InnerHtml = sAccMsg;
                        lbl_Msg.Text = "Error: Payment not registered in the system.";
                        div_msg.Visible = true;
                    }
                    else
                    {
                        //updateonlinepayment(sPmtOrder, sVoucher);   
                        SqlCommand cmd = new SqlCommand("update Acc_Payment_Order set isCaptured='True',dCaptured=@dCaptured,sVoucherNo=@sVoucherNo,cAmount=@cAmount,cVAT=@cVAT where sOrder=@sOrder", sc);
                        cmd.Parameters.AddWithValue("@sOrder", sPmtOrder);
                        cmd.Parameters.AddWithValue("@dCaptured", creationTime);
                        cmd.Parameters.AddWithValue("@sVoucherNo", sVoucher);
                        cmd.Parameters.AddWithValue("@cAmount", dPmtAmount);
                        cmd.Parameters.AddWithValue("@cVAT", dVAT);                        
                        try
                        {
                            sc.Open();
                            cmd.ExecuteNonQuery();
                            sc.Close();                            
                        }
                        catch(Exception ex)
                        {
                            sc.Close();
                            Console.WriteLine(ex.Message);
                            lbl_Msg.Text = ex.Message;
                            div_msg.Visible = true;
                        }
                        finally
                        {
                            sc.Close();
                        }
                        lbl_Msg.Text = "Voucher# ("+ sVoucher + ") added successfully.";
                        div_Alert.Attributes.Add("class", "alert alert-success alert-dismissible");
                        div_msg.Visible = true;
                    }
                }
                else
                {
                    //lblResult.Text = "Error: Payment not registered in the system.";
                    //divMsg.InnerHtml = sAccMsg;
                    lbl_Msg.Text = "Error: Payment not registered in the system.";
                    div_msg.Visible = true;
                }
            }
            else
            {
                //lblResult.Text = "Error: Payment not received.";
                //divMsg.InnerHtml = sAccMsg;
                lbl_Msg.Text = "Error: Payment not received.";
                div_msg.Visible = true;
            }
        }
        private string AddVoucher(string sAcc, string sSID, string sPmtSession, string sPmtOrder)
        {
            string sVoucher = "";
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            Conn.Open();
            try
            {
                int iCSem = 0;
                int iCYear = LibraryMOD.SeperateTerm(LibraryMOD.GetCurrentTerm(), out iCSem);
                sVoucher = NewVoucher(iCYear, iCSem);
                //,[strRemark],[strMachine],[strNUser]
                string sSQL = "INSERT INTO Acc_Voucher_Header";
                sSQL += " (intFy,byteFSemester,strVoucherNo,dateVoucher,strAccountNo,lngStudentNumber,isPrinted,strUserCreate,dateCreate,strMachine,strNUser,strRemark)";
                sSQL += " VALUES(" + iCYear + "," + iCSem + ",'" + sVoucher + "',GetDate(),'" + sAcc;
                sSQL += "','" + sSID + "',0,'" + sSID + "',GetDate(),'LOCALECT','" + sPmtSession + "','" + sPmtOrder + "')";
                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandText = sSQL;
                int iEffected = Cmd.ExecuteNonQuery();
                if (iEffected == 0)
                {
                    sVoucher = "";
                }
            }
            catch (Exception exp)
            {
                //divMsg.InnerText = exp.Message;
                lbl_Msg.Text = exp.Message;
                div_msg.Visible = true;
                sVoucher = "";
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }
            return sVoucher;
        }
        private string NewVoucher(int iCYear, int iCSem)
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
                // divMsg.InnerText = exp.Message;
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
        private int AddPayment(string sVoucher, string sPmtSession, string sPmtOrder, int iPaidFor, double dAmount, double dVat)
        {
            int iEffected = 0;
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            Conn.Open();
            try
            {

                string sSQL = "INSERT INTO Acc_Voucher_Detail";
                sSQL += " (intFy, byteFSemester, strVoucherNo, lngEntryNo, strAccountNo, datePayment, curDebit, curCredit, byteStatus, bytePaymentWay";
                sSQL += " , strUserCreate,dateCreate, strMachine, strNUser, intCampus, bytePaymentFor, curVat,LastAudit)";
                sSQL += " SELECT intFy, byteFSemester, strVoucherNo, 1 AS lngEntryNo, strAccountNo, GETDATE() AS datePayment, 0 AS curDebit, " + dAmount + " AS curCredit, 0 AS byteStatus, 6 AS bytePaymentWay,";
                sSQL += " strUserCreate, GETDATE() AS dateCreate, 'LOCALECT' AS strMachine, '" + sPmtOrder + "' AS strNUser, " + (int)Campus + " AS intCampus, " + iPaidFor + " AS bytePaymentFor, " + dVat + " AS curVat,0 as LastAudit";
                sSQL += " FROM  Acc_Voucher_Header";
                sSQL += " WHERE(strVoucherNo = '" + sVoucher + "')";


                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandText = sSQL;
                iEffected = Cmd.ExecuteNonQuery();
                if (iEffected == 0)
                {
                    //showErr("Payment Error");
                    lbl_Msg.Text = "Payment Error";
                    div_msg.Visible = true;
                }

            }
            catch (Exception exp)
            {
                //showErr("Payment Error");
                lbl_Msg.Text = "Payment Error";
                div_msg.Visible = true;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }
            return iEffected;
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
