using BulkCopyCSV.Infra.Data.Repository;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPDataBizHackathon.Application.AppServices;
using TPDataBizHackathon.Application.IAppServices;
using TPDataBizHackathon.Domain.Interfaces.IRepositories;
using TPDataBizHackathon.Domain.Interfaces.IServices;
using TPDataBizHackathon.Domain.Services;

namespace TPDataBizHackathon.Infra.IoC
{
    public class BootStrapper
    {
        public static Container container;

        public static void Start()
        {
            container = new Container();

            container.Register<IAppServiceBase, AppServiceBase>();
            container.Register<IServiceBase, ServiceBase>();
            container.Register<IRepositoryBase, RepositoryBase>();
        }
    }
}
