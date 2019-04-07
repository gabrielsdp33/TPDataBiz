using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TPDataBizHackathon.Web.Models
{
    public class TabuaMare
    {
        public TabuaMare()
        {
            this.agitacao = new Dictionary<string, string>();
            this.altura = new Dictionary<string, double>();
            this.direcao = new Dictionary<string, string>();
            this.vento = new Dictionary<string, double>();
            this.vento_dir = new Dictionary<string, string>();
            this.hora = new List<string>();
        }

        public Guid id { get; set; }
        public string cidade { get; set; }
        public string uf { get; set; }
        public DateTime atualizacao { get; set; }

        public DateTime dia { get; set; }
        public List<string> hora { get; set; }

        public Dictionary<string, string> agitacao;
        public Dictionary<string, double> altura;
        public Dictionary<string, string> direcao;
        public Dictionary<string, double> vento;
        public Dictionary<string, string> vento_dir;
    }
}