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
    public partial class Inicio_Sesion : Form
    {
        public Inicio_Sesion()
        {
            InitializeComponent();
        }

        private void btninicio_sesion_Click(object sender, EventArgs e)
        {
            
        }

        private void btnregistrarse_Click(object sender, EventArgs e)
        {
            this.Hide();
            Registro_Usuario registro_Usuario = new Registro_Usuario();
            registro_Usuario.Show();
        }
    }
}
