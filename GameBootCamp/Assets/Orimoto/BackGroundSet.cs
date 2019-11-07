using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackGroundSet : MonoBehaviour
{
    Animator animator;
    Image Image;
    [SerializeField] Sprite sprite;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        if(Image == null)
        {
            Image = GameObject.Find("BackGround").GetComponent<Image>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(animator != null)
        {
            if(animator.GetBool("select"))
            {
                if(Image != null)
                {
                    Image.sprite = sprite;
                }
            }
        }
    }
}
