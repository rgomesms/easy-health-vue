using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace EasyHealthApi.Models
{
    public class Agenda
    {
        public string codigo { get; set; }
        public string datetime { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string telefone { get; set; }
        public string codigoMedico { get; set; }
        public string nomeMedico { get; set; }
    }
    public class AgendaManager
    {
        public AgendaManager() { }

        public List<Agenda> GetAgendas()
        {
            List<Agenda> v_Agendas = new List<Agenda>();
            MySqlConnection v_connection = ConnectionDB.connection();
            MySqlCommand v_query = v_connection.CreateCommand();
            v_query.CommandText = "SELECT a.codigo, a.`datetime`, a.nome, a.email, a.telefone, a.codigoMedico, p.nome nomeMedico FROM easyhealth.Agenda a inner join easyhealth.pessoa p on p.codigo=a.codigoMedico;";
            v_connection.Open();
            MySqlDataReader v_fetchQuery = v_query.ExecuteReader();
            while (v_fetchQuery.Read())
            {
                Agenda t_Medico = new Agenda();
                t_Medico.codigo = v_fetchQuery["codigo"].ToString();
                t_Medico.datetime = v_fetchQuery["datetime"].ToString();
                t_Medico.nome = v_fetchQuery["nome"].ToString();
                t_Medico.email = v_fetchQuery["email"].ToString();
                t_Medico.telefone = v_fetchQuery["telefone"].ToString();
                t_Medico.codigoMedico = v_fetchQuery["codigoMedico"].ToString();
                t_Medico.nomeMedico = v_fetchQuery["nomeMedico"].ToString();


                v_Agendas.Add(t_Medico);
            }
            v_connection.Close();

            return v_Agendas;
        }

        public List<Agenda> GetMedicoAgenda(int codigoMedico)
        {
            List<Agenda> v_Agendas = new List<Agenda>();
            MySqlConnection v_connection = ConnectionDB.connection();
            MySqlCommand v_query = v_connection.CreateCommand();
            v_query.CommandText = $"SELECT a.codigo, a.`datetime`, a.nome, a.email, a.telefone, a.codigoMedico, p.nome nomeMedico FROM easyhealth.Agenda a inner join easyhealth.pessoa p on p.codigo=a.codigoMedico where a.codigoMedico='{codigoMedico}';";
            v_connection.Open();
            MySqlDataReader v_fetchQuery = v_query.ExecuteReader();
            while (v_fetchQuery.Read())
            {
                Agenda t_Medico = new Agenda();
                t_Medico.codigo = v_fetchQuery["codigo"].ToString();
                t_Medico.datetime = v_fetchQuery["datetime"].ToString();
                t_Medico.nome = v_fetchQuery["nome"].ToString();
                t_Medico.email = v_fetchQuery["email"].ToString();
                t_Medico.telefone = v_fetchQuery["telefone"].ToString();
                t_Medico.codigoMedico = v_fetchQuery["codigoMedico"].ToString();
                t_Medico.nomeMedico = v_fetchQuery["nomeMedico"].ToString();


                v_Agendas.Add(t_Medico);
            }
            v_connection.Close();

            return v_Agendas;
        }

        //TODO
        public List<string> GetHorariosDisponiveis(int codigoMedico, string date)
        //Espero receber a data no seguinte formato '%Y/%m/%d'
        {
            MySqlConnection v_connection = ConnectionDB.connection();
            MySqlCommand v_query = v_connection.CreateCommand();
            v_query.CommandText = $"SELECT date_format(datetime, '%H:%i') `date` from easyhealth.agenda where codigoMedico = '{codigoMedico}' and date_format(datetime, '%Y-%m-%d') = '{date}';";
            v_connection.Open();
            List<String> v_schedules = new List<String>(new String[] { "08:00", "09:00", "10:00", "11:00", "12:00", "14:00", "15:00", "16:00", "17:00"});
            MySqlDataReader v_fetchQuery = v_query.ExecuteReader();
            while (v_fetchQuery.Read())
            {
                String v_horario = v_fetchQuery["date"].ToString();
                if (v_schedules.Contains(v_horario))
                    v_schedules.Remove(v_fetchQuery["date"].ToString());
            }
            v_connection.Close();

            return v_schedules;
        }


        public void AddConsulta(Agenda p_agenda)
        {
            MySqlConnection v_connection = ConnectionDB.connection();
            v_connection.Open();
            MySqlCommand v_query = v_connection.CreateCommand();
            v_query.CommandText = "INSERT INTO easyhealth.agenda (`datetime`,nome,email,telefone,codigoMedico) " +
                $"values ('{p_agenda.datetime}','{p_agenda.nome}','{p_agenda.email}','{p_agenda.telefone}','{p_agenda.codigoMedico}')";
            try
            {
                v_query.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Problem inserting new Consulta into database: " + ex.Message);
            }
            finally
            {
                v_connection.Close();
            }
        }
    }


}