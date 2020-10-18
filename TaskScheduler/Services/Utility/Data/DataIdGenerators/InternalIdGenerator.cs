using System.Collections.Generic;
using System.Linq;
using SharedClasses.Interfaces;

namespace TaskScheduler.Services.Utility.Data
{
    class InternalIdGenerator : IIdGenerator
    {
        public int? GenerateId<DataType>(List<DataType> dataList)
            where DataType : IIdentifiable
        {
            return dataList.Max(el => el.Id) + 1;
        }
    }
}
