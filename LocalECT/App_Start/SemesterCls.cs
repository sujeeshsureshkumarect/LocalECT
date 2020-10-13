using System;
using System.Data;
using System.Configuration;
//////using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
////using System.Xml.Linq;
using System.Collections.Generic;
using ECTGlobalDll;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
public class Semesters
{
    //Creation Date: 18/04/2010 07:04:53 م
    //Programmer Name : hazem
    //-----Decleration --------------
    #region "Decleration"
    private int m_AcademicYear;
    private int m_Semester;
    private int m_Term;
    private int m_RegistrationStartDate;
    private int m_RegistrationEndDate;
    private int m_SemesterStartDate;
    private int m_SemesterEndDate;
    private int m_Period;
    private int m_IsApplyRules;
    private int m_AttendanceDaysAllowed;
    private string m_ShortDesc;
    private string m_LongDesc;
    private int m_CreationUserID;
    private DateTime m_CreationDate;
    private int m_LastUpdateUserID;
    private DateTime m_LastUpdateDate;
    private string m_PCName;
    private string m_NetUserName;
    #endregion
    #region "Puplic Properties"
    //'-----------------------------------------------------
    public int AcademicYear
    {
        get { return m_AcademicYear; }
        set { m_AcademicYear = value; }
    }
    public int Semester
    {
        get { return m_Semester; }
        set { m_Semester = value; }
    }
    public int Term
    {
        get { return m_Term; }
        set { m_Term = value; }
    }
    public int RegistrationStartDate
    {
        get { return m_RegistrationStartDate; }
        set { m_RegistrationStartDate = value; }
    }
    public int RegistrationEndDate
    {
        get { return m_RegistrationEndDate; }
        set { m_RegistrationEndDate = value; }
    }
    public int SemesterStartDate
    {
        get { return m_SemesterStartDate; }
        set { m_SemesterStartDate = value; }
    }
    public int SemesterEndDate
    {
        get { return m_SemesterEndDate; }
        set { m_SemesterEndDate = value; }
    }
    public int Period
    {
        get { return m_Period; }
        set { m_Period = value; }
    }
    public int IsApplyRules
    {
        get { return m_IsApplyRules; }
        set { m_IsApplyRules = value; }
    }
    public int AttendanceDaysAllowed
    {
        get { return m_AttendanceDaysAllowed; }
        set { m_AttendanceDaysAllowed = value; }
    }
    public string ShortDesc
    {
        get { return m_ShortDesc; }
        set { m_ShortDesc = value; }
    }
    public string LongDesc
    {
        get { return m_LongDesc; }
        set { m_LongDesc = value; }
    }
    public int CreationUserID
    {
        get { return m_CreationUserID; }
        set { m_CreationUserID = value; }
    }
    public DateTime CreationDate
    {
        get { return m_CreationDate; }
        set { m_CreationDate = value; }
    }
    public int LastUpdateUserID
    {
        get { return m_LastUpdateUserID; }
        set { m_LastUpdateUserID = value; }
    }
    public DateTime LastUpdateDate
    {
        get { return m_LastUpdateDate; }
        set { m_LastUpdateDate = value; }
    }
    public string PCName
    {
        get { return m_PCName; }
        set { m_PCName = value; }
    }
    public string NetUserName
    {
        get { return m_NetUserName; }
        set { m_NetUserName = value; }
    }
    #endregion
    //'-----------------------------------------------------
    public Semesters()
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
public class SemesterDAL : Semesters
{
    #region "Decleration"
    private string m_TableName;
    private string m_AcademicYearFN;
    private string m_SemesterFN;
    private string m_TermFN;
    private string m_RegistrationStartDateFN;
    private string m_RegistrationEndDateFN;
    private string m_SemesterStartDateFN;
    private string m_SemesterEndDateFN;
    private string m_PeriodFN;
    private string m_IsApplyRulesFN;
    private string m_AttendanceDaysAllowedFN;
    private string m_ShortDescFN;
    private string m_LongDescFN;
    private string m_CreationUserIDFN;
    private string m_CreationDateFN;
    private string m_LastUpdateUserIDFN;
    private string m_LastUpdateDateFN;
    private string m_PCNameFN;
    private string m_NetUserNameFN;
    #endregion
    //'-----------------------------------------------------
    #region "Puplic Properties"
    public string TableName
    {
        get { return m_TableName; }
        set { m_TableName = value; }
    }
    public string AcademicYearFN
    {
        get { return m_AcademicYearFN; }
        set { m_AcademicYearFN = value; }
    }
    public string SemesterFN
    {
        get { return m_SemesterFN; }
        set { m_SemesterFN = value; }
    }
    public string TermFN
    {
        get { return m_TermFN; }
        set { m_TermFN = value; }
    }
    public string RegistrationStartDateFN
    {
        get { return m_RegistrationStartDateFN; }
        set { m_RegistrationStartDateFN = value; }
    }
    public string RegistrationEndDateFN
    {
        get { return m_RegistrationEndDateFN; }
        set { m_RegistrationEndDateFN = value; }
    }
    public string SemesterStartDateFN
    {
        get { return m_SemesterStartDateFN; }
        set { m_SemesterStartDateFN = value; }
    }
    public string SemesterEndDateFN
    {
        get { return m_SemesterEndDateFN; }
        set { m_SemesterEndDateFN = value; }
    }
    public string PeriodFN
    {
        get { return m_PeriodFN; }
        set { m_PeriodFN = value; }
    }
    public string IsApplyRulesFN
    {
        get { return m_IsApplyRulesFN; }
        set { m_IsApplyRulesFN = value; }
    }
    public string AttendanceDaysAllowedFN
    {
        get { return m_AttendanceDaysAllowedFN; }
        set { m_AttendanceDaysAllowedFN = value; }
    }
    public string ShortDescFN
    {
        get { return m_ShortDescFN; }
        set { m_ShortDescFN = value; }
    }
    public string LongDescFN
    {
        get { return m_LongDescFN; }
        set { m_LongDescFN = value; }
    }
    public string CreationUserIDFN
    {
        get { return m_CreationUserIDFN; }
        set { m_CreationUserIDFN = value; }
    }
    public string CreationDateFN
    {
        get { return m_CreationDateFN; }
        set { m_CreationDateFN = value; }
    }
    public string LastUpdateUserIDFN
    {
        get { return m_LastUpdateUserIDFN; }
        set { m_LastUpdateUserIDFN = value; }
    }
    public string LastUpdateDateFN
    {
        get { return m_LastUpdateDateFN; }
        set { m_LastUpdateDateFN = value; }
    }
    public string PCNameFN
    {
        get { return m_PCNameFN; }
        set { m_PCNameFN = value; }
    }
    public string NetUserNameFN
    {
        get { return m_NetUserNameFN; }
        set { m_NetUserNameFN = value; }
    }
    #endregion
    //================End Properties ===================
    #region "Data Access Layer"
    //-----Get SQl Function ---------------------------------
    public string GetSQL()
    {
        string sSQL = "";
        try
        {
            sSQL = "SELECT ";
            sSQL += AcademicYearFN;
            sSQL += " , " + SemesterFN;
            sSQL += " , " + TermFN;
            sSQL += " , " + RegistrationStartDateFN;
            sSQL += " , " + RegistrationEndDateFN;
            sSQL += " , " + SemesterStartDateFN;
            sSQL += " , " + SemesterEndDateFN;
            sSQL += " , " + PeriodFN;
            sSQL += " , " + IsApplyRulesFN;
            sSQL += " , " + AttendanceDaysAllowedFN;
            sSQL += " , " + ShortDescFN;
            sSQL += " , " + LongDescFN;
            sSQL += " , " + CreationUserIDFN;
            sSQL += " , " + CreationDateFN;
            sSQL += " , " + LastUpdateUserIDFN;
            sSQL += " , " + LastUpdateDateFN;
            sSQL += " , " + PCNameFN;
            sSQL += " , " + NetUserNameFN;
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

    public string GetListSQL(string sWhere)
    {
        string sSQL = "";
        try
        {
            sSQL = "SELECT ";
            sSQL += TermFN;
            sSQL += " , " + ShortDescFN;
            sSQL += " , " + LongDescFN;
            sSQL += "  FROM " + m_TableName;
            sSQL += sWhere;
            sSQL += " Order By " + AcademicYearFN + " DESC ," + SemesterFN + " DESC ";

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

    public string GetListSQLAcademicYear(string sWhere)
    {
        string sSQL = "";
        try
        {
            sSQL = "SELECT Distinct ";
            sSQL += AcademicYearFN;
            sSQL += " , convert( varchar(10) , " + AcademicYearFN + ") + '/' + convert(varchar(10) , " + AcademicYearFN + " + 1) As AcademicYearText ";
            sSQL += "  FROM " + m_TableName;
            sSQL += sWhere;
            sSQL += " Order By " + AcademicYearFN + " Desc";

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
            sSQL += AcademicYearFN;
            sSQL += " , " + SemesterFN;
            sSQL += " , " + TermFN;
            sSQL += " , " + RegistrationStartDateFN;
            sSQL += " , " + RegistrationEndDateFN;
            sSQL += " , " + SemesterStartDateFN;
            sSQL += " , " + SemesterEndDateFN;
            sSQL += " , " + PeriodFN;
            sSQL += " , " + IsApplyRulesFN;
            sSQL += " , " + AttendanceDaysAllowedFN;
            sSQL += " , " + ShortDescFN;
            sSQL += " , " + LongDescFN;
            sSQL += " , " + CreationUserIDFN;
            sSQL += " , " + CreationDateFN;
            sSQL += " , " + LastUpdateUserIDFN;
            sSQL += " , " + LastUpdateDateFN;
            sSQL += " , " + PCNameFN;
            sSQL += " , " + NetUserNameFN;
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
            sSQL += LibraryMOD.GetFieldName(AcademicYearFN) + "=@AcademicYear";
            sSQL += " , " + LibraryMOD.GetFieldName(SemesterFN) + "=@Semester";
            sSQL += " , " + LibraryMOD.GetFieldName(TermFN) + "=@Term";
            sSQL += " , " + LibraryMOD.GetFieldName(RegistrationStartDateFN) + "=@RegistrationStartDate";
            sSQL += " , " + LibraryMOD.GetFieldName(RegistrationEndDateFN) + "=@RegistrationEndDate";
            sSQL += " , " + LibraryMOD.GetFieldName(SemesterStartDateFN) + "=@SemesterStartDate";
            sSQL += " , " + LibraryMOD.GetFieldName(SemesterEndDateFN) + "=@SemesterEndDate";
            sSQL += " , " + LibraryMOD.GetFieldName(PeriodFN) + "=@Period";
            sSQL += " , " + LibraryMOD.GetFieldName(IsApplyRulesFN) + "=@IsApplyRules";
            sSQL += " , " + LibraryMOD.GetFieldName(AttendanceDaysAllowedFN) + "=@AttendanceDaysAllowed";
            sSQL += " , " + LibraryMOD.GetFieldName(ShortDescFN) + "=@ShortDesc";
            sSQL += " , " + LibraryMOD.GetFieldName(LongDescFN) + "=@LongDesc";
            sSQL += " , " + LibraryMOD.GetFieldName(CreationUserIDFN) + "=@CreationUserID";
            sSQL += " , " + LibraryMOD.GetFieldName(CreationDateFN) + "=@CreationDate";
            sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateUserIDFN) + "=@LastUpdateUserID";
            sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateDateFN) + "=@LastUpdateDate";
            sSQL += " , " + LibraryMOD.GetFieldName(PCNameFN) + "=@PCName";
            sSQL += " , " + LibraryMOD.GetFieldName(NetUserNameFN) + "=@NetUserName";
            sSQL += " WHERE ";
            sSQL += LibraryMOD.GetFieldName(AcademicYearFN) + "=@AcademicYear";
            sSQL += " And " + LibraryMOD.GetFieldName(SemesterFN) + "=@Semester";
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
            sSQL += LibraryMOD.GetFieldName(AcademicYearFN);
            sSQL += " , " + LibraryMOD.GetFieldName(SemesterFN);
            sSQL += " , " + LibraryMOD.GetFieldName(TermFN);
            sSQL += " , " + LibraryMOD.GetFieldName(RegistrationStartDateFN);
            sSQL += " , " + LibraryMOD.GetFieldName(RegistrationEndDateFN);
            sSQL += " , " + LibraryMOD.GetFieldName(SemesterStartDateFN);
            sSQL += " , " + LibraryMOD.GetFieldName(SemesterEndDateFN);
            sSQL += " , " + LibraryMOD.GetFieldName(PeriodFN);
            sSQL += " , " + LibraryMOD.GetFieldName(IsApplyRulesFN);
            sSQL += " , " + LibraryMOD.GetFieldName(AttendanceDaysAllowedFN);
            sSQL += " , " + LibraryMOD.GetFieldName(ShortDescFN);
            sSQL += " , " + LibraryMOD.GetFieldName(LongDescFN);
            sSQL += " , " + LibraryMOD.GetFieldName(CreationUserIDFN);
            sSQL += " , " + LibraryMOD.GetFieldName(CreationDateFN);
            sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateUserIDFN);
            sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateDateFN);
            sSQL += " , " + LibraryMOD.GetFieldName(PCNameFN);
            sSQL += " , " + LibraryMOD.GetFieldName(NetUserNameFN);
            sSQL += ")";
            sSQL += " VALUES ";
            sSQL += "( ";
            sSQL += " @AcademicYear";
            sSQL += " ,@Semester";
            sSQL += " ,@Term";
            sSQL += " ,@RegistrationStartDate";
            sSQL += " ,@RegistrationEndDate";
            sSQL += " ,@SemesterStartDate";
            sSQL += " ,@SemesterEndDate";
            sSQL += " ,@Period";
            sSQL += " ,@IsApplyRules";
            sSQL += " ,@AttendanceDaysAllowed";
            sSQL += " ,@ShortDesc";
            sSQL += " ,@LongDesc";
            sSQL += " ,@CreationUserID";
            sSQL += " ,@CreationDate";
            sSQL += " ,@LastUpdateUserID";
            sSQL += " ,@LastUpdateDate";
            sSQL += " ,@PCName";
            sSQL += " ,@NetUserName";
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
            sSQL += LibraryMOD.GetFieldName(AcademicYearFN) + "=@AcademicYear";
            sSQL += " And " + LibraryMOD.GetFieldName(SemesterFN) + "=@Semester";
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

    public SemesterDAL()
    {
        try
        {
            this.TableName = "Reg_Semester";
            this.AcademicYearFN = m_TableName + ".AcademicYear";
            this.SemesterFN = m_TableName + ".Semester";
            this.TermFN = m_TableName + ".Term";
            this.RegistrationStartDateFN = m_TableName + ".RegistrationStartDate";
            this.RegistrationEndDateFN = m_TableName + ".RegistrationEndDate";
            this.SemesterStartDateFN = m_TableName + ".SemesterStartDate";
            this.SemesterEndDateFN = m_TableName + ".SemesterEndDate";
            this.PeriodFN = m_TableName + ".Period";
            this.IsApplyRulesFN = m_TableName + ".IsApplyRules";
            this.AttendanceDaysAllowedFN = m_TableName + ".AttendanceDaysAllowed";
            this.ShortDescFN = m_TableName + ".ShortDesc";
            this.LongDescFN = m_TableName + ".LongDesc";
            this.CreationUserIDFN = m_TableName + ".CreationUserID";
            this.CreationDateFN = m_TableName + ".CreationDate";
            this.LastUpdateUserIDFN = m_TableName + ".LastUpdateUserID";
            this.LastUpdateDateFN = m_TableName + ".LastUpdateDate";
            this.PCNameFN = m_TableName + ".PCName";
            this.NetUserNameFN = m_TableName + ".NetUserName";
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
    }

    public string GetSemesterShortDesc(InitializeModule.EnumCampus Campus, int iTerm)
    {
        string functionReturnValue = ""  ;
        try
        {
            string sSQL = null;
            Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
          
            SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
          

            //Dim CommSQL As New SqlClient.SQLDbCommand(sSQL, conn) 
            SqlCommand CommSQL = new SqlCommand();
           
            
            sSQL = "SELECT " + ShortDescFN  + " FROM " + TableName;
            sSQL += " WHERE " + TermFN + "=" + iTerm;
           

            CommSQL.CommandText = sSQL;
            CommSQL.Connection = Conn;
            Conn.Open();
            SqlDataReader reader = CommSQL.ExecuteReader(CommandBehavior.CloseConnection);

            while (reader.Read())
            {
                functionReturnValue = Convert.ToString ("" + reader.GetValue (0)) ;
            }
            

        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {

        }
        return functionReturnValue;
    }
    public int GetTermID_From_sTerm(InitializeModule.EnumCampus Campus, string sTerm)
    {
        int functionReturnValue = 0;
        try
        {
            string sSQL = null;
            Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);

            SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());


            //Dim CommSQL As New SqlClient.SQLDbCommand(sSQL, conn) 
            SqlCommand CommSQL = new SqlCommand();


            sSQL = "SELECT " + TermFN + " FROM " + TableName;
            sSQL += " WHERE sTerm ='" + sTerm + "'";


            CommSQL.CommandText = sSQL;
            CommSQL.Connection = Conn;
            Conn.Open();
            SqlDataReader reader = CommSQL.ExecuteReader(CommandBehavior.CloseConnection);

            while (reader.Read())
            {
                functionReturnValue = Convert.ToInt32 ("0" + reader.GetValue(0));
            }


        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {

        }
        return functionReturnValue;
    }
    public DateTime GetSemesterStartDate(InitializeModule.EnumCampus Campus, int iAcademicYear, int iSemester)
    {
        DateTime functionReturnValue = DateTime.MinValue  ;
        try
        {
            string sSQL = null;
            Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
          
            SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
          

            //Dim CommSQL As New SqlClient.SQLDbCommand(sSQL, conn) 
            SqlCommand CommSQL = new SqlCommand();
           
            
            sSQL = "SELECT " + SemesterStartDateFN + " FROM " + TableName;
            sSQL += " WHERE " + AcademicYearFN + "=" + iAcademicYear;
            sSQL += " AND " + SemesterFN + "=" + iSemester;

            CommSQL.CommandText = sSQL;
            CommSQL.Connection = Conn;
            Conn.Open();
            SqlDataReader reader = CommSQL.ExecuteReader(CommandBehavior.CloseConnection);

            while (reader.Read())
            {
                functionReturnValue = Convert.ToDateTime (LibraryMOD.NumberToDate ( (int) reader.GetValue (0))) ;
            }
            

        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {

        }
        return functionReturnValue;
    }
    public List<Semesters> GetSemester(InitializeModule.EnumCampus Campus, string sCondition)
    {
        //' returns a list of Classes instances based on the
        //' data in the Semester
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
        List<Semesters> results = new List<Semesters>();
        try
        {

            Semesters mySemester = new Semesters();
            //if (isDeafaultIncluded)
            //{
            //    //Change the code here
            //    mySemester.AcademicYear = 0;
            //    mySemester.Semester = 0;
            //    mySemester.Term = 0;
            //    results.Add(mySemester);
            //}
            while (reader.Read())
            {
                mySemester = new Semesters();
                if (reader[LibraryMOD.GetFieldName(AcademicYearFN)].Equals(DBNull.Value))
                {
                    mySemester.AcademicYear = 0;
                }
                else
                {
                    mySemester.AcademicYear = int.Parse(reader[LibraryMOD.GetFieldName(AcademicYearFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(SemesterFN)].Equals(DBNull.Value))
                {
                    mySemester.Semester = 0;
                }
                else
                {
                    mySemester.Semester = int.Parse(reader[LibraryMOD.GetFieldName(SemesterFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(TermFN)].Equals(DBNull.Value))
                {
                    mySemester.Term = 0;
                }
                else
                {
                    mySemester.Term = int.Parse(reader[LibraryMOD.GetFieldName(TermFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(RegistrationStartDateFN)].Equals(DBNull.Value))
                {
                    mySemester.RegistrationStartDate = 0;
                }
                else
                {
                    mySemester.RegistrationStartDate = int.Parse(reader[LibraryMOD.GetFieldName(RegistrationStartDateFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(RegistrationEndDateFN)].Equals(DBNull.Value))
                {
                    mySemester.RegistrationEndDate = 0;
                }
                else
                {
                    mySemester.RegistrationEndDate = int.Parse(reader[LibraryMOD.GetFieldName(RegistrationEndDateFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(SemesterStartDateFN)].Equals(DBNull.Value))
                {
                    mySemester.SemesterStartDate = 0;
                }
                else
                {
                    mySemester.SemesterStartDate = int.Parse(reader[LibraryMOD.GetFieldName(SemesterStartDateFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(SemesterEndDateFN)].Equals(DBNull.Value))
                {
                    mySemester.SemesterEndDate = 0;
                }
                else
                {
                    mySemester.SemesterEndDate = int.Parse(reader[LibraryMOD.GetFieldName(SemesterEndDateFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(PeriodFN)].Equals(DBNull.Value))
                {
                    mySemester.Period = 0;
                }
                else
                {
                    mySemester.Period = int.Parse(reader[LibraryMOD.GetFieldName(PeriodFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(IsApplyRulesFN)].Equals(DBNull.Value))
                {
                    mySemester.IsApplyRules = 0;
                }
                else
                {
                    mySemester.IsApplyRules = int.Parse(reader[LibraryMOD.GetFieldName(IsApplyRulesFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(AttendanceDaysAllowedFN)].Equals(DBNull.Value))
                {
                    mySemester.AttendanceDaysAllowed = 0;
                }
                else
                {
                    mySemester.AttendanceDaysAllowed = int.Parse(reader[LibraryMOD.GetFieldName(AttendanceDaysAllowedFN)].ToString());
                }
                mySemester.ShortDesc = reader[LibraryMOD.GetFieldName(ShortDescFN)].ToString();
                mySemester.LongDesc = reader[LibraryMOD.GetFieldName(LongDescFN)].ToString();
                if (reader[LibraryMOD.GetFieldName(CreationUserIDFN)].Equals(DBNull.Value))
                {
                    mySemester.CreationUserID = 0;
                }
                else
                {
                    mySemester.CreationUserID = int.Parse(reader[LibraryMOD.GetFieldName(CreationUserIDFN)].ToString());
                }
                if (!reader[LibraryMOD.GetFieldName(CreationDateFN)].Equals(DBNull.Value))
                {
                    mySemester.CreationDate = DateTime.Parse(reader[LibraryMOD.GetFieldName(CreationDateFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(LastUpdateUserIDFN)].Equals(DBNull.Value))
                {
                    mySemester.LastUpdateUserID = 0;
                }
                else
                {
                    mySemester.LastUpdateUserID = int.Parse(reader[LibraryMOD.GetFieldName(LastUpdateUserIDFN)].ToString());
                }
                if (!reader[LibraryMOD.GetFieldName(LastUpdateDateFN)].Equals(DBNull.Value))
                {
                    mySemester.LastUpdateDate = DateTime.Parse(reader[LibraryMOD.GetFieldName(LastUpdateDateFN)].ToString());
                }
                mySemester.PCName = reader[LibraryMOD.GetFieldName(PCNameFN)].ToString();
                mySemester.NetUserName = reader[LibraryMOD.GetFieldName(NetUserNameFN)].ToString();
                results.Add(mySemester);
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
    public List<Semesters> GetTerms(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
    {

        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        string sSQL = GetListSQL(sCondition);

        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        SqlCommand Cmd = new SqlCommand(sSQL, Conn);
        Conn.Open();
        SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
        List<Semesters> results = new List<Semesters>();
        try
        {

            Semesters mySemester = new Semesters();
            if (isDeafaultIncluded)
            {
                mySemester.Term = 0;
                mySemester.ShortDesc = "Select Term ...";
                mySemester.LongDesc = "Select Term ...";
                results.Add(mySemester);
            }
            while (reader.Read())
            {
                mySemester = new Semesters();

                if (reader[LibraryMOD.GetFieldName(TermFN)].Equals(DBNull.Value))
                {
                    mySemester.Term = 0;
                }
                else
                {
                    mySemester.Term = int.Parse(reader[LibraryMOD.GetFieldName(TermFN)].ToString());
                }

                mySemester.ShortDesc = reader[LibraryMOD.GetFieldName(ShortDescFN)].ToString();
                mySemester.LongDesc = reader[LibraryMOD.GetFieldName(LongDescFN)].ToString();

                results.Add(mySemester);
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
    public List<Semesters> GetAcademicYear(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
    {

        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        string sSQL = GetListSQLAcademicYear(sCondition);

        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        SqlCommand Cmd = new SqlCommand(sSQL, Conn);
        Conn.Open();
        SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
        List<Semesters> results = new List<Semesters>();
        try
        {

            Semesters mySemester = new Semesters();
            if (isDeafaultIncluded)
            {
                mySemester.AcademicYear = 0;
                mySemester.ShortDesc = "Select Academic Year ...";

                results.Add(mySemester);
            }
            while (reader.Read())
            {
                mySemester = new Semesters();

                if (reader[LibraryMOD.GetFieldName(AcademicYearFN)].Equals(DBNull.Value))
                {
                    mySemester.AcademicYear = 0;
                }
                else
                {
                    mySemester.AcademicYear = int.Parse(reader[LibraryMOD.GetFieldName(AcademicYearFN)].ToString());
                }

                mySemester.ShortDesc = reader["AcademicYearText"].ToString();

                results.Add(mySemester);
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
    public int UpdateSemester(InitializeModule.EnumCampus Campus, int iMode, int AcademicYear, int Semester, int Term, int RegistrationStartDate, int RegistrationEndDate, int SemesterStartDate, int SemesterEndDate, int Period, int IsApplyRules, int AttendanceDaysAllowed, string ShortDesc, string LongDesc, int CreationUserID, DateTime CreationDate, int LastUpdateUserID, DateTime LastUpdateDate, string PCName, string NetUserName)
    {
        int iEffected = 0;
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        try
        {
            Conn.Open();
            string sql = "";
            Semesters theSemester = new Semesters();
            //'Updates the  table
            switch (iMode)
            {
                case (int)InitializeModule.enumModes.EditMode:
                    sql = GetUpdateCommand();
                    break;
                case (int)InitializeModule.enumModes.NewMode:
                    sql = GetInsertCommand();
                    break;
            }
            SqlCommand Cmd = new SqlCommand(sql, Conn);
            Cmd.Parameters.Add(new SqlParameter("@AcademicYear", AcademicYear));
            Cmd.Parameters.Add(new SqlParameter("@Semester", Semester));
            Cmd.Parameters.Add(new SqlParameter("@Term", Term));
            Cmd.Parameters.Add(new SqlParameter("@RegistrationStartDate", RegistrationStartDate));
            Cmd.Parameters.Add(new SqlParameter("@RegistrationEndDate", RegistrationEndDate));
            Cmd.Parameters.Add(new SqlParameter("@SemesterStartDate", SemesterStartDate));
            Cmd.Parameters.Add(new SqlParameter("@SemesterEndDate", SemesterEndDate));
            Cmd.Parameters.Add(new SqlParameter("@Period", Period));
            Cmd.Parameters.Add(new SqlParameter("@IsApplyRules", IsApplyRules));
            Cmd.Parameters.Add(new SqlParameter("@AttendanceDaysAllowed", AttendanceDaysAllowed));
            Cmd.Parameters.Add(new SqlParameter("@ShortDesc", ShortDesc));
            Cmd.Parameters.Add(new SqlParameter("@LongDesc", LongDesc));
            Cmd.Parameters.Add(new SqlParameter("@CreationUserID", CreationUserID));
            Cmd.Parameters.Add(new SqlParameter("@CreationDate", CreationDate));
            Cmd.Parameters.Add(new SqlParameter("@LastUpdateUserID", LastUpdateUserID));
            Cmd.Parameters.Add(new SqlParameter("@LastUpdateDate", LastUpdateDate));
            Cmd.Parameters.Add(new SqlParameter("@PCName", PCName));
            Cmd.Parameters.Add(new SqlParameter("@NetUserName", NetUserName));
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
    public int DeleteSemester(InitializeModule.EnumCampus Campus, string AcademicYear, string Semester)
    {
        int iEffected = 0;
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        try
        {
            string sSQL = GetDeleteCommand();
            //sSQL += sCondition;
            SqlCommand Cmd = new SqlCommand(sSQL, Conn);
            Cmd.Parameters.Add(new SqlParameter("@AcademicYear", AcademicYear));
            Cmd.Parameters.Add(new SqlParameter("@Semester", Semester));
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
    public DataView GetDataView(string sCondition)
    {
        DataTable dt = new DataTable("Terms");
        DataView dv = new DataView();
        List<Semesters> mySemesters = new List<Semesters>();
        try
        {
            mySemesters = GetTerms(InitializeModule.EnumCampus.ECTNew, sCondition, false);
            DataColumn col1 = new DataColumn("Term", Type.GetType("int"));
            dt.Columns.Add(col1);
            DataColumn col2 = new DataColumn("ShortDesc", Type.GetType("string"));
            dt.Columns.Add(col2);
            DataColumn col3 = new DataColumn("LongDesc", Type.GetType("string"));
            dt.Columns.Add(col3);
            dt.Constraints.Add(new UniqueConstraint(col1));

            DataRow dr;
            for (int i = 0; i < mySemesters.Count; i++)
            {
                dr = dt.NewRow();
                dr[1] = mySemesters[i].Term;
                dr[2] = mySemesters[i].ShortDesc;
                dr[3] = mySemesters[i].LongDesc;
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
            mySemesters.Clear();
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
            sSQL += AcademicYearFN;
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
public class SemesterCls : SemesterDAL
{
    #region "Decleration"
    private int m_lngCurRow = 0;
    public SqlDataAdapter daSemester;
    private DataSet m_dsSemester;
    public DataRow SemesterDataRow;
    #endregion
    #region "Puplic Properties"
    public DataSet dsSemester
    {
        get { return m_dsSemester; }
        set { m_dsSemester = value; }
    }
    //-----------------------------------------------------
    public int lngCurRow
    {
        get { return m_lngCurRow; }
        set { m_lngCurRow = value; }
    }
    #endregion
    public SemesterCls()
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
    //-------Get DataAdapter  -----------------------------
    #region "DataAdapter"
    public virtual SqlDataAdapter GetSemesterDataAdapter(string sCondition, SqlConnection con)
    {
        string sSQL = "";
        try
        {
            sSQL = GetSQL();
            sSQL += " " + sCondition;
            //-----------------------------------------
            daSemester = new SqlDataAdapter(sSQL, con);
            // Create command builder. This line automatically generates the update commands for you, so you don't
            // have to provide or create your own.
            SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daSemester);
            //Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
            // key + unique key information to be retrieved unless AddWithKey is specified.
            daSemester.MissingSchemaAction = MissingSchemaAction.AddWithKey;
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return daSemester;
    }
    public virtual SqlDataAdapter GetSemesterDataAdapter(SqlConnection con)
    {
        try
        {
            daSemester = new SqlDataAdapter();
            //''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
            //'' key + unique key information to be retrieved unless AddWithKey is specified.
            daSemester.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            //-----------------------------------------
            SqlParameter Parmeter = default(SqlParameter);
            //[SELECT COMMAND]
            SqlCommand cmdSemester;
            cmdSemester = new SqlCommand(GetSelectCommand(), con);
            //'cmdRolePermission.Parameters.Add("@AcademicYear", SqlDbType.Int, 4, "AcademicYear" );
            //'cmdRolePermission.Parameters.Add("@Semester", SqlDbType.Int, 4, "Semester" );
            daSemester.SelectCommand = cmdSemester;
            //'Add Handlers
            //'RowUpdating,RowUpdated
            AddDAEventHandler();
            //'[UPDATE COMMAND].
            cmdSemester = new SqlCommand(GetUpdateCommand(), con);
            //'Delete PK Parameteres from here. b/c its declared below
            cmdSemester.Parameters.Add("@AcademicYear", SqlDbType.Int, 4, LibraryMOD.GetFieldName(AcademicYearFN));
            cmdSemester.Parameters.Add("@Semester", SqlDbType.Int, 4, LibraryMOD.GetFieldName(SemesterFN));
            cmdSemester.Parameters.Add("@Term", SqlDbType.Int, 4, LibraryMOD.GetFieldName(TermFN));
            cmdSemester.Parameters.Add("@RegistrationStartDate", SqlDbType.Int, 4, LibraryMOD.GetFieldName(RegistrationStartDateFN));
            cmdSemester.Parameters.Add("@RegistrationEndDate", SqlDbType.Int, 4, LibraryMOD.GetFieldName(RegistrationEndDateFN));
            cmdSemester.Parameters.Add("@SemesterStartDate", SqlDbType.Int, 4, LibraryMOD.GetFieldName(SemesterStartDateFN));
            cmdSemester.Parameters.Add("@SemesterEndDate", SqlDbType.Int, 4, LibraryMOD.GetFieldName(SemesterEndDateFN));
            cmdSemester.Parameters.Add("@Period", SqlDbType.Int, 4, LibraryMOD.GetFieldName(PeriodFN));
            cmdSemester.Parameters.Add("@IsApplyRules", SqlDbType.Int, 4, LibraryMOD.GetFieldName(IsApplyRulesFN));
            cmdSemester.Parameters.Add("@AttendanceDaysAllowed", SqlDbType.Int, 4, LibraryMOD.GetFieldName(AttendanceDaysAllowedFN));
            cmdSemester.Parameters.Add("@ShortDesc", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(ShortDescFN));
            cmdSemester.Parameters.Add("@LongDesc", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(LongDescFN));
            cmdSemester.Parameters.Add("@CreationUserID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(CreationUserIDFN));
            cmdSemester.Parameters.Add("@CreationDate", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(CreationDateFN));
            cmdSemester.Parameters.Add("@LastUpdateUserID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(LastUpdateUserIDFN));
            cmdSemester.Parameters.Add("@LastUpdateDate", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(LastUpdateDateFN));
            cmdSemester.Parameters.Add("@PCName", SqlDbType.NVarChar, 32, LibraryMOD.GetFieldName(PCNameFN));
            cmdSemester.Parameters.Add("@NetUserName", SqlDbType.NVarChar, 32, LibraryMOD.GetFieldName(NetUserNameFN));


            Parmeter = cmdSemester.Parameters.Add("@AcademicYear", SqlDbType.Int, 4, LibraryMOD.GetFieldName(AcademicYearFN));
            Parmeter = cmdSemester.Parameters.Add("@Semester", SqlDbType.Int, 4, LibraryMOD.GetFieldName(SemesterFN));
            Parmeter.SourceVersion = DataRowVersion.Original;
            //'Its should be none for batch updating
            //'UpdateCommand, InsertCommand, and DeleteCommand 
            //'should be set to None or OutputParameters
            daSemester.UpdateCommand = cmdSemester;
            daSemester.UpdateCommand.UpdatedRowSource = UpdateRowSource.None;
            //'-------------------------------------------------------------------------
            //'/INSERT COMMAND
            cmdSemester = new SqlCommand(GetInsertCommand(), con);
            cmdSemester.Parameters.Add("@AcademicYear", SqlDbType.Int, 4, LibraryMOD.GetFieldName(AcademicYearFN));
            cmdSemester.Parameters.Add("@Semester", SqlDbType.Int, 4, LibraryMOD.GetFieldName(SemesterFN));
            cmdSemester.Parameters.Add("@Term", SqlDbType.Int, 4, LibraryMOD.GetFieldName(TermFN));
            cmdSemester.Parameters.Add("@RegistrationStartDate", SqlDbType.Int, 4, LibraryMOD.GetFieldName(RegistrationStartDateFN));
            cmdSemester.Parameters.Add("@RegistrationEndDate", SqlDbType.Int, 4, LibraryMOD.GetFieldName(RegistrationEndDateFN));
            cmdSemester.Parameters.Add("@SemesterStartDate", SqlDbType.Int, 4, LibraryMOD.GetFieldName(SemesterStartDateFN));
            cmdSemester.Parameters.Add("@SemesterEndDate", SqlDbType.Int, 4, LibraryMOD.GetFieldName(SemesterEndDateFN));
            cmdSemester.Parameters.Add("@Period", SqlDbType.Int, 4, LibraryMOD.GetFieldName(PeriodFN));
            cmdSemester.Parameters.Add("@IsApplyRules", SqlDbType.Int, 4, LibraryMOD.GetFieldName(IsApplyRulesFN));
            cmdSemester.Parameters.Add("@AttendanceDaysAllowed", SqlDbType.Int, 4, LibraryMOD.GetFieldName(AttendanceDaysAllowedFN));
            cmdSemester.Parameters.Add("@ShortDesc", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(ShortDescFN));
            cmdSemester.Parameters.Add("@LongDesc", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(LongDescFN));
            cmdSemester.Parameters.Add("@CreationUserID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(CreationUserIDFN));
            cmdSemester.Parameters.Add("@CreationDate", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(CreationDateFN));
            cmdSemester.Parameters.Add("@LastUpdateUserID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(LastUpdateUserIDFN));
            cmdSemester.Parameters.Add("@LastUpdateDate", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(LastUpdateDateFN));
            cmdSemester.Parameters.Add("@PCName", SqlDbType.NVarChar, 32, LibraryMOD.GetFieldName(PCNameFN));
            cmdSemester.Parameters.Add("@NetUserName", SqlDbType.NVarChar, 32, LibraryMOD.GetFieldName(NetUserNameFN));
            Parmeter.SourceVersion = DataRowVersion.Current;
            daSemester.InsertCommand = cmdSemester;
            daSemester.InsertCommand.UpdatedRowSource = UpdateRowSource.None;
            //'------------------------
            //'/DELETE COMMAND
            cmdSemester = new SqlCommand(GetDeleteCommand(), con);
            Parmeter = cmdSemester.Parameters.Add("@AcademicYear", SqlDbType.Int, 4, LibraryMOD.GetFieldName(AcademicYearFN));
            Parmeter = cmdSemester.Parameters.Add("@Semester", SqlDbType.Int, 4, LibraryMOD.GetFieldName(SemesterFN));
            Parmeter.SourceVersion = DataRowVersion.Original;
            daSemester.DeleteCommand = cmdSemester;
            daSemester.DeleteCommand.UpdatedRowSource = UpdateRowSource.None;
            //'Batch Size
            //'Set the batch size.
            daSemester.UpdateBatchSize = InitializeModule.BATCH_SIZE;
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return daSemester;
    }
    //'-------SaveData  -----------------------------
    public int SaveData(int lFormMode)
    {
        //SaveData= ECTGlobalDll.InitializeModule.FAIL_RET;
        try
        {
            switch (lFormMode)
            {
                case (int)InitializeModule.enumModes.NewMode:
                    DataRow dr = default(DataRow);
                    dr = dsSemester.Tables[TableName].NewRow();
                    dr[LibraryMOD.GetFieldName(AcademicYearFN)] = AcademicYear;
                    dr[LibraryMOD.GetFieldName(SemesterFN)] = Semester;
                    dr[LibraryMOD.GetFieldName(TermFN)] = Term;
                    dr[LibraryMOD.GetFieldName(RegistrationStartDateFN)] = RegistrationStartDate;
                    dr[LibraryMOD.GetFieldName(RegistrationEndDateFN)] = RegistrationEndDate;
                    dr[LibraryMOD.GetFieldName(SemesterStartDateFN)] = SemesterStartDate;
                    dr[LibraryMOD.GetFieldName(SemesterEndDateFN)] = SemesterEndDate;
                    dr[LibraryMOD.GetFieldName(PeriodFN)] = Period;
                    dr[LibraryMOD.GetFieldName(IsApplyRulesFN)] = IsApplyRules;
                    dr[LibraryMOD.GetFieldName(AttendanceDaysAllowedFN)] = AttendanceDaysAllowed;
                    dr[LibraryMOD.GetFieldName(ShortDescFN)] = ShortDesc;
                    dr[LibraryMOD.GetFieldName(LongDescFN)] = LongDesc;
                    dr[LibraryMOD.GetFieldName(CreationUserIDFN)] = InitializeModule.gUserNo;
                    dr[LibraryMOD.GetFieldName(CreationDateFN)] = DateTime.Now; //' CreationDate
                    dr[LibraryMOD.GetFieldName(LastUpdateUserIDFN)] = InitializeModule.gUserNo;  //'LastUpdateUserID
                    dr[LibraryMOD.GetFieldName(LastUpdateDateFN)] = DateTime.Now; //'LastUpdateDate
                    dr[LibraryMOD.GetFieldName(PCNameFN)] = InitializeModule.gPCName;
                    dr[LibraryMOD.GetFieldName(NetUserNameFN)] = InitializeModule.gNetUserName;
                    dsSemester.Tables[TableName].Rows.Add(dr);
                    break;
                case (int)InitializeModule.enumModes.EditMode:
                    DataRow[] drAry = null;
                    drAry = dsSemester.Tables[TableName].Select(LibraryMOD.GetFieldName(AcademicYearFN) + "=" + AcademicYear + " AND " + LibraryMOD.GetFieldName(SemesterFN) + "=" + Semester);
                    //'its return array of rows and we can access the first by index 0
                    drAry[0][LibraryMOD.GetFieldName(AcademicYearFN)] = AcademicYear;
                    drAry[0][LibraryMOD.GetFieldName(SemesterFN)] = Semester;
                    drAry[0][LibraryMOD.GetFieldName(TermFN)] = Term;
                    drAry[0][LibraryMOD.GetFieldName(RegistrationStartDateFN)] = RegistrationStartDate;
                    drAry[0][LibraryMOD.GetFieldName(RegistrationEndDateFN)] = RegistrationEndDate;
                    drAry[0][LibraryMOD.GetFieldName(SemesterStartDateFN)] = SemesterStartDate;
                    drAry[0][LibraryMOD.GetFieldName(SemesterEndDateFN)] = SemesterEndDate;
                    drAry[0][LibraryMOD.GetFieldName(PeriodFN)] = Period;
                    drAry[0][LibraryMOD.GetFieldName(IsApplyRulesFN)] = IsApplyRules;
                    drAry[0][LibraryMOD.GetFieldName(AttendanceDaysAllowedFN)] = AttendanceDaysAllowed;
                    drAry[0][LibraryMOD.GetFieldName(ShortDescFN)] = ShortDesc;
                    drAry[0][LibraryMOD.GetFieldName(LongDescFN)] = LongDesc;
                    drAry[0][LibraryMOD.GetFieldName(LastUpdateUserIDFN)] = InitializeModule.gUserNo;  //'LastUpdateUserID
                    drAry[0][LibraryMOD.GetFieldName(LastUpdateDateFN)] = DateTime.Now; //'LastUpdateDate
                    drAry[0][LibraryMOD.GetFieldName(PCNameFN)] = InitializeModule.gPCName;
                    drAry[0][LibraryMOD.GetFieldName(NetUserNameFN)] = InitializeModule.gNetUserName;
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
        return InitializeModule.SUCCESS_RET;
    }
    //'-------Commit  -----------------------------
    public int CommitSemester()
    {
        //CommitSemester= ECTGlobalDll.InitializeModule.FAIL_RET;
        try
        {
            //'' Update Database with SqlDataAdapter
            daSemester.Update(dsSemester, TableName);
            //'Sent Update to database.
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return InitializeModule.SUCCESS_RET;
    }
    //'-------DeleteRow  -----------------------------
    public int DeleteRow()
    {
        //DeleteRow= ECTGlobalDll.InitializeModule.FAIL_RET;
        try
        {
            FindInMultiPKey(AcademicYear, Semester);
            if ((SemesterDataRow != null))
            {
                SemesterDataRow.Delete();
                CommitSemester();
                if (MoveNext() == InitializeModule.FAIL_RET) return InitializeModule.FAIL_RET;
            }
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return InitializeModule.SUCCESS_RET;
    }
    #endregion
    //'-------SynchronizeDataRowToClass  -----------------------------
    private int SynchronizeDataRowToClass()
    {
        try
        {
            if (SemesterDataRow[LibraryMOD.GetFieldName(AcademicYearFN)] == System.DBNull.Value)
            {
                AcademicYear = 0;
            }
            else
            {
                AcademicYear = (int)SemesterDataRow[LibraryMOD.GetFieldName(AcademicYearFN)];
            }
            if (SemesterDataRow[LibraryMOD.GetFieldName(SemesterFN)] == System.DBNull.Value)
            {
                Semester = 0;
            }
            else
            {
                Semester = (int)SemesterDataRow[LibraryMOD.GetFieldName(SemesterFN)];
            }
            if (SemesterDataRow[LibraryMOD.GetFieldName(TermFN)] == System.DBNull.Value)
            {
                Term = 0;
            }
            else
            {
                Term = (int)SemesterDataRow[LibraryMOD.GetFieldName(TermFN)];
            }
            if (SemesterDataRow[LibraryMOD.GetFieldName(RegistrationStartDateFN)] == System.DBNull.Value)
            {
                RegistrationStartDate = 0;
            }
            else
            {
                RegistrationStartDate = (int)SemesterDataRow[LibraryMOD.GetFieldName(RegistrationStartDateFN)];
            }
            if (SemesterDataRow[LibraryMOD.GetFieldName(RegistrationEndDateFN)] == System.DBNull.Value)
            {
                RegistrationEndDate = 0;
            }
            else
            {
                RegistrationEndDate = (int)SemesterDataRow[LibraryMOD.GetFieldName(RegistrationEndDateFN)];
            }
            if (SemesterDataRow[LibraryMOD.GetFieldName(SemesterStartDateFN)] == System.DBNull.Value)
            {
                SemesterStartDate = 0;
            }
            else
            {
                SemesterStartDate = (int)SemesterDataRow[LibraryMOD.GetFieldName(SemesterStartDateFN)];
            }
            if (SemesterDataRow[LibraryMOD.GetFieldName(SemesterEndDateFN)] == System.DBNull.Value)
            {
                SemesterEndDate = 0;
            }
            else
            {
                SemesterEndDate = (int)SemesterDataRow[LibraryMOD.GetFieldName(SemesterEndDateFN)];
            }
            if (SemesterDataRow[LibraryMOD.GetFieldName(PeriodFN)] == System.DBNull.Value)
            {
                Period = 0;
            }
            else
            {
                Period = (int)SemesterDataRow[LibraryMOD.GetFieldName(PeriodFN)];
            }
            if (SemesterDataRow[LibraryMOD.GetFieldName(IsApplyRulesFN)] == System.DBNull.Value)
            {
                IsApplyRules = 0;
            }
            else
            {
                IsApplyRules = (int)SemesterDataRow[LibraryMOD.GetFieldName(IsApplyRulesFN)];
            }
            if (SemesterDataRow[LibraryMOD.GetFieldName(AttendanceDaysAllowedFN)] == System.DBNull.Value)
            {
                AttendanceDaysAllowed = 0;
            }
            else
            {
                AttendanceDaysAllowed = (int)SemesterDataRow[LibraryMOD.GetFieldName(AttendanceDaysAllowedFN)];
            }
            if (SemesterDataRow[LibraryMOD.GetFieldName(ShortDescFN)] == System.DBNull.Value)
            {
                ShortDesc = "";
            }
            else
            {
                ShortDesc = (string)SemesterDataRow[LibraryMOD.GetFieldName(ShortDescFN)];
            }
            if (SemesterDataRow[LibraryMOD.GetFieldName(LongDescFN)] == System.DBNull.Value)
            {
                LongDesc = "";
            }
            else
            {
                LongDesc = (string)SemesterDataRow[LibraryMOD.GetFieldName(LongDescFN)];
            }
            if (SemesterDataRow[LibraryMOD.GetFieldName(CreationUserIDFN)] == System.DBNull.Value)
            {
                CreationUserID = 0;
            }
            else
            {
                CreationUserID = (int)SemesterDataRow[LibraryMOD.GetFieldName(CreationUserIDFN)];
            }
            if (SemesterDataRow[LibraryMOD.GetFieldName(CreationDateFN)] == System.DBNull.Value)
            {
            }
            else
            {
                CreationDate = (DateTime)SemesterDataRow[LibraryMOD.GetFieldName(CreationDateFN)];
            }
            if (SemesterDataRow[LibraryMOD.GetFieldName(LastUpdateUserIDFN)] == System.DBNull.Value)
            {
                LastUpdateUserID = 0;
            }
            else
            {
                LastUpdateUserID = (int)SemesterDataRow[LibraryMOD.GetFieldName(LastUpdateUserIDFN)];
            }
            if (SemesterDataRow[LibraryMOD.GetFieldName(LastUpdateDateFN)] == System.DBNull.Value)
            {
            }
            else
            {
                LastUpdateDate = (DateTime)SemesterDataRow[LibraryMOD.GetFieldName(LastUpdateDateFN)];
            }
            if (SemesterDataRow[LibraryMOD.GetFieldName(PCNameFN)] == System.DBNull.Value)
            {
                PCName = "";
            }
            else
            {
                PCName = (string)SemesterDataRow[LibraryMOD.GetFieldName(PCNameFN)];
            }
            if (SemesterDataRow[LibraryMOD.GetFieldName(NetUserNameFN)] == System.DBNull.Value)
            {
                NetUserName = "";
            }
            else
            {
                NetUserName = (string)SemesterDataRow[LibraryMOD.GetFieldName(NetUserNameFN)];
            }
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return InitializeModule.SUCCESS_RET;
    }
    //'-------FindInMultiPKey  -----------------------------
    public int FindInMultiPKey(int PKAcademicYear, int PKSemester)
    {
        //FindInMultiPKey= ECTGlobalDll.InitializeModule.FAIL_RET;
        try
        {
            //' Create an array for the key values to find.
            object[] findTheseVals = new object[1];
            //' Set the values of the keys to find.
            findTheseVals[0] = PKAcademicYear;
            findTheseVals[1] = PKSemester;
            SemesterDataRow = dsSemester.Tables[TableName].Rows.Find(findTheseVals);
            if ((SemesterDataRow != null))
            {
                lngCurRow = dsSemester.Tables[TableName].Rows.IndexOf(SemesterDataRow);
                SynchronizeDataRowToClass();
                return InitializeModule.SUCCESS_RET;
            }
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return InitializeModule.FAIL_RET;
    }
    #region "Navigation"
    //'-------MoveFirst  -----------------------------
    public int MoveFirst()
    {
        //MoveFirst= ECTGlobalDll.InitializeModule.FAIL_RET;
        try
        {
            lngCurRow = 0;
            if (GoToCurrentRow() == InitializeModule.FAIL_RET) return InitializeModule.FAIL_RET;
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return InitializeModule.SUCCESS_RET;
    }
    //'-------MovePrevious  -----------------------------
    public int MovePrevious()
    {
        //MovePrevious= InitializeModule.FAIL_RET;
        try
        {
            lngCurRow = Math.Max(lngCurRow - 1, 0);
            if (GoToCurrentRow() == InitializeModule.FAIL_RET) return InitializeModule.FAIL_RET;
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return InitializeModule.SUCCESS_RET;
    }
    //'-------MoveLast  -----------------------------
    public int MoveLast()
    {
        //MoveLast= ECTGlobalDll.InitializeModule.FAIL_RET;
        try
        {
            lngCurRow = dsSemester.Tables[TableName].Rows.Count - 1; //'Zero based index
            if (GoToCurrentRow() == InitializeModule.FAIL_RET) return InitializeModule.FAIL_RET;
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return InitializeModule.SUCCESS_RET;
    }
    //'-------MoveNext  -----------------------------
    public int MoveNext()
    {
        //MoveNext= ECTGlobalDll.InitializeModule.FAIL_RET;
        try
        {
            lngCurRow = Math.Min(lngCurRow + 1, dsSemester.Tables[TableName].Rows.Count - 1);
            if (GoToCurrentRow() == InitializeModule.FAIL_RET) return InitializeModule.FAIL_RET;
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return InitializeModule.SUCCESS_RET;
    }
    //'-------GoToCurrentRow  -----------------------------
    public int GoToCurrentRow()
    {
        //GoToCurrentRow= ECTGlobalDll.InitializeModule.FAIL_RET;
        try
        {
            if (lngCurRow >= 0 & dsSemester.Tables[TableName].Rows.Count > 0)
            {
                SemesterDataRow = dsSemester.Tables[TableName].Rows[lngCurRow];
                SynchronizeDataRowToClass();
            }
            else return InitializeModule.FAIL_RET;
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return InitializeModule.SUCCESS_RET;
    }
    #endregion
    #region "Events"
    //'-------AddDAEventHandler  -----------------------------
    public int AddDAEventHandler()
    {
        // ECTGlobalDll.InitializeModule.FAIL_RET;
        try
        {
            daSemester.RowUpdating += new SqlRowUpdatingEventHandler(OnRowUpdating);
            daSemester.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return InitializeModule.SUCCESS_RET;
    }
    //'-------RemoveDAEventHandler  -----------------------------
    public int RemoveDAEventHandler()
    {
        // InitializeModule.FAIL_RET;
        try
        {
            daSemester.RowUpdating -= new SqlRowUpdatingEventHandler(OnRowUpdating);
            daSemester.RowUpdated -= new SqlRowUpdatedEventHandler(OnRowUpdated);
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return InitializeModule.SUCCESS_RET;
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
