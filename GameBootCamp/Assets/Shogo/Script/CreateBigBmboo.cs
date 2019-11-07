//-------------------------------------
// Script  : CreateBigBmboo
// Name    : 竹の作成
// Creater : 大山 尚悟 (おおやま しょうご)
// Day     : 11 / 07
//-------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBigBmboo : MonoBehaviour
{
    [SerializeField, Tooltip("現在のシーン")]
    int nowScene;
    [SerializeField, Tooltip("大きい竹")]
    GameObject bigBmboo;


    // Start is called before the first frame update
    void Start()
    {
        bigBmboo.transform.localScale = new Vector3(10, 10, 10);
        switch (nowScene)
        {
            case 0:
                Instantiate(bigBmboo, new Vector3(200, 0, 0), new Quaternion(0, 180, 0, 0));
                break;
            case 1:
                Instantiate(bigBmboo, new Vector3(250, 0, 0), new Quaternion(0, 180, 0, 0));
                Instantiate(bigBmboo, new Vector3(500, 0, 0), new Quaternion(0, 180, 0, 0));
                break;
            case 2:
                Instantiate(bigBmboo, new Vector3(250, 0, 0), new Quaternion(0, 180, 0, 0));
                Instantiate(bigBmboo, new Vector3(450, 0, 0), new Quaternion(0, 180, 0, 0));
                Instantiate(bigBmboo, new Vector3(600, 0, 0), new Quaternion(0, 180, 0, 0));
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
