using CmsCore.Data.Infrastructure;
using CmsCore.Data.Repositories;
using CmsCore.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCore.Service
{
    public interface ITemplateService
    {

        IEnumerable<Template> GetTemplates();
        Template GetTemplate(long id);
        void CreateTemplate(Template template);
        void UpdateTemplate(Template template);
        void DeleteTemplate(long id);
        void SaveTemplate();
    }

    public class TemplateService : ITemplateService
    {
        private readonly ITemplateRepository templateRepository;
        private readonly IUnitOfWork unitOfWork;

        public TemplateService(ITemplateRepository templateRepository, IUnitOfWork unitOfWork)
        {
            this.templateRepository = templateRepository;
            this.unitOfWork = unitOfWork;
        }

        #region ITemplateService Members

        public IEnumerable<Template> GetTemplates()
        {
            var templates = templateRepository.GetAll();
            return templates;
        }


        public Template GetTemplate(long id)
        {
            var template = templateRepository.GetById(id);
            return template;
        }
        

        public void CreateTemplate(Template template)
        {
            templateRepository.Add(template);
        }

        public void UpdateTemplate(Template template)
        {
            templateRepository.Update(template);
        }

        public void DeleteTemplate(long id)
        {
            templateRepository.Delete(p => p.Id == id);
        }

        public void SaveTemplate()
        {
            unitOfWork.Commit();
        }
        #endregion
    }
}

