using System;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private bool stopped;
    [HideInInspector]
    public float timePlayed;
    public GameObject escMenu;
    public GameObject player;
    public Text TimePlayedText;
    private TimeSpan timeSpan;

    private void Awake()
    {
        escMenu.SetActive(false);
        stopped = false;
        this.player.GetComponent<CharacterControlSystem>().Pause += context =>
        {
            if (context.performed)
            {
                stopped = !stopped;
                escMenu.SetActive(stopped);
                if (stopped)
                    Time.timeScale = 0;
                else
                    Time.timeScale = 1;
            }
        };
    }

    void Update()
    {
        timePlayed += Time.deltaTime;
        timeSpan = TimeSpan.FromSeconds(timePlayed);
        TimePlayedText.text = $"{timeSpan.Minutes}:{timeSpan.Seconds}";
    }
}
