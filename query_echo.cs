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
    public partial class echo_parameters : Form
    {
        public echo_parameters()
        {
            InitializeComponent();
            this.AcceptButton = okButton;
        }
        public string Arguments { get { return echoTextBox.Text; } }
        public bool FileWrite { get { return fileWriteCheckBox.Checked; } }
        public bool FileAppend { get { return appendCheckBox.Checked; } }
        public string FileName { get { return filenamesComboBox.Text; } }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            echoTextBox.Text = "";
            filenamesComboBox.Text = "";
            this.Close();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (!filenamesComboBox.Visible)
            {
                this.Height = this.Height + filenamesComboBox.Height+10;
                this.Size = new Size(this.Width, this.Height);
                filenamesComboBox.Visible = true;
                appendCheckBox.Visible = true;
            }
            else
            {
                this.Height = this.Height - filenamesComboBox.Height-10;
                this.Size = new Size(this.Width, this.Height);
                filenamesComboBox.Visible = false;
                appendCheckBox.Visible = false;
            }
        }
    }
}
