    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrador_Yooyo.Modelo
{
    public class ModeloCriarPostagem
    {
     
        public DateTime data_hora { get; set; }
        public string categoria { get; set; }
        public string login { get; set; }
        public string titulo { get; set; }
        public string avaliacao_vantagem { get; set; }
        public string avaliacao_desvantagem { get; set; }
        // Construtor
        public ModeloCriarPostagem()
        {
            this.categoria ="";
            this.titulo = "";
            this.data_hora = DateTime.Now;
            this.avaliacao_vantagem = "";
            this.avaliacao_desvantagem = "";
            this.login = "";
        }
        public ModeloCriarPostagem(string acategoria, string atitulo, DateTime adata_hora, string aavaliacao_vantagem, string aavaliacao_desvantagem, string alogin)
        {
           
            this.categoria = acategoria;
            this.titulo = atitulo;
            this.data_hora = adata_hora;
            this.avaliacao_vantagem = aavaliacao_vantagem;
            this.avaliacao_desvantagem = aavaliacao_desvantagem;
            this.login = alogin;
        }
    }
}
