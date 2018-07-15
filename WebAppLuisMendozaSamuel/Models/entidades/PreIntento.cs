using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppLuisMendozaSamuel.Models.entidades
{
    public class PreIntento
    {
        public decimal start { get; set; }
        public decimal stop { get; set; }
        public int IdAlumno { get; set; }
        public string RespuestaCorrecta { get; set; }
        public string RespuestaAlumno { get; set; }
    }
}
