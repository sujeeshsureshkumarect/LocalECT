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
public class LibTransactions
{
    //Creation Date: 31/01/2011 02:18:42 PM
    //Programmer Name : 
    //-----Decleration --------------
    #region "Decleration"
    private int m_TransactionID;
    private int m_AccesstionNo;
    private int m_BookID;
    private string m_PersonID;
    private int m_PersonRoleID;
    private string m_IsBlocked;
    private DateTime m_dateTransaction;
    private int m_TransTypeID;
    private string  m_InvoiceNO;
    private string m_InvoiceDesc;
    private int m_PublisherID;
    private int m_CurrencyID;
    private DateTime m_dateMustReturn;
    private DateTime m_dateReturn;
    private int m_CampusIDFrom;
    private int m_CampusIDTo;
    private string m_IsJournal;
    private string m_strUserCreate;
    private DateTime m_dateCreate;
    private string m_strUserSave;
    private DateTime m_dateLastSave;
    private string m_strMachine;
    private string m_strNUser;
    #endregion
    #region "Puplic Properties"
    //'-----------------------------------------------------
    public int TransactionID
    {
        get { return m_TransactionID; }
        set { m_TransactionID = value; }
    }
    public int AccesstionNo
    {
        get { return m_AccesstionNo; }
        set { m_AccesstionNo = value; }
    }
    public int BookID
    {
        get { return m_BookID; }
        set { m_BookID = value; }
    }
    public string PersonID
    {
        get { return m_PersonID; }
        set { m_PersonID = value; }
    }
    public int PersonRoleID
    {
        get { return m_PersonRoleID; }
        set { m_PersonRoleID = value; }
    }
    public string IsBlocked
    {
        get { return m_IsBlocked; }
        set { m_IsBlocked = value; }
    }
    public DateTime dateTransaction
    {
        get { return m_dateTransaction; }
        set { m_dateTransaction = value; }
    }
    public int TransTypeID
    {
        get { return m_TransTypeID; }
        set { m_TransTypeID = value; }
    }
    public string InvoiceNo
    {
        get { return m_InvoiceNO; }
        set { m_InvoiceNO = value; }
    }
    public string InvoiceDesc
    {
        get { return m_InvoiceDesc; }
        set { m_InvoiceDesc = value; }
    }

    public int PublisherID
    {
        get { return m_PublisherID; }
        set { m_PublisherID = value; }
    }

