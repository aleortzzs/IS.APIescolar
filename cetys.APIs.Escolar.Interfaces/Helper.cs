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
                DTOs.AlumnoProfileDto item = new DTOs.AlumnoProfileDto()
                {
                    matricula = a.matricula,
                    nombre = a.nombre,
                    direcc = a.direcc,
                    lugarNacimiento = a.lugarNacimiento,
                    fechaNacimiento = a.fechaNacimiento,
                    idCampus = a.idCampus
                };

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