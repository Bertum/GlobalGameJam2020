using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoReset()
    {
        //TODO: Reset the game
    }
    
    public void GoMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
