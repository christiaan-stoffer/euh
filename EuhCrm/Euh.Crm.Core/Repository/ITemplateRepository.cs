using Euh.Crm.Core.Domain;

namespace Euh.Crm.Core.Repository
{
    public interface ITemplateRepository
    {
        TemplateConfiguration Save(TemplateConfiguration template);
    }
}