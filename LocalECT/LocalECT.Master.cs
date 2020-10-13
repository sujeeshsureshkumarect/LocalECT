using LocalECT.DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LocalECT
{
    public partial class LocalECT : System.Web.UI.MasterPage
    {
        SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["ECTDataNew"].ConnectionString);
        DataTable Menus = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getcurrentterm();
                Generate_Menu();
            }
        }

        public void getcurrentterm()
        {
            int iCSem = 0;
            int iCYear = LibraryMOD.SeperateTerm(LibraryMOD.GetCurrentTerm(), out iCSem);
            Session["CurrentYear"] = iCYear;
            Session["CurrentSemester"] = iCSem;

            string sYear = iCYear.ToString() + " / " + (iCYear + 1).ToString();
            string sSem = LibraryMOD.GetSemesterString(iCSem);
            lbl_term.Text = sYear + " " + sSem;
        }
        public void Generate_Menu()
        {
            int RoleId = 0;

            if (Session["CurrentRole"] != null)
            {
                RoleId = (int)Session["CurrentRole"];
            }

            var Menu = new DAL.DAL();
            Menus = Menu.GetMenuData();
            DataView view = new DataView(Menus);
            view.RowFilter = "iLevel=0";
            this.rptCategories.DataSource = view;
            this.rptCategories.DataBind();
        }
        protected void rptCategories_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    if (Menus != null)
                    {
                        DataRowView drv = e.Item.DataItem as DataRowView;
                        string ID = drv["ObjectID"].ToString();
                        string Title = drv["DisplayObjectName"].ToString();
                        DataRow[] rows = Menus.Select("ParentID='" + ID + "' AND iLevel <> 0");
                        // DataRow[] rows = Menus.Select("ParentID=" + ID);
                        if (rows.Length > 0)
                        {
                            StringBuilder sb = new StringBuilder();
                            sb.Append("<ul class='nav child_menu'>");
                            foreach (var item in rows)
                            {
                                string parentId = item["ObjectID"].ToString();
                                string parentTitle = item["DisplayObjectName"].ToString();


                                DataRow[] parentRow = Menus.Select("ParentID=" + parentId);

                                if (parentRow.Count() > 0)
                                {
                                    sb.Append("<li><a>" + item["DisplayObjectName"] + "<span class='fa fa-chevron-down'></span></a>");
                                    //sb.Append("</li>");
                                }
                                else
                                {
                                    string strUrl = item["sURL"].ToString().Replace(".aspx", "");
                                    //sb.Append("<li><a href='" + item["sURL"] + "'>" + item["DisplayObjectName"] + "</a>"); old with aspx
                                    sb.Append("<li><a href='" + strUrl + "'>" + item["DisplayObjectName"] + "</a>");
                                    //sb.Append("</li>");
                                }
                                sb = CreateChild(sb, parentId, parentTitle, parentRow);
                            }
                            sb.Append("</li>");
                            sb.Append("</ul>");
                            (e.Item.FindControl("ltrlSubMenu") as Literal).Text = sb.ToString();
                        }
                    }
                }
            }
        }
        private StringBuilder CreateChild(StringBuilder sb, string parentId, string parentTitle, DataRow[] parentRows)
        {
            if (parentRows.Length > 0)
            {
                //sb.Append("<ul class='nav child_menu'>");sub_menu
                sb.Append("<ul class='nav child_menu'>");
                foreach (var item in parentRows)
                {
                    string childId = item["ObjectID"].ToString();
                    string childTitle = item["DisplayObjectName"].ToString();
                    DataRow[] childRow = Menus.Select("ParentID=" + childId);

                    if (childRow.Count() > 0)
                    {
                        sb.Append("<li><a>" + item["DisplayObjectName"] + "<span class='fa fa-chevron-down'></span></a>");

                        //sb.Append("</li>");
                    }
                    else
                    {
                        //sb.Append("<li  class='sub_menu'><a href='" + item["sURL"] + "'>" + item["DisplayObjectName"] + "</a>"); old with aspx
                        string strUrl = item["sURL"].ToString().Replace(".aspx", "");
                        sb.Append("<li  class='sub_menu'><a href='" + strUrl + "'>" + item["DisplayObjectName"] + "</a>");
                        // sb.Append("</li>");
                    }
                    CreateChild(sb, childId, childTitle, childRow);
                }
                sb.Append("</li>");
                sb.Append("</ul>");
            }
            return sb;
        }
        protected void lnk_Logout_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login");
        }
    }
}