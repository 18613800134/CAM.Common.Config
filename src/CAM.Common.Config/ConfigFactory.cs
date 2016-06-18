using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAM.Common.Config
{
    public enum ENUM_Cam_Config_Type
    {
        ecct_fileio_string,
    }

    public class ConfigFactory
    {

        public static IConfig<TConfigType> createConfig<TConfigType>(string ConfigName)
            where TConfigType : class, new()
        {
            return createConfig<TConfigType>(ConfigName, ENUM_Cam_Config_Type.ecct_fileio_string);
        }

        public static IConfig<TConfigType> createConfig<TConfigType>(string ConfigName, ENUM_Cam_Config_Type ecct)
            where TConfigType : class, new()
        {
            IConfig<TConfigType> ic = null;
            switch (ecct)
            {
                case ENUM_Cam_Config_Type.ecct_fileio_string:
                    ic = createFileIOStringConfig<TConfigType>(ConfigName);
                    break;
            }

            return ic;
        }


        public static IConfig<TConfigType> createFileIOStringConfig<TConfigType>(string ConfigName)
            where TConfigType : class, new()
        {
            IConfig<TConfigType> ic = new Config_FileIO_String<TConfigType>(ConfigName);
            return ic;
        }
    }
}
