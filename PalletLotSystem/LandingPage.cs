using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalletLotSystem
{
    public partial class LandingPage : Form
    {
        public LandingPage()
        {
            InitializeComponent();
        }

        private void btnLayout_Click(object sender, EventArgs e)
        {
            Layout layout = new Layout();
            this.Hide();
            layout.Show();
            layout.FormClosed += (s, args) => this.Show();
        }
    }
}
