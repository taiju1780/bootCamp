//-------------------------------------
// Script  : CrowMove
// Name    : カラス移動
// Creater : 大山 尚悟 (おおやま しょうご)
// Day     : 11 / 04
//-------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowMove : MonoBehaviour
{

    Rigidbody rid;
    Vector3 direction;

    const int SPEED = -5;

    int time;
    const int deleteTime = 300;

    // Start is called before the first frame update
    void Start()
    {
        // 各初期化
        rid = GetComponent<Rigidbody>();
        time = 0;
    }

    private void FixedUpdate()
    {
        // 左向き
        gameObject.transform.rotation = new Quaternion(0, 180, 0, 0);
        
        // 移動
        rid.velocity = direction;
    }

    // Update is called once per frame
    void Update()
    {
        time++;

        // 移動
        direction = new Vector3(1 * SPEED, 0, 0);

        // 時間後削除
        if (time > deleteTime)
        {
            Destroy(this.gameObject);
        }
    }
}
