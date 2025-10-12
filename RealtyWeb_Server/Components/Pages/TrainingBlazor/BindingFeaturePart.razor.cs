using Microsoft.AspNetCore.Components;
using Realty_Models.TrainingBlazorModels;
using System.Globalization;

namespace RealtyWeb_Server.Components.Pages.TrainingBlazor
{
    partial class BindingFeaturePart
    {
        string Status { get; set; } = "Кнопка ещё не нажата!";
        private string selectedPhone = string.Empty;
        Tenant tenant = new Tenant()
        {
            Id = 1,
            Fio = "Иванов Алексей Владимирович",
            Dr = DateTime.Parse("01.12.1980", CultureInfo.GetCultureInfo("ru")),
            DateContact = DateTime.Parse("10.10.2024", CultureInfo.GetCultureInfo("ru")),
            Commission = 12000.50d,
            IsSend = true,
            Phones = new List<Phone>()
            {
                new Phone(){Id = 1, TypePhone = "Мобильный", NumberPhone = "+79257863538" },
                new Phone(){Id = 2, TypePhone = "Домашний", NumberPhone = "2607060" },
                new Phone(){Id = 3, TypePhone = "Рабочий", NumberPhone = "2355050" }
            }
        };
        void SelectedPhonesChanged(ChangeEventArgs e)
        {
            if (e.Value is not null)
            {
                selectedPhone = (string) e.Value;
            }
        }
        private void ButtonClicked(bool isSingleClick)
        {
            Status = $"Кнопка нажата один раз {isSingleClick}";
        }
        private void ButtonDoubleClicked(string status)
        {
            Status = status;
        }
    }
}
