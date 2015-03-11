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
    public partial class query_label : Form
    {
        public query_label()
        {
            InitializeComponent();
            this.AcceptButton = okButton;
        }
        public string labelText { get { return labelTextBox.Text; } }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
