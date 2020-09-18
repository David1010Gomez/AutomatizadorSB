using AutomatizadorSB.Modelo;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AutomatizadorSB.Servicio
{
    class ServicioBD
    {
        //Obtener todos los mensajes desde slack
        public JObject GuardarMensaje()
        {
            JObject json = new JObject();
            var ultimo = "1600390687.001200";

            string uri = ConfigurationManager.AppSettings["obtenerConversacionesUrl"];
            string token = ConfigurationManager.AppSettings["tokenSlack"];
            string channel = ConfigurationManager.AppSettings["channel1"];
            string url = uri + "token=" + token + "&channel=" + channel;
            if (ultimo.Length > 0)
            {
                url += "&oldest=" + ultimo;
            }

            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.Method = "GET";
            request.Accept = "application/json";


            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string resultado = reader.ReadToEnd();
                json = JObject.Parse(resultado);
                json.GetValue("ok");
                reader.Close();
                dataStream.Close();
            }

            return json;
        }


    }
}
