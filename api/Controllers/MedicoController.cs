using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EasyHealthApi.Models;

namespace EasyHealthApi.Controllers
{
    public class RequestPessoaFuncionarioMedico
    {
        public Pessoa pessoa { get; set; }
        public Funcionario funcionario { get; set; }
        public Medico medico { get; set; }
    }

    [ApiController]
    [Route("medico")]
    public class MedicoController : Controller
    {
        [HttpGet("get")]
        public List<Medico> GetMedicos()
        {
            MedicoManager v_manager = new MedicoManager();
            List<Medico> v_result = v_manager.GetMedicos().ToList();
            return v_result;
        }

        [HttpGet("get/especialidades")]
        public Object GetEspecialidades(String especialidade)
        {
            MedicoManager v_manager = new MedicoManager();
            //Se tem uma especialidade como parametro, pega esses medicos
           //Senao, pega a lista de especialidades. Gambiarra para usar o mesmo endpoint, pq eh mais facil.
            if (especialidade==null)
            {
                List<String> v_result = v_manager.GetEspecialidades().ToList();
                return v_result;
            }
            else
            {
                List<Medico> v_result = v_manager.GetMedicosPorEspecialidade(especialidade).ToList();
                return v_result;
            }
        }
        [HttpPost("post")]
        public void AddMedico(RequestPessoaFuncionarioMedico data)
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
            Medico v_medico = data.medico;
            MedicoManager v_medicoManager = new MedicoManager();
            v_medico.codigo = v_pessoaId;
            v_medicoManager.AddMedico(v_medico);
        }
    }
}
