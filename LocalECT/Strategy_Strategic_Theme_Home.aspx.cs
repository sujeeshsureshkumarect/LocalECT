using System;
using System.Collections;
using System.Configuration;
using LocalECT.DAL;
using System.Data;
//using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
//using System.Xml.Linq;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;

namespace LocalECT
{
    public partial class Strategy_Strategic_Theme_Home : System.Web.UI.Page
    {
        int CurrentRole = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            string strRefPage = "";
            if (Request.UrlReferrer != null)
            {
                strRefPage = Request.UrlReferrer.Segments[Request.UrlReferrer.Segments.Length - 1];
            }
            else
            {
                Server.Transfer("Authorization.aspx");
            }
            try
            {
                if (Session["CurrentRole"] != null)
                {
                    CurrentRole = (int)Session["CurrentRole"];
                    if (!IsPostBack)
                    {
                        string f = Request.QueryString["f"];
                        if(f=="m")
                        {

                        }
                        //else
                        //{
                        //    if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.Strategic_Theme,
                        //InitializeModule.enumPrivilege.ShowBrowse, CurrentRole) != true)
                        //    {
                        //        Server.Transfer("Authorization.aspx");
                        //    }
                        //}                        
                    }
                }
                else
                {
                    Session.RemoveAll();
                    Response.Redirect("Login.aspx");

                }
                if (Session["CurrentUserName"] != null)
                {
                    if (!IsPostBack)
                    {
                        string id = Request.QueryString["id"];
                        string f = Request.QueryString["f"];                        
                        bindStrategic_Theme();
                    }
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine("{0} Exception caught.", exp);
            }
            finally
            {

            }
        }

