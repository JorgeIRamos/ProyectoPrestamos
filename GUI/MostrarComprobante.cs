using Entidades;
using Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class MostrarComprobante : Form
    {
        private int idTransaccionActual;
        private Service<Transaccion> serviceTransaccion;
        public MostrarComprobante(int idTransaccion)
        {
            idTransaccionActual = idTransaccion;
            serviceTransaccion = new Service<Transaccion>();
            InitializeComponent();
            CargarComprobante();
        }
        private void CargarComprobante()
        {
            var transaccion = serviceTransaccion.BuscarPorId(idTransaccionActual, new Transaccion());
            picturecomprobante.SizeMode = PictureBoxSizeMode.StretchImage;
            if (transaccion != null && transaccion.imagen != null)
            {
                using (var ms = new MemoryStream(transaccion.imagen))
                {
                    picturecomprobante.Image = Image.FromStream(ms);
                }
            }
            else
            {
                picturecomprobante.Image = null; 
            }
        }

        private void picturecomprobante_Click(object sender, EventArgs e)
        {
            if (picturecomprobante.Image == null)
                return;

            Form pantallaCompleta = new Form();
            pantallaCompleta.FormBorderStyle = FormBorderStyle.None;
            pantallaCompleta.WindowState = FormWindowState.Maximized;
            pantallaCompleta.BackColor = Color.Black;
            pantallaCompleta.StartPosition = FormStartPosition.CenterScreen;

            PictureBox pb = new PictureBox();
            pb.Dock = DockStyle.Fill;
            pb.Image = picturecomprobante.Image;
            pb.SizeMode = PictureBoxSizeMode.Zoom;
            pb.BackColor = Color.Black;


            pb.Click += (s, ev) => pantallaCompleta.Close();

            pantallaCompleta.Controls.Add(pb);
            pantallaCompleta.ShowDialog();
        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btndescargar_Click(object sender, EventArgs e)
        {
            var transaccion = serviceTransaccion.BuscarPorId(idTransaccionActual, new Transaccion());
            if (picturecomprobante.Image == null)
            {
                MessageBox.Show("No hay imagen para guardar.");
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Title = "Guardar comprobante";
                sfd.Filter = "Imagen PNG|*.png|Imagen JPEG|*.jpg;*.jpeg|Bitmap|*.bmp";
                sfd.FileName = "ComprobanteDePago";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    System.Drawing.Imaging.ImageFormat formato = System.Drawing.Imaging.ImageFormat.Png;
                    string ext = Path.GetExtension(sfd.FileName).ToLower();

                    if (ext == ".jpg" || ext == ".jpeg")
                        formato = System.Drawing.Imaging.ImageFormat.Jpeg;
                    else if (ext == ".bmp")
                        formato = System.Drawing.Imaging.ImageFormat.Bmp;

                    try
                    {
                        using (Bitmap copia = new Bitmap(picturecomprobante.Image))
                        {
                            copia.Save(sfd.FileName, formato);
                        }
                        MessageBox.Show("Imagen guardada correctamente.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al guardar la imagen: " + ex.Message);
                    }
                }
            }
        }

    }
}
