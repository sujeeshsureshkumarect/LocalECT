using System;
using System.Data;
using System.Configuration;
////using System.Linq;
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
public class Grade_Header
{
//Creation Date: 27/06/2010 8:14 PM
//Programmer Name : 
//-----Decleration --------------
#region "Decleration"
private int m_intStudyYear; 
private int m_byteSemester; 
private int m_byteShift; 
private string m_strCourse; 
private int m_byteClass; 
private string m_lngStudentNumber; 
private int m_byteRefCollege; 
//private double m_curFirst; 
//private double m_curSecond; 
//private double m_curThird; 
//private double m_curAssignments; 
//private double m_curAssignments2; 
//private double m_curAssignments3; 
//private double m_curParticipate; 
//private double m_curProjects; 
//private double m_curProjects2; 
//private double m_curProjects3; 
//private double m_curFinal; 
private double m_curUseMark; 
private string m_strGrade; 
private string m_bDisActivated; 
private string m_bCanceled; 
private int m_intCanceledYear; 
private int m_byteCanceledSem; 
private string m_strDegree; 
private string m_strMajor; 
private double m_AttMark;
private string m_sAlt;
private string m_sEQ;
private string m_strUserCreate; 
private DateTime m_dateCreate; 
private string m_strUserSave; 
private DateTime m_dateLastSave; 
private string m_strMachine; 
private string m_strNUser;
 
#endregion
#region "Puplic Properties"
//'-----------------------------------------------------
public int intStudyYear
{
get { return  m_intStudyYear; }
set {m_intStudyYear  = value ; }
}
public int byteSemester
{
get { return  m_byteSemester; }
set {m_byteSemester  = value ; }
}
public int byteShift
{
get { return  m_byteShift; }
set {m_byteShift  = value ; }
}
public string strCourse
{
get { return  m_strCourse; }
set {m_strCourse  = value ; }
}
public int byteClass
{
get { return  m_byteClass; }
set {m_byteClass  = value ; }
}
public string lngStudentNumber
{
get { return  m_lngStudentNumber; }
set {m_lngStudentNumber  = value ; }
}
public int byteRefCollege
{
get { return  m_byteRefCollege; }
set {m_byteRefCollege  = value ; }
}

//public double curFirst
//{
//get { return  m_curFirst; }
//set {m_curFirst  = value ; }
//}
//public double curSecond
//{
//get { return  m_curSecond; }
//set {m_curSecond  = value ; }
//}
//public double curThird
//{
//get { return  m_curThird; }
//set {m_curThird  = value ; }
//}
//public double curAssignments
//{
//get { return  m_curAssignments; }
//set {m_curAssignments  = value ; }
//}
//public double curAssignments2
//{
//get { return  m_curAssignments2; }
//set {m_curAssignments2  = value ; }
//}
//public double curAssignments3
//{
//get { return  m_curAssignments3; }
//set {m_curAssignments3  = value ; }
//}
//public double curParticipate
//{
//get { return  m_curParticipate; }
//set {m_curParticipate  = value ; }
//}
//public double curProjects
//{
//get { return  m_curProjects; }
//set {m_curProjects  = value ; }
//}
//public double curProjects2
//{
//get { return  m_curProjects2; }
//set {m_curProjects2  = value ; }
//}
//public double curProjects3
//{
//get { return  m_curProjects3; }
//set {m_curProjects3  = value ; }
//}
//public double curFinal
//{
//get { return  m_curFinal; }
//set {m_curFinal  = value ; }
//}

public double curUseMark
{
    get { return  m_curUseMark; }
    set {m_curUseMark  = value ; }
}

public string strGrade
{
get { return  m_strGrade; }
set {m_strGrade  = value ; }
}
public string bDisActivated
{
get { return  m_bDisActivated; }
set {m_bDisActivated  = value ; }
}
public string bCanceled
{
get { return  m_bCanceled; }
set {m_bCanceled  = value ; }
}
public int intCanceledYear
{
get { return  m_intCanceledYear; }
set {m_intCanceledYear  = value ; }
}
public int byteCanceledSem
{
get { return  m_byteCanceledSem; }
set {m_byteCanceledSem  = value ; }
}
public string strDegree
{
get { return  m_strDegree; }
set {m_strDegree  = value ; }
}
public string strMajor
{
get { return  m_strMajor; }
set {m_strMajor  = value ; }
}
public double AttMark
{
get { return  m_AttMark; }
set {m_AttMark  = value ; }
}

public string SAlt
{
    get { return m_sAlt; }
    set { m_sAlt = value; }
}
public string sEQ
{
    get { return m_sEQ; }
    set { m_sEQ = value; }
}
public string strUserCreate
{
get { return  m_strUserCreate; }
set {m_strUserCreate  = value ; }
}
public DateTime dateCreate
{
get { return  m_dateCreate; }
set {m_dateCreate  = value ; }
}
public string strUserSave
{
get { return  m_strUserSave; }
set {m_strUserSave  = value ; }
}
public DateTime dateLastSave
{
get { return  m_dateLastSave; }
set {m_dateLastSave  = value ; }
}
public string strMachine
{
get { return  m_strMachine; }
set {m_strMachine  = value ; }
}
public string strNUser
{
get { return  m_strNUser; }
set {m_strNUser  = value ; }
}
//'-----------------------------------------------------
#endregion
//'-----------------------------------------------------
public Grade_Header()
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
public class Grade_HeaderDAL : Grade_Header
{
#region "Decleration"
private string m_TableName;
private string m_intStudyYearFN ;
private string m_byteSemesterFN ;
private string m_byteShiftFN ;
private string m_strCourseFN ;
private string m_byteClassFN ;
private string m_lngStudentNumberFN ;
private string m_byteRefCollegeFN ;
//private string m_curFirstFN ;
//private string m_curSecondFN ;
//private string m_curThirdFN ;
//private string m_curAssignmentsFN ;
//private string m_curAssignments2FN ;
//private string m_curAssignments3FN ;
//private string m_curParticipateFN ;
//private string m_curProjectsFN ;
//private string m_curProjects2FN ;
//private string m_curProjects3FN ;
//private string m_curFinalFN ;
private string m_curUseMarkFN ;
private string m_strGradeFN ;
private string m_bDisActivatedFN ;
private string m_bCanceledFN ;
private string m_intCanceledYearFN ;
private string m_byteCanceledSemFN ;
private string m_strDegreeFN ;
private string m_strMajorFN ;
private string m_AttMarkFN ;
private string m_sAltFN;
private string m_sEQFN;
private string m_strUserCreateFN ;
private string m_dateCreateFN ;
private string m_strUserSaveFN ;
private string m_dateLastSaveFN ;
private string m_strMachineFN ;
private string m_strNUserFN ;
#endregion
//'-----------------------------------------------------
#region "Puplic Properties"
public string TableName 
{
get { return m_TableName; }
set { m_TableName = value; }
}
public string intStudyYearFN 
{
get { return  m_intStudyYearFN; }
set {m_intStudyYearFN  = value ; }
}
public string byteSemesterFN 
{
get { return  m_byteSemesterFN; }
set {m_byteSemesterFN  = value ; }
}
public string byteShiftFN 
{
get { return  m_byteShiftFN; }
set {m_byteShiftFN  = value ; }
}
public string strCourseFN 
{
get { return  m_strCourseFN; }
set {m_strCourseFN  = value ; }
}
public string byteClassFN 
{
get { return  m_byteClassFN; }
set {m_byteClassFN  = value ; }
}
public string lngStudentNumberFN 
{
get { return  m_lngStudentNumberFN; }
set {m_lngStudentNumberFN  = value ; }
}
public string byteRefCollegeFN 
{
get { return  m_byteRefCollegeFN; }
set {m_byteRefCollegeFN  = value ; }
}
//public string curFirstFN 
//{
//get { return  m_curFirstFN; }
//set {m_curFirstFN  = value ; }
//}
//public string curSecondFN 
//{
//get { return  m_curSecondFN; }
//set {m_curSecondFN  = value ; }
//}
//public string curThirdFN 
//{
//get { return  m_curThirdFN; }
//set {m_curThirdFN  = value ; }
//}
//public string curAssignmentsFN 
//{
//get { return  m_curAssignmentsFN; }
//set {m_curAssignmentsFN  = value ; }
//}
//public string curAssignments2FN 
//{
//get { return  m_curAssignments2FN; }
//set {m_curAssignments2FN  = value ; }
//}
//public string curAssignments3FN 
//{
//get { return  m_curAssignments3FN; }
//set {m_curAssignments3FN  = value ; }
//}
//public string curParticipateFN 
//{
//get { return  m_curParticipateFN; }
//set {m_curParticipateFN  = value ; }
//}
//public string curProjectsFN 
//{
//get { return  m_curProjectsFN; }
//set {m_curProjectsFN  = value ; }
//}
//public string curProjects2FN 
//{
//get { return  m_curProjects2FN; }
//set {m_curProjects2FN  = value ; }
//}
//public string curProjects3FN 
//{
//get { return  m_curProjects3FN; }
//set {m_curProjects3FN  = value ; }
//}
//public string curFinalFN 
//{
//get { return  m_curFinalFN; }
//set {m_curFinalFN  = value ; }
//}
public string curUseMarkFN 
{
get { return  m_curUseMarkFN; }
set {m_curUseMarkFN  = value ; }
}
public string strGradeFN 
{
get { return  m_strGradeFN; }
set {m_strGradeFN  = value ; }
}
public string bDisActivatedFN 
{
get { return  m_bDisActivatedFN; }
set {m_bDisActivatedFN  = value ; }
}
public string bCanceledFN 
{
get { return  m_bCanceledFN; }
set {m_bCanceledFN  = value ; }
}
public string intCanceledYearFN 
{
get { return  m_intCanceledYearFN; }
set {m_intCanceledYearFN  = value ; }
}
public string byteCanceledSemFN 
{
get { return  m_byteCanceledSemFN; }
set {m_byteCanceledSemFN  = value ; }
}
public string strDegreeFN 
{
get { return  m_strDegreeFN; }
set {m_strDegreeFN  = value ; }
}
public string strMajorFN 
{
get { return  m_strMajorFN; }
set {m_strMajorFN  = value ; }
}
public string AttMarkFN 
{
get { return  m_AttMarkFN; }
set {m_AttMarkFN  = value ; }
}

public string SAltFN
{
    get { return m_sAltFN; }
    set { m_sAltFN = value; }
}
public string sEQFN
{
    get { return m_sEQFN; }
    set { m_sEQFN = value; }
}    

public string strUserCreateFN 
{
get { return  m_strUserCreateFN; }
set {m_strUserCreateFN  = value ; }
}
public string dateCreateFN 
{
get { return  m_dateCreateFN; }
set {m_dateCreateFN  = value ; }
}
public string strUserSaveFN 
{
get { return  m_strUserSaveFN; }
set {m_strUserSaveFN  = value ; }
}
public string dateLastSaveFN 
{
get { return  m_dateLastSaveFN; }
set {m_dateLastSaveFN  = value ; }
}
public string strMachineFN 
{
get { return  m_strMachineFN; }
set {m_strMachineFN  = value ; }
}
public string strNUserFN 
{
get { return  m_strNUserFN; }
set {m_strNUserFN  = value ; }
}
#endregion
//================End Properties ===================
public Grade_HeaderDAL()
{
try
{
this.TableName = "Reg_Grade_Header";
this.intStudyYearFN = m_TableName + ".intStudyYear";
this.byteSemesterFN = m_TableName + ".byteSemester";
this.byteShiftFN = m_TableName + ".byteShift";
this.strCourseFN = m_TableName + ".strCourse";
this.byteClassFN = m_TableName + ".byteClass";
this.lngStudentNumberFN = m_TableName + ".lngStudentNumber";
this.byteRefCollegeFN = m_TableName + ".byteRefCollege";
//this.curFirstFN = m_TableName + ".curFirst";
//this.curSecondFN = m_TableName + ".curSecond";
//this.curThirdFN = m_TableName + ".curThird";
//this.curAssignmentsFN = m_TableName + ".curAssignments";
//this.curAssignments2FN = m_TableName + ".curAssignments2";
//this.curAssignments3FN = m_TableName + ".curAssignments3";
//this.curParticipateFN = m_TableName + ".curParticipate";
//this.curProjectsFN = m_TableName + ".curProjects";
//this.curProjects2FN = m_TableName + ".curProjects2";
//this.curProjects3FN = m_TableName + ".curProjects3";
//this.curFinalFN = m_TableName + ".curFinal";
this.curUseMarkFN = m_TableName + ".curUseMark";
this.strGradeFN = m_TableName + ".strGrade";
this.bDisActivatedFN = m_TableName + ".bDisActivated";
this.bCanceledFN = m_TableName + ".bCanceled";
this.intCanceledYearFN = m_TableName + ".intCanceledYear";
this.byteCanceledSemFN = m_TableName + ".byteCanceledSem";
this.strDegreeFN = m_TableName + ".strDegree";
this.strMajorFN = m_TableName + ".strMajor";
this.AttMarkFN = m_TableName + ".AttMark";
this.SAltFN = m_TableName + ".sAlt";
this.sEQFN = m_TableName + ".sEQ";
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
public string  GetSQL() 
{
string sSQL  = "";
try
{
sSQL = "SELECT ";
sSQL +=intStudyYearFN;
sSQL += " , " + byteSemesterFN;
sSQL += " , " + byteShiftFN;
sSQL += " , " + strCourseFN;
sSQL += " , " + byteClassFN;
sSQL += " , " + lngStudentNumberFN;
sSQL += " , " + byteRefCollegeFN;
sSQL += " , " + curUseMarkFN;
sSQL += " , " + strGradeFN;
sSQL += " , " + bDisActivatedFN;
sSQL += " , " + bCanceledFN;
sSQL += " , " + intCanceledYearFN;
sSQL += " , " + byteCanceledSemFN;
sSQL += " , " + strDegreeFN;
sSQL += " , " + strMajorFN;
sSQL += " , " + AttMarkFN;
sSQL += " , " + SAltFN;
sSQL += " , " + sEQFN;
sSQL += " , " + strUserCreateFN;
sSQL += " , " + dateCreateFN;
sSQL += " , " + strUserSaveFN;
sSQL += " , " + dateLastSaveFN;
sSQL += " , " + strMachineFN;
sSQL += " , " + strNUserFN;
//sSQL += " , " + curFirstFN;
//sSQL += " , " + curSecondFN;
//sSQL += " , " + curThirdFN;
//sSQL += " , " + curAssignmentsFN;
//sSQL += " , " + curAssignments2FN;
//sSQL += " , " + curAssignments3FN;
//sSQL += " , " + curParticipateFN;
//sSQL += " , " + curProjectsFN;
//sSQL += " , " + curProjects2FN;
//sSQL += " , " + curProjects3FN;
//sSQL += " , " + curFinalFN;
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
    
public string  GetListSQL() 
{
string sSQL  = "";
try
{
sSQL = "SELECT ";
sSQL +=intStudyYearFN;
sSQL += " , " + byteSemesterFN;
sSQL += " , " + byteShiftFN;
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

public string GetListSQL(string sCondition)
{
    string sSQL = "";
    try
    {
        sSQL = "SELECT ";
        sSQL += intStudyYearFN;
        sSQL += " , " + byteSemesterFN;
        sSQL += " , " + byteShiftFN;
        sSQL += "  FROM " + m_TableName;
        sSQL += "  WHERE " + InitializeModule.POSSIBLE_CONDITION ;
        sSQL += sCondition ;
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
string sSQL= "";
try
{
sSQL = "SELECT ";
sSQL +=intStudyYearFN;
sSQL += " , " + byteSemesterFN;
sSQL += " , " + byteShiftFN;
sSQL += " , " + strCourseFN;
sSQL += " , " + byteClassFN;
sSQL += " , " + lngStudentNumberFN;
sSQL += " , " + byteRefCollegeFN;
sSQL += " , " + curUseMarkFN;
sSQL += " , " + strGradeFN;
sSQL += " , " + bDisActivatedFN;
sSQL += " , " + bCanceledFN;
sSQL += " , " + intCanceledYearFN;
sSQL += " , " + byteCanceledSemFN;
sSQL += " , " + strDegreeFN;
sSQL += " , " + strMajorFN;
sSQL += " , " + AttMarkFN;
sSQL += " , " + SAltFN;
sSQL += " , " + sEQFN;
sSQL += " , " + strUserCreateFN;
sSQL += " , " + dateCreateFN;
sSQL += " , " + strUserSaveFN;
sSQL += " , " + dateLastSaveFN;
sSQL += " , " + strMachineFN;
sSQL += " , " + strNUserFN;
//sSQL += " , " + curFirstFN;
//sSQL += " , " + curSecondFN;
//sSQL += " , " + curThirdFN;
//sSQL += " , " + curAssignmentsFN;
//sSQL += " , " + curAssignments2FN;
//sSQL += " , " + curAssignments3FN;
//sSQL += " , " + curParticipateFN;
//sSQL += " , " + curProjectsFN;
//sSQL += " , " + curProjects2FN;
//sSQL += " , " + curProjects3FN;
//sSQL += " , " + curFinalFN;
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
sSQL += LibraryMOD.GetFieldName(intStudyYearFN) + "=@intStudyYear";
sSQL += " , " + LibraryMOD.GetFieldName(byteSemesterFN) + "=@byteSemester";
sSQL += " , " + LibraryMOD.GetFieldName(byteShiftFN) + "=@byteShift";
sSQL += " , " + LibraryMOD.GetFieldName(strCourseFN) + "=@strCourse";
sSQL += " , " + LibraryMOD.GetFieldName(byteClassFN) + "=@byteClass";
sSQL += " , " + LibraryMOD.GetFieldName(lngStudentNumberFN) + "=@lngStudentNumber";
sSQL += " , " + LibraryMOD.GetFieldName(byteRefCollegeFN) + "=@byteRefCollege";
sSQL += " , " + LibraryMOD.GetFieldName(curUseMarkFN) + "=@curUseMark";
sSQL += " , " + LibraryMOD.GetFieldName(strGradeFN) + "=@strGrade";
sSQL += " , " + LibraryMOD.GetFieldName(bDisActivatedFN) + "=@bDisActivated";
sSQL += " , " + LibraryMOD.GetFieldName(bCanceledFN) + "=@bCanceled";
sSQL += " , " + LibraryMOD.GetFieldName(intCanceledYearFN) + "=@intCanceledYear";
sSQL += " , " + LibraryMOD.GetFieldName(byteCanceledSemFN) + "=@byteCanceledSem";
sSQL += " , " + LibraryMOD.GetFieldName(strDegreeFN) + "=@strDegree";
sSQL += " , " + LibraryMOD.GetFieldName(strMajorFN) + "=@strMajor";
sSQL += " , " + LibraryMOD.GetFieldName(AttMarkFN) + "=@AttMark";
sSQL += " , " + LibraryMOD.GetFieldName(SAltFN) + "=@sAlt";
sSQL += " , " + LibraryMOD.GetFieldName(sEQFN) + "=@sEQ";    
sSQL += " , " + LibraryMOD.GetFieldName(strUserCreateFN) + "=@strUserCreate";
sSQL += " , " + LibraryMOD.GetFieldName(dateCreateFN) + "=@dateCreate";
sSQL += " , " + LibraryMOD.GetFieldName(strUserSaveFN) + "=@strUserSave";
sSQL += " , " + LibraryMOD.GetFieldName(dateLastSaveFN) + "=@dateLastSave";
sSQL += " , " + LibraryMOD.GetFieldName(strMachineFN) + "=@strMachine";
sSQL += " , " + LibraryMOD.GetFieldName(strNUserFN) + "=@strNUser";
//sSQL += " , " + LibraryMOD.GetFieldName(curFirstFN) + "=@curFirst";
//sSQL += " , " + LibraryMOD.GetFieldName(curSecondFN) + "=@curSecond";
//sSQL += " , " + LibraryMOD.GetFieldName(curThirdFN) + "=@curThird";
//sSQL += " , " + LibraryMOD.GetFieldName(curAssignmentsFN) + "=@curAssignments";
//sSQL += " , " + LibraryMOD.GetFieldName(curAssignments2FN) + "=@curAssignments2";
//sSQL += " , " + LibraryMOD.GetFieldName(curAssignments3FN) + "=@curAssignments3";
//sSQL += " , " + LibraryMOD.GetFieldName(curParticipateFN) + "=@curParticipate";
//sSQL += " , " + LibraryMOD.GetFieldName(curProjectsFN) + "=@curProjects";
//sSQL += " , " + LibraryMOD.GetFieldName(curProjects2FN) + "=@curProjects2";
//sSQL += " , " + LibraryMOD.GetFieldName(curProjects3FN) + "=@curProjects3";
//sSQL += " , " + LibraryMOD.GetFieldName(curFinalFN) + "=@curFinal";
sSQL += " WHERE ";
sSQL += LibraryMOD.GetFieldName(intStudyYearFN)+"=@intStudyYear";
sSQL +=  " And " + LibraryMOD.GetFieldName(byteSemesterFN)+"=@byteSemester";
sSQL +=  " And " + LibraryMOD.GetFieldName(byteShiftFN)+"=@byteShift";
sSQL +=  " And " + LibraryMOD.GetFieldName(strCourseFN)+"=@strCourse";
sSQL +=  " And " + LibraryMOD.GetFieldName(byteClassFN)+"=@byteClass";
sSQL +=  " And " + LibraryMOD.GetFieldName(lngStudentNumberFN)+"=@lngStudentNumber";
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
public string GetUpdateCommandGradesEdit()
{
    string sSQL = "";
    try
    {

        sSQL = "UPDATE " + TableName;
        sSQL += " SET ";
        //sSQL += LibraryMOD.GetFieldName(intStudyYearFN) + "=@intStudyYear";
        //sSQL += " , " + LibraryMOD.GetFieldName(byteSemesterFN) + "=@byteSemester";
        //sSQL += " , " + LibraryMOD.GetFieldName(byteShiftFN) + "=@byteShift";
        //sSQL += " , " + LibraryMOD.GetFieldName(strCourseFN) + "=@strCourse";
        //sSQL += " , " + LibraryMOD.GetFieldName(byteClassFN) + "=@byteClass";
        //sSQL += " , " + LibraryMOD.GetFieldName(lngStudentNumberFN) + "=@lngStudentNumber";
        //sSQL += " , " + LibraryMOD.GetFieldName(byteRefCollegeFN) + "=@byteRefCollege";
        //sSQL +=  LibraryMOD.GetFieldName(curUseMarkFN) + "=@curUseMark";
        //sSQL += " , ";
        sSQL +=  LibraryMOD.GetFieldName(strGradeFN) + "=@strGrade";
        sSQL += " , " + LibraryMOD.GetFieldName(bDisActivatedFN) + "=@bDisActivated";
        sSQL += " , " + LibraryMOD.GetFieldName(bCanceledFN) + "=@bCanceled";
        //sSQL += " , " + LibraryMOD.GetFieldName(intCanceledYearFN) + "=@intCanceledYear";
        //sSQL += " , " + LibraryMOD.GetFieldName(byteCanceledSemFN) + "=@byteCanceledSem";
        sSQL += " , " + LibraryMOD.GetFieldName(strDegreeFN) + "=@strDegree";
        sSQL += " , " + LibraryMOD.GetFieldName(strMajorFN) + "=@strMajor";
        sSQL += " , " + LibraryMOD.GetFieldName(AttMarkFN) + "=@AttMark";
        //sSQL += " , " + LibraryMOD.GetFieldName(SAltFN) + "=@sAlt";
        //sSQL += " , " + LibraryMOD.GetFieldName(sEQFN) + "=@sEQ";
        sSQL += " , " + LibraryMOD.GetFieldName(strUserCreateFN) + "=@strUserCreate";
        sSQL += " , " + LibraryMOD.GetFieldName(dateCreateFN) + "=@dateCreate";
        sSQL += " , " + LibraryMOD.GetFieldName(strUserSaveFN) + "=@strUserSave";
        sSQL += " , " + LibraryMOD.GetFieldName(dateLastSaveFN) + "=@dateLastSave";
        sSQL += " , " + LibraryMOD.GetFieldName(strMachineFN) + "=@strMachine";
        sSQL += " , " + LibraryMOD.GetFieldName(strNUserFN) + "=@strNUser";
      
        sSQL += " WHERE ";
        sSQL += LibraryMOD.GetFieldName(intStudyYearFN) + "=@intStudyYear";
        sSQL += " And " + LibraryMOD.GetFieldName(byteSemesterFN) + "=@byteSemester";
        sSQL += " And " + LibraryMOD.GetFieldName(byteShiftFN) + "=@byteShift";
        sSQL += " And " + LibraryMOD.GetFieldName(strCourseFN) + "=@strCourse";
        sSQL += " And " + LibraryMOD.GetFieldName(byteClassFN) + "=@byteClass";
        sSQL += " And " + LibraryMOD.GetFieldName(lngStudentNumberFN) + "=@lngStudentNumber";
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
sSQL +=LibraryMOD.GetFieldName(intStudyYearFN);
sSQL += " , " + LibraryMOD.GetFieldName(byteSemesterFN);
sSQL += " , " + LibraryMOD.GetFieldName(byteShiftFN);
sSQL += " , " + LibraryMOD.GetFieldName(strCourseFN);
sSQL += " , " + LibraryMOD.GetFieldName(byteClassFN);
sSQL += " , " + LibraryMOD.GetFieldName(lngStudentNumberFN);
sSQL += " , " + LibraryMOD.GetFieldName(byteRefCollegeFN);
sSQL += " , " + LibraryMOD.GetFieldName(curUseMarkFN);
sSQL += " , " + LibraryMOD.GetFieldName(strGradeFN);
sSQL += " , " + LibraryMOD.GetFieldName(bDisActivatedFN);
sSQL += " , " + LibraryMOD.GetFieldName(bCanceledFN);
sSQL += " , " + LibraryMOD.GetFieldName(intCanceledYearFN);
sSQL += " , " + LibraryMOD.GetFieldName(byteCanceledSemFN);
sSQL += " , " + LibraryMOD.GetFieldName(strDegreeFN);
sSQL += " , " + LibraryMOD.GetFieldName(strMajorFN);
sSQL += " , " + LibraryMOD.GetFieldName(AttMarkFN);
sSQL += " , " + LibraryMOD.GetFieldName(SAltFN);
sSQL += " , " + LibraryMOD.GetFieldName(sEQFN);
sSQL += " , " + LibraryMOD.GetFieldName(strUserCreateFN);
sSQL += " , " + LibraryMOD.GetFieldName(dateCreateFN);
sSQL += " , " + LibraryMOD.GetFieldName(strUserSaveFN);
sSQL += " , " + LibraryMOD.GetFieldName(dateLastSaveFN);
sSQL += " , " + LibraryMOD.GetFieldName(strMachineFN);
sSQL += " , " + LibraryMOD.GetFieldName(strNUserFN);
//sSQL += " , " + LibraryMOD.GetFieldName(curFirstFN);
//sSQL += " , " + LibraryMOD.GetFieldName(curSecondFN);
//sSQL += " , " + LibraryMOD.GetFieldName(curThirdFN);
//sSQL += " , " + LibraryMOD.GetFieldName(curAssignmentsFN);
//sSQL += " , " + LibraryMOD.GetFieldName(curAssignments2FN);
//sSQL += " , " + LibraryMOD.GetFieldName(curAssignments3FN);
//sSQL += " , " + LibraryMOD.GetFieldName(curParticipateFN);
//sSQL += " , " + LibraryMOD.GetFieldName(curProjectsFN);
//sSQL += " , " + LibraryMOD.GetFieldName(curProjects2FN);
//sSQL += " , " + LibraryMOD.GetFieldName(curProjects3FN);
//sSQL += " , " + LibraryMOD.GetFieldName(curFinalFN);
sSQL += ")";
sSQL += " VALUES ";
sSQL += "( ";
sSQL += " @intStudyYear";
sSQL += " ,@byteSemester";
sSQL += " ,@byteShift";
sSQL += " ,@strCourse";
sSQL += " ,@byteClass";
sSQL += " ,@lngStudentNumber";
sSQL += " ,@byteRefCollege";
sSQL += " ,@curUseMark";
sSQL += " ,@strGrade";
sSQL += " ,@bDisActivated";
sSQL += " ,@bCanceled";
sSQL += " ,@intCanceledYear";
sSQL += " ,@byteCanceledSem";
sSQL += " ,@strDegree";
sSQL += " ,@strMajor";
sSQL += " ,@AttMark";
sSQL += " ,@sAlt";
sSQL += " ,@sEQ";
sSQL += " ,@strUserCreate";
sSQL += " ,@dateCreate";
sSQL += " ,@strUserSave";
sSQL += " ,@dateLastSave";
sSQL += " ,@strMachine";
sSQL += " ,@strNUser";
//sSQL += " ,@curFirst";
//sSQL += " ,@curSecond";
//sSQL += " ,@curThird";
//sSQL += " ,@curAssignments";
//sSQL += " ,@curAssignments2";
//sSQL += " ,@curAssignments3";
//sSQL += " ,@curParticipate";
//sSQL += " ,@curProjects";
//sSQL += " ,@curProjects2";
//sSQL += " ,@curProjects3";
//sSQL += " ,@curFinal";
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
public string GetInsertCommandGradesEdit()
{
    string sSQL = "";
    try
    {
        sSQL = "INSERT intO " + TableName;
        sSQL += "( ";
        sSQL += LibraryMOD.GetFieldName(intStudyYearFN);
        sSQL += " , " + LibraryMOD.GetFieldName(byteSemesterFN);
        sSQL += " , " + LibraryMOD.GetFieldName(byteShiftFN);
        sSQL += " , " + LibraryMOD.GetFieldName(strCourseFN);
        sSQL += " , " + LibraryMOD.GetFieldName(byteClassFN);
        sSQL += " , " + LibraryMOD.GetFieldName(lngStudentNumberFN);
        //sSQL += " , " + LibraryMOD.GetFieldName(byteRefCollegeFN);
        sSQL += " , " + LibraryMOD.GetFieldName(curUseMarkFN);
        sSQL += " , " + LibraryMOD.GetFieldName(strGradeFN);
        sSQL += " , " + LibraryMOD.GetFieldName(bDisActivatedFN);
        sSQL += " , " + LibraryMOD.GetFieldName(bCanceledFN);
        //sSQL += " , " + LibraryMOD.GetFieldName(intCanceledYearFN);
        //sSQL += " , " + LibraryMOD.GetFieldName(byteCanceledSemFN);
        sSQL += " , " + LibraryMOD.GetFieldName(strDegreeFN);
        sSQL += " , " + LibraryMOD.GetFieldName(strMajorFN);
        sSQL += " , " + LibraryMOD.GetFieldName(AttMarkFN);
        //sSQL += " , " + LibraryMOD.GetFieldName(SAltFN);
        //sSQL += " , " + LibraryMOD.GetFieldName(sEQFN);
        sSQL += " , " + LibraryMOD.GetFieldName(strUserCreateFN);
        sSQL += " , " + LibraryMOD.GetFieldName(dateCreateFN);
        sSQL += " , " + LibraryMOD.GetFieldName(strUserSaveFN);
        sSQL += " , " + LibraryMOD.GetFieldName(dateLastSaveFN);
        sSQL += " , " + LibraryMOD.GetFieldName(strMachineFN);
        sSQL += " , " + LibraryMOD.GetFieldName(strNUserFN);
        
        sSQL += ")";
        sSQL += " VALUES ";
        sSQL += "( ";
        sSQL += " @intStudyYear";
        sSQL += " ,@byteSemester";
        sSQL += " ,@byteShift";
        sSQL += " ,@strCourse";
        sSQL += " ,@byteClass";
        sSQL += " ,@lngStudentNumber";
        //sSQL += " ,@byteRefCollege";
        sSQL += " ,@curUseMark";
        sSQL += " ,@strGrade";
        sSQL += " ,@bDisActivated";
        sSQL += " ,@bCanceled";
        //sSQL += " ,@intCanceledYear";
        //sSQL += " ,@byteCanceledSem";
        sSQL += " ,@strDegree";
        sSQL += " ,@strMajor";
        sSQL += " ,@AttMark";
        //sSQL += " ,@sAlt";
        //sSQL += " ,@sEQ";
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
public string  GetDeleteCommand()
{
string sSQL= "";
try
{
sSQL = "DELETE FROM "  + TableName;
sSQL += " WHERE ";
sSQL += LibraryMOD.GetFieldName(intStudyYearFN)+"=@intStudyYear";
sSQL +=  " And " +  LibraryMOD.GetFieldName(byteSemesterFN)+"=@byteSemester";
sSQL +=  " And " +  LibraryMOD.GetFieldName(byteShiftFN)+"=@byteShift";
sSQL +=  " And " +  LibraryMOD.GetFieldName(strCourseFN)+"=@strCourse";
sSQL +=  " And " +  LibraryMOD.GetFieldName(byteClassFN)+"=@byteClass";
sSQL +=  " And " +  LibraryMOD.GetFieldName(lngStudentNumberFN)+"=@lngStudentNumber";
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
public List< Grade_Header> GetGrade_Header(InitializeModule.EnumCampus Campus ,string sCondition,bool isDeafaultIncluded)
{
//' returns a list of Classes instances based on the
//' data in the Grade_Header
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
List<Grade_Header> results = new List<Grade_Header>();
try
{
//Default Value
Grade_Header myGrade_Header = new Grade_Header();
if (isDeafaultIncluded)
{
//Change the code here
myGrade_Header.intStudyYear = 0;
myGrade_Header.byteSemester = 0;

results.Add(myGrade_Header);
}
while (reader.Read())
{
myGrade_Header = new Grade_Header();
if (reader[LibraryMOD.GetFieldName(intStudyYearFN)].Equals(DBNull.Value))
{
myGrade_Header.intStudyYear = 0;
}
else
{
myGrade_Header.intStudyYear = int.Parse(reader[LibraryMOD.GetFieldName( intStudyYearFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(byteSemesterFN)].Equals(DBNull.Value))
{
myGrade_Header.byteSemester = 0;
}
else
{
myGrade_Header.byteSemester = int.Parse(reader[LibraryMOD.GetFieldName( byteSemesterFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(byteShiftFN)].Equals(DBNull.Value))
{
myGrade_Header.byteShift = 0;
}
else
{
myGrade_Header.byteShift = int.Parse(reader[LibraryMOD.GetFieldName( byteShiftFN) ].ToString());
}
myGrade_Header.strCourse =reader[LibraryMOD.GetFieldName( strCourseFN) ].ToString();
if (reader[LibraryMOD.GetFieldName(byteClassFN)].Equals(DBNull.Value))
{
myGrade_Header.byteClass = 0;
}
else
{
myGrade_Header.byteClass = int.Parse(reader[LibraryMOD.GetFieldName( byteClassFN) ].ToString());
}
myGrade_Header.lngStudentNumber =reader[LibraryMOD.GetFieldName( lngStudentNumberFN) ].ToString();
if (reader[LibraryMOD.GetFieldName(byteRefCollegeFN)].Equals(DBNull.Value))
{
myGrade_Header.byteRefCollege = 0;
}
else
{
myGrade_Header.byteRefCollege = int.Parse(reader[LibraryMOD.GetFieldName( byteRefCollegeFN) ].ToString());
}
myGrade_Header.strGrade =reader[LibraryMOD.GetFieldName( strGradeFN) ].ToString();
myGrade_Header.bDisActivated =reader[LibraryMOD.GetFieldName( bDisActivatedFN) ].ToString();
myGrade_Header.bCanceled =reader[LibraryMOD.GetFieldName( bCanceledFN) ].ToString();
if (reader[LibraryMOD.GetFieldName(intCanceledYearFN)].Equals(DBNull.Value))
{
myGrade_Header.intCanceledYear = 0;
}
else
{
myGrade_Header.intCanceledYear = int.Parse(reader[LibraryMOD.GetFieldName( intCanceledYearFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(byteCanceledSemFN)].Equals(DBNull.Value))
{
myGrade_Header.byteCanceledSem = 0;
}
else
{
myGrade_Header.byteCanceledSem = int.Parse(reader[LibraryMOD.GetFieldName( byteCanceledSemFN) ].ToString());
}
myGrade_Header.strDegree =reader[LibraryMOD.GetFieldName( strDegreeFN) ].ToString();
myGrade_Header.strMajor =reader[LibraryMOD.GetFieldName( strMajorFN) ].ToString();
if (!reader[LibraryMOD.GetFieldName(AttMarkFN)].Equals(DBNull.Value))
{
    myGrade_Header.AttMark = double.Parse(reader[LibraryMOD.GetFieldName(AttMarkFN)].ToString());
}

    myGrade_Header.SAlt = reader[LibraryMOD.GetFieldName(SAltFN)].ToString();
    myGrade_Header.sEQ= reader[LibraryMOD.GetFieldName(sEQFN)].ToString();

myGrade_Header.strUserCreate =reader[LibraryMOD.GetFieldName( strUserCreateFN) ].ToString();
if (!reader[LibraryMOD.GetFieldName(dateCreateFN)].Equals(DBNull.Value))
{
myGrade_Header.dateCreate = DateTime.Parse(reader[LibraryMOD.GetFieldName( dateCreateFN) ].ToString());
}
myGrade_Header.strUserSave =reader[LibraryMOD.GetFieldName( strUserSaveFN) ].ToString();
if (!reader[LibraryMOD.GetFieldName(dateLastSaveFN)].Equals(DBNull.Value))
{
myGrade_Header.dateLastSave = DateTime.Parse(reader[LibraryMOD.GetFieldName( dateLastSaveFN) ].ToString());
}
myGrade_Header.strMachine =reader[LibraryMOD.GetFieldName( strMachineFN) ].ToString();
myGrade_Header.strNUser =reader[LibraryMOD.GetFieldName( strNUserFN) ].ToString();
 results.Add(myGrade_Header);
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
public List< Grade_Header > GetList(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
{
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
string sSQL = GetListSQL(sCondition);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
SqlCommand Cmd = new SqlCommand(sSQL, Conn);
Conn.Open();
SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
List<Grade_Header> results = new List<Grade_Header>();
try
{
//Default Value
Grade_Header myGrade_Header= new Grade_Header();
if (isDeafaultIncluded) 
 {
//Change the code here
 myGrade_Header.intStudyYear = -1;
 myGrade_Header.byteSemester = -1 ;
results.Add(myGrade_Header);
 }
while (reader.Read())
{
myGrade_Header = new Grade_Header();
if (reader[LibraryMOD.GetFieldName(intStudyYearFN)].Equals(DBNull.Value))
{
myGrade_Header.intStudyYear = 0;
}
else
{
myGrade_Header.intStudyYear = int.Parse(reader[LibraryMOD.GetFieldName( intStudyYearFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(byteSemesterFN)].Equals(DBNull.Value))
{
myGrade_Header.byteSemester = 0;
}
else
{
myGrade_Header.byteSemester = int.Parse(reader[LibraryMOD.GetFieldName( byteSemesterFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(byteShiftFN)].Equals(DBNull.Value))
{
myGrade_Header.byteShift = 0;
}
else
{
myGrade_Header.byteShift = int.Parse(reader[LibraryMOD.GetFieldName( byteShiftFN) ].ToString());
}
 results.Add(myGrade_Header);
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
public int UpdateTotalMarkAndGrade(int StudyYear, byte Semester, byte Shift, string Course, byte bClass, string StudentNumber,
decimal Mark, string Grade,int DataStatus, InitializeModule.EnumCampus Campus, string sUser, string sNetUser, string sPCName)
{
    int iEffected = 0;
    Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);

    SqlConnection myConnection = new SqlConnection(myConnection_String.Conn_string);
    SqlCommand myCommand = new SqlCommand();
    try
    {

        myConnection.Open();

        string sSQL = null;
        string sCon = null;
        string sExec = null;

        if (DataStatus == (int)ECTGlobalDll.InitializeModule.enumModes.EditMode)
        {
            //'//Update Header 
            sSQL = "Update Reg_Grade_Header Set";
            sSQL = sSQL + " curUseMark=@Mark,";
            sSQL = sSQL + " strGrade=@Grade,";
            sSQL = sSQL + " strUserSave=@User,";
            sSQL = sSQL + " dateLastSave=@Date,";
            sSQL = sSQL + " strNUser=@NetUser,";
            sSQL = sSQL + " strMachine=@PCName";
            sCon = " Where ";
            sCon = sCon + " intStudyYear=@StudyYear";
            sCon = sCon + " And byteSemester=@Semester";
            sCon = sCon + " And strCourse=@Course";
            sCon = sCon + " And byteClass=@Class";
            sCon = sCon + " And byteShift=@Shift";
            sCon = sCon + " And lngStudentNumber=@StudentNumber";

            sExec = sSQL + sCon;

            myCommand = new SqlCommand(sExec, myConnection);

            myCommand.Parameters.Add(new SqlParameter("@StudyYear", StudyYear));
            myCommand.Parameters.Add(new SqlParameter("@Semester", Semester));
            myCommand.Parameters.Add(new SqlParameter("@Shift", Shift));
            myCommand.Parameters.Add(new SqlParameter("@Course", Course));
            myCommand.Parameters.Add(new SqlParameter("@Class", bClass));
            myCommand.Parameters.Add(new SqlParameter("@StudentNumber", StudentNumber));
            myCommand.Parameters.Add(new SqlParameter("@Mark", Mark));
            myCommand.Parameters.Add(new SqlParameter("@Grade", Grade));
            myCommand.Parameters.Add(new SqlParameter("@User", sUser));
            myCommand.Parameters.Add(new SqlParameter("@Date", DateTime.Today.Date));
            myCommand.Parameters.Add(new SqlParameter("@NetUser", sNetUser));
            myCommand.Parameters.Add(new SqlParameter("@PCName", sPCName));

            iEffected = myCommand.ExecuteNonQuery();
           
        }
       
      
    }
    catch (Exception ex)
    {
        LibraryMOD.ShowErrorMessage(ex);
    }
    finally
    {
        myConnection.Close();
        myConnection.Dispose();
    }
    return iEffected;
} 

public int UpdateGrade_Header(InitializeModule.EnumCampus Campus, int iMode, int intStudyYear, int byteSemester, int byteShift, string strCourse, int byteClass, string lngStudentNumber, int byteRefCollege, double curUseMark, string strGrade, string bDisActivated, string bCanceled, int intCanceledYear, int byteCanceledSem, string strDegree, string strMajor, double AttMark, string sAlt, string sEQ, string strUserCreate, DateTime dateCreate, string strUserSave, DateTime dateLastSave, string strMachine, string strNUser)
{
    //, double curFirst, double curSecond, double curThird, double curAssignments, double curAssignments2, double curAssignments3, double curParticipate, double curProjects, double curProjects2, double curProjects3, double curFinal

int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
Conn.Open();
string sql = "";
Grade_Header theGrade_Header = new Grade_Header();
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
    Cmd.Parameters.Add(new SqlParameter("@intStudyYear",intStudyYear));
    Cmd.Parameters.Add(new SqlParameter("@byteSemester",byteSemester));
    Cmd.Parameters.Add(new SqlParameter("@byteShift",byteShift));
    Cmd.Parameters.Add(new SqlParameter("@strCourse",strCourse));
    Cmd.Parameters.Add(new SqlParameter("@byteClass",byteClass));
    Cmd.Parameters.Add(new SqlParameter("@lngStudentNumber",lngStudentNumber));
    if (byteRefCollege > 0)
    {
        Cmd.Parameters.Add(new SqlParameter("@byteRefCollege", byteRefCollege));
    }
    else 
    {
        Cmd.Parameters.Add(new SqlParameter("@byteRefCollege", -1));
    }
    Cmd.Parameters.Add(new SqlParameter("@curUseMark",curUseMark));
    Cmd.Parameters.Add(new SqlParameter("@strGrade",strGrade));
    Cmd.Parameters.Add(new SqlParameter("@bDisActivated",bDisActivated));
    Cmd.Parameters.Add(new SqlParameter("@bCanceled",bCanceled));

    if (intCanceledYear > 0)
    {
        Cmd.Parameters.Add(new SqlParameter("@intCanceledYear", intCanceledYear));
        Cmd.Parameters.Add(new SqlParameter("@byteCanceledSem", byteCanceledSem));
    }
    else
    {
        Cmd.Parameters.Add(new SqlParameter("@intCanceledYear", DBNull.Value ));
        Cmd.Parameters.Add(new SqlParameter("@byteCanceledSem", DBNull.Value));
    }

    Cmd.Parameters.Add(new SqlParameter("@strDegree",strDegree));
    Cmd.Parameters.Add(new SqlParameter("@strMajor",strMajor));
    Cmd.Parameters.Add(new SqlParameter("@AttMark",AttMark));
    if (sAlt != "")
    {
        Cmd.Parameters.Add(new SqlParameter("@sAlt", sAlt));
    }
    else
    {
        Cmd.Parameters.Add(new SqlParameter("@sAlt", DBNull.Value));
    }
    if (sEQ != "")
    {
        Cmd.Parameters.Add(new SqlParameter("@sEQ", sEQ));
    }
    else
    {
        Cmd.Parameters.Add(new SqlParameter("@sEQ", DBNull.Value));
    }
    Cmd.Parameters.Add(new SqlParameter("@strUserCreate",strUserCreate));
    Cmd.Parameters.Add(new SqlParameter("@dateCreate",dateCreate));
    Cmd.Parameters.Add(new SqlParameter("@strUserSave",strUserSave));
    Cmd.Parameters.Add(new SqlParameter("@dateLastSave",dateLastSave));
    Cmd.Parameters.Add(new SqlParameter("@strMachine",strMachine));
    Cmd.Parameters.Add(new SqlParameter("@strNUser",strNUser));

    //Cmd.Parameters.Add(new SqlParameter("@curFirst", curFirst));
    //Cmd.Parameters.Add(new SqlParameter("@curSecond", curSecond));
    //Cmd.Parameters.Add(new SqlParameter("@curThird", curThird));
    //Cmd.Parameters.Add(new SqlParameter("@curAssignments", curAssignments));
    //Cmd.Parameters.Add(new SqlParameter("@curAssignments2", curAssignments2));
    //Cmd.Parameters.Add(new SqlParameter("@curAssignments3", curAssignments3));
    //Cmd.Parameters.Add(new SqlParameter("@curParticipate", curParticipate));
    //Cmd.Parameters.Add(new SqlParameter("@curProjects", curProjects));
    //Cmd.Parameters.Add(new SqlParameter("@curProjects2", curProjects2));
    //Cmd.Parameters.Add(new SqlParameter("@curProjects3", curProjects3));
    //Cmd.Parameters.Add(new SqlParameter("@curFinal", curFinal));
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

public int UpdateGrade_Header_ForGradesEdit(InitializeModule.EnumCampus Campus, int iMode, int intStudyYear, int byteSemester, int byteShift, string strCourse, int byteClass, string lngStudentNumber, int byteRefCollege, double curUseMark, string strGrade, string bDisActivated, string bCanceled, int intCanceledYear, int byteCanceledSem, string strDegree, string strMajor, double AttMark, string sAlt, string sEQ, string strUserCreate, DateTime dateCreate, string strUserSave, DateTime dateLastSave, string strMachine, string strNUser)
{
    //, double curFirst, double curSecond, double curThird, double curAssignments, double curAssignments2, double curAssignments3, double curParticipate, double curProjects, double curProjects2, double curProjects3, double curFinal

    int iEffected = 0;
    Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
    SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
    try
    {
        Conn.Open();
        string sql = "";
        Grade_Header theGrade_Header = new Grade_Header();
        //'Updates the  table
        switch (iMode)
        {
            case (int)ECTGlobalDll.InitializeModule.enumModes.EditMode:
                sql = GetUpdateCommandGradesEdit();
                break;
            case (int)ECTGlobalDll.InitializeModule.enumModes.NewMode:
                sql = GetInsertCommandGradesEdit();
                break;
        }
        SqlCommand Cmd = new SqlCommand(sql, Conn);
        Cmd.Parameters.Add(new SqlParameter("@intStudyYear", intStudyYear));
        Cmd.Parameters.Add(new SqlParameter("@byteSemester", byteSemester));
        Cmd.Parameters.Add(new SqlParameter("@byteShift", byteShift));
        Cmd.Parameters.Add(new SqlParameter("@strCourse", strCourse));
        Cmd.Parameters.Add(new SqlParameter("@byteClass", byteClass));
        Cmd.Parameters.Add(new SqlParameter("@lngStudentNumber", lngStudentNumber));
     
        Cmd.Parameters.Add(new SqlParameter("@curUseMark", curUseMark));
        Cmd.Parameters.Add(new SqlParameter("@strGrade", strGrade));
        Cmd.Parameters.Add(new SqlParameter("@bDisActivated", bDisActivated));
        Cmd.Parameters.Add(new SqlParameter("@bCanceled", bCanceled));

       

        Cmd.Parameters.Add(new SqlParameter("@strDegree", strDegree));
        Cmd.Parameters.Add(new SqlParameter("@strMajor", strMajor));
        Cmd.Parameters.Add(new SqlParameter("@AttMark", AttMark));
       
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

public int DeleteGrade_Header(InitializeModule.EnumCampus Campus,int intStudyYear,int byteSemester,int byteShift,string strCourse,int byteClass,string lngStudentNumber)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
string sSQL = GetDeleteCommand();
//sSQL += sCondition;
SqlCommand Cmd = new SqlCommand(sSQL, Conn);
Cmd.Parameters.Add(new SqlParameter("@intStudyYear", intStudyYear ));
Cmd.Parameters.Add(new SqlParameter("@byteSemester", byteSemester ));
Cmd.Parameters.Add(new SqlParameter("@byteShift", byteShift ));
Cmd.Parameters.Add(new SqlParameter("@strCourse", strCourse ));
Cmd.Parameters.Add(new SqlParameter("@byteClass", byteClass ));
Cmd.Parameters.Add(new SqlParameter("@lngStudentNumber", lngStudentNumber ));
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
DataTable dt = new DataTable("Grade_Header");
DataView dv = new DataView();
List<Grade_Header> myGrade_Headers = new List<Grade_Header>();
try
{
myGrade_Headers = GetGrade_Header(InitializeModule.EnumCampus.ECTNew,sCondition,false);
DataColumn col1= new DataColumn("intStudyYear", Type.GetType("smallint"));
dt.Columns.Add(col1 );
DataColumn col2= new DataColumn("byteSemester", Type.GetType("smallint"));
dt.Columns.Add(col2 );
DataColumn col3= new DataColumn("byteShift", Type.GetType("smallint"));
dt.Columns.Add(col3 );
dt.Constraints.Add(new UniqueConstraint(col1));
dt.Constraints.Add(new UniqueConstraint(col2));
dt.Constraints.Add(new UniqueConstraint(col3));
//dt.Constraints.Add(new UniqueConstraint(col4));
//dt.Constraints.Add(new UniqueConstraint(col5));
//dt.Constraints.Add(new UniqueConstraint(col6));

DataRow dr;
for (int i = 0; i < myGrade_Headers.Count; i++)
{
dr = dt.NewRow();
  dr[1] = myGrade_Headers[i].intStudyYear;
  dr[2] = myGrade_Headers[i].byteSemester;
  dr[3] = myGrade_Headers[i].byteShift;
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
myGrade_Headers.Clear();
}
 return dv;
}
public string IsGradeExists(InitializeModule.EnumCampus Campus,string sCondition)
{
    string  sCourse = "";

    Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
    SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
    try
    {
        Conn.Open();

        string sql = "SELECT strCourse";
        sql += " FROM " + TableName  ;
        sql += " WHERE " + InitializeModule.POSSIBLE_CONDITION;
        sql += sCondition;

        SqlCommand Cmd = new SqlCommand(sql, Conn);

        SqlDataReader dr = Cmd.ExecuteReader();

        if (dr.HasRows)
        {
            dr.Read();
            sCourse = dr["strCourse"].ToString();
        }

        Conn.Close();
        dr.Close();

    }
    catch (Exception ex)
    {
        LibraryMOD.ShowErrorMessage(ex);
    }

    return sCourse;
}
public int IsGradeShiftExists(InitializeModule.EnumCampus Campus, string sCondition)
{
    int iShift = 0;

    Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
    SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
    try
    {
        Conn.Open();

        string sql = "SELECT " + byteShiftFN  ;
        sql += " FROM " + TableName;
        sql += " WHERE " + InitializeModule.POSSIBLE_CONDITION;
        sql += sCondition;

        SqlCommand Cmd = new SqlCommand(sql, Conn);

        SqlDataReader dr = Cmd.ExecuteReader();

        if (dr.HasRows)
        {
            dr.Read();
            iShift = dr.GetInt16 (0);
        }

        Conn.Close();
        dr.Close();

    }
    catch (Exception ex)
    {
        LibraryMOD.ShowErrorMessage(ex);
    }

    return iShift;
}

public string GetGrade(int iCampus, string sStudentID, int iyear, int isem, string sCourse, int iSession, int iClass)
{
    string sSQL;
    string sGrade= "";

    Connection_StringCLS MyConnection_string = new Connection_StringCLS((InitializeModule.EnumCampus)iCampus);
    SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
    try
    {
        sSQL = "SELECT ";
        sSQL += strGradeFN  ;
        sSQL += "  FROM " + m_TableName;
        sSQL += "  WHERE " + lngStudentNumberFN + "='" + sStudentID + "'";
        sSQL += "  AND " + strCourseFN + "='" + sCourse + "'";
        sSQL += "  AND " + intStudyYearFN + "=" + iyear;
        sSQL += "  AND " + byteSemesterFN + "=" + isem;
        sSQL += "  AND " + byteShiftFN + "=" + iSession;
        sSQL += "  AND " + byteClassFN + "=" + iClass;
      
        Conn.Open();

        System.Data.SqlClient.SqlCommand CommandSQL = new System.Data.SqlClient.SqlCommand(sSQL, Conn);
        System.Data.SqlClient.SqlDataReader datReader;
        datReader = CommandSQL.ExecuteReader(CommandBehavior.CloseConnection);

        if (datReader.Read())
        {
            sGrade = datReader[0].ToString();
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

    return sGrade;
}

public decimal GetTotalMarks(int iCampus, string sStudentID, int iyear, int isem, string sCourse, int iSession, int iClass)
{
    string sSQL;
    decimal TotalMarks = 0;

    Connection_StringCLS MyConnection_string = new Connection_StringCLS((InitializeModule.EnumCampus)iCampus);
    SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
    try
    {

        sSQL = "SELECT ";
        sSQL += curUseMarkFN ;
        sSQL += "  FROM " + m_TableName;
        sSQL += "  WHERE " + lngStudentNumberFN + "='" + sStudentID + "'";
        sSQL += "  AND " + strCourseFN + "='" + sCourse + "'";
        sSQL += "  AND " + intStudyYearFN + "=" + iyear;
        sSQL += "  AND " + byteSemesterFN + "=" + isem;
        sSQL += "  AND " + byteShiftFN + "=" + iSession;
        sSQL += "  AND " + byteClassFN + "=" + iClass;
      

        Conn.Open();

        System.Data.SqlClient.SqlCommand CommandSQL = new System.Data.SqlClient.SqlCommand(sSQL, Conn);
        System.Data.SqlClient.SqlDataReader datReader;
        datReader = CommandSQL.ExecuteReader(CommandBehavior.CloseConnection);


        if (datReader.Read())
        {
            TotalMarks = Convert.ToDecimal ("0" + datReader[0].ToString());
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

    return TotalMarks;
}


//'-------Populate  -----------------------------
public DataTable Populate(SqlConnection con) 
{
string sSQL =""; 
DataTable table = new DataTable();
try
{
sSQL = "SELECT";
sSQL += intStudyYearFN;
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
public class Grade_HeaderCls : Grade_HeaderDAL
{
#region "Decleration"
private int m_lngCurRow=0;
public SqlDataAdapter daGrade_Header;
private DataSet m_dsGrade_Header;
public DataRow Grade_HeaderDataRow ;
#endregion
#region "Puplic Properties"
public DataSet dsGrade_Header
{
get { return m_dsGrade_Header ; }
set { m_dsGrade_Header = value ; }
}
//-----------------------------------------------------
public int lngCurRow 
{
get { return  m_lngCurRow ; }
set {m_lngCurRow = value ; }
}
#endregion
public Grade_HeaderCls()
{
try
{
dsGrade_Header= new DataSet();

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
public virtual SqlDataAdapter GetGrade_HeaderDataAdapter(string sCondition ,SqlConnection con ) 
{
string sSQL =""; 
try
{
sSQL = GetSQL();
sSQL += " " + sCondition;
//-----------------------------------------
daGrade_Header = new SqlDataAdapter(sSQL, con);
// Create command builder. This line automatically generates the update commands for you, so you don't
// have to provide or create your own.
SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daGrade_Header);
//Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
// key + unique key information to be retrieved unless AddWithKey is specified.
daGrade_Header.MissingSchemaAction = MissingSchemaAction.AddWithKey;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daGrade_Header;
}
public virtual SqlDataAdapter GetGrade_HeaderDataAdapter(SqlConnection con)  
{
try
{
daGrade_Header = new SqlDataAdapter();
//''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
//'' key + unique key information to be retrieved unless AddWithKey is specified.
daGrade_Header.MissingSchemaAction = MissingSchemaAction.AddWithKey;
//-----------------------------------------
SqlParameter Parmeter = default(SqlParameter); 
//[SELECT COMMAND]
SqlCommand cmdGrade_Header;
cmdGrade_Header = new SqlCommand(GetSelectCommand(), con);
//'cmdRolePermission.Parameters.Add("@intStudyYear", SqlDbType.Int, 4, "intStudyYear" );
//'cmdRolePermission.Parameters.Add("@byteSemester", SqlDbType.Int, 4, "byteSemester" );
//'cmdRolePermission.Parameters.Add("@byteShift", SqlDbType.Int, 4, "byteShift" );
//'cmdRolePermission.Parameters.Add("@strCourse", SqlDbType.Int, 4, "strCourse" );
//'cmdRolePermission.Parameters.Add("@byteClass", SqlDbType.Int, 4, "byteClass" );
//'cmdRolePermission.Parameters.Add("@lngStudentNumber", SqlDbType.Int, 4, "lngStudentNumber" );
daGrade_Header.SelectCommand = cmdGrade_Header;
//'Add Handlers
//'RowUpdating,RowUpdated
AddDAEventHandler();
//'[UPDATE COMMAND].
cmdGrade_Header = new SqlCommand(GetUpdateCommand(), con);
//'Delete PK Parameteres from here. b/c its declared below
cmdGrade_Header.Parameters.Add("@byteRefCollege", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteRefCollegeFN));
cmdGrade_Header.Parameters.Add("@curUseMark", SqlDbType.Money,21, LibraryMOD.GetFieldName(curUseMarkFN));
cmdGrade_Header.Parameters.Add("@strGrade", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strGradeFN));
cmdGrade_Header.Parameters.Add("@bDisActivated", SqlDbType.Bit,1, LibraryMOD.GetFieldName(bDisActivatedFN));
cmdGrade_Header.Parameters.Add("@bCanceled", SqlDbType.Bit,1, LibraryMOD.GetFieldName(bCanceledFN));
cmdGrade_Header.Parameters.Add("@intCanceledYear", SqlDbType.Int,2, LibraryMOD.GetFieldName(intCanceledYearFN));
cmdGrade_Header.Parameters.Add("@byteCanceledSem", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteCanceledSemFN));
cmdGrade_Header.Parameters.Add("@strDegree", SqlDbType.NVarChar,12, LibraryMOD.GetFieldName(strDegreeFN));
cmdGrade_Header.Parameters.Add("@strMajor", SqlDbType.NVarChar,12, LibraryMOD.GetFieldName(strMajorFN));
cmdGrade_Header.Parameters.Add("@AttMark", SqlDbType.Money,21, LibraryMOD.GetFieldName(AttMarkFN));
cmdGrade_Header.Parameters.Add("@sAlt", SqlDbType.NVarChar,12, LibraryMOD.GetFieldName(SAltFN));
cmdGrade_Header.Parameters.Add("@sEQ", SqlDbType.NVarChar, 12, LibraryMOD.GetFieldName(sEQFN));
    cmdGrade_Header.Parameters.Add("@strUserCreate", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strUserCreateFN));
cmdGrade_Header.Parameters.Add("@dateCreate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateCreateFN));
cmdGrade_Header.Parameters.Add("@strUserSave", SqlDbType.Char,10, LibraryMOD.GetFieldName(strUserSaveFN));
cmdGrade_Header.Parameters.Add("@dateLastSave", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateLastSaveFN));
cmdGrade_Header.Parameters.Add("@strMachine", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strMachineFN));
cmdGrade_Header.Parameters.Add("@strNUser", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strNUserFN));


Parmeter = cmdGrade_Header.Parameters.Add("@intStudyYear", SqlDbType.Int, 4, LibraryMOD.GetFieldName(intStudyYearFN));
Parmeter = cmdGrade_Header.Parameters.Add("@byteSemester", SqlDbType.Int, 4, LibraryMOD.GetFieldName(byteSemesterFN));
Parmeter = cmdGrade_Header.Parameters.Add("@byteShift", SqlDbType.Int, 4, LibraryMOD.GetFieldName(byteShiftFN));
Parmeter = cmdGrade_Header.Parameters.Add("@strCourse", SqlDbType.Int, 4, LibraryMOD.GetFieldName(strCourseFN));
Parmeter = cmdGrade_Header.Parameters.Add("@byteClass", SqlDbType.Int, 4, LibraryMOD.GetFieldName(byteClassFN));
Parmeter = cmdGrade_Header.Parameters.Add("@lngStudentNumber", SqlDbType.Int, 4, LibraryMOD.GetFieldName(lngStudentNumberFN));
Parmeter.SourceVersion = DataRowVersion.Original;
//'Its should be none for batch updating
//'UpdateCommand, InsertCommand, and DeleteCommand 
//'should be set to None or OutputParameters
daGrade_Header.UpdateCommand = cmdGrade_Header;
daGrade_Header.UpdateCommand.UpdatedRowSource  = UpdateRowSource.None ;
//'-------------------------------------------------------------------------
//'/INSERT COMMAND
 cmdGrade_Header = new SqlCommand(GetInsertCommand(), con);
cmdGrade_Header.Parameters.Add("@intStudyYear", SqlDbType.Int,2, LibraryMOD.GetFieldName(intStudyYearFN));
cmdGrade_Header.Parameters.Add("@byteSemester", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteSemesterFN));
cmdGrade_Header.Parameters.Add("@byteShift", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteShiftFN));
cmdGrade_Header.Parameters.Add("@strCourse", SqlDbType.NVarChar,24, LibraryMOD.GetFieldName(strCourseFN));
cmdGrade_Header.Parameters.Add("@byteClass", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteClassFN));
cmdGrade_Header.Parameters.Add("@lngStudentNumber", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(lngStudentNumberFN));
cmdGrade_Header.Parameters.Add("@byteRefCollege", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteRefCollegeFN));
cmdGrade_Header.Parameters.Add("@curUseMark", SqlDbType.Money,21, LibraryMOD.GetFieldName(curUseMarkFN));
cmdGrade_Header.Parameters.Add("@strGrade", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strGradeFN));
cmdGrade_Header.Parameters.Add("@bDisActivated", SqlDbType.Bit,1, LibraryMOD.GetFieldName(bDisActivatedFN));
cmdGrade_Header.Parameters.Add("@bCanceled", SqlDbType.Bit,1, LibraryMOD.GetFieldName(bCanceledFN));
cmdGrade_Header.Parameters.Add("@intCanceledYear", SqlDbType.Int,2, LibraryMOD.GetFieldName(intCanceledYearFN));
cmdGrade_Header.Parameters.Add("@byteCanceledSem", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteCanceledSemFN));
cmdGrade_Header.Parameters.Add("@strDegree", SqlDbType.NVarChar,12, LibraryMOD.GetFieldName(strDegreeFN));
cmdGrade_Header.Parameters.Add("@strMajor", SqlDbType.NVarChar,12, LibraryMOD.GetFieldName(strMajorFN));
cmdGrade_Header.Parameters.Add("@AttMark", SqlDbType.Money,21, LibraryMOD.GetFieldName(AttMarkFN));
cmdGrade_Header.Parameters.Add("@sAlt", SqlDbType.NVarChar, 12, LibraryMOD.GetFieldName(SAltFN));
cmdGrade_Header.Parameters.Add("@sEQ", SqlDbType.NVarChar, 12, LibraryMOD.GetFieldName(sEQFN ));
cmdGrade_Header.Parameters.Add("@strUserCreate", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strUserCreateFN));
cmdGrade_Header.Parameters.Add("@dateCreate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateCreateFN));
cmdGrade_Header.Parameters.Add("@strUserSave", SqlDbType.Char,10, LibraryMOD.GetFieldName(strUserSaveFN));
cmdGrade_Header.Parameters.Add("@dateLastSave", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateLastSaveFN));
cmdGrade_Header.Parameters.Add("@strMachine", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strMachineFN));
cmdGrade_Header.Parameters.Add("@strNUser", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strNUserFN));
Parmeter.SourceVersion = DataRowVersion.Current;
daGrade_Header.InsertCommand =cmdGrade_Header;
daGrade_Header.InsertCommand.UpdatedRowSource  = UpdateRowSource.None;
//'------------------------
//'/DELETE COMMAND
 cmdGrade_Header = new SqlCommand(GetDeleteCommand(), con);
Parmeter = cmdGrade_Header.Parameters.Add("@intStudyYear", SqlDbType.Int, 4, LibraryMOD.GetFieldName(intStudyYearFN));
Parmeter = cmdGrade_Header.Parameters.Add("@byteSemester", SqlDbType.Int, 4, LibraryMOD.GetFieldName(byteSemesterFN));
Parmeter = cmdGrade_Header.Parameters.Add("@byteShift", SqlDbType.Int, 4, LibraryMOD.GetFieldName(byteShiftFN));
Parmeter = cmdGrade_Header.Parameters.Add("@strCourse", SqlDbType.Int, 4, LibraryMOD.GetFieldName(strCourseFN));
Parmeter = cmdGrade_Header.Parameters.Add("@byteClass", SqlDbType.Int, 4, LibraryMOD.GetFieldName(byteClassFN));
Parmeter = cmdGrade_Header.Parameters.Add("@lngStudentNumber", SqlDbType.Int, 4, LibraryMOD.GetFieldName(lngStudentNumberFN));
Parmeter.SourceVersion = DataRowVersion.Original;
daGrade_Header.DeleteCommand =cmdGrade_Header;
daGrade_Header.DeleteCommand.UpdatedRowSource  = UpdateRowSource.None;
//'Batch Size
//'Set the batch size.
daGrade_Header.UpdateBatchSize = ECTGlobalDll.InitializeModule.BATCH_SIZE;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daGrade_Header;
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
dr = dsGrade_Header.Tables[TableName].NewRow();
dr[LibraryMOD.GetFieldName(intStudyYearFN)]=intStudyYear;
dr[LibraryMOD.GetFieldName(byteSemesterFN)]=byteSemester;
dr[LibraryMOD.GetFieldName(byteShiftFN)]=byteShift;
dr[LibraryMOD.GetFieldName(strCourseFN)]=strCourse;
dr[LibraryMOD.GetFieldName(byteClassFN)]=byteClass;
dr[LibraryMOD.GetFieldName(lngStudentNumberFN)]=lngStudentNumber;
dr[LibraryMOD.GetFieldName(byteRefCollegeFN)]=byteRefCollege;

dr[LibraryMOD.GetFieldName(curUseMarkFN)]=curUseMark;
dr[LibraryMOD.GetFieldName(strGradeFN)]=strGrade;
dr[LibraryMOD.GetFieldName(bDisActivatedFN)]=bDisActivated;
dr[LibraryMOD.GetFieldName(bCanceledFN)]=bCanceled;
dr[LibraryMOD.GetFieldName(intCanceledYearFN)]=intCanceledYear;
dr[LibraryMOD.GetFieldName(byteCanceledSemFN)]=byteCanceledSem;
dr[LibraryMOD.GetFieldName(strDegreeFN)]=strDegree;
dr[LibraryMOD.GetFieldName(strMajorFN)]=strMajor;
dr[LibraryMOD.GetFieldName(AttMarkFN)]=AttMark;
dr[LibraryMOD.GetFieldName(SAltFN)] = SAlt;
dr[LibraryMOD.GetFieldName(strUserCreateFN)]=strUserCreate;
dr[LibraryMOD.GetFieldName(dateCreateFN)]=dateCreate;
dr[LibraryMOD.GetFieldName(strUserSaveFN)]=strUserSave;
dr[LibraryMOD.GetFieldName(dateLastSaveFN)]=dateLastSave;
dr[LibraryMOD.GetFieldName(strMachineFN)]=strMachine;
dr[LibraryMOD.GetFieldName(strNUserFN)]=strNUser;
dsGrade_Header.Tables[TableName].Rows.Add(dr);
break;
case (int)ECTGlobalDll.InitializeModule.enumModes.EditMode:
 DataRow[] drAry = null;
drAry = dsGrade_Header.Tables[TableName].Select(LibraryMOD.GetFieldName(intStudyYearFN)  + "=" + intStudyYear  + " AND " + LibraryMOD.GetFieldName(byteSemesterFN) + "=" + byteSemester  + " AND " + LibraryMOD.GetFieldName(byteShiftFN) + "=" + byteShift  + " AND " + LibraryMOD.GetFieldName(strCourseFN) + "=" + strCourse  + " AND " + LibraryMOD.GetFieldName(byteClassFN) + "=" + byteClass  + " AND " + LibraryMOD.GetFieldName(lngStudentNumberFN) + "=" + lngStudentNumber);
//'its return array of rows and we can access the first by index 0
drAry[0][LibraryMOD.GetFieldName(intStudyYearFN)]=intStudyYear;
drAry[0][LibraryMOD.GetFieldName(byteSemesterFN)]=byteSemester;
drAry[0][LibraryMOD.GetFieldName(byteShiftFN)]=byteShift;
drAry[0][LibraryMOD.GetFieldName(strCourseFN)]=strCourse;
drAry[0][LibraryMOD.GetFieldName(byteClassFN)]=byteClass;
drAry[0][LibraryMOD.GetFieldName(lngStudentNumberFN)]=lngStudentNumber;
drAry[0][LibraryMOD.GetFieldName(byteRefCollegeFN)]=byteRefCollege;

drAry[0][LibraryMOD.GetFieldName(curUseMarkFN)]=curUseMark;
drAry[0][LibraryMOD.GetFieldName(strGradeFN)]=strGrade;
drAry[0][LibraryMOD.GetFieldName(bDisActivatedFN)]=bDisActivated;
drAry[0][LibraryMOD.GetFieldName(bCanceledFN)]=bCanceled;
drAry[0][LibraryMOD.GetFieldName(intCanceledYearFN)]=intCanceledYear;
drAry[0][LibraryMOD.GetFieldName(byteCanceledSemFN)]=byteCanceledSem;
drAry[0][LibraryMOD.GetFieldName(strDegreeFN)]=strDegree;
drAry[0][LibraryMOD.GetFieldName(strMajorFN)]=strMajor;
drAry[0][LibraryMOD.GetFieldName(AttMarkFN)]=AttMark;
drAry[0][LibraryMOD.GetFieldName(SAltFN)] = SAlt;
drAry[0][LibraryMOD.GetFieldName(strUserCreateFN)]=strUserCreate;
drAry[0][LibraryMOD.GetFieldName(dateCreateFN)]=dateCreate;
drAry[0][LibraryMOD.GetFieldName(strUserSaveFN)]=strUserSave;
drAry[0][LibraryMOD.GetFieldName(dateLastSaveFN)]=dateLastSave;
drAry[0][LibraryMOD.GetFieldName(strMachineFN)]=strMachine;
drAry[0][LibraryMOD.GetFieldName(strNUserFN)]=strNUser;
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
public int CommitGrade_Header()  
{
//CommitGrade_Header= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
//'' Update Database with SqlDataAdapter
daGrade_Header.Update(dsGrade_Header, TableName);
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
FindInMultiPKey(intStudyYear,byteSemester,byteShift,strCourse,byteClass,lngStudentNumber);
if (( Grade_HeaderDataRow != null)) 
{
Grade_HeaderDataRow.Delete();
CommitGrade_Header();
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
if (Grade_HeaderDataRow[LibraryMOD.GetFieldName(intStudyYearFN)]== System.DBNull.Value)
{
  intStudyYear=0;
}
else
{
  intStudyYear = (int)Grade_HeaderDataRow[LibraryMOD.GetFieldName(intStudyYearFN)];
}
if (Grade_HeaderDataRow[LibraryMOD.GetFieldName(byteSemesterFN)]== System.DBNull.Value)
{
  byteSemester=0;
}
else
{
  byteSemester = (int)Grade_HeaderDataRow[LibraryMOD.GetFieldName(byteSemesterFN)];
}
if (Grade_HeaderDataRow[LibraryMOD.GetFieldName(byteShiftFN)]== System.DBNull.Value)
{
  byteShift=0;
}
else
{
  byteShift = (int)Grade_HeaderDataRow[LibraryMOD.GetFieldName(byteShiftFN)];
}
if (Grade_HeaderDataRow[LibraryMOD.GetFieldName(strCourseFN)]== System.DBNull.Value)
{
  strCourse="";
}
else
{
  strCourse = (string)Grade_HeaderDataRow[LibraryMOD.GetFieldName(strCourseFN)];
}
if (Grade_HeaderDataRow[LibraryMOD.GetFieldName(byteClassFN)]== System.DBNull.Value)
{
  byteClass=0;
}
else
{
  byteClass = (int)Grade_HeaderDataRow[LibraryMOD.GetFieldName(byteClassFN)];
}
if (Grade_HeaderDataRow[LibraryMOD.GetFieldName(lngStudentNumberFN)]== System.DBNull.Value)
{
  lngStudentNumber="";
}
else
{
  lngStudentNumber = (string)Grade_HeaderDataRow[LibraryMOD.GetFieldName(lngStudentNumberFN)];
}
if (Grade_HeaderDataRow[LibraryMOD.GetFieldName(byteRefCollegeFN)]== System.DBNull.Value)
{
  byteRefCollege=0;
}
else
{
  byteRefCollege = (int)Grade_HeaderDataRow[LibraryMOD.GetFieldName(byteRefCollegeFN)];
}

if (Grade_HeaderDataRow[LibraryMOD.GetFieldName(curUseMarkFN)]== System.DBNull.Value)
{
}
else
{
}
if (Grade_HeaderDataRow[LibraryMOD.GetFieldName(strGradeFN)]== System.DBNull.Value)
{
  strGrade="";
}
else
{
  strGrade = (string)Grade_HeaderDataRow[LibraryMOD.GetFieldName(strGradeFN)];
}
if (Grade_HeaderDataRow[LibraryMOD.GetFieldName(bDisActivatedFN)]== System.DBNull.Value)
{
  bDisActivated="";
}
else
{
  bDisActivated = (string)Grade_HeaderDataRow[LibraryMOD.GetFieldName(bDisActivatedFN)];
}
if (Grade_HeaderDataRow[LibraryMOD.GetFieldName(bCanceledFN)]== System.DBNull.Value)
{
  bCanceled="";
}
else
{
  bCanceled = (string)Grade_HeaderDataRow[LibraryMOD.GetFieldName(bCanceledFN)];
}
if (Grade_HeaderDataRow[LibraryMOD.GetFieldName(intCanceledYearFN)]== System.DBNull.Value)
{
  intCanceledYear=0;
}
else
{
  intCanceledYear = (int)Grade_HeaderDataRow[LibraryMOD.GetFieldName(intCanceledYearFN)];
}
if (Grade_HeaderDataRow[LibraryMOD.GetFieldName(byteCanceledSemFN)]== System.DBNull.Value)
{
  byteCanceledSem=0;
}
else
{
  byteCanceledSem = (int)Grade_HeaderDataRow[LibraryMOD.GetFieldName(byteCanceledSemFN)];
}
if (Grade_HeaderDataRow[LibraryMOD.GetFieldName(strDegreeFN)]== System.DBNull.Value)
{
  strDegree="";
}
else
{
  strDegree = (string)Grade_HeaderDataRow[LibraryMOD.GetFieldName(strDegreeFN)];
}
if (Grade_HeaderDataRow[LibraryMOD.GetFieldName(strMajorFN)]== System.DBNull.Value)
{
  strMajor="";
}
else
{
  strMajor = (string)Grade_HeaderDataRow[LibraryMOD.GetFieldName(strMajorFN)];
}
if (Grade_HeaderDataRow[LibraryMOD.GetFieldName(AttMarkFN)]== System.DBNull.Value)
{
    
}
else
{
    AttMark = (double) Grade_HeaderDataRow[LibraryMOD.GetFieldName(AttMarkFN)];
}
if (Grade_HeaderDataRow[LibraryMOD.GetFieldName(SAltFN)] == System.DBNull.Value)
{
    SAlt = "";
}
else
{
    SAlt = (string )Grade_HeaderDataRow[LibraryMOD.GetFieldName(SAltFN)];
}
if (Grade_HeaderDataRow[LibraryMOD.GetFieldName(strUserCreateFN)]== System.DBNull.Value)
{
  strUserCreate="";
}
else
{
  strUserCreate = (string)Grade_HeaderDataRow[LibraryMOD.GetFieldName(strUserCreateFN)];
}
if (Grade_HeaderDataRow[LibraryMOD.GetFieldName(dateCreateFN)]== System.DBNull.Value)
{
}
else
{
  dateCreate = (DateTime)Grade_HeaderDataRow[LibraryMOD.GetFieldName(dateCreateFN)];
}
if (Grade_HeaderDataRow[LibraryMOD.GetFieldName(strUserSaveFN)]== System.DBNull.Value)
{
  strUserSave="";
}
else
{
  strUserSave = (string)Grade_HeaderDataRow[LibraryMOD.GetFieldName(strUserSaveFN)];
}
if (Grade_HeaderDataRow[LibraryMOD.GetFieldName(dateLastSaveFN)]== System.DBNull.Value)
{
}
else
{
  dateLastSave = (DateTime)Grade_HeaderDataRow[LibraryMOD.GetFieldName(dateLastSaveFN)];
}
if (Grade_HeaderDataRow[LibraryMOD.GetFieldName(strMachineFN)]== System.DBNull.Value)
{
  strMachine="";
}
else
{
  strMachine = (string)Grade_HeaderDataRow[LibraryMOD.GetFieldName(strMachineFN)];
}
if (Grade_HeaderDataRow[LibraryMOD.GetFieldName(strNUserFN)]== System.DBNull.Value)
{
  strNUser="";
}
else
{
  strNUser = (string)Grade_HeaderDataRow[LibraryMOD.GetFieldName(strNUserFN)];
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
public int FindInMultiPKey(int PKintStudyYear,int PKbyteSemester,int PKbyteShift,string PKstrCourse,int PKbyteClass,string PKlngStudentNumber) 
{
//FindInMultiPKey= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
//' Create an array for the key values to find.
object[] findTheseVals = new object[1] ; 
//' Set the values of the keys to find.
findTheseVals[0] = PKintStudyYear;
findTheseVals[1] = PKbyteSemester;
findTheseVals[2] = PKbyteShift;
findTheseVals[3] = PKstrCourse;
findTheseVals[4] = PKbyteClass;
findTheseVals[5] = PKlngStudentNumber;
Grade_HeaderDataRow = dsGrade_Header.Tables[TableName].Rows.Find(findTheseVals);
if  ((Grade_HeaderDataRow !=null)) 
{
lngCurRow = dsGrade_Header.Tables[TableName].Rows.IndexOf(Grade_HeaderDataRow);
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
  lngCurRow = dsGrade_Header.Tables[TableName].Rows.Count - 1; //'Zero based index
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
  lngCurRow = Math.Min(lngCurRow + 1, dsGrade_Header.Tables[TableName].Rows.Count - 1);
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
  if (lngCurRow >= 0 & dsGrade_Header.Tables[TableName].Rows.Count > 0) 
{
  Grade_HeaderDataRow = dsGrade_Header.Tables[TableName].Rows[lngCurRow];
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
daGrade_Header.RowUpdating+= new SqlRowUpdatingEventHandler(OnRowUpdating);
daGrade_Header.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
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
daGrade_Header.RowUpdating-= new SqlRowUpdatingEventHandler(OnRowUpdating);
daGrade_Header.RowUpdated-= new SqlRowUpdatedEventHandler(OnRowUpdated);
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
