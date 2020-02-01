using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour
{
    public void GoGame()
    {
        //TODO: Close canvas
    }

    public void GoMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
