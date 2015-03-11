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
    public partial class query_pause : Form
    {
        public query_pause()
        {
            InitializeComponent();
            pauseButton.Checked = true;
        }

        public bool HidePause { get { return hideCheckBox.Checked; } }
        public int SleepTime { get { return (int)numericUpDown.Value; } }
        public bool PauseOrSleep
        {
            get
            {
                if (pauseButton.Checked)
                    return true;
                else
                    return false;
            }
        }

        private void buttonsChecked(object sender, EventArgs e)
        {
            if (pauseButton.Checked)
            {
                hideCheckBox.Enabled = true;
                numericLabel.Enabled = false;
                numericUpDown.Enabled = false;
            }
            else
            {
                hideCheckBox.Enabled = false;
                numericLabel.Enabled = true;
                numericUpDown.Enabled = true;

            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            hideCheckBox.Checked = false;
            numericUpDown.Value = 1;
            this.Close();
        }

    }
}
