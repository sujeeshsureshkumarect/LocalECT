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
public class ECTNewLecturers
{
    //Creation Date: 18/11/2009 9:01:58 AM
    //Programmer Name : 
    //-----Decleration --------------
    #region "Decleration"
    private int m_LecturerID;
    private string m_LecturerNameEn;
    private string m_LecturerNameAr;
    private int m_MCampusID;
    private int m_FCampusID;
    private int m_CollegeID;
    private int m_IsActive;
    private string m_Mobile;
    private string m_Phone;
    private string m_InternalPhone;
    private int m_HireDate;
    private int m_IsAdvisor;
    private int m_IsPartTime;
    private int m_iFacultyType;
    private string m_AdvisingDept;
    private int m_AdvisingType;

    private int m_CampusID;
    private int m_CreationUserID;
    private DateTime m_CreationDate;
    private int m_LastUpdateUserID;
    private DateTime m_LastUpdateDate;
    private string m_PCName;
    private string m_NetUserName;
    #endregion
    #region "Puplic Properties"
    //'-----------------------------------------------------
    public int LecturerID
    {
        get { return m_LecturerID; }
        set { m_LecturerID = value; }
    }
    public string LecturerNameEn
    {
        get { return m_LecturerNameEn; }
        set { m_LecturerNameEn = value; }
    }
    public string LecturerNameAr
    {
        get { return m_LecturerNameAr; }
        set { m_LecturerNameAr = value; }
    }
    public int MCampusID
    {
        get { return m_MCampusID; }
        set { m_MCampusID = value; }
    }
    public int FCampusID
    {
        get { return m_FCampusID; }
        set { m_FCampusID = value; }
    }
    public int CollegeID
    {
        get { return m_CollegeID; }
        set { m_CollegeID = value; }
    }
    public int IsActive
    {
        get { return m_IsActive; }
        set { m_IsActive = value; }
    }
    public string Mobile
    {
        get { return m_Mobile; }
        set { m_Mobile = value; }
    }
    public string Phone
    {
        get { return m_Phone; }
        set { m_Phone = value; }
    }
    public string InternalPhone
    {
        get { return m_InternalPhone; }
        set { m_InternalPhone = value; }
    }
    public int HireDate
    {
        get { return m_HireDate; }
        set { m_HireDate = value; }
    }
    public int IsAdvisor
    {
        get { return m_IsAdvisor; }
        set { m_IsAdvisor = value; }
    }
    
