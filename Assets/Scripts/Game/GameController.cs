using UnityEngine;

public class GameController : MonoBehaviour
{
    private bool stopped;
    private float timePlayed;
    public GameObject escMenu;
    public GameObject player;

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
    }
}