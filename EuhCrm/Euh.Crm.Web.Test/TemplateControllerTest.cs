using Euh.Crm.Core.Domain;
using Euh.Crm.Core.Repository;
using Euh.Crm.Web.Controllers;
using Moq;
using NUnit.Framework;

namespace Euh.Crm.Web.Test
{
    [TestFixture]
    internal class TemplateControllerTest
    {
        [Test]
        public void SaveTemplate()
        {
            var mockConfiguration = new Mock<TemplateConfiguration>();
            var mockRepo = new Mock<ITemplateRepository>();

            mockConfiguration.Setup(framework => framework.Name);
            mockRepo.Setup(framework => framework.Save(mockConfiguration.Object));

            var controller = new TemplateController(mockRepo.Object);

            var result = controller.Save(mockConfiguration.Object);

            mockRepo.Verify(framework => framework.Save(mockConfiguration.Object));
        }
    }
}