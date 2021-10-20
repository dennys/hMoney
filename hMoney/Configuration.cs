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
        IniData data;

        public void Init()
        {
            FileIniDataParser parser = new FileIniDataParser();
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
        private void GenerateDefaultIni(FileIniDataParser parser)
        {
            IniData ini = new IniData();
            ini["UI"]["Language"] = "en";
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
            return language;
        }
        public string GetDateFormat()
        {
            this.Init();
            string dateFormat = data["UI"]["DateFormat"];
            return dateFormat;
        }
        public string GetNumberFormat()
        {
            this.Init();
            string numberFormat = data["UI"]["NumberFormat"];
            return numberFormat;
        }
        public int GetTreeAccountFontSize()
        {
            this.Init();
            int treeAccountFontSize = Convert.ToInt32(data["UI"]["TreeAccountFontSize"]);
            return treeAccountFontSize;
        }
        public int GetFontSize()
        {
            this.Init();
            int fontSize = Convert.ToInt32(data["UI"]["FontSize"]);
            return fontSize;
        }
        public Color GetAccountSummaryHeaderBackColor()
        {
            this.Init();
            Color backColor = Color.FromName(data["UI"]["AccountSummaryHeaderBackColor"]);
            return backColor;
        }
    }
}
