using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public string CurrentPlayerName;
    public string BestPlayer;
    public string LastPlayer;
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
}
