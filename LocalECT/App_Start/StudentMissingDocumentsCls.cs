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
public class StudentMissingDocuments
{
//Creation Date: 10/05/2010 10:20 AM
//Programmer Name : 
//-----Decleration --------------
#region "Decleration"
private int m_StudentSerialNo; 
private int m_MissingDocumentID; 
private int m_CreationUserID; 
private DateTime m_CreationDate; 
private int m_LastUpdateUserID; 
private DateTime m_LastUpdateDate; 
private string m_PCName; 
private string m_NetUserName; 
#endregion
#region "Puplic Properties"
//'-----------------------------------------------------
public int StudentSerialNo
{
get { return  m_StudentSerialNo; }
set {m_StudentSerialNo  = value ; }
}
public int MissingDocumentID
{
get { return  m_MissingDocumentID; }
set {m_MissingDocumentID  = value ; }
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
public StudentMissingDocuments()
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
public class StudentMissingDocumentsDAL : StudentMissingDocuments
{
#region "Decleration"
private string m_TableName;
private string m_StudentSerialNoFN ;
private string m_MissingDocumentIDFN ;
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
public string StudentSerialNoFN 
{
get { return  m_StudentSerialNoFN; }
set {m_StudentSerialNoFN  = value ; }
}
public string MissingDocumentIDFN 
{
get { return  m_MissingDocumentIDFN; }
set {m_MissingDocumentIDFN  = value ; }
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
public StudentMissingDocumentsDAL()
{
try
{
this.TableName = "Reg_StudentMissingDocuments";
this.StudentSerialNoFN = m_TableName + ".StudentSerialNo";
this.MissingDocumentIDFN = m_TableName + ".MissingDocumentID";
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
sSQL +=StudentSerialNoFN;
sSQL += " , " + MissingDocumentIDFN;
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
public string GetListSQL(string sCond)
{
    string sSQL = "";
    try
    {
        sSQL = "SELECT ";
        sSQL += StudentSerialNoFN;
        sSQL += " , " + MissingDocumentIDFN;

        sSQL += "  FROM " + m_TableName;
        sSQL += "  WHERE 1=1";
        if (sCond.Length > 0)
        {
            sSQL += sCond;
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

//-----Get GetSelectCommand Function -----------------------
public string GetSelectCommand() 
{
string sSQL= "";
try
{
sSQL = "SELECT ";
sSQL +=StudentSerialNoFN;
sSQL += " , " + MissingDocumentIDFN;
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
sSQL += LibraryMOD.GetFieldName(StudentSerialNoFN) + "=@StudentSerialNo";
sSQL += " , " + LibraryMOD.GetFieldName(MissingDocumentIDFN) + "=@MissingDocumentID";
sSQL += " , " + LibraryMOD.GetFieldName(CreationUserIDFN) + "=@CreationUserID";
sSQL += " , " + LibraryMOD.GetFieldName(CreationDateFN) + "=@CreationDate";
sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateUserIDFN) + "=@LastUpdateUserID";
sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateDateFN) + "=@LastUpdateDate";
sSQL += " , " + LibraryMOD.GetFieldName(PCNameFN) + "=@PCName";
sSQL += " , " + LibraryMOD.GetFieldName(NetUserNameFN) + "=@NetUserName";
sSQL += " WHERE ";
sSQL += LibraryMOD.GetFieldName(StudentSerialNoFN)+"=@StudentSerialNo";
sSQL +=  " And " + LibraryMOD.GetFieldName(MissingDocumentIDFN)+"=@MissingDocumentID";
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
sSQL +=LibraryMOD.GetFieldName(StudentSerialNoFN);
sSQL += " , " + LibraryMOD.GetFieldName(MissingDocumentIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(CreationUserIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(CreationDateFN);
sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateUserIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateDateFN);
sSQL += " , " + LibraryMOD.GetFieldName(PCNameFN);
sSQL += " , " + LibraryMOD.GetFieldName(NetUserNameFN);
sSQL += ")";
sSQL += " VALUES ";
sSQL += "( ";
sSQL += " @StudentSerialNo";
sSQL += " ,@MissingDocumentID";
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
sSQL += LibraryMOD.GetFieldName(StudentSerialNoFN)+"=@StudentSerialNo";
sSQL +=  " And " +  LibraryMOD.GetFieldName(MissingDocumentIDFN)+"=@MissingDocumentID";
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
public string GetDeleteAllCommand()
{
    string sSQL = "";
    try
    {
        sSQL = "DELETE FROM " + TableName;
        sSQL += " WHERE ";
        sSQL += LibraryMOD.GetFieldName(StudentSerialNoFN) + "=@StudentSerialNo";
        
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
public List< StudentMissingDocuments> GetStudentMissingDocuments(InitializeModule.EnumCampus Campus ,string sCondition,bool isDeafaultIncluded)
{
//' returns a list of Classes instances based on the
//' data in the StudentMissingDocuments
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
List<StudentMissingDocuments> results = new List<StudentMissingDocuments>();
try
{
//Default Value
StudentMissingDocuments myStudentMissingDocuments = new StudentMissingDocuments();
if (isDeafaultIncluded)
{
//Change the code here
myStudentMissingDocuments.StudentSerialNo = 0;
myStudentMissingDocuments.MissingDocumentID = 0;

    results.Add(myStudentMissingDocuments);
}
while (reader.Read())
{
myStudentMissingDocuments = new StudentMissingDocuments();
if (reader[LibraryMOD.GetFieldName(StudentSerialNoFN)].Equals(DBNull.Value))
{
myStudentMissingDocuments.StudentSerialNo = 0;
}
else
{
myStudentMissingDocuments.StudentSerialNo = int.Parse(reader[LibraryMOD.GetFieldName( StudentSerialNoFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(MissingDocumentIDFN)].Equals(DBNull.Value))
{
myStudentMissingDocuments.MissingDocumentID = 0;
}
else
{
myStudentMissingDocuments.MissingDocumentID = int.Parse(reader[LibraryMOD.GetFieldName( MissingDocumentIDFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(CreationUserIDFN)].Equals(DBNull.Value))
{
myStudentMissingDocuments.CreationUserID = 0;
}
else
{
myStudentMissingDocuments.CreationUserID = int.Parse(reader[LibraryMOD.GetFieldName( CreationUserIDFN) ].ToString());
}
if (!reader[LibraryMOD.GetFieldName(CreationDateFN)].Equals(DBNull.Value))
{
myStudentMissingDocuments.CreationDate = DateTime.Parse(reader[LibraryMOD.GetFieldName( CreationDateFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(LastUpdateUserIDFN)].Equals(DBNull.Value))
{
myStudentMissingDocuments.LastUpdateUserID = 0;
}
else
{
myStudentMissingDocuments.LastUpdateUserID = int.Parse(reader[LibraryMOD.GetFieldName( LastUpdateUserIDFN) ].ToString());
}
if (!reader[LibraryMOD.GetFieldName(LastUpdateDateFN)].Equals(DBNull.Value))
{
myStudentMissingDocuments.LastUpdateDate = DateTime.Parse(reader[LibraryMOD.GetFieldName( LastUpdateDateFN) ].ToString());
}
myStudentMissingDocuments.PCName =reader[LibraryMOD.GetFieldName( PCNameFN) ].ToString();
myStudentMissingDocuments.NetUserName =reader[LibraryMOD.GetFieldName( NetUserNameFN) ].ToString();
 results.Add(myStudentMissingDocuments);
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
    public List< StudentMissingDocuments > GetList(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
{
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
string sSQL = GetListSQL(sCondition);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
SqlCommand Cmd = new SqlCommand(sSQL, Conn);
Conn.Open();
SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
List<StudentMissingDocuments> results = new List<StudentMissingDocuments>();
try
{
//Default Value
    StudentMissingDocuments myStudentMissingDocuments = new StudentMissingDocuments();
if (isDeafaultIncluded) 
 {
//Change the code here
 myStudentMissingDocuments.StudentSerialNo = -1;
 myStudentMissingDocuments.MissingDocumentID = 0;
results.Add(myStudentMissingDocuments);
 }
while (reader.Read())
{
myStudentMissingDocuments = new StudentMissingDocuments();
if (reader[LibraryMOD.GetFieldName(StudentSerialNoFN)].Equals(DBNull.Value))
{
myStudentMissingDocuments.StudentSerialNo = 0;
}
else
{
myStudentMissingDocuments.StudentSerialNo = int.Parse(reader[LibraryMOD.GetFieldName( StudentSerialNoFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(MissingDocumentIDFN)].Equals(DBNull.Value))
{
myStudentMissingDocuments.MissingDocumentID = 0;
}
else
{
myStudentMissingDocuments.MissingDocumentID = int.Parse(reader[LibraryMOD.GetFieldName( MissingDocumentIDFN) ].ToString());
}


 results.Add(myStudentMissingDocuments);
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

public int UpdateStudentMissingDocuments(InitializeModule.EnumCampus Campus, int iMode,int StudentSerialNo,int MissingDocumentID,int CreationUserID,DateTime CreationDate,int LastUpdateUserID,DateTime LastUpdateDate,string PCName,string NetUserName)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
Conn.Open();
string sql = "";
StudentMissingDocuments theStudentMissingDocuments = new StudentMissingDocuments();
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
Cmd.Parameters.Add(new SqlParameter("@StudentSerialNo",StudentSerialNo));
Cmd.Parameters.Add(new SqlParameter("@MissingDocumentID",MissingDocumentID));
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
public int DeleteStudentMissingDocuments(InitializeModule.EnumCampus Campus,int StudentSerialNo,int MissingDocumentID)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
string sSQL = GetDeleteCommand();
//sSQL += sCondition;
SqlCommand Cmd = new SqlCommand(sSQL, Conn);
Cmd.Parameters.Add(new SqlParameter("@StudentSerialNo", StudentSerialNo ));
Cmd.Parameters.Add(new SqlParameter("@MissingDocumentID", MissingDocumentID ));
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

public int DeleteStudentMissingDocuments(InitializeModule.EnumCampus Campus, int StudentSerialNo)
{
    int iEffected = 0;
    Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
    SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
    try
    {
        string sSQL = GetDeleteAllCommand();
        //sSQL += sCondition;
        SqlCommand Cmd = new SqlCommand(sSQL, Conn);
        Cmd.Parameters.Add(new SqlParameter("@StudentSerialNo", StudentSerialNo));
       
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
DataTable dt = new DataTable("StudentMissingDocuments");
DataView dv = new DataView();
List<StudentMissingDocuments> myStudentMissingDocumentss = new List<StudentMissingDocuments>();
try
{
myStudentMissingDocumentss = GetStudentMissingDocuments(InitializeModule.EnumCampus.ECTNew,sCondition,false);
DataColumn col1= new DataColumn("StudentSerialNo", Type.GetType("int"));
dt.Columns.Add(col1 );
DataColumn col2= new DataColumn("MissingDocumentID", Type.GetType("int"));
dt.Columns.Add(col2 );
DataColumn col3= new DataColumn("CreationUserID", Type.GetType("int"));
dt.Columns.Add(col3 );
dt.Constraints.Add(new UniqueConstraint(col1));
dt.Constraints.Add(new UniqueConstraint(col2));

DataRow dr;
for (int i = 0; i < myStudentMissingDocumentss.Count; i++)
{
dr = dt.NewRow();
  dr[1] = myStudentMissingDocumentss[i].StudentSerialNo;
  dr[2] = myStudentMissingDocumentss[i].MissingDocumentID;
  dr[3] = myStudentMissingDocumentss[i].CreationUserID;
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
myStudentMissingDocumentss.Clear();
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
sSQL += StudentSerialNoFN;
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
public class StudentMissingDocumentsCls : StudentMissingDocumentsDAL
{
#region "Decleration"
private int m_lngCurRow=0;
public SqlDataAdapter daStudentMissingDocuments;
private DataSet m_dsStudentMissingDocuments;
public DataRow StudentMissingDocumentsDataRow ;
#endregion
#region "Puplic Properties"
public DataSet dsStudentMissingDocuments
{
get { return m_dsStudentMissingDocuments ; }
set { m_dsStudentMissingDocuments = value ; }
}
//-----------------------------------------------------
public int lngCurRow 
{
get { return  m_lngCurRow ; }
set {m_lngCurRow = value ; }
}
#endregion
public StudentMissingDocumentsCls()
{
try
{
dsStudentMissingDocuments= new DataSet();

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
public virtual SqlDataAdapter GetStudentMissingDocumentsDataAdapter(string sCondition ,SqlConnection con ) 
{
string sSQL =""; 
try
{
sSQL = GetSQL();
sSQL += " " + sCondition;
//-----------------------------------------
daStudentMissingDocuments = new SqlDataAdapter(sSQL, con);
// Create command builder. This line automatically generates the update commands for you, so you don't
// have to provide or create your own.
SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daStudentMissingDocuments);
//Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
// key + unique key information to be retrieved unless AddWithKey is specified.
daStudentMissingDocuments.MissingSchemaAction = MissingSchemaAction.AddWithKey;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daStudentMissingDocuments;
}
public virtual SqlDataAdapter GetStudentMissingDocumentsDataAdapter(SqlConnection con)  
{
try
{
daStudentMissingDocuments = new SqlDataAdapter();
//''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
//'' key + unique key information to be retrieved unless AddWithKey is specified.
daStudentMissingDocuments.MissingSchemaAction = MissingSchemaAction.AddWithKey;
//-----------------------------------------
SqlParameter Parmeter = default(SqlParameter); 
//[SELECT COMMAND]
SqlCommand cmdStudentMissingDocuments;
cmdStudentMissingDocuments = new SqlCommand(GetSelectCommand(), con);
//'cmdRolePermission.Parameters.Add("@StudentSerialNo", SqlDbType.Int, 4, "StudentSerialNo" );
//'cmdRolePermission.Parameters.Add("@MissingDocumentID", SqlDbType.Int, 4, "MissingDocumentID" );
daStudentMissingDocuments.SelectCommand = cmdStudentMissingDocuments;
//'Add Handlers
//'RowUpdating,RowUpdated
AddDAEventHandler();
//'[UPDATE COMMAND].
cmdStudentMissingDocuments = new SqlCommand(GetUpdateCommand(), con);
//'Delete PK Parameteres from here. b/c its declared below
//cmdStudentMissingDocuments.Parameters.Add("@StudentSerialNo", SqlDbType.Int,4, LibraryMOD.GetFieldName(StudentSerialNoFN));
//cmdStudentMissingDocuments.Parameters.Add("@MissingDocumentID", SqlDbType.Int,4, LibraryMOD.GetFieldName(MissingDocumentIDFN));
cmdStudentMissingDocuments.Parameters.Add("@CreationUserID", SqlDbType.Int,4, LibraryMOD.GetFieldName(CreationUserIDFN));
cmdStudentMissingDocuments.Parameters.Add("@CreationDate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(CreationDateFN));
cmdStudentMissingDocuments.Parameters.Add("@LastUpdateUserID", SqlDbType.Int,4, LibraryMOD.GetFieldName(LastUpdateUserIDFN));
cmdStudentMissingDocuments.Parameters.Add("@LastUpdateDate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(LastUpdateDateFN));
cmdStudentMissingDocuments.Parameters.Add("@PCName", SqlDbType.NVarChar,32, LibraryMOD.GetFieldName(PCNameFN));
cmdStudentMissingDocuments.Parameters.Add("@NetUserName", SqlDbType.NVarChar,32, LibraryMOD.GetFieldName(NetUserNameFN));


Parmeter = cmdStudentMissingDocuments.Parameters.Add("@StudentSerialNo", SqlDbType.Int, 4, LibraryMOD.GetFieldName(StudentSerialNoFN));
Parmeter = cmdStudentMissingDocuments.Parameters.Add("@MissingDocumentID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(MissingDocumentIDFN));
Parmeter.SourceVersion = DataRowVersion.Original;
//'Its should be none for batch updating
//'UpdateCommand, InsertCommand, and DeleteCommand 
//'should be set to None or OutputParameters
daStudentMissingDocuments.UpdateCommand = cmdStudentMissingDocuments;
daStudentMissingDocuments.UpdateCommand.UpdatedRowSource  = UpdateRowSource.None ;
//'-------------------------------------------------------------------------
//'/INSERT COMMAND
 cmdStudentMissingDocuments = new SqlCommand(GetInsertCommand(), con);
cmdStudentMissingDocuments.Parameters.Add("@StudentSerialNo", SqlDbType.Int,4, LibraryMOD.GetFieldName(StudentSerialNoFN));
cmdStudentMissingDocuments.Parameters.Add("@MissingDocumentID", SqlDbType.Int,4, LibraryMOD.GetFieldName(MissingDocumentIDFN));
cmdStudentMissingDocuments.Parameters.Add("@CreationUserID", SqlDbType.Int,4, LibraryMOD.GetFieldName(CreationUserIDFN));
cmdStudentMissingDocuments.Parameters.Add("@CreationDate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(CreationDateFN));
cmdStudentMissingDocuments.Parameters.Add("@LastUpdateUserID", SqlDbType.Int,4, LibraryMOD.GetFieldName(LastUpdateUserIDFN));
cmdStudentMissingDocuments.Parameters.Add("@LastUpdateDate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(LastUpdateDateFN));
cmdStudentMissingDocuments.Parameters.Add("@PCName", SqlDbType.NVarChar,32, LibraryMOD.GetFieldName(PCNameFN));
cmdStudentMissingDocuments.Parameters.Add("@NetUserName", SqlDbType.NVarChar,32, LibraryMOD.GetFieldName(NetUserNameFN));
Parmeter.SourceVersion = DataRowVersion.Current;
daStudentMissingDocuments.InsertCommand =cmdStudentMissingDocuments;
daStudentMissingDocuments.InsertCommand.UpdatedRowSource  = UpdateRowSource.None;
//'------------------------
//'/DELETE COMMAND
 cmdStudentMissingDocuments = new SqlCommand(GetDeleteCommand(), con);
Parmeter = cmdStudentMissingDocuments.Parameters.Add("@StudentSerialNo", SqlDbType.Int, 4, LibraryMOD.GetFieldName(StudentSerialNoFN));
Parmeter = cmdStudentMissingDocuments.Parameters.Add("@MissingDocumentID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(MissingDocumentIDFN));
Parmeter.SourceVersion = DataRowVersion.Original;
daStudentMissingDocuments.DeleteCommand =cmdStudentMissingDocuments;
daStudentMissingDocuments.DeleteCommand.UpdatedRowSource  = UpdateRowSource.None;
//'Batch Size
//'Set the batch size.
daStudentMissingDocuments.UpdateBatchSize = ECTGlobalDll.InitializeModule.BATCH_SIZE;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daStudentMissingDocuments;
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
dr = dsStudentMissingDocuments.Tables[TableName].NewRow();
dr[LibraryMOD.GetFieldName(StudentSerialNoFN)]=StudentSerialNo;
dr[LibraryMOD.GetFieldName(MissingDocumentIDFN)]=MissingDocumentID;
dsStudentMissingDocuments.Tables[TableName].Rows.Add(dr);
break;
case (int)ECTGlobalDll.InitializeModule.enumModes.EditMode:
 DataRow[] drAry = null;
drAry = dsStudentMissingDocuments.Tables[TableName].Select(LibraryMOD.GetFieldName(StudentSerialNoFN)  + "=" + StudentSerialNo  + " AND " + LibraryMOD.GetFieldName(MissingDocumentIDFN) + "=" + MissingDocumentID);
//'its return array of rows and we can access the first by index 0
drAry[0][LibraryMOD.GetFieldName(StudentSerialNoFN)]=StudentSerialNo;
drAry[0][LibraryMOD.GetFieldName(MissingDocumentIDFN)]=MissingDocumentID;
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
public int CommitStudentMissingDocuments()  
{
//CommitStudentMissingDocuments= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
//'' Update Database with SqlDataAdapter
daStudentMissingDocuments.Update(dsStudentMissingDocuments, TableName);
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
FindInMultiPKey(StudentSerialNo,MissingDocumentID);
if (( StudentMissingDocumentsDataRow != null)) 
{
StudentMissingDocumentsDataRow.Delete();
CommitStudentMissingDocuments();
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
if (StudentMissingDocumentsDataRow[LibraryMOD.GetFieldName(StudentSerialNoFN)]== System.DBNull.Value)
{
  StudentSerialNo=0;
}
else
{
  StudentSerialNo = (int)StudentMissingDocumentsDataRow[LibraryMOD.GetFieldName(StudentSerialNoFN)];
}
if (StudentMissingDocumentsDataRow[LibraryMOD.GetFieldName(MissingDocumentIDFN)]== System.DBNull.Value)
{
  MissingDocumentID=0;
}
else
{
  MissingDocumentID = (int)StudentMissingDocumentsDataRow[LibraryMOD.GetFieldName(MissingDocumentIDFN)];
}
if (StudentMissingDocumentsDataRow[LibraryMOD.GetFieldName(CreationUserIDFN)]== System.DBNull.Value)
{
  CreationUserID=0;
}
else
{
  CreationUserID = (int)StudentMissingDocumentsDataRow[LibraryMOD.GetFieldName(CreationUserIDFN)];
}
if (StudentMissingDocumentsDataRow[LibraryMOD.GetFieldName(CreationDateFN)]== System.DBNull.Value)
{
}
else
{
  CreationDate = (DateTime)StudentMissingDocumentsDataRow[LibraryMOD.GetFieldName(CreationDateFN)];
}
if (StudentMissingDocumentsDataRow[LibraryMOD.GetFieldName(LastUpdateUserIDFN)]== System.DBNull.Value)
{
  LastUpdateUserID=0;
}
else
{
  LastUpdateUserID = (int)StudentMissingDocumentsDataRow[LibraryMOD.GetFieldName(LastUpdateUserIDFN)];
}
if (StudentMissingDocumentsDataRow[LibraryMOD.GetFieldName(LastUpdateDateFN)]== System.DBNull.Value)
{
}
else
{
  LastUpdateDate = (DateTime)StudentMissingDocumentsDataRow[LibraryMOD.GetFieldName(LastUpdateDateFN)];
}
if (StudentMissingDocumentsDataRow[LibraryMOD.GetFieldName(PCNameFN)]== System.DBNull.Value)
{
  PCName="";
}
else
{
  PCName = (string)StudentMissingDocumentsDataRow[LibraryMOD.GetFieldName(PCNameFN)];
}
if (StudentMissingDocumentsDataRow[LibraryMOD.GetFieldName(NetUserNameFN)]== System.DBNull.Value)
{
  NetUserName="";
}
else
{
  NetUserName = (string)StudentMissingDocumentsDataRow[LibraryMOD.GetFieldName(NetUserNameFN)];
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
public int FindInMultiPKey(int PKStudentSerialNo,int PKMissingDocumentID) 
{
//FindInMultiPKey= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
//' Create an array for the key values to find.
object[] findTheseVals = new object[1] ; 
//' Set the values of the keys to find.
findTheseVals[0] = PKStudentSerialNo;
findTheseVals[1] = PKMissingDocumentID;
StudentMissingDocumentsDataRow = dsStudentMissingDocuments.Tables[TableName].Rows.Find(findTheseVals);
if  ((StudentMissingDocumentsDataRow !=null)) 
{
lngCurRow = dsStudentMissingDocuments.Tables[TableName].Rows.IndexOf(StudentMissingDocumentsDataRow);
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
  lngCurRow = dsStudentMissingDocuments.Tables[TableName].Rows.Count - 1; //'Zero based index
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
  lngCurRow = Math.Min(lngCurRow + 1, dsStudentMissingDocuments.Tables[TableName].Rows.Count - 1);
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
  if (lngCurRow >= 0 & dsStudentMissingDocuments.Tables[TableName].Rows.Count > 0) 
{
  StudentMissingDocumentsDataRow = dsStudentMissingDocuments.Tables[TableName].Rows[lngCurRow];
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
daStudentMissingDocuments.RowUpdating+= new SqlRowUpdatingEventHandler(OnRowUpdating);
daStudentMissingDocuments.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
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
daStudentMissingDocuments.RowUpdating-= new SqlRowUpdatingEventHandler(OnRowUpdating);
daStudentMissingDocuments.RowUpdated-= new SqlRowUpdatedEventHandler(OnRowUpdated);
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
