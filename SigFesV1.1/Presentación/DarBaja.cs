using Entidades;
using Lógica;
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
    public partial class DarBaja : Form
    {
        E_Producto objProducto;
        L_Productos productoCN = new L_Productos();
        public int codigo;
        public decimal stock;
        public string umedida;


        public DarBaja()
        {
            InitializeComponent();


        }

        public void mostrarBotones()
        {
            if (this.umedida.Equals("Unidades") || this.umedida.Equals("Cajas") || this.umedida.Equals("Resmas"))
            {
                this.tBcantidad.Visible = false;
                this.tBcantidad1.Visible = true;
            }
            else
            {
                this.tBcantidad.Visible = true;
                this.tBcantidad1.Visible = false;
            }
        }


        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
        private void tBcantidad_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }


            bool IsDec = false;
            int nroDec = 0;

            for (int i = 0; i < tBcantidad.Text.Length; i++)
            {
                if (tBcantidad.Text[i] == ',' )
                    IsDec = true;

                if (IsDec && nroDec++ >= 2)
                {
                    e.Handled = true;
                    return;
                }
            }

            if (e.KeyChar >= 48 && e.KeyChar <= 57)
                e.Handled = false;
            else if (e.KeyChar == 44)
                e.Handled = (IsDec) ? true : false;
            else
                e.Handled = true;
        }

        private void tBcatidad1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void DarBaja_Load(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            
            if (this.umedida.Equals("Unidades") || this.umedida.Equals("Cajas") || this.umedida.Equals("Resmas"))
            {
                int aux = Convert.ToInt16(this.tBcantidad1.Text);
                if (aux >= 0 && aux <= this.stock)
                {
                    int aux2 = Convert.ToInt16(stock);
                    int aux3 = aux2 - aux;
                    productoCN.modificarStock(this.codigo,Convert.ToString(aux3));
                    MessageBox.Show("Stock modificado exitosamente", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();

                }
                else
                {
                    MessageBox.Show("Cantidad Incorrecta", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            else
            {
                
                decimal aux = Convert.ToDecimal(this.tBcantidad.Text);
                if (aux >= 0 && aux <= this.stock)
                {
                    
                    decimal aux2 = stock - aux;

                    productoCN.modificarStock(this.codigo, Convert.ToString(aux2));
                    MessageBox.Show("Stock modificado exitosamente", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();


                }
                else
                {
                    MessageBox.Show("Cantidad Incorrecta", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }

        }
    }
}
