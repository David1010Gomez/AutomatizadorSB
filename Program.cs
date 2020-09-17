using AutomatizadorSB.Servicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace AutomatizadorSB
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        static void Main()
        {
            var urlWithAccessToken = "https://hooks.slack.com/services/{YOUR}/{ACCESS}/{TOKENS}";


            var client = new ServicioSlack(urlWithAccessToken);

            client.PostMessage(username: "Mr. Torgue",
                       text: "THIS IS A TEST MESSAGE! SQUEEDLYBAMBLYFEEDLYMEEDLYMOWWWWWWWW!",
                       channel: "#voboestabilizacioncore");
            //ServiceBase[] ServicesToRun;
            ///ServicesToRun = new ServiceBase[]
            //{
            //  new Service1()
            //};
            //ServiceBase.Run(ServicesToRun);
        }
    }
}
