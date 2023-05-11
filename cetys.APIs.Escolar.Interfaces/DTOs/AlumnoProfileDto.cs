using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cetys.APIs.Escolar.Interfaces.DTOs
{

    public class AlumnoProfileDto
    {
        public string matricula { get; set; }
        public string nombre { get; set; }
        public string direcc { get; set; }
        public string lugarNacimiento { get; set; }

        public DateTime? fechaNacimiento { get; set; }
        public bool? estatus { get; set; }

        public CampusDto Campus { get; set; }
    }
    public class CampusDto
    {
        public string idCampus { get; set; }
        public string tipo { get; set; }
        public string nombre { get; set; }
        public string direcc { get; set; }
    }
}