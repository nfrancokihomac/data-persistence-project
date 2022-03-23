using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    public string nameHighScore;
    public string nameCurrent;
    public int highScore;
    
    private void Awake() {
        if(gameManager != null) {
            Destroy(gameObject);
            return;
        }

        gameManager = this;
        DontDestroyOnLoad(gameObject);

        Load();
    }

    public void Save(){
        SaveData data = new SaveData();
        data.nameHighScore = nameHighScore;
        data.nameCurrent = nameCurrent;
        data.highScore = highScore;

        string json = JsonUtility.ToJson(data);
        string path = Application.persistentDataPath + "/savefile.json";
        
        File.WriteAllText(path, json);
    }

    public void Load(){
        string path = Application.persistentDataPath + "/savefile.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            nameHighScore = data.nameHighScore;
            nameCurrent = data.nameCurrent;
            highScore = data.highScore;
        }
    }

    [System.Serializable]
    class SaveData
    { 
        public string nameHighScore;
        public string nameCurrent;
        public int highScore;
    }
}
