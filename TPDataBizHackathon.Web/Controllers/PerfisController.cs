using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TPDataBizHackathon.Application.IAppServices;
using TPDataBizHackathon.Infra.IoC;
using TPDataBizHackathon.Web.Models.Enums;
using TPDataBizHackathon.Web.ViewModel;

namespace TPDataBizHackathon.Web.Controllers
{
    public class PerfisController : Controller
    {
        private IAppServiceBase _appServiceBase;

        public PerfisController()
        {
            BootStrapper.Start();
            _appServiceBase = BootStrapper.container.GetInstance<IAppServiceBase>();
        }
        // GET: Perfis
        public ActionResult Perfis()
        {
            
            var reader = _appServiceBase.getFuncionarios();
            List<FuncionarioViewModel> model = new List<FuncionarioViewModel>();
            foreach(var item in reader)
            {
               
                    FuncionarioViewModel funcionario = new FuncionarioViewModel();
                    funcionario.Nome = item[0].ToString();
                    funcionario.Cargo = item[1].ToString();
                    funcionario.Cursos = new List<Cursos>();

                    model.Add(funcionario);
                
                
            }
            
            return View(model);
        }
    }
}