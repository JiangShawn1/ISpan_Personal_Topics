using ISpan.Personal_Topics.Services;
using ISPan.Utility;
using ISpan_Personal_Topics.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace ISpan_Personal_Topics
{

    public partial class EditUserForm : Form
    {
        private int id;
        public EditUserForm(int id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void EditUserForm_Load(object sender, EventArgs e)
        {
            BindData(id);
        }
        private void BindData(int id)
        {
            string sql = @"select * from Users where Id=@Id";
            var parameters = new SqlParameterBuilder()
                .AddInt("Id", id)
                .Build();

            DataTable data = new SqlDbHelper("default").Select(sql, parameters);
            if (data.Rows.Count == 0)
            {
                MessageBox.Show("帳號已刪除，請立即登出");
                this.DialogResult = DialogResult.OK;
                return;
            }
            UserVM model = ToUserVM(data.Rows[0]);
            accountTextBox.Text = model.Account;
            passwordTextBox.Text = model.Password;
            usersNameTextBox.Text = model.Name;
        }
        private UserVM ToUserVM(DataRow row)
        {
            return new UserVM
            {
                Id = row.Field<int>("Id"),
                Account = row.Field<string>("Account"),
                Password = row.Field<string>("Password"),
                Name = row.Field<string>("Name"),
            };
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            string account = accountTextBox.Text;
            string password = passwordTextBox.Text;
            string name = usersNameTextBox.Text;

            UserVM model = new UserVM
            {
                Account = account,
                Password = password,
                Name = name,
                Id = id
            };
            Dictionary<string, Control> map = new Dictionary<string, Control>(StringComparer.CurrentCultureIgnoreCase)
            {
                {"Account",accountTextBox },
                {"Password",passwordTextBox},
                {"Name",usersNameTextBox },
            };
            bool isValid = ValidationHelper.Validate(model, map, errorProvider1);
            if (!isValid) return;
            
            try
            { 
                new UserServic().Update(model);                

                MessageBox.Show("資料已更新");
                this.Close();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }            
        }
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            UserVM model = new UserVM
            {                
                Id = this.id
            };
            new UserServic().Delete(model);            
            
            MessageBox.Show("資料已刪除");
            this.Parent.FindForm().Close();                      
        }      
    }
}
