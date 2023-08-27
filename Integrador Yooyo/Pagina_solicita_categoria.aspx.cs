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
    public partial class Pagina_solicita_categoria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnconfirma_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text == "" || listbx1.SelectedItem == null)
            {

            }
            else
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["2019YoyooConnectionString"].ConnectionString);
                con.Open();
                string command = "INSERT INTO solicita_categoria (descricao, justificativa, sub_categoria, status, login) VALUES(@descricao, 'Nova Categoria Se Faz Necessária', @sub_categoria, 'pendente', @login)";
                SqlCommand cmd = new SqlCommand(command, con);
                cmd.Parameters.AddWithValue("@descricao", TextBox1.Text);
                cmd.Parameters.AddWithValue("@sub_categoria", listbx1.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@login", Session["login"]);
                cmd.ExecuteNonQuery();
                Response.Redirect("PaginaDenuncias.aspx");
            }
        }
    }
}