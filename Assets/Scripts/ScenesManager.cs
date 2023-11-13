using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    [SerializeField] string mainGame;

    private void Start()
    {
        
    }

    public void LoadMainGame()
    {
        SceneManager.LoadScene(mainGame);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void TitleScreen()
    {        
        SceneManager.LoadScene("Start");        
    }

    public void RestartGameFinal()
    {
        SceneManager.LoadScene("Infinite");
    }

}
