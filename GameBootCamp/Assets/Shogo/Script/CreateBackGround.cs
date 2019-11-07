//-------------------------------------
// Script  : CreateBackGround
// Name    : 背景の作成
// Creater : 大山 尚悟 (おおやま しょうご)
// Day     : 11 / 05
//-------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBackGround : MonoBehaviour
{
    [SerializeField,Tooltip("背景")]
    GameObject gameObject;
    [SerializeField, Tooltip("サイズ")]
    int size;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < size; i++)
        {
            Instantiate(gameObject, new Vector3(i * 75, 3.0f, 5.0f), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
