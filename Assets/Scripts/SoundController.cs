using UnityEngine;

public class SoundController : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this);
        int numBackgroundSounds = FindObjectsOfType<SoundController>().Length;
        if (numBackgroundSounds != 1)
        {
            Destroy(this.gameObject);
        }
    }
}
