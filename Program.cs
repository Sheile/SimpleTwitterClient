using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TwitterClient
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static int Main(string[] args)
        {
            if (args.Length == 0) return 1;
            if (args[0] == "--config")
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Config());
            }
            else
            {
                Twitter twitter = Twitter.Load(Properties.Settings.Default.SettingFilePath);
                if (twitter == null) return 1;
                try
                {
                    twitter.PostTweet(args[0]);
                }
                catch (Exception)
                {
                    return 1;
                }
            }
            return 0;
        }
    }
}
