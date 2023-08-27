using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Integrador_Yooyo
{
    public partial class AddUsers : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["nomeFiltroAmigo"] = SearchIDTXT.Value;
            DataSet ds = GetData();
            Repeater1.DataSource = ds;
            Repeater1.DataBind();


            DataSet ds2 = GetData2();
            Repeater2.DataSource = ds2;
            Repeater2.DataBind();
            TXTEU.InnerText = Session["login"].ToString();
        }
        protected void botaoAmigos_Click(object sender, EventArgs e)
        {
            if (divAmigos.Visible == false)
            {
                divAmigos.Visible = true;
            }
            else
            {
                divAmigos.Visible = false;
            }
        }
        private DataSet GetData()
        {
            string CS = ConfigurationManager.ConnectionStrings["2019YoyooConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM [notificacao] as noti WHERE noti.login IN(Select(seguido) FROM usuarioSeguir as se WHERE se.login = '" + Session["login"] + "') AND noti.login != 'admin' AND noti.login != '" + Session["login"] + "' order by postagem_id desc", con);

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
                SqlDataAdapter da2 = new SqlDataAdapter("SELECT (seguido) FROM usuarioSeguir Where login = '" + Session["login"] + "'", con);

                DataSet ds2 = new DataSet();
                da2.Fill(ds2);
                return ds2;
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Session["nomeFiltroAmigo"] = SearchIDTXT.Value;

            Response.Redirect("PaginaVisualizar_Usuarios.aspx?filtroAmigo=" + SearchIDTXT.Value);
        }

    }
}