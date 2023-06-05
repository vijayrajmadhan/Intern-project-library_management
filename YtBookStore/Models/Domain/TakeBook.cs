using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YtBookStore.Models.Domain
{
    public class TakeBook
    {
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }

        [Required]
        public int Age { get; set; }
        [Required]
        public string AadharNo { get; set; }
        [Required]
        public string Mobile { get; set; }

        [Required]
        public string BookTitle { get; set; }
        [Required]
        public string BookCode { get; set; }

        public string? Approval { get; set; }
        [Required]
        public DateTime Date1 {  get; set; }
        [Required]
        public DateTime Date2 { get; set; }


    }
}
