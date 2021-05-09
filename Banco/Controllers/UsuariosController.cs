using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiRest.DTO;
using ApiRest.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiRest.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IUsuariosServices _usuariosServices;


        public UsuariosController(IUsuariosServices usuariosServices)
        {
            this._usuariosServices = usuariosServices;
        }

        [HttpPost]
        public IActionResult Insert([FromBody] Usuarios dto)
        {
            if (string.IsNullOrEmpty(dto.nombre.ToString()))
            {
                BadRequest("error con los parametros enviados");
            }
            return Ok(_usuariosServices.Insert(dto));
        }

        [HttpGet]
        public IActionResult Login(string dto)
        {
            if (string.IsNullOrEmpty(dto.ToString()))
            {
                BadRequest("error con los parametros enviados");
            }
            return Ok(_usuariosServices.Login(dto));
        }


        [HttpGet]
        public IActionResult Roles(string dto)
        {
            if (string.IsNullOrEmpty(dto.ToString()))
            {
                BadRequest("error con los parametros enviados");
            }
            return Ok(_usuariosServices.Roles(dto));
        }

        [HttpPut]
        public IActionResult Actualizar([FromBody]Usuarios dto)
        {
            if (string.IsNullOrEmpty(dto.nombre.ToString()))
            {
                BadRequest("error con los parametros enviados");
            }
            return Ok(_usuariosServices.Actualizar(dto));
        }

        [HttpGet]
        public IActionResult Listar(string dto)
        {
            //IUsuariosServices
            List<IUsuariosServices> list = _usuariosServices.Listar(dto);
            for(int i=0; i<list.size; i++)
            {
                list.GetEnumerator(i).id = Encrypt(list.GetEnumerator(i).id);
                list.GetEnumerator(i).id = Encrypt(list.GetEnumerator(i).nombre);
                list.GetEnumerator(i).id = Encrypt(list.GetEnumerator(i).apellido);
                list.GetEnumerator(i).id = Encrypt(list.GetEnumerator(i).saldo);
                list.GetEnumerator(i).id = Encrypt(list.GetEnumerator(i).fecha);
                list.GetEnumerator(i).id = Encrypt(list.GetEnumerator(i).cuenta);
                list.GetEnumerator(i).id = Encrypt(list.GetEnumerator(i).clave);
                list.GetEnumerator(i).id = Encrypt(list.GetEnumerator(i).rol);
                list.GetEnumerator(i).id = Encrypt(list.GetEnumerator(i).cedula);
            }
            return Ok(_usuariosServices.Listar(dto));
        }

        [HttpGet]
        public IActionResult LCuenta(string dto)
        {

            return Ok(_usuariosServices.LCuenta(dto));
        }

        [HttpGet]
        public IActionResult Imprimir()
        {

            return Ok(_usuariosServices.Imprime());
        }
    }
}
