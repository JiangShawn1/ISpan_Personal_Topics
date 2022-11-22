using ISPan.Utility;
using ISpan_Personal_Topics.Infra.Extensions;
using ISpan_Personal_Topics.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ISpan_Personal_Topics
{
    public partial class CreateSalesRecordForm : Form
    {
        public CreateSalesRecordForm()
        {
            InitializeComponent();
            InitFrom();
        }
        private void InitFrom()
        {
            closeDatePicker.CustomFormat ="yyyy/MM/dd";
            customerComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            productComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            string sqlc = @"select * from Customers";
            string sqlp = @"select * from Products";
            var dbhelper = new SqlDbHelper("default");

            List<CustomerVM> resultc = dbhelper.Select(sqlc, null)
                .AsEnumerable()
                .Select(row => ToCustomerVM(row))                
                .ToList();

            List<ProductVM> resultp = dbhelper.Select(sqlp, null)
                .AsEnumerable()
                .Select(row => ToProductVM(row))                
                .ToList();

            this.customerComboBox.DataSource = resultc;
            this.productComboBox.DataSource = resultp;
        }
        private CustomerVM ToCustomerVM(DataRow row)
        {
            return new CustomerVM
            {
                Id = row.Field<int>("id"),
                City = row.Field<string>("City"),
                CustomerName= row.Field<string>("CustomerName"),
                Age = row.Field<int>("Age"),
                Phone= row.Field<string>("Phone"),
                Job= row.Field<string>("Job"),
            };
        }
        private ProductVM ToProductVM(DataRow row)
        {
            return new ProductVM
            {
                Id = row.Field<int>("id"),
                ProductCategory = row.Field<string>("ProductCategory"),
                ProductName = row.Field<string>("ProductName"),                
                Detail = row.Field<string>("Detail"),                
            };
        }

        private void saveButton_Click(object sender, EventArgs e)
        {            
            if (this.closeDatePicker.Value >= DateTime.Today.AddDays(1))
            {
                MessageBox.Show("成交日不可大於今天");
                return;
            }        
            
            DateTime closingDate = this.closeDatePicker.Value;
            int customersId = ((CustomerVM)this.customerComboBox.SelectedItem).Id;
            int productsId = ((ProductVM)this.productComboBox.SelectedItem).Id;
            int Bonus = bonusTextBox.Text.ToInt(0);

            SalesRecordVM model = new SalesRecordVM
            {
                ClosingDate = closingDate,
                CustomersId = customersId,
                ProductsId = productsId,
                Bonus= Bonus
            };          

            string sql = @"insert into SalesRecord
                         (ClosingDate,CustomersId,ProductsId,Bonus)                        
                         values(@ClosingDate,@CustomersId,@ProductsId,@Bonus)";

            var parameters = new SqlParameterBuilder()
                .AddDateTime("ClosingDate", model.ClosingDate)
                .AddInt("CustomersId",  model.CustomersId)
                .AddInt("ProductsId",  model.ProductsId)
                .AddInt("Bonus",model.Bonus)
                .Build();

            new SqlDbHelper("default").ExecuteNonQuery(sql, parameters);

            this.DialogResult = DialogResult.OK;
        }
    }
}
