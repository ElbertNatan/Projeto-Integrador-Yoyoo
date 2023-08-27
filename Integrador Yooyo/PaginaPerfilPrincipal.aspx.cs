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
    public partial class PaginaPerfilPrincipal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //PEGA IMAGE
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["2019YoyooConnectionString"].ConnectionString);
            con.Open();
            string command = "SELECT (pos.perfil_foto) FROM usuario as pos WHERE login = @login";
            SqlCommand cmd = new SqlCommand(command, con);
            cmd.Parameters.AddWithValue("@login", Session["login"]);
            cmd.ExecuteNonQuery();
            string imageperfil = Convert.ToString(cmd.ExecuteScalar());
            image_perfil.Src = "ImagemPerfilusers/" + imageperfil + ".png";
            //PEGA LOGIN
            labelLogin.Text = Session["login"].ToString();
            //PEGA NOME
            command = "SELECT (pos.perfil_nome) FROM usuario as pos WHERE login = @login";
            cmd = new SqlCommand(command, con);
            cmd.Parameters.AddWithValue("@login", Session["login"]);
            cmd.ExecuteNonQuery();
            string nomeperfil = Convert.ToString(cmd.ExecuteScalar());
            labelNome.Text = nomeperfil;
           
           
            command = "SELECT (pos.perfil_recado) FROM usuario as pos WHERE login = @login";
            cmd = new SqlCommand(command, con);
            cmd.Parameters.AddWithValue("@login", Session["login"]);
            cmd.ExecuteNonQuery();
            string recadoperfil = Convert.ToString(cmd.ExecuteScalar());


            command = "SELECT (pos.perfil_email) FROM usuario as pos WHERE login = @login";
            cmd = new SqlCommand(command, con);
            cmd.Parameters.AddWithValue("@login", Session["login"]);
            cmd.ExecuteNonQuery();
            string perfilemail = Convert.ToString(cmd.ExecuteScalar());
  

        }
        protected void EditarPosta_ItemCommand(Object Sender, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {
                Response.Redirect("EditarPostagem.aspx?postagem_id=" + ((Button)e.Item.FindControl("Button2")).CommandArgument.ToString());
            }
            if (e.CommandName == "Salvar")
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["2019yoyooconnectionstring"].ConnectionString);
                con.Open();

                // abre conexão com o banco de dados

                // cria comando sql

                // define comando de exclusão
                SqlCommand cmd = new SqlCommand("Update postagem set titulo = @titulo,avaliacao_vantagem = @avaliacao_vantagem,avaliacao_desvantagem = @avaliacao_desvantagem where postagem_id = @postagem_id", con);
                cmd.Parameters.AddWithValue("@postagem_id", ((HiddenField)e.Item.FindControl("HfieldID")).Value);
                cmd.Parameters.AddWithValue("@titulo", ((TextBox)e.Item.FindControl("TextBox4")).Text);
                cmd.Parameters.AddWithValue("@avaliacao_vantagem", ((TextBox)e.Item.FindControl("TextBox5")).Text);
                cmd.Parameters.AddWithValue("@avaliacao_desvantagem", ((TextBox)e.Item.FindControl("TextBox6")).Text);
                // executa comando
                cmd.ExecuteNonQuery();
                Response.Redirect("PaginaPerfilPrincipal.aspx");


            }
            if(e.CommandName == "Excluir")
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["2019yoyooconnectionstring"].ConnectionString);
                con.Open();

                // abre conexão com o banco de dados

                // cria comando sql

                // define comando de exclusão
                SqlCommand cmd = new SqlCommand("DELETE postagem where postagem_id = @postagem_id", con);
                cmd.Parameters.AddWithValue("@postagem_id", ((HiddenField)e.Item.FindControl("HfieldID")).Value);
                
                // executa comando
                cmd.ExecuteNonQuery();
                Response.Redirect("PaginaInicialPostagem.aspx");
            }

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
                Response.Redirect("PaginaInicialPostagemFiltrada.aspx?postagem_id="+ ((HiddenField)e.Item.FindControl("HfieldID")).Value);
            }

        }

        protected void btnRecado_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["2019YoyooConnectionString"].ConnectionString);
            con.Open();
            string command = "SELECT (pos.perfil_recado) FROM usuario as pos WHERE login = @login";
            SqlCommand cmd = new SqlCommand(command, con);
            cmd.Parameters.AddWithValue("@login", Session["login"]);
            string perfilRecado = Convert.ToString(cmd.ExecuteScalar());
            labelTexto.Text = perfilRecado;
        }

        protected void btnEmail_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["2019YoyooConnectionString"].ConnectionString);
            con.Open();
            string command = "SELECT (pos.perfil_email) FROM usuario as pos WHERE login = @login";
            SqlCommand cmd = new SqlCommand(command, con);
            cmd.Parameters.AddWithValue("@login", Session["login"]);
            string perfilemail = Convert.ToString(cmd.ExecuteScalar());
            labelTexto.Text = perfilemail;

        }
        protected void btnconfirmaedit_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["2019YoyooConnectionString"].ConnectionString);
            con.Open();
            SqlCommand com = con.CreateCommand();
            // Define comando de exclusão
            SqlCommand cmd = new SqlCommand("UPDATE USUARIO SET perfil_recado = @recado, perfil_nome = @nome, perfil_email = @email where login = @login", con);
            cmd.Parameters.AddWithValue("@login", Session["login"]);
            cmd.Parameters.AddWithValue("@recado", EditRecadoTXT.Text);
            cmd.Parameters.AddWithValue("@nome", EditNomeTXT.Text);
            cmd.Parameters.AddWithValue("@email", EditEmailTXT.Text);
            // Executa Comando
            cmd.ExecuteNonQuery();
            Response.Redirect("PaginaPerfilPrincipal.aspx");






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

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditarPostagem.aspx?postagem_id=" + ((Button)sender).CommandArgument.ToString());
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string postagem_id = ((Button)sender).CommandArgument.ToString();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["2019YoyooConnectionString"].ConnectionString);
            con.Open();

            string command = "DELETE FROM Avaliacao_Postagem where postagem_id = @postagem_id DELETE FROM comentario where postagem_id = @postagem_id DELETE FROM tblimages where postagem_id = @postagem_id  DELETE FROM notificacao where postagem_id = @postagem_id DELETE FROM postagem where postagem_id = @postagem_id ";
            SqlCommand cmd = new SqlCommand(command, con);
            cmd.Parameters.AddWithValue("@postagem_id", postagem_id);

            cmd.ExecuteNonQuery();
            Response.Redirect("PaginaPerfilPrincipal.aspx");    
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
            Response.Redirect("PaginaPerfilPrincipal.aspx");
        }
    }
}