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
    public partial class FormModificarOp : Form
    {
        public FormModificarOp()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormModificarNatural frm = new FormModificarNatural();
            frm.Show();
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormModificarJuridico frm1 = new FormModificarJuridico();
            frm1.Show();
            this.Dispose();
        }
    }
}
