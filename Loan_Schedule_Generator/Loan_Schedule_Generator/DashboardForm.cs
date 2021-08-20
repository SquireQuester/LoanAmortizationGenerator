using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Loan_Schedule_Generator
{

    public partial class DashboardForm : Form
    {
        public DashboardForm()
        {
            InitializeComponent();
        }

        private void dim_ClientBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.dim_ClientBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.db_LoanDataSet1);

        }

        private void dim_ClientBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.dim_ClientBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.db_LoanDataSet1);

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'db_LoanDataSet1.Dim_Client' table. You can move, or remove it, as needed.
            this.dim_ClientTableAdapter.Fill(this.db_LoanDataSet1.Dim_Client);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Goes to a screen where you can generate new loans
            this.Hide();
            LoanGeneratorForm LG = new LoanGeneratorForm();
            LG.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Goes to a screen where you can view the generated Amortization Schedule
            this.Hide();
            AmortizationScheduleViewerForm ASV = new AmortizationScheduleViewerForm();
            ASV.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            //Goes to a screen where you can edit the selected Client
            this.Hide();
            LoanGeneratorForm LG = new LoanGeneratorForm();
            LG.Show();
        }
    }
}
