namespace DoubleUnderline
{
    partial class DoubleUnderLineForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnQuest = new System.Windows.Forms.Button();
            this.tbxQuest = new System.Windows.Forms.TextBox();
            this.tbxAnswer = new System.Windows.Forms.TextBox();
            this.btnAnswer = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.ofdQuest = new System.Windows.Forms.OpenFileDialog();
            this.ofdAnswer = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // btnQuest
            // 
            this.btnQuest.Location = new System.Drawing.Point(384, 12);
            this.btnQuest.Name = "btnQuest";
            this.btnQuest.Size = new System.Drawing.Size(110, 22);
            this.btnQuest.TabIndex = 0;
            this.btnQuest.Text = "Load Quest";
            this.btnQuest.UseVisualStyleBackColor = true;
            this.btnQuest.Click += new System.EventHandler(this.btnQuest_Click);
            // 
            // tbxQuest
            // 
            this.tbxQuest.Location = new System.Drawing.Point(12, 12);
            this.tbxQuest.Name = "tbxQuest";
            this.tbxQuest.Size = new System.Drawing.Size(351, 22);
            this.tbxQuest.TabIndex = 1;
            // 
            // tbxAnswer
            // 
            this.tbxAnswer.Location = new System.Drawing.Point(12, 52);
            this.tbxAnswer.Name = "tbxAnswer";
            this.tbxAnswer.Size = new System.Drawing.Size(351, 22);
            this.tbxAnswer.TabIndex = 3;
            // 
            // btnAnswer
            // 
            this.btnAnswer.Location = new System.Drawing.Point(384, 52);
            this.btnAnswer.Name = "btnAnswer";
            this.btnAnswer.Size = new System.Drawing.Size(110, 22);
            this.btnAnswer.TabIndex = 2;
            this.btnAnswer.Text = "Load Answer";
            this.btnAnswer.UseVisualStyleBackColor = true;
            this.btnAnswer.Click += new System.EventHandler(this.btnAnswer_Click);
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(12, 100);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(110, 22);
            this.btnRun.TabIndex = 4;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // ofdQuest
            // 
            this.ofdQuest.FileName = "openFileDialog1";
            // 
            // ofdAnswer
            // 
            this.ofdAnswer.FileName = "openFileDialog1";
            // 
            // DoubleUnderLineForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 144);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.tbxAnswer);
            this.Controls.Add(this.btnAnswer);
            this.Controls.Add(this.tbxQuest);
            this.Controls.Add(this.btnQuest);
            this.Name = "DoubleUnderLineForm";
            this.Text = "Double Under Line";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnQuest;
        private System.Windows.Forms.TextBox tbxQuest;
        private System.Windows.Forms.TextBox tbxAnswer;
        private System.Windows.Forms.Button btnAnswer;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.OpenFileDialog ofdQuest;
        private System.Windows.Forms.OpenFileDialog ofdAnswer;
    }
}

