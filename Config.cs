using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace TwitterClient
{
    public partial class Config : Form
    {
        private const string CONSUMER_KEY = "CHANGEME:Change to your consumer key.";
        private const string CONSUMER_SECRET = "CHANGEME:Change to your consumer secret";
        private Twitter twitter = new Twitter(CONSUMER_KEY, CONSUMER_SECRET);

        public Config()
        {
            InitializeComponent();
            UpdateButtonStatus();

            Browser.Navigate(twitter.GetAuthorizeUrl());
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AuthorizeButton_Click(object sender, EventArgs e)
        {
            string secretNumber = SecretNumber.Text.Trim();
            if (twitter.GetAccessToken(secretNumber))
            {
                MessageBox.Show("認証に成功しました。", "認証結果", MessageBoxButtons.OK, MessageBoxIcon.Information);
                twitter.Save(Properties.Settings.Default.SettingFilePath);
                this.Close();
            }
            else
            {
                MessageBox.Show("認証に失敗しました。", "認証結果", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SecretNumber_TextChanged(object sender, EventArgs e)
        {
            UpdateButtonStatus();
        }

        private void UpdateButtonStatus()
        {
            AuthorizeButton.Enabled = SecretNumber.Text != "";
        }

        private void Config_Load(object sender, EventArgs e)
        {

        }

        private void Browser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            if (e.Url.AbsoluteUri == "https://twitter.com/oauth/authorize")
            {
                SecretNumber.Enabled = true;
                Description2.Enabled = true;
                SecretNumberLabel.Enabled = true;
            }
        }
    }
}
