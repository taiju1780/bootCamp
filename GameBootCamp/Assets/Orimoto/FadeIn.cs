using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIn : MonoBehaviour
{
    FadeImage fadeImage;
    [SerializeField] float fadeSpeed;

    // Start is called before the first frame update
    void Start()
    {
        fadeImage = GameObject.Find("FadeCanvas").GetComponent<FadeImage>();
        fadeImage.Range = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(fadeImage.Range > 0)
        {
            if (fadeImage != null)
            {
                StartCoroutine(Fadein());
            }
        }
    }

    IEnumerator Fadein()
    {
        while (fadeImage.Range > 0)
        {
            fadeImage.Range -= fadeSpeed;
            yield return null;
        }
    }
}
