using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject creditsPanel;
    public GameObject rankingPanel;
    public Text rankingText;
    private RankingController rankingController;

    private void Awake()
    {
        creditsPanel.SetActive(false);
        rankingPanel.SetActive(false);
        rankingController = FindObjectOfType<RankingController>();
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
        creditsPanel.SetActive(true);
    }
    public void CloseCredits()
    {
        creditsPanel.SetActive(false);
    }

    public void CloseRanking()
    {
        rankingPanel.SetActive(false);
    }

    public void GoRanking()
    {
        rankingText.text = rankingController.GetRankingForText();
        rankingPanel.SetActive(true);
    }
}
