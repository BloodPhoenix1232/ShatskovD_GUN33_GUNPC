namespace Final_Task.SaveLoadSystem
{
    internal class FileSystemSaveLoadService : ISaveLoadService<string>
    {
        public FileSystemSaveLoadService(string pathToFile)
        {
            if (File.Exists(pathToFile))
            {
                var data = LoadData<string>(pathToFile);
            }
            else
            {
                Console.Write("Введите ваше имя: ");
                var name = Console.ReadLine();
                SaveData($"{name} 50000", pathToFile);
            }
        }


        public void SaveData<T>(T data, string pathToFile)
        {
            using (StreamWriter writeStream = File.CreateText(pathToFile))
            {
                writeStream.Write(data);
            }
        }

        public T LoadData<T>(string pathToFile)
        {
            var fileContent = File.ReadAllText(pathToFile);

            try
            {
                if (typeof(T) == typeof(string))
                {
                    return (T)(object)fileContent;
                }

                throw new InvalidOperationException("Ошибка чтения.");
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.ToString());
            }
        }
    }
}
