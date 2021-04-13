using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace EasyHealthApi.Models
{
    public class Pessoa
    {
        public string codigo { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string telefone { get; set; }
        public string CEP { get; set; }
        public string logradouro { get; set; }
        public string bairro { get; set; }
        public string cidade { get; set; }
        public string estado { get; set; }
    }

    public class PessoaManager
    {
        public PessoaManager() { }

        public List<Pessoa> GetPessoas()
        {
            List<Pessoa> v_pessoas = new List<Pessoa>();
            MySqlConnection v_connection = ConnectionDB.connection();
            MySqlCommand v_query = v_connection.CreateCommand();
            v_query.CommandText = "SELECT * FROM easyhealth.pessoa";
            v_connection.Open();
            MySqlDataReader v_fetchQuery = v_query.ExecuteReader();
            while (v_fetchQuery.Read())
            {
                Pessoa t_pessoa = new Pessoa();
                t_pessoa.codigo = v_fetchQuery["codigo"].ToString();
                t_pessoa.nome = v_fetchQuery["nome"].ToString();
                t_pessoa.email = v_fetchQuery["email"].ToString();
                t_pessoa.telefone = v_fetchQuery["telefone"].ToString();
                t_pessoa.CEP = v_fetchQuery["CEP"].ToString();
                t_pessoa.logradouro = v_fetchQuery["logradouro"].ToString();
                t_pessoa.bairro = v_fetchQuery["bairro"].ToString();
                t_pessoa.cidade = v_fetchQuery["cidade"].ToString();
                t_pessoa.estado = v_fetchQuery["estado"].ToString();


                v_pessoas.Add(t_pessoa);
            }
            v_connection.Close();

            return v_pessoas;
        }

        public void AddPessoa(Pessoa p_pessoa)
        {
            MySqlConnection v_connection = ConnectionDB.connection();
            v_connection.Open();
            MySqlCommand v_query = v_connection.CreateCommand();
            v_query.CommandText = "INSERT INTO easyhealth.pessoa (nome,email,telefone,CEP,logradouro,bairro,cidade,estado) " +
                $"values ('{p_pessoa.nome}','{p_pessoa.email}','{p_pessoa.telefone}','{p_pessoa.CEP}','{p_pessoa.logradouro}','{p_pessoa.bairro}','{p_pessoa.cidade}','{p_pessoa.estado}')";
            try
            {
                v_query.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Problem inserting new Pessoa into database: " + ex.Message);
            }
            finally
            {
                v_connection.Close();
            }
        }

        public string GetPessoaId()
        {
            string v_pId = "";
            MySqlConnection v_connection = ConnectionDB.connection();
            MySqlCommand v_query = v_connection.CreateCommand();
            v_query.CommandText = "SELECT MAX(`codigo`) FROM easyhealth.pessoa";
            v_connection.Open();
            MySqlDataReader v_fetchQuery = v_query.ExecuteReader();
            while (v_fetchQuery.Read())
            {
                v_pId = v_fetchQuery["MAX(`codigo`)"].ToString();
            }
            v_connection.Close();
            return v_pId;
        }
    }
}