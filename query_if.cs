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
    public partial class query_if : Form
    {
        public query_if(List<string> labels, List<string> variables)
        {
            InitializeComponent();
            this.AcceptButton = okButton;
            foreach (string label in labels)
            {
                labelComboBox.Items.Add(label);
            }
            foreach (string variable in variables)
            {
                ExistsOrNotComboBox.Items.Add(variable);
            }
            fileCommandComboBox.Items.Add("goto");

            typeOfIfComboBox.Items.Add("If File exists Do");
            typeOfIfComboBox.Items.Add("Compare two variables, Do");
            typeOfIfComboBox.Items.Add("If Errorlevel Do");

        }
        private string varNameString = "";
        private string varCompareToString = "";
        private string reactionString = "";
        private string reactionLabelString = "";

        public string varName { get { return varNameString; } }
        public string varCompareTo { get { return varCompareToString; } }
        public string reactionS { get { return reactionString; } }
        public string reactionLabelS { get { return reactionLabelString; } }


        private void okButton_Click(object sender, EventArgs e)
        {
            if (ExistsOrNotComboBox.SelectedItem.ToString() == "")
            {
                MessageBox.Show("Please select a variable!", "Choose a Variable");
            }
            else if (varCompareTextBox.Text == "")
            {
                MessageBox.Show("You must input a value against witch the variable is tested!", "Argument needed");
            }

            else
            {
                varNameString = ExistsOrNotComboBox.SelectedItem.ToString();
                varCompareToString = varCompareTextBox.Text;
                reactionString = fileCommandComboBox.SelectedItem.ToString();
                reactionLabelString = labelComboBox.SelectedItem.ToString();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }

        }

        private void typeOfIfComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //If file exists do
            if (typeOfIfComboBox.SelectedIndex == 0)
            {
                if (!IfErrorlevelGroupBox.Visible && !IfVarGroupBox.Visible && !IfFileGroupBox.Visible)
                {
                    this.Height = this.Height + IfFileGroupBox.Height;
                }
                this.Width = IfFileGroupBox.Width + 45;
                this.Size = new Size(this.Width, this.Height);

                IfFileGroupBox.Visible = true;
                IfVarGroupBox.Visible = false;
                IfErrorlevelGroupBox.Visible = false;

            }

            //Compare two variables, do
            if (typeOfIfComboBox.SelectedIndex == 1)
            {
                IfVarGroupBox.Location = new Point(IfFileGroupBox.Location.X, IfFileGroupBox.Location.Y);
                if (!IfErrorlevelGroupBox.Visible && !IfVarGroupBox.Visible && !IfFileGroupBox.Visible)
                {
                    this.Height = this.Height + IfVarGroupBox.Height;
                }
                this.Width = IfFileGroupBox.Width + 45;
                this.Size = new Size(this.Width, this.Height);
                IfFileGroupBox.Visible = false;
                IfVarGroupBox.Visible = true;
                IfErrorlevelGroupBox.Visible = false;

            }
            //If errorlevel, do
            if (typeOfIfComboBox.SelectedIndex == 2)
            {
                IfErrorlevelGroupBox.Location = new Point(IfFileGroupBox.Location.X, IfFileGroupBox.Location.Y);
                if (!IfErrorlevelGroupBox.Visible && !IfVarGroupBox.Visible && !IfFileGroupBox.Visible)
                {
                    this.Height = this.Height + IfErrorlevelGroupBox.Height;
                }
                this.Width = IfErrorlevelGroupBox.Width + 45;
                this.Size = new Size(this.Width, this.Height);
                IfFileGroupBox.Visible = false;
                IfVarGroupBox.Visible = false;
                IfErrorlevelGroupBox.Visible = true;

            }


        }

        private void query_if_Load(object sender, EventArgs e)
        {
            this.Height = this.Height - IfFileGroupBox.Height - IfErrorlevelGroupBox.Height - IfVarGroupBox.Height - 15;
            this.Width = this.Width - 610;
            this.Size = new Size(this.Width, this.Height);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                elseFileLabel1.Enabled = true;
                elseFileLabel2.Enabled = true;
                elseFileCommandComboBox.Enabled = true;
                elseFileLabelComboBox.Enabled = true;
            }
            else
            {
                elseFileLabel1.Enabled = false;
                elseFileLabel2.Enabled = false;
                elseFileCommandComboBox.Enabled = false;
                elseFileLabelComboBox.Enabled = false;
            }

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                elseVarLabel1.Enabled = true;
                elseVarLabel2.Enabled = true;
                elseVarCommandComboBox.Enabled = true;
                elseVarLabelComboBox.Enabled = true;
            }
            else
            {
                elseVarLabel1.Enabled = false;
                elseVarLabel2.Enabled = false;
                elseVarCommandComboBox.Enabled = false;
                elseVarLabelComboBox.Enabled = false;
            }
        }

    }
}
