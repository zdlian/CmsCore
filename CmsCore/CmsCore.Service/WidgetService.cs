using CmsCore.Data.Infrastructure;
using CmsCore.Data.Repositories;
using CmsCore.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCore.Service
{
    public interface IWidgetService
    {
        IEnumerable<Widget> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords);
        IEnumerable<Widget> GetWidgets();
        Widget GetWidget(long id);
        void CreateWidget(Widget widget);
        void UpdateWidget(Widget widget);
        void DeleteWidget(long id);
        void SaveWidget();

    }

    public class WidgetService : IWidgetService
    {
        private readonly IWidgetRepository widgetRepository;
        private readonly IUnitOfWork unitOfWork;
        public WidgetService(IWidgetRepository widgetRepository, IUnitOfWork unitOfWork)
        {
            this.widgetRepository = widgetRepository;
            this.unitOfWork = unitOfWork;
        }
        #region IWidgetServiceMembers
        public IEnumerable<Widget> GetWidgets()
        {
            var widgets = widgetRepository.GetAll();
            return widgets;
        }
        public Widget GetWidget(long id)
        {
            var widget = widgetRepository.GetById(id);
            return widget;
        }
        public void CreateWidget(Widget widget)
        {
            widgetRepository.Add(widget);
        }
        public void UpdateWidget(Widget widget)
        {
            widgetRepository.Update(widget);
        }
        public void DeleteWidget(long id)
        {
            widgetRepository.Delete(x => x.Id == id);
        }
        public void SaveWidget()
        {
            unitOfWork.Commit();
        }
        public IEnumerable<Widget> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords)
        {
            var widgets = widgetRepository.Search(search, sortColumnIndex, sortDirection, displayStart, displayLength, out totalRecords, out totalDisplayRecords);
            return widgets;
        }
    }
}
#endregion