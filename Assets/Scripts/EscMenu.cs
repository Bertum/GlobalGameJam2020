﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class EscMenu : MonoBehaviour
{
    public GameObject menu;
    public void GoReset()
    {
        menu.SetActive(false);
        Time.timeScale = 1;
    }

    public void GoMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