        public void bindStrategic_Theme()
        {
            string id = Request.QueryString["id"];
            string f = Request.QueryString["f"];
            string sSQL = "SELECT CS_Strategic_Theme.iSerial, CS_Strategic_Theme.sThemeCode, CS_Strategic_Theme.sThemeDesc, CS_Strategic_Theme.iOrder, CS_Strategic_Theme.dAdded, CS_Strategic_Theme.sAddedBy, CS_Strategic_Theme.dUpdated, CS_Strategic_Theme.sUpdatedBy, CS_Strategic_Theme.iStrategyVersion, CS_Strategic_Theme.sAbbreviation, CS_Strategic_Theme.sImagePath, CS_Strategic_Theme.iLevel, CS_Strategy_Version.sStrategyVersion FROM CS_Strategic_Theme INNER JOIN CS_Strategy_Version ON CS_Strategic_Theme.iStrategyVersion = CS_Strategy_Version.iSerial order by CS_Strategic_Theme.iOrder";
            if (id != null && f!=null)
            {
                lnk_Create.Visible = false;
                Img_Header.Visible = true;                
                //row1.Style.Add("margin-top", "18% !important");
                Page.Header.Controls.Add(new System.Web.UI.LiteralControl("<link rel=\"stylesheet\" type=\"text/css\" href=\"" + ResolveUrl("~/Strategy/dttable.css") + "\" />"));
                sSQL = "SELECT CS_Strategic_Theme.iSerial, CS_Strategic_Theme.sThemeCode, CS_Strategic_Theme.sThemeDesc, CS_Strategic_Theme.iOrder, CS_Strategic_Theme.dAdded, CS_Strategic_Theme.sAddedBy, CS_Strategic_Theme.dUpdated, CS_Strategic_Theme.sUpdatedBy, CS_Strategic_Theme.iStrategyVersion, CS_Strategic_Theme.sAbbreviation, CS_Strategic_Theme.sImagePath, CS_Strategic_Theme.iLevel, CS_Strategy_Version.sStrategyVersion FROM CS_Strategic_Theme INNER JOIN CS_Strategy_Version ON CS_Strategic_Theme.iStrategyVersion = CS_Strategy_Version.iSerial where CS_Strategic_Theme.iSerial="+id+ " order by CS_Strategic_Theme.iOrder";
            }
            else if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.Strategic_Theme,
                        InitializeModule.enumPrivilege.ShowAll, CurrentRole) != true)
            {
                sSQL = "SELECT CS_Strategic_Theme.iSerial, CS_Strategic_Theme.sThemeCode, CS_Strategic_Theme.sThemeDesc, CS_Strategic_Theme.iOrder, CS_Strategic_Theme.dAdded, CS_Strategic_Theme.sAddedBy, CS_Strategic_Theme.dUpdated, CS_Strategic_Theme.sUpdatedBy, CS_Strategic_Theme.iStrategyVersion, CS_Strategic_Theme.sAbbreviation, CS_Strategic_Theme.sImagePath, CS_Strategic_Theme.iLevel, CS_Strategy_Version.sStrategyVersion FROM CS_Strategic_Theme INNER JOIN CS_Strategy_Version ON CS_Strategic_Theme.iStrategyVersion = CS_Strategy_Version.iSerial where CS_Strategic_Theme.iSerial in (";

                sSQL += " SELECT        ObjectID ";
                sSQL += "        FROM            (SELECT        TH.iSerial AS ObjectID, TH.sThemeDesc AS ObjectNameEn, TH.sThemeCode AS DisplayObjectName, TH.iOrder AS ShowOrder, 14 AS SystemID, 1299 AS ParentID, 'Strategy_Strategic_Theme_Home.aspx?f=m&id=' + CONVERT(varchar, TH.iSerial)   ";
                sSQL += "                                                            AS sURL, TH.iLevel + 1 AS iLevel, 1 AS Privilege  ";
                sSQL += "                                  FROM            (SELECT        ES.EmployeeID, SI.iSerial AS SIID, SI.iTheme, SI.iGoal, SI.iProject, SI.iObjective, SI.iOrder, SIDS.isPrincipal  ";
                sSQL += "                                                            FROM            CS_Strategic_Initiative AS SI INNER JOIN  ";
                sSQL += "                                                                                      CS_Initiative_Dpartment_Section AS SIDS ON SI.iSerial = SIDS.iInitiative INNER JOIN  ";
                sSQL += "                                                                                      CS_Employees_Sections AS ES ON SIDS.iDepartment = ES.DepartmentID AND SIDS.iSection = ES.SectionID  ";
                sSQL += "                                                        WHERE        (ES.EmployeeID = "+ Session["EmployeeID"].ToString() + ")    ) AS C INNER JOIN  ";
                sSQL += "                                                            CS_Strategic_Theme AS TH ON C.iTheme = TH.iSerial  ";
                sSQL += "                                  UNION ALL  ";
                sSQL += "                                  SELECT        SG.iSerial as ObjectID,CONVERT(varchar(100),SG.sStrategicGoalDesc) AS ObjectNameEn, SG.sAbbreviation AS DisplayObjectName, SG.iOrder AS ShowOrder, 14 AS SystemID, C_4.iTheme AS ParentID,   ";
                sSQL += "                                                           'Strategy_Strategic_Goal_Home.aspx?f=m&id=' + CONVERT(varchar, SG.iSerial) AS sURL, SG.iLevel + 1 AS iLevel, 1 AS Privilege  ";
                sSQL += "                                  FROM            (SELECT        ES.EmployeeID, SI.iSerial AS SIID, SI.iTheme, SI.iGoal, SI.iProject, SI.iObjective, SI.iOrder, SIDS.isPrincipal  ";
                sSQL += "                                                            FROM            CS_Strategic_Initiative AS SI INNER JOIN  ";
                sSQL += "                                                                                      CS_Initiative_Dpartment_Section AS SIDS ON SI.iSerial = SIDS.iInitiative INNER JOIN  ";
                sSQL += "                                                                                      CS_Employees_Sections AS ES ON SIDS.iDepartment = ES.DepartmentID AND SIDS.iSection = ES.SectionID  ";
                sSQL += "                                                          WHERE        (ES.EmployeeID = "+ Session["EmployeeID"].ToString() + ")      ) AS C_4 INNER JOIN  ";
                sSQL += "                                                           CS_Strategic_Goal AS SG ON C_4.iGoal = SG.iSerial  ";
                sSQL += "                                  UNION ALL  ";
                sSQL += "                                  SELECT        SP.iSerial as ObjectID, CONVERT(varchar(100),SP.sStrategicProjectDesc) AS ObjectNameEn, SP.sAbbreviation AS DisplayObjectName, SP.iOrder, 14 AS SystemID, C_3.iGoal * 10 AS ParentID, 'Strategy_Strategic_Project_Home.aspx?f=m&id=' + CONVERT(varchar,   ";
                sSQL += "                                                           SP.iSerial) AS sURL, SP.iLevel + 1 AS iLevel, 1 AS Privilege  ";
                sSQL += "                                  FROM            (SELECT        ES.EmployeeID, SI.iSerial AS SIID, SI.iTheme, SI.iGoal, SI.iProject, SI.iObjective, SI.iOrder, SIDS.isPrincipal  ";
                sSQL += "                                                            FROM            CS_Strategic_Initiative AS SI INNER JOIN  ";
                sSQL += "                                                                                      CS_Initiative_Dpartment_Section AS SIDS ON SI.iSerial = SIDS.iInitiative INNER JOIN  ";
                sSQL += "                                                                                      CS_Employees_Sections AS ES ON SIDS.iDepartment = ES.DepartmentID AND SIDS.iSection = ES.SectionID  ";
                sSQL += "                                                            WHERE        (ES.EmployeeID = "+ Session["EmployeeID"].ToString() + ")     ) AS C_3 INNER JOIN  ";
                sSQL += "                                                           CS_Strategic_Project AS SP ON C_3.iProject = SP.iSerial  ";
                sSQL += "                                  UNION ALL  ";
                sSQL += "                                  SELECT        SO.iSerial AS ObjectID, CONVERT(varchar(100),SO.sStrategicObjectiveDesc) AS ObjectNameEn, SO.sAbbreviation AS DisplayObjectName, SO.iOrder, 14 AS SystemID, C_2.iProject * 100 AS ParentID,   ";
                sSQL += "                                                           'Strategy_Strategic_Objective_Home.aspx?f=m&id=' + CONVERT(varchar, SO.iSerial) AS sURL, SO.iLevel + 1 AS iLevel, 1 AS Privilege  ";
                sSQL += "                                  FROM            (SELECT        ES.EmployeeID, SI.iSerial AS SIID, SI.iTheme, SI.iGoal, SI.iProject, SI.iObjective, SI.iOrder, SIDS.isPrincipal  ";
                sSQL += "                                                            FROM            CS_Strategic_Initiative AS SI INNER JOIN  ";
                sSQL += "                                                                                      CS_Initiative_Dpartment_Section AS SIDS ON SI.iSerial = SIDS.iInitiative INNER JOIN  ";
                sSQL += "                                                                                      CS_Employees_Sections AS ES ON SIDS.iDepartment = ES.DepartmentID AND SIDS.iSection = ES.SectionID  ";
                sSQL += "                                                       WHERE        (ES.EmployeeID = "+ Session["EmployeeID"].ToString() + ")          ) AS C_2 INNER JOIN  ";
                sSQL += "                                                           CS_Strategic_Objective AS SO ON C_2.iObjective = SO.iSerial  ";
                sSQL += "                                  UNION ALL  ";
                sSQL += "                                  SELECT        SInit.iSerial  AS ObjectID, CONVERT(varchar(150),SInit.sInitiativeDesc) AS ObjectNameEn, SInit.sAbbreviation AS DisplayObjectName, SInit.iOrder, 14 AS SystemID, C_1.iObjective * 1000 AS ParentID,   ";
                sSQL += "                                                           'Strategy_Strategic_Initiative_Home.aspx?f=m&id=' + CONVERT(varchar, SInit.iSerial) AS sURL, SInit.iLevel + 1 AS iLevel, 1 AS Privilege  ";
                sSQL += "                                  FROM            (SELECT        ES.EmployeeID, SI.iSerial AS SIID, SI.iTheme, SI.iGoal, SI.iProject, SI.iObjective, SI.iOrder, SIDS.isPrincipal  ";
                sSQL += "                                                            FROM            CS_Strategic_Initiative AS SI INNER JOIN  ";
                sSQL += "                                                                                      CS_Initiative_Dpartment_Section AS SIDS ON SI.iSerial = SIDS.iInitiative INNER JOIN  ";
                sSQL += "                                                                                      CS_Employees_Sections AS ES ON SIDS.iDepartment = ES.DepartmentID AND SIDS.iSection = ES.SectionID  ";
                sSQL += "                                                        WHERE        (ES.EmployeeID = "+ Session["EmployeeID"].ToString() + ")        ) AS C_1 INNER JOIN  ";
                sSQL += "                                                           CS_Strategic_Initiative AS SInit ON C_1.SIID = SInit.iSerial) AS MNU  ";
                sSQL += " 														  where iLevel=2 ";
                sSQL += "        GROUP BY ObjectID, ObjectNameEn, DisplayObjectName, ShowOrder, SystemID, ParentID, sURL, iLevel  ";
                //sSQL += "        order by ObjectID ";

                sSQL += ") order by CS_Strategic_Theme.iOrder";
            }
            else
            {
                sSQL = "SELECT CS_Strategic_Theme.iSerial, CS_Strategic_Theme.sThemeCode, CS_Strategic_Theme.sThemeDesc, CS_Strategic_Theme.iOrder, CS_Strategic_Theme.dAdded, CS_Strategic_Theme.sAddedBy, CS_Strategic_Theme.dUpdated, CS_Strategic_Theme.sUpdatedBy, CS_Strategic_Theme.iStrategyVersion, CS_Strategic_Theme.sAbbreviation, CS_Strategic_Theme.sImagePath, CS_Strategic_Theme.iLevel, CS_Strategy_Version.sStrategyVersion FROM CS_Strategic_Theme INNER JOIN CS_Strategy_Version ON CS_Strategic_Theme.iStrategyVersion = CS_Strategy_Version.iSerial order by CS_Strategic_Theme.iOrder";
            }
            //else
            //{
            //    row1.Style.Add("margin-top", "0px !important");
            //}
            Connection_StringCLS myConnection_String = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew);
            SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["ECTDataNew"].ConnectionString);

            SqlCommand cmd = new SqlCommand(sSQL, sc);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                if (id != null && f != null)
                {
                    Img_Header.Src = dt.Rows[0]["sImagePath"].ToString();
                }

                Repeater1.DataSource = dt;
                Repeater1.DataBind();
            }
            catch (Exception ex)
            {
                sc.Close();
                Console.WriteLine("{0} Exception caught.", ex);
            }
            finally
            {
                sc.Close();
            }
        }

        protected void lnk_View_Click(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];
            string f = Request.QueryString["f"];
            if (id != null && f != null)
            {
                Response.Redirect("Strategy_Strategic_Theme_Update.aspx?f=m&id="+ id + "&t=v");
            }
            else
            {
                //Get the reference of the clicked button.
                LinkButton button = (sender as LinkButton);
                //Get the command argument
                string dateWarning = button.CommandArgument;//dateWarning
                Response.Redirect("Strategy_Strategic_Theme_Update.aspx?id=" + dateWarning + "&t=v");
            }
        }

        protected void lnk_Edit_Click(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];
            string f = Request.QueryString["f"];
            if (id != null && f != null)
            {
                Response.Redirect("Strategy_Strategic_Theme_Update.aspx?f=m&id=" + id + "&t=e");
            }
            else
            {   //Get the reference of the clicked button.
                LinkButton button = (sender as LinkButton);
                //Get the command argument
                string dateWarning = button.CommandArgument;//dateWarning
                Response.Redirect("Strategy_Strategic_Theme_Update.aspx?id=" + dateWarning + "&t=e");
            }
        }
    }
}