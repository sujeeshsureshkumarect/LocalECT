using System;
using System.Data;
using System.Configuration;
//using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
//using System.Xml.Linq;
using System.Collections.Generic;
using ECTGlobalDll;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
public class LibBookHeader
{
    //Creation Date: 24/01/2011 4:22:03 PM
    //Programmer Name : 
    //-----Decleration --------------
    #region "Decleration"
    private int m_BookID;
    private string m_strTitle;
    private string m_strTitleParallel;
    private int m_PublishedYear;
    private int m_PlaceID;
    private int m_SupplierID;
    private string m_strISBN;
    private string m_strEdition;
    private string m_ClassificationID;
    private string m_strShortcut;
    private string m_BookType;
    private int m_PageCount;
    private int m_Volume;
    private int m_LanguageID;
    private DateTime m_dateBook;
    private int m_SeriesID;
    private int m_IndxerID;
    private int m_AuditorID;
    private string m_strUserCreate;
    private DateTime m_dateCreate;
    private string m_strUserSave;
    private DateTime m_dateLastSave;
    private string m_strMachine;
    private string m_strNUser;
    #endregion
    #region "Puplic Properties"
    //'-----------------------------------------------------
    public int BookID
    {
        get { return m_BookID; }
        set { m_BookID = value; }
    }
    public string strTitle
    {
        get { return m_strTitle; }
        set { m_strTitle = value; }
    }
    public string strTitleParallel
    {
        get { return m_strTitleParallel; }
        set { m_strTitleParallel = value; }
    }
    public int PublishedYear
    {
        get { return m_PublishedYear; }
        set { m_PublishedYear = value; }
    }
    public int PlaceID
    {
        get { return m_PlaceID; }
        set { m_PlaceID = value; }
    }
    public int SupplierID
    {
        get { return m_SupplierID; }
        set { m_SupplierID = value; }
    }
    public string strISBN
    {
        get { return m_strISBN; }
        set { m_strISBN = value; }
    }
    public string strEdition
    {
        get { return m_strEdition; }
        set { m_strEdition = value; }
    }
    public string ClassificationID
    {
        get { return m_ClassificationID; }
        set { m_ClassificationID = value; }
    }
    public string strShortcut
    {
        get { return m_strShortcut; }
        set { m_strShortcut = value; }
    }
    public string BookType
    {
        get { return m_BookType; }
        set { m_BookType = value; }
    }
    
    public int PageCount
    {
        get { return m_PageCount; }
        set { m_PageCount = value; }
    }
    public int Volume
    {
        get { return m_Volume; }
        set { m_Volume = value; }
    }
    public int LanguageID
    {
        get { return m_LanguageID; }
        set { m_LanguageID = value; }
    }
    public DateTime dateBook
    {
        get { return m_dateBook; }
        set { m_dateBook = value; }
    }
    public int SeriesID
    {
        get { return m_SeriesID; }
        set { m_SeriesID = value; }
    }
    public int IndxerID
    {
        get { return m_IndxerID; }
        set { m_IndxerID = value; }
    }
    public int AuditorID
    {
        get { return m_AuditorID; }
        set { m_AuditorID = value; }
    }
    public string strUserCreate
    {
        get { return m_strUserCreate; }
        set { m_strUserCreate = value; }
    }
    public DateTime dateCreate
    {
        get { return m_dateCreate; }
        set { m_dateCreate = value; }
    }
    public string strUserSave
    {
        get { return m_strUserSave; }
        set { m_strUserSave = value; }
    }
    public DateTime dateLastSave
    {
        get { return m_dateLastSave; }
        set { m_dateLastSave = value; }
    }
    public string strMachine
    {
        get { return m_strMachine; }
        set { m_strMachine = value; }
    }
    public string strNUser
    {
        get { return m_strNUser; }
        set { m_strNUser = value; }
    }
    //'-----------------------------------------------------
    #endregion
    //'-----------------------------------------------------
    public LibBookHeader()
    {
        try
        {
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
    }
    //end first class
}
public class LibBookHeaderDAL : LibBookHeader
{
    #region "Decleration"
    private string m_TableName;
    private string m_BookIDFN;
    private string m_strTitleFN;
    private string m_strTitleParallelFN;
    private string m_PublishedYearFN;
    private string m_PlaceIDFN;
    private string m_SupplierIDFN;
    private string m_strISBNFN;
    private string m_strEditionFN;
    private string m_ClassificationIDFN;
    private string m_strShortcutFN;
    private string m_BookTypeFN;
    private string m_PageCountFN;
    private string m_VolumeFN;
    private string m_LanguageIDFN;
    private string m_dateBookFN;
    private string m_SeriesIDFN;
    private string m_IndxerIDFN;
    private string m_AuditorIDFN;
    private string m_strUserCreateFN;
    private string m_dateCreateFN;
    private string m_strUserSaveFN;
    private string m_dateLastSaveFN;
    private string m_strMachineFN;
    private string m_strNUserFN;
    #endregion
    //'-----------------------------------------------------
    #region "Puplic Properties"
    public string TableName
    {
        get { return m_TableName; }
        set { m_TableName = value; }
    }
    public string BookIDFN
    {
        get { return m_BookIDFN; }
        set { m_BookIDFN = value; }
    }
    public string strTitleFN
    {
        get { return m_strTitleFN; }
        set { m_strTitleFN = value; }
    }
    public string strTitleParallelFN
    {
        get { return m_strTitleParallelFN; }
        set { m_strTitleParallelFN = value; }
    }
    public string PublishedYearFN
    {
        get { return m_PublishedYearFN; }
        set { m_PublishedYearFN = value; }
    }
    public string PlaceIDFN
    {
        get { return m_PlaceIDFN; }
        set { m_PlaceIDFN = value; }
    }
    public string SupplierIDFN
    {
        get { return m_SupplierIDFN; }
        set { m_SupplierIDFN = value; }
    }
    public string strISBNFN
    {
        get { return m_strISBNFN; }
        set { m_strISBNFN = value; }
    }
    public string strEditionFN
    {
        get { return m_strEditionFN; }
        set { m_strEditionFN = value; }
    }
    public string ClassificationIDFN
    {
        get { return m_ClassificationIDFN; }
        set { m_ClassificationIDFN = value; }
    }
    public string strShortcutFN
    {
        get { return m_strShortcutFN; }
        set { m_strShortcutFN = value; }
    }
    public string BookTypeFN
    {
        get { return m_BookTypeFN; }
        set { m_BookTypeFN = value; }
    }
    
