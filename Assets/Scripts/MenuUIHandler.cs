using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public Text bestScoreText;
    public int bestScore;
    public string bestPlayer;
    // Start is called before the first frame update
    void Start()
    {
        bestPlayer = MainGameManager.Instance.playerName;
        bestScore = MainGameManager.Instance.highScore;
        if (bestScore != 0)
        {
            bestScoreText.text = "Best Score : " + bestPlayer + " : " + bestScore;
        }
        MainGameManager.Instance.LoadInputName();
    }

    public void StartNewScene() 
    {
        SceneManager.LoadScene(1);
    }

    public void ReadInputField(string name) 
    {
        MainGameManager.Instance.playerName = name;
    }

    public void ExitApplicaiton() 
    {
        MainGameManager.Instance.SaveInputName();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
}
