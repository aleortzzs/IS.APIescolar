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
        public double? avance { get; set; }

        public CampusDto Campus { get; set; }
    }
    public class CampusDto
    {
        public string idCampus { get; set; }
        public string tipo { get; set; }
        public string nombre { get; set; }
        public string direcc { get; set; }
    }

    public class MateriaDto
    {
        public string idMateria { get; set; }
        public string nombre { get; set; }
    }

    public class ProgramaDto
    {
        public string idPrograma { get; set; }
        public string nombrePrograma { get; set; }
        public string nivel { get; set; }
        public CampusDto Campus { get; set; }
    }
    public class MateriaProgramaDto
    {
        public int idMateriaPrograma { get; set; }
        public MateriaDto idMateria { get; set; }
        public ProgramaDto idPrograma { get; set; }
    }

    public class MaestroMateriaDto
    {
        public int idMaestroMateria { get; set; }
        public MateriaDto idMateria { get; set; }
        public MaestroDto numEmpleado { get; set; }
    }

    public class AlumnoMateriaDto
    {
        public int idAlumnoMateria { get; set; }
        public MateriaDto idMateria { get; set; }
        public AlumnoProfileDto matricula { get; set; }
        public bool aprobada { get; set; }
    }

    public class AlumnoProgramaDto
    {
        public int idAlumnoPrograma { get; set; }
        public AlumnoProfileDto matricula { get; set; }
        public ProgramaDto idPrograma { get; set; }
        public int semestre { get; set; }
        public float avance { get; set; }
    }
}