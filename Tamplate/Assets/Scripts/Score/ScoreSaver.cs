using System.IO;
using UnityEngine;


public class ScoreSaver
{
    public static ScoreSaver Instance = new ScoreSaver();

    private string _path;
    private int _record;
    //private RecordsPanel _recordPanel;

    public ScoreSaver()
    { 
        //_path = Path.Combine(Application.persistentDataPath, "/SaveData.json");
    }

    public void SaveRecord(int score)
    {
        if (score >= _record)
        {
            _record = score;
        }

        PlayerPrefs.SetInt("Record", _record);

        ////_record = JsonUtility.FromJson<int>(File.ReadAllText(_path));
        //File.WriteAllText(_path, JsonUtility.ToJson(_record));
    }

    public int LoadScore()
    {
        _record = PlayerPrefs.GetInt("Record", 0);
        return _record;
    }

//    public static int highScore;
//    public static int[] stars = new int[5];

//    public static void Save()
//    {
//        BinaryFormatter bf = new BinaryFormatter();
//        FileStream file = File.Create(Application.persistentDataPath + "/savedGame.gd");
//        SaveData data = new SaveData();
//        data.highScore = highScore;
//        data.stars = stars;
//        bf.Serialize(file, data);
//        file.Close();
//    }

//    public static void Load()
//    {
//        if (File.Exists(Application.persistentDataPath + "/savedGame.gd"))
//        {
//            BinaryFormatter bf = new BinaryFormatter();
//            FileStream file = File.Open(Application.persistentDataPath + "/savedGame.gd", FileMode.Open);
//            SaveData data = (SaveData)bf.Deserialize(file);
//            highScore = data.highScore;
//            stars = data.stars;
//            file.Close();
//        }
//    }
//}


//[Serializable]
//class SaveData //можно записывать разные виды данных
//{
//    public int highScore;
//    public int[] stars = new int[5];
//}

}