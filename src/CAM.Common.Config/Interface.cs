using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAM.Common.Config
{
    public interface IConfig<TConfigType> where TConfigType : class, new()
    {
        void updateConfig(TConfigType ConfigObject);
        TConfigType ConfigObject { get; }
        string ConfigName { get; }

    }
}
