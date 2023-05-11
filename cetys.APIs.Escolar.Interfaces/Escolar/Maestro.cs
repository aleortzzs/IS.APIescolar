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
    }
}