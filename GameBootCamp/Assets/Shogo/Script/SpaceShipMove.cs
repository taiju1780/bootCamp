//-------------------------------------
// Script  : SpaceShipMove
// Name    : 宇宙船の移動
// Creater : 大山 尚悟 (おおやま しょうご)
// Day     : 11 / 06
//-------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipMove : MonoBehaviour
{
    Rigidbody rid;
    Vector3 direction;

    const int SPEED = -2;

    int rand;
    const int MAX_RANDOM = 15;
    const int MIN_RANDOM = 1;
    bool isPlusMinus;

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
        // 出現時の位置によってサインの向きを変更
        if (transform.position.y < 0)
        {
            isPlusMinus = false;
        }
        else
        {
            isPlusMinus = true;
        }

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
        // 当たっていないときのの処理 
        else
        {
            // ランダム
            rand = Random.Range(MIN_RANDOM, MAX_RANDOM);

            // サインカーブ
            float sin = Mathf.Sin(2 * Mathf.PI * 0.5f * Time.time);
            float cos = Mathf.Cos(2 * Mathf.PI * 2.0f * Time.time);

            // 移動
            if (isPlusMinus)
            {
                direction = new Vector3((cos * 2) + (1 * SPEED), sin * rand, 0);
            }
            else
            {
                direction = new Vector3((cos * 2) + (1 * SPEED), -sin * rand, 0);
            }
        }

        // 時間後削除
        if (transform.position.x < player.transform.position.x - PLAYER_BACK_DELETE)
        {
            Destroy(this.gameObject);
        }
    }
}