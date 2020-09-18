using AutomatizadorSB.Modelo;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatizadorSB.Repositorio
{
    class MensajeRepository
    {
        private IMongoClient _client;
        private IMongoDatabase _database;
        private IMongoCollection<MensajeDto> _mensajeCollection;

        public MensajeRepository()
        {
            _client = new MongoClient(ConfigurationManager.AppSettings["connectionString"] + "&w=majority");
            _database = _client.GetDatabase("automatizador_bd");
            _mensajeCollection = _database.GetCollection<MensajeDto>("mensaje");
        }

        public async Task InsertarMensaje(MensajeDto mensajeDto)
        {
            await _mensajeCollection.InsertOneAsync(mensajeDto);
        }

        public async Task<List<MensajeDto>> ObtenerMensajes()
        {
            return await _mensajeCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task<List<MensajeDto>> ObtenerMensajePorCampo(string campo, string valor)
        {
            var filter = Builders<MensajeDto>.Filter.Eq(campo, valor);
            var result = await _mensajeCollection.Find(filter).ToListAsync();

            return result;
        }

        public async Task<bool> ActualizarMensaje(ObjectId id, string campo, string valor)
        {
            var filter = Builders<MensajeDto>.Filter.Eq("_id", id);
            var update = Builders<MensajeDto>.Update.Set(campo, valor);

            var result = await _mensajeCollection.UpdateOneAsync(filter, update);

            return result.ModifiedCount != 0;
        }

        public async Task<bool> BorrarMensajePorID(ObjectId id)
        {
            var filter = Builders<MensajeDto>.Filter.Eq("_id", id);
            var result = await _mensajeCollection.DeleteOneAsync(filter);
            return result.DeletedCount != 0;
        }

        public async Task<long> BorrarTodosLosMensajes()
        {
            var filter = new BsonDocument();
            var result = await _mensajeCollection.DeleteManyAsync(filter);
            return result.DeletedCount;
        }


        /*
       public async Task<List<MensajeDto>> GetUsers(int startingFrom, int count)
       {
           var result = await _usersCollection.Find(new BsonDocument())
           .Skip(startingFrom)
           .Limit(count)
           .ToListAsync();

           return result;
       } */

    }
}
