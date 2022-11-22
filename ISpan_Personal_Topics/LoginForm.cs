using ISpan.Personal_Topics.Services;
using ISpan_Personal_Topics.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ISpan_Personal_Topics
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            LoginVM model = new LoginVM
            {
                Account = accountTextBox.Text,
                Password = passwordTextBox.Text,
            };
            Dictionary<string, Control> map = new Dictionary<string, Control>(StringComparer.CurrentCultureIgnoreCase)
            {
                {"Account",accountTextBox },
                {"Password",passwordTextBox},                
            };
            bool isValid = ValidationHelper.Validate(model, map, errorProvider1);
            if (!isValid) return;


            bool result = new UserServic().Authenticate(model,out int id);
            if (result == false)
            {
                MessageBox.Show("帳號或密碼錯誤");
                return;
            }

            accountTextBox.Text = String.Empty;
            passwordTextBox.Text = String.Empty;
            var frm = new MainForm(id);
            frm.Owner = this;
            frm.Show();
            this.Hide();
        }

        private void signUpButton_Click(object sender, EventArgs e)
        {
            var frm = new CreateUserFrom();

            frm.Show();
        }
    }
}
