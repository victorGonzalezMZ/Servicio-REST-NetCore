using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicioRESTNetCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PrincipalController : Controller
    {
        [HttpGet("ConsultaSQLServer")]
        public JsonResult Consultar(int ID)
        {
            var Consulta = new StorageAzure();
            var Lista = Consulta.Consulta(ID);
            //return new JsonResult(Lista);
            return Json(Lista);
        }

        [HttpGet("AlmacenarSQLServer")]
        public string Almacenar(string Nombre, string Domicilio, string Correo, int Edad, double Saldo)
        {
            var Almacena = new StorageAzure();
            bool resultado = Almacena.Almacenar(Nombre, Domicilio, Correo, Edad, Saldo);
            if (resultado == true)
                return "Almacenado en SQL Server sobre Azure desde .NET Core";
            else
                return "No Almacenado";
        }
    }
}
