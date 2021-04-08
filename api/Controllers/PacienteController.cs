using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EasyHealthApi.Models;

namespace EasyHealthApi.Controllers
{
    [ApiController]
    [Route("paciente")]
    public class PacienteController : Controller
    {
        [HttpGet("get")]
        public List<Paciente> GetPacientes()
        {
            PacienteManager v_manager = new PacienteManager();
            List<Paciente> v_result = v_manager.GetPacientes().ToList();
            return v_result;
        }
    }
}
