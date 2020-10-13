using System;
using System.Data;
using System.Configuration;
////////using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
//////using System.Xml.Linq;
using System.Data.Sql;
using System.Data.SqlClient;
//using Microsoft.Office.Interop.Excel;
//using System.Reflection; 


/// <summary>
/// Summary description for XLS
/// </summary>
public class XLS
{
    Excel.Application oXL;
    Excel._Workbook oWB;
    Excel._Worksheet oSheet;
    Excel.Range oRng;

    string[] ranges = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", 
    "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", 
    "U", "V", "W", "X", "Y", "Z", "AA", "AB", "AC", "AD", 
    "AE", "AF", "AG", "AH", "AI", "AJ", "AK", "AL", "AM", "AN", 
    "AO", "AP", "AQ", "AR", "AS", "AS", "AT", "AU", "AV", "AW", 
    "AX", "AY", "AZ" };

	public XLS()
	{
        oXL = new Excel.Application();
        oXL.Visible = true;
	}

    public string Transfer(SqlDataReader Rd,string sCaption,int iVertical)
    {
        string sReturn="";
        try
        {
            //Get a new workbook.
            oWB = (Excel._Workbook)(oXL.Workbooks.Add(""));
            oSheet = (Excel._Worksheet)oWB.ActiveSheet;

            int iFields = 0;
            iFields = Rd.FieldCount;
            oSheet.Cells[1, 1] = sCaption; 
            string sRng = ranges[iFields - 1] + 1;
            oRng = oSheet.get_Range( "A1", sRng);
            oRng.Merge(oRng.WrapText);
            oRng.Font.Bold = true;
            oRng.Font.Size = 14;
            oRng.VerticalAlignment = 3;
            oRng.HorizontalAlignment = 3;
            oRng.Interior.ColorIndex = 15;



            //Add table headers going cell by cell.
            for (int i = 0; i < iFields; i++)
            {
                oSheet.Cells[2, i + 1] = Rd.GetName(i);

            }

            //Set Header Format
            sRng = ranges[iFields - 1]+1;
            oRng = oSheet.get_Range("A2", sRng);
            oRng.Font.Bold = true;
            oRng.Font.Size=12;
            oRng.VerticalAlignment = 3;
            oRng.HorizontalAlignment = 3;
            oRng.Interior.ColorIndex = 15;

            if (iVertical > 0)
            {
                oRng = oSheet.get_Range(ranges[iVertical]+"2", sRng);
                oRng.Orientation = 90;
            }
                                   

            int iRow = 3;
            while (Rd.Read())
            {
                for (int iCol = 0; iCol < Rd.FieldCount; iCol++)
                {
                    oSheet.Cells[iRow, iCol + 1] = Rd[iCol].ToString();
                }
                iRow += 1;
            }

            sRng = ranges[iFields - 1] + (iRow-1).ToString();
            oRng = oSheet.get_Range("A3", sRng);
            oRng.VerticalAlignment = 2;
            oRng.HorizontalAlignment = 2;
            oRng.NumberFormat = "0.00";
            oRng.EntireColumn.AutoFit();

            sRng = ranges[iFields - 1] + (iRow - 1).ToString();
            oRng = oSheet.get_Range("A1", sRng);
            oRng.Borders.Weight = Excel.XlBorderWeight.xlThin;

            //Make sure Excel is visible and give the user control
            //of Microsoft Excel's lifetime.
            oXL.Visible = true;
            oXL.UserControl = true;
            
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
            sReturn = ex.Message;
        }
        finally
        {
            sReturn = "Transferred Successfully";
        }
        return sReturn;
        
    }
}
