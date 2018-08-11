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
    public partial class FormCliente : Form
    {
        public FormCliente()
        {
            InitializeComponent();
            tableLayoutPanel5.Visible=false;
            tableLayoutPanel6.Visible=false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox1.Items.Insert(0, "Cedula de identidad");
            comboBox1.Items.Insert(1, "Nombre");
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox1.Items.Insert(0, "RUC");
            comboBox1.Items.Insert(1, "Nombre comercial");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //FormNuevoOp frm = new FormNuevoOp();
            //frm.Show();
            tableLayoutPanel6.Visible=false;
            tableLayoutPanel5.Visible=true;
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //FormModificarOp frm1 = new FormModificarOp();
            //frm1.Show();
            tableLayoutPanel5.Visible=false;
            tableLayoutPanel6.Visible=true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormNuevoNatural frm = new FormNuevoNatural();
            frm.Show();
            tableLayoutPanel5.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FormNuevoJuridico frm1 = new FormNuevoJuridico();
            frm1.Show();
            tableLayoutPanel5.Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FormModificarNatural frm = new FormModificarNatural();
            frm.Show();
            tableLayoutPanel6.Visible = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            FormModificarJuridico frm1 = new FormModificarJuridico();
            frm1.Show();
            tableLayoutPanel6.Visible = false;
        }
    }
}
