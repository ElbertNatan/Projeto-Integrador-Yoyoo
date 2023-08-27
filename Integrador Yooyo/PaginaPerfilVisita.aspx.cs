using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Integrador_Yooyo
{
    public partial class PaginaPerfilVisita : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {





            //PEGA IMAGE
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["2019YoyooConnectionString"].ConnectionString);
            con.Open();
            string command = "SELECT (pos.perfil_foto) FROM usuario as pos WHERE login = @login";
            SqlCommand cmd = new SqlCommand(command, con);
            cmd.Parameters.AddWithValue("@login", Request.QueryString["user"]);
            string imageperfil = Convert.ToString(cmd.ExecuteScalar());
            image_perfil.Src = "ImagemPerfilusers/" + imageperfil + ".png";
            //PEGA LOGIN
            labelLogin.Text = Request.QueryString["user"];
            //PEGA NOME
            command = "SELECT (pos.perfil_nome) FROM usuario as pos WHERE login = @login";
            cmd = new SqlCommand(command, con);
            cmd.Parameters.AddWithValue("@login", Request.QueryString["user"]);
            string nomeperfil = Convert.ToString(cmd.ExecuteScalar());
            labelNome.Text = nomeperfil;

            command = "select count(seguido) from UsuarioSeguir where login = @login and seguido=@seguido";
            cmd = new SqlCommand(command, con);
            cmd.Parameters.AddWithValue("@login", Session["login"]);
            cmd.Parameters.AddWithValue("@seguido", Request.QueryString["user"]);
            string countseguido = Convert.ToString(cmd.ExecuteScalar());
            if (Convert.ToInt32(countseguido) == 1)
            {
                string className = "btn btn-danger btn-sm";
                btnSeguir.Attributes["class"] = className;
                btnSeguir.Text = "Deixar de Seguir";

            }
            else
            {
                string className = "btn btn-success btn-sm";
                btnSeguir.Attributes["class"] = className;
                btnSeguir.Text = "Seguir";
            }
        }
        protected void Repeater1_ItemCommand(Object Sender, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Comentar")
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["2019YoyooConnectionString"].ConnectionString);
                con.Open();


                // Define comando de isnert
                SqlCommand cmd = new SqlCommand("INSERT INTO comentario (postagem_id, descricao, data_hora, login) VALUES(@postagem_id, @descricao, (select CURRENT_TIMESTAMP), @login)", con);
                cmd.Parameters.AddWithValue("@postagem_id", ((HiddenField)e.Item.FindControl("HfieldID")).Value);
                cmd.Parameters.AddWithValue("@descricao", ((TextBox)e.Item.FindControl("comentarTXT")).Text);
                cmd.Parameters.AddWithValue("@login", Session["login"]);

                // Executa Comando
                cmd.ExecuteNonQuery();
                Response.Redirect("PaginaInicialPostagemFiltrada.aspx?postagem_id=" + ((HiddenField)e.Item.FindControl("HfieldID")).Value);
            }
        }

       
        

        protected void btnRecado_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["2019YoyooConnectionString"].ConnectionString);
            con.Open();
            string command = "SELECT (pos.perfil_recado) FROM usuario as pos WHERE login = @login";
            SqlCommand cmd = new SqlCommand(command, con);
            cmd.Parameters.AddWithValue("@login", Request.QueryString["user"]);
            string perfilRecado = Convert.ToString(cmd.ExecuteScalar());
            labelTexto.Text = perfilRecado;
        }

        protected void btnEmail_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["2019YoyooConnectionString"].ConnectionString);
            con.Open();
            string command = "SELECT (pos.perfil_email) FROM usuario as pos WHERE login = @login";
            SqlCommand cmd = new SqlCommand(command, con);
            cmd.Parameters.AddWithValue("@login", Request.QueryString["user"]);
            string perfilemail = Convert.ToString(cmd.ExecuteScalar());
            labelTexto.Text = perfilemail;

        }

        protected void btnSeguir_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["2019YoyooConnectionString"].ConnectionString);
            if (btnSeguir.Text == "Seguir")
            {
                con.Open();
                string command = "INSERT INTO UsuarioSeguir (login, seguido) VALUES(@login, @seguido)";
                SqlCommand cmd = new SqlCommand(command, con);

                cmd.Parameters.AddWithValue("@login", Session["login"]);
                cmd.Parameters.AddWithValue("@seguido", labelLogin.Text);

                cmd.ExecuteNonQuery();
                string className = "btn btn-danger btn-sm";
                btnSeguir.Attributes["class"] = className;
                btnSeguir.Text = "Deixar de Seguir";

            }
            else
            {
                con.Open();
                string command = "DELETE FROM UsuarioSeguir WHERE login = @login AND seguido = @seguido";
                SqlCommand cmd = new SqlCommand(command, con);

                cmd.Parameters.AddWithValue("@login", Session["login"]);
                cmd.Parameters.AddWithValue("@seguido", labelLogin.Text);

                cmd.ExecuteNonQuery();
                string className = "btn btn-success btn-sm";
                btnSeguir.Attributes["class"] = className;
                btnSeguir.Text = "Seguir";
            }
        }
        protected void denuncia_click(object sender, EventArgs e)
        {
            string[] arg = new string[2];
            arg = ((Button)sender).CommandArgument.ToString().Split(';');
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["2019YoyooConnectionString"].ConnectionString);
            con.Open();
            SqlCommand com = con.CreateCommand();
            // Define comando de exclusão
            SqlCommand cmd = new SqlCommand("INSERT INTO denuncia_postagem (motivo_denuncia, login, postagem_id, postagem_dono, status) VALUES('Postagem Viola Termos de uso do site', @login, @postagem_id, @postagem_dono, 'pendente')", con);
            cmd.Parameters.AddWithValue("@login", Session["login"]);
            cmd.Parameters.AddWithValue("@postagem_id", arg[0]);
            cmd.Parameters.AddWithValue("@postagem_dono", arg[1]);
            // Executa Comando
            cmd.ExecuteNonQuery();
            Response.Redirect("PaginaInicialPostagem.aspx");

        }

        public string getimage(object postagem_id, object imagedata)
        {

            // Cria objeto com dados lidos do banco de dados

            byte[] imagedata2 = (byte[])imagedata;
            string strbase64 = Convert.ToBase64String(imagedata2);

            string URL = "data:Image/png;base64," + strbase64;

            return URL;
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
                Response.Redirect("PaginaPerfilVisita.aspx?user=" + Request.QueryString["user"]);
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
                Response.Redirect("PaginaPerfilVisita.aspx?user=" + Request.QueryString["user"]);
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
                Response.Redirect("PaginaPerfilVisita.aspx?user=" + Request.QueryString["user"]);
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
                Response.Redirect("PaginaPerfilVisita.aspx?user=" + Request.QueryString["user"]);
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
                Response.Redirect("PaginaPerfilVisita.aspx?user=" + Request.QueryString["user"]);
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
                Response.Redirect("PaginaPerfilVisita.aspx?user=" + Request.QueryString["user"]);
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
                Response.Redirect("PaginaPerfilVisita.aspx?user=" + Request.QueryString["user"]);
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
                Response.Redirect("PaginaPerfilVisita.aspx?user=" + Request.QueryString["user"]);
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
                Response.Redirect("PaginaPerfilVisita.aspx?user=" + Request.QueryString["user"]);
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
                Response.Redirect("PaginaPerfilVisita.aspx?user=" + Request.QueryString["user"]);
            }
        }

        protected void btndenunciaUser_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["2019YoyooConnectionString"].ConnectionString);
            con.Open();
            SqlCommand com = con.CreateCommand();
            // Define comando de exclusão
            SqlCommand cmd = new SqlCommand("INSERT INTO denuncia_usuario (motivo_denuncia, status, login, denunciado) VALUES('Perfil Viola Termos de uso do site', 'pendente', @login, @denunciado )", con);
            cmd.Parameters.AddWithValue("@login", Session["login"]);
            cmd.Parameters.AddWithValue("@denunciado", Request.QueryString["user"]);

            // Executa Comando
            cmd.ExecuteNonQuery();
            Response.Redirect("PaginaPerfilVisita.aspx?user=" + Request.QueryString["user"]);
        }
        protected void Button1_Click(object sender, EventArgs e)
        {

            string arg = ((LinkButton)sender).CommandArgument.ToString();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["2019YoyooConnectionString"].ConnectionString);
            con.Open();
            SqlCommand com = con.CreateCommand();
            // Define comando de exclusão
            SqlCommand cmd = new SqlCommand("DELETE FROM comentario where comentario_id = @comentario_id", con);

            cmd.Parameters.AddWithValue("@comentario_id", arg);

            // Executa Comando
            cmd.ExecuteNonQuery();
            Response.Redirect("PaginaPerfilVisita.aspx?user=" + Request.QueryString["user"]);
        }
    }
}