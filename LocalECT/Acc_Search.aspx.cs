using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace LocalECT
{
    public partial class Acc_Search : System.Web.UI.Page
    {
        InitializeModule.EnumCampus Campus = InitializeModule.EnumCampus.Females;
        string constr = ConfigurationManager.ConnectionStrings["ECTDataFemales"].ConnectionString;
        int CurrentRole = 0;
        int iCYear = 0;
        int iCSem = 0;
        int iTerm = 0;
        string sOAcc = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CurrentRole"] != null)
            {
                CurrentRole = (int)Session["CurrentRole"];
                if (!IsPostBack)
                {
                    if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_ACC_Search,
              InitializeModule.enumPrivilege.ShowBrowse, CurrentRole) != true)
                    {
                        Server.Transfer("Authorization.aspx");
                    }
                }
                if (Session["studenttable1"] != null)
                {
                    DataTable dt1 = (DataTable)Session["studenttable1"];
                    RepterDetails.DataSource = dt1;
                    RepterDetails.DataBind();
                }
            }
            else
            {
                Session.RemoveAll();
                Response.Redirect("Login.aspx");
            }
        }

        protected void lnk_Search_Click(object sender, EventArgs e)
        {
            String sqlcomd = "";
            string sqlcont = "";
            //hdnMF.Value = "e0a8zjpV";
            if (drp_Campus.SelectedItem.Text == "Males")
            {
                constr = ConfigurationManager.ConnectionStrings["ECTDataMales"].ConnectionString;
                //sqlcomd = "SELECT sNo, sName, sAccount, sPhone1, ECTEmail  FROM [Web_Students_Search] where sAccount is not null AND ";
                //sqlcomd = "SELECT sNo, sName, sAccount, sPhone, ECTEmail  FROM Web_Acc_Search where ";
                sqlcomd = "SELECT Web_Students_Search.sNo, Web_Students_Search.iSerial, Web_Students_Search.sName, Web_Students_Search.sAccount, Web_Students_Search.sPhone1, Web_Students_Search.sPhone2, Web_Students_Search.bShift, Web_Students_Search.sCollege, Web_Students_Search.sDegree, Web_Students_Search.sMajor, Web_Students_Search.iYear, Web_Students_Search.bSemester, Web_Students_Search.bType, Web_Students_Search.UID, Web_Students_Search.ECTEmail, Reg_Specializations.strCaption FROM Web_Students_Search INNER JOIN Reg_Specializations ON Web_Students_Search.sCollege = Reg_Specializations.strCollege AND Web_Students_Search.sDegree = Reg_Specializations.strDegree AND Web_Students_Search.sMajor = Reg_Specializations.strSpecialization where ";
                Campus = (InitializeModule.EnumCampus)int.Parse(drp_Campus.SelectedItem.Value);
                //hdnMF.Value = "yM87jnAJ";
            }
            else
            {
                constr = ConfigurationManager.ConnectionStrings["ECTDataFemales"].ConnectionString;
                //sqlcomd = "SELECT sNo, sName, sAccount, sPhone1, ECTEmail  FROM [Web_Students_Search] where sAccount is not null AND ";
                sqlcomd = "SELECT Web_Students_Search.sNo, Web_Students_Search.iSerial, Web_Students_Search.sName, Web_Students_Search.sAccount, Web_Students_Search.sPhone1, Web_Students_Search.sPhone2, Web_Students_Search.bShift, Web_Students_Search.sCollege, Web_Students_Search.sDegree, Web_Students_Search.sMajor, Web_Students_Search.iYear, Web_Students_Search.bSemester, Web_Students_Search.bType, Web_Students_Search.UID, Web_Students_Search.ECTEmail, Reg_Specializations.strCaption FROM Web_Students_Search INNER JOIN Reg_Specializations ON Web_Students_Search.sCollege = Reg_Specializations.strCollege AND Web_Students_Search.sDegree = Reg_Specializations.strDegree AND Web_Students_Search.sMajor = Reg_Specializations.strSpecialization where ";
                Campus = (InitializeModule.EnumCampus)int.Parse(drp_Campus.SelectedItem.Value);
                //hdnMF.Value = "e0a8zjpV";
            }
            Session["CurrentCampus"] = Campus;
            //if (drp_Criteria.SelectedItem.Text == "Student ID")
            //{
            //    sqlcont = "sNo like '%" + txt_Search.Text + "%'";
            //}
            //else if (drp_Criteria.SelectedItem.Text == "Student Name")
            //{
            //    sqlcont = "sName like '%" + txt_Search.Text + "%'";
            //}
            //else if (drp_Criteria.SelectedItem.Text == "Phone Number")
            //{
            //    sqlcont = "(sPhone1 like '%" + txt_Search.Text + "%' OR sPhone2 like '%" + txt_Search.Text + "%')";
            //}
            //else if (drp_Criteria.SelectedItem.Text == "Student Account Number")
            //{
            //    sqlcont = "sAccount like '%" + txt_Search.Text + "%'";
            //}
            //else if (drp_Criteria.SelectedItem.Text == "ECT Email")
            //{
            //    sqlcont = "ECTEmail like '%" + txt_Search.Text + "%'";
            //}

            string sIDsCon = "";
            if (drp_Type.SelectedItem.Text == "Like")
            {
                string sIDs = txt_Search.Text.Replace("\r\n", ";");
                int iLen = sIDs.Length;
                string sLast = sIDs.Substring(iLen - 1, 1);
                if (sLast == ";")
                {
                    sIDs = sIDs.Remove(iLen - 1, 1);
                }
                sIDsCon = "";
                if (drp_Criteria.SelectedItem.Text == "Student ID")
                {
                    //sqlcont = "sNo like '%" + txt_Search.Text + "%'";
                    sIDsCon = getIDsCondition(sIDs, "sNo");
                }
                else if (drp_Criteria.SelectedItem.Text == "Student Name")
                {
                    //sqlcont = "sName like '%" + txt_Search.Text + "%'";
                    sIDsCon = getIDsCondition(sIDs, "sName");
                }
                else if (drp_Criteria.SelectedItem.Text == "Phone Number")
                {
                    // sqlcont = "(sPhone1 like '%" + txt_Search.Text + "%' OR sPhone2 like '%" + txt_Search.Text + "%')";
                    sIDsCon = getIDsCondition(sIDs, "sPhone1");
                    string sIDsCon1 = getIDsCondition(sIDs, "sPhone2");

                    sIDsCon = sIDsCon + " OR " + sIDsCon1;
                }
                else if (drp_Criteria.SelectedItem.Text == "Student Account Number")
                {
                    //sqlcont = "sAccount like '%" + txt_Search.Text + "%'";
                    sIDsCon = getIDsCondition(sIDs, "sAccount");
                }
                else if (drp_Criteria.SelectedItem.Text == "ECT Email")
                {
                    //sqlcont = "ECTEmail like '%" + txt_Search.Text + "%'";
                    sIDsCon = getIDsCondition(sIDs, "ECTEmail");
                }
                else if (drp_Criteria.SelectedItem.Text == "Major Name")
                {
                    //sqlcont = "strCaption like '%" + txt_Search.Text + "%'";
                    sIDsCon = getIDsCondition(sIDs, "strCaption");
                }
            }
            else
            {
                string sIDs = txt_Search.Text.Replace("\r\n", ",");
                int iLen = sIDs.Length;
                string sLast = sIDs.Substring(iLen - 1, 1);
                if (sLast == ",")
                {
                    sIDs = sIDs.Remove(iLen - 1, 1);
                }
                string s = sIDs;
                sIDs = "'" + s.Replace(",", "','") + "'";
                sIDsCon = "";
                if (drp_Criteria.SelectedItem.Text == "Student ID")
                {
                    sIDsCon = "sNo in (" + sIDs + ")";
                }
                else if (drp_Criteria.SelectedItem.Text == "Student Name")
                {
                    sIDsCon = "sName in (" + sIDs + ")";
                }
                else if (drp_Criteria.SelectedItem.Text == "Phone Number")
                {
                    sIDsCon = "(sPhone1 in (" + sIDs + ") OR sPhone2 in (" + sIDs + "))";
                }
                else if (drp_Criteria.SelectedItem.Text == "Student Account Number")
                {
                    sIDsCon = "sAccount in (" + sIDs + ")";
                }
                else if (drp_Criteria.SelectedItem.Text == "ECT Email")
                {
                    sIDsCon = "ECTEmail in (" + sIDs + ")";
                }
                else if (drp_Criteria.SelectedItem.Text == "Major Name")
                {
                    sIDsCon = "strCaption in (" + sIDs + ")";
                }
            }

            SqlConnection sc = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand(sqlcomd + " " + sIDsCon + " ORDER BY sName asc", sc);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                Session["studenttable1"] = dt;
                RepterDetails.DataSource = dt;
                RepterDetails.DataBind();

                alertsearch.Visible = true;
                lbl_Count.Text = dt.Rows.Count.ToString() + " entry(s) found.";

            }
            catch (Exception ex)
            {
                sc.Close();
                throw ex;
            }
            finally
            {
                sc.Close();
            }
        }
        private string getIDsCondition(string sIDs, string columnname)
        {
            string sCon = " (";
            try
            {
                string[] sSeperated;
                sSeperated = sIDs.Split(';');
                int iCount = sSeperated.Length;

                foreach (string sID in sSeperated)
                {
                    sCon += " " + columnname + " like '%" + sID + "%'";
                    iCount -= 1;
                    if (iCount > 0)
                    {
                        sCon += " Or";
                    }
                    else
                    {
                        sCon += ")";
                    }
                }
            }
            catch (Exception exp)
            {
                //Console.WriteLine("{0} Exception caught.", exp);
                //divMsg.InnerText = exp.Message;
            }
            finally
            {

            }

            return sCon;
        }

        protected void lnk_Execute_Click(object sender, EventArgs e)
        {
            string sids = hdn_Selected_Sids.Value;
            Session["sids"] = sids;
            if (drp_Bulk.SelectedItem.Text == "Block/Unblock")
            {
                Response.Redirect(drp_Bulk.SelectedItem.Value);
            }
            else if (drp_Bulk.SelectedItem.Text == "Send SMS")
            {
                Response.Redirect(drp_Bulk.SelectedItem.Value);
            }
            else
            {

            }
        }
    }
}