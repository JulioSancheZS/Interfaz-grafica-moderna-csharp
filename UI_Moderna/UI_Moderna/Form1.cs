using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace UI_Moderna
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //private void btnCerrar_Click(object sender, EventArgs e)
        //{
        //    Application.Exit();
        //}

        //private void btnMinimizar_Click(object sender, EventArgs e)
        //{
        //    this.WindowState = FormWindowState.Minimized;
        //}

        //private void btnMaximizar_Click(object sender, EventArgs e)
        //{
        //    this.WindowState = FormWindowState.Maximized;
        //    btnMinimizar.Visible = false;
        //    btnMaximizar.Visible = true;
        //}

        //private void btnRestaurar_Click(object sender, EventArgs e)
        //{
        //    this.WindowState = FormWindowState.Normal;
        //    btnMaximizar.Visible = false;
        //    btnMinimizar.Visible = true;
        //}

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            subMenu.Visible = true;
        }

        private void btnReproVenta_Click(object sender, EventArgs e)
        {
            subMenu.Visible = false;
        }

        private void btnReproPagos_Click(object sender, EventArgs e)
        {
            subMenu.Visible = false;
        }

        private void btnReporPagos_Click(object sender, EventArgs e)
        {
            subMenu.Visible = false;
        }

        // Metodo para abrir un form dentro de otro
        private void abrirVentanaHija(object ventaHija)
        {
            if (this.panelContenedor.Controls.Count > 0) // Preguntamos si existe algun control en el panel
            {
                this.panelContenedor.Controls.RemoveAt(0); // Si se cumple, lo eliminamos
            }

            Form formulario = ventaHija as Form; // Aqui se crea un nuevo formulario...  
            // que es igual al objeto que recibe el metodo y a este los convertimos en un formulario con la palabra reservada "as"

            formulario.TopLevel = false;// decimos que no sea un formulario de nivel superior, si no un formulario secundario
            formulario.Dock = DockStyle.Fill; // Esto hara que se acople a todo el panel contenedor
            this.panelContenedor.Controls.Add(formulario); // Lo agregamos al panel
            this.panelContenedor.Tag = formulario; //establesemos la instancia como contenedor de datos de nuestro panel
            formulario.Show(); // lo mostramos
        }

        private void btnProducto_Click(object sender, EventArgs e)
        {
            abrirVentanaHija(new frmProducto()); // Lo enviamos como parametro y lo declaramos como nuevo objeto
        }

        private void btncClientes_Click(object sender, EventArgs e)
        {
            abrirVentanaHija(new frmCliente());
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //private void btnMaximizar_Click(object sender, EventArgs e)
        //{
        //    this.WindowState = FormWindowState.Maximized;
        //    btnMinimizar.Visible = false;
        //    btnMaximizar.Visible = true;
        //}

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panelContenedor_Paint(object sender, PaintEventArgs e)
        {

        }

        //private void btnRestaurar_Click(object sender, EventArgs e)
        //{
        //    this.WindowState = FormWindowState.Normal;
        //    btnMaximizar.Visible = false;
        //    btnMinimizar.Visible = true;
        //}
    }
}
