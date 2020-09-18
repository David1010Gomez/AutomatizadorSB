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
    class ServicioSlack
    {

        private readonly Uri _uri;
        private readonly Encoding _encoding = new UTF8Encoding();

        public ServicioSlack(string urlWithAccessToken)
        {
            //_uri = new Uri(urlWithAccessToken);
        }

        //Post a message using simple strings
        public void PostMessage(string text, string username = null, string channel = null)
        {
            PayloadSlack payload = new PayloadSlack()
            {
                Channel = channel,
                Username = username,
                Text = text
            };

            PostMessage(payload);
        }

        //Post a message using a Payload object
        public void PostMessage(PayloadSlack payload)
        {
            string payloadJson = JsonConvert.SerializeObject(payload);

            using (WebClient client = new WebClient())
            {
                NameValueCollection data = new NameValueCollection();
                data["payload"] = payloadJson;

                var response = client.UploadValues(_uri, "POST", data);

                //The response text is usually "ok"
                string responseText = _encoding.GetString(response);
            }
        }


        //Obtener todos los mensajes desde slack
        public JObject ObtenerMensajesSlack()
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
