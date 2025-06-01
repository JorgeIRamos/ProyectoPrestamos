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
using ClosedXML.Excel;

namespace GUI
{
    public partial class Menu_Prestatario : Form
    {
        private int idPrestatarioActual;
        private string Nombre;
        private byte[] CargarImagen;
        private decimal montopagar;
        private Service<OfertaPrestamo> serviceOfertaPrestamo;
        private Service<Prestamista> servicePrestamista;
        private Service<Prestatario> servicePrestatario;
        private Service<Prestamo> servicePrestamo;
        private Service<Transaccion> serviceTransaccion;
        private Service<Recordatorio> serviceRecordatorio;
        public Menu_Prestatario(int idPrestatario, string nombre)
        {
            serviceOfertaPrestamo = new Service<OfertaPrestamo>();
            servicePrestamista = new Service<Prestamista>();
            servicePrestatario = new Service<Prestatario>();
            servicePrestamo = new Service<Prestamo>();
            serviceTransaccion = new Service<Transaccion>();
            serviceRecordatorio = new Service<Recordatorio>();
            InitializeComponent();
            QuitarBordes();
            dgvDatosPrestamos.DefaultCellStyle.ForeColor = Color.Black;
            dgvmisprestamos.DefaultCellStyle.ForeColor = Color.Black;
            idPrestatarioActual = idPrestatario;
            Nombre = nombre;
            labeluser.Text = "BIENVENIDO " + Nombre.ToUpper();
            pnlofertasprestamo.Visible = false;
            pnlmisprestamos.Visible = false;
            pnlpagos.Visible = false;
            pnlconfirmarpago.Visible = false;
            pnlconsultarpagos.Visible = false;
            pnlnotificaciones.Visible = false;
            CargarPrestamos();
            CargarMisPrestamos();
            CargarPrestamosPagar();
            CargarHistorialPagos();
            CargarRecordatorios();
            CargarUltimosDatos();
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

        private void CargarUltimosDatos()
        {
            var ultimoPrestamo = servicePrestamo.Consultar(new Prestamo())
                .Where(p => p.id_prestatario == idPrestatarioActual &&
                            (p.estado == "Activo" || p.estado == "Finalizado"))
                .OrderByDescending(p => p.id_prestamo)
                .FirstOrDefault();

            var ultimaNotificacion = serviceRecordatorio.Consultar(new Recordatorio())
                .Where(r => r.Prestamo != null && r.Prestamo.id_prestatario == idPrestatarioActual)
                .OrderByDescending(r => r.fecharecordatorio)
                .FirstOrDefault();

            var prestamosIds = servicePrestamo.Consultar(new Prestamo())
                .Where(p => p.id_prestatario == idPrestatarioActual)
                .Select(p => p.id_prestamo)
                .ToList();

            var ultimaTransaccion = serviceTransaccion.Consultar(new Transaccion())
                .Where(t => prestamosIds.Contains(t.id_prestamo))
                .OrderByDescending(t => t.fecha)
                .FirstOrDefault();

            if (ultimoPrestamo == null || ultimaTransaccion == null || ultimaTransaccion == null)
            {
                pnlnotificacionreciente.Visible = false;
                pnlprestamosrecientes.Visible = false;
                pnltransferenciareciente.Visible = false;
                lblresumen.Visible = false;
                return;
            }

            lblmonto.Text = ultimoPrestamo.ofertaPrestamo.cantidad.ToString("C2");
            lblinteresesrecientes.Text = ultimoPrestamo.ofertaPrestamo.intereses.ToString() + " %";
            lblcuota.Text = ultimoPrestamo.ofertaPrestamo.cuotas_restantes.ToString();
            lblultimosaldo.Text = ultimoPrestamo.saldo_restante.ToString("C2");
            lblfechareciente.Text = ultimaNotificacion.fecharecordatorio.ToString("dd/MM/yyyy");
            if (ultimaNotificacion.mensaje.Length > 30)
            {
                lblmensaje.Text = ultimaNotificacion.mensaje.Substring(0, 30) + "...";
            }
            else
            {
                lblmensaje.Text = ultimaNotificacion.mensaje;
            }

            lblpago.Text = ultimaTransaccion.monto.ToString("C2");
            lblfechatrans.Text = ultimaTransaccion.fecha.ToString("dd/MM/yyyy");
            lbltipotransaccion.Text = ultimaTransaccion.tipo_transaccion;



        }
        private void btninicio_Click(object sender, EventArgs e)
        {
            ResaltarBoton(btninicio);
            pnlinicio.Visible = true;
            pnlofertasprestamo.Visible = false;
            pnlnotificaciones.Visible = false;
            pnlmisprestamos.Visible = false;
            pnlpagos.Visible = false;
            pnlconfirmarpago.Visible = false;
            pnlconsultarpagos.Visible = false;
            CargarUltimosDatos();
        }

        private void btnofertasprestamo_Click(object sender, EventArgs e)
        {
            ResaltarBoton(btnofertaprestamo);
            pnlofertasprestamo.Visible = true;
            pnlmisprestamos.Visible = false;
            pnlinicio.Visible = false;
            pnlconsultarpagos.Visible = false;
            pnlnotificaciones.Visible = false;
            pnlpagos.Visible = false;
            pnlconfirmarpago.Visible = false;
            CargarPrestamos();
        }

        private void btnprestamosactivos_Click(object sender, EventArgs e)
        {
            ResaltarBoton(btnmisprestamos);
            pnlmisprestamos.Visible = true;
            pnlofertasprestamo.Visible = false;
            pnlpagos.Visible = false;
            pnlinicio.Visible = false;
            pnlconsultarpagos.Visible = false;
            pnlnotificaciones.Visible = false;
            pnlconfirmarpago.Visible = false;
            CargarMisPrestamos();
        }

        private void btnpagar_Click(object sender, EventArgs e)
        {
            ResaltarBoton(btnpagar);
            pnlpagos.Visible = true;
            pnlconfirmarpago.Visible = false;
            pnlinicio.Visible = false;
            pnlmisprestamos.Visible = false;
            pnlofertasprestamo.Visible = false;
            pnlconsultarpagos.Visible = false;
            pnlnotificaciones.Visible = false;
            CargarPrestamosPagar();
        }

        private void btnhistorial_Click(object sender, EventArgs e)
        {
            ResaltarBoton(btnhistorial);
            pnlconfirmarpago.Visible = false;
            pnlpagos.Visible = false;
            pnlinicio.Visible = false;
            pnlmisprestamos.Visible = false;
            pnlofertasprestamo.Visible = false;
            pnlconsultarpagos.Visible = true;
            pnlnotificaciones.Visible = false;
            CargarHistorialPagos();
        }

        private void btnnotificaciones_Click(object sender, EventArgs e)
        {
            ResaltarBoton(btnnotificaciones);
            pnlconfirmarpago.Visible = false;
            pnlpagos.Visible = false;
            pnlinicio.Visible = false;
            pnlmisprestamos.Visible = false;
            pnlofertasprestamo.Visible = false;
            pnlconsultarpagos.Visible = false;
            pnlnotificaciones.Visible = true;
            CargarRecordatorios();
        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

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
            dgvDatosPrestamos.ClearSelection();
        }

        private void CargarMisPrestamos()
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
            dgvmisprestamos.DataSource = null;
            dgvmisprestamos.DataSource = prestamosDTO;
            dgvmisprestamos.ClearSelection();
            dgvmisprestamos.Columns["id_ofertaprestamo"].Visible = false;
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
                .Where(p => p.id_prestatario == idPrestatarioActual && p.ofertaPrestamo.estado == "Activo")
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
            dgvmostrarpagos.ClearSelection();
            dgvmostrarpagos.Columns["id_ofertaprestamo"].Visible = false;

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
            dgvhistorialpago.ClearSelection();
        }

