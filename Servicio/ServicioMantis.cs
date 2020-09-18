using AutomatizadorSB.Modelo;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AutomatizadorSB.Servicio
{
    class ServicioMantis
    {
        public JObject ComentarioMantis(string url)
        {
            ////CONSULTA A BASE DE DATOS
            ///

            // SACAR SUBSTR() DE URL PARA CASO

            JObject json = new JObject();
            Task<string> strObj = null;
            using (var httpClient = new HttpClient())
            {
                string urlMantis = @"https://www.segurosbolivar.com/mantis/api/rest/issues/1234/notes";
                httpClient.DefaultRequestHeaders.Add("Authorization", "DW-teND1jURt73m1Jjc61Q-Kv3cGsbrr");

                var body = "{text: 'Buen día, Se autoriza ejecución de script.', 'view_state': {name: 'public'} }";
                var data = new StringContent(body, Encoding.UTF8, "application/json");
                var res = httpClient.PostAsync(urlMantis, data).Result;

                if (res != null && res.Content != null)
                {
                    strObj = res.Content.ReadAsStringAsync();
                    json = (JObject)JsonConvert.DeserializeObject<string>(strObj.Result.ToString());
                    AsigancionMantis();
                }
                else
                {
                    ComentarioMantis(url);
                }
            }
            return json;
        }

        public JObject AsigancionMantis()
        {

            JObject json = new JObject();
            Task<string> strObj = null;
            using (var httpClient = new HttpClient())
            {
                string urlMantis = @"https://www.segurosbolivar.com/mantis/api/rest/issues/1234/notes";
                httpClient.DefaultRequestHeaders.Add("Authorization", "DW-teND1jURt73m1Jjc61Q-Kv3cGsbrr");

                var body = "{text: 'Buen día, Se autoriza ejecución de script.', 'view_state': {name: 'public'} }";
                var data = new StringContent(body, Encoding.UTF8, "application/json");
                var res = httpClient.PostAsync(urlMantis, data).Result;

                if (res != null && res.Content != null)
                {
                    strObj = res.Content.ReadAsStringAsync();
                    json = (JObject)JsonConvert.DeserializeObject<string>(strObj.Result.ToString());

                }
                else
                {
                    AsigancionMantis();
                }
            }
            return json;
        }

    }
}