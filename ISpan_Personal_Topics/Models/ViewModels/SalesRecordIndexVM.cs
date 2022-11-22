using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace ISpan_Personal_Topics.Models.ViewModels
{
    public class SalesRecordIndexVM
    {
        public int Id { get; set; }
        public DateTime ClosingDate { get; set; }

        public string CustomerName { get; set; }

        public string Phone { get; set; }

        public string ProductName { get; set; }

        public int Bonus { get; set; }
               
    }
    public class SalesRecordVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "日期未填")]
        public DateTime ClosingDate { get; set; }
        [Required(ErrorMessage = "客戶未填")]
        public int CustomersId { get; set; }
        [Required(ErrorMessage = "商品未填")]
        public int ProductsId { get; set; }
        [Required(ErrorMessage = "獎金未填")]
        public int Bonus { get; set; }

    }
}
