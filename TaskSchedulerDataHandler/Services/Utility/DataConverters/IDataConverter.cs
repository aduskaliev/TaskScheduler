using System;
using System.Collections.Generic;

namespace TaskSchedulerDataHandler.Services.Utility
{
    internal interface IDataConverter
    {
        Dictionary<Type, List<object>> ConvertFromStorageType(object data);
        object ConvertToStorageType(Dictionary<Type, List<object>> data);
    }
}
