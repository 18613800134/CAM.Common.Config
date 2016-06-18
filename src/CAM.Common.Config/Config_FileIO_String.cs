using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CAM.Common.DiskOperation.File;
using Newtonsoft.Json;

namespace CAM.Common.Config
{
    public class Config_FileIO_String<TConfigType> : IConfig<TConfigType>
        where TConfigType : class, new()
    {

        private TConfigType _configObject = null;
        private string _configName = "";

        public Config_FileIO_String(string ConfigName)
        {
            _configName = ConfigName;
            string configFilePath = formatConfigFileWithPath();

            IFileIO<string> io = FileFactory.createStringFileIO();
            string configFileContent = io.readFile(configFilePath);

            if (string.IsNullOrWhiteSpace(configFileContent))
            {
                _configObject = new TConfigType();
                updateConfig(_configObject);
            }
            else
            {
                _configObject = JsonConvert.DeserializeObject<TConfigType>(configFileContent);
            }
        }

        private string formatConfigFileWithPath()
        {
            string configFilePath = string.Format("/CAM_WEB_CONFIG/{0}.config", ConfigName);
            return configFilePath;
        }

        public void updateConfig(TConfigType ConfigObject)
        {
            _configObject = ConfigObject;
            string configFileContent = JsonConvert.SerializeObject(ConfigObject);

            string configFilePath = formatConfigFileWithPath();

            IFileIO<string> io = FileFactory.createStringFileIO();
            io.writeFile(configFilePath, configFileContent);

        }

        public TConfigType ConfigObject
        {
            get
            {
                return _configObject;
            }
        }


        public string ConfigName
        {
            get { return _configName; }
        }
    }

}
