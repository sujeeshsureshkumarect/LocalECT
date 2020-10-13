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

public class BookStudent
{
    //Creation Date: 14/03/2012 10:30:43 AM
    //Programmer Name : Hazem Galal
    //-----Decleration --------------
    #region "Decleration"
    private int m_BookId;
    private string m_BookName;
    private int m_PublishYear;
    private string m_AuthorName;
    private string m_Publisher;
    private int m_Pages;
    private int m_Language;
    private int m_LimitedCount;
    private string m_strUserCreate;
    private DateTime m_dateCreate;
    private string m_strUserSave;
    private DateTime m_dateLastSave;
    private string m_strMachine;
    private string m_strNUser;
    private int m_IsActive;
    #endregion
    #region "Puplic Properties"
    //'-----------------------------------------------------
    public int BookId
    {
        get { return m_BookId; }
        set { m_BookId = value; }
    }
    public string BookName
    {
        get { return m_BookName; }
        set { m_BookName = value; }
    }
    public int PublishYear
    {
        get { return m_PublishYear; }
        set { m_PublishYear = value; }
    }
    public string AuthorName
    {
        get { return m_AuthorName; }
        set { m_AuthorName = value; }
    }
    public string Publisher
    {
        get { return m_Publisher; }
        set { m_Publisher = value; }
    }
    public int Pages
    {
        get { return m_Pages; }
        set { m_Pages = value; }
    }
    public int Language
    {
        get { return m_Language; }
        set { m_Language = value; }
    }
    public int LimitedCount
    {
        get { return m_LimitedCount; }
        set { m_LimitedCount = value; }
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

    public int IsActive
    {
        get { return m_IsActive; }
        set { m_IsActive = value; }
    }
    //'-----------------------------------------------------
    #endregion
    //'-----------------------------------------------------
    public BookStudent()
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

public class BookStudentDAL : BookStudent
{
    #region "Decleration"
    private string m_TableName;
    private string m_BookIdFN;
    private string m_BookNameFN;
    private string m_PublishYearFN;
    private string m_AuthorNameFN;
    private string m_PublisherFN;
    private string m_PagesFN;
    private string m_LanguageFN;
    private string m_LimitedCountFN;
    private string m_strUserCreateFN;
    private string m_dateCreateFN;
    private string m_strUserSaveFN;
    private string m_dateLastSaveFN;
    private string m_strMachineFN;
    private string m_strNUserFN;
    private string m_IsActiveFN;
    #endregion
    //'-----------------------------------------------------
    #region "Puplic Properties"
    public string TableName
    {
        get { return m_TableName; }
        set { m_TableName = value; }
    }
    public string BookIdFN
    {
        get { return m_BookIdFN; }
        set { m_BookIdFN = value; }
    }
    public string BookNameFN
    {
        get { return m_BookNameFN; }
        set { m_BookNameFN = value; }
    }
    public string PublishYearFN
    {
        get { return m_PublishYearFN; }
        set { m_PublishYearFN = value; }
    }
    public string AuthorNameFN
    {
        get { return m_AuthorNameFN; }
        set { m_AuthorNameFN = value; }
    }
    public string PublisherFN
    {
        get { return m_PublisherFN; }
        set { m_PublisherFN = value; }
    }
    public string PagesFN
    {
        get { return m_PagesFN; }
        set { m_PagesFN = value; }
    }
    public string LanguageFN
    {
        get { return m_LanguageFN; }
        set { m_LanguageFN = value; }
    }
    public string LimitedCountFN
    {
        get { return m_LimitedCountFN; }
        set { m_LimitedCountFN = value; }
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
    public string IsActiveFN
    {
        get { return m_IsActiveFN; }
        set { m_IsActiveFN = value; }
    }
    

    #endregion
    //================End Properties ===================
    public BookStudentDAL()
    {
        try
        {
            this.TableName = "Sto_BookStudent";
            this.BookIdFN = m_TableName + ".BookId";
            this.BookNameFN = m_TableName + ".BookName";
            this.PublishYearFN = m_TableName + ".PublishYear";
            this.AuthorNameFN = m_TableName + ".AuthorName";
            this.PublisherFN = m_TableName + ".Publisher";
            this.PagesFN = m_TableName + ".Pages";
            this.LanguageFN = m_TableName + ".Language";
            this.LimitedCountFN = m_TableName + ".LimitedCount";
            this.strUserCreateFN = m_TableName + ".strUserCreate";
            this.dateCreateFN = m_TableName + ".dateCreate";
            this.strUserSaveFN = m_TableName + ".strUserSave";
            this.dateLastSaveFN = m_TableName + ".dateLastSave";
            this.strMachineFN = m_TableName + ".strMachine";
            this.strNUserFN = m_TableName + ".strNUser";
            this.IsActiveFN = m_TableName + ".IsActive";
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
            sSQL += BookIdFN;
            sSQL += " , " + BookNameFN;
            sSQL += " , " + PublishYearFN;
            sSQL += " , " + AuthorNameFN;
            sSQL += " , " + PublisherFN;
            sSQL += " , " + PagesFN;
            sSQL += " , " + LanguageFN;
            sSQL += " , " + LimitedCountFN;
            sSQL += " , " + strUserCreateFN;
            sSQL += " , " + dateCreateFN;
            sSQL += " , " + strUserSaveFN;
            sSQL += " , " + dateLastSaveFN;
            sSQL += " , " + strMachineFN;
            sSQL += " , " + strNUserFN;
            sSQL += " , " + IsActiveFN;
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
            sSQL += BookIdFN;
            sSQL += " , " + BookNameFN;
            sSQL += " , " + PublishYearFN;
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
            sSQL += BookIdFN;
            sSQL += " , " + BookNameFN;
            sSQL += " , " + PublishYearFN;
            sSQL += " , " + AuthorNameFN;
            sSQL += " , " + PublisherFN;
            sSQL += " , " + PagesFN;
            sSQL += " , " + LanguageFN;
            sSQL += " , " + LimitedCountFN;
            sSQL += " , " + strUserCreateFN;
            sSQL += " , " + dateCreateFN;
            sSQL += " , " + strUserSaveFN;
            sSQL += " , " + dateLastSaveFN;
            sSQL += " , " + strMachineFN;
            sSQL += " , " + strNUserFN;
            sSQL += " , " + IsActiveFN;
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
            sSQL += LibraryMOD.GetFieldName(BookIdFN) + "=@BookId";
            sSQL += " , " + LibraryMOD.GetFieldName(BookNameFN) + "=@BookName";
            sSQL += " , " + LibraryMOD.GetFieldName(PublishYearFN) + "=@PublishYear";
            sSQL += " , " + LibraryMOD.GetFieldName(AuthorNameFN) + "=@AuthorName";
            sSQL += " , " + LibraryMOD.GetFieldName(PublisherFN) + "=@Publisher";
            sSQL += " , " + LibraryMOD.GetFieldName(PagesFN) + "=@Pages";
            sSQL += " , " + LibraryMOD.GetFieldName(LanguageFN) + "=@Language";
            sSQL += " , " + LibraryMOD.GetFieldName(LimitedCountFN) + "=@LimitedCount";
            sSQL += " , " + LibraryMOD.GetFieldName(strUserCreateFN) + "=@strUserCreate";
            sSQL += " , " + LibraryMOD.GetFieldName(dateCreateFN) + "=@dateCreate";
            sSQL += " , " + LibraryMOD.GetFieldName(strUserSaveFN) + "=@strUserSave";
            sSQL += " , " + LibraryMOD.GetFieldName(dateLastSaveFN) + "=@dateLastSave";
            sSQL += " , " + LibraryMOD.GetFieldName(strMachineFN) + "=@strMachine";
            sSQL += " , " + LibraryMOD.GetFieldName(strNUserFN) + "=@strNUser";
            sSQL += " , " + LibraryMOD.GetFieldName(IsActiveFN) + "=@IsActive";
            sSQL += " WHERE ";
            sSQL += LibraryMOD.GetFieldName(BookIdFN) + "=@BookId";
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
            sSQL += LibraryMOD.GetFieldName(BookIdFN);
            sSQL += " , " + LibraryMOD.GetFieldName(BookNameFN);
            sSQL += " , " + LibraryMOD.GetFieldName(PublishYearFN);
            sSQL += " , " + LibraryMOD.GetFieldName(AuthorNameFN);
            sSQL += " , " + LibraryMOD.GetFieldName(PublisherFN);
            sSQL += " , " + LibraryMOD.GetFieldName(PagesFN);
            sSQL += " , " + LibraryMOD.GetFieldName(LanguageFN);
            sSQL += " , " + LibraryMOD.GetFieldName(LimitedCountFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strUserCreateFN);
            sSQL += " , " + LibraryMOD.GetFieldName(dateCreateFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strUserSaveFN);
            sSQL += " , " + LibraryMOD.GetFieldName(dateLastSaveFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strMachineFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strNUserFN);
            sSQL += " , " + LibraryMOD.GetFieldName(IsActiveFN);
            sSQL += ")";
            sSQL += " VALUES ";
            sSQL += "( ";
            sSQL += " @BookId";
            sSQL += " ,@BookName";
            sSQL += " ,@PublishYear";
            sSQL += " ,@AuthorName";
            sSQL += " ,@Publisher";
            sSQL += " ,@Pages";
            sSQL += " ,@Language";
            sSQL += " ,@LimitedCount";
            sSQL += " ,@strUserCreate";
            sSQL += " ,@dateCreate";
            sSQL += " ,@strUserSave";
            sSQL += " ,@dateLastSave";
            sSQL += " ,@strMachine";
            sSQL += " ,@strNUser";
            sSQL += " ,@IsActive";
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
            sSQL += LibraryMOD.GetFieldName(BookIdFN) + "=@BookId";
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
    public List<BookStudent> GetBookStudent(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
    {
        //' returns a list of Classes instances based on the
        //' data in the BookStudent
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
        List<BookStudent> results = new List<BookStudent>();
        try
        {
            //Default Value
            BookStudent myBookStudent = new BookStudent();
            if (isDeafaultIncluded)
            {
                //Change the code here
                myBookStudent.BookId = 0;
                results.Add(myBookStudent);
            }
            while (reader.Read())
            {
                myBookStudent = new BookStudent();
                if (reader[LibraryMOD.GetFieldName(BookIdFN)].Equals(DBNull.Value))
                {
                    myBookStudent.BookId = 0;
                }
                else
                {
                    myBookStudent.BookId = int.Parse(reader[LibraryMOD.GetFieldName(BookIdFN)].ToString());
                }
                myBookStudent.BookName = reader[LibraryMOD.GetFieldName(BookNameFN)].ToString();
                if (reader[LibraryMOD.GetFieldName(PublishYearFN)].Equals(DBNull.Value))
                {
                    myBookStudent.PublishYear = 0;
                }
                else
                {
                    myBookStudent.PublishYear = int.Parse(reader[LibraryMOD.GetFieldName(PublishYearFN)].ToString());
                }
                myBookStudent.AuthorName = reader[LibraryMOD.GetFieldName(AuthorNameFN)].ToString();
                myBookStudent.Publisher = reader[LibraryMOD.GetFieldName(PublisherFN)].ToString();
                if (reader[LibraryMOD.GetFieldName(PagesFN)].Equals(DBNull.Value))
                {
                    myBookStudent.Pages = 0;
                }
                else
                {
                    myBookStudent.Pages = int.Parse(reader[LibraryMOD.GetFieldName(PagesFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(LanguageFN)].Equals(DBNull.Value))
                {
                    myBookStudent.Language = 0;
                }
                else
                {
                    myBookStudent.Language = int.Parse(reader[LibraryMOD.GetFieldName(LanguageFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(LimitedCountFN)].Equals(DBNull.Value))
                {
                    myBookStudent.LimitedCount = 0;
                }
                else
                {
                    myBookStudent.LimitedCount = int.Parse(reader[LibraryMOD.GetFieldName(LimitedCountFN)].ToString());
                }

                if (reader[LibraryMOD.GetFieldName(IsActiveFN)].Equals(DBNull.Value))
                {
                    myBookStudent.IsActive = 0;
                }
                else
                {
                    myBookStudent.IsActive = Convert.ToInt32(Convert.ToBoolean(reader[LibraryMOD.GetFieldName(IsActiveFN)].ToString()));
                }
                myBookStudent.strUserCreate = reader[LibraryMOD.GetFieldName(strUserCreateFN)].ToString();
                if (!reader[LibraryMOD.GetFieldName(dateCreateFN)].Equals(DBNull.Value))
                {
                    myBookStudent.dateCreate = DateTime.Parse(reader[LibraryMOD.GetFieldName(dateCreateFN)].ToString());
                }
                myBookStudent.strUserSave = reader[LibraryMOD.GetFieldName(strUserSaveFN)].ToString();
                if (!reader[LibraryMOD.GetFieldName(dateLastSaveFN)].Equals(DBNull.Value))
                {
                    myBookStudent.dateLastSave = DateTime.Parse(reader[LibraryMOD.GetFieldName(dateLastSaveFN)].ToString());
                }
                myBookStudent.strMachine = reader[LibraryMOD.GetFieldName(strMachineFN)].ToString();
                myBookStudent.strNUser = reader[LibraryMOD.GetFieldName(strNUserFN)].ToString();
                results.Add(myBookStudent);
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
    public List<BookStudent> GetList(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
    {
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        string sSQL = GetListSQL(sCondition);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        SqlCommand Cmd = new SqlCommand(sSQL, Conn);
        Conn.Open();
        SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
        List<BookStudent> results = new List<BookStudent>();
        try
        {
            //Default Value
            BookStudent myBookStudent = new BookStudent();
            if (isDeafaultIncluded)
            {
                //Change the code here
                myBookStudent.BookId = -1;
                myBookStudent.BookName = "Select BookStudent";
                results.Add(myBookStudent);
            }
            while (reader.Read())
            {
                myBookStudent = new BookStudent();
                if (reader[LibraryMOD.GetFieldName(BookIdFN)].Equals(DBNull.Value))
                {
                    myBookStudent.BookId = 0;
                }
                else
                {
                    myBookStudent.BookId = int.Parse(reader[LibraryMOD.GetFieldName(BookIdFN)].ToString());
                }
                myBookStudent.BookName = reader[LibraryMOD.GetFieldName(BookNameFN)].ToString();
                if (reader[LibraryMOD.GetFieldName(PublishYearFN)].Equals(DBNull.Value))
                {
                    myBookStudent.PublishYear = 0;
                }
                else
                {
                    myBookStudent.PublishYear = int.Parse(reader[LibraryMOD.GetFieldName(PublishYearFN)].ToString());
                }
                results.Add(myBookStudent);
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
    public int UpdateBookStudent(InitializeModule.EnumCampus Campus, int iMode, int BookId, string BookName, int PublishYear, string AuthorName, string Publisher, int Pages, int Language, int LimitedCount, int IsActive, string strUserCreate, DateTime dateCreate, string strUserSave, DateTime dateLastSave, string strMachine, string strNUser)
    {
        int iEffected = 0;
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        try
        {
            Conn.Open();
            string sql = "";
            BookStudent theBookStudent = new BookStudent();
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
            Cmd.Parameters.Add(new SqlParameter("@BookId", BookId));
            Cmd.Parameters.Add(new SqlParameter("@BookName", BookName));
            Cmd.Parameters.Add(new SqlParameter("@PublishYear", PublishYear));
            Cmd.Parameters.Add(new SqlParameter("@AuthorName", AuthorName));
            Cmd.Parameters.Add(new SqlParameter("@Publisher", Publisher));
            Cmd.Parameters.Add(new SqlParameter("@Pages", Pages));
            Cmd.Parameters.Add(new SqlParameter("@Language", Language));
            Cmd.Parameters.Add(new SqlParameter("@LimitedCount", LimitedCount));
            Cmd.Parameters.Add(new SqlParameter("@strUserCreate", strUserCreate));
            Cmd.Parameters.Add(new SqlParameter("@dateCreate", dateCreate));
            Cmd.Parameters.Add(new SqlParameter("@strUserSave", strUserSave));
            Cmd.Parameters.Add(new SqlParameter("@dateLastSave", dateLastSave));
            Cmd.Parameters.Add(new SqlParameter("@strMachine", strMachine));
            Cmd.Parameters.Add(new SqlParameter("@strNUser", strNUser));
            Cmd.Parameters.Add(new SqlParameter("@IsActive", IsActive)); 
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
    public int DeleteBookStudent(InitializeModule.EnumCampus Campus, string BookId)
    {
        int iEffected = 0;
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        try
        {
            string sSQL = GetDeleteCommand();
            //sSQL += sCondition;
            SqlCommand Cmd = new SqlCommand(sSQL, Conn);
            Cmd.Parameters.Add(new SqlParameter("@BookId", BookId));
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
        DataTable dt = new DataTable("BookStudent");
        DataView dv = new DataView();
        List<BookStudent> myBookStudents = new List<BookStudent>();
        try
        {
            myBookStudents = GetBookStudent(InitializeModule.EnumCampus.ECTNew, sCondition, false);
            DataColumn col0 = new DataColumn("BookId", Type.GetType("int"));
            dt.Columns.Add(col0);
            dt.Constraints.Add(new UniqueConstraint(col0));

            DataRow dr;
            for (int i = 0; i < myBookStudents.Count; i++)
            {
                dr = dt.NewRow();
                dr[1] = myBookStudents[i].BookId;
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
            myBookStudents.Clear();
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
            sSQL += BookIdFN;
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

public class BookStudentCls : BookStudentDAL
{
    #region "Decleration"
    private int m_lngCurRow = 0;
    public SqlDataAdapter daBookStudent;
    private DataSet m_dsBookStudent;
    public DataRow BookStudentDataRow;
    #endregion
    #region "Puplic Properties"
    public DataSet dsBookStudent
    {
        get { return m_dsBookStudent; }
        set { m_dsBookStudent = value; }
    }
    //-----------------------------------------------------
    public int lngCurRow
    {
        get { return m_lngCurRow; }
        set { m_lngCurRow = value; }
    }
    #endregion
    public BookStudentCls()
    {
        try
        {
            dsBookStudent = new DataSet();

        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
    }
    public string GetBookTitle(int BookID)
    {
        string sTitle = "";
        string sSQL = "";
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());

        try
        {


            sSQL = "SELECT " + BookNameFN ;
            sSQL += " FROM " + TableName;
            sSQL += " WHERE " + BookIdFN  + "=" + BookID;

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
    public virtual SqlDataAdapter GetBookStudentDataAdapter(string sCondition, SqlConnection con)
    {
        string sSQL = "";
        try
        {
            sSQL = GetSQL();
            sSQL += " " + sCondition;
            //-----------------------------------------
            daBookStudent = new SqlDataAdapter(sSQL, con);
            // Create command builder. This line automatically generates the update commands for you, so you don't
            // have to provide or create your own.
            SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daBookStudent);
            //Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
            // key + unique key information to be retrieved unless AddWithKey is specified.
            daBookStudent.MissingSchemaAction = MissingSchemaAction.AddWithKey;
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return daBookStudent;
    }
    public virtual SqlDataAdapter GetBookStudentDataAdapter(SqlConnection con)
    {
        try
        {
            daBookStudent = new SqlDataAdapter();
            //''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
            //'' key + unique key information to be retrieved unless AddWithKey is specified.
            daBookStudent.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            //-----------------------------------------
            SqlParameter Parmeter = default(SqlParameter);
            //[SELECT COMMAND]
            SqlCommand cmdBookStudent;
            cmdBookStudent = new SqlCommand(GetSelectCommand(), con);
            //'cmdRolePermission.Parameters.Add("@BookId", SqlDbType.Int, 4, "BookId" );
            daBookStudent.SelectCommand = cmdBookStudent;
            //'Add Handlers
            //'RowUpdating,RowUpdated
            AddDAEventHandler();
            //'[UPDATE COMMAND].
            cmdBookStudent = new SqlCommand(GetUpdateCommand(), con);
            //'Delete PK Parameteres from here. b/c its declared below
            cmdBookStudent.Parameters.Add("@BookId", SqlDbType.Int, 4, LibraryMOD.GetFieldName(BookIdFN));
            cmdBookStudent.Parameters.Add("@BookName", SqlDbType.NVarChar, 510, LibraryMOD.GetFieldName(BookNameFN));
            cmdBookStudent.Parameters.Add("@PublishYear", SqlDbType.Int, 4, LibraryMOD.GetFieldName(PublishYearFN));
            cmdBookStudent.Parameters.Add("@AuthorName", SqlDbType.NVarChar, 250, LibraryMOD.GetFieldName(AuthorNameFN));
            cmdBookStudent.Parameters.Add("@Publisher", SqlDbType.NVarChar, 250, LibraryMOD.GetFieldName(PublisherFN));
            cmdBookStudent.Parameters.Add("@Pages", SqlDbType.Int, 4, LibraryMOD.GetFieldName(PagesFN));
            cmdBookStudent.Parameters.Add("@Language", SqlDbType.Int, 4, LibraryMOD.GetFieldName(LanguageFN));
            cmdBookStudent.Parameters.Add("@LimitedCount", SqlDbType.Int, 4, LibraryMOD.GetFieldName(LimitedCountFN));
            cmdBookStudent.Parameters.Add("@strUserCreate", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strUserCreateFN));
            cmdBookStudent.Parameters.Add("@dateCreate", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dateCreateFN));
            cmdBookStudent.Parameters.Add("@strUserSave", SqlDbType.Char, 10, LibraryMOD.GetFieldName(strUserSaveFN));
            cmdBookStudent.Parameters.Add("@dateLastSave", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dateLastSaveFN));
            cmdBookStudent.Parameters.Add("@strMachine", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strMachineFN));
            cmdBookStudent.Parameters.Add("@strNUser", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strNUserFN));
            cmdBookStudent.Parameters.Add("@IsActive", SqlDbType.Int, 4, LibraryMOD.GetFieldName(IsActiveFN)); 

            Parmeter = cmdBookStudent.Parameters.Add("@BookId", SqlDbType.Int, 4, LibraryMOD.GetFieldName(BookIdFN));
            Parmeter.SourceVersion = DataRowVersion.Original;
            //'Its should be none for batch updating
            //'UpdateCommand, InsertCommand, and DeleteCommand 
            //'should be set to None or OutputParameters
            daBookStudent.UpdateCommand = cmdBookStudent;
            daBookStudent.UpdateCommand.UpdatedRowSource = UpdateRowSource.None;
            //'-------------------------------------------------------------------------
            //'/INSERT COMMAND
            cmdBookStudent = new SqlCommand(GetInsertCommand(), con);
            cmdBookStudent.Parameters.Add("@BookId", SqlDbType.Int, 4, LibraryMOD.GetFieldName(BookIdFN));
            cmdBookStudent.Parameters.Add("@BookName", SqlDbType.NVarChar, 510, LibraryMOD.GetFieldName(BookNameFN));
            cmdBookStudent.Parameters.Add("@PublishYear", SqlDbType.Int, 4, LibraryMOD.GetFieldName(PublishYearFN));
            cmdBookStudent.Parameters.Add("@AuthorName", SqlDbType.NVarChar, 250, LibraryMOD.GetFieldName(AuthorNameFN));
            cmdBookStudent.Parameters.Add("@Publisher", SqlDbType.NVarChar, 250, LibraryMOD.GetFieldName(PublisherFN));
            cmdBookStudent.Parameters.Add("@Pages", SqlDbType.Int, 4, LibraryMOD.GetFieldName(PagesFN));
            cmdBookStudent.Parameters.Add("@Language", SqlDbType.Int, 4, LibraryMOD.GetFieldName(LanguageFN));
            cmdBookStudent.Parameters.Add("@LimitedCount", SqlDbType.Int, 4, LibraryMOD.GetFieldName(LimitedCountFN));
            cmdBookStudent.Parameters.Add("@strUserCreate", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strUserCreateFN));
            cmdBookStudent.Parameters.Add("@dateCreate", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dateCreateFN));
            cmdBookStudent.Parameters.Add("@strUserSave", SqlDbType.Char, 10, LibraryMOD.GetFieldName(strUserSaveFN));
            cmdBookStudent.Parameters.Add("@dateLastSave", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dateLastSaveFN));
            cmdBookStudent.Parameters.Add("@strMachine", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strMachineFN));
            cmdBookStudent.Parameters.Add("@strNUser", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strNUserFN));
            cmdBookStudent.Parameters.Add("@IsActive", SqlDbType.Int, 4, LibraryMOD.GetFieldName(IsActiveFN));

            Parmeter.SourceVersion = DataRowVersion.Current;
            daBookStudent.InsertCommand = cmdBookStudent;
            daBookStudent.InsertCommand.UpdatedRowSource = UpdateRowSource.None;
            //'------------------------
            //'/DELETE COMMAND
            cmdBookStudent = new SqlCommand(GetDeleteCommand(), con);
            Parmeter = cmdBookStudent.Parameters.Add("@BookId", SqlDbType.Int, 4, LibraryMOD.GetFieldName(BookIdFN));
            Parmeter.SourceVersion = DataRowVersion.Original;
            daBookStudent.DeleteCommand = cmdBookStudent;
            daBookStudent.DeleteCommand.UpdatedRowSource = UpdateRowSource.None;
            //'Batch Size
            //'Set the batch size.
            daBookStudent.UpdateBatchSize = ECTGlobalDll.InitializeModule.BATCH_SIZE;
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return daBookStudent;
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
                    dr = dsBookStudent.Tables[TableName].NewRow();
                    dr[LibraryMOD.GetFieldName(BookIdFN)] = BookId;
                    dr[LibraryMOD.GetFieldName(BookNameFN)] = BookName;
                    dr[LibraryMOD.GetFieldName(PublishYearFN)] = PublishYear;
                    dr[LibraryMOD.GetFieldName(AuthorNameFN)] = AuthorName;
                    dr[LibraryMOD.GetFieldName(PublisherFN)] = Publisher;
                    dr[LibraryMOD.GetFieldName(PagesFN)] = Pages;
                    dr[LibraryMOD.GetFieldName(LanguageFN)] = Language;
                    dr[LibraryMOD.GetFieldName(LimitedCountFN)] = LimitedCount;
                    dr[LibraryMOD.GetFieldName(strUserCreateFN)] = strUserCreate;
                    dr[LibraryMOD.GetFieldName(dateCreateFN)] = dateCreate;
                    dr[LibraryMOD.GetFieldName(strUserSaveFN)] = strUserSave;
                    dr[LibraryMOD.GetFieldName(dateLastSaveFN)] = dateLastSave;
                    dr[LibraryMOD.GetFieldName(strMachineFN)] = strMachine;
                    dr[LibraryMOD.GetFieldName(strNUserFN)] = strNUser;
                    dr[LibraryMOD.GetFieldName(IsActiveFN)] = IsActive;

                    dsBookStudent.Tables[TableName].Rows.Add(dr);
                    break;
                case (int)ECTGlobalDll.InitializeModule.enumModes.EditMode:
                    DataRow[] drAry = null;
                    drAry = dsBookStudent.Tables[TableName].Select(LibraryMOD.GetFieldName(BookIdFN) + "=" + BookId);
                    //'its return array of rows and we can access the first by index 0
                    drAry[0][LibraryMOD.GetFieldName(BookIdFN)] = BookId;
                    drAry[0][LibraryMOD.GetFieldName(BookNameFN)] = BookName;
                    drAry[0][LibraryMOD.GetFieldName(PublishYearFN)] = PublishYear;
                    drAry[0][LibraryMOD.GetFieldName(AuthorNameFN)] = AuthorName;
                    drAry[0][LibraryMOD.GetFieldName(PublisherFN)] = Publisher;
                    drAry[0][LibraryMOD.GetFieldName(PagesFN)] = Pages;
                    drAry[0][LibraryMOD.GetFieldName(LanguageFN)] = Language;
                    drAry[0][LibraryMOD.GetFieldName(LimitedCountFN)] = LimitedCount;
                    drAry[0][LibraryMOD.GetFieldName(strUserCreateFN)] = strUserCreate;
                    drAry[0][LibraryMOD.GetFieldName(dateCreateFN)] = dateCreate;
                    drAry[0][LibraryMOD.GetFieldName(strUserSaveFN)] = strUserSave;
                    drAry[0][LibraryMOD.GetFieldName(dateLastSaveFN)] = dateLastSave;
                    drAry[0][LibraryMOD.GetFieldName(strMachineFN)] = strMachine;
                    drAry[0][LibraryMOD.GetFieldName(strNUserFN)] = strNUser;
                    drAry[0][LibraryMOD.GetFieldName(IsActiveFN)] = IsActive;
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
    public int CommitBookStudent()
    {
        //CommitBookStudent= ECTGlobalDll.InitializeModule.FAIL_RET;
        try
        {
            //'' Update Database with SqlDataAdapter
            daBookStudent.Update(dsBookStudent, TableName);
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
            FindInMultiPKey(BookId);
            if ((BookStudentDataRow != null))
            {
                BookStudentDataRow.Delete();
                CommitBookStudent();
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
            if (BookStudentDataRow[LibraryMOD.GetFieldName(BookIdFN)] == System.DBNull.Value)
            {
                BookId = 0;
            }
            else
            {
                BookId = (int)BookStudentDataRow[LibraryMOD.GetFieldName(BookIdFN)];
            }
            if (BookStudentDataRow[LibraryMOD.GetFieldName(BookNameFN)] == System.DBNull.Value)
            {
                BookName = "";
            }
            else
            {
                BookName = (string)BookStudentDataRow[LibraryMOD.GetFieldName(BookNameFN)];
            }
            if (BookStudentDataRow[LibraryMOD.GetFieldName(PublishYearFN)] == System.DBNull.Value)
            {
                PublishYear = 0;
            }
            else
            {
                PublishYear = (int)BookStudentDataRow[LibraryMOD.GetFieldName(PublishYearFN)];
            }
            if (BookStudentDataRow[LibraryMOD.GetFieldName(AuthorNameFN)] == System.DBNull.Value)
            {
                AuthorName = "";
            }
            else
            {
                AuthorName = (string)BookStudentDataRow[LibraryMOD.GetFieldName(AuthorNameFN)];
            }
            if (BookStudentDataRow[LibraryMOD.GetFieldName(PublisherFN)] == System.DBNull.Value)
            {
                Publisher = "";
            }
            else
            {
                Publisher = (string)BookStudentDataRow[LibraryMOD.GetFieldName(PublisherFN)];
            }
            if (BookStudentDataRow[LibraryMOD.GetFieldName(PagesFN)] == System.DBNull.Value)
            {
                Pages = 0;
            }
            else
            {
                Pages = (int)BookStudentDataRow[LibraryMOD.GetFieldName(PagesFN)];
            }
            if (BookStudentDataRow[LibraryMOD.GetFieldName(LanguageFN)] == System.DBNull.Value)
            {
                Language = 0;
            }
            else
            {
                Language = (int)BookStudentDataRow[LibraryMOD.GetFieldName(LanguageFN)];
            }

            if (BookStudentDataRow[LibraryMOD.GetFieldName(IsActiveFN)] == System.DBNull.Value)
            {
                IsActive= 0;
            }
            else
            {
                IsActive = (int)BookStudentDataRow[LibraryMOD.GetFieldName(IsActiveFN)];
            }

            if (BookStudentDataRow[LibraryMOD.GetFieldName(LimitedCountFN)] == System.DBNull.Value)
            {
                LimitedCount = 0;
            }
            else
            {
                LimitedCount = (int)BookStudentDataRow[LibraryMOD.GetFieldName(LimitedCountFN)];
            }
            if (BookStudentDataRow[LibraryMOD.GetFieldName(strUserCreateFN)] == System.DBNull.Value)
            {
                strUserCreate = "";
            }
            else
            {
                strUserCreate = (string)BookStudentDataRow[LibraryMOD.GetFieldName(strUserCreateFN)];
            }
            if (BookStudentDataRow[LibraryMOD.GetFieldName(dateCreateFN)] == System.DBNull.Value)
            {
            }
            else
            {
                dateCreate = (DateTime)BookStudentDataRow[LibraryMOD.GetFieldName(dateCreateFN)];
            }
            if (BookStudentDataRow[LibraryMOD.GetFieldName(strUserSaveFN)] == System.DBNull.Value)
            {
                strUserSave = "";
            }
            else
            {
                strUserSave = (string)BookStudentDataRow[LibraryMOD.GetFieldName(strUserSaveFN)];
            }
            if (BookStudentDataRow[LibraryMOD.GetFieldName(dateLastSaveFN)] == System.DBNull.Value)
            {
            }
            else
            {
                dateLastSave = (DateTime)BookStudentDataRow[LibraryMOD.GetFieldName(dateLastSaveFN)];
            }
            if (BookStudentDataRow[LibraryMOD.GetFieldName(strMachineFN)] == System.DBNull.Value)
            {
                strMachine = "";
            }
            else
            {
                strMachine = (string)BookStudentDataRow[LibraryMOD.GetFieldName(strMachineFN)];
            }
            if (BookStudentDataRow[LibraryMOD.GetFieldName(strNUserFN)] == System.DBNull.Value)
            {
                strNUser = "";
            }
            else
            {
                strNUser = (string)BookStudentDataRow[LibraryMOD.GetFieldName(strNUserFN)];
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
    public int FindInMultiPKey(int PKBookId)
    {
        //FindInMultiPKey= ECTGlobalDll.InitializeModule.FAIL_RET;
        try
        {
            //' Create an array for the key values to find.
            object[] findTheseVals = new object[1];
            //' Set the values of the keys to find.
            findTheseVals[0] = PKBookId;
            BookStudentDataRow = dsBookStudent.Tables[TableName].Rows.Find(findTheseVals);
            if ((BookStudentDataRow != null))
            {
                lngCurRow = dsBookStudent.Tables[TableName].Rows.IndexOf(BookStudentDataRow);
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
            lngCurRow = dsBookStudent.Tables[TableName].Rows.Count - 1; //'Zero based index
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
            lngCurRow = Math.Min(lngCurRow + 1, dsBookStudent.Tables[TableName].Rows.Count - 1);
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
            if (lngCurRow >= 0 & dsBookStudent.Tables[TableName].Rows.Count > 0)
            {
                BookStudentDataRow = dsBookStudent.Tables[TableName].Rows[lngCurRow];
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
            daBookStudent.RowUpdating += new SqlRowUpdatingEventHandler(OnRowUpdating);
            daBookStudent.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
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
            daBookStudent.RowUpdating -= new SqlRowUpdatingEventHandler(OnRowUpdating);
            daBookStudent.RowUpdated -= new SqlRowUpdatedEventHandler(OnRowUpdated);
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
