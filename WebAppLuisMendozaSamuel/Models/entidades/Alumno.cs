using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppLuisMendozaSamuel.Models.Entidades
{
    public class Alumno
    {
        [Key]
        public int IdAlumno { get; set; }

        [Display(Name = "Correo del almuno"), Required(ErrorMessage = "Debe ingresar un correo para el alumno.")]
        public string Correo { get; set; }
        public virtual ICollection<Intento> Intentos { get; set; }
    }
}
