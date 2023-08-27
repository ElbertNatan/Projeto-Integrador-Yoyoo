using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Integrador_Yooyo
{
    public partial class PaginaRegistro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["2019YoyooConnectionString"].ConnectionString);
            try
            {
                if (txtSenha.Text == txtConf.Text)
                {
                    con.Open();
                    string command = "INSERT INTO Usuario (login, senha) VALUES(@login, @senha)";
                    SqlCommand cmd = new SqlCommand(command, con);

                    cmd.Parameters.AddWithValue("@login", txtLogin.Text.Trim());
                    cmd.Parameters.AddWithValue("@senha", txtSenha.Text.Trim());

                    cmd.ExecuteNonQuery();

                    con = new SqlConnection(ConfigurationManager.ConnectionStrings["2019YoyooConnectionString"].ConnectionString);
                    con.Open();
                    command = "UPDATE usuario SET perfil_foto = @perfil_foto where login=@login";
                    cmd = new SqlCommand(command, con);

                    cmd.Parameters.AddWithValue("@login", txtLogin.Text.Trim());
                    cmd.Parameters.AddWithValue("@perfil_foto", "ImagePadrão");
                    cmd.ExecuteNonQuery();
                    Response.Redirect("PaginaInicial.aspx");

                }
                else
                {
                    Label1.Text = "As senhas não são iguais";
                    Label1.Visible = true;
                }
              
            }
            catch (Exception)
            {
                Label1.Text = "Nome de usuário já cadastrado";
                Label1.Visible = true;
            }
            finally
            {
                con.Close();
            }
            
        }
    }
}