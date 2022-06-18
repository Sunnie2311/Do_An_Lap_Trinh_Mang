using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System.Drawing;

namespace Server_Side2
{
    class Room
    {
        [BsonId]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public byte[] Board { get; set; }
        public Room()
        {
            Board = new byte[1024 * 5000];
        }
    }
}
