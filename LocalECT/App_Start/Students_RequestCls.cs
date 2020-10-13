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

public class Students_Request
{
    //Creation Date: 16/05/2012 03:20:12 PM
    //Programmer Name : 
    //-----Decleration --------------
    #region "Decleration"
    private int m_iSerial;
    private string m_sStudentNo;
    private int m_bStatus;
    private int m_bReason;
    private int m_bSubReason;
    private string m_sNote;
    private DateTime m_dDateFollowup;
    private string m_sFollowedBy;
    private DateTime m_dDateChecked;
    private string m_sCheckedBy;
    private int m_bFollowStatus;
    private int m_iTRKTimes;
    private string m_isCreated;
    private DateTime m_dateCreated;
    private string m_sUserCreated;
    #endregion
    #region "Puplic Properties"
    //'-----------------------------------------------------
    public int iSerial
    {
        get { return m_iSerial; }
        set { m_iSerial = value; }
    }
    public string sStudentNo
    {
        get { return m_sStudentNo; }
        set { m_sStudentNo = value; }
    }
    public int bStatus
    {
        get { return m_bStatus; }
        set { m_bStatus = value; }
    }
    public int bReason
    {
        get { return m_bReason; }
        set { m_bReason = value; }
    }
    public int bSubReason
    {
        get { return m_bSubReason; }
        set { m_bSubReason = value; }
    }
    public string sNote
    {
        get { return m_sNote; }
        set { m_sNote = value; }
    }
    public DateTime dDateFollowup
    {
        get { return m_dDateFollowup; }
        set { m_dDateFollowup = value; }
    }
    public string sFollowedBy
    {
        get { return m_sFollowedBy; }
        set { m_sFollowedBy = value; }
    }
    public DateTime dDateChecked
    {
        get { return m_dDateChecked; }
        set { m_dDateChecked = value; }
    }
    public string sCheckedBy
    {
        get { return m_sCheckedBy; }
        set { m_sCheckedBy = value; }
    }
    public int bFollowStatus
    {
        get { return m_bFollowStatus; }
        set { m_bFollowStatus = value; }
    }
    public int iTRKTimes
    {
        get { return m_iTRKTimes; }
        set { m_iTRKTimes = value; }
    }
    public string isCreated
    {
        get { return m_isCreated; }
        set { m_isCreated = value; }
    }
    public DateTime dateCreated
    {
        get { return m_dateCreated; }
        set { m_dateCreated = value; }
    }
    public string sUserCreated
    {
        get { return m_sUserCreated; }
        set { m_sUserCreated = value; }
    }
    //'-----------------------------------------------------
    #endregion
    //'-----------------------------------------------------
    public Students_Request()
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

public class Students_RequestDAL : Students_Request
{
    #region "Decleration"
    private string m_TableName;
    private string m_iSerialFN;
    private string m_sStudentNoFN;
    private string m_bStatusFN;
    private string m_bReasonFN;
    private string m_bSubReasonFN;
    private string m_sNoteFN;
    private string m_dDateFollowupFN;
    private string m_sFollowedByFN;
    private string m_dDateCheckedFN;
    private string m_sCheckedByFN;
    private string m_bFollowStatusFN;
    private string m_iTRKTimesFN;
    private string m_isCreatedFN;
    private string m_dateCreatedFN;
    private string m_sUserCreatedFN;
    #endregion
    //'-----------------------------------------------------
    #region "Puplic Properties"
    public string TableName
    {
        get { return m_TableName; }
        set { m_TableName = value; }
    }
    public string iSerialFN
    {
        get { return m_iSerialFN; }
        set { m_iSerialFN = value; }
    }
    public string sStudentNoFN
    {
        get { return m_sStudentNoFN; }
        set { m_sStudentNoFN = value; }
    }
    public string bStatusFN
    {
        get { return m_bStatusFN; }
        set { m_bStatusFN = value; }
    }
    public string bReasonFN
    {
        get { return m_bReasonFN; }
        set { m_bReasonFN = value; }
    }
    public string bSubReasonFN
    {
        get { return m_bSubReasonFN; }
        set { m_bSubReasonFN = value; }
    }
    public string sNoteFN
    {
        get { return m_sNoteFN; }
        set { m_sNoteFN = value; }
    }
    public string dDateFollowupFN
    {
        get { return m_dDateFollowupFN; }
        set { m_dDateFollowupFN = value; }
    }
    public string sFollowedByFN
    {
        get { return m_sFollowedByFN; }
        set { m_sFollowedByFN = value; }
    }
    public string dDateCheckedFN
    {
        get { return m_dDateCheckedFN; }
        set { m_dDateCheckedFN = value; }
    }
    public string sCheckedByFN
    {
        get { return m_sCheckedByFN; }
        set { m_sCheckedByFN = value; }
    }
    public string bFollowStatusFN
    {
        get { return m_bFollowStatusFN; }
        set { m_bFollowStatusFN = value; }
    }
    public string iTRKTimesFN
    {
        get { return m_iTRKTimesFN; }
        set { m_iTRKTimesFN = value; }
    }
    public string isCreatedFN
    {
        get { return m_isCreatedFN; }
        set { m_isCreatedFN = value; }
    }
    public string dateCreatedFN
    {
        get { return m_dateCreatedFN; }
        set { m_dateCreatedFN = value; }
    }
    public string sUserCreatedFN
    {
        get { return m_sUserCreatedFN; }
        set { m_sUserCreatedFN = value; }
    }
    #endregion
    //================End Properties ===================
    public Students_RequestDAL()
    {
        try
        {
            this.TableName = "Reg_Students_Request";
            this.iSerialFN = m_TableName + ".iSerial";
            this.sStudentNoFN = m_TableName + ".sStudentNo";
            this.bStatusFN = m_TableName + ".bStatus";
            this.bReasonFN = m_TableName + ".bReason";
            this.bSubReasonFN = m_TableName + ".bSubReason";
            this.sNoteFN = m_TableName + ".sNote";
            this.dDateFollowupFN = m_TableName + ".dDateFollowup";
            this.sFollowedByFN = m_TableName + ".sFollowedBy";
            this.dDateCheckedFN = m_TableName + ".dDateChecked";
            this.sCheckedByFN = m_TableName + ".sCheckedBy";
            this.bFollowStatusFN = m_TableName + ".bFollowStatus";
            this.iTRKTimesFN = m_TableName + ".iTRKTimes";
            this.isCreatedFN = m_TableName + ".isCreated";
            this.dateCreatedFN = m_TableName + ".dateCreated";
            this.sUserCreatedFN = m_TableName + ".sUserCreated";
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
            sSQL += iSerialFN;
            sSQL += " , " + sStudentNoFN;
            sSQL += " , " + bStatusFN;
            sSQL += " , " + bReasonFN;
            sSQL += " , " + bSubReasonFN;
            sSQL += " , " + sNoteFN;
            sSQL += " , " + dDateFollowupFN;
            sSQL += " , " + sFollowedByFN;
            sSQL += " , " + dDateCheckedFN;
            sSQL += " , " + sCheckedByFN;
            sSQL += " , " + bFollowStatusFN;
            sSQL += " , " + iTRKTimesFN;
            sSQL += " , " + isCreatedFN;
            sSQL += " , " + dateCreatedFN;
            sSQL += " , " + sUserCreatedFN;
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
            sSQL += iSerialFN;
            sSQL += " , " + sStudentNoFN;
            sSQL += " , " + bStatusFN;
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
            sSQL += iSerialFN;
            sSQL += " , " + sStudentNoFN;
            sSQL += " , " + bStatusFN;
            sSQL += " , " + bReasonFN;
            sSQL += " , " + bSubReasonFN;
            sSQL += " , " + sNoteFN;
            sSQL += " , " + dDateFollowupFN;
            sSQL += " , " + sFollowedByFN;
            sSQL += " , " + dDateCheckedFN;
            sSQL += " , " + sCheckedByFN;
            sSQL += " , " + bFollowStatusFN;
            sSQL += " , " + iTRKTimesFN;
            sSQL += " , " + isCreatedFN;
            sSQL += " , " + dateCreatedFN;
            sSQL += " , " + sUserCreatedFN;
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
            sSQL += LibraryMOD.GetFieldName(iSerialFN) + "=@iSerial";
            sSQL += " , " + LibraryMOD.GetFieldName(sStudentNoFN) + "=@sStudentNo";
            sSQL += " , " + LibraryMOD.GetFieldName(bStatusFN) + "=@bStatus";
            sSQL += " , " + LibraryMOD.GetFieldName(bReasonFN) + "=@bReason";
            sSQL += " , " + LibraryMOD.GetFieldName(bSubReasonFN) + "=@bSubReason";
            sSQL += " , " + LibraryMOD.GetFieldName(sNoteFN) + "=@sNote";
            sSQL += " , " + LibraryMOD.GetFieldName(dDateFollowupFN) + "=@dDateFollowup";
            sSQL += " , " + LibraryMOD.GetFieldName(sFollowedByFN) + "=@sFollowedBy";
            sSQL += " , " + LibraryMOD.GetFieldName(dDateCheckedFN) + "=@dDateChecked";
            sSQL += " , " + LibraryMOD.GetFieldName(sCheckedByFN) + "=@sCheckedBy";
            sSQL += " , " + LibraryMOD.GetFieldName(bFollowStatusFN) + "=@bFollowStatus";
            sSQL += " , " + LibraryMOD.GetFieldName(iTRKTimesFN) + "=@iTRKTimes";
            sSQL += " , " + LibraryMOD.GetFieldName(isCreatedFN) + "=@isCreated";
            sSQL += " , " + LibraryMOD.GetFieldName(dateCreatedFN) + "=@dateCreated";
            sSQL += " , " + LibraryMOD.GetFieldName(sUserCreatedFN) + "=@sUserCreated";
            sSQL += " WHERE ";
            sSQL += LibraryMOD.GetFieldName(iSerialFN) + "=@iSerial";
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
            sSQL += LibraryMOD.GetFieldName(iSerialFN);
            sSQL += " , " + LibraryMOD.GetFieldName(sStudentNoFN);
            sSQL += " , " + LibraryMOD.GetFieldName(bStatusFN);
            sSQL += " , " + LibraryMOD.GetFieldName(bReasonFN);
            sSQL += " , " + LibraryMOD.GetFieldName(bSubReasonFN);
            sSQL += " , " + LibraryMOD.GetFieldName(sNoteFN);
            sSQL += " , " + LibraryMOD.GetFieldName(dDateFollowupFN);
            sSQL += " , " + LibraryMOD.GetFieldName(sFollowedByFN);
            sSQL += " , " + LibraryMOD.GetFieldName(dDateCheckedFN);
            sSQL += " , " + LibraryMOD.GetFieldName(sCheckedByFN);
            sSQL += " , " + LibraryMOD.GetFieldName(bFollowStatusFN);
            sSQL += " , " + LibraryMOD.GetFieldName(iTRKTimesFN);
            sSQL += " , " + LibraryMOD.GetFieldName(isCreatedFN);
            sSQL += " , " + LibraryMOD.GetFieldName(dateCreatedFN);
            sSQL += " , " + LibraryMOD.GetFieldName(sUserCreatedFN);
            sSQL += ")";
            sSQL += " VALUES ";
            sSQL += "( ";
            sSQL += " @iSerial";
            sSQL += " ,@sStudentNo";
            sSQL += " ,@bStatus";
            sSQL += " ,@bReason";
            sSQL += " ,@bSubReason";
            sSQL += " ,@sNote";
            sSQL += " ,@dDateFollowup";
            sSQL += " ,@sFollowedBy";
            sSQL += " ,@dDateChecked";
            sSQL += " ,@sCheckedBy";
            sSQL += " ,@bFollowStatus";
            sSQL += " ,@iTRKTimes";
            sSQL += " ,@isCreated";
            sSQL += " ,@dateCreated";
            sSQL += " ,@sUserCreated";
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
            sSQL += LibraryMOD.GetFieldName(iSerialFN) + "=@iSerial";
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
    public List<Students_Request> GetStudents_Request(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
    {
        //' returns a list of Classes instances based on the
        //' data in the Students_Request
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
        List<Students_Request> results = new List<Students_Request>();
        try
        {
            //Default Value
            Students_Request myStudents_Request = new Students_Request();
            if (isDeafaultIncluded)
            {
                //Change the code here
                myStudents_Request.iSerial = 0;
                results.Add(myStudents_Request);
            }
            while (reader.Read())
            {
                myStudents_Request = new Students_Request();
                if (reader[LibraryMOD.GetFieldName(iSerialFN)].Equals(DBNull.Value))
                {
                    myStudents_Request.iSerial = 0;
                }
                else
                {
                    myStudents_Request.iSerial = int.Parse(reader[LibraryMOD.GetFieldName(iSerialFN)].ToString());
                }
                myStudents_Request.sStudentNo = reader[LibraryMOD.GetFieldName(sStudentNoFN)].ToString();
                if (reader[LibraryMOD.GetFieldName(bStatusFN)].Equals(DBNull.Value))
                {
                    myStudents_Request.bStatus = 0;
                }
                else
                {
                    myStudents_Request.bStatus = int.Parse(reader[LibraryMOD.GetFieldName(bStatusFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(bReasonFN)].Equals(DBNull.Value))
                {
                    myStudents_Request.bReason = 0;
                }
                else
                {
                    myStudents_Request.bReason = int.Parse(reader[LibraryMOD.GetFieldName(bReasonFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(bSubReasonFN)].Equals(DBNull.Value))
                {
                    myStudents_Request.bSubReason = 0;
                }
                else
                {
                    myStudents_Request.bSubReason = int.Parse(reader[LibraryMOD.GetFieldName(bSubReasonFN)].ToString());
                }
                myStudents_Request.sNote = reader[LibraryMOD.GetFieldName(sNoteFN)].ToString();
                if (!reader[LibraryMOD.GetFieldName(dDateFollowupFN)].Equals(DBNull.Value))
                {
                    myStudents_Request.dDateFollowup = DateTime.Parse(reader[LibraryMOD.GetFieldName(dDateFollowupFN)].ToString());
                }
                myStudents_Request.sFollowedBy = reader[LibraryMOD.GetFieldName(sFollowedByFN)].ToString();
                if (!reader[LibraryMOD.GetFieldName(dDateCheckedFN)].Equals(DBNull.Value))
                {
                    myStudents_Request.dDateChecked = DateTime.Parse(reader[LibraryMOD.GetFieldName(dDateCheckedFN)].ToString());
                }
                myStudents_Request.sCheckedBy = reader[LibraryMOD.GetFieldName(sCheckedByFN)].ToString();
                if (reader[LibraryMOD.GetFieldName(bFollowStatusFN)].Equals(DBNull.Value))
                {
                    myStudents_Request.bFollowStatus = 0;
                }
                else
                {
                    myStudents_Request.bFollowStatus = int.Parse(reader[LibraryMOD.GetFieldName(bFollowStatusFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(iTRKTimesFN)].Equals(DBNull.Value))
                {
                    myStudents_Request.iTRKTimes = 0;
                }
                else
                {
                    myStudents_Request.iTRKTimes = int.Parse(reader[LibraryMOD.GetFieldName(iTRKTimesFN)].ToString());
                }
                myStudents_Request.isCreated = reader[LibraryMOD.GetFieldName(isCreatedFN)].ToString();
                if (!reader[LibraryMOD.GetFieldName(dateCreatedFN)].Equals(DBNull.Value))
                {
                    myStudents_Request.dateCreated = DateTime.Parse(reader[LibraryMOD.GetFieldName(dateCreatedFN)].ToString());
                }
                myStudents_Request.sUserCreated = reader[LibraryMOD.GetFieldName(sUserCreatedFN)].ToString();
                results.Add(myStudents_Request);
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
    public List<Students_Request> GetList(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
    {
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        string sSQL = GetListSQL(sCondition);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        SqlCommand Cmd = new SqlCommand(sSQL, Conn);
        Conn.Open();
        SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
        List<Students_Request> results = new List<Students_Request>();
        try
        {
            //Default Value
            Students_Request myStudents_Request = new Students_Request();
            if (isDeafaultIncluded)
            {
                //Change the code here
                myStudents_Request.iSerial = -1;
                myStudents_Request.sStudentNo = "Select Students_Request";
                results.Add(myStudents_Request);
            }
            while (reader.Read())
            {
                myStudents_Request = new Students_Request();
                if (reader[LibraryMOD.GetFieldName(iSerialFN)].Equals(DBNull.Value))
                {
                    myStudents_Request.iSerial = 0;
                }
                else
                {
                    myStudents_Request.iSerial = int.Parse(reader[LibraryMOD.GetFieldName(iSerialFN)].ToString());
                }
                myStudents_Request.sStudentNo = reader[LibraryMOD.GetFieldName(sStudentNoFN)].ToString();
                if (reader[LibraryMOD.GetFieldName(bStatusFN)].Equals(DBNull.Value))
                {
                    myStudents_Request.bStatus = 0;
                }
                else
                {
                    myStudents_Request.bStatus = int.Parse(reader[LibraryMOD.GetFieldName(bStatusFN)].ToString());
                }
                results.Add(myStudents_Request);
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
    public int UpdateStudents_Request(InitializeModule.EnumCampus Campus, int iMode, int iSerial, string sStudentNo, int bStatus, int bReason, int bSubReason, string sNote, DateTime dDateFollowup, string sFollowedBy, DateTime dDateChecked, string sCheckedBy, int bFollowStatus, int iTRKTimes, string isCreated, DateTime dateCreated, string sUserCreated)
    {
        int iEffected = 0;
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        try
        {
            Conn.Open();
            string sql = "";
            Students_Request theStudents_Request = new Students_Request();
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
            Cmd.Parameters.Add(new SqlParameter("@iSerial", iSerial));
            Cmd.Parameters.Add(new SqlParameter("@sStudentNo", sStudentNo));
            Cmd.Parameters.Add(new SqlParameter("@bStatus", bStatus));
            Cmd.Parameters.Add(new SqlParameter("@bReason", bReason));
            Cmd.Parameters.Add(new SqlParameter("@bSubReason", bSubReason));
            Cmd.Parameters.Add(new SqlParameter("@sNote", sNote));
            if (dDateFollowup != new DateTime(1900, 01, 01))
                Cmd.Parameters.Add(new SqlParameter("@dDateFollowup", dDateFollowup));
            else
                Cmd.Parameters.Add(new SqlParameter("@dDateFollowup", DBNull.Value));
            Cmd.Parameters.Add(new SqlParameter("@sFollowedBy", sFollowedBy));
            if (dDateChecked != new DateTime(1900, 01, 01))
            Cmd.Parameters.Add(new SqlParameter("@dDateChecked", dDateChecked));
            else
                Cmd.Parameters.Add(new SqlParameter("@dDateChecked", DBNull.Value));
            Cmd.Parameters.Add(new SqlParameter("@sCheckedBy", sCheckedBy));
            Cmd.Parameters.Add(new SqlParameter("@bFollowStatus", bFollowStatus));
            Cmd.Parameters.Add(new SqlParameter("@iTRKTimes", iTRKTimes));
            Cmd.Parameters.Add(new SqlParameter("@isCreated", isCreated));

            if (dateCreated != new DateTime(1900, 01, 01))
                Cmd.Parameters.Add(new SqlParameter("@dateCreated", dateCreated));
            else
                Cmd.Parameters.Add(new SqlParameter("@dateCreated", DBNull.Value));
            Cmd.Parameters.Add(new SqlParameter("@sUserCreated", sUserCreated));
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
    public int DeleteStudents_Request(InitializeModule.EnumCampus Campus, string iSerial)
    {
        int iEffected = 0;
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        try
        {
            string sSQL = GetDeleteCommand();
            //sSQL += sCondition;
            SqlCommand Cmd = new SqlCommand(sSQL, Conn);
            Cmd.Parameters.Add(new SqlParameter("@iSerial", iSerial));
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
        DataTable dt = new DataTable("Students_Request");
        DataView dv = new DataView();
        List<Students_Request> myStudents_Requests = new List<Students_Request>();
        try
        {
            myStudents_Requests = GetStudents_Request(InitializeModule.EnumCampus.ECTNew, sCondition, false);
            DataColumn col0 = new DataColumn("iSerial", Type.GetType("int"));
            dt.Columns.Add(col0);
            dt.Constraints.Add(new UniqueConstraint(col0));

            DataRow dr;
            for (int i = 0; i < myStudents_Requests.Count; i++)
            {
                dr = dt.NewRow();
                dr[1] = myStudents_Requests[i].iSerial;
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
            myStudents_Requests.Clear();
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
            sSQL += iSerialFN;
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

public class Students_RequestCls : Students_RequestDAL
{
    #region "Decleration"
    private int m_lngCurRow = 0;
    public SqlDataAdapter daStudents_Request;
    private DataSet m_dsStudents_Request;
    public DataRow Students_RequestDataRow;
    #endregion
    #region "Puplic Properties"
    public DataSet dsStudents_Request
    {
        get { return m_dsStudents_Request; }
        set { m_dsStudents_Request = value; }
    }
    //-----------------------------------------------------
    public int lngCurRow
    {
        get { return m_lngCurRow; }
        set { m_lngCurRow = value; }
    }
    #endregion
    public Students_RequestCls()
    {
        try
        {
            dsStudents_Request = new DataSet();

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
    public virtual SqlDataAdapter GetStudents_RequestDataAdapter(string sCondition, SqlConnection con)
    {
        string sSQL = "";
        try
        {
            sSQL = GetSQL();
            sSQL += " " + sCondition;
            //-----------------------------------------
            daStudents_Request = new SqlDataAdapter(sSQL, con);
            // Create command builder. This line automatically generates the update commands for you, so you don't
            // have to provide or create your own.
            SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daStudents_Request);
            //Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
            // key + unique key information to be retrieved unless AddWithKey is specified.
            daStudents_Request.MissingSchemaAction = MissingSchemaAction.AddWithKey;
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return daStudents_Request;
    }
    public virtual SqlDataAdapter GetStudents_RequestDataAdapter(SqlConnection con)
    {
        try
        {
            daStudents_Request = new SqlDataAdapter();
            //''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
            //'' key + unique key information to be retrieved unless AddWithKey is specified.
            daStudents_Request.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            //-----------------------------------------
            SqlParameter Parmeter = default(SqlParameter);
            //[SELECT COMMAND]
            SqlCommand cmdStudents_Request;
            cmdStudents_Request = new SqlCommand(GetSelectCommand(), con);
            //'cmdRolePermission.Parameters.Add("@iSerial", SqlDbType.Int, 4, "iSerial" );
            daStudents_Request.SelectCommand = cmdStudents_Request;
            //'Add Handlers
            //'RowUpdating,RowUpdated
            AddDAEventHandler();
            //'[UPDATE COMMAND].
            cmdStudents_Request = new SqlCommand(GetUpdateCommand(), con);
            //'Delete PK Parameteres from here. b/c its declared below
            cmdStudents_Request.Parameters.Add("@iSerial", SqlDbType.Int, 4, LibraryMOD.GetFieldName(iSerialFN));
            cmdStudents_Request.Parameters.Add("@sStudentNo", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(sStudentNoFN));
            cmdStudents_Request.Parameters.Add("@bStatus", SqlDbType.Int, 2, LibraryMOD.GetFieldName(bStatusFN));
            cmdStudents_Request.Parameters.Add("@bReason", SqlDbType.Int, 2, LibraryMOD.GetFieldName(bReasonFN));
            cmdStudents_Request.Parameters.Add("@bSubReason", SqlDbType.Int, 2, LibraryMOD.GetFieldName(bSubReasonFN));
            cmdStudents_Request.Parameters.Add("@sNote", SqlDbType.NVarChar, 600, LibraryMOD.GetFieldName(sNoteFN));
            cmdStudents_Request.Parameters.Add("@dDateFollowup", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dDateFollowupFN));
            cmdStudents_Request.Parameters.Add("@sFollowedBy", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(sFollowedByFN));
            cmdStudents_Request.Parameters.Add("@dDateChecked", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dDateCheckedFN));
            cmdStudents_Request.Parameters.Add("@sCheckedBy", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(sCheckedByFN));
            cmdStudents_Request.Parameters.Add("@bFollowStatus", SqlDbType.Int, 2, LibraryMOD.GetFieldName(bFollowStatusFN));
            cmdStudents_Request.Parameters.Add("@iTRKTimes", SqlDbType.Int, 2, LibraryMOD.GetFieldName(iTRKTimesFN));
            cmdStudents_Request.Parameters.Add("@isCreated", SqlDbType.Bit, 1, LibraryMOD.GetFieldName(isCreatedFN));
            cmdStudents_Request.Parameters.Add("@dateCreated", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dateCreatedFN));
            cmdStudents_Request.Parameters.Add("@sUserCreated", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(sUserCreatedFN));


            Parmeter = cmdStudents_Request.Parameters.Add("@iSerial", SqlDbType.Int, 4, LibraryMOD.GetFieldName(iSerialFN));
            Parmeter.SourceVersion = DataRowVersion.Original;
            //'Its should be none for batch updating
            //'UpdateCommand, InsertCommand, and DeleteCommand 
            //'should be set to None or OutputParameters
            daStudents_Request.UpdateCommand = cmdStudents_Request;
            daStudents_Request.UpdateCommand.UpdatedRowSource = UpdateRowSource.None;
            //'-------------------------------------------------------------------------
            //'/INSERT COMMAND
            cmdStudents_Request = new SqlCommand(GetInsertCommand(), con);
            cmdStudents_Request.Parameters.Add("@iSerial", SqlDbType.Int, 4, LibraryMOD.GetFieldName(iSerialFN));
            cmdStudents_Request.Parameters.Add("@sStudentNo", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(sStudentNoFN));
            cmdStudents_Request.Parameters.Add("@bStatus", SqlDbType.Int, 2, LibraryMOD.GetFieldName(bStatusFN));
            cmdStudents_Request.Parameters.Add("@bReason", SqlDbType.Int, 2, LibraryMOD.GetFieldName(bReasonFN));
            cmdStudents_Request.Parameters.Add("@bSubReason", SqlDbType.Int, 2, LibraryMOD.GetFieldName(bSubReasonFN));
            cmdStudents_Request.Parameters.Add("@sNote", SqlDbType.NVarChar, 600, LibraryMOD.GetFieldName(sNoteFN));
            cmdStudents_Request.Parameters.Add("@dDateFollowup", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dDateFollowupFN));
            cmdStudents_Request.Parameters.Add("@sFollowedBy", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(sFollowedByFN));
            cmdStudents_Request.Parameters.Add("@dDateChecked", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dDateCheckedFN));
            cmdStudents_Request.Parameters.Add("@sCheckedBy", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(sCheckedByFN));
            cmdStudents_Request.Parameters.Add("@bFollowStatus", SqlDbType.Int, 2, LibraryMOD.GetFieldName(bFollowStatusFN));
            cmdStudents_Request.Parameters.Add("@iTRKTimes", SqlDbType.Int, 2, LibraryMOD.GetFieldName(iTRKTimesFN));
            cmdStudents_Request.Parameters.Add("@isCreated", SqlDbType.Bit, 1, LibraryMOD.GetFieldName(isCreatedFN));
            cmdStudents_Request.Parameters.Add("@dateCreated", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dateCreatedFN));
            cmdStudents_Request.Parameters.Add("@sUserCreated", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(sUserCreatedFN));
            Parmeter.SourceVersion = DataRowVersion.Current;
            daStudents_Request.InsertCommand = cmdStudents_Request;
            daStudents_Request.InsertCommand.UpdatedRowSource = UpdateRowSource.None;
            //'------------------------
            //'/DELETE COMMAND
            cmdStudents_Request = new SqlCommand(GetDeleteCommand(), con);
            Parmeter = cmdStudents_Request.Parameters.Add("@iSerial", SqlDbType.Int, 4, LibraryMOD.GetFieldName(iSerialFN));
            Parmeter.SourceVersion = DataRowVersion.Original;
            daStudents_Request.DeleteCommand = cmdStudents_Request;
            daStudents_Request.DeleteCommand.UpdatedRowSource = UpdateRowSource.None;
            //'Batch Size
            //'Set the batch size.
            daStudents_Request.UpdateBatchSize = ECTGlobalDll.InitializeModule.BATCH_SIZE;
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return daStudents_Request;
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
                    dr = dsStudents_Request.Tables[TableName].NewRow();
                    dr[LibraryMOD.GetFieldName(iSerialFN)] = iSerial;
                    dr[LibraryMOD.GetFieldName(sStudentNoFN)] = sStudentNo;
                    dr[LibraryMOD.GetFieldName(bStatusFN)] = bStatus;
                    dr[LibraryMOD.GetFieldName(bReasonFN)] = bReason;
                    dr[LibraryMOD.GetFieldName(bSubReasonFN)] = bSubReason;
                    dr[LibraryMOD.GetFieldName(sNoteFN)] = sNote;
                    dr[LibraryMOD.GetFieldName(dDateFollowupFN)] = dDateFollowup;
                    dr[LibraryMOD.GetFieldName(sFollowedByFN)] = sFollowedBy;
                    dr[LibraryMOD.GetFieldName(dDateCheckedFN)] = dDateChecked;
                    dr[LibraryMOD.GetFieldName(sCheckedByFN)] = sCheckedBy;
                    dr[LibraryMOD.GetFieldName(bFollowStatusFN)] = bFollowStatus;
                    dr[LibraryMOD.GetFieldName(iTRKTimesFN)] = iTRKTimes;
                    dr[LibraryMOD.GetFieldName(isCreatedFN)] = isCreated;
                    dr[LibraryMOD.GetFieldName(dateCreatedFN)] = dateCreated;
                    dr[LibraryMOD.GetFieldName(sUserCreatedFN)] = sUserCreated;
                    dsStudents_Request.Tables[TableName].Rows.Add(dr);
                    break;
                case (int)ECTGlobalDll.InitializeModule.enumModes.EditMode:
                    DataRow[] drAry = null;
                    drAry = dsStudents_Request.Tables[TableName].Select(LibraryMOD.GetFieldName(iSerialFN) + "=" + iSerial);
                    //'its return array of rows and we can access the first by index 0
                    drAry[0][LibraryMOD.GetFieldName(iSerialFN)] = iSerial;
                    drAry[0][LibraryMOD.GetFieldName(sStudentNoFN)] = sStudentNo;
                    drAry[0][LibraryMOD.GetFieldName(bStatusFN)] = bStatus;
                    drAry[0][LibraryMOD.GetFieldName(bReasonFN)] = bReason;
                    drAry[0][LibraryMOD.GetFieldName(bSubReasonFN)] = bSubReason;
                    drAry[0][LibraryMOD.GetFieldName(sNoteFN)] = sNote;
                    drAry[0][LibraryMOD.GetFieldName(dDateFollowupFN)] = dDateFollowup;
                    drAry[0][LibraryMOD.GetFieldName(sFollowedByFN)] = sFollowedBy;
                    drAry[0][LibraryMOD.GetFieldName(dDateCheckedFN)] = dDateChecked;
                    drAry[0][LibraryMOD.GetFieldName(sCheckedByFN)] = sCheckedBy;
                    drAry[0][LibraryMOD.GetFieldName(bFollowStatusFN)] = bFollowStatus;
                    drAry[0][LibraryMOD.GetFieldName(iTRKTimesFN)] = iTRKTimes;
                    drAry[0][LibraryMOD.GetFieldName(isCreatedFN)] = isCreated;
                    drAry[0][LibraryMOD.GetFieldName(dateCreatedFN)] = dateCreated;
                    drAry[0][LibraryMOD.GetFieldName(sUserCreatedFN)] = sUserCreated;
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
    public int CommitStudents_Request()
    {
        //CommitStudents_Request= ECTGlobalDll.InitializeModule.FAIL_RET;
        try
        {
            //'' Update Database with SqlDataAdapter
            daStudents_Request.Update(dsStudents_Request, TableName);
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
            FindInMultiPKey(iSerial);
            if ((Students_RequestDataRow != null))
            {
                Students_RequestDataRow.Delete();
                CommitStudents_Request();
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
            if (Students_RequestDataRow[LibraryMOD.GetFieldName(iSerialFN)] == System.DBNull.Value)
            {
                iSerial = 0;
            }
            else
            {
                iSerial = (int)Students_RequestDataRow[LibraryMOD.GetFieldName(iSerialFN)];
            }
            if (Students_RequestDataRow[LibraryMOD.GetFieldName(sStudentNoFN)] == System.DBNull.Value)
            {
                sStudentNo = "";
            }
            else
            {
                sStudentNo = (string)Students_RequestDataRow[LibraryMOD.GetFieldName(sStudentNoFN)];
            }
            if (Students_RequestDataRow[LibraryMOD.GetFieldName(bStatusFN)] == System.DBNull.Value)
            {
                bStatus = 0;
            }
            else
            {
                bStatus = (int)Students_RequestDataRow[LibraryMOD.GetFieldName(bStatusFN)];
            }
            if (Students_RequestDataRow[LibraryMOD.GetFieldName(bReasonFN)] == System.DBNull.Value)
            {
                bReason = 0;
            }
            else
            {
                bReason = (int)Students_RequestDataRow[LibraryMOD.GetFieldName(bReasonFN)];
            }
            if (Students_RequestDataRow[LibraryMOD.GetFieldName(bSubReasonFN)] == System.DBNull.Value)
            {
                bSubReason = 0;
            }
            else
            {
                bSubReason = (int)Students_RequestDataRow[LibraryMOD.GetFieldName(bSubReasonFN)];
            }
            if (Students_RequestDataRow[LibraryMOD.GetFieldName(sNoteFN)] == System.DBNull.Value)
            {
                sNote = "";
            }
            else
            {
                sNote = (string)Students_RequestDataRow[LibraryMOD.GetFieldName(sNoteFN)];
            }
            if (Students_RequestDataRow[LibraryMOD.GetFieldName(dDateFollowupFN)] == System.DBNull.Value)
            {
            }
            else
            {
                dDateFollowup = (DateTime)Students_RequestDataRow[LibraryMOD.GetFieldName(dDateFollowupFN)];
            }
            if (Students_RequestDataRow[LibraryMOD.GetFieldName(sFollowedByFN)] == System.DBNull.Value)
            {
                sFollowedBy = "";
            }
            else
            {
                sFollowedBy = (string)Students_RequestDataRow[LibraryMOD.GetFieldName(sFollowedByFN)];
            }
            if (Students_RequestDataRow[LibraryMOD.GetFieldName(dDateCheckedFN)] == System.DBNull.Value)
            {
            }
            else
            {
                dDateChecked = (DateTime)Students_RequestDataRow[LibraryMOD.GetFieldName(dDateCheckedFN)];
            }
            if (Students_RequestDataRow[LibraryMOD.GetFieldName(sCheckedByFN)] == System.DBNull.Value)
            {
                sCheckedBy = "";
            }
            else
            {
                sCheckedBy = (string)Students_RequestDataRow[LibraryMOD.GetFieldName(sCheckedByFN)];
            }
            if (Students_RequestDataRow[LibraryMOD.GetFieldName(bFollowStatusFN)] == System.DBNull.Value)
            {
                bFollowStatus = 0;
            }
            else
            {
                bFollowStatus = (int)Students_RequestDataRow[LibraryMOD.GetFieldName(bFollowStatusFN)];
            }
            if (Students_RequestDataRow[LibraryMOD.GetFieldName(iTRKTimesFN)] == System.DBNull.Value)
            {
                iTRKTimes = 0;
            }
            else
            {
                iTRKTimes = (int)Students_RequestDataRow[LibraryMOD.GetFieldName(iTRKTimesFN)];
            }
            if (Students_RequestDataRow[LibraryMOD.GetFieldName(isCreatedFN)] == System.DBNull.Value)
            {
                isCreated = "";
            }
            else
            {
                isCreated = (string)Students_RequestDataRow[LibraryMOD.GetFieldName(isCreatedFN)];
            }
            if (Students_RequestDataRow[LibraryMOD.GetFieldName(dateCreatedFN)] == System.DBNull.Value)
            {
            }
            else
            {
                dateCreated = (DateTime)Students_RequestDataRow[LibraryMOD.GetFieldName(dateCreatedFN)];
            }
            if (Students_RequestDataRow[LibraryMOD.GetFieldName(sUserCreatedFN)] == System.DBNull.Value)
            {
                sUserCreated = "";
            }
            else
            {
                sUserCreated = (string)Students_RequestDataRow[LibraryMOD.GetFieldName(sUserCreatedFN)];
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
    public int FindInMultiPKey(int PKiSerial)
    {
        //FindInMultiPKey= ECTGlobalDll.InitializeModule.FAIL_RET;
        try
        {
            //' Create an array for the key values to find.
            object[] findTheseVals = new object[1];
            //' Set the values of the keys to find.
            findTheseVals[0] = PKiSerial;
            Students_RequestDataRow = dsStudents_Request.Tables[TableName].Rows.Find(findTheseVals);
            if ((Students_RequestDataRow != null))
            {
                lngCurRow = dsStudents_Request.Tables[TableName].Rows.IndexOf(Students_RequestDataRow);
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
            lngCurRow = dsStudents_Request.Tables[TableName].Rows.Count - 1; //'Zero based index
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
            lngCurRow = Math.Min(lngCurRow + 1, dsStudents_Request.Tables[TableName].Rows.Count - 1);
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
            if (lngCurRow >= 0 & dsStudents_Request.Tables[TableName].Rows.Count > 0)
            {
                Students_RequestDataRow = dsStudents_Request.Tables[TableName].Rows[lngCurRow];
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
            daStudents_Request.RowUpdating += new SqlRowUpdatingEventHandler(OnRowUpdating);
            daStudents_Request.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
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
            daStudents_Request.RowUpdating -= new SqlRowUpdatingEventHandler(OnRowUpdating);
            daStudents_Request.RowUpdated -= new SqlRowUpdatedEventHandler(OnRowUpdated);
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
