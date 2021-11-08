using IniParser;
using IniParser.Model;
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
        IniData data;

        public void Init()
        {
            FileIniDataParser parser = new();
            try
            {
                if (!File.Exists(Globals.INI_FILE_NAME) )
                {
                    GenerateDefaultIni(parser);
                }
                data = parser.ReadFile(Globals.INI_FILE_NAME);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Cannot open INI file");
            }
        }
        private static void GenerateDefaultIni(FileIniDataParser parser)
        {
            IniData ini = new();
            ini["UI"]["Language"] = DEFAULT_UI_LANGUAGE;
            ini["UI"]["DateFormat"] = DEFAULT_UI_DATEFORMAT;
            ini["UI"]["NumberFormat"] = DEFAULT_UI_NUMBERFORMAT;
            ini["UI"]["TreeAccountFontSize"] = DEFAULT_UI_TREEACCOUNTFONTSIZE;
            ini["UI"]["FontSize"] = DEFAULT_UI_FONTSIZE;
            ini["UI"]["AccountSummaryHeaderBackColor"] = DEFAULT_UI_AccountSummaryHeaderBackColor;
            parser.WriteFile(Globals.INI_FILE_NAME, ini);
        }

        public string GetDbPath()
        {
            string dbPath = data["DB"]["DB_PATH"];
            return dbPath;
        }
        public string GetLanguage()
        {
            this.Init();
            string language = data["UI"]["Language"];
            return language ?? DEFAULT_UI_LANGUAGE;
        }
        public string GetDateFormat()
        {
            this.Init();
            string dateFormat = data["UI"]["DateFormat"];
            return dateFormat ?? DEFAULT_UI_DATEFORMAT;
        }
        public string GetNumberFormat()
        {
            this.Init();
            string numberFormat = data["UI"]["NumberFormat"];
            return numberFormat ?? DEFAULT_UI_NUMBERFORMAT;
        }
        public int GetTreeAccountFontSize()
        {
            this.Init();
            String treeAccountFontSize = data["UI"]["TreeAccountFontSize"];
            return Convert.ToInt32(treeAccountFontSize ?? DEFAULT_UI_TREEACCOUNTFONTSIZE);
        }
        public int GetFontSize()
        {
            this.Init();
            String fontSize = data["UI"]["FontSize"];
            return Convert.ToInt32(fontSize ?? DEFAULT_UI_FONTSIZE);
        }
        public Color GetAccountSummaryHeaderBackColor()
        {
            this.Init();
            String backColor = data["UI"]["AccountSummaryHeaderBackColor"];
            return Color.FromName(backColor ?? DEFAULT_UI_AccountSummaryHeaderBackColor);
        }
    }
}
