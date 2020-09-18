using AutomatizadorSB.Servicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatizadorSB.Test
{
    class TestSlack
    {
        public void EnviarMensajeSlack()
        {
            var urlWithAccessToken = "https://hooks.slack.com/services/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";


            var client = new ServicioSlack(urlWithAccessToken);

            client.PostMessage(username: "Mr. Torgue",
                           text: "THIS IS A TEST MESSAGE! SQUEEDLYBAMBLYFEEDLYMEEDLYMOWWWWWWWW!",
                           channel: "#voboestabilizacioncore");
        }

        public void RecibirMensajeSlack()
        {
            var urlWithAccessToken = "https://hooks.slack.com/services/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";


            var client = new ServicioSlack(urlWithAccessToken);

            client.PostMessage(username: "Mr. Torgue",
                           text: "THIS IS A TEST MESSAGE! SQUEEDLYBAMBLYFEEDLYMEEDLYMOWWWWWWWW!",
                           channel: "#voboestabilizacioncore");
        }

        public void obtenerMensajesSlack() {
            ServicioSlack s = new ServicioSlack("aa");
            s.ObtenerMensajesSlack();
        }



    }
}
