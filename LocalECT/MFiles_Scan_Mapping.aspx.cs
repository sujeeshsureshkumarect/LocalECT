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
    public partial class MFiles_Scan_Mapping : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CurrentRole"] != null)
            {
                if (!IsPostBack)
                {

                }
            }
            else
            {
                Session.RemoveAll();
                Session["cpage"] = "MFiles_Scan_Mapping.aspx";
                Response.Redirect("Login.aspx");
            }
        }

        protected void lnk_Save_Click(object sender, EventArgs e)
        {
            string sSID = txt_StudnetID.Text.Trim();
            InitializeModule.EnumCampus campus = InitializeModule.EnumCampus.Males;
            if (sSID.Contains("AF") || sSID.Contains("ESF"))
            {
                campus = InitializeModule.EnumCampus.Females;
            }

            Connection_StringCLS myConnection_String = new Connection_StringCLS(campus);
            SqlConnection sc = new SqlConnection(myConnection_String.Conn_string);

            int SerialNo = GetSerial(sSID, campus);
            bool showModal = true;
            if (SerialNo!=0)
            {
                showModal = false;
                string SQL = "insert into ECT_MFiles_Scan_Mapping";
                SQL += " (sSID,iUnifiedID,sName,iPlace,isDBFound,dAdded,sAddedby)";
                SQL += " SELECT '" + sSID + "',iUnifiedID,strLastDescEn,'" + txt_Place.Text.Trim() + "','" + true + "','" + DateTime.Now + "','" + Session["CurrentUserName"].ToString() + "'";
                SQL += " FROM Reg_Students_Data AS Rsd where (Rsd.lngSerial="+SerialNo+")";
                SqlCommand cmd = new SqlCommand(SQL, sc);
                try
                {
                    sc.Open();
                    cmd.ExecuteNonQuery();
                    sc.Close();
                    lbl_Msg.Text = "Added Successfully";
                    lbl_Msg.ForeColor = System.Drawing.Color.Green;
                }
                catch(Exception ex)
                {
                    sc.Close();
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    sc.Close();
                    txt_Place.Text = "";
                    txt_StudnetID.Text = "";
                }
            }  
            else
            {
                //No Data in DB
                if (showModal)
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "myModal", "$('#myModal').modal('show');", true);
            }
        }
        protected void Decision_Command(object sender, CommandEventArgs e)
        {           
           if(e.CommandArgument.ToString()=="Yes")
            {
                string sSID = txt_StudnetID.Text.Trim();
                InitializeModule.EnumCampus campus = InitializeModule.EnumCampus.Males;
                if (sSID.Contains("AF") || sSID.Contains("ESF"))
                {
                    campus = InitializeModule.EnumCampus.Females;
                }

                Connection_StringCLS myConnection_String = new Connection_StringCLS(campus);
                SqlConnection sc = new SqlConnection(myConnection_String.Conn_string);

                string SQL = "insert into ECT_MFiles_Scan_Mapping";
                SQL += " (sSID,iPlace,isDBFound,dAdded,sAddedby)";
                SQL += " values ( '" + sSID + "','" + txt_Place.Text.Trim() + "','" + false + "','" + DateTime.Now + "','" + Session["CurrentUserName"].ToString() + "')";                
                SqlCommand cmd = new SqlCommand(SQL, sc);
                try
                {
                    sc.Open();
                    cmd.ExecuteNonQuery();
                    sc.Close();
                    lbl_Msg.Text = "Added Successfully";
                    lbl_Msg.ForeColor = System.Drawing.Color.Green;
                }
                catch (Exception ex)
                {
                    sc.Close();
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    sc.Close();
                    txt_Place.Text = "";
                    txt_StudnetID.Text = "";
                }
            }
           else
            {
                lbl_Msg.Text = "No records found";
                lbl_Msg.ForeColor = System.Drawing.Color.Red;
                txt_Place.Text = "";
                txt_StudnetID.Text = "";
            }
        }
        private int GetSerial(string sNumber, InitializeModule.EnumCampus Campus)
        {
            int iserial = 0;
            try
            {
                ApplicationsDAL myapp = new ApplicationsDAL();
                iserial = myapp.GetSerial(Campus, sNumber);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return iserial;
        }
    }
}