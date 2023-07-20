using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Memory_Game
{
    public partial class frmPlayerInfo : Form
    {
        public string FullName { get; private set; }
        public frmPlayerInfo()
        {
            InitializeComponent();
        }

        private void frmPlayerInfo_Load(object sender, EventArgs e)
        {
            this.Text = "Player Info";

        }
        private void txtFullName_Validating_1(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFullName, "Full Name Should be have a value");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtFullName, "");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FullName = txtFullName.Text;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
