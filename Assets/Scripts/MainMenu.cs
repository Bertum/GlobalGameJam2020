using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

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
        SceneManager.LoadScene("Credits");
    }
    public void GoRanking() 
    {
        SceneManager.LoadScene("Ranking");
    }
}
