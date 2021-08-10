using System;
using System.Collections;
using System.Configuration;
using LocalECT.DAL;
using System.Data;
//using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
//using System.Xml.Linq;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using Microsoft.Office.Interop.Word;
using Microsoft.VisualBasic;

namespace LocalECT
{
    public partial class Strategy_Strategic_Evidence_Home : System.Web.UI.Page
    {
        int CurrentRole = 0;

        public int ClrPrjRed;
        public int ClrCelDarkBlue;
        public int ClrCelLightGray;
        public int ClrCelAquaBlue;
        public int ClrCelLightBlue;
        public int ClrCelLightGreen;
        protected void Page_Load(object sender, EventArgs e)
        {
            string strRefPage = "";
            if (Request.UrlReferrer != null)
            {
                strRefPage = Request.UrlReferrer.Segments[Request.UrlReferrer.Segments.Length - 1];
            }
            else
            {
                Server.Transfer("Authorization.aspx");
            }
            try
            {
                if (Session["CurrentRole"] != null)
                {
                    CurrentRole = (int)Session["CurrentRole"];
                    if (!IsPostBack)
                    {
                        //if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.Strategic_Evidence,
                        //InitializeModule.enumPrivilege.ShowBrowse, CurrentRole) != true)
                        //{
                        //    Server.Transfer("Authorization.aspx");
                        //}
                    }
                }
                else
                {
                    Session.RemoveAll();
                    Response.Redirect("Login.aspx");

                }
                if (Session["CurrentUserName"] != null)
                {
                    if (!IsPostBack)
                    {
                        bindStrategic_Evidence();
                    }
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine("{0} Exception caught.", exp);
            }
            finally
            {

            }
        }

        public void bindStrategic_Evidence()
        {
            string id = Request.QueryString["id"];

            Connection_StringCLS myConnection_String = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew);
            SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["ECTDataNew"].ConnectionString);

