using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveLoadManager : MonoBehaviour // Skorumuz, en yüksek skorumuz ve oyuncumuzun bilgilerini dosyaya kaydetme ve dosyadan yükleme.
{
    public static int decisior; // Static bir decisior'ımız karar verme işlemi yapıyor.

    public static void Save(string path, GameData gameData)
    {
        using (var fs = new FileStream(path, FileMode.OpenOrCreate))
        {
            var formatter = new BinaryFormatter();
            formatter.Serialize(fs, gameData);
        }
    }
    public static GameData Load(string path)
    {
        using (var fs = new FileStream(path, FileMode.Open))
        {
            var formatter = new BinaryFormatter();
            return (GameData)formatter.Deserialize(fs);
        }
    }
}
