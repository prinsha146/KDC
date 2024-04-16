using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KDC.DESKTOP
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            //mnuAddCandidate.Visible = false;
        }

        private void mnuAddCandidate_Click(object sender, EventArgs e)
        {
            FrmCandidateAdd frm1 = new FrmCandidateAdd();
            frm1.MdiParent = this;
            frm1.Show();
        }

        private void mnuCandidateVerify_Click(object sender, EventArgs e)
        {
            FrmCandidateVerify frm1 = new FrmCandidateVerify();
            frm1.MdiParent = this;
            frm1.Show();
        }

        private void editCandidateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCandidateAdd frm1 = new FrmCandidateAdd();
            frm1.formMode = "EDIT";
            frm1.MdiParent = this;
            frm1.Show();
        }
    }
}
