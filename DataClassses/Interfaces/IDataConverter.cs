

namespace SharedClasses.Interfaces
{
    public interface IDataConverter
    {
        DataType ConvertFromStorageType<DataType>(object data);
        object ConvertToStorageType<DataType>(object data, DataType newData);
    }
}
