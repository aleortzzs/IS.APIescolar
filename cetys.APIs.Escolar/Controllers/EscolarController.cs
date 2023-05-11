using cetys.APIs.Escolar.Interfaces.DTOs;
using cetys.APIs.Escolar.Interfaces.Escolar;
using System;
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
        /// <param name="matricula">matricula as a parameter [matricula numeric(6)], ex:010300</param>
        /// <returns>Regresa User Prodile Dto</returns>
        [Route("GetAlumnoByMatricula/v1/{matricula}/profile"), HttpGet]
        public AlumnoProfileDto GetAlumnoByMatriculaProfile(string matricula)
        {
            return Alumno.GetAlumnoProfile(matricula);
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
            httpResponseMessage.Headers.Location = new Uri("escolarQA/swagger/ui/index", UriKind.Relative);
            return httpResponseMessage;
        }
    }
}
