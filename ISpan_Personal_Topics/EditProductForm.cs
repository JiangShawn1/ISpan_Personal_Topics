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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace ISpan_Personal_Topics
{
    public partial class EditProductForm : Form
    {
        private int id;
        public EditProductForm(int id)
        {
            InitializeComponent();
            InitFrom();
            this.id = id;
        }

        private void EditProductForm_Load(object sender, EventArgs e)
        {
            BindData(id);
        }
        private void BindData(int id)
        {
            string sql = @"select * from Products where Id=@Id";
            var parameters = new SqlParameterBuilder()
                .AddInt("Id", id)
                .Build();

            DataTable data = new SqlDbHelper("default").Select(sql, parameters);
            if (data.Rows.Count == 0)
            {
                MessageBox.Show("抱歉，找不到要編輯的紀錄");
                this.DialogResult = DialogResult.OK;
                //this.Close();
                return;
            }
            ProductVM model = ToProductVM(data.Rows[0]);

            productCategoryComboBox.SelectedItem = model.ProductCategory;      
            productNameTextBox.Text = model.ProductName;
            DetailTextBox.Text = model.Detail;
        }
        private ProductVM ToProductVM(DataRow row)
        {
            return new ProductVM
            {
                Id = row.Field<int>("Id"),
                ProductCategory = row.Field<string>("ProductCategory"),
                ProductName = row.Field<string>("ProductName"),
                Detail = row.Field<string>("Detail"),
            };
        }

        private void InitFrom()
        {
            productCategoryComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            string sql = @"select distinct ProductCategory from Products";
            var dbhelper = new SqlDbHelper("default");

            List<string> result = dbhelper.Select(sql, null)
                .AsEnumerable()
                .Select(x => x.Field<string>("ProductCategory"))
                //.Prepend(string.Empty)
                .ToList();
            this.productCategoryComboBox.DataSource = result;
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            string productCategory = this.productCategoryComboBox.SelectedItem.ToString();
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
                {"ProductCategory",productCategoryComboBox },
                {"ProductName",productNameTextBox },
                {"Detail",DetailTextBox},
            };
            bool isValid = ValidationHelper.Validate(model, map, errorProvider1);
            if (!isValid) return;


            string sql = @"UPDATE Products set 
                           ProductCategory=@ProductCategory,ProductName=@ProductName,Detail=@Detail
                           where id=@id";

            var parameters = new SqlParameterBuilder()
                .AddNvachar("ProductCategory",50, model.ProductCategory)
                .AddNvachar("ProductName", 50, model.ProductName)
                .AddNvachar("Detail",50, model.Detail)
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
            string sql = @"Delete from Products where id=@id";

            var parameters = new SqlParameterBuilder()
                .AddInt("id", this.id)
                .Build();

            new SqlDbHelper("default").ExecuteNonQuery(sql, parameters);

            //MessageBox.Show("資料已刪除");
            this.DialogResult = DialogResult.OK;
            }
            catch (Exception)
            {
                MessageBox.Show("已有出售紀錄，不可刪除");
            }
        }
    }
}
