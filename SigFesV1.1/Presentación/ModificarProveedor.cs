using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Entidades;
using Lógica;
using System.Runtime.InteropServices;

namespace Presentación
{
    public partial class ModificarProveedor : Form

    
    {
        private E_Proveedores objProveedor = new E_Proveedores();
        private L_Proveedores objProvee = new L_Proveedores();

        public ModificarProveedor(E_Proveedores proveedor, Proveedor formulario)
        {
            InitializeComponent();
            this.txtNombreComercial.Text = proveedor.NombreComercial;
            this.txtRUC.Text = proveedor.Ruc;
            this.txtDireccion.Text = proveedor.Dirección;
            this.txtTelfContacto.Text = proveedor.NumeroTelefonoContacto;
            this.txtRazonSocial.Text = proveedor.RazonSocial;
            this.txtCorreoelectronico.Text = proveedor.CorreoElectronico;
           
            if (proveedor.Estado)
            {
                this.estado.SelectedIndex = 0;
            }
            else
            {
                this.estado.SelectedIndex = 1;
            }

            this.cBprovincia.Text = proveedor.Provincia;
            this.cBcanton.Text = proveedor.Canton;
        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
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
                error += validarNombre(txtNombreComercial.Text);
                error += validarRUC(txtRUC.Text);
                error += validarTelefono(txtTelfContacto.Text);
                error += validarMail(txtCorreoelectronico.Text);

                if (error.Equals(""))
                {
                    objProveedor.NombreComercial = txtNombreComercial.Text.Trim();
                    objProveedor.Ruc = txtRUC.Text.Trim();
                    objProveedor.Provincia = cBprovincia.GetItemText(cBprovincia.SelectedIndex);
                    objProveedor.Canton = cBcanton.GetItemText(cBcanton.SelectedIndex);
                    objProveedor.Dirección = txtDireccion.Text.Trim();
                    objProveedor.NumeroTelefonoContacto = txtTelfContacto.Text.Trim();
                    objProveedor.RazonSocial = txtRazonSocial.Text;
                    objProveedor.CorreoElectronico = txtCorreoelectronico.Text.Trim();

                    MessageBox.Show("Proveedor Actualizado Correctamente", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    /*txtNombreComercial.Text = "";
                    txtRuc.Text = "";
                    cbxProvincias.ResetText();
                    txtCanton.Text = "";
                    txtDireccion.Text = "";
                    txtRazonSocial.Text = "";
                    txtNumeroTelefono.Text = "";
                    txtCorreo.Text = "";*/
                    objProvee.modificarProveedor(objProveedor);
                    //Proveedor proveedor1 = new Proveedor();
                    //proveedor1.mostarTodos();*/
                    
                }

                else
                {
                    MessageBox.Show(error);
                }


              

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
            if (txtRUC.Text == "")
            {
                e.Cancel = true;
                txtRUC.Select(0, txtRUC.Text.Length);
                //errorProvider1.SetError(txtRuc, 
                Console.WriteLine("----- Debe introducir el nombre");
            }
        }

        /*private void btnSalir_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }*/

        private void cbxProvincias_SelectedIndexChanged(object sender, EventArgs e)
        {

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
               // MessageBox.Show(numero);
                return "";
            }

            if (validarCedula(numero.Substring(0, 10)))
            {
                if (numero.Substring(10, 3).Equals("001"))
                {//return "RUC correcto";
                 //MessageBox.Show("correcto");
                }
                else
                {
                    return "RUC ingresado incorrecto\n";
                }
            }
            else
            {
                //MessageBox.Show("cedula");
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

        private void cBprovincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cBprovincia.Items.Clear();
            llenarProvincias();
        }

        private void cBcanton_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cBcanton.Items.Clear();
             llenarCantones(Convert.ToString(cBprovincia.SelectedIndex+1));
        }


        public void llenarCantones(String provincia)
        {
            cBcanton.DataSource = objProvee.buscarCantones(provincia);
            cBcanton.DisplayMember = "NombreCanton";
            cBcanton.ValueMember = "idCanton";

        }

        public void llenarProvincias()
        {
            cBprovincia.DataSource = objProvee.mostrarProvincias();
            cBprovincia.DisplayMember = "NombreProvincia";
            cBprovincia.ValueMember = "idProvincia";

        }



        //Todo esto es para redimensionar el form con los paneles.
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
    

