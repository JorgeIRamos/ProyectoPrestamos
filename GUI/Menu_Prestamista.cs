using ClosedXML.Excel;
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

        private Service<OfertaPrestamo> serviceOfertaPrestamo;
        private Service<Transaccion> serviceTransaccion;
        private Service<Prestamo> servicePrestamo;
        private Service<Recordatorio> serviceRecordatorio;
        private int idPrestamistaActual;
        private string Nombre;
        public Menu_Prestamista(int idPrestamista, string nombre)
        {
            serviceOfertaPrestamo = new Service<OfertaPrestamo>();
            serviceTransaccion = new Service<Transaccion>();
            servicePrestamo = new Service<Prestamo>();
            serviceRecordatorio = new Service<Recordatorio>();
            InitializeComponent();
            QuitarBordes();
            idPrestamistaActual = idPrestamista;
            Nombre = nombre;
            pnlconsultarprestamo.Visible = false;
            pnlcrearprestamo.Visible = false;
            pnlcontrolpago.Visible = false;
            labeluser.Text = "BIENVENIDO " + Nombre.ToUpper();
            CargarPrestamos();
            CargarControlPagos();
            CargarUsuarios();
            CargarUltimosDatos();
        }

        private void QuitarBordes()
        {
            btninicio.FlatStyle = FlatStyle.Flat;
            btninicio.FlatAppearance.BorderSize = 0;
            btncrearprestamo.FlatStyle = FlatStyle.Flat;
            btncrearprestamo.FlatAppearance.BorderSize = 0;
            btnconsultarprestamos.FlatStyle = FlatStyle.Flat;
            btnconsultarprestamos.FlatAppearance.BorderSize = 0;
            btnrecordatorios.FlatStyle = FlatStyle.Flat;
            btnrecordatorios.FlatAppearance.BorderSize = 0;
            btncontrolpago.FlatStyle = FlatStyle.Flat;
            btncontrolpago.FlatAppearance.BorderSize = 0;
            btnsalir.FlatStyle = FlatStyle.Flat;
            btnsalir.FlatAppearance.BorderSize = 0;

        }

        private void btninicio_Click(object sender, EventArgs e)
        {
            ResaltarBoton(btninicio);
            pnlconsultarprestamo.Visible = false;
            pnlcrearprestamo.Visible = false;
            pnlinicio.Visible = true;
            pnlcontrolpago.Visible = false;
            pnlconsultarprestamo.Visible = false;
            CargarUltimosDatos();

        }
        private void btncrearprestamo_Click(object sender, EventArgs e)
        {
            ResaltarBoton(btncrearprestamo);
            pnlcrearprestamo.Visible = true;
            pnlconsultarprestamo.Visible = false;
            pnlinicio.Visible = false;
            pnlcontrolpago.Visible = false;
            pnlmandarecordatorio.Visible = false;
            pnlrecordatorio.Visible = false;
        }

        private void btnconsultarprestamos_Click(object sender, EventArgs e)
        {
            ResaltarBoton(btnconsultarprestamos);
            pnlinicio.Visible = false;
            pnlcrearprestamo.Visible = false;
            pnlconsultarprestamo.Visible = true;
            pnlcontrolpago.Visible = false;
            pnlmandarecordatorio.Visible = false;
            pnlrecordatorio.Visible = false;
            CargarPrestamos();
        }

        private void btncontrolpago_Click(object sender, EventArgs e)
        {
            ResaltarBoton(btncontrolpago);
            pnlinicio.Visible = false;
            pnlcrearprestamo.Visible = false;
            pnlconsultarprestamo.Visible = false;
            pnlcontrolpago.Visible = true;
            pnlmandarecordatorio.Visible = false;
            pnlrecordatorio.Visible = false;
            CargarControlPagos();

        }

        private void btnrecordatorios_Click(object sender, EventArgs e)
        {
            ResaltarBoton(btnrecordatorios);
            pnlinicio.Visible = false;
            pnlcrearprestamo.Visible = false;
            pnlconsultarprestamo.Visible = false;
            pnlcontrolpago.Visible = false;
            pnlmandarecordatorio.Visible = false;
            pnlrecordatorio.Visible = true;
            CargarUsuarios();
        }

        private void btncrear_Click(object sender, EventArgs e)
        {
            if (!ValidarCantidad() || !ValidarIntereses() || !ValidarPlazo() || !ValidarFrecuencia() )
            {
                return;
            }

            GuardarPrestamo();
        }

        private void CargarUltimosDatos()
        {
            var ultimaOferta = serviceOfertaPrestamo.Consultar(new OfertaPrestamo())
            .Where(o => o.id_prestamista == idPrestamistaActual)
            .OrderByDescending(o => o.id)
            .FirstOrDefault();

            var prestamosDelPrestamista = servicePrestamo.Consultar(new Prestamo())
                .Where(p => p.ofertaPrestamo != null && p.ofertaPrestamo.id_prestamista == idPrestamistaActual)
                .Select(p => p.id_prestamo)
                .ToList();

            var ultimaTransaccion = serviceTransaccion.Consultar(new Transaccion())
                .Where(t => prestamosDelPrestamista.Contains(t.id_prestamo))
                .OrderByDescending(t => t.fecha)
                .FirstOrDefault();

            var ultimoCliente = servicePrestamo.Consultar(new Prestamo())
                .Where(p => p.ofertaPrestamo != null && p.ofertaPrestamo.id_prestamista == idPrestamistaActual)
                .OrderByDescending(p => p.id_prestamo)
                .Select(p => p.prestatario)
                .FirstOrDefault();

            if (ultimaOferta == null || ultimaTransaccion == null || ultimoCliente == null)
            {
                pnlclientereciente.Visible = false;
                pnlprestamosrecientes.Visible = false;
                pnltransferenciareciente.Visible = false;
                lblresumen.Visible = false;
                return;
            }

            lblmonto.Text = ultimaOferta.cantidad.ToString("C2");
            lblinteres.Text = ultimaOferta.intereses.ToString() + "%";
            lblcuota.Text = ultimaOferta.cuotas.ToString();
            lblestado.Text = ultimaOferta.estado;
            lblpago.Text = ultimaTransaccion.monto.ToString("C2");
            lblfecha.Text = ultimaTransaccion.fecha.ToString("dd/MM/yyyy");
            lbltipotransaccion.Text = ultimaTransaccion.tipo_transaccion.ToString();
            lblnombrecliente.Text = ultimoCliente.Persona.nombre;
            lbltelefonocliente.Text = ultimoCliente.Persona.telefono;
            lblemailcliente.Text = ultimoCliente.Persona.email;
        }

        private void CargarPrestamos()
        {
            var ofertasprestamos = serviceOfertaPrestamo.Consultar(new OfertaPrestamo());

            var prestamosFiltrados = ofertasprestamos
                .Where(p => p.id_prestamista == idPrestamistaActual)
                .OrderBy(p => p.id)
                .ToList();
            dgvDatosPrestamos.DefaultCellStyle.ForeColor = Color.Black;
            dgvDatosPrestamos.DataSource = null;
            dgvDatosPrestamos.DataSource = prestamosFiltrados;
            dgvDatosPrestamos.ClearSelection();
            OcultarColumnas();
        }

        private void CargarControlPagos()
        {

            var ofertas = serviceOfertaPrestamo.Consultar(new OfertaPrestamo())
                .Where(o => o.id_prestamista == idPrestamistaActual)
                .ToList();

            var prestamos = servicePrestamo.Consultar(new Prestamo())
                .Where(pr => ofertas.Any(o => o.id == pr.id_ofertaprestamo))
                .ToList();

            var transacciones = serviceTransaccion.Consultar(new Transaccion())
                .Where(t => prestamos.Any(pr => pr.id_prestamo == t.id_prestamo))
                .OrderBy(t => t.fecha)
                .Select(t =>
                {
                    var prestamo = prestamos.FirstOrDefault(pr => pr.id_prestamo == t.id_prestamo);
                    var prestatario = prestamo?.prestatario;
                    var persona = prestatario?.Persona;

                    return new TransaccionDTO
                    {
                        id = t.id_transaccion,
                        id_prestamo = t.id_prestamo,
                        monto = t.monto,
                        fecha = t.fecha,
                        tipo_transaccion = t.tipo_transaccion,
                        NombrePrestatario = persona?.nombre ?? "Desconocido",
                        ApellidoPrestatario = persona?.apellido ?? "Desconocido",
                        NumeroDocumentoPrestatario = persona?.NumeroDocumento ?? "Desconocido",
                        Intereses = ofertas.FirstOrDefault(o => o.id == prestamo?.id_ofertaprestamo)?.intereses ?? 0,
                        cuota = ofertas.FirstOrDefault(o => o.id == prestamo?.id_ofertaprestamo)?.cuotas ?? 0,
                    };
                })
                .ToList();
            dgvcontrolpagos.DefaultCellStyle.ForeColor = Color.Black;
            dgvcontrolpagos.DataSource = null;
            dgvcontrolpagos.DataSource = transacciones;
            dgvcontrolpagos.ClearSelection();
            dgvcontrolpagos.Columns["estado"].Visible = false;
        }

        private void btnmirarcomprobante_Click(object sender, EventArgs e)
        {
            if (dgvcontrolpagos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar una oferta de préstamo.");
                return;
            }
            var transaccionSeleccionada = (TransaccionDTO)dgvcontrolpagos.SelectedRows[0].DataBoundItem;
            MostrarComprobante mostrarComprobante = new MostrarComprobante(transaccionSeleccionada.id);
            mostrarComprobante.ShowDialog();
        }

        private void CargarUsuarios()
        {
            var prestamos = servicePrestamo.Consultar(new Prestamo())
                .Where(pr => pr.ofertaPrestamo.id_prestamista == idPrestamistaActual)
                .GroupBy(pr => pr.id_prestatario)
                .Select(g => g.First())
                .Select(pr => new UsuariosDTO
                {
                    id = pr.id_prestatario.ToString(),
                    Nombre = pr.prestatario.Persona.nombre,
                    Apellido = pr.prestatario.Persona.apellido,
                    NumeroDocumento = pr.prestatario.Persona.NumeroDocumento,
                    CorreoElectronico = pr.prestatario.Persona.email,
                    Telefono = pr.prestatario.Persona.telefono,
                    sexo = pr.prestatario.Persona.sexo
                }).ToList();
            dgvusuarios.DefaultCellStyle.ForeColor = Color.Black;
            dgvusuarios.DataSource = null;
            dgvusuarios.DataSource = prestamos;
            dgvusuarios.ClearSelection();

            dgvusuarios.Columns["id"].Visible = false;
        }

        private void btncontinuar_Click(object sender, EventArgs e)
        {
            if (dgvusuarios.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar una oferta de préstamo.");
                return;
            }
            var usuarioSeleccionado = (UsuariosDTO)dgvusuarios.SelectedRows[0].DataBoundItem;
            int idusuario = int.Parse(usuarioSeleccionado.id);
            pnlmandarecordatorio.Visible = true;
            pnlrecordatorio.Visible = false;
            CargarDatosRecordatorio(idusuario);
        }

        private void CargarDatosRecordatorio(int Usuario)
        {
            var prestamos = servicePrestamo.Consultar(new Prestamo());
            var prestamo = prestamos.FirstOrDefault(p => p.id_prestatario == Usuario);

            lblnombreprestatario.Text = prestamo?.prestatario.Persona.nombre ?? "Desconocido";
            lblapellidoprestatario.Text = prestamo?.prestatario.Persona.apellido ?? "Desconocido";
            lbldocumentoprestatario.Text = prestamo?.prestatario.Persona.NumeroDocumento ?? "Desconocido";
            boxprestamosactivos.DataSource = prestamos
                .Where(p => p.id_prestatario == Usuario && p.estado == "Activo" && p.ofertaPrestamo.id_prestamista == idPrestamistaActual)
                .Select(p => p.id_prestamo)
                .ToList();
        }

        private void btnmandarecordatorio_Click(object sender, EventArgs e)
        {
            string mensaje = txtmensaje.Text.Trim();
            if (string.IsNullOrEmpty(mensaje))
            {
                MessageBox.Show("Debe ingresar un mensaje para el recordatorio.");
                return;
            }
            GuardarRecordatorio();
            MessageBox.Show("Recordatorio mandado exitosamente.");
            pnlmandarecordatorio.Visible = false;
            pnlrecordatorio.Visible = true;
        }

        private void GuardarRecordatorio()
        {
            var recordatorio = new Recordatorio
            {
                id_prestamo = (int)boxprestamosactivos.SelectedItem,
                fecharecordatorio = DateTime.Now,
                mensaje = txtmensaje.Text.Trim()
            };

            serviceRecordatorio.Guardar(recordatorio);
        }

        private void GuardarPrestamo()
        {
            int cuota = ValorCuota();
            OfertaPrestamo ofertaPrestamo = new OfertaPrestamo
            {
                cantidad = decimal.Parse(txtcantidad.Text.Trim()),
                intereses = decimal.Parse(txtintereses.Text.Trim().Replace('.', ',')),
                plazo = int.Parse(txtplazo.Text.Trim()),
                cuotas = cuota,
                cuotas_restantes = cuota,
                frecuencia = boxfrecuencia.SelectedItem.ToString(),
                fechainicio = DateTime.Now,
                fechavencimiento = DateTime.Now.AddMonths(int.Parse(txtplazo.Text.Trim())),
                estado = "Pendiente",
                proposito = "No informado",
                tipopago = "No informado",
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
            decimal valor;
            if (string.IsNullOrEmpty(cantidad) || !decimal.TryParse(cantidad, out valor) || valor <= 0)
            {
                MessageBox.Show("La cantidad no está digitada de manera correcta.");
                return false;
            }
            return true;
        }

        private bool ValidarIntereses()
        {
            string intereses = txtintereses.Text.Trim();
            decimal valor;
            if (string.IsNullOrEmpty(intereses) || !decimal.TryParse(intereses, out valor) || valor <= 0)
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

        private bool ValidarFrecuencia()
        {
            if (boxfrecuencia.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un tipo de documento.");
                boxfrecuencia.Focus();
                return false;
            }
            return true;
        }

        private int ValorCuota()
        {
            int plazo = int.Parse(txtplazo.Text.Trim());

            if (boxfrecuencia.SelectedItem.ToString() == "Mensual")
            {
                
                return plazo * 1;
            }
            else if (boxfrecuencia.SelectedItem.ToString() == "Quincenal")
            {

                return plazo * 2;
            }
            return plazo * 4;
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

        private void ResaltarBoton(Button botonActivo)
        {
            var botones = new List<Button> { btninicio, btnconsultarprestamos, btncrearprestamo, btncontrolpago, btnrecordatorios, btnsalir };

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
            pnlmandarecordatorio.Visible = false;
            pnlrecordatorio.Visible = true;
        }

        private void btnestadoprestamo_Click(object sender, EventArgs e)
        {
            if (boxestadoprestamo.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un estado de préstamo.");
                return;
            }
            string estadoSeleccionado = boxestadoprestamo.SelectedItem.ToString();
            var ofertasprestamo = serviceOfertaPrestamo.Consultar(new OfertaPrestamo())
                .Where(p => p.id_prestamista == idPrestamistaActual && p.estado == estadoSeleccionado)
                .ToList();
            dgvDatosPrestamos.DataSource = null;
            dgvDatosPrestamos.DataSource = ofertasprestamo;
            dgvDatosPrestamos.ClearSelection();
            OcultarColumnas();
        }

        private void btnrestablecer_Click(object sender, EventArgs e)
        {
            CargarPrestamos();
        }

        private void btnrestablecerpago_Click(object sender, EventArgs e)
        {
            CargarControlPagos();
        }

        private void btnfiltrarpago_Click(object sender, EventArgs e)
        {
            if (boxtipodepago.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un tipo de pago.");
                return;
            }
            string tipoPagoSeleccionado = boxtipodepago.SelectedItem.ToString();
            var ofertas = serviceOfertaPrestamo.Consultar(new OfertaPrestamo())
                .Where(o => o.id_prestamista == idPrestamistaActual)
                .ToList();

            var prestamos = servicePrestamo.Consultar(new Prestamo())
                .Where(pr => ofertas.Any(o => o.id == pr.id_ofertaprestamo))
                .ToList();

            var transacciones = serviceTransaccion.Consultar(new Transaccion())
                .Where(t => prestamos.Any(pr => pr.id_prestamo == t.id_prestamo) && t.tipo_transaccion == tipoPagoSeleccionado)
                .OrderBy(t => t.fecha)
                .Select(t =>
                {
                    var prestamo = prestamos.FirstOrDefault(pr => pr.id_prestamo == t.id_prestamo);
                    var prestatario = prestamo?.prestatario;
                    var persona = prestatario?.Persona;

                    return new TransaccionDTO
                    {
                        id = t.id_transaccion,
                        id_prestamo = t.id_prestamo,
                        monto = t.monto,
                        fecha = t.fecha,
                        tipo_transaccion = t.tipo_transaccion,
                        NombrePrestatario = persona?.nombre ?? "Desconocido",
                        ApellidoPrestatario = persona?.apellido ?? "Desconocido",
                        NumeroDocumentoPrestatario = persona?.NumeroDocumento ?? "Desconocido",
                        Intereses = ofertas.FirstOrDefault(o => o.id == prestamo?.id_ofertaprestamo)?.intereses ?? 0,
                        cuota = ofertas.FirstOrDefault(o => o.id == prestamo?.id_ofertaprestamo)?.cuotas ?? 0,
                    };
                })
                .ToList();
            dgvcontrolpagos.DefaultCellStyle.ForeColor = Color.Black;
            dgvcontrolpagos.DataSource = null;
            dgvcontrolpagos.DataSource = transacciones;
            dgvcontrolpagos.ClearSelection();
            dgvcontrolpagos.Columns["estado"].Visible = false;
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


        private void btndescargarpagos_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel files (*.xlsx)|*.xlsx";
                sfd.FileName = "InformeTransacciones.xlsx";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    ExportarDataGridViewAExcel(dgvcontrolpagos, sfd.FileName, "Control de pagos");
                }
            }
        }

        private void btndescargarprestamos_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel files (*.xlsx)|*.xlsx";
                sfd.FileName = "InformePrestamos.xlsx";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    ExportarDataGridViewAExcel(dgvDatosPrestamos, sfd.FileName, "Prestamos");
                }
            }
        }
    }
}
