using System;
using System.Collections.Generic;

namespace TaskSchedulerDataHandler.Services.Utility
{
    internal class JSONDataConverter : IDataConverter
    {
        public Dictionary<Type, List<object>> ConvertFromStorageType(object data)
        {
            return (Dictionary<Type, List<object>>)data;
        }

        public object ConvertToStorageType(Dictionary<Type, List<object>> data)
        {
            return (object)data;
        }
    }
}
