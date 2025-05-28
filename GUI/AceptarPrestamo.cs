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

            string tipoPago = txtpago.Text.Trim();
            if (string.IsNullOrEmpty(tipoPago))
            {
                MessageBox.Show("Ingrese un tipo de pago válido.");
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
            oferta.tipopago = tipoPago;

            string resultado = serviceOfertaPrestamo.Modificar(oferta);

            MessageBox.Show("Proposito y pago guardados con exito");
            this.Dispose();

        }
    }
}
