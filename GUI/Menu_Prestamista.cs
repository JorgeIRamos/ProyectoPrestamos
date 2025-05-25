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
            // Consultar todos los préstamos
            var prestamos = serviceOfertaPrestamo.Consultar(null);

            // Filtrar por el prestamista actual
            var prestamosFiltrados = prestamos
                .Where(p => p.id_prestamista == idPrestamistaActual)
                .ToList();

            dgvDatosPrestamos.DataSource = prestamosFiltrados;
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
                tipopago = txttipopago.Text.Trim(),
                id_prestamista = idPrestamistaActual
            };
            serviceOfertaPrestamo.AbrirConexion();
            ;
            MessageBox.Show(serviceOfertaPrestamo.Guardar(ofertaPrestamo));

            serviceOfertaPrestamo.CerrarConexion();
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

        private bool ValidarProposito()
        {
            string proposito = txtproposito.Text.Trim();
            if (string.IsNullOrEmpty(proposito))
            {
                MessageBox.Show("El proposito no esta digitado de manera correcta.");
                return false;
            }
            return true;
        }

        private bool ValidarTipoPago()
        {
            string tipopago = txttipopago.Text.Trim();
            if (string.IsNullOrEmpty(tipopago))
            {
                MessageBox.Show("El tipo de pago no esta digitado de manera correcta.");
                return false;
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int idofertaprestamo;
            if (!int.TryParse(txtid.Text.Trim(), out idofertaprestamo))
            {
                MessageBox.Show("Ingrese un ID válido.");
                return;
            }

            string nuevoProposito = tproposito.Text.Trim();
            if (string.IsNullOrEmpty(nuevoProposito))
            {
                MessageBox.Show("Ingrese un propósito válido.");
                return;
            }
            OfertaPrestamo ofertaPrestamo = new OfertaPrestamo();
            var oferta = serviceOfertaPrestamo.BuscarPorId(idofertaprestamo, ofertaPrestamo);

            if (oferta == null)
            {
                MessageBox.Show("No se encontró la oferta de préstamo con ese ID.");
                return;
            }

            oferta.proposito = nuevoProposito;

            string resultado = serviceOfertaPrestamo.Modificar(oferta);

            MessageBox.Show(resultado);
        }

        private void txtcantidad_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
