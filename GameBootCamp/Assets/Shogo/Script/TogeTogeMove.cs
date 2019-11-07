//-------------------------------------
// Script  : TogeTogeMove
// Name    : とげの移動
// Creater : 大山 尚悟 (おおやま しょうご)
// Day     : 11 / 04
//-------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TogeTogeMove : MonoBehaviour
{
    Rigidbody rid;
    Vector3 direction;

    int time;

    const float t = 4.0f;
    const float f = 1.0f / t;

    [SerializeField,Tooltip("スピードと向き")]
    float speed;
    float sin;

    const int SPEED = -5;

    // Start is called before the first frame update
    void Start()
    {
        rid = GetComponent<Rigidbody>();

        sin = 0;
        time = 0;
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
        time++;

        // サインカーブ
        sin = Mathf.Sin(2 * Mathf.PI * f * Time.time);

        // 移動
        direction = new Vector3(0, sin * speed, 0);

        // 回転
        gameObject.transform.Rotate(new Vector3(0, 90, 0) * Time.deltaTime);

    }
}
