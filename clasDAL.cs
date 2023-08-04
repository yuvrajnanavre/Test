using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TestYuvrajWithDatabase;


namespace TestYuvrajWithDatabase
{
    public class clasDAL
    {
        private SqlDataAdapter SqlDA;
        public SqlDataReader GetAllTestDetails()
        {

            SqlDataReader dr = null;
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                SqlConnection con = new SqlConnection(constr);
                con.Open();

                SqlCommand cmd = new SqlCommand("sp_select", con);
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            finally
            {

            }
            return dr;
        }

        public DataRow GetTestDetails(string szTestId)
        {
            DataRow dr = null;
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                SqlConnection con = new SqlConnection(constr);
                SqlCommand cmd = new SqlCommand("BindTextbox", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Input", szTestId);
                SqlDA = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                SqlDA.Fill(dt);
                dr = dt.Rows[0];
            }
            finally
            {

            }
            return dr;
        }
        public int IsTestRecordExists(string input)
        {
            int A = 0;
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                SqlConnection con = new SqlConnection(constr);
                SqlCommand cmd = new SqlCommand("availableornot", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Input", input);
                A = (int)cmd.ExecuteScalar();
            }
            finally
            {

            }
            return A;
        }
        public void SaveTestDetails(string TestID, string TestCaseDesc, string DateofTest, string TestResult, EventArgs e)
        {
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                SqlConnection con = new SqlConnection(constr);
                SqlCommand cmd1 = new SqlCommand("AddDet", con);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("@TestCaseID", TestID.Trim());
                cmd1.Parameters.AddWithValue("@TestCaseDesc", TestCaseDesc.Trim());
                cmd1.Parameters.AddWithValue("@DateOfTest", DateofTest.Trim());
                cmd1.Parameters.AddWithValue("@TestResult", TestResult.Trim());
                cmd1.Connection = con;
                con.Open();
                cmd1.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex)
            {
                
            }
            finally
            {

            }
        }
        public DataSet UpdateTestDetails(string TestID, string TestCaseDesc, string DateofTest, string TestResult, EventArgs e)
        {
            DataSet dt = null;
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("sp_update1", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "UPDATE");
                cmd.Parameters.AddWithValue("@TestCaseID", TestID.Trim());
                cmd.Parameters.AddWithValue("@TestCaseDesc", TestCaseDesc.Trim());
                cmd.Parameters.AddWithValue("@DateOfTest", DateofTest.Trim());
                cmd.Parameters.AddWithValue("@TestResult", TestResult.Trim());
                cmd.Connection = con;
                con.Open();
                SqlDA = new SqlDataAdapter(cmd);
                dt = new DataSet();
                SqlDA.Fill(dt);
                cmd.Dispose();
                con.Close();
            }
            return dt;
        }
        public DataSet DeleteTestDetails(string TestID, EventArgs e)
        {
            DataSet dt = null;
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_delete"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TestCaseID", TestID);
                    cmd.Connection = con;
                    con.Open();
                    SqlDA = new SqlDataAdapter(cmd);
                    dt = new DataSet();
                    SqlDA.Fill(dt);
                    cmd.Dispose();
                    con.Close();
                }
            }
            return dt;
        }

    }
}
