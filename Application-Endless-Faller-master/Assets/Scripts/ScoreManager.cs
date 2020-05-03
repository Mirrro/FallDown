using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static int currentScore;
    public static int highScore;
    // Start is called before the first frame update
    void Awake()
    {
        Load();
        currentScore = 0;
        //DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
    }
    public static void CheckNewHighscore()
    {
        if(currentScore > highScore)
        {
            highScore = currentScore;
            Save();
        }
    }

    public static void Save()
    {
        BinaryFormatter bF = new BinaryFormatter();
        scoreData data = new scoreData();
        data.highScore = highScore;
        if (!File.Exists(Application.persistentDataPath + "/highscore.dat"))
        {
            FileStream file = File.Create(Application.persistentDataPath + "/highscore.dat");
            bF.Serialize(file, data);
        }
        else
        {
            FileStream file = File.Open(Application.persistentDataPath + "/highscore.dat", FileMode.Open);
            bF.Serialize(file, data);
        }
    }

    public static void Load()
    {
        if(File.Exists(Application.persistentDataPath + "/highscore.dat"))
        {
            BinaryFormatter bF = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/highscore.dat", FileMode.Open);
            scoreData data = (scoreData)bF.Deserialize(file);
           highScore = data.highScore;

        }
    }
}
[System.Serializable]
class scoreData
{
    public int highScore;
}


