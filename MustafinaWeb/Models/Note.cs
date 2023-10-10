//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MustafinaWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class Note
    {
        public int NoteId { get; set; }
        [DisplayName("Название")]
        [Required(ErrorMessage = "Поле Title обязательно для заполнения.")]
        [StringLength(50)]
        public string Title { get; set; }

        [DisplayName("Текст")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Text { get; set; }

        [DisplayName("Последняя дата редактирования")]
        [DataType(DataType.Date)] // Указываем тип данных (дата)
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)] // Формат даты
        public System.DateTime Date { get; set; }

        [DisplayName("Владелец")]
        public string UserId { get; set; }
    }
}
