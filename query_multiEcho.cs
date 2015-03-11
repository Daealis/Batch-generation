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
    public partial class query_multiEcho : Form
    {
        public query_multiEcho()
        {
            InitializeComponent();
        }

        public static string Repeat(char c, int n)
        {
            return new String(c, n);
        }

        public bool FileWrite{ get { return fileWriteCheckBox.Checked; } }
        public bool FileAppend { get { return appendCheckBox.Checked; } }
        public string FileName { get { return filenamesComboBox.Text; } }

        public RichTextBox getText
        {
            get
            {
                RichTextBox returnbox = new RichTextBox();
                if (framingCheckBox.Checked == false)
                {
                    returnbox = multiechoRichTextBox;
                }
                else
                {
                    int maxlenght = 0;

                    //get the longest line in the text
                    foreach (string line in multiechoRichTextBox.Lines)
                    {
                        if (line.Length >= maxlenght)
                            maxlenght = line.Length;
                    }

                    //add the chars to make a frame for the text
                    returnbox.Text += "+" + Repeat('-', maxlenght) + "+" + Environment.NewLine;
                    foreach (string line in multiechoRichTextBox.Lines)
                    {
                        returnbox.Text += "^|" + line + Repeat(' ', maxlenght - line.Length) + "^|" + Environment.NewLine;
                    }
                    returnbox.Text += "+" + Repeat('-', maxlenght) + "+";
                }
                return returnbox;
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (!filenamesComboBox.Visible)
            {
                this.Height = this.Height + filenamesComboBox.Height + 10;
                this.Size = new Size(this.Width, this.Height);
                filenamesComboBox.Visible = true;
                appendCheckBox.Visible = true;
            }
            else
            {
                this.Height = this.Height - filenamesComboBox.Height - 10;
                this.Size = new Size(this.Width, this.Height);
                appendCheckBox.Visible = false;
                filenamesComboBox.Visible = false;
            }

        }
    }
}
