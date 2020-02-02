using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InGameMenu : MonoBehaviour
{
    public Text NameForRanking;
    public Text Title;
    private RankingController rankingController;
    private GameController gameController;

    private void Awake()
    {
        gameController = FindObjectOfType<GameController>();
        rankingController = FindObjectOfType<RankingController>();
    }

    public void GoGame()
    {
        rankingController.SaveRanking(NameForRanking.text, gameController.timePlayed);
        SceneManager.LoadScene("Game");
    }

    public void GoMenu()
    {
        rankingController.SaveRanking(NameForRanking.text, gameController.timePlayed);
        SceneManager.LoadScene("MainMenu");
    }

    public void SetTitle()
    {
        var timeSpan = TimeSpan.FromSeconds(gameController.timePlayed);
        Title.text = $"You have survived  {timeSpan.Minutes}:{timeSpan.Seconds}";
    }
}
