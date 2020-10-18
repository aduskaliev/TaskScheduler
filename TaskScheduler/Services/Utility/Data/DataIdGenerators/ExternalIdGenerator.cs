using SharedClasses.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaskScheduler.Services.Utility.Data
{
    class ExternalIdGenerator : IIdGenerator
    {
        public int? GenerateId<DataType>(List<DataType> dataList)
            where DataType : IIdentifiable
        {
            return null;
        }
    }
}
