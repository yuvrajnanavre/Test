using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestYuvrajWithDatabase
{
    public partial class TextBoxToDropdownandListView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string item = null;
            item = TextBox1.Text.Trim();
            if (item == "")
            {
                //Label1.Text = "Enter Value !!";
                TextBox1.Focus();
            }
            else
            {
                ListBox1.Items.Add(new ListItem(item));
                ddladd.Items.Add(new ListItem(item));
                //Label2.Text = "Item Added Successfully!!";
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            ddladd.Items.Remove(ddladd.SelectedItem);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            ListBox1.Items.Remove(ListBox1.SelectedItem);
        }
    }
}