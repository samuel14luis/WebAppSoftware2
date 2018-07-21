using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppLuisMendozaSamuel.Models.Entidades;

namespace WebAppLuisMendozaSamuel.Data.DataAccess
{
    public class CompraDA
    {
        public IEnumerable<Compra> GetListaCompras()
        {
            var listado = new List<Compra>();
            using (var db = new ApplicationDbContext())
            {
                listado = db.Compra.Include(item => item.Producto).ToList();
            }
            return listado;
        }
        public int InsertarCompra(Compra Compra)
        {
            var result = 0;
            using (var db = new ApplicationDbContext())
            {
                db.Add(Compra);
                db.SaveChanges();
                result = Compra.id;

            }
            return result;
        }
        public Compra GetCompraById(int id)
        {
            var result = new Compra();
            using (var db = new ApplicationDbContext())
            {
                result = db.Compra.Where(item => item.id == id).FirstOrDefault();
            }
            return result;
        }
        public Boolean ActualizarCompra(Compra Compra)
        {
            var result = false;
            using (var db = new ApplicationDbContext())
            {
                db.Compra.Attach(Compra);
                db.Entry(Compra).State = EntityState.Modified;
                //db.Entry(Cliente).Property(item => item.FechaCreacion).IsModified = false;
                result = db.SaveChanges() != 0;

            }
            return result;
        }
        public Boolean EliminarCompra(int id)
        {
            var result = false;
            using (var db = new ApplicationDbContext())
            {
                var Compra = new Compra() { id = id };
                db.Compra.Attach(Compra);
                db.Compra.Remove(Compra);
                result = db.SaveChanges() != 0;

            }
            return result;
        }
    }
}
