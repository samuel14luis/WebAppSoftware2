using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAppLuisMendozaSamuel.Data.DataAccess;
using WebAppLuisMendozaSamuel.Models.entidades;
using WebAppLuisMendozaSamuel.Models.Entidades;

namespace WebAppLuisMendozaSamuel.Controllers
{
    public class AlumnoController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            var alumnoDA = new AlumnoDA();
            var modelo = alumnoDA.ListaAlumnos();
            return View(modelo);
        }
        [Authorize]
        public IActionResult Entrenamiento(string correo)
        {
            var alumnoDA = new AlumnoDA();
            var alumno = alumnoDA.GetAlumno(correo);
            if (alumno == null)
            {
                //no hay alumnos y este correo no está registrado como alumno, procedemos a registrarlo
                alumno = new Alumno();
                alumno.IdAlumno = 0;
                alumno.Correo = correo;
                var result = alumnoDA.InsertarAlumno(alumno);
                if (result > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            //Información del ejercicio
            ViewBag.enunciado = "Halla la subred a la que pertenece la siguiente dirección IP:";
            Random rnd = new Random();
            int o1 = rnd.Next(10, 192);
            int o2 = rnd.Next(0, 256);
            int o3 = rnd.Next(0, 256);
            int o4 = rnd.Next(0, 256);
            int x = rnd.Next(8, 32);
            ViewBag.ejercicio = o1+"."+o2+"."+o3+"."+o4+"/"+x;
            ViewBag.respuesta = "192.168.14.0";
            return View(alumno);
        }
        [Authorize]
        public IActionResult Create(Alumno alumno)
        {
            ViewBag.id = alumno.IdAlumno;
            ViewBag.correo = alumno.Correo;
            return View();
        }
        [Authorize]
        public IActionResult Resultado(PreIntento preintento, string correo)
        {
            ViewBag.start = preintento.start;
            ViewBag.stop = preintento.stop;
            ViewBag.IdAlumno = preintento.IdAlumno;
            ViewBag.RespuestaCorrecta = preintento.RespuestaCorrecta;
            ViewBag.RespuestaAlumno = preintento.RespuestaAlumno;
            ViewBag.usuario = correo.Split("@")[0];

            var intento = new Intento();
            intento.IdAlumno = preintento.IdAlumno;
            intento.Tiempo = preintento.stop - preintento.start;
            return View(intento);
        }
    }
}