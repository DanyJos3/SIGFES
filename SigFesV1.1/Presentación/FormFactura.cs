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
    public partial class FormFactura : Form
    {
        FormMenu frmMenu;
        public FormFactura(FormMenu frm)
        {
            InitializeComponent();
            frmMenu = frm;
        }

        private void btnNuevaVenta_Click(object sender, EventArgs e)
        {
            NuevaVenta frm = new NuevaVenta();
            //frm.FormClosed += new FormClosedEventHandler(mostrarlogoAlCerrarForm);
            //AbrirFormInPanel(frm);
            frm.ShowDialog();
        }

        private void mostrarlogoAlCerrarForm(object sender, FormClosedEventArgs e)
        {
            mostrarlogo();
        }

        private void mostrarlogo()
        {
            AbrirFormInPanel(new FormSello());
        }

        private void AbrirFormInPanel(object formHijo)
        {
            if (frmMenu.panelContenedor.Controls.Count > 0)
                frmMenu.panelContenedor.Controls.RemoveAt(0);
            Form fh = formHijo as Form;
            fh.TopLevel = false;
            fh.FormBorderStyle = FormBorderStyle.None;
            fh.Dock = DockStyle.Fill;
            frmMenu.panelContenedor.Controls.Add(fh);
            frmMenu.panelContenedor.Tag = fh;
            fh.Show();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            ModificarFactura frm = new ModificarFactura();
            if (dGVfacturas.SelectedRows.Count > 0)
            {
                //frm.tBcodigo.Text = dGVfacturas.CurrentRow.Cells[0].Value.ToString();
                //frm.cBcategoria.Items.Insert(0, dGVfacturas.CurrentRow.Cells[1].Value.ToString());
                //frm.cBcategoria.SelectedIndex = 0;
                //frm.tBtipo.Text = dGVfacturas.CurrentRow.Cells[2].Value.ToString();
                //frm.tBmarca.Text = dGVfacturas.CurrentRow.Cells[3].Value.ToString();
                //frm.tBserie.Text = dGVfacturas.CurrentRow.Cells[4].Value.ToString();
                //frm.tBdescrip.Text = dGVfacturas.CurrentRow.Cells[5].Value.ToString();
                //frm.tBprecioCompra.Text = dGVfacturas.CurrentRow.Cells[6].Value.ToString();
                //frm.cBunidadMedida.Items.Insert(0, dGVfacturas.CurrentRow.Cells[7].Value.ToString());
                //frm.cBunidadMedida.SelectedIndex = 0;
                //frm.tBstock.Text = dGVfacturas.CurrentRow.Cells[8].Value.ToString();
                //frm.cBproveedor.Items.Insert(0, dGVfacturas.CurrentRow.Cells[9].Value.ToString());
                //frm.cBproveedor.SelectedIndex = 0;
                //frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("No se ha seleccionado una fila","ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error,MessageBoxDefaultButton.Button1);
                frm.ShowDialog();
            }
        }
    }
}
