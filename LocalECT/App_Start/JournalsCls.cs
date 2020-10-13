using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections.Generic;
using ECTGlobalDll;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
public class Journals
{
    //Creation Date: 19/10/2010 2:48:56 PM
    //Programmer Name : Hazem
    //-----Decleration --------------
    #region "Decleration"
    private int m_iJournal;
    private string m_strSerialNumber;
    private DateTime m_dDeliveryDate;
    private DateTime m_dEntryDate;
    private int m_iSupplier;
    private string m_strSubscriptionNo;
    private double m_cPrice;
    private string m_strNote;
    private string m_strTitle;
    private int m_iVolume;
    private string m_strIssueNo;
    private int m_iFrequency;
    private DateTime m_dPublicationDate;
    private int m_iPublisher;
    private string m_sISSN;
    private DateTime m_dStartingDate;
    private DateTime m_dExpiryDate;
    private string m_strUserCreate;
    private DateTime m_dateCreate;
    private string m_strUserSave;
    private DateTime m_dateLastSave;
    private string m_strMachine;
    private string m_strNUser;
    #endregion
    #region "Puplic Properties"
    //'-----------------------------------------------------
    public int iJournal
    {
        get { return m_iJournal; }
        set { m_iJournal = value; }
    }
    public string strSerialNumber
    {
        get { return m_strSerialNumber; }
        set { m_strSerialNumber = value; }
    }
    public DateTime dDeliveryDate
    {
        get { return m_dDeliveryDate; }
        set { m_dDeliveryDate = value; }
    }
    public DateTime dEntryDate
    {
        get { return m_dEntryDate; }
        set { m_dEntryDate = value; }
    }
    public int iSupplier
    {
        get { return m_iSupplier; }
        set { m_iSupplier = value; }
    }
    public string strSubscriptionNo
    {
        get { return m_strSubscriptionNo; }
        set { m_strSubscriptionNo = value; }
    }
    public double cPrice
    {
        get { return m_cPrice; }
        set { m_cPrice = value; }
    }
    public string strNote
    {
        get { return m_strNote; }
        set { m_strNote = value; }
    }
    public string strTitle
    {
        get { return m_strTitle; }
        set { m_strTitle = value; }
    }
    public int iVolume
    {
        get { return m_iVolume; }
        set { m_iVolume = value; }
    }
    public string strIssueNo
    {
        get { return m_strIssueNo; }
        set { m_strIssueNo = value; }
    }
    public int iFrequency
    {
        get { return m_iFrequency; }
        set { m_iFrequency = value; }
    }
    public DateTime dPublicationDate
    {
        get { return m_dPublicationDate; }
        set { m_dPublicationDate = value; }
    }
    public int iPublisher
    {
        get { return m_iPublisher; }
        set { m_iPublisher = value; }
    }
    public string sISSN
    {
        get { return m_sISSN; }
        set { m_sISSN = value; }
    }
    public DateTime dStartingDate
    {
        get { return m_dStartingDate; }
        set { m_dStartingDate = value; }
    }
    public DateTime dExpiryDate
    {
        get { return m_dExpiryDate; }
        set { m_dExpiryDate = value; }
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
    public Journals()
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
public class JournalsDAL : Journals
{
    #region "Decleration"
    private string m_TableName;
    private string m_iJournalFN;
    private string m_strSerialNumberFN;
    private string m_dDeliveryDateFN;
    private string m_dEntryDateFN;
    private string m_iSupplierFN;
    private string m_strSubscriptionNoFN;
    private string m_cPriceFN;
    private string m_strNoteFN;
    private string m_strTitleFN;
    private string m_iVolumeFN;
    private string m_strIssueNoFN;
    private string m_iFrequencyFN;
    private string m_dPublicationDateFN;
    private string m_iPublisherFN;
    private string m_sISSNFN;
    private string m_dStartingDateFN;
    private string m_dExpiryDateFN;
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
    public string iJournalFN
    {
        get { return m_iJournalFN; }
        set { m_iJournalFN = value; }
    }
    public string strSerialNumberFN
    {
        get { return m_strSerialNumberFN; }
        set { m_strSerialNumberFN = value; }
    }
    public string dDeliveryDateFN
    {
        get { return m_dDeliveryDateFN; }
        set { m_dDeliveryDateFN = value; }
    }
    public string dEntryDateFN
    {
        get { return m_dEntryDateFN; }
        set { m_dEntryDateFN = value; }
    }
    public string iSupplierFN
    {
        get { return m_iSupplierFN; }
        set { m_iSupplierFN = value; }
    }
    public string strSubscriptionNoFN
    {
        get { return m_strSubscriptionNoFN; }
        set { m_strSubscriptionNoFN = value; }
    }
    public string cPriceFN
    {
        get { return m_cPriceFN; }
        set { m_cPriceFN = value; }
    }
    public string strNoteFN
    {
        get { return m_strNoteFN; }
        set { m_strNoteFN = value; }
    }
    public string strTitleFN
    {
        get { return m_strTitleFN; }
        set { m_strTitleFN = value; }
    }
    public string iVolumeFN
    {
        get { return m_iVolumeFN; }
        set { m_iVolumeFN = value; }
    }
    public string strIssueNoFN
    {
        get { return m_strIssueNoFN; }
        set { m_strIssueNoFN = value; }
    }
    public string iFrequencyFN
    {
        get { return m_iFrequencyFN; }
        set { m_iFrequencyFN = value; }
    }
    public string dPublicationDateFN
    {
        get { return m_dPublicationDateFN; }
        set { m_dPublicationDateFN = value; }
    }
    public string iPublisherFN
    {
        get { return m_iPublisherFN; }
        set { m_iPublisherFN = value; }
    }
    public string sISSNFN
    {
        get { return m_sISSNFN; }
        set { m_sISSNFN = value; }
    }
    public string dStartingDateFN
    {
        get { return m_dStartingDateFN; }
        set { m_dStartingDateFN = value; }
    }
    public string dExpiryDateFN
    {
        get { return m_dExpiryDateFN; }
        set { m_dExpiryDateFN = value; }
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
    public JournalsDAL()
    {
        try
        {
            this.TableName = "Lib_Journals";
            this.iJournalFN = m_TableName + ".iJournal";
            this.strSerialNumberFN = m_TableName + ".strSerialNumber";
            this.dDeliveryDateFN = m_TableName + ".dDeliveryDate";
            this.dEntryDateFN = m_TableName + ".dEntryDate";
            this.iSupplierFN = m_TableName + ".iSupplier";
            this.strSubscriptionNoFN = m_TableName + ".strSubscriptionNo";
            this.cPriceFN = m_TableName + ".cPrice";
            this.strNoteFN = m_TableName + ".strNote";
            this.strTitleFN = m_TableName + ".strTitle";
            this.iVolumeFN = m_TableName + ".iVolume";
            this.strIssueNoFN = m_TableName + ".strIssueNo";
            this.iFrequencyFN = m_TableName + ".iFrequency";
            this.dPublicationDateFN = m_TableName + ".dPublicationDate";
            this.iPublisherFN = m_TableName + ".iPublisher";
            this.sISSNFN = m_TableName + ".sISSN";
            this.dStartingDateFN = m_TableName + ".dStartingDate";
            this.dExpiryDateFN = m_TableName + ".dExpiryDate";
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
            sSQL += iJournalFN;
            sSQL += " , " + strSerialNumberFN;
            sSQL += " , " + dDeliveryDateFN;
            sSQL += " , " + dEntryDateFN;
            sSQL += " , " + iSupplierFN;
            sSQL += " , " + strSubscriptionNoFN;
            sSQL += " , " + cPriceFN;
            sSQL += " , " + strNoteFN;
            sSQL += " , " + strTitleFN;
            sSQL += " , " + iVolumeFN;
            sSQL += " , " + strIssueNoFN;
            sSQL += " , " + iFrequencyFN;
            sSQL += " , " + dPublicationDateFN;
            sSQL += " , " + iPublisherFN;
            sSQL += " , " + sISSNFN;
            sSQL += " , " + dStartingDateFN;
            sSQL += " , " + dExpiryDateFN;
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
    //-----Get GetSelectCommand Function -----------------------
    public string GetSelectCommand()
    {
        string sSQL = "";
        try
        {
            sSQL = "SELECT ";
            sSQL += iJournalFN;
            sSQL += " , " + strSerialNumberFN;
            sSQL += " , " + dDeliveryDateFN;
            sSQL += " , " + dEntryDateFN;
            sSQL += " , " + iSupplierFN;
            sSQL += " , " + strSubscriptionNoFN;
            sSQL += " , " + cPriceFN;
            sSQL += " , " + strNoteFN;
            sSQL += " , " + strTitleFN;
            sSQL += " , " + iVolumeFN;
            sSQL += " , " + strIssueNoFN;
            sSQL += " , " + iFrequencyFN;
            sSQL += " , " + dPublicationDateFN;
            sSQL += " , " + iPublisherFN;
            sSQL += " , " + sISSNFN;
            sSQL += " , " + dStartingDateFN;
            sSQL += " , " + dExpiryDateFN;
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
            sSQL += LibraryMOD.GetFieldName(iJournalFN) + "=@iJournal";
            sSQL += " , " + LibraryMOD.GetFieldName(strSerialNumberFN) + "=@strSerialNumber";
            sSQL += " , " + LibraryMOD.GetFieldName(dDeliveryDateFN) + "=@dDeliveryDate";
            sSQL += " , " + LibraryMOD.GetFieldName(dEntryDateFN) + "=@dEntryDate";
            sSQL += " , " + LibraryMOD.GetFieldName(iSupplierFN) + "=@iSupplier";
            sSQL += " , " + LibraryMOD.GetFieldName(strSubscriptionNoFN) + "=@strSubscriptionNo";
            sSQL += " , " + LibraryMOD.GetFieldName(cPriceFN) + "=@cPrice";
            sSQL += " , " + LibraryMOD.GetFieldName(strNoteFN) + "=@strNote";
            sSQL += " , " + LibraryMOD.GetFieldName(strTitleFN) + "=@strTitle";
            sSQL += " , " + LibraryMOD.GetFieldName(iVolumeFN) + "=@iVolume";
            sSQL += " , " + LibraryMOD.GetFieldName(strIssueNoFN) + "=@strIssueNo";
            sSQL += " , " + LibraryMOD.GetFieldName(iFrequencyFN) + "=@iFrequency";
            sSQL += " , " + LibraryMOD.GetFieldName(dPublicationDateFN) + "=@dPublicationDate";
            sSQL += " , " + LibraryMOD.GetFieldName(iPublisherFN) + "=@iPublisher";
            sSQL += " , " + LibraryMOD.GetFieldName(sISSNFN) + "=@sISSN";
            sSQL += " , " + LibraryMOD.GetFieldName(dStartingDateFN) + "=@dStartingDate";
            sSQL += " , " + LibraryMOD.GetFieldName(dExpiryDateFN) + "=@dExpiryDate";
            sSQL += " , " + LibraryMOD.GetFieldName(strUserCreateFN) + "=@strUserCreate";
            sSQL += " , " + LibraryMOD.GetFieldName(dateCreateFN) + "=@dateCreate";
            sSQL += " , " + LibraryMOD.GetFieldName(strUserSaveFN) + "=@strUserSave";
            sSQL += " , " + LibraryMOD.GetFieldName(dateLastSaveFN) + "=@dateLastSave";
            sSQL += " , " + LibraryMOD.GetFieldName(strMachineFN) + "=@strMachine";
            sSQL += " , " + LibraryMOD.GetFieldName(strNUserFN) + "=@strNUser";
            sSQL += " WHERE ";
            sSQL += LibraryMOD.GetFieldName(iJournalFN) + "=@iJournal";
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
            sSQL += LibraryMOD.GetFieldName(iJournalFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strSerialNumberFN);
            sSQL += " , " + LibraryMOD.GetFieldName(dDeliveryDateFN);
            sSQL += " , " + LibraryMOD.GetFieldName(dEntryDateFN);
            sSQL += " , " + LibraryMOD.GetFieldName(iSupplierFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strSubscriptionNoFN);
            sSQL += " , " + LibraryMOD.GetFieldName(cPriceFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strNoteFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strTitleFN);
            sSQL += " , " + LibraryMOD.GetFieldName(iVolumeFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strIssueNoFN);
            sSQL += " , " + LibraryMOD.GetFieldName(iFrequencyFN);
            sSQL += " , " + LibraryMOD.GetFieldName(dPublicationDateFN);
            sSQL += " , " + LibraryMOD.GetFieldName(iPublisherFN);
            sSQL += " , " + LibraryMOD.GetFieldName(sISSNFN);
            sSQL += " , " + LibraryMOD.GetFieldName(dStartingDateFN);
            sSQL += " , " + LibraryMOD.GetFieldName(dExpiryDateFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strUserCreateFN);
            sSQL += " , " + LibraryMOD.GetFieldName(dateCreateFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strUserSaveFN);
            sSQL += " , " + LibraryMOD.GetFieldName(dateLastSaveFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strMachineFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strNUserFN);
            sSQL += ")";
            sSQL += " VALUES ";
            sSQL += "( ";
            sSQL += " @iJournal";
            sSQL += " ,@strSerialNumber";
            sSQL += " ,@dDeliveryDate";
            sSQL += " ,@dEntryDate";
            sSQL += " ,@iSupplier";
            sSQL += " ,@strSubscriptionNo";
            sSQL += " ,@cPrice";
            sSQL += " ,@strNote";
            sSQL += " ,@strTitle";
            sSQL += " ,@iVolume";
            sSQL += " ,@strIssueNo";
            sSQL += " ,@iFrequency";
            sSQL += " ,@dPublicationDate";
            sSQL += " ,@iPublisher";
            sSQL += " ,@sISSN";
            sSQL += " ,@dStartingDate";
            sSQL += " ,@dExpiryDate";
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
            sSQL += LibraryMOD.GetFieldName(iJournalFN) + "=@iJournal";
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
    public List<Journals> GetJournals(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
    {
        //' returns a list of Classes instances based on the
        //' data in the Journals
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
        List<Journals> results = new List<Journals>();
        try
        {
            //Default Value
            Journals myJournals = new Journals();
            if (isDeafaultIncluded)
            {
                //Change the code here
                myJournals.iJournal = 0;
                myJournals.strSerialNumber = "Select Journals ...";
                results.Add(myJournals);
            }
            while (reader.Read())
            {
                myJournals = new Journals();
                if (reader[LibraryMOD.GetFieldName(iJournalFN)].Equals(DBNull.Value))
                {
                    myJournals.iJournal = 0;
                }
                else
                {
                    myJournals.iJournal = int.Parse(reader[LibraryMOD.GetFieldName(iJournalFN)].ToString());
                }
                myJournals.strSerialNumber = reader[LibraryMOD.GetFieldName(strSerialNumberFN)].ToString();
                if (!reader[dDeliveryDateFN].Equals(DBNull.Value))
                {
                    myJournals.dDeliveryDate = DateTime.Parse(reader[LibraryMOD.GetFieldName(dDeliveryDateFN)].ToString());
                }
                if (!reader[dEntryDateFN].Equals(DBNull.Value))
                {
                    myJournals.dEntryDate = DateTime.Parse(reader[LibraryMOD.GetFieldName(dEntryDateFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(iSupplierFN)].Equals(DBNull.Value))
                {
                    myJournals.iSupplier = 0;
                }
                else
                {
                    myJournals.iSupplier = int.Parse(reader[LibraryMOD.GetFieldName(iSupplierFN)].ToString());
                }
                myJournals.strSubscriptionNo = reader[LibraryMOD.GetFieldName(strSubscriptionNoFN)].ToString();
                myJournals.strNote = reader[LibraryMOD.GetFieldName(strNoteFN)].ToString();
                myJournals.strTitle = reader[LibraryMOD.GetFieldName(strTitleFN)].ToString();
                if (reader[LibraryMOD.GetFieldName(iVolumeFN)].Equals(DBNull.Value))
                {
                    myJournals.iVolume = 0;
                }
                else
                {
                    myJournals.iVolume = int.Parse(reader[LibraryMOD.GetFieldName(iVolumeFN)].ToString());
                }
                myJournals.strIssueNo = reader[LibraryMOD.GetFieldName(strIssueNoFN)].ToString();
                if (reader[LibraryMOD.GetFieldName(iFrequencyFN)].Equals(DBNull.Value))
                {
                    myJournals.iFrequency = 0;
                }
                else
                {
                    myJournals.iFrequency = int.Parse(reader[LibraryMOD.GetFieldName(iFrequencyFN)].ToString());
                }
                if (!reader[dPublicationDateFN].Equals(DBNull.Value))
                {
                    myJournals.dPublicationDate = DateTime.Parse(reader[LibraryMOD.GetFieldName(dPublicationDateFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(iPublisherFN)].Equals(DBNull.Value))
                {
                    myJournals.iPublisher = 0;
                }
                else
                {
                    myJournals.iPublisher = int.Parse(reader[LibraryMOD.GetFieldName(iPublisherFN)].ToString());
                }
                myJournals.sISSN = reader[LibraryMOD.GetFieldName(sISSNFN)].ToString();
                if (!reader[dStartingDateFN].Equals(DBNull.Value))
                {
                    myJournals.dStartingDate = DateTime.Parse(reader[LibraryMOD.GetFieldName(dStartingDateFN)].ToString());
                }
                if (!reader[dExpiryDateFN].Equals(DBNull.Value))
                {
                    myJournals.dExpiryDate = DateTime.Parse(reader[LibraryMOD.GetFieldName(dExpiryDateFN)].ToString());
                }
                myJournals.strUserCreate = reader[LibraryMOD.GetFieldName(strUserCreateFN)].ToString();
                if (!reader[dateCreateFN].Equals(DBNull.Value))
                {
                    myJournals.dateCreate = DateTime.Parse(reader[LibraryMOD.GetFieldName(dateCreateFN)].ToString());
                }
                myJournals.strUserSave = reader[LibraryMOD.GetFieldName(strUserSaveFN)].ToString();
                if (!reader[dateLastSaveFN].Equals(DBNull.Value))
                {
                    myJournals.dateLastSave = DateTime.Parse(reader[LibraryMOD.GetFieldName(dateLastSaveFN)].ToString());
                }
                myJournals.strMachine = reader[LibraryMOD.GetFieldName(strMachineFN)].ToString();
                myJournals.strNUser = reader[LibraryMOD.GetFieldName(strNUserFN)].ToString();
                results.Add(myJournals);
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
    public int UpdateJournals(InitializeModule.EnumCampus Campus, int iMode, int iJournal, string strSerialNumber, DateTime dDeliveryDate, DateTime dEntryDate, int iSupplier, string strSubscriptionNo, double cPrice, string strNote, string strTitle, int iVolume, string strIssueNo, int iFrequency, DateTime dPublicationDate, int iPublisher, string sISSN, DateTime dStartingDate, DateTime dExpiryDate, string strUserCreate, DateTime dateCreate, string strUserSave, DateTime dateLastSave, string strMachine, string strNUser)
    {
        int iEffected = 0;
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        try
        {
            Conn.Open();
            string sql = "";
            Journals theJournals = new Journals();
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
            Cmd.Parameters.Add(new SqlParameter("@iJournal", iJournal));
            Cmd.Parameters.Add(new SqlParameter("@strSerialNumber", strSerialNumber));
            Cmd.Parameters.Add(new SqlParameter("@dDeliveryDate", dDeliveryDate));
            Cmd.Parameters.Add(new SqlParameter("@dEntryDate", dEntryDate));
            Cmd.Parameters.Add(new SqlParameter("@iSupplier", iSupplier));
            Cmd.Parameters.Add(new SqlParameter("@strSubscriptionNo", strSubscriptionNo));
            Cmd.Parameters.Add(new SqlParameter("@cPrice", cPrice));
            Cmd.Parameters.Add(new SqlParameter("@strNote", strNote));
            Cmd.Parameters.Add(new SqlParameter("@strTitle", strTitle));
            Cmd.Parameters.Add(new SqlParameter("@iVolume", iVolume));
            Cmd.Parameters.Add(new SqlParameter("@strIssueNo", strIssueNo));
            Cmd.Parameters.Add(new SqlParameter("@iFrequency", iFrequency));
            Cmd.Parameters.Add(new SqlParameter("@dPublicationDate", dPublicationDate));
            Cmd.Parameters.Add(new SqlParameter("@iPublisher", iPublisher));
            Cmd.Parameters.Add(new SqlParameter("@sISSN", sISSN));
            Cmd.Parameters.Add(new SqlParameter("@dStartingDate", dStartingDate));
            Cmd.Parameters.Add(new SqlParameter("@dExpiryDate", dExpiryDate));
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
    public int DeleteJournals(InitializeModule.EnumCampus Campus, string iJournal)
    {
        int iEffected = 0;
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        try
        {
            string sSQL = GetDeleteCommand();
            //sSQL += sCondition;
            SqlCommand Cmd = new SqlCommand(sSQL, Conn);
            Cmd.Parameters.Add(new SqlParameter("@iJournal", iJournal));
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
        DataTable dt = new DataTable("Journals");
        DataView dv = new DataView();
        List<Journals> myJournalss = new List<Journals>();
        try
        {
            myJournalss = GetJournals(InitializeModule.EnumCampus.ECTNew, sCondition, false);
            DataColumn col1 = new DataColumn("iJournal", Type.GetType("int"));
            dt.Columns.Add(col1);
            DataColumn col2 = new DataColumn("strSerialNumber", Type.GetType("nvarchar"));
            dt.Columns.Add(col2);
            DataColumn col3 = new DataColumn("dDeliveryDate", Type.GetType("datetime"));
            dt.Columns.Add(col3);
            dt.Constraints.Add(new UniqueConstraint(col1));

            DataRow dr;
            for (int i = 0; i < myJournalss.Count; i++)
            {
                dr = dt.NewRow();
                dr[1] = myJournalss[i].iJournal;
                dr[2] = myJournalss[i].strSerialNumber;
                dr[3] = myJournalss[i].dDeliveryDate;
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
            myJournalss.Clear();
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
            sSQL += iJournalFN;
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
public class JournalsCls : JournalsDAL
{
    #region "Decleration"
    private int m_lngCurRow = 0;
    public SqlDataAdapter daJournals;
    private DataSet m_dsJournals;
    public DataRow JournalsDataRow;
    #endregion
    #region "Puplic Properties"
    public DataSet dsJournals
    {
        get { return m_dsJournals; }
        set { m_dsJournals = value; }
    }
    //-----------------------------------------------------
    public int lngCurRow
    {
        get { return m_lngCurRow; }
        set { m_lngCurRow = value; }
    }
    #endregion
    public JournalsCls()
    {
        try
        {
            dsJournals = new DataSet();

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
    public virtual SqlDataAdapter GetJournalsDataAdapter(string sCondition, SqlConnection con)
    {
        string sSQL = "";
        try
        {
            sSQL = GetSQL();
            sSQL += " " + sCondition;
            //-----------------------------------------
            daJournals = new SqlDataAdapter(sSQL, con);
            // Create command builder. This line automatically generates the update commands for you, so you don't
            // have to provide or create your own.
            SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daJournals);
            //Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
            // key + unique key information to be retrieved unless AddWithKey is specified.
            daJournals.MissingSchemaAction = MissingSchemaAction.AddWithKey;
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return daJournals;
    }
    public virtual SqlDataAdapter GetJournalsDataAdapter(SqlConnection con)
    {
        try
        {
            daJournals = new SqlDataAdapter();
            //''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
            //'' key + unique key information to be retrieved unless AddWithKey is specified.
            daJournals.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            //-----------------------------------------
            SqlParameter Parmeter = default(SqlParameter);
            //[SELECT COMMAND]
            SqlCommand cmdJournals;
            cmdJournals = new SqlCommand(GetSelectCommand(), con);
            //'cmdRolePermission.Parameters.Add("@iJournal", SqlDbType.Int, 4, "iJournal" );
            daJournals.SelectCommand = cmdJournals;
            //'Add Handlers
            //'RowUpdating,RowUpdated
            AddDAEventHandler();
            //'[UPDATE COMMAND].
            cmdJournals = new SqlCommand(GetUpdateCommand(), con);
            //'Delete PK Parameteres from here. b/c its declared below
            cmdJournals.Parameters.Add("@iJournal", SqlDbType.Int, 4, LibraryMOD.GetFieldName(iJournalFN));
            cmdJournals.Parameters.Add("@strSerialNumber", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strSerialNumberFN));
            cmdJournals.Parameters.Add("@dDeliveryDate", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dDeliveryDateFN));
            cmdJournals.Parameters.Add("@dEntryDate", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dEntryDateFN));
            cmdJournals.Parameters.Add("@iSupplier", SqlDbType.Int, 4, LibraryMOD.GetFieldName(iSupplierFN));
            cmdJournals.Parameters.Add("@strSubscriptionNo", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strSubscriptionNoFN));
            cmdJournals.Parameters.Add("@cPrice", SqlDbType.SmallMoney, 21, LibraryMOD.GetFieldName(cPriceFN));
            cmdJournals.Parameters.Add("@strNote", SqlDbType.NVarChar, 400, LibraryMOD.GetFieldName(strNoteFN));
            cmdJournals.Parameters.Add("@strTitle", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strTitleFN));
            cmdJournals.Parameters.Add("@iVolume", SqlDbType.Int, 4, LibraryMOD.GetFieldName(iVolumeFN));
            cmdJournals.Parameters.Add("@strIssueNo", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strIssueNoFN));
            cmdJournals.Parameters.Add("@iFrequency", SqlDbType.Int, 2, LibraryMOD.GetFieldName(iFrequencyFN));
            cmdJournals.Parameters.Add("@dPublicationDate", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dPublicationDateFN));
            cmdJournals.Parameters.Add("@iPublisher", SqlDbType.Int, 4, LibraryMOD.GetFieldName(iPublisherFN));
            cmdJournals.Parameters.Add("@sISSN", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(sISSNFN));
            cmdJournals.Parameters.Add("@dStartingDate", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dStartingDateFN));
            cmdJournals.Parameters.Add("@dExpiryDate", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dExpiryDateFN));
            cmdJournals.Parameters.Add("@strUserCreate", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strUserCreateFN));
            cmdJournals.Parameters.Add("@dateCreate", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dateCreateFN));
            cmdJournals.Parameters.Add("@strUserSave", SqlDbType.Char, 10, LibraryMOD.GetFieldName(strUserSaveFN));
            cmdJournals.Parameters.Add("@dateLastSave", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dateLastSaveFN));
            cmdJournals.Parameters.Add("@strMachine", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strMachineFN));
            cmdJournals.Parameters.Add("@strNUser", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strNUserFN));


            Parmeter = cmdJournals.Parameters.Add("@iJournal", SqlDbType.Int, 4, LibraryMOD.GetFieldName(iJournalFN));
            Parmeter.SourceVersion = DataRowVersion.Original;
            //'Its should be none for batch updating
            //'UpdateCommand, InsertCommand, and DeleteCommand 
            //'should be set to None or OutputParameters
            daJournals.UpdateCommand = cmdJournals;
            daJournals.UpdateCommand.UpdatedRowSource = UpdateRowSource.None;
            //'-------------------------------------------------------------------------
            //'/INSERT COMMAND
            cmdJournals = new SqlCommand(GetInsertCommand(), con);
            cmdJournals.Parameters.Add("@iJournal", SqlDbType.Int, 4, LibraryMOD.GetFieldName(iJournalFN));
            cmdJournals.Parameters.Add("@strSerialNumber", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strSerialNumberFN));
            cmdJournals.Parameters.Add("@dDeliveryDate", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dDeliveryDateFN));
            cmdJournals.Parameters.Add("@dEntryDate", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dEntryDateFN));
            cmdJournals.Parameters.Add("@iSupplier", SqlDbType.Int, 4, LibraryMOD.GetFieldName(iSupplierFN));
            cmdJournals.Parameters.Add("@strSubscriptionNo", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strSubscriptionNoFN));
            cmdJournals.Parameters.Add("@cPrice", SqlDbType.SmallMoney, 21, LibraryMOD.GetFieldName(cPriceFN));
            cmdJournals.Parameters.Add("@strNote", SqlDbType.NVarChar, 400, LibraryMOD.GetFieldName(strNoteFN));
            cmdJournals.Parameters.Add("@strTitle", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strTitleFN));
            cmdJournals.Parameters.Add("@iVolume", SqlDbType.Int, 4, LibraryMOD.GetFieldName(iVolumeFN));
            cmdJournals.Parameters.Add("@strIssueNo", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strIssueNoFN));
            cmdJournals.Parameters.Add("@iFrequency", SqlDbType.Int, 2, LibraryMOD.GetFieldName(iFrequencyFN));
            cmdJournals.Parameters.Add("@dPublicationDate", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dPublicationDateFN));
            cmdJournals.Parameters.Add("@iPublisher", SqlDbType.Int, 4, LibraryMOD.GetFieldName(iPublisherFN));
            cmdJournals.Parameters.Add("@sISSN", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(sISSNFN));
            cmdJournals.Parameters.Add("@dStartingDate", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dStartingDateFN));
            cmdJournals.Parameters.Add("@dExpiryDate", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dExpiryDateFN));
            cmdJournals.Parameters.Add("@strUserCreate", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strUserCreateFN));
            cmdJournals.Parameters.Add("@dateCreate", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dateCreateFN));
            cmdJournals.Parameters.Add("@strUserSave", SqlDbType.Char, 10, LibraryMOD.GetFieldName(strUserSaveFN));
            cmdJournals.Parameters.Add("@dateLastSave", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dateLastSaveFN));
            cmdJournals.Parameters.Add("@strMachine", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strMachineFN));
            cmdJournals.Parameters.Add("@strNUser", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strNUserFN));
            Parmeter.SourceVersion = DataRowVersion.Current;
            daJournals.InsertCommand = cmdJournals;
            daJournals.InsertCommand.UpdatedRowSource = UpdateRowSource.None;
            //'------------------------
            //'/DELETE COMMAND
            cmdJournals = new SqlCommand(GetDeleteCommand(), con);
            Parmeter = cmdJournals.Parameters.Add("@iJournal", SqlDbType.Int, 4, LibraryMOD.GetFieldName(iJournalFN));
            Parmeter.SourceVersion = DataRowVersion.Original;
            daJournals.DeleteCommand = cmdJournals;
            daJournals.DeleteCommand.UpdatedRowSource = UpdateRowSource.None;
            //'Batch Size
            //'Set the batch size.
            daJournals.UpdateBatchSize = ECTGlobalDll.InitializeModule.BATCH_SIZE;
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return daJournals;
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
                    dr = dsJournals.Tables[TableName].NewRow();
                    dr[LibraryMOD.GetFieldName(iJournalFN)] = iJournal;
                    dr[LibraryMOD.GetFieldName(strSerialNumberFN)] = strSerialNumber;
                    dr[LibraryMOD.GetFieldName(dDeliveryDateFN)] = dDeliveryDate;
                    dr[LibraryMOD.GetFieldName(dEntryDateFN)] = dEntryDate;
                    dr[LibraryMOD.GetFieldName(iSupplierFN)] = iSupplier;
                    dr[LibraryMOD.GetFieldName(strSubscriptionNoFN)] = strSubscriptionNo;
                    dr[LibraryMOD.GetFieldName(cPriceFN)] = cPrice;
                    dr[LibraryMOD.GetFieldName(strNoteFN)] = strNote;
                    dr[LibraryMOD.GetFieldName(strTitleFN)] = strTitle;
                    dr[LibraryMOD.GetFieldName(iVolumeFN)] = iVolume;
                    dr[LibraryMOD.GetFieldName(strIssueNoFN)] = strIssueNo;
                    dr[LibraryMOD.GetFieldName(iFrequencyFN)] = iFrequency;
                    dr[LibraryMOD.GetFieldName(dPublicationDateFN)] = dPublicationDate;
                    dr[LibraryMOD.GetFieldName(iPublisherFN)] = iPublisher;
                    dr[LibraryMOD.GetFieldName(sISSNFN)] = sISSN;
                    dr[LibraryMOD.GetFieldName(dStartingDateFN)] = dStartingDate;
                    dr[LibraryMOD.GetFieldName(dExpiryDateFN)] = dExpiryDate;
                    dr[LibraryMOD.GetFieldName(strUserCreateFN)] = strUserCreate;
                    dr[LibraryMOD.GetFieldName(dateCreateFN)] = dateCreate;
                    dr[LibraryMOD.GetFieldName(strUserSaveFN)] = strUserSave;
                    dr[LibraryMOD.GetFieldName(dateLastSaveFN)] = dateLastSave;
                    dr[LibraryMOD.GetFieldName(strMachineFN)] = strMachine;
                    dr[LibraryMOD.GetFieldName(strNUserFN)] = strNUser;
                    dsJournals.Tables[TableName].Rows.Add(dr);
                    break;
                case (int)ECTGlobalDll.InitializeModule.enumModes.EditMode:
                    DataRow[] drAry = null;
                    drAry = dsJournals.Tables[TableName].Select(LibraryMOD.GetFieldName(iJournalFN) + "=" + iJournal);
                    //'its return array of rows and we can access the first by index 0
                    drAry[0][LibraryMOD.GetFieldName(iJournalFN)] = iJournal;
                    drAry[0][LibraryMOD.GetFieldName(strSerialNumberFN)] = strSerialNumber;
                    drAry[0][LibraryMOD.GetFieldName(dDeliveryDateFN)] = dDeliveryDate;
                    drAry[0][LibraryMOD.GetFieldName(dEntryDateFN)] = dEntryDate;
                    drAry[0][LibraryMOD.GetFieldName(iSupplierFN)] = iSupplier;
                    drAry[0][LibraryMOD.GetFieldName(strSubscriptionNoFN)] = strSubscriptionNo;
                    drAry[0][LibraryMOD.GetFieldName(cPriceFN)] = cPrice;
                    drAry[0][LibraryMOD.GetFieldName(strNoteFN)] = strNote;
                    drAry[0][LibraryMOD.GetFieldName(strTitleFN)] = strTitle;
                    drAry[0][LibraryMOD.GetFieldName(iVolumeFN)] = iVolume;
                    drAry[0][LibraryMOD.GetFieldName(strIssueNoFN)] = strIssueNo;
                    drAry[0][LibraryMOD.GetFieldName(iFrequencyFN)] = iFrequency;
                    drAry[0][LibraryMOD.GetFieldName(dPublicationDateFN)] = dPublicationDate;
                    drAry[0][LibraryMOD.GetFieldName(iPublisherFN)] = iPublisher;
                    drAry[0][LibraryMOD.GetFieldName(sISSNFN)] = sISSN;
                    drAry[0][LibraryMOD.GetFieldName(dStartingDateFN)] = dStartingDate;
                    drAry[0][LibraryMOD.GetFieldName(dExpiryDateFN)] = dExpiryDate;
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
    public int CommitJournals()
    {
        //CommitJournals= ECTGlobalDll.InitializeModule.FAIL_RET;
        try
        {
            //'' Update Database with SqlDataAdapter
            daJournals.Update(dsJournals, TableName);
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
            FindInMultiPKey(iJournal);
            if ((JournalsDataRow != null))
            {
                JournalsDataRow.Delete();
                CommitJournals();
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
            if (JournalsDataRow[LibraryMOD.GetFieldName(iJournalFN)] == System.DBNull.Value)
            {
                iJournal = 0;
            }
            else
            {
                iJournal = (int)JournalsDataRow[LibraryMOD.GetFieldName(iJournalFN)];
            }
            if (JournalsDataRow[LibraryMOD.GetFieldName(strSerialNumberFN)] == System.DBNull.Value)
            {
                strSerialNumber = "";
            }
            else
            {
                strSerialNumber = (string)JournalsDataRow[LibraryMOD.GetFieldName(strSerialNumberFN)];
            }
            if (JournalsDataRow[LibraryMOD.GetFieldName(dDeliveryDateFN)] == System.DBNull.Value)
            {
            }
            else
            {
                dDeliveryDate = (DateTime)JournalsDataRow[LibraryMOD.GetFieldName(dDeliveryDateFN)];
            }
            if (JournalsDataRow[LibraryMOD.GetFieldName(dEntryDateFN)] == System.DBNull.Value)
            {
            }
            else
            {
                dEntryDate = (DateTime)JournalsDataRow[LibraryMOD.GetFieldName(dEntryDateFN)];
            }
            if (JournalsDataRow[LibraryMOD.GetFieldName(iSupplierFN)] == System.DBNull.Value)
            {
                iSupplier = 0;
            }
            else
            {
                iSupplier = (int)JournalsDataRow[LibraryMOD.GetFieldName(iSupplierFN)];
            }
            if (JournalsDataRow[LibraryMOD.GetFieldName(strSubscriptionNoFN)] == System.DBNull.Value)
            {
                strSubscriptionNo = "";
            }
            else
            {
                strSubscriptionNo = (string)JournalsDataRow[LibraryMOD.GetFieldName(strSubscriptionNoFN)];
            }
            if (JournalsDataRow[LibraryMOD.GetFieldName(cPriceFN)] == System.DBNull.Value)
            {
            }
            else
            {
            }
            if (JournalsDataRow[LibraryMOD.GetFieldName(strNoteFN)] == System.DBNull.Value)
            {
                strNote = "";
            }
            else
            {
                strNote = (string)JournalsDataRow[LibraryMOD.GetFieldName(strNoteFN)];
            }
            if (JournalsDataRow[LibraryMOD.GetFieldName(strTitleFN)] == System.DBNull.Value)
            {
                strTitle = "";
            }
            else
            {
                strTitle = (string)JournalsDataRow[LibraryMOD.GetFieldName(strTitleFN)];
            }
            if (JournalsDataRow[LibraryMOD.GetFieldName(iVolumeFN)] == System.DBNull.Value)
            {
                iVolume = 0;
            }
            else
            {
                iVolume = (int)JournalsDataRow[LibraryMOD.GetFieldName(iVolumeFN)];
            }
            if (JournalsDataRow[LibraryMOD.GetFieldName(strIssueNoFN)] == System.DBNull.Value)
            {
                strIssueNo = "";
            }
            else
            {
                strIssueNo = (string)JournalsDataRow[LibraryMOD.GetFieldName(strIssueNoFN)];
            }
            if (JournalsDataRow[LibraryMOD.GetFieldName(iFrequencyFN)] == System.DBNull.Value)
            {
                iFrequency = 0;
            }
            else
            {
                iFrequency = (int)JournalsDataRow[LibraryMOD.GetFieldName(iFrequencyFN)];
            }
            if (JournalsDataRow[LibraryMOD.GetFieldName(dPublicationDateFN)] == System.DBNull.Value)
            {
            }
            else
            {
                dPublicationDate = (DateTime)JournalsDataRow[LibraryMOD.GetFieldName(dPublicationDateFN)];
            }
            if (JournalsDataRow[LibraryMOD.GetFieldName(iPublisherFN)] == System.DBNull.Value)
            {
                iPublisher = 0;
            }
            else
            {
                iPublisher = (int)JournalsDataRow[LibraryMOD.GetFieldName(iPublisherFN)];
            }
            if (JournalsDataRow[LibraryMOD.GetFieldName(sISSNFN)] == System.DBNull.Value)
            {
                sISSN = "";
            }
            else
            {
                sISSN = (string)JournalsDataRow[LibraryMOD.GetFieldName(sISSNFN)];
            }
            if (JournalsDataRow[LibraryMOD.GetFieldName(dStartingDateFN)] == System.DBNull.Value)
            {
            }
            else
            {
                dStartingDate = (DateTime)JournalsDataRow[LibraryMOD.GetFieldName(dStartingDateFN)];
            }
            if (JournalsDataRow[LibraryMOD.GetFieldName(dExpiryDateFN)] == System.DBNull.Value)
            {
            }
            else
            {
                dExpiryDate = (DateTime)JournalsDataRow[LibraryMOD.GetFieldName(dExpiryDateFN)];
            }
            if (JournalsDataRow[LibraryMOD.GetFieldName(strUserCreateFN)] == System.DBNull.Value)
            {
                strUserCreate = "";
            }
            else
            {
                strUserCreate = (string)JournalsDataRow[LibraryMOD.GetFieldName(strUserCreateFN)];
            }
            if (JournalsDataRow[LibraryMOD.GetFieldName(dateCreateFN)] == System.DBNull.Value)
            {
            }
            else
            {
                dateCreate = (DateTime)JournalsDataRow[LibraryMOD.GetFieldName(dateCreateFN)];
            }
            if (JournalsDataRow[LibraryMOD.GetFieldName(strUserSaveFN)] == System.DBNull.Value)
            {
                strUserSave = "";
            }
            else
            {
                strUserSave = (string)JournalsDataRow[LibraryMOD.GetFieldName(strUserSaveFN)];
            }
            if (JournalsDataRow[LibraryMOD.GetFieldName(dateLastSaveFN)] == System.DBNull.Value)
            {
            }
            else
            {
                dateLastSave = (DateTime)JournalsDataRow[LibraryMOD.GetFieldName(dateLastSaveFN)];
            }
            if (JournalsDataRow[LibraryMOD.GetFieldName(strMachineFN)] == System.DBNull.Value)
            {
                strMachine = "";
            }
            else
            {
                strMachine = (string)JournalsDataRow[LibraryMOD.GetFieldName(strMachineFN)];
            }
            if (JournalsDataRow[LibraryMOD.GetFieldName(strNUserFN)] == System.DBNull.Value)
            {
                strNUser = "";
            }
            else
            {
                strNUser = (string)JournalsDataRow[LibraryMOD.GetFieldName(strNUserFN)];
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
    public int FindInMultiPKey(int PKiJournal)
    {
        //FindInMultiPKey= ECTGlobalDll.InitializeModule.FAIL_RET;
        try
        {
            //' Create an array for the key values to find.
            object[] findTheseVals = new object[1];
            //' Set the values of the keys to find.
            findTheseVals[0] = PKiJournal;
            JournalsDataRow = dsJournals.Tables[TableName].Rows.Find(findTheseVals);
            if ((JournalsDataRow != null))
            {
                lngCurRow = dsJournals.Tables[TableName].Rows.IndexOf(JournalsDataRow);
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
            lngCurRow = dsJournals.Tables[TableName].Rows.Count - 1; //'Zero based index
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
            lngCurRow = Math.Min(lngCurRow + 1, dsJournals.Tables[TableName].Rows.Count - 1);
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
            if (lngCurRow >= 0 & dsJournals.Tables[TableName].Rows.Count > 0)
            {
                JournalsDataRow = dsJournals.Tables[TableName].Rows[lngCurRow];
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
            daJournals.RowUpdating += new SqlRowUpdatingEventHandler(OnRowUpdating);
            daJournals.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
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
            daJournals.RowUpdating -= new SqlRowUpdatingEventHandler(OnRowUpdating);
            daJournals.RowUpdated -= new SqlRowUpdatedEventHandler(OnRowUpdated);
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
