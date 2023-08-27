using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Integrador_Yooyo
{
    public partial class PaginaDenuncias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void solicita_cat_click(object sender, EventArgs e)
        {
            if (solicita_cat_sec.Style["display"] == "none")
            {
                denun_user.Style.Add("display", "none");
                solicita_cat_sec.Style.Add("display", "block");
                denuncia_post_sec.Style.Add("display", "none");
            }
            else
            {
                denun_user.Style.Add("display", "none");
                solicita_cat_sec.Style.Add("display", "none");
                denuncia_post_sec.Style.Add("display", "none");
            }
        }

        protected void denuncia_post_click(object sender, EventArgs e)
        {
            if (denuncia_post_sec.Style["display"] == "none")
            {
                denun_user.Style.Add("display", "none");
                denuncia_post_sec.Style.Add("display", "block");
                 solicita_cat_sec.Style.Add("display", "none");
            }
            else
            {
                denun_user.Style.Add("display", "none");
                solicita_cat_sec.Style.Add("display", "none");
                denuncia_post_sec.Style.Add("display", "none");
            }
        }

        protected void denun_perfil_click(object sender, EventArgs e)
        {
            if (denun_user.Style["display"] == "none")
            {
                denun_user.Style.Add("display", "block");
                denuncia_post_sec.Style.Add("display", "none");
                solicita_cat_sec.Style.Add("display", "none");
            }
            else
            {
                denun_user.Style.Add("display", "none");
                solicita_cat_sec.Style.Add("display", "none");
                denuncia_post_sec.Style.Add("display", "none");
            }
        }
    }
}