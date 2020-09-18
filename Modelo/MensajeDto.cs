using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatizadorSB.Modelo
{
    public class MensajeDto
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("client_msg_id")]
        public string ClientMsgId { get; set; }

        [BsonElement("type")]
        public string type { get; set; }

        [BsonElement("text")]
        public string text { get; set; }

        [BsonElement("user")]
        public string user { get; set; }

        [BsonElement("ts")]
        public string ts { get; set; }

        [BsonElement("team")]
        public string team { get; set; }


    }
}
