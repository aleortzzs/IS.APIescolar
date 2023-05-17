using cetys.APIs.Escolar.Entity;
using cetys.APIs.Escolar.Interfaces.DTOs;
using cetys.APIs.Escolar.Interfaces.Escolar;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace cetys.APIs.Escolar.Controllers
{
    /// <summary>
    /// API que contiene los endpoints relativos a informaci1ón de Alumnos
    /// </summary>
    /// <remarks>
    /// API containing endpoint for Students related information
    /// </remarks>
    [Route("api/Escolar")]
    public class EscolarController : ApiController
    {
        /// <summary>
        /// API que contiene los endpoints relativos a informacion de Alumnos
        /// </summary>
        /// <remarks>
        /// API containing endpoint for Students related information
        /// </remarks>
        public EscolarController()
        {

        }

        /// <summary>
        /// Metodo para obtener el perfil basico del alumno
        /// </summary>
        /// <remarks>
        /// Method to get the basic user profile
        /// </remarks>
        /// <param name="matricula">matricula as a parameter [matricula varchar(7)], ex:m035190</param>
        /// <returns>Regresa User Prodile Dto</returns>
        [Route("GetAlumnoByMatricula/v1/{matricula}/profile"), HttpGet]
        public AlumnoProfileDto GetAlumnoByMatriculaProfile(string matricula)
        {
            return Alumno.GetAlumnoProfile(matricula);
        }

        /// <summary>
        /// Metodo para obtener lista de alumnos, proporcionando nombre o apellido
        /// </summary>
        /// <remarks>
        /// Method to get the basic user profile
        /// </remarks>
        /// <param name="nombre">nombre as a parameter [nombre varchar(50)], ex:Melghem</param>
        /// <returns>Regresa Lista Alumnos</returns>
        [Route("GetListAlumnosByName/v1/{nombre}/profile"), HttpGet]
        public List<AlumnoProfileDto> GetListAlumnosByName(string nombre)
        {
            return Alumno.GetAlumnosByName(nombre);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="datos"></param>
        /// <returns></returns>
        [Route("AgregarAlumno/v1"), HttpPost]
        public bool AgregarAlumno(AlumnoProfileDto datos)
        {
            return Alumno.AgregarAlumno(datos);
        }


        /// <summary>
        /// Metodo para obtener el perfil basico del maestro
        /// </summary>
        /// <remarks>
        /// Method to get the basic user profile
        /// </remarks>
        /// <param name="numEmpleado">numEmpleado as a parameter [numEmpleado numeric(6)], ex:010300</param>
        /// <returns>Regresa User Prodile Dto</returns>
        [Route("GetMaestroByNumEmpleado/v1/{numEmpleado}/profile"), HttpGet]
        public MaestroDto GetMaestroByNumEmpleado(int numEmpleado)
        {
            return Maestro.GetMaestroProfile(numEmpleado);
        }

        /// <summary>
        /// Metodo para obtener lista de maestros, proporcionando nombre o apellido
        /// </summary>
        /// <remarks>
        /// Method to get the basic user profile
        /// </remarks>
        /// <param name="nombre">nombre as a parameter [nombre varchar(50)], ex:Melghem</param>
        /// <returns>Regresa Lista Maestros</returns>
        [Route("GetListMaestrosByName/v1/{nombre}/profile"), HttpGet]
        public List<MaestroDto> GetListMaestrosByName(string nombre)
        {
            return Maestro.GetMaestrosByName(nombre);
        }


        /// <summary>
        /// Obtiene todas las materias 
        /// </summary>
        /// <returns></returns>
        [Route("GetMaterias/v1/Todos"), HttpGet]
        public List<Interfaces.DTOs.MateriaDto> GetMaterias()
        {
            return Interfaces.Escolar.Materia.GetALLmaterias();
        }







        /// <summary>
        /// Redirects to swagger
        /// </summary>
        /// <returns></returns>
        [Route(""), HttpGet]
        [ApiExplorerSettings(IgnoreApi = true)]
        public HttpResponseMessage RedirectToSwaggerUi()
        {
            var httpResponseMessage = new HttpResponseMessage(HttpStatusCode.Found);
            httpResponseMessage.Headers.Location = new Uri("swagger/ui/index", UriKind.Relative);
            return httpResponseMessage;
        }
    }
}
