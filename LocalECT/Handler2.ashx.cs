using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace LocalECT
{
    /// <summary>
    /// Summary description for Handler2
    /// </summary>
    public class Handler2 : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            string f = HttpContext.Current.Session["ProfilePIcUsers"].ToString();
            f = "//management-m/ETSD/ETS/Images/Employees/PIC" + f + ".jpeg";
            //\\management-m\ETSD\ETS\Images\Employees\PICE10168.jpeg
            if (File.Exists(f))
            {
                Image image = Image.FromFile(f);
                context.Response.Clear();
                context.Response.ClearHeaders();
                image.Save(context.Response.OutputStream, ImageFormat.Jpeg);
                context.Response.ContentType = "image/jpeg";
                HttpContext.Current.ApplicationInstance.CompleteRequest();
            }
            //else
            //{
            //    f = "~/images/Student.jpg";
            //    Image image = Image.FromFile(f);
            //    context.Response.Clear();
            //    context.Response.ClearHeaders();
            //    image.Save(context.Response.OutputStream, ImageFormat.Jpeg);
            //    context.Response.ContentType = "image/jpeg";
            //    HttpContext.Current.ApplicationInstance.CompleteRequest();
            //}
            //f = "//management-m/ETSD/ETS/Images/Students/" + f ;


        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}