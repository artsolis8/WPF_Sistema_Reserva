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
    /// Lógica de interacción para w_turno.xaml
    /// </summary>
    public partial class w_turno : Window
    {
        ConsultaMedicaEntities datos;
        public w_turno()
        {
            InitializeComponent();
            datos= new ConsultaMedicaEntities();
        }

        private void CargarDatosGrilla()
        {
            try
            {

                dgTurno.ItemsSource = datos.Turno.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CargarDatosGrilla();
        }

        private void BtnModificar_Click(object sender, RoutedEventArgs e)
        {
            if (dgTurno.SelectedItem != null)
            {

                Turno turno = (Turno)dgTurno.SelectedItem;

                turno.descripcion = txtTurno.Text;
                turno.hora_inicio = txtHoraInicio.Text;
                turno.hora_fin = txtHoraFin.Text;

                datos.Entry(turno).State = System.Data.Entity.EntityState.Modified;
                datos.SaveChanges();

                CargarDatosGrilla();
            }
            else
                MessageBox.Show("Debe seleccionar un Turno de la grilla para modificar!");

        }

        private void BtnGuardar_Click_1(object sender, RoutedEventArgs e)
        {
            Turno turno = new Turno();
            turno.descripcion = txtTurno.Text;
            turno.hora_inicio = txtHoraInicio.Text;
            turno.hora_fin = txtHoraFin.Text;

            datos.Turno.Add(turno);
            datos.SaveChanges();
            CargarDatosGrilla();

        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (dgTurno.SelectedItem != null)
            {
                Turno turno = (Turno)dgTurno.SelectedItem;



                datos.Turno.Remove(turno);
                datos.SaveChanges();
                CargarDatosGrilla();
            }
            else
                MessageBox.Show("Debe seleccionar un Turno de la grilla para eliminar!");

        }

        private void BtnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            txtTurno.Text = "";
            txtHoraInicio.Text = "";
            txtHoraFin.Text = "";
            CargarDatosGrilla();
        }
    }
}
