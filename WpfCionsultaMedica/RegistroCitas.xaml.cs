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
using System.Speech.Synthesis;
namespace WpfCionsultaMedica
{
    /// <summary>
    /// Interaction logic for RegistroCitas.xaml
    /// </summary>
    public partial class RegistroCitas : Window
    {

        SpeechSynthesizer hablar = new SpeechSynthesizer();
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
            string nombre = cmbPaciente.DisplayMemberPath = "nombre";
            string apellido = cmbPaciente.DisplayMemberPath = "apellido";

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
            Cita citas = new Cita();
            
            citas.Consultorio1= (Consultorio)cmbConsultorio.SelectedItem;
            citas.Funcionario1 = (Funcionario)cmbFuncionario.SelectedItem;
            citas.Reserva1 = (Reserva)cmbReserva.SelectedItem;
            citas.Medico1 = (Medico)cmbMedico.SelectedItem;
            citas.Turno1= (Turno)cmbTurno.SelectedItem;
            citas.Paciente1= (Paciente)cmbPaciente.SelectedItem;
            citas.fecha = dtpFecha.SelectedDate;

            datos.Cita.Add(citas);
            datos.SaveChanges();
            CargarDatosGrilla();
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (dgCitas.SelectedItem != null)
            {
                Cita citas = (Cita)dgCitas.SelectedItem;



                datos.Cita.Remove(citas);
                datos.SaveChanges();
                CargarDatosGrilla();
            }
            else
                MessageBox.Show("Debe seleccionar una cita de la grilla para eliminar!");
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            if (dgCitas.SelectedItem != null)
            {

                Cita citas= (Cita)dgCitas.SelectedItem;

                citas.Consultorio1 = (Consultorio)cmbConsultorio.SelectedItem;
                citas.Funcionario1 = (Funcionario)cmbFuncionario.SelectedItem;
                citas.Reserva1 = (Reserva)cmbReserva.SelectedItem;
                citas.Medico1 = (Medico)cmbMedico.SelectedItem;
                citas.Turno1 = (Turno)cmbTurno.SelectedItem;
                citas.Paciente1 = (Paciente)cmbPaciente.SelectedItem;
                citas.fecha = dtpFecha.SelectedDate;


                //Le ponemos una banderita de que se modicaron datos en la entidad..
                datos.Entry(citas).State = System.Data.Entity.EntityState.Modified;
                datos.SaveChanges();

                CargarDatosGrilla();
            }
            else
                MessageBox.Show("Debe seleccionar una Cita de la grilla para modificar!");
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            cmbPaciente.SelectedIndex = -1;
            cmbConsultorio.SelectedIndex = -1;
            cmbFuncionario.SelectedIndex = -1;
            cmbMedico.SelectedIndex = -1;
            cmbReserva.SelectedIndex = -1;
            cmbTurno.SelectedIndex = -1;
        }

        private void btnLeer_Click(object sender, RoutedEventArgs e)
        {
            hablar.Speak(cmbConsultorio.SelectedItem.ToString());

            
        }

       
    }
}
