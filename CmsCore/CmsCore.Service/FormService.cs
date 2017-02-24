using CmsCore.Data.Infrastructure;
using CmsCore.Data.Repositories;
using CmsCore.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCore.Service
{
    public interface IFormService
    {
        IEnumerable<Form> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords);
        IEnumerable<Form> GetForms();
        Form GetForm(long id);
        void CreateForm(Form form);
        void UpdateForm(Form form);
        void DeleteForm(long id);
        long FormCount();
        List<FormField> GetFormFieldsByFormId(long id);
        void SaveForm();
    }

    public class FormService : IFormService
    {
        private readonly IFormRepository formRepository;
        private readonly IUnitOfWork unitOfWork;
        public FormService(IFormRepository formRepository, IUnitOfWork unitOfWork)
        {
            this.formRepository = formRepository;
            this.unitOfWork = unitOfWork;
        }
        public IEnumerable<Form> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords)
        {
            var forms = formRepository.Search(search, sortColumnIndex, sortDirection, displayStart, displayLength, out totalRecords, out totalDisplayRecords);

            return forms;
        }
        public IEnumerable<Form> GetForms()
        {
            var forms = formRepository.GetAll("FormField");
            return forms;
        }
        public Form GetForm(long id)
        {
            var form = formRepository.GetById(id);
            return form;
        }
        public List<FormField> GetFormFieldsByFormId(long id)
        {
            Form form = formRepository.GetById(id);
            return form.FormFields.OrderBy(c => c.Position).ToList();
        }
        public void CreateForm(Form form)
        {
            formRepository.Add(form);
        }
        public void UpdateForm(Form form)
        {
            formRepository.Update(form);
        }
        public void DeleteForm(long id)
        {
            formRepository.Delete(f => f.Id == id);
        }
        public void SaveForm()
        {
            unitOfWork.Commit();
        }
        public long FormCount()
        {
            return formRepository.GetAll().Count();
        }
    }
}
