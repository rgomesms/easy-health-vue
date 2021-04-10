using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace EasyHealthApi.Models
{
    public class Paciente
    {
        public string codigo { get; set; }
        
        public string nome { get; set; }
        public string tipoSanguineo { get; set; }
        public string peso { get; set; }
        public string altura { get; set; }
    }

    public class PacienteManager
    {
        public PacienteManager() { }

        public List<Paciente> GetPacientes()
        {
            List<Paciente> v_pacientes = new List<Paciente>();
            MySqlConnection v_connection = ConnectionDB.connection();
            MySqlCommand v_query = v_connection.CreateCommand();
            //v_query.CommandText = "SELECT * FROM easyhealth.paciente";
            v_query.CommandText = "SELECT m.codigo,p.nome, m.tipoSanguineo, m.peso, m.altura FROM easyhealth.paciente m inner join easyhealth.pessoa p on P.codigo=M.codigo";
            v_connection.Open();
            MySqlDataReader v_fetchQuery = v_query.ExecuteReader();
            while (v_fetchQuery.Read())
            {
                Paciente t_paciente = new Paciente();
                t_paciente.codigo = v_fetchQuery["codigo"].ToString();
                t_paciente.nome = v_fetchQuery["nome"].ToString();
                t_paciente.tipoSanguineo = v_fetchQuery["tipoSanguineo"].ToString();
                t_paciente.peso = v_fetchQuery["peso"].ToString();
                t_paciente.altura = v_fetchQuery["altura"].ToString();
                v_pacientes.Add(t_paciente);
            }
            v_connection.Close();

            return v_pacientes;
        }
    }
}
