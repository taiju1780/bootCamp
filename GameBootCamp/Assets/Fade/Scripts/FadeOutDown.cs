using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOutDown : MonoBehaviour
{
    FadeImage fade;

    // Start is called before the first frame update
    void Start()
    {
        fade = GameObject.FindGameObjectWithTag("Fade").GetComponent<FadeImage>();
        fade.Range = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (fade.Range <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            fade.Range -= 0.02f;
        }
    }
}
