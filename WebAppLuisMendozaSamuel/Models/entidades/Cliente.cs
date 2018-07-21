using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppLuisMendozaSamuel.Models.Entidades
{
    public class Cliente
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string nombre { get; set; }
        [Required]
        public int edad { get; set; }

        public virtual ICollection<Compra> Compras { get; set; }
    }
}
