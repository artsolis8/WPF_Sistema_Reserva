using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfCionsultaMedica
{
    /// <summary>
    /// Lógica de interacción para Clinica.xaml
    /// </summary>
    public partial class Clinica : Window
    {
        ConsultaMedicaEntities datos;


        public Clinica()
        {
            InitializeComponent();
            datos = new ConsultaMedicaEntities();
        }

        void CargarGrilla()
        {
            dgClinica.ItemsSource = datos.Clinica.ToList();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CargarGrilla();
        }

        private void BtnAgregar_Click(object sender, RoutedEventArgs e)
        {

            Clinica c = new Clinica();
            c.descripcion = txtDescripcion.Text;
            c.direccion = txtDireccion.Text;
            c.ciudad = Convert.ToInt32(txtCiudad.Text);
            c.telefono = txtTelefono.Text;


            datos.Clinica.Add(c);
            datos.SaveChanges();
            CargarGrilla();

        }

        private void BtnModificar_Click(object sender, RoutedEventArgs e)
        {
            if (dgClinica.SelectedItem != null)
            {
                Clinica c = (Clinica)dgClinica.SelectedItem;
                c.descripcion = txtDescripcion.Text;
                c.direccion = txtDireccion.Text;
                c.ciudad = Convert.ToInt32(txtCiudad.Text);
                c.telefono = txtTelefono.Text;

                datos.Entry(c).State = System.Data.Entity.EntityState.Modified;
                datos.SaveChanges();
                CargarGrilla();

            }
            else
                MessageBox.Show("Debe seleccionar una Clinica de la grilla para modificar!");

        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (dgClinica.SelectedItem != null)
            {
                Clinica c = (Clinica)dgClinica.SelectedItem;
                datos.Clinica.Remove(c);
                datos.SaveChanges();
                CargarGrilla();
            }
        }

        private void BtnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            txtId.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtCiudad.Text = string.Empty;
            txtTelefono.Text = string.Empty;

        }



        private void DgClinica_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dgClinica.SelectedItem != null)
            {
                Clinica c = (Clinica)dgClinica.SelectedItem;

                txtId.Text = c.id.ToString();
                txtDescripcion.Text = c.descripcion;
                txtDireccion.Text = c.direccion;
                txtCiudad.Text = c.ciudad.ToString();
                txtTelefono.Text = c.telefono;

            }

        }
    }
}
