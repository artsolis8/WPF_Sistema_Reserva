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
    /// Lógica de interacción para w_cita.xaml
    /// </summary>
    public partial class w_cita : Window
    {
        ConsultaMedicaEntities datos;
        public w_cita()
        {
            InitializeComponent();
            datos = new WpfCionsultaMedica.ConsultaMedicaEntities();
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

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            Cita consul = new Cita();
            consul.paciente= (Paciente)cmbPaciente.SelectedItem;




            datos.Consultorio.Add(consul);
            datos.SaveChanges();
            CargarDatosGrilla();
        }
    }
}
