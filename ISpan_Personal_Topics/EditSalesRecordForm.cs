using ISPan.Utility;
using ISpan_Personal_Topics.Infra.Extensions;
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
    public partial class EditSalesRecordForm : Form
    {
        private int id;
        public EditSalesRecordForm(int id)
        {
            InitializeComponent();
            InitFrom();
            this.id = id;
        }

        private void EditSalesRecordForm_Load(object sender, EventArgs e)
        {
            BindData(id);
        }
        private void BindData(int id)
        {
            string sql = @"select * from SalesRecord where Id=@Id";
            var parameters = new SqlParameterBuilder()
                .AddInt("Id", id)
                .Build();

            DataTable data = new SqlDbHelper("default").Select(sql, parameters);
            if (data.Rows.Count == 0)
            {
                MessageBox.Show("抱歉，找不到要編輯的紀錄");
                this.DialogResult = DialogResult.OK;
                return;
            }
            SalesRecordVM model = ToSalesRecordVM(data.Rows[0]);
            closeDatePicker.Value = model.ClosingDate;
            customerComboBox.SelectedItem = ((List<CustomerVM>)customerComboBox.DataSource)
                .FirstOrDefault(x => x.Id == model.CustomersId);
            productComboBox.SelectedItem = ((List<ProductVM>)productComboBox.DataSource)
                .FirstOrDefault(x => x.Id == model.ProductsId);            
            bonusTextBox.Text = model.Bonus.ToString();            
        }
        private SalesRecordVM ToSalesRecordVM(DataRow row)
        {
            return new SalesRecordVM
            {
                Id = row.Field<int>("Id"),
                ClosingDate = row.Field<DateTime>("ClosingDate"),
                CustomersId = row.Field<int>("CustomersId"),
                ProductsId = row.Field<int>("ProductsId"),                
                Bonus = row.Field<int>("Bonus"),
            };
        }
        private void InitFrom()
        {
            closeDatePicker.CustomFormat = "yyyy/MM/dd";
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
                CustomerName = row.Field<string>("CustomerName"),
                Age = row.Field<int>("Age"),
                Phone = row.Field<string>("Phone"),
                Job = row.Field<string>("Job"),
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

        private void UpdateButton_Click(object sender, EventArgs e)
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
                Bonus = Bonus
            };            

            string sql = @"UPDATE SalesRecord set 
                           ClosingDate=@ClosingDate,Bonus=@Bonus,
                           CustomersId=@CustomersId,ProductsId=@ProductsId
                           where id=@id";

            var parameters = new SqlParameterBuilder()
                .AddDateTime("ClosingDate", model.ClosingDate)
                .AddInt("CustomersId", model.CustomersId)
                .AddInt("ProductsId", model.ProductsId)
                .AddInt("Bonus", model.Bonus)
                .AddInt("id", this.id)
                .Build();

            new SqlDbHelper("default").ExecuteNonQuery(sql, parameters);

            //MessageBox.Show("資料已更新");
            this.DialogResult = DialogResult.OK;
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("您真的要刪除嗎?", "確定刪除?",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                != DialogResult.Yes)
            {
                return;
            }
            string sql = @"Delete from SalesRecord 
                           where id=@id";

            var parameters = new SqlParameterBuilder()
                .AddInt("id", this.id)
                .Build();

            new SqlDbHelper("default").ExecuteNonQuery(sql, parameters);

            //MessageBox.Show("資料已刪除");
            this.DialogResult = DialogResult.OK;

        }
    }
}
