﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatizadorSB.Modelo
{
	public class PayloadSlack
	{
		[JsonProperty("channel")]
		public string Channel { get; set; }

		[JsonProperty("username")]
		public string Username { get; set; }

		[JsonProperty("text")]
		public string Text { get; set; }
	}
}
