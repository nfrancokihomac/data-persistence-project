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
    public TextMeshProUGUI nameEntry;
    void Start()
    {
        //insert name into text entry field, if available
        if(GameManager.gameManager.name != null)
            nameEntry.text = GameManager.gameManager.name;

        //put in the high score name and score
        
    }

    public void StartButton(){
        SceneManager.LoadScene(1);
    }

    public void QuitButton(){
        //remember entered name, remember score
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
