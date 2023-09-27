using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations;


namespace Practica_2.Shared.Entities
{
    public class Evento
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "El identificador es requerido")]

        public string nombre_Evento { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]

        public string fechainicio { get; set; }

        public string fechafin { get; set; }

        public string ubicacion { get; set; }

        public string descripcion { get; set; }

        public string tema { get; set; }
    }

}
