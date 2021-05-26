using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace LocalECT
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //string APIKey = "AIzaSyB5YhNp1Hwa7vGrrpSrCILvUI8BvxkdosY";
            //string longURL = "https://www.codeguru.com/csharp/.net/net_asp/mvc/best-practices-for-improving-web-application-performance.html";
            //string shortURL = MyURLShorten(longURL, APIKey);
        }
        //public static string MyURLShorten(string Longurl,string APIKey)
        //{
        //    ServicePointManager.Expect100Continue = true;
        //    ServicePointManager.DefaultConnectionLimit = 9999;
        //    ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;

        //    string post = "{\"longUrl\": \"" + Longurl + "\"}";
        //    string MyshortUrl = Longurl;
        //    HttpWebRequest Myrequest = (HttpWebRequest)WebRequest.Create("https://www.googleapis.com/urlshortener/v1/url?key="+APIKey);
        // try
        //    {
        //        //Myrequest.ServicePoint.Expect100Continue = false;
        //        Myrequest.Method = "POST";
        //        Myrequest.ContentLength = post.Length;
        //        Myrequest.ContentType = "application/json";
        //        Myrequest.Headers.Add("Cache-Control", "no-cache");

        //        using (Stream requestStream =
        //           Myrequest.GetRequestStream())
        //        {
        //            byte[] postBuffer = Encoding.ASCII.GetBytes(post);
        //            requestStream.Write(postBuffer, 0,
        //               postBuffer.Length);
        //        }

        //        using (HttpWebResponse response =
        //           (HttpWebResponse)Myrequest.GetResponse())
        //        {
        //            using (Stream responseStream =
        //               response.GetResponseStream())
        //            {
        //                using (StreamReader responseReader = new StreamReader(responseStream))
        //                {
        //                    string json = responseReader.ReadToEnd();
        //                    MyshortUrl = Regex.Match(json, @"""id"":
        //                ?""(?<id>.+)""").Groups["id"].Value;
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Diagnostics.Debug.WriteLine(ex.Message);
        //        System.Diagnostics.Debug.WriteLine(ex.StackTrace);
        //    }
        //    return MyshortUrl;
        //}
    }
}