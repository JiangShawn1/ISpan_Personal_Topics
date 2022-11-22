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
    public partial class CreateCustomerFrom : Form
    {
        public CreateCustomerFrom()
        {
            InitializeComponent();
            InitFrom();
        }
        private void InitFrom()
        {
            string sql = @"select distinct City from Customers";
            var dbhelper = new SqlDbHelper("default");

            List<string> result = dbhelper.Select(sql, null)
                .AsEnumerable()
                .Select(x => x.Field<string>("City"))
                .Prepend(string.Empty)
                .ToList();

            this.cityComboBox.DataSource = result;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string city = this.cityComboBox.Text;
            string customerName = customerNameTextBox.Text;
            int age = ageTextBox.Text.ToInt(0);
            string phone = phoneTextBox.Text;
            string job = jobTextBox.Text;

            CustomerVM model = new CustomerVM
            {
                City = city,
                CustomerName = customerName,
                Age = age,
                Phone = phone,
                Job = job,
            };
            
            Dictionary<string, Control> map = new Dictionary<string, Control>(StringComparer.CurrentCultureIgnoreCase)
            {
                {"City",cityComboBox },
                {"CustomerName",customerNameTextBox },
                {"Age",ageTextBox},
                {"Phone",phoneTextBox },
                {"Job",jobTextBox },
            };
            bool isValid = ValidationHelper.Validate(model, map, errorProvider1);
            if (!isValid) return;


            string sql = @"insert into Customers
                         (City,CustomerName,Age,Phone,Job)
                   values(@City,@CustomerName,@Age,@Phone,@Job)";


            var parameters = new SqlParameterBuilder()
                .AddNvachar("City", 50, model.City)
                .AddNvachar("CustomerName", 50, model.CustomerName)
                .AddInt("Age",model.Age)
                .AddNvachar("Phone", 50, model.Phone)
                .AddNvachar("Job", 50, model.Job)
                .Build();

            new SqlDbHelper("default").ExecuteNonQuery(sql, parameters);

            this.DialogResult = DialogResult.OK;
        }
    }
}
