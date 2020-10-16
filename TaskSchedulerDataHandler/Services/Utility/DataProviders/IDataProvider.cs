

namespace TaskSchedulerDataHandler.Services.Utility
{
    internal interface IDataProvider
    {
        object LoadData();
        void SaveData(object data);
    }
}
