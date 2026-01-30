using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Realty_Models
{
    public class House
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Введите Номер лота")]
        [RegularExpression(@"\d{3}", ErrorMessage = "Некорректный Номер лота")]
        public string? Lot { get; set; }
        [Required(ErrorMessage = "Введите Адрес объекта")]
        public string? Address { get; set; }
        public string? Notes { get; set; }
        public bool IsExclusive { get; set; }
        public bool IsMortagege { get; set; }
        [Required(ErrorMessage = "Введите Жилую площадь")]
        [Range(1, double.MaxValue, ErrorMessage = "Введите корректную Жилую площадь")]
        public double Squeare { get; set; }
        [Required(ErrorMessage = "Введите Количество комнат")]
        [Range(1, int.MaxValue, ErrorMessage = "Введите корректное Число комнат")]
        public int NumOfRoms { get; set; }
        [Required(ErrorMessage = "Укажите Цену объекта")]
        [Range(1, double.MaxValue, ErrorMessage = "Введите корректную Цену")]
        public double Price { get; set; }
        public string? ImageUrl { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Выберите регион")]
        public int RegionId { get; set; }
        [ForeignKey("RegionId")]
        public Region? Region { get; set; } //Навигационное поле
        public ICollection<Owner> Owners { get; set; } = new List<Owner>();
    }
}
