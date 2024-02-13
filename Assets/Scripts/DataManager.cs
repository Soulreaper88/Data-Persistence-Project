using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;
    public string nameEnter;
    public int bestScore;
    public int score;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
        LoadBestScore();
        LoadName();
    }
   
    public void higherNumber()
    {
        if (score > bestScore)
        {
            bestScore = score;
        }
    }
    [System.Serializable]
    class SaveData
    {
        public string nome;
        public int bestScore;
    }
    public void SaveBestScore()
    {
        SaveData data = new SaveData();
        data.bestScore = bestScore;
        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadBestScore() 
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestScore = data.bestScore;
        }
    }
    public void SaveName()
    {
        SaveData data = new SaveData();
        data.nome = nameEnter;
        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savename.json", json);
    }
    public void LoadName()
    {
        string path = Application.persistentDataPath + "/savename.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            nameEnter = data.nome;
        }
    }
}
