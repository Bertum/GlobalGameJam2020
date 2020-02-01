using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject character;
    private Transform cameraTransform;
    
    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (character.transform.position.y > 2.69 && character.transform.position.y < 48) {
            cameraTransform.position = new Vector3(0, character.transform.position.y, cameraTransform.position.z);
        }
    }
}
