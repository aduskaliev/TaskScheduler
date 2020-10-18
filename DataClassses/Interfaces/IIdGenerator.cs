using System.Collections.Generic;

namespace SharedClasses.Interfaces
{
    public interface IIdGenerator
    {
        int? GenerateId<DataType>(List<DataType> dataList)
           where DataType : IIdentifiable;
    }
}
