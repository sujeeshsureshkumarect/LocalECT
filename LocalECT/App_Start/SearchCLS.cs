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


/// <summary>
/// Summary description for SearchCLS
/// </summary>
/// 

public class SearchCLS
{
    #region "Decleration"
    private string _sField1;
    private string _sField2;
    private string _sField3;
    private string _sField4;
    private string _sField5;
    //private string _sField6;
    #endregion
    #region "Puplic Properties"
    //'-----------------------------------------------------

    public string SField1
    {
        get { return _sField1; }
        set { _sField1 = value; }
    }

    public string SField2
    {
        get { return _sField2; }
        set { _sField2 = value; }
    }

    public string SField3
    {
        get { return _sField3; }
        set { _sField3 = value; }
    }

    public string SField4
    {
        get { return _sField4; }
        set { _sField4 = value; }
    }

    public string SField5
    {
        get { return _sField5; }
        set { _sField5 = value; }
    }

    //public string SField6
    //{
    //    get { return _sField6; }
    //    set { _sField6 = value; }
    //}
    
    //'-----------------------------------------------------
    #endregion
	public SearchCLS()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}
