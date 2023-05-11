﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cetys.APIs.Escolar.Interfaces.DTOs
{

    public class MaestroDto
    {
        public string numEmpleado { get; set; }
        public string nombre { get; set; }
        public string direcc { get; set; }
        public string lugarNacimiento { get; set; }
        public string fechaNacimiento { get; set; }
        public bool estatus { get; set; }
        public CampusDto idCampus { get; set; }
    }
}