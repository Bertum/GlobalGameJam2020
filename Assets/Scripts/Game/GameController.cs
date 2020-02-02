using System;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private bool stopped;
    private bool gameFinished;
    [HideInInspector]
    public float timePlayed;
    public GameObject escMenu;
    public GameObject endGameMenu;
    public GameObject uiMenu;
    public GameObject player;
    public Text TimePlayedText;
    private TimeSpan timeSpan;
    private AudioSource _audioSource;
    //public AudioClip audioClipEndGame;

    private void Awake()
    {
        this._audioSource = GetComponent<AudioSource>();
        escMenu.SetActive(false);
        stopped = false;
        gameFinished = false;
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
        if (!gameFinished)
        {
            timePlayed += Time.deltaTime;
            timeSpan = TimeSpan.FromSeconds((double)new decimal(timePlayed));
            TimePlayedText.text = $"{timeSpan.Minutes}:{timeSpan.Seconds}";
        }
    }

    public void EndGame()
    {
        gameFinished = true;
        uiMenu.SetActive(false);
        endGameMenu.SetActive(true);
        FindObjectOfType<InGameMenu>().SetTitle();
        //this._audioSource.clip = this.audioClipEndGame;
        //this._audioSource.Play();
    }
}
