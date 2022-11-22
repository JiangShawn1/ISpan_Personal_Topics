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
    public partial class SalesRecordForm : Form
    {
        private SalesRecordIndexVM[] salesRecord = null;
        public SalesRecordForm()
        {
            InitializeComponent();
            InitFrom();
            DisplaySalesRecord();
        }
        private void InitFrom()
        {
            customerComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            productComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            string sqlc = @"select distinct CustomerName from Customers";
            string sqlp = @"select distinct ProductCategory from Products";
            var dbhelper = new SqlDbHelper("default");

            List<string> resultc = dbhelper.Select(sqlc, null)
                .AsEnumerable()
                .Select(x => x.Field<string>("CustomerName"))
                .Prepend(string.Empty)
                .ToList();            
            
            List<string> resultp = dbhelper.Select(sqlp, null)
                .AsEnumerable()
                .Select(x => x.Field<string>("ProductCategory"))
                .Prepend(string.Empty)
                .ToList();

            this.customerComboBox.DataSource = resultc;
            this.productComboBox.DataSource = resultp;
        }
        private void DisplaySalesRecord()
        {
            string sql = @"select SalesRecord.Id,ClosingDate,CustomerName,Phone,ProductName,Bonus from SalesRecord
                           join Customers on Customers.Id=CustomersId
                           join Products on Products.Id=ProductsId";

            SqlParameter[] parameters = new SqlParameter[] { };

            string ProductCategory = productComboBox.SelectedItem.ToString();
            string CustomerName = customerComboBox.SelectedItem.ToString();

            if (ProductCategory != string.Empty && CustomerName != string.Empty)
            {
                sql += @" where ProductCategory=@ProductCategory
                          and CustomerName=@CustomerName";
                parameters = new SqlParameterBuilder()
                    .AddNvachar("ProductCategory", 50, ProductCategory)
                    .AddNvachar("CustomerName", 50, CustomerName)
                    .Build();
            }
            if (ProductCategory != string.Empty && CustomerName == string.Empty)
            {
                sql += @" where ProductCategory=@ProductCategory";                          
                parameters = new SqlParameterBuilder()
                    .AddNvachar("ProductCategory", 50, ProductCategory)                    
                    .Build();
            }
            if (ProductCategory == string.Empty && CustomerName != string.Empty)
            {
                sql += @" where CustomerName=@CustomerName";
                parameters = new SqlParameterBuilder()                    
                    .AddNvachar("CustomerName", 50, CustomerName)
                    .Build();
            }


            sql += @" order by ClosingDate";
            var dbHelper = new SqlDbHelper("default");
            salesRecord = dbHelper.Select(sql, parameters)
            .AsEnumerable()
            .Select(row => ParseToindexVM(row))
            .ToArray();

            BindData(salesRecord);
        }

        private void BindData(SalesRecordIndexVM[] data)
        {
            dataGridView1.DataSource = data;
        }
        private SalesRecordIndexVM ParseToindexVM(DataRow row)
        {
            return new SalesRecordIndexVM
            {   Id=row.Field<int>("Id"),        
                ClosingDate = row.Field<DateTime>("ClosingDate"),
                CustomerName = row.Field<string>("CustomerName"),
                Phone = row.Field<string>("Phone"),
                ProductName = row.Field<string>("ProductName"),
                Bonus = row.Field<int>("Bonus"),
            };
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            DisplaySalesRecord();
        }

        private void addnewButton_Click(object sender, EventArgs e)
        {
            var frm = new CreateSalesRecordForm();            
            DialogResult result = frm.ShowDialog();
            if (result == DialogResult.OK)
            {
                DisplaySalesRecord();
                InitFrom();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndx = e.RowIndex;
            if (rowIndx < 0) return;            
            SalesRecordIndexVM row = this.salesRecord[rowIndx];
            int id = row.Id;

            var frm = new EditSalesRecordForm(id);
            //frm.Show();
            DialogResult result = frm.ShowDialog();
            if (result == DialogResult.OK)
            {
                DisplaySalesRecord();
                InitFrom();
            }
        }
    }
}
