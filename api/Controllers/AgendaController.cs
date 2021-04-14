using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EasyHealthApi.Models;

namespace EasyHealthApi.Controllers
{
    [ApiController]
    [Route("agenda")]
    public class AgendaController : Controller
    {
        [HttpGet("get")]
        public List<Agenda> GetAgendas()
        {
            AgendaManager v_manager = new AgendaManager();
            List<Agenda> v_result = v_manager.GetAgendas().ToList();
            return v_result;
        }

        [HttpGet("get/medico")]
        public List<Agenda> GetMedicoAgenda(int codigoMedico)
        {
            AgendaManager v_manager = new AgendaManager();
            List<Agenda> v_result = v_manager.GetMedicoAgenda(codigoMedico).ToList();
            return v_result;
        }

        [HttpGet("get/horarios")]
        public List<String> GetHorariosDisponiveis(int codigoMedico, string date)
        {
            AgendaManager v_manager = new AgendaManager();
            List<String> v_result = v_manager.GetHorariosDisponiveis(codigoMedico, date);
            return v_result;
        }

        [HttpPost("post")]
        public void AddConsulta(Agenda p_agenda)
        {
            AgendaManager v_manager = new AgendaManager();
             v_manager.AddConsulta(p_agenda);
        }
    }
}
