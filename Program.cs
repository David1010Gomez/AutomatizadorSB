﻿using AutomatizadorSB.Repositorio;
using AutomatizadorSB.Servicio;
using AutomatizadorSB.Test;
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
        static async Task Main()
        {
            TestMongo tm = new TestMongo();
            await tm.insertarMensajeAsync();
            await tm.seleccionarTodos();




            //ServiceBase[] ServicesToRun;
            ///ServicesToRun = new ServiceBase[]
            //{
            //  new Service1()
            //};
            //ServiceBase.Run(ServicesToRun);
        }
    }
}
