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
public class EmployeeExperiences
{
//Creation Date: 29/11/2010 4:01 PM
//Programmer Name : Bahaa Addin Ghaleb Najem
//-----Decleration --------------
#region "Decleration"
private int m_EmployeeID; 
private int m_ExperienceID; 
private int m_ExperienceTypeID; 
private string m_CompanyName; 
private string m_Address; 
private int m_JobTitleID; 
private string m_JobTitle; 
private string m_StartDate; 
private string m_EndDate; 
private string m_DirectManager; 
private string m_JobDescription; 
private string m_Notes; 
private int m_CreationUserID; 
private DateTime m_CreationDate; 
private int m_LastUpdateUserID; 
private DateTime m_LastUpdateDate; 
private string m_PCName; 
private string m_NetUserName; 
#endregion
#region "Puplic Properties"
//'-----------------------------------------------------
public int EmployeeID
{
get { return  m_EmployeeID; }
set {m_EmployeeID  = value ; }
}
public int ExperienceID
{
get { return  m_ExperienceID; }
set {m_ExperienceID  = value ; }
}
public int ExperienceTypeID
{
get { return  m_ExperienceTypeID; }
set {m_ExperienceTypeID  = value ; }
}
public string CompanyName
{
get { return  m_CompanyName; }
set {m_CompanyName  = value ; }
}
public string Address
{
get { return  m_Address; }
set {m_Address  = value ; }
}
public int JobTitleID
{
get { return  m_JobTitleID; }
set {m_JobTitleID  = value ; }
}
public string JobTitle
{
get { return  m_JobTitle; }
set {m_JobTitle  = value ; }
}
public string StartDate
{
get { return  m_StartDate; }
set {m_StartDate  = value ; }
}
public string EndDate
{
get { return  m_EndDate; }
set {m_EndDate  = value ; }
}
public string DirectManager
{
get { return  m_DirectManager; }
set {m_DirectManager  = value ; }
}
public string JobDescription
{
get { return  m_JobDescription; }
set {m_JobDescription  = value ; }
}
public string Notes
{
get { return  m_Notes; }
set {m_Notes  = value ; }
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
public EmployeeExperiences()
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
public class EmployeeExperiencesDAL : EmployeeExperiences
{
#region "Decleration"
private string m_TableName;
private string m_EmployeeIDFN ;
private string m_ExperienceIDFN ;
private string m_ExperienceTypeIDFN ;
private string m_CompanyNameFN ;
private string m_AddressFN ;
private string m_JobTitleIDFN ;
private string m_JobTitleFN ;
private string m_StartDateFN ;
private string m_EndDateFN ;
private string m_DirectManagerFN ;
private string m_JobDescriptionFN ;
private string m_NotesFN ;
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
public string EmployeeIDFN 
{
get { return  m_EmployeeIDFN; }
set {m_EmployeeIDFN  = value ; }
}
public string ExperienceIDFN 
{
get { return  m_ExperienceIDFN; }
set {m_ExperienceIDFN  = value ; }
}
public string ExperienceTypeIDFN 
{
get { return  m_ExperienceTypeIDFN; }
set {m_ExperienceTypeIDFN  = value ; }
}
public string CompanyNameFN 
{
get { return  m_CompanyNameFN; }
set {m_CompanyNameFN  = value ; }
}
public string AddressFN 
{
get { return  m_AddressFN; }
set {m_AddressFN  = value ; }
}
public string JobTitleIDFN 
{
get { return  m_JobTitleIDFN; }
set {m_JobTitleIDFN  = value ; }
}
public string JobTitleFN 
{
get { return  m_JobTitleFN; }
set {m_JobTitleFN  = value ; }
}
public string StartDateFN 
{
get { return  m_StartDateFN; }
set {m_StartDateFN  = value ; }
}
public string EndDateFN 
{
get { return  m_EndDateFN; }
set {m_EndDateFN  = value ; }
}
public string DirectManagerFN 
{
get { return  m_DirectManagerFN; }
set {m_DirectManagerFN  = value ; }
}
public string JobDescriptionFN 
{
get { return  m_JobDescriptionFN; }
set {m_JobDescriptionFN  = value ; }
}
public string NotesFN 
{
get { return  m_NotesFN; }
set {m_NotesFN  = value ; }
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
public EmployeeExperiencesDAL()
{
try
{
this.TableName = "Hr_EmployeeExperiences";
this.EmployeeIDFN = m_TableName + ".EmployeeID";
this.ExperienceIDFN = m_TableName + ".ExperienceID";
this.ExperienceTypeIDFN = m_TableName + ".ExperienceTypeID";
this.CompanyNameFN = m_TableName + ".CompanyName";
this.AddressFN = m_TableName + ".Address";
this.JobTitleIDFN = m_TableName + ".JobTitleID";
this.JobTitleFN = m_TableName + ".JobTitle";
this.StartDateFN = m_TableName + ".StartDate";
this.EndDateFN = m_TableName + ".EndDate";
this.DirectManagerFN = m_TableName + ".DirectManager";
this.JobDescriptionFN = m_TableName + ".JobDescription";
this.NotesFN = m_TableName + ".Notes";
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
sSQL +=EmployeeIDFN;
sSQL += " , " + ExperienceIDFN;
sSQL += " , " + ExperienceTypeIDFN;
sSQL += " , " + CompanyNameFN;
sSQL += " , " + AddressFN;
sSQL += " , " + JobTitleIDFN;
sSQL += " , " + JobTitleFN;
sSQL += " , " + StartDateFN;
sSQL += " , " + EndDateFN;
sSQL += " , " + DirectManagerFN;
sSQL += " , " + JobDescriptionFN;
sSQL += " , " + NotesFN;
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
public string GetListSQL(string sCondition) 
{
string sSQL  = "";
try
{
sSQL = "SELECT ";
sSQL +=EmployeeIDFN;
sSQL += " , " + ExperienceIDFN;
sSQL += " , " + ExperienceTypeIDFN;
sSQL += "  FROM " + m_TableName;
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
string sSQL= "";
try
{
sSQL = "SELECT ";
sSQL +=EmployeeIDFN;
sSQL += " , " + ExperienceIDFN;
sSQL += " , " + ExperienceTypeIDFN;
sSQL += " , " + CompanyNameFN;
sSQL += " , " + AddressFN;
sSQL += " , " + JobTitleIDFN;
sSQL += " , " + JobTitleFN;
sSQL += " , " + StartDateFN;
sSQL += " , " + EndDateFN;
sSQL += " , " + DirectManagerFN;
sSQL += " , " + JobDescriptionFN;
sSQL += " , " + NotesFN;
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
sSQL += LibraryMOD.GetFieldName(EmployeeIDFN) + "=@EmployeeID";
sSQL += " , " + LibraryMOD.GetFieldName(ExperienceIDFN) + "=@ExperienceID";
sSQL += " , " + LibraryMOD.GetFieldName(ExperienceTypeIDFN) + "=@ExperienceTypeID";
sSQL += " , " + LibraryMOD.GetFieldName(CompanyNameFN) + "=@CompanyName";
sSQL += " , " + LibraryMOD.GetFieldName(AddressFN) + "=@Address";
sSQL += " , " + LibraryMOD.GetFieldName(JobTitleIDFN) + "=@JobTitleID";
sSQL += " , " + LibraryMOD.GetFieldName(JobTitleFN) + "=@JobTitle";
sSQL += " , " + LibraryMOD.GetFieldName(StartDateFN) + "=@StartDate";
sSQL += " , " + LibraryMOD.GetFieldName(EndDateFN) + "=@EndDate";
sSQL += " , " + LibraryMOD.GetFieldName(DirectManagerFN) + "=@DirectManager";
sSQL += " , " + LibraryMOD.GetFieldName(JobDescriptionFN) + "=@JobDescription";
sSQL += " , " + LibraryMOD.GetFieldName(NotesFN) + "=@Notes";
sSQL += " , " + LibraryMOD.GetFieldName(CreationUserIDFN) + "=@CreationUserID";
sSQL += " , " + LibraryMOD.GetFieldName(CreationDateFN) + "=@CreationDate";
sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateUserIDFN) + "=@LastUpdateUserID";
sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateDateFN) + "=@LastUpdateDate";
sSQL += " , " + LibraryMOD.GetFieldName(PCNameFN) + "=@PCName";
sSQL += " , " + LibraryMOD.GetFieldName(NetUserNameFN) + "=@NetUserName";
sSQL += " WHERE ";
sSQL += LibraryMOD.GetFieldName(EmployeeIDFN)+"=@EmployeeID";
sSQL +=  " And " + LibraryMOD.GetFieldName(ExperienceIDFN)+"=@ExperienceID";
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
sSQL +=LibraryMOD.GetFieldName(EmployeeIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(ExperienceIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(ExperienceTypeIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(CompanyNameFN);
sSQL += " , " + LibraryMOD.GetFieldName(AddressFN);
sSQL += " , " + LibraryMOD.GetFieldName(JobTitleIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(JobTitleFN);
sSQL += " , " + LibraryMOD.GetFieldName(StartDateFN);
sSQL += " , " + LibraryMOD.GetFieldName(EndDateFN);
sSQL += " , " + LibraryMOD.GetFieldName(DirectManagerFN);
sSQL += " , " + LibraryMOD.GetFieldName(JobDescriptionFN);
sSQL += " , " + LibraryMOD.GetFieldName(NotesFN);
sSQL += " , " + LibraryMOD.GetFieldName(CreationUserIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(CreationDateFN);
sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateUserIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateDateFN);
sSQL += " , " + LibraryMOD.GetFieldName(PCNameFN);
sSQL += " , " + LibraryMOD.GetFieldName(NetUserNameFN);
sSQL += ")";
sSQL += " VALUES ";
sSQL += "( ";
sSQL += " @EmployeeID";
sSQL += " ,@ExperienceID";
sSQL += " ,@ExperienceTypeID";
sSQL += " ,@CompanyName";
sSQL += " ,@Address";
sSQL += " ,@JobTitleID";
sSQL += " ,@JobTitle";
sSQL += " ,@StartDate";
sSQL += " ,@EndDate";
sSQL += " ,@DirectManager";
sSQL += " ,@JobDescription";
sSQL += " ,@Notes";
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
sSQL += LibraryMOD.GetFieldName(EmployeeIDFN)+"=@EmployeeID";
sSQL +=  " And " +  LibraryMOD.GetFieldName(ExperienceIDFN)+"=@ExperienceID";
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
public List< EmployeeExperiences> GetEmployeeExperiences(InitializeModule.EnumCampus Campus ,string sCondition,bool isDeafaultIncluded)
{
//' returns a list of Classes instances based on the
//' data in the EmployeeExperiences
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
List<EmployeeExperiences> results = new List<EmployeeExperiences>();
try
{
//Default Value
EmployeeExperiences myEmployeeExperiences = new EmployeeExperiences();
if (isDeafaultIncluded)
{
//Change the code here
myEmployeeExperiences.EmployeeID = 0;
myEmployeeExperiences.ExperienceID = 0;
myEmployeeExperiences.ExperienceTypeID = 0;
results.Add(myEmployeeExperiences);
}
while (reader.Read())
{
myEmployeeExperiences = new EmployeeExperiences();
if (reader[LibraryMOD.GetFieldName(EmployeeIDFN)].Equals(DBNull.Value))
{
myEmployeeExperiences.EmployeeID = 0;
}
else
{
myEmployeeExperiences.EmployeeID = int.Parse(reader[LibraryMOD.GetFieldName( EmployeeIDFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(ExperienceIDFN)].Equals(DBNull.Value))
{
myEmployeeExperiences.ExperienceID = 0;
}
else
{
myEmployeeExperiences.ExperienceID = int.Parse(reader[LibraryMOD.GetFieldName( ExperienceIDFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(ExperienceTypeIDFN)].Equals(DBNull.Value))
{
myEmployeeExperiences.ExperienceTypeID = 0;
}
else
{
myEmployeeExperiences.ExperienceTypeID = int.Parse(reader[LibraryMOD.GetFieldName( ExperienceTypeIDFN) ].ToString());
}
myEmployeeExperiences.CompanyName =reader[LibraryMOD.GetFieldName( CompanyNameFN) ].ToString();
myEmployeeExperiences.Address =reader[LibraryMOD.GetFieldName( AddressFN) ].ToString();
if (reader[LibraryMOD.GetFieldName(JobTitleIDFN)].Equals(DBNull.Value))
{
myEmployeeExperiences.JobTitleID = 0;
}
else
{
myEmployeeExperiences.JobTitleID = int.Parse(reader[LibraryMOD.GetFieldName( JobTitleIDFN) ].ToString());
}
myEmployeeExperiences.JobTitle =reader[LibraryMOD.GetFieldName( JobTitleFN) ].ToString();
myEmployeeExperiences.StartDate =reader[LibraryMOD.GetFieldName( StartDateFN) ].ToString();
myEmployeeExperiences.EndDate =reader[LibraryMOD.GetFieldName( EndDateFN) ].ToString();
myEmployeeExperiences.DirectManager =reader[LibraryMOD.GetFieldName( DirectManagerFN) ].ToString();
myEmployeeExperiences.JobDescription =reader[LibraryMOD.GetFieldName( JobDescriptionFN) ].ToString();
myEmployeeExperiences.Notes =reader[LibraryMOD.GetFieldName( NotesFN) ].ToString();
if (reader[LibraryMOD.GetFieldName(CreationUserIDFN)].Equals(DBNull.Value))
{
myEmployeeExperiences.CreationUserID = 0;
}
else
{
myEmployeeExperiences.CreationUserID = int.Parse(reader[LibraryMOD.GetFieldName( CreationUserIDFN) ].ToString());
}
if (!reader[LibraryMOD.GetFieldName(CreationDateFN)].Equals(DBNull.Value))
{
myEmployeeExperiences.CreationDate = DateTime.Parse(reader[LibraryMOD.GetFieldName( CreationDateFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(LastUpdateUserIDFN)].Equals(DBNull.Value))
{
myEmployeeExperiences.LastUpdateUserID = 0;
}
else
{
myEmployeeExperiences.LastUpdateUserID = int.Parse(reader[LibraryMOD.GetFieldName( LastUpdateUserIDFN) ].ToString());
}
if (!reader[LibraryMOD.GetFieldName(LastUpdateDateFN)].Equals(DBNull.Value))
{
myEmployeeExperiences.LastUpdateDate = DateTime.Parse(reader[LibraryMOD.GetFieldName( LastUpdateDateFN) ].ToString());
}
myEmployeeExperiences.PCName =reader[LibraryMOD.GetFieldName( PCNameFN) ].ToString();
myEmployeeExperiences.NetUserName =reader[LibraryMOD.GetFieldName( NetUserNameFN) ].ToString();
 results.Add(myEmployeeExperiences);
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
public List< EmployeeExperiences > GetList(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
{
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
string sSQL = GetListSQL(sCondition);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
SqlCommand Cmd = new SqlCommand(sSQL, Conn);
Conn.Open();
SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
List<EmployeeExperiences> results = new List<EmployeeExperiences>();
try
{
//Default Value
EmployeeExperiences myEmployeeExperiences= new EmployeeExperiences();
if (isDeafaultIncluded) 
 {
//Change the code here
 myEmployeeExperiences.EmployeeID = -1;
 myEmployeeExperiences.ExperienceID = 0 ;
results.Add(myEmployeeExperiences);
 }
while (reader.Read())
{
myEmployeeExperiences = new EmployeeExperiences();
if (reader[LibraryMOD.GetFieldName(EmployeeIDFN)].Equals(DBNull.Value))
{
myEmployeeExperiences.EmployeeID = 0;
}
else
{
myEmployeeExperiences.EmployeeID = int.Parse(reader[LibraryMOD.GetFieldName( EmployeeIDFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(ExperienceIDFN)].Equals(DBNull.Value))
{
myEmployeeExperiences.ExperienceID = 0;
}
else
{
myEmployeeExperiences.ExperienceID = int.Parse(reader[LibraryMOD.GetFieldName( ExperienceIDFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(ExperienceTypeIDFN)].Equals(DBNull.Value))
{
myEmployeeExperiences.ExperienceTypeID = 0;
}
else
{
myEmployeeExperiences.ExperienceTypeID = int.Parse(reader[LibraryMOD.GetFieldName( ExperienceTypeIDFN) ].ToString());
}
 results.Add(myEmployeeExperiences);
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
public int UpdateEmployeeExperiences(InitializeModule.EnumCampus Campus, int iMode,int EmployeeID,int ExperienceID,int ExperienceTypeID,string CompanyName,string Address,int JobTitleID,string JobTitle,string StartDate,string EndDate,string DirectManager,string JobDescription,string Notes,int CreationUserID,DateTime CreationDate,int LastUpdateUserID,DateTime LastUpdateDate,string PCName,string NetUserName)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
Conn.Open();
string sql = "";
EmployeeExperiences theEmployeeExperiences = new EmployeeExperiences();
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
Cmd.Parameters.Add(new SqlParameter("@EmployeeID",EmployeeID));
Cmd.Parameters.Add(new SqlParameter("@ExperienceID",ExperienceID));
Cmd.Parameters.Add(new SqlParameter("@ExperienceTypeID",ExperienceTypeID));
Cmd.Parameters.Add(new SqlParameter("@CompanyName",CompanyName));
Cmd.Parameters.Add(new SqlParameter("@Address",Address));
Cmd.Parameters.Add(new SqlParameter("@JobTitleID",JobTitleID));
Cmd.Parameters.Add(new SqlParameter("@JobTitle",JobTitle));
Cmd.Parameters.Add(new SqlParameter("@StartDate",StartDate));
Cmd.Parameters.Add(new SqlParameter("@EndDate",EndDate));
Cmd.Parameters.Add(new SqlParameter("@DirectManager",DirectManager));
Cmd.Parameters.Add(new SqlParameter("@JobDescription",JobDescription));
Cmd.Parameters.Add(new SqlParameter("@Notes",Notes));
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
public int DeleteEmployeeExperiences(InitializeModule.EnumCampus Campus,string EmployeeID,string ExperienceID)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
string sSQL = GetDeleteCommand();
//sSQL += sCondition;
SqlCommand Cmd = new SqlCommand(sSQL, Conn);
Cmd.Parameters.Add(new SqlParameter("@EmployeeID", EmployeeID ));
Cmd.Parameters.Add(new SqlParameter("@ExperienceID", ExperienceID ));
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
DataTable dt = new DataTable("EmployeeExperiences");
DataView dv = new DataView();
List<EmployeeExperiences> myEmployeeExperiencess = new List<EmployeeExperiences>();
try
{
myEmployeeExperiencess = GetEmployeeExperiences(InitializeModule.EnumCampus.ECTNew,sCondition,false);
DataColumn col1= new DataColumn("EmployeeID", Type.GetType("int"));
dt.Columns.Add(col1 );
DataColumn col2= new DataColumn("ExperienceID", Type.GetType("int"));
dt.Columns.Add(col2 );
DataColumn col3= new DataColumn("ExperienceTypeID", Type.GetType("int"));
dt.Columns.Add(col3 );
dt.Constraints.Add(new UniqueConstraint(col1));
dt.Constraints.Add(new UniqueConstraint(col2));

DataRow dr;
for (int i = 0; i < myEmployeeExperiencess.Count; i++)
{
dr = dt.NewRow();
  dr[1] = myEmployeeExperiencess[i].EmployeeID;
  dr[2] = myEmployeeExperiencess[i].ExperienceID;
  dr[3] = myEmployeeExperiencess[i].ExperienceTypeID;
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
myEmployeeExperiencess.Clear();
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
sSQL += EmployeeIDFN;
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
public class EmployeeExperiencesCls : EmployeeExperiencesDAL
{
#region "Decleration"
private int m_lngCurRow=0;
public SqlDataAdapter daEmployeeExperiences;
private DataSet m_dsEmployeeExperiences;
public DataRow EmployeeExperiencesDataRow ;
#endregion
#region "Puplic Properties"
public DataSet dsEmployeeExperiences
{
get { return m_dsEmployeeExperiences ; }
set { m_dsEmployeeExperiences = value ; }
}
//-----------------------------------------------------
public int lngCurRow 
{
get { return  m_lngCurRow ; }
set {m_lngCurRow = value ; }
}
#endregion
public EmployeeExperiencesCls()
{
try
{
dsEmployeeExperiences= new DataSet();

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
public virtual SqlDataAdapter GetEmployeeExperiencesDataAdapter(string sCondition ,SqlConnection con ) 
{
string sSQL =""; 
try
{
sSQL = GetSQL();
sSQL += " " + sCondition;
//-----------------------------------------
daEmployeeExperiences = new SqlDataAdapter(sSQL, con);
// Create command builder. This line automatically generates the update commands for you, so you don't
// have to provide or create your own.
SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daEmployeeExperiences);
//Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
// key + unique key information to be retrieved unless AddWithKey is specified.
daEmployeeExperiences.MissingSchemaAction = MissingSchemaAction.AddWithKey;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daEmployeeExperiences;
}
public virtual SqlDataAdapter GetEmployeeExperiencesDataAdapter(SqlConnection con)  
{
try
{
daEmployeeExperiences = new SqlDataAdapter();
//''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
//'' key + unique key information to be retrieved unless AddWithKey is specified.
daEmployeeExperiences.MissingSchemaAction = MissingSchemaAction.AddWithKey;
//-----------------------------------------
SqlParameter Parmeter = default(SqlParameter); 
//[SELECT COMMAND]
SqlCommand cmdEmployeeExperiences;
cmdEmployeeExperiences = new SqlCommand(GetSelectCommand(), con);
//'cmdRolePermission.Parameters.Add("@EmployeeID", SqlDbType.Int, 4, "EmployeeID" );
//'cmdRolePermission.Parameters.Add("@ExperienceID", SqlDbType.Int, 4, "ExperienceID" );
daEmployeeExperiences.SelectCommand = cmdEmployeeExperiences;
//'Add Handlers
//'RowUpdating,RowUpdated
AddDAEventHandler();
//'[UPDATE COMMAND].
cmdEmployeeExperiences = new SqlCommand(GetUpdateCommand(), con);
//'Delete PK Parameteres from here. b/c its declared below
cmdEmployeeExperiences.Parameters.Add("@EmployeeID", SqlDbType.Int,4, LibraryMOD.GetFieldName(EmployeeIDFN));
cmdEmployeeExperiences.Parameters.Add("@ExperienceID", SqlDbType.Int,4, LibraryMOD.GetFieldName(ExperienceIDFN));
cmdEmployeeExperiences.Parameters.Add("@ExperienceTypeID", SqlDbType.Int,4, LibraryMOD.GetFieldName(ExperienceTypeIDFN));
cmdEmployeeExperiences.Parameters.Add("@CompanyName", SqlDbType.NVarChar,120, LibraryMOD.GetFieldName(CompanyNameFN));
cmdEmployeeExperiences.Parameters.Add("@Address", SqlDbType.NVarChar,200, LibraryMOD.GetFieldName(AddressFN));
cmdEmployeeExperiences.Parameters.Add("@JobTitleID", SqlDbType.Int,4, LibraryMOD.GetFieldName(JobTitleIDFN));
cmdEmployeeExperiences.Parameters.Add("@JobTitle", SqlDbType.VarChar,50, LibraryMOD.GetFieldName(JobTitleFN));
cmdEmployeeExperiences.Parameters.Add("@StartDate", SqlDbType.VarChar,10, LibraryMOD.GetFieldName(StartDateFN));
cmdEmployeeExperiences.Parameters.Add("@EndDate", SqlDbType.VarChar,10, LibraryMOD.GetFieldName(EndDateFN));
cmdEmployeeExperiences.Parameters.Add("@DirectManager", SqlDbType.VarChar,50, LibraryMOD.GetFieldName(DirectManagerFN));
cmdEmployeeExperiences.Parameters.Add("@JobDescription", SqlDbType.VarChar,1000, LibraryMOD.GetFieldName(JobDescriptionFN));
cmdEmployeeExperiences.Parameters.Add("@Notes", SqlDbType.NVarChar,1000, LibraryMOD.GetFieldName(NotesFN));
cmdEmployeeExperiences.Parameters.Add("@CreationUserID", SqlDbType.Int,4, LibraryMOD.GetFieldName(CreationUserIDFN));
cmdEmployeeExperiences.Parameters.Add("@CreationDate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(CreationDateFN));
cmdEmployeeExperiences.Parameters.Add("@LastUpdateUserID", SqlDbType.Int,4, LibraryMOD.GetFieldName(LastUpdateUserIDFN));
cmdEmployeeExperiences.Parameters.Add("@LastUpdateDate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(LastUpdateDateFN));
cmdEmployeeExperiences.Parameters.Add("@PCName", SqlDbType.NVarChar,32, LibraryMOD.GetFieldName(PCNameFN));
cmdEmployeeExperiences.Parameters.Add("@NetUserName", SqlDbType.NVarChar,32, LibraryMOD.GetFieldName(NetUserNameFN));


Parmeter = cmdEmployeeExperiences.Parameters.Add("@EmployeeID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(EmployeeIDFN));
Parmeter = cmdEmployeeExperiences.Parameters.Add("@ExperienceID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(ExperienceIDFN));
Parmeter.SourceVersion = DataRowVersion.Original;
//'Its should be none for batch updating
//'UpdateCommand, InsertCommand, and DeleteCommand 
//'should be set to None or OutputParameters
daEmployeeExperiences.UpdateCommand = cmdEmployeeExperiences;
daEmployeeExperiences.UpdateCommand.UpdatedRowSource  = UpdateRowSource.None ;
//'-------------------------------------------------------------------------
//'/INSERT COMMAND
 cmdEmployeeExperiences = new SqlCommand(GetInsertCommand(), con);
cmdEmployeeExperiences.Parameters.Add("@EmployeeID", SqlDbType.Int,4, LibraryMOD.GetFieldName(EmployeeIDFN));
cmdEmployeeExperiences.Parameters.Add("@ExperienceID", SqlDbType.Int,4, LibraryMOD.GetFieldName(ExperienceIDFN));
cmdEmployeeExperiences.Parameters.Add("@ExperienceTypeID", SqlDbType.Int,4, LibraryMOD.GetFieldName(ExperienceTypeIDFN));
cmdEmployeeExperiences.Parameters.Add("@CompanyName", SqlDbType.NVarChar,120, LibraryMOD.GetFieldName(CompanyNameFN));
cmdEmployeeExperiences.Parameters.Add("@Address", SqlDbType.NVarChar,200, LibraryMOD.GetFieldName(AddressFN));
cmdEmployeeExperiences.Parameters.Add("@JobTitleID", SqlDbType.Int,4, LibraryMOD.GetFieldName(JobTitleIDFN));
cmdEmployeeExperiences.Parameters.Add("@JobTitle", SqlDbType.VarChar,50, LibraryMOD.GetFieldName(JobTitleFN));
cmdEmployeeExperiences.Parameters.Add("@StartDate", SqlDbType.VarChar,10, LibraryMOD.GetFieldName(StartDateFN));
cmdEmployeeExperiences.Parameters.Add("@EndDate", SqlDbType.VarChar,10, LibraryMOD.GetFieldName(EndDateFN));
cmdEmployeeExperiences.Parameters.Add("@DirectManager", SqlDbType.VarChar,50, LibraryMOD.GetFieldName(DirectManagerFN));
cmdEmployeeExperiences.Parameters.Add("@JobDescription", SqlDbType.VarChar,1000, LibraryMOD.GetFieldName(JobDescriptionFN));
cmdEmployeeExperiences.Parameters.Add("@Notes", SqlDbType.NVarChar,1000, LibraryMOD.GetFieldName(NotesFN));
cmdEmployeeExperiences.Parameters.Add("@CreationUserID", SqlDbType.Int,4, LibraryMOD.GetFieldName(CreationUserIDFN));
cmdEmployeeExperiences.Parameters.Add("@CreationDate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(CreationDateFN));
cmdEmployeeExperiences.Parameters.Add("@LastUpdateUserID", SqlDbType.Int,4, LibraryMOD.GetFieldName(LastUpdateUserIDFN));
cmdEmployeeExperiences.Parameters.Add("@LastUpdateDate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(LastUpdateDateFN));
cmdEmployeeExperiences.Parameters.Add("@PCName", SqlDbType.NVarChar,32, LibraryMOD.GetFieldName(PCNameFN));
cmdEmployeeExperiences.Parameters.Add("@NetUserName", SqlDbType.NVarChar,32, LibraryMOD.GetFieldName(NetUserNameFN));
Parmeter.SourceVersion = DataRowVersion.Current;
daEmployeeExperiences.InsertCommand =cmdEmployeeExperiences;
daEmployeeExperiences.InsertCommand.UpdatedRowSource  = UpdateRowSource.None;
//'------------------------
//'/DELETE COMMAND
 cmdEmployeeExperiences = new SqlCommand(GetDeleteCommand(), con);
Parmeter = cmdEmployeeExperiences.Parameters.Add("@EmployeeID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(EmployeeIDFN));
Parmeter = cmdEmployeeExperiences.Parameters.Add("@ExperienceID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(ExperienceIDFN));
Parmeter.SourceVersion = DataRowVersion.Original;
daEmployeeExperiences.DeleteCommand =cmdEmployeeExperiences;
daEmployeeExperiences.DeleteCommand.UpdatedRowSource  = UpdateRowSource.None;
//'Batch Size
//'Set the batch size.
daEmployeeExperiences.UpdateBatchSize = ECTGlobalDll.InitializeModule.BATCH_SIZE;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daEmployeeExperiences;
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
dr = dsEmployeeExperiences.Tables[TableName].NewRow();
dr[LibraryMOD.GetFieldName(EmployeeIDFN)]=EmployeeID;
dr[LibraryMOD.GetFieldName(ExperienceIDFN)]=ExperienceID;
dr[LibraryMOD.GetFieldName(ExperienceTypeIDFN)]=ExperienceTypeID;
dr[LibraryMOD.GetFieldName(CompanyNameFN)]=CompanyName;
dr[LibraryMOD.GetFieldName(AddressFN)]=Address;
dr[LibraryMOD.GetFieldName(JobTitleIDFN)]=JobTitleID;
dr[LibraryMOD.GetFieldName(JobTitleFN)]=JobTitle;
dr[LibraryMOD.GetFieldName(StartDateFN)]=StartDate;
dr[LibraryMOD.GetFieldName(EndDateFN)]=EndDate;
dr[LibraryMOD.GetFieldName(DirectManagerFN)]=DirectManager;
dr[LibraryMOD.GetFieldName(JobDescriptionFN)]=JobDescription;
dr[LibraryMOD.GetFieldName(NotesFN)]=Notes;
dsEmployeeExperiences.Tables[TableName].Rows.Add(dr);
break;
case (int)ECTGlobalDll.InitializeModule.enumModes.EditMode:
 DataRow[] drAry = null;
drAry = dsEmployeeExperiences.Tables[TableName].Select(LibraryMOD.GetFieldName(EmployeeIDFN)  + "=" + EmployeeID  + " AND " + LibraryMOD.GetFieldName(ExperienceIDFN) + "=" + ExperienceID);
//'its return array of rows and we can access the first by index 0
drAry[0][LibraryMOD.GetFieldName(EmployeeIDFN)]=EmployeeID;
drAry[0][LibraryMOD.GetFieldName(ExperienceIDFN)]=ExperienceID;
drAry[0][LibraryMOD.GetFieldName(ExperienceTypeIDFN)]=ExperienceTypeID;
drAry[0][LibraryMOD.GetFieldName(CompanyNameFN)]=CompanyName;
drAry[0][LibraryMOD.GetFieldName(AddressFN)]=Address;
drAry[0][LibraryMOD.GetFieldName(JobTitleIDFN)]=JobTitleID;
drAry[0][LibraryMOD.GetFieldName(JobTitleFN)]=JobTitle;
drAry[0][LibraryMOD.GetFieldName(StartDateFN)]=StartDate;
drAry[0][LibraryMOD.GetFieldName(EndDateFN)]=EndDate;
drAry[0][LibraryMOD.GetFieldName(DirectManagerFN)]=DirectManager;
drAry[0][LibraryMOD.GetFieldName(JobDescriptionFN)]=JobDescription;
drAry[0][LibraryMOD.GetFieldName(NotesFN)]=Notes;
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
public int CommitEmployeeExperiences()  
{
//CommitEmployeeExperiences= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
//'' Update Database with SqlDataAdapter
daEmployeeExperiences.Update(dsEmployeeExperiences, TableName);
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
FindInMultiPKey(EmployeeID,ExperienceID);
if (( EmployeeExperiencesDataRow != null)) 
{
EmployeeExperiencesDataRow.Delete();
CommitEmployeeExperiences();
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
if (EmployeeExperiencesDataRow[LibraryMOD.GetFieldName(EmployeeIDFN)]== System.DBNull.Value)
{
  EmployeeID=0;
}
else
{
  EmployeeID = (int)EmployeeExperiencesDataRow[LibraryMOD.GetFieldName(EmployeeIDFN)];
}
if (EmployeeExperiencesDataRow[LibraryMOD.GetFieldName(ExperienceIDFN)]== System.DBNull.Value)
{
  ExperienceID=0;
}
else
{
  ExperienceID = (int)EmployeeExperiencesDataRow[LibraryMOD.GetFieldName(ExperienceIDFN)];
}
if (EmployeeExperiencesDataRow[LibraryMOD.GetFieldName(ExperienceTypeIDFN)]== System.DBNull.Value)
{
  ExperienceTypeID=0;
}
else
{
  ExperienceTypeID = (int)EmployeeExperiencesDataRow[LibraryMOD.GetFieldName(ExperienceTypeIDFN)];
}
if (EmployeeExperiencesDataRow[LibraryMOD.GetFieldName(CompanyNameFN)]== System.DBNull.Value)
{
  CompanyName="";
}
else
{
  CompanyName = (string)EmployeeExperiencesDataRow[LibraryMOD.GetFieldName(CompanyNameFN)];
}
if (EmployeeExperiencesDataRow[LibraryMOD.GetFieldName(AddressFN)]== System.DBNull.Value)
{
  Address="";
}
else
{
  Address = (string)EmployeeExperiencesDataRow[LibraryMOD.GetFieldName(AddressFN)];
}
if (EmployeeExperiencesDataRow[LibraryMOD.GetFieldName(JobTitleIDFN)]== System.DBNull.Value)
{
  JobTitleID=0;
}
else
{
  JobTitleID = (int)EmployeeExperiencesDataRow[LibraryMOD.GetFieldName(JobTitleIDFN)];
}
if (EmployeeExperiencesDataRow[LibraryMOD.GetFieldName(JobTitleFN)]== System.DBNull.Value)
{
  JobTitle="";
}
else
{
  JobTitle = (string)EmployeeExperiencesDataRow[LibraryMOD.GetFieldName(JobTitleFN)];
}
if (EmployeeExperiencesDataRow[LibraryMOD.GetFieldName(StartDateFN)]== System.DBNull.Value)
{
  StartDate="";
}
else
{
  StartDate = (string)EmployeeExperiencesDataRow[LibraryMOD.GetFieldName(StartDateFN)];
}
if (EmployeeExperiencesDataRow[LibraryMOD.GetFieldName(EndDateFN)]== System.DBNull.Value)
{
  EndDate="";
}
else
{
  EndDate = (string)EmployeeExperiencesDataRow[LibraryMOD.GetFieldName(EndDateFN)];
}
if (EmployeeExperiencesDataRow[LibraryMOD.GetFieldName(DirectManagerFN)]== System.DBNull.Value)
{
  DirectManager="";
}
else
{
  DirectManager = (string)EmployeeExperiencesDataRow[LibraryMOD.GetFieldName(DirectManagerFN)];
}
if (EmployeeExperiencesDataRow[LibraryMOD.GetFieldName(JobDescriptionFN)]== System.DBNull.Value)
{
  JobDescription="";
}
else
{
  JobDescription = (string)EmployeeExperiencesDataRow[LibraryMOD.GetFieldName(JobDescriptionFN)];
}
if (EmployeeExperiencesDataRow[LibraryMOD.GetFieldName(NotesFN)]== System.DBNull.Value)
{
  Notes="";
}
else
{
  Notes = (string)EmployeeExperiencesDataRow[LibraryMOD.GetFieldName(NotesFN)];
}
if (EmployeeExperiencesDataRow[LibraryMOD.GetFieldName(CreationUserIDFN)]== System.DBNull.Value)
{
  CreationUserID=0;
}
else
{
  CreationUserID = (int)EmployeeExperiencesDataRow[LibraryMOD.GetFieldName(CreationUserIDFN)];
}
if (EmployeeExperiencesDataRow[LibraryMOD.GetFieldName(CreationDateFN)]== System.DBNull.Value)
{
}
else
{
  CreationDate = (DateTime)EmployeeExperiencesDataRow[LibraryMOD.GetFieldName(CreationDateFN)];
}
if (EmployeeExperiencesDataRow[LibraryMOD.GetFieldName(LastUpdateUserIDFN)]== System.DBNull.Value)
{
  LastUpdateUserID=0;
}
else
{
  LastUpdateUserID = (int)EmployeeExperiencesDataRow[LibraryMOD.GetFieldName(LastUpdateUserIDFN)];
}
if (EmployeeExperiencesDataRow[LibraryMOD.GetFieldName(LastUpdateDateFN)]== System.DBNull.Value)
{
}
else
{
  LastUpdateDate = (DateTime)EmployeeExperiencesDataRow[LibraryMOD.GetFieldName(LastUpdateDateFN)];
}
if (EmployeeExperiencesDataRow[LibraryMOD.GetFieldName(PCNameFN)]== System.DBNull.Value)
{
  PCName="";
}
else
{
  PCName = (string)EmployeeExperiencesDataRow[LibraryMOD.GetFieldName(PCNameFN)];
}
if (EmployeeExperiencesDataRow[LibraryMOD.GetFieldName(NetUserNameFN)]== System.DBNull.Value)
{
  NetUserName="";
}
else
{
  NetUserName = (string)EmployeeExperiencesDataRow[LibraryMOD.GetFieldName(NetUserNameFN)];
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
public int FindInMultiPKey(int PKEmployeeID,int PKExperienceID) 
{
//FindInMultiPKey= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
//' Create an array for the key values to find.
object[] findTheseVals = new object[1] ; 
//' Set the values of the keys to find.
findTheseVals[0] = PKEmployeeID;
findTheseVals[1] = PKExperienceID;
EmployeeExperiencesDataRow = dsEmployeeExperiences.Tables[TableName].Rows.Find(findTheseVals);
if  ((EmployeeExperiencesDataRow !=null)) 
{
lngCurRow = dsEmployeeExperiences.Tables[TableName].Rows.IndexOf(EmployeeExperiencesDataRow);
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
  lngCurRow = dsEmployeeExperiences.Tables[TableName].Rows.Count - 1; //'Zero based index
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
  lngCurRow = Math.Min(lngCurRow + 1, dsEmployeeExperiences.Tables[TableName].Rows.Count - 1);
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
  if (lngCurRow >= 0 & dsEmployeeExperiences.Tables[TableName].Rows.Count > 0) 
{
  EmployeeExperiencesDataRow = dsEmployeeExperiences.Tables[TableName].Rows[lngCurRow];
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
daEmployeeExperiences.RowUpdating+= new SqlRowUpdatingEventHandler(OnRowUpdating);
daEmployeeExperiences.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
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
daEmployeeExperiences.RowUpdating-= new SqlRowUpdatingEventHandler(OnRowUpdating);
daEmployeeExperiences.RowUpdated-= new SqlRowUpdatedEventHandler(OnRowUpdated);
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
