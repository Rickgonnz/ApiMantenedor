using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MantenedorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ClientesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Cliente> clientes = from d in _unitOfWork.Cliente.Get()
                                            select new Cliente
                                            {
                                                ClienteId = d.ClienteId,
                                                Nombre = d.Nombre,
                                                Rut = d.Rut,
                                                Direccion = d.Direccion,
                                                Telefono = d.Telefono
                                            };
            if(clientes == null)
            {
                return NotFound("No existen clientes");
            }

            return Ok(clientes);
        }
    }
}
