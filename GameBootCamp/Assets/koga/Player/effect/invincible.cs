using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invincible : MonoBehaviour
{
    [SerializeField] private float speed = 20;
    //リジッドボディ
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //回転
        transform.Rotate(new Vector3(0, speed, 0));
    }
}
