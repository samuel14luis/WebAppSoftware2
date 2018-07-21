using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppLuisMendozaSamuel.Models.Entidades;

namespace WebAppLuisMendozaSamuel.Data.DataAccess
{
    public class ClienteDA
    {
        public IEnumerable<Cliente> GetListaClientes()
        {
            var listado = new List<Cliente>();
            using (var db = new ApplicationDbContext())
            {
                listado = db.Cliente.ToList();
            }
            return listado;
        }
        public int InsertarCliente(Cliente Cliente)
        {
            var result = 0;
            using (var db = new ApplicationDbContext())
            {
                db.Add(Cliente);
                db.SaveChanges();
                result = Cliente.idCliente;

            }
            return result;
        }
        public Cliente GetClienteById(int id)
        {
            var result = new Cliente();
            using (var db = new ApplicationDbContext())
            {
                result = db.Cliente.Where(item => item.idCliente == id).FirstOrDefault();
            }
            return result;
        }
        public Boolean ActualizarCliente(Cliente Cliente)
        {
            var result = false;
            using (var db = new ApplicationDbContext())
            {
                db.Cliente.Attach(Cliente);
                db.Entry(Cliente).State = EntityState.Modified;
                //db.Entry(Cliente).Property(item => item.FechaCreacion).IsModified = false;
                result = db.SaveChanges() != 0;

            }
            return result;
        }
        public Boolean EliminarCliente(int id)
        {
            var result = false;
            using (var db = new ApplicationDbContext())
            {
                var Cliente = new Cliente() { idCliente = id };
                db.Cliente.Attach(Cliente);
                db.Cliente.Remove(Cliente);
                result = db.SaveChanges() != 0;

            }
            return result;
        }
    }
}
