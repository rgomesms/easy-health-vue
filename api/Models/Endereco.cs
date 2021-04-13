using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace EasyHealthApi.Models
{
    public class Endereco
    {
        public string CEP { get; set; }
        public string logradouro { get; set; }
        public string bairro { get; set; }
        public string cidade { get; set; }
        public string estado { get; set; }
    }

    public class EnderecoManager
    {
        public EnderecoManager() { }

        public List<Endereco> GetEnderecos()
        {
            List<Endereco> v_enderecos = new List<Endereco>();
            MySqlConnection v_connection = ConnectionDB.connection();
            MySqlCommand v_query = v_connection.CreateCommand();
            v_query.CommandText = "SELECT * FROM easyhealth.enderecos";
            v_connection.Open();
            MySqlDataReader v_fetchQuery = v_query.ExecuteReader();
            while (v_fetchQuery.Read())
            {
                Endereco t_endereco = new Endereco();
                t_endereco.CEP = v_fetchQuery["CEP"].ToString();
                t_endereco.logradouro = v_fetchQuery["logradouro"].ToString();
                t_endereco.bairro = v_fetchQuery["bairro"].ToString();
                t_endereco.cidade = v_fetchQuery["cidade"].ToString();
                t_endereco.estado = v_fetchQuery["estado"].ToString();
                v_enderecos.Add(t_endereco);
            }
            v_connection.Close();

            return v_enderecos;
        }

        public List<Endereco> GetEnderecosPorCep(string cep)
        {
            List<Endereco> v_enderecos = new List<Endereco>();
            MySqlConnection v_connection = ConnectionDB.connection();
            MySqlCommand v_query = v_connection.CreateCommand();
            v_query.CommandText = "SELECT * FROM easyhealth.enderecos where cep="+cep;
            v_connection.Open();
            MySqlDataReader v_fetchQuery = v_query.ExecuteReader();
            while (v_fetchQuery.Read())
            {
                Endereco t_endereco = new Endereco();
                t_endereco.CEP = v_fetchQuery["CEP"].ToString();
                t_endereco.logradouro = v_fetchQuery["logradouro"].ToString();
                t_endereco.bairro = v_fetchQuery["bairro"].ToString();
                t_endereco.cidade = v_fetchQuery["cidade"].ToString();
                t_endereco.estado = v_fetchQuery["estado"].ToString();
                v_enderecos.Add(t_endereco);
            }
            v_connection.Close();

            return v_enderecos;
        }

        public void AddEndereco(Endereco endereco)
        {
            MySqlConnection v_connection = ConnectionDB.connection();
            v_connection.Open();
            MySqlCommand v_query = v_connection.CreateCommand();

            v_query.CommandText = "INSERT INTO easyhealth.enderecos (cep,logradouro,bairro,cidade,estado) " +
                $"values ('{endereco.CEP}','{endereco.logradouro}','{endereco.bairro}','{endereco.cidade}','{endereco.estado}')";

            try
            {
                v_query.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Problem inserting new Endereco into database: " + ex.Message);
            }
            finally
            {
                v_connection.Close();
            }
        }

    }
}
