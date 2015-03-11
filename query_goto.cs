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
    public partial class query_goto : Form
    {
        public query_goto(List<string> labels)
        {
            InitializeComponent();
            this.AcceptButton = okButton;
            foreach (string label in labels)
            {
                gotoComboBox.Items.Add(label);
            }
        }
        private string gototext = "";

        public string gotoText { get { return gototext; } }

        private void okButton_Click(object sender, EventArgs e)
        {
            gototext = gotoComboBox.SelectedItem.ToString();
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void query_goto_Load(object sender, EventArgs e)
        {

        }

    }
}
