using System;
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
        public void TestCreateEntity()
        {
            var entities = Enumerable.Range(0, 50000).Select(i =>
                                                     {
                                                         var ent = new Entity();
                                                         ent.Fields.Add(new Field
                                                                            {
                                                                                Name = "string field",
                                                                                Value = "FooShizzle"
                                                                            });
                                                         ent.Fields.Add(new Field
                                                                            {Name = "date field", Value = DateTime.Now});
                                                         return ent;
                                                     });

            foreach (var entity in entities)
            {
                _service.CreateEntity(entity);
            }
            
            
//            foreach (var entity in _service.FindAll())
//            {
//                string s = "";
//            }
        }
    }
}