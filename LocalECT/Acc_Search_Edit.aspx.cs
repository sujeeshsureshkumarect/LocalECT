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
    public partial class Acc_Search_Edit : System.Web.UI.Page
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
                if(Session["CurrentCampus"].ToString()=="Males")
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
                    //Fill_Student();
                    FillTerms();
                    Fill_Sponsors();
                    Fill_PaymentType();
                    iCYear = Convert.ToInt32(Session["CurrentYear"].ToString());
                    iCSem = Convert.ToInt32(Session["CurrentSemester"].ToString()); ;
                    iTerm = iCYear * 10 + iCSem;

                    if (Request.QueryString["sAcc"] != null && Request.QueryString["sAcc"] != "")
                    {
                        string sAcc = Request.QueryString["sAcc"];
                        Get_ACC(sAcc);
                        ddlOnlineStatus.SelectedIndex = getOnlineStatus(ddlIDs.Text);

                        bool isACCWanted = false;
                        int iFinCat = 0;

                        iFinCat = LibraryMOD.getFinanceCategory(ddlIDs.Text, out sOAcc);
                        Session["CurrentFinCat"] = iFinCat;
                        ddlFinanceCat.SelectedValue = iFinCat.ToString();

                        isACCWanted = LibraryMOD.isACCWanted(ddlIDs.Text, Campus);
                        ddlACCWanted.SelectedIndex = Convert.ToInt32(isACCWanted);
                    }
                    //Permissions Apply
                    if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_ACC_Search,
                      InitializeModule.enumPrivilege.ChangeOnlineStatus, CurrentRole) != true)
                    {
                        ddlOnlineStatus.Enabled = false;
                        ddlACCWanted.Enabled = false;
                    }
                    if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_ACC_Search,
                      InitializeModule.enumPrivilege.EditUpdate, CurrentRole) != true)
                    {
                        lnk_update.Enabled = false;
                        LinkButton1.Enabled = false;
                        lnk_Settings.Enabled = false;
                    }
                }
            }
            else
            {
                Session.RemoveAll();
                Response.Redirect("Login.aspx");
            }
        }
        private int getOnlineStatus(string sNo)
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            Conn.Open();
            int iStatus = 0;
            try
            {
                string sSQL = "SELECT intOnlineStatus FROM Reg_Student_Accounts WHERE [lngStudentNumber]='" + sNo + "'";
                SqlCommand Cmd = new SqlCommand(sSQL, Conn);
                iStatus = Convert.ToInt32("0" + Cmd.ExecuteScalar().ToString());

            }
            catch (Exception exp)
            {
                //Console.WriteLine("{0} Exception caught.", exp);
                //divMsg.InnerText = exp.Message;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }
            return iStatus;

        }

        protected void ddlOnlineStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(ddlIDs.Text))
                {                    
                    lbl_Msg.Text = "Select a student please or the students hasn't account yet.";
                    div_msg.Visible = true;
                    return;
                }
                int iStatus = 0;
                if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_ACC_Search,
                      InitializeModule.enumPrivilege.ChangeOnlineStatus, CurrentRole) != true)
                {
                    iStatus = getOnlineStatus(ddlIDs.Text);
                    ddlOnlineStatus.SelectedIndex = iStatus;                    
                    lbl_Msg.Text = "Sorry you cannot change online status for student";
                    div_msg.Visible = true;

                    return;
                }

                iStatus = ddlOnlineStatus.SelectedIndex;
                string sACC = lblACC.Text;//getStAcc(sSelectedValue.Value);
                UpdateStAcc(ddlIDs.Text, sACC, iStatus);
            }
            catch (Exception exp)
            {
                //Console.WriteLine("{0} Exception caught.", exp);
                //divMsg.InnerText = exp.Message;
            }
            finally
            {

            }
        }
        private void UpdateStAcc(string sSno, string sAcc, int iStatus)
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);           
            try
            {
                string sSQL = "";
                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                int iOnlineUser = getOnlineUser(sSno);
                if (iStatus == 0)
                {

                    Cmd.CommandText = "Delete_Online_User";
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.Add("@UserNo", SqlDbType.Int).Value = iOnlineUser;
                    Cmd.Parameters.Add("@sNo", SqlDbType.VarChar).Value = sSno;
                    Cmd.Parameters.Add("@sAccount", SqlDbType.VarChar).Value = sAcc;
                    Conn.Open();
                    Cmd.ExecuteNonQuery();
                    Conn.Close();
                }

                if (iStatus == 1)
                {
                    Cmd.CommandText = "Create_Online_User";
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.Add("@sNo", SqlDbType.VarChar).Value = sSno;
                    Cmd.Parameters.Add("@sAccount", SqlDbType.VarChar).Value = sAcc;
                    Cmd.Parameters.Add("@iRole", SqlDbType.Int).Value = 111;
                    Conn.Open();
                    Cmd.ExecuteNonQuery();
                    Conn.Close();
                }

                if (iStatus == 2)
                {
                    Cmd.CommandText = "Create_Online_User";
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.Add("@sNo", SqlDbType.VarChar).Value = sSno;
                    Cmd.Parameters.Add("@sAccount", SqlDbType.VarChar).Value = sAcc;
                    Cmd.Parameters.Add("@iRole", SqlDbType.Int).Value = 105;
                    Conn.Open();
                    Cmd.ExecuteNonQuery();
                    Conn.Close();
                }

                sSQL = "UPDATE Reg_Student_Accounts";
                sSQL += " SET intOnlineStatus =" + iStatus;
                sSQL += ",strUserSave='" + Session["CurrentUserName"].ToString() + "',dateLastSave=getDate()";
                sSQL += " Where strAccountNo='" + sAcc + "'";
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = sSQL;
                Conn.Open();
                Cmd.ExecuteNonQuery();
                Conn.Close();

                lbl_Msg.Text = "Online Status updated successfully";
                div_Alert.Attributes.Add("class", "alert alert-success alert-dismissible");
                div_msg.Visible = true;


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
        private int getOnlineUser(string sNo)
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            Conn.Open();
            int iOnlineUser = 0;
            try
            {
                string sSQL = "SELECT intOnlineUser FROM Reg_Student_Accounts  WHERE [lngStudentNumber]='" + sNo + "'";
                SqlCommand Cmd = new SqlCommand(sSQL, Conn);
                iOnlineUser = Convert.ToInt32("0" + Cmd.ExecuteScalar().ToString());

            }
            catch (Exception exp)
            {
                //Console.WriteLine("{0} Exception caught.", exp);
                //divMsg.InnerText = exp.Message;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }
            return iOnlineUser;

        }
        protected void ddlACCWanted_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(ddlIDs.Text))
                {
                    lbl_Msg.Text = "Select a student please or the students hasn't account yet.";
                    div_msg.Visible = true;
                    return;
                }
                bool bStatus = false;
                if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_ACC_Search,
                      InitializeModule.enumPrivilege.ChangeOnlineStatus, CurrentRole) != true)
                {
                    bStatus = LibraryMOD.isACCWanted(ddlIDs.Text, Campus);
                    ddlACCWanted.SelectedIndex = Convert.ToInt32(bStatus);                   
                    lbl_Msg.Text = "Sorry you cannot change online status for student";
                    div_msg.Visible = true;

                    return;
                }

                bStatus = Convert.ToBoolean(ddlACCWanted.SelectedIndex);
                string sNo = ddlIDs.Text;//getStAcc(sSelectedValue.Value);
                UpdateStACCWanted(sNo, ddlACCWanted.SelectedIndex);
            }
            catch (Exception exp)
            {
                //Console.WriteLine("{0} Exception caught.", exp);
                //divMsg.InnerText = exp.Message;
            }
            finally
            {

            }
        }
        private void UpdateStACCWanted(string sSno, int iStatus)
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            Conn.Open();
            try
            {
                string sSQL = "";
                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = Conn;


                //     ,[isACCWanted] = 

                sSQL = "UPDATE Reg_Applications";
                sSQL += " SET isACCWanted = " + iStatus;
                sSQL += ",strUserSave='" + Session["CurrentUserName"].ToString() + "',dateLastSave=getDate(),strMachine='localect',strNUser='" + Session["CurrentUserName"].ToString() + "'";
                sSQL += " WHERE lngStudentNumber='" + sSno + "'";
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = sSQL;
                Cmd.ExecuteNonQuery();

                lbl_Msg.Text = "Is Acc Wanted? updated successfully";
                div_Alert.Attributes.Add("class", "alert alert-success alert-dismissible");
                div_msg.Visible = true;

            }
            catch (Exception exp)
            {
                //Console.WriteLine("{0} Exception caught.", exp);
                lbl_Msg.Text = "Is Acc Wanted? not updated";
                div_msg.Visible = true;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }

        }
        protected void ddlFinanceCat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Session["CurrentFinCat"] != null)
            {
                int iFinCat = Convert.ToInt32(Session["CurrentFinCat"]);
                int iUser = Convert.ToInt32(Session["CurrentUserNo"]);
                bool isAllowed = ((LibraryMOD.isFinCatPermitted(iFinCat, iUser)) || (ddlSponsor.SelectedValue != "0" && iUser == 50));//Sponsor allowed for Anas
                if (!isAllowed)
                {
                    ddlFinanceCat.SelectedValue = iFinCat.ToString();                   
                    lbl_Msg.Text = "Sorry, You are not authorized to change (" + ddlFinanceCat.SelectedItem.Text + ") category";
                    div_msg.Visible = true;
                }
                else
                {
                    string sUser = Session["CurrentUserName"].ToString();
                    Session["CurrentFinCat"] = Convert.ToInt32(ddlFinanceCat.SelectedValue);
                    int iEffected = LibraryMOD.UpdateFinanceCategory(ddlIDs.Text, Convert.ToInt32(ddlFinanceCat.SelectedValue), sUser);
                    if (iEffected > 0)
                    {
                        lbl_Msg.Text = "Finance category updated to (" + ddlFinanceCat.SelectedItem.Text + ")";
                        div_Alert.Attributes.Add("class", "alert alert-success alert-dismissible");
                        div_msg.Visible = true;
                    }
                }
            }


            //ddlFinanceCat.SelectedValue = iFinCat.ToString();}
        }
        private void Get_ACC(string strAccountNo)
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            Conn.Open();
            try
            {
                //Clear_ACC(strAccountNo);
                string sSQL = "SELECT strAccountNo,strStudentName,lngStudentNumber,strPhone1,intRegYear,byteRegSem,byteType";
                sSQL += ",intDelegation,curDelegation,strDelegationNote,strNote,intOnlineStatus,intOnlineUser,strOnlinePWD,iAdmissionPaymentType,cAdmissionPaymentValue";
                sSQL += " FROM Reg_Student_Accounts";
                sSQL += " Where strAccountNo='" + strAccountNo + "'";
                SqlCommand Cmd = new SqlCommand(sSQL, Conn);
                SqlDataReader Rd = Cmd.ExecuteReader();
                while (Rd.Read())
                {
                    lblACC.Text = Rd["strAccountNo"].ToString();
                    ddlACCType.SelectedValue = Rd["byteType"].ToString();
                    txtName.Text = Rd["strStudentName"].ToString();
                    if (string.IsNullOrEmpty(Rd["lngStudentNumber"].ToString()))
                    {
                        ddlIDs.Text = "0";
                    }
                    else
                    {
                        ddlIDs.Text = Rd["lngStudentNumber"].ToString();
                    }
                    txtPhone.Text = Rd["strPhone1"].ToString();
                    txtNote.Text = Rd["strNote"].ToString();
                    if (string.IsNullOrEmpty(Rd["intDelegation"].ToString()))
                    {
                        ddlSponsor.SelectedValue = "0";
                    }
                    else
                    {
                        ddlSponsor.SelectedValue = Rd["intDelegation"].ToString();
                    }
                    if (string.IsNullOrEmpty(Rd["iAdmissionPaymentType"].ToString()))
                    {
                        drp_PaymentType.SelectedValue = "0";
                        hdn_Admission_Payment_Type.Value = "0";
                    }
                    else
                    {
                        drp_PaymentType.SelectedValue = Rd["iAdmissionPaymentType"].ToString();
                        hdn_Admission_Payment_Type.Value= Rd["iAdmissionPaymentType"].ToString();
                    }
                    if(Rd["iAdmissionPaymentType"].ToString()=="3")
                    {
                        txt_Value.Enabled = true;
                    }
                    if (string.IsNullOrEmpty(Rd["cAdmissionPaymentValue"].ToString()))
                    {
                        txt_Value.Text = "0";
                    }
                    else
                    {
                        txt_Value.Text = Rd["cAdmissionPaymentValue"].ToString();
                    }
                    //txt_Value.Text = Rd["cAdmissionPaymentValue"].ToString();
                    txtAmount.Text = Rd["curDelegation"].ToString();
                    txtRemarks.Text = Rd["strDelegationNote"].ToString();
                    //if (LibraryMOD.isFinanceProblems(Campus, ddlIDs.SelectedValue))
                    //{
                    //    rbnStatus.SelectedIndex = 0;
                    //}
                    //else
                    //{
                    //    rbnStatus.SelectedIndex = 1;
                    //}
                    //ddlOnlineStatus.SelectedValue = Rd["intOnlineStatus"].ToString();

                    ddlRegTerm.SelectedValue = Rd["intRegYear"].ToString() + Rd["byteRegSem"].ToString();
                    //ddlRegTerm1.SelectedValue = ddlRegTerm.SelectedValue;
                }
                Rd.Close();

            }
            catch (Exception exp)
            {
                //Console.WriteLine("{0} Exception caught.", exp);
                //divMsg.InnerText = exp.Message;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }

           // SqlCommand cmd=new SqlCommand
        }
        //private void Fill_Student()
        //{
        //    Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
        //    SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
        //    Conn.Open();
        //    try
        //    {
        //        ddlIDs.Items.Clear();
        //        ddlIDs.Items.Add(new ListItem("-", "0"));
        //        string sSQL = "SELECT lngStudentNumber FROM Reg_Applications order by lngStudentNumber desc";
        //        SqlCommand Cmd = new SqlCommand(sSQL, Conn);
        //        SqlDataReader Rd = Cmd.ExecuteReader();
        //        while (Rd.Read())
        //        {
        //            ddlIDs.Items.Add(new ListItem(Rd["lngStudentNumber"].ToString(), Rd["lngStudentNumber"].ToString()));
        //        }
        //        Rd.Close();

        //    }
        //    catch (Exception exp)
        //    {
        //        //Console.WriteLine("{0} Exception caught.", exp);
        //        //divMsg.InnerText = exp.Message;
        //    }
        //    finally
        //    {
        //        Conn.Close();
        //        Conn.Dispose();
        //    }
        //}

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
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }
            return isSet;
        }
        private void Fill_Sponsors()
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            Conn.Open();
            try
            {
                ddlSponsor.Items.Clear();
                ddlSponsor.Items.Add(new ListItem("-", "0"));
                string sSQL = "SELECT intDelegation,strDelegationDescEn FROM Lkp_Delegations";
                SqlCommand Cmd = new SqlCommand(sSQL, Conn);
                SqlDataReader Rd = Cmd.ExecuteReader();
                while (Rd.Read())
                {
                    ddlSponsor.Items.Add(new ListItem(Rd["strDelegationDescEn"].ToString(), Rd["intDelegation"].ToString()));
                }
                Rd.Close();

            }
            catch (Exception exp)
            {
                //Console.WriteLine("{0} Exception caught.", exp);
                //divMsg.InnerText = exp.Message;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
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
        private void Fill_PaymentType()
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            Conn.Open();
            try
            {
                drp_PaymentType.Items.Clear();
                //drp_PaymentType.Items.Add(new ListItem("-", "0"));
                string sSQL = "SELECT [iAdmissionPaymentType],[cAdmissionPaymentValue],[sAdmissionPaymentDesc] FROM [Lkp_AdmissionPayment]";
                SqlCommand Cmd = new SqlCommand(sSQL, Conn);
                SqlDataReader Rd = Cmd.ExecuteReader();
                while (Rd.Read())
                {
                    drp_PaymentType.Items.Add(new ListItem(Rd["sAdmissionPaymentDesc"].ToString(), Rd["iAdmissionPaymentType"].ToString()));
                }
                Rd.Close();

            }
            catch (Exception exp)
            {
                //Console.WriteLine("{0} Exception caught.", exp);
                //divMsg.InnerText = exp.Message;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }
        }

        protected void lnk_update_Click(object sender, EventArgs e)
        {
            if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_ACC_Search,
               InitializeModule.enumPrivilege.EditUpdate, CurrentRole) != true)
            {                
                lbl_Msg.Text = "Sorry you not allowed to update a student account.";
                div_msg.Visible = true;
                return;

            }

            if(drp_PaymentType.SelectedItem.Value=="3")
            {
                if(Convert.ToInt32(txt_Value.Text)>500)
                {
                    Update_Acc();
                }
                else
                {
                    lbl_Msg.Text = "Admission Payment Value needs to greater than 500.";
                    div_msg.Visible = true;
                }
            }
            else
            {
                Update_Acc();
            }
        }
        private void Update_Acc()
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
           

            try
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.CommandText = "Add_Account";
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Connection = Conn;
                Cmd.Parameters.Add("@strAccountNo", SqlDbType.VarChar).Value = lblACC.Text;
                Cmd.Parameters.Add("@strStudentName", SqlDbType.VarChar).Value = txtName.Text;
                Cmd.Parameters.Add("@lngStudentNumber", SqlDbType.VarChar).Value = ddlIDs.Text;
                Cmd.Parameters.Add("@strPhone1", SqlDbType.VarChar).Value = txtPhone.Text;
                Cmd.Parameters.Add("@byteAccountStatus", SqlDbType.SmallInt).Value = 0;
                int iTerm = Convert.ToInt32(ddlRegTerm.SelectedValue);
                int iYear = 0;
                int iSem = 0;
                iYear = LibraryMOD.SeperateTerm(iTerm, out iSem);
                Cmd.Parameters.Add("@intRegYear", SqlDbType.Int).Value = iYear;
                Cmd.Parameters.Add("@byteRegSem", SqlDbType.SmallInt).Value = iSem;
                Cmd.Parameters.Add("@intDelegation", SqlDbType.Int).Value = Convert.ToInt32(ddlSponsor.SelectedValue);
                Cmd.Parameters.Add("@curDelegation", SqlDbType.Decimal).Value = Convert.ToDecimal(txtAmount.Text);
                Cmd.Parameters.Add("@strDelegationNote", SqlDbType.VarChar).Value = txtRemarks.Text;
                Cmd.Parameters.Add("@strNote", SqlDbType.VarChar).Value = txtNote.Text;
                Cmd.Parameters.Add("@byteType", SqlDbType.SmallInt).Value = Convert.ToInt32(ddlACCType.SelectedValue);
                Cmd.Parameters.Add("@intOnlineStatus", SqlDbType.Int).Value = Convert.ToInt32(ddlOnlineStatus.SelectedValue);
                //Cmd.Parameters.Add("@intOnlineUser", SqlDbType.Int).Value = 0;
                //Cmd.Parameters.Add("@strOnlinePWD", SqlDbType.VarChar).Value = "";
                string sUser = Session["CurrentUserName"].ToString();
                Cmd.Parameters.Add("@sUser", SqlDbType.VarChar).Value = sUser;
                Conn.Open();
                Cmd.ExecuteNonQuery();
                Conn.Close();

                //if (ddlIDs.Text != "0")
                //{
                //    Cmd.CommandText = "UPDATE Reg_Applications SET bOtherCollege =" + rbnStatus.SelectedValue + "  WHERE lngStudentNumber='" + ddlIDs.SelectedValue + "'";
                //    Cmd.CommandType = CommandType.Text;
                //    Cmd.ExecuteNonQuery();
                //}

                SqlCommand cmd1 = new SqlCommand("update Reg_Student_Accounts set iAdmissionPaymentType=@iAdmissionPaymentType,cAdmissionPaymentValue=@cAdmissionPaymentValue where strAccountNo=@strAccountNo", Conn);
                cmd1.Parameters.AddWithValue("@iAdmissionPaymentType", drp_PaymentType.SelectedItem.Value);
                cmd1.Parameters.AddWithValue("@cAdmissionPaymentValue", txt_Value.Text.Trim());
                cmd1.Parameters.AddWithValue("@strAccountNo", lblACC.Text);
                try
                {
                    Conn.Open();
                    cmd1.ExecuteNonQuery();
                    Conn.Close();
                }
                catch(Exception ex)
                {
                    Conn.Close();
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Conn.Close();
                }

                //Update Opportunity-Pending Payment

                //if(hdn_Admission_Payment_Type.Value=="0" && Convert.ToInt32(drp_PaymentType.SelectedItem.Value)>0)
                //{
                //    //New Change by Accounts Team
                //    int iOpportunity = 0;
                //    if (isOpportunitySet(ddlIDs.Text, out iOpportunity))
                //    {
                //        //lbl_Msg.Text = "Opportunity must be set one time only.";
                //        //div_msg.Visible = true;
                //        if (iOpportunity > 0)
                //        {
                //            //this.ClientScript.RegisterStartupScript(this.GetType(), "test", "setOpportunity();", true);
                //            ServicePointManager.Expect100Continue = true;
                //            ServicePointManager.DefaultConnectionLimit = 9999;
                //            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
                //            string accessToken = InitializeModule.CxPwd;

                //            using (var httpClient = new HttpClient())
                //            {
                //                using (var request = new HttpRequestMessage(new HttpMethod("GET"), "https://ect.custhelp.com/services/rest/connect/v1.4/opportunities/" + iOpportunity + ""))
                //                {
                //                    request.Headers.TryAddWithoutValidation("Authorization", accessToken);
                //                    request.Headers.TryAddWithoutValidation("OSvC-CREST-Application-Context", "application/x-www-form-urlencoded");

                //                    request.Content = new StringContent("{\n\t\"customFields\": {\n\t\t\"c\": {\n\t\t\t\"paymentstatus\": {\n                \"id\": 1094,\n                \"lookupName\": \"Payment Succeeded\"\n            }\n\t\t}\n\t},\n\t\"statusWithType\": {\n        \"status\": {\n            \"id\": 11\n        }\n    }\n}");
                //                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                //                    var task = httpClient.SendAsync(request);
                //                    task.Wait();
                //                    var response = task.Result;
                //                    string s = response.Content.ReadAsStringAsync().Result;
                //                    //If Status 200
                //                    //if (response.IsSuccessStatusCode == true)
                //                    //{
                //                    //    SetOpportunity(sSID);
                //                    //}
                //                }
                //            }
                //        }
                //    }
                //    else
                //    {
                //        //lbl_Msg.Text = "Opportunity must be set one time only.";
                //        //div_msg.Visible = true;
                //        if (iOpportunity > 0)
                //        {
                //            //this.ClientScript.RegisterStartupScript(this.GetType(), "test", "setOpportunity();", true);
                //            ServicePointManager.Expect100Continue = true;
                //            ServicePointManager.DefaultConnectionLimit = 9999;
                //            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
                //            string accessToken = InitializeModule.CxPwd;

                //            using (var httpClient = new HttpClient())
                //            {
                //                using (var request = new HttpRequestMessage(new HttpMethod("GET"), "https://ect.custhelp.com/services/rest/connect/v1.4/opportunities/" + iOpportunity + ""))
                //                {
                //                    request.Headers.TryAddWithoutValidation("Authorization", accessToken);
                //                    request.Headers.TryAddWithoutValidation("OSvC-CREST-Application-Context", "application/x-www-form-urlencoded");

                //                    request.Content = new StringContent("{\n\t\"customFields\": {\n\t\t\"c\": {\n\t\t\t\"paymentstatus\": {\n                \"id\": 1094,\n                \"lookupName\": \"Payment Succeeded\"\n            }\n\t\t}\n\t},\n\t\"statusWithType\": {\n        \"status\": {\n            \"id\": 11\n        }\n    }\n}");
                //                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                //                    var task = httpClient.SendAsync(request);
                //                    task.Wait();
                //                    var response = task.Result;
                //                    string s = response.Content.ReadAsStringAsync().Result;
                //                    //If Status 200
                //                    //if (response.IsSuccessStatusCode == true)
                //                    //{
                //                    //    SetOpportunity(sSID);
                //                    //}
                //                }
                //            }
                //        }
                //    }
                //}


                lbl_Msg.Text = "Data Updated Successfully";
                div_Alert.Attributes.Add("class", "alert alert-success alert-dismissible");
                div_msg.Visible = true;
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
                Conn.Dispose();
            }
        }
        protected void lnk_Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Acc_Search");
        }

        protected void drp_PaymentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drp_PaymentType.SelectedItem.Value == "1")
            {
                txt_Value.Text = "3500";
                txt_Value.Enabled = false;
            }
            else if (drp_PaymentType.SelectedItem.Value == "2")
            {
                txt_Value.Text = "0";
                txt_Value.Enabled = false;
            }
            else if (drp_PaymentType.SelectedItem.Value == "3")
            {
                txt_Value.Text = "0";
                txt_Value.Enabled = true;
            }
            else
            {
                txt_Value.Text = "0";
                txt_Value.Enabled = false;
            }
        }
        protected void ddlRegTerm1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(lblACC.Text))
                {                 
                    lbl_Msg.Text = "Select a student please or the students hasn't account yet.";
                    div_msg.Visible = true;
                }
                int iTerm = 0;
                if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_ACC_Search,
                      InitializeModule.enumPrivilege.ChangeOnlineStatus, CurrentRole) != true)
                {
                    iTerm = int.Parse(ddlRegTerm.SelectedValue);
                    //ddlRegTerm1.SelectedValue = ddlRegTerm.SelectedValue;                
                    lbl_Msg.Text = "Sorry you cannot change reg term for student";
                    div_msg.Visible = true;
                    return;
                }

                iTerm = int.Parse(ddlRegTerm.SelectedValue);
                string sAccount = lblACC.Text;//getStAcc(sSelectedValue.Value);
                UpdateRegTerm(sAccount, iTerm);
            }
            catch (Exception exp)
            {
                //Console.WriteLine("{0} Exception caught.", exp);
                //divMsg.InnerText = exp.Message;
            }
            finally
            {

            }
        }

        private void UpdateRegTerm(string sAccount, int iTerm)
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            Conn.Open();
            try
            {
                string sSQL = "";
                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                int iYear = 0;
                int iSem = 0;
                iYear = LibraryMOD.SeperateTerm(iTerm, out iSem);


                sSQL = "UPDATE Reg_Student_Accounts";
                sSQL += " SET intRegYear =" + iYear + " , byteRegSem =" + iSem;
                sSQL += ",strUserSave='" + Session["CurrentUserName"].ToString() + "',dateLastSave=getDate(),strMachine='localect',strNUser='" + Session["CurrentUserName"].ToString() + "'";
                sSQL += " WHERE strAccountNo='" + sAccount + "'";

                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = sSQL;
                Cmd.ExecuteNonQuery();
                ddlRegTerm.SelectedValue = ddlRegTerm.SelectedValue;
                lbl_Msg.Text = "Reg Term updated successfully";
                div_Alert.Attributes.Add("class", "alert alert-success alert-dismissible");
                div_msg.Visible = true;
            }
            catch (Exception exp)
            {
                //Console.WriteLine("{0} Exception caught.", exp);
                lbl_Msg.Text = "Reg Term not updated";
                div_msg.Visible = true;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }

        }
        protected void lnk_Settings_Click(object sender, EventArgs e)
        {
            ddlOnlineStatus_SelectedIndexChanged(null,null);
            ddlFinanceCat_SelectedIndexChanged(null, null);
            ddlACCWanted_SelectedIndexChanged(null, null);
            ddlRegTerm1_SelectedIndexChanged(null, null);
        }
    }
}