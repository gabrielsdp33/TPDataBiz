using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TPDataBizHackathon.Web.Models.Enums;

namespace TPDataBizHackathon.Web.ViewModel
{
    public class FuncionarioViewModel
    {
        public string Nome { get; set; }
        public string Cargo { get; set; }
        public List<Cursos> Cursos { get; set; } 
    }
}