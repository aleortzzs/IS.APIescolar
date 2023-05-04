using cetys.APIs.Escolar.Interfaces.DTOs;
using System.Collections.Generic;

namespace cetys.APIs.Escolar.Interfaces.Escolar
{
    public class Alumno
    {
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
        }

        

    }
}