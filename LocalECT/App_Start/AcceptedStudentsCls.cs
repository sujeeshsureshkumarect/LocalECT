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
using System.Data.Sql;
using System.Data.SqlClient;

public class AcceptedStudentsCls
{
    
    #region "Private Member Variables"

    private string iAccepted;
    private byte bPeriod;
    private string sPeriod;
    private string sStudentNumber;
    private string sStudentName;
    private string sMajor;
    private string sHSSource;
    private string sHSCountry;
    private decimal dHSAvg;
    private string sEng;
    private int iScore;
    private decimal dGpa;
    private string sPhone1;
    private string sPhone2;
    private int iLtr;
    private DateTime dAccepted;
    private byte bCancelReason;
    private string sCollege;
    private string sDegree;
    private string sSpecialization;
    private byte bStudentType;
    private byte bHSCountry;
    private string sStatus;
    private int iStatusTerm;

    #endregion
             
    #region "Constructors"
    public AcceptedStudentsCls()
    {
    }

    #endregion

    #region "Public Properties"
    
    public string IAccepted
    {
        get { return iAccepted; }
        set { iAccepted = value; }
    }
    
    public byte BPeriod
    {
        get { return bPeriod; }
        set { bPeriod = value; }
    }
    public string SPeriod
    {
        get { return sPeriod; }
        set { sPeriod = value; }
    }
    public string SStudentNumber
    {
        get { return sStudentNumber; }
        set { sStudentNumber = value; }
    }
    public string SStudentName
    {
        get { return sStudentName; }
        set { sStudentName = value; }
    }
    public string SMajor
    {
        get { return sMajor; }
        set { sMajor = value; }
    }
    public string SHSSource
    {
        get { return sHSSource; }
        set { sHSSource = value; }
    }
    public string SHSCountry
    {
        get { return sHSCountry; }
        set { sHSCountry = value; }
    }
    public decimal DHSAvg
    {
        get { return dHSAvg; }
        set { dHSAvg = value; }
    }
    public string SEng
    {
        get { return sEng; }
        set { sEng = value; }
    }
    public int IScore
    {
        get { return iScore; }
        set { iScore = value; }
    }
    public decimal DGpa
    {
        get { return dGpa; }
        set { dGpa = value; }
    }
    public string SPhone1
    {
        get { return sPhone1; }
        set { sPhone1 = value; }
    }
    public string SPhone2
    {
        get { return sPhone2; }
        set { sPhone2 = value; }
    }
    public int ILtr
    {
        get { return iLtr; }
        set { iLtr = value; }
    }
    public DateTime DAccepted
    {
        get { return dAccepted; }
        set { dAccepted = value; }
    }
    public byte BCancelReason
    {
        get { return bCancelReason; }
        set { bCancelReason = value; }
    }
    public string SCollege
    {
        get { return sCollege; }
        set { sCollege = value; }
    }
    public string SDegree
    {
        get { return sDegree; }
        set { sDegree = value; }
    }
    public string SSpecialization
    {
        get { return sSpecialization; }
        set { sSpecialization = value; }
    }
    public byte BStudentType
    {
        get { return bStudentType; }
        set { bStudentType = value; }
    }
    public byte BHSCountry
    {
        get { return bHSCountry; }
        set { bHSCountry = value; }
    }
    public string SStatus
    {
        get { return sStatus; }
        set { sStatus = value; }
    }

    public int StatusTerm
    {
        get { return iStatusTerm; }
        set { iStatusTerm = value; }
    }
    #endregion 
}
public class AcceptedStudentsDAL
{

    public List<AcceptedStudentsCls> GetAcceptedStudents(InitializeModule.EnumCampus Campus, string Condition)
    {
        Connection_StringCLS sConn = new Connection_StringCLS(Campus);

        //string sSQL = "SELECT iAccepted, iPeriod, sPeriod, sNo, ";
        string sSQL = "SELECT iAccepted, iPeriod, sPeriod, sNo, ";
        sSQL += "sName, sMajor, HSSource, HSCountryDesc, HSAVG, sENG, ";
        sSQL += "Score, CGPA, Phone1, Phone2, LTR, dAccepted, Status,StatusTerm ";
         sSQL += "FROM Web_Accepted_Students"; 
        
        if (!String.IsNullOrEmpty(Condition)) {
            sSQL += Condition;
            }

        sSQL += " Order By sName";

        SqlConnection Conn = new SqlConnection(sConn.Conn_string.ToString());

        SqlCommand Cmd = new SqlCommand(sSQL, Conn);
        Conn.Open();
        SqlDataReader Rd = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
        List<AcceptedStudentsCls> results = new List<AcceptedStudentsCls>();
        //try
        //{
            while (Rd.Read())
            {
                AcceptedStudentsCls myAcceptedStudent = new AcceptedStudentsCls();
                myAcceptedStudent.IAccepted = Rd["iAccepted"].ToString();
                if(!Rd["iPeriod"].Equals(DBNull.Value))
                myAcceptedStudent.BPeriod = Convert.ToByte(Rd["iPeriod"]);

                myAcceptedStudent.SPeriod = Rd["sPeriod"].ToString();
                myAcceptedStudent.SStudentNumber = Rd["sNo"].ToString();
                myAcceptedStudent.SStudentName = Rd["sName"].ToString();
                myAcceptedStudent.SMajor = Rd["sMajor"].ToString();
                myAcceptedStudent.SHSSource = Rd["HSSource"].ToString();
                myAcceptedStudent.SHSCountry = Rd["HSCountryDesc"].ToString();
                //check numbers and dates for null values.
                if (!Rd["HSAVG"].Equals(DBNull.Value))
                myAcceptedStudent.DHSAvg = Convert.ToDecimal(Rd["HSAVG"]);

                myAcceptedStudent.SEng = Rd["sENG"].ToString();
                if (!Rd["Score"].Equals(DBNull.Value))
                myAcceptedStudent.IScore = Convert.ToInt32(Rd["Score"]);

                if (!Rd["CGPA"].Equals(DBNull.Value))
                myAcceptedStudent.DGpa = Convert.ToDecimal(Rd["CGPA"]);
                
                myAcceptedStudent.SPhone1 = Rd["Phone1"].ToString();
                myAcceptedStudent.SPhone2 = Rd["Phone2"].ToString();
                
                
                if (!Rd["LTR"].Equals(DBNull.Value))
                myAcceptedStudent.ILtr = Convert.ToInt32(Rd["LTR"]);

                if (!Rd["dAccepted"].Equals(DBNull.Value))
                myAcceptedStudent.DAccepted = Convert.ToDateTime(Rd["dAccepted"]);

                myAcceptedStudent.SStatus = Rd["Status"].ToString();

                if (!Rd["StatusTerm"].Equals(DBNull.Value))
                    myAcceptedStudent.StatusTerm = Convert.ToInt32(Rd["StatusTerm"]);

                

                results.Add(myAcceptedStudent);

            }
        //}
        //catch (Exception ex)
        //{
        //    Console.WriteLine(ex.Message);
        //}
        //finally
        //{

        //    Rd.Close();
        //    Rd.Dispose();
        //    Conn.Close();
        //    Conn.Dispose();
        //}
        return results; 
    }
}
