using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Mvc;
using EasyHealthApi.Models;

namespace EasyHealthApi.Controllers
{
    public class RequestPessoaPaciente
    {
        public Pessoa pessoa { get; set; }
        public Paciente paciente { get; set; }
    }

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

        [HttpPost("post")]
        public void AddPaciente(RequestPessoaPaciente data)
        {
            //Adicionar uma pessoa primeiro
            Pessoa v_pessoa = data.pessoa;
            PessoaManager v_pessoaManager = new PessoaManager();
            v_pessoaManager.AddPessoa(v_pessoa);
            string v_pessoaId = v_pessoaManager.GetPessoaId();
            PacienteManager v_pacienteManager = new PacienteManager();
            Paciente v_paciente = data.paciente;
            v_paciente.codigo = v_pessoaId;
            v_pacienteManager.AddPaciente(v_paciente);
        }
    }
}
