using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

// == LinkedIn
using System.Web.Script.Serialization;



/// <summary>
/// Summary description for ClsLinkedInAPI
/// </summary>
public class ClsLinkedInAPI
{
    //public static string LinkedInClientID = "773cqg20giin95";
    //public static string LinkedInClientSecret = "t45WXRErCLlrOzVV";
    //===============================

   // public string LinkedInOAuthToken = "AQVELJyw0ZB7eJEm4eP4OwiGwO_c7BxKVNuKDkiE5y98a8mPp2wolKYsFqV-UMU9OrkK4kSTtbJhj8gKGRlgDag0luYrNKM62x6c_xpoZCMjS0IK1n5ka4I6tSuiO2yf2A12RBkpBboiKSMlAvLuFRzAls7eYowR5dGLjVkbsIZKG0Syt-6q0q_dljboZvS43wvZ9PsO_jPS5KeB8z3AUPGBfGusBP3MwVkZMZj_s_12meVcq6Zhz0hmfpqI77FSdpmG8x7mouhFa__gOi8q608SswUt-55kNFnuART72uaMHRun1nCa2tQcRt5s1bwEdvCiICF_yeu8NTVcb6w";

    public ClsLinkedInAPI()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public class Locale
    {
        public string country { get; set; }
        public string language { get; set; }
    }

    public class Name
    {
        public Locale locale { get; set; }
        public string value { get; set; }
    }

    public class Owner
    {
        public string urn { get; set; }
        public Name name { get; set; }
    }

    public class LinkedInLearningClassificationRoot
    {
        public string urn { get; set; }
        public Owner owner { get; set; }
        public Name name { get; set; }
        public string type { get; set; }
    }
    //============================================
    public class Element
    {
        public string urn { get; set; }
        public Name name { get; set; }
        public string type { get; set; }
    }

    public class Link
    {
        public string rel { get; set; }
        public string href { get; set; }
        public string type { get; set; }
    }

    public class Paging
    {
        public int total { get; set; }
        public int count { get; set; }
        public int start { get; set; }
        public List<Link> links { get; set; }
    }

    public class LinkedInLearningClassificationKeywordRoot
    {
        public List<Element> elements { get; set; }
        public Paging paging { get; set; }
    }


    public class LinkedInException
    {
        public string exception { get; set; }
        public string errorcode { get; set; }
        public string message { get; set; }
        public string debuginfo { get; set; }
    }

    public class Generating_Access_Token
    {
        public string GrantType { get; set; }
        public string ClientID { get; set; }
        public string ClientSecret { get; set; }
    }

    public static string LinkedIn_Generating_Access_Token(string sLinkedInClientID,string sLinkedInClientSecret)
    {
        ServicePointManager.Expect100Continue = true;
        ServicePointManager.DefaultConnectionLimit = 9999;
        ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;


        using (var httpClient = new HttpClient())
        {
            using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://www.linkedin.com/oauth/v2/accessToken"))
            {
                request.Content = new StringContent("grant_type=client_credentials&client_id=" + sLinkedInClientID + "&client_secret=" + sLinkedInClientSecret + "");
                request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/x-www-form-urlencoded");

                var task = httpClient.SendAsync(request);
                task.Wait();
                var response = task.Result;
                string s = response.Content.ReadAsStringAsync().Result;


                var x = JObject.Parse(s);
                var sAccessToken = x["access_token"];
                if (sAccessToken != null) //added by bahaa 25-09-2020 //
                {
                    return sAccessToken.ToString();
                }
                else
                {
                    return "";
                }
            }
        }
    }
    public static string LinkedIn_GetLearningClassificationsByCategory(string LinkedInAccessToken, DataSet dsClassification, int CategoryID)
    {
        ServicePointManager.Expect100Continue = true;
        ServicePointManager.DefaultConnectionLimit = 9999;
        // ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;

        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        // Use SecurityProtocolType.Ssl3 if needed for compatibility reasons

        //GET https://api.linkedin.com/v2/learningClassifications/{URN}
        //The URN types supported by this endpoint are "urn:li:lyndaCategory" and "urn:li:skill".

        using (var httpClient = new HttpClient())
        {
            using (var request = new HttpRequestMessage(new HttpMethod("GET"), "https://api.linkedin.com/v2/learningClassifications/urn:li:lyndaCategory:" + CategoryID.ToString() + "?targetLocale.language=en&targetLocale.country=US"))
            {
                request.Headers.TryAddWithoutValidation("authorization", "Bearer " + LinkedInAccessToken + "");

                var task = httpClient.SendAsync(request);
                task.Wait();
                var response = task.Result;
                string contents = response.Content.ReadAsStringAsync().Result;
                //=================================

                // Deserialize
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                string slearningClassificationsType = "";
                string slearningClassificationsValue = "";

                if (contents.Contains("serviceErrorCode"))
                {
                    // Error
                }
                else
                {
                    // Good
                    // List<ClsLinkedInAPI.LinkedInLearningClassificationRoot> LearningClass = serializer.Deserialize<List<ClsLinkedInAPI.LinkedInLearningClassificationRoot>>(contents);
                    //foreach (var value in LearningClass)
                    //{
                    //    slearningClassificationsValue = value.value;
                    //}

                    ClsLinkedInAPI.LinkedInLearningClassificationRoot myDeserializedClass = JsonConvert.DeserializeObject<ClsLinkedInAPI.LinkedInLearningClassificationRoot>(contents);
                    var sValue = myDeserializedClass.name;
                    if (sValue != null)
                    {
                        slearningClassificationsValue = myDeserializedClass.name.value;
                        slearningClassificationsType = myDeserializedClass.type;
                        AddNewRowToLearningClassificationDataset(dsClassification, CategoryID, slearningClassificationsType, slearningClassificationsValue);
                    }
                    else
                    {
                        //return "";
                    }

                }
                return slearningClassificationsValue;

            }
        }

    }


