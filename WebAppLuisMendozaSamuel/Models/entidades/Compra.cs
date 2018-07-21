using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppLuisMendozaSamuel.Models.Entidades
{
    public class Compra
    {
        [Key]
        public int id { get; set; }
        [Required]
        public int idProducto { get; set; }
        [Required]
        public int idCliente { get; set; }
        [Required]
        public int cantidad { get; set; }
        [Required]
        public decimal precioTotal { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual Producto Producto { get; set; }
    }
}
