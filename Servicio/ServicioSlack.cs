using AutomatizadorSB.Modelo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
			_uri = new Uri(urlWithAccessToken);
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

	}
}
