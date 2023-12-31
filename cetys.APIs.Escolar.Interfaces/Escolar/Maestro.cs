﻿using cetys.APIs.Escolar.Interfaces.DTOs;
using cetys.APIs.Escolar.Entity;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using cetys.APIs.Escolar.Interfaces.Escolar;
using cetys.APIs.Escolar.Interfaces;
using System;
using System.Linq;

namespace cetys.APIs.Escolar.Interfaces.Escolar
{
    public class Maestro
    {
        //GET BY NUMEPLEADO
        public static DTOs.MaestroDto GetMaestroProfile(int numEmpleado)
        {
            using (var cx = new EscolarEquipo5Entities())
            {
                var maestro = cx.maestro
                    .Include("Campus")
                    .Where(a => a.numEmpleado == numEmpleado)
                .FirstOrDefault();
                return Helper.ConvertTo1Maestro(maestro);
            }
        }

        //GET BY NOMBRE O APELLIDO
        public static List<DTOs.MaestroDto> GetMaestrosByName(string nombre = "")
        {
            using (var cx = new EscolarEquipo5Entities())
            {
                var maestro = cx.maestro
                    .Where(a => a.nombre.Contains(nombre))
                    .ToList();
                return Helper.ConvertToMaestro(maestro);
            }
        }

        //ADD MAESTRO
        public static bool AddMaestro(MaestroDto maestro)
        {
            try
            {
                using (var cx = new EscolarEquipo5Entities())
                {
                    var a = new Entity.maestro
                    {
                        numEmpleado = maestro.numEmpleado,
                        nombre = maestro.nombre,
                        direcc = maestro.direcc,
                        lugarNacimiento = maestro.lugarNacimiento,
                        fechaNacimiento = maestro.fechaNacimiento,
                        estatus = true,
                        idCampus = maestro.idCampus.idCampus
                    };
                    cx.maestro.Add(a);
                    cx.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Helper.log(e);
                throw;
            }
            return true;
        }
        //UPDATE MAESTRO

        public static bool UpdateMaestro(MaestroDto maestro)
        {
            using (var cx = new EscolarEquipo5Entities())
            {
                var item = cx.maestro
                    .Where(a => a.numEmpleado == maestro.numEmpleado)
                    .SingleOrDefault();
                if (item != null)
                {
                    item.nombre = maestro.nombre;
                    item.direcc = maestro.direcc;
                    item.lugarNacimiento = maestro.lugarNacimiento;
                    item.fechaNacimiento = maestro.fechaNacimiento;
                    item.estatus= maestro.estatus;
                    item.idCampus = maestro.idCampus.idCampus;
                }
                cx.SaveChanges();
            }

            return true;
        }
        //DELETE MAESTRO
        public static bool DeleteMaestro(int numEmpleado)
        {
            using (var cx = new EscolarEquipo5Entities())
            {
                var item = cx.maestro
                    .Where(a => a.numEmpleado == numEmpleado)
                    .SingleOrDefault();
                if (item != null)
                {
                    item.estatus = false;
                }
                cx.SaveChanges();
            }

            return true;
        }
    }

    public class Materia
    {
        //GET ALL MATERIAS
        public static List<DTOs.MateriaDto> GetALLmaterias(string nombre = "")
        {
            using (var cx = new EscolarEquipo5Entities())
            {
                var materia = cx.materia
                    .Where(a => a.nombre.Contains(nombre))
                    .ToList();
                return Helper.ConvertToMaterias(materia);
            }
        }

        //GET MATERIAS IN PROGRAMA
        public static List<DTOs.MateriaDto> GetMateriasInPrograma(string idPrograma = "")
        {
            using (var cx = new EscolarEquipo5Entities())
            {
                var materias = cx.materia
                .Where(m => m.materiaPrograma.Any(mp => mp.idPrograma == idPrograma))
                .ToList();

                return Helper.ConvertToMaterias(materias);
            }
        }

