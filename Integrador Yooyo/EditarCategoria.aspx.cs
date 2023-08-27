using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Integrador_Yooyo
{
    public partial class FORMULARIO2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //abre o details view
            if (!IsPostBack)
            {
                DetailsView1.DefaultMode = DetailsViewMode.Edit;

            }
        }

        protected void DetailsView1_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
        {
            //update manda de volta para a categoria
            Response.Redirect("~/InicialCriarCategoria.aspx");
        }

        protected void DetailsView1_ItemCommand(object sender, DetailsViewCommandEventArgs e)
        {
            //Botão para cancelar edição
            if(e.CommandName == "Cancel")
            {
                Response.Redirect("~/InicialCriarCategoria.aspx");
            }
        }
    }
}