    public int IsPartTime
    {
        get { return m_IsPartTime; }
        set { m_IsPartTime = value; }
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
    public int CampusID
    {
        get { return m_CampusID; }
        set { m_CampusID = value; }
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
    public ECTNewLecturers()
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
public class ECTNewLecturersDAL : ECTNewLecturers
{
    #region "Decleration"
    private string m_TableName;
    private string m_LecturerIDFN;
    private string m_LecturerNameEnFN;
    private string m_LecturerNameArFN;
    private string m_MCampusIDFN;
    private string m_FCampusIDFN;
    private string m_CollegeIDFN;
    private string m_IsActiveFN;
    private string m_MobileFN;
    private string m_PhoneFN;
    private string m_InternalPhoneFN;
    private string m_HireDateFN;
    private string m_IsAdvisorFN;
    private string m_IsPartTimeFN;
    private string m_iFacultyTypeFN;
    private string m_AdvisingDeptFN;
    private string m_AdvisingTypeFN;
    private string m_CampusIDFN;
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
    public string LecturerIDFN
    {
        get { return m_LecturerIDFN; }
        set { m_LecturerIDFN = value; }
    }
    public string LecturerNameEnFN
    {
        get { return m_LecturerNameEnFN; }
        set { m_LecturerNameEnFN = value; }
    }
    public string LecturerNameArFN
    {
        get { return m_LecturerNameArFN; }
        set { m_LecturerNameArFN = value; }
    }
    public string MCampusIDFN
    {
        get { return m_MCampusIDFN; }
        set { m_MCampusIDFN = value; }
    }
    public string FCampusIDFN
    {
        get { return m_FCampusIDFN; }
        set { m_FCampusIDFN = value; }
    }
    public string CollegeIDFN
    {
        get { return m_CollegeIDFN; }
        set { m_CollegeIDFN = value; }
    }
    public string IsActiveFN
    {
        get { return m_IsActiveFN; }
        set { m_IsActiveFN = value; }
    }
    public string MobileFN
    {
        get { return m_MobileFN; }
        set { m_MobileFN = value; }
    }
    public string PhoneFN
    {
        get { return m_PhoneFN; }
        set { m_PhoneFN = value; }
    }
    public string InternalPhoneFN
    {
        get { return m_InternalPhoneFN; }
        set { m_InternalPhoneFN = value; }
    }
    public string HireDateFN
    {
        get { return m_HireDateFN; }
        set { m_HireDateFN = value; }
    }

    public string IsAdvisorFN
    {
        get { return m_IsAdvisorFN; }
        set { m_IsAdvisorFN = value; }
    }
    public string IsPartTimeFN
    {
        get { return m_IsPartTimeFN; }
        set { m_IsPartTimeFN = value; }
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
    public string CampusIDFN
    {
        get { return m_CampusIDFN; }
        set { m_CampusIDFN = value; }
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
            sSQL += LecturerIDFN;
            sSQL += " , " + LecturerNameEnFN;
            sSQL += " , " + LecturerNameArFN;
            sSQL += " , " + MCampusIDFN;
            sSQL += " , " + FCampusIDFN;
            sSQL += " , " + CollegeIDFN;
            sSQL += " , " + IsActiveFN;
            sSQL += " , " + MobileFN;
            sSQL += " , " + PhoneFN;
            sSQL += " , " + InternalPhoneFN;
            sSQL += " , " + HireDateFN;
            sSQL += " , " + IsAdvisorFN;
            sSQL += " , " + IsPartTimeFN;
            sSQL += " , " + CampusIDFN;
            sSQL += " , " + iFacultyTypeFN;
            sSQL += " , " + AdvisingDeptFN;
            sSQL += " , " + AdvisingTypeFN;

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
            sSQL += LecturerIDFN;
            sSQL += " , " + LecturerNameEnFN;
            sSQL += " , " + MCampusIDFN;
            sSQL += " , " + FCampusIDFN;
            sSQL += "  FROM " + m_TableName;
            sSQL += sWhere;
            sSQL += " Order By " + LecturerNameEnFN;
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
            sSQL += LecturerIDFN;
            sSQL += " , " + LecturerNameEnFN;
            sSQL += " , " + LecturerNameArFN;
            sSQL += " , " + MCampusIDFN;
            sSQL += " , " + FCampusIDFN;
            sSQL += " , " + CollegeIDFN;
            sSQL += " , " + IsActiveFN;
            sSQL += " , " + MobileFN;
            sSQL += " , " + PhoneFN;
            sSQL += " , " + InternalPhoneFN;
            sSQL += " , " + HireDateFN;
            sSQL += " , " + IsAdvisorFN;
            sSQL += " , " + IsPartTimeFN;
            sSQL += " , " + CampusIDFN;
            sSQL += " , " + iFacultyTypeFN;
            sSQL += " , " + AdvisingDeptFN;
            sSQL += " , " + AdvisingTypeFN;
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
            sSQL += LibraryMOD.GetFieldName(LecturerIDFN) + "=@LecturerID";
            sSQL += " , " + LibraryMOD.GetFieldName(LecturerNameEnFN) + "=@LecturerNameEn";
            sSQL += " , " + LibraryMOD.GetFieldName(LecturerNameArFN) + "=@LecturerNameAr";
            sSQL += " , " + LibraryMOD.GetFieldName(MCampusIDFN) + "=@MCampusID";
            sSQL += " , " + LibraryMOD.GetFieldName(FCampusIDFN) + "=@FCampusID";
            sSQL += " , " + LibraryMOD.GetFieldName(CollegeIDFN) + "=@CollegeID";
            sSQL += " , " + LibraryMOD.GetFieldName(IsActiveFN) + "=@IsActive";
            sSQL += " , " + LibraryMOD.GetFieldName(MobileFN) + "=@Mobile";
            sSQL += " , " + LibraryMOD.GetFieldName(PhoneFN) + "=@Phone";
            sSQL += " , " + LibraryMOD.GetFieldName(InternalPhoneFN) + "=@InternalPhone";
            sSQL += " , " + LibraryMOD.GetFieldName(HireDateFN) + "=@HireDate";
            sSQL += " , " + LibraryMOD.GetFieldName(IsAdvisorFN) + "=@IsAdvisor";
            sSQL += " , " + LibraryMOD.GetFieldName(IsPartTimeFN) + "=@IsPartTime";
            sSQL += " , " + LibraryMOD.GetFieldName(CampusIDFN) + "=@CampusID";
            sSQL += " , " + LibraryMOD.GetFieldName(iFacultyTypeFN) + "=@iFacultyType";
            sSQL += " , " + LibraryMOD.GetFieldName(AdvisingDeptFN) + "=@AdvisingDept";
            sSQL += " , " + LibraryMOD.GetFieldName(AdvisingTypeFN) + "=@AdvisingType";
            sSQL += " , " + LibraryMOD.GetFieldName(CreationUserIDFN) + "=@CreationUserID";
            sSQL += " , " + LibraryMOD.GetFieldName(CreationDateFN) + "=@CreationDate";
            sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateUserIDFN) + "=@LastUpdateUserID";
            sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateDateFN) + "=@LastUpdateDate";
            sSQL += " , " + LibraryMOD.GetFieldName(PCNameFN) + "=@PCName";
            sSQL += " , " + LibraryMOD.GetFieldName(NetUserNameFN) + "=@NetUserName";
            sSQL += " WHERE ";
            sSQL += LibraryMOD.GetFieldName(LecturerIDFN) + "=@LecturerID";
            //sSQL +=  " And " + LibraryMOD.GetFieldName(LecturerNameEnFN)+"=@LecturerNameEn";
            //sSQL +=  " And " + LibraryMOD.GetFieldName(LecturerNameArFN)+"=@LecturerNameAr";
            //sSQL +=  " And " + LibraryMOD.GetFieldName(MCampusIDFN)+"=@MCampusID";
            //sSQL +=  " And " + LibraryMOD.GetFieldName(FCampusIDFN)+"=@FCampusID";
            //sSQL +=  " And " + LibraryMOD.GetFieldName(CollegeIDFN)+"=@CollegeID";
            //sSQL +=  " And " + LibraryMOD.GetFieldName(IsActiveFN)+"=@IsActive";
            //sSQL +=  " And " + LibraryMOD.GetFieldName(MobileFN)+"=@Mobile";
            //sSQL +=  " And " + LibraryMOD.GetFieldName(PhoneFN)+"=@Phone";
            //sSQL +=  " And " + LibraryMOD.GetFieldName(InternalPhoneFN)+"=@InternalPhone";
            //sSQL +=  " And " + LibraryMOD.GetFieldName(HireDateFN)+"=@HireDate";
            //sSQL +=  " And " + LibraryMOD.GetFieldName(IsPartTimeFN)+"=@IsPartTime";
            //sSQL +=  " And " + LibraryMOD.GetFieldName(CreationUserIDFN)+"=@CreationUserID";
            //sSQL +=  " And " + LibraryMOD.GetFieldName(CreationDateFN)+"=@CreationDate";
            //sSQL +=  " And " + LibraryMOD.GetFieldName(LastUpdateUserIDFN)+"=@LastUpdateUserID";
            //sSQL +=  " And " + LibraryMOD.GetFieldName(LastUpdateDateFN)+"=@LastUpdateDate";
            //sSQL +=  " And " + LibraryMOD.GetFieldName(PCNameFN)+"=@PCName";
            //sSQL +=  " And " + LibraryMOD.GetFieldName(NetUserNameFN)+"=@NetUserName";
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
            sSQL += LibraryMOD.GetFieldName(LecturerIDFN);
            sSQL += " , " + LibraryMOD.GetFieldName(LecturerNameEnFN);
            sSQL += " , " + LibraryMOD.GetFieldName(LecturerNameArFN);
            sSQL += " , " + LibraryMOD.GetFieldName(MCampusIDFN);
            sSQL += " , " + LibraryMOD.GetFieldName(FCampusIDFN);
            sSQL += " , " + LibraryMOD.GetFieldName(CollegeIDFN);
            sSQL += " , " + LibraryMOD.GetFieldName(IsActiveFN);
            sSQL += " , " + LibraryMOD.GetFieldName(MobileFN);
            sSQL += " , " + LibraryMOD.GetFieldName(PhoneFN);
            sSQL += " , " + LibraryMOD.GetFieldName(InternalPhoneFN);
            sSQL += " , " + LibraryMOD.GetFieldName(HireDateFN);
            sSQL += " , " + LibraryMOD.GetFieldName(IsAdvisorFN);
            sSQL += " , " + LibraryMOD.GetFieldName(IsPartTimeFN);
            sSQL += " , " + LibraryMOD.GetFieldName(CampusIDFN);
            sSQL += " , " + LibraryMOD.GetFieldName(iFacultyTypeFN);
            sSQL += " , " + LibraryMOD.GetFieldName(AdvisingDeptFN);
            sSQL += " , " + LibraryMOD.GetFieldName(AdvisingTypeFN);
            sSQL += " , " + LibraryMOD.GetFieldName(CreationUserIDFN);
            sSQL += " , " + LibraryMOD.GetFieldName(CreationDateFN);
            sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateUserIDFN);
            sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateDateFN);
            sSQL += " , " + LibraryMOD.GetFieldName(PCNameFN);
            sSQL += " , " + LibraryMOD.GetFieldName(NetUserNameFN);
            sSQL += ")";
            sSQL += " VALUES ";
            sSQL += "( ";
            sSQL += " @LecturerID";
            sSQL += " ,@LecturerNameEn";
            sSQL += " ,@LecturerNameAr";
            sSQL += " ,@MCampusID";
            sSQL += " ,@FCampusID";
            sSQL += " ,@CollegeID";
            sSQL += " ,@IsActive";
            sSQL += " ,@Mobile";
            sSQL += " ,@Phone";
            sSQL += " ,@InternalPhone";
            sSQL += " ,@HireDate";
            sSQL += " ,@IsAdvisor";
            sSQL += " ,@IsPartTime";
            sSQL += " ,@CampusID";
            sSQL += " ,@iFacultyType";
            sSQL += " ,@AdvisingDept";
            sSQL += " ,@AdvisingType";
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
            sSQL += LibraryMOD.GetFieldName(LecturerIDFN) + "=@LecturerID";
            //sSQL += " And " + LibraryMOD.GetFieldName(LecturerNameEnFN) + "=@LecturerNameEn";
            //sSQL += " And " + LibraryMOD.GetFieldName(LecturerNameArFN) + "=@LecturerNameAr";
            //sSQL += " And " + LibraryMOD.GetFieldName(MCampusIDFN) + "=@MCampusID";
            //sSQL += " And " + LibraryMOD.GetFieldName(FCampusIDFN) + "=@FCampusID";
            //sSQL += " And " + LibraryMOD.GetFieldName(CollegeIDFN) + "=@CollegeID";
            //sSQL += " And " + LibraryMOD.GetFieldName(IsActiveFN) + "=@IsActive";
            //sSQL += " And " + LibraryMOD.GetFieldName(MobileFN) + "=@Mobile";
            //sSQL += " And " + LibraryMOD.GetFieldName(PhoneFN) + "=@Phone";
            //sSQL += " And " + LibraryMOD.GetFieldName(InternalPhoneFN) + "=@InternalPhone";
            //sSQL += " And " + LibraryMOD.GetFieldName(HireDateFN) + "=@HireDate";
            //sSQL += " And " + LibraryMOD.GetFieldName(IsPartTimeFN) + "=@IsPartTime";
            //sSQL += " And " + LibraryMOD.GetFieldName(CreationUserIDFN) + "=@CreationUserID";
            //sSQL += " And " + LibraryMOD.GetFieldName(CreationDateFN) + "=@CreationDate";
            //sSQL += " And " + LibraryMOD.GetFieldName(LastUpdateUserIDFN) + "=@LastUpdateUserID";
            //sSQL += " And " + LibraryMOD.GetFieldName(LastUpdateDateFN) + "=@LastUpdateDate";
            //sSQL += " And " + LibraryMOD.GetFieldName(PCNameFN) + "=@PCName";
            //sSQL += " And " + LibraryMOD.GetFieldName(NetUserNameFN) + "=@NetUserName";
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
    public ECTNewLecturersDAL()
    {
        try
        {
            this.TableName = "Reg_Lecturers";
            this.LecturerIDFN = m_TableName + ".LecturerID";
            this.LecturerNameEnFN = m_TableName + ".LecturerNameEn";
            this.LecturerNameArFN = m_TableName + ".LecturerNameAr";
            this.MCampusIDFN = m_TableName + ".MCampusID";
            this.FCampusIDFN = m_TableName + ".FCampusID";
            this.CollegeIDFN = m_TableName + ".CollegeID";
            this.IsActiveFN = m_TableName + ".IsActive";
            this.MobileFN = m_TableName + ".Mobile";
            this.PhoneFN = m_TableName + ".Phone";
            this.InternalPhoneFN = m_TableName + ".InternalPhone";
            this.HireDateFN = m_TableName + ".HireDate";
            this.IsAdvisorFN = m_TableName + ".IsAdvisor";
            this.IsPartTimeFN = m_TableName + ".IsPartTimer";
            this.CampusIDFN = m_TableName + ".CampusID";
            this.iFacultyTypeFN = m_TableName + ".iFacultyType";
            this.AdvisingDeptFN = m_TableName + ".strAdvisingDept";
            this.AdvisingTypeFN = m_TableName + ".iAdvisingType";
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
    public List<ECTNewLecturers> GetLecturers(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
    {
        //' returns a list of Classes instances based on the
        //' data in the Lecturers
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
        List<ECTNewLecturers> results = new List<ECTNewLecturers>();
        try
        {
            //Default Value
            ECTNewLecturers myLecturers = new ECTNewLecturers();
            if (isDeafaultIncluded)
            {
                //Change the code here
                myLecturers.LecturerID = 0;
                myLecturers.LecturerNameEn = "Select Instructor ...";
                results.Add(myLecturers);
            }
            while (reader.Read())
            {
                myLecturers = new ECTNewLecturers();
                if (reader[LibraryMOD.GetFieldName(LecturerIDFN)].Equals(DBNull.Value))
                {
                    myLecturers.LecturerID = 0;
                }
                else
                {
                    myLecturers.LecturerID = int.Parse(reader[LibraryMOD.GetFieldName(LecturerIDFN)].ToString());
                }
                myLecturers.LecturerNameEn = reader[LibraryMOD.GetFieldName(LecturerNameEnFN)].ToString();
                myLecturers.LecturerNameAr = reader[LibraryMOD.GetFieldName(LecturerNameArFN)].ToString();
                if (reader[LibraryMOD.GetFieldName(MCampusIDFN)].Equals(DBNull.Value))
                {
                    myLecturers.MCampusID = 0;
                }
                else
                {
                    myLecturers.MCampusID = int.Parse(reader[LibraryMOD.GetFieldName(MCampusIDFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(FCampusIDFN)].Equals(DBNull.Value))
                {
                    myLecturers.FCampusID = 0;
                }
                else
                {
                    myLecturers.FCampusID = int.Parse(reader[LibraryMOD.GetFieldName(FCampusIDFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(CollegeIDFN)].Equals(DBNull.Value))
                {
                    myLecturers.CollegeID = 0;
                }
                else
                {
                    myLecturers.CollegeID = int.Parse(reader[LibraryMOD.GetFieldName(CollegeIDFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(IsActiveFN)].Equals(DBNull.Value))
                {
                    myLecturers.IsActive = 0;
                }
                else
                {
                    myLecturers.IsActive = int.Parse(reader[LibraryMOD.GetFieldName(IsActiveFN)].ToString());
                }
                myLecturers.Mobile = reader[LibraryMOD.GetFieldName(MobileFN)].ToString();
                myLecturers.Phone = reader[LibraryMOD.GetFieldName(PhoneFN)].ToString();
                myLecturers.InternalPhone = reader[LibraryMOD.GetFieldName(InternalPhoneFN)].ToString();
                if (reader[LibraryMOD.GetFieldName(HireDateFN)].Equals(DBNull.Value))
                {
                    myLecturers.HireDate = 0;
                }
                else
                {
                    myLecturers.HireDate = int.Parse(reader[LibraryMOD.GetFieldName(HireDateFN)].ToString());
                }

                if (reader[LibraryMOD.GetFieldName(IsAdvisorFN)].Equals(DBNull.Value))
                {
                    myLecturers.IsAdvisor= 0;
                }
                else
                {
                    myLecturers.IsAdvisor = Convert.ToInt32(bool.Parse(reader[LibraryMOD.GetFieldName(IsAdvisorFN)].ToString()));
                }

                if (reader[LibraryMOD.GetFieldName(IsPartTimeFN)].Equals(DBNull.Value))
                {
                    myLecturers.IsPartTime = 0;
                }
                else
                {
                    myLecturers.IsPartTime = Convert.ToInt32(bool.Parse(reader[LibraryMOD.GetFieldName(IsPartTimeFN)].ToString()));
                }

                if (reader[LibraryMOD.GetFieldName(CampusIDFN)].Equals(DBNull.Value))
                {
                    myLecturers.CampusID = 0;
                }
                else
                {
                    myLecturers.CampusID = int.Parse(reader[LibraryMOD.GetFieldName(CampusIDFN)].ToString());
                }

                if (reader[LibraryMOD.GetFieldName(iFacultyTypeFN)].Equals(DBNull.Value))
                {
                    myLecturers.iFacultyType = 0;
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
                    myLecturers.AdvisingDept = reader[LibraryMOD.GetFieldName(AdvisingDeptFN)].ToString();
                }
                if (reader[LibraryMOD.GetFieldName(AdvisingTypeFN)].Equals(DBNull.Value))
                {
                    myLecturers.AdvisingType = 0;
                }
                else
                {
                    myLecturers.AdvisingType = int.Parse(reader[LibraryMOD.GetFieldName(AdvisingTypeFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(CreationUserIDFN)].Equals(DBNull.Value))
                {
                    myLecturers.CreationUserID = 0;
                }
                else
                {
                    myLecturers.CreationUserID = int.Parse(reader[LibraryMOD.GetFieldName(CreationUserIDFN)].ToString());
                }
                if (!reader[LibraryMOD.GetFieldName(CreationDateFN)].Equals(DBNull.Value))
                {
                    myLecturers.CreationDate = DateTime.Parse(reader[LibraryMOD.GetFieldName(CreationDateFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(LastUpdateUserIDFN)].Equals(DBNull.Value))
                {
                    myLecturers.LastUpdateUserID = 0;
                }
                else
                {
                    myLecturers.LastUpdateUserID = int.Parse(reader[LibraryMOD.GetFieldName(LastUpdateUserIDFN)].ToString());
                }
                if (!reader[LibraryMOD.GetFieldName(LastUpdateDateFN)].Equals(DBNull.Value))
                {
                    myLecturers.LastUpdateDate = DateTime.Parse(reader[LibraryMOD.GetFieldName(LastUpdateDateFN)].ToString());
                }
                myLecturers.PCName = reader[LibraryMOD.GetFieldName(PCNameFN)].ToString();
                myLecturers.NetUserName = reader[LibraryMOD.GetFieldName(NetUserNameFN)].ToString();
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

    public List<ECTNewLecturers> GetCampusLecturer(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
    {
        //' returns a list of Classes instances based on the
        //' data in the Lecturers
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        string sSQL = "SELECT intLecturer, strLecturerDescEn AS sName FROM Reg_Lecturers AS L";
        sSQL += " WHERE 1=1";
        if (!string.IsNullOrEmpty(sCondition))
        {
            sSQL += " And " + sCondition;
        }
        sSQL += " ORDER BY strLecturerDescEn";

        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        SqlCommand Cmd = new SqlCommand(sSQL, Conn);
        Conn.Open();
        SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
        List<ECTNewLecturers> results = new List<ECTNewLecturers>();
        try
        {
            //Default Value
            ECTNewLecturers myLecturers = new ECTNewLecturers();
            if (isDeafaultIncluded)
            {
                //Change the code here
                myLecturers.LecturerID = 0;
                myLecturers.LecturerNameEn = "Select Instructor ...";
                myLecturers.FCampusID = 0;
                myLecturers.MCampusID = 0;
                results.Add(myLecturers);
            }
            while (reader.Read())
            {
                myLecturers = new ECTNewLecturers();
                if (reader["intLecturer"].Equals(DBNull.Value))
                {
                    myLecturers.LecturerID = 0;
                }
                else
                {
                    myLecturers.LecturerID = int.Parse(reader["intLecturer"].ToString());
                }

                myLecturers.LecturerNameEn = reader["sName"].ToString();

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

    public int GetLecturerFaculty(int LecturerID, InitializeModule.EnumCampus Campus)
    {

        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        Conn.Open();
        int iresult = 0;
        try
        {
          
            string sSQL = "SELECT FacultyID FROM Reg_Lecturers ";
            sSQL += " INNER JOIN dbo.Reg_Colleges ";
            sSQL += " ON dbo.Reg_Lecturers.CollegeID = dbo.Reg_Colleges.strCollege";
            sSQL += " WHERE LecturerID =" + LecturerID;

            SqlCommand Cmd = new SqlCommand(sSQL, Conn);
            SqlDataReader reader = Cmd.ExecuteReader();
            iresult = 0;
            while (reader.Read())
            {
                iresult = reader.GetInt32(0);
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
        return iresult;
    }

    public int GetLecturerCollege(int LecturerID, InitializeModule.EnumCampus Campus)
    {

        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        Conn.Open();
        int iresult = 0;
        try
        {

            //tommorow here
            string sSQL = "SELECT " + CollegeIDFN + " FROM Reg_Lecturers";
            sSQL += " WHERE LecturerID =" + LecturerID;

            SqlCommand Cmd = new SqlCommand(sSQL, Conn);
            SqlDataReader reader = Cmd.ExecuteReader();
            iresult = 0;
            while (reader.Read())
            {
                iresult = reader.GetInt32(0);
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
        return iresult;
    }

    public int GetLecturer_MF_ID(int LecturerID, InitializeModule.EnumCampus Campus)
    {

        Connection_StringCLS MyConnection_string = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        Conn.Open();
        int iresult = 0;
        try
        {

            string sSQL = "SELECT " + MCampusIDFN;
            sSQL += ", " + FCampusIDFN;
            // sSQL += ", " + LecturerNameEnFN;
            sSQL += " FROM " + TableName;
            sSQL += " WHERE LecturerID =" + LecturerID;



            SqlCommand Cmd = new SqlCommand(sSQL, Conn);
            SqlDataReader reader = Cmd.ExecuteReader();
            iresult = 0;
            while (reader.Read())
            {
                if (Campus == InitializeModule.EnumCampus.Males)
                {
                    iresult = reader.GetInt32(0);
                }
                else
                {
                    iresult = reader.GetInt32(1);
                }

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
        return iresult;
    }

    public int UpdateLecturers(InitializeModule.EnumCampus Campus, int LecturerID, int MCampusID, int FCampusID, string PCName, string NetUserName)
    {
        int iEffected = 0;
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        try
        {
            Conn.Open();
            string sSQL = "UPDATE " + TableName;
            sSQL += " SET ";

            sSQL += LibraryMOD.GetFieldName(MCampusIDFN) + "=@MCampusID";
            sSQL += " , " + LibraryMOD.GetFieldName(FCampusIDFN) + "=@FCampusID";
            sSQL += " , " + LibraryMOD.GetFieldName(PCNameFN) + "=@PCName";
            sSQL += " , " + LibraryMOD.GetFieldName(NetUserNameFN) + "=@NetUserName";
            sSQL += " WHERE ";
            sSQL += LibraryMOD.GetFieldName(LecturerIDFN) + "=@LecturerID";

            SqlCommand Cmd = new SqlCommand(sSQL, Conn);
            Cmd.Parameters.Add(new SqlParameter("@LecturerID", LecturerID));
            Cmd.Parameters.Add(new SqlParameter("@MCampusID", MCampusID));
            Cmd.Parameters.Add(new SqlParameter("@FCampusID", FCampusID));
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

    public int SetNames(int LecturerID, string sName, int MalesID, int FemalesID)
    {
        int iEffected = 0;
        InitializeModule.EnumCampus Campus = InitializeModule.EnumCampus.ECTNew;
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());

        Conn.Open();

        try
        {
            //Update Main
            string sSQL = "UPDATE " + TableName;
            sSQL += " SET ";
            sSQL += LibraryMOD.GetFieldName(LecturerNameEnFN) + "='" + sName + "'";
            sSQL += " WHERE ";
            sSQL += LibraryMOD.GetFieldName(LecturerIDFN) + "=" + LecturerID;
            SqlCommand Cmd = new SqlCommand(sSQL, Conn);
            iEffected = Cmd.ExecuteNonQuery();

            //Update Males
            iEffected += SetCampusNames(MalesID, sName, InitializeModule.EnumCampus.Males);

            //Update Females
            iEffected += SetCampusNames(FemalesID, sName, InitializeModule.EnumCampus.Females);

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

    public int SetCampusNames(int LecturerID, string sName, InitializeModule.EnumCampus Campus)
    {
        int iEffected = 0;
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        Conn.Open();

        try
        {

            string sSQL = "UPDATE Reg_Lecturers";
            sSQL += " SET strLecturerDescEn ='" + sName + "'";
            sSQL += " WHERE intLecturer=" + LecturerID;

            SqlCommand Cmd = new SqlCommand(sSQL, Conn);

            Cmd.CommandText = sSQL;
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

    public List<ECTNewLecturers> GetList(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
    {
        //' returns a list of Classes instances based on the
        //' data in the Lecturers
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        string sSQL = GetListSQL(sCondition);

        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        SqlCommand Cmd = new SqlCommand(sSQL, Conn);
        Conn.Open();
        SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
        List<ECTNewLecturers> results = new List<ECTNewLecturers>();
        try
        {
            //Default Value
            ECTNewLecturers myLecturers = new ECTNewLecturers();
            if (isDeafaultIncluded)
            {
                //Change the code here
                myLecturers.LecturerID = 0;
                myLecturers.LecturerNameEn = "Select Instructor ...";
                myLecturers.MCampusID = 0;
                myLecturers.FCampusID = 0;
                results.Add(myLecturers);
            }
            while (reader.Read())
            {
                myLecturers = new ECTNewLecturers();
                if (reader[LibraryMOD.GetFieldName(LecturerIDFN)].Equals(DBNull.Value))
                {
                    myLecturers.LecturerID = 0;
                }
                else
                {
                    myLecturers.LecturerID = int.Parse(reader[LibraryMOD.GetFieldName(LecturerIDFN)].ToString());
                }
                myLecturers.LecturerNameEn = reader[LibraryMOD.GetFieldName(LecturerNameEnFN)].ToString();

                if (!reader[LibraryMOD.GetFieldName(MCampusIDFN)].Equals(DBNull.Value))
                {
                    myLecturers.MCampusID = int.Parse(reader[LibraryMOD.GetFieldName(MCampusIDFN)].ToString());
                }
                if (!reader[LibraryMOD.GetFieldName(FCampusIDFN)].Equals(DBNull.Value))
                {
                    myLecturers.FCampusID = int.Parse(reader[LibraryMOD.GetFieldName(FCampusIDFN)].ToString());
                }




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

    public int UpdateLecturers(InitializeModule.EnumCampus Campus, int iMode, int LecturerID, string LecturerNameEn, string LecturerNameAr, int MCampusID, int FCampusID, int CollegeID, int IsActive, string Mobile, string Phone, string InternalPhone, int HireDate,int iIsAdvisor, int IsPartTime, int CampusID, int iFacultyType, string sAdvisingDept, int iAdvisingType, int CreationUserID, DateTime CreationDate, int LastUpdateUserID, DateTime LastUpdateDate, string PCName, string NetUserName)
    {
        int iEffected = 0;
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        try
        {
            Conn.Open();
            string sql = "";
            ECTNewLecturers theLecturers = new ECTNewLecturers();
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
            Cmd.Parameters.Add(new SqlParameter("@LecturerID", LecturerID));
            Cmd.Parameters.Add(new SqlParameter("@LecturerNameEn", LecturerNameEn));
            Cmd.Parameters.Add(new SqlParameter("@LecturerNameAr", LecturerNameAr));
            Cmd.Parameters.Add(new SqlParameter("@MCampusID", MCampusID));
            Cmd.Parameters.Add(new SqlParameter("@FCampusID", FCampusID));
            Cmd.Parameters.Add(new SqlParameter("@CollegeID", CollegeID));
            Cmd.Parameters.Add(new SqlParameter("@IsActive", IsActive));
            Cmd.Parameters.Add(new SqlParameter("@Mobile", Mobile));
            Cmd.Parameters.Add(new SqlParameter("@Phone", Phone));
            Cmd.Parameters.Add(new SqlParameter("@InternalPhone", InternalPhone));
            Cmd.Parameters.Add(new SqlParameter("@HireDate", HireDate));
            Cmd.Parameters.Add(new SqlParameter("@IsAdvisor", iIsAdvisor));
            Cmd.Parameters.Add(new SqlParameter("@IsPartTime", IsPartTime));
            Cmd.Parameters.Add(new SqlParameter("@CampusID", CampusID));
            Cmd.Parameters.Add(new SqlParameter("@iFacultyType", iFacultyType));
            Cmd.Parameters.Add(new SqlParameter("@AdvisingDept", sAdvisingDept));
            Cmd.Parameters.Add(new SqlParameter("@AdvisingType", iAdvisingType));
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
    public int DeleteLecturers(InitializeModule.EnumCampus Campus, string LecturerID)//, string LecturerNameEn, string LecturerNameAr, string MCampusID, string FCampusID, string CollegeID, string IsActive)
    {
        int iEffected = 0;
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        try
        {
            string sSQL = GetDeleteCommand();
            //sSQL += sCondition;
            SqlCommand Cmd = new SqlCommand(sSQL, Conn);
            Cmd.Parameters.Add(new SqlParameter("@LecturerID", LecturerID));
            //Cmd.Parameters.Add(new SqlParameter("@LecturerNameEn", LecturerNameEn));
            //Cmd.Parameters.Add(new SqlParameter("@LecturerNameAr", LecturerNameAr));
            //Cmd.Parameters.Add(new SqlParameter("@MCampusID", MCampusID));
            //Cmd.Parameters.Add(new SqlParameter("@FCampusID", FCampusID));
            //Cmd.Parameters.Add(new SqlParameter("@CollegeID", CollegeID));
            //Cmd.Parameters.Add(new SqlParameter("@IsActive", IsActive));
            //Cmd.Parameters.Add(new SqlParameter("@Mobile", Mobile));
            //Cmd.Parameters.Add(new SqlParameter("@Phone", Phone));
            //Cmd.Parameters.Add(new SqlParameter("@InternalPhone", InternalPhone));
            //Cmd.Parameters.Add(new SqlParameter("@HireDate", HireDate));
            //Cmd.Parameters.Add(new SqlParameter("@IsPartTime", IsPartTime));
            //Cmd.Parameters.Add(new SqlParameter("@CreationUserID", CreationUserID));
            //Cmd.Parameters.Add(new SqlParameter("@CreationDate", CreationDate));
            //Cmd.Parameters.Add(new SqlParameter("@LastUpdateUserID", LastUpdateUserID));
            //Cmd.Parameters.Add(new SqlParameter("@LastUpdateDate", LastUpdateDate));
            //Cmd.Parameters.Add(new SqlParameter("@PCName", PCName));
            //Cmd.Parameters.Add(new SqlParameter("@NetUserName", NetUserName));
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
        DataTable dt = new DataTable("Lecturers");
        DataView dv = new DataView();
        List<ECTNewLecturers> myLecturerss = new List<ECTNewLecturers>();
        try
        {
            myLecturerss = GetList(InitializeModule.EnumCampus.ECTNew, sCondition, false);
            DataColumn col1 = new DataColumn("LecturerID", Type.GetType("int"));
            dt.Columns.Add(col1);
            DataColumn col2 = new DataColumn("LecturerNameEn", Type.GetType("varchar"));
            dt.Columns.Add(col2);

            dt.Constraints.Add(new UniqueConstraint(col1));


            DataRow dr;
            for (int i = 0; i < myLecturerss.Count; i++)
            {
                dr = dt.NewRow();
                dr[1] = myLecturerss[i].LecturerID;
                dr[2] = myLecturerss[i].LecturerNameEn;

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
            sSQL += LecturerIDFN;
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
public class ECTNewLecturersCls : ECTNewLecturersDAL
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
    public ECTNewLecturersCls()
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
            //'cmdRolePermission.Parameters.Add("@LecturerID", SqlDbType.Int, 4, "LecturerID" );
            //'cmdRolePermission.Parameters.Add("@LecturerNameEn", SqlDbType.Int, 4, "LecturerNameEn" );
            //'cmdRolePermission.Parameters.Add("@LecturerNameAr", SqlDbType.Int, 4, "LecturerNameAr" );
            //'cmdRolePermission.Parameters.Add("@MCampusID", SqlDbType.Int, 4, "MCampusID" );
            //'cmdRolePermission.Parameters.Add("@FCampusID", SqlDbType.Int, 4, "FCampusID" );
            //'cmdRolePermission.Parameters.Add("@CollegeID", SqlDbType.Int, 4, "CollegeID" );
            //'cmdRolePermission.Parameters.Add("@IsActive", SqlDbType.Int, 4, "IsActive" );
            //'cmdRolePermission.Parameters.Add("@Mobile", SqlDbType.Int, 4, "Mobile" );
            //'cmdRolePermission.Parameters.Add("@Phone", SqlDbType.Int, 4, "Phone" );
            //'cmdRolePermission.Parameters.Add("@InternalPhone", SqlDbType.Int, 4, "InternalPhone" );
            //'cmdRolePermission.Parameters.Add("@HireDate", SqlDbType.Int, 4, "HireDate" );
            //'cmdRolePermission.Parameters.Add("@IsPartTime", SqlDbType.Int, 4, "IsPartTime" );
            //'cmdRolePermission.Parameters.Add("@CreationUserID", SqlDbType.Int, 4, "CreationUserID" );
            //'cmdRolePermission.Parameters.Add("@CreationDate", SqlDbType.Int, 4, "CreationDate" );
            //'cmdRolePermission.Parameters.Add("@LastUpdateUserID", SqlDbType.Int, 4, "LastUpdateUserID" );
            //'cmdRolePermission.Parameters.Add("@LastUpdateDate", SqlDbType.Int, 4, "LastUpdateDate" );
            //'cmdRolePermission.Parameters.Add("@PCName", SqlDbType.Int, 4, "PCName" );
            //'cmdRolePermission.Parameters.Add("@NetUserName", SqlDbType.Int, 4, "NetUserName" );
            daLecturers.SelectCommand = cmdLecturers;
            //'Add Handlers
            //'RowUpdating,RowUpdated
            AddDAEventHandler();
            //'[UPDATE COMMAND].
            cmdLecturers = new SqlCommand(GetUpdateCommand(), con);
            //'Delete PK Parameteres from here. b/c its declared below
            cmdLecturers.Parameters.Add("@LecturerID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(LecturerIDFN));
            cmdLecturers.Parameters.Add("@LecturerNameEn", SqlDbType.VarChar, 50, LibraryMOD.GetFieldName(LecturerNameEnFN));
            cmdLecturers.Parameters.Add("@LecturerNameAr", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(LecturerNameArFN));
            cmdLecturers.Parameters.Add("@MCampusID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(MCampusIDFN));
            cmdLecturers.Parameters.Add("@FCampusID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(FCampusIDFN));
            cmdLecturers.Parameters.Add("@CollegeID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(CollegeIDFN));
            cmdLecturers.Parameters.Add("@IsActive", SqlDbType.Int, 4, LibraryMOD.GetFieldName(IsActiveFN));
            cmdLecturers.Parameters.Add("@Mobile", SqlDbType.NVarChar, 30, LibraryMOD.GetFieldName(MobileFN));
            cmdLecturers.Parameters.Add("@Phone", SqlDbType.NVarChar, 30, LibraryMOD.GetFieldName(PhoneFN));
            cmdLecturers.Parameters.Add("@InternalPhone", SqlDbType.NVarChar, 8, LibraryMOD.GetFieldName(InternalPhoneFN));
            cmdLecturers.Parameters.Add("@HireDate", SqlDbType.Int, 4, LibraryMOD.GetFieldName(HireDateFN));
            cmdLecturers.Parameters.Add("@IsPartTime", SqlDbType.Int, 4, LibraryMOD.GetFieldName(IsPartTimeFN));
            cmdLecturers.Parameters.Add("@CreationUserID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(CreationUserIDFN));
            cmdLecturers.Parameters.Add("@CreationDate", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(CreationDateFN));
            cmdLecturers.Parameters.Add("@LastUpdateUserID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(LastUpdateUserIDFN));
            cmdLecturers.Parameters.Add("@LastUpdateDate", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(LastUpdateDateFN));
            cmdLecturers.Parameters.Add("@PCName", SqlDbType.NVarChar, 32, LibraryMOD.GetFieldName(PCNameFN));
            cmdLecturers.Parameters.Add("@NetUserName", SqlDbType.NVarChar, 32, LibraryMOD.GetFieldName(NetUserNameFN));


            Parmeter = cmdLecturers.Parameters.Add("@LecturerID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(LecturerIDFN));
            Parmeter = cmdLecturers.Parameters.Add("@LecturerNameEn", SqlDbType.Int, 4, LibraryMOD.GetFieldName(LecturerNameEnFN));
            Parmeter = cmdLecturers.Parameters.Add("@LecturerNameAr", SqlDbType.Int, 4, LibraryMOD.GetFieldName(LecturerNameArFN));
            Parmeter = cmdLecturers.Parameters.Add("@MCampusID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(MCampusIDFN));
            Parmeter = cmdLecturers.Parameters.Add("@FCampusID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(FCampusIDFN));
            Parmeter = cmdLecturers.Parameters.Add("@CollegeID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(CollegeIDFN));
            Parmeter = cmdLecturers.Parameters.Add("@IsActive", SqlDbType.Int, 4, LibraryMOD.GetFieldName(IsActiveFN));
            Parmeter = cmdLecturers.Parameters.Add("@Mobile", SqlDbType.Int, 4, LibraryMOD.GetFieldName(MobileFN));
            Parmeter = cmdLecturers.Parameters.Add("@Phone", SqlDbType.Int, 4, LibraryMOD.GetFieldName(PhoneFN));
            Parmeter = cmdLecturers.Parameters.Add("@InternalPhone", SqlDbType.Int, 4, LibraryMOD.GetFieldName(InternalPhoneFN));
            Parmeter = cmdLecturers.Parameters.Add("@HireDate", SqlDbType.Int, 4, LibraryMOD.GetFieldName(HireDateFN));
            Parmeter = cmdLecturers.Parameters.Add("@IsPartTime", SqlDbType.Int, 4, LibraryMOD.GetFieldName(IsPartTimeFN));
            Parmeter = cmdLecturers.Parameters.Add("@CreationUserID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(CreationUserIDFN));
            Parmeter = cmdLecturers.Parameters.Add("@CreationDate", SqlDbType.Int, 4, LibraryMOD.GetFieldName(CreationDateFN));
            Parmeter = cmdLecturers.Parameters.Add("@LastUpdateUserID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(LastUpdateUserIDFN));
            Parmeter = cmdLecturers.Parameters.Add("@LastUpdateDate", SqlDbType.Int, 4, LibraryMOD.GetFieldName(LastUpdateDateFN));
            Parmeter = cmdLecturers.Parameters.Add("@PCName", SqlDbType.Int, 4, LibraryMOD.GetFieldName(PCNameFN));
            Parmeter = cmdLecturers.Parameters.Add("@NetUserName", SqlDbType.Int, 4, LibraryMOD.GetFieldName(NetUserNameFN));
            Parmeter.SourceVersion = DataRowVersion.Original;
            //'Its should be none for batch updating
            //'UpdateCommand, InsertCommand, and DeleteCommand 
            //'should be set to None or OutputParameters
            daLecturers.UpdateCommand = cmdLecturers;
            daLecturers.UpdateCommand.UpdatedRowSource = UpdateRowSource.None;
            //'-------------------------
            //'/INSERT COMMAND
            cmdLecturers = new SqlCommand(GetInsertCommand(), con);
            cmdLecturers.Parameters.Add("@LecturerID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(LecturerIDFN));
            cmdLecturers.Parameters.Add("@LecturerNameEn", SqlDbType.VarChar, 50, LibraryMOD.GetFieldName(LecturerNameEnFN));
            cmdLecturers.Parameters.Add("@LecturerNameAr", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(LecturerNameArFN));
            cmdLecturers.Parameters.Add("@MCampusID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(MCampusIDFN));
            cmdLecturers.Parameters.Add("@FCampusID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(FCampusIDFN));
            cmdLecturers.Parameters.Add("@CollegeID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(CollegeIDFN));
            cmdLecturers.Parameters.Add("@IsActive", SqlDbType.Int, 4, LibraryMOD.GetFieldName(IsActiveFN));
            cmdLecturers.Parameters.Add("@Mobile", SqlDbType.NVarChar, 30, LibraryMOD.GetFieldName(MobileFN));
            cmdLecturers.Parameters.Add("@Phone", SqlDbType.NVarChar, 30, LibraryMOD.GetFieldName(PhoneFN));
            cmdLecturers.Parameters.Add("@InternalPhone", SqlDbType.NVarChar, 8, LibraryMOD.GetFieldName(InternalPhoneFN));
            cmdLecturers.Parameters.Add("@HireDate", SqlDbType.Int, 4, LibraryMOD.GetFieldName(HireDateFN));
            cmdLecturers.Parameters.Add("@IsPartTime", SqlDbType.Int, 4, LibraryMOD.GetFieldName(IsPartTimeFN));
            cmdLecturers.Parameters.Add("@CreationUserID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(CreationUserIDFN));
            cmdLecturers.Parameters.Add("@CreationDate", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(CreationDateFN));
            cmdLecturers.Parameters.Add("@LastUpdateUserID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(LastUpdateUserIDFN));
            cmdLecturers.Parameters.Add("@LastUpdateDate", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(LastUpdateDateFN));
            cmdLecturers.Parameters.Add("@PCName", SqlDbType.NVarChar, 32, LibraryMOD.GetFieldName(PCNameFN));
            cmdLecturers.Parameters.Add("@NetUserName", SqlDbType.NVarChar, 32, LibraryMOD.GetFieldName(NetUserNameFN));
            Parmeter.SourceVersion = DataRowVersion.Current;
            daLecturers.InsertCommand = cmdLecturers;
            daLecturers.InsertCommand.UpdatedRowSource = UpdateRowSource.None;
            //'------------------------
            //'/DELETE COMMAND
            cmdLecturers = new SqlCommand(GetDeleteCommand(), con);
            Parmeter = cmdLecturers.Parameters.Add("@LecturerID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(LecturerIDFN));
            Parmeter = cmdLecturers.Parameters.Add("@LecturerNameEn", SqlDbType.Int, 4, LibraryMOD.GetFieldName(LecturerNameEnFN));
            Parmeter = cmdLecturers.Parameters.Add("@LecturerNameAr", SqlDbType.Int, 4, LibraryMOD.GetFieldName(LecturerNameArFN));
            Parmeter = cmdLecturers.Parameters.Add("@MCampusID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(MCampusIDFN));
            Parmeter = cmdLecturers.Parameters.Add("@FCampusID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(FCampusIDFN));
            Parmeter = cmdLecturers.Parameters.Add("@CollegeID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(CollegeIDFN));
            Parmeter = cmdLecturers.Parameters.Add("@IsActive", SqlDbType.Int, 4, LibraryMOD.GetFieldName(IsActiveFN));
            Parmeter = cmdLecturers.Parameters.Add("@Mobile", SqlDbType.Int, 4, LibraryMOD.GetFieldName(MobileFN));
            Parmeter = cmdLecturers.Parameters.Add("@Phone", SqlDbType.Int, 4, LibraryMOD.GetFieldName(PhoneFN));
            Parmeter = cmdLecturers.Parameters.Add("@InternalPhone", SqlDbType.Int, 4, LibraryMOD.GetFieldName(InternalPhoneFN));
            Parmeter = cmdLecturers.Parameters.Add("@HireDate", SqlDbType.Int, 4, LibraryMOD.GetFieldName(HireDateFN));
            Parmeter = cmdLecturers.Parameters.Add("@IsPartTime", SqlDbType.Int, 4, LibraryMOD.GetFieldName(IsPartTimeFN));
            Parmeter = cmdLecturers.Parameters.Add("@CreationUserID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(CreationUserIDFN));
            Parmeter = cmdLecturers.Parameters.Add("@CreationDate", SqlDbType.Int, 4, LibraryMOD.GetFieldName(CreationDateFN));
            Parmeter = cmdLecturers.Parameters.Add("@LastUpdateUserID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(LastUpdateUserIDFN));
            Parmeter = cmdLecturers.Parameters.Add("@LastUpdateDate", SqlDbType.Int, 4, LibraryMOD.GetFieldName(LastUpdateDateFN));
            Parmeter = cmdLecturers.Parameters.Add("@PCName", SqlDbType.Int, 4, LibraryMOD.GetFieldName(PCNameFN));
            Parmeter = cmdLecturers.Parameters.Add("@NetUserName", SqlDbType.Int, 4, LibraryMOD.GetFieldName(NetUserNameFN));
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
                    dr[LibraryMOD.GetFieldName(LecturerIDFN)] = LecturerID;
                    dr[LibraryMOD.GetFieldName(LecturerNameEnFN)] = LecturerNameEn;
                    dr[LibraryMOD.GetFieldName(LecturerNameArFN)] = LecturerNameAr;
                    dr[LibraryMOD.GetFieldName(MCampusIDFN)] = MCampusID;
                    dr[LibraryMOD.GetFieldName(FCampusIDFN)] = FCampusID;
                    dr[LibraryMOD.GetFieldName(CollegeIDFN)] = CollegeID;
                    dr[LibraryMOD.GetFieldName(IsActiveFN)] = IsActive;
                    dr[LibraryMOD.GetFieldName(MobileFN)] = Mobile;
                    dr[LibraryMOD.GetFieldName(PhoneFN)] = Phone;
                    dr[LibraryMOD.GetFieldName(InternalPhoneFN)] = InternalPhone;
                    dr[LibraryMOD.GetFieldName(HireDateFN)] = HireDate;
                    dr[LibraryMOD.GetFieldName(IsPartTimeFN)] = IsPartTime;
                    dr[LibraryMOD.GetFieldName(CampusIDFN)] = CampusID;
                    dr[LibraryMOD.GetFieldName(iFacultyTypeFN)] = iFacultyType;
                    dr[LibraryMOD.GetFieldName(CreationUserIDFN)] = InitializeModule.gUserNo;
                    dr[LibraryMOD.GetFieldName(CreationDateFN)] = DateTime.Now; //' CreationDate
                    dr[LibraryMOD.GetFieldName(LastUpdateUserIDFN)] = InitializeModule.gUserNo;  //'LastUpdateUserID
                    dr[LibraryMOD.GetFieldName(LastUpdateDateFN)] = DateTime.Now; //'LastUpdateDate
                    dr[LibraryMOD.GetFieldName(PCNameFN)] = InitializeModule.gPCName;
                    dr[LibraryMOD.GetFieldName(NetUserNameFN)] = InitializeModule.gNetUserName;
                    dsLecturers.Tables[TableName].Rows.Add(dr);
                    break;
                case (int)InitializeModule.enumModes.EditMode:
                    DataRow[] drAry = null;
                    drAry = dsLecturers.Tables[TableName].Select(LibraryMOD.GetFieldName(LecturerIDFN) + "=" + LecturerID + " AND " + LibraryMOD.GetFieldName(LecturerNameEnFN) + "=" + LecturerNameEn + " AND " + LibraryMOD.GetFieldName(LecturerNameArFN) + "=" + LecturerNameAr + " AND " + LibraryMOD.GetFieldName(MCampusIDFN) + "=" + MCampusID + " AND " + LibraryMOD.GetFieldName(FCampusIDFN) + "=" + FCampusID + " AND " + LibraryMOD.GetFieldName(CollegeIDFN) + "=" + CollegeID + " AND " + LibraryMOD.GetFieldName(IsActiveFN) + "=" + IsActive + " AND " + LibraryMOD.GetFieldName(MobileFN) + "=" + Mobile + " AND " + LibraryMOD.GetFieldName(PhoneFN) + "=" + Phone + " AND " + LibraryMOD.GetFieldName(InternalPhoneFN) + "=" + InternalPhone + " AND " + LibraryMOD.GetFieldName(HireDateFN) + "=" + HireDate + " AND " + LibraryMOD.GetFieldName(IsPartTimeFN) + "=" + IsPartTime + " AND " + LibraryMOD.GetFieldName(CreationUserIDFN) + "=" + CreationUserID + " AND " + LibraryMOD.GetFieldName(CreationDateFN) + "=" + CreationDate + " AND " + LibraryMOD.GetFieldName(LastUpdateUserIDFN) + "=" + LastUpdateUserID + " AND " + LibraryMOD.GetFieldName(LastUpdateDateFN) + "=" + LastUpdateDate + " AND " + LibraryMOD.GetFieldName(PCNameFN) + "=" + PCName + " AND " + LibraryMOD.GetFieldName(NetUserNameFN) + "=" + NetUserName);
                    //'its return array of rows and we can access the first by index 0
                    drAry[0][LibraryMOD.GetFieldName(LecturerIDFN)] = LecturerID;
                    drAry[0][LibraryMOD.GetFieldName(LecturerNameEnFN)] = LecturerNameEn;
                    drAry[0][LibraryMOD.GetFieldName(LecturerNameArFN)] = LecturerNameAr;
                    drAry[0][LibraryMOD.GetFieldName(MCampusIDFN)] = MCampusID;
                    drAry[0][LibraryMOD.GetFieldName(FCampusIDFN)] = FCampusID;
                    drAry[0][LibraryMOD.GetFieldName(CollegeIDFN)] = CollegeID;
                    drAry[0][LibraryMOD.GetFieldName(IsActiveFN)] = IsActive;
                    drAry[0][LibraryMOD.GetFieldName(MobileFN)] = Mobile;
                    drAry[0][LibraryMOD.GetFieldName(PhoneFN)] = Phone;
                    drAry[0][LibraryMOD.GetFieldName(InternalPhoneFN)] = InternalPhone;
                    drAry[0][LibraryMOD.GetFieldName(HireDateFN)] = HireDate;
                    drAry[0][LibraryMOD.GetFieldName(IsPartTimeFN)] = IsPartTime;
                    drAry[0][LibraryMOD.GetFieldName(CampusIDFN)] = CampusID;
                    drAry[0][LibraryMOD.GetFieldName(iFacultyTypeFN)] = iFacultyType;
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
            FindInMultiPKey(LecturerID);
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
            if (LecturersDataRow[LibraryMOD.GetFieldName(LecturerIDFN)] == System.DBNull.Value)
            {
                LecturerID = 0;
            }
            else
            {
                LecturerID = (int)LecturersDataRow[LibraryMOD.GetFieldName(LecturerIDFN)];
            }
            if (LecturersDataRow[LibraryMOD.GetFieldName(LecturerNameEnFN)] == System.DBNull.Value)
            {
                LecturerNameEn = "";
            }
            else
            {
                LecturerNameEn = (string)LecturersDataRow[LibraryMOD.GetFieldName(LecturerNameEnFN)];
            }
            if (LecturersDataRow[LibraryMOD.GetFieldName(LecturerNameArFN)] == System.DBNull.Value)
            {
                LecturerNameAr = "";
            }
            else
            {
                LecturerNameAr = (string)LecturersDataRow[LibraryMOD.GetFieldName(LecturerNameArFN)];
            }
            if (LecturersDataRow[LibraryMOD.GetFieldName(MCampusIDFN)] == System.DBNull.Value)
            {
                MCampusID = 0;
            }
            else
            {
                MCampusID = (int)LecturersDataRow[LibraryMOD.GetFieldName(MCampusIDFN)];
            }
            if (LecturersDataRow[LibraryMOD.GetFieldName(FCampusIDFN)] == System.DBNull.Value)
            {
                FCampusID = 0;
            }
            else
            {
                FCampusID = (int)LecturersDataRow[LibraryMOD.GetFieldName(FCampusIDFN)];
            }
            if (LecturersDataRow[LibraryMOD.GetFieldName(CollegeIDFN)] == System.DBNull.Value)
            {
                CollegeID = 0;
            }
            else
            {
                CollegeID = (int)LecturersDataRow[LibraryMOD.GetFieldName(CollegeIDFN)];
            }
            if (LecturersDataRow[LibraryMOD.GetFieldName(IsActiveFN)] == System.DBNull.Value)
            {
                IsActive = 0;
            }
            else
            {
                IsActive = (int)LecturersDataRow[LibraryMOD.GetFieldName(IsActiveFN)];
            }
            if (LecturersDataRow[LibraryMOD.GetFieldName(MobileFN)] == System.DBNull.Value)
            {
                Mobile = "";
            }
            else
            {
                Mobile = (string)LecturersDataRow[LibraryMOD.GetFieldName(MobileFN)];
            }
            if (LecturersDataRow[LibraryMOD.GetFieldName(PhoneFN)] == System.DBNull.Value)
            {
                Phone = "";
            }
            else
            {
                Phone = (string)LecturersDataRow[LibraryMOD.GetFieldName(PhoneFN)];
            }
            if (LecturersDataRow[LibraryMOD.GetFieldName(InternalPhoneFN)] == System.DBNull.Value)
            {
                InternalPhone = "";
            }
            else
            {
                InternalPhone = (string)LecturersDataRow[LibraryMOD.GetFieldName(InternalPhoneFN)];
            }
            if (LecturersDataRow[LibraryMOD.GetFieldName(HireDateFN)] == System.DBNull.Value)
            {
                HireDate = 0;
            }
            else
            {
                HireDate = (int)LecturersDataRow[LibraryMOD.GetFieldName(HireDateFN)];
            }
            if (LecturersDataRow[LibraryMOD.GetFieldName(IsAdvisorFN)] == System.DBNull.Value)
            {
                IsAdvisor = 0;
            }
            else
            {
                IsAdvisor = (int)LecturersDataRow[LibraryMOD.GetFieldName(IsAdvisorFN)];
            }

            if (LecturersDataRow[LibraryMOD.GetFieldName(IsPartTimeFN)] == System.DBNull.Value)
            {
                IsPartTime = 0;
            }
            else
            {
                IsPartTime = (int)LecturersDataRow[LibraryMOD.GetFieldName(IsPartTimeFN)];
            }
            if (LecturersDataRow[LibraryMOD.GetFieldName(iFacultyTypeFN)] == System.DBNull.Value)
            {
                iFacultyType = 0;
            }
            else
            {
                iFacultyType = (int)LecturersDataRow[LibraryMOD.GetFieldName(iFacultyTypeFN)];
            }

            if (LecturersDataRow[LibraryMOD.GetFieldName(CreationUserIDFN)] == System.DBNull.Value)
            {
                CreationUserID = 0;
            }
            else
            {
                CreationUserID = (int)LecturersDataRow[LibraryMOD.GetFieldName(CreationUserIDFN)];
            }
            if (LecturersDataRow[LibraryMOD.GetFieldName(CreationDateFN)] == System.DBNull.Value)
            {
            }
            else
            {
                CreationDate = (DateTime)LecturersDataRow[LibraryMOD.GetFieldName(CreationDateFN)];
            }
            if (LecturersDataRow[LibraryMOD.GetFieldName(LastUpdateUserIDFN)] == System.DBNull.Value)
            {
                LastUpdateUserID = 0;
            }
            else
            {
                LastUpdateUserID = (int)LecturersDataRow[LibraryMOD.GetFieldName(LastUpdateUserIDFN)];
            }
            if (LecturersDataRow[LibraryMOD.GetFieldName(LastUpdateDateFN)] == System.DBNull.Value)
            {
            }
            else
            {
                LastUpdateDate = (DateTime)LecturersDataRow[LibraryMOD.GetFieldName(LastUpdateDateFN)];
            }
            if (LecturersDataRow[LibraryMOD.GetFieldName(PCNameFN)] == System.DBNull.Value)
            {
                PCName = "";
            }
            else
            {
                PCName = (string)LecturersDataRow[LibraryMOD.GetFieldName(PCNameFN)];
            }
            if (LecturersDataRow[LibraryMOD.GetFieldName(NetUserNameFN)] == System.DBNull.Value)
            {
                NetUserName = "";
            }
            else
            {
                NetUserName = (string)LecturersDataRow[LibraryMOD.GetFieldName(NetUserNameFN)];
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
    public int FindInMultiPKey(int PKLecturerID )
    {
        //FindInMultiPKey= InitializeModule.FAIL_RET;
        try
        {
            //' Create an array for the key values to find.
            object[] findTheseVals = new object[1];
            //' Set the values of the keys to find.
            findTheseVals[0] = PKLecturerID;
            //findTheseVals[1] = PKLecturerNameEn;
            //findTheseVals[2] = PKLecturerNameAr;
            //findTheseVals[3] = PKMCampusID;
            //findTheseVals[4] = PKFCampusID;
            //findTheseVals[5] = PKCollegeID;
            //findTheseVals[6] = PKIsActive;
            //findTheseVals[7] = PKMobile;
            //findTheseVals[8] = PKPhone;
            //findTheseVals[9] = PKInternalPhone;
            //findTheseVals[10] = PKHireDate;
            //findTheseVals[11] = PKIsPartTime;
            //findTheseVals[11] = PKiFacultyType;
            //findTheseVals[12] = PKCreationUserID;
            //findTheseVals[13] = PKCreationDate;
            //findTheseVals[14] = PKLastUpdateUserID;
            //findTheseVals[15] = PKLastUpdateDate;
            //findTheseVals[16] = PKPCName;
            //findTheseVals[17] = PKNetUserName;
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
