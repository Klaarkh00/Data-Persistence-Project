using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public string CurrentPlayerName;
    public string BestPlayer;
    public int Highscore;
    private void Awake()
    {
        if(Instance!=null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadGameData();
    }

    public void NewHighscore(int score)
    {
        BestPlayer = CurrentPlayerName;
        Highscore = score;
    }
    public void SetCurrentPlayer(string playerName)
    {
        CurrentPlayerName = playerName;
    }

    [System.Serializable]
    class SaveData
    {
        public string bestPlayer;
        public string lastPlayer;
        public int highscore;
    }

    public void SaveGame()
    {
        SaveData data = new SaveData();

        data.bestPlayer = BestPlayer;
        data.lastPlayer = CurrentPlayerName;
        data.highscore = Highscore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadGameData()
    {
        if (File.Exists(Application.persistentDataPath + "/savefile.json"))
        {
            string json = File.ReadAllText(Application.persistentDataPath + "/savefile.json");
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            BestPlayer = data.bestPlayer;
            CurrentPlayerName = data.lastPlayer;
            Highscore = data.highscore;
        }
    }
}
