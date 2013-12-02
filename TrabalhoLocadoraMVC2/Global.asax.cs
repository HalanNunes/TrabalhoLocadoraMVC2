using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TrabalhoLocadoraMVC2.Models;

namespace TrabalhoLocadoraMVC2
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();

            Repository db = new Repository();
            if (db.TipoCopias.Count() == 0)
            {
                db.TipoCopias.Add(new TipoCopia { Descricao = "CDRom" });
                db.TipoCopias.Add(new TipoCopia { Descricao = "DVD" });
                db.TipoCopias.Add(new TipoCopia { Descricao = "Blue Ray" });
                db.TipoCopias.Add(new TipoCopia { Descricao = "VHS" });
                db.SaveChanges();
            }
        }
    }
}