            string sSQL = "";
            sSQL += " SELECT        CS_Strategic_Evidence.iSerial, CS_Strategic_Evidence.sRevisionNo, CS_Strategic_Evidence.iEvidenceType, CS_Strategic_Evidence.sEvidenceTitle, CS_Strategic_Evidence.sAbbreviation,  ";
            sSQL += "                          CS_Strategic_Evidence.sEvidenceSerial, CS_Strategic_Evidence.iDepartment, CS_Strategic_Evidence.iSection, CS_Strategic_Evidence.sEvidenceRecored, CS_Strategic_Evidence.isIRQASurveyReportRequired,  ";
            sSQL += "                          CS_Strategic_Evidence.iCustomerExperienceEvidenceCategory, CS_Strategic_Evidence.iCustomerExperienceEvidenceSubCategory, CS_Strategic_Evidence.iOrder, CS_Strategic_Evidence.iStrategyVersion,  ";
            sSQL += "                          CS_Strategic_Evidence.dAdded, CS_Strategic_Evidence.sAddedBy, CS_Strategic_Evidence.dUpdated, CS_Strategic_Evidence.sUpdatedBy, CS_Evidence_Type.sEvidenceType, Lkp_Department.DescEN,  ";
            sSQL += "                          Lkp_Department.DepartmentAbbreviation, Lkp_Section.SectionAbbreviation, Lkp_Section.DescEN AS Expr1, CS_Customer_Experience_Evidence_Category.sCustomerExperienceEvidenceCategory,  ";
            sSQL += "                          CS_Customer_Experience_Evidence_Sub_Category.sCustomerExperienceEvidenceSubCategory, CS_Strategy_Version.sStrategyVersion, CS_Strategic_Evidence.iProject, CS_Strategic_Project.sStrategicProjectID,  ";
            sSQL += "                          CS_Strategic_Project.sStrategicProjectDesc ";
            sSQL += " FROM            CS_Strategy_Version INNER JOIN ";
            sSQL += "                          CS_Customer_Experience_Evidence_Sub_Category INNER JOIN ";
            sSQL += "                          CS_Customer_Experience_Evidence_Category INNER JOIN ";
            sSQL += "                          Lkp_Section INNER JOIN ";
            sSQL += "                          CS_Evidence_Type INNER JOIN ";
            sSQL += "                          CS_Strategic_Evidence ON CS_Evidence_Type.iSerial = CS_Strategic_Evidence.iEvidenceType INNER JOIN ";
            sSQL += "                          Lkp_Department ON CS_Strategic_Evidence.iDepartment = Lkp_Department.DepartmentID ON Lkp_Section.SectionID = CS_Strategic_Evidence.iSection ON  ";
            sSQL += "                          CS_Customer_Experience_Evidence_Category.iSerial = CS_Strategic_Evidence.iCustomerExperienceEvidenceCategory ON  ";
            sSQL += "                          CS_Customer_Experience_Evidence_Sub_Category.iSerial = CS_Strategic_Evidence.iCustomerExperienceEvidenceSubCategory ON CS_Strategy_Version.iSerial = CS_Strategic_Evidence.iStrategyVersion INNER JOIN ";
            sSQL += "                          CS_Strategic_Project ON CS_Strategic_Evidence.iProject = CS_Strategic_Project.iSerial ";
            if (id != null)
            {
                sSQL += " where CS_Strategic_Evidence.iSerial=" + id + "";
            }
            else if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.Strategic_Evidence,
                        InitializeModule.enumPrivilege.ShowAll, CurrentRole) != true)
            {
                sSQL += "where CS_Strategic_Evidence.iProject in (";
                //string sSQL1 = "SELECT CS_Strategic_Goal.iSerial, CS_Strategic_Goal.sStrategicGoalID, CS_Strategic_Goal.sStrategicGoalDesc, CS_Strategic_Goal.iStipulation, CS_Strategic_Goal.iInspectioncomplianceStandard, CS_Strategic_Goal.iOrder, CS_Strategic_Goal.iStrategyVersion, CS_Strategic_Goal.dAdded, CS_Strategic_Goal.sAddedBy, CS_Strategic_Goal.dUpdated, CS_Strategic_Goal.sUpdatedBy, CS_Strategic_Goal.sAbbreviation, CS_Strategic_Goal.iTheme, CS_Strategic_Goal.sImagePath, CS_Strategic_Goal.iLevel, CS_Inspection_Compliance_Standard.sInspectionComplianceStandardDesc, CS_Stipulation.sStipulationDesc, CS_Strategic_Theme.sThemeCode,CS_Strategic_Theme.sThemeDesc, CS_Strategy_Version.sStrategyVersion FROM CS_Strategic_Theme INNER JOIN CS_Strategy_Version INNER JOIN CS_Stipulation INNER JOIN CS_Strategic_Goal ON CS_Stipulation.iSerial = CS_Strategic_Goal.iStipulation INNER JOIN CS_Inspection_Compliance_Standard ON CS_Strategic_Goal.iInspectioncomplianceStandard = CS_Inspection_Compliance_Standard.iSerial ON CS_Strategy_Version.iSerial = CS_Strategic_Goal.iStrategyVersion ON CS_Strategic_Theme.iSerial = CS_Strategic_Goal.iTheme where CS_Strategic_Goal.iSerial in (";

                string sSQL1 = " SELECT        ObjectID ";
                sSQL1 += "        FROM            (SELECT        TH.iSerial AS ObjectID, TH.sThemeDesc AS ObjectNameEn, TH.sThemeCode AS DisplayObjectName, TH.iOrder AS ShowOrder, 14 AS SystemID, 1299 AS ParentID, 'Strategy_Strategic_Theme_Home.aspx?f=m&id=' + CONVERT(varchar, TH.iSerial)   ";
                sSQL1 += "                                                            AS sURL, TH.iLevel + 1 AS iLevel, 1 AS Privilege  ";
                sSQL1 += "                                  FROM            (SELECT        ES.EmployeeID, SI.iSerial AS SIID, SI.iTheme, SI.iGoal, SI.iProject, SI.iObjective, SI.iOrder, SIDS.isPrincipal  ";
                sSQL1 += "                                                            FROM            CS_Strategic_Initiative AS SI INNER JOIN  ";
                sSQL1 += "                                                                                      CS_Initiative_Dpartment_Section AS SIDS ON SI.iSerial = SIDS.iInitiative INNER JOIN  ";
                sSQL1 += "                                                                                      CS_Employees_Sections AS ES ON SIDS.iDepartment = ES.DepartmentID AND SIDS.iSection = ES.SectionID  ";
                sSQL1 += "                                                        WHERE        (ES.EmployeeID = " + Session["EmployeeID"].ToString() + ")    ) AS C INNER JOIN  ";
                sSQL1 += "                                                            CS_Strategic_Theme AS TH ON C.iTheme = TH.iSerial  ";
                sSQL1 += "                                  UNION ALL  ";
                sSQL1 += "                                  SELECT        SG.iSerial as ObjectID,CONVERT(varchar(100),SG.sStrategicGoalDesc) AS ObjectNameEn, SG.sAbbreviation AS DisplayObjectName, SG.iOrder AS ShowOrder, 14 AS SystemID, C_4.iTheme AS ParentID,   ";
                sSQL1 += "                                                           'Strategy_Strategic_Goal_Home.aspx?f=m&id=' + CONVERT(varchar, SG.iSerial) AS sURL, SG.iLevel + 1 AS iLevel, 1 AS Privilege  ";
                sSQL1 += "                                  FROM            (SELECT        ES.EmployeeID, SI.iSerial AS SIID, SI.iTheme, SI.iGoal, SI.iProject, SI.iObjective, SI.iOrder, SIDS.isPrincipal  ";
                sSQL1 += "                                                            FROM            CS_Strategic_Initiative AS SI INNER JOIN  ";
                sSQL1 += "                                                                                      CS_Initiative_Dpartment_Section AS SIDS ON SI.iSerial = SIDS.iInitiative INNER JOIN  ";
                sSQL1 += "                                                                                      CS_Employees_Sections AS ES ON SIDS.iDepartment = ES.DepartmentID AND SIDS.iSection = ES.SectionID  ";
                sSQL1 += "                                                          WHERE        (ES.EmployeeID = " + Session["EmployeeID"].ToString() + ")      ) AS C_4 INNER JOIN  ";
                sSQL1 += "                                                           CS_Strategic_Goal AS SG ON C_4.iGoal = SG.iSerial  ";
                sSQL1 += "                                  UNION ALL  ";
                sSQL1 += "                                  SELECT        SP.iSerial as ObjectID, CONVERT(varchar(100),SP.sStrategicProjectDesc) AS ObjectNameEn, SP.sAbbreviation AS DisplayObjectName, SP.iOrder, 14 AS SystemID, C_3.iGoal * 10 AS ParentID, 'Strategy_Strategic_Project_Home.aspx?f=m&id=' + CONVERT(varchar,   ";
                sSQL1 += "                                                           SP.iSerial) AS sURL, SP.iLevel + 1 AS iLevel, 1 AS Privilege  ";
                sSQL1 += "                                  FROM            (SELECT        ES.EmployeeID, SI.iSerial AS SIID, SI.iTheme, SI.iGoal, SI.iProject, SI.iObjective, SI.iOrder, SIDS.isPrincipal  ";
                sSQL1 += "                                                            FROM            CS_Strategic_Initiative AS SI INNER JOIN  ";
                sSQL1 += "                                                                                      CS_Initiative_Dpartment_Section AS SIDS ON SI.iSerial = SIDS.iInitiative INNER JOIN  ";
                sSQL1 += "                                                                                      CS_Employees_Sections AS ES ON SIDS.iDepartment = ES.DepartmentID AND SIDS.iSection = ES.SectionID  ";
                sSQL1 += "                                                            WHERE        (ES.EmployeeID = "+ Session["EmployeeID"].ToString() + ")     ) AS C_3 INNER JOIN  ";
                sSQL1 += "                                                           CS_Strategic_Project AS SP ON C_3.iProject = SP.iSerial  ";
                sSQL1 += "                                  UNION ALL  ";
                sSQL1 += "                                  SELECT        SO.iSerial AS ObjectID, CONVERT(varchar(100),SO.sStrategicObjectiveDesc) AS ObjectNameEn, SO.sAbbreviation AS DisplayObjectName, SO.iOrder, 14 AS SystemID, C_2.iProject * 100 AS ParentID,   ";
                sSQL1 += "                                                           'Strategy_Strategic_Objective_Home.aspx?f=m&id=' + CONVERT(varchar, SO.iSerial) AS sURL, SO.iLevel + 1 AS iLevel, 1 AS Privilege  ";
                sSQL1 += "                                  FROM            (SELECT        ES.EmployeeID, SI.iSerial AS SIID, SI.iTheme, SI.iGoal, SI.iProject, SI.iObjective, SI.iOrder, SIDS.isPrincipal  ";
                sSQL1 += "                                                            FROM            CS_Strategic_Initiative AS SI INNER JOIN  ";
                sSQL1 += "                                                                                      CS_Initiative_Dpartment_Section AS SIDS ON SI.iSerial = SIDS.iInitiative INNER JOIN  ";
                sSQL1 += "                                                                                      CS_Employees_Sections AS ES ON SIDS.iDepartment = ES.DepartmentID AND SIDS.iSection = ES.SectionID  ";
                sSQL1 += "                                                       WHERE        (ES.EmployeeID = " + Session["EmployeeID"].ToString() + ")          ) AS C_2 INNER JOIN  ";
                sSQL1 += "                                                           CS_Strategic_Objective AS SO ON C_2.iObjective = SO.iSerial  ";
                sSQL1 += "                                  UNION ALL  ";
                sSQL1 += "                                  SELECT        SInit.iSerial  AS ObjectID, CONVERT(varchar(150),SInit.sInitiativeDesc) AS ObjectNameEn, SInit.sAbbreviation AS DisplayObjectName, SInit.iOrder, 14 AS SystemID, C_1.iObjective * 1000 AS ParentID,   ";
                sSQL1 += "                                                           'Strategy_Strategic_Initiative_Home.aspx?f=m&id=' + CONVERT(varchar, SInit.iSerial) AS sURL, SInit.iLevel + 1 AS iLevel, 1 AS Privilege  ";
                sSQL1 += "                                  FROM            (SELECT        ES.EmployeeID, SI.iSerial AS SIID, SI.iTheme, SI.iGoal, SI.iProject, SI.iObjective, SI.iOrder, SIDS.isPrincipal  ";
                sSQL1 += "                                                            FROM            CS_Strategic_Initiative AS SI INNER JOIN  ";
                sSQL1 += "                                                                                      CS_Initiative_Dpartment_Section AS SIDS ON SI.iSerial = SIDS.iInitiative INNER JOIN  ";
                sSQL1 += "                                                                                      CS_Employees_Sections AS ES ON SIDS.iDepartment = ES.DepartmentID AND SIDS.iSection = ES.SectionID  ";
                sSQL1 += "                                                        WHERE        (ES.EmployeeID = " + Session["EmployeeID"].ToString() + ")        ) AS C_1 INNER JOIN  ";
                sSQL1 += "                                                           CS_Strategic_Initiative AS SInit ON C_1.SIID = SInit.iSerial) AS MNU  ";
                sSQL1 += " 														  where iLevel=4 ";
                sSQL1 += "        GROUP BY ObjectID, ObjectNameEn, DisplayObjectName, ShowOrder, SystemID, ParentID, sURL, iLevel  )";
                //sSQL += "        order by ObjectID ";
                sSQL = sSQL + sSQL1;
            }
            else
            {

            }
            SqlCommand cmd = new SqlCommand(sSQL, sc);
            System.Data.DataTable dt = new System.Data.DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                Repeater1.DataSource = dt;
                Repeater1.DataBind();
            }
            catch (Exception ex)
            {
                sc.Close();
                Console.WriteLine("{0} Exception caught.", ex);
            }
            finally
            {
                sc.Close();
            }
        }
        private void setColor()
        {
            ClrPrjRed = Information.RGB(237, 28, 36);
            ClrCelDarkBlue = Information.RGB(55, 71, 123);
            ClrCelLightGray = Information.RGB(231, 231, 232);
            ClrCelAquaBlue = Information.RGB(0, 102, 179);
            ClrCelLightBlue = Information.RGB(160, 201, 236);
            ClrCelLightGreen = Information.RGB(193, 224, 183);
        }
        public object CreateWFile(string id)
        {
            object oMissing = System.Reflection.Missing.Value;
            object oEndOfDoc = "\\endofdoc";

            // Set Colors
            setColor();

            int CreateWFileRet = 0;
            string sSQL = "";
            //var rs = default(DataTable);
            //string sOKSQL;
            //var rsOK = default(DataTable);
            string sIID;
            string sCurrentSI;
            string sObjective;
            string sCurrentObjective;
            long lngPGS = 0;
            string filename = "";

            //var objWord = default(Microsoft.Office.Interop.Word.Application);
            Application objWord = new Application();
            //var objdoc = default(Microsoft.Office.Interop.Word.Document);
            Document objdoc = objWord.Documents.Add(ref oMissing, ref oMissing, ref oMissing, ref oMissing);//new Document();



            //objWord.Visible = true;

            sSQL += " SELECT        E.sEvidenceRecored, ET.sEvidenceType, E.isIRQASurveyReportRequired, CE.sCustomerExperienceEvidenceCategory, CES.sCustomerExperienceEvidenceSubCategory, TH.sThemeCode, TH.sThemeDesc, ";
            sSQL += "                          P.sStrategicProjectID, P.sStrategicProjectDesc, G.sStrategicGoalID, G.sStrategicGoalDesc, D.DepartmentAbbreviation, S.SectionAbbreviation, D.DescEN AS Dept, S.DescEN AS Section, O.sStrategicObjectiveID, ";
            sSQL += "                          O.sStrategicObjectiveDesc, SI.sInitiativeID, SI.sInitiativeDesc, K.sKPIID AS K_T_ID, K.sKPIDesc AS K_T_Desc, E.iSerial, E.sEvidenceTitle, O.iOrder AS OORD, SI.iOrder AS SORD, K.iOrder AS TKORD, 1 AS isKpi ";
            sSQL += " FROM            CS_Strategic_Goal AS G INNER JOIN ";
            sSQL += "                          CS_Strategic_Objective AS O INNER JOIN ";
            sSQL += "                          Lkp_Department AS D INNER JOIN ";
            sSQL += "                          CS_Strategic_Evidence AS E ON D.DepartmentID = E.iDepartment INNER JOIN ";
            sSQL += "                          Lkp_Section AS S ON E.iSection = S.SectionID AND E.iDepartment = S.DepartmentID INNER JOIN ";
            sSQL += "                          CS_Strategic_KPI AS K ON E.iSerial = K.iEvidence INNER JOIN ";
            sSQL += "                          CS_Strategic_Initiative AS SI ON K.iInitiative = SI.iSerial ON O.iSerial = SI.iObjective INNER JOIN ";
            sSQL += "                          CS_Strategic_Project AS P ON SI.iProject = P.iSerial ON G.iSerial = SI.iGoal INNER JOIN ";
            sSQL += "                          CS_Strategic_Theme AS TH ON SI.iTheme = TH.iSerial INNER JOIN ";
            sSQL += "                          CS_Evidence_Type AS ET ON E.iEvidenceType = ET.iSerial LEFT OUTER JOIN ";
            sSQL += "                          CS_Customer_Experience_Evidence_Sub_Category AS CES ON E.iCustomerExperienceEvidenceSubCategory = CES.iSerial LEFT OUTER JOIN ";
            sSQL += "                          CS_Customer_Experience_Evidence_Category AS CE ON E.iCustomerExperienceEvidenceCategory = CE.iSerial ";
            sSQL += " WHERE        (E.iSerial = "+ id + " AND SI.iDepartment<>0) ";
            sSQL += " union ALL ";
            sSQL += " SELECT        E.sEvidenceRecored, ET.sEvidenceType, E.isIRQASurveyReportRequired, CE.sCustomerExperienceEvidenceCategory, CES.sCustomerExperienceEvidenceSubCategory, TH.sThemeCode, TH.sThemeDesc, ";
            sSQL += "                          P.sStrategicProjectID, P.sStrategicProjectDesc, G.sStrategicGoalID, G.sStrategicGoalDesc, D.DepartmentAbbreviation, S.SectionAbbreviation, D.DescEN AS Dept, S.DescEN AS Section, O.sStrategicObjectiveID, ";
            sSQL += "                          O.sStrategicObjectiveDesc, SI.sInitiativeID, SI.sInitiativeDesc, T.sTaskID AS K_T_ID, T.sTaskDesc AS K_T_Desc, E.iSerial, E.sEvidenceTitle, O.iOrder AS OORD, SI.iOrder AS SORD, T.iOrder AS TKORD, 0 AS isKpi ";
            sSQL += " FROM            CS_Evidence_Type AS ET INNER JOIN ";
            sSQL += "                          Lkp_Department AS D INNER JOIN ";
            sSQL += "                          CS_Strategic_Evidence AS E ON D.DepartmentID = E.iDepartment INNER JOIN ";
            sSQL += "                          Lkp_Section AS S ON E.iSection = S.SectionID AND E.iDepartment = S.DepartmentID ON ET.iSerial = E.iEvidenceType INNER JOIN ";
            sSQL += "                          CS_Strategic_Task AS T ON E.iSerial = T.iEvidence INNER JOIN ";
            sSQL += "                          CS_Strategic_Theme AS TH INNER JOIN ";
            sSQL += "                          CS_Strategic_Project AS P INNER JOIN ";
            sSQL += "                          CS_Strategic_Objective AS O INNER JOIN ";
            sSQL += "                          CS_Strategic_Initiative AS SI ON O.iSerial = SI.iObjective ON P.iSerial = SI.iProject INNER JOIN ";
            sSQL += "                          CS_Strategic_Goal AS G ON SI.iGoal = G.iSerial ON TH.iSerial = SI.iTheme ON T.iInitiative = SI.iSerial LEFT OUTER JOIN ";
            sSQL += "                          CS_Customer_Experience_Evidence_Sub_Category AS CES ON E.iCustomerExperienceEvidenceSubCategory = CES.iSerial LEFT OUTER JOIN ";
            sSQL += "                          CS_Customer_Experience_Evidence_Category AS CE ON E.iCustomerExperienceEvidenceCategory = CE.iSerial ";
            sSQL += " WHERE        (E.iSerial = "+ id + " AND SI.iDepartment<>0) ";
            sSQL += " ORDER BY OORD, SORD,isKpi, TKORD ";

            Connection_StringCLS myConnection_String = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew);
            SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["ECTDataNew"].ConnectionString);
            SqlCommand cmd = new SqlCommand(sSQL, sc);
            System.Data.DataTable dt = new System.Data.DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();


                if (dt.Rows.Count > 0)
                {
                    //while (rs.Rows.Count > 0)
                    //{
                    //OBJECT OF MISSING "NULL VALUE"                      
                    //objdoc = objWord.Documents.Add(ref oMissing, ref oMissing, ref oMissing, ref oMissing);
                    filename = "~/Strategy/" + dt.Rows[0]["sEvidenceRecored"].ToString() + ".docx";
                    objdoc.SaveAs(Server.MapPath(filename));
                    objWord.Selection.Paragraphs.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;
                    objWord.Selection.Font.Name = "Book Antiqua";
                    objWord.Selection.Font.Size = 16;
                    objWord.Selection.Font.Bold = 1;
                    objWord.Selection.TypeText("Project");
                    objWord.Selection.TypeParagraph(); // Enter Pressed
                    objWord.Selection.Font.Size = 18;
                    objWord.Selection.Font.Color = (Microsoft.Office.Interop.Word.WdColor)ClrPrjRed;
                    objWord.Selection.TypeText(dt.Rows[0]["sStrategicProjectDesc"].ToString());
                    objWord.Selection.InlineShapes.AddHorizontalLineStandard();

                    // objWord.Selection.TypeParagraph
                    objWord.Selection.Font.Size = 12;
                    objWord.Selection.Font.Bold = 0;
                    objWord.Selection.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdBlack;
                    objWord.Selection.Font.Name = "Arial";

                    // Setup Table properties
                    Range wrdRng = objdoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
                    Microsoft.Office.Interop.Word.Table objTable;
                    objTable = objdoc.Tables.Add(wrdRng, 6, 2);
                    objTable.Spacing = 1;
                    objTable.AllowAutoFit = true;
                    objTable.AutoFitBehavior(Microsoft.Office.Interop.Word.WdAutoFitBehavior.wdAutoFitWindow);
                    objTable.BottomPadding = 0;
                    objTable.TopPadding = 0;
                    objTable.Rows.SetHeight(0, Microsoft.Office.Interop.Word.WdRowHeightRule.wdRowHeightAuto);
                    objTable.Range.Font.Bold = 0;

                    objTable.Columns[1].SetWidth(150, Microsoft.Office.Interop.Word.WdRulerStyle.wdAdjustNone);
                    objTable.Columns[2].SetWidth(350, Microsoft.Office.Interop.Word.WdRulerStyle.wdAdjustNone);
                    objTable.Columns[1].Cells.VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalTop;
                    objTable.Rows.Alignment = Microsoft.Office.Interop.Word.WdRowAlignment.wdAlignRowLeft;

                    // Load Values into the table
                    objTable.Cell(1, 1).Range.Select();
                    // objWord.Selection.TypeBackspace();
                    objTable.Cell(1, 1).Range.Shading.BackgroundPatternColor = (Microsoft.Office.Interop.Word.WdColor)ClrCelDarkBlue;
                    objTable.Cell(1, 1).Range.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdWhite;
                    objTable.Cell(1, 1).Range.InsertAfter("Evidence Record");
                    objTable.Cell(1, 2).Range.Shading.BackgroundPatternColor = (Microsoft.Office.Interop.Word.WdColor)ClrCelLightGray;
                    objTable.Cell(1, 2).Range.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdBlack;
                    objTable.Cell(1, 2).Range.InsertAfter(dt.Rows[0]["sEvidenceRecored"].ToString());
                    objTable.Cell(2, 1).Range.Shading.BackgroundPatternColor = (Microsoft.Office.Interop.Word.WdColor)ClrCelDarkBlue;
                    objTable.Cell(2, 1).Range.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdWhite;
                    objTable.Cell(2, 1).Range.InsertAfter("Evidence Type");
                    objTable.Cell(2, 2).Range.Shading.BackgroundPatternColor = (Microsoft.Office.Interop.Word.WdColor)ClrCelLightGray;
                    objTable.Cell(2, 2).Range.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdBlack;
                    objTable.Cell(2, 2).Range.InsertAfter(dt.Rows[0]["sEvidenceType"].ToString());
                    objTable.Cell(3, 1).Range.Shading.BackgroundPatternColor = (Microsoft.Office.Interop.Word.WdColor)ClrCelDarkBlue;
                    objTable.Cell(3, 1).Range.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdWhite;
                    objTable.Cell(3, 1).Range.InsertAfter("Responsible Department");
                    objTable.Cell(3, 2).Range.Shading.BackgroundPatternColor = (Microsoft.Office.Interop.Word.WdColor)ClrCelAquaBlue;
                    objTable.Cell(3, 2).Range.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdWhite;
                    objTable.Cell(3, 2).Range.InsertAfter(dt.Rows[0]["Dept"].ToString());
                    objTable.Cell(4, 1).Range.Shading.BackgroundPatternColor = (Microsoft.Office.Interop.Word.WdColor)ClrCelDarkBlue;
                    objTable.Cell(4, 1).Range.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdWhite;
                    objTable.Cell(4, 1).Range.InsertAfter("Responsible Section");
                    objTable.Cell(4, 2).Range.Shading.BackgroundPatternColor = (Microsoft.Office.Interop.Word.WdColor)ClrCelAquaBlue;
                    objTable.Cell(4, 2).Range.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdWhite;
                    objTable.Cell(4, 2).Range.InsertAfter(dt.Rows[0]["Section"].ToString());

                    objTable.Cell(5, 1).Range.Shading.BackgroundPatternColor = (Microsoft.Office.Interop.Word.WdColor)ClrCelDarkBlue;
                    objTable.Cell(5, 1).Range.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdWhite;
                    objTable.Cell(5, 1).Range.InsertAfter("Strategic Theme");
                    objTable.Cell(5, 2).Range.Shading.BackgroundPatternColor = (Microsoft.Office.Interop.Word.WdColor)ClrCelLightGray;
                    objTable.Cell(5, 2).Range.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdBlack;
                    objTable.Cell(5, 2).Range.InsertAfter(dt.Rows[0]["sThemeCode"].ToString() + " " + dt.Rows[0]["sThemeDesc"].ToString());

                    objTable.Cell(6, 1).Range.Shading.BackgroundPatternColor = (Microsoft.Office.Interop.Word.WdColor)ClrCelDarkBlue;
                    objTable.Cell(6, 1).Range.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdWhite;
                    objTable.Cell(6, 1).Range.InsertAfter("Strategic Goal");
                    objTable.Cell(6, 2).Range.Shading.BackgroundPatternColor = (Microsoft.Office.Interop.Word.WdColor)ClrCelLightGray;
                    objTable.Cell(6, 2).Range.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdBlack;
                    objTable.Cell(6, 2).Range.InsertAfter(dt.Rows[0]["sStrategicGoalID"].ToString() + " " + dt.Rows[0]["sStrategicGoalDesc"].ToString());
                    objWord.Selection.MoveDown(Unit: Microsoft.Office.Interop.Word.WdUnits.wdLine, Count: 20);
                    {
                        var withBlock = objWord.Selection.Font;
                        withBlock.Bold = 1;
                        withBlock.Size = 12;
                    }
                    objdoc.Save();

                    // OP & KPT & Initiative Information

                    //sOKSQL = "SELECT SI.sObjective, Ok.sIID, SI.sDesc, Ok.ISKPI, Ok.sTID, Ok.sTName, Ok.EVRec";
                    //sOKSQL = sOKSQL + " FROM CS_EV_OPT_KPI AS OK INNER JOIN CSInitiative AS SI ON OK.sIID = SI.sIID";
                    //sOKSQL = sOKSQL + " WHERE Ok.EVRec = '" + rs["EVRec"] + "'";
                    //sOKSQL = sOKSQL + " ORDER BY SI.sObjective, OK.sIID, OK.ISKPI, OK.sTID";
                    sIID = "";
                    sObjective = "";
                    sCurrentObjective = "";
                    var iKPI = default(int);
                    int iCounter;
                    iCounter = 0;
                    int iRow;


                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        sCurrentObjective = dt.Rows[i]["sStrategicObjectiveID"].ToString() + " " + dt.Rows[i]["sStrategicObjectiveDesc"].ToString();
                        sCurrentSI = dt.Rows[i]["sInitiativeID"].ToString();
                        // Add Objective
                        if ((sCurrentObjective ?? "") != (sObjective ?? ""))//(sCurrentObjective ?? "") != (sObjective ?? "")
                        {
                            if (iCounter > 0)
                            {
                                objdoc.Save();
                                objTable.Rows.Add();
                                iRow = objTable.Rows.Count;
                                objTable.Cell(iRow, 1).Range.Shading.BackgroundPatternColor = (Microsoft.Office.Interop.Word.WdColor)ClrCelDarkBlue;
                                objTable.Cell(iRow, 1).Range.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdWhite;
                                objTable.Cell(iRow, 2).Range.Shading.BackgroundPatternColor = (Microsoft.Office.Interop.Word.WdColor)ClrCelLightGray;
                                objTable.Cell(iRow, 2).Range.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdBlack;
                                objTable.Cell(iRow, 1).Range.InsertAfter("Summary of contribution related to operational tasks");
                                objTable.Cell(iRow, 2).Range.InsertAfter("Type Text Here");
                                objdoc.Save();
                                objTable.Rows.Add();
                                iRow = objTable.Rows.Count;
                                objTable.Cell(iRow, 1).Range.Shading.BackgroundPatternColor = (Microsoft.Office.Interop.Word.WdColor)ClrCelDarkBlue;
                                objTable.Cell(iRow, 1).Range.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdWhite;
                                objTable.Cell(iRow, 2).Range.Shading.BackgroundPatternColor = (Microsoft.Office.Interop.Word.WdColor)ClrCelLightGray;
                                objTable.Cell(iRow, 2).Range.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdBlack;
                                objTable.Cell(iRow, 1).Range.InsertAfter("Attachment of supplementary documents");
                                objTable.Cell(iRow, 2).Range.InsertAfter("Attach Here");
                                objdoc.Save();
                                iCounter = 0;
                                //objWord.Selection.MoveDown(Unit: Microsoft.Office.Interop.Word.WdUnits.wdLine, Count: 20);
                                //objWord.Selection.MoveDown(Unit: Microsoft.Office.Interop.Word.WdUnits.wdLine, Count: 20);
                                //{
                                //    var withBlock = objWord.Selection.Font;
                                //    withBlock.Bold = 1;
                                //    withBlock.Size = 12;
                                //}
                                //objWord.Selection.InsertBreak(); //Type:=wdPageBreak 'Create new page for new objective
                                objdoc.Save();
                            }
                            //objWord.Selection.TypeParagraph();
                            Microsoft.Office.Interop.Word.Range objRange1 = objdoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
                            Microsoft.Office.Interop.Word.Paragraph para1 = objdoc.Content.Paragraphs.Add(objRange1);
                            // 
                            //objWord.Selection.MoveDown(Unit: Microsoft.Office.Interop.Word.WdUnits.wdLine, Count: 20);
                            objWord.Selection.MoveDown(Unit: Microsoft.Office.Interop.Word.WdUnits.wdLine, Count: 20);

                            objWord.Selection.TypeParagraph();
                            objWord.Selection.InlineShapes.AddHorizontalLineStandard();

                            

                            // Setup Table properties
                            Microsoft.Office.Interop.Word.Range objRange = objdoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
                            objTable = objdoc.Tables.Add(objRange, 1, 2);
                            objTable.Rows.Add();
                            iRow = objTable.Rows.Count;
                            objTable.Spacing = 1;
                            objTable.AllowAutoFit = true;
                            objTable.AutoFitBehavior(Microsoft.Office.Interop.Word.WdAutoFitBehavior.wdAutoFitWindow);
                            objTable.BottomPadding = 0;
                            objTable.TopPadding = 0;
                            objTable.Rows.SetHeight(0, Microsoft.Office.Interop.Word.WdRowHeightRule.wdRowHeightAuto);
                            objTable.Range.Font.Bold = 0;
                            //if(iRow<=2)
                            //{
                            objTable.Columns[1].SetWidth(150, Microsoft.Office.Interop.Word.WdRulerStyle.wdAdjustNone);
                            objTable.Columns[2].SetWidth(350, Microsoft.Office.Interop.Word.WdRulerStyle.wdAdjustNone);
                            objTable.Columns[1].Cells.VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalTop;
                            //}                                                        
                            objTable.Rows.Alignment = Microsoft.Office.Interop.Word.WdRowAlignment.wdAlignRowLeft;
                            objTable.Cell(iRow, 1).Range.Shading.BackgroundPatternColor = (Microsoft.Office.Interop.Word.WdColor)ClrCelDarkBlue;
                            objTable.Cell(iRow, 1).Range.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdWhite;
                            objTable.Cell(iRow, 1).Range.InsertAfter("Strategic Objective");
                            objTable.Cell(iRow, 2).Range.Shading.BackgroundPatternColor = (Microsoft.Office.Interop.Word.WdColor)ClrCelLightGray;
                            objTable.Cell(iRow, 2).Range.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdBlack;
                            objTable.Cell(iRow, 2).Range.Font.Bold = 1;
                            objTable.Cell(iRow, 2).Range.InsertAfter(dt.Rows[i]["sStrategicObjectiveID"].ToString() + " " + dt.Rows[i]["sStrategicObjectiveDesc"].ToString());
                            sObjective = sCurrentObjective;
                            objdoc.Save();
                        }


                        // Add Initiative
                        if ((sCurrentSI ?? "") != (sIID ?? ""))
                        {

                            // 
                            iKPI = 0;
                            sIID = sCurrentSI;

                            // Add Row
                            objTable.Rows.Add();
                            iRow = objTable.Rows.Count;
                            objTable.Cell(iRow, 1).Range.InsertAfter("Strategic Initiative");
                            objTable.Cell(iRow, 2).Range.Shading.BackgroundPatternColor = (Microsoft.Office.Interop.Word.WdColor)ClrCelLightBlue;
                            objTable.Cell(iRow, 2).Range.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdBlack;
                            objTable.Cell(iRow, 2).Range.Font.Bold = 1;
                            objTable.Cell(iRow, 2).Range.InsertAfter(sCurrentSI + " " + dt.Rows[i]["sInitiativeDesc"].ToString());
                            objdoc.Save();
                            objTable.Rows.Add();
                            iRow = objTable.Rows.Count;
                            objTable.Cell(iRow, 1).Range.Shading.BackgroundPatternColor = (Microsoft.Office.Interop.Word.WdColor)ClrCelDarkBlue;
                            objTable.Cell(iRow, 1).Range.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdWhite;
                            objTable.Cell(iRow, 2).Range.Shading.BackgroundPatternColor = (Microsoft.Office.Interop.Word.WdColor)ClrCelLightGray;
                            objTable.Cell(iRow, 2).Range.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdBlack;
                            objTable.Cell(iRow, 1).Range.InsertAfter(sCurrentSI);
                            objTable.Cell(iRow, 2).Range.Font.Bold = 1;
                            objTable.Cell(iRow, 2).Range.InsertAfter("Operational Tasks");
                            objdoc.Save();
                        }
                        // Add KPI
                        if (Convert.ToInt32(dt.Rows[i]["isKpi"]) == 1 & iKPI == 0)
                        {
                            iKPI = 1;
                            objTable.Rows.Add();
                            iRow = objTable.Rows.Count;
                            objTable.Cell(iRow, 1).Range.Shading.BackgroundPatternColor = (Microsoft.Office.Interop.Word.WdColor)ClrCelDarkBlue;
                            objTable.Cell(iRow, 1).Range.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdWhite;
                            objTable.Cell(iRow, 2).Range.Shading.BackgroundPatternColor = (Microsoft.Office.Interop.Word.WdColor)ClrCelLightGray;
                            objTable.Cell(iRow, 2).Range.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdBlack;
                            objTable.Cell(iRow, 1).Range.InsertAfter(sCurrentSI);
                            objTable.Cell(iRow, 2).Range.Font.Bold = 1;
                            objTable.Cell(iRow, 2).Range.InsertAfter("Key Performance Indicators Achieved");
                            objdoc.Save();
                        }

                        objTable.Rows.Add();
                        iRow = objTable.Rows.Count;
                        objTable.Cell(iRow, 1).Range.Shading.BackgroundPatternColor = (Microsoft.Office.Interop.Word.WdColor)ClrCelDarkBlue;
                        objTable.Cell(iRow, 1).Range.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdWhite;
                        objTable.Cell(iRow, 2).Range.Font.Bold = 0;
                        if (Convert.ToInt32(dt.Rows[i]["isKpi"]) != 1)
                        {
                            objTable.Cell(iRow, 2).Range.Shading.BackgroundPatternColor = (Microsoft.Office.Interop.Word.WdColor)ClrCelLightGreen;
                            objTable.Cell(iRow, 2).Range.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdBlack;
                            objdoc.Save();
                        }
                        else
                        {
                            objTable.Cell(iRow, 2).Range.Shading.BackgroundPatternColor = (Microsoft.Office.Interop.Word.WdColor)ClrCelLightGray;
                            objTable.Cell(iRow, 2).Range.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdBlack;
                            objdoc.Save();
                        }

                        objTable.Cell(iRow, 1).Range.InsertAfter(dt.Rows[i]["K_T_ID"].ToString());
                        objTable.Cell(iRow, 2).Range.InsertAfter(dt.Rows[i]["K_T_Desc"].ToString());
                        iCounter = iCounter + 1;
                        //rsOK.MoveNext();
                        objdoc.Save();
                    }


                    //rsOK.Close();
                    objTable.Rows.Add();
                    iRow = objTable.Rows.Count;
                    objTable.Cell(iRow, 1).Range.Shading.BackgroundPatternColor = (Microsoft.Office.Interop.Word.WdColor)ClrCelDarkBlue;
                    objTable.Cell(iRow, 1).Range.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdWhite;
                    objTable.Cell(iRow, 2).Range.Shading.BackgroundPatternColor = (Microsoft.Office.Interop.Word.WdColor)ClrCelLightGray;
                    objTable.Cell(iRow, 2).Range.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdBlack;
                    objTable.Cell(iRow, 1).Range.InsertAfter("Summary of contribution related to operational tasks");
                    objTable.Cell(iRow, 2).Range.InsertAfter("Type Text Here");
                    objTable.Rows.Add();
                    iRow = objTable.Rows.Count;
                    objTable.Cell(iRow, 1).Range.Shading.BackgroundPatternColor = (Microsoft.Office.Interop.Word.WdColor)ClrCelDarkBlue;
                    objTable.Cell(iRow, 1).Range.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdWhite;
                    objTable.Cell(iRow, 2).Range.Shading.BackgroundPatternColor = (Microsoft.Office.Interop.Word.WdColor)ClrCelLightGray;
                    objTable.Cell(iRow, 2).Range.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdBlack;
                    objTable.Cell(iRow, 1).Range.InsertAfter("Attachment of supplementary documents");
                    objTable.Cell(iRow, 2).Range.InsertAfter("Attach Here");
                    objdoc.Save();
                    objdoc.Close();
                    lngPGS = lngPGS + 1L;
                    //rs.MoveNext();

                    //rs.Close();
                    //objWord.Visible = false;

                    CreateWFileRet = (int)lngPGS;
                    //CLOSING THE FILE  
                    Object oFalse = false;
                    //objdoc.Close(ref oFalse, ref oMissing, ref oMissing);
                    //wordApp.Documents.Open(Server.MapPath(filename));
                    objWord.Application.Quit();
                    //objWord.Visible = false;

                    if (filename != "")
                    {
                        string path = Server.MapPath(filename);
                        System.IO.FileInfo file = new System.IO.FileInfo(path);
                        if (file.Exists)
                        {
                            Response.Clear();
                            Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
                            Response.AddHeader("Content-Length", file.Length.ToString());
                            Response.ContentType = "application/octet-stream";
                            Response.WriteFile(file.FullName);
                            Response.End();
                        }
                        else
                        {
                            Response.Write("This file does not exist.");
                            div_msg.Visible = true;
                            div_Alert.Attributes.Add("class", "alert alert-danger alert-dismissible");
                            lbl_Msg.Text = "This file does not exist.";
                        }
                    }

                }
                //}
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


            ////rs.Close();
            //objWord.Visible = false;

            //CreateWFileRet = (int)lngPGS;
            ////CLOSING THE FILE  
            //Object oFalse = false;
            ////objdoc.Close(ref oFalse, ref oMissing, ref oMissing);
            ////wordApp.Documents.Open(Server.MapPath(filename));
            //objWord.Application.Quit();
            ////objWord.Visible = false;
            return CreateWFileRet;
        }
        protected void lnk_Download_Click(object sender, EventArgs e)
        {
            if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.Strategic_Evidence,
                              InitializeModule.enumPrivilege.EditUpdate, CurrentRole) != true)
            {
                div_msg.Visible = true;
                div_Alert.Attributes.Add("class", "alert alert-danger alert-dismissible");
                lbl_Msg.Text = "Sorry-You cannot Download";
                return;
            }
            //Get the reference of the clicked button.
            LinkButton button = (sender as LinkButton);

            //Get the command argument
            string commandArgument = button.CommandArgument;

            CreateWFile(commandArgument);
        }
    }
}