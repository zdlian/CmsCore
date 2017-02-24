using CmsCore.Data.Infrastructure;
using CmsCore.Data.Repositories;
using CmsCore.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCore.Service
{
    public interface IFormFieldService
    {
        IEnumerable<FormField> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords);
        IEnumerable<FormField> GetFormFields();
        FormField GetForms(long id);
        FormField GetFormField(long id);
        void CreateFormField(FormField formField);
        void UpdateFormField(FormField formField);
        void DeleteFormField(long id);
        int FormFieldCount();

        void SaveFormField();
    }

    public class FormFieldService : IFormFieldService
    {
        private readonly IFormFieldRepository formFieldRepository;
        private readonly IUnitOfWork unitOfWork;
        public FormFieldService(IFormFieldRepository formFieldRepository, IUnitOfWork unitOfWork)
        {
            this.formFieldRepository = formFieldRepository;
            this.unitOfWork = unitOfWork;
        }
        public IEnumerable<FormField> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords)
        {
            var formFields = formFieldRepository.Search(search, sortColumnIndex, sortDirection, displayStart, displayLength, out totalRecords, out totalDisplayRecords);

            return formFields;
        }
        public IEnumerable<FormField> GetFormFields()
        {
            var formFields = formFieldRepository.GetAll("FormType");
            return formFields;
        }
        public FormField GetForms(long id)
        {
            var formfield = formFieldRepository.Get(f => f.Form.Id == id);
            return formfield;
        }

        public FormField GetFormField(long id)
        {
            var formInfo = formFieldRepository.GetById(id);
            return formInfo;
        }
        public void CreateFormField(FormField formField)
        {
            formFieldRepository.Add(formField);
        }
        public void UpdateFormField(FormField formField)
        {
            formFieldRepository.Update(formField);
        }
        public void DeleteFormField(long id)
        {
            formFieldRepository.Delete(f => f.Id == id);
        }
        public void SaveFormField()
        {
            unitOfWork.Commit();
        }
        public int FormFieldCount()
        {
            return formFieldRepository.GetAll().Count();
        }
    }
}
