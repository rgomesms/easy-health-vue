using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EasyHealthApi.Models;

namespace EasyHealthApi.Controllers
{
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

    }
}
