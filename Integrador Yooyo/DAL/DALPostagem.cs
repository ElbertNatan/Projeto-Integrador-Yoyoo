using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Integrador_Yooyo.DAL
{
    public class DALPostagem
    {
        string connectionString = "";

        public int forpostagem_id;
        public DALPostagem()
        {
            connectionString = ConfigurationManager.ConnectionStrings
                      ["2019YoyooConnectionString"].ConnectionString;
        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Modelo.ModeloPostagem> Select(string postagem_id)
        {
            // Variavel para armazenar um livro
            Modelo.ModeloPostagem apostagem;
            // Cria Lista Vazia
            List<Modelo.ModeloPostagem> aListPostagem = new List<Modelo.ModeloPostagem>();
            // Cria Conexão com banco de dados
            SqlConnection conn = new SqlConnection(connectionString);
            // Abre conexão com o banco de dados
            conn.Open();
            // Cria comando SQL
            SqlCommand cmd = conn.CreateCommand();
            // define SQL do comando
            cmd.CommandText = "Select * from postagem Where postagem_id = @postagem_id";
            cmd.Parameters.AddWithValue("@postagem_id", postagem_id);
            // Executa comando, gerando objeto DbDataReader
            SqlDataReader dr = cmd.ExecuteReader();
            // Le titulo do livro do resultado e apresenta no segundo rótulo
            if (dr.HasRows)
            {

                while (dr.Read()) // Le o proximo registro
                {
                    // Cria objeto com dados lidos do banco de dados
                    apostagem = new Modelo.ModeloPostagem(
                        dr["postagem_id"].ToString(),
                        dr["titulo"].ToString(),                
                        dr["avaliacao_vantagem"].ToString(),
                        dr["avaliacao_desvantagem"].ToString(),
                        dr["media_geral"].ToString()
                        );
                    // Adiciona o livro lido à lista
                    aListPostagem.Add(apostagem);
                }
            }
            // Fecha DataReader
            dr.Close();
            // Fecha Conexão
            conn.Close();

            return aListPostagem;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Modelo.ModeloPostagem> SelectAll()
        {
            // Variavel para armazenar um livro
            Modelo.ModeloPostagem aPostagem;
            // Cria Lista Vazia
            List<Modelo.ModeloPostagem> aListPostagem = new List<Modelo.ModeloPostagem>();
            // Cria Conexão com banco de dados
            SqlConnection conn = new SqlConnection(connectionString);
            // Abre conexão com o banco de dados
            conn.Open();
            // Cria comando SQL
            SqlCommand cmd = conn.CreateCommand();
            // define SQL do comando
            cmd.CommandText = "Select * from Postagem";
            // Executa comando, gerando objeto DbDataReader
            SqlDataReader dr = cmd.ExecuteReader();
            // Le titulo do livro do resultado e apresenta no segundo rótulo
            if (dr.HasRows)
            {
                while (dr.Read()) // Le o proximo registro
                {
                    // Cria objeto com dados lidos do banco de dados
                    aPostagem = new Modelo.ModeloPostagem(
                        dr["postagem_id"].ToString(),
                        dr["titulo"].ToString(),
                        dr["avaliacao_vantagem"].ToString(),
                        dr["avaliacao_desvantagem"].ToString(),
                        dr["media_geral"].ToString()
                        );
                    // Adiciona o livro lido à lista
                    aListPostagem.Add(aPostagem);
                }
            }
            // Fecha DataReader
            dr.Close();
            // Fecha Conexão
            conn.Close();
            return aListPostagem;
        }

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public void Delete(Modelo.ModeloPostagem obj)
        {
            // Cria Conexão com banco de dados
            SqlConnection conn = new SqlConnection(connectionString);
            // Abre conexão com o banco de dados
            conn.Open();
            // Cria comando SQL
            SqlCommand com = conn.CreateCommand();
            // Define comando de exclusão
            SqlCommand cmd = new SqlCommand("DELETE FROM postagem WHERE postagem_id = @postagem_id", conn);
            cmd.Parameters.AddWithValue("@postagem_id", obj.postagem_id);

            // Executa Comando
            cmd.ExecuteNonQuery();

        }


        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void Insert(Modelo.ModeloCriarPostagem obj)
        {
            // Cria Conexão com banco de dados
            SqlConnection conn = new SqlConnection(connectionString);
            // Abre conexão com o banco de dados
            conn.Open();
            // Cria comando SQL
            SqlCommand com = conn.CreateCommand();
            // Define comando de exclusão
            SqlCommand cmd = new SqlCommand("INSERT INTO Postagem (titulo, categoria, data_hora, avaliacao_vantagem, avaliacao_desvantagem, media_geral, login) VALUES(@titulo, @categoria, @data_hora, @avaliacao_vantagem, @avaliacao_desvantagem, 0, @login)", conn);
            cmd.Parameters.AddWithValue("@titulo", obj.titulo);
            cmd.Parameters.AddWithValue("@categoria", obj.categoria);
            cmd.Parameters.AddWithValue("@data_hora", obj.data_hora);
            cmd.Parameters.AddWithValue("@avaliacao_vantagem", obj.avaliacao_vantagem);
            cmd.Parameters.AddWithValue("@avaliacao_desvantagem", obj.avaliacao_desvantagem);
            cmd.Parameters.AddWithValue("@login", obj.login);
            // Executa Comando
            cmd.ExecuteNonQuery();

            // Cria comando SQL
            
            SqlCommand com2 = conn.CreateCommand();
            // Define comando de exclusão
            SqlCommand cmd2 = new SqlCommand("select @@identity as idNew", conn);
            
            forpostagem_id = Convert.ToInt32(cmd2.ExecuteScalar());
            com = conn.CreateCommand();
            // Define comando de exclusão
            cmd = new SqlCommand("INSERT INTO notificacao (descricao, login, postagem_id, categoria) VALUES('Fez uma nova postagem sobre ' + @categoria, @login, @postagem_id, @categoria)", conn);     
            cmd.Parameters.AddWithValue("@login", obj.login);
            cmd.Parameters.AddWithValue("@postagem_id", forpostagem_id);
            cmd.Parameters.AddWithValue("@categoria", obj.categoria);
            // Executa Comando
            cmd.ExecuteNonQuery();
            // Executa comando, gerando objeto DbDataReader
            /* SqlDataReader dr = cmd.ExecuteReader();
             string strid = "0";
             // Le titulo do livro do resultado e apresenta no segundo rótulo
             if (dr.HasRows)
             {
                 if (dr.Read()) // Le o proximo registro
                 {
                     strid = dr["idNew"].ToString();
                 }
             }

             obj.postagem_id = Convert.ToInt32(strid); // corrigir o id*/


        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public void Update(Modelo.ModeloPostagem obj)
        {
            // Cria Conexão com banco de dados
            SqlConnection conn = new SqlConnection(connectionString);
            // Abre conexão com o banco de dados
            conn.Open();
            // Cria comando SQL
            SqlCommand com = conn.CreateCommand();
            // Define comando de exclusão
            SqlCommand cmd = new SqlCommand("UPDATE Postagem SET titulo = @titulo,avaliacao_vantagem = @avaliacao_vantagem,avaliacao_desvantagem = @avaliacao_desvantagem WHERE postagem_id = @postagem_id", conn);
            cmd.Parameters.AddWithValue("@postagem_id", obj.postagem_id);
            cmd.Parameters.AddWithValue("@titulo", obj.titulo);
            cmd.Parameters.AddWithValue("@avaliacao_vantagem", obj.avaliacao_vantagem);
            cmd.Parameters.AddWithValue("@avaliacao_desvantagem", obj.avaliacao_desvantagem);
            // Executa Comando
            cmd.ExecuteNonQuery();
        }


    }

}