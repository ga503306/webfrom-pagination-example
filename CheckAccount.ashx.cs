using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using  Newtonsoft.Json;

namespace police
{
    /// <summary>
    /// CheckAccount 的摘要描述
    /// </summary>
    public class CheckAccount : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request["pid"]))
            {
                context.Response.Write("請輸入參數pid");
                return;
            }

            string pid = context.Request["pid"];

            context.Response.ContentType = "application/json";

            string commandstring = "SELECT  * FROM      警察局暨各分局所屬派出所$ where pid=@pid";

            string connectstring = WebConfigurationManager.ConnectionStrings["PoliceConnectionString"].ToString();
            SqlConnection connect = new SqlConnection(connectstring);
            SqlCommand sqlCommand = new SqlCommand(commandstring, connect);

            sqlCommand.Parameters.Add("@pid",SqlDbType.Int);
            sqlCommand.Parameters["@pid"].Value = pid;

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill((dataTable));

            string strJson= JsonConvert.SerializeObject(dataTable);//序列化datatable

            context.Response.Write(strJson);
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