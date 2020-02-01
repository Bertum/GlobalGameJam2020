using UnityEngine;

public class GameController : MonoBehaviour
{
    private bool stopped;
    private float timePlayed;

    private void Awake()
    {
        stopped = false;
    }

    void Update()
    {
        //TODO: change to use the input manager
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            stopped = !stopped;
            if (stopped)
                Time.timeScale = 0;
            else
                Time.timeScale = 1;
        }
        timePlayed += Time.deltaTime;
    }
}
