using ISPan.Utility;
using ISpan_Personal_Topics.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ISpan_Personal_Topics
{
    public partial class ProductsForm : Form
    {
        private ProductIndexVM[] products = null;
        public ProductsForm()
        {
            InitializeComponent();
            InitFrom();
            DisplayProducts();
        }
        private void InitFrom()
        {
            productCategoryComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            string sql = @"select distinct ProductCategory from Products";
            var dbhelper = new SqlDbHelper("default");
                        
            List<string> result = dbhelper.Select(sql, null)
                .AsEnumerable()
                .Select(x=> x.Field<string>("ProductCategory"))
                .Prepend(string.Empty)
                .ToList();

            this.productCategoryComboBox.DataSource = result;
        }

        private ProductVM ToProductCategoryVM(DataRow row)
        {
            return new ProductVM
            {
                Id = row.Field<int>("id"),
                ProductCategory = row.Field<string>("ProductCategory"),
                ProductName = row.Field<string>("ProductName"),
                Detail = row.Field<string>("Detail"),

            };
        }

        private void DisplayProducts()
        {
            string sql = @"select * from Products";

            SqlParameter[] parameters = new SqlParameter[] { };

            string ProductCategory =productCategoryComboBox.SelectedItem.ToString();
            if (ProductCategory!=string.Empty)
            {
                sql += " where ProductCategory=@ProductCategory";
                parameters = new SqlParameterBuilder()
                    .AddNvachar("ProductCategory",50, ProductCategory)
                    .Build();
            }

            sql += @" order by id";
            var dbHelper = new SqlDbHelper("default");
            products = dbHelper.Select(sql, parameters)
            .AsEnumerable()
            .Select(row => ParseToindexVM(row))
            .ToArray();

            BindData(products);
        }

        private void BindData(ProductIndexVM[] data)
        {
            dataGridView1.DataSource = data;
        }
        private ProductIndexVM ParseToindexVM(DataRow row)
        {
            return new ProductIndexVM
            {
                Id = row.Field<int>("Id"),
                ProductCategory = row.Field<string>("ProductCategory"),
                ProductName = row.Field<string>("ProductName"),
                Detail = row.Field<string>("Detail"),
            };
        }

        private void addnewButton_Click(object sender, EventArgs e)
        {
            var frm = new CreateProductForm();
            //frm.Show();
            DialogResult result = frm.ShowDialog();
            if (result == DialogResult.OK)
            {
                DisplayProducts();
                InitFrom();
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            DisplayProducts();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndx = e.RowIndex;
            if (rowIndx < 0) return;

            ProductIndexVM row = this.products[rowIndx];
            int id = row.Id;

            var frm = new EditProductForm(id);
            //frm.Show();
            DialogResult result = frm.ShowDialog();
            if (result == DialogResult.OK)
            {
                DisplayProducts();
                InitFrom();
            }
        }
    }
}
