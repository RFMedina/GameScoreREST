using System;
using System.ComponentModel.DataAnnotations;

namespace TodoAPI.Models
{
    public class TodoItem
    {
        [Required]
        public string ID { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public int Puntuacion { get; set; }

        public string Sinopsis { get; set; }

        public string Fecha { get; set; }
        
        public string Plataforma { get; set; }

    }
}
