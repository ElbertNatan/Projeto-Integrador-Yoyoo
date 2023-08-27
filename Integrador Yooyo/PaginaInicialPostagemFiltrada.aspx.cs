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
    public partial class PaginaInicialPostagemFiltrada : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                vantagemTXT.Attributes.Add("maxlength", vantagemTXT.MaxLength.ToString());
                desvantagemTXT.Attributes.Add("maxlength", desvantagemTXT.MaxLength.ToString());
                tituloTXT.Attributes.Add("maxlength", tituloTXT.MaxLength.ToString());
            }
            if (this.Page.ToString() + Request.QueryString["postagem_id"] == "ASP.paginainicialpostagemfiltrada_aspx")
            {
               //OK
                if (Session["categoriaFiltro"].ToString() == "Todos" && Session["nomeFiltro"].ToString() == "")
                {

                    DataSet ds3 = GetData3();
                    RepPosID.DataSource = ds3;
                    RepPosID.DataBind();
                }
                else
                //OK
                if (Session["categoriaFiltro"].ToString() == "Todos" && Session["nomeFiltro"].ToString() != "")
                {
                    Session["categoriaFiltro"] = "cat.sub_categoria";
                    DataSet ds4 = GetData4();
                    RepPosID.DataSource = ds4;
                    RepPosID.DataBind();
                }
                else
                //NOT OK
                if (Session["nomeFiltro"].ToString() == "" && Session["categoriaFiltro"].ToString() != "Todos")
                {
                    Session["nomeFiltro"] = "";
                    DataSet ds5 = GetData5();
                    RepPosID.DataSource = ds5;
                    RepPosID.DataBind();
                }
                else
                {
                    DataSet ds = GetData();
                    RepPosID.DataSource = ds;
                    RepPosID.DataBind();
                }
            }
            else
               if (this.Page.ToString() + Request.QueryString["postagem_id"] != "ASP.paginainicialpostagemfiltrada_aspx")
            {
                DataSet ds2 = GetData2();

                RepPosID.DataSource = ds2;
                RepPosID.DataBind();
            }

        }
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
        private DataSet GetData()
        {
            string CS = ConfigurationManager.ConnectionStrings["2019YoyooConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlDataAdapter da = new SqlDataAdapter("select distinct pos.titulo, pos.avaliacao_desvantagem, pos.avaliacao_vantagem, pos.data_hora, pos.login, pos.media_geral, pos.postagem_id, pos.Categoria from Postagem as pos Cross apply Categoria cat where pos.titulo LIKE '%" + Session["nomeFiltro"] + "%' AND cat.sub_categoria = '" + Session["categoriaFiltro"] + "'", con);


                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
        }
        private DataSet GetData2()
        {
            string CS = ConfigurationManager.ConnectionStrings["2019YoyooConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlDataAdapter da2 = new SqlDataAdapter("Select * from postagem WHERE postagem_id =  " + Request.QueryString["postagem_id"] + "", con);

                DataSet ds2 = new DataSet();
                da2.Fill(ds2);
                return ds2;
            }
        }
        private DataSet GetData3()
        {
            string CS3 = ConfigurationManager.ConnectionStrings["2019YoyooConnectionString"].ConnectionString;
            using (SqlConnection con3 = new SqlConnection(CS3))
            {
                SqlDataAdapter da3 = new SqlDataAdapter("select * from Postagem", con3);


                DataSet ds3 = new DataSet();
                da3.Fill(ds3);
                return ds3;
            }
        }

        private DataSet GetData4()
        {
            string CS4 = ConfigurationManager.ConnectionStrings["2019YoyooConnectionString"].ConnectionString;
            using (SqlConnection con4 = new SqlConnection(CS4))
            {
                SqlDataAdapter da4 = new SqlDataAdapter("select distinct pos.titulo, pos.avaliacao_desvantagem, pos.avaliacao_vantagem, pos.data_hora, pos.login, pos.media_geral, pos.postagem_id, pos.Categoria from Postagem as pos Cross apply Categoria cat where pos.titulo LIKE '%" + Session["nomeFiltro"] + "%' AND cat.sub_categoria = " + Session["categoriaFiltro"] + "", con4);


                DataSet ds4 = new DataSet();
                da4.Fill(ds4);
                Session["categoriaFiltro"] = "Todos";
                return ds4;
            }
        }

        private DataSet GetData5()
        {
            string CS5 = ConfigurationManager.ConnectionStrings["2019YoyooConnectionString"].ConnectionString;
            using (SqlConnection con5 = new SqlConnection(CS5))
            {
                SqlDataAdapter da5 = new SqlDataAdapter("select distinct pos.titulo, pos.avaliacao_desvantagem, pos.avaliacao_vantagem, pos.data_hora, pos.login, pos.media_geral, pos.postagem_id, pos.Categoria from Postagem as pos Cross apply Categoria cat where pos.Categoria = cat.descricao AND  cat.sub_categoria = '"+Session["categoriaFiltro"]+"'", con5);


                DataSet ds5 = new DataSet();
                da5.Fill(ds5);
                return ds5;
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
            Response.Redirect("PaginaInicialPostagemFiltrada.aspx");

        }
        protected void Postar_Click(object sender, EventArgs e)
        {
            if (tituloTXT.Text == "" || vantagemTXT.Text == "" || desvantagemTXT.Text == "" || ListBox1.SelectedValue.ToString() == "")
            {
                Label1.Visible = true;

            }
            else
            {
                Modelo.ModeloCriarPostagem aPostagem;
                DAL.DALPostagem aDALPostagem;
                // Instancia um Objeto de postagem com as informações fornecidas
                aPostagem = new Modelo.ModeloCriarPostagem(
                ListBox1.SelectedValue.ToString(), tituloTXT.Text, DateTime.Now.ToLocalTime(), vantagemTXT.Text, desvantagemTXT.Text, Session["login"].ToString());
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
                        || fileExtension.ToLower() == ".png" || fileExtension.ToLower() == ".J")
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
                Response.Redirect("PaginaInicialPostagemFiltrada.aspx?postagem_id="+ ((ImageButton)sender).CommandArgument.ToString());
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
            
        }
    }
}