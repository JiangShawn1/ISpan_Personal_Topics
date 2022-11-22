using ISPan.Utility;
using ISpan_Personal_Topics.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ISpan.Personal_Topics.Services
{
    public class UserServic
    {
        public IEnumerable<UserIndexVM> GetAll()
        {
            string sql = @"SELECT * From Users order by Id desc ";                       
            var dbHelper = new SqlDbHelper("default");
            return dbHelper.Select(sql, null)
            .AsEnumerable()
            .Select(row => ParseToindexVM(row));            
        }

        private UserIndexVM ParseToindexVM(DataRow row)
        {
            return new UserIndexVM
            {
                Id = row.Field<int>("id"),
                Account = row.Field<string>("Account"),               
                Name = row.Field<string>("Name"),
            };
        }

        public void Greate(UserVM model)
        {
            bool isExiste = AccountExists(model.Account,model.Id);
            if (isExiste) throw new Exception("帳號已存在");

            string sql = @"insert into Users
                         (Account,Password,Name)
                         values(@Account,@Password,@Name)";

            var parameters = new SqlParameterBuilder()
                .AddNvachar("Account", 50, model.Account)
                .AddNvachar("Password", 50, model.Password)
                .AddNvachar("Name", 50, model.Name)
                .Build();
            new SqlDbHelper("default").ExecuteNonQuery(sql, parameters);

        }

        private bool AccountExists(string account,int id)
        {
            string sql = @"select count(*) as count from Users where Account=@Account and Id!=@Id";
            var parameters = new SqlParameterBuilder()
                .AddNvachar("Account", 50, account)
                .AddInt("Id", id)
                .Build();

            DataTable data= new SqlDbHelper("default").Select(sql, parameters);
            return data.Rows[0].Field<int>("count") > 0;
        }
        
        public void Update(UserVM model)
        {
            bool isExiste = AccountExists(model.Account,model.Id);
            if (isExiste) throw new Exception("帳號已存在");

            string sql = @"UPDATE Users set 
                           Account=@Account,Password=@Password,Name=@Name
                           where id=@id";

            var parameters = new SqlParameterBuilder()
                .AddNvachar("Account", 50, model.Account)
                .AddNvachar("Password", 50, model.Password)
                .AddNvachar("Name", 50, model.Name)
                .AddInt("id",model.Id)
                .Build();

            new SqlDbHelper("default").ExecuteNonQuery(sql, parameters);           

        }

        public void Delete(UserVM model)
        {
            if (MessageBox.Show("您真的要刪除嗎?", "確定刪除?",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                != DialogResult.Yes)
            {
                return;
            }

            string sql = @"Delete from Users where id=@id";

            var parameters = new SqlParameterBuilder()
                .AddInt("id", model.Id)
                .Build();

            new SqlDbHelper("default").ExecuteNonQuery(sql, parameters);            
        }

        public bool Authenticate(LoginVM model, out int num)
        {
            var user = Get(model.Account);
            if (user == null) 
            {
                num=0;
                return false;
            }            
            num = user.Id;
            return (user.Password == model.Password);
        }

        private UserVM Get(string account)
        {
            string sql = @"select * from Users where Account=@Account";
            var parameters = new SqlParameterBuilder()
                .AddNvachar("Account", 50, account)
                .Build();

            DataTable data = new SqlDbHelper("default").Select(sql, parameters);
            if (data.Rows.Count==0)
            {
                return null;
            }
            return ToUserVM(data.Rows[0]);
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

    }
}
