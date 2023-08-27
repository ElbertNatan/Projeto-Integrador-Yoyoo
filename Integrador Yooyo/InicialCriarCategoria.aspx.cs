using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Integrador_Yooyo
{
    public partial class InicialCriarCategoria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        { 
            //define nome de usuário logado
            txtlabel.Text = " " + Session["login"] + "   ";
        }

        protected void Button_Click(object sender, EventArgs e)
        {
            //verificar descrição
            if (descricaoTXT.Text.Trim() == "")
            {
                Label1.Text = "Insira um Nome válido para Categoria";
                Label1.Visible = true;
            }
            else
            {
                Modelo.ModeloCriarCategoria aCategoria;
                DAL.DALCategoria aDALCategoria;

                aCategoria = new Modelo.ModeloCriarCategoria(descricaoTXT.Text, ListBox1.SelectedItem.Text);
                // Instancia objeto da camada de negocio
                aDALCategoria = new DAL.DALCategoria();
                // Chama metodo de insert passando o objeto preenchido
                aDALCategoria.Insert(aCategoria);
                // Chama Página de Categoria
                Response.Redirect("~\\InicialCriarCategoria.aspx");
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            // Verifica se o comando é "Editar"
            if (e.CommandName == "Editar")
            {
                string codigo;

                // Le o numero da linha selecionada
                int index = Convert.ToInt32(e.CommandArgument);

                // Copia o conteúdo da primeira célula da linha -> Código da postagem
                codigo = GridView1.Rows[index].Cells[0].Text;

                // Grava código da postagem na sessão
                Session["categoria_id"] = codigo;

                // Chama a tela de edição
                Response.Redirect("~\\EditarCategoria.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //abandona sessão e desloga
            Session.Abandon();
            Response.Redirect("PaginaInicial.aspx");
        }
    }
}