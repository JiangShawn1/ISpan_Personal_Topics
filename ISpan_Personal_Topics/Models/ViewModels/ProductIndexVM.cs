using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace ISpan_Personal_Topics.Models.ViewModels
{
    public class ProductIndexVM
    {
        public int Id { get; set; }       

        public string ProductCategory { get; set; }

        public string ProductName { get; set; }

        public string Detail { get; set; }
    }

    public class ProductVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "商品分類未填")]
        public string ProductCategory { get; set; }
        [Required(ErrorMessage = "商品名稱未填")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "商品內容未填")]
        public string Detail { get; set; }
    }
}