        //GET MATERIAS BY PROFESOR
        public static List<DTOs.MateriaDto> GetMateriasByMaestro(int maestroId)
        {
            using (var cx = new EscolarEquipo5Entities())
            {
                var materias = cx.materia
                    .Where(m => m.maestroMateria.Any(mm => mm.numEmpleado == maestroId))
                    .ToList();

                return Helper.ConvertToMaterias(materias);
            }
        }

        //POST ADD MATERIA
        public static bool AgregarMateria(MateriaDto materia)
        {
            try
            {
                using (var cx = new EscolarEquipo5Entities())
                {
                    var a = new Entity.materia
                    {
                        idMateria = materia.idMateria,
                        nombre = materia.nombre
                    };
                    cx.materia.Add(a);
                    cx.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Helper.log(e);
                throw;
            }
            return true;
        }
    }
    public class Campus
    {

        //POST ADD Campus
        public static bool AgregarCampus(CampusDto campus)
        {
            try
            {
                using (var cx = new EscolarEquipo5Entities())
                {
                    var a = new Entity.campus
                    {
                        idCampus = campus.idCampus,
                        nombre = campus.nombre,
                        tipo = campus.tipo,
                        direcc = campus.direcc
                    };
                    cx.campus.Add(a);
                    cx.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Helper.log(e);
                throw;
            }
            return true;
        }
    }
    public class Programa
    {
        //GET ALL PROGRAMAS
        public static List<DTOs.ProgramaDto> GetALLprogramas(string nombre = "")
        {
            using (var cx = new EscolarEquipo5Entities())
            {
                var programa = cx.programa
                    .Where(a => a.nombrePrograma.Contains(nombre))
                    .ToList();
                return Helper.ConvertToProgramas(programa);
            }
        }

        //GET PROGRAMAS WITH MATERIA
        public static List<DTOs.ProgramaDto> GetProgramaWithMateria(string idMateria = "")
        {
            using (var cx = new EscolarEquipo5Entities())
            {
                var programas = cx.programa
                .Where(p => p.materiaPrograma.Any(mp => mp.idMateria == idMateria))
                .ToList();

                return Helper.ConvertToProgramas(programas);
            }
        }

        //GET PROGRAMA DE ALUMNO
        public static DTOs.ProgramaDto GetProgramaAlumno(string matricula = "")
        {
            using (var cx = new EscolarEquipo5Entities())
            {
                var programa = cx.programa
                .Join(cx.alumnoPrograma,
                    p => p.idPrograma,
                    ap => ap.idPrograma,
                    (p, ap) => new { Programa = p, alumnoPrograma = ap })
                .Join(cx.alumno,
                    ap => ap.alumnoPrograma.matricula,
                    a => a.matricula,
                    (ap, a) => new { Programa = ap.Programa, alumno = a })
                .Where(data => data.alumno.matricula == matricula)
                .Select(data => data.Programa)
                .FirstOrDefault();

                return Helper.ConvertTo1Programa(programa);
            }
        }

        //POST ADD PROGRAMA
        public static bool AgregarPrograma(ProgramaDto programa)
        {
            try
            {
                using (var cx = new EscolarEquipo5Entities())
                {
                    var a = new Entity.programa
                    {
                        idPrograma = programa.idPrograma,
                        nombrePrograma = programa.nombrePrograma,
                        nivel = programa.nombrePrograma,
                        idCampus = programa.Campus.idCampus
                    };
                    cx.programa.Add(a);
                    cx.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Helper.log(e);
                throw;
            }
            return true;
        }

    }


