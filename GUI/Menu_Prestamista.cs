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
    public partial class Menu_Prestamista : Form
    {
        private Service<Prestamista> servicePrestamista;
        private Service<OfertaPrestamo> serviceOfertaPrestamo;
        private int idPrestamistaActual;
        private string Nombre;
        public Menu_Prestamista(int idPrestamista, string nombre)
        {
            servicePrestamista = new Service<Prestamista>();
            serviceOfertaPrestamo = new Service<OfertaPrestamo>();
            InitializeComponent();
            idPrestamistaActual = idPrestamista;
            Nombre = nombre;
            pnlconsultarprestamo.Visible = false;
            pnlcrearprestamo.Visible = false;
            labeluser.Text = "BIENVENIDO " + Nombre.ToUpper();
            CargarPrestamos();
        }

        private void btncrearprestamo_Click(object sender, EventArgs e)
        {
            pnlcrearprestamo.Visible = true;
            pnlconsultarprestamo.Visible = false;
            pnlinicio.Visible = false;
        }

        private void btnconsultarprestamos_Click(object sender, EventArgs e)
        {
            pnlinicio.Visible = false;
            pnlcrearprestamo.Visible = false;
            pnlconsultarprestamo.Visible = true;
            CargarPrestamos();


        }

        private void btncrear_Click(object sender, EventArgs e)
        {
            if (!ValidarCantidad() || !ValidarIntereses() || !ValidarPlazo() )
            {
                return;
            }

            GuardarPrestamo();


        }

        private void CargarPrestamos()
        {
            var prestamos = serviceOfertaPrestamo.Consultar(new OfertaPrestamo());

            var prestamosFiltrados = prestamos
                .Where(p => p.id_prestamista == idPrestamistaActual)
                .OrderBy(p => p.id)
                .ToList();

            dgvDatosPrestamos.DataSource = null;
            dgvDatosPrestamos.DataSource = prestamosFiltrados;

            OcultarColumnas();
        }


        private void GuardarPrestamo()
        {

            OfertaPrestamo ofertaPrestamo = new OfertaPrestamo
            {
                cantidad = decimal.Parse(txtcantidad.Text.Trim()),
                intereses = decimal.Parse(txtintereses.Text.Trim()),
                plazo = int.Parse(txtplazo.Text.Trim()),
                fechainicio = DateTime.Now,
                fechavencimiento = DateTime.Now.AddMonths(int.Parse(txtplazo.Text.Trim())),
                estado = "Pendiente",
                id_prestamista = idPrestamistaActual
            };
            serviceOfertaPrestamo.AbrirConexion();
            ;
            MessageBox.Show(serviceOfertaPrestamo.Guardar(ofertaPrestamo));

            serviceOfertaPrestamo.CerrarConexion();
            CargarPrestamos();
        }


        private bool ValidarCantidad()
        {
            string cantidad = txtcantidad.Text.Trim();
            if (string.IsNullOrEmpty(cantidad) || !cantidad.All(char.IsDigit))
            {
                MessageBox.Show("La cantidad no esta digitado de manera correcta.");
                return false;
            }
            return true;
        }

        private bool ValidarIntereses()
        {
            string intereses = txtintereses.Text.Trim();
            if (string.IsNullOrEmpty(intereses) || !intereses.All(char.IsDigit))
            {
                MessageBox.Show("Los intereses no estan digitados de manera correcta.");
                return false;
            }
            return true;
        }

        private bool ValidarPlazo()
        {
            string plazo = txtplazo.Text.Trim();
            if (string.IsNullOrEmpty(plazo) || !plazo.All(char.IsDigit))
            {
                MessageBox.Show("El plazo no esta digitado de manera correcta.");
                return false;
            }
            return true;
        }

        private void txtcantidad_TextChanged(object sender, EventArgs e)
        {

        }

        private void btninicio_Click(object sender, EventArgs e)
        {
            pnlconsultarprestamo.Visible = false;
            pnlcrearprestamo.Visible = false;
            pnlinicio.Visible = true;
        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            this.Close();
            Inicio_Sesion inicio_Sesion = new Inicio_Sesion();
            inicio_Sesion.Close();
        }

        private void OcultarColumnas()
        {
            if (dgvDatosPrestamos.Columns["id_prestamista"] != null)
                dgvDatosPrestamos.Columns["id_prestamista"].Visible = false;
            if (dgvDatosPrestamos.Columns["prestamista"] != null)
                dgvDatosPrestamos.Columns["prestamista"].Visible = false;
        }
    }
}
