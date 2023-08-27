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
    public partial class FORMULARIO1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //login
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["2019YoyooConnectionString"].ConnectionString);
            try
            {
                //verifica se usuário existe
                con.Open();
                string query = "Select COUNT(1) FROM Usuario WHERE login=@login AND senha=@senha";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@login", txtLogin.Text.Trim());
                cmd.Parameters.AddWithValue("@senha", txtSenha.Text.Trim());
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                //verifica se usuário existe
                if (count == 1)
                {
                    Session["login"] = txtLogin.Text.Trim();

                    string banido = "Select (banido) FROM Usuario WHERE login=@login";
                    cmd = new SqlCommand(banido, con);
                    cmd.Parameters.AddWithValue("@login", txtLogin.Text.Trim());
                    int baint = Convert.ToInt32(cmd.ExecuteScalar());
                    //usuário não banido continua
                    if (baint == 0)
                    {
                         query = "Select eh_administrador FROM Usuario WHERE login=@login AND senha=@senha";

                         cmd = new SqlCommand(query, con);

                        cmd.Parameters.AddWithValue("@login", txtLogin.Text.Trim());
                        cmd.Parameters.AddWithValue("@senha", txtSenha.Text.Trim());
                        int adminc = Convert.ToInt32(cmd.ExecuteScalar());
                        //loga
                        if (adminc == 1)
                        {
                            Response.Redirect("PaginaAdminNew.aspx");
                        }
                        else
                        {
                            Response.Redirect("PaginaInicialPostagem.aspx");
                        }
                    }
                    else
                    //usuário banido
                    if (baint == 1)
                    {

                        Label1.Text = "Usuário está atualmente banido";
                        Label1.Visible = true;
                        baint = 0;
                    }
                }
                else
                //usuário não existe
        if (count == 0)
                {
                    Label1.Visible = true;
                }

                cmd.ExecuteNonQuery();
                Label1.Visible = true;

            }
            catch (Exception)
            {
                Label1.Visible = true;
            }
            finally
            {
                con.Close();
            }
        }


        protected void Button2_Click(object sender, EventArgs e)
        {
            //chama página de registro
            Response.Redirect("~\\PaginaRegistro.aspx");
        }
    }
}