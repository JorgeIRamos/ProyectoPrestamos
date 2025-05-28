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
    public partial class Menu_Prestatario : Form
    {
        private int idPrestatarioActual;
        private string Nombre;
        private Service<OfertaPrestamo> serviceOfertaPrestamo;
        private Service<Prestamista> servicePrestamista;
        private Service<Prestatario> servicePrestatario;
        private Service<Prestamo> servicePrestamo;
        public Menu_Prestatario(int idPrestatario, string nombre)
        {
            serviceOfertaPrestamo = new Service<OfertaPrestamo>();
            servicePrestamista = new Service<Prestamista>();
            servicePrestatario = new Service<Prestatario>();
            servicePrestamo = new Service<Prestamo>();
            InitializeComponent();
            dgvDatosPrestamos.DefaultCellStyle.ForeColor = Color.Black;
            idPrestatarioActual = idPrestatario;
            Nombre = nombre;
            labeluser.Text = "BIENVENIDO " + Nombre.ToUpper();
            pnlofertasprestamo.Visible = false;
            pnlprestamosactivos.Visible = false;
            CargarPrestamos();
        }

        private void btnofertasprestamo_Click(object sender, EventArgs e)
        {
            pnlofertasprestamo.Visible = true;
            pnlprestamosactivos.Visible = false;
            pnlinicio.Visible = false;
        }

        private void btnprestamosactivos_Click(object sender, EventArgs e)
        {
            pnlprestamosactivos.Visible = true;
            pnlofertasprestamo.Visible = false;
            pnlinicio.Visible = false;
        }

        //AQUI SOLO VAMOS A CARGAR LOS PRESTAMOS QUE NO ESTEN EN ESTADO ACTIVO
        private void CargarPrestamos()
        {
            var prestamos = serviceOfertaPrestamo.Consultar(new OfertaPrestamo());
            var prestamosDTO = prestamos.Where(p => p.estado == "Pendiente").OrderBy(p => p.id).Select(p => new OfertaPrestamoDTO
            {
                id = p.id,
                cantidad = p.cantidad,
                intereses = p.intereses,
                plazo = p.plazo,
                fechainicio = p.fechainicio,
                fechavencimiento = p.fechavencimiento,
                proposito = p.proposito,
                tipopago = p.tipopago,
                estado = p.estado,
                NombrePrestamista = p.prestamista?.Persona?.nombre,
                ApellidoPrestamista = p.prestamista?.Persona?.apellido,
                NumeroDocumentoPrestamista = p.prestamista?.Persona?.NumeroDocumento
            }).ToList();
            dgvDatosPrestamos.DataSource = null;
            dgvDatosPrestamos.DataSource = prestamosDTO;
        }

        private void btnaceptaroferta_Click(object sender, EventArgs e)
        {
            if (dgvDatosPrestamos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar una oferta de préstamo.");
                return;
            }
            var ofertaSeleccionada = (OfertaPrestamoDTO)dgvDatosPrestamos.SelectedRows[0].DataBoundItem;
            int idOferta = ofertaSeleccionada.id;
            AceptarPrestamo aceptarprestamo = new AceptarPrestamo(idOferta);
            aceptarprestamo.ShowDialog();
            GuardarPrestamo(idOferta);
            Cambiar_Estado(idOferta);


            MessageBox.Show($"Oferta de préstamo aceptada: {ofertaSeleccionada.cantidad} a {ofertaSeleccionada.intereses}% por {ofertaSeleccionada.plazo} meses.");
        }

        private void GuardarPrestamo(int idOferta)
        {
            var prestamo = new Prestamo
            {
                id_prestatario = idPrestatarioActual,
                id_ofertaprestamo = idOferta,
                saldo_restante = ((OfertaPrestamoDTO)dgvDatosPrestamos.SelectedRows[0].DataBoundItem).cantidad,
                estado = "Activo",
            };
            var resultado = servicePrestamo.Guardar(prestamo);
            CargarPrestamos();
        }

        private void Cambiar_Estado(int idOferta)
        {
            var buscarprestamo = serviceOfertaPrestamo.BuscarPorId(idOferta, new OfertaPrestamo());
            buscarprestamo.estado = "Activo";
            var resultado = serviceOfertaPrestamo.Modificar(buscarprestamo);
            MessageBox.Show(resultado);
            CargarPrestamos();
        }
    }
}
