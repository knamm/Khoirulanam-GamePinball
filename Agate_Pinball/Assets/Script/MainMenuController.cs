using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public Button playButton;
    public Button exitButton;
    public Button creditButton;
    

    private void Start()
    {
        playButton.onClick.AddListener(PlayGame);
        exitButton.onClick.AddListener(ExitGame);
        creditButton.onClick.AddListener(Credit);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Main");
    }
    private void ExitGame()
    {
        Application.Quit();
    }
    public void Credit()
    {
        SceneManager.LoadScene("Credit");
    }
}
