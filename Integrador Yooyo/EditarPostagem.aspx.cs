using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Integrador_Yooyo
{
    public partial class EditarPostagem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
                DataSet ds2 = GetData2();

               ReEdit.DataSource = ds2;
                ReEdit.DataBind();

            

        }
        private DataSet GetData2()
        {
            string CS = ConfigurationManager.ConnectionStrings["2019YoyooConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlDataAdapter da2 = new SqlDataAdapter("Select * from postagem WHERE postagem_id =  '" + Request.QueryString["postagem_id"] + "'", con);

                DataSet ds2 = new DataSet();
                da2.Fill(ds2);
                return ds2;
            }
        }
        protected void ReEdit_ItemCommand(Object Sender, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Salvar")
            {
                if (((TextBox)e.Item.FindControl("TextBox1")).Text == "" || ((TextBox)e.Item.FindControl("TextBox2")).Text == "" || ((TextBox)e.Item.FindControl("TextBox3")).Text == "") { }
                else
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["2019yoyooconnectionstring"].ConnectionString);
                    con.Open();

                    // abre conexão com o banco de dados

                    // cria comando sql

                    // define comando de exclusão
                    SqlCommand cmd = new SqlCommand("Update postagem set titulo = @titulo,avaliacao_vantagem = @avaliacao_vantagem,avaliacao_desvantagem = @avaliacao_desvantagem where postagem_id = @postagem_id", con);
                    cmd.Parameters.AddWithValue("@postagem_id", ((LinkButton)e.Item.FindControl("Button5")).CommandArgument);
                    cmd.Parameters.AddWithValue("@titulo", ((TextBox)e.Item.FindControl("TextBox1")).Text);
                    cmd.Parameters.AddWithValue("@avaliacao_vantagem", ((TextBox)e.Item.FindControl("TextBox2")).Text);
                    cmd.Parameters.AddWithValue("@avaliacao_desvantagem", ((TextBox)e.Item.FindControl("TextBox3")).Text);
                    // executa comando
                    cmd.ExecuteNonQuery();
                    Response.Redirect("PaginaPerfilPrincipal.aspx");
                }
            }

        }


        




        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["2019YoyooConnectionString"].ConnectionString);

            con.Open();
            string query = "Select COUNT(1) FROM Avaliacao_Postagem WHERE login=@login AND Postagem_id=@Postagemid";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@Postagemid", ((ImageButton)sender).CommandArgument.ToString());
            cmd.Parameters.AddWithValue("@login", Session["login"]);
            int count = Convert.ToInt32(cmd.ExecuteScalar());




            if (count == 0)
            {

                SqlCommand com = con.CreateCommand();
                // Define comando de exclusão
                cmd = new SqlCommand("INSERT INTO Avaliacao_Postagem(nota, login, postagem_id) VALUES(1, @login, @postagemid)", con);
                cmd.Parameters.AddWithValue("@Postagemid", ((ImageButton)sender).CommandArgument.ToString());
                cmd.Parameters.AddWithValue("@login", Session["login"]);
                // Executa Comando
                cmd.ExecuteNonQuery();
                Response.Redirect("PaginaInicialPostagemFiltrada.aspx?postagem_id=" + ((ImageButton)sender).CommandArgument.ToString());
            }
            else
            {

                SqlCommand com = con.CreateCommand();
                // Define comando de exclusão
                cmd = new SqlCommand("UPDATE Avaliacao_Postagem SET nota = 1 WHERE login=@login AND Postagem_id=@Postagemid", con);
                cmd.Parameters.AddWithValue("@Postagemid", ((ImageButton)sender).CommandArgument.ToString());
                cmd.Parameters.AddWithValue("@login", Session["login"]);
                // Executa Comando
                cmd.ExecuteNonQuery();
                Response.Redirect("PaginaInicialPostagemFiltrada.aspx?postagem_id=" + ((ImageButton)sender).CommandArgument.ToString());
            }
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["2019YoyooConnectionString"].ConnectionString);

            con.Open();
            string query = "Select COUNT(1) FROM Avaliacao_Postagem WHERE login=@login AND Postagem_id=@Postagemid";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@Postagemid", ((ImageButton)sender).CommandArgument.ToString());
            cmd.Parameters.AddWithValue("@login", Session["login"]);
            int count = Convert.ToInt32(cmd.ExecuteScalar());




            if (count == 0)
            {

                SqlCommand com = con.CreateCommand();
                // Define comando de exclusão
                cmd = new SqlCommand("INSERT INTO Avaliacao_Postagem(nota, login, postagem_id) VALUES(2, @login, @postagemid)", con);
                cmd.Parameters.AddWithValue("@Postagemid", ((ImageButton)sender).CommandArgument.ToString());
                cmd.Parameters.AddWithValue("@login", Session["login"]);
                // Executa Comando
                cmd.ExecuteNonQuery();
                Response.Redirect("PaginaInicialPostagemFiltrada.aspx?postagem_id=" + ((ImageButton)sender).CommandArgument.ToString());
            }
            else
            {

                SqlCommand com = con.CreateCommand();
                // Define comando de exclusão
                cmd = new SqlCommand("UPDATE Avaliacao_Postagem SET nota = 2 WHERE login=@login AND Postagem_id=@Postagemid", con);
                cmd.Parameters.AddWithValue("@Postagemid", ((ImageButton)sender).CommandArgument.ToString());
                cmd.Parameters.AddWithValue("@login", Session["login"]);
                // Executa Comando
                cmd.ExecuteNonQuery();
                Response.Redirect("PaginaInicialPostagemFiltrada.aspx?postagem_id=" + ((ImageButton)sender).CommandArgument.ToString());
            }
        }



        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["2019YoyooConnectionString"].ConnectionString);

            con.Open();
            string query = "Select COUNT(1) FROM Avaliacao_Postagem WHERE login=@login AND Postagem_id=@Postagemid";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@Postagemid", ((ImageButton)sender).CommandArgument.ToString());
            cmd.Parameters.AddWithValue("@login", Session["login"]);
            int count = Convert.ToInt32(cmd.ExecuteScalar());




            if (count == 0)
            {

                SqlCommand com = con.CreateCommand();
                // Define comando de exclusão
                cmd = new SqlCommand("INSERT INTO Avaliacao_Postagem(nota, login, postagem_id) VALUES(3, @login, @postagemid)", con);
                cmd.Parameters.AddWithValue("@Postagemid", ((ImageButton)sender).CommandArgument.ToString());
                cmd.Parameters.AddWithValue("@login", Session["login"]);
                // Executa Comando
                cmd.ExecuteNonQuery();
                Response.Redirect("PaginaInicialPostagemFiltrada.aspx?postagem_id=" + ((ImageButton)sender).CommandArgument.ToString());
            }
            else
            {

                SqlCommand com = con.CreateCommand();
                // Define comando de exclusão
                cmd = new SqlCommand("UPDATE Avaliacao_Postagem SET nota = 3 WHERE login=@login AND Postagem_id=@Postagemid", con);
                cmd.Parameters.AddWithValue("@Postagemid", ((ImageButton)sender).CommandArgument.ToString());
                cmd.Parameters.AddWithValue("@login", Session["login"]);
                // Executa Comando
                cmd.ExecuteNonQuery();
                Response.Redirect("PaginaInicialPostagemFiltrada.aspx?postagem_id=" + ((ImageButton)sender).CommandArgument.ToString());
            }
        }


        protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["2019YoyooConnectionString"].ConnectionString);

            con.Open();
            string query = "Select COUNT(1) FROM Avaliacao_Postagem WHERE login=@login AND Postagem_id=@Postagemid";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@Postagemid", ((ImageButton)sender).CommandArgument.ToString());
            cmd.Parameters.AddWithValue("@login", Session["login"]);
            int count = Convert.ToInt32(cmd.ExecuteScalar());




            if (count == 0)
            {

                SqlCommand com = con.CreateCommand();
                // Define comando de exclusão
                cmd = new SqlCommand("INSERT INTO Avaliacao_Postagem(nota, login, postagem_id) VALUES(4, @login, @postagemid)", con);
                cmd.Parameters.AddWithValue("@Postagemid", ((ImageButton)sender).CommandArgument.ToString());
                cmd.Parameters.AddWithValue("@login", Session["login"]);
                // Executa Comando
                cmd.ExecuteNonQuery();
                Response.Redirect("PaginaInicialPostagemFiltrada.aspx?postagem_id=" + ((ImageButton)sender).CommandArgument.ToString());
            }
            else
            {

                SqlCommand com = con.CreateCommand();
                // Define comando de exclusão
                cmd = new SqlCommand("UPDATE Avaliacao_Postagem SET nota = 4 WHERE login=@login AND Postagem_id=@Postagemid", con);
                cmd.Parameters.AddWithValue("@Postagemid", ((ImageButton)sender).CommandArgument.ToString());
                cmd.Parameters.AddWithValue("@login", Session["login"]);
                // Executa Comando
                cmd.ExecuteNonQuery();
                Response.Redirect("PaginaInicialPostagemFiltrada.aspx?postagem_id=" + ((ImageButton)sender).CommandArgument.ToString());
            }
        }


        protected void ImageButton5_Click(object sender, ImageClickEventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["2019YoyooConnectionString"].ConnectionString);

            con.Open();
            string query = "Select COUNT(1) FROM Avaliacao_Postagem WHERE login=@login AND Postagem_id=@Postagemid";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@Postagemid", ((ImageButton)sender).CommandArgument.ToString());
            cmd.Parameters.AddWithValue("@login", Session["login"]);
            int count = Convert.ToInt32(cmd.ExecuteScalar());




            if (count == 0)
            {

                SqlCommand com = con.CreateCommand();
                // Define comando de exclusão
                cmd = new SqlCommand("INSERT INTO Avaliacao_Postagem(nota, login, postagem_id) VALUES(5, @login, @postagemid)", con);
                cmd.Parameters.AddWithValue("@Postagemid", ((ImageButton)sender).CommandArgument.ToString());
                cmd.Parameters.AddWithValue("@login", Session["login"]);
                // Executa Comando
                cmd.ExecuteNonQuery();
                Response.Redirect("PaginaInicialPostagemFiltrada.aspx?postagem_id=" + ((ImageButton)sender).CommandArgument.ToString());
            }
            else
            {

                SqlCommand com = con.CreateCommand();
                // Define comando de exclusão
                cmd = new SqlCommand("UPDATE Avaliacao_Postagem SET nota = 5 WHERE login=@login AND Postagem_id=@Postagemid", con);
                cmd.Parameters.AddWithValue("@Postagemid", ((ImageButton)sender).CommandArgument.ToString());
                cmd.Parameters.AddWithValue("@login", Session["login"]);
                // Executa Comando
                cmd.ExecuteNonQuery();
                Response.Redirect("PaginaInicialPostagemFiltrada.aspx?postagem_id=" + ((ImageButton)sender).CommandArgument.ToString());
            }
        }

        

        

    }
}
