using System;
using System.Data;
using System.Configuration;
////////using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
//////using System.Xml.Linq;
using System.Data.SqlClient;
using System.Collections.Generic;

//SELECT [SeqID]
//      ,[MajorID]
//      ,[MinorID]
//      ,[DescEn]
//      ,[DescAr]
//      ,[IsActive]
//      ,[CreationUserID]
//      ,[CreationDate]
//      ,[LastUpdateUserID]
//      ,[LastUpdateDate]
//      ,[PCName]
//      ,[NetUserName]
//  FROM [ECTDataNew].[dbo].[Cmn_LookupDetails]
public class Lookups
{
    
    #region "Private Member Variables"
    
    private int _SeqID;
    private int _MajorID;
    private int _MinorID;
    private string _DescEn;
    private byte _IsActive;
    private int _DataStatus;
    private bool _isDataGhanged;

    #endregion

    #region "Constructors"
    public Lookups()
    {
    }


    public Lookups(int SeqID, int MajorID, int MinorID, string DescEn, byte IsActive,
    int DataStatus, bool isDataGhanged)
    {
        this._SeqID = SeqID;
        this._MajorID = MajorID;
        this._MinorID = MinorID;
        this._DescEn = DescEn;
        this._IsActive = IsActive;
        this._DataStatus = DataStatus;
        this.isDataGhanged = isDataGhanged;
    }

    #endregion

    #region "Public Properties"

    public int SeqID
    {
        get { return _SeqID; }
        set { _SeqID = value; }
    }

    public int MajorID
    {
        get { return _MajorID; }
        set { _MajorID = value; }
    }

    public int MinorID
    {
        get { return _MinorID; }
        set { _MinorID = value; }
    }

    public string DescEn
    {
        get { return _DescEn; }
        set { _DescEn = value; }
    }

    public byte IsActive
    {
        get { return _IsActive; }
        set { _IsActive = value; }
    }

    public int DataStatus
    {
        get { return _DataStatus; }
        //Throw New ArgumentException("UnitsInStock must be " & _ 
        //"greater than or equal to zero.") 
        set { _DataStatus = value; }
    }

    public bool isDataGhanged
    {
        get { return _isDataGhanged; }
        //Throw New ArgumentException("UnitsInStock must be " & _ 
        //"greater than or equal to zero.") 
        set { _isDataGhanged = value; }
    }
    #endregion


}

public class LookupsDAL
{
    public enum LkpHeaders { Systems = 200, Campus = 401 };

    public List<Lookups> GetLookup(string sCondition, LkpHeaders LkpHeader)
    {

        InitializeModule.EnumCampus iCampus = InitializeModule.EnumCampus.ECTNew;
        //iCampus = InitializeModule.EnumCampus.ECTNew;
        Connection_StringCLS sConn = new Connection_StringCLS(iCampus);

        string sSQL = "SELECT SeqID,MajorID,MinorID,DescEn,IsActive FROM Cmn_LookupDetails";

        sSQL += " Where MajorID=" + (int)LkpHeader; 
        sSQL += sCondition;

        sSQL = sSQL + " Order By DescEn";

        SqlConnection Conn = new SqlConnection(sConn.Conn_string.ToString());

        SqlCommand Cmd = new SqlCommand(sSQL, Conn);
        Conn.Open();
        SqlDataReader Rd = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
        List<Lookups> results = new List<Lookups>();

        //int i = 0;
        try
        {
            while (Rd.Read())
            {
                Lookups MyLookups = new Lookups();
                MyLookups.SeqID = int.Parse(Rd["SeqID"].ToString());
                MyLookups.MajorID = int.Parse(Rd["MajorID"].ToString());
                MyLookups.MinorID = int.Parse(Rd["MinorID"].ToString());
                MyLookups.DescEn = Rd["DescEn"].ToString();
                MyLookups.IsActive = byte.Parse(Rd["IsActive"].ToString());
                MyLookups.isDataGhanged = false;
                MyLookups.DataStatus = 1;//Old 2:New Recored

                results.Add(MyLookups);
                //i += 1;

            }
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
            //'Response.Write(ex.Message) 

            Rd.Close();
            Rd.Dispose();
            Conn.Close();
            Conn.Dispose();
        }
        //myStatus.Clear() 

        return results;

    }

    public int UpdateLookups(int SeqID,int MajorID,int MinorID,string DescEn,byte IsActive,
        bool isDataChanged, int iDataStatus, SqlConnection Conn, string sUser)
    {
        int iEffected = 0;

        try
        {

            string sSQL = null;

            if (iDataStatus == 1)
            {
                //SELECT SeqID,MajorID,MinorID,DescEn,DescAr,IsActive FROM Cmn_LookupDetails
                sSQL = "UPDATE Cmn_LookupDetails SET DescEn=@DescEn,";
                sSQL += "IsActive=@IsActive";
                sSQL += " Where MajorID=@MajorID";
                sSQL += " and MinorID=@MinorID,";
                
            }
            else
            {

                sSQL = "Insert Into Cmn_LookupDetails";
                sSQL += " (SeqID,MajorID,MinorID,DescEn,IsActive)";
                sSQL += " Values(@SeqID,@MajorID,@MinorID,@DescEn,@IsActive)";

            }
            SqlCommand Cmd = new SqlCommand(sSQL, Conn);

            Cmd.Parameters.Add(new SqlParameter("@SeqID", SeqID));
            Cmd.Parameters.Add(new SqlParameter("@MajorID", MajorID));
            Cmd.Parameters.Add(new SqlParameter("@MinorID", MinorID));
            Cmd.Parameters.Add(new SqlParameter("@DescEn", DescEn));
            Cmd.Parameters.Add(new SqlParameter("@IsActive", IsActive));

            iEffected = Cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Console.WriteLine("{0} Exception caught.", ex.Message);
        }
        finally
        {
            //Conn.Close();

        }
        return iEffected;
    }

    public int GetNewID(string sCondition)
    {
        int iNewID = 1;
        SqlConnection Conn = new SqlConnection();

        try
        {
            InitializeModule.EnumCampus iCampus = InitializeModule.EnumCampus.ECTNew;
            //iCampus = InitializeModule.EnumCampus.ECTNew;
            Connection_StringCLS sConn = new Connection_StringCLS(iCampus);

            string sSQL = "SELECT Max(MinorID) FROM Cmn_LookupDetails";

            sSQL += sCondition;

            Conn.ConnectionString = sConn.Conn_string.ToString();
            SqlCommand Cmd = new SqlCommand(sSQL, Conn);
            Conn.Open();

            iNewID += (int)Cmd.ExecuteScalar();
        }
        catch (Exception ex)
        {
            Console.WriteLine("{0} Exception caught.", ex.Message);
        }
        finally
        {
            //Conn.Close();

        }
        return iNewID;
    }

    public int DeleteLookups(string sCondition)
    {
        int iEffected = 0;
        SqlConnection Conn = new SqlConnection();

        try
        {
            InitializeModule.EnumCampus iCampus = InitializeModule.EnumCampus.ECTNew;
            //iCampus = InitializeModule.EnumCampus.ECTNew;
            Connection_StringCLS sConn = new Connection_StringCLS(iCampus);

            string sSQL = "Delete  from Cmn_LookupDetails";

            sSQL += sCondition;

            Conn.ConnectionString = sConn.Conn_string.ToString();
            SqlCommand Cmd = new SqlCommand(sSQL, Conn);
            Conn.Open();

            iEffected = Cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Console.WriteLine("{0} Exception caught.", ex.Message);
        }
        finally
        {
            //Conn.Close();

        }
        return iEffected;
    }
}
