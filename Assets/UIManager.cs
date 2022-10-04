using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class UIManager : MonoBehaviour
{
    public InputField nameInput;
    // Start is called before the first frame update
    void Start()
    {
        nameInput.onEndEdit.AddListener(GameManager.Instance.SetCurrentPlayer);
        nameInput.text = GameManager.Instance.CurrentPlayerName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadScoreboard()
    {
        SceneManager.LoadScene(2);
    }

    public void ExitGame()
    {
        GameManager.Instance.SaveGame();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif  
    }
}
