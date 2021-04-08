﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EasyHealthApi.Models;

namespace EasyHealthApi.Controllers
{
    [ApiController]
    [Route("endereco")]
    public class EnderecoController : Controller
    {
        [HttpGet("get")]
        public List<Endereco> GetEnderecos()
        {
            EnderecoManager v_manager = new EnderecoManager();
            List<Endereco> v_result = v_manager.GetEnderecos().ToList();
            return v_result;
        }
    }
}