        private void CargarRecordatorios()
        {
            var recordatorios = serviceRecordatorio.Consultar(new Recordatorio())
                .Where(r => r.Prestamo.id_prestatario == idPrestatarioActual)
                .OrderBy(r => r.fecharecordatorio)
                .ToList();
            dgvnotificaciones.DataSource = null;
            dgvnotificaciones.DataSource = recordatorios;
            dgvnotificaciones.ClearSelection();
            dgvnotificaciones.Columns["id_recordatorio"].Visible = false;
            dgvnotificaciones.Columns["Prestamo"].Visible = false;
        }



        private void btncontinuar_Click(object sender, EventArgs e)
        {
            btnconfirmarpago.Enabled = false;
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
            prestamo.id_ofertaprestamo = ((PrestamoDTO)dgvmostrarpagos.SelectedRows[0].DataBoundItem).id_ofertaprestamo;
            prestamo.saldo_restante -= montopagar;
            ofertaprestamo.cuotas_restantes -= 1;
            if (ofertaprestamo.cuotas_restantes == 0)
            {
                prestamo.estado = "Finalizado";
                ofertaprestamo.estado = "Finalizado";
            }
            servicePrestamo.Modificar(prestamo);
            serviceOfertaPrestamo.Modificar(ofertaprestamo);
            MessageBox.Show("Pago realizado con éxito.");
            GuardarTransaccion(idPrestamo);
            pnlconfirmarpago.Visible = false;
            pnlpagos.Visible = true;
            CargarPrestamosPagar();
            CargarHistorialPagos();

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
            CargarMisPrestamos();
            CargarPrestamosPagar();
        }

