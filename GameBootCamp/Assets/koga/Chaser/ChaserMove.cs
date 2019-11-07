using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserMove : MonoBehaviour
{
    //移動速度
    [SerializeField] private float speed;
    [SerializeField] private GameObject player;
    private Move move;

    //リジッドボディ
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        transform.position = player.transform.position - new Vector3(15, 0, 0);
        speed = 1;
        Sound.LoadBGM("typoon", "wind2");
        Sound.PlayBGM("typoon");
    }

    // Update is called once per frame
    void Update()
    {
        move = player.GetComponent<Move>();

        if (move.GetDieFlag())
        {
            speed = 0;
        }

        var offset = player.transform.position - transform.position;
        if (!move.GetDieFlag())
        {
            if (offset.x >= 15)
            {
                speed = 5;
            }
            if (offset.x <= 14 && offset.x >= 10)
            {
                speed = 3;
            }
            if (offset.x <= 9)
            {
                speed = 2;
            }
        }
        rb.velocity = new Vector3(speed, 0, 0);

        //回転
        transform.Rotate(new Vector3(0, 10, 0));
    }
}