    public string PageCountFN
    {
        get { return m_PageCountFN; }
        set { m_PageCountFN = value; }
    }
    public string VolumeFN
    {
        get { return m_VolumeFN; }
        set { m_VolumeFN = value; }
    }
    public string LanguageIDFN
    {
        get { return m_LanguageIDFN; }
        set { m_LanguageIDFN = value; }
    }
    public string dateBookFN
    {
        get { return m_dateBookFN; }
        set { m_dateBookFN = value; }
    }
    public string SeriesIDFN
    {
        get { return m_SeriesIDFN; }
        set { m_SeriesIDFN = value; }
    }
    public string IndxerIDFN
    {
        get { return m_IndxerIDFN; }
        set { m_IndxerIDFN = value; }
    }
    public string AuditorIDFN
    {
        get { return m_AuditorIDFN; }
        set { m_AuditorIDFN = value; }
    }
    public string strUserCreateFN
    {
        get { return m_strUserCreateFN; }
        set { m_strUserCreateFN = value; }
    }
    public string dateCreateFN
    {
        get { return m_dateCreateFN; }
        set { m_dateCreateFN = value; }
    }
    public string strUserSaveFN
    {
        get { return m_strUserSaveFN; }
        set { m_strUserSaveFN = value; }
    }
    public string dateLastSaveFN
    {
        get { return m_dateLastSaveFN; }
        set { m_dateLastSaveFN = value; }
    }
    public string strMachineFN
    {
        get { return m_strMachineFN; }
        set { m_strMachineFN = value; }
    }
    public string strNUserFN
    {
        get { return m_strNUserFN; }
        set { m_strNUserFN = value; }
    }
    #endregion
    //================End Properties ===================
    public LibBookHeaderDAL()
    {
        try
        {
            this.TableName = "LibBookHeader";
            this.BookIDFN = m_TableName + ".BookID";
            this.strTitleFN = m_TableName + ".strTitle";
            this.strTitleParallelFN = m_TableName + ".strTitleParallel";
            this.PublishedYearFN = m_TableName + ".PublishedYear";
            this.PlaceIDFN = m_TableName + ".PlaceID";
            this.SupplierIDFN = m_TableName + ".SupplierID";
            this.strISBNFN = m_TableName + ".strISBN";
            this.strEditionFN = m_TableName + ".strEdition";
            this.ClassificationIDFN = m_TableName + ".ClassificationID";
            this.strShortcutFN = m_TableName + ".strShortcut";
            this.BookTypeFN = m_TableName + ".BookType";
            
            this.PageCountFN = m_TableName + ".PageCount";
            this.VolumeFN = m_TableName + ".Volume";
            this.LanguageIDFN = m_TableName + ".LanguageID";
            this.dateBookFN = m_TableName + ".dateBook";
            this.SeriesIDFN = m_TableName + ".SeriesID";
            this.IndxerIDFN = m_TableName + ".IndxerID";
            this.AuditorIDFN = m_TableName + ".AuditorID";
            this.strUserCreateFN = m_TableName + ".strUserCreate";
            this.dateCreateFN = m_TableName + ".dateCreate";
            this.strUserSaveFN = m_TableName + ".strUserSave";
            this.dateLastSaveFN = m_TableName + ".dateLastSave";
            this.strMachineFN = m_TableName + ".strMachine";
            this.strNUserFN = m_TableName + ".strNUser";
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
    }
    #region "Data Access Layer"
    //-----Get SQl Function ---------------------------------
    public string GetSQL()
    {
        string sSQL = "";
        try
        {
            sSQL = "SELECT ";
            sSQL += BookIDFN;
            sSQL += " , " + strTitleFN;
            sSQL += " , " + strTitleParallelFN;
            sSQL += " , " + PublishedYearFN;
            sSQL += " , " + PlaceIDFN;
            sSQL += " , " + SupplierIDFN;
            sSQL += " , " + strISBNFN;
            sSQL += " , " + strEditionFN;
            sSQL += " , " + ClassificationIDFN;
            sSQL += " , " + strShortcutFN;
            sSQL += " , " + BookTypeFN;
            sSQL += " , " + PageCountFN;
            sSQL += " , " + VolumeFN;
            sSQL += " , " + LanguageIDFN;
            sSQL += " , " + dateBookFN;
            sSQL += " , " + SeriesIDFN;
            sSQL += " , " + IndxerIDFN;
            sSQL += " , " + AuditorIDFN;
            sSQL += " , " + strUserCreateFN;
            sSQL += " , " + dateCreateFN;
            sSQL += " , " + strUserSaveFN;
            sSQL += " , " + dateLastSaveFN;
            sSQL += " , " + strMachineFN;
            sSQL += " , " + strNUserFN;
            sSQL += "  FROM " + m_TableName;
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return sSQL;
    }
    //-----GetListSQl Function ---------------------------------
    public string GetListSQL(string sCondition)
    {
        string sSQL = "";
        try
        {
            sSQL = "SELECT ";
            sSQL += BookIDFN;
            sSQL += " , " + strTitleFN;
            sSQL += " , " + strTitleParallelFN;
            sSQL += "  FROM " + m_TableName;
            sSQL += "  WHERE " + InitializeModule.POSSIBLE_CONDITION;
            sSQL += sCondition;
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return sSQL;
    }
    //-----Get GetSelectCommand Function -----------------------
    public string GetSelectCommand()
    {
        string sSQL = "";
        try
        {
            sSQL = "SELECT ";
            sSQL += BookIDFN;
            sSQL += " , " + strTitleFN;
            sSQL += " , " + strTitleParallelFN;
            sSQL += " , " + PublishedYearFN;
            sSQL += " , " + PlaceIDFN;
            sSQL += " , " + SupplierIDFN;
            sSQL += " , " + strISBNFN;
            sSQL += " , " + strEditionFN;
            sSQL += " , " + ClassificationIDFN;
            sSQL += " , " + strShortcutFN;
            sSQL += " , " + BookTypeFN;
            sSQL += " , " + PageCountFN;
            sSQL += " , " + VolumeFN;
            sSQL += " , " + LanguageIDFN;
            sSQL += " , " + dateBookFN;
            sSQL += " , " + SeriesIDFN;
            sSQL += " , " + IndxerIDFN;
            sSQL += " , " + AuditorIDFN;
            sSQL += " , " + strUserCreateFN;
            sSQL += " , " + dateCreateFN;
            sSQL += " , " + strUserSaveFN;
            sSQL += " , " + dateLastSaveFN;
            sSQL += " , " + strMachineFN;
            sSQL += " , " + strNUserFN;
            sSQL += "  FROM " + m_TableName;
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return sSQL;
    }
    //-----Get GetUpdateCommand Function -----------------------
    public string GetUpdateCommand()
    {
        string sSQL = "";
        try
        {
            sSQL = "UPDATE " + TableName;
            sSQL += " SET ";
            sSQL += LibraryMOD.GetFieldName(BookIDFN) + "=@BookID";
            sSQL += " , " + LibraryMOD.GetFieldName(strTitleFN) + "=@strTitle";
            sSQL += " , " + LibraryMOD.GetFieldName(strTitleParallelFN) + "=@strTitleParallel";
            sSQL += " , " + LibraryMOD.GetFieldName(PublishedYearFN) + "=@PublishedYear";
            sSQL += " , " + LibraryMOD.GetFieldName(PlaceIDFN) + "=@PlaceID";
            sSQL += " , " + LibraryMOD.GetFieldName(SupplierIDFN) + "=@SupplierID";
            sSQL += " , " + LibraryMOD.GetFieldName(strISBNFN) + "=@strISBN";
            sSQL += " , " + LibraryMOD.GetFieldName(strEditionFN) + "=@strEdition";
            sSQL += " , " + LibraryMOD.GetFieldName(ClassificationIDFN) + "=@ClassificationID";
            sSQL += " , " + LibraryMOD.GetFieldName(strShortcutFN) + "=@strShortcut";
            sSQL += " , " + LibraryMOD.GetFieldName(BookTypeFN) + "=@BookType";
            
            sSQL += " , " + LibraryMOD.GetFieldName(PageCountFN) + "=@PageCount";
            sSQL += " , " + LibraryMOD.GetFieldName(VolumeFN) + "=@Volume";
            sSQL += " , " + LibraryMOD.GetFieldName(LanguageIDFN) + "=@LanguageID";
            sSQL += " , " + LibraryMOD.GetFieldName(dateBookFN) + "=@dateBook";
            sSQL += " , " + LibraryMOD.GetFieldName(SeriesIDFN) + "=@SeriesID";
            sSQL += " , " + LibraryMOD.GetFieldName(IndxerIDFN) + "=@IndxerID";
            sSQL += " , " + LibraryMOD.GetFieldName(AuditorIDFN) + "=@AuditorID";
            sSQL += " , " + LibraryMOD.GetFieldName(strUserCreateFN) + "=@strUserCreate";
            sSQL += " , " + LibraryMOD.GetFieldName(dateCreateFN) + "=@dateCreate";
            sSQL += " , " + LibraryMOD.GetFieldName(strUserSaveFN) + "=@strUserSave";
            sSQL += " , " + LibraryMOD.GetFieldName(dateLastSaveFN) + "=@dateLastSave";
            sSQL += " , " + LibraryMOD.GetFieldName(strMachineFN) + "=@strMachine";
            sSQL += " , " + LibraryMOD.GetFieldName(strNUserFN) + "=@strNUser";
            sSQL += " WHERE ";
            sSQL += LibraryMOD.GetFieldName(BookIDFN) + "=@BookID";
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return sSQL;
    }
    //-----Get GetInsertCommand Function -----------------------
    public string GetInsertCommand()
    {
        string sSQL = "";
        try
        {
            sSQL = "INSERT intO " + TableName;
            sSQL += "( ";
            sSQL += LibraryMOD.GetFieldName(BookIDFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strTitleFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strTitleParallelFN);
            sSQL += " , " + LibraryMOD.GetFieldName(PublishedYearFN);
            sSQL += " , " + LibraryMOD.GetFieldName(PlaceIDFN);
            sSQL += " , " + LibraryMOD.GetFieldName(SupplierIDFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strISBNFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strEditionFN);
            sSQL += " , " + LibraryMOD.GetFieldName(ClassificationIDFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strShortcutFN);
            sSQL += " , " + LibraryMOD.GetFieldName(BookTypeFN);
            sSQL += " , " + LibraryMOD.GetFieldName(PageCountFN);
            sSQL += " , " + LibraryMOD.GetFieldName(VolumeFN);
            sSQL += " , " + LibraryMOD.GetFieldName(LanguageIDFN);
            sSQL += " , " + LibraryMOD.GetFieldName(dateBookFN);
            sSQL += " , " + LibraryMOD.GetFieldName(SeriesIDFN);
            sSQL += " , " + LibraryMOD.GetFieldName(IndxerIDFN);
            sSQL += " , " + LibraryMOD.GetFieldName(AuditorIDFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strUserCreateFN);
            sSQL += " , " + LibraryMOD.GetFieldName(dateCreateFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strUserSaveFN);
            sSQL += " , " + LibraryMOD.GetFieldName(dateLastSaveFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strMachineFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strNUserFN);
            sSQL += ")";
            sSQL += " VALUES ";
            sSQL += "( ";
            sSQL += " @BookID";
            sSQL += " ,@strTitle";
            sSQL += " ,@strTitleParallel";
            sSQL += " ,@PublishedYear";
            sSQL += " ,@PlaceID";
            sSQL += " ,@SupplierID";
            sSQL += " ,@strISBN";
            sSQL += " ,@strEdition";
            sSQL += " ,@ClassificationID";
            sSQL += " ,@strShortcut";
            sSQL += " ,@BookType";
            sSQL += " ,@PageCount";
            sSQL += " ,@Volume";
            sSQL += " ,@LanguageID";
            sSQL += " ,@dateBook";
            sSQL += " ,@SeriesID";
            sSQL += " ,@IndxerID";
            sSQL += " ,@AuditorID";
            sSQL += " ,@strUserCreate";
            sSQL += " ,@dateCreate";
            sSQL += " ,@strUserSave";
            sSQL += " ,@dateLastSave";
            sSQL += " ,@strMachine";
            sSQL += " ,@strNUser";
            sSQL += ") ";
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return sSQL;
    }
    //-----Get GetDeleteCommand Function -----------------------
    public string GetDeleteCommand()
    {
        string sSQL = "";
        try
        {
            sSQL = "DELETE FROM " + TableName;
            sSQL += " WHERE ";
            sSQL += LibraryMOD.GetFieldName(BookIDFN) + "=@BookID";
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return sSQL;
    }
    #endregion
    public List<LibBookHeader> GetLibBookHeader(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
    {
        //' returns a list of Classes instances based on the
        //' data in the LibBookHeader
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        string sSQL = GetSQL();
        if (!string.IsNullOrEmpty(sCondition))
        {
            sSQL += sCondition;
        }
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        SqlCommand Cmd = new SqlCommand(sSQL, Conn);
        Conn.Open();
        SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
        List<LibBookHeader> results = new List<LibBookHeader>();
        try
        {
            //Default Value
            LibBookHeader myLibBookHeader = new LibBookHeader();
            if (isDeafaultIncluded)
            {
                //Change the code here
                myLibBookHeader.BookID = 0;
                results.Add(myLibBookHeader);
            }
            while (reader.Read())
            {
                myLibBookHeader = new LibBookHeader();
                if (reader[LibraryMOD.GetFieldName(BookIDFN)].Equals(DBNull.Value))
                {
                    myLibBookHeader.BookID = 0;
                }
                else
                {
                    myLibBookHeader.BookID = int.Parse(reader[LibraryMOD.GetFieldName(BookIDFN)].ToString());
                }
                myLibBookHeader.strTitle = reader[LibraryMOD.GetFieldName(strTitleFN)].ToString();
                myLibBookHeader.strTitleParallel = reader[LibraryMOD.GetFieldName(strTitleParallelFN)].ToString();
                if (reader[LibraryMOD.GetFieldName(PublishedYearFN)].Equals(DBNull.Value))
                {
                    myLibBookHeader.PublishedYear = 0;
                }
                else
                {
                    myLibBookHeader.PublishedYear = int.Parse(reader[LibraryMOD.GetFieldName(PublishedYearFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(PlaceIDFN)].Equals(DBNull.Value))
                {
                    myLibBookHeader.PlaceID = 0;
                }
                else
                {
                    myLibBookHeader.PlaceID = int.Parse(reader[LibraryMOD.GetFieldName(PlaceIDFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(SupplierIDFN)].Equals(DBNull.Value))
                {
                    myLibBookHeader.SupplierID = 0;
                }
                else
                {
                    myLibBookHeader.SupplierID = int.Parse(reader[LibraryMOD.GetFieldName(SupplierIDFN)].ToString());
                }
                myLibBookHeader.strISBN = reader[LibraryMOD.GetFieldName(strISBNFN)].ToString();
                myLibBookHeader.strEdition = reader[LibraryMOD.GetFieldName(strEditionFN)].ToString();
                myLibBookHeader.ClassificationID = reader[LibraryMOD.GetFieldName(ClassificationIDFN)].ToString();
                myLibBookHeader.strShortcut = reader[LibraryMOD.GetFieldName(strShortcutFN)].ToString();
               
               
                if (reader[LibraryMOD.GetFieldName(BookTypeFN)].Equals(DBNull.Value))
                {
                    myLibBookHeader.BookType = "-1";
                }
                else
                {
                    myLibBookHeader.BookType = reader[LibraryMOD.GetFieldName(BookTypeFN)].ToString();
                }

                if (reader[LibraryMOD.GetFieldName(PageCountFN)].Equals(DBNull.Value))
                {
                    myLibBookHeader.PageCount = 0;
                }
                else
                {
                    myLibBookHeader.PageCount = int.Parse(reader[LibraryMOD.GetFieldName(PageCountFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(VolumeFN)].Equals(DBNull.Value))
                {
                    myLibBookHeader.Volume = 0;
                }
                else
                {
                    myLibBookHeader.Volume = int.Parse(reader[LibraryMOD.GetFieldName(VolumeFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(LanguageIDFN)].Equals(DBNull.Value))
                {
                    myLibBookHeader.LanguageID = 0;
                }
                else
                {
                    myLibBookHeader.LanguageID = int.Parse(reader[LibraryMOD.GetFieldName(LanguageIDFN)].ToString());
                }
                if (!reader[LibraryMOD.GetFieldName(dateBookFN)].Equals(DBNull.Value))
                {
                    myLibBookHeader.dateBook = DateTime.Parse(reader[LibraryMOD.GetFieldName(dateBookFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(SeriesIDFN)].Equals(DBNull.Value))
                {
                    myLibBookHeader.SeriesID = 0;
                }
                else
                {
                    myLibBookHeader.SeriesID = int.Parse(reader[LibraryMOD.GetFieldName(SeriesIDFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(IndxerIDFN)].Equals(DBNull.Value))
                {
                    myLibBookHeader.IndxerID = 0;
                }
                else
                {
                    myLibBookHeader.IndxerID = int.Parse(reader[LibraryMOD.GetFieldName(IndxerIDFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(AuditorIDFN)].Equals(DBNull.Value))
                {
                    myLibBookHeader.AuditorID = 0;
                }
                else
                {
                    myLibBookHeader.AuditorID = int.Parse(reader[LibraryMOD.GetFieldName(AuditorIDFN)].ToString());
                }
                myLibBookHeader.strUserCreate = reader[LibraryMOD.GetFieldName(strUserCreateFN)].ToString();
                if (!reader[LibraryMOD.GetFieldName(dateCreateFN)].Equals(DBNull.Value))
                {
                    myLibBookHeader.dateCreate = DateTime.Parse(reader[LibraryMOD.GetFieldName(dateCreateFN)].ToString());
                }
                myLibBookHeader.strUserSave = reader[LibraryMOD.GetFieldName(strUserSaveFN)].ToString();
                if (!reader[LibraryMOD.GetFieldName(dateLastSaveFN)].Equals(DBNull.Value))
                {
                    myLibBookHeader.dateLastSave = DateTime.Parse(reader[LibraryMOD.GetFieldName(dateLastSaveFN)].ToString());
                }
                myLibBookHeader.strMachine = reader[LibraryMOD.GetFieldName(strMachineFN)].ToString();
                myLibBookHeader.strNUser = reader[LibraryMOD.GetFieldName(strNUserFN)].ToString();
                results.Add(myLibBookHeader);
            }
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
            reader.Close();
            reader.Dispose();
            Conn.Close();
            Conn.Dispose();
        }
        return results;
    }
    public List<LibBookHeader> GetList(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
    {
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        string sSQL = GetListSQL(sCondition);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        SqlCommand Cmd = new SqlCommand(sSQL, Conn);
        Conn.Open();
        SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
        List<LibBookHeader> results = new List<LibBookHeader>();
        try
        {
            //Default Value
            LibBookHeader myLibBookHeader = new LibBookHeader();
            if (isDeafaultIncluded)
            {
                //Change the code here
                myLibBookHeader.BookID = -1;
                myLibBookHeader.strTitle = "Select LibBookHeader";
                results.Add(myLibBookHeader);
            }
            while (reader.Read())
            {
                myLibBookHeader = new LibBookHeader();
                if (reader[LibraryMOD.GetFieldName(BookIDFN)].Equals(DBNull.Value))
                {
                    myLibBookHeader.BookID = 0;
                }
                else
                {
                    myLibBookHeader.BookID = int.Parse(reader[LibraryMOD.GetFieldName(BookIDFN)].ToString());
                }
                myLibBookHeader.strTitle = reader[LibraryMOD.GetFieldName(strTitleFN)].ToString();
                myLibBookHeader.strTitleParallel = reader[LibraryMOD.GetFieldName(strTitleParallelFN)].ToString();
                results.Add(myLibBookHeader);
            }
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
            reader.Close();
            reader.Dispose();
            Conn.Close();
            Conn.Dispose();
        }
        return results;
    }
    public int UpdateLibBookHeader(InitializeModule.EnumCampus Campus, int iMode, int BookID, string strTitle, string strTitleParallel, int PublishedYear, int PlaceID, int SupplierID, string strISBN, string strEdition, string ClassificationID, string strShortcut,string BookType, int PageCount, int Volume, int LanguageID, DateTime dateBook, int SeriesID, int IndxerID, int AuditorID, string strUserCreate, DateTime dateCreate, string strUserSave, DateTime dateLastSave, string strMachine, string strNUser)
    {
        int iEffected = 0;
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        try
        {
            Conn.Open();
            string sql = "";
            LibBookHeader theLibBookHeader = new LibBookHeader();
            //'Updates the  table
            switch (iMode)
            {
                case (int)ECTGlobalDll.InitializeModule.enumModes.EditMode:
                    sql = GetUpdateCommand();
                    break;
                case (int)ECTGlobalDll.InitializeModule.enumModes.NewMode:
                    sql = GetInsertCommand();
                    break;
            }
            SqlCommand Cmd = new SqlCommand(sql, Conn);
            Cmd.Parameters.Add(new SqlParameter("@BookID", BookID));
            Cmd.Parameters.Add(new SqlParameter("@strTitle", strTitle));
            Cmd.Parameters.Add(new SqlParameter("@strTitleParallel", strTitleParallel));
            Cmd.Parameters.Add(new SqlParameter("@PublishedYear", PublishedYear));
            if (PlaceID != -1)
                Cmd.Parameters.Add(new SqlParameter("@PlaceID", PlaceID));
            else
                Cmd.Parameters.AddWithValue("@PlaceID", DBNull.Value);

            if (SupplierID != -1)
                Cmd.Parameters.Add(new SqlParameter("@SupplierID", SupplierID));
            else
                Cmd.Parameters.AddWithValue("@SupplierID", DBNull.Value);

            Cmd.Parameters.Add(new SqlParameter("@strISBN", strISBN));
            Cmd.Parameters.Add(new SqlParameter("@strEdition", strEdition));
            Cmd.Parameters.Add(new SqlParameter("@ClassificationID", ClassificationID));
            Cmd.Parameters.Add(new SqlParameter("@strShortcut", strShortcut));
            Cmd.Parameters.Add(new SqlParameter("@BookType", BookType));
            
            Cmd.Parameters.Add(new SqlParameter("@PageCount", PageCount));
            Cmd.Parameters.Add(new SqlParameter("@Volume", Volume));

            if (LanguageID != -1)
                Cmd.Parameters.Add(new SqlParameter("@LanguageID", LanguageID));
            else
                Cmd.Parameters.AddWithValue("@LanguageID", DBNull.Value);

            Cmd.Parameters.Add(new SqlParameter("@dateBook", dateBook));

            if (SeriesID != -1)
                Cmd.Parameters.Add(new SqlParameter("@SeriesID", SeriesID));
            else
                Cmd.Parameters.AddWithValue("@SeriesID", DBNull.Value);

            if (IndxerID != -1)
                Cmd.Parameters.Add(new SqlParameter("@IndxerID", IndxerID));
            else
                Cmd.Parameters.AddWithValue("@IndxerID", DBNull.Value);

            if (AuditorID != -1)
                Cmd.Parameters.Add(new SqlParameter("@AuditorID", AuditorID));
            else
                Cmd.Parameters.AddWithValue("@AuditorID", DBNull.Value);

            Cmd.Parameters.Add(new SqlParameter("@strUserCreate", strUserCreate));
            Cmd.Parameters.Add(new SqlParameter("@dateCreate", dateCreate));
            Cmd.Parameters.Add(new SqlParameter("@strUserSave", strUserSave));
            Cmd.Parameters.Add(new SqlParameter("@dateLastSave", dateLastSave));
            Cmd.Parameters.Add(new SqlParameter("@strMachine", strMachine));
            Cmd.Parameters.Add(new SqlParameter("@strNUser", strNUser));
            iEffected = Cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
            Conn.Close();
            Conn.Dispose();
        }
        return iEffected;
    }
    public int DeleteLibBookHeader(InitializeModule.EnumCampus Campus, string BookID)
    {
        int iEffected = 0;
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        try
        {
            string sSQL = GetDeleteCommand();
            //sSQL += sCondition;
            SqlCommand Cmd = new SqlCommand(sSQL, Conn);
            Cmd.Parameters.Add(new SqlParameter("@BookID", BookID));
            Conn.Open();
            iEffected = Cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
            Conn.Close();
            Conn.Dispose();
        }
        return iEffected;
    }
    public DataView GetDataView(bool isFromRole, int PK, string sCondition)
    {
        DataTable dt = new DataTable("LibBookHeader");
        DataView dv = new DataView();
        List<LibBookHeader> myLibBookHeaders = new List<LibBookHeader>();
        try
        {
            myLibBookHeaders = GetLibBookHeader(InitializeModule.EnumCampus.ECTNew, sCondition, false);
            DataColumn col0 = new DataColumn("BookID", Type.GetType("int"));
            dt.Columns.Add(col0);
            dt.Constraints.Add(new UniqueConstraint(col0));

            DataRow dr;
            for (int i = 0; i < myLibBookHeaders.Count; i++)
            {
                dr = dt.NewRow();
                dr[1] = myLibBookHeaders[i].BookID;
                dt.Rows.Add(dr);
            }
            dt.AcceptChanges();
            dv.Table = dt;
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
            myLibBookHeaders.Clear();
        }
        return dv;
    }
    //'-------Populate  -----------------------------
    public DataTable Populate(SqlConnection con)
    {
        string sSQL = "";
        DataTable table = new DataTable();
        try
        {
            sSQL = "SELECT";
            sSQL += BookIDFN;
            //sSQL += " , " + ";
            sSQL += "  FROM " + m_TableName;
            SqlDataAdapter adapter = new SqlDataAdapter(sSQL, con);
            //'table.Locale = System.Globalization.CultureInfo.InvariantCulture
            adapter.Fill(table);
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return table;
    }
    //end class tow
}
public class LibBookHeaderCls : LibBookHeaderDAL
{
    #region "Decleration"
    private int m_lngCurRow = 0;
    public SqlDataAdapter daLibBookHeader;
    private DataSet m_dsLibBookHeader;
    public DataRow LibBookHeaderDataRow;
    #endregion
    #region "Puplic Properties"
    public DataSet dsLibBookHeader
    {
        get { return m_dsLibBookHeader; }
        set { m_dsLibBookHeader = value; }
    }
    //-----------------------------------------------------
    public int lngCurRow
    {
        get { return m_lngCurRow; }
        set { m_lngCurRow = value; }
    }
    #endregion
    public LibBookHeaderCls()
    {
        try
        {
            dsLibBookHeader = new DataSet();

        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
    }
    private string GetPersonName(int PersonType, string PersonID)
    {
        string sName = "";
        SqlDataReader rd;
        try
        {
            //DdlPerson.Items.Clear();
            if (PersonType != -1)
            {
                string StrSql = string.Empty;
                switch (PersonType)
                {
                    case 1:
                        // Faculty
                        StrSql = "SELECT EmployeeName";
                        StrSql += " FROM AllFaculty";
                        StrSql += " WHERE EmpFileNo =" + Convert.ToInt32("0" + PersonID);

                        break;
                    case 2:
                        // Students
                        StrSql = "SELECT sName";
                        StrSql += " FROM View_MoodleAllStudent";
                        StrSql += " WHERE sStudentNumber ='" + PersonID + "'";
                        break;

                    case 3:
                        //Staff
                        StrSql = "SELECT EmployeeName";
                        StrSql += " FROM AllStaff";
                        StrSql += " WHERE EmpFileNo =" + Convert.ToInt32("0" + PersonID);
                        break;
                    default:
                        break;
                }
                SqlCommand cmd = new SqlCommand();
                Connection_StringCLS myConnection_String = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew);
                SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);

                Conn.Open();
                rd = cmd.ExecuteReader();


                if (rd.Read())
                {
                    sName = rd.GetString(0);
                }
                rd.Dispose();
                rd.Close();
            }

        }

        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
         
        }
        return sName;
    }
    public string GetBookStatus(int AccNo)
    {
        string sStatus = "";
        string sSQL = "";
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());

        try
        {

            sSQL = "SELECT MAX(LibTransactions.TransactionID) AS LastTrans";
            sSQL += ", LibTransTypes.strTransTypeEn";
            sSQL += ", LibTransactions.dateTransaction";
            sSQL += ", LibTransactions.PersonID";
            sSQL += ", LibTransactions.PersonRoleID";
            sSQL += ", LibTransactions.dateMustReturn";
            sSQL += " FROM LibTransactions INNER JOIN";
            sSQL += " LibTransTypes ON LibTransactions.TransTypeID = LibTransTypes.TransTypeID";
            sSQL += " GROUP BY LibTransactions.AccesstionNo";
            sSQL += " , LibTransTypes.strTransTypeEn";
            sSQL += " , LibTransactions.dateTransaction";
            sSQL += " , LibTransactions.PersonID";
            sSQL += " , LibTransactions.PersonRoleID";
            sSQL += ", LibTransactions.dateMustReturn";
            sSQL += " HAVING LibTransactions.AccesstionNo =" + AccNo;
            sSQL += " ORDER BY LastTrans DESC";


            Conn.Open();

            System.Data.SqlClient.SqlCommand CommandSQL = new System.Data.SqlClient.SqlCommand(sSQL, Conn);
            System.Data.SqlClient.SqlDataReader datReader;
            datReader = CommandSQL.ExecuteReader(CommandBehavior.CloseConnection);

            string sName = "";
            if (datReader.Read())
            {
                sStatus = datReader.GetString(1);
                sStatus += "      ";
                sStatus += " in Date: " + datReader.GetDateTime(2);
                sStatus += " By Person: " + datReader.GetString(3) + " / ";
                datReader.Close();

                sName = GetPersonName(datReader.GetInt32(4), datReader.GetString(3));
                switch (datReader.GetInt32(4))
                {
                    case 2:
                        sStatus += " [ Student ]";
                        break;
                    case 3:
                        sStatus += " [ Employee ]";
                        break;
                    case 1:
                        sStatus += " [ Instructor ]";
                        break;
                }


            }
            else
            {
                sStatus = "";
                datReader.Close();
            }



        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
            Conn.Close();
            Conn.Dispose();
        }
        return sStatus;
    }
    public string GetBookDesc(int AccNo)
    {
        string sTitle = "";
        string sSQL ="";
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());

        try
        {
            

            sSQL="SELECT " + strTitleFN;
            sSQL+=" FROM LibBookDetail INNER JOIN";
            sSQL+=" LibBookHeader ON LibBookDetail.BookID = LibBookHeader.BookID";
            sSQL+=" WHERE LibBookDetail.AccesstionNo =" +  AccNo ;

            Conn.Open();

            System.Data.SqlClient.SqlCommand CommandSQL = new System.Data.SqlClient.SqlCommand(sSQL, Conn);
            System.Data.SqlClient.SqlDataReader datReader;
            datReader = CommandSQL.ExecuteReader(CommandBehavior.CloseConnection);


            if (datReader.Read())
            {
                sTitle = datReader.GetString(0);
            }
            datReader.Close();

        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
            Conn.Close();
            Conn.Dispose();
        }
        return sTitle;
    }
   
    //-------Get DataAdapter  -----------------------------
    #region "DataAdapter"
    public virtual SqlDataAdapter GetLibBookHeaderDataAdapter(string sCondition, SqlConnection con)
    {
        string sSQL = "";
        try
        {
            sSQL = GetSQL();
            sSQL += " " + sCondition;
            //-----------------------------------------
            daLibBookHeader = new SqlDataAdapter(sSQL, con);
            // Create command builder. This line automatically generates the update commands for you, so you don't
            // have to provide or create your own.
            SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daLibBookHeader);
            //Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
            // key + unique key information to be retrieved unless AddWithKey is specified.
            daLibBookHeader.MissingSchemaAction = MissingSchemaAction.AddWithKey;
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return daLibBookHeader;
    }
    public virtual SqlDataAdapter GetLibBookHeaderDataAdapter(SqlConnection con)
    {
        try
        {
            daLibBookHeader = new SqlDataAdapter();
            //''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
            //'' key + unique key information to be retrieved unless AddWithKey is specified.
            daLibBookHeader.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            //-----------------------------------------
            SqlParameter Parmeter = default(SqlParameter);
            //[SELECT COMMAND]
            SqlCommand cmdLibBookHeader;
            cmdLibBookHeader = new SqlCommand(GetSelectCommand(), con);
            //'cmdRolePermission.Parameters.Add("@BookID", SqlDbType.Int, 4, "BookID" );
            daLibBookHeader.SelectCommand = cmdLibBookHeader;
            //'Add Handlers
            //'RowUpdating,RowUpdated
            AddDAEventHandler();
            //'[UPDATE COMMAND].
            cmdLibBookHeader = new SqlCommand(GetUpdateCommand(), con);
            //'Delete PK Parameteres from here. b/c its declared below
            cmdLibBookHeader.Parameters.Add("@BookID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(BookIDFN));
            cmdLibBookHeader.Parameters.Add("@strTitle", SqlDbType.NVarChar, 510, LibraryMOD.GetFieldName(strTitleFN));
            cmdLibBookHeader.Parameters.Add("@strTitleParallel", SqlDbType.NVarChar, 510, LibraryMOD.GetFieldName(strTitleParallelFN));
            cmdLibBookHeader.Parameters.Add("@PublishedYear", SqlDbType.Int, 4, LibraryMOD.GetFieldName(PublishedYearFN));
            cmdLibBookHeader.Parameters.Add("@PlaceID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(PlaceIDFN));
            cmdLibBookHeader.Parameters.Add("@SupplierID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(SupplierIDFN));
            cmdLibBookHeader.Parameters.Add("@strISBN", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strISBNFN));
            cmdLibBookHeader.Parameters.Add("@strEdition", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strEditionFN));
            cmdLibBookHeader.Parameters.Add("@ClassificationID", SqlDbType.NVarChar, 200, LibraryMOD.GetFieldName(ClassificationIDFN));
            cmdLibBookHeader.Parameters.Add("@strShortcut", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strShortcutFN));
            cmdLibBookHeader.Parameters.Add("@PageCount", SqlDbType.Int, 4, LibraryMOD.GetFieldName(PageCountFN));
            cmdLibBookHeader.Parameters.Add("@Volume", SqlDbType.Int, 2, LibraryMOD.GetFieldName(VolumeFN));
            cmdLibBookHeader.Parameters.Add("@LanguageID", SqlDbType.Int, 2, LibraryMOD.GetFieldName(LanguageIDFN));
            cmdLibBookHeader.Parameters.Add("@dateBook", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dateBookFN));
            cmdLibBookHeader.Parameters.Add("@SeriesID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(SeriesIDFN));
            cmdLibBookHeader.Parameters.Add("@IndxerID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(IndxerIDFN));
            cmdLibBookHeader.Parameters.Add("@AuditorID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(AuditorIDFN));
            cmdLibBookHeader.Parameters.Add("@strUserCreate", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strUserCreateFN));
            cmdLibBookHeader.Parameters.Add("@dateCreate", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dateCreateFN));
            cmdLibBookHeader.Parameters.Add("@strUserSave", SqlDbType.Char, 10, LibraryMOD.GetFieldName(strUserSaveFN));
            cmdLibBookHeader.Parameters.Add("@dateLastSave", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dateLastSaveFN));
            cmdLibBookHeader.Parameters.Add("@strMachine", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strMachineFN));
            cmdLibBookHeader.Parameters.Add("@strNUser", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strNUserFN));


            Parmeter = cmdLibBookHeader.Parameters.Add("@BookID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(BookIDFN));
            Parmeter.SourceVersion = DataRowVersion.Original;
            //'Its should be none for batch updating
            //'UpdateCommand, InsertCommand, and DeleteCommand 
            //'should be set to None or OutputParameters
            daLibBookHeader.UpdateCommand = cmdLibBookHeader;
            daLibBookHeader.UpdateCommand.UpdatedRowSource = UpdateRowSource.None;
            //'-------------------------------------------------------------------------
            //'/INSERT COMMAND
            cmdLibBookHeader = new SqlCommand(GetInsertCommand(), con);
            cmdLibBookHeader.Parameters.Add("@BookID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(BookIDFN));
            cmdLibBookHeader.Parameters.Add("@strTitle", SqlDbType.NVarChar, 510, LibraryMOD.GetFieldName(strTitleFN));
            cmdLibBookHeader.Parameters.Add("@strTitleParallel", SqlDbType.NVarChar, 510, LibraryMOD.GetFieldName(strTitleParallelFN));
            cmdLibBookHeader.Parameters.Add("@PublishedYear", SqlDbType.Int, 4, LibraryMOD.GetFieldName(PublishedYearFN));
            cmdLibBookHeader.Parameters.Add("@PlaceID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(PlaceIDFN));
            cmdLibBookHeader.Parameters.Add("@SupplierID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(SupplierIDFN));
            cmdLibBookHeader.Parameters.Add("@strISBN", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strISBNFN));
            cmdLibBookHeader.Parameters.Add("@strEdition", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strEditionFN));
            cmdLibBookHeader.Parameters.Add("@ClassificationID", SqlDbType.NVarChar, 200, LibraryMOD.GetFieldName(ClassificationIDFN));
            cmdLibBookHeader.Parameters.Add("@strShortcut", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strShortcutFN));
            cmdLibBookHeader.Parameters.Add("@PageCount", SqlDbType.Int, 4, LibraryMOD.GetFieldName(PageCountFN));
            cmdLibBookHeader.Parameters.Add("@Volume", SqlDbType.Int, 2, LibraryMOD.GetFieldName(VolumeFN));
            cmdLibBookHeader.Parameters.Add("@LanguageID", SqlDbType.Int, 2, LibraryMOD.GetFieldName(LanguageIDFN));
            cmdLibBookHeader.Parameters.Add("@dateBook", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dateBookFN));
            cmdLibBookHeader.Parameters.Add("@SeriesID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(SeriesIDFN));
            cmdLibBookHeader.Parameters.Add("@IndxerID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(IndxerIDFN));
            cmdLibBookHeader.Parameters.Add("@AuditorID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(AuditorIDFN));
            cmdLibBookHeader.Parameters.Add("@strUserCreate", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strUserCreateFN));
            cmdLibBookHeader.Parameters.Add("@dateCreate", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dateCreateFN));
            cmdLibBookHeader.Parameters.Add("@strUserSave", SqlDbType.Char, 10, LibraryMOD.GetFieldName(strUserSaveFN));
            cmdLibBookHeader.Parameters.Add("@dateLastSave", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dateLastSaveFN));
            cmdLibBookHeader.Parameters.Add("@strMachine", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strMachineFN));
            cmdLibBookHeader.Parameters.Add("@strNUser", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strNUserFN));
            Parmeter.SourceVersion = DataRowVersion.Current;
            daLibBookHeader.InsertCommand = cmdLibBookHeader;
            daLibBookHeader.InsertCommand.UpdatedRowSource = UpdateRowSource.None;
            //'------------------------
            //'/DELETE COMMAND
            cmdLibBookHeader = new SqlCommand(GetDeleteCommand(), con);
            Parmeter = cmdLibBookHeader.Parameters.Add("@BookID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(BookIDFN));
            Parmeter.SourceVersion = DataRowVersion.Original;
            daLibBookHeader.DeleteCommand = cmdLibBookHeader;
            daLibBookHeader.DeleteCommand.UpdatedRowSource = UpdateRowSource.None;
            //'Batch Size
            //'Set the batch size.
            daLibBookHeader.UpdateBatchSize = ECTGlobalDll.InitializeModule.BATCH_SIZE;
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return daLibBookHeader;
    }
    //'-------SaveData  -----------------------------
    public int SaveData(int lFormMode)
    {
        //SaveData= ECTGlobalDll.InitializeModule.FAIL_RET;
        try
        {
            switch (lFormMode)
            {
                case (int)ECTGlobalDll.InitializeModule.enumModes.NewMode:
                    DataRow dr = default(DataRow);
                    dr = dsLibBookHeader.Tables[TableName].NewRow();
                    dr[LibraryMOD.GetFieldName(BookIDFN)] = BookID;
                    dr[LibraryMOD.GetFieldName(strTitleFN)] = strTitle;
                    dr[LibraryMOD.GetFieldName(strTitleParallelFN)] = strTitleParallel;
                    dr[LibraryMOD.GetFieldName(PublishedYearFN)] = PublishedYear;
                    dr[LibraryMOD.GetFieldName(PlaceIDFN)] = PlaceID;
                    dr[LibraryMOD.GetFieldName(SupplierIDFN)] = SupplierID;
                    dr[LibraryMOD.GetFieldName(strISBNFN)] = strISBN;
                    dr[LibraryMOD.GetFieldName(strEditionFN)] = strEdition;
                    dr[LibraryMOD.GetFieldName(ClassificationIDFN)] = ClassificationID;
                    dr[LibraryMOD.GetFieldName(strShortcutFN)] = strShortcut;
                    dr[LibraryMOD.GetFieldName(PageCountFN)] = PageCount;
                    dr[LibraryMOD.GetFieldName(VolumeFN)] = Volume;
                    dr[LibraryMOD.GetFieldName(LanguageIDFN)] = LanguageID;
                    dr[LibraryMOD.GetFieldName(dateBookFN)] = dateBook;
                    dr[LibraryMOD.GetFieldName(SeriesIDFN)] = SeriesID;
                    dr[LibraryMOD.GetFieldName(IndxerIDFN)] = IndxerID;
                    dr[LibraryMOD.GetFieldName(AuditorIDFN)] = AuditorID;
                    dr[LibraryMOD.GetFieldName(strUserCreateFN)] = strUserCreate;
                    dr[LibraryMOD.GetFieldName(dateCreateFN)] = dateCreate;
                    dr[LibraryMOD.GetFieldName(strUserSaveFN)] = strUserSave;
                    dr[LibraryMOD.GetFieldName(dateLastSaveFN)] = dateLastSave;
                    dr[LibraryMOD.GetFieldName(strMachineFN)] = strMachine;
                    dr[LibraryMOD.GetFieldName(strNUserFN)] = strNUser;
                    dsLibBookHeader.Tables[TableName].Rows.Add(dr);
                    break;
                case (int)ECTGlobalDll.InitializeModule.enumModes.EditMode:
                    DataRow[] drAry = null;
                    drAry = dsLibBookHeader.Tables[TableName].Select(LibraryMOD.GetFieldName(BookIDFN) + "=" + BookID);
                    //'its return array of rows and we can access the first by index 0
                    drAry[0][LibraryMOD.GetFieldName(BookIDFN)] = BookID;
                    drAry[0][LibraryMOD.GetFieldName(strTitleFN)] = strTitle;
                    drAry[0][LibraryMOD.GetFieldName(strTitleParallelFN)] = strTitleParallel;
                    drAry[0][LibraryMOD.GetFieldName(PublishedYearFN)] = PublishedYear;
                    drAry[0][LibraryMOD.GetFieldName(PlaceIDFN)] = PlaceID;
                    drAry[0][LibraryMOD.GetFieldName(SupplierIDFN)] = SupplierID;
                    drAry[0][LibraryMOD.GetFieldName(strISBNFN)] = strISBN;
                    drAry[0][LibraryMOD.GetFieldName(strEditionFN)] = strEdition;
                    drAry[0][LibraryMOD.GetFieldName(ClassificationIDFN)] = ClassificationID;
                    drAry[0][LibraryMOD.GetFieldName(strShortcutFN)] = strShortcut;
                    drAry[0][LibraryMOD.GetFieldName(PageCountFN)] = PageCount;
                    drAry[0][LibraryMOD.GetFieldName(VolumeFN)] = Volume;
                    drAry[0][LibraryMOD.GetFieldName(LanguageIDFN)] = LanguageID;
                    drAry[0][LibraryMOD.GetFieldName(dateBookFN)] = dateBook;
                    drAry[0][LibraryMOD.GetFieldName(SeriesIDFN)] = SeriesID;
                    drAry[0][LibraryMOD.GetFieldName(IndxerIDFN)] = IndxerID;
                    drAry[0][LibraryMOD.GetFieldName(AuditorIDFN)] = AuditorID;
                    drAry[0][LibraryMOD.GetFieldName(strUserCreateFN)] = strUserCreate;
                    drAry[0][LibraryMOD.GetFieldName(dateCreateFN)] = dateCreate;
                    drAry[0][LibraryMOD.GetFieldName(strUserSaveFN)] = strUserSave;
                    drAry[0][LibraryMOD.GetFieldName(dateLastSaveFN)] = dateLastSave;
                    drAry[0][LibraryMOD.GetFieldName(strMachineFN)] = strMachine;
                    drAry[0][LibraryMOD.GetFieldName(strNUserFN)] = strNUser;
                    break;
            }
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return ECTGlobalDll.InitializeModule.SUCCESS_RET;
    }
    //'-------Commit  -----------------------------
    public int CommitLibBookHeader()
    {
        //CommitLibBookHeader= ECTGlobalDll.InitializeModule.FAIL_RET;
        try
        {
            //'' Update Database with SqlDataAdapter
            daLibBookHeader.Update(dsLibBookHeader, TableName);
            //'Sent Update to database.
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return ECTGlobalDll.InitializeModule.SUCCESS_RET;
    }
    //'-------DeleteRow  -----------------------------
    public int DeleteRow()
    {
        //DeleteRow= ECTGlobalDll.InitializeModule.FAIL_RET;
        try
        {
            FindInMultiPKey(BookID);
            if ((LibBookHeaderDataRow != null))
            {
                LibBookHeaderDataRow.Delete();
                CommitLibBookHeader();
                if (MoveNext() == ECTGlobalDll.InitializeModule.FAIL_RET) return ECTGlobalDll.InitializeModule.FAIL_RET;
            }
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return ECTGlobalDll.InitializeModule.SUCCESS_RET;
    }
    #endregion
    //'-------SynchronizeDataRowToClass  -----------------------------
    private int SynchronizeDataRowToClass()
    {
        try
        {
            if (LibBookHeaderDataRow[LibraryMOD.GetFieldName(BookIDFN)] == System.DBNull.Value)
            {
                BookID = 0;
            }
            else
            {
                BookID = (int)LibBookHeaderDataRow[LibraryMOD.GetFieldName(BookIDFN)];
            }
            if (LibBookHeaderDataRow[LibraryMOD.GetFieldName(strTitleFN)] == System.DBNull.Value)
            {
                strTitle = "";
            }
            else
            {
                strTitle = (string)LibBookHeaderDataRow[LibraryMOD.GetFieldName(strTitleFN)];
            }
            if (LibBookHeaderDataRow[LibraryMOD.GetFieldName(strTitleParallelFN)] == System.DBNull.Value)
            {
                strTitleParallel = "";
            }
            else
            {
                strTitleParallel = (string)LibBookHeaderDataRow[LibraryMOD.GetFieldName(strTitleParallelFN)];
            }
            if (LibBookHeaderDataRow[LibraryMOD.GetFieldName(PublishedYearFN)] == System.DBNull.Value)
            {
                PublishedYear = 0;
            }
            else
            {
                PublishedYear = (int)LibBookHeaderDataRow[LibraryMOD.GetFieldName(PublishedYearFN)];
            }
            if (LibBookHeaderDataRow[LibraryMOD.GetFieldName(PlaceIDFN)] == System.DBNull.Value)
            {
                PlaceID = 0;
            }
            else
            {
                PlaceID = (int)LibBookHeaderDataRow[LibraryMOD.GetFieldName(PlaceIDFN)];
            }
            if (LibBookHeaderDataRow[LibraryMOD.GetFieldName(SupplierIDFN)] == System.DBNull.Value)
            {
                SupplierID = 0;
            }
            else
            {
                SupplierID = (int)LibBookHeaderDataRow[LibraryMOD.GetFieldName(SupplierIDFN)];
            }
            if (LibBookHeaderDataRow[LibraryMOD.GetFieldName(strISBNFN)] == System.DBNull.Value)
            {
                strISBN = "";
            }
            else
            {
                strISBN = (string)LibBookHeaderDataRow[LibraryMOD.GetFieldName(strISBNFN)];
            }
            if (LibBookHeaderDataRow[LibraryMOD.GetFieldName(strEditionFN)] == System.DBNull.Value)
            {
                strEdition = "";
            }
            else
            {
                strEdition = (string)LibBookHeaderDataRow[LibraryMOD.GetFieldName(strEditionFN)];
            }
            if (LibBookHeaderDataRow[LibraryMOD.GetFieldName(ClassificationIDFN)] == System.DBNull.Value)
            {
                ClassificationID = "";
            }
            else
            {
                ClassificationID = (string)LibBookHeaderDataRow[LibraryMOD.GetFieldName(ClassificationIDFN)];
            }
            if (LibBookHeaderDataRow[LibraryMOD.GetFieldName(strShortcutFN)] == System.DBNull.Value)
            {
                strShortcut = "";
            }
            else
            {
                strShortcut = (string)LibBookHeaderDataRow[LibraryMOD.GetFieldName(strShortcutFN)];
            }
            if (LibBookHeaderDataRow[LibraryMOD.GetFieldName(BookTypeFN)] == System.DBNull.Value)
            {
                BookType = "-1";
            }
            else
            {
                BookType = (string)LibBookHeaderDataRow[LibraryMOD.GetFieldName(BookTypeFN)];
            }
            if (LibBookHeaderDataRow[LibraryMOD.GetFieldName(PageCountFN)] == System.DBNull.Value)
            {
                PageCount = 0;
            }
            else
            {
                PageCount = (int)LibBookHeaderDataRow[LibraryMOD.GetFieldName(PageCountFN)];
            }
            if (LibBookHeaderDataRow[LibraryMOD.GetFieldName(VolumeFN)] == System.DBNull.Value)
            {
                Volume = 0;
            }
            else
            {
                Volume = (int)LibBookHeaderDataRow[LibraryMOD.GetFieldName(VolumeFN)];
            }
            if (LibBookHeaderDataRow[LibraryMOD.GetFieldName(LanguageIDFN)] == System.DBNull.Value)
            {
                LanguageID = 0;
            }
            else
            {
                LanguageID = (int)LibBookHeaderDataRow[LibraryMOD.GetFieldName(LanguageIDFN)];
            }
            if (LibBookHeaderDataRow[LibraryMOD.GetFieldName(dateBookFN)] == System.DBNull.Value)
            {
            }
            else
            {
                dateBook = (DateTime)LibBookHeaderDataRow[LibraryMOD.GetFieldName(dateBookFN)];
            }
            if (LibBookHeaderDataRow[LibraryMOD.GetFieldName(SeriesIDFN)] == System.DBNull.Value)
            {
                SeriesID = 0;
            }
            else
            {
                SeriesID = (int)LibBookHeaderDataRow[LibraryMOD.GetFieldName(SeriesIDFN)];
            }
            if (LibBookHeaderDataRow[LibraryMOD.GetFieldName(IndxerIDFN)] == System.DBNull.Value)
            {
                IndxerID = 0;
            }
            else
            {
                IndxerID = (int)LibBookHeaderDataRow[LibraryMOD.GetFieldName(IndxerIDFN)];
            }
            if (LibBookHeaderDataRow[LibraryMOD.GetFieldName(AuditorIDFN)] == System.DBNull.Value)
            {
                AuditorID = 0;
            }
            else
            {
                AuditorID = (int)LibBookHeaderDataRow[LibraryMOD.GetFieldName(AuditorIDFN)];
            }
            if (LibBookHeaderDataRow[LibraryMOD.GetFieldName(strUserCreateFN)] == System.DBNull.Value)
            {
                strUserCreate = "";
            }
            else
            {
                strUserCreate = (string)LibBookHeaderDataRow[LibraryMOD.GetFieldName(strUserCreateFN)];
            }
            if (LibBookHeaderDataRow[LibraryMOD.GetFieldName(dateCreateFN)] == System.DBNull.Value)
            {
            }
            else
            {
                dateCreate = (DateTime)LibBookHeaderDataRow[LibraryMOD.GetFieldName(dateCreateFN)];
            }
            if (LibBookHeaderDataRow[LibraryMOD.GetFieldName(strUserSaveFN)] == System.DBNull.Value)
            {
                strUserSave = "";
            }
            else
            {
                strUserSave = (string)LibBookHeaderDataRow[LibraryMOD.GetFieldName(strUserSaveFN)];
            }
            if (LibBookHeaderDataRow[LibraryMOD.GetFieldName(dateLastSaveFN)] == System.DBNull.Value)
            {
            }
            else
            {
                dateLastSave = (DateTime)LibBookHeaderDataRow[LibraryMOD.GetFieldName(dateLastSaveFN)];
            }
            if (LibBookHeaderDataRow[LibraryMOD.GetFieldName(strMachineFN)] == System.DBNull.Value)
            {
                strMachine = "";
            }
            else
            {
                strMachine = (string)LibBookHeaderDataRow[LibraryMOD.GetFieldName(strMachineFN)];
            }
            if (LibBookHeaderDataRow[LibraryMOD.GetFieldName(strNUserFN)] == System.DBNull.Value)
            {
                strNUser = "";
            }
            else
            {
                strNUser = (string)LibBookHeaderDataRow[LibraryMOD.GetFieldName(strNUserFN)];
            }
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return ECTGlobalDll.InitializeModule.SUCCESS_RET;
    }
    //'-------FindInMultiPKey  -----------------------------
    public int FindInMultiPKey(int PKBookID)
    {
        //FindInMultiPKey= ECTGlobalDll.InitializeModule.FAIL_RET;
        try
        {
            //' Create an array for the key values to find.
            object[] findTheseVals = new object[1];
            //' Set the values of the keys to find.
            findTheseVals[0] = PKBookID;
            LibBookHeaderDataRow = dsLibBookHeader.Tables[TableName].Rows.Find(findTheseVals);
            if ((LibBookHeaderDataRow != null))
            {
                lngCurRow = dsLibBookHeader.Tables[TableName].Rows.IndexOf(LibBookHeaderDataRow);
                SynchronizeDataRowToClass();
                return ECTGlobalDll.InitializeModule.SUCCESS_RET;
            }
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return ECTGlobalDll.InitializeModule.FAIL_RET;
    }
    #region "Navigation"
    //'-------MoveFirst  -----------------------------
    public int MoveFirst()
    {
        //MoveFirst= ECTGlobalDll.InitializeModule.FAIL_RET;
        try
        {
            lngCurRow = 0;
            if (GoToCurrentRow() == ECTGlobalDll.InitializeModule.FAIL_RET) return InitializeModule.FAIL_RET;
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return ECTGlobalDll.InitializeModule.SUCCESS_RET;
    }
    //'-------MovePrevious  -----------------------------
    public int MovePrevious()
    {
        //MovePrevious= InitializeModule.FAIL_RET;
        try
        {
            lngCurRow = Math.Max(lngCurRow - 1, 0);
            if (GoToCurrentRow() == ECTGlobalDll.InitializeModule.FAIL_RET) return ECTGlobalDll.InitializeModule.FAIL_RET;
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return ECTGlobalDll.InitializeModule.SUCCESS_RET;
    }
    //'-------MoveLast  -----------------------------
    public int MoveLast()
    {
        //MoveLast= ECTGlobalDll.InitializeModule.FAIL_RET;
        try
        {
            lngCurRow = dsLibBookHeader.Tables[TableName].Rows.Count - 1; //'Zero based index
            if (GoToCurrentRow() == ECTGlobalDll.InitializeModule.FAIL_RET) return ECTGlobalDll.InitializeModule.FAIL_RET;
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return ECTGlobalDll.InitializeModule.SUCCESS_RET;
    }
    //'-------MoveNext  -----------------------------
    public int MoveNext()
    {
        //MoveNext= ECTGlobalDll.InitializeModule.FAIL_RET;
        try
        {
            lngCurRow = Math.Min(lngCurRow + 1, dsLibBookHeader.Tables[TableName].Rows.Count - 1);
            if (GoToCurrentRow() == ECTGlobalDll.InitializeModule.FAIL_RET) return ECTGlobalDll.InitializeModule.FAIL_RET;
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return ECTGlobalDll.InitializeModule.SUCCESS_RET;
    }
    //'-------GoToCurrentRow  -----------------------------
    public int GoToCurrentRow()
    {
        //GoToCurrentRow= ECTGlobalDll.InitializeModule.FAIL_RET;
        try
        {
            if (lngCurRow >= 0 & dsLibBookHeader.Tables[TableName].Rows.Count > 0)
            {
                LibBookHeaderDataRow = dsLibBookHeader.Tables[TableName].Rows[lngCurRow];
                SynchronizeDataRowToClass();
            }
            else return ECTGlobalDll.InitializeModule.FAIL_RET;
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return ECTGlobalDll.InitializeModule.SUCCESS_RET;
    }
    #endregion
    #region "Events"
    //'-------AddDAEventHandler  -----------------------------
    public int AddDAEventHandler()
    {
        // ECTGlobalDll.InitializeModule.FAIL_RET;
        try
        {
            daLibBookHeader.RowUpdating += new SqlRowUpdatingEventHandler(OnRowUpdating);
            daLibBookHeader.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return ECTGlobalDll.InitializeModule.SUCCESS_RET;
    }
    //'-------RemoveDAEventHandler  -----------------------------
    public int RemoveDAEventHandler()
    {
        // InitializeModule.FAIL_RET;
        try
        {
            daLibBookHeader.RowUpdating -= new SqlRowUpdatingEventHandler(OnRowUpdating);
            daLibBookHeader.RowUpdated -= new SqlRowUpdatedEventHandler(OnRowUpdated);
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return ECTGlobalDll.InitializeModule.SUCCESS_RET;
    }
    //'-------OnRowUpdating  -----------------------------
    private static void OnRowUpdating(object sender, SqlRowUpdatingEventArgs args)
    {
        try
        {
            if (args.StatementType == StatementType.Delete)
            {
                System.IO.TextWriter tw = System.IO.File.AppendText("Delete.log");
                tw.Close();
            }
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
    }
    //'-------OnRowUpdated  -----------------------------
    private static void OnRowUpdated(object sender, SqlRowUpdatedEventArgs args)
    {
        try
        {
            if (args.Status == UpdateStatus.ErrorsOccurred)
            {
                args.Row.RowError = args.Errors.Message;
                System.IO.File.AppendText("Delete.log");
            }
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
    }
    #endregion
    //end third class
}
