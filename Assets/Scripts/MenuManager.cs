using UnityEngine;

public class MenuManager : MonoBehaviour
{

    public GameObject escMenuPrefab;
    public GameObject endMenuPrefab;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            escMenuPrefab.SetActive(true);
        }
    }
}
