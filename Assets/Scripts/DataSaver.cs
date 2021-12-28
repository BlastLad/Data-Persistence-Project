using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class DataSaver : MonoBehaviour
{
    public static DataSaver Instance { get; private set; }
    public int high_score;
    public string playerName;
    PlayerData playerData;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
        LoadData();
    }

    public void UpdateName(string name)
    {
        playerName = name;
        Debug.Log(playerName);
    }

    public void SaveData(int m_Points, string playerName)
    {
        if (m_Points > high_score)
        {

            playerData = new PlayerData();
            playerData.highScore = m_Points;

            string json = JsonUtility.ToJson(playerData);

            File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        }
    }


    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);

            PlayerData data = JsonUtility.FromJson<PlayerData>(json);


            high_score = data.highScore;
        }
    }
}

[System.Serializable]
class PlayerData
{
    public int highScore = 0;

}