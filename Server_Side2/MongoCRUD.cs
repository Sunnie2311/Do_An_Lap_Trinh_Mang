using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Server_Side2
{
    class MongoCRUD
    {
        private IMongoDatabase db;
        public MongoCRUD(string database)
        {
            var client = new MongoClient();
            db = client.GetDatabase(database);
        }
        public void InsertOneRecord<T>(string table, T record)
        {
            var collection = db.GetCollection<T>(table);
            collection.InsertOne(record);
        }
        public long CountRecord<T>(string table, string nameField, string info)
        {
            var collection = db.GetCollection<T>(table);
            var filter = Builders<T>.Filter.Eq(nameField, info);
            return collection.CountDocuments(filter);
        }

        public List<T> LoadAllRecord<T>(string table)
        {
            var collection = db.GetCollection<T>(table);
            return collection.Find(new BsonDocument()).ToList();
        }

        public T LoadOneRecord<T>(string table, string nameField, string info)
        {
            var collection = db.GetCollection<T>(table);
            var filter = Builders<T>.Filter.Eq(nameField, info);
            return collection.Find(filter).FirstOrDefault();
        }

        public void UpdateRecord(string table, string name, Room record)
        {
            var collection = db.GetCollection<Room>(table);
            var filter = Builders<Room>.Filter.Eq(a => a.Name, name);
            var updateDefinition = Builders<Room>.Update.Set(a => a.Board, record.Board);
            collection.UpdateOne(filter, updateDefinition);
        }
    }
}
