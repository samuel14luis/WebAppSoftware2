using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppLuisMendozaSamuel.Models.Entidades;

namespace WebAppLuisMendozaSamuel.Data.DataAccess
{
    public class IntentoDA
    {
        public int insertarIntento(Intento intento)
        {
            var resultado = 0;
            using (var db = new ApplicationDbContext())
            {
                db.Add(intento);
                db.SaveChanges();
                resultado = intento.IdIntento;
            }
            return resultado;
        }
    }
}
