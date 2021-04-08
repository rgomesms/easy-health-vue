using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EasyHealthApi.Models;

namespace EasyHealthApi.Controllers
{
    [ApiController]
    [Route("funcionario")]
    public class FuncionarioController : Controller
    {
        [HttpGet("get")]
        public List<Funcionario> GetFuncionarios()
        {
            FuncionarioManager v_manager = new FuncionarioManager();
            List<Funcionario> v_result = v_manager.GetFuncionarios().ToList();
            return v_result;
        }
    }
}
