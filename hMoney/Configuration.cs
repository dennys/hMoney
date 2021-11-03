using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace hMoney
{
    public class Configuration
    {
        const String DEFAULT_UI_LANGUAGE = "en";
        const String DEFAULT_UI_DATEFORMAT = "yyyy/mm/dd";
        const String DEFAULT_UI_NUMBERFORMAT = "n2";
        const String DEFAULT_UI_TREEACCOUNTFONTSIZE = "12";
        const String DEFAULT_UI_FONTSIZE = "12";
        const String DEFAULT_UI_AccountSummaryHeaderBackColor = "Color.Cornsilk";

        private static readonly NLog.Logger Log = NLog.LogManager.GetCurrentClassLogger();
        private IConfigurationRoot configRoot;

        public void Init()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddIniFile("hMoney.ini", optional: false, reloadOnChange: true);
            //.AddJsonFile("appsettings.json", true);   // 讀取appsettings.json檔案

            configRoot = builder.Build();
            Log.Debug("DB_PATH = " + configRoot["DB:DB_PATH"]);
            Log.Debug("UI = " + configRoot["UI:Language"]);

        }
        private static void GenerateDefaultIni()
        {
            //ini["UI:Language"] = DEFAULT_UI_LANGUAGE;
            //ini["UI:DateFormat"] = DEFAULT_UI_DATEFORMAT;
            //ini["UI:NumberFormat"] = DEFAULT_UI_NUMBERFORMAT;
            //ini["UI:TreeAccountFontSize"] = DEFAULT_UI_TREEACCOUNTFONTSIZE;
            //ini["UI:FontSize"] = DEFAULT_UI_FONTSIZE;
            //ini["UI:AccountSummaryHeaderBackColor"] = DEFAULT_UI_AccountSummaryHeaderBackColor;
        }

        public string GetDbPath()
        {
            string dbPath = configRoot["DB:DB_PATH"];
            return dbPath;
        }
        public string GetLanguage()
        {
            this.Init();
            string language = configRoot["UI:Language"];
            return language ?? DEFAULT_UI_LANGUAGE;
        }
        public string GetDateFormat()
        {
            this.Init();
            string dateFormat = configRoot["UI:DateFormat"];
            return dateFormat ?? DEFAULT_UI_DATEFORMAT;
        }
        public string GetNumberFormat()
        {
            this.Init();
            string numberFormat = configRoot["UI:NumberFormat"];
            return numberFormat ?? DEFAULT_UI_NUMBERFORMAT;
        }
        public int GetTreeAccountFontSize()
        {
            this.Init();
            String treeAccountFontSize = configRoot["UI:TreeAccountFontSize"];
            return Convert.ToInt32(treeAccountFontSize ?? DEFAULT_UI_TREEACCOUNTFONTSIZE);
        }
        public int GetFontSize()
        {
            this.Init();
            String fontSize = configRoot["UI:FontSize"];
            return Convert.ToInt32(fontSize ?? DEFAULT_UI_FONTSIZE);
        }
        public Color GetAccountSummaryHeaderBackColor()
        {
            this.Init();
            String backColor = configRoot["UI:AccountSummaryHeaderBackColor"];
            return Color.FromName(backColor ?? DEFAULT_UI_AccountSummaryHeaderBackColor);
        }
    }
}
