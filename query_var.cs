using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Batch_generation
{
    public partial class query_var : Form
    {
        public query_var()
        {
            InitializeComponent();
            this.AcceptButton = okButton;
        }
        private string varNameString = "";
        private string varValueString = "";

        public string varName { get { return varNameString; } }
        public string varValue { get { return varValueString; } }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (varNameTextBox.Text == "")
            {
                MessageBox.Show("Variable needs a name!", "Name the Variable");
            }
            else if (VarValueTextBox.Text == "")
            {
                MessageBox.Show("Variable needs a value!", "Give a value");
            }
            else
            {
                varNameString = varNameTextBox.Text;
                varValueString = VarValueTextBox.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
