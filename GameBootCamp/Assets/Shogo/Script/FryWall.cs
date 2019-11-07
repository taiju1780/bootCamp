//-------------------------------------
// Script  : FryWall
// Name    : 壁の吹っ飛び
// Creater : 大山 尚悟 (おおやま しょうご)
// Day     : 11 / 07
//-------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FryWall : MonoBehaviour
{
    GameObject obj;
    Collider coll;
    Rigidbody rid;
    Vector3 direction;
    float dis;

    bool isHit;
    const int SPEED = 10;
    float size;

    private void FixedUpdate()
    {
        // 移動
        rid.velocity = direction;
    }

    // Start is called before the first frame update
    void Start()
    {
        obj = GameObject.FindGameObjectWithTag("Chaser");
        coll = GetComponent<Collider>();
        rid = GetComponent<Rigidbody>();
        size = 1;
    }

    // Update is called once per frame
    void Update()
    {
        // サインカーブ
        float sin = Mathf.Sin(1.0f * Mathf.PI * 20.0f * Time.time);
        float cos = Mathf.Cos(1.0f * Mathf.PI * 1.0f * Time.time);

        dis = Vector3.Distance(obj.transform.position, transform.position);

        Debug.Log(dis);

        if(dis < 4)
        {
            isHit = true;
        }

        if (isHit)
        {
            // 回転
            transform.Rotate(new Vector3(0, 1800, 0) * Time.deltaTime);
            // 移動
            direction = new Vector3(1 * SPEED, sin, 0);

            coll.enabled = false;

            size -= 0.1f;
            transform.localScale = new Vector3(size, size, size);
            if (transform.localScale.x < 0) { transform.localScale = new Vector3(0.0f, transform.localScale.y, transform.localScale.z); }
            if (transform.localScale.y < 0) { transform.localScale = new Vector3(transform.localScale.x, 0.0f, transform.localScale.z); }
            if (transform.localScale.z < 0) { transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, 0.0f); }
        }
    }
}
