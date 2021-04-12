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
        //TODO
        //public List<string> GetHorariosDisponiveis(int codigoMedico, string date)
        ////Espero receber a data no seguinte formato '%Y/%m/%d'
        //{
        //    List<string> v_Agendas = new List<string>();
        //    MySqlConnection v_connection = ConnectionDB.connection();
        //    MySqlCommand v_query = v_connection.CreateCommand();
        //    //Tem de fazer essa query
        //    v_query.CommandText = $"SELECT date_format(datetime, '%H:%i') `date` from easyhealth.agenda where codigoMedico = '{codigoMedico}' and date_format(datetime, '%Y/%m/%d') = '{date}';";
        //    v_connection.Open();
        //    MySqlDataReader v_fetchQuery = v_query.ExecuteReader();
        //    while (v_fetchQuery.Read())
        //    {

        //        //Agenda t_Medico = new Agenda();
        //        //t_Medico.codigo = v_fetchQuery["codigo"].ToString();
        //        //t_Medico.datetime = v_fetchQuery["datetime"].ToString();
        //        //t_Medico.nome = v_fetchQuery["nome"].ToString();
        //        //t_Medico.email = v_fetchQuery["email"].ToString();
        //        //t_Medico.telefone = v_fetchQuery["telefone"].ToString();
        //        //t_Medico.codigoMedico = v_fetchQuery["codigoMedico"].ToString();
        //        //t_Medico.nomeMedico = v_fetchQuery["nomeMedico"].ToString();


        //        v_Agendas.Add( v_fetchQuery["date"].ToString()) ;
        //    }
        //    v_connection.Close();

        //    return v_Agendas;
        //}
    }


}