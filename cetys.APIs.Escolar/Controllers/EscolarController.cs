using cetys.APIs.Escolar.Entity;
using cetys.APIs.Escolar.Interfaces.DTOs;
using cetys.APIs.Escolar.Interfaces.Escolar;
using Swashbuckle.Swagger.Annotations;
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
        /// Agregar nueva Materia
        /// </summary>
        /// <param name="datos"></param>
        /// <returns></returns>
        [Route("AgregarMateria/v1"), HttpPost]
        public bool AgregarMateria(MateriaDto datos)
        {
            return Materia.AgregarMateria(datos);
        }

        /// <summary>
        /// Agregar nuevo Maestro
        /// </summary>
        /// <param name="datos"></param>
        /// <returns></returns>
        [Route("AgregarMaestro/v1"), HttpPost]
        public bool AgregarMaestro(MaestroDto datos)
        {
            return Maestro.AddMaestro(datos);
        }

        /// <summary>
        /// Agregar nuevoPrograma
        /// </summary>
        /// <param name="datos"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AgregarPrograma/v1")]
        public bool AgregarPrograma([FromBody] ProgramaDto datos)
        {
            return Programa.AgregarPrograma(datos);
        }


        /// <summary>
        /// Modificar alumno
        /// </summary>
        /// <param name="alumno"></param>
        /// <returns></returns>
        [Route("ModificarAlumno/v1/"), HttpPost]
        public bool ModificarAlumno(Interfaces.DTOs.AlumnoProfileDto alumno)
        {
            return Interfaces.Escolar.Alumno.ModificarAlumno(alumno);
        }

        /// <summary>
        /// Modificar maestro
        /// </summary>
        /// <param name="maestro"></param>
        /// <returns></returns>
        [Route("ModificarMaestro/v1/"), HttpPost]
        public bool ModificarMaestro(Interfaces.DTOs.MaestroDto maestro)
        {
            return Interfaces.Escolar.Maestro.UpdateMaestro(maestro);
        }
        /// <summary>
        /// Baja a alumno por matricula
        /// </summary>
        /// <param name="matricula"></param>
        /// <returns></returns>
        [Route("BajaAlumno/v1/{matricula}"), HttpPost]
        public bool BajaAlumno(string matricula)
        {
            return Interfaces.Escolar.Alumno.BajaAlumno(matricula);
        }

        /// <summary>
        /// Baja a maestro por número de empleado
        /// </summary>
        /// <param name="numEmpleado"></param>
        /// <returns></returns>
        [Route("BajaMaestro/v1/{numEmpleado}"), HttpPost]
        public bool BajaMaestro(int numEmpleado)
        {
            return Interfaces.Escolar.Maestro.DeleteMaestro(numEmpleado);
        }
        /// <summary>
        /// Metodo para obtener lista de materias en un programa
        /// </summary>
        /// <param name="idPrograma"></param>
        /// <returns>Regresa Lista Materias</returns>
        [Route("GetMateriasInPrograma/v1/{idPrograma}/"), HttpGet]
        public List<MateriaDto> GetMateriasInPrograma(string idPrograma)
        {
            return Materia.GetMateriasInPrograma(idPrograma);
        }

        /// <summary>
        /// Metodo para obtener lista de materias por el profesor
        /// </summary>
        /// <param name="numEmpleado"></param>
        /// <returns>Regresa Lista Materias</returns>
        [Route("GetMateriasByMaestro/v1/{numEmpleado}/"), HttpGet]
        public List<MateriaDto> GetMateriasByMaestro(int numEmpleado)
        {
            return Materia.GetMateriasByMaestro(numEmpleado);
        }

        /// <summary>
        /// Metodo para obtener lista de programas que tienen a una materia en específico
        /// </summary>
        /// <param name="idMateria"></param>
        /// <returns>Regresa Lista Programas</returns>
        [Route("GetProgramaWithMateria/v1/{idMateria}/"), HttpGet]
        public List<ProgramaDto> GetProgramaWithMateria(string idMateria)
        {
            return Programa.GetProgramaWithMateria(idMateria);
        }

        /// <summary>
        /// Metodo para obtener el programa del alumno proporcionando la matrícula
        /// </summary>
        /// <param name="matricula"></param>
        /// <returns>Regresa el Programa del Alumno</returns>
        [Route("GetProgramaAlumno/v1/{matricula}/"), HttpGet]
        public ProgramaDto GetProgramaAlumno(string matricula)
        {
            return Programa.GetProgramaAlumno(matricula);
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
