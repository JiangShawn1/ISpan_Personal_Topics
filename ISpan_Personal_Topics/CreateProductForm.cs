using ISPan.Utility;
using ISpan_Personal_Topics.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ISpan_Personal_Topics
{
    public partial class CreateProductForm : Form
    {
        public CreateProductForm()
        {
            InitializeComponent();
            InitFrom();
        }
        private void InitFrom()
        {        

            string sql = @"select distinct ProductCategory from Products";
            var dbhelper = new SqlDbHelper("default");

            List<string> result = dbhelper.Select(sql, null)
                .AsEnumerable()
                .Select(x => x.Field<string>("ProductCategory"))
                .Prepend(string.Empty)
                .ToList();

            this.categoryComboBox.DataSource = result;
        }


        private void saveButton_Click(object sender, EventArgs e)
        {
            string productCategory = this.categoryComboBox.Text;
            string productName = productNameTextBox.Text;
            string detail = DetailTextBox.Text;

            ProductVM model = new ProductVM
            {
                ProductCategory = productCategory,
                ProductName = productName,
                Detail = detail
            };

            Dictionary<string, Control> map = new Dictionary<string, Control>(StringComparer.CurrentCultureIgnoreCase)
            {
                {"ProductCategory",categoryComboBox },
                {"ProductName",productNameTextBox },
                {"Detail",DetailTextBox},                
            };
            bool isValid = ValidationHelper.Validate(model, map, errorProvider1);
            if (!isValid) return;



            string sql = @"insert into Products
                         (ProductCategory,ProductName,Detail)
                         values(@CategoryId,@ProductName,@Detail)";

            var parameters = new SqlParameterBuilder()
                .AddNvachar("CategoryId",50, model.ProductCategory)
                .AddNvachar("ProductName", 50, model.ProductName)
                .AddNvachar("Detail",50, model.Detail)
                .Build();

            new SqlDbHelper("default").ExecuteNonQuery(sql, parameters);

            
            this.DialogResult = DialogResult.OK;
        }
    }
}
