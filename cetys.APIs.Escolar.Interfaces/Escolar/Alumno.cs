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
    public class Alumno
    {
        /*
        public static AlumnoProfileDto GetAlumnoProfile(string Matricula)
        {
            try
            {
                var profile = new AlumnoProfileDto()
                {

                    matricula = "123456",
                    nombre = "Alejandra Ortiz",
                    direcc = "Mexicali, B.C.",
                    lugarNacimiento = "Mexicali",
                    fechaNacimiento = "09/07/2002",
                    idCampus = new CampusDto()
                    {
                        idCampus = "1",
                        tipo = "presencial",
                        nombre = "CETYS UNIVERSIDAD CAMPUS Mexicali",
                        direcc = "Calz. Cetys s/n, Mexicali"
                    }
                };

                return profile;
            }
            catch (System.Exception)
            {
                throw;
            }
        }*/


        //GET BY MATRICULA
        public static DTOs.AlumnoProfileDto GetAlumnoProfile(string matricula)
        {
            using (var cx = new EscolarEquipo5Entities())
            {
                var alumno = cx.alumno
                    .Include("Campus")
                    .Where(a => a.matricula == matricula)
                .FirstOrDefault();

                var alumnoprofiler = Helper.ConvertTo1Alumno(alumno);
                alumnoprofiler.avance = AlumnoPrograma.CalcularPorcentajeAvance(alumnoprofiler.matricula);

                return alumnoprofiler;
            }
        }

        //GET BY NOMBRE O APELLIDO
        public static List<DTOs.AlumnoProfileDto> GetAlumnosByName(string nombre = "")
        {
            using (var cx = new EscolarEquipo5Entities())
            {
                var alumno = cx.alumno
                    .Where(a => a.nombre.Contains(nombre))
                    .ToList();

                var alumnoprofiler = Helper.ConvertToAlumno(alumno);
                foreach(var a in alumnoprofiler)
                {
                    a.avance = AlumnoPrograma.CalcularPorcentajeAvance(a.matricula);
                }

                return alumnoprofiler;
            }
        }

        //ALTA ALUMNO
        public static bool AgregarAlumno(AlumnoProfileDto alumno)
        {
            try
            {
                using (var cx = new EscolarEquipo5Entities())
                {
                    var a = new Entity.alumno
                    {
                        matricula = alumno.matricula,
                        nombre = alumno.nombre,
                        direcc = alumno.direcc,
                        lugarNacimiento = alumno.lugarNacimiento,
                        fechaNacimiento = alumno.fechaNacimiento,
                        estatus = true,
                        idCampus = alumno.Campus.idCampus
                    };
                    cx.alumno.Add(a);
                    cx.SaveChanges();
                }
            }
            catch (Exception e){
                Helper.log(e);
                throw;
            }
            return true;
        }

        //BAJA ALUMNO
        //Se tiene que poner el AlumnoProfileDto

        public static bool BajaAlumno(string matricula)
        {
            using (var cx = new EscolarEquipo5Entities())
            {
                var item = cx.alumno
                    .Where(a => a.matricula == matricula)
                    .SingleOrDefault();
                if (item != null)
                {
                    item.estatus = false;
                }
                cx.SaveChanges();
            }

            return true;
        }

        //CAMBIO ALUMNO
        public static bool ModificarAlumno(AlumnoProfileDto alumno)
        {
            using (var cx = new EscolarEquipo5Entities())
            {
                var item = cx.alumno
                    .Where(a => a.matricula == alumno.matricula)
                    .SingleOrDefault();
                if (item != null)
                {
                    item.nombre = alumno.nombre;
                    item.direcc = alumno.direcc;
                    item.lugarNacimiento = alumno.lugarNacimiento;
                    item.fechaNacimiento = alumno.fechaNacimiento;
                    item.estatus = alumno.estatus;
                    item.idCampus = alumno.Campus.idCampus;
                }
                cx.SaveChanges();
            }

            return true;
        }



    }
}