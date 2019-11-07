//-------------------------------------
// Script  : CreateUpWall
// Name    : 上壁の作成
// Creater : 大山 尚悟 (おおやま しょうご)
// Day     : 11 / 06
//-------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateUpWall : MonoBehaviour
{
    [SerializeField, Tooltip("壁の作成")]
    GameObject gameObject;
    [SerializeField, Tooltip("サイズ")]
    int size;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < size; i++)
        {
            Instantiate(gameObject, new Vector3(i * 40, 0, 0.0f), Quaternion.identity);
        }

        for (int i = 0; i < size; i++)
        {
            Instantiate(gameObject, new Vector3(i * 40, -25, 0.0f), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
