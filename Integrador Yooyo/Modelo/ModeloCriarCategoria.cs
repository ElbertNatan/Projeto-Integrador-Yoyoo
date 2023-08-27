using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrador_Yooyo.Modelo
{
    public class ModeloCriarCategoria
    {
   
        public string descricao { get; set; }
        public string sub_categoria { get; set; }

        // Construtor
        public ModeloCriarCategoria()
        {
        
            this.descricao = "";
            this.sub_categoria = "";

        }
        public ModeloCriarCategoria(string aDescricao, string asub_categoria)
        {
            this.descricao = aDescricao;
            this.sub_categoria = asub_categoria;
        }


    }
}