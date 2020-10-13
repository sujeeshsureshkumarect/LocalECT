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
//using ECTGlobalDll;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
public class Lecturers
{
    //Creation Date: 22/02/2010 06:44:07 م
    //Programmer Name : Hazem Galal
    //-----Decleration --------------
    #region "Decleration"
    private int m_intLecturer;
    private string m_strLecturerDescEn;
    private string m_strLecturerDescAr;
    private string m_strCollege;
    private string m_bActive;
    private int m_IsPartTimer;
    private int m_IsAdvisor;
    private int m_iFacultyType;
    private string m_AdvisingDept;
    private int m_AdvisingType;
    private int m_iCampus;

    private string m_strUserCreate;
    private DateTime m_dateCreate;
    private string m_strUserSave;
    private DateTime m_dateLastSave;
    private string m_strMachine;
    private string m_strNUser;
    #endregion
    #region "Puplic Properties"
    //'-----------------------------------------------------
    public int intLecturer
    {
        get { return m_intLecturer; }
        set { m_intLecturer = value; }
    }
    public string strLecturerDescEn
    {
        get { return m_strLecturerDescEn; }
        set { m_strLecturerDescEn = value; }
    }
    public string strLecturerDescAr
    {
        get { return m_strLecturerDescAr; }
        set { m_strLecturerDescAr = value; }
    }
    public string strCollege
    {
        get { return m_strCollege; }
        set { m_strCollege = value; }
    }
    public string bActive
    {
        get { return m_bActive; }
        set { m_bActive = value; }
    }
    public int IsPartTimer
    {
        get { return m_IsPartTimer; }
        set { m_IsPartTimer = value; }
    }
    public int IsAdvisor
    {
        get { return m_IsAdvisor; }
        set { m_IsAdvisor = value; }
    }
    public int iFacultyType
    {
        get { return m_iFacultyType; }
        set { m_iFacultyType = value; }
    }
   
