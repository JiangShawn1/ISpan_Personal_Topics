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
    public partial class CustomersForm : Form
    {
        private CustomerIndexVM[] customers = null;
        public CustomersForm()
        {
            InitializeComponent();
            InitFrom();
            DisplayCustomers();
        }
        private void InitFrom()
        {
            cityComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            string sql = @"select distinct City from Customers";
            var dbhelper = new SqlDbHelper("default");

            List<string> result = dbhelper.Select(sql, null)
                .AsEnumerable()
                .Select(x => x.Field<string>("City"))
                .Prepend(string.Empty)
                .ToList();

            this.cityComboBox.DataSource = result;
        }
        private void DisplayCustomers()
        {
            string sql = @"select * from Customers";

            SqlParameter[] parameters = new SqlParameter[] { };

            string City = cityComboBox.SelectedItem.ToString();
            if (City != string.Empty)
            {
                sql += " where City=@City";
                parameters = new SqlParameterBuilder()
                    .AddNvachar("City", 50, City)
                    .Build();
            }

            sql += @" order by id";
            var dbHelper = new SqlDbHelper("default");
            customers = dbHelper.Select(sql, parameters)
            .AsEnumerable()
            .Select(row => ParseToindexVM(row))
            .ToArray();

            BindData(customers);
        }

        private void BindData(CustomerIndexVM[] data)
        {
            dataGridView1.DataSource = data;
        }
        private CustomerIndexVM ParseToindexVM(DataRow row)
        {
            return new CustomerIndexVM
            {
                Id = row.Field<int>("Id"),
                City = row.Field<string>("City"),
                CustomerName = row.Field<string>("CustomerName"),
                Age = row.Field<int>("Age"),
                Phone= row.Field<string>("Phone"),
                Job = row.Field<string>("Job"),
            };
        }
        private void searchButton_Click(object sender, EventArgs e)
        {
            DisplayCustomers();
        }

        private void addnewButton_Click(object sender, EventArgs e)
        {
            var frm = new CreateCustomerFrom();            
            DialogResult result = frm.ShowDialog();
            if (result == DialogResult.OK)
            {
                DisplayCustomers();
                InitFrom();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndx = e.RowIndex;
            if (rowIndx < 0) return;

            CustomerIndexVM row = this.customers[rowIndx];
            int id = row.Id;

            var frm = new EditCustomerFrom(id);
            
            DialogResult result = frm.ShowDialog();
            if (result == DialogResult.OK)
            {
                DisplayCustomers();
                InitFrom();
            }
        }
    }
}
