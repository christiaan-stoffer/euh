using System;
using NUnit.Framework;

namespace Euh.Crm.Core.Test
{
    [TestFixture]
    public class EntityClassBuilderTest
    {
        [Test]
        public void TestCreateEntityClass()
        {
            var entity = new Entity {Name = "Contact"};
            entity.Fields.Add(new Field {BaseType = "string", Name = "Name"});
            Type contactType = EntityClassBuilder.BuildEntityClass(entity);
            Assert.NotNull(contactType, "contactType cannot be null");
        }
    }
}