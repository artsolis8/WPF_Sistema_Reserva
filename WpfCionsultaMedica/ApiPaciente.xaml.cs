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
    /// Lógica de interacción para ApiPaciente.xaml
    /// </summary>
    public partial class ApiPaciente : Window
    {
        public ApiPaciente()
        {
            InitializeComponent();
        }
        private async void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            Paciente p = new Paciente();
            p.nombre = txtNombre.Text;
            p.apellido = txtApellido.Text;
            p.nro_doc = Convert.ToInt32(txtNroDoc.Text);
            p.edad = Convert.ToInt32(txtNroDoc.Text);
            p.direccion = txtEdad.Text;
            p.telefono = txtNroTel.Text;
            p.direccion = txtDireccion.Text;
            p.ruc = txtRuc.Text;
            p.tipo_estado = Convert.ToInt32(txtTipoEstado.Text);
            p.tipo_sexo = Convert.ToInt32(txtTipoSexo.Text);
            p.email = txtEmail.Text;

            await Paciente.AgregarPaciente(p); //No olvidar el await
            ObtenerDatos();
        }
        private async void ObtenerDatos()
        {
            List<Paciente> lista = await Paciente.ObtenerTodos(); //No olvidar el await
            lstPacientes.ItemsSource = lista;
        }

        private async void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            if (lstPacientes.SelectedItem != null)
            {
                Paciente pacienteSeleccionado = (Paciente)lstPacientes.SelectedItem;
                pacienteSeleccionado.nombre = txtNombre.Text;
                pacienteSeleccionado.apellido = txtApellido.Text;
                pacienteSeleccionado.nro_doc = Convert.ToInt32(txtNroDoc.Text);
                pacienteSeleccionado.edad = Convert.ToInt32(txtNroDoc.Text);
                pacienteSeleccionado.direccion = txtEdad.Text;
                pacienteSeleccionado.telefono = txtNroTel.Text;
                pacienteSeleccionado.direccion = txtDireccion.Text;
                pacienteSeleccionado.ruc = txtRuc.Text;
                pacienteSeleccionado.tipo_estado = Convert.ToInt32(txtTipoEstado.Text);
                pacienteSeleccionado.tipo_sexo = Convert.ToInt32(txtTipoSexo.Text);
                pacienteSeleccionado.email = txtEmail.Text;
                await Paciente.ModificarPersona(pacienteSeleccionado); //No olvidar el await
                ObtenerDatos();
            }
            else
                MessageBox.Show("Debe seleccionar primeramente el paciente a modificar ");
        }

        private async void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (lstPacientes.SelectedItem != null)
            {
                Paciente pacienteSeleccionado = (Paciente)lstPacientes.SelectedItem;
                await Paciente.EliminarPaciente(pacienteSeleccionado); //No olvidar el await
                ObtenerDatos();
            }
            else
                MessageBox.Show("Debe seleccionar primeramente el pacientea eliminar ");
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            txtId.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtEdad.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtRuc.Text = string.Empty;
            txtNroDoc.Text = string.Empty;
            txtNroTel.Text = string.Empty;
            txtTipoEstado.Text = string.Empty;
            txtTipoSexo.Text = string.Empty;
            txtEmail.Text = string.Empty;

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ObtenerDatos();
        }

        private void lstPacientes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstPacientes.SelectedItem != null)
            {
                Paciente pacienteSeleccionado= (Paciente)lstPacientes.SelectedItem;
                txtId.Text = pacienteSeleccionado.id.ToString();
                txtNombre.Text = pacienteSeleccionado.nombre;
                txtApellido.Text = pacienteSeleccionado.apellido;
                txtEdad.Text = pacienteSeleccionado.edad.ToString();
                txtDireccion.Text = pacienteSeleccionado.direccion;
                txtRuc.Text = pacienteSeleccionado.ruc;
                txtTipoEstado.Text = pacienteSeleccionado.tipo_estado.ToString();
                txtTipoSexo.Text = pacienteSeleccionado.tipo_sexo.ToString();
                txtNroDoc.Text = pacienteSeleccionado.nro_doc.ToString();
                txtNroTel.Text = pacienteSeleccionado.telefono;
                txtEmail.Text = pacienteSeleccionado.email;

            }
        }
    }
}
