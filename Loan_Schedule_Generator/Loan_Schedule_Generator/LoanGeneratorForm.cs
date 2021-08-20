using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Loan_Schedule_Generator
{
    public partial class LoanGeneratorForm : Form
    {
       
        public LoanGeneratorForm()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void LoanGeneratorForm_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connetionString;
            SqlConnection cnn;
            connetionString = @"Server=localhost;Database=db_Loan;Trusted_Connection=True;";
            cnn = new SqlConnection(connetionString);
            cnn.Open();

            //SELECT STATEMENT - Searching for Max ID of Client_ID from Dim_Client
            SqlCommand command;
            SqlDataReader dataReader;
            String sql, MaxLoanID = "", MaxDateID = "";

            sql = "SELECT MAX(loan_ID) FROM Dim_Client";

            command = new SqlCommand(sql, cnn);

            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                MaxLoanID = MaxLoanID + dataReader.GetValue(0);
            }
            dataReader.Close();



            //INSERT QUERY STATEMENT TO DIM_CLIENT
            SqlDataAdapter adapter = new SqlDataAdapter();

            int NewLoanID = Int32.Parse(MaxLoanID) + 1;

            sql = "INSERT INTO Dim_Client VALUES (" + Convert.ToInt32(NewLoanID) + ", '" + txtname.Text + "', '" + Convert.ToInt32(txtRate.Text) + "', '" + Convert.ToDouble(txtLoanAmnt.Text) + "', '" + 25000 + "', '" + Convert.ToInt32(txtTerm.Text) + "')";

            command = new SqlCommand(sql, cnn);

            adapter.InsertCommand = command;
            adapter.InsertCommand.ExecuteNonQuery();

            dataReader.Close();




            //SELECT STATEMENT - Searching for Max ID of Date_ID from Dim_Dates

            //sql = "SELECT MAX(date_ID) FROM Dim_Dates";

            //command = new SqlCommand(sql, cnn);

            //dataReader = command.ExecuteReader();

            //while (dataReader.Read())
            //{
            //    MaxDateID = MaxDateID + dataReader.GetValue(0);
            //}

            //dataReader.Close();



            ////INSERT QUERY STATEMENT TO DIM_Date
            //DateTime @date;
            //@date = dateTimePicker1.Value.Date;

            //int NewDateID = Int32.Parse(MaxDateID) + 1;

            //sql = "INSERT INTO Dim_DATES VALUES (" + Convert.ToInt32(NewDateID) + ", "+@date+", GETDATE(), GETDATE())";

            ////command.Parameters.Add(new SqlParameter("@date", dateTimePicker1.Value.Date));

            //command = new SqlCommand(sql, cnn);

            //adapter.InsertCommand = command;
            //adapter.InsertCommand.ExecuteNonQuery();

            //dataReader.Close();
            //command.Dispose();
            //cnn.Close();




            //Goes to a screen where you can view the generated Amortization Schedule
            MessageBox.Show("New Loan Generated!");
            this.Hide();
            AmortizationScheduleViewerForm ASV = new AmortizationScheduleViewerForm();
            ASV.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Goes back to the Dashboard
            this.Hide();
            DashboardForm DB = new DashboardForm();
            DB.Show();
        }
    }
}
