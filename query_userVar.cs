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
    public partial class query_userVar : Form
    {
        public query_userVar()
        {
            InitializeComponent();
            this.AcceptButton = okButton;
        }
        private string varNameString = "";
        private string varQueryString = "";

        public string varName { get { return varNameString; } }
        public string varQuery { get { return varQueryString; } }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (varNameTextBox.Text == "")
            {
                MessageBox.Show("Variable needs a name!", "Name the Variable");
            }
            else
            {
                varNameString = varNameTextBox.Text;
                varQueryString = VarQueryTextBox.Text;
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