    public class AlumnoPrograma
    {
        public static DTOs.AlumnoProgramaDto GetAlumnoPrograma(string matricula)
        {
            using (var cx = new EscolarEquipo5Entities())
            {
                var alumnoP = cx.alumnoPrograma
                    .Where(a => a.matricula == matricula)
                .FirstOrDefault();

                return Helper.ConvertTo1AP(alumnoP);
            }
        }
        public static bool addAlumnoPrograma(AlumnoProgramaDto alumnoPrograma)
        {
            try
            {
                using (var cx = new EscolarEquipo5Entities())
                {
                    var a = new Entity.alumnoPrograma
                    {
                        idAlumnoPrograma = alumnoPrograma.idAlumnoPrograma,
                        matricula = alumnoPrograma.matricula.matricula,
                        idPrograma = alumnoPrograma.idPrograma.idPrograma,
                        semestre = alumnoPrograma.semestre,
                        avance = CalcularPorcentajeAvance(alumnoPrograma.matricula.matricula)
                    };
                    cx.alumnoPrograma.Add(a);
                    cx.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Helper.log(e);
                throw;
            }
            return true;
        }
        public static bool UpdateAlumnoPrograma(AlumnoProgramaDto alumnoPrograma)
        {
            using (var cx = new EscolarEquipo5Entities())
            {
                var item = cx.alumnoPrograma
                    .Where(a => a.idAlumnoPrograma == alumnoPrograma.idAlumnoPrograma)
                    .SingleOrDefault();
                if (item != null)
                {
                    item.idAlumnoPrograma = alumnoPrograma.idAlumnoPrograma;
                    item.matricula = alumnoPrograma.matricula.matricula;
                    item.idPrograma = alumnoPrograma.idPrograma.idPrograma;
                    item.semestre = alumnoPrograma.semestre;
                    item.avance= CalcularPorcentajeAvance(alumnoPrograma.matricula.matricula);
                }
                cx.SaveChanges();
            }
            return true;
        }


        public static double CalcularPorcentajeAvance(string matricula)
        {
            using (var cx = new EscolarEquipo5Entities())
            {
                var materias = cx.alumnoMateria
                    .Where(ap => ap.matricula == matricula).ToList();

                double totalMateriasPrograma = materias.Count();
                double materiasAprobadas = materias.Where(m => m.aprobada == true).Count();

                return totalMateriasPrograma == 0 ? 0 : (double)(materiasAprobadas / totalMateriasPrograma) * 100; ;
            }
        }
    }

    public class AlumnoMateria
    {
        public static bool addAlumnoMateria(AlumnoMateriaDto alumnoMateria)
        {
            try
            {
                using (var cx = new EscolarEquipo5Entities())
                {
                    var a = new Entity.alumnoMateria
                    {
                        idAlumnoMateria = alumnoMateria.idAlumnoMateria,
                        matricula = alumnoMateria.matricula.matricula,
                        idMateria = alumnoMateria.idMateria.idMateria,
                        aprobada = alumnoMateria.aprobada
                    };
                    cx.alumnoMateria.Add(a);
                    cx.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Helper.log(e);
                throw;
            }
            //LLAMAR AL METODO UPDATEALUMNOPROGRAMA PARA QUE SE ACTUALICE EL %%% AVANCE
            var cc = AlumnoPrograma.GetAlumnoPrograma(alumnoMateria.matricula.matricula);
            AlumnoPrograma.UpdateAlumnoPrograma(cc);
            return true;
        }

        //UPDATE ALUMNOMATERIA
        //POR EJEMPLO, SI SE QUIERE CAMBIAR QUE LA MATERIA YA SE APROBO, NO SOLO SE TIENE Q CAMBIAR ESE DATO
        //TAMBIEN SE TIENE QUE CAMBIAR EL PORCENTAJE DE AVNCE EN ALUMNO PROGRAMA
        public static bool UpdateAlumnoMateria(AlumnoMateriaDto alumnoMateria)
        {
            using (var cx = new EscolarEquipo5Entities())
            {
                var item = cx.alumnoMateria
                    .Where(a => a.idAlumnoMateria == alumnoMateria.idAlumnoMateria)
                    .SingleOrDefault();
                if (item != null)
                {
                    item.idAlumnoMateria = alumnoMateria.idAlumnoMateria;
                    item.matricula = alumnoMateria.matricula.matricula;
                    item.idMateria = alumnoMateria.idMateria.idMateria;
                    item.aprobada = alumnoMateria.aprobada;
                }
                cx.SaveChanges();
            }
            //LLAMAR AL METODO UPDATEALUMNOPROGRAMA PARA QUE SE ACTUALICE EL %%% AVANCE
            var cc = AlumnoPrograma.GetAlumnoPrograma(alumnoMateria.matricula.matricula);
            AlumnoPrograma.UpdateAlumnoPrograma(cc);
            return true;
        }
    }
}