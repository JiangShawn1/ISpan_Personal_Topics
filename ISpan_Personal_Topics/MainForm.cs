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
    public partial class MainForm : Form
    {
        private int id;
        public MainForm(int id)
        {
            InitializeComponent();
            this.id = id;            
        }        

        private void 產品ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new ProductsForm();
            frm.MdiParent = this;
            frm.Show();
        }

        private void 用戶管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new CustomersForm();
            frm.MdiParent = this;
            frm.Show();
        }

        private void 業績紀錄ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new SalesRecordForm();
            frm.MdiParent = this;
            frm.Show();
        }

        private void 帳號設定ToolStripMenuItem_Click(object sender, EventArgs e)
        {       
            var frm = new EditUserForm(id);
            
            frm.MdiParent = this;
            frm.Show();            
        }

        private void 登出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("您真的要登出嗎?", "確定登出?",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                != DialogResult.Yes)
            {
                return;
            }
            this.Close();
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Owner.Show();
        }
    }
}
