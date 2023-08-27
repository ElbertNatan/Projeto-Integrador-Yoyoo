using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace Integrador_Yooyo
{
    public partial class PaginaInicialPostagem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                vantagemTXT.Attributes.Add("maxlength", vantagemTXT.MaxLength.ToString());
                desvantagemTXT.Attributes.Add("maxlength", desvantagemTXT.MaxLength.ToString());
                tituloTXT.Attributes.Add("maxlength", tituloTXT.MaxLength.ToString());
            }

            //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["2019YoyooConnectionString"].ConnectionString);
            //con.Open();

            ////Pega o Login
            //string command = "SELECT (pos.login) FROM postagem as pos WHERE postagem_id = @postagemid";
            //SqlCommand cmd = new SqlCommand(command, con);
            //cmd.Parameters.AddWithValue("@postagemid", Session["postagem_id"]);
            //string poslogin = Convert.ToString(cmd.ExecuteScalar());
            //loginTXT.Text = poslogin;
            //if (Session["login"].ToString().ToUpper() == poslogin.ToUpper())
            //{
            //    Button1.Visible = true;
            //    Button3.Visible = true;
            //}
            //else
            //if (Session["login"].ToString().ToUpper() == "ADMIN")
            //{
            //    Button1.Visible = true;
            //    Button3.Visible = true;
            //}

            //else
            //{

            //}
        }



        //protected void loginTXT_Click(object sender, EventArgs e)
        //{
        //    Session["Visita"] = loginTXT.Text;
        //    Response.Redirect("~/paginaperfilvisita.aspx");
        //}

        protected void Repeater1_ItemCommand(Object Sender, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Comentar")
            {
                if (((TextBox)e.Item.FindControl("comentarTXT")).Text == "")
                { }
                else
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
        protected void Postar_Click(object sender, EventArgs e)
        {
            if (tituloTXT.Text == "" || vantagemTXT.Text == "" || desvantagemTXT.Text == "" || ListboxCategoria.SelectedValue.ToString() == "")
            {
                Label1.Visible = true;

            }
            else
            {
                Modelo.ModeloCriarPostagem aPostagem;
                DAL.DALPostagem aDALPostagem;
                // Instancia um Objeto de postagem com as informações fornecidas
                aPostagem = new Modelo.ModeloCriarPostagem(
                ListboxCategoria.SelectedValue.ToString(), tituloTXT.Text, DateTime.Now.ToLocalTime(), vantagemTXT.Text, desvantagemTXT.Text, Session["login"].ToString());
                // Instancia objeto da camada de negocio
                aDALPostagem = new DAL.DALPostagem();

                // Chama metodo de insert passando o objeto preenchido
                aDALPostagem.Insert(aPostagem);
                int Fpostagem_id = aDALPostagem.forpostagem_id;


                //insert imagem
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["2019YoyooConnectionString"].ConnectionString);
                con.Open();
                string command = "SELECT SCOPE_IDENTITY()";
                SqlCommand cmd = new SqlCommand(command, con);

                foreach (HttpPostedFile postedFile in FileUpload1.PostedFiles)
                {
                    string filename = Path.GetFileName(postedFile.FileName);


                    string fileExtension = Path.GetExtension(filename);
                    int fileSize = postedFile.ContentLength;

                    if (fileExtension.ToLower() == ".jpg" || fileExtension.ToLower() == ".jpeg"
                        || fileExtension.ToLower() == ".png" || fileExtension.ToLower() == ".jfif")
                    {
                        Stream stream = postedFile.InputStream;
                        BinaryReader binaryReader = new BinaryReader(stream);
                        Byte[] bytes = binaryReader.ReadBytes((int)stream.Length);




                        // Cria comando SQL
                        SqlCommand com = con.CreateCommand();
                        // Define comando de isnert
                        cmd = new SqlCommand("INSERT INTO tblimages (name, imagedata, postagem_id) VALUES(@Name, @imagedata, @postagem_id)", con);
                        cmd.Parameters.AddWithValue("@Name", filename);
                        cmd.Parameters.AddWithValue("@imagedata", bytes);
                        cmd.Parameters.AddWithValue("@postagem_id", Fpostagem_id);

                        // Executa Comando
                        cmd.ExecuteNonQuery();


                    }

                }
                con.Close();
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
                Response.Redirect("PaginaInicialPostagem.aspx");
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
                Response.Redirect("PaginaInicialPostagem.aspx");
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
                Response.Redirect("PaginaInicialPostagem.aspx");
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
                Response.Redirect("PaginaInicialPostagem.aspx");
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
                Response.Redirect("PaginaInicialPostagem.aspx");
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
                Response.Redirect("PaginaInicialPostagem.aspx");
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
                Response.Redirect("PaginaInicialPostagem.aspx");
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
                Response.Redirect("PaginaInicialPostagem.aspx");
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
                Response.Redirect("PaginaInicialPostagem.aspx");
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
                Response.Redirect("PaginaInicialPostagem.aspx");
            }
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
            Response.Redirect("PaginaInicialPostagem.aspx");
        }
    }
}