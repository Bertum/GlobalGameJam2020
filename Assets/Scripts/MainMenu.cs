using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject creditsPanel;
    public void GoPlay() 
    {
        SceneManager.LoadScene("Game");
    }
    public void GoExit() 
    {
        Application.Quit();
    }
    public void GoCredits() 
    {
        creditsPanel.SetActive(true);
    }
    public void CloseCredits() {
        creditsPanel.SetActive(false);
    }
    public void GoRanking() 
    {
        SceneManager.LoadScene("Ranking");
    }
}
