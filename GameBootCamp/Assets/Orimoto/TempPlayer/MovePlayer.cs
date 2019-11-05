using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    private Rigidbody rigid;
    float moveSpeed;
    Vector3 upVec;
    Vector3 downVec;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        upVec = new Vector3(0.0f,8.0f,0.0f);
        downVec = new Vector3(0.0f, -4.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            rigid.velocity += upVec;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += transform.right * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += transform.right * -moveSpeed * Time.deltaTime;
        }

        rigid.velocity += downVec;
    }
}
