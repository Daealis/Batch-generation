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
    public partial class query_color : Form
    {
        public query_color()
        {
            InitializeComponent();
        }

        public string BGColor { get { return ColorCode(backgroundColorGroupBox.Controls.OfType<RadioButton>().SingleOrDefault(rad=>rad.Checked==true).TabIndex); } }
        public string TColor { get { return ColorCode(textColorGroupBox.Controls.OfType<RadioButton>().SingleOrDefault(rad => rad.Checked == true).TabIndex); } }

        private string ColorCode(int index)
        {
            string choice = "0";
            switch (index)
            {
                case 0: choice = "0"; break;
                case 1: choice = "8"; break;
                case 2: choice = "7"; break;
                case 3: choice = "F"; break;
                case 4: choice = "1"; break;
                case 5: choice = "9"; break;
                case 6: choice = "3"; break;
                case 7: choice = "B"; break;
                case 8: choice = "5"; break;
                case 9: choice = "D"; break;
                case 10: choice = "4"; break;
                case 11: choice = "C"; break;
                case 12: choice = "2"; break;
                case 13: choice = "A"; break;
                case 14: choice = "6"; break;
                case 15: choice = "E"; break;
                default: choice = "0"; break;
            }
            return choice;
        }

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
