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
public class Reg_History
    {
    //Creation Date: 10/04/2014 3:36 PM
//Programmer Name : Bahaa Addin
//-----Decleration --------------
                                                                                                        #region "Decleration"
private int m_Term; 
private int m_CampusID; 
private int m_Session; 
private int m_RegOld_Diploma; 
private int m_RegOld_BA; 
private int m_RegNew_Diploma; 
private int m_RegNew_BA; 
private int m_RegExtended_Diploma; 
private int m_RegExtended_BA;
private int m_RegExtended_ESL; 
private int m_RegOld_Foundation; 
private int m_RegNew_Foundation;
private int m_RegOld_ESL;
private int m_RegNew_ESL;
private int m_RegOld_Visiting;
private int m_RegNew_Visiting;

private int m_UnRegOld_Diploma; 
private int m_UnRegOld_BA; 
private int m_UnRegNew_Diploma; 
private int m_UnRegNew_BA; 
private int m_UnRegExtended_Diploma; 
private int m_UnRegExtended_BA;
private int m_UnRegExtended_ESL; 
private int m_UnRegOld_Foundation; 
private int m_UnRegNew_Foundation;
private int m_UnRegOld_ESL;
private int m_UnRegNew_ESL;
private int m_AllGraduatedDiploma;
private int m_AllExtendedtoBA;
private int m_OldDiplomaRetention_LastYear;
private int m_OldDiplomaRetention_LastSem;
private int m_OldBARetention_LastYear;
private int m_OldBARetention_LastSem;
private int m_AllOldRetention_LastYear;
private int m_AllOldRetention_LastSem;
private int m_AllOldUnregister_LastYear;
private int m_AllOldUnregister_LastSem;

private int m_AllDiplomaGraduated_Last2Years;
private int m_AllDiplomaGraduated_LastYear;
private int m_AllDiplomaGraduated_LastSem;

private int m_AllPotentialNotExtendedBA_Last2Years;
private int m_AllPotentialNotExtendedBA_LastYear;
private int m_AllPotentialNotExtendedBA_LastSem;

private string m_sUser; 
private DateTime m_dCreationDate; 
private DateTime m_dLastUpdate; 
private string m_sNUser; 
private string m_sDevice; 
#endregion
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                #region "Puplic Properties"
//'-----------------------------------------------------
public int Term
{
get { return  m_Term; }
set {m_Term  = value ; }
}
public int CampusID
{
get { return  m_CampusID; }
set {m_CampusID  = value ; }
}
public int Session
{
get { return  m_Session; }
set {m_Session  = value ; }
}
public int RegOld_Diploma
{
get { return  m_RegOld_Diploma; }
set {m_RegOld_Diploma  = value ; }
}
public int RegOld_BA
{
get { return  m_RegOld_BA; }
set {m_RegOld_BA  = value ; }
}
public int RegNew_Diploma
{
get { return  m_RegNew_Diploma; }
set {m_RegNew_Diploma  = value ; }
}
public int RegNew_BA
{
get { return  m_RegNew_BA; }
set {m_RegNew_BA  = value ; }
}
public int RegExtended_Diploma
{
get { return  m_RegExtended_Diploma; }
set {m_RegExtended_Diploma  = value ; }
}
public int RegExtended_BA
{
get { return  m_RegExtended_BA; }
set {m_RegExtended_BA  = value ; }
}
public int RegExtended_ESL
{
    get { return m_RegExtended_ESL; }
    set { m_RegExtended_ESL = value; }
}
public int RegOld_Foundation
{
get { return  m_RegOld_Foundation; }
set {m_RegOld_Foundation  = value ; }
}
public int RegNew_Foundation
{
get { return  m_RegNew_Foundation; }
set {m_RegNew_Foundation  = value ; }
}

public int RegOld_ESL
{
get { return  m_RegOld_ESL; }
set {m_RegOld_ESL  = value ; }
}
public int RegNew_ESL
{
get { return  m_RegNew_ESL; }
set {m_RegNew_ESL  = value ; }
}
public int RegOld_Visiting
{
get { return  m_RegOld_Visiting; }
set {m_RegOld_Visiting  = value ; }
}
public int RegNew_Visiting
{
get { return  m_RegNew_Visiting; }
set {m_RegNew_Visiting  = value ; }
}
public int UnRegOld_Diploma
{
get { return  m_UnRegOld_Diploma; }
set {m_UnRegOld_Diploma  = value ; }
}
public int UnRegOld_BA
{
get { return  m_UnRegOld_BA; }
set {m_UnRegOld_BA  = value ; }
}
public int UnRegNew_Diploma
{
get { return  m_UnRegNew_Diploma; }
set {m_UnRegNew_Diploma  = value ; }
}
public int UnRegNew_BA
{
get { return  m_UnRegNew_BA; }
set {m_UnRegNew_BA  = value ; }
}
public int UnRegExtended_Diploma
{
get { return  m_UnRegExtended_Diploma; }
set {m_UnRegExtended_Diploma  = value ; }
}
public int UnRegExtended_BA
{
get { return  m_UnRegExtended_BA; }
set {m_UnRegExtended_BA  = value ; }
}
public int UnRegExtended_ESL
{
    get { return m_UnRegExtended_ESL; }
    set { m_UnRegExtended_ESL = value; }
}
public int UnRegOld_Foundation
{
get { return  m_UnRegOld_Foundation; }
set {m_UnRegOld_Foundation  = value ; }
}
public int UnRegNew_Foundation
{
get { return  m_UnRegNew_Foundation; }
set {m_UnRegNew_Foundation  = value ; }
}
   
public int UnRegOld_ESL
{
get { return  m_UnRegOld_ESL; }
set {m_UnRegOld_ESL  = value ; }
}
public int UnRegNew_ESL
{
get { return  m_UnRegNew_ESL; }
set {m_UnRegNew_ESL  = value ; }
}
public int AllDiplomaGraduated_Last2Years
{
    get { return m_AllDiplomaGraduated_Last2Years; }
    set { m_AllDiplomaGraduated_Last2Years = value; }
}
public int AllDiplomaGraduated_LastYear
{
    get { return m_AllDiplomaGraduated_LastYear; }
    set { m_AllDiplomaGraduated_LastYear = value; }
}
public int AllDiplomaGraduated_LastSem
{
    get { return m_AllDiplomaGraduated_LastSem; }
    set { m_AllDiplomaGraduated_LastSem = value; }
}
public int AllPotentialNotExtendedBA_Last2Years
{
    get { return m_AllPotentialNotExtendedBA_Last2Years; }
    set { m_AllPotentialNotExtendedBA_Last2Years = value; }
}
public int AllPotentialNotExtendedBA_LastYear
{
    get { return m_AllPotentialNotExtendedBA_LastYear; }
    set { m_AllPotentialNotExtendedBA_LastYear = value; }
}
public int AllPotentialNotExtendedBA_LastSem
{
    get { return m_AllPotentialNotExtendedBA_LastSem; }
    set { m_AllPotentialNotExtendedBA_LastSem = value; }
}
public string sUser
{
get { return  m_sUser; }
set {m_sUser  = value ; }
}
public DateTime dCreationDate
{
get { return  m_dCreationDate; }
set {m_dCreationDate  = value ; }
}
public DateTime dLastUpdate
{
get { return  m_dLastUpdate; }
set {m_dLastUpdate  = value ; }
}
public string sNUser
{
get { return  m_sNUser; }
set {m_sNUser  = value ; }
}
public string sDevice
{
get { return  m_sDevice; }
set {m_sDevice  = value ; }
}
//'-----------------------------------------------------
#endregion
    //'-----------------------------------------------------
    public Reg_History()
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
    public class Reg_HistoryDAL : Reg_History
    {
                                                                                                            #region "Decleration"
private string m_TableName;
private string m_TermFN ;
private string m_CampusIDFN ;
private string m_SessionFN ;
private string m_RegOld_DiplomaFN ;
private string m_RegOld_BAFN ;
private string m_RegNew_DiplomaFN ;
private string m_RegNew_BAFN ;
private string m_RegExtended_DiplomaFN ;
private string m_RegExtended_BAFN ;
private string m_RegExtended_ESLFN;
private string m_RegOld_FoundationFN ;
private string m_RegNew_FoundationFN ;
private string m_RegOld_ESLFN ;
private string m_RegNew_ESLFN ;	
private string m_RegOld_VisitingFN ;
private string m_RegNew_VisitingFN ;	

private string m_UnRegOld_DiplomaFN ;
private string m_UnRegOld_BAFN ;
private string m_UnRegNew_DiplomaFN ;
private string m_UnRegNew_BAFN ;
private string m_UnRegExtended_DiplomaFN ;
private string m_UnRegExtended_BAFN ;
private string m_UnRegExtended_ESLFN;
private string m_UnRegOld_FoundationFN ;
private string m_UnRegNew_FoundationFN ;
private string m_UnRegOld_ESLFN ;
private string m_UnRegNew_ESLFN;	

private string m_AllGraduatedDiplomaFN;
private string m_AllExtendedtoBAFN;
private string m_OldDiplomaRetention_LastYearFN;
private string m_OldDiplomaRetention_LastSemFN;
private string m_OldBARetention_LastYearFN;
private string m_OldBARetention_LastSemFN;
private string m_AllOldRetention_LastYearFN;
private string m_AllOldRetention_LastSemFN;
private string m_AllOldUnregister_LastYearFN;
private string m_AllOldUnregister_LastSemFN;
private string m_AllPostponedFN;
private string m_AllPostponed_LastYearFN;
private string m_AllPostponed_LastSemFN;
private string m_AllDiplomaGraduated_Last2YearsFN;
private string m_AllDiplomaGraduated_LastYearFN;
private string m_AllDiplomaGraduated_LastSemFN;

private string m_AllPotentialNotExtendedBA_Last2YearsFN;
private string m_AllPotentialNotExtendedBA_LastYearFN;
private string m_AllPotentialNotExtendedBA_LastSemFN;

private string m_sUserFN ;
private string m_dCreationDateFN ;
private string m_dLastUpdateFN ;
private string m_sNUserFN ;
private string m_sDeviceFN ;
#endregion
    //'-----------------------------------------------------
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            #region "Puplic Properties"
public string TableName 
{
get { return m_TableName; }
set { m_TableName = value; }
}
public string TermFN 
{
get { return  m_TermFN; }
set {m_TermFN  = value ; }
}
public string CampusIDFN 
{
get { return  m_CampusIDFN; }
set {m_CampusIDFN  = value ; }
}
public string SessionFN 
{
get { return  m_SessionFN; }
set {m_SessionFN  = value ; }
}
public string RegOld_DiplomaFN 
{
get { return  m_RegOld_DiplomaFN; }
set {m_RegOld_DiplomaFN  = value ; }
}
public string RegOld_BAFN 
{
get { return  m_RegOld_BAFN; }
set {m_RegOld_BAFN  = value ; }
}
public string RegNew_DiplomaFN 
{
get { return  m_RegNew_DiplomaFN; }
set {m_RegNew_DiplomaFN  = value ; }
}
public string RegNew_BAFN 
{
get { return  m_RegNew_BAFN; }
set {m_RegNew_BAFN  = value ; }
}
public string RegExtended_DiplomaFN 
{
get { return  m_RegExtended_DiplomaFN; }
set {m_RegExtended_DiplomaFN  = value ; }
}
public string RegExtended_BAFN 
{
get { return  m_RegExtended_BAFN; }
set {m_RegExtended_BAFN  = value ; }
}
public string RegExtended_ESLFN
{
    get { return m_RegExtended_ESLFN; }
    set { m_RegExtended_ESLFN = value; }
}
public string RegOld_FoundationFN 
{
get { return  m_RegOld_FoundationFN; }
set {m_RegOld_FoundationFN  = value ; }
}
public string RegNew_FoundationFN 
{
get { return  m_RegNew_FoundationFN; }
set {m_RegNew_FoundationFN  = value ; }
}

public string RegOld_ESLFN 
{
get { return  m_RegOld_ESLFN; }
set {m_RegOld_ESLFN  = value ; }
}
public string RegNew_ESLFN 
{
get { return  m_RegNew_ESLFN; }
set {m_RegNew_ESLFN  = value ; }
}
public string RegOld_VisitingFN 
{
get { return  m_RegOld_VisitingFN; }
set {m_RegOld_VisitingFN  = value ; }
}
public string RegNew_VisitingFN 
{
get { return  m_RegNew_VisitingFN; }
set {m_RegNew_VisitingFN  = value ; }
}


public string UnRegOld_DiplomaFN 
{
get { return  m_UnRegOld_DiplomaFN; }
set {m_UnRegOld_DiplomaFN  = value ; }
}
public string UnRegOld_BAFN 
{
get { return  m_UnRegOld_BAFN; }
set {m_UnRegOld_BAFN  = value ; }
}
public string UnRegNew_DiplomaFN 
{
get { return  m_UnRegNew_DiplomaFN; }
set {m_UnRegNew_DiplomaFN  = value ; }
}
public string UnRegNew_BAFN 
{
get { return  m_UnRegNew_BAFN; }
set {m_UnRegNew_BAFN  = value ; }
}
public string UnRegExtended_DiplomaFN 
{
get { return  m_UnRegExtended_DiplomaFN; }
set {m_UnRegExtended_DiplomaFN  = value ; }
}
public string UnRegExtended_BAFN 
{
get { return  m_UnRegExtended_BAFN; }
set {m_UnRegExtended_BAFN  = value ; }
}
public string UnRegExtended_ESLFN
{
    get { return m_UnRegExtended_ESLFN; }
    set { m_UnRegExtended_ESLFN = value; }
}
public string UnRegOld_FoundationFN 
{
get { return  m_UnRegOld_FoundationFN; }
set {m_UnRegOld_FoundationFN  = value ; }
}
public string UnRegNew_FoundationFN 
{
get { return  m_UnRegNew_FoundationFN; }
set {m_UnRegNew_FoundationFN  = value ; }
}
public string UnRegOld_ESLFN 
{
get { return  m_UnRegOld_ESLFN; }
set {m_UnRegOld_ESLFN  = value ; }
}
public string UnRegNew_ESLFN 
{
get { return  m_UnRegNew_ESLFN; }
set {m_UnRegNew_ESLFN  = value ; }
}

public string AllGraduatedDiplomaFN
{
    get { return m_AllGraduatedDiplomaFN; }
    set { m_AllGraduatedDiplomaFN = value; }
}
public string AllExtendedtoBAFN
{
    get { return m_AllExtendedtoBAFN; }
    set { m_AllExtendedtoBAFN = value; }
}

public string OldDiplomaRetention_LastYearFN
{
    get { return m_OldDiplomaRetention_LastYearFN; }
    set { m_OldDiplomaRetention_LastYearFN = value; }
}
public string OldDiplomaRetention_LastSemFN
{
    get { return m_OldDiplomaRetention_LastSemFN; }
    set { m_OldDiplomaRetention_LastSemFN = value; }
}
public string OldBARetention_LastYearFN
{
    get { return m_OldBARetention_LastYearFN; }
    set { m_OldBARetention_LastYearFN = value; }
}
public string OldBARetention_LastSemFN
{
    get { return m_OldBARetention_LastSemFN; }
    set { m_OldBARetention_LastSemFN = value; }
}
public string AllOldRetention_LastYearFN
{
    get { return m_AllOldRetention_LastYearFN; }
    set { m_AllOldRetention_LastYearFN = value; }
}
public string AllOldRetention_LastSemFN
{
    get { return m_AllOldRetention_LastSemFN; }
    set { m_AllOldRetention_LastSemFN = value; }
}
public string AllOldUnregister_LastYearFN
{
    get { return m_AllOldUnregister_LastYearFN; }
    set { m_AllOldUnregister_LastYearFN = value; }
}
public string AllOldUnregister_LastSemFN
{
    get { return m_AllOldUnregister_LastSemFN; }
    set { m_AllOldUnregister_LastSemFN = value; }
}

public string AllPostponedFN
{
    get { return m_AllPostponedFN; }
    set { m_AllPostponedFN = value; }
}

public string AllPostponed_LastYearFN
{
    get { return m_AllPostponed_LastYearFN; }
    set { m_AllPostponed_LastYearFN = value; }
}
public string AllPostponed_LastSemFN
{
    get { return m_AllPostponed_LastSemFN; }
    set { m_AllPostponed_LastSemFN = value; }
}
      
public string AllDiplomaGraduated_Last2YearsFN
{
    get { return m_AllDiplomaGraduated_Last2YearsFN; }
    set { m_AllDiplomaGraduated_Last2YearsFN = value; }
}
public string AllDiplomaGraduated_LastYearFN
{
    get { return m_AllDiplomaGraduated_LastYearFN; }
    set { m_AllDiplomaGraduated_LastYearFN = value; }
}
public string AllDiplomaGraduated_LastSemFN
{
    get { return m_AllDiplomaGraduated_LastSemFN; }
    set { m_AllDiplomaGraduated_LastSemFN = value; }
}
public string AllPotentialNotExtendedBA_Last2YearsFN
{
    get { return m_AllPotentialNotExtendedBA_Last2YearsFN; }
    set { m_AllPotentialNotExtendedBA_Last2YearsFN = value; }
}
public string AllPotentialNotExtendedBA_LastYearFN
{
    get { return m_AllPotentialNotExtendedBA_LastYearFN; }
    set { m_AllPotentialNotExtendedBA_LastYearFN = value; }
}
public string AllPotentialNotExtendedBA_LastSemFN
{
    get { return m_AllPotentialNotExtendedBA_LastSemFN; }
    set { m_AllPotentialNotExtendedBA_LastSemFN = value; }
}
public string sUserFN 
{
get { return  m_sUserFN; }
set {m_sUserFN  = value ; }
}
public string dCreationDateFN 
{
get { return  m_dCreationDateFN; }
set {m_dCreationDateFN  = value ; }
}
public string dLastUpdateFN 
{
get { return  m_dLastUpdateFN; }
set {m_dLastUpdateFN  = value ; }
}
public string sNUserFN 
{
get { return  m_sNUserFN; }
set {m_sNUserFN  = value ; }
}
public string sDeviceFN 
{
get { return  m_sDeviceFN; }
set {m_sDeviceFN  = value ; }
}
#endregion
    //================End Properties ===================
    public Reg_HistoryDAL()
    {
    try
    {
    this.TableName = "ECT_Reg_History";
    this.TermFN = m_TableName + ".Term";
    this.CampusIDFN = m_TableName + ".CampusID";
    this.SessionFN = m_TableName + ".Session";
    this.RegOld_DiplomaFN = m_TableName + ".RegOld_Diploma";
    this.RegOld_BAFN = m_TableName + ".RegOld_BA";
    this.RegNew_DiplomaFN = m_TableName + ".RegNew_Diploma";
    this.RegNew_BAFN = m_TableName + ".RegNew_BA";
    this.RegExtended_DiplomaFN = m_TableName + ".RegExtended_Diploma";
    this.RegExtended_BAFN = m_TableName + ".RegExtended_BA";
    this.RegExtended_ESLFN = m_TableName + ".RegExtended_ESL";
    this.RegOld_FoundationFN = m_TableName + ".RegOld_Foundation";
    this.RegNew_FoundationFN = m_TableName + ".RegNew_Foundation";
    this.RegOld_ESLFN = m_TableName + ".RegOld_ESL";
    this.RegNew_ESLFN = m_TableName + ".RegNew_ESL";
    this.RegOld_VisitingFN = m_TableName + ".RegOld_Visiting";
    this.RegNew_VisitingFN = m_TableName + ".RegNew_Visiting";
    this.UnRegOld_DiplomaFN = m_TableName + ".UnRegOld_Diploma";
    this.UnRegOld_BAFN = m_TableName + ".UnRegOld_BA";
    this.UnRegNew_DiplomaFN = m_TableName + ".UnRegNew_Diploma";
    this.UnRegNew_BAFN = m_TableName + ".UnRegNew_BA";
    this.UnRegExtended_DiplomaFN = m_TableName + ".UnRegExtended_Diploma";
    this.UnRegExtended_BAFN = m_TableName + ".UnRegExtended_BA";
    this.UnRegExtended_ESLFN = m_TableName + ".UnRegExtended_ESL";
    this.UnRegOld_FoundationFN = m_TableName + ".UnRegOld_Foundation";
    this.UnRegNew_FoundationFN = m_TableName + ".UnRegNew_Foundation";
    this.UnRegOld_ESLFN = m_TableName + ".UnRegOld_ESL";
    this.UnRegNew_ESLFN = m_TableName + ".UnRegNew_ESL";
    

    this.AllGraduatedDiplomaFN= m_TableName + ".AllGraduatedDiploma";
    this.AllExtendedtoBAFN = m_TableName + ".AllExtendedtoBA";
    this.OldDiplomaRetention_LastYearFN = m_TableName + ".OldDiplomaRetention_LastYear";
    this.OldDiplomaRetention_LastSemFN = m_TableName + ".OldDiplomaRetention_LastSem";
    this.OldBARetention_LastYearFN = m_TableName + ".OldBARetention_LastYear";
    this.OldBARetention_LastSemFN = m_TableName + ".OldBARetention_LastSem";
    this.AllOldRetention_LastYearFN = m_TableName + ".AllOldRetention_LastYear";
    this.AllOldRetention_LastSemFN = m_TableName + ".AllOldRetention_LastSem";
    this.AllOldUnregister_LastYearFN = m_TableName + ".AllOldUnregister_LastYear";
    this.AllOldUnregister_LastSemFN = m_TableName + ".AllOldUnregister_LastSem";
    
    this.AllPostponedFN = m_TableName + ".AllPostponed";
    this.AllPostponed_LastYearFN = m_TableName + ".AllPostponed_LastYear";
    this.AllPostponed_LastSemFN = m_TableName + ".AllPostponed_LastSem";

    this.AllDiplomaGraduated_Last2YearsFN = m_TableName + ".AllDiplomaGraduated_Last2Years";
    this.AllDiplomaGraduated_LastYearFN = m_TableName + ".AllDiplomaGraduated_LastYear";
    this.AllDiplomaGraduated_LastSemFN = m_TableName + ".AllDiplomaGraduated_LastSem";

    this.AllPotentialNotExtendedBA_Last2YearsFN = m_TableName + ".AllPotentialNotExtendedBA_Last2Years";
    this.AllPotentialNotExtendedBA_LastYearFN = m_TableName + ".AllPotentialNotExtendedBA_LastYear";
    this.AllPotentialNotExtendedBA_LastSemFN = m_TableName + ".AllPotentialNotExtendedBA_LastSem";

    this.sUserFN = m_TableName + ".sUser";
    this.dCreationDateFN = m_TableName + ".dCreationDate";
    this.dLastUpdateFN = m_TableName + ".dLastUpdate";
    this.sNUserFN = m_TableName + ".sNUser";
    this.sDeviceFN = m_TableName + ".sDevice";
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
public string  GetSQL() 
{
string sSQL  = "";
try
{
sSQL = "SELECT ";
sSQL +=TermFN;
sSQL += " , " + CampusIDFN;
sSQL += " , " + SessionFN;
sSQL += " , " + RegOld_DiplomaFN;
sSQL += " , " + RegOld_BAFN;
sSQL += " , " + RegNew_DiplomaFN;
sSQL += " , " + RegNew_BAFN;
sSQL += " , " + RegExtended_DiplomaFN;
sSQL += " , " + RegExtended_BAFN;
sSQL += " , " + RegExtended_ESLFN;
sSQL += " , " + RegOld_FoundationFN;
sSQL += " , " + RegNew_FoundationFN;

sSQL += " , " + RegOld_ESLFN;
sSQL += " , " + RegNew_ESLFN;
sSQL += " , " + RegOld_VisitingFN;
sSQL += " , " + RegNew_VisitingFN;

sSQL += " , " + UnRegOld_DiplomaFN;
sSQL += " , " + UnRegOld_BAFN;
sSQL += " , " + UnRegNew_DiplomaFN;
sSQL += " , " + UnRegNew_BAFN;
sSQL += " , " + UnRegExtended_DiplomaFN;
sSQL += " , " + UnRegExtended_BAFN;
sSQL += " , " + UnRegExtended_ESLFN;
sSQL += " , " + UnRegOld_FoundationFN;
sSQL += " , " + UnRegNew_FoundationFN;
sSQL += " , " + UnRegOld_ESLFN;
sSQL += " , " + UnRegNew_ESLFN;
sSQL += " , " + AllGraduatedDiplomaFN;
sSQL += " , " + AllExtendedtoBAFN;
sSQL += " , " + OldDiplomaRetention_LastYearFN;
sSQL += " , " + OldDiplomaRetention_LastSemFN;
sSQL += " , " + OldBARetention_LastYearFN;
sSQL += " , " + OldBARetention_LastSemFN;
sSQL += " , " + AllOldRetention_LastYearFN;
sSQL += " , " + AllOldRetention_LastSemFN;
sSQL += " , " + AllOldUnregister_LastYearFN;
sSQL += " , " + AllOldUnregister_LastSemFN;
sSQL += " , " + AllPostponedFN;
sSQL += " , " + AllPostponed_LastYearFN ;
sSQL += " , " + AllPostponed_LastSemFN;

sSQL += " , " + AllDiplomaGraduated_Last2YearsFN;
sSQL += " , " + AllDiplomaGraduated_LastYearFN;
sSQL += " , " + AllDiplomaGraduated_LastSemFN;

sSQL += " , " + AllPotentialNotExtendedBA_Last2YearsFN;
sSQL += " , " + AllPotentialNotExtendedBA_LastYearFN;
sSQL += " , " + AllPotentialNotExtendedBA_LastSemFN;

sSQL += " , " + sUserFN;
sSQL += " , " + dCreationDateFN;
sSQL += " , " + dLastUpdateFN;
sSQL += " , " + sNUserFN;
sSQL += " , " + sDeviceFN;
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
string sSQL  = "";
try
{
sSQL = "SELECT ";
sSQL +=TermFN;
sSQL += " , " + CampusIDFN;
sSQL += " , " + SessionFN;
sSQL += "  FROM " + m_TableName;
if (sCondition != "")
{
    sSQL += " WHERE " + sCondition;
}
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
public DataSet GetRegHistory(InitializeModule.EnumCampus Campus, int iFilter)
{

    DataSet dsResult = new DataSet();
    Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);

    SqlConnection myConnection = new SqlConnection(MyConnection_string.Conn_string);

    string sql = null;

    try
    {
        sql = GetListSQL("");

      
        if (iFilter != 0)
        {
            sql += " WHERE ECT_Reg_History.Term =" + iFilter;
        }
       
        myConnection.Open();

        SqlDataAdapter da = new SqlDataAdapter(sql, myConnection);
        da.Fill(dsResult, "result");

    }
    catch (Exception ex)
    {
        LibraryMOD.ShowErrorMessage(ex);
    }
    finally
    {
        myConnection.Close();
        myConnection = null;
    }
    return dsResult;
} 

//-----Get GetSelectCommand Function -----------------------
public string GetSelectCommand() 
{
string sSQL= "";
try
{
sSQL = "SELECT ";
sSQL +=TermFN;
sSQL += " , " + CampusIDFN;
sSQL += " , " + SessionFN;
sSQL += " , " + RegOld_DiplomaFN;
sSQL += " , " + RegOld_BAFN;
sSQL += " , " + RegNew_DiplomaFN;
sSQL += " , " + RegNew_BAFN;
sSQL += " , " + RegExtended_DiplomaFN;
sSQL += " , " + RegExtended_BAFN;
sSQL += " , " + RegOld_FoundationFN;
sSQL += " , " + RegNew_FoundationFN;
sSQL += " , " + RegOld_ESLFN;
sSQL += " , " + RegNew_ESLFN;
sSQL += " , " + RegOld_VisitingFN;
sSQL += " , " + RegNew_VisitingFN;

sSQL += " , " + UnRegOld_DiplomaFN;
sSQL += " , " + UnRegOld_BAFN;
sSQL += " , " + UnRegNew_DiplomaFN;
sSQL += " , " + UnRegNew_BAFN;
sSQL += " , " + UnRegExtended_DiplomaFN;
sSQL += " , " + UnRegExtended_BAFN;
sSQL += " , " + UnRegOld_FoundationFN;
sSQL += " , " + UnRegNew_FoundationFN;
sSQL += " , " + UnRegOld_ESLFN;
sSQL += " , " + UnRegNew_ESLFN;
sSQL += " , " + OldDiplomaRetention_LastYearFN;
sSQL += " , " + OldDiplomaRetention_LastSemFN;
sSQL += " , " + OldBARetention_LastYearFN;
sSQL += " , " + OldBARetention_LastSemFN;
sSQL += " , " + AllOldRetention_LastYearFN;
sSQL += " , " + AllOldRetention_LastSemFN;
sSQL += " , " + AllOldUnregister_LastYearFN;
sSQL += " , " + AllOldUnregister_LastSemFN;
sSQL += " , " + AllPostponedFN;
sSQL += " , " + AllPostponed_LastYearFN;
sSQL += " , " + AllPostponed_LastSemFN;

sSQL += " , " + AllDiplomaGraduated_Last2YearsFN;
sSQL += " , " + AllDiplomaGraduated_LastYearFN;
sSQL += " , " + AllDiplomaGraduated_LastSemFN;

sSQL += " , " + AllPotentialNotExtendedBA_Last2YearsFN;
sSQL += " , " + AllPotentialNotExtendedBA_LastYearFN;
sSQL += " , " + AllPotentialNotExtendedBA_LastSemFN;

sSQL += " , " + sUserFN;
sSQL += " , " + dCreationDateFN;
sSQL += " , " + dLastUpdateFN;
sSQL += " , " + sNUserFN;
sSQL += " , " + sDeviceFN;
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
string sSQL  = "";
try
{
sSQL = "UPDATE " + TableName;
sSQL += " SET ";
sSQL += LibraryMOD.GetFieldName(TermFN) + "=@Term";
sSQL += " , " + LibraryMOD.GetFieldName(CampusIDFN) + "=@CampusID";
sSQL += " , " + LibraryMOD.GetFieldName(SessionFN) + "=@Session";
sSQL += " , " + LibraryMOD.GetFieldName(RegOld_DiplomaFN) + "=@RegOld_Diploma";
sSQL += " , " + LibraryMOD.GetFieldName(RegOld_BAFN) + "=@RegOld_BA";
sSQL += " , " + LibraryMOD.GetFieldName(RegNew_DiplomaFN) + "=@RegNew_Diploma";
sSQL += " , " + LibraryMOD.GetFieldName(RegNew_BAFN) + "=@RegNew_BA";
sSQL += " , " + LibraryMOD.GetFieldName(RegExtended_DiplomaFN) + "=@RegExtended_Diploma";
sSQL += " , " + LibraryMOD.GetFieldName(RegExtended_BAFN) + "=@RegExtended_BA";
sSQL += " , " + LibraryMOD.GetFieldName(RegExtended_ESLFN) + "=@RegExtended_ESL";
sSQL += " , " + LibraryMOD.GetFieldName(RegOld_FoundationFN) + "=@RegOld_Foundation";
sSQL += " , " + LibraryMOD.GetFieldName(RegNew_FoundationFN) + "=@RegNew_Foundation";

sSQL += " , " + LibraryMOD.GetFieldName(RegOld_ESLFN) + "=@RegOld_ESL";
sSQL += " , " + LibraryMOD.GetFieldName(RegNew_ESLFN) + "=@RegNew_ESL";
sSQL += " , " + LibraryMOD.GetFieldName(RegOld_VisitingFN) + "=@RegOld_Visiting";
sSQL += " , " + LibraryMOD.GetFieldName(RegNew_VisitingFN) + "=@RegNew_Visiting";
    
sSQL += " , " + LibraryMOD.GetFieldName(UnRegOld_DiplomaFN) + "=@UnRegOld_Diploma";
sSQL += " , " + LibraryMOD.GetFieldName(UnRegOld_BAFN) + "=@UnRegOld_BA";
sSQL += " , " + LibraryMOD.GetFieldName(UnRegNew_DiplomaFN) + "=@UnRegNew_Diploma";
sSQL += " , " + LibraryMOD.GetFieldName(UnRegNew_BAFN) + "=@UnRegNew_BA";
sSQL += " , " + LibraryMOD.GetFieldName(UnRegExtended_DiplomaFN) + "=@UnRegExtended_Diploma";
sSQL += " , " + LibraryMOD.GetFieldName(UnRegExtended_BAFN) + "=@UnRegExtended_BA";
sSQL += " , " + LibraryMOD.GetFieldName(UnRegExtended_ESLFN) + "=@UnRegExtended_ESL";
sSQL += " , " + LibraryMOD.GetFieldName(UnRegOld_FoundationFN) + "=@UnRegOld_Foundation";
sSQL += " , " + LibraryMOD.GetFieldName(UnRegNew_FoundationFN) + "=@UnRegNew_Foundation";

sSQL += " , " + LibraryMOD.GetFieldName(UnRegOld_ESLFN) + "=@UnRegOld_ESL";
sSQL += " , " + LibraryMOD.GetFieldName(UnRegNew_ESLFN) + "=@UnRegNew_ESL";

sSQL += " , " + LibraryMOD.GetFieldName(AllGraduatedDiplomaFN) + "=@AllGraduatedDiploma";
sSQL += " , " + LibraryMOD.GetFieldName(AllExtendedtoBAFN) + "=@AllExtendedtoBA";
sSQL += " , " + LibraryMOD.GetFieldName(OldDiplomaRetention_LastYearFN) + "=@OldDiplomaRetention_LastYear";
sSQL += " , " + LibraryMOD.GetFieldName(OldDiplomaRetention_LastSemFN) + "=@OldDiplomaRetention_LastSem";
sSQL += " , " + LibraryMOD.GetFieldName(OldBARetention_LastYearFN) + "=@OldBARetention_LastYear";
sSQL += " , " + LibraryMOD.GetFieldName(OldBARetention_LastSemFN) + "=@OldBARetention_LastSem";
sSQL += " , " + LibraryMOD.GetFieldName(AllOldRetention_LastYearFN) + "=@AllOldRetention_LastYear";
sSQL += " , " + LibraryMOD.GetFieldName(AllOldRetention_LastSemFN) + "=@AllOldRetention_LastSem";
sSQL += " , " + LibraryMOD.GetFieldName(AllOldUnregister_LastYearFN) + "=@AllOldUnregister_LastYear";
sSQL += " , " + LibraryMOD.GetFieldName(AllOldUnregister_LastSemFN) + "=@AllOldUnregister_LastSem";
sSQL += " , " + LibraryMOD.GetFieldName(AllPostponedFN) + "=@AllPostponed";
sSQL += " , " + LibraryMOD.GetFieldName(AllPostponed_LastYearFN) + "=@AllPostponed_LastYear";
sSQL += " , " + LibraryMOD.GetFieldName(AllPostponed_LastSemFN) + "=@AllPostponed_LastSem";

sSQL += " , " + LibraryMOD.GetFieldName(AllDiplomaGraduated_Last2YearsFN) + "=@AllDiplomaGraduated_Last2Years";
sSQL += " , " + LibraryMOD.GetFieldName(AllDiplomaGraduated_LastYearFN) + "=@AllDiplomaGraduated_LastYear";
sSQL += " , " + LibraryMOD.GetFieldName(AllDiplomaGraduated_LastSemFN) + "=@AllDiplomaGraduated_LastSem";

sSQL += " , " + LibraryMOD.GetFieldName(AllPotentialNotExtendedBA_Last2YearsFN) + "=@AllPotentialNotExtendedBA_Last2Years";
sSQL += " , " + LibraryMOD.GetFieldName(AllPotentialNotExtendedBA_LastYearFN) + "=@AllPotentialNotExtendedBA_LastYear";
sSQL += " , " + LibraryMOD.GetFieldName(AllPotentialNotExtendedBA_LastSemFN) + "=@AllPotentialNotExtendedBA_LastSem";

sSQL += " , " + LibraryMOD.GetFieldName(sUserFN) + "=@sUser";
sSQL += " , " + LibraryMOD.GetFieldName(dCreationDateFN) + "=@dCreationDate";
sSQL += " , " + LibraryMOD.GetFieldName(dLastUpdateFN) + "=@dLastUpdate";
sSQL += " , " + LibraryMOD.GetFieldName(sNUserFN) + "=@sNUser";
sSQL += " , " + LibraryMOD.GetFieldName(sDeviceFN) + "=@sDevice";
sSQL += " WHERE ";
sSQL += LibraryMOD.GetFieldName(TermFN)+"=@Term";
sSQL +=  " And " + LibraryMOD.GetFieldName(CampusIDFN)+"=@CampusID";
sSQL +=  " And " + LibraryMOD.GetFieldName(SessionFN)+"=@Session";
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
string sSQL= "";
try
{
sSQL = "INSERT intO "  + TableName;
sSQL += "( ";
sSQL +=LibraryMOD.GetFieldName(TermFN);
sSQL += " , " + LibraryMOD.GetFieldName(CampusIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(SessionFN);
sSQL += " , " + LibraryMOD.GetFieldName(RegOld_DiplomaFN);
sSQL += " , " + LibraryMOD.GetFieldName(RegOld_BAFN);
sSQL += " , " + LibraryMOD.GetFieldName(RegNew_DiplomaFN);
sSQL += " , " + LibraryMOD.GetFieldName(RegNew_BAFN);
sSQL += " , " + LibraryMOD.GetFieldName(RegExtended_DiplomaFN);
sSQL += " , " + LibraryMOD.GetFieldName(RegExtended_BAFN);
sSQL += " , " + LibraryMOD.GetFieldName(RegExtended_ESLFN);
sSQL += " , " + LibraryMOD.GetFieldName(RegOld_FoundationFN);
sSQL += " , " + LibraryMOD.GetFieldName(RegNew_FoundationFN);
sSQL += " , " + LibraryMOD.GetFieldName(RegOld_ESLFN);
sSQL += " , " + LibraryMOD.GetFieldName(RegNew_ESLFN);
sSQL += " , " + LibraryMOD.GetFieldName(RegOld_VisitingFN);
sSQL += " , " + LibraryMOD.GetFieldName(RegNew_VisitingFN);
sSQL += " , " + LibraryMOD.GetFieldName(UnRegOld_DiplomaFN);sSQL += " , " + LibraryMOD.GetFieldName(UnRegOld_BAFN);

sSQL += " , " + LibraryMOD.GetFieldName(UnRegNew_DiplomaFN);
sSQL += " , " + LibraryMOD.GetFieldName(UnRegNew_BAFN);
sSQL += " , " + LibraryMOD.GetFieldName(UnRegExtended_DiplomaFN);
sSQL += " , " + LibraryMOD.GetFieldName(UnRegExtended_BAFN);
sSQL += " , " + LibraryMOD.GetFieldName(UnRegExtended_ESLFN);
sSQL += " , " + LibraryMOD.GetFieldName(UnRegOld_FoundationFN);
sSQL += " , " + LibraryMOD.GetFieldName(UnRegNew_FoundationFN);
sSQL += " , " + LibraryMOD.GetFieldName(UnRegOld_ESLFN);
sSQL += " , " + LibraryMOD.GetFieldName(UnRegNew_ESLFN);

sSQL += " , " + LibraryMOD.GetFieldName(AllGraduatedDiplomaFN);
sSQL += " , " + LibraryMOD.GetFieldName(AllExtendedtoBAFN);
sSQL += " , " + LibraryMOD.GetFieldName(OldDiplomaRetention_LastYearFN);
sSQL += " , " + LibraryMOD.GetFieldName(OldDiplomaRetention_LastSemFN);
sSQL += " , " + LibraryMOD.GetFieldName(OldBARetention_LastYearFN);
sSQL += " , " + LibraryMOD.GetFieldName(OldBARetention_LastSemFN);
sSQL += " , " + LibraryMOD.GetFieldName(AllOldRetention_LastYearFN);
sSQL += " , " + LibraryMOD.GetFieldName(AllOldRetention_LastSemFN);
sSQL += " , " + LibraryMOD.GetFieldName(AllOldUnregister_LastYearFN);
sSQL += " , " + LibraryMOD.GetFieldName(AllOldUnregister_LastSemFN);

sSQL += " , " + LibraryMOD.GetFieldName(AllPostponedFN);
sSQL += " , " + LibraryMOD.GetFieldName(AllPostponed_LastYearFN);
sSQL += " , " + LibraryMOD.GetFieldName(AllPostponed_LastSemFN);

sSQL += " , " + LibraryMOD.GetFieldName(AllDiplomaGraduated_Last2YearsFN);
sSQL += " , " + LibraryMOD.GetFieldName(AllDiplomaGraduated_LastYearFN);
sSQL += " , " + LibraryMOD.GetFieldName(AllDiplomaGraduated_LastSemFN);

sSQL += " , " + LibraryMOD.GetFieldName(AllPotentialNotExtendedBA_Last2YearsFN) ;
sSQL += " , " + LibraryMOD.GetFieldName(AllPotentialNotExtendedBA_LastYearFN) ;
sSQL += " , " + LibraryMOD.GetFieldName(AllPotentialNotExtendedBA_LastSemFN) ;

sSQL += " , " + LibraryMOD.GetFieldName(sUserFN);
sSQL += " , " + LibraryMOD.GetFieldName(dCreationDateFN);
sSQL += " , " + LibraryMOD.GetFieldName(dLastUpdateFN);
sSQL += " , " + LibraryMOD.GetFieldName(sNUserFN);
sSQL += " , " + LibraryMOD.GetFieldName(sDeviceFN);
sSQL += ")";
sSQL += " VALUES ";
sSQL += "( ";
sSQL += " @Term";
sSQL += " ,@CampusID";
sSQL += " ,@Session";
sSQL += " ,@RegOld_Diploma";
sSQL += " ,@RegOld_BA";
sSQL += " ,@RegNew_Diploma";
sSQL += " ,@RegNew_BA";
sSQL += " ,@RegExtended_Diploma";
sSQL += " ,@RegExtended_BA";
sSQL += " ,@RegExtended_ESL";
sSQL += " ,@RegOld_Foundation";
sSQL += " ,@RegNew_Foundation";
sSQL += " ,@RegOld_ESL";
sSQL += " ,@RegNew_ESL";
sSQL += " ,@RegOld_Visiting";
sSQL += " ,@RegNew_Visiting";
sSQL += " ,@UnRegOld_Diploma";
sSQL += " ,@UnRegOld_BA";
sSQL += " ,@UnRegNew_Diploma";
sSQL += " ,@UnRegNew_BA";
sSQL += " ,@UnRegExtended_Diploma";
sSQL += " ,@UnRegExtended_BA";
sSQL += " ,@UnRegExtended_ESL";
sSQL += " ,@UnRegOld_Foundation";
sSQL += " ,@UnRegNew_Foundation";
sSQL += " ,@UnRegOld_ESL";
sSQL += " ,@UnRegNew_ESL";

sSQL += " ,@AllGraduatedDiploma";
sSQL += " ,@AllExtendedtoBA";
sSQL += " ,@OldDiplomaRetention_LastYear";	
sSQL += " ,@OldDiplomaRetention_LastSem";
sSQL += " ,@OldBARetention_LastYear";
sSQL += " ,@OldBARetention_LastSem";
sSQL += " ,@AllOldRetention_LastYear";	
sSQL += " ,@AllOldRetention_LastSem";
sSQL += " ,@AllOldUnregister_LastYear";
sSQL += " ,@AllOldUnregister_LastSem";
sSQL += " ,@AllPostponed";
sSQL += " ,@AllPostponed_LastYear";
sSQL += " ,@AllPostponed_LastSem";

sSQL += " ,@AllDiplomaGraduated_Last2Years";
sSQL += " ,@AllDiplomaGraduated_LastYear";
sSQL += " ,@AllDiplomaGraduated_LastSem";

sSQL += " ,@AllPotentialNotExtendedBA_Last2Years";
sSQL += " ,@AllPotentialNotExtendedBA_LastYear";
sSQL += " ,@AllPotentialNotExtendedBA_LastSem";

sSQL += " ,@sUser";
sSQL += " ,@dCreationDate";
sSQL += " ,@dLastUpdate";
sSQL += " ,@sNUser";
sSQL += " ,@sDevice";
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
public string  GetDeleteCommand()
{
string sSQL= "";
try
{
sSQL = "DELETE FROM "  + TableName;
sSQL += " WHERE ";
sSQL += LibraryMOD.GetFieldName(TermFN)+"=@Term";
sSQL +=  " And " +  LibraryMOD.GetFieldName(CampusIDFN)+"=@CampusID";
sSQL +=  " And " +  LibraryMOD.GetFieldName(SessionFN)+"=@Session";
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
    public List< Reg_History> GetReg_History(InitializeModule.EnumCampus Campus ,string sCondition,bool isDeafaultIncluded)
    {
    //' returns a list of Classes instances based on the
    //' data in the Reg_History
    Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
    string  sSQL = GetSQL();
    if (!string.IsNullOrEmpty(sCondition))
    {
    sSQL += sCondition;
    }
    SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
    SqlCommand Cmd = new SqlCommand(sSQL, Conn);
    Conn.Open();
    SqlDataReader reader  = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
    List<Reg_History> results = new List<Reg_History>();
    try
    {
    //Default Value
    Reg_History myReg_History = new Reg_History();
    if (isDeafaultIncluded)
    {
    //Change the code here
    myReg_History.Term = 0;
    myReg_History.CampusID = 0;
    myReg_History.Session = 0;
  
    results.Add(myReg_History);
    }
    while (reader.Read())
    {
    myReg_History = new Reg_History();
    if (reader[LibraryMOD.GetFieldName(TermFN)].Equals(DBNull.Value))
    {
    myReg_History.Term = 0;
    }
    else
    {
    myReg_History.Term = int.Parse(reader[LibraryMOD.GetFieldName( TermFN) ].ToString());
    }
    if (reader[LibraryMOD.GetFieldName(CampusIDFN)].Equals(DBNull.Value))
    {
    myReg_History.CampusID = 0;
    }
    else
    {
    myReg_History.CampusID = int.Parse(reader[LibraryMOD.GetFieldName( CampusIDFN) ].ToString());
    }
    if (reader[LibraryMOD.GetFieldName(SessionFN)].Equals(DBNull.Value))
    {
    myReg_History.Session = 0;
    }
    else
    {
    myReg_History.Session = int.Parse(reader[LibraryMOD.GetFieldName( SessionFN) ].ToString());
    }
    if (reader[LibraryMOD.GetFieldName(RegOld_DiplomaFN)].Equals(DBNull.Value))
    {
    myReg_History.RegOld_Diploma = 0;
    }
    else
    {
    myReg_History.RegOld_Diploma = int.Parse(reader[LibraryMOD.GetFieldName( RegOld_DiplomaFN) ].ToString());
    }
    if (reader[LibraryMOD.GetFieldName(RegOld_BAFN)].Equals(DBNull.Value))
    {
    myReg_History.RegOld_BA = 0;
    }
    else
    {
    myReg_History.RegOld_BA = int.Parse(reader[LibraryMOD.GetFieldName( RegOld_BAFN) ].ToString());
    }
    if (reader[LibraryMOD.GetFieldName(RegNew_DiplomaFN)].Equals(DBNull.Value))
    {
    myReg_History.RegNew_Diploma = 0;
    }
    else
    {
    myReg_History.RegNew_Diploma = int.Parse(reader[LibraryMOD.GetFieldName( RegNew_DiplomaFN) ].ToString());
    }
    if (reader[LibraryMOD.GetFieldName(RegNew_BAFN)].Equals(DBNull.Value))
    {
    myReg_History.RegNew_BA = 0;
    }
    else
    {
    myReg_History.RegNew_BA = int.Parse(reader[LibraryMOD.GetFieldName( RegNew_BAFN) ].ToString());
    }
    if (reader[LibraryMOD.GetFieldName(RegExtended_DiplomaFN)].Equals(DBNull.Value))
    {
    myReg_History.RegExtended_Diploma = 0;
    }
    else
    {
    myReg_History.RegExtended_Diploma = int.Parse(reader[LibraryMOD.GetFieldName( RegExtended_DiplomaFN) ].ToString());
    }
    if (reader[LibraryMOD.GetFieldName(RegExtended_BAFN)].Equals(DBNull.Value))
    {
    myReg_History.RegExtended_BA = 0;
    }
    else
    {
    myReg_History.RegExtended_BA = int.Parse(reader[LibraryMOD.GetFieldName( RegExtended_BAFN) ].ToString());
    }
    if (reader[LibraryMOD.GetFieldName(RegOld_FoundationFN)].Equals(DBNull.Value))
    {
    myReg_History.RegOld_Foundation = 0;
    }
    else
    {
    myReg_History.RegOld_Foundation = int.Parse(reader[LibraryMOD.GetFieldName( RegOld_FoundationFN) ].ToString());
    }
    if (reader[LibraryMOD.GetFieldName(RegNew_FoundationFN)].Equals(DBNull.Value))
    {
    myReg_History.RegNew_Foundation = 0;
    }
    else
    {
    myReg_History.RegNew_Foundation = int.Parse(reader[LibraryMOD.GetFieldName( RegNew_FoundationFN) ].ToString());
    }
    
    if (reader[LibraryMOD.GetFieldName(RegOld_ESLFN)].Equals(DBNull.Value))
    {
        myReg_History.RegOld_ESL = 0;
    }
    else
    {
        myReg_History.RegOld_ESL = int.Parse(reader[LibraryMOD.GetFieldName(RegOld_ESLFN)].ToString());
    }
    if (reader[LibraryMOD.GetFieldName(RegNew_ESLFN)].Equals(DBNull.Value))
    {
        myReg_History.RegNew_ESL = 0;
    }
    else
    {
        myReg_History.RegNew_ESL = int.Parse(reader[LibraryMOD.GetFieldName(RegNew_ESLFN)].ToString());
    }
    if (reader[LibraryMOD.GetFieldName(RegOld_VisitingFN)].Equals(DBNull.Value))
    {
        myReg_History.RegOld_Visiting = 0;
    }
    else
    {
        myReg_History.RegOld_Visiting = int.Parse(reader[LibraryMOD.GetFieldName(RegOld_VisitingFN)].ToString());
    }

    if (reader[LibraryMOD.GetFieldName(RegNew_VisitingFN)].Equals(DBNull.Value))
    {
        myReg_History.RegNew_Visiting = 0;
    }
    else
    {
        myReg_History.RegNew_Visiting = int.Parse(reader[LibraryMOD.GetFieldName(RegNew_VisitingFN)].ToString());
    }

    if (reader[LibraryMOD.GetFieldName(UnRegOld_DiplomaFN)].Equals(DBNull.Value))
    {
    myReg_History.UnRegOld_Diploma = 0;
    }
    else
    {
    myReg_History.UnRegOld_Diploma = int.Parse(reader[LibraryMOD.GetFieldName( UnRegOld_DiplomaFN) ].ToString());
    }
    if (reader[LibraryMOD.GetFieldName(UnRegOld_BAFN)].Equals(DBNull.Value))
    {
    myReg_History.UnRegOld_BA = 0;
    }
    else
    {
    myReg_History.UnRegOld_BA = int.Parse(reader[LibraryMOD.GetFieldName( UnRegOld_BAFN) ].ToString());
    }
    if (reader[LibraryMOD.GetFieldName(UnRegNew_DiplomaFN)].Equals(DBNull.Value))
    {
    myReg_History.UnRegNew_Diploma = 0;
    }
    else
    {
    myReg_History.UnRegNew_Diploma = int.Parse(reader[LibraryMOD.GetFieldName( UnRegNew_DiplomaFN) ].ToString());
    }
    if (reader[LibraryMOD.GetFieldName(UnRegNew_BAFN)].Equals(DBNull.Value))
    {
    myReg_History.UnRegNew_BA = 0;
    }
    else
    {
    myReg_History.UnRegNew_BA = int.Parse(reader[LibraryMOD.GetFieldName( UnRegNew_BAFN) ].ToString());
    }
    if (reader[LibraryMOD.GetFieldName(UnRegExtended_DiplomaFN)].Equals(DBNull.Value))
    {
    myReg_History.UnRegExtended_Diploma = 0;
    }
    else
    {
    myReg_History.UnRegExtended_Diploma = int.Parse(reader[LibraryMOD.GetFieldName( UnRegExtended_DiplomaFN) ].ToString());
    }
    if (reader[LibraryMOD.GetFieldName(UnRegExtended_BAFN)].Equals(DBNull.Value))
    {
    myReg_History.UnRegExtended_BA = 0;
    }
    else
    {
    myReg_History.UnRegExtended_BA = int.Parse(reader[LibraryMOD.GetFieldName( UnRegExtended_BAFN) ].ToString());
    }
    if (reader[LibraryMOD.GetFieldName(UnRegOld_FoundationFN)].Equals(DBNull.Value))
    {
    myReg_History.UnRegOld_Foundation = 0;
    }
    else
    {
    myReg_History.UnRegOld_Foundation = int.Parse(reader[LibraryMOD.GetFieldName( UnRegOld_FoundationFN) ].ToString());
    }
    if (reader[LibraryMOD.GetFieldName(UnRegNew_FoundationFN)].Equals(DBNull.Value))
    {
    myReg_History.UnRegNew_Foundation = 0;
    }
    else
    {
    myReg_History.UnRegNew_Foundation = int.Parse(reader[LibraryMOD.GetFieldName( UnRegNew_FoundationFN) ].ToString());
    }
   
    if (reader[LibraryMOD.GetFieldName(UnRegOld_ESLFN)].Equals(DBNull.Value))
    {
        myReg_History.UnRegOld_ESL = 0;
    }
    else
    {
        myReg_History.UnRegOld_ESL = int.Parse(reader[LibraryMOD.GetFieldName(UnRegOld_ESLFN)].ToString());
    }
    if (reader[LibraryMOD.GetFieldName(UnRegNew_ESLFN)].Equals(DBNull.Value))
    {
        myReg_History.UnRegNew_ESL = 0;
    }
    else
    {
        myReg_History.UnRegNew_ESL = int.Parse(reader[LibraryMOD.GetFieldName(UnRegNew_ESLFN)].ToString());
    }
    myReg_History.sUser =reader[LibraryMOD.GetFieldName( sUserFN) ].ToString();
    if (!reader[LibraryMOD.GetFieldName(dCreationDateFN)].Equals(DBNull.Value))
    {
    myReg_History.dCreationDate = DateTime.Parse(reader[LibraryMOD.GetFieldName( dCreationDateFN) ].ToString());
    }
    if (!reader[LibraryMOD.GetFieldName(dLastUpdateFN)].Equals(DBNull.Value))
    {
    myReg_History.dLastUpdate = DateTime.Parse(reader[LibraryMOD.GetFieldName( dLastUpdateFN) ].ToString());
    }
    myReg_History.sNUser =reader[LibraryMOD.GetFieldName( sNUserFN) ].ToString();
    myReg_History.sDevice =reader[LibraryMOD.GetFieldName( sDeviceFN) ].ToString();
     results.Add(myReg_History);
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
    public List< Reg_History > GetList(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
    {
    Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
    string sSQL = GetListSQL(sCondition);
    SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
    SqlCommand Cmd = new SqlCommand(sSQL, Conn);
    Conn.Open();
    SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
    List<Reg_History> results = new List<Reg_History>();
    try
    {
    //Default Value
    Reg_History myReg_History= new Reg_History();
    if (isDeafaultIncluded)
     {
    //Change the code here
     myReg_History.Term = -1;
   //  myReg_History.CampusID = "Select Reg_History" ;
    results.Add(myReg_History);
     }
    while (reader.Read())
    {
    myReg_History = new Reg_History();
    if (reader[LibraryMOD.GetFieldName(TermFN)].Equals(DBNull.Value))
    {
    myReg_History.Term = 0;
    }
    else
    {
    myReg_History.Term = int.Parse(reader[LibraryMOD.GetFieldName( TermFN) ].ToString());
    }
    if (reader[LibraryMOD.GetFieldName(CampusIDFN)].Equals(DBNull.Value))
    {
    myReg_History.CampusID = 0;
    }
    else
    {
    myReg_History.CampusID = int.Parse(reader[LibraryMOD.GetFieldName( CampusIDFN) ].ToString());
    }
    if (reader[LibraryMOD.GetFieldName(SessionFN)].Equals(DBNull.Value))
    {
    myReg_History.Session = 0;
    }
    else
    {
    myReg_History.Session = int.Parse(reader[LibraryMOD.GetFieldName( SessionFN) ].ToString());
    }
     results.Add(myReg_History);
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
         
    public int UpdateReg_History(InitializeModule.EnumCampus Campus, int iMode, int Term, int CampusID,
         int Session, int RegOld_Diploma, int RegOld_BA, int RegNew_Diploma, int RegNew_BA, 
         int RegExtended_Diploma, int RegExtended_BA, int RegExtended_ESL,
         int RegOld_Foundation, int RegNew_Foundation, 
         
         int UnRegOld_Diploma, int UnRegOld_BA, 
         int UnRegNew_Diploma, int UnRegNew_BA, int UnRegExtended_Diploma, 
         int UnRegExtended_BA, int UnRegExtended_ESL,
         int UnRegOld_Foundation, int UnRegNew_Foundation,
         int AllDiplomaGraduated,int AllExtendedToBA, int OldDiplomaRetention_LastSem,
         int OldBARetention_LastSem,int AllOldRetention_LastSem, 
         int AllOldUnregister_LastSem, int OldDiplomaRetention_LastYear, 
         int OldBARetention_LastYear, int AllOldRetention_LastYear, int AllOldUnregister_LastYear, 
         int AllPostponed, int AllPostponed_LastYear, int  AllPostponed_LastSem,
         int AllDiplomaGraduated_Last2Years,int AllDiplomaGraduated_LastYear,int AllDiplomaGraduated_LastSem,
         int AllPotentialNotExtendedBA_Last2Years,int AllPotentialNotExtendedBA_LastYear, int AllPotentialNotExtendedBA_LastSem,
         int RegOld_ESL, int RegNew_ESL, 
         int UnRegOld_ESL, int UnRegNew_ESL,
         int RegOld_Visiting, int RegNew_Visiting,
        string sUser, DateTime dCreationDate, DateTime dLastUpdate, string sNUser, string sDevice)
    {
         
       

    int iEffected = 0;
    Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
    SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
    try
    {
    Conn.Open();
    string sql = "";
    Reg_History theReg_History = new Reg_History();
    //'Updates the  table
    switch(iMode) 
      {
      case  (int)ECTGlobalDll.InitializeModule.enumModes.EditMode:
          sql = GetUpdateCommand();
          break ;
      case (int)ECTGlobalDll.InitializeModule.enumModes.NewMode:
          sql = GetInsertCommand();
          break ;
      }
    SqlCommand Cmd = new SqlCommand(sql, Conn);
    Cmd.Parameters.Add(new SqlParameter("@Term",Term));
    Cmd.Parameters.Add(new SqlParameter("@CampusID",CampusID));
    Cmd.Parameters.Add(new SqlParameter("@Session",Session));
    Cmd.Parameters.Add(new SqlParameter("@RegOld_Diploma",RegOld_Diploma));
    Cmd.Parameters.Add(new SqlParameter("@RegOld_BA",RegOld_BA));
    Cmd.Parameters.Add(new SqlParameter("@RegNew_Diploma",RegNew_Diploma));
    Cmd.Parameters.Add(new SqlParameter("@RegNew_BA",RegNew_BA));
    Cmd.Parameters.Add(new SqlParameter("@RegExtended_Diploma",RegExtended_Diploma));
    Cmd.Parameters.Add(new SqlParameter("@RegExtended_BA",RegExtended_BA));
    Cmd.Parameters.Add(new SqlParameter("@RegExtended_ESL", RegExtended_ESL));
    Cmd.Parameters.Add(new SqlParameter("@RegOld_Foundation",RegOld_Foundation));
    Cmd.Parameters.Add(new SqlParameter("@RegNew_Foundation",RegNew_Foundation));
   
    Cmd.Parameters.Add(new SqlParameter("@RegOld_ESL", RegOld_ESL));
    Cmd.Parameters.Add(new SqlParameter("@RegNew_ESL", RegNew_ESL));
    Cmd.Parameters.Add(new SqlParameter("@RegOld_Visiting", RegOld_Visiting));
    Cmd.Parameters.Add(new SqlParameter("@RegNew_Visiting", RegNew_Visiting));
    Cmd.Parameters.Add(new SqlParameter("@UnRegOld_Diploma",UnRegOld_Diploma));
    Cmd.Parameters.Add(new SqlParameter("@UnRegOld_BA",UnRegOld_BA));
    Cmd.Parameters.Add(new SqlParameter("@UnRegNew_Diploma",UnRegNew_Diploma));
    Cmd.Parameters.Add(new SqlParameter("@UnRegNew_BA",UnRegNew_BA));
    Cmd.Parameters.Add(new SqlParameter("@UnRegExtended_Diploma",UnRegExtended_Diploma));
    Cmd.Parameters.Add(new SqlParameter("@UnRegExtended_BA",UnRegExtended_BA));
    Cmd.Parameters.Add(new SqlParameter("@UnRegExtended_ESL", UnRegExtended_ESL));
    Cmd.Parameters.Add(new SqlParameter("@UnRegOld_Foundation",UnRegOld_Foundation));
    Cmd.Parameters.Add(new SqlParameter("@UnRegNew_Foundation",UnRegNew_Foundation));
   
    Cmd.Parameters.Add(new SqlParameter("@UnRegOld_ESL", UnRegOld_ESL));
    Cmd.Parameters.Add(new SqlParameter("@UnRegNew_ESL", UnRegNew_ESL));

    Cmd.Parameters.Add(new SqlParameter("@AllGraduatedDiploma", AllDiplomaGraduated));
    Cmd.Parameters.Add(new SqlParameter("@AllExtendedtoBA", AllExtendedToBA));

    Cmd.Parameters.Add(new SqlParameter("@OldDiplomaRetention_LastSem", OldDiplomaRetention_LastSem));
    Cmd.Parameters.Add(new SqlParameter("@OldBARetention_LastSem", OldBARetention_LastSem));
    Cmd.Parameters.Add(new SqlParameter("@AllOldRetention_LastSem", AllOldRetention_LastSem));
    Cmd.Parameters.Add(new SqlParameter("@AllOldUnregister_LastSem", AllOldUnregister_LastSem));

    Cmd.Parameters.Add(new SqlParameter("@OldDiplomaRetention_LastYear", OldDiplomaRetention_LastYear));
    Cmd.Parameters.Add(new SqlParameter("@OldBARetention_LastYear", OldBARetention_LastYear));
    Cmd.Parameters.Add(new SqlParameter("@AllOldRetention_LastYear", AllOldRetention_LastYear));
    Cmd.Parameters.Add(new SqlParameter("@AllOldUnregister_LastYear", AllOldUnregister_LastYear));

    Cmd.Parameters.Add(new SqlParameter("@AllPostponed", AllPostponed));
    Cmd.Parameters.Add(new SqlParameter("@AllPostponed_LastYear", AllPostponed_LastYear));
    Cmd.Parameters.Add(new SqlParameter("@AllPostponed_LastSem", AllPostponed_LastSem));
   
    Cmd.Parameters.Add(new SqlParameter("@AllDiplomaGraduated_Last2Years", AllDiplomaGraduated_Last2Years));
    Cmd.Parameters.Add(new SqlParameter("@AllDiplomaGraduated_LastYear", AllDiplomaGraduated_LastYear));
    Cmd.Parameters.Add(new SqlParameter("@AllDiplomaGraduated_LastSem", AllDiplomaGraduated_LastSem));

    Cmd.Parameters.Add(new SqlParameter("@AllPotentialNotExtendedBA_Last2Years", AllPotentialNotExtendedBA_Last2Years));
    Cmd.Parameters.Add(new SqlParameter("@AllPotentialNotExtendedBA_LastYear", AllPotentialNotExtendedBA_LastYear));
    Cmd.Parameters.Add(new SqlParameter("@AllPotentialNotExtendedBA_LastSem", AllPotentialNotExtendedBA_LastSem));
    
    Cmd.Parameters.Add(new SqlParameter("@sUser",sUser));
    Cmd.Parameters.Add(new SqlParameter("@dCreationDate",dCreationDate));
    Cmd.Parameters.Add(new SqlParameter("@dLastUpdate",dLastUpdate));
    Cmd.Parameters.Add(new SqlParameter("@sNUser",sNUser));
    Cmd.Parameters.Add(new SqlParameter("@sDevice",sDevice));
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
    public int DeleteReg_History(InitializeModule.EnumCampus Campus,string Term,string CampusID,string Session)
    {
    int iEffected = 0;
    Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
    SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
    try
    {
    string sSQL = GetDeleteCommand();
    //sSQL += sCondition;
    SqlCommand Cmd = new SqlCommand(sSQL, Conn);
    Cmd.Parameters.Add(new SqlParameter("@Term", Term ));
    Cmd.Parameters.Add(new SqlParameter("@CampusID", CampusID ));
    Cmd.Parameters.Add(new SqlParameter("@Session", Session ));
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
    public DataView GetDataView(bool isFromRole,int PK,string sCondition)
    {
    DataTable dt = new DataTable("Reg_History");
    DataView dv = new DataView();
    List<Reg_History> myReg_Historys = new List<Reg_History>();
    try
    {
    myReg_Historys = GetReg_History(InitializeModule.EnumCampus.ECTNew,sCondition,false);
    DataColumn col0= new DataColumn("Term", Type.GetType("int"));
    dt.Columns.Add(col0 );

    DataColumn col1= new DataColumn("CampusID", Type.GetType("int"));
    dt.Columns.Add(col1 );

    DataColumn col2= new DataColumn("Session", Type.GetType("int"));
    dt.Columns.Add(col2 );

    dt.Constraints.Add(new UniqueConstraint(col0));
    dt.Constraints.Add(new UniqueConstraint(col1));
    dt.Constraints.Add(new UniqueConstraint(col2));

    DataRow dr;
    for (int i = 0; i < myReg_Historys.Count; i++)
    {
    dr = dt.NewRow();
      dr[1] = myReg_Historys[i].Term;
      dr[2] = myReg_Historys[i].CampusID;
      dr[3] = myReg_Historys[i].Session;
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
    myReg_Historys.Clear();
    }
     return dv;
    }
    //'-------Populate  -----------------------------
    public DataTable Populate(SqlConnection con) 
    {
    string sSQL =""; 
    DataTable table = new DataTable();
    try
    {
    sSQL = "SELECT";
    sSQL += TermFN;
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
    public class Reg_HistoryCls : Reg_HistoryDAL
    {
                        #region "Decleration"
private int m_lngCurRow=0;
public SqlDataAdapter daReg_History;
private DataSet m_dsReg_History;
public DataRow Reg_HistoryDataRow ;
#endregion
                                                    #region "Puplic Properties"
public DataSet dsReg_History
{
get { return m_dsReg_History ; }
set { m_dsReg_History = value ; }
}
//-----------------------------------------------------
public int lngCurRow 
{
get { return  m_lngCurRow ; }
set {m_lngCurRow = value ; }
}
#endregion
    public Reg_HistoryCls()
    {
    try
    {
    dsReg_History= new DataSet();

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
public virtual SqlDataAdapter GetReg_HistoryDataAdapter(string sCondition ,SqlConnection con ) 
{
string sSQL =""; 
try
{
sSQL = GetSQL();
sSQL += " " + sCondition;
//-----------------------------------------
daReg_History = new SqlDataAdapter(sSQL, con);
// Create command builder. This line automatically generates the update commands for you, so you don't
// have to provide or create your own.
SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daReg_History);
//Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
// key + unique key information to be retrieved unless AddWithKey is specified.
daReg_History.MissingSchemaAction = MissingSchemaAction.AddWithKey;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daReg_History;
}
public virtual SqlDataAdapter GetReg_HistoryDataAdapter(SqlConnection con)  
{
try
{
daReg_History = new SqlDataAdapter();
//''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
//'' key + unique key information to be retrieved unless AddWithKey is specified.
daReg_History.MissingSchemaAction = MissingSchemaAction.AddWithKey;
//-----------------------------------------
SqlParameter Parmeter = default(SqlParameter); 
//[SELECT COMMAND]
SqlCommand cmdReg_History;
cmdReg_History = new SqlCommand(GetSelectCommand(), con);
//'cmdRolePermission.Parameters.Add("@Term", SqlDbType.Int, 4, "Term" );
//'cmdRolePermission.Parameters.Add("@CampusID", SqlDbType.Int, 4, "CampusID" );
//'cmdRolePermission.Parameters.Add("@Session", SqlDbType.Int, 4, "Session" );
daReg_History.SelectCommand = cmdReg_History;
//'Add Handlers
//'RowUpdating,RowUpdated
AddDAEventHandler();
//'[UPDATE COMMAND].
cmdReg_History = new SqlCommand(GetUpdateCommand(), con);
//'Delete PK Parameteres from here. b/c its declared below
//cmdReg_History.Parameters.Add("@Term", SqlDbType.Int,4, LibraryMOD.GetFieldName(TermFN));
//cmdReg_History.Parameters.Add("@CampusID", SqlDbType.Int,4, LibraryMOD.GetFieldName(CampusIDFN));
//cmdReg_History.Parameters.Add("@Session", SqlDbType.Int,4, LibraryMOD.GetFieldName(SessionFN));
cmdReg_History.Parameters.Add("@RegOld_Diploma", SqlDbType.Int,4, LibraryMOD.GetFieldName(RegOld_DiplomaFN));
cmdReg_History.Parameters.Add("@RegOld_BA", SqlDbType.Int,4, LibraryMOD.GetFieldName(RegOld_BAFN));
cmdReg_History.Parameters.Add("@RegNew_Diploma", SqlDbType.Int,4, LibraryMOD.GetFieldName(RegNew_DiplomaFN));
cmdReg_History.Parameters.Add("@RegNew_BA", SqlDbType.Int,4, LibraryMOD.GetFieldName(RegNew_BAFN));
cmdReg_History.Parameters.Add("@RegExtended_Diploma", SqlDbType.Int,4, LibraryMOD.GetFieldName(RegExtended_DiplomaFN));
cmdReg_History.Parameters.Add("@RegExtended_BA", SqlDbType.Int,4, LibraryMOD.GetFieldName(RegExtended_BAFN));
cmdReg_History.Parameters.Add("@RegOld_Foundation", SqlDbType.Int,4, LibraryMOD.GetFieldName(RegOld_FoundationFN));
cmdReg_History.Parameters.Add("@RegNew_Foundation", SqlDbType.Int,4, LibraryMOD.GetFieldName(RegNew_FoundationFN));
cmdReg_History.Parameters.Add("@UnRegOld_Diploma", SqlDbType.Int,4, LibraryMOD.GetFieldName(UnRegOld_DiplomaFN));
cmdReg_History.Parameters.Add("@UnRegOld_BA", SqlDbType.Int,4, LibraryMOD.GetFieldName(UnRegOld_BAFN));
cmdReg_History.Parameters.Add("@UnRegNew_Diploma", SqlDbType.Int,4, LibraryMOD.GetFieldName(UnRegNew_DiplomaFN));
cmdReg_History.Parameters.Add("@UnRegNew_BA", SqlDbType.Int,4, LibraryMOD.GetFieldName(UnRegNew_BAFN));
cmdReg_History.Parameters.Add("@UnRegExtended_Diploma", SqlDbType.Int,4, LibraryMOD.GetFieldName(UnRegExtended_DiplomaFN));
cmdReg_History.Parameters.Add("@UnRegExtended_BA", SqlDbType.Int,4, LibraryMOD.GetFieldName(UnRegExtended_BAFN));
cmdReg_History.Parameters.Add("@UnRegOld_Foundation", SqlDbType.Int,4, LibraryMOD.GetFieldName(UnRegOld_FoundationFN));
cmdReg_History.Parameters.Add("@UnRegNew_Foundation", SqlDbType.Int,4, LibraryMOD.GetFieldName(UnRegNew_FoundationFN));
cmdReg_History.Parameters.Add("@sUser", SqlDbType.VarChar,50, LibraryMOD.GetFieldName(sUserFN));
cmdReg_History.Parameters.Add("@dCreationDate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dCreationDateFN));
cmdReg_History.Parameters.Add("@dLastUpdate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dLastUpdateFN));
cmdReg_History.Parameters.Add("@sNUser", SqlDbType.VarChar,50, LibraryMOD.GetFieldName(sNUserFN));
cmdReg_History.Parameters.Add("@sDevice", SqlDbType.VarChar,50, LibraryMOD.GetFieldName(sDeviceFN));


Parmeter = cmdReg_History.Parameters.Add("@Term", SqlDbType.Int, 4, LibraryMOD.GetFieldName(TermFN));
Parmeter = cmdReg_History.Parameters.Add("@CampusID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(CampusIDFN));
Parmeter = cmdReg_History.Parameters.Add("@Session", SqlDbType.Int, 4, LibraryMOD.GetFieldName(SessionFN));
Parmeter.SourceVersion = DataRowVersion.Original;
//'Its should be none for batch updating
//'UpdateCommand, InsertCommand, and DeleteCommand 
//'should be set to None or OutputParameters
daReg_History.UpdateCommand = cmdReg_History;
daReg_History.UpdateCommand.UpdatedRowSource  = UpdateRowSource.None ;
//'-------------------------------------------------------------------------
//'/INSERT COMMAND
 cmdReg_History = new SqlCommand(GetInsertCommand(), con);
cmdReg_History.Parameters.Add("@Term", SqlDbType.Int,4, LibraryMOD.GetFieldName(TermFN));
cmdReg_History.Parameters.Add("@CampusID", SqlDbType.Int,4, LibraryMOD.GetFieldName(CampusIDFN));
cmdReg_History.Parameters.Add("@Session", SqlDbType.Int,4, LibraryMOD.GetFieldName(SessionFN));
cmdReg_History.Parameters.Add("@RegOld_Diploma", SqlDbType.Int,4, LibraryMOD.GetFieldName(RegOld_DiplomaFN));
cmdReg_History.Parameters.Add("@RegOld_BA", SqlDbType.Int,4, LibraryMOD.GetFieldName(RegOld_BAFN));
cmdReg_History.Parameters.Add("@RegNew_Diploma", SqlDbType.Int,4, LibraryMOD.GetFieldName(RegNew_DiplomaFN));
cmdReg_History.Parameters.Add("@RegNew_BA", SqlDbType.Int,4, LibraryMOD.GetFieldName(RegNew_BAFN));
cmdReg_History.Parameters.Add("@RegExtended_Diploma", SqlDbType.Int,4, LibraryMOD.GetFieldName(RegExtended_DiplomaFN));
cmdReg_History.Parameters.Add("@RegExtended_BA", SqlDbType.Int,4, LibraryMOD.GetFieldName(RegExtended_BAFN));
cmdReg_History.Parameters.Add("@RegOld_Foundation", SqlDbType.Int,4, LibraryMOD.GetFieldName(RegOld_FoundationFN));
cmdReg_History.Parameters.Add("@RegNew_Foundation", SqlDbType.Int,4, LibraryMOD.GetFieldName(RegNew_FoundationFN));
cmdReg_History.Parameters.Add("@UnRegOld_Diploma", SqlDbType.Int,4, LibraryMOD.GetFieldName(UnRegOld_DiplomaFN));
cmdReg_History.Parameters.Add("@UnRegOld_BA", SqlDbType.Int,4, LibraryMOD.GetFieldName(UnRegOld_BAFN));
cmdReg_History.Parameters.Add("@UnRegNew_Diploma", SqlDbType.Int,4, LibraryMOD.GetFieldName(UnRegNew_DiplomaFN));
cmdReg_History.Parameters.Add("@UnRegNew_BA", SqlDbType.Int,4, LibraryMOD.GetFieldName(UnRegNew_BAFN));
cmdReg_History.Parameters.Add("@UnRegExtended_Diploma", SqlDbType.Int,4, LibraryMOD.GetFieldName(UnRegExtended_DiplomaFN));
cmdReg_History.Parameters.Add("@UnRegExtended_BA", SqlDbType.Int,4, LibraryMOD.GetFieldName(UnRegExtended_BAFN));
cmdReg_History.Parameters.Add("@UnRegOld_Foundation", SqlDbType.Int,4, LibraryMOD.GetFieldName(UnRegOld_FoundationFN));
cmdReg_History.Parameters.Add("@UnRegNew_Foundation", SqlDbType.Int,4, LibraryMOD.GetFieldName(UnRegNew_FoundationFN));
cmdReg_History.Parameters.Add("@sUser", SqlDbType.VarChar,50, LibraryMOD.GetFieldName(sUserFN));
cmdReg_History.Parameters.Add("@dCreationDate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dCreationDateFN));
cmdReg_History.Parameters.Add("@dLastUpdate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dLastUpdateFN));
cmdReg_History.Parameters.Add("@sNUser", SqlDbType.VarChar,50, LibraryMOD.GetFieldName(sNUserFN));
cmdReg_History.Parameters.Add("@sDevice", SqlDbType.VarChar,50, LibraryMOD.GetFieldName(sDeviceFN));
Parmeter.SourceVersion = DataRowVersion.Current;
daReg_History.InsertCommand =cmdReg_History;
daReg_History.InsertCommand.UpdatedRowSource  = UpdateRowSource.None;
//'------------------------
//'/DELETE COMMAND
 cmdReg_History = new SqlCommand(GetDeleteCommand(), con);
Parmeter = cmdReg_History.Parameters.Add("@Term", SqlDbType.Int, 4, LibraryMOD.GetFieldName(TermFN));
Parmeter = cmdReg_History.Parameters.Add("@CampusID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(CampusIDFN));
Parmeter = cmdReg_History.Parameters.Add("@Session", SqlDbType.Int, 4, LibraryMOD.GetFieldName(SessionFN));
Parmeter.SourceVersion = DataRowVersion.Original;
daReg_History.DeleteCommand =cmdReg_History;
daReg_History.DeleteCommand.UpdatedRowSource  = UpdateRowSource.None;
//'Batch Size
//'Set the batch size.
daReg_History.UpdateBatchSize = ECTGlobalDll.InitializeModule.BATCH_SIZE;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daReg_History;
}
//'-------SaveData  -----------------------------
public int SaveData(int lFormMode  )  
{
//SaveData= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
switch (lFormMode)
{
case (int)ECTGlobalDll.InitializeModule.enumModes.NewMode:
 DataRow  dr = default(DataRow); 
dr = dsReg_History.Tables[TableName].NewRow();
dr[LibraryMOD.GetFieldName(TermFN)]=Term;
dr[LibraryMOD.GetFieldName(CampusIDFN)]=CampusID;
dr[LibraryMOD.GetFieldName(SessionFN)]=Session;
dr[LibraryMOD.GetFieldName(RegOld_DiplomaFN)]=RegOld_Diploma;
dr[LibraryMOD.GetFieldName(RegOld_BAFN)]=RegOld_BA;
dr[LibraryMOD.GetFieldName(RegNew_DiplomaFN)]=RegNew_Diploma;
dr[LibraryMOD.GetFieldName(RegNew_BAFN)]=RegNew_BA;
dr[LibraryMOD.GetFieldName(RegExtended_DiplomaFN)]=RegExtended_Diploma;
dr[LibraryMOD.GetFieldName(RegExtended_BAFN)]=RegExtended_BA;
dr[LibraryMOD.GetFieldName(RegOld_FoundationFN)]=RegOld_Foundation;
dr[LibraryMOD.GetFieldName(RegNew_FoundationFN)]=RegNew_Foundation;
dr[LibraryMOD.GetFieldName(UnRegOld_DiplomaFN)]=UnRegOld_Diploma;
dr[LibraryMOD.GetFieldName(UnRegOld_BAFN)]=UnRegOld_BA;
dr[LibraryMOD.GetFieldName(UnRegNew_DiplomaFN)]=UnRegNew_Diploma;
dr[LibraryMOD.GetFieldName(UnRegNew_BAFN)]=UnRegNew_BA;
dr[LibraryMOD.GetFieldName(UnRegExtended_DiplomaFN)]=UnRegExtended_Diploma;
dr[LibraryMOD.GetFieldName(UnRegExtended_BAFN)]=UnRegExtended_BA;
dr[LibraryMOD.GetFieldName(UnRegOld_FoundationFN)]=UnRegOld_Foundation;
dr[LibraryMOD.GetFieldName(UnRegNew_FoundationFN)]=UnRegNew_Foundation;
dr[LibraryMOD.GetFieldName(sUserFN)]=sUser;
dr[LibraryMOD.GetFieldName(dCreationDateFN)]=dCreationDate;
dr[LibraryMOD.GetFieldName(dLastUpdateFN)]=dLastUpdate;
dr[LibraryMOD.GetFieldName(sNUserFN)]=sNUser;
dr[LibraryMOD.GetFieldName(sDeviceFN)]=sDevice;
dsReg_History.Tables[TableName].Rows.Add(dr);
break;
case (int)ECTGlobalDll.InitializeModule.enumModes.EditMode:
 DataRow[] drAry = null;
drAry = dsReg_History.Tables[TableName].Select(LibraryMOD.GetFieldName(TermFN)  + "=" + Term  + " AND " + LibraryMOD.GetFieldName(CampusIDFN) + "=" + CampusID  + " AND " + LibraryMOD.GetFieldName(SessionFN) + "=" + Session);
//'its return array of rows and we can access the first by index 0
drAry[0][LibraryMOD.GetFieldName(TermFN)]=Term;
drAry[0][LibraryMOD.GetFieldName(CampusIDFN)]=CampusID;
drAry[0][LibraryMOD.GetFieldName(SessionFN)]=Session;
drAry[0][LibraryMOD.GetFieldName(RegOld_DiplomaFN)]=RegOld_Diploma;
drAry[0][LibraryMOD.GetFieldName(RegOld_BAFN)]=RegOld_BA;
drAry[0][LibraryMOD.GetFieldName(RegNew_DiplomaFN)]=RegNew_Diploma;
drAry[0][LibraryMOD.GetFieldName(RegNew_BAFN)]=RegNew_BA;
drAry[0][LibraryMOD.GetFieldName(RegExtended_DiplomaFN)]=RegExtended_Diploma;
drAry[0][LibraryMOD.GetFieldName(RegExtended_BAFN)]=RegExtended_BA;
drAry[0][LibraryMOD.GetFieldName(RegOld_FoundationFN)]=RegOld_Foundation;
drAry[0][LibraryMOD.GetFieldName(RegNew_FoundationFN)]=RegNew_Foundation;
drAry[0][LibraryMOD.GetFieldName(UnRegOld_DiplomaFN)]=UnRegOld_Diploma;
drAry[0][LibraryMOD.GetFieldName(UnRegOld_BAFN)]=UnRegOld_BA;
drAry[0][LibraryMOD.GetFieldName(UnRegNew_DiplomaFN)]=UnRegNew_Diploma;
drAry[0][LibraryMOD.GetFieldName(UnRegNew_BAFN)]=UnRegNew_BA;
drAry[0][LibraryMOD.GetFieldName(UnRegExtended_DiplomaFN)]=UnRegExtended_Diploma;
drAry[0][LibraryMOD.GetFieldName(UnRegExtended_BAFN)]=UnRegExtended_BA;
drAry[0][LibraryMOD.GetFieldName(UnRegOld_FoundationFN)]=UnRegOld_Foundation;
drAry[0][LibraryMOD.GetFieldName(UnRegNew_FoundationFN)]=UnRegNew_Foundation;
drAry[0][LibraryMOD.GetFieldName(sUserFN)]=sUser;
drAry[0][LibraryMOD.GetFieldName(dCreationDateFN)]=dCreationDate;
drAry[0][LibraryMOD.GetFieldName(dLastUpdateFN)]=dLastUpdate;
drAry[0][LibraryMOD.GetFieldName(sNUserFN)]=sNUser;
drAry[0][LibraryMOD.GetFieldName(sDeviceFN)]=sDevice;
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
public int CommitReg_History()  
{
//CommitReg_History= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
//'' Update Database with SqlDataAdapter
daReg_History.Update(dsReg_History, TableName);
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
FindInMultiPKey(Term,CampusID,Session);
if (( Reg_HistoryDataRow != null)) 
{
Reg_HistoryDataRow.Delete();
CommitReg_History();
if (MoveNext() == ECTGlobalDll.InitializeModule.FAIL_RET ) return ECTGlobalDll.InitializeModule.FAIL_RET;
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
    if (Reg_HistoryDataRow[LibraryMOD.GetFieldName(TermFN)]== System.DBNull.Value)
    {
      Term=0;
    }
    else
    {
      Term = (int)Reg_HistoryDataRow[LibraryMOD.GetFieldName(TermFN)];
    }
    if (Reg_HistoryDataRow[LibraryMOD.GetFieldName(CampusIDFN)]== System.DBNull.Value)
    {
      CampusID=0;
    }
    else
    {
      CampusID = (int)Reg_HistoryDataRow[LibraryMOD.GetFieldName(CampusIDFN)];
    }
    if (Reg_HistoryDataRow[LibraryMOD.GetFieldName(SessionFN)]== System.DBNull.Value)
    {
      Session=0;
    }
    else
    {
      Session = (int)Reg_HistoryDataRow[LibraryMOD.GetFieldName(SessionFN)];
    }
    if (Reg_HistoryDataRow[LibraryMOD.GetFieldName(RegOld_DiplomaFN)]== System.DBNull.Value)
    {
      RegOld_Diploma=0;
    }
    else
    {
      RegOld_Diploma = (int)Reg_HistoryDataRow[LibraryMOD.GetFieldName(RegOld_DiplomaFN)];
    }
    if (Reg_HistoryDataRow[LibraryMOD.GetFieldName(RegOld_BAFN)]== System.DBNull.Value)
    {
      RegOld_BA=0;
    }
    else
    {
      RegOld_BA = (int)Reg_HistoryDataRow[LibraryMOD.GetFieldName(RegOld_BAFN)];
    }
    if (Reg_HistoryDataRow[LibraryMOD.GetFieldName(RegNew_DiplomaFN)]== System.DBNull.Value)
    {
      RegNew_Diploma=0;
    }
    else
    {
      RegNew_Diploma = (int)Reg_HistoryDataRow[LibraryMOD.GetFieldName(RegNew_DiplomaFN)];
    }
    if (Reg_HistoryDataRow[LibraryMOD.GetFieldName(RegNew_BAFN)]== System.DBNull.Value)
    {
      RegNew_BA=0;
    }
    else
    {
      RegNew_BA = (int)Reg_HistoryDataRow[LibraryMOD.GetFieldName(RegNew_BAFN)];
    }
    if (Reg_HistoryDataRow[LibraryMOD.GetFieldName(RegExtended_DiplomaFN)]== System.DBNull.Value)
    {
      RegExtended_Diploma=0;
    }
    else
    {
      RegExtended_Diploma = (int)Reg_HistoryDataRow[LibraryMOD.GetFieldName(RegExtended_DiplomaFN)];
    }
    if (Reg_HistoryDataRow[LibraryMOD.GetFieldName(RegExtended_BAFN)]== System.DBNull.Value)
    {
      RegExtended_BA=0;
    }
    else
    {
      RegExtended_BA = (int)Reg_HistoryDataRow[LibraryMOD.GetFieldName(RegExtended_BAFN)];
    }
    if (Reg_HistoryDataRow[LibraryMOD.GetFieldName(RegOld_FoundationFN)]== System.DBNull.Value)
    {
      RegOld_Foundation=0;
    }
    else
    {
      RegOld_Foundation = (int)Reg_HistoryDataRow[LibraryMOD.GetFieldName(RegOld_FoundationFN)];
    }
    if (Reg_HistoryDataRow[LibraryMOD.GetFieldName(RegNew_FoundationFN)]== System.DBNull.Value)
    {
      RegNew_Foundation=0;
    }
    else
    {
      RegNew_Foundation = (int)Reg_HistoryDataRow[LibraryMOD.GetFieldName(RegNew_FoundationFN)];
    }
    if (Reg_HistoryDataRow[LibraryMOD.GetFieldName(UnRegOld_DiplomaFN)]== System.DBNull.Value)
    {
      UnRegOld_Diploma=0;
    }
    else
    {
      UnRegOld_Diploma = (int)Reg_HistoryDataRow[LibraryMOD.GetFieldName(UnRegOld_DiplomaFN)];
    }
    if (Reg_HistoryDataRow[LibraryMOD.GetFieldName(UnRegOld_BAFN)]== System.DBNull.Value)
    {
      UnRegOld_BA=0;
    }
    else
    {
      UnRegOld_BA = (int)Reg_HistoryDataRow[LibraryMOD.GetFieldName(UnRegOld_BAFN)];
    }
    if (Reg_HistoryDataRow[LibraryMOD.GetFieldName(UnRegNew_DiplomaFN)]== System.DBNull.Value)
    {
      UnRegNew_Diploma=0;
    }
    else
    {
      UnRegNew_Diploma = (int)Reg_HistoryDataRow[LibraryMOD.GetFieldName(UnRegNew_DiplomaFN)];
    }
    if (Reg_HistoryDataRow[LibraryMOD.GetFieldName(UnRegNew_BAFN)]== System.DBNull.Value)
    {
      UnRegNew_BA=0;
    }
    else
    {
      UnRegNew_BA = (int)Reg_HistoryDataRow[LibraryMOD.GetFieldName(UnRegNew_BAFN)];
    }
    if (Reg_HistoryDataRow[LibraryMOD.GetFieldName(UnRegExtended_DiplomaFN)]== System.DBNull.Value)
    {
      UnRegExtended_Diploma=0;
    }
    else
    {
      UnRegExtended_Diploma = (int)Reg_HistoryDataRow[LibraryMOD.GetFieldName(UnRegExtended_DiplomaFN)];
    }
    if (Reg_HistoryDataRow[LibraryMOD.GetFieldName(UnRegExtended_BAFN)]== System.DBNull.Value)
    {
      UnRegExtended_BA=0;
    }
    else
    {
      UnRegExtended_BA = (int)Reg_HistoryDataRow[LibraryMOD.GetFieldName(UnRegExtended_BAFN)];
    }
    if (Reg_HistoryDataRow[LibraryMOD.GetFieldName(UnRegOld_FoundationFN)]== System.DBNull.Value)
    {
      UnRegOld_Foundation=0;
    }
    else
    {
      UnRegOld_Foundation = (int)Reg_HistoryDataRow[LibraryMOD.GetFieldName(UnRegOld_FoundationFN)];
    }
    if (Reg_HistoryDataRow[LibraryMOD.GetFieldName(UnRegNew_FoundationFN)]== System.DBNull.Value)
    {
      UnRegNew_Foundation=0;
    }
    else
    {
      UnRegNew_Foundation = (int)Reg_HistoryDataRow[LibraryMOD.GetFieldName(UnRegNew_FoundationFN)];
    }
    if (Reg_HistoryDataRow[LibraryMOD.GetFieldName(sUserFN)]== System.DBNull.Value)
    {
      sUser="";
    }
    else
    {
      sUser = (string)Reg_HistoryDataRow[LibraryMOD.GetFieldName(sUserFN)];
    }
    if (Reg_HistoryDataRow[LibraryMOD.GetFieldName(dCreationDateFN)]== System.DBNull.Value)
    {
    }
    else
    {
      dCreationDate = (DateTime)Reg_HistoryDataRow[LibraryMOD.GetFieldName(dCreationDateFN)];
    }
    if (Reg_HistoryDataRow[LibraryMOD.GetFieldName(dLastUpdateFN)]== System.DBNull.Value)
    {
    }
    else
    {
      dLastUpdate = (DateTime)Reg_HistoryDataRow[LibraryMOD.GetFieldName(dLastUpdateFN)];
    }
    if (Reg_HistoryDataRow[LibraryMOD.GetFieldName(sNUserFN)]== System.DBNull.Value)
    {
      sNUser="";
    }
    else
    {
      sNUser = (string)Reg_HistoryDataRow[LibraryMOD.GetFieldName(sNUserFN)];
    }
    if (Reg_HistoryDataRow[LibraryMOD.GetFieldName(sDeviceFN)]== System.DBNull.Value)
    {
      sDevice="";
    }
    else
    {
      sDevice = (string)Reg_HistoryDataRow[LibraryMOD.GetFieldName(sDeviceFN)];
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
    public int FindInMultiPKey(int PKTerm,int PKCampusID,int PKSession) 
    {
    //FindInMultiPKey= ECTGlobalDll.InitializeModule.FAIL_RET;
    try
    {
    //' Create an array for the key values to find.
    object[] findTheseVals = new object[3] ; 
    //' Set the values of the keys to find.
    findTheseVals[0] = PKTerm;
    findTheseVals[1] = PKCampusID;
    findTheseVals[2] = PKSession;
    Reg_HistoryDataRow = dsReg_History.Tables[TableName].Rows.Find(findTheseVals);
    if  ((Reg_HistoryDataRow !=null)) 
    {
    lngCurRow = dsReg_History.Tables[TableName].Rows.IndexOf(Reg_HistoryDataRow);
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
public int  MoveFirst()  
{
//MoveFirst= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
  lngCurRow = 0;
  if (GoToCurrentRow() == ECTGlobalDll.InitializeModule.FAIL_RET ) return InitializeModule.FAIL_RET;
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
public int  MovePrevious()  
{
//MovePrevious= InitializeModule.FAIL_RET;
try
{
  lngCurRow = Math.Max(lngCurRow - 1, 0);
  if (GoToCurrentRow() == ECTGlobalDll.InitializeModule.FAIL_RET ) return ECTGlobalDll.InitializeModule.FAIL_RET;
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
public int  MoveLast()  
{
//MoveLast= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
  lngCurRow = dsReg_History.Tables[TableName].Rows.Count - 1; //'Zero based index
  if (GoToCurrentRow() == ECTGlobalDll.InitializeModule.FAIL_RET ) return ECTGlobalDll.InitializeModule.FAIL_RET;
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
public int  MoveNext() 
{
//MoveNext= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
  lngCurRow = Math.Min(lngCurRow + 1, dsReg_History.Tables[TableName].Rows.Count - 1);
  if (GoToCurrentRow() == ECTGlobalDll.InitializeModule.FAIL_RET ) return ECTGlobalDll.InitializeModule.FAIL_RET;
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
public int  GoToCurrentRow() 
{
//GoToCurrentRow= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
  if (lngCurRow >= 0 & dsReg_History.Tables[TableName].Rows.Count > 0) 
{
  Reg_HistoryDataRow = dsReg_History.Tables[TableName].Rows[lngCurRow];
  SynchronizeDataRowToClass();
}
  else  return ECTGlobalDll.InitializeModule.FAIL_RET;
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
daReg_History.RowUpdating+= new SqlRowUpdatingEventHandler(OnRowUpdating);
daReg_History.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
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
daReg_History.RowUpdating-= new SqlRowUpdatingEventHandler(OnRowUpdating);
daReg_History.RowUpdated-= new SqlRowUpdatedEventHandler(OnRowUpdated);
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
if (args.StatementType == StatementType.Delete )
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
private static void  OnRowUpdated( object sender, SqlRowUpdatedEventArgs args)
{
try
{
if (args.Status == UpdateStatus.ErrorsOccurred )
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
