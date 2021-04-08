using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace EasyHealthApi.Models
{
    public class Funcionario
    {
        public string codigo { get; set; }
        public string dataContrato { get; set; }
        public string salario { get; set; }

        //private string _senhaHash;
        //public string senhaHash {
        //    get => _senhaHash;
        //    set {
        //        //do something while value is being set
        //        _senhaHash = value;
        //   }
        //}
    }

    public class FuncionarioManager
    {
        public FuncionarioManager() { }

        public List<Funcionario> GetFuncionarios()
        {
            List<Funcionario> v_funcionarios = new List<Funcionario>();
            MySqlConnection v_connection = ConnectionDB.connection();
            MySqlCommand v_query = v_connection.CreateCommand();
            v_query.CommandText = "SELECT `codigo`,`dataContrato`,`salario` FROM easyhealth.funcionario";
            v_connection.Open();
            MySqlDataReader v_fetchQuery = v_query.ExecuteReader();
            while (v_fetchQuery.Read())
            {
                Funcionario t_funcionario = new Funcionario();
                t_funcionario.codigo = v_fetchQuery["codigo"].ToString();
                t_funcionario.dataContrato = v_fetchQuery["dataContrato"].ToString();
                t_funcionario.salario = v_fetchQuery["salario"].ToString();
                v_funcionarios.Add(t_funcionario);
            }
            v_connection.Close();

            return v_funcionarios;
        }
    }
}
