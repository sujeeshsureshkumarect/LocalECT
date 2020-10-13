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
using System.Data.SqlClient;
using System.Collections.Generic;

public class AttStatusesCLS 
{ 
    
    #region "Private Member Variables" 
    
    private byte _AttStatus; 
    private string _AttDescEn; 
    private string _AttDescAr; 
    #endregion 
    
    #region "Constructors" 
    public AttStatusesCLS() 
    { 
    } 
    public AttStatusesCLS(byte AttStatus, string AttDescEn, string AttDescAr) 
    { 
        this._AttStatus = AttStatus; 
        this._AttDescEn = AttDescEn; 
        this._AttDescAr = AttDescAr; 
    } 
    
    #endregion 
    
    #region "Public Properties" 
    
    public byte AttStatus { 
        get { return _AttStatus; } 
        set { _AttStatus = value; } 
    } 
    
    public string AttDescEn { 
        get { return _AttDescEn; } 
        set { _AttDescEn = value; } 
    } 
    
    public string AttDescAr { 
        get { return _AttDescAr; } 
        set { _AttDescAr = value; } 
    } 
    
    #endregion 
    
    
} 

public class AttStatusDAL 
{
    public List<AttStatusesCLS> GetAttStatuses(InitializeModule.EnumCampus Campus, string Condition) 
    { 
        
        
        Connection_StringCLS sConn = new Connection_StringCLS(Campus); 
        //SELECT byteAttStatus, strAttDescEn, strAttDescAr 
        //FROM Lkp_Att_Status; 
        string sSQL = "SELECT byteAttStatus, strAttDescEn, strAttDescAr " + "FROM Lkp_Att_Status";
        if (!string.IsNullOrEmpty(Condition))
        { 
            sSQL = sSQL + " Where " + Condition; 
        }
        sSQL = sSQL + " ORDER BY iOrderNo";

        SqlConnection Conn = new SqlConnection(sConn.Conn_string.ToString()); 
        
        SqlCommand Cmd = new SqlCommand(sSQL, Conn); 
        Conn.Open(); 
        SqlDataReader Rd = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
        List<AttStatusesCLS> results = new List<AttStatusesCLS>(); 
        while (Rd.Read()) {
            AttStatusesCLS AttStatus = new AttStatusesCLS(); 
            
            AttStatus.AttStatus = Convert.ToByte(Rd["byteAttStatus"]); 
            AttStatus.AttDescEn = Rd["strAttDescEn"].ToString(); 
            AttStatus.AttDescAr = Rd["strAttDescAr"].ToString(); 
            
                
            results.Add(AttStatus); 
        } 
        Rd.Close();
        Rd.Dispose();
        Conn.Close();
        Conn.Dispose();
        return results; 
    } 
    
    
} 

