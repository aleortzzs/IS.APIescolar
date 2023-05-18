using cetys.APIs.Escolar.Interfaces.DTOs;
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
                        idCampus = maestro.Campus.idCampus
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

        public static bool UpdateMaestro(MaestroDTO maestro)
        {
            using (var cx = new EscolarRomeliaEntities())
            {
                var item = cx.Maestro
                    .Where(a => a.numEmpleado == maestro.numEmpleado)
                    .SingleOrDefault();
                if (item != null)
                {
                    item.nombre = maestro.nombre;
                    item.direcc = maestro.direcc;
                    item.lugarNacimiento = maestro.lugarNacimiento;
                    item.fechaNacimiento = maestro.fechaNacimiento;
                    item.estatus= maestro.estatus;
                    item.idCampus = maestro.idCampus;
                }
                cx.SaveChanges();
            }

            return true;
        }

        //DELETE MAESTRO 
    }
    public static bool DeleteMaestro(string numEmpleado)
    {
        using (var cx = new EscolarRomeliaEntities())
        {
            var item = cx.Maestro
                .Where(a => a.numEmplelado == numeEmpleado)
                .SingleOrDefault();
            if (item != null)
            {
                item.estatus = false;
            }
            cx.SaveChanges();
        }

        return true;
    }

    public class Materia
    {
        //GET ALL MATERIAS
        //!!!!!!!!!!!!!!!!!!checar este
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

    public class Programa
    {
        //GET ALL PROGRAMAS
        //!!!!!!!!!!!!!!!!!!checar este
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
}