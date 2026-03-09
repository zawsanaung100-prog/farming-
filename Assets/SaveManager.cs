using UnityEngine;
using System.IO;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;
    private string savePath;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        savePath = Application.persistentDataPath + "/savefile.json";
    }

    public void SaveGame(Transform player)
    {
        SaveData data = new SaveData();

        data.playerX = player.position.x;
        data.playerY = player.position.y;

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(savePath, json);

        Debug.Log("Game Saved!");
        Debug.Log("Saved at: " + savePath);
    }

    public SaveData LoadGame()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            Debug.Log("Game Loaded!");
            return data;
        }
        else
        {
            Debug.Log("No save file found.");
            return null;
        }
    }
}