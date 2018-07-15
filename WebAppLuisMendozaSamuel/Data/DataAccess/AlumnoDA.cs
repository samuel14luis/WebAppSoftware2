using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppLuisMendozaSamuel.Models.Entidades;

namespace WebAppLuisMendozaSamuel.Data.DataAccess
{
    public class AlumnoDA
    {
        public IEnumerable<Alumno> ListaAlumnos()
        {
            var listado = new List<Alumno>();
            using (var db = new ApplicationDbContext())
            {
                var query = db.Alumno.ToList();
                listado = query.OrderBy(item => item.IdAlumno).ToList();

            }
            return listado;
        }
        public Alumno GetAlumno(string correo)
        {
            var result = new Alumno();
            using (var db = new ApplicationDbContext())
            {
                result = db.Alumno.Where(item => item.Correo == correo).FirstOrDefault();
            }
            return result;
        }
        public int InsertarAlumno(Alumno alumno)
        {
            var result = 0;
            using (var db = new ApplicationDbContext())
            {
                db.Add(alumno);
                db.SaveChanges();
                result = alumno.IdAlumno;

            }
            return result;
        }
    }
}
