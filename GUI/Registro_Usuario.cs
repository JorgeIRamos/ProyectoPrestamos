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

            GuardarPersona();
            GuardarRol();
            MessageBox.Show("A continuacion digite los datos para loguearse");
            this.Close();

        }

        private void GuardarPersona()
        {
            int tipo_documento = ValorTipoDocumento();
            char sexo = ValorSexo();


            Persona persona = new Persona
            {
                nombre = txtnombre.Text.Trim(),
                apellido = txtapellido.Text.Trim(),
                NumeroDocumento = txtnrodocumento.Text.Trim(),
                tipo_documento = tipo_documento,
                telefono = txttelefono.Text.Trim(),
                sexo = sexo.ToString(),
                direccion = txtdireccion.Text.Trim(),
                email = txtemail.Text.Trim(),
                username = txtusuario.Text.Trim(),
                contraseña = txtcontraseña.Text.Trim()
            };

            // Guardar persona
            servicePersona.AbrirConexion();
            servicePersona.Guardar(persona);
            servicePersona.CerrarConexion();
        }

        private void GuardarRol()
        {
            string rol = boxrol.SelectedItem.ToString();
            if (rol == "Prestamista")
            {
                var personas = servicePersona.Consultar(new Persona());
                var servicePrestamista = new Service<Prestamista>();
                Prestamista prestamista = new Prestamista();
                foreach (var item in personas)
                {

                    prestamista.id_prestamista = item.id_persona;

                }
                servicePrestamista.AbrirConexion();
                MessageBox.Show(servicePrestamista.Guardar(prestamista));
                servicePrestamista.CerrarConexion();


            }
            else if (rol == "Prestatario")
            {
                var personas = servicePersona.Consultar(new Persona());
                var servicePrestatario = new Service<Prestatario>();
                Prestatario prestatario = new Prestatario();
                foreach (var item in personas)
                {
                    prestatario.id_prestatario = item.id_persona;
                }

                servicePrestatario.AbrirConexion();
                MessageBox.Show(servicePrestatario.Guardar(prestatario));
                servicePrestatario.CerrarConexion();
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
                MessageBox.Show("Debe seleccionar un sexo.");
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
            var regex = new System.Text.RegularExpressions.Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            var listapersona = servicePersona.Consultar(new Persona());
            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("El email no puede estar vacio.");
                return false;
            }
            
            if (!regex.IsMatch(email))
            {
                MessageBox.Show("El formato del email no es válido.");
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

        private int ValorTipoDocumento()
        {
            if (boxtipodocumento.SelectedItem.ToString() == "Cedula de Ciudadania")
            {
                return 1;
            }
            else if (boxtipodocumento.SelectedItem.ToString() == "Tarjeta de Identidad")
            {
                return 2;
            }
            else if (boxtipodocumento.SelectedItem.ToString() == "Cedula de Extranjeria")
            {
                return 3;
            }

            return 4;
        }

        private char ValorSexo()
        {
            if (boxsexo.SelectedItem.ToString() == "Masculino")
            {
                return 'M';
            }  
            return 'F';
        } 

        
    }
}
