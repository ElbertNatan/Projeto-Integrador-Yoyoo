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
    public partial class PaginaAdminNew : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["modal"] == null)
            {

            }
            else
              if (Session["modal"].ToString() == "0")
            {

            }
            else
            {

            }
        }
        public string getimage(object postagem_id, object imagedata)
        {

            // Cria objeto com dados lidos do banco de dados

            byte[] imagedata2 = (byte[])imagedata;
            string strbase64 = Convert.ToBase64String(imagedata2);

            string URL = "data:Image/png;base64," + strbase64;

            return URL;




        }

        protected void btnexcluirpost_Click(object sender, EventArgs e)
        {
            string postagem_id = ((LinkButton)sender).CommandArgument.ToString();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["2019YoyooConnectionString"].ConnectionString);
            con.Open();

            string command = "DELETE FROM Avaliacao_Postagem where postagem_id = @postagem_id DELETE FROM comentario where postagem_id = @postagem_id DELETE FROM tblimages where postagem_id = @postagem_id UPDATE denuncia_postagem set postagem_id= '-1' where postagem_id = @postagem_id DELETE FROM notificacao where postagem_id = @postagem_id DELETE FROM postagem where postagem_id = @postagem_id ";
            SqlCommand cmd = new SqlCommand(command, con);
            cmd.Parameters.AddWithValue("@postagem_id", postagem_id);

            cmd.ExecuteNonQuery();
            command = "UPDATE denuncia_postagem set status = 'Postagem Excluida' where denuncia_postagem_id = @denuncia_postagem_id";
            cmd = new SqlCommand(command, con);
            cmd.Parameters.AddWithValue("@denuncia_postagem_id", postagem_id);
            cmd.ExecuteNonQuery();






            Response.Redirect("PaginaAdminNew.aspx");
        }

        protected void btnexcluirsol_Click(object sender, EventArgs e)
        {
            string postagem_id = ((LinkButton)sender).CommandArgument.ToString();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["2019YoyooConnectionString"].ConnectionString);
            con.Open();
            string command = "UPDATE denuncia_postagem set status = 'Solicitação negada' where denuncia_postagem_id = @denuncia_postagem_id";
            SqlCommand cmd = new SqlCommand(command, con);
            cmd.Parameters.AddWithValue("@denuncia_postagem_id", postagem_id);
            cmd.ExecuteNonQuery();
            Response.Redirect("PaginaAdminNew.aspx");
        }

        protected void btnshowpostdenun_Click(object sender, EventArgs e)
        {
            if (divdepos.Style["display"] == "none")
            {
                divdepos.Style.Add("display", "block");
                divdeuser.Style.Add("display", "none");
            }
            else
            {
                divdeuser.Style.Add("display", "none");
                divdepos.Style.Add("display", "none");
            }
        }

        protected void btnshowuserdenun_Click(object sender, EventArgs e)
        {
            if (divdeuser.Style["display"] == "none")
            {
                divdeuser.Style.Add("display", "block");
                divdepos.Style.Add("display", "none");
            }
            else
            {
                divdepos.Style.Add("display", "none");
                divdeuser.Style.Add("display", "none");
            }
        }
        protected void btnbanidos_Click(object sender, EventArgs e)
        {
            if (divdebanidos.Style["display"] == "none")
            {
                divdebanidos.Style.Add("display", "block");
                divdeuser.Style.Add("display", "none");
                divdepos.Style.Add("display", "none");
            }
            else
            {
                divdebanidos.Style.Add("display", "none");
                divdepos.Style.Add("display", "none");
                divdeuser.Style.Add("display", "none");
            }
        }
        protected void btnshowsolicita_Click(object sender, EventArgs e)
        {
            if (divdebanidos.Style["display"] == "none")
            {
                divdesolicita.Style.Add("display", "block");
                divdebanidos.Style.Add("display", "none");
                divdeuser.Style.Add("display", "none");
                divdepos.Style.Add("display", "none");
            }
            else
            {
                divdesolicita.Style.Add("display", "none");
                divdebanidos.Style.Add("display", "none");
                divdeuser.Style.Add("display", "none");
                divdepos.Style.Add("display", "none");
            }
            
        }
        protected void btnbaniruser_Click(object sender, EventArgs e)
        {
            string[] arg = new string[2];
            arg = ((LinkButton)sender).CommandArgument.ToString().Split(';');

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["2019YoyooConnectionString"].ConnectionString);
            con.Open();
            string command = "UPDATE usuario SET banido = '1' where login = @login";
            SqlCommand cmd = new SqlCommand(command, con);
            cmd.Parameters.AddWithValue("@login", arg[0]);
            cmd.ExecuteNonQuery();



            command = "UPDATE denuncia_usuario SET status = 'Usuário Banido' where denuncia_usuario_id = @denuncia_id";
            cmd = new SqlCommand(command, con);
            cmd.Parameters.AddWithValue("@denuncia_id", arg[1]);
            cmd.ExecuteNonQuery();
            Response.Redirect("PaginaAdminNew.aspx");
        }

        protected void btnexcluirdenunuser_Click(object sender, EventArgs e)
        {
            string usuario_id = ((LinkButton)sender).CommandArgument.ToString();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["2019YoyooConnectionString"].ConnectionString);
            con.Open();
            string command = "UPDATE denuncia_usuario SET status = 'Solicitação Negada' where denuncia_usuario_id = @denuncia_usuario_id";
            SqlCommand cmd = new SqlCommand(command, con);
            cmd.Parameters.AddWithValue("@denuncia_usuario_id", usuario_id);
            cmd.ExecuteNonQuery();
            Response.Redirect("PaginaAdminNew.aspx");
        }

        protected void btndesbanir_Click(object sender, EventArgs e)
        {
            string usuario_id = ((LinkButton)sender).CommandArgument.ToString();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["2019YoyooConnectionString"].ConnectionString);
            con.Open();
            string command = "UPDATE usuario SET banido = '0' where login = @login";
            SqlCommand cmd = new SqlCommand(command, con);
            cmd.Parameters.AddWithValue("@login", usuario_id);
            cmd.ExecuteNonQuery();
            Response.Redirect("PaginaAdminNew.aspx");
        }

        protected void btnDeleteCat_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["2019YoyooConnectionString"].ConnectionString);
            con.Open();
            string command = "DELETE FROM categoria where categoria_id = @categoria_id";
            SqlCommand cmd = new SqlCommand(command, con);
            cmd.Parameters.AddWithValue("@categoria_id", ListBox1.SelectedItem.Value);
            cmd.ExecuteNonQuery();
            Response.Redirect("PaginaAdminNew.aspx");
        }

        protected void btnUpdateCat_Click(object sender, EventArgs e)
        {
     


        }
        
      

       

        protected void btnaprovacategoria_Click(object sender, EventArgs e)
        {
            string[] arg = new string[2];
            arg = ((LinkButton)sender).CommandArgument.ToString().Split(';');
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["2019YoyooConnectionString"].ConnectionString);
            con.Open();
            string command = "INSERT into categoria (descricao, sub_categoria) VALUES(@descricao, @sub_categoria)";
            SqlCommand cmd = new SqlCommand(command, con);
            cmd.Parameters.AddWithValue("@descricao", arg[0]);
            cmd.Parameters.AddWithValue("@sub_categoria", arg[1]);
            cmd.ExecuteNonQuery();

            command = "UPDATE solicita_categoria set status = 'Aprovada' where solicita_categoria_id = @id";
            cmd = new SqlCommand(command, con);
            cmd.Parameters.AddWithValue("@id", arg[2]);

            cmd.ExecuteNonQuery();
            Response.Redirect("PaginaAdminNew.aspx");
        }

        protected void btnrecusacategoria_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["2019YoyooConnectionString"].ConnectionString);
            con.Open();
            string command = "UPDATE solicita_categoria set status = 'Recusada' where solicita_categoria_id = @id";
            SqlCommand cmd = new SqlCommand(command, con);
            cmd.Parameters.AddWithValue("@id", ((LinkButton)sender).CommandArgument.ToString());

            cmd.ExecuteNonQuery();
            Response.Redirect("PaginaAdminNew.aspx");
        }

        protected void btncriacat_Click(object sender, EventArgs e)
        {
            if (CriaCatTXT.Text == "" || ListBox2.SelectedItem == null) { }
            else
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["2019YoyooConnectionString"].ConnectionString);
                con.Open();
                string command = "INSERT into categoria (descricao, sub_categoria) VALUES(@descricao, @sub_categoria)";
                SqlCommand cmd = new SqlCommand(command, con);
                cmd.Parameters.AddWithValue("@descricao", CriaCatTXT.Text);
                cmd.Parameters.AddWithValue("@sub_categoria", ListBox2.SelectedItem.Text);
                cmd.ExecuteNonQuery();
                Response.Redirect("PaginaAdminNew.aspx");
            }
        }

        protected void btnAttCat_Click(object sender, EventArgs e)
        {
            if (attCatTXT.Text == "" || ListBox3.SelectedItem == null) { }
            else
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["2019YoyooConnectionString"].ConnectionString);
                con.Open();
                string command = "UPDATE categoria set descricao = @descricao where categoria_id = @categoria_id";
                SqlCommand cmd = new SqlCommand(command, con);
                cmd.Parameters.AddWithValue("@descricao", attCatTXT.Text);
                cmd.Parameters.AddWithValue("@categoria_id", ListBox3.SelectedItem.Value);
                cmd.ExecuteNonQuery();
                Response.Redirect("PaginaAdminNew.aspx");
            }
        }
    }
}