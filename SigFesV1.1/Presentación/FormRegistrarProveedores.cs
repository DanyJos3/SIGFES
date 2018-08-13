using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Entidades;
using Lógica;

namespace Presentación
{
    public partial class FormRegistrarProveedores : Form


    {
        private E_Proveedores objProveedor = new E_Proveedores();
        private L_Proveedores provedorCN = new L_Proveedores();

        public FormRegistrarProveedores()
        {
            InitializeComponent();
            llenarProvincias();
        }


        public void llenarCantones(String provincia)
        {
            cBcantones.DataSource = provedorCN.buscarCantones(provincia);
            cBcantones.DisplayMember = "NombreCanton";
            cBcantones.ValueMember = "idCanton";

        }

        public void llenarProvincias()
        {
            cBprovincias.DataSource = provedorCN.mostrarProvincias();
            cBprovincias.DisplayMember = "NombreProvincia";
            cBprovincias.ValueMember = "idProvincia";

        }

        private void cBcategoria_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            string error = "";
            //Console.WriteLine("Datos: {0}", txtNombreComercial.Text);
            try
            {


                /*if (txtNombreComercial.Text.Equals("") || txtNumeroTelefono.Text.Equals("") || txtCanton.Text.Equals("")
                    || txtCorreo.Text.Equals("") || txtDireccion.Text.Equals("") || txtRuc.Text.Equals("")
                    || txtRazonSocial.Text.Equals("") || cbxProvincias.SelectedIndex == 0)
                {
                    MessageBox.Show("Debe ingresar todos los campos");
                    error = "error";
                }
                */
                //error += validarNombre(txtNombreComercial.Text);
                error += validarRUC(txtRuc.Text.Trim());
                //error += validarTelefono(txtNumeroTelefono.Text);
                //error += validarMail(txtCorreo.Text);

                if (error.Equals(""))
                {
                    
                    objProveedor.NombreComercial = this.txtNombreComercial.Text.Trim();
                    objProveedor.Ruc = txtRuc.Text.Trim();
                    objProveedor.Provincia = cBprovincias.GetItemText(cBprovincias.SelectedIndex);
                    objProveedor.Canton = cBcantones.GetItemText(cBcantones.SelectedIndex);
                    objProveedor.Dirección = txtDireccion.Text.Trim();
                    objProveedor.NumeroTelefonoContacto = txtNumeroTelefono.Text.Trim();
                    objProveedor.RazonSocial = txtRazonSocial.Text.Trim();
                    objProveedor.CorreoElectronico = txtCorreo.Text.Trim();

                    
                    MessageBox.Show("Proveedor Ingresado Correctamente", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //txtNombreComercial.Text = "";
                    //txtRuc.Text = "";
                    //cBprovincias.ResetText();
                    //cBcantones.ResetText();
                    //txtDireccion.Text = "";
                    //txtRazonSocial.Text = "";
                    //txtNumeroTelefono.Text = "";
                    //txtCorreo.Text = "";

                }
                provedorCN.insertarProveedores(objProveedor);

            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo ingresar el proveedor por " + error, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void txtRuc_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtRuc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Console.WriteLine("----- Solo ingrese numero");

                e.Handled = true;
                return;
            }
        }

        private void TxtRuc_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (txtRuc.Text == "")
            {
                e.Cancel = true;
                txtRuc.Select(0, txtRuc.Text.Length);
                //errorProvider1.SetError(txtRuc, 
                Console.WriteLine("----- Debe introducir el nombre");
            }
        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbxProvincias_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenarCantones(Convert.ToString(cBprovincias.SelectedIndex+1));
        }

        public static string validarNombre(string nombre)
        {
            if (nombre.Length > 50)
                return "No puede ingresar mas de 50 caracteres en el campo nombre\n";
            return "";
        }


        public static string validarRUC(string numero)
        {
            if (numero.Length != 13)
                return "RUC ingresado incorrecto\n";

            //MessageBox.Show(numero);
            if ((esNumero(numero)))
            {
                MessageBox.Show(numero);
                return "";
            }

            if (validarCedula(numero.Substring(0, 10)))
            {
                if (numero.Substring(10, 3).Equals("001"))
                {
                    return "RUC correcto";
                    //MessageBox.Show("correcto");
                } 
            else
            {
                return "RUC ingresado incorrecto\n";
            }
            }
            else
            {
                MessageBox.Show("Cédula Incorrecta","ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return "RUC ingresado incorrecto\n";
            }

            return "";

        }

        public static bool validarCedula(string cedula)
        {


            char[] vector = cedula.ToArray();
            int final = 0;
            if (vector.Length == 10)

            {
                for (int i = 0; i < vector.Length - 1; i++)
                {
                    int numero = Convert.ToInt32(vector[i].ToString());
                    if ((i + 1) % 2 == 1)
                    {
                        numero = Convert.ToInt32(vector[i].ToString()) * 2;
                        if (numero > 9)
                        {
                            numero = numero - 9;
                        }
                    }
                    final += numero;
                }
                final = 10 - (final % 10);
                if (vector[vector.Length - 1].ToString().Equals(final.ToString()))
                {
                    // MessageBox.Show("CedulaCorrecta");
                    return true;
                }
                if (final > 9)
                {
                    if (vector[vector.Length - 1].ToString().Equals("0"))
                    {
                        return true;
                    }
                }
            }
            return false;


        }

        public static string validarTelefono(string telefono)
        {
            if (esNumero(telefono))
            {
                if (telefono.Length < 9 || telefono.Length > 10)
                    return "el telefono ingresado es incorrecto solo puede tener 9 o 10 digitos\n";
                else
                    return "";
            }
            else
            {
                return "solo debe ingresar digitos en el campo telefono\n";
            }

        }


        public static bool esNumero(string numero)
        {
            int valor;
            return int.TryParse(numero, out valor);
        }

        public static string validarMail(String email)
        {
            String expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    return "";
                }
                else
                {
                    return "Correo electronico incorrecto\n";
                }
            }
            else
            {
                return "Correo electronico incorrecto\n";
            }
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);


        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}


