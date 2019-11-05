using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAnyKey : MonoBehaviour
{
    SceneChange sceneChange;
    // Start is called before the first frame update
    void Start()
    {
        sceneChange = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<SceneChange>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKey)
        {
            if(sceneChange != null)
            {
                sceneChange.ChangeScene();
            }
        }
    }
}
