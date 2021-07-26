using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Net.Http;
// == LinkedIn
using System.Web.Script.Serialization;



/// <summary>
/// Summary description for ClsLinkedInActivityRepAPI
/// </summary>
public class ClsLinkedInActivityRepAPI
{
    //public static string LinkedInClientID = "773cqg20giin95";
    //public static string LinkedInClientSecret = "t45WXRErCLlrOzVV";

    //public string LinkedInOAuthToken = "AQVELJyw0ZB7eJEm4eP4OwiGwO_c7BxKVNuKDkiE5y98a8mPp2wolKYsFqV-UMU9OrkK4kSTtbJhj8gKGRlgDag0luYrNKM62x6c_xpoZCMjS0IK1n5ka4I6tSuiO2yf2A12RBkpBboiKSMlAvLuFRzAls7eYowR5dGLjVkbsIZKG0Syt-6q0q_dljboZvS43wvZ9PsO_jPS5KeB8z3AUPGBfGusBP3MwVkZMZj_s_12meVcq6Zhz0hmfpqI77FSdpmG8x7mouhFa__gOi8q608SswUt-55kNFnuART72uaMHRun1nCa2tQcRt5s1bwEdvCiICF_yeu8NTVcb6w";


    public ClsLinkedInActivityRepAPI()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public class Link
    {
        public string type { get; set; }
        public string rel { get; set; }
        public string href { get; set; }
    }

    public class Paging
    {
        public int start { get; set; }
        public int count { get; set; }
        public List<Link> links { get; set; }
        public int total { get; set; }
    }

    public class Entity
    {
        public string profileUrn { get; set; }
    }

    public class CustomAttributes
    {
    }

    public class LearnerDetails
    {
        public string name { get; set; }
        public List<object> enterpriseGroups { get; set; }
        public string email { get; set; }
        public Entity entity { get; set; }
        public string uniqueUserId { get; set; }
        public CustomAttributes customAttributes { get; set; }
    }

    public class Activity
    {
        public string engagementType { get; set; }
        public object firstEngagedAt { get; set; }
        public object lastEngagedAt { get; set; }
        public string engagementMetricQualifier { get; set; }
        public int engagementValue { get; set; }
        public string assetType { get; set; }
    }

    public class Locale
    {
        public string country { get; set; }
        public string language { get; set; }
    }

    public class ContentDetails
    {
        public string name { get; set; }
        public string contentSource { get; set; }
        public string contentUrn { get; set; }
        public Locale locale { get; set; }
    }

    public class Element
    {
        public LearnerDetails learnerDetails { get; set; }
        public List<Activity> activities { get; set; }
        public ContentDetails contentDetails { get; set; }
    }

    public class LinkedInActivityRepRoot
    {
        public Paging paging { get; set; }
        public List<Element> elements { get; set; }
    }

