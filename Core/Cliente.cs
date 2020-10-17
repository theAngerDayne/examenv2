using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core
{
    public class Cliente
    {
        public int Id { get; set; }
        [Required]
        public string Rut { get; set; }

        [Required, MinLength(3)]
        public string Nombre { get; set; }

        [Required, MinLength(3)]
        public string Apellidos { get; set; }

        [Required]
        public DateTime FechaNacimiento { get; set; }

        [Required, MinLength(10)]
        public string Direccion { get; set; }

        [MinLength(8)]
        public string Telefono { get; set; }
    }
}
