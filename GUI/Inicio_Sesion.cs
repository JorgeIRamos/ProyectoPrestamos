using Entidades;
using Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class Inicio_Sesion : Form
    {
        private Service<Persona> servicePersona;
        private Service<Prestamista> servicePrestamista;
        private Service<Prestatario> servicePrestatario;
        public Inicio_Sesion()
        {
            servicePersona = new Service<Persona>();
            servicePrestamista = new Service<Prestamista>();
            servicePrestatario = new Service<Prestatario>();
            InitializeComponent();
        }

        private void btninicio_sesion_Click(object sender, EventArgs e)
        {
            if (!UsuarioVacio() || !ContrasenaVacia())
            {
                return;
            }

            if (!ValidarCredenciales())
            {
                return;
            }

            if (AbrirPrestamista() || AbrirPrestatario())
            {
                return;
            }
        }

        private void btnregistrarse_Click(object sender, EventArgs e)
        {
            this.Hide();
            Registro_Usuario registro_Usuario = new Registro_Usuario();
            registro_Usuario.ShowDialog();
            this.Show();
        }

        private bool UsuarioVacio()
        {
            string usuario = txtusuario.Text.Trim();
            if (string.IsNullOrEmpty(usuario))
            {
                MessageBox.Show("El usuario no esta digitado de manera correcta.");
                return false;
            }
            return true;
        }

        private bool ContrasenaVacia()
        {
            string contrasena = txtcontraseña.Text.Trim();
            if (string.IsNullOrEmpty(contrasena))
            {
                MessageBox.Show("La contraseña no esta digitada de manera correcta.");
                return false;
            }
            return true;
        }

        private bool ValidarCredenciales()
        {
            string usuario = txtusuario.Text.Trim();
            string contrasena = txtcontraseña.Text.Trim();
            servicePersona.AbrirConexion();
            var listapersona = servicePersona.Consultar(new Persona());

            bool combinacionCorrecta = listapersona.Any(p => p.username == usuario && p.contraseña == contrasena);
            if (!combinacionCorrecta)
            {
                MessageBox.Show("El usuario y la contraseña no corresponden a la misma persona.");
                return false;
            }
            servicePersona.CerrarConexion();
            return true;
            
        }

        private bool AbrirPrestamista()
        {
            servicePrestamista.AbrirConexion();
            var listaprestamista = servicePrestamista.Consultar(new Prestamista());
            foreach (var prestamista in listaprestamista)
            {
                if (prestamista.Persona.username == txtusuario.Text.Trim() && prestamista.Persona.contraseña == txtcontraseña.Text.Trim())
                {
                    this.Hide();
                    txtusuario.Text = "";
                    txtcontraseña.Text = "";
                    Menu_Prestamista menu_Prestamista = new Menu_Prestamista(prestamista.id_prestamista, prestamista.Persona.nombre);
                    menu_Prestamista.ShowDialog();
                    this.Show();
                    return true;
                }
            }
            servicePrestamista.CerrarConexion();
            return false;
        }

        private bool AbrirPrestatario()
        {
            servicePrestatario.AbrirConexion();
            var listaprestatario = servicePrestatario.Consultar(new Prestatario());
            foreach (var prestatario in listaprestatario)
            {
                if (prestatario.Persona.username == txtusuario.Text.Trim() && prestatario.Persona.contraseña == txtcontraseña.Text.Trim())
                {
                    this.Hide();
                    txtusuario.Text = "";
                    txtcontraseña.Text = "";
                    Menu_Prestatario menu_Prestatario = new Menu_Prestatario();
                    menu_Prestatario.ShowDialog();
                    this.Show();
                    return true;
                }
            }
            servicePrestatario.CerrarConexion();
            return false;
        }
    }
}
