﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LocalECT
{
    public partial class Student_Search_SMSSent : System.Web.UI.Page
    {
        int CurrentRole = 0;
        InitializeModule.EnumCampus Campus = InitializeModule.EnumCampus.Males;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CurrentRole"] != null)
            {
                CurrentRole = (int)Session["CurrentRole"];
                if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Student_Data,
                        InitializeModule.enumPrivilege.SendSMS, CurrentRole) != true)
                {
                   Server.Transfer("Authorization.aspx");
                }
                if (Session["CurrentCampus"] != null)
                {
                    Campus = (InitializeModule.EnumCampus)Session["CurrentCampus"];
                }
                else
                {
                    Campus = InitializeModule.EnumCampus.Males;
                }
                string sid = "";
                if (Request.QueryString["sid"] != null && Request.QueryString["sid"] != "")
                {
                    sid = Request.QueryString["sid"];
                    txt_SID.Text = sid.Trim();
                }
                else
                {
                    Server.Transfer("Authorization.aspx");
                }
                if (!IsPostBack)
                {
                    getmobilenumber(sid);
                }
            }
            else
            {
                Session.RemoveAll();
                Response.Redirect("Login.aspx");
            }
        }
        public void getmobilenumber(string SID)
        {
            string mobile = LibraryMOD.GetStudentMobileNo(Campus, SID);
            if(!string.IsNullOrEmpty(mobile))
            {
                mobile = LibraryMOD.CleanPhone(mobile);
                if(mobile.Substring(0, 1) == "0")
                {
                    mobile = "+971" + mobile.Remove(0, 1);
                }
                txt_Mobile.Text = mobile.Trim();
            }
            else
            {
                //Disable Sent Button
                lnk_Sent.Enabled = false;
            }
        }

        protected void lnk_Sent_Click(object sender, EventArgs e)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.DefaultConnectionLimit = 9999;
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;

            if (txt_Mobile.Text.Trim().StartsWith("+971"))
            {
                using (var httpClient = new HttpClient())
                {
                    using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://c-eu.linkmobility.io/sms/send"))
                    {
                        request.Headers.TryAddWithoutValidation("Authorization", "Basic cE9UZ1oyTFc6R2NuMzU1MzJHcXc=");

                        request.Content = new StringContent("{\n    \"source\": \"LINK\",\n    \"destination\": \"" + txt_Mobile.Text.Trim() + "\",\n    \"userData\": \"" + txt_Text.Text.Trim() + "\",\n    \"platformId\": \"SMSC\",\n    \"platformPartnerId\": \"3759\",\n    \"useDeliveryReport\": false\n}");
                        request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                        var task = httpClient.SendAsync(request);
                        task.Wait();
                        var response = task.Result;
                        string s = response.Content.ReadAsStringAsync().Result;
                        if (response.IsSuccessStatusCode == true)
                        {
                            //Success
                            lbl_Msg.Text = "SMS Sent";
                            div_Alert.Attributes.Add("class", "alert alert-success alert-dismissible");
                            div_msg.Visible = true;
                        }
                    }
                }
            }
            else
            {
                lbl_Msg.Text = "Mobile number format incorrect.";
                div_Alert.Attributes.Add("class", "alert alert-success alert-dismissible");
            }                     
        }

        protected void lnk_Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentSearch.aspx");
        }
    }
}