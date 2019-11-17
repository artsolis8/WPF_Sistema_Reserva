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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfCionsultaMedica
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ConsultaMedicaEntities datos;
        public MainWindow()
        {
            InitializeComponent();
            datos = new ConsultaMedicaEntities();
        }

        private void CargarDatosGrilla()
        {
            try
            {
                
                dgConsultorios.ItemsSource = datos.Consultorio.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CargarDatosGrilla();
            cboClinica.ItemsSource = datos.Clinica.ToList();
            cboClinica.DisplayMemberPath = "descripcion";
            cboClinica.SelectedValuePath = "id";
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            Consultorio consul= new Consultorio();
            consul.descripcion= txtDescripcion.Text;
            consul.Clinica1= (Clinica)cboClinica.SelectedItem;




            datos.Consultorio.Add(consul);
            datos.SaveChanges();
            CargarDatosGrilla();
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            if (dgConsultorios.SelectedItem != null)
            {

                Consultorio consul= (Consultorio)dgConsultorios.SelectedItem;

                consul.descripcion= txtDescripcion.Text;
                consul.Clinica1= (Clinica)cboClinica.SelectedItem;

                
                //Le ponemos una banderita de que se modicaron datos en la entidad..
                datos.Entry(consul).State = System.Data.Entity.EntityState.Modified;
                datos.SaveChanges();
                
                CargarDatosGrilla();
            }
            else
                MessageBox.Show("Debe seleccionar un Consultorio de la grilla para modificar!");
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (dgConsultorios.SelectedItem != null)
            {
                Consultorio consul= (Consultorio)dgConsultorios.SelectedItem;

                

                datos.Consultorio.Remove(consul);
                datos.SaveChanges();
                CargarDatosGrilla();
            }
            else
                MessageBox.Show("Debe seleccionar un COnsultorio de la grilla para eliminar!");
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            txtId.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            cboClinica.SelectedIndex = -1;
            
        }
    }
}
