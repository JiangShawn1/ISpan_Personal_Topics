using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ISpan_Personal_Topics.Models.ViewModels
{
    public class UserIndexVM
    {
        public int Id { get; set; }
        public string Account { get; set; }
        //public string Password { get; set; }
        public string Name { get; set; }
    }
    public class UserVM
    {      
        public int Id { get; set; }

        [Required(ErrorMessage ="帳號未填")]
        public string Account { get; set; }

        [Required(ErrorMessage = "密碼未填")]
        public string Password { get; set; }

        [Required(ErrorMessage = "姓名未填")]
        public string Name { get; set; }

    }
}
