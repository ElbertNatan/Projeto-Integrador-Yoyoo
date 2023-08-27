using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using Integrador_Yooyo.Modelo;
using System.ComponentModel;
using System.Web.UI.WebControls;

namespace Integrador_Yooyo.DAL
{
    public class DALCategoria
    {
        string connectionString = "";


        public DALCategoria()
        {
            connectionString = ConfigurationManager.ConnectionStrings
                      ["2019YoyooConnectionString"].ConnectionString;
        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Modelo.ModeloCategoria> Select(string categoria_id)
        {
            // Variavel para armazenar um livro
            Modelo.ModeloCategoria aCategoria;
            // Cria Lista Vazia
            List<Modelo.ModeloCategoria> aListCategoria = new List<Modelo.ModeloCategoria>();
            // Cria Conexão com banco de dados
            SqlConnection conn = new SqlConnection(connectionString);
            // Abre conexão com o banco de dados
            conn.Open();
            // Cria comando SQL
            SqlCommand cmd = conn.CreateCommand();
            // define SQL do comando
            cmd.CommandText = "Select * from categoria Where categoria_id = @categoria_id";
            cmd.Parameters.AddWithValue("@categoria_id", categoria_id);
            // Executa comando, gerando objeto DbDataReader
            SqlDataReader dr = cmd.ExecuteReader();
            // Le titulo do livro do resultado e apresenta no segundo rótulo
            if (dr.HasRows)
            {

                while (dr.Read()) // Le o proximo registro
                {
                    // Cria objeto com dados lidos do banco de dados
                    aCategoria = new Modelo.ModeloCategoria(
                        dr["categoria_id"].ToString(),
                        dr["descricao"].ToString()           
                        );
                    // Adiciona o livro lido à lista
                    aListCategoria.Add(aCategoria);
                }
            }
            // Fecha DataReader
            dr.Close();
            // Fecha Conexão
            conn.Close();

            return aListCategoria;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Modelo.ModeloCategoria> SelectAll()
        {
            // Variavel para armazenar um livro
            Modelo.ModeloCategoria aCategoria;
            // Cria Lista Vazia
            List<Modelo.ModeloCategoria> aListCategoria = new List<Modelo.ModeloCategoria>();
            // Cria Conexão com banco de dados
            SqlConnection conn = new SqlConnection(connectionString);
            // Abre conexão com o banco de dados
            conn.Open();
            // Cria comando SQL
            SqlCommand cmd = conn.CreateCommand();
            // define SQL do comando
            cmd.CommandText = "Select * from Categoria";
            // Executa comando, gerando objeto DbDataReader
            SqlDataReader dr = cmd.ExecuteReader();
            // Le titulo do livro do resultado e apresenta no segundo rótulo
            if (dr.HasRows)
            {
                while (dr.Read()) // Le o proximo registro
                {
                    // Cria objeto com dados lidos do banco de dados
                    aCategoria = new Modelo.ModeloCategoria(
                        dr["categoria_id"].ToString(),
                        dr["descricao"].ToString()
                        ) ;
                    // Adiciona o livro lido à lista
                    aListCategoria.Add(aCategoria);
                }
            }
            // Fecha DataReader
            dr.Close();
            // Fecha Conexão
            conn.Close();
            return aListCategoria;
        }

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public void Delete(Modelo.ModeloCategoria obj)
        {
            // Cria Conexão com banco de dados
            SqlConnection conn = new SqlConnection(connectionString);
            // Abre conexão com o banco de dados
            conn.Open();
            // Cria comando SQL
            SqlCommand com = conn.CreateCommand();
            // Define comando de exclusão
            SqlCommand cmd = new SqlCommand("DELETE FROM categoria WHERE categoria_id = @categoria_id", conn);
            cmd.Parameters.AddWithValue("@categoria_id", obj.categoria_id);

            // Executa Comando
            cmd.ExecuteNonQuery();

        }


        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void Insert(Modelo.ModeloCriarCategoria obj)
        {
            // Cria Conexão com banco de dados
            SqlConnection conn = new SqlConnection(connectionString);
            // Abre conexão com o banco de dados
            conn.Open();
            // Cria comando SQL
            SqlCommand com = conn.CreateCommand();
            // Define comando de exclusão
            SqlCommand cmd = new SqlCommand("INSERT INTO categoria (descricao, sub_categoria) VALUES(@descricao, @sub_categoria)", conn);
            cmd.Parameters.AddWithValue("@descricao", obj.descricao);
            cmd.Parameters.AddWithValue("@sub_categoria", obj.sub_categoria);
            // Executa Comando
            cmd.ExecuteNonQuery();

        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public void Update(Modelo.ModeloCategoria obj)
        {
            // Cria Conexão com banco de dados
            SqlConnection conn = new SqlConnection(connectionString);
            // Abre conexão com o banco de dados
            conn.Open();
            // Cria comando SQL
            SqlCommand com = conn.CreateCommand();
            // Define comando de exclusão
            SqlCommand cmd = new SqlCommand("UPDATE categoria SET descricao = @descricao WHERE categoria_id = @categoria_id", conn);
            cmd.Parameters.AddWithValue("@categoria_id", obj.categoria_id);
            cmd.Parameters.AddWithValue("@descricao", obj.descricao);

            // Executa Comando
            cmd.ExecuteNonQuery();
        }


    }

}