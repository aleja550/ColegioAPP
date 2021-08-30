using System.Collections.Generic;

namespace Domain.AggregatesModel
{
    public class Estudiante
    {
        public int Id { get; set; }
        public string TipoIdentificacion { get; set; }
        public string Identificacion { get; set; }
        public string Nombre1 { get; set; }
        public string Nombre2 { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public string Direccion { get; set; }
        public string Ciudad { get; set; }

        public Estudiante() { }

        public Estudiante(int id, string tipoIdentificacion, string identificacion, string nombre1, string nombre2, string apellido1, string apellido2, string email, string celular, string direccion, string ciudad)
        {
            Id = id;
            TipoIdentificacion = tipoIdentificacion;
            Identificacion = identificacion;
            Nombre1 = nombre1;
            Nombre2 = nombre2;
            Apellido1 = apellido1;
            Apellido2 = apellido2;
            Email = email;
            Celular = celular;
            Direccion = direccion;
            Ciudad = ciudad;
        }
    }
}
