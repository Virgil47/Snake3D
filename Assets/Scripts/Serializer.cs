using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

public class Profile
{
    public string Name { get; set; }
    public int Score { get; set; }
}
public class Serializer
{
    public string path;
    public string serialize;
    /// <summary>
    /// Конструктор, создающий папку в которой будет файл json с игровыми профилями.
    /// </summary>
    public Serializer()
    {
        path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        path = Path.Combine(path, "Snake");
        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);
        path = Path.Combine(path, "settings.json");
        if (!File.Exists(path))
        {
            var myFile = File.Create(path);
            myFile.Close();
        }
    }
    /// <summary>
    /// Метод записывающий новые  профили в  файл с профилями.
    /// </summary>
    /// <param name="name">имя пользователя</param>
    /// <param name="score">очки пользователя на момент окончания игры (победы или смерти)</param>
    public void Write(string name, int score)
    {
        var readSettings = File.ReadAllText(path);
        var profile = new Profile(); 
        profile.Name = name; 
        profile.Score = score;

        if (string.IsNullOrEmpty(readSettings)) //проверяем, если созданый  файл не Null и не пустой, тогда просто добавляем в лист профиль сериализуем и записываем.
        {
            var list = new List<Profile>() { profile };
            serialize = JsonConvert.SerializeObject(list);
            File.WriteAllText(path, serialize);
        }
        else // если нет - десериализуем, в лист (потому что сериализовали лист) добавляем в этот лист новый профиль, сериализуем и записываем в файл.
        {
            var profiles = JsonConvert.DeserializeObject<List<Profile>>(readSettings);
            profiles.Add(profile);
            serialize = JsonConvert.SerializeObject(profiles);
            File.WriteAllText(path, serialize);
        }
    }
}
