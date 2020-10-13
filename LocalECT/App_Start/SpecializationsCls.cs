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
public class Specializations
{
    //Creation Date: 14/12/2009 6:35:25 PM
    //Programmer Name : 
    //-----Decleration --------------
    #region "Decleration"
    private string m_strCollege;
    private string m_strDegree;
    private string m_strSpecialization;
    private string m_strAltMajor;
    private string m_strSpecializationDescEn;
    private string m_strSpecializationDescAr;
    private int m_intCenter;
    private DateTime m_dateStart;
    private DateTime m_dateEnd;
    private int m_intStudyHours;
    private int m_ElectiveCreditHours;
    private string m_bAvailable;
    private int m_intStudyYear;
    private int m_byteSemester;
    private int m_bytePapersNumber;
    private int m_byteIncludeICDL;
    private double m_curICDLValue;
    private int m_intSerial;
    private string m_strKey;
    private string m_strMajor;
    private string m_strDisplay;
    private string m_strCaption;
    private int m_CreationUserID;
    private DateTime m_CreationDate;
    private int m_LastUpdateUserID;
    private DateTime m_LastUpdateDate;
    private string m_PCName;
    private string m_NetUserName;
    #endregion
    #region "Puplic Properties"
    //'-----------------------------------------------------
    public string strCollege
    {
        get { return m_strCollege; }
        set { m_strCollege = value; }
    }
    public string strDegree
    {
        get { return m_strDegree; }
        set { m_strDegree = value; }
    }
    public string strSpecialization
    {
        get { return m_strSpecialization; }
        set { m_strSpecialization = value; }
    }
    public string strAltMajor
    {
        get { return m_strAltMajor; }
        set { m_strAltMajor = value; }
    }
    public string strSpecializationDescEn
    {
        get { return m_strSpecializationDescEn; }
        set { m_strSpecializationDescEn = value; }
    }
    public string strSpecializationDescAr
    {
        get { return m_strSpecializationDescAr; }
        set { m_strSpecializationDescAr = value; }
    }
    public int intCenter
    {
        get { return m_intCenter; }
        set { m_intCenter = value; }
    }
    public DateTime dateStart
    {
        get { return m_dateStart; }
        set { m_dateStart = value; }
    }
    public DateTime dateEnd
    {
        get { return m_dateEnd; }
        set { m_dateEnd = value; }
    }
    public int intStudyHours
    {
        get { return m_intStudyHours; }
        set { m_intStudyHours = value; }
    }
    public int ElectiveCreditHours
    {
        get { return m_ElectiveCreditHours; }
        set { m_ElectiveCreditHours = value; }
    }
    public string bAvailable
    {
        get { return m_bAvailable; }
        set { m_bAvailable = value; }
    }
    public int intStudyYear
    {
        get { return m_intStudyYear; }
        set { m_intStudyYear = value; }
    }
    public int byteSemester
    {
        get { return m_byteSemester; }
        set { m_byteSemester = value; }
    }
    public int bytePapersNumber
    {
        get { return m_bytePapersNumber; }
        set { m_bytePapersNumber = value; }
    }
    public int byteIncludeICDL
    {
        get { return m_byteIncludeICDL; }
        set { m_byteIncludeICDL = value; }
    }
    public double curICDLValue
    {
        get { return m_curICDLValue; }
        set { m_curICDLValue = value; }
    }
    public int intSerial
    {
        get { return m_intSerial; }
        set { m_intSerial = value; }
    }
    public string strKey
    {
        get { return m_strKey; }
        set { m_strKey = value; }
    }
    public string strMajor
    {
        get { return m_strMajor; }
        set { m_strMajor = value; }
    }
    public string strDisplay
    {
        get { return m_strDisplay; }
        set { m_strDisplay = value; }
    }
    public string strCaption
    {
        get { return m_strCaption; }
        set { m_strCaption = value; }
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
    public Specializations()
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
public class SpecializationsDAL : Specializations
{
    #region "Decleration"
    private string m_TableName;
    private string m_strCollegeFN;
    private string m_strDegreeFN;
    private string m_strSpecializationFN;
    private string m_strAltMajorFN;
    private string m_strSpecializationDescEnFN;
    private string m_strSpecializationDescArFN;
    private string m_intCenterFN;
    private string m_dateStartFN;
    private string m_dateEndFN;
    private string m_intStudyHoursFN;
    private string m_ElectiveCreditHoursFN;
    private string m_bAvailableFN;
    private string m_intStudyYearFN;
    private string m_byteSemesterFN;
    private string m_bytePapersNumberFN;
    private string m_byteIncludeICDLFN;
    private string m_curICDLValueFN;
    private string m_intSerialFN;
    private string m_strKeyFN;
    private string m_strMajorFN;
    private string m_strDisplayFN;
    private string m_strCaptionFN;
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
    public string strCollegeFN
    {
        get { return m_strCollegeFN; }
        set { m_strCollegeFN = value; }
    }
    public string strDegreeFN
    {
        get { return m_strDegreeFN; }
        set { m_strDegreeFN = value; }
    }
    public string strSpecializationFN
    {
        get { return m_strSpecializationFN; }
        set { m_strSpecializationFN = value; }
    }
    public string strAltMajorFN
    {
        get { return m_strAltMajorFN; }
        set { m_strAltMajorFN = value; }
    }
    public string strSpecializationDescEnFN
    {
        get { return m_strSpecializationDescEnFN; }
        set { m_strSpecializationDescEnFN = value; }
    }
    public string strSpecializationDescArFN
    {
        get { return m_strSpecializationDescArFN; }
        set { m_strSpecializationDescArFN = value; }
    }
    public string intCenterFN
    {
        get { return m_intCenterFN; }
        set { m_intCenterFN = value; }
    }
    public string dateStartFN
    {
        get { return m_dateStartFN; }
        set { m_dateStartFN = value; }
    }
    public string dateEndFN
    {
        get { return m_dateEndFN; }
        set { m_dateEndFN = value; }
    }
    public string intStudyHoursFN
    {
        get { return m_intStudyHoursFN; }
        set { m_intStudyHoursFN = value; }
    }
    public string ElectiveCreditHoursFN
    {
        get { return m_ElectiveCreditHoursFN; }
        set { m_ElectiveCreditHoursFN = value; }
    }
    public string bAvailableFN
    {
        get { return m_bAvailableFN; }
        set { m_bAvailableFN = value; }
    }
    public string intStudyYearFN
    {
        get { return m_intStudyYearFN; }
        set { m_intStudyYearFN = value; }
    }
    public string byteSemesterFN
    {
        get { return m_byteSemesterFN; }
        set { m_byteSemesterFN = value; }
    }
    public string bytePapersNumberFN
    {
        get { return m_bytePapersNumberFN; }
        set { m_bytePapersNumberFN = value; }
    }
    public string byteIncludeICDLFN
    {
        get { return m_byteIncludeICDLFN; }
        set { m_byteIncludeICDLFN = value; }
    }
    public string curICDLValueFN
    {
        get { return m_curICDLValueFN; }
        set { m_curICDLValueFN = value; }
    }
    public string intSerialFN
    {
        get { return m_intSerialFN; }
        set { m_intSerialFN = value; }
    }
    public string strKeyFN
    {
        get { return m_strKeyFN; }
        set { m_strKeyFN = value; }
    }
    public string strMajorFN
    {
        get { return m_strMajorFN; }
        set { m_strMajorFN = value; }
    }
    public string strDisplayFN
    {
        get { return m_strDisplayFN; }
        set { m_strDisplayFN = value; }
    }
    public string strCaptionFN
    {
        get { return m_strCaptionFN; }
        set { m_strCaptionFN = value; }
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
    public SpecializationsDAL()
    {
        try
        {
            this.TableName = "Reg_Specializations";
            this.strCollegeFN = m_TableName + ".strCollege";
            this.strDegreeFN = m_TableName + ".strDegree";
            this.strSpecializationFN = m_TableName + ".strSpecialization";
            this.strAltMajorFN = m_TableName + ".strAltMajor";
            this.strSpecializationDescEnFN = m_TableName + ".strSpecializationDescEn";
            this.strSpecializationDescArFN = m_TableName + ".strSpecializationDescAr";
            this.intCenterFN = m_TableName + ".intCenter";
            this.dateStartFN = m_TableName + ".dateStart";
            this.dateEndFN = m_TableName + ".dateEnd";
            this.intStudyHoursFN = m_TableName + ".intStudyHours";
            this.ElectiveCreditHoursFN = m_TableName + ".ElectiveCreditHours";
            this.bAvailableFN = m_TableName + ".bAvailable";
            this.intStudyYearFN = m_TableName + ".intStudyYear";
            this.byteSemesterFN = m_TableName + ".byteSemester";
            this.bytePapersNumberFN = m_TableName + ".bytePapersNumber";
            this.byteIncludeICDLFN = m_TableName + ".byteIncludeICDL";
            this.curICDLValueFN = m_TableName + ".curICDLValue";
            this.intSerialFN = m_TableName + ".intSerial";
            this.strKeyFN = m_TableName + ".strKey";
            this.strMajorFN = m_TableName + ".strMajor";
            this.strDisplayFN = m_TableName + ".strDisplay";
            this.strCaptionFN = m_TableName + ".strCaption";
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
    #region "Data Access Layer"
    //-----Get SQl Function ---------------------------------
    public string GetSQL()
    {
        string sSQL = "";
        try
        {
            sSQL = "SELECT ";
            sSQL += strCollegeFN;
            sSQL += " , " + strDegreeFN;
            sSQL += " , " + strSpecializationFN;
            sSQL += " , " + strAltMajorFN;
            sSQL += " , " + strSpecializationDescEnFN;
            sSQL += " , " + strSpecializationDescArFN;
            sSQL += " , " + intCenterFN;
            sSQL += " , " + dateStartFN;
            sSQL += " , " + dateEndFN;
            sSQL += " , " + intStudyHoursFN;
            sSQL += " , " + ElectiveCreditHoursFN;
            sSQL += " , " + bAvailableFN;
            sSQL += " , " + intStudyYearFN;
            sSQL += " , " + byteSemesterFN;
            sSQL += " , " + bytePapersNumberFN;
            sSQL += " , " + byteIncludeICDLFN;
            sSQL += " , " + curICDLValueFN;
            sSQL += " , " + intSerialFN;
            sSQL += " , " + strKeyFN;
            sSQL += " , " + strMajorFN;
            sSQL += " , " + strDisplayFN;
            sSQL += " , " + strCaptionFN;
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

    public string GetListMajorIDSQL(string sWhere)
    {
        string sSQL = "";
        try
        {
            sSQL = "SELECT ";
            sSQL += strSpecializationFN ;
            sSQL += " , " + strMajorFN;
            sSQL += "  FROM " + m_TableName;

            sSQL += sWhere;
            sSQL += " Order By (" + intSerialFN + ")";

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
            sSQL += strKeyFN;
            sSQL += " , " + strMajorFN;
            sSQL += " , " + strAltMajorFN ;
            sSQL += " , " + strDegreeFN ;
            sSQL += "  FROM " + m_TableName;
            sSQL += "  WHERE 1=1";
            sSQL += sWhere;
            sSQL += " Order By (" + strMajorFN + ")";

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
            sSQL += strCollegeFN;
            sSQL += " , " + strDegreeFN;
            sSQL += " , " + strSpecializationFN;
            sSQL += " , " + strAltMajorFN;
            sSQL += " , " + strSpecializationDescEnFN;
            sSQL += " , " + strSpecializationDescArFN;
            sSQL += " , " + intCenterFN;
            sSQL += " , " + dateStartFN;
            sSQL += " , " + dateEndFN;
            sSQL += " , " + intStudyHoursFN;
            sSQL += " , " + ElectiveCreditHoursFN;
            sSQL += " , " + bAvailableFN;
            sSQL += " , " + intStudyYearFN;
            sSQL += " , " + byteSemesterFN;
            sSQL += " , " + bytePapersNumberFN;
            sSQL += " , " + byteIncludeICDLFN;
            sSQL += " , " + curICDLValueFN;
            sSQL += " , " + intSerialFN;
            sSQL += " , " + strKeyFN;
            sSQL += " , " + strMajorFN;
            sSQL += " , " + strDisplayFN;
            sSQL += " , " + strCaptionFN;
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
            sSQL += LibraryMOD.GetFieldName(strCollegeFN) + "=@strCollege";
            sSQL += " , " + LibraryMOD.GetFieldName(strDegreeFN) + "=@strDegree";
            sSQL += " , " + LibraryMOD.GetFieldName(strSpecializationFN) + "=@strSpecialization";
            sSQL += " , " + LibraryMOD.GetFieldName(strAltMajorFN) + "=@strAltMajor";
            sSQL += " , " + LibraryMOD.GetFieldName(strSpecializationDescEnFN) + "=@strSpecializationDescEn";
            sSQL += " , " + LibraryMOD.GetFieldName(strSpecializationDescArFN) + "=@strSpecializationDescAr";
            sSQL += " , " + LibraryMOD.GetFieldName(intCenterFN) + "=@intCenter";
            sSQL += " , " + LibraryMOD.GetFieldName(dateStartFN) + "=@dateStart";
            sSQL += " , " + LibraryMOD.GetFieldName(dateEndFN) + "=@dateEnd";
            sSQL += " , " + LibraryMOD.GetFieldName(intStudyHoursFN) + "=@intStudyHours";
            sSQL += " , " + LibraryMOD.GetFieldName(ElectiveCreditHoursFN) + "=@ElectiveCreditHours";
            sSQL += " , " + LibraryMOD.GetFieldName(bAvailableFN) + "=@bAvailable";
            sSQL += " , " + LibraryMOD.GetFieldName(intStudyYearFN) + "=@intStudyYear";
            sSQL += " , " + LibraryMOD.GetFieldName(byteSemesterFN) + "=@byteSemester";
            sSQL += " , " + LibraryMOD.GetFieldName(bytePapersNumberFN) + "=@bytePapersNumber";
            sSQL += " , " + LibraryMOD.GetFieldName(byteIncludeICDLFN) + "=@byteIncludeICDL";
            sSQL += " , " + LibraryMOD.GetFieldName(curICDLValueFN) + "=@curICDLValue";
            sSQL += " , " + LibraryMOD.GetFieldName(intSerialFN) + "=@intSerial";
            sSQL += " , " + LibraryMOD.GetFieldName(strKeyFN) + "=@strKey";
            sSQL += " , " + LibraryMOD.GetFieldName(strMajorFN) + "=@strMajor";
            sSQL += " , " + LibraryMOD.GetFieldName(strDisplayFN) + "=@strDisplay";
            sSQL += " , " + LibraryMOD.GetFieldName(strCaptionFN) + "=@strCaption";
            sSQL += " , " + LibraryMOD.GetFieldName(CreationUserIDFN) + "=@CreationUserID";
            sSQL += " , " + LibraryMOD.GetFieldName(CreationDateFN) + "=@CreationDate";
            sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateUserIDFN) + "=@LastUpdateUserID";
            sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateDateFN) + "=@LastUpdateDate";
            sSQL += " , " + LibraryMOD.GetFieldName(PCNameFN) + "=@PCName";
            sSQL += " , " + LibraryMOD.GetFieldName(NetUserNameFN) + "=@NetUserName";
            sSQL += " WHERE ";
            sSQL += LibraryMOD.GetFieldName(strCollegeFN) + "=@strCollege";
            sSQL += " And " + LibraryMOD.GetFieldName(strDegreeFN) + "=@strDegree";
            sSQL += " And " + LibraryMOD.GetFieldName(strSpecializationFN) + "=@strSpecialization";
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
            sSQL += LibraryMOD.GetFieldName(strCollegeFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strDegreeFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strSpecializationFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strAltMajorFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strSpecializationDescEnFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strSpecializationDescArFN);
            sSQL += " , " + LibraryMOD.GetFieldName(intCenterFN);
            sSQL += " , " + LibraryMOD.GetFieldName(dateStartFN);
            sSQL += " , " + LibraryMOD.GetFieldName(dateEndFN);
            sSQL += " , " + LibraryMOD.GetFieldName(intStudyHoursFN);
            sSQL += " , " + LibraryMOD.GetFieldName(ElectiveCreditHoursFN);
            sSQL += " , " + LibraryMOD.GetFieldName(bAvailableFN);
            sSQL += " , " + LibraryMOD.GetFieldName(intStudyYearFN);
            sSQL += " , " + LibraryMOD.GetFieldName(byteSemesterFN);
            sSQL += " , " + LibraryMOD.GetFieldName(bytePapersNumberFN);
            sSQL += " , " + LibraryMOD.GetFieldName(byteIncludeICDLFN);
            sSQL += " , " + LibraryMOD.GetFieldName(curICDLValueFN);
            sSQL += " , " + LibraryMOD.GetFieldName(intSerialFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strKeyFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strMajorFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strDisplayFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strCaptionFN);
            sSQL += " , " + LibraryMOD.GetFieldName(CreationUserIDFN);
            sSQL += " , " + LibraryMOD.GetFieldName(CreationDateFN);
            sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateUserIDFN);
            sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateDateFN);
            sSQL += " , " + LibraryMOD.GetFieldName(PCNameFN);
            sSQL += " , " + LibraryMOD.GetFieldName(NetUserNameFN);
            sSQL += ")";
            sSQL += " VALUES ";
            sSQL += "( ";
            sSQL += " @strCollege";
            sSQL += " ,@strDegree";
            sSQL += " ,@strSpecialization";
            sSQL += " ,@strAltMajor";
            sSQL += " ,@strSpecializationDescEn";
            sSQL += " ,@strSpecializationDescAr";
            sSQL += " ,@intCenter";
            sSQL += " ,@dateStart";
            sSQL += " ,@dateEnd";
            sSQL += " ,@intStudyHours";
            sSQL += " ,@ElectiveCreditHours";
            sSQL += " ,@bAvailable";
            sSQL += " ,@intStudyYear";
            sSQL += " ,@byteSemester";
            sSQL += " ,@bytePapersNumber";
            sSQL += " ,@byteIncludeICDL";
            sSQL += " ,@curICDLValue";
            sSQL += " ,@intSerial";
            sSQL += " ,@strKey";
            sSQL += " ,@strMajor";
            sSQL += " ,@strDisplay";
            sSQL += " ,@strCaption";
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
            sSQL += LibraryMOD.GetFieldName(strCollegeFN) + "=@strCollege";
            sSQL += " And " + LibraryMOD.GetFieldName(strDegreeFN) + "=@strDegree";
            sSQL += " And " + LibraryMOD.GetFieldName(strSpecializationFN) + "=@strSpecialization";
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
    public List<Specializations> GetSpecializations(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
    {
        //' returns a list of Classes instances based on the
        //' data in the Specializations
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        string sSQL = GetSQL();
        if (!string.IsNullOrEmpty(sCondition))
        {
            sSQL += sCondition;
            
        }
        sSQL += "ORDER BY strSpecializationDescEn";

        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        SqlCommand Cmd = new SqlCommand(sSQL, Conn);
        Conn.Open();
        SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
        List<Specializations> results = new List<Specializations>();
        try
        {
            //Default Value
            Specializations mySpecializations = new Specializations();
            if (isDeafaultIncluded)
            {
                //Change the code here
                mySpecializations.strCollege = "0";
                mySpecializations.strDegree = "0";
                mySpecializations.strSpecialization = "0";
                mySpecializations.strAltMajor = "Select Major ...";
                results.Add(mySpecializations);
            }
            while (reader.Read())
            {
                mySpecializations = new Specializations();
                mySpecializations.strCollege = reader[LibraryMOD.GetFieldName(strCollegeFN)].ToString();
                mySpecializations.strDegree = reader[LibraryMOD.GetFieldName(strDegreeFN)].ToString();
                mySpecializations.strSpecialization = reader[LibraryMOD.GetFieldName(strSpecializationFN)].ToString();
                mySpecializations.strAltMajor = reader[LibraryMOD.GetFieldName(strAltMajorFN)].ToString();
                mySpecializations.strSpecializationDescEn = reader[LibraryMOD.GetFieldName(strSpecializationDescEnFN)].ToString();
                mySpecializations.strSpecializationDescAr = reader[LibraryMOD.GetFieldName(strSpecializationDescArFN)].ToString();
                if (reader[LibraryMOD.GetFieldName(intCenterFN)].Equals(DBNull.Value))
                {
                    mySpecializations.intCenter = 0;
                }
                else
                {
                    mySpecializations.intCenter = int.Parse(reader[LibraryMOD.GetFieldName(intCenterFN)].ToString());
                }
                if (!reader[LibraryMOD.GetFieldName(dateStartFN)].Equals(DBNull.Value))
                {
                    mySpecializations.dateStart = DateTime.Parse(reader[LibraryMOD.GetFieldName(dateStartFN)].ToString());
                }
                if (!reader[LibraryMOD.GetFieldName(dateEndFN)].Equals(DBNull.Value))
                {
                    mySpecializations.dateEnd = DateTime.Parse(reader[LibraryMOD.GetFieldName(dateEndFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(intStudyHoursFN)].Equals(DBNull.Value))
                {
                    mySpecializations.intStudyHours = 0;
                }
                else
                {
                    mySpecializations.intStudyHours = int.Parse(reader[LibraryMOD.GetFieldName(intStudyHoursFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(ElectiveCreditHoursFN)].Equals(DBNull.Value))
                {
                    mySpecializations.ElectiveCreditHours = 0;
                }
                else
                {
                    mySpecializations.ElectiveCreditHours = int.Parse(reader[LibraryMOD.GetFieldName(ElectiveCreditHoursFN)].ToString());
                }
                mySpecializations.bAvailable = reader[LibraryMOD.GetFieldName(bAvailableFN)].ToString();
                if (reader[LibraryMOD.GetFieldName(intStudyYearFN)].Equals(DBNull.Value))
                {
                    mySpecializations.intStudyYear = 0;
                }
                else
                {
                    mySpecializations.intStudyYear = int.Parse(reader[LibraryMOD.GetFieldName(intStudyYearFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(byteSemesterFN)].Equals(DBNull.Value))
                {
                    mySpecializations.byteSemester = 0;
                }
                else
                {
                    mySpecializations.byteSemester = int.Parse(reader[LibraryMOD.GetFieldName(byteSemesterFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(bytePapersNumberFN)].Equals(DBNull.Value))
                {
                    mySpecializations.bytePapersNumber = 0;
                }
                else
                {
                    mySpecializations.bytePapersNumber = int.Parse(reader[LibraryMOD.GetFieldName(bytePapersNumberFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(byteIncludeICDLFN)].Equals(DBNull.Value))
                {
                    mySpecializations.byteIncludeICDL = 0;
                }
                else
                {
                    mySpecializations.byteIncludeICDL = int.Parse(reader[LibraryMOD.GetFieldName(byteIncludeICDLFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(intSerialFN)].Equals(DBNull.Value))
                {
                    mySpecializations.intSerial = 0;
                }
                else
                {
                    mySpecializations.intSerial = int.Parse(reader[LibraryMOD.GetFieldName(intSerialFN)].ToString());
                }
                mySpecializations.strKey = reader[LibraryMOD.GetFieldName(strKeyFN)].ToString();
                mySpecializations.strMajor = reader[LibraryMOD.GetFieldName(strMajorFN)].ToString();
                mySpecializations.strDisplay = reader[LibraryMOD.GetFieldName(strDisplayFN)].ToString();
                mySpecializations.strCaption = reader[LibraryMOD.GetFieldName(strCaptionFN)].ToString();
                if (reader[LibraryMOD.GetFieldName(CreationUserIDFN)].Equals(DBNull.Value))
                {
                    mySpecializations.CreationUserID = 0;
                }
                else
                {
                    mySpecializations.CreationUserID = int.Parse(reader[LibraryMOD.GetFieldName(CreationUserIDFN)].ToString());
                }
                if (!reader[LibraryMOD.GetFieldName(CreationDateFN)].Equals(DBNull.Value))
                {
                    mySpecializations.CreationDate = DateTime.Parse(reader[LibraryMOD.GetFieldName(CreationDateFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(LastUpdateUserIDFN)].Equals(DBNull.Value))
                {
                    mySpecializations.LastUpdateUserID = 0;
                }
                else
                {
                    mySpecializations.LastUpdateUserID = int.Parse(reader[LibraryMOD.GetFieldName(LastUpdateUserIDFN)].ToString());
                }
                if (!reader[LibraryMOD.GetFieldName(LastUpdateDateFN)].Equals(DBNull.Value))
                {
                    mySpecializations.LastUpdateDate = DateTime.Parse(reader[LibraryMOD.GetFieldName(LastUpdateDateFN)].ToString());
                }
                mySpecializations.PCName = reader[LibraryMOD.GetFieldName(PCNameFN)].ToString();
                mySpecializations.NetUserName = reader[LibraryMOD.GetFieldName(NetUserNameFN)].ToString();
                results.Add(mySpecializations);
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

    public List<Specializations> GetList(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
    {

        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        string sSQL = GetListSQL(sCondition);

        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        SqlCommand Cmd = new SqlCommand(sSQL, Conn);
        Conn.Open();
        SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
        List<Specializations> results = new List<Specializations>();
        try
        {
            //Default Value
            Specializations mySpecializations = new Specializations();
            if (isDeafaultIncluded)
            {
                //Change the code here
                mySpecializations.strKey = "000000";
                mySpecializations.strMajor = "Select Major ...";
                results.Add(mySpecializations);
            }
            while (reader.Read())
            {
                mySpecializations = new Specializations();

                mySpecializations.strKey = reader[LibraryMOD.GetFieldName(strKeyFN)].ToString();
                mySpecializations.strMajor = reader[LibraryMOD.GetFieldName(strMajorFN)].ToString();
                mySpecializations.strAltMajor = reader[LibraryMOD.GetFieldName(strAltMajorFN)].ToString();
                mySpecializations.strDegree= reader[LibraryMOD.GetFieldName(strDegreeFN)].ToString();

                results.Add(mySpecializations);
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

    public List<Specializations> GetList(InitializeModule.EnumCampus Campus, string sSQL)
    {

        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
    

        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        SqlCommand Cmd = new SqlCommand(sSQL, Conn);
        Conn.Open();
        SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
        List<Specializations> results = new List<Specializations>();
        try
        {
            //Default Value
            Specializations mySpecializations = new Specializations();

            mySpecializations.strKey = "000000";
            mySpecializations.strMajor = "Select Major ...";
            results.Add(mySpecializations);

            while (reader.Read())
            {
                mySpecializations = new Specializations();

                mySpecializations.strKey = reader[LibraryMOD.GetFieldName(strKeyFN)].ToString();
                mySpecializations.strMajor = reader[LibraryMOD.GetFieldName(strMajorFN)].ToString();
                mySpecializations.strAltMajor = reader[LibraryMOD.GetFieldName(strAltMajorFN)].ToString();
                mySpecializations.strDegree = reader[LibraryMOD.GetFieldName(strDegreeFN)].ToString();

                results.Add(mySpecializations);
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

    public string GetSpecializationCollege(string sCollege, string sDegree,string sMajor)
    {
        string result = "0";
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew );
        
        string sSQL = "Select CollegeID from Reg_CollegeMajors";
        sSQL += " Where CollegeID='" + sCollege + "'";
        sSQL += " AND DegreeID='" + sDegree + "'";
        sSQL += " AND MajorID='" + sMajor + "'";
      

        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        SqlCommand Cmd = new SqlCommand(sSQL, Conn);
        Conn.Open();
        SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);

        try
        {

            while (reader.Read())
            {
                result =reader["CollegeID"].ToString();
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
        return result;
    }
    public bool IsStudyLanguageArabic(string sCollege, string sDegree, string sMajor)
    {
        bool  result = false;
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(InitializeModule.EnumCampus.Males );
        
        string sSQL = "SELECT  isArabic FROM  Reg_Specializations";
        sSQL += " Where strCollege='" + sCollege + "'";
        sSQL += " AND strDegree='" + sDegree + "'";
        sSQL += " AND strSpecialization='" + sMajor + "'";


        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        SqlCommand Cmd = new SqlCommand(sSQL, Conn);
        Conn.Open();
        SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);

        try
        {

            while (reader.Read())
            {
                result = Convert.ToBoolean (reader["isArabic"].ToString());
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
        return result;
    }
    public int GetHours(InitializeModule.EnumCampus Campus, string sCollege,string sDegree,string sMajor)
    {
        int result = 0;
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        string sSQL = "Select intStudyHours from Reg_Specializations";
        sSQL += " Where strCollege='"+ sCollege +"'";
        sSQL += " AND strDegree='"+ sDegree +"'";
        sSQL += " AND strSpecialization='"+ sMajor +"'";

        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        SqlCommand Cmd = new SqlCommand(sSQL, Conn);
        Conn.Open();
        SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
 
        try
        {
           
            while (reader.Read())
            {
                result = int.Parse( reader["intStudyHours"].ToString());
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
        return result;
    }
    public List<Specializations> GetListMajorID(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
    {

        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        string sSQL = GetListMajorIDSQL(sCondition);

        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        SqlCommand Cmd = new SqlCommand(sSQL, Conn);
        Conn.Open();
        SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
        List<Specializations> results = new List<Specializations>();
        try
        {
            //Default Value
            Specializations mySpecializations = new Specializations();
            if (isDeafaultIncluded)
            {
                //Change the code here
                mySpecializations.strSpecialization  = "0";
                mySpecializations.strMajor = "Select Major ...";
                results.Add(mySpecializations);
            }
            while (reader.Read())
            {
                mySpecializations = new Specializations();

                mySpecializations.strSpecialization = reader[LibraryMOD.GetFieldName(strSpecializationFN )].ToString();
                mySpecializations.strMajor = reader[LibraryMOD.GetFieldName(strMajorFN)].ToString();

                results.Add(mySpecializations);
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
    public int UpdateSpecializations(InitializeModule.EnumCampus Campus, int iMode, string strCollege, string strDegree, string strSpecialization, string strAltMajor, string strSpecializationDescEn, string strSpecializationDescAr, int intCenter, DateTime dateStart, DateTime dateEnd, int intStudyHours, int ElectiveCreditHours, string bAvailable, int intStudyYear, int byteSemester, int bytePapersNumber, int byteIncludeICDL, double curICDLValue, int intSerial, string strKey, string strMajor, string strDisplay, string strCaption, int CreationUserID, DateTime CreationDate, int LastUpdateUserID, DateTime LastUpdateDate, string PCName, string NetUserName)
    {
        int iEffected = 0;
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        try
        {
            Conn.Open();
            string sql = "";
            Specializations theSpecializations = new Specializations();
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
            Cmd.Parameters.Add(new SqlParameter("@strCollege", strCollege));
            Cmd.Parameters.Add(new SqlParameter("@strDegree", strDegree));
            Cmd.Parameters.Add(new SqlParameter("@strSpecialization", strSpecialization));
            Cmd.Parameters.Add(new SqlParameter("@strAltMajor", strAltMajor));
            Cmd.Parameters.Add(new SqlParameter("@strSpecializationDescEn", strSpecializationDescEn));
            Cmd.Parameters.Add(new SqlParameter("@strSpecializationDescAr", strSpecializationDescAr));
            Cmd.Parameters.Add(new SqlParameter("@intCenter", intCenter));
            Cmd.Parameters.Add(new SqlParameter("@dateStart", dateStart));
            Cmd.Parameters.Add(new SqlParameter("@dateEnd", dateEnd));
            Cmd.Parameters.Add(new SqlParameter("@intStudyHours", intStudyHours));
            Cmd.Parameters.Add(new SqlParameter("@ElectiveCreditHours", ElectiveCreditHours));
            Cmd.Parameters.Add(new SqlParameter("@bAvailable", bAvailable));
            Cmd.Parameters.Add(new SqlParameter("@intStudyYear", intStudyYear));
            Cmd.Parameters.Add(new SqlParameter("@byteSemester", byteSemester));
            Cmd.Parameters.Add(new SqlParameter("@bytePapersNumber", bytePapersNumber));
            Cmd.Parameters.Add(new SqlParameter("@byteIncludeICDL", byteIncludeICDL));
            Cmd.Parameters.Add(new SqlParameter("@curICDLValue", curICDLValue));
            Cmd.Parameters.Add(new SqlParameter("@intSerial", intSerial));
            Cmd.Parameters.Add(new SqlParameter("@strKey", strKey));
            Cmd.Parameters.Add(new SqlParameter("@strMajor", strMajor));
            Cmd.Parameters.Add(new SqlParameter("@strDisplay", strDisplay));
            Cmd.Parameters.Add(new SqlParameter("@strCaption", strCaption));
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
    public int DeleteSpecializations(InitializeModule.EnumCampus Campus, string strCollege, string strDegree, string strSpecialization)
    {
        int iEffected = 0;
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        try
        {
            string sSQL = GetDeleteCommand();
            //sSQL += sCondition;
            SqlCommand Cmd = new SqlCommand(sSQL, Conn);
            Cmd.Parameters.Add(new SqlParameter("@strCollege", strCollege));
            Cmd.Parameters.Add(new SqlParameter("@strDegree", strDegree));
            Cmd.Parameters.Add(new SqlParameter("@strSpecialization", strSpecialization));
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
        DataTable dt = new DataTable("Specializations");
        DataView dv = new DataView();
        List<Specializations> mySpecializationss = new List<Specializations>();
        try
        {
            mySpecializationss = GetSpecializations(InitializeModule.EnumCampus.ECTNew, sCondition, false);
            DataColumn col1 = new DataColumn("strCollege", Type.GetType("nvarchar"));
            dt.Columns.Add(col1);
            DataColumn col2 = new DataColumn("strDegree", Type.GetType("nvarchar"));
            dt.Columns.Add(col2);
            DataColumn col3 = new DataColumn("strSpecialization", Type.GetType("nvarchar"));
            dt.Columns.Add(col3);
            dt.Constraints.Add(new UniqueConstraint(col1));
            dt.Constraints.Add(new UniqueConstraint(col2));
            dt.Constraints.Add(new UniqueConstraint(col3));

            DataRow dr;
            for (int i = 0; i < mySpecializationss.Count; i++)
            {
                dr = dt.NewRow();
                dr[1] = mySpecializationss[i].strCollege;
                dr[2] = mySpecializationss[i].strDegree;
                dr[3] = mySpecializationss[i].strSpecialization;
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
            mySpecializationss.Clear();
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
            sSQL += strCollegeFN;
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
public class SpecializationsCls : SpecializationsDAL
{
    #region "Decleration"
    private int m_lngCurRow = 0;
    public SqlDataAdapter daSpecializations;
    private DataSet m_dsSpecializations;
    public DataRow SpecializationsDataRow;
    #endregion
    #region "Puplic Properties"
    public DataSet dsSpecializations
    {
        get { return m_dsSpecializations; }
        set { m_dsSpecializations = value; }
    }
    //-----------------------------------------------------
    public int lngCurRow
    {
        get { return m_lngCurRow; }
        set { m_lngCurRow = value; }
    }
    #endregion
    public SpecializationsCls()
    {
        try
        {
            dsSpecializations = new DataSet();

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
    public virtual SqlDataAdapter GetSpecializationsDataAdapter(string sCondition, SqlConnection con)
    {
        string sSQL = "";
        try
        {
            sSQL = GetSQL();
            sSQL += " " + sCondition;
            //-----------------------------------------
            daSpecializations = new SqlDataAdapter(sSQL, con);
            // Create command builder. This line automatically generates the update commands for you, so you don't
            // have to provide or create your own.
            SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daSpecializations);
            //Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
            // key + unique key information to be retrieved unless AddWithKey is specified.
            daSpecializations.MissingSchemaAction = MissingSchemaAction.AddWithKey;
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return daSpecializations;
    }
    public virtual SqlDataAdapter GetSpecializationsDataAdapter(SqlConnection con)
    {
        try
        {
            daSpecializations = new SqlDataAdapter();
            //''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
            //'' key + unique key information to be retrieved unless AddWithKey is specified.
            daSpecializations.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            //-----------------------------------------
            SqlParameter Parmeter = default(SqlParameter);
            //[SELECT COMMAND]
            SqlCommand cmdSpecializations;
            cmdSpecializations = new SqlCommand(GetSelectCommand(), con);
            //'cmdRolePermission.Parameters.Add("@strCollege", SqlDbType.Int, 4, "strCollege" );
            //'cmdRolePermission.Parameters.Add("@strDegree", SqlDbType.Int, 4, "strDegree" );
            //'cmdRolePermission.Parameters.Add("@strSpecialization", SqlDbType.Int, 4, "strSpecialization" );
            daSpecializations.SelectCommand = cmdSpecializations;
            //'Add Handlers
            //'RowUpdating,RowUpdated
            AddDAEventHandler();
            //'[UPDATE COMMAND].
            cmdSpecializations = new SqlCommand(GetUpdateCommand(), con);
            //'Delete PK Parameteres from here. b/c its declared below
            cmdSpecializations.Parameters.Add("@strCollege", SqlDbType.NVarChar, 12, LibraryMOD.GetFieldName(strCollegeFN));
            cmdSpecializations.Parameters.Add("@strDegree", SqlDbType.NVarChar, 12, LibraryMOD.GetFieldName(strDegreeFN));
            cmdSpecializations.Parameters.Add("@strSpecialization", SqlDbType.NVarChar, 12, LibraryMOD.GetFieldName(strSpecializationFN));
            cmdSpecializations.Parameters.Add("@strAltMajor", SqlDbType.NVarChar, 12, LibraryMOD.GetFieldName(strAltMajorFN));
            cmdSpecializations.Parameters.Add("@strSpecializationDescEn", SqlDbType.NVarChar, 160, LibraryMOD.GetFieldName(strSpecializationDescEnFN));
            cmdSpecializations.Parameters.Add("@strSpecializationDescAr", SqlDbType.NVarChar, 160, LibraryMOD.GetFieldName(strSpecializationDescArFN));
            cmdSpecializations.Parameters.Add("@intCenter", SqlDbType.Int, 2, LibraryMOD.GetFieldName(intCenterFN));
            cmdSpecializations.Parameters.Add("@dateStart", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dateStartFN));
            cmdSpecializations.Parameters.Add("@dateEnd", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dateEndFN));
            cmdSpecializations.Parameters.Add("@intStudyHours", SqlDbType.Int, 2, LibraryMOD.GetFieldName(intStudyHoursFN));
            cmdSpecializations.Parameters.Add("@ElectiveCreditHours", SqlDbType.Int, 4, LibraryMOD.GetFieldName(ElectiveCreditHoursFN));
            cmdSpecializations.Parameters.Add("@bAvailable", SqlDbType.Bit, 1, LibraryMOD.GetFieldName(bAvailableFN));
            cmdSpecializations.Parameters.Add("@intStudyYear", SqlDbType.Int, 2, LibraryMOD.GetFieldName(intStudyYearFN));
            cmdSpecializations.Parameters.Add("@byteSemester", SqlDbType.Int, 2, LibraryMOD.GetFieldName(byteSemesterFN));
            cmdSpecializations.Parameters.Add("@bytePapersNumber", SqlDbType.Int, 2, LibraryMOD.GetFieldName(bytePapersNumberFN));
            cmdSpecializations.Parameters.Add("@byteIncludeICDL", SqlDbType.Int, 2, LibraryMOD.GetFieldName(byteIncludeICDLFN));
            cmdSpecializations.Parameters.Add("@curICDLValue", SqlDbType.Money, 21, LibraryMOD.GetFieldName(curICDLValueFN));
            cmdSpecializations.Parameters.Add("@intSerial", SqlDbType.Int, 4, LibraryMOD.GetFieldName(intSerialFN));
            cmdSpecializations.Parameters.Add("@strKey", SqlDbType.NVarChar, 12, LibraryMOD.GetFieldName(strKeyFN));
            cmdSpecializations.Parameters.Add("@strMajor", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strMajorFN));
            cmdSpecializations.Parameters.Add("@strDisplay", SqlDbType.NVarChar, 160, LibraryMOD.GetFieldName(strDisplayFN));
            cmdSpecializations.Parameters.Add("@strCaption", SqlDbType.NVarChar, 160, LibraryMOD.GetFieldName(strCaptionFN));
            cmdSpecializations.Parameters.Add("@CreationUserID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(CreationUserIDFN));
            cmdSpecializations.Parameters.Add("@CreationDate", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(CreationDateFN));
            cmdSpecializations.Parameters.Add("@LastUpdateUserID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(LastUpdateUserIDFN));
            cmdSpecializations.Parameters.Add("@LastUpdateDate", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(LastUpdateDateFN));
            cmdSpecializations.Parameters.Add("@PCName", SqlDbType.NVarChar, 32, LibraryMOD.GetFieldName(PCNameFN));
            cmdSpecializations.Parameters.Add("@NetUserName", SqlDbType.NVarChar, 32, LibraryMOD.GetFieldName(NetUserNameFN));


            Parmeter = cmdSpecializations.Parameters.Add("@strCollege", SqlDbType.Int, 4, LibraryMOD.GetFieldName(strCollegeFN));
            Parmeter = cmdSpecializations.Parameters.Add("@strDegree", SqlDbType.Int, 4, LibraryMOD.GetFieldName(strDegreeFN));
            Parmeter = cmdSpecializations.Parameters.Add("@strSpecialization", SqlDbType.Int, 4, LibraryMOD.GetFieldName(strSpecializationFN));
            Parmeter.SourceVersion = DataRowVersion.Original;
            //'Its should be none for batch updating
            //'UpdateCommand, InsertCommand, and DeleteCommand 
            //'should be set to None or OutputParameters
            daSpecializations.UpdateCommand = cmdSpecializations;
            daSpecializations.UpdateCommand.UpdatedRowSource = UpdateRowSource.None;
            //'-------------------------
            //'/INSERT COMMAND
            cmdSpecializations = new SqlCommand(GetInsertCommand(), con);
            cmdSpecializations.Parameters.Add("@strCollege", SqlDbType.NVarChar, 12, LibraryMOD.GetFieldName(strCollegeFN));
            cmdSpecializations.Parameters.Add("@strDegree", SqlDbType.NVarChar, 12, LibraryMOD.GetFieldName(strDegreeFN));
            cmdSpecializations.Parameters.Add("@strSpecialization", SqlDbType.NVarChar, 12, LibraryMOD.GetFieldName(strSpecializationFN));
            cmdSpecializations.Parameters.Add("@strAltMajor", SqlDbType.NVarChar, 12, LibraryMOD.GetFieldName(strAltMajorFN));
            cmdSpecializations.Parameters.Add("@strSpecializationDescEn", SqlDbType.NVarChar, 160, LibraryMOD.GetFieldName(strSpecializationDescEnFN));
            cmdSpecializations.Parameters.Add("@strSpecializationDescAr", SqlDbType.NVarChar, 160, LibraryMOD.GetFieldName(strSpecializationDescArFN));
            cmdSpecializations.Parameters.Add("@intCenter", SqlDbType.Int, 2, LibraryMOD.GetFieldName(intCenterFN));
            cmdSpecializations.Parameters.Add("@dateStart", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dateStartFN));
            cmdSpecializations.Parameters.Add("@dateEnd", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dateEndFN));
            cmdSpecializations.Parameters.Add("@intStudyHours", SqlDbType.Int, 2, LibraryMOD.GetFieldName(intStudyHoursFN));
            cmdSpecializations.Parameters.Add("@ElectiveCreditHours", SqlDbType.Int, 4, LibraryMOD.GetFieldName(ElectiveCreditHoursFN));
            cmdSpecializations.Parameters.Add("@bAvailable", SqlDbType.Bit, 1, LibraryMOD.GetFieldName(bAvailableFN));
            cmdSpecializations.Parameters.Add("@intStudyYear", SqlDbType.Int, 2, LibraryMOD.GetFieldName(intStudyYearFN));
            cmdSpecializations.Parameters.Add("@byteSemester", SqlDbType.Int, 2, LibraryMOD.GetFieldName(byteSemesterFN));
            cmdSpecializations.Parameters.Add("@bytePapersNumber", SqlDbType.Int, 2, LibraryMOD.GetFieldName(bytePapersNumberFN));
            cmdSpecializations.Parameters.Add("@byteIncludeICDL", SqlDbType.Int, 2, LibraryMOD.GetFieldName(byteIncludeICDLFN));
            cmdSpecializations.Parameters.Add("@curICDLValue", SqlDbType.Money, 21, LibraryMOD.GetFieldName(curICDLValueFN));
            cmdSpecializations.Parameters.Add("@intSerial", SqlDbType.Int, 4, LibraryMOD.GetFieldName(intSerialFN));
            cmdSpecializations.Parameters.Add("@strKey", SqlDbType.NVarChar, 12, LibraryMOD.GetFieldName(strKeyFN));
            cmdSpecializations.Parameters.Add("@strMajor", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strMajorFN));
            cmdSpecializations.Parameters.Add("@strDisplay", SqlDbType.NVarChar, 160, LibraryMOD.GetFieldName(strDisplayFN));
            cmdSpecializations.Parameters.Add("@strCaption", SqlDbType.NVarChar, 160, LibraryMOD.GetFieldName(strCaptionFN));
            cmdSpecializations.Parameters.Add("@CreationUserID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(CreationUserIDFN));
            cmdSpecializations.Parameters.Add("@CreationDate", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(CreationDateFN));
            cmdSpecializations.Parameters.Add("@LastUpdateUserID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(LastUpdateUserIDFN));
            cmdSpecializations.Parameters.Add("@LastUpdateDate", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(LastUpdateDateFN));
            cmdSpecializations.Parameters.Add("@PCName", SqlDbType.NVarChar, 32, LibraryMOD.GetFieldName(PCNameFN));
            cmdSpecializations.Parameters.Add("@NetUserName", SqlDbType.NVarChar, 32, LibraryMOD.GetFieldName(NetUserNameFN));
            Parmeter.SourceVersion = DataRowVersion.Current;
            daSpecializations.InsertCommand = cmdSpecializations;
            daSpecializations.InsertCommand.UpdatedRowSource = UpdateRowSource.None;
            //'------------------------
            //'/DELETE COMMAND
            cmdSpecializations = new SqlCommand(GetDeleteCommand(), con);
            Parmeter = cmdSpecializations.Parameters.Add("@strCollege", SqlDbType.Int, 4, LibraryMOD.GetFieldName(strCollegeFN));
            Parmeter = cmdSpecializations.Parameters.Add("@strDegree", SqlDbType.Int, 4, LibraryMOD.GetFieldName(strDegreeFN));
            Parmeter = cmdSpecializations.Parameters.Add("@strSpecialization", SqlDbType.Int, 4, LibraryMOD.GetFieldName(strSpecializationFN));
            Parmeter.SourceVersion = DataRowVersion.Original;
            daSpecializations.DeleteCommand = cmdSpecializations;
            daSpecializations.DeleteCommand.UpdatedRowSource = UpdateRowSource.None;
            //'Batch Size
            //'Set the batch size.
            daSpecializations.UpdateBatchSize = InitializeModule.BATCH_SIZE;
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return daSpecializations;
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
                    dr = dsSpecializations.Tables[TableName].NewRow();
                    dr[LibraryMOD.GetFieldName(strCollegeFN)] = strCollege;
                    dr[LibraryMOD.GetFieldName(strDegreeFN)] = strDegree;
                    dr[LibraryMOD.GetFieldName(strSpecializationFN)] = strSpecialization;
                    dr[LibraryMOD.GetFieldName(strAltMajorFN)] = strAltMajor;
                    dr[LibraryMOD.GetFieldName(strSpecializationDescEnFN)] = strSpecializationDescEn;
                    dr[LibraryMOD.GetFieldName(strSpecializationDescArFN)] = strSpecializationDescAr;
                    dr[LibraryMOD.GetFieldName(intCenterFN)] = intCenter;
                    dr[LibraryMOD.GetFieldName(dateStartFN)] = dateStart;
                    dr[LibraryMOD.GetFieldName(dateEndFN)] = dateEnd;
                    dr[LibraryMOD.GetFieldName(intStudyHoursFN)] = intStudyHours;
                    dr[LibraryMOD.GetFieldName(ElectiveCreditHoursFN)] = ElectiveCreditHours;
                    dr[LibraryMOD.GetFieldName(bAvailableFN)] = bAvailable;
                    dr[LibraryMOD.GetFieldName(intStudyYearFN)] = intStudyYear;
                    dr[LibraryMOD.GetFieldName(byteSemesterFN)] = byteSemester;
                    dr[LibraryMOD.GetFieldName(bytePapersNumberFN)] = bytePapersNumber;
                    dr[LibraryMOD.GetFieldName(byteIncludeICDLFN)] = byteIncludeICDL;
                    dr[LibraryMOD.GetFieldName(curICDLValueFN)] = curICDLValue;
                    dr[LibraryMOD.GetFieldName(intSerialFN)] = intSerial;
                    dr[LibraryMOD.GetFieldName(strKeyFN)] = strKey;
                    dr[LibraryMOD.GetFieldName(strMajorFN)] = strMajor;
                    dr[LibraryMOD.GetFieldName(strDisplayFN)] = strDisplay;
                    dr[LibraryMOD.GetFieldName(strCaptionFN)] = strCaption;
                    dr[LibraryMOD.GetFieldName(CreationUserIDFN)] = InitializeModule.gUserNo;
                    dr[LibraryMOD.GetFieldName(CreationDateFN)] = DateTime.Now; //' CreationDate
                    dr[LibraryMOD.GetFieldName(LastUpdateUserIDFN)] = InitializeModule.gUserNo;  //'LastUpdateUserID
                    dr[LibraryMOD.GetFieldName(LastUpdateDateFN)] = DateTime.Now; //'LastUpdateDate
                    dr[LibraryMOD.GetFieldName(PCNameFN)] = InitializeModule.gPCName;
                    dr[LibraryMOD.GetFieldName(NetUserNameFN)] = InitializeModule.gNetUserName;
                    dsSpecializations.Tables[TableName].Rows.Add(dr);
                    break;
                case (int)InitializeModule.enumModes.EditMode:
                    DataRow[] drAry = null;
                    drAry = dsSpecializations.Tables[TableName].Select(LibraryMOD.GetFieldName(strCollegeFN) + "=" + strCollege + " AND " + LibraryMOD.GetFieldName(strDegreeFN) + "=" + strDegree + " AND " + LibraryMOD.GetFieldName(strSpecializationFN) + "=" + strSpecialization);
                    //'its return array of rows and we can access the first by index 0
                    drAry[0][LibraryMOD.GetFieldName(strCollegeFN)] = strCollege;
                    drAry[0][LibraryMOD.GetFieldName(strDegreeFN)] = strDegree;
                    drAry[0][LibraryMOD.GetFieldName(strSpecializationFN)] = strSpecialization;
                    drAry[0][LibraryMOD.GetFieldName(strAltMajorFN)] = strAltMajor;
                    drAry[0][LibraryMOD.GetFieldName(strSpecializationDescEnFN)] = strSpecializationDescEn;
                    drAry[0][LibraryMOD.GetFieldName(strSpecializationDescArFN)] = strSpecializationDescAr;
                    drAry[0][LibraryMOD.GetFieldName(intCenterFN)] = intCenter;
                    drAry[0][LibraryMOD.GetFieldName(dateStartFN)] = dateStart;
                    drAry[0][LibraryMOD.GetFieldName(dateEndFN)] = dateEnd;
                    drAry[0][LibraryMOD.GetFieldName(intStudyHoursFN)] = intStudyHours;
                    drAry[0][LibraryMOD.GetFieldName(ElectiveCreditHoursFN)] = ElectiveCreditHours;
                    drAry[0][LibraryMOD.GetFieldName(bAvailableFN)] = bAvailable;
                    drAry[0][LibraryMOD.GetFieldName(intStudyYearFN)] = intStudyYear;
                    drAry[0][LibraryMOD.GetFieldName(byteSemesterFN)] = byteSemester;
                    drAry[0][LibraryMOD.GetFieldName(bytePapersNumberFN)] = bytePapersNumber;
                    drAry[0][LibraryMOD.GetFieldName(byteIncludeICDLFN)] = byteIncludeICDL;
                    drAry[0][LibraryMOD.GetFieldName(curICDLValueFN)] = curICDLValue;
                    drAry[0][LibraryMOD.GetFieldName(intSerialFN)] = intSerial;
                    drAry[0][LibraryMOD.GetFieldName(strKeyFN)] = strKey;
                    drAry[0][LibraryMOD.GetFieldName(strMajorFN)] = strMajor;
                    drAry[0][LibraryMOD.GetFieldName(strDisplayFN)] = strDisplay;
                    drAry[0][LibraryMOD.GetFieldName(strCaptionFN)] = strCaption;
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
    public int CommitSpecializations()
    {
        //CommitSpecializations= InitializeModule.FAIL_RET;
        try
        {
            //'' Update Database with SqlDataAdapter
            daSpecializations.Update(dsSpecializations, TableName);
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
            FindInMultiPKey(strCollege, strDegree, strSpecialization);
            if ((SpecializationsDataRow != null))
            {
                SpecializationsDataRow.Delete();
                CommitSpecializations();
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
            if (SpecializationsDataRow[LibraryMOD.GetFieldName(strCollegeFN)] == System.DBNull.Value)
            {
                strCollege = "";
            }
            else
            {
                strCollege = (string)SpecializationsDataRow[LibraryMOD.GetFieldName(strCollegeFN)];
            }
            if (SpecializationsDataRow[LibraryMOD.GetFieldName(strDegreeFN)] == System.DBNull.Value)
            {
                strDegree = "";
            }
            else
            {
                strDegree = (string)SpecializationsDataRow[LibraryMOD.GetFieldName(strDegreeFN)];
            }
            if (SpecializationsDataRow[LibraryMOD.GetFieldName(strSpecializationFN)] == System.DBNull.Value)
            {
                strSpecialization = "";
            }
            else
            {
                strSpecialization = (string)SpecializationsDataRow[LibraryMOD.GetFieldName(strSpecializationFN)];
            }
            if (SpecializationsDataRow[LibraryMOD.GetFieldName(strAltMajorFN)] == System.DBNull.Value)
            {
                strAltMajor = "";
            }
            else
            {
                strAltMajor = (string)SpecializationsDataRow[LibraryMOD.GetFieldName(strAltMajorFN)];
            }
            if (SpecializationsDataRow[LibraryMOD.GetFieldName(strSpecializationDescEnFN)] == System.DBNull.Value)
            {
                strSpecializationDescEn = "";
            }
            else
            {
                strSpecializationDescEn = (string)SpecializationsDataRow[LibraryMOD.GetFieldName(strSpecializationDescEnFN)];
            }
            if (SpecializationsDataRow[LibraryMOD.GetFieldName(strSpecializationDescArFN)] == System.DBNull.Value)
            {
                strSpecializationDescAr = "";
            }
            else
            {
                strSpecializationDescAr = (string)SpecializationsDataRow[LibraryMOD.GetFieldName(strSpecializationDescArFN)];
            }
            if (SpecializationsDataRow[LibraryMOD.GetFieldName(intCenterFN)] == System.DBNull.Value)
            {
                intCenter = 0;
            }
            else
            {
                intCenter = (int)SpecializationsDataRow[LibraryMOD.GetFieldName(intCenterFN)];
            }
            if (SpecializationsDataRow[LibraryMOD.GetFieldName(dateStartFN)] == System.DBNull.Value)
            {
            }
            else
            {
                dateStart = (DateTime)SpecializationsDataRow[LibraryMOD.GetFieldName(dateStartFN)];
            }
            if (SpecializationsDataRow[LibraryMOD.GetFieldName(dateEndFN)] == System.DBNull.Value)
            {
            }
            else
            {
                dateEnd = (DateTime)SpecializationsDataRow[LibraryMOD.GetFieldName(dateEndFN)];
            }
            if (SpecializationsDataRow[LibraryMOD.GetFieldName(intStudyHoursFN)] == System.DBNull.Value)
            {
                intStudyHours = 0;
            }
            else
            {
                intStudyHours = (int)SpecializationsDataRow[LibraryMOD.GetFieldName(intStudyHoursFN)];
            }
            if (SpecializationsDataRow[LibraryMOD.GetFieldName(ElectiveCreditHoursFN)] == System.DBNull.Value)
            {
                ElectiveCreditHours = 0;
            }
            else
            {
                ElectiveCreditHours = (int)SpecializationsDataRow[LibraryMOD.GetFieldName(ElectiveCreditHoursFN)];
            }
            if (SpecializationsDataRow[LibraryMOD.GetFieldName(bAvailableFN)] == System.DBNull.Value)
            {
                bAvailable = "";
            }
            else
            {
                bAvailable = (string)SpecializationsDataRow[LibraryMOD.GetFieldName(bAvailableFN)];
            }
            if (SpecializationsDataRow[LibraryMOD.GetFieldName(intStudyYearFN)] == System.DBNull.Value)
            {
                intStudyYear = 0;
            }
            else
            {
                intStudyYear = (int)SpecializationsDataRow[LibraryMOD.GetFieldName(intStudyYearFN)];
            }
            if (SpecializationsDataRow[LibraryMOD.GetFieldName(byteSemesterFN)] == System.DBNull.Value)
            {
                byteSemester = 0;
            }
            else
            {
                byteSemester = (int)SpecializationsDataRow[LibraryMOD.GetFieldName(byteSemesterFN)];
            }
            if (SpecializationsDataRow[LibraryMOD.GetFieldName(bytePapersNumberFN)] == System.DBNull.Value)
            {
                bytePapersNumber = 0;
            }
            else
            {
                bytePapersNumber = (int)SpecializationsDataRow[LibraryMOD.GetFieldName(bytePapersNumberFN)];
            }
            if (SpecializationsDataRow[LibraryMOD.GetFieldName(byteIncludeICDLFN)] == System.DBNull.Value)
            {
                byteIncludeICDL = 0;
            }
            else
            {
                byteIncludeICDL = (int)SpecializationsDataRow[LibraryMOD.GetFieldName(byteIncludeICDLFN)];
            }
            if (SpecializationsDataRow[LibraryMOD.GetFieldName(curICDLValueFN)] == System.DBNull.Value)
            {
            }
            else
            {
            }
            if (SpecializationsDataRow[LibraryMOD.GetFieldName(intSerialFN)] == System.DBNull.Value)
            {
                intSerial = 0;
            }
            else
            {
                intSerial = (int)SpecializationsDataRow[LibraryMOD.GetFieldName(intSerialFN)];
            }
            if (SpecializationsDataRow[LibraryMOD.GetFieldName(strKeyFN)] == System.DBNull.Value)
            {
                strKey = "";
            }
            else
            {
                strKey = (string)SpecializationsDataRow[LibraryMOD.GetFieldName(strKeyFN)];
            }
            if (SpecializationsDataRow[LibraryMOD.GetFieldName(strMajorFN)] == System.DBNull.Value)
            {
                strMajor = "";
            }
            else
            {
                strMajor = (string)SpecializationsDataRow[LibraryMOD.GetFieldName(strMajorFN)];
            }
            if (SpecializationsDataRow[LibraryMOD.GetFieldName(strDisplayFN)] == System.DBNull.Value)
            {
                strDisplay = "";
            }
            else
            {
                strDisplay = (string)SpecializationsDataRow[LibraryMOD.GetFieldName(strDisplayFN)];
            }

            if (SpecializationsDataRow[LibraryMOD.GetFieldName(strCaptionFN)] == System.DBNull.Value)
            {
                strCaption = "";
            }
            else
            {
                strCaption = (string)SpecializationsDataRow[LibraryMOD.GetFieldName(strCaptionFN)];
            }
            

            if (SpecializationsDataRow[LibraryMOD.GetFieldName(CreationUserIDFN)] == System.DBNull.Value)
            {
                CreationUserID = 0;
            }
            else
            {
                CreationUserID = (int)SpecializationsDataRow[LibraryMOD.GetFieldName(CreationUserIDFN)];
            }
            if (SpecializationsDataRow[LibraryMOD.GetFieldName(CreationDateFN)] == System.DBNull.Value)
            {
            }
            else
            {
                CreationDate = (DateTime)SpecializationsDataRow[LibraryMOD.GetFieldName(CreationDateFN)];
            }
            if (SpecializationsDataRow[LibraryMOD.GetFieldName(LastUpdateUserIDFN)] == System.DBNull.Value)
            {
                LastUpdateUserID = 0;
            }
            else
            {
                LastUpdateUserID = (int)SpecializationsDataRow[LibraryMOD.GetFieldName(LastUpdateUserIDFN)];
            }
            if (SpecializationsDataRow[LibraryMOD.GetFieldName(LastUpdateDateFN)] == System.DBNull.Value)
            {
            }
            else
            {
                LastUpdateDate = (DateTime)SpecializationsDataRow[LibraryMOD.GetFieldName(LastUpdateDateFN)];
            }
            if (SpecializationsDataRow[LibraryMOD.GetFieldName(PCNameFN)] == System.DBNull.Value)
            {
                PCName = "";
            }
            else
            {
                PCName = (string)SpecializationsDataRow[LibraryMOD.GetFieldName(PCNameFN)];
            }
            if (SpecializationsDataRow[LibraryMOD.GetFieldName(NetUserNameFN)] == System.DBNull.Value)
            {
                NetUserName = "";
            }
            else
            {
                NetUserName = (string)SpecializationsDataRow[LibraryMOD.GetFieldName(NetUserNameFN)];
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
    public int FindInMultiPKey(string PKstrCollege, string PKstrDegree, string PKstrSpecialization)
    {
        //FindInMultiPKey= InitializeModule.FAIL_RET;
        try
        {
            //' Create an array for the key values to find.
            object[] findTheseVals = new object[1];
            //' Set the values of the keys to find.
            findTheseVals[0] = PKstrCollege;
            findTheseVals[1] = PKstrDegree;
            findTheseVals[2] = PKstrSpecialization;
            SpecializationsDataRow = dsSpecializations.Tables[TableName].Rows.Find(findTheseVals);
            if ((SpecializationsDataRow != null))
            {
                lngCurRow = dsSpecializations.Tables[TableName].Rows.IndexOf(SpecializationsDataRow);
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
            lngCurRow = dsSpecializations.Tables[TableName].Rows.Count - 1; //'Zero based index
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
            lngCurRow = Math.Min(lngCurRow + 1, dsSpecializations.Tables[TableName].Rows.Count - 1);
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
            if (lngCurRow >= 0 & dsSpecializations.Tables[TableName].Rows.Count > 0)
            {
                SpecializationsDataRow = dsSpecializations.Tables[TableName].Rows[lngCurRow];
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
            daSpecializations.RowUpdating += new SqlRowUpdatingEventHandler(OnRowUpdating);
            daSpecializations.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
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
            daSpecializations.RowUpdating -= new SqlRowUpdatingEventHandler(OnRowUpdating);
            daSpecializations.RowUpdated -= new SqlRowUpdatedEventHandler(OnRowUpdated);
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
