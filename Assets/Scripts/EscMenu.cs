using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscMenu : MonoBehaviour
{
    public void GoReset()
    {
        //TODO: Reset the game
    }
    
    public void GoMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
