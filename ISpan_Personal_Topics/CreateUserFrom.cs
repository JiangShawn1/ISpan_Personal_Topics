using ISpan.Personal_Topics.Services;
using ISpan_Personal_Topics.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ISpan_Personal_Topics
{
    public partial class CreateUserFrom : Form
    {       
        public CreateUserFrom()
        {
            InitializeComponent();
        }        

        private void singUpButton_Click(object sender, EventArgs e)
        {            
            string account = accountTextBox.Text;
            string password = passwordTextBox.Text;
            string name = usersNameTextBox.Text;

            UserVM model = new UserVM
            {
                Account = account,
                Password = password,
                Name = name,                
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
                new UserServic().Greate(model);               

                MessageBox.Show("帳號已新增");
                this.Close();
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }            
        }        
    }
}