    public static string LinkedIn_GetLearningClassificationsBySkill(string LinkedInAccessToken, DataSet dsClassification, int SkillID)
    {
        ServicePointManager.Expect100Continue = true;
        ServicePointManager.DefaultConnectionLimit = 9999;
        //If you don’t have .NET 4.5 then use
        // ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;


        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        // Use SecurityProtocolType.Ssl3 if needed for compatibility reasons

        //GET https://api.linkedin.com/v2/learningClassifications/{URN}
        //The URN types supported by this endpoint are "urn:li:lyndaCategory" and "urn:li:skill".

        using (var httpClient = new HttpClient())
        {
            using (var request = new HttpRequestMessage(new HttpMethod("GET"), "https://api.linkedin.com/v2/learningClassifications/urn:li:skill:" + SkillID + "?targetLocale.language=en&targetLocale.country=US"))
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

                    AddNewRowToLearningClassificationDataset(dsClassification, SkillID, "Skill", "ErrorGettingSkill");

                }
                if (iErrorHappened > 0)
                {
                    return "";
                }
                var response = task.Result;
                string contents = response.Content.ReadAsStringAsync().Result;
                //=================================

                // Deserialize
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                string slearningClassificationsType = "";
                string slearningClassificationsValue = "";

                if (contents.Contains("serviceErrorCode"))
                {
                    // Error
                    return contents;
                }
                else if (contents!="") 
                {
                    // Good
                    
                    ClsLinkedInAPI.LinkedInLearningClassificationRoot myDeserializedClass = JsonConvert.DeserializeObject<ClsLinkedInAPI.LinkedInLearningClassificationRoot>(contents);

                    var sValue = myDeserializedClass.name;
                    if (sValue != null)
                    {
                        slearningClassificationsValue = myDeserializedClass.name.value;
                        slearningClassificationsType = myDeserializedClass.type;
                        AddNewRowToLearningClassificationDataset(dsClassification, SkillID, slearningClassificationsType, slearningClassificationsValue);
                    }
                    else
                    {
                        //return "";
                    }


                }
                return slearningClassificationsValue;

            }
        }
    }
    public static string LinkedIn_LearningClassificationsByType(string LinkedInAccessToken, DataSet dsClassification, string sType, int iStart, int iCount)
    {
        ServicePointManager.Expect100Continue = true;
        ServicePointManager.DefaultConnectionLimit = 9999;
        ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;


        using (var httpClient = new HttpClient())
        {
            //using (var request = new HttpRequestMessage(new HttpMethod("GET"), "https://api.linkedin.com/v2/learningClassifications?q=keyword&keyword=" + sKeyword + "&targetLocale.language=en&targetLocale.country=US&start=" + iStart + "&count=" + iCount + "&fields=name,type,urn"))
            using (var request = new HttpRequestMessage(new HttpMethod("GET"), "https://api.linkedin.com/v2/learningClassifications?q=localeAndType&type=" + sType + "&sourceLocale.language=en&sourceLocale.country=US&start=" + iStart + "&count=" + iCount + "&fields=name:(value),urn"))
            {
                request.Headers.TryAddWithoutValidation("authorization", "Bearer " + LinkedInAccessToken + "");

                var task = httpClient.SendAsync(request);
                task.Wait();
                var response = task.Result;
                string responseString = response.Content.ReadAsStringAsync().Result;
                //=================================

                // Deserialize
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                string slearningClassificationsType = "";
                string slearningClassificationsValue = "";
                int CategoryID = 0;
                if (responseString.Contains("serviceErrorCode"))
                {
                    // Error
                    return responseString;
                }
                else
                {
                    // Good

                    ClsLinkedInAPI.LinkedInLearningClassificationKeywordRoot myDeserializedClass = JsonConvert.DeserializeObject<ClsLinkedInAPI.LinkedInLearningClassificationKeywordRoot>(responseString);

                    int iMax = iCount;
                    if (iMax > myDeserializedClass.paging.total)
                    {
                        iMax = myDeserializedClass.paging.total;
                    }
                    for (int i = 0; i < iMax; i++)
                    {
                        slearningClassificationsValue = myDeserializedClass.elements[i].name.value;
                        slearningClassificationsType = sType;
                        string[] iURNCategoryID = myDeserializedClass.elements[i].urn.Split(':');

                        CategoryID = Convert.ToInt32(iURNCategoryID[3]);
                        AddNewRowToLearningClassificationDataset(dsClassification, CategoryID, slearningClassificationsType, slearningClassificationsValue);


                    }

                }
                return slearningClassificationsValue;
            }
        }

    }
    public static string LinkedIn_LearningClassificationsByKeyword(string LinkedInAccessToken, DataSet dsClassification, string sKeyword, int iStart, int iCount)
    {
        ServicePointManager.Expect100Continue = true;
        ServicePointManager.DefaultConnectionLimit = 9999;
        ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;


        using (var httpClient = new HttpClient())
        {
            using (var request = new HttpRequestMessage(new HttpMethod("GET"), "https://api.linkedin.com/v2/learningClassifications?q=keyword&keyword=" + sKeyword + "&targetLocale.language=en&targetLocale.country=US&start=" + iStart + "&count=" + iCount + "&fields=name,type,urn"))
            {
                request.Headers.TryAddWithoutValidation("authorization", "Bearer " + LinkedInAccessToken + "");

                var task = httpClient.SendAsync(request);
                task.Wait();
                var response = task.Result;
                string responseString = response.Content.ReadAsStringAsync().Result;
                //=================================

                //dynamic LearningClassificationKeyword = JArray.Parse(responseString) as JArray;

                //var listofLearningClassificationKeyword = new List<ClsLinkedInAPI.LinkedInLearningClassificationKeywordRoot>();

                //foreach (var obj in LearningClassificationKeyword)
                //{
                //    var dto = new ClsLinkedInAPI.LinkedInLearningClassificationKeywordRoot
                //    {
                //        //TaskId = obj.taskId,
                //        //Note = obj.note,
                //        //TaskName = obj.taskName,
                //        //StartDate = obj.startDate,
                //        //EndDate = obj.endDate,
                //        //Status = obj.status,
                //        //TaskDuration = obj.taskDuration,
                //        //TaskSpent = obj.taskSpent,
                //        //ProjectId = obj.projectId,
                //        //ResourceId = obj.resourceId
                //    };

                //    listofLearningClassificationKeyword.Add(dto);
                //}

                //return listofLearningClassificationKeyword;



                // Deserialize
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                string slearningClassificationsType = "";
                string slearningClassificationsValue = "";
                int CategoryID = 0;
                if (responseString.Contains("serviceErrorCode"))
                {
                    // Error
                    return responseString;
                }
                else
                {
                    // Good

                    ClsLinkedInAPI.LinkedInLearningClassificationKeywordRoot myDeserializedClass = JsonConvert.DeserializeObject<ClsLinkedInAPI.LinkedInLearningClassificationKeywordRoot>(responseString);

                    for (int i = 0; i < myDeserializedClass.paging.total; i++)
                    {
                        slearningClassificationsValue = myDeserializedClass.elements[i].name.value;
                        slearningClassificationsType = myDeserializedClass.elements[i].type;
                        string[] iURNCategoryID = myDeserializedClass.elements[i].urn.Split(':');

                        CategoryID = Convert.ToInt32(iURNCategoryID[3]);
                        AddNewRowToLearningClassificationDataset(dsClassification, CategoryID, slearningClassificationsType, slearningClassificationsValue);

                    }

                }
                return slearningClassificationsValue;
            }
        }

    }
    private static int AddNewRowToLearningClassificationDataset(DataSet ds, int ID, string sType, string sName)
    {
        int iResult = InitializeModule.FAIL_RET;
        DataRow dr;
        DataTable dt = new DataTable();
        try
        {

            dt = ds.Tables["LeraningClassification"];
            dr = dt.NewRow();

            dr["ClassificationNumber"] = ID;
            dr["ClassificationType"] = sType;
            dr["ClassificationName"] = sName;

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
