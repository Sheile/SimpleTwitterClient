namespace TwitterClient
{
    partial class Config
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.SecretNumberLabel = new System.Windows.Forms.Label();
            this.SecretNumber = new System.Windows.Forms.TextBox();
            this.AuthorizeButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.Browser = new System.Windows.Forms.WebBrowser();
            this.Description1 = new System.Windows.Forms.Label();
            this.Description2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SecretNumberLabel
            // 
            this.SecretNumberLabel.AutoSize = true;
            this.SecretNumberLabel.Enabled = false;
            this.SecretNumberLabel.Location = new System.Drawing.Point(32, 511);
            this.SecretNumberLabel.Name = "SecretNumberLabel";
            this.SecretNumberLabel.Size = new System.Drawing.Size(59, 12);
            this.SecretNumberLabel.TabIndex = 0;
            this.SecretNumberLabel.Text = "暗証番号：";
            // 
            // SecretNumber
            // 
            this.SecretNumber.Enabled = false;
            this.SecretNumber.Location = new System.Drawing.Point(91, 508);
            this.SecretNumber.Name = "SecretNumber";
            this.SecretNumber.Size = new System.Drawing.Size(176, 19);
            this.SecretNumber.TabIndex = 0;
            this.SecretNumber.TextChanged += new System.EventHandler(this.SecretNumber_TextChanged);
            // 
            // AuthorizeButton
            // 
            this.AuthorizeButton.Location = new System.Drawing.Point(705, 541);
            this.AuthorizeButton.Name = "AuthorizeButton";
            this.AuthorizeButton.Size = new System.Drawing.Size(83, 24);
            this.AuthorizeButton.TabIndex = 2;
            this.AuthorizeButton.Text = "OK";
            this.AuthorizeButton.UseVisualStyleBackColor = true;
            this.AuthorizeButton.Click += new System.EventHandler(this.AuthorizeButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CloseButton.Location = new System.Drawing.Point(794, 539);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(83, 24);
            this.CloseButton.TabIndex = 3;
            this.CloseButton.Text = "キャンセル";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // Browser
            // 
            this.Browser.Location = new System.Drawing.Point(28, 36);
            this.Browser.MinimumSize = new System.Drawing.Size(20, 20);
            this.Browser.Name = "Browser";
            this.Browser.Size = new System.Drawing.Size(849, 405);
            this.Browser.TabIndex = 6;
            this.Browser.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.Browser_Navigated);
            // 
            // Description1
            // 
            this.Description1.AutoSize = true;
            this.Description1.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Description1.Location = new System.Drawing.Point(12, 9);
            this.Description1.Name = "Description1";
            this.Description1.Size = new System.Drawing.Size(521, 16);
            this.Description1.TabIndex = 7;
            this.Description1.Text = "1. ユーザ名とパスワードを入力して【CHANGEME: Change to your application name】によるアクセスを許可して下さい。";
            // 
            // Description2
            // 
            this.Description2.AutoSize = true;
            this.Description2.Enabled = false;
            this.Description2.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Description2.Location = new System.Drawing.Point(12, 487);
            this.Description2.Name = "Description2";
            this.Description2.Size = new System.Drawing.Size(418, 16);
            this.Description2.TabIndex = 8;
            this.Description2.Text = "2. 表示された暗証番号を入力してOKボタンを押して下さい。";
            // 
            // Config
            // 
            this.AcceptButton = this.AuthorizeButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CloseButton;
            this.ClientSize = new System.Drawing.Size(898, 575);
            this.Controls.Add(this.Description2);
            this.Controls.Add(this.Description1);
            this.Controls.Add(this.Browser);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.AuthorizeButton);
            this.Controls.Add(this.SecretNumber);
            this.Controls.Add(this.SecretNumberLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Config";
            this.Text = "Twitter認証";
            this.Load += new System.EventHandler(this.Config_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label SecretNumberLabel;
        private System.Windows.Forms.TextBox SecretNumber;
        private System.Windows.Forms.Button AuthorizeButton;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.WebBrowser Browser;
        private System.Windows.Forms.Label Description1;
        private System.Windows.Forms.Label Description2;
    }
}

