using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EasyHealthApi.Models;

namespace EasyHealthApi.Controllers
{
    public class RequestPessoaFuncionario
    {
        public Pessoa pessoa { get; set; }
        public Funcionario funcionario { get; set; }
    }
    public class RequestLogin
    {
        public string senha { get; set; }
        public string email { get; set; }
    }

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
        [HttpPost("login")]
        public Object PostLogin(RequestLogin data)
        {
            FuncionarioManager v_manager = new FuncionarioManager();
            string v_senhaHash = v_manager.GetHash(data.senha);
            Object v_result = v_manager.Login(v_senhaHash, data.email);
            return v_result;
        }
        [HttpPost("post")]
        public void AddFuncionario(RequestPessoaFuncionario data)
        {
            //Adicionar uma pessoa primeiro
            Pessoa v_pessoa = data.pessoa;
            PessoaManager v_pessoaManager = new PessoaManager();
            v_pessoaManager.AddPessoa(v_pessoa);
            string v_pessoaId = v_pessoaManager.GetPessoaId();
            FuncionarioManager v_funcionarioManager = new FuncionarioManager();
            Funcionario v_funcionario = data.funcionario;
            v_funcionario.senha = v_funcionarioManager.GetHash(v_funcionario.senha);
            v_funcionario.codigo = v_pessoaId;
            v_funcionarioManager.AddFuncionario(v_funcionario);
        }
    }
}

