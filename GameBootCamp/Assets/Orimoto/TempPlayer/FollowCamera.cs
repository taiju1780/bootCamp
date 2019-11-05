using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    GameObject followCamera;
    Vector3 cameraBeforePos;
    // Start is called before the first frame update
    void Start()
    {
        followCamera = GameObject.FindGameObjectWithTag("MainCamera");
        if(followCamera != null)
        {
            cameraBeforePos = followCamera.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(followCamera != null)
        {
            transform.position += followCamera.transform.position - cameraBeforePos;
            cameraBeforePos = followCamera.transform.position;
        }
    }
}
