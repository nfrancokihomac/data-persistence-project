using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    public new string name;
    public int score;
    
    private void Awake() {
        if(gameManager != null) {
            Destroy(gameObject);
            return;
        }

        gameManager = this;
        DontDestroyOnLoad(gameObject);

        LoadScore();
    }

    public void SaveScore(){
        SaveData data = new SaveData();
        data.name = name;
        data.score = score;

        string json = JsonUtility.ToJson(data);
        string path = Application.persistentDataPath + "/savefile.json";
        
        File.WriteAllText(path, json);
    }

    public void LoadScore(){
        string path = Application.persistentDataPath + "/savefile.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            name = data.name;
            score = data.score;
        }
    }

    [System.Serializable]
    class SaveData
    { 
        public string name;
        public int score;
    }
}
