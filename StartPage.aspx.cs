using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestYuvrajWithDatabase
{
    public partial class StartPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string input = TextBox1.Text;
            Session["input"] = input;
            //clasDAL separateInstance = new clasDAL();
            //separateInstance.ValueToProcess = (string)Session["Input"];
            //separateInstance.ProcessValue();
            Response.Redirect("UpdateFromInsert.aspx");
        }
    }
}