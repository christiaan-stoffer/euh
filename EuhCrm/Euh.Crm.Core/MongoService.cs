using System;
using System.Collections.Generic;
using System.Configuration;
using MongoDB;

namespace Euh.Crm.Core
{
    public class MongoService
    {
        private readonly IMongoCollection<Entity> _collection;

        public MongoService()
        {
            var mongo = new Mongo();
            mongo.Connect();
            IMongoDatabase mongoDatabase = mongo.GetDatabase(ConfigurationManager.AppSettings["Database"]);
            _collection = mongoDatabase.GetCollection<Entity>("entity");
        }

        public Entity CreateEntity(Entity entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            _collection.Insert(entity);
            return entity;
        }

        public IEnumerable<Entity> FindAll()
        {
            return _collection.FindAll().Documents;
        }

        public void CreateEntity(IEnumerable<Entity> entities)
        {
            _collection.Insert(entities);
        }
    }
}