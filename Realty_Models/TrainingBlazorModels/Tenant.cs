using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realty_Models.TrainingBlazorModels
{
    public class Tenant
    {
        public int Id { get; set; } //Идентификатор
        public string Fio { get; set; } = string.Empty; //Ф.И.О
        public DateTime Dr { get; set; } //Дата рождения
        public DateTime DateContact { get; set; } //Дата договора
        public double Commission { get; set; } //Размер комиссионного вознаграждения
        public bool IsSend { get; set; } //Отправлять уведомления
        public IEnumerable<Phone>? Phones { get; set; } //Список контактных телефонов
    }
}
