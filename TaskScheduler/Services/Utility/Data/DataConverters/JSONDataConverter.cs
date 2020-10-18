using System;
using System.Collections.Generic;
using SharedClasses.Interfaces;

namespace TaskScheduler.Services.Utility.Data
{
    internal class JSONDataConverter : IDataConverter
    {
        public DataType ConvertFromStorageType<DataType>(object data)
        {            
            Dictionary<Type, object> dictData = (Dictionary<Type, object>)data;
            return (DataType) dictData[typeof(DataType)];
        }

        public object ConvertToStorageType<DataType>(object data, DataType newData)
        {
            Dictionary<Type, object> dictData = (Dictionary<Type, object>)data;
            dictData[typeof(DataType)] = newData;
            return (object)dictData;
        }
    }
}
