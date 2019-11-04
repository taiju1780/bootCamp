using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Move : MonoBehaviour
{
    [SerializeField] private float rotaspeed;
    [SerializeField] private float speed;
    [SerializeField] private float gravity;
    [SerializeField] private bool rotaright = false;
    [SerializeField] private bool rotaleft = false;
    [SerializeField] private bool rotaup = false;
    [SerializeField] private bool rotadown = false;
    [SerializeField] private float sticRange = 0.7f;
    [SerializeField] private float rotalimit = 2.0f;

    private Rigidbody rb;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rotaspeed = 0;
        speed = 4;
        gravity = 3;
    }

    // Update is called once per frame
    void Update()
    {
        float rotaHorizontal = Input.GetAxis("Horizontal2");
        float rotaVertical = Input.GetAxis("Vertical2");
        float viasHorizontal = Input.GetAxis("Horizontal");

        if (rotaHorizontal >= sticRange)
        {
            rotaright = true;
        }
        if (rotaHorizontal <= -sticRange)
        {
            rotaleft = true;
        }
        if (rotaVertical >= sticRange)
        {
            rotadown = true;
        }
        if (rotaVertical <= -sticRange)
        {
            rotaup = true;
        }

        RotaCheck();

        transform.Rotate(new Vector3(0, rotaspeed * 2, 0));
        
        if(rotaspeed <= rotalimit)
        {
            rb.velocity = new Vector3(speed + viasHorizontal, rotaspeed - gravity * 2, 0);
        }
        else
        {
            rb.velocity = new Vector3(speed + viasHorizontal, rotaspeed - gravity, 0);
        }
        rotaspeed *= 0.995f;
    }


    //フラグすべて立っていたら回転速度を上げる
    private void RotaCheck() { 
        if(rotaright && rotaleft && rotaup && rotadown)
        {
            rotaspeed += 2;
            rotaright = false;
            rotaleft = false;
            rotaup = false;
            rotadown = false;
        }
    }

}
