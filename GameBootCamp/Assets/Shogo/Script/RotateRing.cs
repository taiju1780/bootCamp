//-------------------------------------
// Script  : RotateRing
// Name    : リングの回転
// Creater : 大山 尚悟 (おおやま しょうご)
// Day     : 11 / 07
//-------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateRing : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.Euler(0, 0, 90);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
