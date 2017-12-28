using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RussloWPF
{
    /// <summary>
    /// Объект для сопрежения с дочерними Page, отображаемые в контейнере
    /// </summary>
    public interface IMainWindow
    {
        /// <summary>
        /// Запросить переход на страницу
        /// </summary>
        /// <param name="page"></param>
        void NavigateToPage(PageTypesEnum page);
        /// <summary>
        /// Вернуться назад
        /// </summary>
        void NavigateBack();
        /// <summary>
        /// Изменение визуального состояния уведомления об обработке
        /// </summary>
        /// <param name="value"></param>
        void ShowProgressDialog(bool value);
    }
}
