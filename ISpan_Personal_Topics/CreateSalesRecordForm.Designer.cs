namespace ISpan_Personal_Topics
{
    partial class CreateSalesRecordForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.closeDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.customerComboBox = new System.Windows.Forms.ComboBox();
            this.customerVMBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.productComboBox = new System.Windows.Forms.ComboBox();
            this.productVMBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bonusTextBox = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.customerVMBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productVMBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // closeDatePicker
            // 
            this.closeDatePicker.Location = new System.Drawing.Point(120, 49);
            this.closeDatePicker.Name = "closeDatePicker";
            this.closeDatePicker.Size = new System.Drawing.Size(267, 22);
            this.closeDatePicker.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(58, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 12);
            this.label2.TabIndex = 13;
            this.label2.Text = "用戶姓名:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(58, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 12);
            this.label3.TabIndex = 14;
            this.label3.Text = "成交日期:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 178);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 12);
            this.label1.TabIndex = 15;
            this.label1.Text = "商品名稱:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(58, 240);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 12);
            this.label4.TabIndex = 15;
            this.label4.Text = "業績獎金:";
            // 
            // customerComboBox
            // 
            this.customerComboBox.DataSource = this.customerVMBindingSource;
            this.customerComboBox.DisplayMember = "CustomerName";
            this.customerComboBox.FormattingEnabled = true;
            this.customerComboBox.Location = new System.Drawing.Point(120, 112);
            this.customerComboBox.Name = "customerComboBox";
            this.customerComboBox.Size = new System.Drawing.Size(267, 20);
            this.customerComboBox.TabIndex = 16;
            this.customerComboBox.ValueMember = "Id";
            // 
            // customerVMBindingSource
            // 
            this.customerVMBindingSource.DataSource = typeof(ISpan_Personal_Topics.Models.ViewModels.CustomerVM);
            // 
            // productComboBox
            // 
            this.productComboBox.DataSource = this.productVMBindingSource;
            this.productComboBox.DisplayMember = "ProductName";
            this.productComboBox.FormattingEnabled = true;
            this.productComboBox.Location = new System.Drawing.Point(120, 173);
            this.productComboBox.Name = "productComboBox";
            this.productComboBox.Size = new System.Drawing.Size(267, 20);
            this.productComboBox.TabIndex = 16;
            this.productComboBox.ValueMember = "Id";
            // 
            // productVMBindingSource
            // 
            this.productVMBindingSource.DataSource = typeof(ISpan_Personal_Topics.Models.ViewModels.ProductVM);
            // 
            // bonusTextBox
            // 
            this.bonusTextBox.Location = new System.Drawing.Point(120, 234);
            this.bonusTextBox.Name = "bonusTextBox";
            this.bonusTextBox.Size = new System.Drawing.Size(267, 22);
            this.bonusTextBox.TabIndex = 17;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(312, 287);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 18;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // CreateSalesRecordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 386);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.bonusTextBox);
            this.Controls.Add(this.productComboBox);
            this.Controls.Add(this.customerComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.closeDatePicker);
            this.Name = "CreateSalesRecordForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "新增成交紀錄";
            ((System.ComponentModel.ISupportInitialize)(this.customerVMBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productVMBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker closeDatePicker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox customerComboBox;
        private System.Windows.Forms.ComboBox productComboBox;
        private System.Windows.Forms.TextBox bonusTextBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.BindingSource customerVMBindingSource;
        private System.Windows.Forms.BindingSource productVMBindingSource;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}