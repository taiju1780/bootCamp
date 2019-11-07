//-------------------------------------
// Script  : WastelandWoodlMove
// Name    : 木移動
// Creater : 大山 尚悟 (おおやま しょうご)
// Day     : 11 / 05
//-------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WastelandWoodlMove : MonoBehaviour
{
    Vector3 targetPos;

    Rigidbody rid;
    Vector3 direction;

    const int SPEED = -6;
    const int CIRCLESPEED = 8;

    const int deleteTime = 300;
    float sin;
    float cos;

    GameObject player;
    const int PLAYER_BACK_DELETE = 40;

    bool isHit;
    Collider collider;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isHit = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        sin = 0;
        cos = 0;

        // 各初期化
        rid = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");

        collider = GetComponent<Collider>();
        isHit = false;
    }

    private void FixedUpdate()
    {
        // 移動
        rid.velocity = direction;
    }

    // Update is called once per frame
    void Update()
    {
        // 当たった後の処理
        if (isHit)
        {
            // 当たり判定をなしにする
            collider.enabled = false;
            // 移動
            direction = new Vector3(0, 1 * SPEED, 0);
            // 一定数下に行くと削除
            if (transform.position.y < -PLAYER_BACK_DELETE)
            {
                Destroy(this.gameObject);
            }
        }
        // 当たっていないときの処理
        else
        {
            // サインカーブ
            sin = Mathf.Sin(Time.time * 2) * CIRCLESPEED;
            cos = Mathf.Cos(Time.time * 2) * CIRCLESPEED;

            // 移動
            direction = new Vector3(SPEED + sin, cos, 0);
        }

        // 回転
        gameObject.transform.Rotate(new Vector3(0, 0, 360) * Time.deltaTime);

        // 時間後削除
        if (transform.position.x < player.transform.position.x - PLAYER_BACK_DELETE)
        {
            Destroy(this.gameObject);
        }
    }
}
