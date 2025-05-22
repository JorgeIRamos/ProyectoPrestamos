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

    public partial class Registro_Usuario : Form
    {
        private Service<Persona> servicePersona;
        public Registro_Usuario()
        {
            servicePersona = new Service<Persona>();
            InitializeComponent();
        }

        

        private void btningresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnregistrar_Click(object sender, EventArgs e)
        {
            if (!ValidarNombre() || !ValidarApellido() || !validarTipoDocumento() || !ValidarNumeroDocumento() || !ValidarTelefono() || !validarSexo() ||!ValidarDireccion() || !ValidarEmail() || !ValidarUsuario() || !validarContrasena() || !validarConfirmarContrasena() || !validarRol())
            {
                return;
            }
        }

        private bool ValidarNombre()
        {
            string nombre = txtnombre.Text.Trim();
            if (string.IsNullOrEmpty(nombre) || nombre.Any(char.IsDigit))
            {
                MessageBox.Show("El nombre no esta digitado de manera correcta.");
                return false;
            }
            return true;
        }

        private bool ValidarApellido()
        {
            string apellido = txtapellido.Text.Trim();
            if (string.IsNullOrEmpty(apellido) || apellido.Any(char.IsDigit))
            {
                MessageBox.Show("El apellido no esta digitado de manera correcta.");
                return false;
            }
            return true;
        }

        private bool validarTipoDocumento()
        {
            if (boxtipodocumento.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un tipo de documento.");
                boxtipodocumento.Focus();
                return false;
            }
            return true;
        }
        private bool ValidarNumeroDocumento()
        {
            string nrodocumento = txtnrodocumento.Text.Trim();
            if (string.IsNullOrEmpty(nrodocumento) || !nrodocumento.All(char.IsDigit))
            {
                MessageBox.Show("El numero de documento no esta digitado de manera correcta.");
                return false;
            }
            return true;
        }

        private bool ValidarTelefono()
        {
            string telefono = txttelefono.Text.Trim();
            if (string.IsNullOrEmpty(telefono) || !telefono.All(char.IsDigit))
            {
                MessageBox.Show("El telefono no esta digitado de manera correcta.");
                return false;
            }
            return true;
        }

        private bool validarSexo()
        {
            if (boxsexo.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un tipo de documento.");
                boxsexo.Focus();
                return false;
            }
            return true;
        }

        private bool ValidarDireccion()
        {
            string direccion = txtdireccion.Text.Trim();
            if (string.IsNullOrEmpty(direccion))
            {
                MessageBox.Show("la direccion no puede estar vacia.");
                return false;
            }
            return true;
        }

        private bool ValidarEmail()
        {
            servicePersona.AbrirConexion();
            string email = txtemail.Text.Trim();
            var listapersona = servicePersona.Consultar(new Persona());
            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("El email no puede estar vacio.");
                return false;
            }

            foreach (var persona in listapersona)
            {
                if (persona.email == email)
                {
                    MessageBox.Show("El email ya esta registrado por otro usuario.");
                    return false;
                }
            }
            return true;
        }

        private bool ValidarUsuario()
        {

            servicePersona.AbrirConexion();
            string usuario = txtusuario.Text.Trim();
            var listapersona = servicePersona.Consultar(new Persona());

            if (string.IsNullOrEmpty(usuario))
            {
                MessageBox.Show("El usuario no puede estar vacio.");
                return false;
            }

            foreach (var persona in listapersona)
            {

                if (persona.username == usuario)
                {
                    MessageBox.Show("El usuario ya existe.");
                    return false;
                }
            }

            return true;

        }

        private bool validarContrasena()
        {
            string contrasena = txtcontraseña.Text.Trim();
            if (string.IsNullOrEmpty(contrasena))
            {
                MessageBox.Show("la contraseña no puede estar vacia.");
                return false;
            }
            return true;

        }

        private bool validarConfirmarContrasena()
        {
            string contrasena = txtcontraseña.Text.Trim();
            string confirmarContrasena = txtverificar.Text.Trim();
            if (contrasena != confirmarContrasena)
            {
                MessageBox.Show("las contraseñas no coinciden.");
                return false;
            }
            return true;

        }

        private bool validarRol()
        {
            if (boxrol.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un tipo de documento.");
                boxrol.Focus();
                return false;
            }
            return true;
        }
    }
}
