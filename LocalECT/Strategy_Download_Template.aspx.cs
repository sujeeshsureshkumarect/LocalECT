using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace LocalECT
{
    public partial class Strategy_Download_Template : System.Web.UI.Page
    {  
        //public int ClrPrjRed;
        //public int ClrCelDarkBlue;
        //public int ClrCelLightGray;
        //public int ClrCelAquaBlue;
        //public int ClrCelLightBlue;
        //public int ClrCelLightGreen;

        //private void setColor()
        //{
        //    ClrPrjRed = Information.RGB(237, 28, 36);
        //    ClrCelDarkBlue = Information.RGB(55, 71, 123);
        //    ClrCelLightGray = Information.RGB(231, 231, 232);
        //    ClrCelAquaBlue = Information.RGB(0, 102, 179);
        //    ClrCelLightBlue = Information.RGB(160, 201, 236);
        //    ClrCelLightGreen = Information.RGB(193, 224, 183);
        //}
        //// Digital Transformation for Educational Applications and Services Technology Infrastructure
        //public int CreateWFile(string sDept, string sSection, string sEvTitle)
        //{
        //    int CreateWFileRet = default;
        //    string sSQL;
        //    var rs = default(DataTable);
        //    string sOKSQL;
        //    var rsOK = default(DataTable);
        //    string sIID;
        //    string sCurrentSI;
        //    string sObjective;
        //    string sCurrentObjective;
        //    long lngPGS;
            
        //    var objWord = default(Microsoft.Office.Interop.Word.Application);
        //    var objdoc = default(Microsoft.Office.Interop.Word.Document);
        //    var objTable = default(Microsoft.Office.Interop.Word.Table);
        //    Microsoft.Office.Interop.Word.Range objRange;

        //    // Set Colors
        //    setColor();
     
        //    objWord.Visible = true;
        //    sSQL = "SELECT EV.EVRec, EV.sEvType, EV.sEvTitle, EV.Dept, EV.DeptName, EV.Secn, EV.Section, EV.sGoal, EV.sProject, EV.KPIs, EV.OPTs";
        //    sSQL = sSQL + " FROM CS_EV_Final AS EV";
        //    sSQL = sSQL + " WHERE 1=1";
        //    if (!string.IsNullOrEmpty(sDept))
        //    {
        //        sSQL = sSQL + " AND Dept='" + sDept + "'";
        //    }

        //    if (!string.IsNullOrEmpty(sSection))
        //    {
        //        sSQL = sSQL + " AND Secn='" + sSection + "'";
        //    }

        //    if (!string.IsNullOrEmpty(sEvTitle))
        //    {
        //        sSQL = sSQL + " AND sEvTitle='" + sEvTitle + "'";
        //    }
            
        //    while (rs.Rows.Count>0)
        //    {
                
        //        objdoc.SaveAs(@"C:\Users\ihab\Desktop\DPPDesign\csData\Docs\" + rs["EVRec"] + ".docx");
        //        objWord.Selection.Paragraphs.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;
        //        objWord.Selection.Font.Name = "Book Antiqua";
        //        objWord.Selection.Font.Size = 16;
        //        objWord.Selection.Font.Bold = 1;
        //        objWord.Selection.TypeText("Project");
        //        objWord.Selection.TypeParagraph(); // Enter Pressed
        //        objWord.Selection.Font.Size = 18;
        //        objWord.Selection.Font.Color = (Microsoft.Office.Interop.Word.WdColor)ClrPrjRed;
        //        objWord.Selection.TypeText("sProject");
        //        objWord.Selection.InlineShapes.AddHorizontalLineStandard();

        //        // objWord.Selection.TypeParagraph
        //        objWord.Selection.Font.Size = 12;
        //        objWord.Selection.Font.Bold = 0;
        //        objWord.Selection.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdBlack;
        //        objWord.Selection.Font.Name = "Arial";
               
        //        // Setup Table properties
        //        objTable.Spacing = 1;
        //        objTable.AllowAutoFit = true;
        //        objTable.AutoFitBehavior(Microsoft.Office.Interop.Word.WdAutoFitBehavior.wdAutoFitWindow);
        //        objTable.BottomPadding = 0;
        //        objTable.TopPadding = 0;
        //        objTable.Rows.SetHeight(0, Microsoft.Office.Interop.Word.WdRowHeightRule.wdRowHeightAuto);
        //        objTable.Range.Font.Bold = 0;
                
        //        objTable.Columns[1].SetWidth(150, Microsoft.Office.Interop.Word.WdRulerStyle.wdAdjustNone);
        //        objTable.Columns[2].SetWidth(350, Microsoft.Office.Interop.Word.WdRulerStyle.wdAdjustNone);
        //        objTable.Columns[1].Cells.VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalTop;
        //        objTable.Rows.Alignment = Microsoft.Office.Interop.Word.WdRowAlignment.wdAlignRowLeft;

        //        // Load Values into the table
        //        // objTable.Cell(1, 1).Range.Select
        //        // objWord.Selection.TypeBackspace
        //        objTable.Cell(1, 1).Range.Shading.BackgroundPatternColor = (Microsoft.Office.Interop.Word.WdColor)ClrCelDarkBlue;
        //        objTable.Cell(1, 1).Range.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdWhite;
        //        objTable.Cell(1, 1).Range.InsertAfter("Evidence Record");
        //        objTable.Cell(1, 2).Range.Shading.BackgroundPatternColor = (Microsoft.Office.Interop.Word.WdColor)ClrCelLightGray;
        //        objTable.Cell(1, 2).Range.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdBlack;
        //        objTable.Cell(1, 2).Range.InsertAfter("EVRec");
        //        objTable.Cell(2, 1).Range.Shading.BackgroundPatternColor = (Microsoft.Office.Interop.Word.WdColor)ClrCelDarkBlue;
        //        objTable.Cell(2, 1).Range.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdWhite;
        //        objTable.Cell(2, 1).Range.InsertAfter("Evidence Type");
        //        objTable.Cell(2, 2).Range.Shading.BackgroundPatternColor = (Microsoft.Office.Interop.Word.WdColor)ClrCelLightGray;
        //        objTable.Cell(2, 2).Range.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdBlack;
        //        objTable.Cell(2, 2).Range.InsertAfter("sEvType");
        //        objTable.Cell(3, 1).Range.Shading.BackgroundPatternColor = (Microsoft.Office.Interop.Word.WdColor)ClrCelDarkBlue;
        //        objTable.Cell(3, 1).Range.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdWhite;
        //        objTable.Cell(3, 1).Range.InsertAfter("Responsible Department");
        //        objTable.Cell(3, 2).Range.Shading.BackgroundPatternColor = (Microsoft.Office.Interop.Word.WdColor)ClrCelAquaBlue;
        //        objTable.Cell(3, 2).Range.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdWhite;
        //        objTable.Cell(3, 2).Range.InsertAfter("DeptName");
        //        objTable.Cell(4, 1).Range.Shading.BackgroundPatternColor = (Microsoft.Office.Interop.Word.WdColor)ClrCelDarkBlue;
        //        objTable.Cell(4, 1).Range.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdWhite;
        //        objTable.Cell(4, 1).Range.InsertAfter("Responsible Section");
        //        objTable.Cell(4, 2).Range.Shading.BackgroundPatternColor = (Microsoft.Office.Interop.Word.WdColor)ClrCelAquaBlue;
        //        objTable.Cell(4, 2).Range.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdWhite;
        //        objTable.Cell(4, 2).Range.InsertAfter("Section");
        //        objTable.Cell(5, 1).Range.Shading.BackgroundPatternColor = (Microsoft.Office.Interop.Word.WdColor)ClrCelDarkBlue;
        //        objTable.Cell(5, 1).Range.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdWhite;
        //        objTable.Cell(5, 1).Range.InsertAfter("Strategic Goal");
        //        objTable.Cell(5, 2).Range.Shading.BackgroundPatternColor = (Microsoft.Office.Interop.Word.WdColor)ClrCelLightGray;
        //        objTable.Cell(5, 2).Range.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdBlack;
        //        objTable.Cell(5, 2).Range.InsertAfter("sGoal");
        //        objWord.Selection.MoveDown(Unit: Microsoft.Office.Interop.Word.WdUnits.wdLine, Count: 20);
        //        {
        //            var withBlock = objWord.Selection.Font;
        //            withBlock.Bold = 1;
        //            withBlock.Size = 12;
        //        }


        //        // OP & KPT & Initiative Information

        //        sOKSQL = "SELECT SI.sObjective, Ok.sIID, SI.sDesc, Ok.ISKPI, Ok.sTID, Ok.sTName, Ok.EVRec";
        //        sOKSQL = sOKSQL + " FROM CS_EV_OPT_KPI AS OK INNER JOIN CSInitiative AS SI ON OK.sIID = SI.sIID";
        //        sOKSQL = sOKSQL + " WHERE Ok.EVRec = '" + rs["EVRec"] + "'";
        //        sOKSQL = sOKSQL + " ORDER BY SI.sObjective, OK.sIID, OK.ISKPI, OK.sTID";
        //        sIID = "";
        //        sObjective = "";
        //        sCurrentObjective = "";
        //        var iKPI = default(int);
        //        int iCounter;
        //        iCounter = 0;
        //        int iRow;
                
        //        while (!rsOK.EOF)
        //        {
        //            sCurrentObjective = rsOK["sObjective"];
        //            sCurrentSI = rsOK["sIID"];
        //            // Add Objective
        //            if ((sCurrentObjective ?? "") != (sObjective ?? ""))
        //            {
        //                if (iCounter > 0)
        //                {
        //                    objTable.Rows.Add();
        //                    iRow = objTable.Rows.Count;
        //                    objTable.Cell(iRow, 1).Range.Shading.BackgroundPatternColor = (Microsoft.Office.Interop.Word.WdColor)ClrCelDarkBlue;
        //                    objTable.Cell(iRow, 1).Range.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdWhite;
        //                    objTable.Cell(iRow, 2).Range.Shading.BackgroundPatternColor = (Microsoft.Office.Interop.Word.WdColor)ClrCelLightGray;
        //                    objTable.Cell(iRow, 2).Range.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdBlack;
        //                    objTable.Cell(iRow, 1).Range.InsertAfter("Summary of contribution related to operational tasks");
        //                    objTable.Cell(iRow, 2).Range.InsertAfter("Type Text Here");
        //                    objTable.Rows.Add();
        //                    iRow = objTable.Rows.Count;
        //                    objTable.Cell(iRow, 1).Range.Shading.BackgroundPatternColor = (Microsoft.Office.Interop.Word.WdColor)ClrCelDarkBlue;
        //                    objTable.Cell(iRow, 1).Range.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdWhite;
        //                    objTable.Cell(iRow, 2).Range.Shading.BackgroundPatternColor = (Microsoft.Office.Interop.Word.WdColor)ClrCelLightGray;
        //                    objTable.Cell(iRow, 2).Range.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdBlack;
        //                    objTable.Cell(iRow, 1).Range.InsertAfter("Attachment of supplementary documents");
        //                    objTable.Cell(iRow, 2).Range.InsertAfter("Attach Here");
        //                    iCounter = 0;
        //                    objWord.Selection.MoveDown(Unit: Microsoft.Office.Interop.Word.WdUnits.wdLine, Count: 20);
        //                    // objWord.Selection.InsertBreak Type:=wdPageBreak 'Create new page for new objective
        //                }
        //                // 
        //                objWord.Selection.MoveDown(Unit: Microsoft.Office.Interop.Word.WdUnits.wdLine, Count: 20);
        //                // objWord.Selection.TypeParagraph
        //                objWord.Selection.InlineShapes.AddHorizontalLineStandard();
                       
        //                // Setup Table properties
        //                objTable.Spacing = 1;
        //                objTable.AllowAutoFit = true;
        //                objTable.AutoFitBehavior(Microsoft.Office.Interop.Word.WdAutoFitBehavior.wdAutoFitWindow);
        //                objTable.BottomPadding = 0;
        //                objTable.TopPadding = 0;
        //                objTable.Rows.SetHeight(0, Microsoft.Office.Interop.Word.WdRowHeightRule.wdRowHeightAuto);
        //                objTable.Range.Font.Bold = 0;
        //                objTable.Columns[1].SetWidth(150, Microsoft.Office.Interop.Word.WdRulerStyle.wdAdjustNone);
        //                objTable.Columns[2].SetWidth(350, Microsoft.Office.Interop.Word.WdRulerStyle.wdAdjustNone);
        //                objTable.Columns[1].Cells.VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalTop;
        //                objTable.Rows.Alignment = Microsoft.Office.Interop.Word.WdRowAlignment.wdAlignRowLeft;
        //                objTable.Cell(1, 1).Range.Shading.BackgroundPatternColor = (Microsoft.Office.Interop.Word.WdColor)ClrCelDarkBlue;
        //                objTable.Cell(1, 1).Range.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdWhite;
        //                objTable.Cell(1, 1).Range.InsertAfter("Strategic Objective");
        //                objTable.Cell(1, 2).Range.Shading.BackgroundPatternColor = (Microsoft.Office.Interop.Word.WdColor)ClrCelLightGray;
        //                objTable.Cell(1, 2).Range.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdBlack;
        //                objTable.Cell(1, 2).Range.Font.Bold = 1;
        //                objTable.Cell(1, 2).Range.InsertAfter(rsOK["sObjective"]);
        //                sObjective = sCurrentObjective;
        //            }


        //            // Add Initiative
        //            if ((sCurrentSI ?? "") != (sIID ?? ""))
        //            {

        //                // 
        //                iKPI = 0;
        //                sIID = sCurrentSI;

        //                // Add Row
        //                objTable.Rows.Add();
        //                iRow = objTable.Rows.Count;
        //                objTable.Cell(iRow, 1).Range.InsertAfter("Strategic Initiative");
        //                objTable.Cell(iRow, 2).Range.Shading.BackgroundPatternColor = (Microsoft.Office.Interop.Word.WdColor)ClrCelLightBlue;
        //                objTable.Cell(iRow, 2).Range.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdBlack;
        //                objTable.Cell(iRow, 2).Range.Font.Bold = 1;
        //                objTable.Cell(iRow, 2).Range.InsertAfter(sCurrentSI + " " + rsOK["sDesc"]);
        //                objTable.Rows.Add();
        //                iRow = objTable.Rows.Count;
        //                objTable.Cell(iRow, 1).Range.Shading.BackgroundPatternColor = (Microsoft.Office.Interop.Word.WdColor)ClrCelDarkBlue;
        //                objTable.Cell(iRow, 1).Range.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdWhite;
        //                objTable.Cell(iRow, 2).Range.Shading.BackgroundPatternColor = (Microsoft.Office.Interop.Word.WdColor)ClrCelLightGray;
        //                objTable.Cell(iRow, 2).Range.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdBlack;
        //                objTable.Cell(iRow, 1).Range.InsertAfter(sCurrentSI);
        //                objTable.Cell(iRow, 2).Range.Font.Bold = 1;
        //                objTable.Cell(iRow, 2).Range.InsertAfter("Operational Tasks");
        //            }
        //            // Add KPI
        //            if (rsOK["ISKPI"] == 1 & iKPI == 0)
        //            {
        //                iKPI = 1;
        //                objTable.Rows.Add();
        //                iRow = objTable.Rows.Count;
        //                objTable.Cell(iRow, 1).Range.Shading.BackgroundPatternColor = (Microsoft.Office.Interop.Word.WdColor)ClrCelDarkBlue;
        //                objTable.Cell(iRow, 1).Range.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdWhite;
        //                objTable.Cell(iRow, 2).Range.Shading.BackgroundPatternColor = (Microsoft.Office.Interop.Word.WdColor)ClrCelLightGray;
        //                objTable.Cell(iRow, 2).Range.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdBlack;
        //                objTable.Cell(iRow, 1).Range.InsertAfter(sCurrentSI);
        //                objTable.Cell(iRow, 2).Range.Font.Bold = 1;
        //                objTable.Cell(iRow, 2).Range.InsertAfter("Key Performance Indicators Achieved");
        //            }

        //            objTable.Rows.Add();
        //            iRow = objTable.Rows.Count;
        //            objTable.Cell(iRow, 1).Range.Shading.BackgroundPatternColor = (Microsoft.Office.Interop.Word.WdColor)ClrCelDarkBlue;
        //            objTable.Cell(iRow, 1).Range.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdWhite;
        //            objTable.Cell(iRow, 2).Range.Font.Bold = 0;
        //            if (rsOK["ISKPI"] != 1)
        //            {
        //                objTable.Cell(iRow, 2).Range.Shading.BackgroundPatternColor = (Microsoft.Office.Interop.Word.WdColor)ClrCelLightGreen;
        //                objTable.Cell(iRow, 2).Range.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdBlack;
        //            }
        //            else
        //            {
        //                objTable.Cell(iRow, 2).Range.Shading.BackgroundPatternColor = (Microsoft.Office.Interop.Word.WdColor)ClrCelLightGray;
        //                objTable.Cell(iRow, 2).Range.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdBlack;
        //            }

        //            objTable.Cell(iRow, 1).Range.InsertAfter(rsOK["sTID"]);
        //            objTable.Cell(iRow, 2).Range.InsertAfter(rsOK["sTName"]);
        //            iCounter = iCounter + 1;
        //            rsOK.MoveNext();
        //        }

        //        rsOK.Close();
        //        objTable.Rows.Add();
        //        iRow = objTable.Rows.Count;
        //        objTable.Cell(iRow, 1).Range.Shading.BackgroundPatternColor = (Microsoft.Office.Interop.Word.WdColor)ClrCelDarkBlue;
        //        objTable.Cell(iRow, 1).Range.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdWhite;
        //        objTable.Cell(iRow, 2).Range.Shading.BackgroundPatternColor = (Microsoft.Office.Interop.Word.WdColor)ClrCelLightGray;
        //        objTable.Cell(iRow, 2).Range.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdBlack;
        //        objTable.Cell(iRow, 1).Range.InsertAfter("Summary of contribution related to operational tasks");
        //        objTable.Cell(iRow, 2).Range.InsertAfter("Type Text Here");
        //        objTable.Rows.Add();
        //        iRow = objTable.Rows.Count;
        //        objTable.Cell(iRow, 1).Range.Shading.BackgroundPatternColor = (Microsoft.Office.Interop.Word.WdColor)ClrCelDarkBlue;
        //        objTable.Cell(iRow, 1).Range.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdWhite;
        //        objTable.Cell(iRow, 2).Range.Shading.BackgroundPatternColor = (Microsoft.Office.Interop.Word.WdColor)ClrCelLightGray;
        //        objTable.Cell(iRow, 2).Range.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdBlack;
        //        objTable.Cell(iRow, 1).Range.InsertAfter("Attachment of supplementary documents");
        //        objTable.Cell(iRow, 2).Range.InsertAfter("Attach Here");
        //        objdoc.Save();
        //        objdoc.Close();
        //        lngPGS = lngPGS + 1L;               
        //        rs.MoveNext();
        //    }            
        //    rs.Close();
        //    objWord.Visible = false;
           
        //    CreateWFileRet = (int)lngPGS;
        //    objdoc.Close();
        //    objWord.Visible = false;
        //    return CreateWFileRet;                    
        //}
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
    }
    
    }