    public int CurrencyID
    {
        get { return m_CurrencyID; }
        set { m_CurrencyID = value; }
    }
    public DateTime dateMustReturn
    {
        get { return m_dateMustReturn; }
        set { m_dateMustReturn = value; }
    }
    public DateTime dateReturn
    {
        get { return m_dateReturn; }
        set { m_dateReturn = value; }
    }
    public int CampusIDFrom
    {
        get { return m_CampusIDFrom; }
        set { m_CampusIDFrom = value; }
    }
    public int CampusIDTo
    {
        get { return m_CampusIDTo; }
        set { m_CampusIDTo = value; }
    }
    public string IsJournal
    {
        get { return m_IsJournal; }
        set { m_IsJournal = value; }
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
    public LibTransactions()
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
public class LibTransactionsDAL : LibTransactions
{
    #region "Decleration"
    private string m_TableName;
    private string m_TransactionIDFN;
    private string m_AccesstionNoFN;
    private string m_BookIDFN;
    private string m_PersonIDFN;
    private string m_PersonRoleIDFN;
    private string m_IsBlockedFN;
    private string m_dateTransactionFN;
    private string m_TransTypeIDFN;
    
    private string m_InvoiceNoFN;
    private string m_InvoiceDescFN;
    private string m_PublisherIDFN;
    private string m_CurrencyIDFN;
    private string m_dateMustReturnFN;
    private string m_dateReturnFN;
    private string m_CampusIDFromFN;
    private string m_CampusIDToFN;
    private string m_IsJournalFN;
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
    public string TransactionIDFN
    {
        get { return m_TransactionIDFN; }
        set { m_TransactionIDFN = value; }
    }
    public string AccesstionNoFN
    {
        get { return m_AccesstionNoFN; }
        set { m_AccesstionNoFN = value; }
    }
    public string BookIDFN
    {
        get { return m_BookIDFN; }
        set { m_BookIDFN = value; }
    }
    public string PersonIDFN
    {
        get { return m_PersonIDFN; }
        set { m_PersonIDFN = value; }
    }
    public string PersonRoleIDFN
    {
        get { return m_PersonRoleIDFN; }
        set { m_PersonRoleIDFN = value; }
    }
    public string IsBlockedFN
    {
        get { return m_IsBlockedFN; }
        set { m_IsBlockedFN = value; }
    }
    public string dateTransactionFN
    {
        get { return m_dateTransactionFN; }
        set { m_dateTransactionFN = value; }
    }
    public string TransTypeIDFN
    {
        get { return m_TransTypeIDFN; }
        set { m_TransTypeIDFN = value; }
    }
    public string PublisherIDFN
    {
        get { return m_PublisherIDFN; }
        set { m_PublisherIDFN = value; }
    }
    public string CurrencyIDFN
    {
        get { return m_CurrencyIDFN; }
        set { m_CurrencyIDFN = value; }
    }
    public string InvoiceNoFN
    {
        get { return m_InvoiceNoFN; }
        set { m_InvoiceNoFN = value; }
    }
    public string InvoiceDescFN
    {
        get { return m_InvoiceDescFN; }
        set { m_InvoiceDescFN = value; }
    }
    public string dateMustReturnFN
    {
        get { return m_dateMustReturnFN; }
        set { m_dateMustReturnFN = value; }
    }

    public string dateReturnFN
    {
        get { return m_dateReturnFN; }
        set { m_dateReturnFN = value; }
    }

    public string CampusIDFromFN
    {
        get { return m_CampusIDFromFN; }
        set { m_CampusIDFromFN = value; }
    }

    public string CampusIDToFN
    {
        get { return m_CampusIDToFN; }
        set { m_CampusIDToFN = value; }
    }
    public string IsJournalFN
    {
        get { return m_IsJournalFN; }
        set { m_IsJournalFN = value; }
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
    public LibTransactionsDAL()
    {
        try
        {
            this.TableName = "LibTransactions";
            this.TransactionIDFN = m_TableName + ".TransactionID";
            this.AccesstionNoFN = m_TableName + ".AccesstionNo";
            this.BookIDFN = m_TableName + ".BookID";
            this.PersonIDFN = m_TableName + ".PersonID";
            this.PersonRoleIDFN = m_TableName + ".PersonRoleID";
            this.IsBlockedFN = m_TableName + ".IsBlocked";
            this.dateTransactionFN = m_TableName + ".dateTransaction";
            this.TransTypeIDFN = m_TableName + ".TransTypeID";

            this.InvoiceNoFN = m_TableName + ".InvoiceNo";
            this.InvoiceDescFN = m_TableName + ".InvoiceDesc";
            this.PublisherIDFN = m_TableName + ".PublisherID";
            this.CurrencyIDFN = m_TableName + ".CurrencyID";
            this.dateMustReturnFN = m_TableName + ".dateMustReturn";
            this.dateReturnFN = m_TableName + ".dateReturn";
            this.CampusIDFromFN = m_TableName + ".CampusIDFrom";
            this.CampusIDToFN = m_TableName + ".CampusIDTo";
            this.IsJournalFN = m_TableName + ".IsJournal";
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
            sSQL += TransactionIDFN;
            sSQL += " , " + AccesstionNoFN;
            sSQL += " , " + BookIDFN;
            sSQL += " , " + PersonIDFN;
            sSQL += " , " + PersonRoleIDFN;
            sSQL += " , " + IsBlockedFN;
            sSQL += " , " + dateTransactionFN;
            sSQL += " , " + TransTypeIDFN;
            sSQL += " , " + InvoiceNoFN;
            sSQL += " , " + InvoiceDescFN;
            sSQL += " , " + PublisherIDFN;
            sSQL += " , " + CurrencyIDFN;
            sSQL += " , " + dateMustReturnFN;
            sSQL += " , " + dateReturnFN;
            sSQL += " , " + CampusIDFromFN;
            sSQL += " , " + CampusIDToFN;
            sSQL += " , " + IsJournalFN;
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
            sSQL += TransactionIDFN;
            sSQL += " , " + AccesstionNoFN;
            sSQL += " , " + BookIDFN;
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
            sSQL += TransactionIDFN;
            sSQL += " , " + AccesstionNoFN;
            sSQL += " , " + BookIDFN;
            sSQL += " , " + PersonIDFN;
            sSQL += " , " + PersonRoleIDFN;
            sSQL += " , " + IsBlockedFN;
            sSQL += " , " + dateTransactionFN;
            sSQL += " , " + TransTypeIDFN;
            sSQL += " , " + InvoiceNoFN;
            sSQL += " , " + InvoiceDescFN;
            sSQL += " , " + PublisherIDFN;
            sSQL += " , " + CurrencyIDFN;
            sSQL += " , " + dateMustReturnFN;
            sSQL += " , " + dateReturnFN;
            sSQL += " , " + CampusIDFromFN;
            sSQL += " , " + CampusIDToFN;
            sSQL += " , " + IsJournalFN;
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
            sSQL += LibraryMOD.GetFieldName(TransactionIDFN) + "=@TransactionID";
            sSQL += " , " + LibraryMOD.GetFieldName(AccesstionNoFN) + "=@AccesstionNo";
            sSQL += " , " + LibraryMOD.GetFieldName(BookIDFN) + "=@BookID";
            sSQL += " , " + LibraryMOD.GetFieldName(PersonIDFN) + "=@PersonID";
            sSQL += " , " + LibraryMOD.GetFieldName(PersonRoleIDFN) + "=@PersonRoleID";
            sSQL += " , " + LibraryMOD.GetFieldName(IsBlockedFN) + "=@IsBlocked";
            sSQL += " , " + LibraryMOD.GetFieldName(dateTransactionFN) + "=@dateTransaction";
            sSQL += " , " + LibraryMOD.GetFieldName(TransTypeIDFN) + "=@TransTypeID";
            sSQL += " , " + LibraryMOD.GetFieldName(InvoiceNoFN) + "=@InvoiceNo";
            sSQL += " , " + LibraryMOD.GetFieldName(InvoiceDescFN) + "=@InvoiceDesc";
            sSQL += " , " + LibraryMOD.GetFieldName(PublisherIDFN) + "=@PublisherID";
            sSQL += " , " + LibraryMOD.GetFieldName(CurrencyIDFN) + "=@CurrencyID";
            sSQL += " , " + LibraryMOD.GetFieldName(dateMustReturnFN) + "=@dateMustReturn";
            sSQL += " , " + LibraryMOD.GetFieldName(dateReturnFN) + "=@dateReturn";
            sSQL += " , " + LibraryMOD.GetFieldName(CampusIDFromFN) + "=@CampusIDFrom";
            sSQL += " , " + LibraryMOD.GetFieldName(CampusIDToFN) + "=@CampusIDTo";
            sSQL += " , " + LibraryMOD.GetFieldName(IsJournalFN) + "=@IsJournal";
            sSQL += " , " + LibraryMOD.GetFieldName(strUserCreateFN) + "=@strUserCreate";
            sSQL += " , " + LibraryMOD.GetFieldName(dateCreateFN) + "=@dateCreate";
            sSQL += " , " + LibraryMOD.GetFieldName(strUserSaveFN) + "=@strUserSave";
            sSQL += " , " + LibraryMOD.GetFieldName(dateLastSaveFN) + "=@dateLastSave";
            sSQL += " , " + LibraryMOD.GetFieldName(strMachineFN) + "=@strMachine";
            sSQL += " , " + LibraryMOD.GetFieldName(strNUserFN) + "=@strNUser";
            sSQL += " WHERE ";
            sSQL += LibraryMOD.GetFieldName(TransactionIDFN) + "=@TransactionID";
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
            sSQL += LibraryMOD.GetFieldName(TransactionIDFN);
            sSQL += " , " + LibraryMOD.GetFieldName(AccesstionNoFN);
            sSQL += " , " + LibraryMOD.GetFieldName(BookIDFN);
            sSQL += " , " + LibraryMOD.GetFieldName(PersonIDFN);
            sSQL += " , " + LibraryMOD.GetFieldName(PersonRoleIDFN);
            sSQL += " , " + LibraryMOD.GetFieldName(IsBlockedFN);
            sSQL += " , " + LibraryMOD.GetFieldName(dateTransactionFN);
            sSQL += " , " + LibraryMOD.GetFieldName(TransTypeIDFN);
            sSQL += " , " + LibraryMOD.GetFieldName(InvoiceNoFN);
            sSQL += " , " + LibraryMOD.GetFieldName(InvoiceDescFN);
            sSQL += " , " + LibraryMOD.GetFieldName(PublisherIDFN);
            sSQL += " , " + LibraryMOD.GetFieldName(CurrencyIDFN);
            sSQL += " , " + LibraryMOD.GetFieldName(dateMustReturnFN);
            sSQL += " , " + LibraryMOD.GetFieldName(dateReturnFN);
            sSQL += " , " + LibraryMOD.GetFieldName(CampusIDFromFN);
            sSQL += " , " + LibraryMOD.GetFieldName(CampusIDToFN);
            sSQL += " , " + LibraryMOD.GetFieldName(IsJournalFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strUserCreateFN);
            sSQL += " , " + LibraryMOD.GetFieldName(dateCreateFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strUserSaveFN);
            sSQL += " , " + LibraryMOD.GetFieldName(dateLastSaveFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strMachineFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strNUserFN);
            sSQL += ")";
            sSQL += " VALUES ";
            sSQL += "( ";
            sSQL += " @TransactionID";
            sSQL += " ,@AccesstionNo";
            sSQL += " ,@BookID";
            sSQL += " ,@PersonID";
            sSQL += " ,@PersonRoleID";
            sSQL += " ,@IsBlocked";
            sSQL += " ,@dateTransaction";
            sSQL += " ,@TransTypeID";
            sSQL += " ,@InvoiceNo";
            sSQL += " ,@InvoiceDesc";
            sSQL += " ,@PublisherID";
            sSQL += " ,@CurrencyID";
            sSQL += " ,@dateMustReturn";
            sSQL += " ,@dateReturn";
            sSQL += " ,@CampusIDFrom";
            sSQL += " ,@CampusIDTo";
            sSQL += " ,@IsJournal";
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
            sSQL += LibraryMOD.GetFieldName(TransactionIDFN) + "=@TransactionID";
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
    public List<LibTransactions> GetLibTransactions(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
    {
        //' returns a list of Classes instances based on the
        //' data in the LibTransactions
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
        List<LibTransactions> results = new List<LibTransactions>();
        try
        {
            //Default Value
            LibTransactions myLibTransactions = new LibTransactions();
            if (isDeafaultIncluded)
            {
                //Change the code here
                myLibTransactions.TransactionID = 0;
                results.Add(myLibTransactions);
            }
            while (reader.Read())
            {
                myLibTransactions = new LibTransactions();
                if (reader[LibraryMOD.GetFieldName(TransactionIDFN)].Equals(DBNull.Value))
                {
                    myLibTransactions.TransactionID = 0;
                }
                else
                {
                    myLibTransactions.TransactionID = int.Parse(reader[LibraryMOD.GetFieldName(TransactionIDFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(AccesstionNoFN)].Equals(DBNull.Value))
                {
                    myLibTransactions.AccesstionNo = 0;
                }
                else
                {
                    myLibTransactions.AccesstionNo = int.Parse(reader[LibraryMOD.GetFieldName(AccesstionNoFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(BookIDFN)].Equals(DBNull.Value))
                {
                    myLibTransactions.BookID = 0;
                }
                else
                {
                    myLibTransactions.BookID = int.Parse(reader[LibraryMOD.GetFieldName(BookIDFN)].ToString());
                }
                myLibTransactions.PersonID = reader[LibraryMOD.GetFieldName(PersonIDFN)].ToString();
                if (reader[LibraryMOD.GetFieldName(PersonRoleIDFN)].Equals(DBNull.Value))
                {
                    myLibTransactions.PersonRoleID = 0;
                }
                else
                {
                    myLibTransactions.PersonRoleID = int.Parse(reader[LibraryMOD.GetFieldName(PersonRoleIDFN)].ToString());
                }
                myLibTransactions.IsBlocked = reader[LibraryMOD.GetFieldName(IsBlockedFN)].ToString();
                if (!reader[LibraryMOD.GetFieldName(dateTransactionFN)].Equals(DBNull.Value))
                {
                    myLibTransactions.dateTransaction = DateTime.Parse(reader[LibraryMOD.GetFieldName(dateTransactionFN)].ToString());
                }
                
                if (reader[LibraryMOD.GetFieldName(TransTypeIDFN)].Equals(DBNull.Value))
                {
                    myLibTransactions.TransTypeID = 0;
                }
                else
                {
                    myLibTransactions.TransTypeID = int.Parse(reader[LibraryMOD.GetFieldName(TransTypeIDFN)].ToString());
                }

                if (reader[LibraryMOD.GetFieldName(InvoiceNoFN)].Equals(DBNull.Value))
                {
                    myLibTransactions.InvoiceNo = "";
                }
                else
                {
                    myLibTransactions.InvoiceNo = reader[LibraryMOD.GetFieldName(InvoiceNoFN)].ToString();
                }
                if (reader[LibraryMOD.GetFieldName(InvoiceDescFN)].Equals(DBNull.Value))
                {
                    myLibTransactions.InvoiceDesc = "";
                }
                else
                {
                    myLibTransactions.InvoiceDesc = reader[LibraryMOD.GetFieldName(InvoiceDescFN)].ToString();
                }
                if (reader[LibraryMOD.GetFieldName(PublisherIDFN)].Equals(DBNull.Value))
                {
                    myLibTransactions.PublisherID = 0;
                }
                else
                {
                    myLibTransactions.PublisherID = int.Parse(reader[LibraryMOD.GetFieldName(PublisherIDFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(CurrencyIDFN)].Equals(DBNull.Value))
                {
                    myLibTransactions.CurrencyID = 0;
                }
                else
                {
                    myLibTransactions.CurrencyID = int.Parse(reader[LibraryMOD.GetFieldName(CurrencyIDFN)].ToString());
                }

                if (!reader[LibraryMOD.GetFieldName(dateMustReturnFN)].Equals(DBNull.Value))
                {
                    myLibTransactions.dateMustReturn = DateTime.Parse(reader[LibraryMOD.GetFieldName(dateMustReturnFN)].ToString());
                }
                if (!reader[LibraryMOD.GetFieldName(dateReturnFN)].Equals(DBNull.Value))
                {
                    myLibTransactions.dateReturn = DateTime.Parse(reader[LibraryMOD.GetFieldName(dateReturnFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(CampusIDFromFN)].Equals(DBNull.Value))
                {
                    myLibTransactions.CampusIDFrom = 0;
                }
                else
                {
                    myLibTransactions.CampusIDFrom = int.Parse(reader[LibraryMOD.GetFieldName(CampusIDFromFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(CampusIDToFN)].Equals(DBNull.Value))
                {
                    myLibTransactions.CampusIDTo = 0;
                }
                else
                {
                    myLibTransactions.CampusIDTo = int.Parse(reader[LibraryMOD.GetFieldName(CampusIDToFN)].ToString());
                }
                myLibTransactions.IsJournal = reader[LibraryMOD.GetFieldName(IsJournalFN)].ToString();
                myLibTransactions.strUserCreate = reader[LibraryMOD.GetFieldName(strUserCreateFN)].ToString();
                if (!reader[LibraryMOD.GetFieldName(dateCreateFN)].Equals(DBNull.Value))
                {
                    myLibTransactions.dateCreate = DateTime.Parse(reader[LibraryMOD.GetFieldName(dateCreateFN)].ToString());
                }
                myLibTransactions.strUserSave = reader[LibraryMOD.GetFieldName(strUserSaveFN)].ToString();
                if (!reader[LibraryMOD.GetFieldName(dateLastSaveFN)].Equals(DBNull.Value))
                {
                    myLibTransactions.dateLastSave = DateTime.Parse(reader[LibraryMOD.GetFieldName(dateLastSaveFN)].ToString());
                }
                myLibTransactions.strMachine = reader[LibraryMOD.GetFieldName(strMachineFN)].ToString();
                myLibTransactions.strNUser = reader[LibraryMOD.GetFieldName(strNUserFN)].ToString();
                results.Add(myLibTransactions);
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
    public List<LibTransactions> GetList(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
    {
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        string sSQL = GetListSQL(sCondition);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        SqlCommand Cmd = new SqlCommand(sSQL, Conn);
        Conn.Open();
        SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
        List<LibTransactions> results = new List<LibTransactions>();
        try
        {
            //Default Value
            LibTransactions myLibTransactions = new LibTransactions();
            if (isDeafaultIncluded)
            {
                //Change the code here
                myLibTransactions.TransactionID = -1;
                myLibTransactions.AccesstionNo = -1;
                results.Add(myLibTransactions);
            }
            while (reader.Read())
            {
                myLibTransactions = new LibTransactions();
                if (reader[LibraryMOD.GetFieldName(TransactionIDFN)].Equals(DBNull.Value))
                {
                    myLibTransactions.TransactionID = 0;
                }
                else
                {
                    myLibTransactions.TransactionID = int.Parse(reader[LibraryMOD.GetFieldName(TransactionIDFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(AccesstionNoFN)].Equals(DBNull.Value))
                {
                    myLibTransactions.AccesstionNo = 0;
                }
                else
                {
                    myLibTransactions.AccesstionNo = int.Parse(reader[LibraryMOD.GetFieldName(AccesstionNoFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(BookIDFN)].Equals(DBNull.Value))
                {
                    myLibTransactions.BookID = 0;
                }
                else
                {
                    myLibTransactions.BookID = int.Parse(reader[LibraryMOD.GetFieldName(BookIDFN)].ToString());
                }
                results.Add(myLibTransactions);
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
    public int UpdateLibTransactions(InitializeModule.EnumCampus Campus, int iMode, int TransactionID, int AccesstionNo, int BookID, string PersonID, int PersonRoleID, string IsBlocked, DateTime dateTransaction, int TransTypeID, string InvoiceNo, string InvoiceDesc, int PublisherID, int CurrencyID, DateTime dateMustReturn, DateTime dateReturn, int CampusIDFrom, int CampusIDTo, string IsJournal, string strUserCreate, DateTime dateCreate, string strUserSave, DateTime dateLastSave, string strMachine, string strNUser)
    {
        int iEffected = 0;
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        try
        {
            Conn.Open();
            string sql = "";
            LibTransactions theLibTransactions = new LibTransactions();
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
            Cmd.Parameters.Add(new SqlParameter("@TransactionID", TransactionID));
            Cmd.Parameters.Add(new SqlParameter("@AccesstionNo", AccesstionNo));
            Cmd.Parameters.Add(new SqlParameter("@BookID", BookID));

            if (PersonID != "-1")
                Cmd.Parameters.Add(new SqlParameter("@PersonID", PersonID));
            else
                Cmd.Parameters.AddWithValue("@PersonID", DBNull.Value);

            if (PersonRoleID != -1)
                Cmd.Parameters.Add(new SqlParameter("@PersonRoleID", PersonRoleID));
            else
                Cmd.Parameters.AddWithValue("@PersonRoleID", DBNull.Value);

            Cmd.Parameters.Add(new SqlParameter("@IsBlocked", IsBlocked));
            Cmd.Parameters.Add(new SqlParameter("@dateTransaction", dateTransaction));
            Cmd.Parameters.Add(new SqlParameter("@TransTypeID", TransTypeID));
            Cmd.Parameters.Add(new SqlParameter("@InvoiceNo", InvoiceNo));
            Cmd.Parameters.Add(new SqlParameter("@InvoiceDesc", InvoiceDesc));
            Cmd.Parameters.Add(new SqlParameter("@PublisherID", PublisherID));
            Cmd.Parameters.Add(new SqlParameter("@CurrencyID", CurrencyID));

            Cmd.Parameters.Add(new SqlParameter("@dateMustReturn", dateMustReturn));
            Cmd.Parameters.Add(new SqlParameter("@dateReturn", dateReturn));

            if (CampusIDFrom != -1)
                Cmd.Parameters.Add(new SqlParameter("@CampusIDFrom", CampusIDFrom));
            else
                Cmd.Parameters.AddWithValue("@CampusIDFrom", DBNull.Value);

            if (CampusIDTo != -1)
                Cmd.Parameters.Add(new SqlParameter("@CampusIDTo", CampusIDTo));
            else
                Cmd.Parameters.AddWithValue("@CampusIDTo", DBNull.Value);

            Cmd.Parameters.Add(new SqlParameter("@IsJournal", IsJournal));
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

    public bool IsInvoiceHeaderExist(int iTransID)
    {
        Connection_StringCLS myConnection_String;
        SqlConnection Conn;
        SqlCommand cmd;
        object Result = null;
        try
        {
            string strsql = "SELECT TransactionID";
            strsql += " FROM " + m_TableName ;
            strsql += " WHERE TransactionID=" + iTransID;
               
            myConnection_String = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew);
            Conn = new SqlConnection(myConnection_String.Conn_string);

            Conn.Open();
            cmd = new SqlCommand(strsql, Conn);
            Result = cmd.ExecuteScalar();
            Conn.Close();
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
            //divMsg.InnerText = ex.Message;
        }
        finally { }
        if (Result != null)
            return true;
        else
            return false;
    }

    public int DeleteLibTransactions(InitializeModule.EnumCampus Campus, string TransactionID)
    {
        int iEffected = 0;
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        try
        {
            string sSQL = GetDeleteCommand();
            //sSQL += sCondition;
            SqlCommand Cmd = new SqlCommand(sSQL, Conn);
            Cmd.Parameters.Add(new SqlParameter("@TransactionID", TransactionID));
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
        DataTable dt = new DataTable("LibTransactions");
        DataView dv = new DataView();
        List<LibTransactions> myLibTransactionss = new List<LibTransactions>();
        try
        {
            myLibTransactionss = GetLibTransactions(InitializeModule.EnumCampus.ECTNew, sCondition, false);
            DataColumn col0 = new DataColumn("TransactionID", Type.GetType("int"));
            dt.Columns.Add(col0);
            dt.Constraints.Add(new UniqueConstraint(col0));

            DataRow dr;
            for (int i = 0; i < myLibTransactionss.Count; i++)
            {
                dr = dt.NewRow();
                dr[1] = myLibTransactionss[i].TransactionID;
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
            myLibTransactionss.Clear();
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
            sSQL += TransactionIDFN;
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
public class LibTransactionsCls : LibTransactionsDAL
{
    #region "Decleration"
    private int m_lngCurRow = 0;
    public SqlDataAdapter daLibTransactions;
    private DataSet m_dsLibTransactions;
    public DataRow LibTransactionsDataRow;
    #endregion
    #region "Puplic Properties"
    public DataSet dsLibTransactions
    {
        get { return m_dsLibTransactions; }
        set { m_dsLibTransactions = value; }
    }
    //-----------------------------------------------------
    public int lngCurRow
    {
        get { return m_lngCurRow; }
        set { m_lngCurRow = value; }
    }
    #endregion
    public LibTransactionsCls()
    {
        try
        {
            dsLibTransactions = new DataSet();

        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
    }
    //-------Get DataAdapter  -----------------------------
    #region "DataAdapter"
    public virtual SqlDataAdapter GetLibTransactionsDataAdapter(string sCondition, SqlConnection con)
    {
        string sSQL = "";
        try
        {
            sSQL = GetSQL();
            sSQL += " " + sCondition;
            //-----------------------------------------
            daLibTransactions = new SqlDataAdapter(sSQL, con);
            // Create command builder. This line automatically generates the update commands for you, so you don't
            // have to provide or create your own.
            SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daLibTransactions);
            //Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
            // key + unique key information to be retrieved unless AddWithKey is specified.
            daLibTransactions.MissingSchemaAction = MissingSchemaAction.AddWithKey;
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return daLibTransactions;
    }
    public virtual SqlDataAdapter GetLibTransactionsDataAdapter(SqlConnection con)
    {
        try
        {
            daLibTransactions = new SqlDataAdapter();
            //''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
            //'' key + unique key information to be retrieved unless AddWithKey is specified.
            daLibTransactions.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            //-----------------------------------------
            SqlParameter Parmeter = default(SqlParameter);
            //[SELECT COMMAND]
            SqlCommand cmdLibTransactions;
            cmdLibTransactions = new SqlCommand(GetSelectCommand(), con);
            //'cmdRolePermission.Parameters.Add("@TransactionID", SqlDbType.Int, 4, "TransactionID" );
            daLibTransactions.SelectCommand = cmdLibTransactions;
            //'Add Handlers
            //'RowUpdating,RowUpdated
            AddDAEventHandler();
            //'[UPDATE COMMAND].
            cmdLibTransactions = new SqlCommand(GetUpdateCommand(), con);
            //'Delete PK Parameteres from here. b/c its declared below
            cmdLibTransactions.Parameters.Add("@TransactionID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(TransactionIDFN));
            cmdLibTransactions.Parameters.Add("@AccesstionNo", SqlDbType.Int, 4, LibraryMOD.GetFieldName(AccesstionNoFN));
            cmdLibTransactions.Parameters.Add("@BookID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(BookIDFN));
            cmdLibTransactions.Parameters.Add("@PersonID", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(PersonIDFN));
            cmdLibTransactions.Parameters.Add("@PersonRoleID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(PersonRoleIDFN));
            cmdLibTransactions.Parameters.Add("@IsBlocked", SqlDbType.Bit, 1, LibraryMOD.GetFieldName(IsBlockedFN));
            cmdLibTransactions.Parameters.Add("@dateTransaction", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dateTransactionFN));
            cmdLibTransactions.Parameters.Add("@TransTypeID", SqlDbType.Int, 2, LibraryMOD.GetFieldName(TransTypeIDFN));
            cmdLibTransactions.Parameters.Add("@dateMustReturn", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dateMustReturnFN));
            cmdLibTransactions.Parameters.Add("@dateReturn", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dateReturnFN));
            cmdLibTransactions.Parameters.Add("@CampusIDFrom", SqlDbType.Int, 2, LibraryMOD.GetFieldName(CampusIDFromFN));
            cmdLibTransactions.Parameters.Add("@CampusIDTo", SqlDbType.Int, 2, LibraryMOD.GetFieldName(CampusIDToFN));
            cmdLibTransactions.Parameters.Add("@IsJournal", SqlDbType.Bit, 1, LibraryMOD.GetFieldName(IsJournalFN));
            cmdLibTransactions.Parameters.Add("@strUserCreate", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strUserCreateFN));
            cmdLibTransactions.Parameters.Add("@dateCreate", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dateCreateFN));
            cmdLibTransactions.Parameters.Add("@strUserSave", SqlDbType.Char, 10, LibraryMOD.GetFieldName(strUserSaveFN));
            cmdLibTransactions.Parameters.Add("@dateLastSave", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dateLastSaveFN));
            cmdLibTransactions.Parameters.Add("@strMachine", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strMachineFN));
            cmdLibTransactions.Parameters.Add("@strNUser", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strNUserFN));


            Parmeter = cmdLibTransactions.Parameters.Add("@TransactionID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(TransactionIDFN));
            Parmeter.SourceVersion = DataRowVersion.Original;
            //'Its should be none for batch updating
            //'UpdateCommand, InsertCommand, and DeleteCommand 
            //'should be set to None or OutputParameters
            daLibTransactions.UpdateCommand = cmdLibTransactions;
            daLibTransactions.UpdateCommand.UpdatedRowSource = UpdateRowSource.None;
            //'-------------------------------------------------------------------------
            //'/INSERT COMMAND
            cmdLibTransactions = new SqlCommand(GetInsertCommand(), con);
            cmdLibTransactions.Parameters.Add("@TransactionID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(TransactionIDFN));
            cmdLibTransactions.Parameters.Add("@AccesstionNo", SqlDbType.Int, 4, LibraryMOD.GetFieldName(AccesstionNoFN));
            cmdLibTransactions.Parameters.Add("@BookID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(BookIDFN));
            cmdLibTransactions.Parameters.Add("@PersonID", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(PersonIDFN));
            cmdLibTransactions.Parameters.Add("@PersonRoleID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(PersonRoleIDFN));
            cmdLibTransactions.Parameters.Add("@IsBlocked", SqlDbType.Bit, 1, LibraryMOD.GetFieldName(IsBlockedFN));
            cmdLibTransactions.Parameters.Add("@dateTransaction", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dateTransactionFN));
            cmdLibTransactions.Parameters.Add("@TransTypeID", SqlDbType.Int, 2, LibraryMOD.GetFieldName(TransTypeIDFN));
            cmdLibTransactions.Parameters.Add("@dateMustReturn", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dateMustReturnFN));
            cmdLibTransactions.Parameters.Add("@dateReturn", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dateReturnFN));
            cmdLibTransactions.Parameters.Add("@CampusIDFrom", SqlDbType.Int, 2, LibraryMOD.GetFieldName(CampusIDFromFN));
            cmdLibTransactions.Parameters.Add("@CampusIDTo", SqlDbType.Int, 2, LibraryMOD.GetFieldName(CampusIDToFN));
            cmdLibTransactions.Parameters.Add("@IsJournal", SqlDbType.Bit, 1, LibraryMOD.GetFieldName(IsJournalFN));
            cmdLibTransactions.Parameters.Add("@strUserCreate", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strUserCreateFN));
            cmdLibTransactions.Parameters.Add("@dateCreate", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dateCreateFN));
            cmdLibTransactions.Parameters.Add("@strUserSave", SqlDbType.Char, 10, LibraryMOD.GetFieldName(strUserSaveFN));
            cmdLibTransactions.Parameters.Add("@dateLastSave", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dateLastSaveFN));
            cmdLibTransactions.Parameters.Add("@strMachine", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strMachineFN));
            cmdLibTransactions.Parameters.Add("@strNUser", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strNUserFN));
            Parmeter.SourceVersion = DataRowVersion.Current;
            daLibTransactions.InsertCommand = cmdLibTransactions;
            daLibTransactions.InsertCommand.UpdatedRowSource = UpdateRowSource.None;
            //'------------------------
            //'/DELETE COMMAND
            cmdLibTransactions = new SqlCommand(GetDeleteCommand(), con);
            Parmeter = cmdLibTransactions.Parameters.Add("@TransactionID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(TransactionIDFN));
            Parmeter.SourceVersion = DataRowVersion.Original;
            daLibTransactions.DeleteCommand = cmdLibTransactions;
            daLibTransactions.DeleteCommand.UpdatedRowSource = UpdateRowSource.None;
            //'Batch Size
            //'Set the batch size.
            daLibTransactions.UpdateBatchSize = ECTGlobalDll.InitializeModule.BATCH_SIZE;
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return daLibTransactions;
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
                    dr = dsLibTransactions.Tables[TableName].NewRow();
                    dr[LibraryMOD.GetFieldName(TransactionIDFN)] = TransactionID;
                    dr[LibraryMOD.GetFieldName(AccesstionNoFN)] = AccesstionNo;
                    dr[LibraryMOD.GetFieldName(BookIDFN)] = BookID;
                    dr[LibraryMOD.GetFieldName(PersonIDFN)] = PersonID;
                    dr[LibraryMOD.GetFieldName(PersonRoleIDFN)] = PersonRoleID;
                    dr[LibraryMOD.GetFieldName(IsBlockedFN)] = IsBlocked;
                    dr[LibraryMOD.GetFieldName(dateTransactionFN)] = dateTransaction;
                    dr[LibraryMOD.GetFieldName(TransTypeIDFN)] = TransTypeID;
                    dr[LibraryMOD.GetFieldName(dateMustReturnFN)] = dateMustReturn;
                    dr[LibraryMOD.GetFieldName(dateReturnFN)] = dateReturn;
                    dr[LibraryMOD.GetFieldName(CampusIDFromFN)] = CampusIDFrom;
                    dr[LibraryMOD.GetFieldName(CampusIDToFN)] = CampusIDTo;
                    dr[LibraryMOD.GetFieldName(IsJournalFN)] = IsJournal;
                    dr[LibraryMOD.GetFieldName(strUserCreateFN)] = strUserCreate;
                    dr[LibraryMOD.GetFieldName(dateCreateFN)] = dateCreate;
                    dr[LibraryMOD.GetFieldName(strUserSaveFN)] = strUserSave;
                    dr[LibraryMOD.GetFieldName(dateLastSaveFN)] = dateLastSave;
                    dr[LibraryMOD.GetFieldName(strMachineFN)] = strMachine;
                    dr[LibraryMOD.GetFieldName(strNUserFN)] = strNUser;
                    dsLibTransactions.Tables[TableName].Rows.Add(dr);
                    break;
                case (int)ECTGlobalDll.InitializeModule.enumModes.EditMode:
                    DataRow[] drAry = null;
                    drAry = dsLibTransactions.Tables[TableName].Select(LibraryMOD.GetFieldName(TransactionIDFN) + "=" + TransactionID);
                    //'its return array of rows and we can access the first by index 0
                    drAry[0][LibraryMOD.GetFieldName(TransactionIDFN)] = TransactionID;
                    drAry[0][LibraryMOD.GetFieldName(AccesstionNoFN)] = AccesstionNo;
                    drAry[0][LibraryMOD.GetFieldName(BookIDFN)] = BookID;
                    drAry[0][LibraryMOD.GetFieldName(PersonIDFN)] = PersonID;
                    drAry[0][LibraryMOD.GetFieldName(PersonRoleIDFN)] = PersonRoleID;
                    drAry[0][LibraryMOD.GetFieldName(IsBlockedFN)] = IsBlocked;
                    drAry[0][LibraryMOD.GetFieldName(dateTransactionFN)] = dateTransaction;
                    drAry[0][LibraryMOD.GetFieldName(TransTypeIDFN)] = TransTypeID;
                    drAry[0][LibraryMOD.GetFieldName(dateMustReturnFN)] = dateMustReturn;
                    drAry[0][LibraryMOD.GetFieldName(dateReturnFN)] = dateReturn;
                    drAry[0][LibraryMOD.GetFieldName(CampusIDFromFN)] = CampusIDFrom;
                    drAry[0][LibraryMOD.GetFieldName(CampusIDToFN)] = CampusIDTo;
                    drAry[0][LibraryMOD.GetFieldName(IsJournalFN)] = IsJournal;
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
    public int CommitLibTransactions()
    {
        //CommitLibTransactions= ECTGlobalDll.InitializeModule.FAIL_RET;
        try
        {
            //'' Update Database with SqlDataAdapter
            daLibTransactions.Update(dsLibTransactions, TableName);
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
            FindInMultiPKey(TransactionID);
            if ((LibTransactionsDataRow != null))
            {
                LibTransactionsDataRow.Delete();
                CommitLibTransactions();
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
            if (LibTransactionsDataRow[LibraryMOD.GetFieldName(TransactionIDFN)] == System.DBNull.Value)
            {
                TransactionID = 0;
            }
            else
            {
                TransactionID = (int)LibTransactionsDataRow[LibraryMOD.GetFieldName(TransactionIDFN)];
            }
            if (LibTransactionsDataRow[LibraryMOD.GetFieldName(AccesstionNoFN)] == System.DBNull.Value)
            {
                AccesstionNo = 0;
            }
            else
            {
                AccesstionNo = (int)LibTransactionsDataRow[LibraryMOD.GetFieldName(AccesstionNoFN)];
            }
            if (LibTransactionsDataRow[LibraryMOD.GetFieldName(BookIDFN)] == System.DBNull.Value)
            {
                BookID = 0;
            }
            else
            {
                BookID = (int)LibTransactionsDataRow[LibraryMOD.GetFieldName(BookIDFN)];
            }
            if (LibTransactionsDataRow[LibraryMOD.GetFieldName(PersonIDFN)] == System.DBNull.Value)
            {
                PersonID = "";
            }
            else
            {
                PersonID = (string)LibTransactionsDataRow[LibraryMOD.GetFieldName(PersonIDFN)];
            }
            if (LibTransactionsDataRow[LibraryMOD.GetFieldName(PersonRoleIDFN)] == System.DBNull.Value)
            {
                PersonRoleID = 0;
            }
            else
            {
                PersonRoleID = (int)LibTransactionsDataRow[LibraryMOD.GetFieldName(PersonRoleIDFN)];
            }
            if (LibTransactionsDataRow[LibraryMOD.GetFieldName(IsBlockedFN)] == System.DBNull.Value)
            {
                IsBlocked = "";
            }
            else
            {
                IsBlocked = (string)LibTransactionsDataRow[LibraryMOD.GetFieldName(IsBlockedFN)];
            }
            if (LibTransactionsDataRow[LibraryMOD.GetFieldName(dateTransactionFN)] == System.DBNull.Value)
            {
            }
            else
            {
                dateTransaction = (DateTime)LibTransactionsDataRow[LibraryMOD.GetFieldName(dateTransactionFN)];
            }
            if (LibTransactionsDataRow[LibraryMOD.GetFieldName(TransTypeIDFN)] == System.DBNull.Value)
            {
                TransTypeID = 0;
            }
            else
            {
                TransTypeID = (int)LibTransactionsDataRow[LibraryMOD.GetFieldName(TransTypeIDFN)];
            }
            if (LibTransactionsDataRow[LibraryMOD.GetFieldName(PublisherIDFN )] == System.DBNull.Value)
            {
                PublisherID = 0;
            }
            else
            {
                PublisherID = (int)LibTransactionsDataRow[LibraryMOD.GetFieldName(PublisherIDFN)];
            }
            if (LibTransactionsDataRow[LibraryMOD.GetFieldName(CurrencyIDFN)] == System.DBNull.Value)
            {
                CurrencyID = 0;
            }
            else
            {
                CurrencyID = (int)LibTransactionsDataRow[LibraryMOD.GetFieldName(CurrencyIDFN)];
            }
            
            if (LibTransactionsDataRow[LibraryMOD.GetFieldName(InvoiceNoFN)] == System.DBNull.Value)
            {
                InvoiceNo = "";
            }
            else
            {
                InvoiceNo = LibTransactionsDataRow[LibraryMOD.GetFieldName(InvoiceNoFN)].ToString ();
            }
            if (LibTransactionsDataRow[LibraryMOD.GetFieldName(InvoiceDescFN)] == System.DBNull.Value)
            {
                InvoiceDesc = "";
            }
            else
            {
                InvoiceDesc = LibTransactionsDataRow[LibraryMOD.GetFieldName(InvoiceDescFN)].ToString();
            }

            if (LibTransactionsDataRow[LibraryMOD.GetFieldName(dateMustReturnFN)] == System.DBNull.Value)
            {
            }
            else
            {
                dateMustReturn = (DateTime)LibTransactionsDataRow[LibraryMOD.GetFieldName(dateMustReturnFN)];
            }
            if (LibTransactionsDataRow[LibraryMOD.GetFieldName(dateReturnFN)] == System.DBNull.Value)
            {
            }
            else
            {
                dateReturn = (DateTime)LibTransactionsDataRow[LibraryMOD.GetFieldName(dateReturnFN)];
            }
            if (LibTransactionsDataRow[LibraryMOD.GetFieldName(CampusIDFromFN)] == System.DBNull.Value)
            {
                CampusIDFrom = 0;
            }
            else
            {
                CampusIDFrom = (int)LibTransactionsDataRow[LibraryMOD.GetFieldName(CampusIDFromFN)];
            }
            if (LibTransactionsDataRow[LibraryMOD.GetFieldName(CampusIDToFN)] == System.DBNull.Value)
            {
                CampusIDTo = 0;
            }
            else
            {
                CampusIDTo = (int)LibTransactionsDataRow[LibraryMOD.GetFieldName(CampusIDToFN)];
            }
            if (LibTransactionsDataRow[LibraryMOD.GetFieldName(IsJournalFN)] == System.DBNull.Value)
            {
                IsJournal = "";
            }
            else
            {
                IsJournal = (string)LibTransactionsDataRow[LibraryMOD.GetFieldName(IsJournalFN)];
            }
            if (LibTransactionsDataRow[LibraryMOD.GetFieldName(strUserCreateFN)] == System.DBNull.Value)
            {
                strUserCreate = "";
            }
            else
            {
                strUserCreate = (string)LibTransactionsDataRow[LibraryMOD.GetFieldName(strUserCreateFN)];
            }
            if (LibTransactionsDataRow[LibraryMOD.GetFieldName(dateCreateFN)] == System.DBNull.Value)
            {
            }
            else
            {
                dateCreate = (DateTime)LibTransactionsDataRow[LibraryMOD.GetFieldName(dateCreateFN)];
            }
            if (LibTransactionsDataRow[LibraryMOD.GetFieldName(strUserSaveFN)] == System.DBNull.Value)
            {
                strUserSave = "";
            }
            else
            {
                strUserSave = (string)LibTransactionsDataRow[LibraryMOD.GetFieldName(strUserSaveFN)];
            }
            if (LibTransactionsDataRow[LibraryMOD.GetFieldName(dateLastSaveFN)] == System.DBNull.Value)
            {
            }
            else
            {
                dateLastSave = (DateTime)LibTransactionsDataRow[LibraryMOD.GetFieldName(dateLastSaveFN)];
            }
            if (LibTransactionsDataRow[LibraryMOD.GetFieldName(strMachineFN)] == System.DBNull.Value)
            {
                strMachine = "";
            }
            else
            {
                strMachine = (string)LibTransactionsDataRow[LibraryMOD.GetFieldName(strMachineFN)];
            }
            if (LibTransactionsDataRow[LibraryMOD.GetFieldName(strNUserFN)] == System.DBNull.Value)
            {
                strNUser = "";
            }
            else
            {
                strNUser = (string)LibTransactionsDataRow[LibraryMOD.GetFieldName(strNUserFN)];
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
    public int FindInMultiPKey(int PKTransactionID)
    {
        //FindInMultiPKey= ECTGlobalDll.InitializeModule.FAIL_RET;
        try
        {
            //' Create an array for the key values to find.
            object[] findTheseVals = new object[1];
            //' Set the values of the keys to find.
            findTheseVals[0] = PKTransactionID;
            LibTransactionsDataRow = dsLibTransactions.Tables[TableName].Rows.Find(findTheseVals);
            if ((LibTransactionsDataRow != null))
            {
                lngCurRow = dsLibTransactions.Tables[TableName].Rows.IndexOf(LibTransactionsDataRow);
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
            lngCurRow = dsLibTransactions.Tables[TableName].Rows.Count - 1; //'Zero based index
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
            lngCurRow = Math.Min(lngCurRow + 1, dsLibTransactions.Tables[TableName].Rows.Count - 1);
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
            if (lngCurRow >= 0 & dsLibTransactions.Tables[TableName].Rows.Count > 0)
            {
                LibTransactionsDataRow = dsLibTransactions.Tables[TableName].Rows[lngCurRow];
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
            daLibTransactions.RowUpdating += new SqlRowUpdatingEventHandler(OnRowUpdating);
            daLibTransactions.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
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
            daLibTransactions.RowUpdating -= new SqlRowUpdatingEventHandler(OnRowUpdating);
            daLibTransactions.RowUpdated -= new SqlRowUpdatedEventHandler(OnRowUpdated);
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
