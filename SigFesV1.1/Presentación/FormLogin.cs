using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Data.SqlClient;
using Entidades;
using Lógica;

namespace Presentación

{
    public partial class FormLogin : Form
    {
        
        


        public FormLogin()
        {
            InitializeComponent();

            //this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }


        //Para los efectos de color en label
        private void txtUser_Enter(object sender, EventArgs e)
        {
            if (txtUser.Text == "USUARIO")
            {
                txtUser.Text = "";
                txtUser.ForeColor = Color.LightGray;
            }
        }

        private void txtUser_Leave(object sender, EventArgs e)
        {

            if (txtUser.Text == "")
            {
                txtUser.Text = "USUARIO";
                txtUser.ForeColor = Color.DimGray;
            }
        }

        private void txtPass_Enter(object sender, EventArgs e)
        {
            if (txtPass.Text == "CONTRASEÑA")
            {
                txtPass.Text = "";
                txtPass.ForeColor = Color.LightGray;
                txtPass.UseSystemPasswordChar = true;
            }
        }

        private void txtPass_Leave(object sender, EventArgs e)
        {

            if (txtPass.Text == "")
            {
                txtPass.Text = "CONTRASEÑA";
                txtPass.ForeColor = Color.DimGray;
                //txtPass.UseSystemPasswordChar = true;

            }
        }



        //Todo esto es para redimensionar el form con los paneles.
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);




        //Este evento hace que se pueda mover desde un panel y con el método anterior
        private void FormLogin_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }





        //Acciones de los botones
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
       

        private void btbLogin_Click_1(object sender, EventArgs e)
        {
            iniciarSesion();
        }



        //Métodos para el login

        private void iniciarSesion()
        {
            E_Usuario objUsuario = new E_Usuario();
            L_Usuario _logica = new L_Usuario();


            SqlDataReader loguear;

            objUsuario.Cedúla = txtUser.Text.Trim();
            objUsuario.Constraseña = txtPass.Text.Trim();

            loguear = _logica.iniciarSesion(objUsuario);

            if (loguear.Read() == true)
            {

                this.Hide(); // se cierra el login
                FormMenu principal = new FormMenu();
                principal.Show();
            }
            else
            {
                MessageBox.Show("El Usuario o la Contraseña son incorrectos");
            }
        }


    }
}
