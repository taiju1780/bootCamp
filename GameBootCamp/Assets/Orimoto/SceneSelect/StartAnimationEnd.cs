﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAnimationEnd : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AnimationEnd()
    {
        Animator animator = GetComponent<Animator>();
        animator.SetBool("select",true);
    }

}
