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
    public partial class EditCustomerFrom : Form
    {
        private int id;
        public EditCustomerFrom(int id)
        {
            InitializeComponent();            
            InitFrom();
            this.id = id;
        }

        private void EditCustomerFrom_Load(object sender, EventArgs e)
        {
            BindData(id);
        }
        private void BindData(int id)
        {
            string sql = @"select * from Customers where Id=@Id";
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
            CustomerVM model = ToCustomerVM(data.Rows[0]);

            cityComboBox.SelectedItem = model.City;
            customerNameTextBox.Text = model.CustomerName;
            ageTextBox.Text = model.Age.ToString();
            phoneTextBox.Text = model.Phone;
            jobTextBox.Text = model.Job;
        }
        private CustomerVM ToCustomerVM(DataRow row)
        {
            return new CustomerVM
            {
                Id = row.Field<int>("Id"),
                City = row.Field<string>("City"),
                CustomerName = row.Field<string>("CustomerName"),
                Age = row.Field<int>("Age"),
                Phone=row.Field<string>("Phone"),
                Job=row.Field<string>("Job")
            };
        }
        private void InitFrom()
        {
            
            string sql = @"select distinct City from Customers";
            var dbhelper = new SqlDbHelper("default");

            List<string> result = dbhelper.Select(sql, null)
                .AsEnumerable()
                .Select(x => x.Field<string>("City"))
                //.Prepend(string.Empty)
                .ToList();
            this.cityComboBox.DataSource = result;
        }

        private void UpdateButton_Click(object sender, EventArgs e)
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

            string sql = @"UPDATE Customers set 
                           City=@City,CustomerName=@CustomerName,Age=@Age,Phone=@Phone,Job=@Job
                           where id=@id";

            var parameters = new SqlParameterBuilder()
                .AddNvachar("City", 50, model.City)
                .AddNvachar("CustomerName", 50, model.CustomerName)
                .AddInt("Age", model.Age)
                .AddNvachar("Phone", 50, model.Phone)
                .AddNvachar("Job", 50, model.Job)
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
            try
            {            
            string sql = @"Delete from Customers where id=@id";

            var parameters = new SqlParameterBuilder()
                .AddInt("id", this.id)
                .Build();
            new SqlDbHelper("default").ExecuteNonQuery(sql, parameters);
                            
            this.DialogResult = DialogResult.OK;
            }
            catch(Exception)
            {
                MessageBox.Show("已有購買紀錄，不可刪除");
            }


        }
    }
}
