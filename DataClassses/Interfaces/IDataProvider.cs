

namespace SharedClasses.Interfaces
{
    public interface IDataProvider
    {
        object LoadData();
        void SaveData(object data);
    }
}
