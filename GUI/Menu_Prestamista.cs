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
        private Service<Transaccion> serviceTransaccion;
        private Service<Prestamo> servicePrestamo;
        private int idPrestamistaActual;
        private string Nombre;
        public Menu_Prestamista(int idPrestamista, string nombre)
        {
            servicePrestamista = new Service<Prestamista>();
            serviceOfertaPrestamo = new Service<OfertaPrestamo>();
            serviceTransaccion = new Service<Transaccion>();
            servicePrestamo = new Service<Prestamo>();
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
        private void btncrearprestamo_Click(object sender, EventArgs e)
        {
            ResaltarBoton(btncrearprestamo);
            pnlcrearprestamo.Visible = true;
            pnlconsultarprestamo.Visible = false;
            pnlinicio.Visible = false;
            pnlcontrolpago.Visible = false;
        }

        private void btnconsultarprestamos_Click(object sender, EventArgs e)
        {
            ResaltarBoton(btnconsultarprestamos);
            pnlinicio.Visible = false;
            pnlcrearprestamo.Visible = false;
            pnlconsultarprestamo.Visible = true;
            pnlcontrolpago.Visible = false;
            CargarPrestamos();
        }

        private void btncontrolpago_Click(object sender, EventArgs e)
        {
            ResaltarBoton(btncontrolpago);
            pnlinicio.Visible = false;
            pnlcrearprestamo.Visible = false;
            pnlconsultarprestamo.Visible = false;
            pnlcontrolpago.Visible = true;
        }

        private void btncrear_Click(object sender, EventArgs e)
        {
            if (!ValidarCantidad() || !ValidarIntereses() || !ValidarPlazo() || !ValidarFrecuencia() )
            {
                return;
            }

            GuardarPrestamo();


        }

        private void CargarPrestamos()
        {
            var ofertasprestamos = serviceOfertaPrestamo.Consultar(new OfertaPrestamo());

            var prestamosFiltrados = ofertasprestamos
                .Where(p => p.id_prestamista == idPrestamistaActual)
                .OrderBy(p => p.id)
                .ToList();

            dgvDatosPrestamos.DataSource = null;
            dgvDatosPrestamos.DataSource = prestamosFiltrados;

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
                        cuota = ofertas.FirstOrDefault(o => o.id == prestamo?.id_ofertaprestamo)?.cuotas ?? 0
                    };
                })
                .ToList();

            dgvcontrolpagos.DataSource = null;
            dgvcontrolpagos.DataSource = transacciones;
        }

        private void CargarUsuarios()
        {
            var prestamos = servicePrestamo.Consultar(new Prestamo())
                .Where(pr => pr.ofertaPrestamo.id_prestamista == idPrestamistaActual)
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

            dgvusuarios.DataSource = null;
            dgvusuarios.DataSource = prestamos;

            dgvusuarios.Columns["id"].Visible = false;
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

        private void txtcantidad_TextChanged(object sender, EventArgs e)
        {

        }

        private void btninicio_Click(object sender, EventArgs e)
        {
            ResaltarBoton(btninicio);
            pnlconsultarprestamo.Visible = false;
            pnlcrearprestamo.Visible = false;
            pnlinicio.Visible = true;
            pnlcontrolpago.Visible = false;
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

        
    }
}
