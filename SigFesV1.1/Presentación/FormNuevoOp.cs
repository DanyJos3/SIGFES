using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Presentación
{
    public partial class FormNuevoOp : Form
    {
        public FormNuevoOp()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormNuevoNatural frm = new FormNuevoNatural();
            frm.Show();
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormNuevoJuridico frm1 = new FormNuevoJuridico();
            frm1.Show();
            this.Dispose();
        }
    }
}
