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
    public partial class Registro_Usuario : Form
    {
        public Registro_Usuario()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Inicio_Sesion inicio_Sesion = new Inicio_Sesion();
            inicio_Sesion.Show();
        }

        private void btningresar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Inicio_Sesion inicio_Sesion = new Inicio_Sesion();
            inicio_Sesion.Show();
        }
    }
}
