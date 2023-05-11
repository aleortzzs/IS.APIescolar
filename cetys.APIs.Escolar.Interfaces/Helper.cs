using cetys.APIs.Escolar.Interfaces.DTOs;
using cetys.APIs.Escolar.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cetys.APIs.Escolar.Interfaces
{
    public class Helper
    {
        public static List<DTOs.AlumnoProfileDto> ConvertToAlumno(List<Entity.alumno> alumnos)
        {
            List<DTOs.AlumnoProfileDto> list = new List<DTOs.AlumnoProfileDto>();
            foreach (Entity.alumno a in alumnos)
            {
                AlumnoProfileDto item = ConvertTo1Alumno(a);

                list.Add(item);
            }
            return list;

        }

        public static AlumnoProfileDto ConvertTo1Alumno(alumno alumno)
        {
            return new DTOs.AlumnoProfileDto()
            {
                matricula = alumno.matricula,
                nombre = alumno.nombre,
                direcc = alumno.direcc,
                lugarNacimiento = alumno.lugarNacimiento,
                fechaNacimiento = alumno.fechaNacimiento,
                estatus = alumno.estatus,
                Campus = new DTOs.CampusDto()
                {
                    nombre = alumno.campus.nombre
                }
            };
        }

        public static MaestroDto ConvertTo1Maestro(maestro maestro)
        {
            return new DTOs.MaestroDto()
            {
                numEmpleado = maestro.numEmpleado,
                nombre = maestro.nombre,
                direcc = maestro.direcc,
                lugarNacimiento = maestro.lugarNacimiento,
                fechaNacimiento = maestro.fechaNacimiento,
                estatus = maestro.estatus,
                idCampus = new DTOs.CampusDto()
                {
                    idCampus = maestro.campus.idCampus    
                }
            };
        }

        public static List<DTOs.MaestroDto> ConvertToMaestro(List<Entity.maestro> maestros)
        {
            List<DTOs.MaestroDto> list = new List<DTOs.MaestroDto>();
            foreach (Entity.maestro a in maestros)
            {
                MaestroDto item = ConvertTo1Maestro(a);

                list.Add(item);
            }
            return list;

        }

        public static void log(Exception e)
        {
            throw new NotImplementedException();
        }
    }
}