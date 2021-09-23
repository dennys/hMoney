using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IniParser;
using IniParser.Model;

namespace hMoney
{
    public class Configuration
    {
        IniData data;

        public void Init()
        {
            var parser = new FileIniDataParser();
            try
            {
                data = parser.ReadFile(Globals.INI_FILE_NAME);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Cannot open INI file");
            }
            
        }

        public string GetDbPath ()
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
        public string GetTreeAccountFontSize()
        {
            this.Init();
            string treeAccountFontSize = data["UI"]["TreeAccountFontSize"];
            return treeAccountFontSize;
        }
    }
}
