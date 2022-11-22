using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace ISpan_Personal_Topics.Models.ViewModels
{
    public class CustomerIndexVM
    {
        public int Id { get; set; }

        public string City { get; set; }

        public string CustomerName { get; set; }

        public int Age { get; set; }

        public string Phone { get; set; }

        public string Job { get; set; }

    }

    public class CustomerVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "地區未填")]
        public string City { get; set; }
        [Required(ErrorMessage = "姓名未填")]
        public string CustomerName { get; set; }
        [Required(ErrorMessage = "年齡未填")]
        [Range(1,100,ErrorMessage ="年齡錯誤")]
        public int Age { get; set; }
        [Required(ErrorMessage = "電話未填")]
        [MinLength(8,ErrorMessage = "電話錯誤")]
        [StringLength(10,ErrorMessage = "電話錯誤")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "職業未填")]
        public string Job { get; set; }

    }
}
