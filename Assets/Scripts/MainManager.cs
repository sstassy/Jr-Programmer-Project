using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class MainManager : MonoBehaviour
{
    public static MainManager Instance;

    public Color TeamColor; // new variable declared

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        LoadColor();
    }

    [System.Serializable]
    class SaveData
    {
        public Color TeamColor;
    }
    

        public void SaveColor()
        {
            SaveData data = new SaveData();
            data.TeamColor = TeamColor;

            string json = JsonUtility.ToJson(data);

            File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        }

        public void LoadColor()
        {
            string path = Application.persistentDataPath + "/savefile.json";
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                SaveData data = JsonUtility.FromJson<SaveData>(json);

                TeamColor = data.TeamColor;
            }
        }
    
}
