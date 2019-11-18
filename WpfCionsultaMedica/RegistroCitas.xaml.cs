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
    /// Interaction logic for RegistroCitas.xaml
    /// </summary>
    public partial class RegistroCitas : Window
    {
        ConsultaMedicaEntities datos;

        public RegistroCitas()
        {
            InitializeComponent();
            datos = new ConsultaMedicaEntities();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CargarDatosGrilla();
            cmbConsultorio.ItemsSource = datos.Consultorio.ToList();
            cmbConsultorio.DisplayMemberPath = "descripcion";
            cmbConsultorio.SelectedValuePath = "id";
            cmbFuncionario.ItemsSource = datos.Funcionario.ToList();
            cmbFuncionario.DisplayMemberPath = "nombre";
            cmbFuncionario.SelectedValuePath = "id";
            cmbPaciente.ItemsSource = datos.Paciente.ToList();
            cmbPaciente.DisplayMemberPath = "nombre";
            cmbPaciente.SelectedValuePath = "id";
            cmbReserva.ItemsSource = datos.Reserva.ToList();
            cmbReserva.DisplayMemberPath = "paciente";
            cmbReserva.SelectedValuePath = "id";
            cmbTurno.ItemsSource = datos.Turno.ToList();
            cmbTurno.DisplayMemberPath = "descripcion";
            cmbTurno.SelectedValuePath = "id";
            cmbMedico.ItemsSource = datos.Medico.ToList();
            cmbMedico.DisplayMemberPath = "nombre";
            cmbMedico.SelectedValuePath = "id";
            

        }

        private void CargarDatosGrilla()
        {
            try
            {

                dgCitas.ItemsSource = datos.Cita.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
