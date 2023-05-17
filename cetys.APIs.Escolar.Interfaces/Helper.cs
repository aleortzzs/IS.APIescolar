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
                    idCampus = alumno.campus.idCampus
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

        public static MateriaDto ConvertTo1Materia(materia materia)
        {
            return new DTOs.MateriaDto()
            {
                idMateria = materia.idMateria,
                nombre = materia.nombre
            };
        }

        public static List<DTOs.MateriaDto> ConvertToMaterias(List<Entity.materia> materias)
        {
            List<DTOs.MateriaDto> list = new List<DTOs.MateriaDto>();
            foreach (Entity.materia a in materias)
            {
                MateriaDto item = ConvertTo1Materia(a);

                list.Add(item);
            }
            return list;
        }


        public static ProgramaDto ConvertTo1Programa(programa programa)
        {
            return new DTOs.ProgramaDto()
            {
                idPrograma = programa.idPrograma,
                nombrePrograma = programa.nombrePrograma,
                nivel= programa.nivel,
                Campus = new DTOs.CampusDto()
                {
                    idCampus = programa.campus.idCampus
                }
            };
        }

        public static List<DTOs.ProgramaDto> ConvertToProgramas(List<Entity.programa> programas)
        {
            List<DTOs.ProgramaDto> list = new List<DTOs.ProgramaDto>();
            foreach (Entity.programa a in programas)
            {
                ProgramaDto item = ConvertTo1Programa(a);

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