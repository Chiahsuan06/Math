using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Math
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSent_Click(object sender, EventArgs e)
        {
            MathCounting();
        }

        private void MathCounting()
        {
            string A = this.txtBaseNum.Text.ToString();
            int BaseNum = int.Parse(A);
            string B = this.txtCoefficientNum.Text.ToString();
            int CoefficientNum = int.Parse(B);
            if (BaseNum > 0 && CoefficientNum > 0)
            {
                for (int i = 1; i <= BaseNum; i++)
                {
                    for (int j = 1; j <= CoefficientNum; j++)
                    {
                        //i* j = { i * j };  //輸出至資料庫 和跳頁


                        InsertDataToDB(i, j);
                        Response.Redirect("Generator.aspx");
                    }
                }
            }
            else
            {
                this.lblMsg.Text = "請填正整數";
                this.lblMsg.ForeColor = Color.Red;
            }
        }

        private static void InsertDataToDB(int BaseNum , int CoefficientNum)
        {
            String sqlConnectionStr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection dataConnection = new SqlConnection(sqlConnectionStr);
            dataConnection.Open();

            string dbCommand =
                @"INSERT INTO [dbo].[Answers]
                        BaseNumber,
                        CoefficientNumber,
                  VALUES
                   (
                        @BaseNumber,
                        @CoefficientNumber,
                    )
                ";
            SqlCommand mySqlCmd = new SqlCommand(dbCommand, dataConnection);

            mySqlCmd.Parameters.AddWithValue("@BaseNumber", BaseNum);
            mySqlCmd.Parameters.AddWithValue("@CoefficientNumber", CoefficientNum);

            mySqlCmd.ExecuteNonQuery();
           
            dataConnection.Close();
            mySqlCmd.Cancel();
            dataConnection.Close();
            dataConnection.Dispose();

            try
            {
                dataConnection.ConnectionString = sqlConnectionStr;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }
    }
}