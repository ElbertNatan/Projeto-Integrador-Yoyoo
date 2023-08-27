using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrador_Yooyo.Modelo
{
    public class ModeloPostagem
    {
        public string postagem_id { get; set; }
        public string titulo { get; set; }
        public string avaliacao_vantagem { get; set; }
        public string avaliacao_desvantagem { get; set; }

        public string media_geral { get; set; }
        // Construtor
        public ModeloPostagem()
        {
            this.postagem_id = "";
            this.titulo = "";
            this.avaliacao_vantagem = "";
            this.avaliacao_desvantagem = "";
            this.media_geral = "0";
        }
        public ModeloPostagem(string apostagem_id, string atitulo, string aavaliacao_vantagem, string aavaliacao_desvantagem, string amedia_geral)
        {
            this.postagem_id = apostagem_id;
            this.titulo = atitulo;
            this.avaliacao_vantagem = aavaliacao_vantagem;
            this.avaliacao_desvantagem = aavaliacao_desvantagem;
            this.media_geral = amedia_geral;
           
        }
    }
}
