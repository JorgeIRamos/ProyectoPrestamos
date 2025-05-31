using Entidades;
using Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
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
        private Service<Transaccion> serviceTransaccion;
        public Menu_Prestatario(int idPrestatario, string nombre)
        {
            serviceOfertaPrestamo = new Service<OfertaPrestamo>();
            servicePrestamista = new Service<Prestamista>();
            servicePrestatario = new Service<Prestatario>();
            servicePrestamo = new Service<Prestamo>();
            serviceTransaccion = new Service<Transaccion>();
            InitializeComponent();
            QuitarBordes();
            dgvDatosPrestamos.DefaultCellStyle.ForeColor = Color.Black;
            dgvPrestamosActivos.DefaultCellStyle.ForeColor = Color.Black;
            idPrestatarioActual = idPrestatario;
            Nombre = nombre;
            labeluser.Text = "BIENVENIDO " + Nombre.ToUpper();
            pnlofertasprestamo.Visible = false;
            pnlprestamosactivos.Visible = false;
            pnlpagos.Visible = false;
            pnlconfirmarpago.Visible = false;
            pnlconsultarpagos.Visible = false;
            CargarPrestamos();
            CargarPrestamosActivos();
            CargarPrestamosPagar();
            CargarHistorialPagos();
        }

        private void QuitarBordes()
        {
            btninicio.FlatStyle = FlatStyle.Flat;
            btninicio.FlatAppearance.BorderSize = 0;
            btnofertaprestamo.FlatStyle = FlatStyle.Flat;
            btnofertaprestamo.FlatAppearance.BorderSize = 0;
            btnmisprestamos.FlatStyle = FlatStyle.Flat;
            btnmisprestamos.FlatAppearance.BorderSize = 0;
            btnpagar.FlatStyle = FlatStyle.Flat;
            btnpagar.FlatAppearance.BorderSize = 0;
            btnhistorial.FlatStyle = FlatStyle.Flat;
            btnhistorial.FlatAppearance.BorderSize = 0;
            btnnotificaciones.FlatStyle = FlatStyle.Flat;
            btnnotificaciones.FlatAppearance.BorderSize = 0;
            btnsalir.FlatStyle = FlatStyle.Flat;
            btnsalir.FlatAppearance.BorderSize = 0;

        }

        private void btnofertasprestamo_Click(object sender, EventArgs e)
        {
            ResaltarBoton(btnofertaprestamo);
            pnlofertasprestamo.Visible = true;
            pnlprestamosactivos.Visible = false;
            pnlinicio.Visible = false;
            pnlconsultarpagos.Visible = false;
        }

        private void btnprestamosactivos_Click(object sender, EventArgs e)
        {
            ResaltarBoton(btnmisprestamos);
            pnlprestamosactivos.Visible = true;
            pnlofertasprestamo.Visible = false;
            pnlinicio.Visible = false;
            pnlpagos.Visible = false;
            pnlinicio.Visible = false;
            pnlconsultarpagos.Visible = false;
        }

        private void btnpagar_Click(object sender, EventArgs e)
        {
            ResaltarBoton(btnpagar);
            pnlpagos.Visible = true;
            pnlconfirmarpago.Visible = false;
            pnlinicio.Visible = false;
            pnlprestamosactivos.Visible = false;
            pnlofertasprestamo.Visible = false;
            pnlconsultarpagos.Visible = false;
        }

        private void btnhistorial_Click(object sender, EventArgs e)
        {
            ResaltarBoton(btnhistorial);
            pnlconfirmarpago.Visible = false;
            pnlpagos.Visible = false;
            pnlinicio.Visible = false;
            pnlprestamosactivos.Visible = false;
            pnlofertasprestamo.Visible = false;
            pnlconsultarpagos.Visible = true;
        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //AQUI SOLO VAMOS A CARGAR LOS PRESTAMOS QUE NO ESTEN EN ESTADO ACTIVO
        private void CargarPrestamos()
        {
            var ofertaprestamos = serviceOfertaPrestamo.Consultar(new OfertaPrestamo());
            var OfertaprestamosDTO = ofertaprestamos.Where(p => p.estado == "Pendiente").OrderBy(p => p.id).Select(p => new OfertaPrestamoDTO
            {
                id = p.id,
                cantidad = p.cantidad,
                intereses = p.intereses,
                plazo = p.plazo,
                cuotas = p.cuotas,
                frecuencia = p.frecuencia,
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
            dgvDatosPrestamos.DataSource = OfertaprestamosDTO;
        }

        private void CargarPrestamosActivos()
        {
            var prestamos = servicePrestamo.Consultar(new Prestamo());
            var prestamosDTO = prestamos
                .Where(p => p.id_prestatario == idPrestatarioActual)
                .OrderBy(p => p.id_prestamo)
                .Select(p => new PrestamoDTO
                {
                    id_prestamo = p.id_prestamo,
                    saldo_restante = p.saldo_restante,
                    estado = p.estado,
                    id_ofertaprestamo = p.id_ofertaprestamo,
                    NombrePrestamista = p.ofertaPrestamo?.prestamista?.Persona?.nombre,
                    ApellidoPrestamista = p.ofertaPrestamo?.prestamista?.Persona?.apellido,
                    NumeroDocumentoPrestamista = p.ofertaPrestamo?.prestamista?.Persona?.NumeroDocumento,
                    cantidad = p.ofertaPrestamo?.cantidad ?? 0,
                    intereses = p.ofertaPrestamo?.intereses ?? 0,
                    plazo = p.ofertaPrestamo?.plazo ?? 0,
                    cuotas = p.ofertaPrestamo?.cuotas ?? 0,
                    cuotas_restantes = p.ofertaPrestamo?.cuotas_restantes ?? 0,
                    frecuencia = p.ofertaPrestamo?.frecuencia,
                    fechainicio = p.ofertaPrestamo?.fechainicio ?? DateTime.MinValue,
                    fechavencimiento = p.ofertaPrestamo?.fechavencimiento ?? DateTime.MinValue,
                    proposito = p.ofertaPrestamo?.proposito,
                    tipopago = p.ofertaPrestamo?.tipopago
                })
                .ToList();
            dgvPrestamosActivos.DataSource = null;
            dgvPrestamosActivos.DataSource = prestamosDTO;
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
            using (AceptarPrestamo aceptarprestamo = new AceptarPrestamo(idOferta))
            {
                var resultado = aceptarprestamo.ShowDialog();
                if (resultado == DialogResult.OK)
                {
                    GuardarPrestamo(idOferta);
                    Cambiar_Estado(idOferta);
                    MessageBox.Show($"Oferta de préstamo aceptada: {ofertaSeleccionada.cantidad} a {ofertaSeleccionada.intereses}% por {ofertaSeleccionada.plazo} meses.");
                }
                else
                {
                    MessageBox.Show("No se completo la operacion para aceptar el prestamo.");
                }
            }
        }

        private void CargarPrestamosPagar()
        {
            var prestamos = servicePrestamo.Consultar(new Prestamo());
            var prestamoDTO = prestamos
                .Where(p => p.id_prestatario == idPrestatarioActual)
                .OrderBy(p => p.id_prestamo)
                .Select(p => new PrestamoDTO
                {
                    id_prestamo = p.id_prestamo,
                    saldo_restante = p.saldo_restante,
                    estado = p.estado,
                    id_ofertaprestamo = p.id_ofertaprestamo,
                    NombrePrestamista = p.ofertaPrestamo?.prestamista?.Persona?.nombre,
                    ApellidoPrestamista = p.ofertaPrestamo?.prestamista?.Persona?.apellido,
                    NumeroDocumentoPrestamista = p.ofertaPrestamo?.prestamista?.Persona?.NumeroDocumento,
                    cantidad = p.ofertaPrestamo?.cantidad ?? 0,
                    intereses = p.ofertaPrestamo?.intereses ?? 0,
                    plazo = p.ofertaPrestamo?.plazo ?? 0,
                    cuotas = p.ofertaPrestamo?.cuotas ?? 0,
                    cuotas_restantes = p.ofertaPrestamo?.cuotas_restantes ?? 0,
                    frecuencia = p.ofertaPrestamo?.frecuencia,
                    fechainicio = p.ofertaPrestamo?.fechainicio ?? DateTime.MinValue,
                    fechavencimiento = p.ofertaPrestamo?.fechavencimiento ?? DateTime.MinValue,
                    proposito = p.ofertaPrestamo?.proposito,
                    tipopago = p.ofertaPrestamo?.tipopago
                })
                .ToList();
            dgvmostrarpagos.DataSource = null;
            dgvmostrarpagos.DataSource = prestamoDTO;
        }

        private void CargarHistorialPagos()
        {
            var prestamos = servicePrestamo.Consultar(new Prestamo())
                .Where(p => p.id_prestatario == idPrestatarioActual)
                .Select(p => p.id_prestamo)
                .ToList();

            var transacciones = serviceTransaccion.Consultar(new Transaccion())
                .Where(t => prestamos.Contains(t.id_prestamo))
                .OrderBy(t => t.fecha)
                .Select(t => new
                {
                    t.monto,
                    t.fecha,
                    t.id_prestamo,
                    t.tipo_transaccion
                })
                .ToList();

            dgvhistorialpago.DataSource = null;
            dgvhistorialpago.DataSource = transacciones;
        }


        private void btncontinuar_Click(object sender, EventArgs e)
        {
            if (dgvmostrarpagos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar una oferta de préstamo.");
                return;
            }
            var prestamoseleccionado = (PrestamoDTO)dgvmostrarpagos.SelectedRows[0].DataBoundItem;
            int idPrestamo = prestamoseleccionado.id_prestamo;
            pnlconfirmarpago.Visible = true;
            pnlpagos.Visible = false;
            CalcularPago(idPrestamo);
            MostrarDatos(idPrestamo);
            var buscarprestamo = servicePrestamo.Consultar(new Prestamo());

        }

        private void MostrarDatos(int idPrestamo)
        {
            // Buscar el préstamo por su id usando Consultar
            var prestamos = servicePrestamo.Consultar(new Prestamo());
            var prestamo = prestamos.FirstOrDefault(p => p.id_prestamo == idPrestamo);

            if (prestamo == null)
            {
                MessageBox.Show("No se encontró el préstamo seleccionado.");
                return;
            }

            if (prestamo.ofertaPrestamo == null)
            {
                MessageBox.Show("No se encontró la oferta asociada al préstamo.");
                return;
            }

            lblcuotas.Text = prestamo.ofertaPrestamo.cuotas.ToString() + " ( " + prestamo.ofertaPrestamo.cuotas_restantes.ToString() + " cuotas restantes )";
            lblnombreprestamista.Text = prestamo.estado;
            lblfechavencimiento.Text = prestamo.ofertaPrestamo.fechavencimiento.ToString("dd/MM/yyyy");
            lbltotalprestamo.Text = prestamo.ofertaPrestamo.cantidad.ToString("C2");
            lbltipopago.Text = prestamo.ofertaPrestamo.tipopago;
            lblinteres.Text = prestamo.ofertaPrestamo.intereses.ToString() + " %";
            lblplazo.Text = prestamo.ofertaPrestamo.plazo.ToString();
            lblnombreprestamista.Text = prestamo.ofertaPrestamo.prestamista.Persona.nombre.ToString();
            lbldocumentoprestamista.Text = prestamo.ofertaPrestamo.prestamista.Persona.NumeroDocumento.ToString();
            lblsaldorestante.Text = prestamo.saldo_restante.ToString("C2");
            lblnumeroprestamista.Text = prestamo.ofertaPrestamo.prestamista.Persona.NumeroDocumento.ToString();
            lblfrecuencia.Text = prestamo.ofertaPrestamo.frecuencia;
        }

        private decimal montopagar;
        private void CalcularPago(int idoferta)
        {
            var buscarofertaprestamo = serviceOfertaPrestamo.BuscarPorId(idoferta, new OfertaPrestamo());
            

            decimal totalPrestamo = buscarofertaprestamo.cantidad;
            decimal interes = buscarofertaprestamo.intereses;
            int cuotas = buscarofertaprestamo.cuotas;
            
            if (buscarofertaprestamo.frecuencia == "Mensual" || buscarofertaprestamo.frecuencia == "Quincenal" || buscarofertaprestamo.frecuencia == "Semanal")
            {
                montopagar = buscarofertaprestamo.cuotas > 0 ? (buscarofertaprestamo.cantidad * (1 + buscarofertaprestamo.intereses)) / buscarofertaprestamo.cuotas : 0;
                lblmontopagar.Text = montopagar.ToString("C2");
            }
        }

        private void btnconfirmarpago_Click(object sender, EventArgs e)
        {
            int idPrestamo = ((PrestamoDTO)dgvmostrarpagos.SelectedRows[0].DataBoundItem).id_prestamo;
            var prestamo = servicePrestamo.BuscarPorId(idPrestamo, new Prestamo());
            var ofertaprestamo = serviceOfertaPrestamo.BuscarPorId(prestamo.id_ofertaprestamo, new OfertaPrestamo());
            if (prestamo == null)
            {
                MessageBox.Show("No se encontró el préstamo seleccionado.");
                return;
            }
            if (prestamo.saldo_restante < montopagar)
            {
                MessageBox.Show("El monto a pagar no puede ser mayor al saldo restante del préstamo.");
                return;
            }
            prestamo.id_ofertaprestamo = ((PrestamoDTO)dgvmostrarpagos.SelectedRows[0].DataBoundItem).id_ofertaprestamo; 
            prestamo.saldo_restante -= montopagar;
            ofertaprestamo.cuotas_restantes -= 1;
            servicePrestamo.Modificar(prestamo);
            serviceOfertaPrestamo.Modificar(ofertaprestamo);
            MessageBox.Show("Pago realizado con éxito.");
            GuardarTransaccion(idPrestamo);
            pnlconfirmarpago.Visible = false;
            pnlpagos.Visible = true;
            CargarPrestamosPagar();
        }

        private void GuardarPrestamo(int idOferta)
        {
            var ofertaSeleccionada = (OfertaPrestamoDTO)dgvDatosPrestamos.SelectedRows[0].DataBoundItem;
            var prestamo = new Prestamo
            {
                id_prestatario = idPrestatarioActual,
                id_ofertaprestamo = idOferta,
                saldo_restante = ofertaSeleccionada.cantidad * (1 + ofertaSeleccionada.intereses),
                estado = "Activo",
            };
            var resultado = servicePrestamo.Guardar(prestamo);
            CargarPrestamos();
            CargarPrestamosActivos();
            CargarPrestamosPagar();
        }

        private void GuardarTransaccion(int idPrestamo)
        {
            var buscarprestamo = servicePrestamo.Consultar(new Prestamo());
            var transaccion = new Transaccion
            {
                id_prestamo = idPrestamo,
                monto = montopagar,
                fecha = DateTime.Now,
                tipo_transaccion = lbltipopago.Text.ToString()
            };
            var resultado = serviceTransaccion.Guardar(transaccion);
        }

        private void Cambiar_Estado(int idOferta)
        {
            var buscarprestamo = serviceOfertaPrestamo.BuscarPorId(idOferta, new OfertaPrestamo());
            buscarprestamo.estado = "Activo";
            var resultado = serviceOfertaPrestamo.Modificar(buscarprestamo);
            MessageBox.Show(resultado);
            CargarPrestamos();
            CargarPrestamosActivos();
        }

        private void ResaltarBoton(Button botonActivo)
        {
            var botones = new List<Button> { btninicio, btnofertaprestamo, btnmisprestamos, btnpagar, btnnotificaciones, btnhistorial, btnsalir };

            foreach (var btn in botones)
            {
                btn.BackColor = ColorTranslator.FromHtml("#052f4a");
                btn.ForeColor = Color.White;
            }

            botonActivo.BackColor = ColorTranslator.FromHtml("#00598a");
            botonActivo.ForeColor = Color.White;
        }

        
    }
}
