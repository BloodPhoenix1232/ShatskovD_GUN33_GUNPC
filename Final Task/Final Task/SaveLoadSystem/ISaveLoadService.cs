namespace Final_Task.SaveLoadSystem
{
    public interface ISaveLoadService<T>
    {
        void SaveData<T>(T data, string pathToFile);

        T LoadData<T>(string pathToFile);

    }
}
