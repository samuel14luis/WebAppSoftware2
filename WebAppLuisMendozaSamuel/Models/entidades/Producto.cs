using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppLuisMendozaSamuel.Models.Entidades
{
    public class Producto
    {
        [Key] 
        public int idProducto { get; set; }
        [Required]
        public string nombre { get; set; }
        [Required]
        public int stock { get; set; }
        [Required]
        public decimal precioUnitario { get; set; }

        public virtual ICollection<Compra> Compras { get; set; }
    }
}
