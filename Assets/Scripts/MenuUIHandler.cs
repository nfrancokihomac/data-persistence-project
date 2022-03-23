using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    //public TextMeshProUGUI nameEntry;
    public TMP_InputField nameEntry;
    public TextMeshProUGUI highScore;
    void Start()
    {
        //if available, insert previously used name into text entry field, and high score name and score
        if(GameManager.gameManager.nameCurrent != null)
        { 
            nameEntry.text = GameManager.gameManager.nameCurrent; //this doesn't work, need to change it
            highScore.text += GameManager.gameManager.nameHighScore + " : " + GameManager.gameManager.highScore;
        }
        
    }

    public void StartButton(){
        GameManager.gameManager.nameCurrent = nameEntry.text;
        GameManager.gameManager.Save();
        SceneManager.LoadScene(1);
    }

    public void QuitButton(){
        GameManager.gameManager.nameCurrent = nameEntry.text;
        GameManager.gameManager.Save();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
