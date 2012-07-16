using System.Web.Mvc;
using Euh.Crm.Core.Domain;
using Euh.Crm.Core.Repository;

namespace Euh.Crm.Web.Controllers
{
    public class TemplateController : Controller
    {
        private readonly ITemplateRepository _repository;

        public TemplateController(ITemplateRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public ActionResult Save(TemplateConfiguration template)
        {
            var result = new JsonResult();

            template = _repository.Save(template);
            result.Data = template;

            return result;
        }
    }
}