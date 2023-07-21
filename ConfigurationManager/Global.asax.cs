using log4net.Config;
using System;

namespace AppConfigurationManager
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            XmlConfigurator.Configure();
        }

        protected void Session_OnStart(object sender, EventArgs e)
        {
            if (System.Configuration.ConfigurationManager.AppSettings["CookieTimeout"] != null)
            {
                int cookieTimeout = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["CookieTimeout"]);
                this.Session.Timeout = cookieTimeout * 2;
            }
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(Server.GetLastError());
        }

    }
}