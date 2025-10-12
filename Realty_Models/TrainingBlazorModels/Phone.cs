using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realty_Models.TrainingBlazorModels
{
    public class Phone
    {
        public int Id { get; set; } //Идентификатор
        public string TypePhone { get; set; } = string.Empty; //Тип
        public string NumberPhone { get; set; } = string.Empty; //Номер
    }
}
