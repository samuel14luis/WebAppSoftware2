using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppLuisMendozaSamuel.Models.Entidades
{
    public class Intento
    {
        [Key]
        public int IdIntento { get; set; }

        [Display(Name = "Tiempo de respuesta"), Required(ErrorMessage = "Debe medir el tiempo de respuesta del alumno.")]
        public decimal Tiempo { get; set; }
        [Required]
        public decimal puntaje { get; set; }
        [Required]
        public int IdAlumno { get; set; }
        public virtual Alumno Alumno { get; set; }
    }
}
