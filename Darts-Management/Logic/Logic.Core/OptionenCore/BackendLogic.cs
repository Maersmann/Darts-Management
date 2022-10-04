using IniParser;
using IniParser.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darts.Logic.Core.OptionenCore
{
    public class BackendLogic
    {
        private static readonly string FILENAME = "conf.ini";

        private readonly FileIniDataParser parser;
        private IniData iniData;
        private readonly string iniPath;

        private string password;
        private string user;
        public BackendLogic()
        {
            password = "";
            iniPath = "";
            user = "";

            iniPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Dart-Management\\";
            if (!Directory.Exists(iniPath))
                Directory.CreateDirectory(iniPath);
            iniPath += FILENAME;
            parser = new FileIniDataParser();
        }

        public string GetPassword()
        { 
            return password;
        }

        public string GetUser()
        {
            return user;
        }

        public bool IstINIVorhanden()
        {
            return File.Exists(iniPath);
        }

        public void LoadData()
        {

            if (File.Exists(iniPath))
            {
                iniData = parser.ReadFile(iniPath);
                LoadBackendSettings();
            }
        }
        public void SaveData(string user, string password)
        {
            this.user = user;
            this.password = password;

            iniData = new IniData();
            iniData.Sections.AddSection("DB-Settings");

            iniData.Sections.GetSectionData("DB-Settings").Keys.AddKey("USER", user);
            iniData.Sections.GetSectionData("DB-Settings").Keys.AddKey("PASSWORD", password);

            parser.WriteFile(iniPath, iniData);
        }


        private void LoadBackendSettings()
        {
            if (IsFieldVorhanden("DB-Settings", "USER"))
                user = iniData.Sections["DB-Settings"].GetKeyData("USER").Value;
            if (IsFieldVorhanden("DB-Settings", "PASSWORD"))
                password = iniData.Sections["DB-Settings"].GetKeyData("PASSWORD").Value;
        }

        public bool IsFieldVorhanden(string section, string key)
        {
            return iniData.Sections[section].GetKeyData(key) != null;
        }
    }
}
