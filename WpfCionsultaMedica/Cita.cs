//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfCionsultaMedica
{
    using System;
    using System.Collections.Generic;
    
    public partial class Cita
    {
        public int id { get; set; }
        public Nullable<int> paciente { get; set; }
        public Nullable<int> medico { get; set; }
        public Nullable<int> funcionario { get; set; }
        public Nullable<int> turno { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
        public Nullable<int> consultorio { get; set; }
        public Nullable<int> reserva { get; set; }
    
        public virtual Consultorio Consultorio1 { get; set; }
        public virtual Turno Turno1 { get; set; }
        public virtual Funcionario Funcionario1 { get; set; }
        public virtual Medico Medico1 { get; set; }
        public virtual Paciente Paciente1 { get; set; }
        public virtual Reserva Reserva1 { get; set; }
    }
}
