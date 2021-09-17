using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IniParser;
using IniParser.Model;

namespace hMoney
{
    public class Configuration
    {
        Globals gg = new Globals();
        IniData data;

        public void Init()
        {
            var parser = new FileIniDataParser();
            data = parser.ReadFile("hMoney.ini");
        }

        public string GetDbPath ()
        {
            string dbPath = data["DB"]["DB_PATH"];

            return dbPath;
        }


    }
}
