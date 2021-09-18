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
            string language = data["UI"]["Language"];
            return language;
        }

    }
}