    public static string LinkedIn_GetEmpActivityReport(string LinkedInAccessToken, DataSet dsClassification, int iStart, int iCount, Int64 iUTCStartFromDate, int iDaysCount)
    {
        ServicePointManager.Expect100Continue = true;
        ServicePointManager.DefaultConnectionLimit = 9999;
        //If you don’t have .NET 4.5 then use
        // ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;


        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        // Use SecurityProtocolType.Ssl3 if needed for compatibility reasons



        using (var httpClient = new HttpClient())
        {
            //Barry example
            //https://api.linkedin.com/v2/learningActivityReports?aggregationCriteria.primary=INDIVIDUAL&aggregationCriteria.secondary=CONTENT&q=criteria&start=0&count=1&contentSource=EXTERNAL&assetType=COURSE&startedAt=1601546604000&timeOffset.duration=14&timeOffset.unit=DAY

            //LinkedInA example //"https://api.linkedin.com/v2/learningActivityReports?q=criteria&count=1&startedAt=1562699900247&timeOffset.unit=DAY&timeOffset.duration=" + iDaysCount + "& aggregationCriteria.primary=ACCOUNT"

            using (var request = new HttpRequestMessage(new HttpMethod("GET"), "https://api.linkedin.com/v2/learningActivityReports?aggregationCriteria.primary=INDIVIDUAL&aggregationCriteria.secondary=CONTENT&q=criteria&start=" + iStart + "&count=" + iCount + "&contentSource=EXTERNAL&assetType=COURSE&startedAt=" + iUTCStartFromDate + "&timeOffset.duration=" + iDaysCount + "&timeOffset.unit=DAY"))
            {
                request.Headers.TryAddWithoutValidation("authorization", "Bearer " + LinkedInAccessToken + "");

                var task = httpClient.SendAsync(request);
                int iErrorHappened = 0;
                try
                {

                    if (task.Status == System.Threading.Tasks.TaskStatus.Faulted || task.Status == System.Threading.Tasks.TaskStatus.Canceled)

                    {
                        return "";
                    }
                    task.Wait();
                }
                catch (Exception ex)
                {
                    //throw ex;
                    iErrorHappened = 1;



                }
                if (iErrorHappened > 0)
                {
                    return "Error occured";
                }
                var response = task.Result;
                string responseString = response.Content.ReadAsStringAsync().Result;
                //=================================

                // Deserialize
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                string sEmpEmail = "";
                string sEmpName = "";
                int iCourseID = 0;
                string sCourseName = "";
                string sEngagmentType = "";
                string sEngagmentValue = "";
                string sAssetType = "";
                DateTime LastEngagedCompletedDate = DateTime.MinValue;
                DateTime FirstViewDate = DateTime.MinValue;
                if (responseString.Contains("serviceErrorCode"))
                {
                    // Error
                    return responseString;
                }
                else
                {
                    // Good

                    ClsLinkedInActivityRepAPI.LinkedInActivityRepRoot myDeserializedClass = JsonConvert.DeserializeObject<ClsLinkedInActivityRepAPI.LinkedInActivityRepRoot>(responseString);
                    int iEndofLoop = 0;
                    if (iCount < myDeserializedClass.paging.total)
                    {
                        iEndofLoop = iCount;
                    }
                    else
                    {
                        iEndofLoop = myDeserializedClass.paging.total;
                    }
                    for (int i = 0; i < iEndofLoop; i++)
                    {
                        sEmpEmail = myDeserializedClass.elements[i].learnerDetails.email;
                        sEmpName = myDeserializedClass.elements[i].learnerDetails.name;

                        string[] iURNCourseID = myDeserializedClass.elements[i].contentDetails.contentUrn.Split(':');
                        sCourseName = myDeserializedClass.elements[i].contentDetails.name;
                        iCourseID = Convert.ToInt32(iURNCourseID[3]);
                        for (int a = 0; a < myDeserializedClass.elements[i].activities.Count; a++)
                        {
                            sEngagmentType = myDeserializedClass.elements[i].activities[a].engagementType;
                            sEngagmentValue = myDeserializedClass.elements[i].activities[a].engagementValue.ToString();
                            sAssetType = myDeserializedClass.elements[i].activities[a].assetType;
                            
                            if (myDeserializedClass.elements[i].activities[a].lastEngagedAt is null)
                            {

                            }
                            else
                            {
                                LastEngagedCompletedDate = LibraryMOD.FromMillisecondsSinceUnixEpoch(Convert.ToInt64(myDeserializedClass.elements[i].activities[a].lastEngagedAt));
                            }

                            if (myDeserializedClass.elements[i].activities[a].firstEngagedAt is null)
                            {

                            }
                            else
                            {
                                FirstViewDate = LibraryMOD.FromMillisecondsSinceUnixEpoch(Convert.ToInt64(myDeserializedClass.elements[i].activities[a].firstEngagedAt));
                            }

                        }

                        AddNewRowToActivitReportDataset(dsClassification, sEmpEmail, sEmpName, iCourseID, sCourseName, sEngagmentType, sEngagmentValue, sAssetType, FirstViewDate, LastEngagedCompletedDate);

                    }


                }
                return "completed";

            }
        }
    }

    private static int AddNewRowToActivitReportDataset(DataSet ds, string sEmpEmail, string sEmpName, int iCourseID, string sCourseName, string sEngagmentType, string sEngagmentValue, string sAssetType, DateTime FirstViewDate, DateTime LastEngagedCompletedDate)
    {
        int iResult = InitializeModule.FAIL_RET;
        DataRow dr;
        DataTable dt = new DataTable();
        try
        {

            dt = ds.Tables["ActivityReport"];
            dr = dt.NewRow();

            dr["sEmpEmail"] = sEmpEmail;
            dr["sEmpName"] = sEmpName;
            dr["iCourseID"] = iCourseID;
            dr["sCourseName"] = sCourseName;
            dr["sEngagmentType"] = sEngagmentType;
            dr["sEngagmentValue"] = sEngagmentValue;
            dr["sAssetType"] = sAssetType;

            dr["FirstViewDate"] = FirstViewDate;
            dr["LastEngagedCompletedDate"] = LastEngagedCompletedDate;

            dt.Rows.Add(dr);

            dt.AcceptChanges();
            ds.AcceptChanges();
            iResult = InitializeModule.SUCCESS_RET;
        }
        catch (Exception exp)
        {
            Console.WriteLine("{0} Exception caught.", exp);
        }
        finally
        {

        }
        return iResult;
    }

}
