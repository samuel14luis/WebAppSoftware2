using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppLuisMendozaSamuel.Models.Entidades;

namespace WebAppLuisMendozaSamuel.Data.DataAccess
{
    public class ProductoDA
    {
        public IEnumerable<Producto> GetListaProductos()
        {
            var listado = new List<Producto>();
            using (var db = new ApplicationDbContext())
            {
                listado = db.Producto.ToList();

            }
            return listado;
        }
        public int InsertarProducto(Producto producto)
        {
            var result = 0;
            using (var db = new ApplicationDbContext())
            {
                db.Add(producto);
                db.SaveChanges();
                result = producto.idProducto;

            }
            return result;
        }
        public Producto GetProductoById(int id)
        {
            var result = new Producto();
            using (var db = new ApplicationDbContext())
            {
                result = db.Producto.Where(item => item.idProducto == id).FirstOrDefault();
            }
            return result;
        }
        public Boolean ActualizarProducto(Producto producto)
        {
            var result = false;
            using (var db = new ApplicationDbContext())
            {
                db.Producto.Attach(producto);
                db.Entry(producto).State = EntityState.Modified;
                //db.Entry(producto).Property(item => item.FechaCreacion).IsModified = false;
                result = db.SaveChanges() != 0;

            }
            return result;
        }
        public Boolean EliminarProducto(int id)
        {
            var result = false;
            using (var db = new ApplicationDbContext())
            {
                var producto = new Producto() { idProducto = id };
                db.Producto.Attach(producto);
                db.Producto.Remove(producto);
                result = db.SaveChanges() != 0;

            }
            return result;
        }
    }
}
