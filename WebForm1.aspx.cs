using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace police
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private const int PageSize = 10;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["search"] != null)
                {
                    string keyword = Session["search"].ToString();
                    TextBox1.Text = keyword;
                    show(keyword);
                }
                else
                {
                    show("");
                }
            }
        }

        private void show(string keyword)
        {
            int currentPage = Request["page"] == null ? 1 : int.Parse(Request["page"]);

            string search = "";

            if (!string.IsNullOrEmpty(keyword))
            {
                search = " and 地址 like '%'+@keyword+'%' ";//參數sql語法 
                Session["search"] = keyword;
            }

            string commandstring =$@"with tstation as (select row_number() over(order by id asc) as rownumber,* from test$ where 1 =1 {search})select *from tstation where rownumber>=@start and rownumber <=@end";

            string connectstring = WebConfigurationManager.ConnectionStrings["PoliceConnectionString"].ToString();
            SqlConnection connect = new SqlConnection(connectstring);
            SqlCommand sqlCommand = new SqlCommand(commandstring, connect);


            sqlCommand.Parameters.Add("@start", SqlDbType.Int);
            sqlCommand.Parameters["@start"].Value = ((currentPage - 1) * PageSize) + 1;
            sqlCommand.Parameters.Add("@end", SqlDbType.Int);
            sqlCommand.Parameters["@end"].Value = currentPage * PageSize;

            sqlCommand.Parameters.AddWithValue("@keyword", keyword);


            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill((dataTable));
            GridView1.DataSource = dataTable;
            GridView1.DataBind();

            SqlCommand totalcommand = new SqlCommand($@"select count(*) from [dbo].[test$] where 1=1 {search}", connect);
            totalcommand.Parameters.AddWithValue("@keyword", keyword);
            SqlDataAdapter totalAdapter = new SqlDataAdapter(totalcommand);
            DataTable totalTable = new DataTable();
            totalAdapter.Fill((totalTable));
            int total = Convert.ToInt32(totalTable.Rows[0][0]);

            Pagination1.totalitems = total;
            Pagination1.limit = PageSize;
            Pagination1.targetpage = "WebForm1.aspx";
            //技巧:利用這種方式才可以呼叫usercontrol裡的public method
            Pagination1.showPageControls();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string search = TextBox1.Text;
            show(search);
        }
    }
}