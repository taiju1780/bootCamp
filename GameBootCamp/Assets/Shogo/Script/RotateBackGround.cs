//-------------------------------------
// Script  : RotateBackGround
// Name    : 背景の回転
// Creater : 大山 尚悟 (おおやま しょうご)
// Day     : 11 / 05
//-------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBackGround : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.Euler(90, 0, 180);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
