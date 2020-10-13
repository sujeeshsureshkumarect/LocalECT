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
public class EmployeeGrades
{
//Creation Date: 04/11/2010 11:06 AM
//Programmer Name : Bahaa Ghaleb
//-----Decleration --------------
#region "Decleration"
private int m_GradeID; 
private string m_GradeDescEn; 
private string m_GradeDescAr; 
private int m_CirclesNo; 
private string m_MinimumSalary; 
private string m_MaximumSalary; 
private string m_BasicSalary; 
private string m_IncrementAmount; 
private int m_IsGradeType; 
private int m_GradeParent; 
private int m_IsValue; 
private int m_NextGrade; 
private int m_CreationUserID; 
private DateTime m_CreationDate; 
private int m_LastUpdateUserID; 
private DateTime m_LastUpdateDate; 
private string m_PCName; 
private string m_NetUserName; 
#endregion
#region "Puplic Properties"
//'-----------------------------------------------------
public int GradeID
{
get { return  m_GradeID; }
set {m_GradeID  = value ; }
}
public string GradeDescEn
{
get { return  m_GradeDescEn; }
set {m_GradeDescEn  = value ; }
}
public string GradeDescAr
{
get { return  m_GradeDescAr; }
set {m_GradeDescAr  = value ; }
}
public int CirclesNo
{
get { return  m_CirclesNo; }
set {m_CirclesNo  = value ; }
}
public string MinimumSalary
{
get { return  m_MinimumSalary; }
set {m_MinimumSalary  = value ; }
}
public string MaximumSalary
{
get { return  m_MaximumSalary; }
set {m_MaximumSalary  = value ; }
}
public string BasicSalary
{
get { return  m_BasicSalary; }
set {m_BasicSalary  = value ; }
}
public string IncrementAmount
{
get { return  m_IncrementAmount; }
set {m_IncrementAmount  = value ; }
}
public int IsGradeType
{
get { return  m_IsGradeType; }
set {m_IsGradeType  = value ; }
}
public int GradeParent
{
get { return  m_GradeParent; }
set {m_GradeParent  = value ; }
}
public int IsValue
{
get { return  m_IsValue; }
set {m_IsValue  = value ; }
}
public int NextGrade
{
get { return  m_NextGrade; }
set {m_NextGrade  = value ; }
}
public int CreationUserID
{
get { return  m_CreationUserID; }
set {m_CreationUserID  = value ; }
}
public DateTime CreationDate
{
get { return  m_CreationDate; }
set {m_CreationDate  = value ; }
}
public int LastUpdateUserID
{
get { return  m_LastUpdateUserID; }
set {m_LastUpdateUserID  = value ; }
}
public DateTime LastUpdateDate
{
get { return  m_LastUpdateDate; }
set {m_LastUpdateDate  = value ; }
}
public string PCName
{
get { return  m_PCName; }
set {m_PCName  = value ; }
}
public string NetUserName
{
get { return  m_NetUserName; }
set {m_NetUserName  = value ; }
}
//'-----------------------------------------------------
#endregion
//'-----------------------------------------------------
public EmployeeGrades()
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
public class EmployeeGradesDAL : EmployeeGrades
{
#region "Decleration"
private string m_TableName;
private string m_GradeIDFN ;
private string m_GradeDescEnFN ;
private string m_GradeDescArFN ;
private string m_CirclesNoFN ;
private string m_MinimumSalaryFN ;
private string m_MaximumSalaryFN ;
private string m_BasicSalaryFN ;
private string m_IncrementAmountFN ;
private string m_IsGradeTypeFN ;
private string m_GradeParentFN ;
private string m_IsValueFN ;
private string m_NextGradeFN ;
private string m_CreationUserIDFN ;
private string m_CreationDateFN ;
private string m_LastUpdateUserIDFN ;
private string m_LastUpdateDateFN ;
private string m_PCNameFN ;
private string m_NetUserNameFN ;
#endregion
//'-----------------------------------------------------
#region "Puplic Properties"
public string TableName 
{
get { return m_TableName; }
set { m_TableName = value; }
}
public string GradeIDFN 
{
get { return  m_GradeIDFN; }
set {m_GradeIDFN  = value ; }
}
public string GradeDescEnFN 
{
get { return  m_GradeDescEnFN; }
set {m_GradeDescEnFN  = value ; }
}
public string GradeDescArFN 
{
get { return  m_GradeDescArFN; }
set {m_GradeDescArFN  = value ; }
}
public string CirclesNoFN 
{
get { return  m_CirclesNoFN; }
set {m_CirclesNoFN  = value ; }
}
public string MinimumSalaryFN 
{
get { return  m_MinimumSalaryFN; }
set {m_MinimumSalaryFN  = value ; }
}
public string MaximumSalaryFN 
{
get { return  m_MaximumSalaryFN; }
set {m_MaximumSalaryFN  = value ; }
}
public string BasicSalaryFN 
{
get { return  m_BasicSalaryFN; }
set {m_BasicSalaryFN  = value ; }
}
public string IncrementAmountFN 
{
get { return  m_IncrementAmountFN; }
set {m_IncrementAmountFN  = value ; }
}
public string IsGradeTypeFN 
{
get { return  m_IsGradeTypeFN; }
set {m_IsGradeTypeFN  = value ; }
}
public string GradeParentFN 
{
get { return  m_GradeParentFN; }
set {m_GradeParentFN  = value ; }
}
public string IsValueFN 
{
get { return  m_IsValueFN; }
set {m_IsValueFN  = value ; }
}
public string NextGradeFN 
{
get { return  m_NextGradeFN; }
set {m_NextGradeFN  = value ; }
}
public string CreationUserIDFN 
{
get { return  m_CreationUserIDFN; }
set {m_CreationUserIDFN  = value ; }
}
public string CreationDateFN 
{
get { return  m_CreationDateFN; }
set {m_CreationDateFN  = value ; }
}
public string LastUpdateUserIDFN 
{
get { return  m_LastUpdateUserIDFN; }
set {m_LastUpdateUserIDFN  = value ; }
}
public string LastUpdateDateFN 
{
get { return  m_LastUpdateDateFN; }
set {m_LastUpdateDateFN  = value ; }
}
public string PCNameFN 
{
get { return  m_PCNameFN; }
set {m_PCNameFN  = value ; }
}
public string NetUserNameFN 
{
get { return  m_NetUserNameFN; }
set {m_NetUserNameFN  = value ; }
}
#endregion
//================End Properties ===================
public EmployeeGradesDAL()
{
try
{
this.TableName = "PR_Grades";
this.GradeIDFN = m_TableName + ".GradeID";
this.GradeDescEnFN = m_TableName + ".GradeDescEn";
this.GradeDescArFN = m_TableName + ".GradeDescAr";
this.CirclesNoFN = m_TableName + ".CirclesNo";
this.MinimumSalaryFN = m_TableName + ".MinimumSalary";
this.MaximumSalaryFN = m_TableName + ".MaximumSalary";
this.BasicSalaryFN = m_TableName + ".BasicSalary";
this.IncrementAmountFN = m_TableName + ".IncrementAmount";
this.IsGradeTypeFN = m_TableName + ".IsGradeType";
this.GradeParentFN = m_TableName + ".GradeParent";
this.IsValueFN = m_TableName + ".IsValue";
this.NextGradeFN = m_TableName + ".NextGrade";
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
public string  GetSQL() 
{
string sSQL  = "";
try
{
sSQL = "SELECT ";
sSQL +=GradeIDFN;
sSQL += " , " + GradeDescEnFN;
sSQL += " , " + GradeDescArFN;
sSQL += " , " + CirclesNoFN;
sSQL += " , " + MinimumSalaryFN;
sSQL += " , " + MaximumSalaryFN;
sSQL += " , " + BasicSalaryFN;
sSQL += " , " + IncrementAmountFN;
sSQL += " , " + IsGradeTypeFN;
sSQL += " , " + GradeParentFN;
sSQL += " , " + IsValueFN;
sSQL += " , " + NextGradeFN;
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
//-----GetListSQl Function ---------------------------------
public string GetListSQL(string sWhere) 
{
string sSQL  = "";
try
{
sSQL = "SELECT ";
sSQL +=GradeIDFN;
sSQL += " , " + GradeDescEnFN;
sSQL += " , " + GradeDescArFN;
sSQL += "  FROM " + m_TableName;
sSQL += sWhere;
sSQL += " Order By (" + GradeIDFN + ")";
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
sSQL +=GradeIDFN;
sSQL += " , " + GradeDescEnFN;
sSQL += " , " + GradeDescArFN;
sSQL += " , " + CirclesNoFN;
sSQL += " , " + MinimumSalaryFN;
sSQL += " , " + MaximumSalaryFN;
sSQL += " , " + BasicSalaryFN;
sSQL += " , " + IncrementAmountFN;
sSQL += " , " + IsGradeTypeFN;
sSQL += " , " + GradeParentFN;
sSQL += " , " + IsValueFN;
sSQL += " , " + NextGradeFN;
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
string sSQL  = "";
try
{
sSQL = "UPDATE " + TableName;
sSQL += " SET ";
sSQL += LibraryMOD.GetFieldName(GradeIDFN) + "=@GradeID";
sSQL += " , " + LibraryMOD.GetFieldName(GradeDescEnFN) + "=@GradeDescEn";
sSQL += " , " + LibraryMOD.GetFieldName(GradeDescArFN) + "=@GradeDescAr";
sSQL += " , " + LibraryMOD.GetFieldName(CirclesNoFN) + "=@CirclesNo";
sSQL += " , " + LibraryMOD.GetFieldName(MinimumSalaryFN) + "=@MinimumSalary";
sSQL += " , " + LibraryMOD.GetFieldName(MaximumSalaryFN) + "=@MaximumSalary";
sSQL += " , " + LibraryMOD.GetFieldName(BasicSalaryFN) + "=@BasicSalary";
sSQL += " , " + LibraryMOD.GetFieldName(IncrementAmountFN) + "=@IncrementAmount";
sSQL += " , " + LibraryMOD.GetFieldName(IsGradeTypeFN) + "=@IsGradeType";
sSQL += " , " + LibraryMOD.GetFieldName(GradeParentFN) + "=@GradeParent";
sSQL += " , " + LibraryMOD.GetFieldName(IsValueFN) + "=@IsValue";
sSQL += " , " + LibraryMOD.GetFieldName(NextGradeFN) + "=@NextGrade";
sSQL += " , " + LibraryMOD.GetFieldName(CreationUserIDFN) + "=@CreationUserID";
sSQL += " , " + LibraryMOD.GetFieldName(CreationDateFN) + "=@CreationDate";
sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateUserIDFN) + "=@LastUpdateUserID";
sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateDateFN) + "=@LastUpdateDate";
sSQL += " , " + LibraryMOD.GetFieldName(PCNameFN) + "=@PCName";
sSQL += " , " + LibraryMOD.GetFieldName(NetUserNameFN) + "=@NetUserName";
sSQL += " WHERE ";
sSQL += LibraryMOD.GetFieldName(GradeIDFN)+"=@GradeID";
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
sSQL +=LibraryMOD.GetFieldName(GradeIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(GradeDescEnFN);
sSQL += " , " + LibraryMOD.GetFieldName(GradeDescArFN);
sSQL += " , " + LibraryMOD.GetFieldName(CirclesNoFN);
sSQL += " , " + LibraryMOD.GetFieldName(MinimumSalaryFN);
sSQL += " , " + LibraryMOD.GetFieldName(MaximumSalaryFN);
sSQL += " , " + LibraryMOD.GetFieldName(BasicSalaryFN);
sSQL += " , " + LibraryMOD.GetFieldName(IncrementAmountFN);
sSQL += " , " + LibraryMOD.GetFieldName(IsGradeTypeFN);
sSQL += " , " + LibraryMOD.GetFieldName(GradeParentFN);
sSQL += " , " + LibraryMOD.GetFieldName(IsValueFN);
sSQL += " , " + LibraryMOD.GetFieldName(NextGradeFN);
sSQL += " , " + LibraryMOD.GetFieldName(CreationUserIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(CreationDateFN);
sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateUserIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateDateFN);
sSQL += " , " + LibraryMOD.GetFieldName(PCNameFN);
sSQL += " , " + LibraryMOD.GetFieldName(NetUserNameFN);
sSQL += ")";
sSQL += " VALUES ";
sSQL += "( ";
sSQL += " @GradeID";
sSQL += " ,@GradeDescEn";
sSQL += " ,@GradeDescAr";
sSQL += " ,@CirclesNo";
sSQL += " ,@MinimumSalary";
sSQL += " ,@MaximumSalary";
sSQL += " ,@BasicSalary";
sSQL += " ,@IncrementAmount";
sSQL += " ,@IsGradeType";
sSQL += " ,@GradeParent";
sSQL += " ,@IsValue";
sSQL += " ,@NextGrade";
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
public string  GetDeleteCommand()
{
string sSQL= "";
try
{
sSQL = "DELETE FROM "  + TableName;
sSQL += " WHERE ";
sSQL += LibraryMOD.GetFieldName(GradeIDFN)+"=@GradeID";
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
public List< EmployeeGrades> GetGrades(InitializeModule.EnumCampus Campus ,string sCondition,bool isDeafaultIncluded)
{
//' returns a list of Classes instances based on the
//' data in the Grades
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
List<EmployeeGrades> results = new List<EmployeeGrades>();
try
{
//Default Value
EmployeeGrades myEmployeeGrades = new EmployeeGrades();
if (isDeafaultIncluded)
{
//Change the code here
myEmployeeGrades.GradeID = 0;
myEmployeeGrades.GradeDescEn = "Select EmployeeGrades ...";
results.Add(myEmployeeGrades);
}
while (reader.Read())
{
myEmployeeGrades = new EmployeeGrades();
if (reader[LibraryMOD.GetFieldName(GradeIDFN)].Equals(DBNull.Value))
{
myEmployeeGrades.GradeID = 0;
}
else
{
myEmployeeGrades.GradeID = int.Parse(reader[LibraryMOD.GetFieldName( GradeIDFN) ].ToString());
}
myEmployeeGrades.GradeDescEn =reader[LibraryMOD.GetFieldName( GradeDescEnFN) ].ToString();
myEmployeeGrades.GradeDescAr =reader[LibraryMOD.GetFieldName( GradeDescArFN) ].ToString();
if (reader[LibraryMOD.GetFieldName(CirclesNoFN)].Equals(DBNull.Value))
{
myEmployeeGrades.CirclesNo = 0;
}
else
{
myEmployeeGrades.CirclesNo = int.Parse(reader[LibraryMOD.GetFieldName( CirclesNoFN) ].ToString());
}
myEmployeeGrades.MinimumSalary =reader[LibraryMOD.GetFieldName( MinimumSalaryFN) ].ToString();
myEmployeeGrades.MaximumSalary =reader[LibraryMOD.GetFieldName( MaximumSalaryFN) ].ToString();
myEmployeeGrades.BasicSalary =reader[LibraryMOD.GetFieldName( BasicSalaryFN) ].ToString();
myEmployeeGrades.IncrementAmount =reader[LibraryMOD.GetFieldName( IncrementAmountFN) ].ToString();
if (reader[LibraryMOD.GetFieldName(IsGradeTypeFN)].Equals(DBNull.Value))
{
myEmployeeGrades.IsGradeType = 0;
}
else
{
myEmployeeGrades.IsGradeType = int.Parse(reader[LibraryMOD.GetFieldName( IsGradeTypeFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(GradeParentFN)].Equals(DBNull.Value))
{
myEmployeeGrades.GradeParent = 0;
}
else
{
myEmployeeGrades.GradeParent = int.Parse(reader[LibraryMOD.GetFieldName( GradeParentFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(IsValueFN)].Equals(DBNull.Value))
{
myEmployeeGrades.IsValue = 0;
}
else
{
myEmployeeGrades.IsValue = int.Parse(reader[LibraryMOD.GetFieldName( IsValueFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(NextGradeFN)].Equals(DBNull.Value))
{
myEmployeeGrades.NextGrade = 0;
}
else
{
myEmployeeGrades.NextGrade = int.Parse(reader[LibraryMOD.GetFieldName( NextGradeFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(CreationUserIDFN)].Equals(DBNull.Value))
{
myEmployeeGrades.CreationUserID = 0;
}
else
{
myEmployeeGrades.CreationUserID = int.Parse(reader[LibraryMOD.GetFieldName( CreationUserIDFN) ].ToString());
}
if (!reader[LibraryMOD.GetFieldName(CreationDateFN)].Equals(DBNull.Value))
{
myEmployeeGrades.CreationDate = DateTime.Parse(reader[LibraryMOD.GetFieldName( CreationDateFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(LastUpdateUserIDFN)].Equals(DBNull.Value))
{
myEmployeeGrades.LastUpdateUserID = 0;
}
else
{
myEmployeeGrades.LastUpdateUserID = int.Parse(reader[LibraryMOD.GetFieldName( LastUpdateUserIDFN) ].ToString());
}
if (!reader[LibraryMOD.GetFieldName(LastUpdateDateFN)].Equals(DBNull.Value))
{
myEmployeeGrades.LastUpdateDate = DateTime.Parse(reader[LibraryMOD.GetFieldName( LastUpdateDateFN) ].ToString());
}
myEmployeeGrades.PCName =reader[LibraryMOD.GetFieldName( PCNameFN) ].ToString();
myEmployeeGrades.NetUserName =reader[LibraryMOD.GetFieldName( NetUserNameFN) ].ToString();
 results.Add(myEmployeeGrades);
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
public List< EmployeeGrades > GetList(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
{
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
string sSQL = GetListSQL(sCondition);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
SqlCommand Cmd = new SqlCommand(sSQL, Conn);
Conn.Open();
SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
List<EmployeeGrades> results = new List<EmployeeGrades>();
try
{
//Default Value
EmployeeGrades myEmployeeGrades= new EmployeeGrades();
if (isDeafaultIncluded) 
 {
//Change the code here
 myEmployeeGrades.GradeID = -1;
 myEmployeeGrades.GradeDescEn = "Select EmployeeGrades" ;
results.Add(myEmployeeGrades);
 }
while (reader.Read())
{
myEmployeeGrades = new EmployeeGrades();
if (reader[LibraryMOD.GetFieldName(GradeIDFN)].Equals(DBNull.Value))
{
myEmployeeGrades.GradeID = 0;
}
else
{
myEmployeeGrades.GradeID = int.Parse(reader[LibraryMOD.GetFieldName( GradeIDFN) ].ToString());
}
myEmployeeGrades.GradeDescEn =reader[LibraryMOD.GetFieldName( GradeDescEnFN) ].ToString();
myEmployeeGrades.GradeDescAr =reader[LibraryMOD.GetFieldName( GradeDescArFN) ].ToString();
 results.Add(myEmployeeGrades);
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
public int UpdateGrades(InitializeModule.EnumCampus Campus, int iMode,int GradeID,string GradeDescEn,string GradeDescAr,int CirclesNo,string MinimumSalary,string MaximumSalary,string BasicSalary,string IncrementAmount,int IsGradeType,int GradeParent,int IsValue,int NextGrade,int CreationUserID,DateTime CreationDate,int LastUpdateUserID,DateTime LastUpdateDate,string PCName,string NetUserName)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
Conn.Open();
string sql = "";
EmployeeGrades theEmployeeGrades = new EmployeeGrades();
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
Cmd.Parameters.Add(new SqlParameter("@GradeID",GradeID));
Cmd.Parameters.Add(new SqlParameter("@GradeDescEn",GradeDescEn));
Cmd.Parameters.Add(new SqlParameter("@GradeDescAr",GradeDescAr));
Cmd.Parameters.Add(new SqlParameter("@CirclesNo",CirclesNo));
Cmd.Parameters.Add(new SqlParameter("@MinimumSalary",MinimumSalary));
Cmd.Parameters.Add(new SqlParameter("@MaximumSalary",MaximumSalary));
Cmd.Parameters.Add(new SqlParameter("@BasicSalary",BasicSalary));
Cmd.Parameters.Add(new SqlParameter("@IncrementAmount",IncrementAmount));
Cmd.Parameters.Add(new SqlParameter("@IsGradeType",IsGradeType));
Cmd.Parameters.Add(new SqlParameter("@GradeParent",GradeParent));
Cmd.Parameters.Add(new SqlParameter("@IsValue",IsValue));
Cmd.Parameters.Add(new SqlParameter("@NextGrade",NextGrade));
Cmd.Parameters.Add(new SqlParameter("@CreationUserID",CreationUserID));
Cmd.Parameters.Add(new SqlParameter("@CreationDate",CreationDate));
Cmd.Parameters.Add(new SqlParameter("@LastUpdateUserID",LastUpdateUserID));
Cmd.Parameters.Add(new SqlParameter("@LastUpdateDate",LastUpdateDate));
Cmd.Parameters.Add(new SqlParameter("@PCName",PCName));
Cmd.Parameters.Add(new SqlParameter("@NetUserName",NetUserName));
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
public int DeleteGrades(InitializeModule.EnumCampus Campus,string GradeID)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
string sSQL = GetDeleteCommand();
//sSQL += sCondition;
SqlCommand Cmd = new SqlCommand(sSQL, Conn);
Cmd.Parameters.Add(new SqlParameter("@GradeID", GradeID ));
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
DataTable dt = new DataTable("Grades");
DataView dv = new DataView();
List<EmployeeGrades> myEmployeeGradess = new List<EmployeeGrades>();
try
{
myEmployeeGradess = GetGrades(InitializeModule.EnumCampus.ECTNew,sCondition,false);
DataColumn col1= new DataColumn("GradeID", Type.GetType("int"));
dt.Columns.Add(col1 );
DataColumn col2= new DataColumn("GradeDescEn", Type.GetType("nvarchar"));
dt.Columns.Add(col2 );
DataColumn col3= new DataColumn("GradeDescAr", Type.GetType("nvarchar"));
dt.Columns.Add(col3 );
dt.Constraints.Add(new UniqueConstraint(col1));

DataRow dr;
for (int i = 0; i < myEmployeeGradess.Count; i++)
{
dr = dt.NewRow();
  dr[1] = myEmployeeGradess[i].GradeID;
  dr[2] = myEmployeeGradess[i].GradeDescEn;
  dr[3] = myEmployeeGradess[i].GradeDescAr;
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
myEmployeeGradess.Clear();
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
sSQL += GradeIDFN;
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
public class EmployeeGradesCls : EmployeeGradesDAL
{
#region "Decleration"
private int m_lngCurRow=0;
public SqlDataAdapter daGrades;
private DataSet m_dsGrades;
public DataRow GradesDataRow ;
#endregion
#region "Puplic Properties"
public DataSet dsGrades
{
get { return m_dsGrades ; }
set { m_dsGrades = value ; }
}
//-----------------------------------------------------
public int lngCurRow 
{
get { return  m_lngCurRow ; }
set {m_lngCurRow = value ; }
}
#endregion
public EmployeeGradesCls()
{
try
{
dsGrades= new DataSet();

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
public virtual SqlDataAdapter GetGradesDataAdapter(string sCondition ,SqlConnection con ) 
{
string sSQL =""; 
try
{
sSQL = GetSQL();
sSQL += " " + sCondition;
//-----------------------------------------
daGrades = new SqlDataAdapter(sSQL, con);
// Create command builder. This line automatically generates the update commands for you, so you don't
// have to provide or create your own.
SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daGrades);
//Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
// key + unique key information to be retrieved unless AddWithKey is specified.
daGrades.MissingSchemaAction = MissingSchemaAction.AddWithKey;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daGrades;
}
public virtual SqlDataAdapter GetGradesDataAdapter(SqlConnection con)  
{
try
{
daGrades = new SqlDataAdapter();
//''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
//'' key + unique key information to be retrieved unless AddWithKey is specified.
daGrades.MissingSchemaAction = MissingSchemaAction.AddWithKey;
//-----------------------------------------
SqlParameter Parmeter = default(SqlParameter); 
//[SELECT COMMAND]
SqlCommand cmdGrades;
cmdGrades = new SqlCommand(GetSelectCommand(), con);
//'cmdRolePermission.Parameters.Add("@GradeID", SqlDbType.Int, 4, "GradeID" );
daGrades.SelectCommand = cmdGrades;
//'Add Handlers
//'RowUpdating,RowUpdated
AddDAEventHandler();
//'[UPDATE COMMAND].
cmdGrades = new SqlCommand(GetUpdateCommand(), con);
//'Delete PK Parameteres from here. b/c its declared below
cmdGrades.Parameters.Add("@GradeID", SqlDbType.Int,4, LibraryMOD.GetFieldName(GradeIDFN));
cmdGrades.Parameters.Add("@GradeDescEn", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(GradeDescEnFN));
cmdGrades.Parameters.Add("@GradeDescAr", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(GradeDescArFN));
cmdGrades.Parameters.Add("@CirclesNo", SqlDbType.Int,4, LibraryMOD.GetFieldName(CirclesNoFN));
cmdGrades.Parameters.Add("@MinimumSalary", SqlDbType.Decimal,11, LibraryMOD.GetFieldName(MinimumSalaryFN));
cmdGrades.Parameters.Add("@MaximumSalary", SqlDbType.Decimal, 11, LibraryMOD.GetFieldName(MaximumSalaryFN));
cmdGrades.Parameters.Add("@BasicSalary", SqlDbType.Decimal, 11, LibraryMOD.GetFieldName(BasicSalaryFN));
cmdGrades.Parameters.Add("@IncrementAmount", SqlDbType.Decimal,11, LibraryMOD.GetFieldName(IncrementAmountFN));
cmdGrades.Parameters.Add("@IsGradeType", SqlDbType.Int,4, LibraryMOD.GetFieldName(IsGradeTypeFN));
cmdGrades.Parameters.Add("@GradeParent", SqlDbType.Int,4, LibraryMOD.GetFieldName(GradeParentFN));
cmdGrades.Parameters.Add("@IsValue", SqlDbType.Int,4, LibraryMOD.GetFieldName(IsValueFN));
cmdGrades.Parameters.Add("@NextGrade", SqlDbType.Int,4, LibraryMOD.GetFieldName(NextGradeFN));
cmdGrades.Parameters.Add("@CreationUserID", SqlDbType.Int,4, LibraryMOD.GetFieldName(CreationUserIDFN));
cmdGrades.Parameters.Add("@CreationDate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(CreationDateFN));
cmdGrades.Parameters.Add("@LastUpdateUserID", SqlDbType.Int,4, LibraryMOD.GetFieldName(LastUpdateUserIDFN));
cmdGrades.Parameters.Add("@LastUpdateDate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(LastUpdateDateFN));
cmdGrades.Parameters.Add("@PCName", SqlDbType.NVarChar,32, LibraryMOD.GetFieldName(PCNameFN));
cmdGrades.Parameters.Add("@NetUserName", SqlDbType.NVarChar,32, LibraryMOD.GetFieldName(NetUserNameFN));


Parmeter = cmdGrades.Parameters.Add("@GradeID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(GradeIDFN));
Parmeter.SourceVersion = DataRowVersion.Original;
//'Its should be none for batch updating
//'UpdateCommand, InsertCommand, and DeleteCommand 
//'should be set to None or OutputParameters
daGrades.UpdateCommand = cmdGrades;
daGrades.UpdateCommand.UpdatedRowSource  = UpdateRowSource.None ;
//'-------------------------------------------------------------------------
//'/INSERT COMMAND
 cmdGrades = new SqlCommand(GetInsertCommand(), con);
cmdGrades.Parameters.Add("@GradeID", SqlDbType.Int,4, LibraryMOD.GetFieldName(GradeIDFN));
cmdGrades.Parameters.Add("@GradeDescEn", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(GradeDescEnFN));
cmdGrades.Parameters.Add("@GradeDescAr", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(GradeDescArFN));
cmdGrades.Parameters.Add("@CirclesNo", SqlDbType.Int,4, LibraryMOD.GetFieldName(CirclesNoFN));
cmdGrades.Parameters.Add("@MinimumSalary", SqlDbType.Decimal,11, LibraryMOD.GetFieldName(MinimumSalaryFN));
cmdGrades.Parameters.Add("@MaximumSalary", SqlDbType.Decimal,11, LibraryMOD.GetFieldName(MaximumSalaryFN));
cmdGrades.Parameters.Add("@BasicSalary", SqlDbType.Decimal,11, LibraryMOD.GetFieldName(BasicSalaryFN));
cmdGrades.Parameters.Add("@IncrementAmount", SqlDbType.Decimal,11, LibraryMOD.GetFieldName(IncrementAmountFN));
cmdGrades.Parameters.Add("@IsGradeType", SqlDbType.Int,4, LibraryMOD.GetFieldName(IsGradeTypeFN));
cmdGrades.Parameters.Add("@GradeParent", SqlDbType.Int,4, LibraryMOD.GetFieldName(GradeParentFN));
cmdGrades.Parameters.Add("@IsValue", SqlDbType.Int,4, LibraryMOD.GetFieldName(IsValueFN));
cmdGrades.Parameters.Add("@NextGrade", SqlDbType.Int,4, LibraryMOD.GetFieldName(NextGradeFN));
cmdGrades.Parameters.Add("@CreationUserID", SqlDbType.Int,4, LibraryMOD.GetFieldName(CreationUserIDFN));
cmdGrades.Parameters.Add("@CreationDate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(CreationDateFN));
cmdGrades.Parameters.Add("@LastUpdateUserID", SqlDbType.Int,4, LibraryMOD.GetFieldName(LastUpdateUserIDFN));
cmdGrades.Parameters.Add("@LastUpdateDate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(LastUpdateDateFN));
cmdGrades.Parameters.Add("@PCName", SqlDbType.NVarChar,32, LibraryMOD.GetFieldName(PCNameFN));
cmdGrades.Parameters.Add("@NetUserName", SqlDbType.NVarChar,32, LibraryMOD.GetFieldName(NetUserNameFN));
Parmeter.SourceVersion = DataRowVersion.Current;
daGrades.InsertCommand =cmdGrades;
daGrades.InsertCommand.UpdatedRowSource  = UpdateRowSource.None;
//'------------------------
//'/DELETE COMMAND
 cmdGrades = new SqlCommand(GetDeleteCommand(), con);
Parmeter = cmdGrades.Parameters.Add("@GradeID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(GradeIDFN));
Parmeter.SourceVersion = DataRowVersion.Original;
daGrades.DeleteCommand =cmdGrades;
daGrades.DeleteCommand.UpdatedRowSource  = UpdateRowSource.None;
//'Batch Size
//'Set the batch size.
daGrades.UpdateBatchSize = ECTGlobalDll.InitializeModule.BATCH_SIZE;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daGrades;
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
dr = dsGrades.Tables[TableName].NewRow();
dr[LibraryMOD.GetFieldName(GradeIDFN)]=GradeID;
dr[LibraryMOD.GetFieldName(GradeDescEnFN)]=GradeDescEn;
dr[LibraryMOD.GetFieldName(GradeDescArFN)]=GradeDescAr;
dr[LibraryMOD.GetFieldName(CirclesNoFN)]=CirclesNo;
dr[LibraryMOD.GetFieldName(MinimumSalaryFN)]=MinimumSalary;
dr[LibraryMOD.GetFieldName(MaximumSalaryFN)]=MaximumSalary;
dr[LibraryMOD.GetFieldName(BasicSalaryFN)]=BasicSalary;
dr[LibraryMOD.GetFieldName(IncrementAmountFN)]=IncrementAmount;
dr[LibraryMOD.GetFieldName(IsGradeTypeFN)]=IsGradeType;
dr[LibraryMOD.GetFieldName(GradeParentFN)]=GradeParent;
dr[LibraryMOD.GetFieldName(IsValueFN)]=IsValue;
dr[LibraryMOD.GetFieldName(NextGradeFN)]=NextGrade;
dsGrades.Tables[TableName].Rows.Add(dr);
break;
case (int)ECTGlobalDll.InitializeModule.enumModes.EditMode:
 DataRow[] drAry = null;
drAry = dsGrades.Tables[TableName].Select(LibraryMOD.GetFieldName(GradeIDFN)  + "=" + GradeID);
//'its return array of rows and we can access the first by index 0
drAry[0][LibraryMOD.GetFieldName(GradeIDFN)]=GradeID;
drAry[0][LibraryMOD.GetFieldName(GradeDescEnFN)]=GradeDescEn;
drAry[0][LibraryMOD.GetFieldName(GradeDescArFN)]=GradeDescAr;
drAry[0][LibraryMOD.GetFieldName(CirclesNoFN)]=CirclesNo;
drAry[0][LibraryMOD.GetFieldName(MinimumSalaryFN)]=MinimumSalary;
drAry[0][LibraryMOD.GetFieldName(MaximumSalaryFN)]=MaximumSalary;
drAry[0][LibraryMOD.GetFieldName(BasicSalaryFN)]=BasicSalary;
drAry[0][LibraryMOD.GetFieldName(IncrementAmountFN)]=IncrementAmount;
drAry[0][LibraryMOD.GetFieldName(IsGradeTypeFN)]=IsGradeType;
drAry[0][LibraryMOD.GetFieldName(GradeParentFN)]=GradeParent;
drAry[0][LibraryMOD.GetFieldName(IsValueFN)]=IsValue;
drAry[0][LibraryMOD.GetFieldName(NextGradeFN)]=NextGrade;
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
public int CommitGrades()  
{
//CommitGrades= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
//'' Update Database with SqlDataAdapter
daGrades.Update(dsGrades, TableName);
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
FindInMultiPKey(GradeID);
if (( GradesDataRow != null)) 
{
GradesDataRow.Delete();
CommitGrades();
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
if (GradesDataRow[LibraryMOD.GetFieldName(GradeIDFN)]== System.DBNull.Value)
{
  GradeID=0;
}
else
{
  GradeID = (int)GradesDataRow[LibraryMOD.GetFieldName(GradeIDFN)];
}
if (GradesDataRow[LibraryMOD.GetFieldName(GradeDescEnFN)]== System.DBNull.Value)
{
  GradeDescEn="";
}
else
{
  GradeDescEn = (string)GradesDataRow[LibraryMOD.GetFieldName(GradeDescEnFN)];
}
if (GradesDataRow[LibraryMOD.GetFieldName(GradeDescArFN)]== System.DBNull.Value)
{
  GradeDescAr="";
}
else
{
  GradeDescAr = (string)GradesDataRow[LibraryMOD.GetFieldName(GradeDescArFN)];
}
if (GradesDataRow[LibraryMOD.GetFieldName(CirclesNoFN)]== System.DBNull.Value)
{
  CirclesNo=0;
}
else
{
  CirclesNo = (int)GradesDataRow[LibraryMOD.GetFieldName(CirclesNoFN)];
}
if (GradesDataRow[LibraryMOD.GetFieldName(MinimumSalaryFN)]== System.DBNull.Value)
{
  MinimumSalary="";
}
else
{
  MinimumSalary = (string)GradesDataRow[LibraryMOD.GetFieldName(MinimumSalaryFN)];
}
if (GradesDataRow[LibraryMOD.GetFieldName(MaximumSalaryFN)]== System.DBNull.Value)
{
  MaximumSalary="";
}
else
{
  MaximumSalary = (string)GradesDataRow[LibraryMOD.GetFieldName(MaximumSalaryFN)];
}
if (GradesDataRow[LibraryMOD.GetFieldName(BasicSalaryFN)]== System.DBNull.Value)
{
  BasicSalary="";
}
else
{
  BasicSalary = (string)GradesDataRow[LibraryMOD.GetFieldName(BasicSalaryFN)];
}
if (GradesDataRow[LibraryMOD.GetFieldName(IncrementAmountFN)]== System.DBNull.Value)
{
  IncrementAmount="";
}
else
{
  IncrementAmount = (string)GradesDataRow[LibraryMOD.GetFieldName(IncrementAmountFN)];
}
if (GradesDataRow[LibraryMOD.GetFieldName(IsGradeTypeFN)]== System.DBNull.Value)
{
  IsGradeType=0;
}
else
{
  IsGradeType = (int)GradesDataRow[LibraryMOD.GetFieldName(IsGradeTypeFN)];
}
if (GradesDataRow[LibraryMOD.GetFieldName(GradeParentFN)]== System.DBNull.Value)
{
  GradeParent=0;
}
else
{
  GradeParent = (int)GradesDataRow[LibraryMOD.GetFieldName(GradeParentFN)];
}
if (GradesDataRow[LibraryMOD.GetFieldName(IsValueFN)]== System.DBNull.Value)
{
  IsValue=0;
}
else
{
  IsValue = (int)GradesDataRow[LibraryMOD.GetFieldName(IsValueFN)];
}
if (GradesDataRow[LibraryMOD.GetFieldName(NextGradeFN)]== System.DBNull.Value)
{
  NextGrade=0;
}
else
{
  NextGrade = (int)GradesDataRow[LibraryMOD.GetFieldName(NextGradeFN)];
}
if (GradesDataRow[LibraryMOD.GetFieldName(CreationUserIDFN)]== System.DBNull.Value)
{
  CreationUserID=0;
}
else
{
  CreationUserID = (int)GradesDataRow[LibraryMOD.GetFieldName(CreationUserIDFN)];
}
if (GradesDataRow[LibraryMOD.GetFieldName(CreationDateFN)]== System.DBNull.Value)
{
}
else
{
  CreationDate = (DateTime)GradesDataRow[LibraryMOD.GetFieldName(CreationDateFN)];
}
if (GradesDataRow[LibraryMOD.GetFieldName(LastUpdateUserIDFN)]== System.DBNull.Value)
{
  LastUpdateUserID=0;
}
else
{
  LastUpdateUserID = (int)GradesDataRow[LibraryMOD.GetFieldName(LastUpdateUserIDFN)];
}
if (GradesDataRow[LibraryMOD.GetFieldName(LastUpdateDateFN)]== System.DBNull.Value)
{
}
else
{
  LastUpdateDate = (DateTime)GradesDataRow[LibraryMOD.GetFieldName(LastUpdateDateFN)];
}
if (GradesDataRow[LibraryMOD.GetFieldName(PCNameFN)]== System.DBNull.Value)
{
  PCName="";
}
else
{
  PCName = (string)GradesDataRow[LibraryMOD.GetFieldName(PCNameFN)];
}
if (GradesDataRow[LibraryMOD.GetFieldName(NetUserNameFN)]== System.DBNull.Value)
{
  NetUserName="";
}
else
{
  NetUserName = (string)GradesDataRow[LibraryMOD.GetFieldName(NetUserNameFN)];
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
public int FindInMultiPKey(int PKGradeID) 
{
//FindInMultiPKey= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
//' Create an array for the key values to find.
object[] findTheseVals = new object[1] ; 
//' Set the values of the keys to find.
findTheseVals[0] = PKGradeID;
GradesDataRow = dsGrades.Tables[TableName].Rows.Find(findTheseVals);
if  ((GradesDataRow !=null)) 
{
lngCurRow = dsGrades.Tables[TableName].Rows.IndexOf(GradesDataRow);
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
  lngCurRow = dsGrades.Tables[TableName].Rows.Count - 1; //'Zero based index
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
  lngCurRow = Math.Min(lngCurRow + 1, dsGrades.Tables[TableName].Rows.Count - 1);
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
  if (lngCurRow >= 0 & dsGrades.Tables[TableName].Rows.Count > 0) 
{
  GradesDataRow = dsGrades.Tables[TableName].Rows[lngCurRow];
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
daGrades.RowUpdating+= new SqlRowUpdatingEventHandler(OnRowUpdating);
daGrades.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
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
daGrades.RowUpdating-= new SqlRowUpdatingEventHandler(OnRowUpdating);
daGrades.RowUpdated-= new SqlRowUpdatedEventHandler(OnRowUpdated);
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
