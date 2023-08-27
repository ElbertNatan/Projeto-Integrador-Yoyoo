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
    public partial class PaginaVisualizar_Usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
            DataSet ds = GetData();
            Repeater1.DataSource = ds;
            Repeater1.DataBind();




        }
        private DataSet GetData()
        {
            string CS = ConfigurationManager.ConnectionStrings["2019YoyooConnectionString"].ConnectionString;
            if (Page.ToString()== "ASP.PaginaVisualizar_Usuarios_aspx")
            {
                Session["nomeFiltroAmigo"] = "";
                using (SqlConnection con = new SqlConnection(CS))
                {


                    SqlDataAdapter da = new SqlDataAdapter("SELECT * from usuario as us WHERE us.login NOT IN(Select(seguido) FROM usuarioSeguir as se WHERE se.login = '" + Session["login"] + "') AND us.login != 'Admin' AND us.login != '" + Session["login"]+"'", con);


                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    return ds;
                }
            }
            else
            {
                using (SqlConnection con = new SqlConnection(CS))
                {


                    SqlDataAdapter da = new SqlDataAdapter("select * from usuario as us WHERE us.login NOT IN(Select(seguido) FROM usuarioSeguir as se WHERE se.login = '" + Session["login"] + "') AND us.login != 'Admin' AND us.login != '" + Session["login"] + "' AND login LIKE '%" + Request.QueryString["filtroAmigo"] + "%' ", con);


                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    return ds;
                }
            }
        }



    }
}
