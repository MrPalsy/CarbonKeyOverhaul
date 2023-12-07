namespace CarbonKeyOverhaul
{
    partial class invoiceDataForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(invoiceDataForm));
            dataGridInvoiceData = new DataGridView();
            suggestRuleBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridInvoiceData).BeginInit();
            SuspendLayout();
            // 
            // dataGridInvoiceData
            // 
            dataGridInvoiceData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridInvoiceData.Location = new Point(-1, 0);
            dataGridInvoiceData.Name = "dataGridInvoiceData";
            dataGridInvoiceData.RowTemplate.Height = 25;
            dataGridInvoiceData.Size = new Size(802, 346);
            dataGridInvoiceData.TabIndex = 0;
            // 
            // suggestRuleBtn
            // 
            suggestRuleBtn.Location = new Point(690, 399);
            suggestRuleBtn.Name = "suggestRuleBtn";
            suggestRuleBtn.Size = new Size(89, 23);
            suggestRuleBtn.TabIndex = 1;
            suggestRuleBtn.Text = "Suggest Rule";
            suggestRuleBtn.UseVisualStyleBackColor = true;
            suggestRuleBtn.Click += suggestRuleBtn_Click;
            // 
            // invoiceDataForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(67, 176, 42);
            ClientSize = new Size(800, 450);
            Controls.Add(suggestRuleBtn);
            Controls.Add(dataGridInvoiceData);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "invoiceDataForm";
            ((System.ComponentModel.ISupportInitialize)dataGridInvoiceData).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridInvoiceData;
        private Button suggestRuleBtn;
    }
}