using UnityEngine;

public class GameController : MonoBehaviour
{
    private bool stopped;
    public float timePlayed;
    public GameObject escMenu;

    private void Awake()
    {
        escMenu.SetActive(false);
        stopped = false;
    }

    void Update()
    {
        //TODO: change to use the input manager
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            stopped = !stopped;
            escMenu.SetActive(stopped);
            if (stopped)
                Time.timeScale = 0;
            else
                Time.timeScale = 1;
        }
        timePlayed += Time.deltaTime;
    }
}
