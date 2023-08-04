using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestYuvrajWithDatabase
{

    public partial class UpdateFromInsert : System.Web.UI.Page
    {
        private SqlDataAdapter SqlDA;
        clasDAL DAL = new clasDAL();
        private DataRow dr;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                string input = Session["input"] as string;
                check(input);
                BindGrid();
            }
        }
        public override void VerifyRenderingInServerForm(Control control)
        {

        }

        void check(string input)
        {
            try
            {
                int A = DAL.IsTestRecordExists(input);
                if (A == 1)
                {
                    btnInsert.Visible = false;
                    btnUpdate.Visible = true;
                    btnDelete.Visible = true;
                    btnCancel.Visible = true;
                    available(input);
                }
                else
                {
                    btnInsert.Visible = true;
                    btnUpdate.Visible = false;
                    btnDelete.Visible = false;
                    btnCancel.Visible = true;
                    txtTestCaseID.Text = input;
                }

            }
            catch (Exception EX)
            {

            }
        }

        void available(string input)
        {
            try
            {
                dr = DAL.GetTestDetails(input);
                txtTestCaseID.Text = Convert.ToString(dr[0]);
                txtTestCaseDesc.Text = Convert.ToString(dr[1]);
                txtDateOfTest.Text = Convert.ToString(dr[2]);
                ddlOperation.Text = Convert.ToString(dr[3]);

                if (txtTestCaseDesc.Text == null)
                {
                    btnInsert.Visible = true;
                    btnUpdate.Visible = false;
                    btnDelete.Visible = false;
                    btnCancel.Visible = false;
                }
                else if (txtTestCaseDesc.Text != null)
                {
                    btnInsert.Visible = false;
                    btnUpdate.Visible = true;
                    btnDelete.Visible = true;
                    btnCancel.Visible = true;

                }

            }
            catch (Exception ex)
            {
                //ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Error!');", true);
            }
        }
        void BindGrid()
        {
            try
            {
                GridView1.DataSource = DAL.GetAllTestDetails();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Error!');", true);
            }
        }
        void reset()
        {
            txtTestCaseID.Text = "";
            txtTestCaseDesc.Text = "";
            txtDateOfTest.Text = "";
            ddlOperation.SelectedValue = "";
            ddlOperation.ClearSelection();
        }

        protected void Insert_Click(object sender, EventArgs e)
        {
            try
            {
                int a = 0;
                int z = 0;
                int s = a / z;
                string TestID = txtTestCaseID.Text;
                string TestCaseDesc = txtTestCaseDesc.Text;
                string DateofTest = txtDateOfTest.Text;
                string TestResult = ddlOperation.Text;
                DAL.SaveTestDetails(TestID, TestCaseDesc, DateofTest, TestResult, e);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Successfully Inserted.');", true);
                BindGrid();
                reset();
            }
            catch (Exception ex)
            {
                string alertScript = $"<script>alert('{ex.Message}');</script>";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", alertScript);
            }
        }

        protected void Update_Click(object sender, EventArgs e)
        {
            string TestID = txtTestCaseID.Text;
            string TestCaseDesc = txtTestCaseDesc.Text;
            string DateofTest = txtDateOfTest.Text;
            string TestResult = ddlOperation.Text;
            DAL.UpdateTestDetails(TestID, TestCaseDesc, DateofTest, TestResult, e);
            BindGrid();
            DataSet dt = DAL.UpdateTestDetails(TestID, TestCaseDesc, DateofTest, TestResult, e);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('" + dt.Tables[0].Rows[0][0].ToString() + "');", true);
            GridView1.EditIndex = -1;
            BindGrid();
            reset();
            btnInsert.Visible = true;

        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            string TestID = txtTestCaseID.Text;
            DAL.DeleteTestDetails(TestID, e);
            BindGrid();
            DataSet dt = DAL.DeleteTestDetails(TestID, e);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('" + dt.Tables[0].Rows[0][0].ToString() + "');", true);
            reset();

        }
        protected void RadioButton1_CheckedChanged1(object sender, EventArgs e)
        {
            btnInsert.Visible = false;
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                RadioButton rb = (GridView1.Rows[i].FindControl("grdRadioBtn")) as RadioButton;
                if (rb.Checked == true)
                {
                    //txtTestCaseID.Text = GridView1.Rows[i].Cells[1].Text;
                    Label A = (GridView1.Rows[i].Cells[1].FindControl("lblTestCaseID")) as Label;
                    Label B = (GridView1.Rows[i].Cells[2].FindControl("lblTestCaseDesc")) as Label;
                    Label C = (GridView1.Rows[i].Cells[3].FindControl("lblDateOfTest")) as Label;
                    //C.Text = reader[7].ToString();
                    DateTime reviewDate = DateTime.ParseExact(C.Text, "dd-MM-yyyy hh:mm:ss", CultureInfo.InvariantCulture);
                    Label D = (GridView1.Rows[i].Cells[4].FindControl("lblTestResult")) as Label;
                    txtTestCaseID.Text = A.Text;
                    txtTestCaseDesc.Text = B.Text;
                    txtDateOfTest.Text = reviewDate.ToString("dd/MM/yyyy");
                    ddlOperation.Text = D.Text;
                }
            }
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            BindGrid();
            reset();

            btnInsert.Visible = true;
            btnUpdate.Visible = true;
            btnDelete.Visible = true;
            btnBack.Visible = true;
            btnCancel.Visible = true;
            txtTestCaseID.Text = "";
        }

        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("StartPage.aspx");
        }

       
    }
}