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
        public static List<DTOs.AlumnoProfileDto> GetAlumnoProfile(string matricula)
        {
            using (var cx = new EscolarEquipo5Entities())
            {
                var alumno = cx.alumno
                    .Include("Campus")
                    .Where(a => a.matricula == matricula)
                .ToList();

                return Helper.ConvertToAlumno(alumno);
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

                return Helper.ConvertToAlumno(alumno);
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
                        idCampus = alumno.idCampus.idCampus
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

        //CAMBIO ALUMNO



    }
}