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
    public partial class AmortizationScheduleViewerForm : Form
    {
        public AmortizationScheduleViewerForm()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

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
