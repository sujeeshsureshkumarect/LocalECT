using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Printing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LocalECT
{
    public partial class Student_Details : System.Web.UI.Page
    {
        InitializeModule.EnumCampus Campus = InitializeModule.EnumCampus.Females;
        string constr = ConfigurationManager.ConnectionStrings["ECTDataFemales"].ConnectionString;
        int CurrentRole = 0;
        int iCYear = 0;
        int iCSem = 0;
        int iTerm = 0;
        string sOAcc = "";
        string sNo = "";

        protected void Search1_ChangedEvent(object Sender, EventArgs e)
        {
            //sSelectedValue.Value = e.SValue1;
            //sSelectedText.Value = e.SValue3;

            if (Request.QueryString["sAcc"] != null && Request.QueryString["sAcc"] != "")
            {
                string sAcc = Request.QueryString["sAcc"];
                //Get_ACC(sAcc);
                sSelectedText.Value = sAcc;
            }
            if (Request.QueryString["sid"] != null && Request.QueryString["sid"] != "")
            {
                sNo = Request.QueryString["sid"];
                Get_ACC(sNo);
                //sSelectedText.Value = sNo;
            }

            //TMDS.DataBind();
            //ddlOnlineStatus.SelectedIndex = getOnlineStatus(sSelectedValue.Value);

            bool isACCWanted = false;
            bool isFainance = false;
            int iFinCat = 0;

            //iFinCat = LibraryMOD.getFinanceCategory(sSelectedValue.Value, out sOAcc);
            //Session["CurrentFinCat"] = iFinCat;
            //ddlFinanceCat.SelectedValue = iFinCat.ToString();

            //isACCWanted = LibraryMOD.isACCWanted(sSelectedValue.Value, Campus);
            //isFainance = LibraryMOD.isFinanceProblems(Campus, sSelectedValue.Value);

            //ddlACCWanted.SelectedIndex = Convert.ToInt32(isACCWanted);
            //ddlFinance.SelectedIndex = Convert.ToInt32(isFainance);


            Fill_Factors();
            grdTimeTable.DataBind();
            grdFees.DataBind();
            grdDiscounts.DataBind();
            grdPayment.DataBind();
            grdVH.DataBind();
            grdVD.DataBind();
            //Get_ACC(sSelectedText.Value);
            MultiView1.ActiveViewIndex = 0;
        }
        protected void Search1_NewEvent(object Sender, EventArgs e)
        {
            divAccNotification.InnerText = "";
            //divAccNotification.Visible = false;
            sSelectedValue.Value = "";
            sSelectedText.Value = "";

            Session["CurrentFinCat"] = 0;
            ddlFinanceCat.SelectedValue = "0";

            ddlOnlineStatus.SelectedIndex = 0;
            ddlACCWanted.SelectedIndex = 0;
            ddlFinance.SelectedIndex = 0;

            lblMajorCaption.Visible = false;
            lblCGPACaption.Visible = false;

            lblMajor.Visible = false;
            lblCGPA.Visible = false;

            lblArNameCaption.Visible = false;
            lblArName.Visible = false;
            lblFTRCaption.Visible = false;
            lblFTR.Visible = false;
            lblLastDisCaption.Visible = false;
            lstDis.Items.Clear();
            lstDis.Visible = false;
            lblRefCaption.Visible = false;
            lblRef.Visible = false;
            lblLastRefDisCaption.Visible = false;
            lstRefDis.Items.Clear();
            lstRefDis.Visible = false;
            lblOBalanceCVAT.Visible = false;
            lblOBalanceVATBTS.Visible = false;
            lblOBalanceVATCaption.Visible = false;
            lblOBalanceVATCaptionBTS.Visible = false;
            lblLTRBS.Visible = false;
            lblLTRCaption.Visible = false;

            lblRegM.Text = "0";
            lblRegF.Text = "0";
            lblPReg.Text = "0";
            lblPRegGen.Text = "0";
            lblPRegCore.Text = "0";

            lblCReg.Text = "0";
            lblCRegGen.Text = "0";
            lblCRegCore.Text = "0";

            lblCompleted.Text = "0";
            lblCompletedGen.Text = "0";
            lblCompletedCore.Text = "0";

            lblRate.Text = "";

            lblTotal.Text = "0";
            lblTotalGen.Text = "0";
            lblTotalCore.Text = "0";

            lblRemaining.Text = "0";
            lblRemainingGen.Text = "0";
            lblRemainingCore.Text = "0";

            lblOBalanceVAT.Text = "";
            lblOBalanceVATBTS.Text = "";
            lblLTRBS.Text = "0";

            //TMDS.DataBind();
            grdTimeTable.DataBind();
            grdFees.DataBind();
            grdDiscounts.DataBind();
            grdPayment.DataBind();
            grdVH.DataBind();
            grdVD.DataBind();
            Clear_ACC("");
            Empty_Payment_Controls(0);
            MVPayemnt.ActiveViewIndex = 0;
            MultiView1.ActiveViewIndex = 0;
            txtText.Text = "";
            txtPaid.Text = "0";
            txtRemind.Text = "0";
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            //Add Event Handler to the custom control
            //Search1.ChangedEvent += new Search.ChangedEventHandler(Search1_ChangedEvent);
            //Search1.NewEvent += new Search.ChangedEventHandler(Search1_NewEvent);

            divMsg.InnerText = "";

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
                    string sCash = "";
                    string sPrinter = "";
                    sCash = GetCookie("CurrentCash");
                    sPrinter = GetCookie("CurrentPrinter");
                    txtPrinter.Text = sPrinter;
                    if (!string.IsNullOrEmpty(sCash))
                    {
                        rbnCash.SelectedValue = sCash;
                    }
                    else
                    {
                        rbnCash.SelectedValue = "1";
                        divMsg.InnerText = "Sorry you cannot create a new payment , Cash not set yet.";
                        New_Voucher_btn.Enabled = false;
                    }
                    rbnCash.Enabled = LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Student_Data,
                            InitializeModule.enumPrivilege.ACCChangeCash, CurrentRole);
                    txtPrinter.Enabled = rbnCash.Enabled;

                    if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Student_Data,
                    InitializeModule.enumPrivilege.ShowBrowse, CurrentRole) != true)
                    {
                        Server.Transfer("Authorization.aspx");

                    }


                    if (Request.QueryString["Msg"] != null)
                    {
                        divMsg.InnerText = Request.QueryString["Msg"];
                    }
                    else
                    {
                        divMsg.InnerText = "";
                    }
                    Fill_Student();
                    FillTerms();
                    Fill_Sponsors();
                    iCYear = Convert.ToInt32(Session["CurrentYear"].ToString());
                    iCSem = Convert.ToInt32(Session["CurrentSemester"].ToString()); ;
                    iTerm = iCYear * 10 + iCSem;
                    Terms.SelectedValue = iTerm.ToString();
                    TestimonyTerm.SelectedValue = iTerm.ToString();
                }
                else
                {
                    iTerm = Convert.ToInt32(Terms.SelectedValue);

                    iCYear = LibraryMOD.SeperateTerm(iTerm, out iCSem);

                }
            }
            else
            {
                Session.RemoveAll();
                Response.Redirect("Login.aspx");
            }


            if (!IsPostBack)
            {
                if (Session["CurrentCampus"] != null)
                {
                    //string sCampus = Session["CurrentCampus"].ToString();
                    Campus = (InitializeModule.EnumCampus)Session["CurrentCampus"];
                    Campus_ddl.SelectedValue = ((int)Campus).ToString();
                }

                Session["CurrentStudent"] = null;
            }
            else
            {
                Campus = (InitializeModule.EnumCampus)int.Parse(Campus_ddl.SelectedValue);

            }
            Session["CurrentCampus"] = Campus;
            //Search1.Campus = Campus;
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            TMDS.ConnectionString = myConnection_String.Conn_string;
            TMDS.DataBind();
            DiscountDS.ConnectionString = myConnection_String.Conn_string;
            DiscountDS.DataBind();

            ChequesDS.ConnectionString = myConnection_String.Conn_string;
            ChequesDS.DataBind();

            FeesDS.ConnectionString = myConnection_String.Conn_string;
            FeesDS.DataBind();


            PaymentDS.ConnectionString = myConnection_String.Conn_string;
            PaymentDS.DataBind();

            VHDS.ConnectionString = myConnection_String.Conn_string;
            VHDS.DataBind();
            VDDS.ConnectionString = myConnection_String.Conn_string;
            VDDS.DataBind();
            BankDS.ConnectionString = myConnection_String.Conn_string;
            BankDS.DataBind();
            if (!IsPostBack)
            {
                Search1_ChangedEvent(null, null);
                Get_Student_Advising();
                //System.Web.UI.WebControls.Table myTable;
                //List<MirrorCLS> myList = (List<MirrorCLS>)Session["myList"];
                //myTable = Create_Table(myList[0]);
                //divPlan.Controls.Clear();
                //divPlan.Controls.Add(myTable);
                getopportunity(sNo);
            }
            System.Web.UI.WebControls.Table myTable;
            List<MirrorCLS> myList = (List<MirrorCLS>)Session["myList"];
            myTable = Create_Table(myList[0]);
            divPlan.Controls.Clear();
            divPlan.Controls.Add(myTable);
        }

        public void getopportunity(string sNo)
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection sc = new SqlConnection(myConnection_String.Conn_string);
            SqlCommand cmd = new SqlCommand("select * from Reg_Applications where lngStudentNumber=@lngStudentNumber", sc);
            cmd.Parameters.AddWithValue("@lngStudentNumber",sNo);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                if(dt.Rows.Count>0)
                {
                    hdn_iOpportunityID.Value = dt.Rows[0]["iOpportunityID"].ToString();
                    //hdn_Serial.Value = dt.Rows[0]["lngSerial"].ToString();
                    string isOpportunitySet = "0";
                    if(dt.Rows[0]["isOpportunitySet"].ToString()=="True")
                    {
                        isOpportunitySet = "1";
                        drp_setstatus.SelectedIndex = drp_setstatus.Items.IndexOf(drp_setstatus.Items.FindByValue(isOpportunitySet));
                    }
                    else
                    {
                        drp_setstatus.SelectedIndex = drp_setstatus.Items.IndexOf(drp_setstatus.Items.FindByValue(isOpportunitySet));
                    }

                    SqlCommand cmd1 = new SqlCommand("select strPhone1 from Reg_Students_Data where lngSerial=@lngSerial", sc);
                    cmd1.Parameters.AddWithValue("@lngSerial", dt.Rows[0]["lngSerial"].ToString());
                    DataTable dt1 = new DataTable();
                    SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                    try
                    {
                        sc.Open();
                        da1.Fill(dt1);
                        sc.Close();

                        if(dt1.Rows.Count>0)
                        {
                            hdn_Phone1.Value = dt1.Rows[0]["strPhone1"].ToString();
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

        private System.Web.UI.WebControls.Table Create_Table(MirrorCLS myMirror)
        {
            System.Web.UI.WebControls.Table MyTable = new System.Web.UI.WebControls.Table();
            try
            {
                //First Row
                MyTable.Width = Unit.Percentage(100);
                MyTable.BorderWidth = 1;
                MyTable.GridLines = GridLines.Horizontal;
                MyTable.ID = "tblDetail";

                TableHeaderRow Hr = new TableHeaderRow();
                TableHeaderCell Hc = new TableHeaderCell();
                TableCell Hd = new TableCell();
                Hc.ColumnSpan = 4;
                Hc.Text = "Student Information";
                Hr.Cells.Add(Hc);
                MyTable.Rows.Add(Hr);

                //No
                Hr = new TableHeaderRow();

                Hc = new TableHeaderCell();
                Hc.Text = "No : ";
                Hr.Cells.Add(Hc);

                Hd = new TableCell();
                Hd.Text = sNo;
                Hr.Cells.Add(Hd);
                //Name
                Hc = new TableHeaderCell();
                Hc.Text = "Name : ";
                Hr.Cells.Add(Hc);

                Hd = new TableCell();
                Hd.Text = txtName.Text;
                Hr.Cells.Add(Hd);

                MyTable.Rows.Add(Hr);


                //Second Row
                Hr = new TableHeaderRow();

                Hc = new TableHeaderCell();
                Hc.Text = "Major : ";
                Hr.Cells.Add(Hc);

                Hd = new TableCell();
                Hd.ColumnSpan = 3;
                Hd.Text = myMirror.Major;
                Hr.Cells.Add(Hd);

                MyTable.Rows.Add(Hr);
                //----------------------------------------
                //Hc = new TableHeaderCell();
                //Hc.Text = "Registered Courses : ";
                //Hr.Cells.Add(Hc);

                //Hd = new TableCell();
                ////Hd.ColumnSpan = 3;
                //Hd.Text = Convert.ToString(LibraryMOD.GetRegCoursesPrevSem(sNo, iRegYear, iRegSem, (InitializeModule.EnumCampus)Campus));

                //Hr.Cells.Add(Hd);

                //MyTable.Rows.Add(Hr);
                //-------------------------------------------
                //Third Row
                Hr = new TableHeaderRow();

                Hc = new TableHeaderCell();
                Hc.Text = "CGPA : ";
                Hr.Cells.Add(Hc);

                Hd = new TableCell();
                if (myMirror.CGPA != 101)
                {
                    Hd.Text = string.Format("{0:F}", myMirror.CGPA);
                }

                Hr.Cells.Add(Hd);

                Hc = new TableHeaderCell();
                Hc.Text = "ESL : ";
                Hr.Cells.Add(Hc);

                Hd = new TableCell();
                //Get Max Esl
                for (int i = 0; i < 5; i++)
                {
                    if (myMirror.Mirror[i].isPassed)
                    {
                        Hd.Text = myMirror.Mirror[i].sCourse;
                        myMirror.MaxESL = i;

                    }

                }
                Hr.Cells.Add(Hd);

                MyTable.Rows.Add(Hr);

                //Fourth Row
                Hr = new TableHeaderRow();

                Hc = new TableHeaderCell();
                Hc.Text = "ENG : ";
                Hr.Cells.Add(Hc);

                Hd = new TableCell();
                Hd.Text = myMirror.ENG;
                Hr.Cells.Add(Hd);

                Hc = new TableHeaderCell();
                Hc.Text = "Score : ";
                Hr.Cells.Add(Hc);

                Hd = new TableCell();

                Hd.Text = string.Format("{0:F}", myMirror.Score); ;

                Hr.Cells.Add(Hd);

                MyTable.Rows.Add(Hr);




            }
            catch (Exception ex)
            {
                LibraryMOD.ShowErrorMessage(ex);

            }
            finally
            {


            }
            return MyTable;
        }
        private void Get_Student_Advising()
        {
            int iRegYear = 0;
            int iRegSem = 0;
            iRegYear = (int)Session["RegYear"];
            iRegSem = (int)Session["RegSemester"];
            List<MirrorCLS> myMirror = new List<MirrorCLS>();
            Advising myAdvising = new Advising();
            Plans Plan = new Plans();
            try
            {
                Session["myList"] = null;
                Session["myPlan"] = null;

                int iYear = iRegYear;
                int iSem = iRegSem;
                //Is Grades Hidden
                bool isHidden = LibraryMOD.isGradesHidden(Campus);
                myMirror = myAdvising.GetAdvising(sNo, true, iYear, iSem, true, isHidden, out Plan, Campus, Session["sCSemester"].ToString());
                int i = myMirror.Count;
                int iRec = myMirror[0].Recommended.Count;

            }
            catch (Exception exp)
            {
                Console.WriteLine("{0} Exception caught.", exp);
                lbl_Msg.Text = exp.Message;
                div_msg.Visible = true;
            }
            finally
            {
                Session["myList"] = myMirror;
                Session["myPlan"] = Plan;

            }
        }


        protected void lnk_Command(object sender, CommandEventArgs e)
        {
            LinkButton lnk = (LinkButton)sender;
            if (string.IsNullOrEmpty(sSelectedText.Value))
            {

                //divMsg.InnerText = "Select Student Please ...";
                lbl_Msg.Text = "Select Student Please ...";
                div_msg.Visible = true;
                return;

            }

            //else
            //{
            //    Session["CurrentStudent"] = sSelectedValue.Value;
            //    Session["CurrentStudentName"] = sSelectedText.Value;
            //    Session["CurrentCampus"] = Campus;
            //    Session["StudentSerialNo"] = GetSerial(sSelectedValue.Value);
            //}

            switch (lnk.ID)
            {
                case "Balance_lnk":
                    MultiView1.ActiveViewIndex = 0;
                    break;
                case "Account_lnk":

                    MultiView1.ActiveViewIndex = 1;
                    break;

                case "New_lnk":
                    if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_ACC_Search,
                    InitializeModule.enumPrivilege.AddNew, CurrentRole) != true)
                    {
                        //divMsg.InnerText = "Sorry you not allowed to add a student account.";
                        lbl_Msg.Text = "Sorry you not allowed to add a student account.";
                        div_msg.Visible = true;
                        return;

                    }
                    MultiView1.ActiveViewIndex = 1;
                    Clear_ACC("");
                    lblACC.Text = Get_New_Acc();
                    grdTimeTable.DataBind();
                    grdFees.DataBind();
                    grdDiscounts.DataBind();
                    break;
                case "Testimony_Lnk":
                    if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_ACC_Search,
                    InitializeModule.enumPrivilege.AddNew, CurrentRole) != true)
                    {
                        //divMsg.InnerText = "Sorry you not allowed to add a student account.";
                        lbl_Msg.Text = "Sorry you not allowed to add a student account.";
                        div_msg.Visible = true;
                        return;

                    }
                    MultiView1.ActiveViewIndex = 2;

                    break;

                case "Cheques_lnk":
                    MultiView1.ActiveViewIndex = 3;
                    break;

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
                    Terms.Items.Add(new ListItem(myTerms[i].ShortDesc, myTerms[i].Term.ToString()));
                    ddlRegTerm.Items.Add(new ListItem(myTerms[i].ShortDesc, myTerms[i].Term.ToString()));
                    ddlRegTerm1.Items.Add(new ListItem(myTerms[i].ShortDesc, myTerms[i].Term.ToString()));
                    TestimonyTerm.Items.Add(new ListItem(myTerms[i].ShortDesc, myTerms[i].Term.ToString()));

                }

            }
            catch (Exception ex)
            {


                LibraryMOD.ShowErrorMessage(ex);
                //divMsg.InnerText = ex.Message;
                lbl_Msg.Text = ex.Message;
                div_msg.Visible = true;
            }
            finally
            {
                myTerms.Clear();

            }
        }


        protected void Terms_SelectedIndexChanged(object sender, EventArgs e)
        {

            TMDS.DataBind();
            grdTimeTable.DataBind();
            grdFees.DataBind();
            grdPayment.DataBind();
            grdVH.DataBind();
            grdVD.DataBind();
            Clear_ACC("");
            Empty_Payment_Controls(0);
            MVPayemnt.ActiveViewIndex = 0;
            Fill_Factors();
        }


        //protected void PrintCMD_Click(object sender, ImageClickEventArgs e)
        //{
        //    Retrieve();
        //    ExportStudentTimeTable();
        //}
        //private void Retrieve()
        //{
        //    List<TimeTable> myTimeTables = new List<TimeTable>();
        //    TimeTableDAL myTimeTableDAL = new TimeTableDAL();
        //    DataSet Ds = new DataSet();
        //    try
        //    {

        //        int iTerm = Convert.ToInt32(Terms.SelectedValue);

        //        int iSem = 0;
        //        int iYear = LibraryMOD.SeperateTerm(iTerm, out iSem);
        //        //Convert.ToInt32("0" + Session["RegYear"].ToString());


        //        string sStudentNumber = sSelectedValue.Value   ;

        //        myTimeTables = myTimeTableDAL.GetStudentTimeTable(sStudentNumber, iYear, iSem, this.Campus);
        //        Ds = Prepare_TimeTable_Report(myTimeTables);

        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("{0} Exception caught.", ex.Message);
        //    }
        //    finally
        //    {

        //        Session["ReportDS"] = Ds;

        //    }

        //}
        //private string GetCaption()
        //{
        //    string sCaption = "";
        //    try
        //    {

        //        sCaption = sSelectedValue.Value + " - " + sSelectedText.Value;

        //    }
        //    catch (Exception exp)
        //    {
        //        Console.WriteLine("{0} Exception caught.", exp);
        //        divMsg.InnerText = exp.Message;
        //    }

        //    return sCaption;
        //}
        //private DataSet Prepare_TimeTable_Report(List<TimeTable> myTimeTable)
        //{
        //    DataTable dt = new DataTable();
        //    DataRow dr;
        //    DataSet ds = new DataSet();
        //    try
        //    {
        //        DataColumn dc;

        //        dc = new DataColumn("iSerial", Type.GetType("System.Int32"));
        //        dt.Columns.Add(dc);
        //        dc = new DataColumn("iPeriod", Type.GetType("System.Int32"));
        //        dt.Columns.Add(dc);
        //        dc = new DataColumn("sPeriod", Type.GetType("System.String"));
        //        dt.Columns.Add(dc);
        //        dc = new DataColumn("sCourse", Type.GetType("System.String"));
        //        dt.Columns.Add(dc);
        //        dc = new DataColumn("sDesc", Type.GetType("System.String"));
        //        dt.Columns.Add(dc);
        //        dc = new DataColumn("iClass", Type.GetType("System.Int32"));
        //        dt.Columns.Add(dc);
        //        dc = new DataColumn("dFrom", Type.GetType("System.String"));
        //        dt.Columns.Add(dc);
        //        dc = new DataColumn("dTo", Type.GetType("System.String"));
        //        dt.Columns.Add(dc);
        //        dc = new DataColumn("iLecturer", Type.GetType("System.Int32"));
        //        dt.Columns.Add(dc);
        //        dc = new DataColumn("sLecturer", Type.GetType("System.String"));
        //        dt.Columns.Add(dc);
        //        dc = new DataColumn("iDays", Type.GetType("System.Int32"));
        //        dt.Columns.Add(dc);
        //        dc = new DataColumn("sDay", Type.GetType("System.String"));
        //        dt.Columns.Add(dc);
        //        dc = new DataColumn("sHall", Type.GetType("System.String"));
        //        dt.Columns.Add(dc);
        //        int Serial = 0;
        //        for (int i = 0; i < myTimeTable.Count; i++)
        //        {
        //            dr = dt.NewRow();
        //            Serial += 1;
        //            dr["iSerial"] = Serial;
        //            dr["sPeriod"] = myTimeTable[i].SPeriod;
        //            dr["sCourse"] = myTimeTable[i].SCourse;
        //            dr["sDesc"] = myTimeTable[i].SDesc;
        //            dr["iClass"] = myTimeTable[i].IClass;
        //            //add Times
        //            dr["sLecturer"] = myTimeTable[i].ClassTimes[0]._sLecturer;
        //            dr["dFrom"] = myTimeTable[i].ClassTimes[0]._dFrom.ToShortTimeString();
        //            dr["dTo"] = myTimeTable[i].ClassTimes[0]._dTo.ToShortTimeString();
        //            dr["iDays"] = myTimeTable[i].ClassTimes[0]._iDays;
        //            dr["sDay"] = myTimeTable[i].ClassTimes[0]._sDays + "  " + myTimeTable[i].ClassTimes[0]._sNotes;
        //            dr["sHall"] = myTimeTable[i].ClassTimes[0]._sHall + " | " + myTimeTable[i].ClassTimes[0]._sCampus;
        //            dt.Rows.Add(dr);
        //            //Collect Additional Times
        //            for (int j = 1; j < myTimeTable[i].ClassTimes.Count; j++)
        //            {
        //                dr = dt.NewRow();
        //                Serial += 1;
        //                dr["iSerial"] = Serial;
        //                dr["sPeriod"] = myTimeTable[i].SPeriod;
        //                dr["sCourse"] = myTimeTable[i].SCourse;
        //                dr["sDesc"] = myTimeTable[i].SDesc;
        //                dr["iClass"] = myTimeTable[i].IClass;
        //                dr["sLecturer"] = myTimeTable[i].ClassTimes[j]._sLecturer;
        //                dr["dFrom"] = myTimeTable[i].ClassTimes[j]._dFrom.ToShortTimeString();
        //                dr["dTo"] = myTimeTable[i].ClassTimes[j]._dTo.ToShortTimeString();
        //                dr["iDays"] = myTimeTable[i].ClassTimes[j]._iDays;
        //                dr["sDay"] = myTimeTable[i].ClassTimes[j]._sDays + "  " + myTimeTable[i].ClassTimes[j]._sNotes;
        //                dr["sHall"] = myTimeTable[i].ClassTimes[j]._sHall + " | " + myTimeTable[i].ClassTimes[0]._sCampus;
        //                dt.Rows.Add(dr);
        //            }


        //        }
        //        dt.TableName = "StudentTimeTable";
        //        dt.AcceptChanges();
        //        ds.Tables.Add(dt);

        //    }
        //    catch (Exception exp)
        //    {
        //        Console.WriteLine("{0} Exception caught.", exp);
        //    }
        //    finally
        //    {

        //    }
        //    return ds;
        //}
        //private void ExportStudentTimeTable()
        //{
        //    ReportDocument myReport = new ReportDocument();

        //    try
        //    {
        //        DataSet rptDS = new DataSet();

        //        rptDS = (DataSet)Session["ReportDS"];

        //        string reportPath = Server.MapPath("Reports/StudentTimeTableRPT.rpt");
        //        myReport.Load(reportPath);
        //        myReport.SetDataSource(rptDS);

        //        int iTerm = Convert.ToInt32(Terms.SelectedValue);
        //        int iSemester = 0;
        //        int iRegYear = LibraryMOD.SeperateTerm(iTerm, out iSemester);

        //        //int iSemester = Convert.ToInt32("0" + Session["RegSemester"].ToString());
        //        //int iRegYear = Convert.ToInt32("0" + Session["RegYear"].ToString());

        //        TextObject txt;
        //        txt = (TextObject)myReport.ReportDefinition.ReportObjects["txtTitle"];
        //        txt.Text = GetCaption();

        //        txt.Text += "     -   Total Credit Hours: [ " +  LibraryMOD.GetStudentRegisteredCredit(iRegYear, iSemester, sSelectedValue.Value,Convert.ToInt32 ((InitializeModule.EnumCampus)   this.Campus)).ToString () + " ]";



        //        string sSemester = LibraryMOD.GetSemesterString(iSemester);

        //        txt = (TextObject)myReport.ReportDefinition.ReportObjects["txtAcademicYear"];
        //        txt.Text += " - " +  iRegYear.ToString() + " / " + (iRegYear + 1).ToString() + " " + sSemester;

        //        txt = (TextObject)myReport.ReportDefinition.ReportObjects["UserTXT"];
        //        string sUserName = Session["CurrentUserName"].ToString();
        //        txt.Text = "/ " + sUserName;


        //        myReport.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Page.Response, true, "ECTReport");

        //    }
        //    catch (Exception exp)
        //    {
        //        //Console.WriteLine("{0} Exception caught.", exp);
        //        //divMsg.InnerText = exp.Message;
        //    }
        //    finally
        //    {
        //        myReport.Close();
        //        myReport.Dispose();
        //    }
        //}

        private void Fill_Student()
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            Conn.Open();
            try
            {
                ddlIDs.Items.Clear();
                ddlIDs.Items.Add(new ListItem("-", "0"));
                string sSQL = "SELECT lngStudentNumber FROM Reg_Applications order by lngStudentNumber desc";
                SqlCommand Cmd = new SqlCommand(sSQL, Conn);
                SqlDataReader Rd = Cmd.ExecuteReader();
                while (Rd.Read())
                {
                    ddlIDs.Items.Add(new ListItem(Rd["lngStudentNumber"].ToString(), Rd["lngStudentNumber"].ToString()));
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

        private void Get_ACC(string strAccountNo)
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            Conn.Open();
            try
            {
                Clear_ACC(strAccountNo);
                string sSQL = "SELECT strAccountNo,strStudentName,lngStudentNumber,strPhone1,intRegYear,byteRegSem,byteType";
                sSQL += ",intDelegation,curDelegation,strDelegationNote,strNote,intOnlineStatus,intOnlineUser,strOnlinePWD";
                sSQL += " FROM Reg_Student_Accounts";
                sSQL += " Where lngStudentNumber='" + strAccountNo + "'";
                SqlCommand Cmd = new SqlCommand(sSQL, Conn);
                SqlDataReader Rd = Cmd.ExecuteReader();
                while (Rd.Read())
                {
                    hdn_Acc.Value = Rd["strAccountNo"].ToString();
                    sSelectedValue.Value = Rd["lngStudentNumber"].ToString();
                    ddlACCType.SelectedValue = Rd["byteType"].ToString();
                    txtName.Text = Rd["strStudentName"].ToString();
                    if (string.IsNullOrEmpty(Rd["lngStudentNumber"].ToString()))
                    {
                        ddlIDs.SelectedValue = "0";
                    }
                    else
                    {
                        ddlIDs.SelectedValue = Rd["lngStudentNumber"].ToString();
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
                    txtAmount.Text = Rd["curDelegation"].ToString();
                    txtRemarks.Text = Rd["strDelegationNote"].ToString();
                    if (LibraryMOD.isFinanceProblems(Campus, ddlIDs.SelectedValue))
                    {
                        rbnStatus.SelectedIndex = 0;
                    }
                    else
                    {
                        rbnStatus.SelectedIndex = 1;
                    }
                    //ddlOnlineStatus.SelectedValue = Rd["intOnlineStatus"].ToString();

                    ddlRegTerm.SelectedValue = Rd["intRegYear"].ToString() + Rd["byteRegSem"].ToString();
                    ddlRegTerm1.SelectedValue = ddlRegTerm.SelectedValue;
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

        private void Clear_ACC(string strAccountNo)
        {

            try
            {
                if (string.IsNullOrEmpty(strAccountNo))
                {
                    lblACC.Text = "";
                    ddlOnlineStatus.SelectedIndex = 0;
                }
                else
                {
                    lblACC.Text = strAccountNo;
                }
                ddlACCType.SelectedValue = "0";
                txtName.Text = "";
                ddlIDs.SelectedValue = "0";
                txtPhone.Text = "";
                txtNote.Text = "";
                ddlSponsor.SelectedValue = "0";
                txtAmount.Text = "0";
                txtRemarks.Text = "";

                rbnStatus.SelectedIndex = 1;

                ddlRegTerm.SelectedIndex = 0;
                ddlRegTerm1.SelectedIndex = 0;
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
        private string Get_New_Acc()
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            Conn.Open();
            string sNewAcc = "";
            try
            {

                string sSQL = "SELECT sNewACC FROM New_ACC";
                SqlCommand Cmd = new SqlCommand(sSQL, Conn);

                sNewAcc = Cmd.ExecuteScalar().ToString();

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
            return sNewAcc;
        }

        private void Update_Acc()
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            Conn.Open();

            try
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.CommandText = "Add_Account";
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Connection = Conn;
                Cmd.Parameters.Add("@strAccountNo", SqlDbType.VarChar).Value = lblACC.Text;
                Cmd.Parameters.Add("@strStudentName", SqlDbType.VarChar).Value = txtName.Text;
                Cmd.Parameters.Add("@lngStudentNumber", SqlDbType.VarChar).Value = ddlIDs.SelectedValue;
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
                Cmd.ExecuteNonQuery();

                if (ddlIDs.SelectedValue != "0")
                {
                    Cmd.CommandText = "UPDATE Reg_Applications SET bOtherCollege =" + rbnStatus.SelectedValue + "  WHERE lngStudentNumber='" + ddlIDs.SelectedValue + "'";
                    Cmd.CommandType = CommandType.Text;
                    Cmd.ExecuteNonQuery();
                }

                //divMsg.InnerText = "Data Updated Successfully";
                lbl_Msg.Text = "Data Updated Successfully";
                div_Alert.Attributes.Add("class", "alert alert-success alert-dismissible");
                div_msg.Visible = true;
            }
            catch (Exception exp)
            {
                Console.WriteLine("{0} Exception caught.", exp);
                divMsg.InnerText = exp.Message;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }
        }


        protected void Save_btn_Click(object sender, ImageClickEventArgs e)
        {
            if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_ACC_Search,
                    InitializeModule.enumPrivilege.EditUpdate, CurrentRole) != true)
            {
                //divMsg.InnerText = "Sorry you not allowed to update a student account.";
                lbl_Msg.Text = "Sorry you not allowed to update a student account.";
                div_msg.Visible = true;
                return;

            }
            Update_Acc();
        }

        private void Fill_Factors()
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            Conn.Open();
            try
            {
                MirrorCLS myMirror = new MirrorCLS();
                myMirror = LibraryMOD.GetStudentFactors(sSelectedValue.Value, Campus);
                lblMajor.Text = myMirror.Major;


                if (myMirror.CGPA == 101)
                {
                    lblCGPA.Text = "";
                }
                else
                {
                    lblCGPA.Text = string.Format("{0:f}", myMirror.CGPA);
                }

                lblMajorCaption.Visible = true;
                lblCGPACaption.Visible = true;

                lblMajor.Visible = true;
                lblCGPA.Visible = true;


                //Fill Rate
                int iTerm = Convert.ToInt32(Terms.SelectedValue.ToString());
                int iSem = 0;
                int iYear = LibraryMOD.SeperateTerm(iTerm, out iSem);

                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                //SELECT dPRegistered, dCRegistered, dCompleted, dTotal
                //FROM dbo.ACC_Factors_General_Core(2018, 3, 'BAM1709051', 1)
                //General (1)
                Cmd.CommandText = "SELECT dPRegistered, dCRegistered,dCompleted ,dTotal FROM dbo.ACC_Factors_General_Core(@iYear,@bSem,@sNo,1)";
                Cmd.CommandType = CommandType.Text;
                Cmd.Parameters.AddWithValue("iYear", iYear);
                Cmd.Parameters.AddWithValue("bSem", iSem);
                Cmd.Parameters.AddWithValue("sNo", sSelectedValue.Value);

                SqlDataReader rd = Cmd.ExecuteReader();
                while (rd.Read())
                {
                    lblPRegGen.Text = rd["dPRegistered"].ToString();
                    lblCRegGen.Text = rd["dCRegistered"].ToString();
                    lblCompletedGen.Text = rd["dCompleted"].ToString();
                    lblTotalGen.Text = rd["dTotal"].ToString();
                    //lblRate.Text = rd["dCRate"].ToString();
                }
                rd.Close();

                //Core (0)
                Cmd.CommandText = "SELECT dPRegistered, dCRegistered,dCompleted ,dTotal FROM dbo.ACC_Factors_General_Core(@iYear,@bSem,@sNo,0)";
                Cmd.CommandType = CommandType.Text;
                //Cmd.Parameters.AddWithValue("iYear", iYear);
                //Cmd.Parameters.AddWithValue("bSem", iSem);
                //Cmd.Parameters.AddWithValue("sNo", sSelectedValue.Value);

                rd = Cmd.ExecuteReader();
                while (rd.Read())
                {
                    lblPRegCore.Text = rd["dPRegistered"].ToString();
                    lblCRegCore.Text = rd["dCRegistered"].ToString();
                    lblCompletedCore.Text = rd["dCompleted"].ToString();
                    lblTotalCore.Text = rd["dTotal"].ToString();
                    //lblRate.Text = rd["dCRate"].ToString();
                }
                rd.Close();

                //All
                Cmd.CommandText = "SELECT dCRate FROM dbo.ACC_Factors(@iYear,@bSem,@sNo)";
                Cmd.CommandType = CommandType.Text;
                //Cmd.Parameters.AddWithValue("iYear", iYear);
                //Cmd.Parameters.AddWithValue("bSem", iSem);
                //Cmd.Parameters.AddWithValue("sNo", sSelectedValue.Value);

                rd = Cmd.ExecuteReader();
                while (rd.Read())
                {
                    lblRate.Text = rd["dCRate"].ToString();
                }
                rd.Close();

                lblPReg.Text = (Convert.ToInt32(lblPRegGen.Text) + Convert.ToInt32(lblPRegCore.Text)).ToString();
                lblCReg.Text = (Convert.ToInt32(lblCRegGen.Text) + Convert.ToInt32(lblCRegCore.Text)).ToString();
                lblCompleted.Text = (Convert.ToInt32(lblCompletedGen.Text) + Convert.ToInt32(lblCompletedCore.Text)).ToString();
                lblTotal.Text = (Convert.ToInt32(lblTotalGen.Text) + Convert.ToInt32(lblTotalCore.Text)).ToString();

                //Fill Reg Both Side
                lblRegF.Text = "0";
                lblRegM.Text = "0";

                string sSQL = "SELECT MCRS,FCRS FROM Reg_Both_Side";
                sSQL += " WHERE iYear=" + iYear;
                sSQL += " AND Sem=" + iSem;
                sSQL += " AND Student='" + sSelectedValue.Value + "'";
                Cmd.CommandText = sSQL;

                rd = Cmd.ExecuteReader();
                while (rd.Read())
                {
                    lblRegF.Text = rd["FCRS"].ToString();
                    lblRegM.Text = rd["MCRS"].ToString();
                }
                rd.Close();

                sSQL = "SELECT SUM((CASE WHEN C.isGeneralCredits = 1 THEN byteCreditHours ELSE 0 END)) AS General, SUM((CASE WHEN C.isGeneralCredits = 0 THEN byteCreditHours ELSE 0 END))AS Core";
                sSQL += " FROM Reg_Applications AS A INNER JOIN Reg_Specialization_Courses AS M ON A.strCollege = M.strCollege AND A.strDegree = M.strDegree AND A.strSpecialization = M.strSpecialization INNER JOIN";
                sSQL += " Reg_Courses AS C ON M.strCourse = C.strCourse WHERE (A.lngStudentNumber = N'" + sSelectedValue.Value + "')";
                Cmd.CommandText = sSQL;
                rd = Cmd.ExecuteReader();
                int iGen = 0;
                int iCore = 0;

                while (rd.Read())
                {
                    iGen = Convert.ToInt32(rd["General"]);
                    iCore = Convert.ToInt32(rd["Core"]);
                }
                rd.Close();

                lblRemainingGen.Text = (iGen - Convert.ToInt32(lblTotalGen.Text)).ToString();
                lblRemainingCore.Text = (iCore - Convert.ToInt32(lblTotalCore.Text)).ToString();
                lblRemaining.Text = (Convert.ToInt32(lblRemainingGen.Text) + Convert.ToInt32(lblRemainingCore.Text)).ToString();

                //Fill Term Balance
                sSQL = "SELECT ISNULL(SUM(I.curCredit), 0) AS Insurance, ISNULL(SUM(B.curDebit), 0) AS Debit, ISNULL(SUM(B.curCredit), 0) AS Credit,ISNULL(SUM(B.curVAT), 0) AS VAT";
                sSQL += " FROM AccBalance AS B LEFT OUTER JOIN ACC_Insurance AS I ON B.intFy = I.intFy AND B.byteFSemester = I.byteFSemester AND B.sAccount = I.sAccount";
                sSQL += " WHERE (B.sAccount = '" + sSelectedText.Value + "') AND (B.intFy = " + iYear + ") AND (B.byteFSemester = " + iSem + ") AND (B.byteStatus < 2)";
                Cmd.CommandText = sSQL;

                rd = Cmd.ExecuteReader();
                while (rd.Read())
                {
                    lblTIns.Text = string.Format("{0:f}", rd["Insurance"]);
                    lblTDebit.Text = string.Format("{0:f}", rd["Debit"]);
                    lblTCredit.Text = string.Format("{0:f}", rd["Credit"]);
                    lblTBalance.Text = string.Format("{0:f}", (Convert.ToDecimal(lblTDebit.Text) - Convert.ToDecimal(lblTCredit.Text)));
                    lblTVat.Text = string.Format("{0:f}", rd["VAT"]);
                    lblTBalanceVAT.Text = string.Format("{0:f}", (Convert.ToDecimal(lblTDebit.Text) - Convert.ToDecimal(lblTCredit.Text) + Convert.ToDecimal(lblTVat.Text)));
                }
                rd.Close();

                //Fill Overall Balance
                sSQL = "SELECT ISNULL(SUM(I.curCredit),0) AS Insurance, ISNULL(SUM(B.curDebitSum),0) AS Debit, ISNULL(SUM(B.curCreditSum),0) AS Credit, ISNULL(SUM(B.curVATSum),0) AS VAT";
                sSQL += " FROM AccBalanceSumAll AS B LEFT OUTER JOIN ACC_Insurance AS I ON B.sAccount = I.sAccount";
                sSQL += " WHERE (B.sAccount = '" + sSelectedText.Value + "')";
                Cmd.CommandText = sSQL;

                rd = Cmd.ExecuteReader();
                while (rd.Read())
                {
                    lblOIns.Text = string.Format("{0:f}", rd["Insurance"]);
                    lblODebit.Text = string.Format("{0:f}", rd["Debit"]);
                    lblOCredit.Text = string.Format("{0:f}", rd["Credit"]);
                    lblOBalance.Text = string.Format("{0:f}", (Convert.ToDecimal(lblODebit.Text) - Convert.ToDecimal(lblOCredit.Text)));
                    lblOvat.Text = string.Format("{0:f}", rd["VAT"]);
                    lblOBalanceVAT.Text = string.Format("{0:f}", (Convert.ToDecimal(lblODebit.Text) - Convert.ToDecimal(lblOCredit.Text) + Convert.ToDecimal(lblOvat.Text)));
                }
                rd.Close();

                //Fill Discounts
                sSQL = "SELECT A.lngStudentNumber AS SID, FT.MinYear, SD.strLastDescAr AS Name, LDS.LTerm AS Last_Discount, LDS.DType, LDS.DCategory, LDS.Amount AS DAmount";
                sSQL += " FROM First_Time_Registered AS FT RIGHT OUTER JOIN Reg_Applications AS A INNER JOIN Reg_Students_Data AS SD ON A.lngSerial = SD.lngSerial LEFT OUTER JOIN";
                sSQL += " Last_Discount AS LDS ON A.lngStudentNumber = LDS.SID ON FT.Student = A.lngStudentNumber";
                sSQL += " WHERE (A.lngStudentNumber = '" + sSelectedValue.Value + "')";
                Cmd.CommandText = sSQL;

                string sRow = "";
                lstDis.Items.Clear();
                rd = Cmd.ExecuteReader();
                while (rd.Read())
                {
                    lblArName.Text = rd["Name"].ToString();
                    lblFTR.Text = rd["MinYear"].ToString();
                    sRow = "";
                    if (!rd["Last_Discount"].Equals(DBNull.Value))
                    {
                        sRow += rd["Last_Discount"].ToString();
                        sRow += "|" + rd["DType"].ToString();
                        sRow += "|" + rd["DCategory"].ToString();
                        sRow += "|" + string.Format("{0:f}", rd["DAmount"]);
                        lstDis.Items.Add(new ListItem(sRow));
                    }

                }
                rd.Close();

                //Fill Ref Discounts
                sSQL = "SELECT A.lngStudentNumber AS SID, A0.lngStudentNumber AS Ref, LDS0.LTerm AS RLast_Discount, LDS0.DType AS RDType, LDS0.DCategory AS RDCategory,LDS0.Amount AS RDAmount";
                sSQL += " FROM Reg_Applications AS A0 LEFT OUTER JOIN Last_Discount AS LDS0 ON A0.lngStudentNumber = LDS0.SID RIGHT OUTER JOIN Reg_Applications AS A ON A0.lngStudentNumber = A.sReference";
                sSQL += " WHERE (A.lngStudentNumber = '" + sSelectedValue.Value + "')";
                Cmd.CommandText = sSQL;

                lstRefDis.Items.Clear();
                rd = Cmd.ExecuteReader();
                while (rd.Read())
                {
                    lblRef.Text = rd["Ref"].ToString();
                    sRow = "";
                    if (!rd["RLast_Discount"].Equals(DBNull.Value))
                    {
                        sRow += rd["RLast_Discount"].ToString();
                        sRow += "|" + rd["RDType"].ToString();
                        sRow += "|" + rd["RDCategory"].ToString();
                        sRow += "|" + string.Format("{0:f}", rd["RDAmount"]);
                        lstRefDis.Items.Add(new ListItem(sRow));
                    }

                }
                rd.Close();


                string sACC = sSelectedText.Value;

                //Fill Acc Notification
                divAccNotification.InnerText = getAccNotification(sACC, Campus);


                lblOBalanceCVAT.Text = string.Format("{0:f}", LibraryMOD.GetStudentBalance(sACC, Campus));
                InitializeModule.EnumCampus STCampus;
                string sSID = sSelectedValue.Value;
                if (sSID.Contains("AF") || sSID.Contains("SF"))
                {
                    STCampus = InitializeModule.EnumCampus.Females;
                }
                else
                {
                    STCampus = InitializeModule.EnumCampus.Males;
                }
                lblOBalanceVATBTS.Text = string.Format("{0:f}", LibraryMOD.GetStudentBalanceBTS(sSelectedValue.Value, STCampus));
                lblLTRBS.Text = LibraryMOD.GetLTRBTS(sSelectedValue.Value, STCampus).ToString();

                lblArNameCaption.Visible = true;
                lblArName.Visible = true;
                lblFTRCaption.Visible = true;
                lblFTR.Visible = true;
                lblLastDisCaption.Visible = true;
                lstDis.Visible = true;
                lblRefCaption.Visible = true;
                lblRef.Visible = true;
                lblLastRefDisCaption.Visible = true;
                lstRefDis.Visible = true;
                lblOBalanceCVAT.Visible = true;
                lblOBalanceVATBTS.Visible = true;
                lblOBalanceVATCaption.Visible = true;
                lblOBalanceVATCaptionBTS.Visible = true;
                lblLTRBS.Visible = true;
                lblLTRCaption.Visible = true;


            }
            catch (Exception exp)
            {
                Console.WriteLine("{0} Exception caught.", exp);
                //divMsg.InnerText = exp.Message;
                lbl_Msg.Text = exp.Message;
                div_msg.Visible = true;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }


        }
        protected void Campus_ddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            Fill_Student();
            Fill_Sponsors();
        }
        protected void ddlOnlineStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(sSelectedText.Value))
                {
                    //divMsg.InnerText = "Select a student please or the students hasn't account yet.";
                    lbl_Msg.Text = "Select a student please or the students hasn't account yet.";
                    div_msg.Visible = true;
                    return;
                }
                int iStatus = 0;
                if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_ACC_Search,
                      InitializeModule.enumPrivilege.ChangeOnlineStatus, CurrentRole) != true)
                {
                    iStatus = getOnlineStatus(sSelectedValue.Value);
                    ddlOnlineStatus.SelectedIndex = iStatus;
                    //divMsg.InnerText = "Sorry you cannot change online status for student";
                    lbl_Msg.Text = "Sorry you cannot change online status for student";
                    div_msg.Visible = true;
                    return;
                }

                iStatus = ddlOnlineStatus.SelectedIndex;
                string sACC = sSelectedText.Value;//getStAcc(sSelectedValue.Value);
                UpdateStAcc(sSelectedValue.Value, sACC, iStatus);
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
        private int getOnlineStatus(string sNo)
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            Conn.Open();
            int iStatus = 0;
            try
            {
                string sSQL = "SELECT intOnlineStatus FROM Reg_Student_Accounts  WHERE [lngStudentNumber]='" + sNo + "'";
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

        //private string getStAcc(string sNo)
        //{
        //    Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
        //    SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
        //    Conn.Open();
        //    string sAcc = "";
        //    try
        //    {
        //        string sSQL = "SELECT strAccountNo FROM Reg_Student_Accounts  WHERE [lngStudentNumber]='" + sNo + "'";
        //        SqlCommand Cmd = new SqlCommand(sSQL, Conn);
        //        sAcc = Cmd.ExecuteScalar().ToString();

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
        //    return sAcc;
        //}

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

        private void UpdateStAcc(string sSno, string sAcc, int iStatus)
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            Conn.Open();
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
                    Cmd.ExecuteNonQuery();

                }

                if (iStatus == 1)
                {
                    Cmd.CommandText = "Create_Online_User";
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.Add("@sNo", SqlDbType.VarChar).Value = sSno;
                    Cmd.Parameters.Add("@sAccount", SqlDbType.VarChar).Value = sAcc;
                    Cmd.Parameters.Add("@iRole", SqlDbType.Int).Value = 111;
                    Cmd.ExecuteNonQuery();

                }

                if (iStatus == 2)
                {
                    Cmd.CommandText = "Create_Online_User";
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.Add("@sNo", SqlDbType.VarChar).Value = sSno;
                    Cmd.Parameters.Add("@sAccount", SqlDbType.VarChar).Value = sAcc;
                    Cmd.Parameters.Add("@iRole", SqlDbType.Int).Value = 105;
                    Cmd.ExecuteNonQuery();
                }

                sSQL = "UPDATE Reg_Student_Accounts";
                sSQL += " SET intOnlineStatus =" + iStatus;
                sSQL += ",strUserSave='" + Session["CurrentUserName"].ToString() + "',dateLastSave=getDate()";
                sSQL += " Where strAccountNo='" + sAcc + "'";
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = sSQL;
                Cmd.ExecuteNonQuery();

                //divMsg.InnerText = "Online Status updated successfully";
                lbl_Msg.Text = "Online Status updated successfully";
                div_Alert.Attributes.Add("class", "alert alert-success alert-dismissible");
                div_msg.Visible = true;


            }
            catch (Exception exp)
            {
                //Console.WriteLine("{0} Exception caught.", exp);
                //divMsg.InnerText = "Online Status not updated";
                lbl_Msg.Text = "Online Status not updated";
                div_msg.Visible = true;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }

        }
        private void Empty_Payment_Controls(int iEntry)
        {
            lblEntryNo.Text = iEntry.ToString();
            txtDatePayment.Text = string.Format("{0:yyyy-MM-dd}", DateTime.Today.Date);
            txtPayment.Text = "0";
            ddlPaymentWay.SelectedIndex = 0;
            ddlStatus.SelectedIndex = 0;
            txtCheque.Text = "";
            hdnCheque.Value = "";
            txtDueDate.Text = "";
            ddlBank.SelectedValue = "0";
            txtPRemark.Text = "";
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
                sSQL += " VALUES(" + iCYear + "," + iCSem + ",'" + sVoucher + "',GetDate(),'" + sSelectedText.Value;
                sSQL += "','" + sSelectedValue.Value + "',0,'" + Session["CurrentUserName"].ToString() + "',GetDate())";
                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandText = sSQL;
                int iEffected = Cmd.ExecuteNonQuery();
                if (iEffected == 0)
                {
                    sVoucher = "";
                }
                grdVH.DataBind();

            }
            catch (Exception exp)
            {
                divMsg.InnerText = exp.Message;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }
            return sVoucher;
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
                divMsg.InnerText = exp.Message;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }
            return sVoucher;

        }

        private void Bind_GRDs(string sVoucher)
        {
            VHDS.SelectParameters["strVoucherNo"].DefaultValue = sVoucher;
            VHDS.SelectParameters["intFy"].DefaultValue = iCYear.ToString();
            VHDS.SelectParameters["byteFSemester"].DefaultValue = iCSem.ToString();
            grdVH.DataBind();

            VDDS.SelectParameters["strVoucherNo"].DefaultValue = sVoucher;
            VDDS.SelectParameters["intFy"].DefaultValue = iCYear.ToString();
            VDDS.SelectParameters["byteFSemester"].DefaultValue = iCSem.ToString();
            grdVD.DataBind();

        }

        private void Get_Payment(string sVoucher, int iPayment)
        {

            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            Conn.Open();
            try
            {
                string sSQL = "SELECT lngEntryNo,datePayment,curCredit,byteStatus,lngCheque,dateDue,intBank,bytePaymentWay,strRemark";
                sSQL += " FROM Acc_Voucher_Detail";
                sSQL += " WHERE intFy=" + iCYear + " AND byteFSemester=" + iCSem + " AND strVoucherNo='" + sVoucher + "' AND lngEntryNo=" + iPayment;
                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandText = sSQL;
                SqlDataReader Rd = Cmd.ExecuteReader();
                int iCheque = 0;
                while (Rd.Read())
                {
                    lblEntryNo.Text = Rd["lngEntryNo"].ToString();
                    txtDatePayment.Text = string.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(Rd["datePayment"]));
                    txtPayment.Text = string.Format("{0:f}", Convert.ToDouble(Rd["curCredit"]));
                    ddlStatus.SelectedValue = Rd["byteStatus"].ToString();
                    ddlPaymentWay.SelectedValue = Rd["bytePaymentWay"].ToString();
                    txtPRemark.Text = Rd["strRemark"].ToString();
                    if (ddlPaymentWay.SelectedValue == "3")
                    {
                        iCheque = Convert.ToInt32(Rd["lngCheque"]);
                    }
                }
                Rd.Close();
                if (iCheque > 0)
                {
                    hdnCheque.Value = iCheque.ToString();
                    sSQL = "SELECT lngCheque,strChequeNo,dateDue,intBank,byteStatus FROM Acc_Cheques WHERE lngCheque" + iCheque;
                    Cmd.CommandText = sSQL;
                    Rd = Cmd.ExecuteReader();
                    while (Rd.Read())
                    {
                        hdnCheque.Value = Rd["lngCheque"].ToString();
                        txtCheque.Text = Rd["strChequeNo"].ToString();
                        txtDueDate.Text = string.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(Rd["dateDue"]));
                        ddlBank.SelectedValue = Rd["intBank"].ToString();
                        ddlStatus.SelectedValue = Rd["byteStatus"].ToString();
                    }
                    Rd.Close();
                }
                else
                {
                    hdnCheque.Value = "";
                    txtCheque.Text = "";
                    txtDueDate.Text = "";
                    ddlBank.SelectedValue = "0";
                }

            }
            catch (Exception exp)
            {
                divMsg.InnerText = exp.Message;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }

        }
        protected void grdPayment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_ACC_Search,
                        InitializeModule.enumPrivilege.ACCManageStPayment, CurrentRole) != true)
            {
                //divMsg.InnerText = "Sorry you cannot manage st payment.";
                lbl_Msg.Text = "Sorry you cannot manage st payment.";
                div_msg.Visible = true;
                return;
            }
            string sVoucher = grdPayment.SelectedDataKey["strVoucherNo"].ToString();
            int iEntry = Convert.ToInt32(grdPayment.SelectedDataKey["lngEntryNo"].ToString());
            lblVoucher.Text = sVoucher;
            Bind_GRDs(sVoucher);
            Get_Payment(sVoucher, iEntry);
            MVPayemnt.ActiveViewIndex = 1;
            hdnPaymentStatus.Value = "0";//Update


        }
        protected void grdVD_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_ACC_Search,
                        InitializeModule.enumPrivilege.ACCManageStPayment, CurrentRole) != true)
            {
                //divMsg.InnerText = "Sorry you cannot manage st payment.";
                lbl_Msg.Text = "Sorry you cannot manage st payment.";
                div_msg.Visible = true;
                return;
            }
            string sVoucher = lblVoucher.Text;
            int iEntry = Convert.ToInt32(grdVD.SelectedDataKey["lngEntryNo"].ToString());
            Get_Payment(sVoucher, iEntry);
            hdnPaymentStatus.Value = "1";//Update
        }
        protected void Go_Payment_btn_Click(object sender, ImageClickEventArgs e)
        {
            MVPayemnt.ActiveViewIndex = 0;
        }
        protected void New_Voucher_btn_Click(object sender, ImageClickEventArgs e)
        {
            if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_ACC_Search,
                    InitializeModule.enumPrivilege.ACCAddStPayment, CurrentRole) != true)
            {
                //divMsg.InnerText = "Sorry you cannot add payment.";
                lbl_Msg.Text = "Sorry you cannot add payment.";
                div_msg.Visible = true;
                return;
            }
            Empty_Payment_Controls(0);
            lblVoucher.Text = AddVoucher();
            Bind_GRDs(lblVoucher.Text);
            MVPayemnt.ActiveViewIndex = 1;
            hdnPaymentStatus.Value = "";//Not Decided
        }
        protected void New_Payment_btn_Click(object sender, ImageClickEventArgs e)
        {
            if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_ACC_Search,
                    InitializeModule.enumPrivilege.ACCAddStPayment, CurrentRole) != true)
            {
                //divMsg.InnerText = "Sorry you cannot add payment.";
                lbl_Msg.Text = "Sorry you cannot add payment.";
                div_msg.Visible = true;
                return;
            }
            Empty_Payment_Controls(GetNewEntry(lblVoucher.Text));
            //lblVoucher.Text = AddVoucher();
            MVPayemnt.ActiveViewIndex = 1;
            hdnPaymentStatus.Value = "1";//Add

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
                divMsg.InnerText = exp.Message;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }
            return iEntry;
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
                divMsg.InnerText = exp.Message;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }
            return iCheque;
        }

        private int AddCheque()
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            Conn.Open();
            int iCheque = 0;
            try
            {
                iCheque = GetNewCheque();
                string sSQL = "INSERT INTO Acc_Cheques";
                sSQL += " (lngCheque,strChequeNo,dateCheque,dateDue,intBank,byteStatus,curValue,byteCurrency,strUserCreate,dateCreate)";
                sSQL += " Values(" + iCheque + ",'" + txtCheque.Text + "','" + txtDatePayment.Text + "','" + txtDueDate.Text + "'," + ddlBank.SelectedValue;
                sSQL += "," + ddlStatus.SelectedValue + "," + txtAmount.Text + ",0,'" + Session["CurrentUserName"] + "',GetDate())";

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
                divMsg.InnerText = exp.Message;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }
            return iCheque;
        }

        private bool UpdateCheque(int iCheque)
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            Conn.Open();
            bool isUpdated = false;
            try
            {

                string sSQL = "UPDATE Acc_Cheques SET";
                sSQL += " strChequeNo='" + txtCheque.Text + "',dateCheque='" + txtDatePayment.Text + "',dateDue='" + txtDueDate.Text + "'";
                sSQL += ",intBank=" + ddlBank.SelectedValue + ",byteStatus=" + ddlStatus.SelectedValue + ",curValue=" + txtAmount.Text;
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
                divMsg.InnerText = exp.Message;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }
            return isUpdated;
        }
        protected void Save_Payment_btn_Click(object sender, ImageClickEventArgs e)
        {
            if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_ACC_Search,
                    InitializeModule.enumPrivilege.ACCManageStPayment, CurrentRole) != true)
            {
                //divMsg.InnerText = "Sorry you cannot update payment.";
                lbl_Msg.Text = "Sorry you cannot update payment.";
                div_msg.Visible = true;
                return;
            }
            string sMsg = "Payment not saved !";
            bool isUpdated = false;
            if (hdnPaymentStatus.Value == "")
            {
                //divMsg.InnerText = "Select a payment or add new one please.";
                lbl_Msg.Text = "Select a payment or add new one please.";
                div_msg.Visible = true;
                return;
            }
            if (hdnPaymentStatus.Value == "0")//Update
            {

                bool isPrinted = GetIsPrinted(lblVoucher.Text);
                bool isSkip = LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_ACC_Search,
                       InitializeModule.enumPrivilege.ACCSkipPrinted, CurrentRole);

                if (isPrinted && !isSkip)
                {
                    sMsg = "Sorry, You cannot update a printed payment.";
                    return;
                }
                isUpdated = UpdatePayment(false);
                if (isUpdated)
                {
                    sMsg = "Payment updated.";
                }
            }
            else//Add
            {
                isUpdated = UpdatePayment(true);
                if (isUpdated)
                {
                    sMsg = "Payment added.";
                }
            }
            //divMsg.InnerText = sMsg;
            lbl_Msg.Text = sMsg;
            div_msg.Visible = true;
            grdPayment.DataBind();
            grdVD.DataBind();
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
                    case "0"://Entry

                        //divMsg.InnerText = "Sorry you cannot set status :Entry.";
                        lbl_Msg.Text = "Sorry you cannot set status :Entry.";
                        div_msg.Visible = true;
                        return false;

                        break;
                    case "1"://Paid
                        if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_ACC_Search,
                        InitializeModule.enumPrivilege.ACCChequePaid, CurrentRole) != true)
                        {
                            //divMsg.InnerText = "Sorry you cannot set status :Paid.";
                            lbl_Msg.Text = "Sorry you cannot set status :Paid.";
                            div_msg.Visible = true;
                            return false;
                        }
                        break;
                    case "2"://Returned
                        if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_ACC_Search,
                        InitializeModule.enumPrivilege.ACCChequeReturned, CurrentRole) != true)
                        {
                            //divMsg.InnerText = "Sorry you cannot set status :Returned.";
                            lbl_Msg.Text = "Sorry you cannot set status :Returned.";
                            div_msg.Visible = true;
                            return false;
                        }
                        break;
                    case "3"://Insurance
                        if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_ACC_Search,
                        InitializeModule.enumPrivilege.ACCChequeInsurance, CurrentRole) != true)
                        {
                            //divMsg.InnerText = "Sorry you cannot set status :Insurance.";
                            lbl_Msg.Text = "Sorry you cannot set status :Insurance.";
                            div_msg.Visible = true;
                            return false;
                        }
                        break;
                    case "4"://Canceled
                        if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_ACC_Search,
                        InitializeModule.enumPrivilege.ACCChequeCanceled, CurrentRole) != true)
                        {
                            //divMsg.InnerText = "Sorry you cannot set status :Canceled.";
                            lbl_Msg.Text = "Sorry you cannot set status :Canceled.";
                            div_msg.Visible = true;
                            return false;
                        }
                        break;

                }

                string sSQL = "";
                int iCheque = 0;

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

                int iCampaus = Convert.ToInt32(rbnCash.SelectedValue);



                if (isAdd)
                {
                    if (iCheque > 0)//Include Cheque
                    {
                        sSQL = "INSERT INTO Acc_Voucher_Detail";
                        sSQL += " (intFy,byteFSemester,strVoucherNo,lngEntryNo,strAccountNo,datePayment,curDebit,curCredit,bytePaymentWay,";
                        sSQL += " byteStatus,lngCheque,dateDue,intBank,byteCurrency,strRemark,strUserCreate,dateCreate,intCampus)";
                        sSQL += " VALUES(" + iCYear + "," + iCSem + ",'" + lblVoucher.Text + "'," + lblEntryNo.Text + ",'" + sSelectedText.Value + "'";
                        sSQL += ",'" + txtDatePayment.Text + "',0," + txtPayment.Text + "," + ddlPaymentWay.SelectedValue + "," + ddlStatus.SelectedValue;
                        sSQL += "," + iCheque + ",'" + txtDueDate.Text + "'," + ddlBank.SelectedValue + ",0,'" + txtRemarks.Text + "'";
                        sSQL += ",'" + Session["CurrentUserName"] + "',GetDate()," + iCampaus + ")";
                    }
                    else
                    {
                        sSQL = "INSERT INTO Acc_Voucher_Detail";
                        sSQL += " (intFy,byteFSemester,strVoucherNo,lngEntryNo,strAccountNo,datePayment,curDebit,curCredit,bytePaymentWay,";
                        sSQL += " byteStatus,byteCurrency,strRemark,strUserCreate,dateCreate,intCampus)";
                        sSQL += " VALUES(" + iCYear + "," + iCSem + ",'" + lblVoucher.Text + "'," + lblEntryNo.Text + ",'" + sSelectedText.Value + "'";
                        sSQL += ",'" + txtDatePayment.Text + "',0," + txtPayment.Text + "," + ddlPaymentWay.SelectedValue + "," + ddlStatus.SelectedValue;
                        sSQL += ",0,'" + txtRemarks.Text + "','" + Session["CurrentUserName"] + "',GetDate()," + iCampaus + ")";
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
                        sSQL += ",lngCheque=" + iCheque + ",dateDue='" + txtDueDate.Text + "',intBank=" + ddlBank.SelectedValue;
                        sSQL += ",strRemark='" + txtRemarks.Text + "',strUserSave='" + Session["CurrentUserName"] + "',dateLastSave=GetDate()";
                        sSQL += " WHERE intFy=" + iCYear + " AND byteFSemester=" + iCSem + " AND strVoucherNo='" + lblVoucher.Text + "' AND lngEntryNo=" + lblEntryNo.Text;
                    }
                    else
                    {
                        sSQL = "UPDATE Acc_Voucher_Detail SET";
                        sSQL += " curCredit=" + txtPayment.Text + ",bytePaymentWay=" + ddlPaymentWay.SelectedValue + ",byteStatus=" + ddlStatus.SelectedValue;
                        //sSQL += ",lngCheque=" + iCheque + ",dateDue='" + txtDueDate.Text + "',intBank=" + ddlBank.SelectedValue;
                        sSQL += ",strRemark='" + txtRemarks.Text + "',strUserSave='" + Session["CurrentUserName"] + "',dateLastSave=GetDate()";
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
                //divMsg.InnerText = exp.Message;
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

        private bool DeletePayment()
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            Conn.Open();
            bool isDeleted = false;
            try
            {
                if (hdnCheque.Value != "")
                {
                    DeleteCheque(Convert.ToInt32(hdnCheque.Value));
                }

                string sSQL = "DELETE FROM Acc_Voucher_Detail";
                sSQL += " WHERE intFy=" + iCYear + " AND byteFSemester=" + iCSem + " AND strVoucherNo='" + lblVoucher.Text + "' AND lngEntryNo=" + lblEntryNo.Text;

                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandText = sSQL;
                int iEffected = 0;
                iEffected = Cmd.ExecuteNonQuery();
                isDeleted = (iEffected > 0);
            }
            catch (Exception exp)
            {
                //divMsg.InnerText = exp.Message;
                lbl_Msg.Text = exp.Message;
                div_msg.Visible = true;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }
            return isDeleted;
        }

        private bool DeleteCheque(int iCheque)
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            Conn.Open();
            bool isDeleted = false;
            try
            {

                string sSQL = "DELETE FROM Acc_Cheques";
                sSQL += " WHERE lngCheque=" + iCheque;

                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandText = sSQL;
                int iEffected = 0;
                iEffected = Cmd.ExecuteNonQuery();
                isDeleted = (iEffected > 0);
            }
            catch (Exception exp)
            {
                //divMsg.InnerText = exp.Message;
                lbl_Msg.Text = exp.Message;
                div_msg.Visible = true;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }
            return isDeleted;
        }

        protected void Delete_Payment_btn_Click(object sender, ImageClickEventArgs e)
        {
            if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_ACC_Search,
                        InitializeModule.enumPrivilege.ACCCancelStPayment, CurrentRole) != true)
            {
                //divMsg.InnerText = "Sorry you cannot delete payment.";
                lbl_Msg.Text = "Sorry you cannot delete payment.";
                div_msg.Visible = true;
                return;
            }

            bool isDeleted = false;
            string sMsg = "Payment not deleted";
            if (!string.IsNullOrEmpty(lblVoucher.Text) && !string.IsNullOrEmpty(lblEntryNo.Text))
            {
                isDeleted = DeletePayment();
                if (isDeleted)
                {
                    sMsg = "Payment deleted.";
                    grdPayment.DataBind();
                    grdVD.DataBind();
                }
            }
            else
            {
                sMsg = "Select payment please.";
            }
            //divMsg.InnerText = sMsg;
            lbl_Msg.Text = sMsg;
            div_msg.Visible = true;
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
                //divMsg.InnerText = exp.Message;
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

        private bool GetIsPrinted(string sVoucher)
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            Conn.Open();
            bool isPrinted = false;
            try
            {

                string sSQL = "SELECT isPrinted FROM Acc_Voucher_Header";
                sSQL += " WHERE intFy=" + iCYear;
                sSQL += " AND byteFSemester=" + iCSem;
                sSQL += " AND strVoucherNo='" + sVoucher + "'";

                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandText = sSQL;

                isPrinted = Convert.ToBoolean(Cmd.ExecuteScalar());

            }
            catch (Exception exp)
            {
                //divMsg.InnerText = exp.Message;
                lbl_Msg.Text = exp.Message;
                div_msg.Visible = true;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }
            return isPrinted;
        }
        protected void Print_Payment_btn_Click(object sender, ImageClickEventArgs e)
        {
            if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_ACC_Search,
                InitializeModule.enumPrivilege.Print, CurrentRole) != true)
            {
                //divMsg.InnerText = InitializeModule.MsgPrintAuthorization;
                lbl_Msg.Text = InitializeModule.MsgPrintAuthorization;
                div_msg.Visible = true;
                return;
            }

            if (!string.IsNullOrEmpty(lblVoucher.Text))
            {
                UpdateVoucher(lblVoucher.Text, true);//Close the printing
                Export(InitializeModule.ECT_Buttons.Print);
            }
        }

        private void SetCookie(string sCookie, string sValue)
        {
            HttpCookie aCookie = new HttpCookie(sCookie);
            aCookie.Value = sValue;
            aCookie.Expires = DateTime.Now.AddDays(360);
            Response.Cookies.Add(aCookie);
        }
        private string GetCookie(string sCookie)
        {
            string sValue = "";
            if (Request.Cookies[sCookie] != null)
            {
                HttpCookie aCookie = Request.Cookies[sCookie];
                sValue = Server.HtmlEncode(aCookie.Value);
            }
            return sValue;
        }
        protected void lnkSetCash_Click(object sender, EventArgs e)
        {
            SetCookie("CurrentCash", rbnCash.SelectedValue);
        }
        protected void grdFees_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_ACC_Search,
                        InitializeModule.enumPrivilege.ACCManageStFees, CurrentRole) != true)
            {
                //divMsg.InnerText = "Sorry you cannot manage st fees.";
                lbl_Msg.Text = "Sorry you cannot manage st fees.";
                div_msg.Visible = true;
                return;
            }
        }
        protected void grdDiscounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_ACC_Search,
                        InitializeModule.enumPrivilege.ACCManageStDiscounts, CurrentRole) != true)
            {
                //divMsg.InnerText = "Sorry you cannot manage st discount.";
                lbl_Msg.Text = "Sorry you cannot manage st discount.";
                div_msg.Visible = true;
                return;
            }
        }

        private string GetSQL(string sVoucher)
        {
            string sSQL = "";
            try
            {
                sSQL = "SELECT VH.strVoucherNo, VH.dateVoucher, VH.strAccountNo, A.strStudentName, A.lngStudentNumber, VD.lngEntryNo, VD.curCredit, VD.bytePaymentWay,";
                sSQL += " PT.strPaymentTypeEn AS PWay, C.strChequeNo, VD.dateDue, B.strBankEn AS Bank, VH.strRemark";
                sSQL += " FROM Acc_Voucher_Header AS VH INNER JOIN Acc_Voucher_Detail AS VD ON VH.intFy = VD.intFy AND VH.byteFSemester = VD.byteFSemester AND VH.strVoucherNo = VD.strVoucherNo INNER JOIN";
                sSQL += " Acc_PaymentsTypes AS PT ON VD.bytePaymentWay = PT.bytePaymentType LEFT OUTER JOIN Acc_Cheques AS C ON VD.lngCheque = C.lngCheque INNER JOIN";
                sSQL += " Reg_Student_Accounts AS A ON VH.strAccountNo = A.strAccountNo LEFT OUTER JOIN Acc_Banks AS B ON VD.intBank = B.intBank";
                sSQL += " WHERE VH.strVoucherNo = '" + sVoucher + "' AND VH.intFy = " + iCYear + " AND VH.byteFSemester =" + iCSem;
            }
            catch (Exception exp)
            {
                //divMsg.InnerText = exp.Message;
                lbl_Msg.Text = exp.Message;
                div_msg.Visible = true;
            }
            finally
            {

            }
            return sSQL;
        }

        private DataSet Prepare_Report(string sSQL)
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

                string sCash = rbnCash.SelectedItem.Text;
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
                ds.Tables.Add(dt);


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
            return ds;
        }

        private void Export(InitializeModule.ECT_Buttons iExport)
        {
            ReportDocument myReport = new ReportDocument();

            try
            {
                DataSet rptDS = new DataSet();
                rptDS = Prepare_Report(GetSQL(lblVoucher.Text));

                string reportPath = Server.MapPath("Reports/ACC_Voucher.rpt");
                myReport.Load(reportPath);
                myReport.SetDataSource(rptDS);
                //txtPrinter.Text = DefaultPrinterName();
                myReport.PrintOptions.PrinterName = txtPrinter.Text;
                //
                myReport.PrintOptions.PaperSize = SetPaperSize(myReport.PrintOptions.PrinterName);
                myReport.PrintToPrinter(1, false, 0, 0);

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
                //divMsg.InnerText = exp.Message;
                lbl_Msg.Text = exp.Message;
                div_msg.Visible = true;
            }
            finally
            {
                myReport.Close();
                myReport.Dispose();
            }
        }

        private string DefaultPrinterName()
        {
            string functionReturnValue = null;
            System.Drawing.Printing.PrinterSettings oPS = new System.Drawing.Printing.PrinterSettings();

            try
            {
                functionReturnValue = oPS.PrinterName;
            }
            catch (System.Exception ex)
            {
                functionReturnValue = "";
            }
            finally
            {
                oPS = null;
            }
            return functionReturnValue;
        }
        private CrystalDecisions.Shared.PaperSize SetPaperSize(string sPrinter)
        {
            int rawKind = 0;
            PrintDocument doctoprint = new System.Drawing.Printing.PrintDocument();
            doctoprint.PrinterSettings.PrinterName = sPrinter;
            for (int i = 0; i < doctoprint.PrinterSettings.PaperSizes.Count; i++)
            {

                if (doctoprint.PrinterSettings.PaperSizes[i].PaperName.ToLower() == "new" || doctoprint.PrinterSettings.PaperSizes[i].PaperName.ToLower() == "ihab")
                {
                    //rawKind = CInt(doctoprint.PrinterSettings.PaperSizes(i).GetType().GetField("kind", Reflection.BindingFlags.Instance Or Reflection.BindingFlags.NonPublic).GetValue(doctoprint.PrinterSettings.PaperSizes(i)))
                    rawKind = Convert.ToInt32(doctoprint.PrinterSettings.PaperSizes[i].GetType().GetField("kind", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(doctoprint.PrinterSettings.PaperSizes[i]));
                    return (CrystalDecisions.Shared.PaperSize)rawKind;
                }

            }
            return (CrystalDecisions.Shared.PaperSize)rawKind;
        }



        protected void lnkSetPrinter_Click(object sender, EventArgs e)
        {
            SetCookie("CurrentPrinter", txtPrinter.Text);
        }

        protected void ddlFinance_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(sSelectedText.Value))
                {
                    divMsg.InnerText = "Select a student please or the students hasn't account yet.";
                    return;
                }
                bool bStatus = false;
                if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_ACC_Search,
                      InitializeModule.enumPrivilege.ChangeOnlineStatus, CurrentRole) != true)
                {
                    bStatus = LibraryMOD.isFinanceProblems(Campus, sSelectedValue.Value);
                    ddlFinance.SelectedIndex = Convert.ToInt32(bStatus);
                    //divMsg.InnerText = "Sorry you cannot change online status for student";
                    lbl_Msg.Text = "Sorry you cannot change online status for student";
                    div_msg.Visible = true;

                    return;
                }

                bStatus = Convert.ToBoolean(ddlFinance.SelectedIndex);
                string sNo = sSelectedValue.Value;//getStAcc(sSelectedValue.Value);
                UpdateStFinance(sNo, ddlFinance.SelectedIndex);
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

        private void UpdateStFinance(string sSno, int iStatus)
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
                sSQL += " SET bOtherCollege = " + iStatus;
                sSQL += ",strUserSave='" + Session["CurrentUserName"].ToString() + "',dateLastSave=getDate(),strMachine='localect',strNUser='" + Session["CurrentUserName"].ToString() + "'";
                sSQL += " WHERE lngStudentNumber='" + sSno + "'";
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = sSQL;
                Cmd.ExecuteNonQuery();

                //divMsg.InnerText = "($) Has Finance updated successfully";
                lbl_Msg.Text = "($) Has Finance updated successfully";
                div_Alert.Attributes.Add("class", "alert alert-success alert-dismissible");
                div_msg.Visible = true;

            }
            catch (Exception exp)
            {
                //Console.WriteLine("{0} Exception caught.", exp);
                //divMsg.InnerText = "($) Has Finance not updated";
                lbl_Msg.Text = "($) Has Finance not updated";
                div_msg.Visible = true;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
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

                //divMsg.InnerText = "Is Acc Wanted? updated successfully";
                lbl_Msg.Text = "Is Acc Wanted? updated successfully";
                div_Alert.Attributes.Add("class", "alert alert-success alert-dismissible");
                div_msg.Visible = true;

            }
            catch (Exception exp)
            {
                //Console.WriteLine("{0} Exception caught.", exp);
                //divMsg.InnerText = "Is Acc Wanted? not updated";
                lbl_Msg.Text = "Is Acc Wanted? not updated";
                div_msg.Visible = true;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
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
                ddlRegTerm.SelectedValue = ddlRegTerm1.SelectedValue;
                //divMsg.InnerText = "Reg Term updated successfully";
                lbl_Msg.Text = "Reg Term updated successfully";
                div_Alert.Attributes.Add("class", "alert alert-success alert-dismissible");
                div_msg.Visible = true;
            }
            catch (Exception exp)
            {
                //Console.WriteLine("{0} Exception caught.", exp);
                //divMsg.InnerText = "Reg Term not updated";
                lbl_Msg.Text = "Reg Term not updated";
                div_msg.Visible = true;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }

        }

        protected void ddlACCWanted_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(sSelectedText.Value))
                {
                    //divMsg.InnerText = "Select a student please or the students hasn't account yet.";
                    lbl_Msg.Text = "Select a student please or the students hasn't account yet.";
                    div_msg.Visible = true;
                    return;
                }
                bool bStatus = false;
                if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_ACC_Search,
                      InitializeModule.enumPrivilege.ChangeOnlineStatus, CurrentRole) != true)
                {
                    bStatus = LibraryMOD.isACCWanted(sSelectedValue.Value, Campus);
                    ddlACCWanted.SelectedIndex = Convert.ToInt32(bStatus);
                    //divMsg.InnerText = "Sorry you cannot change online status for student";
                    lbl_Msg.Text = "Sorry you cannot change online status for student";
                    div_msg.Visible = true;

                    return;
                }

                bStatus = Convert.ToBoolean(ddlACCWanted.SelectedIndex);
                string sNo = sSelectedValue.Value;//getStAcc(sSelectedValue.Value);
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

        protected void Create_btn_Click(object sender, EventArgs e)
        {
            LibraryMOD myLibrary = new LibraryMOD();

            string sPaid = txtPaid.Text;
            string sRemind = txtRemind.Text;
            int iTerm = Convert.ToInt32(TestimonyTerm.SelectedValue.ToString());
            int iSem = 0;
            int iYear = LibraryMOD.SeperateTerm(iTerm, out iSem);
            string sTerm = "";

            bool isMale = (Campus_ddl.SelectedIndex == 0);

            switch (iSem)
            {
                case 1:
                    sTerm = "الفصل الاول لعام ";
                    break;
                case 2:
                    sTerm = "الفصل الثاني لعام ";
                    break;
                case 3:
                    sTerm = "الفصل الصيفي الاول لعام ";
                    break;
                case 4:
                    sTerm = "الفصل الصيفي الثاني لعام ";
                    break;
            }

            sTerm += iYear.ToString() + "-" + (iYear + 1).ToString();

            switch (optType.SelectedIndex)
            {
                case 0:
                    txtText.Text = getCurrentSemesterText(sPaid, isMale, sTerm);
                    break;
                case 1:
                    txtText.Text = getPaid_Remaining_till_GraduationText(sPaid, sRemind, isMale);
                    break;
                case 2:
                    txtText.Text = getPaid_OnlyText(sPaid, isMale);
                    break;
                case 3:
                    txtText.Text = getCurrent_RemainingText(sRemind, isMale);
                    break;
                case 4:
                    txtText.Text = getRemaining_till_graduationText(sRemind, isMale);
                    break;
            }

        }

        private string getCurrentSemesterText(string sPaid, bool isMale, string sTerm)
        {
            LibraryMOD myLibrary = new LibraryMOD();

            string sReturn = "تشهد إدارة كلية الإمارات للتكنولوجيا في أبوظبي بأن ";
            if (isMale == true)
            {
                sReturn += "الطالب المذكور أعلاه مسجل لدينا في ";
            }
            else
            {
                sReturn += "الطالبة المذكورة أعلاه مسجلة لدينا في ";
            }
            sReturn += sTerm;
            sReturn += "وتبلغ تكلفة الدراسة للفصل الحالي مبلغ وقدره ";
            sReturn += string.Format("{0:N0}", Convert.ToDouble(sPaid)) + "(" + myLibrary.strArabNumWord(Convert.ToInt32(sPaid), "", "") + ")";
            sReturn += "درهم ";
            return sReturn;
        }

        private string getPaid_Remaining_till_GraduationText(string sPaid, string sRemaining, bool isMale)
        {
            LibraryMOD myLibrary = new LibraryMOD();

            string sReturn = "تشهد إدارة كلية الإمارات للتكنولوجيا في أبوظبي بأن ";
            if (isMale == true)
            {
                sReturn += "الطالب المذكور أعلاه مسجل لدينا وقد قام بدفع مبلغ وقدره  ";
            }
            else
            {
                sReturn += "الطالبة المذكورة أعلاه مسجلة لدينا وقد قامت بدفع مبلغ وقدره  ";
            }

            sReturn += string.Format("{0:N0}", Convert.ToDouble(sPaid)) + "(" + myLibrary.strArabNumWord(Convert.ToInt32(sPaid), "", "") + ")";
            sReturn += "درهم ";

            if (isMale == true)
            {
                sReturn += "ويتبقى على الطالب مبلغ وقدره  ";
            }
            else
            {
                sReturn += "ويتبقى على الطالبة مبلغ وقدره  ";
            }

            sReturn += string.Format("{0:N0}", Convert.ToDouble(sRemaining)) + "(" + myLibrary.strArabNumWord(Convert.ToInt32(sRemaining), "", "") + ")";
            sReturn += "درهم ";

            if (isMale == true)
            {
                sReturn += " لإستكمال دراسته لدينا في الكلية";
            }
            else
            {
                sReturn += " لإستكمال دراستها لدينا في الكلية";
            }

            return sReturn;
        }

        private string getPaid_OnlyText(string sPaid, bool isMale)
        {
            LibraryMOD myLibrary = new LibraryMOD();

            string sReturn = "تشهد إدارة كلية الإمارات للتكنولوجيا في أبوظبي بأن ";
            if (isMale == true)
            {
                sReturn += "الطالب المذكور أعلاه مسجل لدينا وقد قام بدفع مبلغ وقدره  ";
            }
            else
            {
                sReturn += "الطالبة المذكورة أعلاه مسجلة لدينا وقد قامت بدفع مبلغ وقدره  ";
            }

            sReturn += string.Format("{0:N0}", Convert.ToDouble(sPaid)) + "(" + myLibrary.strArabNumWord(Convert.ToInt32(sPaid), "", "") + ")";
            sReturn += "درهم ";

            return sReturn;
        }

        private string getCurrent_RemainingText(string sRemaining, bool isMale)
        {
            LibraryMOD myLibrary = new LibraryMOD();

            string sReturn = "تشهد إدارة كلية الإمارات للتكنولوجيا في أبوظبي بأن ";
            if (isMale == true)
            {
                sReturn += "الطالب المذكور أعلاه مسجل لدينا ويتبقى على الطالب مبلغ وقدره  ";
            }
            else
            {
                sReturn += "الطالبة المذكورة أعلاه مسجلة لدينا ويتبقى على الطالبة مبلغ وقدره  ";
            }

            sReturn += string.Format("{0:N0}", Convert.ToDouble(sRemaining)) + "(" + myLibrary.strArabNumWord(Convert.ToInt32(sRemaining), "", "") + ")";
            sReturn += "درهم حتى تاريخه ";

            return sReturn;
        }

        private string getRemaining_till_graduationText(string sRemaining, bool isMale)
        {
            LibraryMOD myLibrary = new LibraryMOD();

            string sReturn = "تشهد إدارة كلية الإمارات للتكنولوجيا في أبوظبي بأن ";
            if (isMale == true)
            {
                sReturn += "الطالب المذكور أعلاه مسجل لدينا ويتبقى على الطالب مبلغ وقدره  ";
            }
            else
            {
                sReturn += "الطالبة المذكورة أعلاه مسجلة لدينا ويتبقى على الطالبة مبلغ وقدره  ";
            }

            sReturn += string.Format("{0:N0}", Convert.ToDouble(sRemaining)) + "(" + myLibrary.strArabNumWord(Convert.ToInt32(sRemaining), "", "") + ")";
            if (isMale == true)
            {
                sReturn += "درهم لإستكمال دراسته لدينا  ";
            }
            else
            {
                sReturn += "درهم لإستكمال دراستها لدينا  ";
            }

            return sReturn;
        }
        protected void Print_Text_Click(object sender, ImageClickEventArgs e)
        {
            if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_ACC_Search,
                       InitializeModule.enumPrivilege.Print, CurrentRole) != true)
            {
                //divMsg.InnerText = "Sorry you cannot print quotations!";
                lbl_Msg.Text = "Sorry you cannot print quotations!";
                div_msg.Visible = true;
                return;
            }

            Retrieve();

        }

        private void Retrieve()
        {

            DataSet ds = new DataSet();
            string sStudentNumber = sSelectedValue.Value;
            try
            {

                string sSQL = "";


                sSQL = "SELECT  A.lngStudentNumber AS sSID, SD.strLastDescAr AS sName, M.strSpecializationDescAr AS sMajor";
                sSQL += " FROM  Reg_Applications AS A INNER JOIN Reg_Students_Data AS SD ON A.lngSerial = SD.lngSerial INNER JOIN";
                sSQL += " Reg_Specializations AS M ON A.strCollege = M.strCollege AND A.strDegree = M.strDegree AND A.strSpecialization = M.strSpecialization";
                sSQL += " Where A.lngStudentNumber = '" + sStudentNumber + "'";


                ds = Prepare_Quotation(sSQL);

            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex.Message);
            }
            finally
            {

                Session["ReportDS"] = ds;
                ExportQuotation();
            }

        }

        private DataSet Prepare_Quotation(string sSQL)
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            Conn.Open();

            Connection_StringCLS myConnection_String2 = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew);
            SqlConnection Conn2 = new SqlConnection(myConnection_String2.Conn_string);
            Conn2.Open();

            DataTable dt = new DataTable();
            DataRow dr;
            DataSet ds = new DataSet();
            try
            {
                bool isMale = (Campus_ddl.SelectedIndex == 0);


                DataColumn myCol;

                myCol = new DataColumn("iSerial", Type.GetType("System.Int32"));
                dt.Columns.Add(myCol);
                myCol = new DataColumn("sName", Type.GetType("System.String"));
                dt.Columns.Add(myCol);
                myCol = new DataColumn("sSID", Type.GetType("System.String"));
                dt.Columns.Add(myCol);
                myCol = new DataColumn("sDate", Type.GetType("System.String"));
                dt.Columns.Add(myCol);
                myCol = new DataColumn("sMajor", Type.GetType("System.String"));
                dt.Columns.Add(myCol);
                myCol = new DataColumn("sText", Type.GetType("System.String"));
                dt.Columns.Add(myCol);
                myCol = new DataColumn("sFooter", Type.GetType("System.String"));
                dt.Columns.Add(myCol);
                myCol = new DataColumn("sRef", Type.GetType("System.String"));
                dt.Columns.Add(myCol);


                SqlCommand Cmd = new SqlCommand(sSQL, Conn);
                SqlDataReader Rd = Cmd.ExecuteReader();

                string sUser = Session["CurrentUserName"].ToString();
                string sRef = "";

                string sUserRef = LibraryMOD.GetColValue(Conn2, "EmployeeName", "Cmn_User", "UserName='" + sUser + "'");

                int iTerm = Convert.ToInt32(TestimonyTerm.SelectedValue.ToString());
                int iSem = 0;
                int iYear = LibraryMOD.SeperateTerm(iTerm, out iSem);

                //int iCYear = DateTime.Today.Year;

                int iMax = LibraryMOD.GetMaxID(Conn, "iSerial", "ACC_Quotation", "iYear=" + iYear + " AND iRef=" + sUserRef);

                sRef = sUserRef + (iYear).ToString() + string.Format("{0:0000}", iMax + 1);

                string sFooter = "أعطيت لها هذه الشهادة بناء على طلبها دون تحمل أدنى مسؤولية تجاه الغير";
                string sSID = "";
                string sMajor = "";
                while (Rd.Read())
                {
                    dr = dt.NewRow();
                    dr["iSerial"] = 1;
                    dr["sName"] = Rd["sName"].ToString();
                    sSID = Rd["sSID"].ToString();
                    dr["sSID"] = sSID;
                    sMajor = Rd["sMajor"].ToString();
                    dr["sMajor"] = sMajor;
                    dr["sDate"] = string.Format("{0:yyyy-MM-dd}", DateTime.Today.Date);
                    dr["sText"] = txtText.Text;
                    if (isMale == true)
                    {
                        sFooter = "أعطيت له هذه الشهادة بناء على طلبه دون تحمل أدنى مسؤولية تجاه الغير";
                    }
                    else
                    {
                        sFooter = "أعطيت لها هذه الشهادة بناء على طلبها دون تحمل أدنى مسؤولية تجاه الغير";
                    }
                    dr["sFooter"] = sFooter;
                    dr["sRef"] = sRef;

                    dt.Rows.Add(dr);
                }
                Rd.Close();
                dt.TableName = "QuotationDt";
                dt.AcceptChanges();
                ds.Tables.Add(dt);


                sSQL = "INSERT INTO ACC_Quotation";
                sSQL += " (iYear,iSem,iRef,iSerial,sRef,dDate,sSID,sMajor,sText,sFooter)";
                sSQL += " Values(" + iYear + "," + iSem + "," + sUserRef + "," + (iMax + 1) + ",'" + sRef + "'";
                sSQL += ",getdate(),'" + sSID + "','" + sMajor + "','" + txtText.Text + "','" + sFooter + "')";

                Cmd.CommandText = sSQL;

                int iInserted = 0;
                iInserted = Cmd.ExecuteNonQuery();




            }
            catch (Exception exp)
            {
                Console.WriteLine("{0} Exception caught.", exp);
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
                Conn2.Close();
                Conn2.Dispose();
            }
            return ds;
        }

        private void ExportQuotation()
        {
            ReportDocument myReport = new ReportDocument();
            DataSet ds = new DataSet();
            try
            {
                ds = (DataSet)Session["ReportDS"];
                string reportPath = Server.MapPath("Reports/Quotation.rpt");
                myReport.Load(reportPath);
                myReport.SetDataSource(ds);

                //myReport.PrintOptions.PaperOrientation = PaperOrientation.Portrait;


                TextObject txt;
                txt = (TextObject)myReport.ReportDefinition.ReportObjects["txtName"];

                bool isMale = (Campus_ddl.SelectedIndex == 0);

                if (isMale == true)
                {
                    txt.Text = "اسم الطالب";
                }
                else
                {
                    txt.Text = "اسم الطالبة";
                }

                txt = (TextObject)myReport.ReportDefinition.ReportObjects["txtPriceAdd"];
                txt.ObjectFormat.EnableSuppress = (optType.SelectedIndex == 0 || optType.SelectedIndex == 2 || optType.SelectedIndex == 3);


                txt = (TextObject)myReport.ReportDefinition.ReportObjects["txtVAT"];
                txt.ObjectFormat.EnableSuppress = (optType.SelectedIndex == 2);
                //txt.Text = "المبلغ المستحق ابتداء من تاريخ 2018/01/01 يشمل قيمة الضريبة المضافة";

                myReport.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Page.Response, true, "ECTReport");
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
                divMsg.InnerText = exp.Message;
            }
            finally
            {
                myReport.Close();
                myReport.Dispose();
            }
        }

        protected void ddlRegTerm1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(sSelectedText.Value))
                {
                    divMsg.InnerText = "Select a student please or the students hasn't account yet.";
                    return;
                }
                int iTerm = 0;
                if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_ACC_Search,
                      InitializeModule.enumPrivilege.ChangeOnlineStatus, CurrentRole) != true)
                {
                    iTerm = int.Parse(ddlRegTerm.SelectedValue);
                    ddlRegTerm1.SelectedValue = ddlRegTerm.SelectedValue;
                    //divMsg.InnerText = "Sorry you cannot change reg term for student";
                    lbl_Msg.Text = "Sorry you cannot change reg term for student";
                    div_msg.Visible = true;

                    return;
                }

                iTerm = int.Parse(ddlRegTerm1.SelectedValue);
                string sAccount = sSelectedText.Value;//getStAcc(sSelectedValue.Value);
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


        protected void grdCheques_SelectedIndexChanged(object sender, EventArgs e)
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            Conn.Open();
            try
            {
                //ACCChequePaid=112,
                //ACCChequeReturned=113,
                //ACCChequeCanceled=114,
                //ACCChequeInsurance=115,
                if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_ACC_Search,
                            InitializeModule.enumPrivilege.ACCManageStPayment, CurrentRole) != true)
                {
                    //divMsg.InnerText = "Sorry you cannot manage st cheques.";
                    lbl_Msg.Text = "Sorry you cannot manage st cheques.";
                    div_msg.Visible = true;
                    return;
                }
                int iTerm = Convert.ToInt32(grdCheques.SelectedDataKey["Term"].ToString());
                int iYear, iSem;
                iYear = LibraryMOD.SeperateTerm(iTerm, out iSem);
                string sVno = grdCheques.SelectedDataKey["VNo"].ToString();
                int iSerial = Convert.ToInt32(grdCheques.SelectedDataKey["Serial"].ToString());

                string sSQL = "SELECT VD.byteStatus, C.strChequeNo, B.strBankEn, VD.curCredit, VD.dateDue";
                sSQL += " FROM Acc_Voucher_Detail AS VD INNER JOIN Acc_Cheques AS C ON VD.lngCheque = C.lngCheque INNER JOIN Acc_Banks AS B ON VD.intBank = B.intBank";
                sSQL += " WHERE (intFy = " + iYear + ") AND (byteFSemester = " + iSem + ") AND (strVoucherNo = '" + sVno + "') AND (lngEntryNo = " + iSerial + ")";

                lblCheque.Text = "";
                lblBank.Text = "";
                lblChCredit.Text = "";
                lblDueDate.Text = "";

                SqlCommand Cmd = new SqlCommand(sSQL, Conn);
                SqlDataReader rd = Cmd.ExecuteReader();
                while (rd.Read())
                {
                    int iStatus = Convert.ToInt32(rd["byteStatus"].ToString());
                    hdnStatus.Value = iStatus.ToString();
                    lblCheque.Text = rd["strChequeNo"].ToString();
                    lblBank.Text = rd["strBankEn"].ToString();
                    lblChCredit.Text = string.Format("{0:f}", rd["curCredit"]);
                    lblDueDate.Text = string.Format("{0:dd/MM/yyyy}", rd["dateDue"]);
                }
                rd.Close();
                ddlChStatus.SelectedValue = hdnStatus.Value;
                lblChMsg.Text = "";
                MVCheque.ActiveViewIndex = 1;

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
        protected void btnUndoStatus_Click(object sender, ImageClickEventArgs e)
        {
            hdnStatus.Value = "0";
            MVCheque.ActiveViewIndex = 0;
        }
        protected void btnSaveStatus_Click(object sender, ImageClickEventArgs e)
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            Conn.Open();
            try
            {
                //0	Entry
                //1	Paid
                //2	Returned
                //3	Insurance
                //4	Canceled
                int iOldStatus = Convert.ToInt32(hdnStatus.Value);
                int iNewStatus = Convert.ToInt32(ddlChStatus.SelectedValue);

                if (iNewStatus == 0)
                {
                    lblChMsg.Text = "Sorry you cannot change to entry status.";
                    ddlChStatus.SelectedValue = iOldStatus.ToString();
                    return;
                }


                if (iOldStatus == 4)
                {
                    lblChMsg.Text = "Sorry you cannot change canceled status.";
                    ddlChStatus.SelectedValue = iOldStatus.ToString();
                    return;
                }
                else if (iOldStatus == 3 || iOldStatus == 2)
                {
                    if (iNewStatus != 4)
                    {
                        lblChMsg.Text = "Returned and insurance statuses can be changed to canceled only.";
                        ddlChStatus.SelectedValue = iOldStatus.ToString();
                        return;
                    }
                }


                int iTerm = Convert.ToInt32(grdCheques.SelectedDataKey["Term"].ToString());
                int iYear, iSem;
                iYear = LibraryMOD.SeperateTerm(iTerm, out iSem);
                string sVno = grdCheques.SelectedDataKey["VNo"].ToString();
                int iSerial = Convert.ToInt32(grdCheques.SelectedDataKey["Serial"].ToString());

                string sSQL = "UPDATE Acc_Voucher_Detail";
                sSQL += " SET byteStatus = " + iNewStatus + ",strUserSave ='" + Session["CurrentUserName"].ToString() + "',dateLastSave=GETDATE() ,strNUser ='" + Session["CurrentUserName"].ToString() + "',strMachine = 'localect'";
                sSQL += " WHERE (intFy = " + iYear + ") AND (byteFSemester = " + iSem + ") AND (strVoucherNo = '" + sVno + "') AND (lngEntryNo = " + iSerial + ")";

                SqlCommand Cmd = new SqlCommand(sSQL, Conn);

                int iUpdated = Cmd.ExecuteNonQuery();
                if (iUpdated > 0)
                {
                    sSQL = "UPDATE Acc_Cheques";
                    sSQL += " SET byteStatus = " + iNewStatus + ",strUserSave ='" + Session["CurrentUserName"].ToString() + "',dateLastSave=GETDATE() ,strNUser ='" + Session["CurrentUserName"].ToString() + "',strMachine = 'localect'";
                    sSQL += " WHERE lngCheque in(SELECT lngCheque FROM Acc_Voucher_Detail";
                    sSQL += " WHERE (intFy = " + iYear + ") AND (byteFSemester = " + iSem + ") AND (strVoucherNo = '" + sVno + "') AND (lngEntryNo = " + iSerial + "))";
                    Cmd.CommandText = sSQL;
                    iUpdated = Cmd.ExecuteNonQuery();
                    lblChMsg.Text = "Cheque status updated successfully.";
                }
                else
                {
                    lblChMsg.Text = "Cheque status not updated.";
                }

                grdCheques.DataBind();
                MVCheque.ActiveViewIndex = 0;

            }
            catch (Exception exp)
            {
                lblChMsg.Text = "Cheque status not updated.";
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }

        }

        private string getAccNotification(string sAcc, InitializeModule.EnumCampus Cmps)
        {
            string sNotification = "";
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Cmps);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            Conn.Open();
            try
            {
                string sSQL = "SELECT strAccNotification FROM Reg_Student_Accounts WHERE strAccountNo='" + sAcc + "'";
                SqlCommand Cmd = new SqlCommand(sSQL, Conn);
                SqlDataReader rd = Cmd.ExecuteReader();
                while (rd.Read())
                {
                    sNotification = rd["strAccNotification"].ToString();
                }
                rd.Close();
            }
            catch (Exception exp)
            {

            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }
            return sNotification;
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
                    //divMsg.InnerText = "Sorry, You are not authorized to change (" + ddlFinanceCat.SelectedItem.Text + ") category";
                    lbl_Msg.Text = "Sorry, You are not authorized to change (" + ddlFinanceCat.SelectedItem.Text + ") category";
                    div_msg.Visible = true;
                }
                else
                {
                    string sUser = Session["CurrentUserName"].ToString();
                    Session["CurrentFinCat"] = Convert.ToInt32(ddlFinanceCat.SelectedValue);
                    int iEffected = LibraryMOD.UpdateFinanceCategory(sSelectedValue.Value, Convert.ToInt32(ddlFinanceCat.SelectedValue), sUser);
                    if (iEffected > 0)
                    {
                        //divMsg.InnerText = "Finance category updated to (" + ddlFinanceCat.SelectedItem.Text + ")";
                        lbl_Msg.Text = "Finance category updated to (" + ddlFinanceCat.SelectedItem.Text + ")";
                        div_msg.Visible = true;
                    }
                }
            }


            //ddlFinanceCat.SelectedValue = iFinCat.ToString();}

        }

        protected void lnk_setOpportunity_Click(object sender, EventArgs e)
        {
            if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Student_Data,
                     InitializeModule.enumPrivilege.UpdateCRMOpportunity, CurrentRole) != true)
            {
                lbl_Msg.Text = "Sorry you cannot update CRM Opportunity";
                div_msg.Visible = true;
                return;
            }

            if (drp_setstatus.SelectedItem.Text== "Pending Payment")
            {
                updateaccountpayemtpending(Convert.ToInt32(hdn_iOpportunityID.Value), hdn_Acc.Value, Request.QueryString["sid"].ToString());
            }
            else
            {
                updateopportunitypaymentsucceeded(Convert.ToInt32(hdn_iOpportunityID.Value), Request.QueryString["sid"].ToString());
            }
            getopportunity(sNo);
        }
        public void updateopportunitypaymentsucceeded(int iOpportunity,string sSID)
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            if (iOpportunity > 0)
            {
                //this.ClientScript.RegisterStartupScript(this.GetType(), "test", "setOpportunity();", true);
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.DefaultConnectionLimit = 9999;
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
                string accessToken = InitializeModule.CxPwd;

                using (var httpClient = new HttpClient())
                {
                    using (var request = new HttpRequestMessage(new HttpMethod("PATCH"), "https://ect.custhelp.com/services/rest/connect/v1.4/opportunities/" + iOpportunity + ""))
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
                            SetOpportunity(sSID,1);
                            lbl_Msg.Text = "Opportunity Updated Successfully-Contact the Accountant to allow the Registration Process";
                            div_Alert.Attributes.Add("class", "alert alert-success alert-dismissible");
                            div_msg.Visible = true;
                        }
                        else
                        {
                            lbl_Msg.Text = "Error- " + s + "";
                            div_msg.Visible = true;
                        }
                    }
                }
            }
            else
            {
                lbl_Msg.Text = "Invalid Opportunity ID";
                div_msg.Visible = true;
            }
        }
        public void updateaccountpayemtpending(int iOpportunity, string sAcc,string sSID)
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            if (iOpportunity > 0)
            {
                //this.ClientScript.RegisterStartupScript(this.GetType(), "test", "setOpportunity();", true);
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.DefaultConnectionLimit = 9999;
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
                string accessToken = InitializeModule.CxPwd;

                using (var httpClient = new HttpClient())
                {
                    using (var request = new HttpRequestMessage(new HttpMethod("PATCH"), "https://ect.custhelp.com/services/rest/connect/v1.4/opportunities/" + iOpportunity + ""))
                    {
                        request.Headers.TryAddWithoutValidation("Authorization", accessToken);
                        request.Headers.TryAddWithoutValidation("OSvC-CREST-Application-Context", "application/x-www-form-urlencoded");

                        request.Content = new StringContent("{\n\t\t\"statusWithType\": {\n        \"status\": {\n            \"id\": 113\n        }\n    }\n}");
                        request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                        var task = httpClient.SendAsync(request);
                        task.Wait();
                        var response = task.Result;
                        string s = response.Content.ReadAsStringAsync().Result;
                        //If Status 200
                        if (response.IsSuccessStatusCode == true)
                        {
                            SetOpportunity(sSID, 0);
                            SqlCommand cmd1 = new SqlCommand("update Reg_Student_Accounts set iAdmissionPaymentType=@iAdmissionPaymentType,cAdmissionPaymentValue=@cAdmissionPaymentValue where strAccountNo=@strAccountNo", Conn);
                            cmd1.Parameters.AddWithValue("@iAdmissionPaymentType", "1");//Original Payment
                            cmd1.Parameters.AddWithValue("@cAdmissionPaymentValue", "3500");
                            cmd1.Parameters.AddWithValue("@strAccountNo", sAcc);
                            try
                            {
                                Conn.Open();
                                cmd1.ExecuteNonQuery();
                                Conn.Close();
                            }
                            catch (Exception ex)
                            {
                                Conn.Close();
                                Console.WriteLine(ex.Message);
                            }
                            finally
                            {
                                Conn.Close();
                            }
                            sentsms(hdn_Phone1.Value, sSID);//hdn_Phone1.Value

                            lbl_Msg.Text = "Opportunity Updated Successfully-AED 3500 is requested from the student unless the Accoutant changed Admission Payment Value";
                            div_Alert.Attributes.Add("class", "alert alert-success alert-dismissible");
                            div_msg.Visible = true;
                        }
                        else
                        {
                            lbl_Msg.Text = "Error- "+ s + "";
                            div_msg.Visible = true;
                        }
                    }
                }
            }
            else
            {
                lbl_Msg.Text = "Invalid Opportunity ID";
                div_msg.Visible = true;
            }
        }
        public static bool SetOpportunity(string sSID,int status)
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

                string sSQL = "UPDATE Reg_Applications SET isOpportunitySet="+ status + "";
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
        public void sentsms(string phone1, string sID)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.DefaultConnectionLimit = 9999;
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;

            if (!string.IsNullOrEmpty(phone1))
            {
                phone1 = LibraryMOD.CleanPhone(phone1);
                if (phone1.Substring(0, 1) == "0")
                {
                    phone1 = "+971" + phone1.Remove(0, 1);
                }
                phone1 = phone1.Trim();
                string sisusername = sID;
                string sispassword = "";
                Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
                SqlConnection sc = new SqlConnection(myConnection_String.Conn_string);
                SqlCommand cmd = new SqlCommand("SELECT  [UserNo],[UserName],[Password] FROM [localect].[ECTDataNew].[dbo].[Cmn_User] where UserNo in (SELECT intOnlineUser from [ECTData].[dbo].[Reg_Student_Accounts] where lngStudentNumber=@lngStudentNumber)", sc);
                cmd.Parameters.AddWithValue("@lngStudentNumber", sID);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                try
                {
                    sc.Open();
                    da.Fill(dt);
                    sc.Close();

                    if (dt.Rows.Count > 0)
                    {
                        sisusername = dt.Rows[0]["UserName"].ToString();
                        sispassword = dt.Rows[0]["Password"].ToString();

                        string txt = "Welcome to ECT\r\nKindly find the following ECT SIS Credentials:\r\nUser : " + sisusername + "\r\nPassword : " + sispassword + "\r\nLink : https://ectsis.ect.ac.ae/Balance";
                        string textmessage = txt.Trim().Replace("\r\n", "\\r\\n");
                        if (phone1.Trim().StartsWith("+971") && phone1.Substring(4, 1) == "5")
                        {
                            using (var httpClient = new HttpClient())
                            {
                                using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://c-eu.linkmobility.io/sms/send"))
                                {
                                    request.Headers.TryAddWithoutValidation("Authorization", "Basic cE9UZ1oyTFc6R2NuMzU1MzJHcXc=");

                                    request.Content = new StringContent("{\n    \"source\": \"AD-ECT\",\n    \"sourceTON\":\"ALPHANUMERIC\",\n    \"destination\": \"" + phone1.Trim() + "\",\n    \"userData\": \"" + textmessage + "\",\n    \"platformId\": \"SMSC\",\n    \"platformPartnerId\": \"3759\",\n    \"useDeliveryReport\": false,\n    \"customParameters\": {\n\"replySmsCount\": \"true\"\n}\n}");
                                    //request.Content = new StringContent("{\n    \"source\": \"LINK\",\n    \"destination\": \"" + txt_Mobile.Text.Trim() + "\",\n    \"userData\": \"" + txt_Text.Text.Trim() + "\",\n    \"platformId\": \"SMSC\",\n    \"platformPartnerId\": \"3759\",\n    \"useDeliveryReport\": false\n}");
                                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                                    var task = httpClient.SendAsync(request);
                                    task.Wait();
                                    var response = task.Result;
                                    string s = response.Content.ReadAsStringAsync().Result;
                                    if (response.IsSuccessStatusCode == true)
                                    {
                                        //Success
                                        //lbl_Msg.Text = "SMS Sent";
                                        //div_Alert.Attributes.Add("class", "alert alert-success alert-dismissible");
                                        //div_msg.Visible = true;
                                    }
                                }
                            }
                        }
                        else
                        {
                            //lbl_Msg.Text = "Invalid Mobile Number";
                            //div_Alert.Attributes.Add("class", "alert alert-success alert-dismissible");
                            //return;
                        }
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
            }
            else
            {

            }
        }
    }
}