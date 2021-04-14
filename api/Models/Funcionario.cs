using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;

namespace EasyHealthApi.Models
{
    public class Funcionario
    {
        public string codigo { get; set; }
        public string nome { get; set; }
        public string dataContrato { get; set; }
        public string salario { get; set; }
        public string senha { get; set; }
    }

    public class FuncionarioManager
    {
        public FuncionarioManager() { }

        public string GetHash(string input)
        {
            return string.Join("", (new SHA1Managed().ComputeHash(Encoding.UTF8.GetBytes(input))).Select(x => x.ToString("X2")).ToArray());
        }

        public Object Login(string p_senha, string p_email)
        {
            bool v_loginCorreto = false;
            string v_tipoUsuario = "funcionario";
            string v_mensagem = "";
            string v_codigo = "";

            MySqlConnection v_connection = ConnectionDB.connection();
            MySqlCommand v_query = v_connection.CreateCommand();
            v_query.CommandText = $"SELECT f.senhaHash pwd, p.codigo code FROM easyhealth.funcionario f inner join easyhealth.pessoa p on p.codigo=f.codigo where p.email='{p_email}'";
            v_connection.Open();
            MySqlDataReader v_fetchQuery = v_query.ExecuteReader();
            if (v_fetchQuery.HasRows)
            {
                while (v_fetchQuery.Read())
                {
                    if (v_fetchQuery["pwd"].ToString().Equals(p_senha))
                    {
                        v_codigo = v_fetchQuery["code"].ToString();
                        v_loginCorreto = true;
                        v_mensagem = "Login bem sucedido.";
                    }
                    else
                    {
                        v_mensagem = "Email e/ou senha inválidos.";
                    }
                }
            }
            else {
                v_mensagem = "Email e/ou senha inválidos.";
            }
            v_fetchQuery.Close();
            if (v_loginCorreto)
            {
                v_query.CommandText = $"SELECT * FROM easyhealth.medico where codigo='{v_codigo}'";
                v_fetchQuery = v_query.ExecuteReader();
                if (v_fetchQuery.HasRows)
                {
                    v_tipoUsuario = "medico";
                }
                v_fetchQuery.Close();
            }
            v_connection.Close();

            var v_response = new { loginCorreto = v_loginCorreto, tipoUsuario = v_tipoUsuario, mensagem = v_mensagem, codigo = v_codigo };
            return v_response;
        }

        public List<Funcionario> GetFuncionarios()
        {
            List<Funcionario> v_funcionarios = new List<Funcionario>();
            MySqlConnection v_connection = ConnectionDB.connection();
            MySqlCommand v_query = v_connection.CreateCommand();
            v_query.CommandText = "SELECT f.codigo,p.nome, f.dataContrato,f.salario FROM easyhealth.funcionario f inner join easyhealth.pessoa p on p.codigo=f.codigo";
            v_connection.Open();
            MySqlDataReader v_fetchQuery = v_query.ExecuteReader();
            while (v_fetchQuery.Read())
            {
                Funcionario t_funcionario = new Funcionario();
                t_funcionario.codigo = v_fetchQuery["codigo"].ToString();
                t_funcionario.nome = v_fetchQuery["nome"].ToString();
                t_funcionario.dataContrato = v_fetchQuery["dataContrato"].ToString();
                t_funcionario.salario = v_fetchQuery["salario"].ToString();
                v_funcionarios.Add(t_funcionario);
            }
            v_connection.Close();

            return v_funcionarios;
        }

        public void AddFuncionario(Funcionario p_funcionario)
        {
            MySqlConnection v_connection = ConnectionDB.connection();
            v_connection.Open();
            MySqlCommand v_query = v_connection.CreateCommand();
            v_query.CommandText = "INSERT INTO easyhealth.funcionario (codigo,dataContrato,salario,senhaHash) " +
                $"values ('{p_funcionario.codigo}','{p_funcionario.dataContrato}','{p_funcionario.salario}','{p_funcionario.senha}')";
            try
            {
                v_query.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Problem inserting new Funcionario into database: " + ex.Message);
            }
            finally
            {
                v_connection.Close();
            }
        }
    }
}
