//-------------------------------------
// Script  : SpaceArtificialSatelliteMove
// Name    : 人工衛星の移動
// Creater : 大山 尚悟 (おおやま しょうご)
// Day     : 11 / 06
//-------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceArtificialSatelliteMove : MonoBehaviour
{
    Rigidbody rid;
    Vector3 direction;

    const float t = 4.0f;
    const float f = 1.0f / t;

    [SerializeField, Tooltip("スピードと向き")]
    float speed;
    [SerializeField, Tooltip("横移動向き"), Range(-1, 1)]
    int rotate;

    float sin;
    float cos;
    const int SPEED = -5;

    // Start is called before the first frame update
    void Start()
    {
        rid = GetComponent<Rigidbody>();

        sin = 0;
        cos = 0;
    }

    private void FixedUpdate()
    {
        //gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);

        // 移動
        rid.velocity = direction;
    }

    // Update is called once per frame
    void Update()
    {
        // サインカーブ
        sin = Mathf.Sin(2 * Mathf.PI * f * Time.time);
        // サインカーブ
        cos = Mathf.Cos(2 * Mathf.PI * f * Time.time);

        // 移動
        direction = new Vector3(cos * rotate, sin * speed, 0);

        // 回転
        gameObject.transform.Rotate(new Vector3(0, 90, 0) * Time.deltaTime);

    }
}
