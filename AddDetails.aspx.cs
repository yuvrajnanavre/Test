using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestYuvrajWithDatabase
{
    public partial class AddDetails : System.Web.UI.Page
    {
        private SqlDataAdapter SqlDA;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
                reset();
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {

        }
        void reset()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
        }
        void BindGrid()
        {
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_select", con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    GridView1.DataSource = dr;
                    GridView1.DataBind();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Error!');", true);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    SqlCommand cmd1 = new SqlCommand("AddDet", con);
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.Parameters.AddWithValue("@TestCaseID", TextBox1.Text.Trim());
                    cmd1.Parameters.AddWithValue("@TestCaseDesc", TextBox2.Text.Trim());
                    cmd1.Parameters.AddWithValue("@DateOfTest", TextBox3.Text.Trim());
                    cmd1.Parameters.AddWithValue("@TestResult", TextBox4.Text.Trim());

                    cmd1.Connection = con;
                    con.Open();
                    cmd1.ExecuteNonQuery();
                    con.Close();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Successfully Inserted.');", true);
                    BindGrid();
                    reset();
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            this.BindGrid();
        }

        protected void OnRowCancelingEdit(object sender, EventArgs e)
        {
            GridView1.EditIndex = -1;
            this.BindGrid();
        }

        protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];
            int TestCaseID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            string TestCaseDesc = (row.FindControl("txtTestCaseDesc") as TextBox).Text;
            string DateOfTest = (row.FindControl("txtDateOfTest") as TextBox).Text.Trim();
            string TestResult = (row.FindControl("txtTestResult") as TextBox).Text;
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("sp_update1", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "UPDATE");
                cmd.Parameters.AddWithValue("@TestCaseID", TestCaseID);
                cmd.Parameters.AddWithValue("@TestCaseDesc", TestCaseDesc);
                cmd.Parameters.AddWithValue("@DateOfTest", DateOfTest);
                cmd.Parameters.AddWithValue("@TestResult", TestResult);
                cmd.Connection = con;
                con.Open();
                SqlDA = new SqlDataAdapter(cmd);
                DataSet dt = new DataSet();
                SqlDA.Fill(dt);
                cmd.Dispose();
                con.Close();
                BindGrid();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('" + dt.Tables[0].Rows[0][0].ToString() + "');", true);
                GridView1.EditIndex = -1;
                BindGrid();
            }
        }

        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int TestCaseID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_delete"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TestCaseID", TestCaseID);
                    cmd.Connection = con;
                    con.Open();
                    SqlDA = new SqlDataAdapter(cmd);
                    DataSet dt = new DataSet();
                    SqlDA.Fill(dt);
                    cmd.Dispose();
                    con.Close();
                    BindGrid();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('" + dt.Tables[0].Rows[0][0].ToString() + "');", true);

                }
            }
            this.BindGrid();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            this.BindGrid();

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}