        private void btnsubirimagen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    CargarImagen = System.IO.File.ReadAllBytes(openFileDialog.FileName);
                    MessageBox.Show("Imagen cargada correctamente.");
                    btnconfirmarpago.Enabled = true;
                }
            }
        }

        private void GuardarTransaccion(int idPrestamo)
        {
            var buscarprestamo = servicePrestamo.Consultar(new Prestamo());
            var transaccion = new Transaccion
            {
                id_prestamo = idPrestamo,
                monto = montopagar,
                fecha = DateTime.Now,
                imagen = CargarImagen,
                tipo_transaccion = lbltipopago.Text.ToString()
            };
            var resultado = serviceTransaccion.Guardar(transaccion);
        }

        private void Cambiar_Estado(int idOferta)
        {
            var buscarprestamo = serviceOfertaPrestamo.BuscarPorId(idOferta, new OfertaPrestamo());
            buscarprestamo.estado = "Activo";
            var resultado = serviceOfertaPrestamo.Modificar(buscarprestamo);
            if (resultado == null) {
                MessageBox.Show("Error al actualizar el estado de la oferta de préstamo.");
                return;
            }
            CargarPrestamos();
            CargarMisPrestamos();
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

        private void btnvolver_Click(object sender, EventArgs e)
        {
            pnlpagos.Visible = true;
            pnlconfirmarpago.Visible = false;
        }


        private void btnrestablecer_Click(object sender, EventArgs e)
        {
            CargarMisPrestamos();
        }

        private void btnestadoprestamo_Click(object sender, EventArgs e)
        {
            if (boxestadoprestamo.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un estado de préstamo.");
                return;
            }
            var prestamosFiltrados = Filtrarporestado();
            dgvmisprestamos.DataSource = null;
            dgvmisprestamos.DataSource = prestamosFiltrados;
            dgvmisprestamos.ClearSelection();
            dgvmisprestamos.Columns["id_ofertaprestamo"].Visible = false;
        }

        private List<PrestamoDTO> Filtrarporestado()
        {
            string estadoSeleccionado = boxestadoprestamo.SelectedItem.ToString();
            var prestamos = servicePrestamo.Consultar(new Prestamo());
            var prestamosFiltrados = prestamos
                .Where(p => p.id_prestatario == idPrestatarioActual && p.estado == estadoSeleccionado)
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
            return prestamosFiltrados;
        }

        private void btnrestablecerpago_Click(object sender, EventArgs e)
        {
            CargarHistorialPagos();
        }

        private void btnfiltrarpago_Click(object sender, EventArgs e)
        {
            if (boxtipodepago.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un estado de préstamo.");
                return;
            }
            string tipopagoSeleccionado = boxtipodepago.SelectedItem.ToString();
            var prestamos = servicePrestamo.Consultar(new Prestamo())
                .Where(p => p.id_prestatario == idPrestatarioActual)
                .Select(p => p.id_prestamo)
                .ToList();

            var transacciones = serviceTransaccion.Consultar(new Transaccion())
                .Where(t => prestamos.Contains(t.id_prestamo) && t.tipo_transaccion == tipopagoSeleccionado)
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
            dgvhistorialpago.ClearSelection();
        }

        private void ExportarDataGridViewAExcel(DataGridView dgv, string rutaArchivo, string nombreHoja)
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add(nombreHoja);
                int excelCol = 1;
                for (int col = 0; col < dgv.Columns.Count; col++)
                {
                    if (dgv.Columns[col].Visible)
                    {
                        worksheet.Cell(1, excelCol).Value = dgv.Columns[col].HeaderText;
                        excelCol++;
                    }
                }

                for (int row = 0; row < dgv.Rows.Count; row++)
                {
                    if (dgv.Rows[row].IsNewRow) continue;
                    excelCol = 1;
                    for (int col = 0; col < dgv.Columns.Count; col++)
                    {
                        if (dgv.Columns[col].Visible)
                        {
                            worksheet.Cell(row + 2, excelCol).Value = dgv.Rows[row].Cells[col].Value;
                            excelCol++;
                        }
                    }
                }
                worksheet.Columns().AdjustToContents();
                workbook.SaveAs(rutaArchivo);
            }
            MessageBox.Show("Informe descargado correctamente.");
        }


        private void btndescargarprestamos_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel files (*.xlsx)|*.xlsx";
                sfd.FileName = "InformeMisPrestamos.xlsx";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    ExportarDataGridViewAExcel(dgvmisprestamos, sfd.FileName, "Mis Prestamos");
                }
            }
        }

        private void btndescargarpagos_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel files (*.xlsx)|*.xlsx";
                sfd.FileName = "InformeHistorialPagos.xlsx";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    ExportarDataGridViewAExcel(dgvhistorialpago, sfd.FileName, "Historial de Pagos");
                }
            }
        }
    }
}
