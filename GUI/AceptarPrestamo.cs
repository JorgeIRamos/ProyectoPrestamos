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
    public partial class AceptarPrestamo : Form
    {
        private int idofertaprestamo;
        private Service<OfertaPrestamo> serviceOfertaPrestamo;
        public AceptarPrestamo(int idoferta)
        {
            serviceOfertaPrestamo = new Service<OfertaPrestamo>();
            InitializeComponent();
            idofertaprestamo = idoferta;
        }

        private void btnfinalizar_Click(object sender, EventArgs e)
        {
            
            string nuevoProposito = txtproposito.Text.Trim();
            if (string.IsNullOrEmpty(nuevoProposito))
            {
                MessageBox.Show("Ingrese un propósito válido.");
                return;
            }
            if (boxtipopago.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un tipo de pago.");
                return;
            }
            string tipoPago = boxtipopago.SelectedItem?.ToString();
            OfertaPrestamo ofertaPrestamo = new OfertaPrestamo();
            var oferta = serviceOfertaPrestamo.BuscarPorId(idofertaprestamo, ofertaPrestamo);

            if (oferta == null)
            {
                MessageBox.Show("No se encontró la oferta de préstamo con ese ID.");
                return;
            }

            oferta.proposito = nuevoProposito;
            oferta.tipopago = tipoPago;

            string resultado = serviceOfertaPrestamo.Modificar(oferta);

            MessageBox.Show("Prestamo aceptado con exito.");
            this.DialogResult = DialogResult.OK;
            this.Close();

        }
    }
}
