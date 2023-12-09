namespace CarbonKeyOverhaul
{
    partial class RuleSuggestionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RuleSuggestionForm));
            SuggestedRuleTb = new RichTextBox();
            label1 = new Label();
            label2 = new Label();
            InputTb = new TextBox();
            SuggestBtn = new Button();
            SuspendLayout();
            // 
            // SuggestedRuleTb
            // 
            SuggestedRuleTb.Location = new Point(12, 221);
            SuggestedRuleTb.Name = "SuggestedRuleTb";
            SuggestedRuleTb.Size = new Size(330, 96);
            SuggestedRuleTb.TabIndex = 1;
            SuggestedRuleTb.Text = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 187);
            label1.Name = "label1";
            label1.Size = new Size(94, 15);
            label1.TabIndex = 2;
            label1.Text = "Suggested Rule :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 72);
            label2.Name = "label2";
            label2.Size = new Size(67, 15);
            label2.TabIndex = 4;
            label2.Text = "User Input :";
            // 
            // InputTb
            // 
            InputTb.Location = new Point(12, 105);
            InputTb.Name = "InputTb";
            InputTb.Size = new Size(173, 23);
            InputTb.TabIndex = 5;
            // 
            // SuggestBtn
            // 
            SuggestBtn.Location = new Point(267, 105);
            SuggestBtn.Name = "SuggestBtn";
            SuggestBtn.Size = new Size(75, 23);
            SuggestBtn.TabIndex = 6;
            SuggestBtn.Text = "Suggest";
            SuggestBtn.UseVisualStyleBackColor = true;
            SuggestBtn.Click += SuggestBtn_Click;
            // 
            // RuleSuggestionForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(67, 176, 42);
            ClientSize = new Size(379, 368);
            Controls.Add(SuggestBtn);
            Controls.Add(InputTb);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(SuggestedRuleTb);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "RuleSuggestionForm";
            Text = "RuleSuggestionForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private RichTextBox SuggestedRuleTb;
        private Label label1;
        private Label label2;
        private TextBox InputTb;
        private Button SuggestBtn;
    }
}