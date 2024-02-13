using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;
    public string nameEnter;
    public string bestNameEnter;
    public int bestScore;

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
   
    
    [System.Serializable]
    class SaveData
    {
        public string nome;
        public string bestName;
        public int bestScore;
    }
    //  Save/Load the BestScore with name and points
    public void SaveBestScore()
    {
        SaveData data = new SaveData();
        data.bestScore = bestScore;
        data.bestName = bestNameEnter;
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
            bestNameEnter = data.bestName;
        }
    }
    //  Save/Load the input name at menu
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
