using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrador_Yooyo.Modelo
{
    public class ModeloCategoria
    {
        public string categoria_id { get; set; }
        public string descricao { get; set; }

        // Construtor
        public ModeloCategoria()
        {
            this.categoria_id = "";
            this.descricao = "";

        }
        public ModeloCategoria(string aCategoria_id, string aDescricao)
        {
            this.categoria_id = aCategoria_id;
            this.descricao = aDescricao;
        }


    }
}