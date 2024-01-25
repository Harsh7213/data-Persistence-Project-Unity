using UnityEngine;
using System.IO;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public float highScore;
    public string playerName;
    public string currentName;
    private void Awake(){
        if(instance != null){
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    [System.Serializable] class SaveData{
        public string playerName;
        public float score;
    }
    public void SaveScore(){
        SaveData data = new SaveData();
        data.playerName = playerName;
        data.score = highScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScore = data.score;
            playerName = data.playerName;
        }
    }

    public void DeleteScore()
    {
        // Specify the file path
        string filePath = Application.persistentDataPath + "/savefile.json";

        // Check if the file exists before attempting to delete it
        if (File.Exists(filePath))
        {
            // Delete the file
            File.Delete(filePath);

            Debug.Log("Save file deleted successfully.");
        }
        else
        {
            Debug.LogWarning("Save file does not exist.");
        }

        highScore = 0;
        playerName = "NoName";
    }
}

