using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace EasyHealthApi.Models
{
    public class Medico
    {
        public string codigo { get; set; }
        public string nome { get; set; }

        public string especialidade { get; set; }
        public string CRM { get; set; }
    }



    public class MedicoManager
    {
        public MedicoManager() { }

        public List<Medico> GetMedicos()
        {
            List<Medico> v_Medicos = new List<Medico>();
            MySqlConnection v_connection = ConnectionDB.connection();
            MySqlCommand v_query = v_connection.CreateCommand();
            //v_query.CommandText = "SELECT * FROM easyhealth.Medico";
            v_query.CommandText = "SELECT m.codigo,p.nome,m.especialidade,m.crm FROM easyhealth.Medico m inner join easyhealth.pessoa p on p.codigo=m.codigo";

            v_connection.Open();
            MySqlDataReader v_fetchQuery = v_query.ExecuteReader();
            while (v_fetchQuery.Read())
            {
                Medico t_Medico = new Medico();
                t_Medico.codigo = v_fetchQuery["codigo"].ToString(); 
                t_Medico.nome= v_fetchQuery["nome"].ToString();
                t_Medico.especialidade = v_fetchQuery["especialidade"].ToString();
                t_Medico.CRM = v_fetchQuery["CRM"].ToString();


                v_Medicos.Add(t_Medico);
            }
            v_connection.Close();

            return v_Medicos;
        }

        public List<String> GetEspecialidades()
        {
            List<String> v_especialidades = new List<String>();
            MySqlConnection v_connection = ConnectionDB.connection();
            MySqlCommand v_query = v_connection.CreateCommand();
            v_query.CommandText = "SELECT distinct especialidade FROM easyhealth.Medico";
            v_connection.Open();
            MySqlDataReader v_fetchQuery = v_query.ExecuteReader();
            while (v_fetchQuery.Read())
            {
                v_especialidades.Add(v_fetchQuery["especialidade"].ToString());
            }
            v_connection.Close();

            return v_especialidades;
        }
        public List<Medico> GetMedicosPorEspecialidade(String especialidade)
        {
            List<Medico> v_medicos = new List<Medico>();
            MySqlConnection v_connection = ConnectionDB.connection();
            MySqlCommand v_query = v_connection.CreateCommand();
            v_query.CommandText = "select p.nome,p.codigo from easyhealth.Medico m inner join easyhealth.Pessoa p on P.codigo=M.codigo where m.especialidade='" + especialidade + "'";
                //='Urologista'";
            v_connection.Open();
            MySqlDataReader v_fetchQuery = v_query.ExecuteReader();
            while (v_fetchQuery.Read())
            {
                Medico t_Medico = new Medico();
                t_Medico.codigo = v_fetchQuery["codigo"].ToString();
                t_Medico.nome = v_fetchQuery["nome"].ToString();
                //v_medicos.Add(v_fetchQuery["nome"].ToString());
                //v_medicos.Add(v_fetchQuery["codigo"].ToString());
                v_medicos.Add(t_Medico);
            }

            v_connection.Close();

            return v_medicos;
        }

        public void AddMedico(Medico p_medico)
        {
            MySqlConnection v_connection = ConnectionDB.connection();
            v_connection.Open();
            MySqlCommand v_query = v_connection.CreateCommand();
            v_query.CommandText = "INSERT INTO easyhealth.medico (codigo,especialidade,crm) " +
                $"values ('{p_medico.codigo}','{p_medico.especialidade}','{p_medico.CRM}')";
            try
            {
                v_query.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Problem inserting new Medico into database: " + ex.Message);
            }
            finally
            {
                v_connection.Close();
            }
        }

    }

}
