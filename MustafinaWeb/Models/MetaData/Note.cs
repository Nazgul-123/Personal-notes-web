using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MustafinaWeb.Models.MetaData
{
    [MetadataType(typeof(NoteMetaData))]
    public partial class Note
    {
        [Bind(Exclude = "NoteId")]
        public class NoteMetaData
        {
            [ScaffoldColumn(false)]
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
}