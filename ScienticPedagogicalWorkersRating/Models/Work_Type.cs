using System.ComponentModel.DataAnnotations;

namespace ScienticPedagogicalWorkersRating.Models
{
    public class Work_Type
    {
        public int id { get; set; }
        [Display(Name = "Назва")]
        public string? name { get; set; }
        [Display(Name = "Бали")]
        public short mark { get; set; }
    }
}
