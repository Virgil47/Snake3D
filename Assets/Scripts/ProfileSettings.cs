namespace Assets.Scripts
{
    public class ProfileSettings
    {
        public string Name { get; set; }
    }
    /// <summary>
    /// Статический класс, как обертка (примерная реализация паттерна singletone) над классом ProfileSettings. Этот класс нужен для того, чтобы он всегда
    /// возвращал единственный экземпляр класса ProfileSettings. В этом классе хранится имя пользователя.
    /// </summary>
    public static class ProfileSettingsLoader
    {
        private static ProfileSettings instance;

        /// <summary>
        /// Этот метод возвращает единственный экземпляр класса ProfileSettings. Если instance пустой, то мы создаем новый экземпляр класса ProfilSettings, 
        /// если не пустой, то возвращает существующий.
        /// </summary>
        /// <returns></returns>
        public static ProfileSettings Get()
        {
            if (instance == null)
            {
                instance = new ProfileSettings();
            }
            return instance;
        }
        /// <summary>
        ///Метод нужен для записи имени нового пользователя и перезаписи старого.
        /// </summary>
        /// <param name="name">имя пользователя</param>
        public static void SetName(string name)
        {
            Get();
            if (!string.IsNullOrEmpty(instance.Name) && instance.Name != name)
            {
                instance = null;
                Get();
            }
            instance.Name = name;
        }
    }
}
