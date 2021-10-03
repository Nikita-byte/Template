using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    public static int highScore;
    public static int[] stars = new int[5];

    public static void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/savedGame.gd");
        SaveData data = new SaveData();
        data.highScore = highScore;
        data.stars = stars;
        bf.Serialize(file, data);
        file.Close();
    }

    public static void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/savedGame.gd"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/savedGame.gd", FileMode.Open);
            SaveData data = (SaveData)bf.Deserialize(file);
            highScore = data.highScore;
            stars = data.stars;
            file.Close();
        }
    }
}

public void ShakeCamera()
{
    Tweener tweener = DOTween.Shake(() => _camera.transform.position, pos => _camera.transform.position = pos,
            0.5f, 1, 15, 90, false);
}

[Serializable]
class SaveData //можно записывать разные виды данных
{
    public int highScore;
    public int[] stars = new int[5];
}
