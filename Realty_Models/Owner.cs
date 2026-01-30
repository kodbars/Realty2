using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realty_Models
{
    public class Owner
    {
        [Key]
        public int Id { get; set; } //Идентификатор
        [Required(ErrorMessage = "Введите Ф.И.О. собственника")]
        public string? Fio { get; set; } //Ф.И.О. собственника
        [Required(ErrorMessage = "Введите Дату регистрации")]
        public DateTime StartTitul { get; set; } //Дата регистрации
        [Required(ErrorMessage = "Введите Вид Собственности")]
        public string? TypeTitul { get; set; } //Вид собственности
        [Required(ErrorMessage = "Введите Номер регистрации права")]
        public string? NumTitul { get; set; } //Номер регистрации права
        public DateTime? EndTitul { get; set; } //Дата прекращения права
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Выберите дом")]
        public int HouseId { get; set; } //Идентификатор дома
        [ForeignKey("HouseId")]
        public House? House { get; set; } //Навигационное поле
    }
}
