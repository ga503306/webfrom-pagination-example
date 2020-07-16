using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace police
{
    /// <summary>
    /// jpg 的摘要描述
    /// </summary>
    public class jpg : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "image/jpeg";
            context.Response.WriteFile(@"C:\Users\user\Desktop\音\東方事変\東方事変 - chapter1\Cover.png");
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