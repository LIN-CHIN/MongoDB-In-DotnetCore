using System;
using System.Collections.Generic;
using System.Text;

namespace Model.ConfigModel
{
    public class MongoDbSettingModel
    {
        public string ConnectionString { get; private set; }
        public string DatabaseName { get; private set; }
    }
}
