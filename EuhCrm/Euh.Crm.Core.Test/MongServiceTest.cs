using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Euh.Crm.Core.Test
{
    [TestFixture]
    public class MongServiceTest
    {
        private MongoService _service;

        [TestFixtureSetUp]
        public void Setup()
        {
            _service = new MongoService();
        }

        [Test]
        public void CreateEntities()
        {
            IEnumerable<Entity> entities = Enumerable.Range(0, 50000).Select(i =>
                                                                                 {
                                                                                     var ent = new Entity();
                                                                                     ent.Fields.Add(new Field
                                                                                                        {
                                                                                                            Name =
                                                                                                                "string field",
                                                                                                            BaseType =
                                                                                                                "string",
                                                                                                        });
                                                                                     ent.Fields.Add(new Field
                                                                                                        {
                                                                                                            Name =
                                                                                                                "date field",
                                                                                                            BaseType = "datetime"
                                                                                                        });
                                                                                     return ent;
                                                                                 });

            _service.CreateEntity(entities);
        }

        [Test]
        public void RetrieveTypeFieldValue()
        {
            IEnumerable<Entity> entities = _service.FindAll();
            Entity entity = entities.First();
            Field first = entity.Fields.First();
            string baseType = first.BaseType;
            Assert.NotNull(baseType, "Field value cannot be null");
        }
    }
}