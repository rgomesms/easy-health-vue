using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EasyHealthApi.Models;

namespace EasyHealthApi.Controllers
{
    [ApiController]
    [Route("pessoa")]
    public class PessoaController : Controller
    {
        [HttpGet("get")]
        public List<Pessoa> GetPessoas()
        {
            PessoaManager v_manager = new PessoaManager();
            List<Pessoa> v_result = v_manager.GetPessoas().ToList();
            return v_result;
        }
    }
}