    public string AdvisingDept
    {
        get { return m_AdvisingDept; }
        set { m_AdvisingDept = value; }
    }
    public int AdvisingType
    {
        get { return m_AdvisingType; }
        set { m_AdvisingType = value; }
    }
    public int iCampus
    {
        get { return m_iCampus; }
        set { m_iCampus = value; }
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
    public Lecturers()
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
public class LecturersDAL : Lecturers
{
    #region "Decleration"
    private string m_TableName;
    private string m_intLecturerFN;
    private string m_strLecturerDescEnFN;
    private string m_strLecturerDescArFN;
    private string m_strCollegeFN;
    private string m_bActiveFN;
    private string m_IsPartTimerFN;
    private string m_IsAdvisorFN;
    private string m_iFacultyTypeFN;
    private string m_AdvisingDeptFN;
    private string m_AdvisingTypeFN;

    private string m_iCampusFN;
    
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
    public string intLecturerFN
    {
        get { return m_intLecturerFN; }
        set { m_intLecturerFN = value; }
    }
    public string strLecturerDescEnFN
    {
        get { return m_strLecturerDescEnFN; }
        set { m_strLecturerDescEnFN = value; }
    }
    public string strLecturerDescArFN
    {
        get { return m_strLecturerDescArFN; }
        set { m_strLecturerDescArFN = value; }
    }
    public string strCollegeFN
    {
        get { return m_strCollegeFN; }
        set { m_strCollegeFN = value; }
    }
    public string bActiveFN
    {
        get { return m_bActiveFN; }
        set { m_bActiveFN = value; }
    }
    public string IsPartTimerFN
    {
        get { return m_IsPartTimerFN; }
        set { m_IsPartTimerFN = value; }
    }
    public string IsAdvisorFN
    {
        get { return m_IsAdvisorFN; }
        set { m_IsAdvisorFN = value; }
    }

    public string iFacultyTypeFN
    {
        get { return m_iFacultyTypeFN; }
        set { m_iFacultyTypeFN = value; }
    }
   
   
    public string AdvisingDeptFN
    {
        get { return m_AdvisingDeptFN; }
        set { m_AdvisingDeptFN = value; }
    }
    public string AdvisingTypeFN
    {
        get { return m_AdvisingTypeFN; }
        set { m_AdvisingTypeFN = value; }
    }
    public string iCampusFN
    {
        get { return m_iCampusFN; }
        set { m_iCampusFN = value; }
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
    public LecturersDAL()
    {
        try
        {
            this.TableName = "Reg_Lecturers";
            this.intLecturerFN = m_TableName + ".intLecturer";
            this.strLecturerDescEnFN = m_TableName + ".strLecturerDescEn";
            this.strLecturerDescArFN = m_TableName + ".strLecturerDescAr";
            this.strCollegeFN = m_TableName + ".strCollege";
            this.bActiveFN = m_TableName + ".bActive";
            
            this.IsPartTimerFN = m_TableName + ".IsPartTimer";
            this.IsAdvisorFN = m_TableName + ".IsAdvisor";
            this.iFacultyTypeFN = m_TableName + ".iFacultyType";
            this.iCampusFN = m_TableName + ".iCampus";
            this.AdvisingDeptFN = m_TableName + ".strAdvisingDept";
            this.AdvisingTypeFN = m_TableName + ".iAdvisingType";
            	
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
            sSQL += intLecturerFN;
            sSQL += " , " + strLecturerDescEnFN;
            sSQL += " , " + strLecturerDescArFN;
            sSQL += " , " + strCollegeFN;
            sSQL += " , " + bActiveFN;
            sSQL += " , " + IsPartTimerFN;
            sSQL += " , " + IsAdvisorFN;
            sSQL += " , " + iCampusFN;
            sSQL += " , " + iFacultyTypeFN;
            sSQL += " , " + AdvisingDeptFN ;
            sSQL += " , " + AdvisingTypeFN;
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
            sSQL += intLecturerFN;
            sSQL += " , " + strLecturerDescEnFN;
            sSQL += " , " + strLecturerDescArFN;
            sSQL += " , " + strCollegeFN;
            sSQL += " , " + bActiveFN;
            sSQL += " , " + IsPartTimerFN;
            sSQL += " , " + IsAdvisorFN;
            sSQL += " , " + iCampusFN;
            sSQL += " , " + iFacultyTypeFN;
            sSQL += " , " + AdvisingDeptFN;
            sSQL += " , " + AdvisingTypeFN;
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
            sSQL += LibraryMOD.GetFieldName(intLecturerFN) + "=@intLecturer";
            sSQL += " , " + LibraryMOD.GetFieldName(strLecturerDescEnFN) + "=@strLecturerDescEn";
            sSQL += " , " + LibraryMOD.GetFieldName(strLecturerDescArFN) + "=@strLecturerDescAr";
            sSQL += " , " + LibraryMOD.GetFieldName(strCollegeFN) + "=@strCollege";
            sSQL += " , " + LibraryMOD.GetFieldName(bActiveFN) + "=@bActive";

            sSQL += " , " + LibraryMOD.GetFieldName(IsPartTimerFN) + "=@IsPartTimer";
            sSQL += " , " + LibraryMOD.GetFieldName(IsAdvisorFN) + "=@IsAdvisor";
            sSQL += " , " + LibraryMOD.GetFieldName(iCampusFN) + "=@iCampus";
            sSQL += " , " + LibraryMOD.GetFieldName(iFacultyTypeFN) + "=@iFacultyType";
            sSQL += " , " + LibraryMOD.GetFieldName(AdvisingDeptFN) + "=@AdvisingDept"; 
            sSQL += " , " + LibraryMOD.GetFieldName(AdvisingTypeFN) + "=@AdvisingType";
            sSQL += " , " + LibraryMOD.GetFieldName(strUserCreateFN) + "=@strUserCreate";
            sSQL += " , " + LibraryMOD.GetFieldName(dateCreateFN) + "=@dateCreate";
            sSQL += " , " + LibraryMOD.GetFieldName(strUserSaveFN) + "=@strUserSave";
            sSQL += " , " + LibraryMOD.GetFieldName(dateLastSaveFN) + "=@dateLastSave";
            sSQL += " , " + LibraryMOD.GetFieldName(strMachineFN) + "=@strMachine";
            sSQL += " , " + LibraryMOD.GetFieldName(strNUserFN) + "=@strNUser";
            sSQL += " WHERE ";
            sSQL += LibraryMOD.GetFieldName(intLecturerFN) + "=@intLecturer";
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
            sSQL += LibraryMOD.GetFieldName(intLecturerFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strLecturerDescEnFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strLecturerDescArFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strCollegeFN);
            sSQL += " , " + LibraryMOD.GetFieldName(bActiveFN);
            
            sSQL += " , " + LibraryMOD.GetFieldName(IsPartTimerFN);
            sSQL += " , " + LibraryMOD.GetFieldName(IsAdvisorFN);
            sSQL += " , " + LibraryMOD.GetFieldName(iCampusFN);
            sSQL += " , " + LibraryMOD.GetFieldName(iFacultyTypeFN);
            sSQL += " , " + LibraryMOD.GetFieldName(AdvisingDeptFN);
            sSQL += " , " + LibraryMOD.GetFieldName(AdvisingTypeFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strUserCreateFN);
            sSQL += " , " + LibraryMOD.GetFieldName(dateCreateFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strUserSaveFN);
            sSQL += " , " + LibraryMOD.GetFieldName(dateLastSaveFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strMachineFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strNUserFN);
            sSQL += ")";
            sSQL += " VALUES ";
            sSQL += "( ";
            sSQL += " @intLecturer";
            sSQL += " ,@strLecturerDescEn";
            sSQL += " ,@strLecturerDescAr";
            sSQL += " ,@strCollege";
            sSQL += " ,@bActive";
            sSQL += " ,@IsPartTimer";
            sSQL += " ,@IsAdvisor";
            sSQL += " ,@iCampus";
            sSQL += " ,@iFacultyType";
            sSQL += " ,@AdvisingDept";
            sSQL += " ,@AdvisingType"; 
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
            sSQL += LibraryMOD.GetFieldName(intLecturerFN) + "=@intLecturer";
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


    public List<Lecturers> GetLecturers(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
    {
        //' returns a list of Classes instances based on the
        //' data in the Lecturers
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        string sSQL = GetSQL();
        if (!string.IsNullOrEmpty(sCondition))
        {
            sSQL += sCondition;
        }
        sSQL += " ORDER BY " + LibraryMOD.GetFieldName(strLecturerDescEnFN);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        SqlCommand Cmd = new SqlCommand(sSQL, Conn);
        Conn.Open();
        SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
        List<Lecturers> results = new List<Lecturers>();
        try
        {
            //Default Value
            Lecturers myLecturers = new Lecturers();
            if (isDeafaultIncluded)
            {
                //Change the code here
                myLecturers.intLecturer = 0;
                myLecturers.strLecturerDescEn = "Select Instructor ...";
                results.Add(myLecturers);
            }
            while (reader.Read())
            {
                myLecturers = new Lecturers();
                if (reader[LibraryMOD.GetFieldName(intLecturerFN)].Equals(DBNull.Value))
                {
                    myLecturers.intLecturer = 0;
                }
                else
                {
                    myLecturers.intLecturer = int.Parse(reader[LibraryMOD.GetFieldName(intLecturerFN)].ToString());
                }
                myLecturers.strLecturerDescEn = reader[LibraryMOD.GetFieldName(strLecturerDescEnFN)].ToString();
                myLecturers.strLecturerDescAr = reader[LibraryMOD.GetFieldName(strLecturerDescArFN)].ToString();
                myLecturers.strCollege = reader[LibraryMOD.GetFieldName(strCollegeFN)].ToString();
                myLecturers.bActive = reader[LibraryMOD.GetFieldName(bActiveFN)].ToString();
                if (reader[LibraryMOD.GetFieldName(IsPartTimerFN)].Equals(DBNull.Value))
                {
                    myLecturers.IsPartTimer = 0;
                }
                else
                {
                    myLecturers.IsPartTimer = Convert.ToInt32(bool.Parse(reader[LibraryMOD.GetFieldName(IsPartTimerFN)].ToString()));
                }
                if (reader[LibraryMOD.GetFieldName(IsAdvisorFN)].Equals(DBNull.Value))
                {
                    myLecturers.IsAdvisor = 0;
                }
                else
                {
                    myLecturers.IsAdvisor = Convert.ToInt32(bool.Parse(reader[LibraryMOD.GetFieldName(IsAdvisorFN)].ToString()));
                }

                if (reader[LibraryMOD.GetFieldName(iCampusFN)].Equals(DBNull.Value))
                {
                    myLecturers.iCampus = 0;
                }
                else
                {
                    myLecturers.iCampus = int.Parse(reader[LibraryMOD.GetFieldName(iCampusFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(iFacultyTypeFN)].Equals(DBNull.Value))
                {
                    myLecturers.iFacultyType= 0;
                }
                else
                {
                    myLecturers.iFacultyType = int.Parse(reader[LibraryMOD.GetFieldName(iFacultyTypeFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(AdvisingDeptFN)].Equals(DBNull.Value))
                {
                    myLecturers.AdvisingDept = "0";
                }
                else
                {
                    myLecturers.AdvisingDept =reader[LibraryMOD.GetFieldName(AdvisingDeptFN)].ToString();
                }
                if (reader[LibraryMOD.GetFieldName(AdvisingTypeFN)].Equals(DBNull.Value))
                {
                    myLecturers.AdvisingType = 0;
                }
                else
                {
                    myLecturers.AdvisingType = int.Parse(reader[LibraryMOD.GetFieldName(AdvisingTypeFN)].ToString());
                }
                myLecturers.strUserCreate = reader[LibraryMOD.GetFieldName(strUserCreateFN)].ToString();



                if (!reader[LibraryMOD.GetFieldName(dateCreateFN)].Equals(DBNull.Value))
                {
                    myLecturers.dateCreate = DateTime.Parse(reader[LibraryMOD.GetFieldName(dateCreateFN)].ToString());
                }
                myLecturers.strUserSave = reader[LibraryMOD.GetFieldName(strUserSaveFN)].ToString();
                if (!reader[LibraryMOD.GetFieldName(dateLastSaveFN)].Equals(DBNull.Value))
                {
                    myLecturers.dateLastSave = DateTime.Parse(reader[LibraryMOD.GetFieldName(dateLastSaveFN)].ToString());
                }
                myLecturers.strMachine = reader[LibraryMOD.GetFieldName(strMachineFN)].ToString();
                myLecturers.strNUser = reader[LibraryMOD.GetFieldName(strNUserFN)].ToString();
                results.Add(myLecturers);
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

    public int UpdateLecturers(InitializeModule.EnumCampus Campus, int iMode, int intLecturer, string strLecturerDescEn, string strLecturerDescAr, string strCollege, string bActive, int iIsAdvisor,int iIsParttimer,int iFacultyType,string sAdvisingDept,int iAdvisingType,int iCampus, string strUserCreate, DateTime dateCreate, string strUserSave, DateTime dateLastSave, string strMachine, string strNUser)
    {
        int iEffected = 0;
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        try
        {
            Conn.Open();
            string sql = "";
            Lecturers theLecturers = new Lecturers();
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
            Cmd.Parameters.Add(new SqlParameter("@intLecturer", intLecturer));
            Cmd.Parameters.Add(new SqlParameter("@strLecturerDescEn", strLecturerDescEn));
            Cmd.Parameters.Add(new SqlParameter("@strLecturerDescAr", strLecturerDescAr));
            Cmd.Parameters.Add(new SqlParameter("@strCollege", strCollege));
            Cmd.Parameters.Add(new SqlParameter("@bActive", bActive));
            Cmd.Parameters.Add(new SqlParameter("@IsAdvisor", iIsAdvisor));
            Cmd.Parameters.Add(new SqlParameter("@IsPartTimer", iIsParttimer));
            Cmd.Parameters.Add(new SqlParameter("@iFacultyType", iFacultyType));
            Cmd.Parameters.Add(new SqlParameter("@AdvisingDept", sAdvisingDept));
            Cmd.Parameters.Add(new SqlParameter("@AdvisingType", iAdvisingType));
            Cmd.Parameters.Add(new SqlParameter("@iCampus", iCampus));
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
    public int DeleteLecturers(InitializeModule.EnumCampus Campus, string intLecturer)
    {
        int iEffected = 0;
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        try
        {
            string sSQL = GetDeleteCommand();
            //sSQL += sCondition;
            SqlCommand Cmd = new SqlCommand(sSQL, Conn);
            Cmd.Parameters.Add(new SqlParameter("@intLecturer", intLecturer));
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
        DataTable dt = new DataTable("Lecturers");
        DataView dv = new DataView();
        List<Lecturers> myLecturerss = new List<Lecturers>();
        try
        {
            myLecturerss = GetLecturers(InitializeModule.EnumCampus.ECTNew, sCondition, false);
            DataColumn col1 = new DataColumn("intLecturer", Type.GetType("smallint"));
            dt.Columns.Add(col1);
            DataColumn col2 = new DataColumn("strLecturerDescEn", Type.GetType("nvarchar"));
            dt.Columns.Add(col2);
            DataColumn col3 = new DataColumn("strLecturerDescAr", Type.GetType("nvarchar"));
            dt.Columns.Add(col3);
            dt.Constraints.Add(new UniqueConstraint(col1));

            DataRow dr;
            for (int i = 0; i < myLecturerss.Count; i++)
            {
                dr = dt.NewRow();
                dr[1] = myLecturerss[i].intLecturer;
                dr[2] = myLecturerss[i].strLecturerDescEn;
                dr[3] = myLecturerss[i].strLecturerDescAr;
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
            myLecturerss.Clear();
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
            sSQL += intLecturerFN;
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
public class LecturersCls : LecturersDAL
{
    #region "Decleration"
    private int m_lngCurRow = 0;
    public SqlDataAdapter daLecturers;
    private DataSet m_dsLecturers;
    public DataRow LecturersDataRow;
    #endregion
    #region "Puplic Properties"
    public DataSet dsLecturers
    {
        get { return m_dsLecturers; }
        set { m_dsLecturers = value; }
    }
    //-----------------------------------------------------
    public int lngCurRow
    {
        get { return m_lngCurRow; }
        set { m_lngCurRow = value; }
    }
    #endregion
    public LecturersCls()
    {
        try
        {
            dsLecturers = new DataSet();

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
    public virtual SqlDataAdapter GetLecturersDataAdapter(string sCondition, SqlConnection con)
    {
        string sSQL = "";
        try
        {
            sSQL = GetSQL();
            sSQL += " " + sCondition;
            //-----------------------------------------
            daLecturers = new SqlDataAdapter(sSQL, con);
            // Create command builder. This line automatically generates the update commands for you, so you don't
            // have to provide or create your own.
            SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daLecturers);
            //Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
            // key + unique key information to be retrieved unless AddWithKey is specified.
            daLecturers.MissingSchemaAction = MissingSchemaAction.AddWithKey;
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return daLecturers;
    }
    public virtual SqlDataAdapter GetLecturersDataAdapter(SqlConnection con)
    {
        try
        {
            daLecturers = new SqlDataAdapter();
            //''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
            //'' key + unique key information to be retrieved unless AddWithKey is specified.
            daLecturers.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            //-----------------------------------------
            SqlParameter Parmeter = default(SqlParameter);
            //[SELECT COMMAND]
            SqlCommand cmdLecturers;
            cmdLecturers = new SqlCommand(GetSelectCommand(), con);
            //'cmdRolePermission.Parameters.Add("@intLecturer", SqlDbType.Int, 4, "intLecturer" );
            daLecturers.SelectCommand = cmdLecturers;
            //'Add Handlers
            //'RowUpdating,RowUpdated
            AddDAEventHandler();
            //'[UPDATE COMMAND].
            cmdLecturers = new SqlCommand(GetUpdateCommand(), con);
            //'Delete PK Parameteres from here. b/c its declared below
           // cmdLecturers.Parameters.Add("@intLecturer", SqlDbType.Int, 2, LibraryMOD.GetFieldName(intLecturerFN));
            cmdLecturers.Parameters.Add("@strLecturerDescEn", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strLecturerDescEnFN));
            cmdLecturers.Parameters.Add("@strLecturerDescAr", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strLecturerDescArFN));
            cmdLecturers.Parameters.Add("@strCollege", SqlDbType.NVarChar, 12, LibraryMOD.GetFieldName(strCollegeFN));
            cmdLecturers.Parameters.Add("@bActive", SqlDbType.Bit, 1, LibraryMOD.GetFieldName(bActiveFN));
            cmdLecturers.Parameters.Add("@strUserCreate", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strUserCreateFN));
            cmdLecturers.Parameters.Add("@dateCreate", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dateCreateFN));
            cmdLecturers.Parameters.Add("@strUserSave", SqlDbType.Char, 10, LibraryMOD.GetFieldName(strUserSaveFN));
            cmdLecturers.Parameters.Add("@dateLastSave", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dateLastSaveFN));
            cmdLecturers.Parameters.Add("@strMachine", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strMachineFN));
            cmdLecturers.Parameters.Add("@strNUser", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strNUserFN));


            Parmeter = cmdLecturers.Parameters.Add("@intLecturer", SqlDbType.Int, 4, LibraryMOD.GetFieldName(intLecturerFN));
            Parmeter.SourceVersion = DataRowVersion.Original;
            //'Its should be none for batch updating
            //'UpdateCommand, InsertCommand, and DeleteCommand 
            //'should be set to None or OutputParameters
            daLecturers.UpdateCommand = cmdLecturers;
            daLecturers.UpdateCommand.UpdatedRowSource = UpdateRowSource.None;
            //'-------------------------------------------------------------------------
            //'/INSERT COMMAND
            cmdLecturers = new SqlCommand(GetInsertCommand(), con);
            cmdLecturers.Parameters.Add("@intLecturer", SqlDbType.Int, 2, LibraryMOD.GetFieldName(intLecturerFN));
            cmdLecturers.Parameters.Add("@strLecturerDescEn", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strLecturerDescEnFN));
            cmdLecturers.Parameters.Add("@strLecturerDescAr", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strLecturerDescArFN));
            cmdLecturers.Parameters.Add("@strCollege", SqlDbType.NVarChar, 12, LibraryMOD.GetFieldName(strCollegeFN));
            cmdLecturers.Parameters.Add("@bActive", SqlDbType.Bit, 1, LibraryMOD.GetFieldName(bActiveFN));
            cmdLecturers.Parameters.Add("@strUserCreate", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strUserCreateFN));
            cmdLecturers.Parameters.Add("@dateCreate", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dateCreateFN));
            cmdLecturers.Parameters.Add("@strUserSave", SqlDbType.Char, 10, LibraryMOD.GetFieldName(strUserSaveFN));
            cmdLecturers.Parameters.Add("@dateLastSave", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dateLastSaveFN));
            cmdLecturers.Parameters.Add("@strMachine", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strMachineFN));
            cmdLecturers.Parameters.Add("@strNUser", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strNUserFN));
            Parmeter.SourceVersion = DataRowVersion.Current;
            daLecturers.InsertCommand = cmdLecturers;
            daLecturers.InsertCommand.UpdatedRowSource = UpdateRowSource.None;
            //'------------------------
            //'/DELETE COMMAND
            cmdLecturers = new SqlCommand(GetDeleteCommand(), con);
            Parmeter = cmdLecturers.Parameters.Add("@intLecturer", SqlDbType.Int, 4, LibraryMOD.GetFieldName(intLecturerFN));
            Parmeter.SourceVersion = DataRowVersion.Original;
            daLecturers.DeleteCommand = cmdLecturers;
            daLecturers.DeleteCommand.UpdatedRowSource = UpdateRowSource.None;
            //'Batch Size
            //'Set the batch size.
            daLecturers.UpdateBatchSize = InitializeModule.BATCH_SIZE;
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return daLecturers;
    }
    //'-------SaveData  -----------------------------
    public int SaveData(int lFormMode)
    {
        //SaveData= InitializeModule.FAIL_RET;
        try
        {
            switch (lFormMode)
            {
                case (int)InitializeModule.enumModes.NewMode:
                    DataRow dr = default(DataRow);
                    dr = dsLecturers.Tables[TableName].NewRow();
                    dr[LibraryMOD.GetFieldName(intLecturerFN)] = intLecturer;
                    dr[LibraryMOD.GetFieldName(strLecturerDescEnFN)] = strLecturerDescEn;
                    dr[LibraryMOD.GetFieldName(strLecturerDescArFN)] = strLecturerDescAr;
                    dr[LibraryMOD.GetFieldName(strCollegeFN)] = strCollege;
                    dr[LibraryMOD.GetFieldName(bActiveFN)] = bActive;
                   
                    dr[LibraryMOD.GetFieldName(IsPartTimerFN)] = IsPartTimer;
                    dr[LibraryMOD.GetFieldName(iCampusFN)] = iCampus;
                    dr[LibraryMOD.GetFieldName(iFacultyTypeFN)] = iFacultyType;
                    dr[LibraryMOD.GetFieldName(strUserCreateFN)] = strUserCreate;
                    dr[LibraryMOD.GetFieldName(dateCreateFN)] = dateCreate;
                    dr[LibraryMOD.GetFieldName(strUserSaveFN)] = strUserSave;
                    dr[LibraryMOD.GetFieldName(dateLastSaveFN)] = dateLastSave;
                    dr[LibraryMOD.GetFieldName(strMachineFN)] = strMachine;
                    dr[LibraryMOD.GetFieldName(strNUserFN)] = strNUser;
                    //dr[LibraryMOD.GetFieldName(CreationUserIDFN)] = InitializeModule.gUserNo;
                    //dr[LibraryMOD.GetFieldName(CreationDateFN)] = DateTime.Now; //' CreationDate
                    //dr[LibraryMOD.GetFieldName(LastUpdateUserIDFN)] = InitializeModule.gUserNo;  //'LastUpdateUserID
                    //dr[LibraryMOD.GetFieldName(LastUpdateDateFN)] = DateTime.Now; //'LastUpdateDate
                    //dr[LibraryMOD.GetFieldName(PCNameFN)] = InitializeModule.gPCName;
                    //dr[LibraryMOD.GetFieldName(NetUserNameFN)] = InitializeModule.gNetUserName;
                    dsLecturers.Tables[TableName].Rows.Add(dr);
                    break;
                case (int)InitializeModule.enumModes.EditMode:
                    DataRow[] drAry = null;
                    drAry = dsLecturers.Tables[TableName].Select(LibraryMOD.GetFieldName(intLecturerFN) + "=" + intLecturer);
                    //'its return array of rows and we can access the first by index 0
                    drAry[0][LibraryMOD.GetFieldName(intLecturerFN)] = intLecturer;
                    drAry[0][LibraryMOD.GetFieldName(strLecturerDescEnFN)] = strLecturerDescEn;
                    drAry[0][LibraryMOD.GetFieldName(strLecturerDescArFN)] = strLecturerDescAr;
                    drAry[0][LibraryMOD.GetFieldName(strCollegeFN)] = strCollege;
                    drAry[0][LibraryMOD.GetFieldName(bActiveFN)] = bActive;
                    drAry[0][LibraryMOD.GetFieldName(IsPartTimerFN)] = IsPartTimer;
                    drAry[0][LibraryMOD.GetFieldName(iCampusFN)] = iCampus;
                    drAry[0][LibraryMOD.GetFieldName(iFacultyTypeFN)] = iFacultyType;
                    drAry[0][LibraryMOD.GetFieldName(strUserCreateFN)] = strUserCreate;
                    drAry[0][LibraryMOD.GetFieldName(dateCreateFN)] = dateCreate;
                    drAry[0][LibraryMOD.GetFieldName(strUserSaveFN)] = strUserSave;
                    drAry[0][LibraryMOD.GetFieldName(dateLastSaveFN)] = dateLastSave;
                    drAry[0][LibraryMOD.GetFieldName(strMachineFN)] = strMachine;
                    drAry[0][LibraryMOD.GetFieldName(strNUserFN)] = strNUser;
                    //drAry[0][LibraryMOD.GetFieldName(LastUpdateUserIDFN)] = InitializeModule.gUserNo;  //'LastUpdateUserID
                    //drAry[0][LibraryMOD.GetFieldName(LastUpdateDateFN)] = DateTime.Now; //'LastUpdateDate
                    //drAry[0][LibraryMOD.GetFieldName(PCNameFN)] = InitializeModule.gPCName;
                    //drAry[0][LibraryMOD.GetFieldName(NetUserNameFN)] = InitializeModule.gNetUserName;
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
    public int CommitLecturers()
    {
        //CommitLecturers= InitializeModule.FAIL_RET;
        try
        {
            //'' Update Database with SqlDataAdapter
            daLecturers.Update(dsLecturers, TableName);
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
        //DeleteRow= InitializeModule.FAIL_RET;
        try
        {
            FindInMultiPKey(intLecturer);
            if ((LecturersDataRow != null))
            {
                LecturersDataRow.Delete();
                CommitLecturers();
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
            if (LecturersDataRow[LibraryMOD.GetFieldName(intLecturerFN)] == System.DBNull.Value)
            {
                intLecturer = 0;
            }
            else
            {
                intLecturer = (int)LecturersDataRow[LibraryMOD.GetFieldName(intLecturerFN)];
            }
            if (LecturersDataRow[LibraryMOD.GetFieldName(strLecturerDescEnFN)] == System.DBNull.Value)
            {
                strLecturerDescEn = "";
            }
            else
            {
                strLecturerDescEn = (string)LecturersDataRow[LibraryMOD.GetFieldName(strLecturerDescEnFN)];
            }
            if (LecturersDataRow[LibraryMOD.GetFieldName(strLecturerDescArFN)] == System.DBNull.Value)
            {
                strLecturerDescAr = "";
            }
            else
            {
                strLecturerDescAr = (string)LecturersDataRow[LibraryMOD.GetFieldName(strLecturerDescArFN)];
            }
            if (LecturersDataRow[LibraryMOD.GetFieldName(strCollegeFN)] == System.DBNull.Value)
            {
                strCollege = "";
            }
            else
            {
                strCollege = (string)LecturersDataRow[LibraryMOD.GetFieldName(strCollegeFN)];
            }
            if (LecturersDataRow[LibraryMOD.GetFieldName(bActiveFN)] == System.DBNull.Value)
            {
                bActive = "";
            }
            else
            {
                bActive = (string)LecturersDataRow[LibraryMOD.GetFieldName(bActiveFN)];
            }
            if (LecturersDataRow[LibraryMOD.GetFieldName(strUserCreateFN)] == System.DBNull.Value)
            {
                strUserCreate = "";
            }
            else
            {
                strUserCreate = (string)LecturersDataRow[LibraryMOD.GetFieldName(strUserCreateFN)];
            }
            if (LecturersDataRow[LibraryMOD.GetFieldName(dateCreateFN)] == System.DBNull.Value)
            {
            }
            else
            {
                dateCreate = (DateTime)LecturersDataRow[LibraryMOD.GetFieldName(dateCreateFN)];
            }
            if (LecturersDataRow[LibraryMOD.GetFieldName(strUserSaveFN)] == System.DBNull.Value)
            {
                strUserSave = "";
            }
            else
            {
                strUserSave = (string)LecturersDataRow[LibraryMOD.GetFieldName(strUserSaveFN)];
            }
            if (LecturersDataRow[LibraryMOD.GetFieldName(dateLastSaveFN)] == System.DBNull.Value)
            {
            }
            else
            {
                dateLastSave = (DateTime)LecturersDataRow[LibraryMOD.GetFieldName(dateLastSaveFN)];
            }
            if (LecturersDataRow[LibraryMOD.GetFieldName(strMachineFN)] == System.DBNull.Value)
            {
                strMachine = "";
            }
            else
            {
                strMachine = (string)LecturersDataRow[LibraryMOD.GetFieldName(strMachineFN)];
            }
            if (LecturersDataRow[LibraryMOD.GetFieldName(strNUserFN)] == System.DBNull.Value)
            {
                strNUser = "";
            }
            else
            {
                strNUser = (string)LecturersDataRow[LibraryMOD.GetFieldName(strNUserFN)];
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
    public int FindInMultiPKey(int PKintLecturer)
    {
        //FindInMultiPKey= InitializeModule.FAIL_RET;
        try
        {
            //' Create an array for the key values to find.
            object[] findTheseVals = new object[1];
            //' Set the values of the keys to find.
            findTheseVals[0] = PKintLecturer;
            LecturersDataRow = dsLecturers.Tables[TableName].Rows.Find(findTheseVals);
            if ((LecturersDataRow != null))
            {
                lngCurRow = dsLecturers.Tables[TableName].Rows.IndexOf(LecturersDataRow);
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
        //MoveFirst= InitializeModule.FAIL_RET;
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
        //MoveLast= InitializeModule.FAIL_RET;
        try
        {
            lngCurRow = dsLecturers.Tables[TableName].Rows.Count - 1; //'Zero based index
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
        //MoveNext= InitializeModule.FAIL_RET;
        try
        {
            lngCurRow = Math.Min(lngCurRow + 1, dsLecturers.Tables[TableName].Rows.Count - 1);
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
        //GoToCurrentRow= InitializeModule.FAIL_RET;
        try
        {
            if (lngCurRow >= 0 & dsLecturers.Tables[TableName].Rows.Count > 0)
            {
                LecturersDataRow = dsLecturers.Tables[TableName].Rows[lngCurRow];
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
        // InitializeModule.FAIL_RET;
        try
        {
            daLecturers.RowUpdating += new SqlRowUpdatingEventHandler(OnRowUpdating);
            daLecturers.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
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
            daLecturers.RowUpdating -= new SqlRowUpdatingEventHandler(OnRowUpdating);
            daLecturers.RowUpdated -= new SqlRowUpdatedEventHandler(OnRowUpdated);
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
